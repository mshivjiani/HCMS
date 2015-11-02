using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.PDExpress.CreatePD
{
    public partial class PDTypeChoice : PageBase
    {
        protected override void OnPreRender(EventArgs e)
        {
            base.LeftMenu = LeftMenuType.PDHomeMenu;            
            base.PDControlName = PDControlType.PDTypeChoice;
            base.OnPreRender(e);
        }
    }
}
