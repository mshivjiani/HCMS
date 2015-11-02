using System;
using System.Web.Security;
using HCMS.WebFramework.BaseControls;
using System.Configuration;

namespace HCMS.OrgChart.Controls.Layout
{
    public partial class HeaderControl : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {
                  
            if (Context.User.Identity.IsAuthenticated)
            {
                spanLogin.Visible = true;
                literalPipe.Text = string.Format("Logged in as: {0} | ", base.CurrentUser.FullName);
                literalPipe.Visible = Context.User.Identity.IsAuthenticated;
                linkHome.HRef = ConfigurationManager.AppSettings["HCMSPortalDefaultURL"].ToString();
            }
            else
            {
                spanLogin.Visible = false;
            }
            base.OnPreRender(e);
        }

        protected void LoginStatus1_LoggingOut(object sender, System.Web.UI.WebControls.LoginCancelEventArgs e)
        {

            string redirectUrl = ConfigurationManager.AppSettings["HCMSPortalBaseURL"].ToString();
            base.FormSignOut(redirectUrl);
        }
    }
}