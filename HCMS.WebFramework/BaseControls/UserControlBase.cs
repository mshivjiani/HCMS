using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Threading;
using System.Web.Caching;

using System.Security;
using System.Web.Security;
using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;

using HCMS.Business.PD;
using HCMS.Business.Security;
using HCMS.Business.Security.Collections;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Security;
using Telerik.Web.UI;
using Telerik.Web.UI.Editor.Diff;
using System.Data;
using HCMS.Business.Base;
using HCMS.WebFramework.BasePages;
using HCMS.Business.Admin.Workforce;


namespace HCMS.WebFramework.BaseControls
{
    #region Public enums



    public enum PDAccessType : int
    {
        None = 0,
        ReadOnly = 1,
        Write = 2
    }
    public enum enumValidationcode : int
    {
        Null = -1,
        ValidationErrors = 1,
        SignAndSubmit = 2,
        SaveAndUnlock = 3

    }
    public enum enumNavigationMode : int
    {
        None = 0,
        Insert = 1,
        Edit = 2,
        View = 3
    }
    public enum enumMenuOption : int
    {
        Null = -1,
        View = 0,
        Edit = 1,
        ContinueEdit = 2,
        FinishEdit = 3,
        Delete = 4,
        Print = 5
    }
    #endregion
    public abstract class UserControlBase : UserControl
    {
        private const string CURRENTUSERID = "CurrentUserID";
        private const string CURRENTSODFULLPERFORMANCEPD = "CurrentSODFullPerformancePD";
        private const string CURRENTASSOCIATEDPDID = "CurrentAssociatedPDID";
        private const string CURRENTPDWORKFLOWSTATUS = "CurrentPDWorkflowStatus";
        private const string CURRENTPDACCESSTYPE = "CurrentPDAccessType";
        private const string CURRENTPDCHOICE = "CurrentPDChoice";
        private const string ISVIEWONLY = "IsViewOnly";
        private const string CURRENTNAVMODE = "CurrentNavMode";
        private const string CURRENTMODE = "CurrentMode";
        private const string CURRENTPDDUTYID = "CurrentPDDutyID";
        protected const long NULLPDID = -1;
        protected const long NULLKEYID = -1;

        private const string CURRENTRULEID = "CurrentWorkflowRuleID";
        protected const int NULLRULEID = -1;

        private const string CURRENTSTAFFINGOBJECTTYPEID = "CurrentStaffingObjectTypeID";
        protected const int NULLSTAFFINGOBJECTTYPEID = -1;

        private const string CURRENTGROUPID = "CurrentGroupID";
        protected const int NULLGROUPID = -1;

        private const string CURRENTSTATUSID = "CurrentStatusID";
        protected const int NULLSTATUSID = -1;

        private const string CURRENTACTIONRECID = "CurrentActionRecID";
        protected const int NULLACTIONRECID = -1;
        private const string CURRENTPERMISSIONS = "CurrentPermissions";

        public const string OTHERKSATEXT = "Create New";
        public const string OTHERTASKSTATEMENTTEXT = "Create New";

        public const string JUSTOTHER = "Other";

        ///TODO: Refactor this const to a better name
        public const string KSA_COMBOBOX_DEFAULT = "Create from Duty Description";


        #region [ Common Properties ]
        protected long CurrentPDID
        {
            get
            {
                return SiteUtility.CurrentPDID;
            }
            set
            {
                this.ClearCurrentPD(); // prevent situation where PDID and PD/PD Status are out of synch
                SiteUtility.CurrentPDID = value;
            }
        }
        public PositionDescription CurrentPD
        {
            get
            {
                return SiteUtility.CurrentPD;
            }
        }
        protected long CurrentAssociatedPDID
        {
            get
            {
                if (Session[CURRENTASSOCIATEDPDID] == null)
                    Session[CURRENTASSOCIATEDPDID] = NULLPDID;

                return (long)Session[CURRENTASSOCIATEDPDID];
            }
            set
            {
                Session[CURRENTASSOCIATEDPDID] = value;
            }
        }
        protected long CurrentGoBackPDID
        {
            get
            {
                if (Session["CurrentGoBackPDID"] == null)
                    Session["CurrentGoBackPDID"] = NULLPDID;

                return (long)Session["CurrentGoBackPDID"];
            }
            set
            {
                Session["CurrentGoBackPDID"] = value;
            }
        }
        protected PositionDescription CurrentSODFullPerformancePD
        {
            get
            {
                if (Session[CURRENTSODFULLPERFORMANCEPD] == null)
                {
                    if (this.CurrentAssociatedPDID == NULLPDID)
                        Session[CURRENTSODFULLPERFORMANCEPD] = new PositionDescription();
                    else
                        Session[CURRENTSODFULLPERFORMANCEPD] = new PositionDescription(this.CurrentAssociatedPDID);
                }

                return (PositionDescription)Session[CURRENTSODFULLPERFORMANCEPD];
            }
        }
        public PositionWorkflowStatus CurrentPDWorkflowStatus
        {
            get
            {
                if (Session[CURRENTPDWORKFLOWSTATUS] == null)
                    Session[CURRENTPDWORKFLOWSTATUS] = this.CurrentPD.GetCurrentPositionWorkflowStatus();

                return (PositionWorkflowStatus)Session[CURRENTPDWORKFLOWSTATUS];
            }
        }

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
            set
            {
                Session[CURRENTPERMISSIONS] = value;
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
        protected bool HasPermissionExcludeAdministrator(enumPermission permissionEnumID)
        {
            bool haspermission = false;
            if (CurrentUser != null)
            {
                PermissionCollection currentPermColl = CurrentPermissions;
                if (currentPermColl.Contains((int)permissionEnumID))
                {
                    haspermission = true;
                }
            }

            return haspermission;
        }

        protected bool HasClassifier15Permission
        {
            get
            {
                return HasPermission(enumPermission.CompleteHRCertification15) || HasPermission(enumPermission.CompleteHighGradeApproval);
            }
        }

        protected bool HasHRGroupPermission
        {
            get
            {
                return (HasPermission(enumPermission.CompleteHRCertification) ||
                         HasPermission(enumPermission.MaintainEvaluationStatements) ||
                         HasPermission(enumPermission.MaintainHRSection) ||
                         HasPermission(enumPermission.MaintainFactorRecommendation) ||
                         HasPermission(enumPermission.PublishPD) ||
                         HasPermission(enumPermission.CreateStandaloneJA) ||
                         HasPermission(enumPermission.CreateStandaloneCR) ||
                         HasPermission(enumPermission.CreateStandaloneJQ) ||
                         HasPermission(enumPermission.CreateStandardJNP) ||
                         HasPermission(enumPermission.CreateCustomRatingScale) ||
                         HasPermission(enumPermission.PublishJNPackage));
            }
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

        protected User CurrentEditUser
        {
            get
            {
                if (Session["CurrentEditUser"] == null)
                    Session["CurrentEditUser"] = new User();

                return (User)Session["CurrentEditUser"];
            }
            set
            {
                Session["CurrentEditUser"] = value;
            }
        }

        protected User CurrentPDCreator
        {
            get
            {
                if (ViewState["CurrentPDCreator"] == null)
                    ViewState["CurrentPDCreator"] = new User(this.CurrentPD.PDCreatorID);

                return (User)ViewState["CurrentPDCreator"];
            }
        }
        public PDChoiceType? CurrentPDChoice
        {
            get
            {
                PDChoiceType? returnChoice = null;

                if (this.CurrentPDID == NULLPDID && Session[CURRENTPDCHOICE] != null)
                    returnChoice = (PDChoiceType)Session[CURRENTPDCHOICE];
                else
                    returnChoice = (PDChoiceType)this.CurrentPD.PositionDescriptionTypeID;

                return returnChoice;
            }
            set
            {
                Session[CURRENTPDCHOICE] = value;
            }
        }
        public bool IsStandardPD
        {
            get
            {
                string returnVal = "N";

                if (this.CurrentPDID != NULLPDID)
                    returnVal = CurrentPD.IsStandardPD;
                else
                    returnVal = (Session[CURRENTPDCHOICE] != null && this.CurrentPDChoice.Equals(PDChoiceType.NewStandardPD)) ? "Y" : "N";

                return returnVal.Equals("Y");
            }
        }
        public bool IsCL
        {
            get
            {
                bool isclpd = false;
                if (CurrentPDChoice == PDChoiceType.CareerLadderPD || CurrentPDChoice == PDChoiceType.CLStatementOfDifferencePD)
                {
                    isclpd = true;
                }
                return isclpd;
            }
        }
        public bool isCLFullPerformancePD
        {
            get
            {
                bool isclfpl = false;
                if ((CurrentPDChoice == PDChoiceType.CareerLadderPD) && (CurrentPD.LadderPosition == 0))
                {
                    isclfpl = true;
                }
                return isclfpl;
            }
        }
        public bool isCLSOD
        {
            get
            {
                bool isclsod = false;
                if (CurrentPDChoice == PDChoiceType.CLStatementOfDifferencePD)
                {
                    isclsod = true;
                }
                return isclsod;
            }
        }
        public bool isCopiedFromExistingPD
        {
            get
            {
                bool iscopied = false;
                if (CurrentPD.CopyFromPDID > 0)
                {
                    iscopied = true;
                }
                return iscopied;
            }
        }
        public bool IsDualSignRequired
        {//added the PDChoiceType as CareerLadderPD also
            get
            {
                bool returnVal = false;
                if (this.CurrentPDID != NULLPDID)
                {
                    //reverted back to original the requirements for dual signature for the PD



                    if ((!IsStandardPD) &&
                        (
                        (
                        ((CurrentPD.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD) && (!isCopiedFromExistingPD))
                        || (CurrentPD.PositionDescriptionTypeID == (int)PDChoiceType.NewPD)
                        )
                        || (CurrentPD.ProposedGrade >= 14)))
                    {
                        returnVal = true;
                    }
                    //modified the dual signature requirements as per issue 701
                    //if ((!IsStandardPD) && (CurrentPD.ReasonForSubmissionID == 1 || CurrentPD.ProposedGrade >= 14))
                    //{
                    //    returnVal = true;
                    //}
                }

                return returnVal;
            }
        }

        /// <summary>
        /// High grade review is only required for Grade 15 and above as per the new policy 
        /// policy change was indicated via email/issue 3629
        /// </summary>
        public bool IsHighGradeApprovalRequired
        {
            get
            {
                bool returnVal = false;
                if (this.CurrentPDID != NULLPDID)
                {
                    if (CurrentPD.ProposedGrade > 14)
                    {
                        returnVal = true;
                    }
                }
                return returnVal;
            }
        }


        protected bool IsOrgCodeSupervisor(int orgCodeID)
        {



            bool IsOrganizationCodeSupervisor = false;
            IsOrganizationCodeSupervisor = CurrentUser.IsOrganizationCodeSupervisor(orgCodeID);

            return (IsOrganizationCodeSupervisor);


        }

        // the following properties are new to JNP project
        protected int CurrentUserID
        {
            get
            {
                //int userid = -1;

                //if (Session[CURRENTUSERID] == null)
                //{
                //    if (CurrentUser != null)
                //    {
                //        Session[CURRENTUSERID] = CurrentUser.UserID;
                //        userid = CurrentUser.UserID;
                //    }

                //}
                //else
                //{
                //    userid = (int)Session[CURRENTUSERID];
                //}
                //return userid;

                if (Session[CURRENTUSERID] == null)
                    Session[CURRENTUSERID] = SiteUtility.CurrentIdentityUser().UserID;

                return (int)Session[CURRENTUSERID];
            }
        }

        //dashboardroles
        protected List<DashboardRole> CurrentUserDashboardRoles()
        {
            DashboardRoleManager dm = new DashboardRoleManager();
            List<DashboardRole> dr = new List<DashboardRole>();
            if (CurrentUserID > 0)
            {
                dr = dm.GetRolesForUser(CurrentUserID);
            }
            return dr;
            
        }
        #endregion

        #region Access Status
        protected bool IsViewOnly
        {
            get
            {
                if (Session[ISVIEWONLY] == null)
                    Session[ISVIEWONLY] = false;

                return (bool)Session[ISVIEWONLY];
            }

        }
        protected enumNavigationMode CurrentNavMode
        {
            get
            {
                enumNavigationMode currentNavMode = enumNavigationMode.None;
                if (Session[CURRENTNAVMODE] == null)
                {
                    Session[CURRENTNAVMODE] = enumNavigationMode.View;
                }
                currentNavMode = (enumNavigationMode)Session[CURRENTNAVMODE];
                return currentNavMode;
            }
            set
            {
                if (value == enumNavigationMode.None)
                {
                    Session[CURRENTNAVMODE] = null;
                }
                else
                {
                    Session[CURRENTNAVMODE] = value;
                }
            }
        }
        /// <summary>
        /// Returns true if CurrentNavMode is enumNavigationMode.Edit
        /// </summary>
        protected bool IsInEdit
        {
            get
            {
                return (CurrentNavMode == enumNavigationMode.Edit);
            }
        }
        /// <summary>
        /// Returns true if CurrentNavMode is enumNavigationMode.Insert
        /// </summary>
        protected bool IsInInsert
        {
            get
            {
                return (CurrentNavMode == enumNavigationMode.Insert);

            }
        }


        protected eMode CurrentMode
        {
            get
            {
                eMode cMode = eMode.None;
                if (Session[CURRENTMODE] != null)
                { cMode = (eMode)Session[CURRENTMODE]; }
                return cMode;
            }
            set
            {
                Session[CURRENTMODE] = value;
            }
        }

        protected void ClearNavigationAccess()
        {
            Session[ISVIEWONLY] = null;
            Session[CURRENTNAVMODE] = null;
            Session[CURRENTMODE] = null;
        }

        protected int CurrentPDDutyID
        {
            get
            {
                int currentpddutyid = -1;
                if (Session[CURRENTPDDUTYID] != null)
                {
                    currentpddutyid = (int)Session[CURRENTPDDUTYID];
                }
                return currentpddutyid;
            }
            set
            {
                Session[CURRENTPDDUTYID] = value;
            }
        }
        #endregion

        #region Events

        public delegate void TitleChangedHandler(string newTitle);
        public event TitleChangedHandler TitleChanged;

        protected void SetPageTitle(string newTitle)
        {
            try
            {
                if (TitleChanged != null)
                    TitleChanged(newTitle);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        #endregion

        #region PD Access Status

        public bool IsPDReadOnly
        {
            get
            {
                return this.CurrentPDAccessType == PDAccessType.None || this.CurrentPDAccessType == PDAccessType.ReadOnly;
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
                    PositionDescription thisPD = this.CurrentPD;
                    access = GetPDAccessType(thisPD);

                }
                catch (Exception ex)
                {
                    this.HandleException(ex);
                }

                Session[CURRENTPDACCESSTYPE] = access;
            }

            return (PDAccessType)Session[CURRENTPDACCESSTYPE];
        }

        protected bool isPDCreatorSupervisor(bool refresh)
        {
            string CurrentUserIsPDCreatorSupervisor = string.Concat(CurrentUser.UserID.ToString(), CurrentPD.PositionDescriptionID.ToString());
            bool isPDCreatorSupervisor = false;
            //added this check because this function was returning false for the users having the supervisory permission but
            // the pd did not have organization code  because the function IsPDCreatorSupervisor is dependent on PD's org code.


            //commented this again as per discussion with Pam that if you should not be allowed to access non standard pd that do not have org code unless you are a pd creator
            //if (CurrentPD.OrganizationCode == -1)
            //{
            //    isPDCreatorSupervisor = CurrentUser.IsPDCreatorSupervisor (CurrentPD.PositionDescriptionID);
            //}
            //else
            //{
            if ((Cache[CurrentUserIsPDCreatorSupervisor] == null) || (refresh))
            {
                //use insert method instead of add - to support refresh
                //add will throw an error if key already exist 
                //modified the cache refresh time to 30 mins from a day
                Cache.Insert(CurrentUserIsPDCreatorSupervisor, CurrentUser.IsPDCreatorSupervisor(CurrentPD.PositionDescriptionID), null, DateTime.Now.AddMinutes(30), TimeSpan.Zero, CacheItemPriority.Normal, null);
            }

            isPDCreatorSupervisor = (bool)Cache[CurrentUserIsPDCreatorSupervisor];

            //}
            return isPDCreatorSupervisor;
        }

        protected virtual PDAccessType GetPDAccessType(PositionDescription thisPD)
        {
            return SiteUtility.GetPDAccessType(thisPD);
        }

        protected bool CanViewReportsWithPhoneNumber(bool refresh)
        {
            bool canView = false;
            if (CurrentUserID > 0)
            {
                string CurrentUserCanViewKey = string.Format("CurrentUserID{0}CanView", CurrentUserID.ToString());
                if ((Cache[CurrentUserCanViewKey] == null) || (refresh))
                {
                    Cache.Insert(CurrentUserCanViewKey, CurrentUser.CanViewReportsWithPhoneNumber(), null, DateTime.Now.AddMinutes(30), TimeSpan.Zero, CacheItemPriority.Normal, null);

                }
                canView = (bool)Cache[CurrentUserCanViewKey];
            }

            return canView;
        }

        #endregion

        #region Workflow Rule
        protected int CurrentGroupID
        {
            get
            {
                if (Session[CURRENTGROUPID] == null)
                    Session[CURRENTGROUPID] = NULLGROUPID;

                return (int)Session[CURRENTGROUPID];
            }
            set
            {
                Session[CURRENTGROUPID] = value;
            }
        }
        protected int CurrentWorkflowRuleID
        {
            get
            {
                if (Session[CURRENTRULEID] == null)
                    Session[CURRENTRULEID] = NULLRULEID;

                return (int)Session[CURRENTRULEID];
            }
            set
            {
                Session[CURRENTRULEID] = value;
            }
        }
        protected int CurrentStaffingObjectTypeID
        {
            get
            {
                if (Session[CURRENTSTAFFINGOBJECTTYPEID] == null)
                    Session[CURRENTSTAFFINGOBJECTTYPEID] = NULLSTAFFINGOBJECTTYPEID;

                return (int)Session[CURRENTSTAFFINGOBJECTTYPEID];
            }
            set
            {
                Session[CURRENTSTAFFINGOBJECTTYPEID] = value;
            }
        }
        protected int CurrentStatusID
        {
            get
            {
                if (Session[CURRENTSTATUSID] == null)
                    Session[CURRENTSTATUSID] = NULLSTATUSID;

                return (int)Session[CURRENTSTATUSID];
            }
            set
            {
                Session[CURRENTSTATUSID] = value;
            }
        }
        protected int CurrentActionRecID
        {
            get
            {
                if (Session[CURRENTACTIONRECID] == null)
                    Session[CURRENTACTIONRECID] = NULLACTIONRECID;

                return (int)Session[CURRENTACTIONRECID];
            }
            set
            {
                Session[CURRENTACTIONRECID] = value;
            }
        }
        #endregion

        #region [ Common Methods ]

        protected virtual void ClearCurrentPD()
        {
            SiteUtility.ClearCurrentPD();
            Session[CURRENTASSOCIATEDPDID] = null;
            Session[CURRENTSODFULLPERFORMANCEPD] = null;
            Session[CURRENTPDWORKFLOWSTATUS] = null;
            Session[CURRENTPDACCESSTYPE] = null;
            Session[CURRENTPDCHOICE] = null;
            Session[ISVIEWONLY] = null;
            Session[CURRENTMODE] = null;
            Session[CURRENTPDDUTYID] = null;
        }

        protected void ReloadCurrentPD(long positionDescriptionID)
        {
            try
            {
                PositionDescription newPD = new PositionDescription(positionDescriptionID);
                this.ClearCurrentPD();

                if (newPD.PositionDescriptionID != NULLPDID)
                {
                    SiteUtility.CurrentPDID = positionDescriptionID;
                    Session["CurrentPD"] = newPD;
                }
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }




        protected void GoToPDLink(string newLink)
        {
            this.GoToPDLink(newLink, null);
        }

        protected void GoToPDLink(string newLink, bool? isView)
        {
            GoToLink(newLink, isView);
        }

        protected void GoToLink(string newLink)
        {
            GoToLink(newLink, null);
        }
        protected void GoToLink(string newLink, bool? isView)
        {
            if (isView != null)
                Session[ISVIEWONLY] = isView;

            this.SafeRedirect(newLink);
        }
        protected void GoToLink(string newLink, eMode currentMode, bool? isView)
        {
            Session[CURRENTMODE] = currentMode;
            if (isView != null)
            {
                Session[ISVIEWONLY] = isView;
            }
            else
            {
                if (currentMode == eMode.View)
                { Session[ISVIEWONLY] = true; }
                else
                { Session[ISVIEWONLY] = false; }
            }
            this.SafeRedirect(newLink);
        }

        protected void GoToLink(string newLink, enumNavigationMode currentMode)
        {
            Session[CURRENTNAVMODE] = currentMode;
            switch (currentMode)
            {
                case enumNavigationMode.Edit:
                    Session[ISVIEWONLY] = false;
                    break;
                case enumNavigationMode.Insert:
                    Session[ISVIEWONLY] = false;
                    break;
                default:
                    Session[ISVIEWONLY] = true;
                    break;
            }
            this.SafeRedirect(newLink);
        }
        protected void CheckOutPositionDescription(long positionDescriptionID, int checkedOutByID)
        {
            try
            {
                PositionDescription pd = new PositionDescription(positionDescriptionID);
                pd.CheckOut(checkedOutByID);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        protected void CheckOutCLPositionDescription(long positionDescriptionID, int checkedOutByID)
        {
            try
            {
                PositionDescription pd = new PositionDescription(positionDescriptionID);
                pd.CheckOutCareerLadder(checkedOutByID);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        protected void CheckInPositionDescription(long positionDescriptionID, int checkedInByID)
        {
            try
            {
                PositionDescription pd = new PositionDescription(positionDescriptionID);
                pd.CheckIn(checkedInByID);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        protected void CheckInCLPositionDescription(long positionDescriptionID, int checkedInByID)
        {
            try
            {
                PositionDescription pd = new PositionDescription(positionDescriptionID);
                pd.CheckInCareerLadder(checkedInByID);
            }
            catch (Exception ex)
            {
                this.HandleException(ex);
            }
        }

        protected void SafeRedirect(string newURL)
        {
            try
            {
                Response.Redirect(newURL, true);
            }

            catch (Exception ex)
            {
                if (!(ex is ThreadAbortException))
                {

                    this.HandleException(ex);
                }
            }
        }



        /// <summary>
        /// This method uses Telerik.Web.UI.DiffEngine to compare the two strings and
        /// returns result of comparision in the form of a string with deletion and addition annotation.
        /// </summary>
        /// <param name="currentString"></param>
        /// <param name="oldString"></param>
        /// <returns></returns>
        protected string DiffCompareStrings(string currentString, string oldString)
        {
            string resultString = string.Empty;
            DiffEngine diff = new DiffEngine();
            resultString = diff.GetDiffs(currentString, oldString);
            //Apply the styles
            string deleteStyleString = resultString.Replace("class=\"diff_deleted\"", "style='color: red;text-decoration:line-through; font-weight: bold;'");
            string newStyleString = deleteStyleString.Replace("class=\"diff_new\"", "style='background-color: #FFFF00;'");
            return newStyleString.Replace("</span>", "</span>&nbsp;&nbsp;");
        }

        #endregion

        #region [ Exception Handling ]

        /// <summary>
        /// Handle exception (ignores thread abort exception)
        /// </summary>
        /// <param name="ex">The exception to be handled</param>
        protected void HandleException(Exception ex)
        {
            if (!(ex is ThreadAbortException))
            {
                string exceptionMessage = string.Format("[{0}]: {1} ----- {2}", this.GetType().Name, ex.Message, ex.StackTrace);
                string internalMessage = null;

                // remove this line before releasing into production
                if (Request.QueryString["showException"] == null)
                    internalMessage = ex.Message;
                else
                    internalMessage = ex.ToString();

                this.PrintErrorMessage("[Exception Occurred]: " + internalMessage, false);
                LogExceptionOnly(exceptionMessage);
            }
        }

        protected void HandleException(string exceptionMessage)
        {
            this.HandleException(new Exception(exceptionMessage));
        }

        /// <summary>
        /// Log the message as an exception
        /// </summary>
        /// <param name="exceptionMessage">The message to be logged as an exception</param>
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

        #region [ PrintMessage ]

        protected void PrintMessage(string systemMessage, bool displayControl, bool isError)
        {
            if (this.Page is PageBase)
            {
                PageBase currentpage = (PageBase)this.Page;
                if (isError)
                {
                    currentpage.PrintErrorMessage(systemMessage, displayControl);
                }
                else
                {
                    currentpage.PrintSystemMessage(systemMessage, displayControl);
                }
            }
        }

        public void PrintSystemMessage(string message)
        {
            this.PrintSystemMessage(message, false);
        }

        protected void PrintSystemMessage(string systemMessage, bool displayControl)
        {
            this.PrintMessage(systemMessage, displayControl, false);
        }

        protected void PrintErrorMessage(string systemMessage, bool displayControl)
        {
            this.PrintMessage(systemMessage, displayControl, true);
        }

        protected void PrintErrorMessage(Exception ex, bool displayControl)
        {
            this.PrintMessage(ex.Message, displayControl, true);
        }

        public void PrintErrorMessage(Exception ex)
        {
            this.PrintErrorMessage(ex, false);
        }

        public void PrintErrorMessage(string message)
        {
            this.PrintErrorMessage(message, false);
        }
        #endregion


        protected void FormSignOut(string redirectUrl)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            CurrentPermissions = null;

            // clear auth cookie
            System.Web.HttpCookie authCookie = new System.Web.HttpCookie(FormsAuthentication.FormsCookieName);
            authCookie.Domain = FormsAuthentication.CookieDomain;
            authCookie.Path = FormsAuthentication.FormsCookiePath;
            authCookie.Expires = System.DateTime.Now.AddDays(-1);  //set the cookie expires time in order to delete it 
            Response.Cookies.Add(authCookie);


            // clear session cookie
            System.Web.HttpCookie sessionCookie = new System.Web.HttpCookie("ASP.NET_SessionId", "");
            sessionCookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(sessionCookie);

            try
            {

                Response.Redirect(redirectUrl);
            }
            catch { }
        }

        protected void SetGridInEditMode(RadGrid currentGrid)
        {
            foreach (GridDataItem item in currentGrid.Items)
            {
                if (item is GridEditableItem)
                {
                    GridEditableItem editableItem = item as GridEditableItem;
                    editableItem.Edit = true;
                }
            }
            currentGrid.Rebind();

        }
    }
}
