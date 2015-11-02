using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.Portal.Admin
{
    public partial class DelegateOrgChart : AdminPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            base.RequireUserID = true;
            base.OnInit(e);
        }
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.TopMenu = enumTopMenuType.AdminMenu;
            base.LeftMenu = LeftMenuType.UserAdminMenu ;


            base.PageTitle = string.Format("Organization Chart Delegation Change for {0}", base.CurrentEditUser.FullNameReverse);
        }
    }
}