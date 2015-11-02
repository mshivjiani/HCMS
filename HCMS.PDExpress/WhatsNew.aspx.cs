using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
namespace HCMS.PDExpress
{
    public partial class WhatsNew : PageBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected override void OnPreRender(EventArgs e)
        {
            base.PageTitle = "What's New";

            base.OnPreRender(e);
        }

    }
}
