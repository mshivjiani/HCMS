using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using HCMS.Business.Security;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.Site.Utilities;
namespace HCMS.Portal.Controls
{
    public partial class Login : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {
            Button button = this.Loginctrl.FindControl("LoginButton") as Button;
            if (button != null)
            {
                this.Page.Form.DefaultButton = button.UniqueID;

                button.Focus();
            }

            base.OnPreRender(e);
        }
        private bool CheckIfUserExistsInDB()
        {
            User currentuser = new User(Loginctrl.UserName);
            if ((currentuser != null)&& (currentuser.UserID >0))
                return true;
            else
                return false;
        }
        private bool CheckIfUserIsAMembershipUser()
        {
            MembershipUser userInfo = Membership.GetUser(Loginctrl.UserName);

            if (userInfo != null)
                return true;
            else
                return false;
        }

        private bool CheckIfPasswordIsValid()
        {
            bool isValidPassword = Membership.ValidateUser(Loginctrl.UserName, Loginctrl.Password);
            if (isValidPassword)
                return true;
            else
                return false;
        }

        private bool CheckIfPasswordIsLocked()
        {
            MembershipUser userInfo = Membership.GetUser(Loginctrl.UserName);
            string Errormsg = string.Empty;
            //check if user is locked
            if (userInfo != null && !userInfo.IsLockedOut)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfPasswordIsApproved()
        {
            MembershipUser userInfo = Membership.GetUser(Loginctrl.UserName);
            string Errormsg = string.Empty;
            //check if user is approved
            if (userInfo != null && userInfo.IsApproved)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool CheckIfPasswordIsAuthorized()
        {
            MembershipUser userInfo = Membership.GetUser(Loginctrl.UserName);
            string Errormsg = string.Empty;
            if (userInfo != null)
            {
                User currentUser = new User(Loginctrl.UserName);
                //Check if username is enabled or activated.
                if (currentUser.UserID == -1 || currentUser.Enabled)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }



        //Issue Id: 16
        //Author: Deepali Anuje
        //Date Fixed: 1/24/2012
        //Description: Login Page: Err Msg didn't refresh/disappear.  
        //Invalid Password
        protected void cvPassword_ServerValidate(object source, ServerValidateEventArgs e)
        {
            TextBox txtUserName = this.Loginctrl.FindControl("UserName") as TextBox;
            TextBox txtPassword = this.Loginctrl.FindControl("Password") as TextBox;
            
            ValidationSummary cvValidationSummary = this.Loginctrl.FindControl("vsLogin") as ValidationSummary;

            CustomValidator cvUsrName = this.Loginctrl.FindControl("cvUserName") as CustomValidator;
            CustomValidator cvPassd = this.Loginctrl.FindControl("cvPassword") as CustomValidator;         

            if (CheckIfUserIsAMembershipUser())
            {
                cvValidationSummary.HeaderText = "";
                cvUsrName.ErrorMessage = "";

                if (!String.IsNullOrEmpty(txtPassword.Text))
                {
                    if (CheckIfPasswordIsValid())
                    {
                        cvValidationSummary.HeaderText = "";
                        cvUsrName.ErrorMessage = "";
                        if (CheckIfPasswordIsLocked())
                        {
                            cvValidationSummary.HeaderText = "";
                            cvUsrName.ErrorMessage = "";
                            if (CheckIfPasswordIsApproved())
                            {
                                cvValidationSummary.HeaderText = "";
                                cvUsrName.ErrorMessage = "";
                                if (CheckIfPasswordIsAuthorized())
                                {

                                    cvValidationSummary.HeaderText = "";
                                    cvUsrName.ErrorMessage = "";
                                    if (CheckIfUserExistsInDB())
                                    {
                                        cvValidationSummary.HeaderText = "";
                                        cvUsrName.ErrorMessage = "";
                                        e.IsValid = true;
                                    }
                                    else
                                    {
                                        cvValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
                                        cvUsrName.ErrorMessage = string.Format("There is no user in the database with the username [{0}]. Please contact your supervisor or click on the Support Desk link below to request access.", Loginctrl.UserName);
                                        e.IsValid = false;
                                    }
                                    
                                }
                                else
                                {
                                    cvValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
                                    
                                    //cvUsrName.ErrorMessage = "You are not authorized to access PDExpress.";
                                    cvUsrName.ErrorMessage = "You are not authorized to access HCMS.";

                                    e.IsValid = false;
                                }
                            }
                            else
                            {
                                cvValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
                                cvUsrName.ErrorMessage = "Your account has not yet been approved by the site's administrators. Please try again later.";
                                e.IsValid = false;
                            }
                        }
                        else
                        {
                            cvValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
                            cvUsrName.ErrorMessage = "Your account has been locked out because of a maximum number of incorrect login attempts. You WILL NOT be able to login until you contact FWS IRTM Help Desk and have your account unlocked.";
                            e.IsValid = false;
                        }
                    }
                    else
                    {
                        cvValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
                        cvUsrName.ErrorMessage = "Invalid Password";
                        e.IsValid = false;
                    }
                }
                else 
                {
                    cvValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
                    cvUsrName.ErrorMessage = "Password cannot be blank";
                    e.IsValid = false;
                }
            }
            else
            {
                cvValidationSummary.DisplayMode = ValidationSummaryDisplayMode.BulletList;
                cvUsrName.ErrorMessage = string.Format("There is no user in the database with the username [{0}]. Please contact your supervisor or click on the Support Desk link below to request access.", Loginctrl.UserName);                 
                e.IsValid = false;
            }    
        }
                             
        //Issue Id: 16
        //Author: Deepali Anuje
        //Date Fixed: 1/24/2012
        //Description: Login Page: Err Msg didn't refresh/disappear.  
        protected void Loginctrl_LoginError(object sender, EventArgs e)
        {
            string Errormsg = string.Empty;

            if (Errormsg.Length > 0)
            {
                Loginctrl.FailureText = Errormsg;
                PrintErrorMessage(new Exception(Errormsg), true);
            }
        }

        //Issue Id: 16
        //Author: Deepali Anuje
        //Date Fixed: 1/24/2012
        //Description: Login Page: Err Msg didn't refresh/disappear.  
        //Once authenticated, proceed 
        protected void Loginctrl_Authenticate(object sender, AuthenticateEventArgs e)
        {
            bool isValidUser = Membership.ValidateUser(Loginctrl.UserName, Loginctrl.Password);

            if (isValidUser)
            {
                MembershipUser userInfo = Membership.GetUser(Loginctrl.UserName);
                string Errormsg = string.Empty;
                if (userInfo != null)
                {
                    User currentUser = new User(Loginctrl.UserName);
                    SiteUtility.BuildAuthenticationCookie(currentUser, currentUser.GetRoles(), currentUser.GetPermissions());
                }

            }

        }
    }
}