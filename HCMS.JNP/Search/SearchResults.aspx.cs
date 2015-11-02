using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.JNP.Search
{
    public partial class SearchResults : JNPPageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.TopMenu = enumTopMenuType.JNPHomeMenu;
            base.ShowLeftMenu = false;
            //base.SelectTopMenuItem = enumTopMenuItem.Search;
            base.ShowTopMenu = false;
            base.ShowSubMenu = false;
            base.PageTitle = "Search";
            base.ShowInformationDiv = false;
            base.ShowRequiredFieldMessage = true;

            ((JNPMaster)this.Master).ShowNotesLink = false;

        }
    }
}