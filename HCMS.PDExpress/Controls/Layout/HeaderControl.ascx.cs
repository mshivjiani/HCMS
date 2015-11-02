using System;
using System.Web.Security;
using HCMS.WebFramework.BaseControls;
using System.Configuration;
namespace HCMS.PDExpress.Controls.Layout
{
    public partial class HeaderControl : UserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //btnGoBack.Visible = Convert.ToBoolean(Session["searchParam"] != null);
        }

        protected override void OnInit(EventArgs e)
        {
            // this.buttonSearch.Click += new EventHandler(buttonSearch_Click);

            btnGoBack.Click += new EventHandler(btnGoBack_Click);
        }
        protected override void OnPreRender(EventArgs e)
        {
            //Issue Id: 29
            //Author: Deepali Anuje
            //Date Fixed: 1/23/2012
            //Description: Remove Login and Home button from top-right corner of login screen..
            //both take user this screen               
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

        protected void btnGoBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Search/SearchReports.aspx");

        }
    }
}