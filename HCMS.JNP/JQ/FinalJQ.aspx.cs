using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BasePages;
using HCMS.JNP.Controls.JQ;

namespace HCMS.JNP.JQ
{
    public partial class FinalJQ : JNPPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.ctrlJQFinalInfo.ViewFactorDetails += new ctrlJQFinal.ViewFactorDetailsHandler(ctrlJQFinalInfo_ViewFactorDetails);
            this.ctrlJQFinalDetailsInfo.ViewFactors += new ctrlJQFinalDetails.ViewFactorsHandler(ctrlJQFinalDetailsInfo_ViewFactors);
            base.OnInit(e);
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            try
            {
                base.TopMenu = enumTopMenuType.JQMenu;
                base.LeftMenu = LeftMenuType.JQMenu;
                base.SelectTopMenuItem = enumTopMenuItem.JobQuestionnaire;
                base.SelectLeftMenuItem = enumLeftMenuItem.FinalJQ;
                base.SelectProgressBar = enumProgressBarItem.JQFinalJQ;

                base.PageTitle = "Job Questionnaire Factors, Factor Items and Rating Responses";

                if (!Page.IsPostBack)
                    this.ctrlJQFinalInfo.BuildPage();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void showFactorDetails(bool display)
        {
            this.ctrlJQFinalInfo.Visible = !display;
            this.ctrlJQFinalDetailsInfo.Visible = display;

        }

        private void ctrlJQFinalInfo_ViewFactorDetails(long factorID, string factorTitle)
        {
            try
            {
                showFactorDetails(true);
                this.ctrlJQFinalDetailsInfo.BuildPage(factorID, factorTitle);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void ctrlJQFinalDetailsInfo_ViewFactors()
        {
            try
            {
                showFactorDetails(false);
                this.ctrlJQFinalInfo.BuildPage();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
    }
}