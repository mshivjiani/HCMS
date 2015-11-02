using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
namespace HCMS.JNP.Approval
{
    public partial class Approval : JNPPageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.TopMenu = enumTopMenuType.ApprovalMenu;
            base.ShowLeftMenu = false;
            base.ShowSubMenu = false;            
            base.SelectTopMenuItem = enumTopMenuItem.Approval;
            base.SelectProgressBar = enumProgressBarItem.Approval;
            base.PageTitle = "Approval";
            ((JNPMaster)this.Master).ShowNotesLink = false;
        }
    }
}