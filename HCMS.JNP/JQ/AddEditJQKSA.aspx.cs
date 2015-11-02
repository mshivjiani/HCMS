using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

using Telerik.Web.UI;
using HCMS.JNP.Controls.Search;

namespace HCMS.JNP.JQ
{
    public partial class AddEditJQKSA : JNPPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            base.TopMenu = enumTopMenuType.JQMenu;
            base.LeftMenu = LeftMenuType.JQMenu;
            base.SelectTopMenuItem = enumTopMenuItem.JobQuestionnaire;
            base.SelectLeftMenuItem = enumLeftMenuItem.KSA;
            base.SelectProgressBar = enumProgressBarItem.JQKSA;

            base.PageTitle = "Add/Edit Job Questionnaire KSA";

        }
    }
}