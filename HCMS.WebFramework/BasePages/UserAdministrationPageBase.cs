using System;

using HCMS.Business.Security;

namespace HCMS.WebFramework.BasePages
{
    public class UserAdministrationPageBase : PageBase
    {
        #region Properties

        protected bool RequireUserID
        {
            get
            {
                if (ViewState["RequireUserID"] == null)
                    ViewState["RequireUserID"] = false;

                return (bool)ViewState["RequireUserID"];
            }
            set
            {
                ViewState["RequireUserID"] = value;
            }
        }

        protected User CurrentEditUser
        {
            get
            {
                if (ViewState["CurrentEditUser"] == null)
                    ViewState["CurrentEditUser"] = new User();

                return (User)ViewState["CurrentEditUser"];
            }
            set
            {
                ViewState["CurrentEditUser"] = value;
            }
        }

        protected enumTopMenuType TopMenu
        {
            get { return ((MasterPageBase)Master).TopMenuType; }
            set { ((MasterPageBase)Master).TopMenuType = value; }
        }




        #endregion

        #region Common Methods

        protected void GoToAdminPage()
        {
            base.SafeRedirect("~/admin/default.aspx");
        }

        #endregion

        protected override void OnLoad(EventArgs e)
        {
            if (base.HasPermission(enumPermission.AllSystemAdministrationPermissions) ||
                base.HasPermission(enumPermission.MaintainUserAccounts) ||
                base.HasPermission(enumPermission.DelegatePD))
            {
                if (base.HasValidIntegerQueryStrings())
                {
                    if (this.RequireUserID)
                    {
                        if (Request.QueryString["userID"] == null)
                            base.PrintErrorMessage("You must specify the user ID of the account to access this page.");
                        else
                        {
                            int tempUserID = int.Parse(Request.QueryString["userID"]);
                            User tempUser = new User(tempUserID);

                            if (tempUser.UserID == -1)
                                base.PrintErrorMessage("The user account specified does not exist in the system.");
                            else
                            {
                                // if the user is not a system admin AND the editUser's region ID is not equal to the currentUser regionID
                                if ((!base.HasPermission(enumPermission.AllSystemAdministrationPermissions)) && (tempUser.RegionID != base.CurrentUser.RegionID))
                                    base.PrintErrorMessage("You do not have permission to access the user account specified.");
                                else
                                {
                                    this.CurrentEditUser = tempUser;
                                    base.OnLoad(e);
                                }
                            }
                        }
                    }
                    else
                        base.OnLoad(e);
                }
                else
                    base.PrintErrorMessage("The user account parameter passed to this page is not valid.");
            }
            else
                base.GoToAccessDeniedPage();
        }
    }
}
