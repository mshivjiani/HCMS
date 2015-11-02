using System;
using HCMS.WebFramework.BasePages;


namespace HCMS.Portal.Admin
{
    public partial class SSASRoles : AdminPageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.TopMenu = enumTopMenuType.AdminMenu;
            base.LeftMenu = LeftMenuType.DashboardRoleMenu;
            base.SelectTopMenuItem = enumTopMenuItem.DashboardRole;
            base.SelectLeftMenuItem = enumLeftMenuItem.SSASRoles;
            base.PageTitle = "SSAS Roles Report";

        }
    }
}