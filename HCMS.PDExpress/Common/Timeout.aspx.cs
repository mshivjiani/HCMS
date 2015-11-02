using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Configuration;


namespace HCMS.PDExpress.Common
{
    public partial class Timeout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.hyperlinkdefault.NavigateUrl = ConfigurationManager.AppSettings["HCMSPortalDefaultURL"].ToString();
            Master.Page.Title = "Session Timeout";
            if (User.Identity.IsAuthenticated )
            {
                    FormsAuthentication.SignOut();
            }

            Session.Abandon();

        }
       
    }
}
