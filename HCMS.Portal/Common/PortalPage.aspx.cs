using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HCMS.Portal.Common
{
    public partial class PortalPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Master.Page.Title  = "Welcome To HCMS";
            
        }

        protected void btnEnter_Click(object sender, EventArgs e)
        {
           Response.Redirect("WarningPage.aspx");
        }

        
    }
}
