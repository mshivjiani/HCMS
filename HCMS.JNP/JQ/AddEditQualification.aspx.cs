using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.JNP.JQ
{
    public partial class AddEditQualification : JNPPageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.TopMenu = enumTopMenuType.JQMenu;
            base.LeftMenu = LeftMenuType.JQMenu;
            base.SelectTopMenuItem = enumTopMenuItem.JobQuestionnaire;
            base.SelectLeftMenuItem = enumLeftMenuItem.Qualifications;
            base.SelectProgressBar = enumProgressBarItem.JQQualifications;

            base.PageTitle = "Add/Edit Job Questionnaire Qualifications";
        }
    }
}