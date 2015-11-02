using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.Business.Security;
using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using Telerik.Web.UI;

namespace HCMS.Portal.Admin
{
    public partial class ToolTipAdmin : AdminPageBase 
    {
        protected override  void Page_Load(object sender, EventArgs e)
        {
            base.TopMenu = enumTopMenuType.AdminMenu;
            base.LeftMenu = LeftMenuType.MiscellaneousAdminMenu;
            base.SelectTopMenuItem = enumTopMenuItem.Miscellaneous;
            base.SelectLeftMenuItem = enumLeftMenuItem.ToolTipAdmin;
            base.PageTitle = "ToolTip Administration";
            
        }
    }
}