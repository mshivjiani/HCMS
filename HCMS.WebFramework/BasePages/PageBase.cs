using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.IO;
using System.Threading;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.Caching;

using HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Security;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.WebFramework.BasePages
{
    public abstract class PageBase : Page
    {
        protected const int NULLKEYID = -1;

        #region Common Properties
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
        protected bool IsAdministrator
        {
            get
            {
                bool returnValue = false;

                if (HasPermission(enumPermission.MaintainUserAccounts) && HasPermission(enumPermission.DelegatePD) && HasPermission(enumPermission.ActivateDeactivatePD))
                    returnValue = true;

                return returnValue;
            }
        }
        protected bool HasValidQuerystrings
        {
            get
            {
                if (ViewState["HasValidQuerystrings"] == null)
                    ViewState["HasValidQuerystrings"] = true;

                return (bool)ViewState["HasValidQuerystrings"];
            }
            set
            {
                ViewState["HasValidQuerystrings"] = value;
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



        //protected override void OnPreRender(EventArgs e)
        //{
        //    base.OnPreRender(e);
        //    this.Page.Header.Controls.Add(new LiteralControl(
        //        String.Format("<meta http-equiv='refresh' content='{0};url={1}'>",
        //        Session.Timeout * 60000, "~/common/Timeout.aspx")));
        //}
        #endregion
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);

        }

        protected override void OnPreRender(EventArgs e)
        {
            base.OnPreRender(e);
        }
        protected override void OnLoad(EventArgs e)
        {
            if (!this.HasValidQuerystrings)
                this.PageTitle += " -- Invalid Parameter";
            else
                base.OnLoad(e);
        }

        protected virtual void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_Error(object sender, EventArgs e)
        {
            Exception ex = Server.GetLastError();
            if (ex is HttpRequestValidationException)
            {
                PrintErrorMessage("Request Server with illegal character");
                Server.ClearError(); // ClearError() stop bubble up to Application_Error()。
            }

        }
        #region Master Functionality

        #region Properties

        protected string PageTitle
        {
            get
            {
                string pgtitle = string.Empty;
                if (this.Page.Master != null)
                {
                    pgtitle = ((MasterPageBase)Master).PageTitle;
                }
                else
                { 
                    pgtitle = this.Page.Title; 
                }
                return pgtitle;
            }
            set
            {
                if (this.Page.Master != null)
                {
                    ((MasterPageBase)Master).PageTitle = value;
                }
                else
                {
                    this.Page.Title = value;
                }

            }
        }

        protected PDControlType PDControlName
        {
            get
            {
                return ((MasterPageBase)Master).PDControlName;
            }
            set
            {
                ((MasterPageBase)Master).PDControlName = value;
            }
        }

        protected LeftMenuType LeftMenu
        {
            get
            {
                return ((MasterPageBase)Master).LeftMenu;
            }
            set
            {
                ((MasterPageBase)Master).LeftMenu = value;
            }
        }

        protected bool ShowRequiredFieldMessage
        {
            set
            {
                ((MasterPageBase)Master).ShowRequiredFieldMessage = value;
            }
        }

        protected bool ShowInformationDiv
        {
            get { return ((MasterPageBase)Master).ShowInformationDiv; }
            set { ((MasterPageBase)Master).ShowInformationDiv = value; }
        }
        protected bool ShowLeftMenu
        {
            set
            {
                ((MasterPageBase)Master).ShowLeftMenu = value;
            }
        }
        protected bool ShowSubMenu
        {
            get { return ((MasterPageBase)Master).ShowSubMenu; }
            set
            {
                ((MasterPageBase)Master).ShowSubMenu = value;
            }
        }

        protected bool ShowTopMenu
        {
            get { return ((MasterPageBase)Master).ShowTopMenu; }
            set
            {
                ((MasterPageBase)Master).ShowTopMenu = value;
            }
        }
        protected enumFooterType FooterType
        {
            get { return ((MasterPageBase)Master).FooterType; }
            set { ((MasterPageBase)Master).FooterType = value; }
        }

        protected enumMenuType SubMenuType
        {
            get { return ((MasterPageBase)Master).SubMenuType; }
            set { ((MasterPageBase)Master).SubMenuType = value; }
        }

        protected enumMenuItem SelectSubMenuItem
        {
            get { return ((MasterPageBase)Master).SelectSubMenuItem; }
            set { ((MasterPageBase)Master).SelectSubMenuItem = value; }
        }
        #endregion

        #region Methods

        public void PrintSystemMessage(string message)
        {
            this.PrintSystemMessage(message, false);
        }

        public void PrintSystemMessage(string message, bool showContentPane)
        {
            ((MasterPageBase)Master).PrintSystemMessage(message, showContentPane);
        }

        public void PrintErrorMessage(string message)
        {
            this.PrintErrorMessage(message, false);
        }

        public void PrintErrorMessage(string message, bool showContentPane)
        {
            ((MasterPageBase)Master).PrintErrorMessage(message, showContentPane);
        }

        public void PrintErrorMessage(Exception ex)
        {
            this.PrintErrorMessage(ex, false);
        }

        public void PrintErrorMessage(Exception ex, bool showContentPane)
        {
            ((MasterPageBase)Master).PrintErrorMessage(ex, showContentPane);
        }

        #endregion

        #region Exception Handling

        protected void HandleException(Exception ex)
        {
            this.HandleException(ex, false);
        }

        protected void HandleException(Exception ex, bool showContentPane)
        {
            ((MasterPageBase)Master).HandleException(ex, showContentPane);
        }

        protected void LogExceptionOnly(string exceptionMessage)
        {
            ((MasterPageBase)Master).LogExceptionOnly(exceptionMessage);
        }

        #endregion

        #endregion

        #region Common Methods

        protected virtual bool HasValidIntegerQueryStrings()
        {
            bool queryStringsOK = true;

            foreach (string singleQS in Request.QueryString.Keys)
            {
                // checks to make sure that all querystrings are valid integers
                if (singleQS.ToLower() != "returnurl")
                {
                    if (!ValidationUtility.IsValidInteger(Request.QueryString[singleQS]))
                    {
                        queryStringsOK = false;
                        break;
                    }
                }
            }

            this.HasValidQuerystrings = queryStringsOK;
            return queryStringsOK;
        }

        protected void SafeRedirect(string newURL)
        {
            try
            {
                Response.Redirect(newURL, true);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        protected void GoToAccessDeniedPage()
        {
            this.SafeRedirect("~/common/accessDenied.aspx");
        }


        protected bool isPDCreatorSupervisor(bool refresh)
        {
            string CurrentUserIsPDCreatorSupervisor = string.Concat(CurrentUser.UserID.ToString(), SiteUtility.CurrentPDID.ToString());
            if ((Cache[CurrentUserIsPDCreatorSupervisor] == null) || (refresh))
            {
                //use insert method instead of add - to support refresh
                //add will throw an error if key already exist 
                Cache.Insert(CurrentUserIsPDCreatorSupervisor, CurrentUser.IsPDCreatorSupervisor(SiteUtility.CurrentPDID), null, DateTime.Now.AddDays(1), TimeSpan.Zero, CacheItemPriority.Normal, null);

            }
            bool isPDCreatorSupervisor = (bool)Cache[CurrentUserIsPDCreatorSupervisor];
            return isPDCreatorSupervisor;
        }


        protected string GetAppThemeUrl(string inurl)
        {
            Page currentPage = HttpContext.Current.CurrentHandler as Page;
            string themedUrl = string.Empty;
            string pageTheme = currentPage.Theme;
            if (!String.IsNullOrEmpty(pageTheme))
            {
                themedUrl = "~/App_themes/" + pageTheme + "/" + inurl;
            }
            return themedUrl;



        }
        #endregion

        [System.Web.Services.WebMethod(EnableSession = true)]
        [System.Web.Script.Services.ScriptMethod]
        public static void PokePage()
        {        // called by client to refresh session   

            String Out = String.Format("{0}  {1}", DateTime.Now.ToString("hh:mm:ss.ff"), "testing");
            System.Diagnostics.Debug.WriteLine(Out);
            System.Diagnostics.Debug.WriteLine("testing again");
            //HttpContext.Current.Session.Timeout = 20;
            HttpCookie sessionCookie = HttpContext.Current.Request.Cookies["ASP.NET_SessionId"];

            sessionCookie.Expires.AddMinutes(3);
        }

        //public static class ControlFinder{    
        //    /// <summary>    
        //    /// Similar to Control.FindControl, but recurses through child controls.    
        //    /// </summary>    
        //    public static T FindControl<T>(Control startingControl, string id) where T : Control    
        //    {                
        //        T found = startingControl.FindControl(id) as T;          
        //        if (found == null)        
        //        {            
        //            found = FindChildControl<T>(startingControl, id);        
        //        }         
        //        return found;            
        //    }     

        //    /// <summary>         
        //    /// Similar to Control.FindControl, but recurses through child controls.    
        //    /// Assumes that startingControl is NOT the control you are searching for.    
        //    /// </summary>    
        //    public static T FindChildControl<T>(Control startingControl, string id) where T : Control    
        //    {        
        //        T found = null;         
        //        foreach (Control activeControl in startingControl.Controls)        
        //        {            
        //            found = activeControl as T;             
        //            if (found == null || (string.Compare(id, found.ID, true) != 0))            
        //            {                
        //                found = FindChildControl<T>(activeControl, id);            
        //            }             
        //            if (found != null)            
        //            {                
        //                break;            
        //            }        
        //        }         
        //        return found;    
        //    }
        //}


        ///// <summary>
        ///// Find control (recursively) by type 
        ///// </summary>
        ///// <typeparam name="T"></typeparam>
        ///// <param name="controls"></param>
        ///// <returns></returns>
        //public static T FindControl<T>(System.Web.UI.ControlCollection controls, string ctrlName) where T : class
        //{
        //    T found = default(T);

        //    if (controls != null && controls.Count > 0)
        //    {
        //        for (int i = 0; i < controls.Count; i++)
        //        {
        //            if (found != null) break;
        //            //if (controls[i] is T && controls[i].ID == ctrlName)
        //            if (controls[i].ID == ctrlName)
        //            {
        //                found = controls[i] as T;
        //                break;
        //            }
        //            found = FindControl<T>(controls[i].Controls, ctrlName);
        //        }
        //    }

        //    return found;
        //}

        public static T FindControl<T>(System.Web.UI.ControlCollection controls) where T : class
        {
            T found = default(T);

            if (controls != null && controls.Count > 0)
            {
                for (int i = 0; i < controls.Count - 1; i++)
                {
                    if (found != null) break;
                    if (controls[i] is T)
                    {
                        found = controls[i] as T;
                        break;
                    }
                    found = FindControl<T>(controls[i].Controls);
                }
            }

            return found;
        }

    }
}
