using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCMS.Portal.Common
{
    public partial class WarningPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title = "Warning";
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // TODO: Need to check for ReturnUrl Querystring and if null go to default.aspx
            Response.Redirect ("~/Default.aspx");
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
           Response.Redirect ("~/Common/PortalPage.aspx");
        }
    }
}
