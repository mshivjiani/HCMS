using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
namespace HCMS.PDExpress
{
    public partial class Help : PageBase 
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.PageTitle = "Help";

            this.trAdminHelpLink.Visible = base.IsAdministrator;
            base.OnPreRender(e);
        }
    }
}
