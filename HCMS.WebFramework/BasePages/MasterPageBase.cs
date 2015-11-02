using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System.Threading;
using System.Web.UI;

using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.Business.Lookups.Collections;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.PD;
using HCMS.Business.Common;
namespace HCMS.WebFramework.BasePages
{

    

   
    [Serializable]
    public enum PDControlType
    {
        Other = 0,
        PDTypeChoice = 1,
        Occupation = 2,
        Duties = 3,
        Characteristics = 4,
        Factors = 5,
        Approvals = 6,
        SOD = 7
    }

    public abstract class MasterPageBase : MasterPage, IMasterPageBase 
    {
        private const string CURRENTPDACCESSTYPE = "CurrentPDAccessType";
        private const string ISVIEWONLY = "IsViewOnly";


        #region IMasterPageBase Members

        public abstract string PageTitle
        {
            get;
            set;
        }

        #endregion

        public abstract PDControlType PDControlName
        {
            get;
            set;
        }

        public abstract LeftMenuType LeftMenu
        {
            get;
            set;
        }

        public abstract bool ShowRequiredFieldMessage
        {
            get;
            set;
        }

        public abstract bool ShowInformationDiv
        { get; set; }
        public abstract bool ShowLeftMenu
        {
            get;
            set;
        }
        public abstract bool ShowTopMenu
        { get; set; }
        
        public abstract bool ShowProgressBar
        { get; set; }
        public abstract enumProgressBarItem SelectProgressBar
        { get; set; }
        public abstract enumProgressBarItem ProgressBar
        { get; set; }

        public abstract enumTopMenuItem SelectTopMenuItem
        { get; set; }
        public abstract enumLeftMenuItem SelectLeftMenuItem
        { get; set; }

        public abstract enumTopMenuItem DisableTopMenuItem
        { get; set; }

        public abstract enumTopMenuType TopMenuType
        { get; set; }


        public abstract enumFooterType FooterType
        { get; set; }

        public abstract enumMenuType SubMenuType
        {
            get;
            set;
        }

        public abstract enumMenuItem SelectSubMenuItem
        {
            get;
            set;
        }
        public abstract bool ShowSubMenu
        {
            get;
            set;
        }
        public abstract void PrintSystemMessage(string message);
        public abstract void PrintSystemMessage(string message, bool showContentPane);
        public abstract void PrintErrorMessage(string message);
        public abstract void PrintErrorMessage(string message, bool showContentPane);
        public abstract void PrintErrorMessage(Exception ex);
        public abstract void PrintErrorMessage(Exception ex, bool showContentPane);

        private const string CURRENTPERMISSIONS = "CurrentPermissions";
        protected PermissionCollection CurrentPermissions
        {
            get
            {

                if (Session[CURRENTPERMISSIONS] == null)
                {
                    Session[CURRENTPERMISSIONS] = CurrentUser.GetPermissions();

                }
                return (PermissionCollection)Session[CURRENTPERMISSIONS];
            }
        }
        protected bool HasPermission(enumPermission permissionEnumID)
        {
            bool haspermission = false;
            if (CurrentUser != null)
            {
                PermissionCollection currentPermColl = CurrentPermissions;
                if (currentPermColl.Contains(enumPermission.AllSystemAdministrationPermissions) || (currentPermColl.Contains((int)permissionEnumID)))
                {
                    haspermission = true;
                }
            }

            return haspermission;
        }

        protected bool IsSystemAdministrator
        {
            get
            {
                return HasPermission(enumPermission.AllSystemAdministrationPermissions);
            }
        }
        protected bool IsAdmin
        {
            get
            {
                bool returnValue = false;

                if (HasPermission(enumPermission.MaintainUserAccounts) && HasPermission(enumPermission.DelegatePD) && HasPermission(enumPermission.ActivateDeactivatePD))
                    returnValue = true;

                return returnValue;
            }
        }     
        protected User CurrentUser
        {
            get
            {
                if (ViewState["CurrentUser"] == null)
                    ViewState["CurrentUser"] = new User(SiteUtility.CurrentIdentityUser().UserID);

                return (User)ViewState["CurrentUser"];
            }
        }
      

        #region PD Access Status

        protected bool IsPDReadOnly
        {
            get
            {
                return this.CurrentPDAccessType == PDAccessType.None || this.CurrentPDAccessType == PDAccessType.ReadOnly;
            }
        }
        protected PositionDescription CurrentPD
        {
            get
            {
                return SiteUtility.CurrentPD;
            }
        }
        protected bool IsViewOnly
        {
            get
            {
                if (Session[ISVIEWONLY] == null)
                    Session[ISVIEWONLY] = false;

                return (bool)Session[ISVIEWONLY];
            }
        }

        protected PDAccessType CurrentPDAccessType
        {
            get
            {
                PDAccessType accessLevel = ReEvaluatePDAccessStatus(false);

                // if the user selected VIEW and the access level is WRITE 
                // then change to Read-Only OTHERWISE return calculated access level
                return this.IsViewOnly && accessLevel == PDAccessType.Write ? PDAccessType.ReadOnly : accessLevel;
            }
        }

        protected PDAccessType ReEvaluatePDAccessStatus(bool reEvaluate)
        {
            // tighten permissions and only upgrade if user has valid permissions
            PDAccessType access = PDAccessType.None;

            if (Session[CURRENTPDACCESSTYPE] == null || reEvaluate)
            {
                try
                {
                    PositionDescription thisPD = SiteUtility.CurrentPD;
                    access = SiteUtility.GetPDAccessType(thisPD);

                }
                catch (Exception ex)
                {
                    this.HandleException(ex);
                }

                Session[CURRENTPDACCESSTYPE] = access;
            }

            return (PDAccessType)Session[CURRENTPDACCESSTYPE];
        }

        #endregion

        #region Exception Handling

        /// <summary>
        /// Handle exception (ignores thread abort exception)
        /// </summary>
        /// <param name="ex">The exception to be handled</param>
        public void HandleException(Exception ex)
        {
            this.HandleException(ex, false);
        }

        /// <summary>
        /// Handle exception (ignores thread abort exception)
        /// </summary>
        /// <param name="ex">The exception to be handled</param>
        /// <param name="showContentPane">Boolean value that determines whether the content pane is visible</param>
        public void HandleException(Exception ex, bool showContentPane)
        {
            if (!(ex is ThreadAbortException))
            {
                StringBuilder exceptionMessage = new StringBuilder(string.Concat("[Error Encountered]:  ", ex.ToString()));

                if (ex.InnerException != null)
                    exceptionMessage.Append(string.Concat("-- Inner: ", ex.InnerException.Message));

                this.PrintErrorMessage(Request.QueryString["showError"] == "1" ? exceptionMessage.ToString() : ex.Message, showContentPane);
                LogExceptionOnly(exceptionMessage.ToString());
            }
        }

        public void LogExceptionOnly(string exceptionMessage)
        {
            LogEntry entry = new LogEntry();
            entry.Message = exceptionMessage;
            entry.EventId = 80;
            entry.MachineName = System.Environment.UserName + "/" + System.Environment.MachineName;
            entry.TimeStamp = DateTime.Now;

            // log the exception to some destination (log file, event log, etc.)
            Logger.Write(entry);
        }

        #endregion
    }
}
