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
    public partial class SeriesAdmin : AdminPageBase
    {
        //protected override void OnInit(EventArgs e)
        //{
        //    base.OnInit(e);
        //}
        protected override void Page_Load(object sender, EventArgs e)
        {
            setMenuTitle();
            
        }
        private void setMenuTitle()
        {
            base.TopMenu = enumTopMenuType.AdminMenu;
            base.LeftMenu = LeftMenuType.PDAminMenu;
            base.SelectTopMenuItem = enumTopMenuItem.PDAdmin;
            base.SelectLeftMenuItem = enumLeftMenuItem.SeriesAdmin ;
            base.PageTitle = "Series Administration";
        }
    }
}