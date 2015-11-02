using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
namespace HCMS.JNP.JA
{
    public partial class AddEditJADuty : JNPPageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {

            base.TopMenu = enumTopMenuType.JAMenu;
            base.LeftMenu = LeftMenuType.JAMenu;
            base.SelectTopMenuItem = enumTopMenuItem.JobAnalysis;
            base.SelectLeftMenuItem = enumLeftMenuItem.JADuties;
            base.SelectProgressBar = enumProgressBarItem.JADutyKSA;

            base.PageTitle = "Add/Edit Job Analysis Duty/KSA";
            
        }
    }
}