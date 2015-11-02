using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.JQ;
using HCMS.Business.Check;

namespace HCMS.JNP.Controls.JQ
{
    public partial class ctrlJQInfo : JNPUserControlBase
    {
        private JQManager manager = new JQManager();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadUIFields();
                SetPageView();
            }

        }

        private void LoadUIFields()
        {
            if (this.CurrentJQID > 0)
            {
                JobQuestionnaire jq = manager.GetJobQuestionnaire(this.CurrentJQID);

                //payPlanField.Text = jq.JQPayPlanID.ToString();
                payPlanField.Text = jq.PayPlanName;
                //seriesField.Text = jq.JQSeriesID.ToString();
                seriesField.Text = string.Format("{0} | {1}", jq.JQSeriesID.ToString(), jq.SeriesName);
                isStandardField.Text = (jq.IsStandardJQ) ? "Yes" : "No";
                isInterDisciplinaryField.Text = (jq.IsInterdisciplinary) ? "Yes" : "No";

                if (jq.AdditionalJQSeriesID > 0)
                {
                    addtlSeriesField.Text = string.Format("{0} | {1}", jq.AdditionalJQSeriesID.ToString(), jq.AdditionalSeriesName);
                }
                else
                {
                    addtlSeriesField.Text = string.Empty;
                }

                lowestAdvGradeField.Text = jq.LowestAdvertisedGrade.ToString();
                highestAdvGradeField.Text = jq.HighestAdvertisedGrade.ToString();
                
                jqPositionTitleField.Text = jq.JQPositionTitle;
            }
            else
            {
                base.PrintErrorMessage(GetGlobalResourceObject("JNPMessages", "JQNotAvailable").ToString(), false);
                
            }
        }
        private void SetPageView()
        {
            enumJNPWorkflowStatus currentws = base.CurrentJNPWS;
            //enumDocWorkflowStatus currentdocws = base.GetJNPCurrentDocumentWorklfowStatus(false);
            //bool isActiveDocument = true;
            //if ((currentws == enumJNPWorkflowStatus.Draft))
            //{
            //    if (base.GetActiveDocumentType(false) != enumDocumentType.JQ)
            //    { isActiveDocument = false; }
            //}
            //bool showEditFields = ((base.IsInEdit)
            //   && ((currentws == enumJNPWorkflowStatus.Draft || currentws == enumJNPWorkflowStatus.Review)
            //   || (currentws == enumJNPWorkflowStatus.Revise && !CurrentJNP.IsJNPSignedBySupervisor) 
            //   || (currentws == enumJNPWorkflowStatus.FinalReview && !CurrentJNP.IsJNPSignedByHR))              
            //    );
            if ((base.IsViewOnly) || (!base.ShowEditFields(enumDocumentType.JQ)))
            {
                
                btnSaveContinue.Text = "Continue";
                btnSaveContinue.ToolTip = "Continue";
            }
            else
            {
                this.btnSaveContinue.Text = "Save and Continue";
                this.btnSaveContinue.ToolTip = "Save and Continue";
            }

           
        }
        protected void btnSaveContinue_Click(object sender, EventArgs e)
        {
            GoToLink("~/JQ/Qualifications.aspx", CurrentNavMode);

        }

       
    }
}