using System;
using System.Web.UI.WebControls;
using System.Web.Security;
using System.Collections.Generic;
using HCMS.Business.Security;
using HCMS.Business.PD;
using HCMS.Business.PD.Collections;
using HCMS.Business.Lookups;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.Security;
using HCMS.PDExpress.Controls.Message;
using HCMS.PDExpress.Controls.ToolTip;

namespace HCMS.PDExpress.Controls.CreatePD.Factors
{
    public partial class Evaluation : CreatePDUserControlBase
    {
        #region "Page Events"
        protected override void OnInit(EventArgs e)
        {
            this.chkEvalCriteria.DataBinding += new EventHandler(chkEvalCriteria_DataBinding);
            this.btnAddEval.Click += new EventHandler(btnAddEval_Click);
            this.btnSubmitEvalCrit.Click += new EventHandler(btnSubmitEvalCrit_Click);
            this.btnSaveEval.Click += new EventHandler(btnSaveEval_Click);
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            PD = base.CurrentPD;
            currentStatus = base.CurrentPD.GetCurrentPDStatus();
            UserID = base.CurrentUser.UserID;
            if (!Page.IsPostBack)
            { BindEvalCriteria(); }

        }
        protected override void OnPreRender(EventArgs e)
        {
            DisplayEvalPanel();
            setPageView();
            base.OnPreRender(e);
        }

        #endregion


        private void setPageView()
        {
            bool okToUse = !base.IsPDReadOnly;
            bool isPDCreator = base.CurrentPD.PDCreatorID.Equals(base.CurrentUser.UserID);
            bool isPDCreatorSupervisor = base.isPDCreatorSupervisor(false);
            bool isSOD = base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
            bool hasHRGroupPermission = (base.HasPermission(enumPermission.CompleteHRCertification) || base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
                    base.HasPermission(enumPermission.MaintainHRSection) || base.HasPermission(enumPermission.MaintainFactorRecommendation) ||
                        base.HasPermission(enumPermission.PublishPD));
            bool isCL = base.CurrentPDChoice == PDChoiceType.CareerLadderPD;


            PDStatus status = base.CurrentPD.GetCurrentPDStatus();
            switch (status)
            {
                case PDStatus.Draft:
                    bool isHMEnabled = okToUse && (isPDCreator || isPDCreatorSupervisor);

                    if(!isHMEnabled) isHMEnabled = base.IsSystemAdministrator;
                   
                    btnSubmitEvalCrit.Enabled = btnAddEval.Enabled = btnSaveEval.Enabled = isHMEnabled && !isSOD;

                    //Issue 1546
                    //if( base.IsSystemAdministrator)btnSubmitEvalCrit.Enabled = true;

                    break;
                case PDStatus.Revise:
                    bool isReviseEnabled = okToUse && (base.HasPermission(enumPermission.CreatePD) || base.HasPermission(enumPermission.CompleteSupervisoryCertification));

                    if (!isReviseEnabled) isReviseEnabled = base.IsSystemAdministrator;

                    btnSubmitEvalCrit.Enabled = btnAddEval.Enabled = btnSaveEval.Enabled =isReviseEnabled && !isSOD;

                    //Issue 1546
                    //if(base.IsSystemAdministrator)btnSubmitEvalCrit.Enabled = true;

                    break;
                case PDStatus.Review:
                    bool isEnabled = okToUse && hasHRGroupPermission;

                    if (!isEnabled) isEnabled = base.IsSystemAdministrator;

                    btnSubmitEvalCrit.Enabled = btnAddEval.Enabled = btnSaveEval.Enabled =  isEnabled && !isSOD;

                    //Issue 1546
                    //if(base.IsSystemAdministrator)btnSubmitEvalCrit.Enabled = true;

                    break;
                case PDStatus.FinalReview:
                    bool isFinalEnabled = okToUse && hasHRGroupPermission;

                    if (!isFinalEnabled) isFinalEnabled = base.IsSystemAdministrator;

                    btnSubmitEvalCrit.Enabled = btnAddEval.Enabled = btnSaveEval.Enabled =  isFinalEnabled && !isSOD;

                    //Issue 1546
                    //if(base.IsSystemAdministrator)btnSubmitEvalCrit.Enabled = true;

                    break;

                default: //takes care of PUBLISHED Status as well
                    btnSubmitEvalCrit.Enabled = okToUse;
                    btnAddEval.Enabled = okToUse;
                    btnSaveEval.Enabled = okToUse;
                    RadSpellEval.Visible = okToUse;
                    break;
            }
        }


        #region [ Evaluation ]

        private void DisplayEvalPanel()
        {
            int count = GetEvalCritCount();
            bool canEdit = CanEditEvaluation();
            if (base.HasPermission(enumPermission.MaintainEvaluationStatements))
            {
                this.tableEval.Visible = true;

            }
            else
            {
                this.tableEval.Visible = this.pnlEvalCrit.Visible = this.pnlEval.Visible = false;
            }
            if (count > 0)
            {
                this.pnlEvalCrit.Visible = true;
                this.pnlEval.Visible = true;
                GetEvalValues();
            }

            this.btnAddEval.Enabled = this.pnlEvalCrit.Enabled = this.pnlEval.Enabled = RadSpellEval.Visible = canEdit;
        }

        private bool CanEditEvaluation()
        {
            bool canEdit = false;

            bool isPDCreator = base.CurrentPD.PDCreatorID.Equals(base.CurrentUser.UserID);
            bool isPDCreatorSupervisor = base.isPDCreatorSupervisor(false);
            bool isSOD = base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
            bool hasHRGroupPermission = (base.HasPermission(enumPermission.CompleteHRCertification) || base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
                                        base.HasPermission(enumPermission.MaintainHRSection) || base.HasPermission(enumPermission.MaintainFactorRecommendation) ||
                                        base.HasPermission(enumPermission.PublishPD));


            if (!(base.IsPDReadOnly || isSOD))
            {
                if (hasHRGroupPermission)
                {
                    if (isPDCreator || isPDCreatorSupervisor)
                    {
                        if (currentStatus == PDStatus.Draft || currentStatus == PDStatus.Review || currentStatus == PDStatus.Revise || currentStatus == PDStatus.FinalReview)
                        {
                            canEdit = true;
                        }
                    }
                    else
                    {
                        if (currentStatus == PDStatus.Review || currentStatus == PDStatus.FinalReview)
                        {
                            canEdit = true;
                        }
                    }
                }
            }

            if (base.IsSystemAdministrator) canEdit = true;
            if (base.IsPDReadOnly) canEdit = false;
            
            return canEdit;
        }



        void btnAddEval_Click(object sender, EventArgs e)
        {
            this.pnlEvalCrit.Visible = true;
            this.pnlEval.Visible = (GetEvalCritCount() > 0);
        }

        void chkEvalCriteria_DataBinding(object sender, EventArgs e)
        {
        }

        void BindEvalCriteria()
        {
            List<PositionEvalCriteria> currentevalCrit = new List<PositionEvalCriteria>();
            currentevalCrit = PD.GetPositionEvalCriteria();

            this.chkEvalCriteria.DataSource = LookupWrapper.GetAllEvalCriterias(true);

            this.chkEvalCriteria.DataBind();
            if (currentevalCrit.Count > 0)
            {
                foreach (ListItem item in this.chkEvalCriteria.Items)
                {
                    PositionEvalCriteria peval = new PositionEvalCriteria();
                    peval.PositionDescriptionID = PD.PositionDescriptionID;
                    peval.EvalCriteriaID = int.Parse(item.Value);
                    if (currentevalCrit.Contains(peval))
                    {
                        item.Selected = true;
                    }
                }
            }
        }

        private int GetEvalCritCount()
        {
            int count = 0;
            foreach (ListItem item in this.chkEvalCriteria.Items)
            {
                if (item.Selected)
                {
                    count = count + 1;
                }
            }
            return count;
        }

        void btnSubmitEvalCrit_Click(object sender, EventArgs e)
        {
            try
            {
                //this.ucFullPerformanceMessage.ReloadControl();
                int count = 0;
                foreach (ListItem item in this.chkEvalCriteria.Items)
                {
                    int evalCriteriaID = int.Parse(item.Value);
                    PositionEvalCriteria pdEvalCrit = new PositionEvalCriteria();
                    pdEvalCrit.PositionDescriptionID = PD.PositionDescriptionID;
                    pdEvalCrit.EvalCriteriaID = evalCriteriaID;
                    pdEvalCrit.UpdatedByID = this.UserID;
                    pdEvalCrit.UpdateDate = DateTime.Today;

                    if (item.Selected)
                    {
                        count = count + 1;
                        pdEvalCrit.Save();
                    }
                    else
                    {
                        pdEvalCrit.Delete();
                    }
                }
                this.litEvalCritmsg.Text = "Evaluation statement criteria saved successfully!";

                //putting the check here to see if there are no eval crit
                //then delete the eval statement so that data is in synch
                if (count == 0)
                {
                    DeleteEvalData();
                }

                GetEvalValues();

                this.pnlEval.Visible = (count > 0);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void GetEvalValues()
        {
            ControlUtility.SafeTextBoxAssign(this.txtTitleJustification, PD.TitleJustification);
            ControlUtility.SafeTextBoxAssign(this.txtSeriesJustification, PD.SeriesJustification);
            ControlUtility.SafeTextBoxAssign(this.txtGradeJustification, PD.GradeJustification);
            ControlUtility.SafeTextBoxAssign(this.txtAdditionalJustification, PD.AdditionalJustification);
        }

        private void DeleteEvalData()
        {
            try
            {
                PD.UpdatedByID = this.UserID;
                PD.UpdateDate = DateTime.Today;
                PD.DeletePositionEvaluation();
                this.litEvalCritmsg.Text = "Evaluation statement deleted successfully!";
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }
        private void SaveEvalValues(string titleJustification, string seriesJustificaion, string gradeJustification, string additionalJustification)
        {


            try
            {
                PD.TitleJustification = titleJustification;
                PD.SeriesJustification = seriesJustificaion;
                PD.GradeJustification = gradeJustification;
                PD.AdditionalJustification = additionalJustification;
                PD.UpdatedByID = this.UserID;
                PD.UpdateDate = DateTime.Today;

                PD.SaveEval(null);
                this.litEvalmsg.Text = "Evaluation statement saved successfully!";
            }
            catch (Exception ex)
            {
                HandleException(ex);
            }
        }

        protected void btnSaveEval_Click(object sender, EventArgs e)
        {
            string titleJustification = this.txtTitleJustification.Text;
            string seriesJustificaion = this.txtSeriesJustification.Text;
            string gradeJustification = this.txtGradeJustification.Text;
            string additionalJustification = this.txtAdditionalJustification.Text;
            SaveEvalValues(titleJustification, seriesJustificaion, gradeJustification, additionalJustification);
        }

        #endregion

        #region [ Fields ]

        private PositionDescription PD = new PositionDescription();
        PDStatus currentStatus = PDStatus.Null;
        int UserID = -1;

        #endregion
    }
}
