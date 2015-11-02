using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using System.Security.Principal;

using HCMS.Business.Security;
using HCMS.WebFramework.Security;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.Site.Utilities;

namespace HCMS
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {

        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {


        }

        private void Application_AuthenticateRequest(object sender, EventArgs e)
        {
            string authCookieName = FormsAuthentication.FormsCookieName;
            HttpCookie authCookie = Context.Request.Cookies[authCookieName];
            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                if (authTicket == null)
                    throw new Exception("Authentication cookie failed to decrypt.");
                else
                {
                    int userID = int.Parse(authTicket.Name);
                    User currentUser = new User();
                    currentUser.UserID = userID;
                    string[] userData = authTicket.UserData.Split('|');
                    SitePrincipal thisPrincipal = new SitePrincipal(new SiteIdentity(currentUser, currentUser.GetRoles(), currentUser.GetPermissions()));
                    currentUser.UserID = userID;
                    currentUser.FirstName = userData[1];
                    currentUser.LastName = userData[2];
                    currentUser.EmailAddress = userData[3];
                    currentUser.RegionID = int.Parse(userData[4]);
                    Context.User = thisPrincipal;
                }
            }
            else if (blnJumpLogin)
            {
                JumpLogin();
            }
        }


        protected void Application_Error(object sender, EventArgs e)
        {
            // NOTE:
            //
            // do not call Server.ClearError() within this handler to allow execution of Error.aspx.cs
            //

            try
            {
                bool showException = Request.QueryString["showException"] != null;
                string strError = "Undefined";
                string message = String.Empty;

                Exception lastException = Server.GetLastError();

                if (lastException != null)
                {
                    Exception lastBaseException = lastException.GetBaseException();

                    if (lastBaseException != null)
                        message = showException ? lastBaseException.ToString() : lastBaseException.Message;
                    else
                        message = showException ? lastException.ToString() : lastException.Message;
                }

                strError = string.Format("<b>Location</b> : {0}<br /><b>Message</b> : {1} ", Request.Url.ToString(), message);

                if (Context.Handler is IRequiresSessionState || Context.Handler is IReadOnlySessionState)
                {
                    Session["error"] = strError;
                }
            }
            catch
            { }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }

        private void JumpLogin()
        {
            int userid = ConfigWrapper.JumpLoginID;
            if (userid > 0)
            {
                User currentUser = new User(userid);
                SiteUtility.BuildAuthenticationCookie(currentUser, currentUser.GetRoles(), currentUser.GetPermissions());


            }
            else
            {
                throw new ApplicationException("Jump login ID not provided");

            }
        }
        private bool blnJumpLogin
        {
            get { return ConfigWrapper.JumpLogin; }
        }
    }
}