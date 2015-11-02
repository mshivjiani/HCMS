using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
namespace HCMS.Portal.Admin
{
    public partial class DelegateJNP : AdminPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            base.RequireUserID = true;
            base.OnInit(e);
        }
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.TopMenu = enumTopMenuType.AdminMenu;
            base.LeftMenu = LeftMenuType.JNPAdminMenu;
            base.SelectLeftMenuItem = enumLeftMenuItem.JNPAdmin;
            base.SelectTopMenuItem = enumTopMenuItem.JNPAdmin;
           
            base.PageTitle = string.Format("JAX Delegation Change for {0}", base.CurrentEditUser.FullNameReverse);
        }
    }
}