using System;


using HCMS.WebFramework.BasePages;

namespace HCMS.PDExpress
{
    public partial class PDExpressTracker : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.Button btn = (System.Web.UI.WebControls.Button)Master.FindControl("btnGoBack");

            //if (btn != null) btn.Visible = false;

            Session["searchParam"] = null;
        }
    }
}
