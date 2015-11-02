using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
namespace HCMS.Portal.Admin
{
    public partial class JNPAdmin : AdminPageBase 
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.TopMenu = enumTopMenuType.AdminMenu;
            base.LeftMenu = LeftMenuType.JNPAdminMenu;
            base.SelectLeftMenuItem = enumLeftMenuItem.JNPAdmin;
            base.SelectTopMenuItem = enumTopMenuItem.JNPAdmin;
            base.PageTitle = "JAX Administration";
        }
    }
}