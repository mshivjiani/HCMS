using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Text;

using Telerik.Web.UI;

using HCMS.Business.PD.Collections;
using HCMS.Business.PD;
using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Search;
using HCMS.Business.Security;
using HCMS.Business.Lookups;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.Common;
using HCMS.WebFramework.Security;

namespace HCMS.PDExpress.Controls.CreatePD.PositionCharacteristics
{
    public partial class PositionCharacteristics : CreatePDUserControlBase
    {
        #region [ Page Event Handlers ]
        protected override void OnLoad(EventArgs e)
        {
            if (base.CurrentPDID == NULLPDID)
            {
                string referringUrl = Context.Request.UrlReferrer.ToString().ToLower();
                base.HandleException("Current Position Description is not set.");
            }
            else
            {
                if (!IsPostBack)
                {
                    LoadData(false);
                    setPageView();
                }
            }

            base.OnLoad(e);
        }
        protected override void OnPreRender(EventArgs e)
        {
            if (base.IsStandardPD)
            {
                spnStarSecondSubdivision.Visible = false;
                spnStarEmpOfficeLocation.Visible = false;
                spnStarDutyLocation.Visible = false;
            }

            base.OnPreRender(e);
        }
        #endregion

        #region [ Private Methods ]

        private void setPageView()
        {
            bool isEditable = !base.IsPDReadOnly;
            bool isSOD = base.CurrentPDChoice == PDChoiceType.StatementOfDifferencePD;
            bool isCL = base.CurrentPDChoice == PDChoiceType.CareerLadderPD;
            bool isCLSOD = base.CurrentPDChoice == PDChoiceType.CLStatementOfDifferencePD;
            bool isPDCreator = base.CurrentPD.PDCreatorID.Equals(base.CurrentUser.UserID);
            bool isPDCreatorSupervisor = base.isPDCreatorSupervisor(false);
            bool isAdmin = base.IsAdmin;
            PDStatus status = base.CurrentPD.GetCurrentPDStatus();
            forHRPanel.Visible = HRPanelVisible;
            bool enableSave = false;

            bool hasHRGroupPermission = (base.HasPermission(enumPermission.CompleteHRCertification) || base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
                    base.HasPermission(enumPermission.MaintainHRSection) || base.HasPermission(enumPermission.MaintainFactorRecommendation) ||
                        base.HasPermission(enumPermission.PublishPD));

            this.ctrlCareerLadderBundle.Visible = isCLSOD;

            switch (status)
            {
                case PDStatus.Draft:

                    enableSave = isEditable && (!isSOD) && (isPDCreator || isPDCreatorSupervisor||isAdmin);
                    btnSaveAndContinue.Enabled = enableSave;
                    btnReset.Enabled = enableSave;
                    AssignEditableControls(enableSave);
                    break;
                //Allow HR to edit the fields during Review Status added by BC 05/24/2011
                case PDStatus.Review:
                    enableSave = isEditable && (hasHRGroupPermission||isAdmin);
                    btnSaveAndContinue.Enabled = btnReset.Enabled = enableSave;
                    AssignEditableControls(enableSave);
                    break;
                case PDStatus.Revise:
                    enableSave = isEditable && (!isSOD) && (isPDCreator || isPDCreatorSupervisor||isAdmin);
                    btnSaveAndContinue.Enabled = enableSave;
                    btnReset.Enabled = enableSave;
                    AssignEditableControls(enableSave);
                    forHRPanel.Visible = true;

                    //enable HR section if PD is editable and has permission to edit the HR only section
                    if (isEditable && (hasHRGroupPermission||isAdmin))
                    {
                        HandleHRControls(true);
                    }
                    else
                    {
                        HandleHRControls(false);
                    }
                    break;
                case PDStatus.FinalReview:
                    enableSave = isEditable && (hasHRGroupPermission||isAdmin);
                    btnSaveAndContinue.Enabled = enableSave;
                    btnReset.Enabled = enableSave;
                    AssignEditableControls(false); //disabling the top section from editing in Review and Final Review
                    break;
                default: //takes care of Published status as well
                    btnSaveAndContinue.Enabled = btnReset.Enabled = isEditable;
                    AssignEditableControls(isEditable);
                    HandleHRControls(isEditable);
                    break;
            }
        }

        private void LoadData(bool reset)
        {
            base.CurrentGoBackPDID = -1;
            OrganizationCode orgCode = new OrganizationCode(PD.OrganizationCodeID);
            Region region = new Region(orgCode.RegionID);

            // row #1
            lblEstablishment.Text = "Department of Interior";
            lblThirdSubdivision.Text = orgCode.OrganizationName;

            // row #2
            lblFirstSubdivision.Text = "US Fish and Wildlife Service";
            //removing this check because check is already in function SafeTextBoxAssign
            //plus this function is also called from reset
            //if (!String.IsNullOrEmpty(PD.FourthSubdivision))
            //{
            ControlUtility.SafeTextBoxAssign(txtFourthSubdivision, PD.FourthSubdivision);
            //}

            // row #3
            if (String.IsNullOrEmpty(PD.SecondSubdivision))
            {
                if (!IsStandardPD)
                {
                    ControlUtility.SafeTextBoxAssign(txtSecondSubdivision, region.RegionName);
                }
            }
            else
            {
                ControlUtility.SafeTextBoxAssign(txtSecondSubdivision, PD.SecondSubdivision);
            }

            //if (!String.IsNullOrEmpty(PD.FifthSubdivision))
            //{
            ControlUtility.SafeTextBoxAssign(txtFifthSubdivision, PD.FifthSubdivision);
            //}

            // row #4
            if (String.IsNullOrEmpty(PD.EmployingOfficeLocation))
            {
                if (!IsStandardPD)
                {
                    ControlUtility.SafeTextBoxAssign(txtEmpOfficeLocation, CurrentUser.EmployingOfficeLocation);
                }
            }
            else
            {
                ControlUtility.SafeTextBoxAssign(txtEmpOfficeLocation, PD.EmployingOfficeLocation);
            }

            if (String.IsNullOrEmpty(PD.DutyLocation))
            {
                if (!IsStandardPD)
                {
                    ControlUtility.SafeTextBoxAssign(txtDutyLocation, txtEmpOfficeLocation.Text);
                }
            }
            else
            {
                ControlUtility.SafeTextBoxAssign(txtDutyLocation, PD.DutyLocation);
            }

            // row #5
            if (!String.IsNullOrEmpty(PD.SubjectToIAaction))
            {
                rblSubjectToIAAction.SelectedIndex = (PD.SubjectToIAaction.ToUpper() == "Y") ? 0 : 1;
            }


            ddlReasonForSubmission.DataTextField = "ReasonForSubmissionName";
            ddlReasonForSubmission.DataValueField = "ReasonForSubmissionID";
            ddlReasonForSubmission.DataSource = LookupWrapper.GetAllReasonForSubmission(true);
            ddlReasonForSubmission.DataBind();

            if (PD.ReasonForSubmissionID != -1)
            {
                ddlReasonForSubmission.SelectedValue = PD.ReasonForSubmissionID.ToString();
            }

            // even though 'drug testing' and 'physical examination' are belong to HR section -
            // set the _default_ values here, which might be overwritten later
            rblDrugTestingRequired.SelectedValue = "0";
            rblPhysicalExaminationRequired.SelectedValue = "0";


            if (HRPanelVisible || (base.HasPermission(enumPermission.CreatePD) && base.CurrentPD.GetCurrentPDStatus() == PDStatus.Revise))
            {
                // row #6
                ddlService.DataTextField = "ServiceName";
                ddlService.DataValueField = "ServiceID";
                ddlService.DataSource = LookupWrapper.GetAllService(true);
                ddlService.DataBind();

                if (PD.ServiceID != -1)
                {
                    ddlService.SelectedValue = PD.ServiceID.ToString();
                }


                // row #7
                if (PD.FLSATypeID != -1)
                {
                    rblFairLaborStandardsAct.SelectedIndex = (PD.FLSATypeID == 1) ? 0 : 1;
                }


                if (PD.FinancialStatementsRequired != null && PD.FinancialStatementsRequired.Trim().Length > 0)
                {
                    //rblFinancialStatementsRequired.Items[PD.FinancialStatementsRequired.Trim().ToUpper() == "Y" ? 0 : 1].Selected = true;
                    rblFinancialStatementsRequired.SelectedIndex = (PD.FinancialStatementsRequired.Trim().ToUpper() == "Y") ? 0 : 1;
                }


                // row #8
                ControlUtility.SafeTextBoxAssign(txtBargaininigUnitStatus, PD.BargainingUnitStatus);

                // row #9
                ddlPositionStatus.DataTextField = "PositionStatusTypeName";
                ddlPositionStatus.DataValueField = "PositionStatusTypeID";
                ddlPositionStatus.DataSource = LookupWrapper.GetAllPositionStatusTypes(true);
                ddlPositionStatus.DataBind();

                if (PD.PositionStatusTypeID != -1)
                {
                    ddlPositionStatus.SelectedValue = PD.PositionStatusTypeID.ToString();
                }


                ControlUtility.SafeTextBoxAssign(txtPositionStatusRemarks, PD.PositionStatusTypeRemark);


                // row #10
                ControlUtility.SafeTextBoxAssign(txtCompetitiveLevelCode, PD.CompetitiveLevelCode);


                ddlPositionSensitivity.DataTextField = "PositionSenesitivityTypeName";
                ddlPositionSensitivity.DataValueField = "PostionSensitivityTypeID";
                ddlPositionSensitivity.DataSource = LookupWrapper.GetAllPostionSensitivityType(true);
                ddlPositionSensitivity.DataBind();

                if (PD.PositionSensitivityTypeID != -1)
                {
                    ddlPositionSensitivity.SelectedValue = PD.PositionSensitivityTypeID.ToString();
                }


                // row #11
                if (PD.DrugTestingRequired != null && PD.DrugTestingRequired.Trim().Length > 0)
                {
                    rblDrugTestingRequired.SelectedIndex = PD.DrugTestingRequired.Trim().ToUpper() == "Y" ? 0 : 1;
                }

                if (PD.PhysicalExaminationRequired != null && PD.PhysicalExaminationRequired.Trim().Length > 0)
                {
                    rblPhysicalExaminationRequired.SelectedIndex = PD.PhysicalExaminationRequired.Trim().ToUpper() == "Y" ? 0 : 1;
                }

                // row #12
                ControlUtility.SafeTextBoxAssign(txtRemarks, PD.Remarks);


                //AssignEditableControls(HRPanelVisible);
            }
            if (!reset)
            {
                AssignValidationGroup();
            }

        }

        private void AssignValidationGroup()
        {
            string validationGroup = "RequiredValuesGroup";

            if (!base.IsStandardPD)
            {
                txtSecondSubdivisionReqVal.ValidationGroup = validationGroup;
                txtEmpOfficeLocationReqVal.ValidationGroup = validationGroup;
                txtDutyLocationReqVal.ValidationGroup = validationGroup;
                txtSecondSubdivisionReqVal.Enabled = true;
                txtEmpOfficeLocationReqVal.Enabled = true;
                txtDutyLocationReqVal.Enabled = true;
            }
            else
            {
                txtSecondSubdivisionReqVal.ValidationGroup = "";
                txtEmpOfficeLocationReqVal.ValidationGroup = "";
                txtDutyLocationReqVal.ValidationGroup = "";
                txtSecondSubdivisionReqVal.Enabled = false;
                txtEmpOfficeLocationReqVal.Enabled = false;
                txtDutyLocationReqVal.Enabled = false;
            }
            rblSubjectToIAActionReqVal.ValidationGroup = validationGroup;
            ddlReasonForSubmissionReqVal.ValidationGroup = validationGroup;

            if (HRPanelVisible && HRPanelRequired)
            {
                txtBargaininigUnitStatusReqVal.ValidationGroup = validationGroup;
                ddlServiceReqVal.ValidationGroup = validationGroup;
                rblFairLaborStandardsActReqVal.ValidationGroup = validationGroup;
                rblFinancialStatementsRequiredReqVal.ValidationGroup = validationGroup;
                ddlPositionStatusReqVal.ValidationGroup = validationGroup;
                txtCompetitiveLevelCodeReqVal.ValidationGroup = validationGroup;
                ddlPositionSensitivityReqVal.ValidationGroup = validationGroup;
                rblDrugTestingRequiredReqVal.ValidationGroup = validationGroup;
                rblPhysicalExaminationRequiredReqVal.ValidationGroup = validationGroup;

                spnBargaininigUnitStatus.InnerHtml = "&nbsp;*";
                spnService.InnerHtml = "&nbsp;*";
                spnFairLaborStandardsAct.InnerHtml = "&nbsp;*";
                spnFinancialStatementsRequired.InnerHtml = "&nbsp;*";
                spnPositionStatus.InnerHtml = "&nbsp;*";
                //spnCompetitiveLevelCode.InnerHtml = "&nbsp;*";
                spnPositionSensitivity.InnerHtml = "&nbsp;*";
                spnDrugTestingRequired.InnerHtml = "&nbsp;*";
                spnPhysicalExaminationRequired.InnerHtml = "&nbsp;*";
            }

            CharacteristicsValSumm.ValidationGroup = validationGroup;
            btnSaveAndContinue.ValidationGroup = validationGroup;
            btnReset.ValidationGroup = string.Empty;
        }

        private void HandleHRControls(bool enable)
        {

            ddlService.Enabled = enable;
            rblFairLaborStandardsAct.Enabled = enable;
            rblFinancialStatementsRequired.Enabled = enable;
            txtBargaininigUnitStatus.Enabled = enable;
            ddlPositionStatus.Enabled = enable;
            txtPositionStatusRemarks.Enabled = enable;
            txtCompetitiveLevelCode.Enabled = enable;
            ddlPositionSensitivity.Enabled = enable;
            rblDrugTestingRequired.Enabled = enable;
            rblPhysicalExaminationRequired.Enabled = enable;
            txtRemarks.Enabled = enable;
        }

        private void AssignEditableControls(bool editable)
        {
            txtFourthSubdivision.Enabled = editable;
            txtSecondSubdivision.Enabled = editable;

            txtFifthSubdivision.Enabled = editable;
            txtEmpOfficeLocation.Enabled = editable;
            txtDutyLocation.Enabled = editable;

            rblSubjectToIAAction.Enabled = editable;
            rblSubjectToIAActionReqVal.Enabled = editable;
            ddlReasonForSubmission.Enabled = editable;
        }

        private void UpdatePD(PositionDescription editPD)
        {
            editPD.DeptAgencyEstablishment = lblEstablishment.Text.Trim();
            editPD.FirstSubdivision = lblFirstSubdivision.Text.Trim();
            editPD.SecondSubdivision = txtSecondSubdivision.Text.Trim();
            editPD.FourthSubdivision = txtFourthSubdivision.Text.Trim();
            editPD.FifthSubdivision = txtFifthSubdivision.Text.Trim();

            editPD.EmployingOfficeLocation = txtEmpOfficeLocation.Text.Trim();
            editPD.DutyLocation = txtDutyLocation.Text.Trim();

            if (rblSubjectToIAAction.SelectedIndex != -1)
                editPD.SubjectToIAaction = rblSubjectToIAAction.SelectedValue;

            editPD.ReasonForSubmissionID = Convert.ToInt32(ddlReasonForSubmission.SelectedValue);
            editPD.ReasonForSubmission = ddlReasonForSubmission.SelectedItem.Text;

            if (HRPanelVisible)
            {
                // row #6
                editPD.ServiceID = Convert.ToInt32(ddlService.SelectedValue);
                editPD.Service = ddlService.SelectedItem.Text;

                // row #7
                if (rblFairLaborStandardsAct.SelectedIndex != -1)
                {
                    editPD.FLSATypeID = Convert.ToInt32(rblFairLaborStandardsAct.SelectedValue);
                    editPD.FLSAType = LookupWrapper.GetAllFLSATypes(true).Where(p => p.FLSATypeID == PD.FLSATypeID).Single().FLSATypeName;
                }

                editPD.FinancialStatementsRequired = rblFinancialStatementsRequired.SelectedIndex == 0 ? "Y" : "N";
                // row #8
                editPD.BargainingUnitStatus = txtBargaininigUnitStatus.Text.Trim();
                // row #9
                if (ddlPositionStatus.SelectedIndex != -1)
                {
                    editPD.PositionStatusTypeID = Convert.ToInt32(ddlPositionStatus.SelectedValue);
                    editPD.PositionStatusType = LookupWrapper.GetAllPositionStatusTypes(true).Where(p => p.PositionStatusTypeID == PD.PositionStatusTypeID).Single().PositionStatusTypeName;
                }

                editPD.PositionStatusTypeRemark = txtPositionStatusRemarks.Text.Trim();

                // row #10
                editPD.CompetitiveLevelCode = txtCompetitiveLevelCode.Text.Trim();

                if (ddlPositionSensitivity.SelectedIndex != -1)
                {
                    editPD.PositionSensitivityTypeID = Convert.ToInt32(ddlPositionSensitivity.SelectedValue);
                    editPD.PositionSenesitivityType = ddlPositionSensitivity.SelectedItem.Text;
                }

                // row #11
                if (rblDrugTestingRequired.SelectedIndex != -1)
                {
                    editPD.DrugTestingRequired = rblDrugTestingRequired.SelectedIndex == 0 ? "Y" : "N";
                }

                if (rblPhysicalExaminationRequired.SelectedIndex != -1)
                {
                    editPD.PhysicalExaminationRequired = rblPhysicalExaminationRequired.SelectedIndex == 0 ? "Y" : "N";
                }

                // row #12
                editPD.Remarks = txtRemarks.Text.Trim();
            }

            editPD.Update();
        }


        private void NextStep(PositionDescription editPD)
        {
            bool isCLSODPD = editPD.PositionDescriptionTypeID == (int)PDChoiceType.CLStatementOfDifferencePD;

            if (isCLSODPD)
            {
                //checking if user has permission to go to approvals page
                if (base.isPDCreatorSupervisor(false) || base.HasHRGroupPermission)
                {
                    if (isCLSODPD && editPD.LadderPosition > 0 && editPD.AssociatedFullPD > 0)
                    {
                        this.ctrlCareerLadderBundle.SetMessage(enumValidationcode.SignAndSubmit, string.Empty);
                        this.ctrlCareerLadderBundle.ReloadControl();
                        btnSaveAndContinue.Enabled = false;
                    }
                }
                else //don't have permission to access Approvals page
                {
                    this.ctrlCareerLadderBundle.SetMessage(enumValidationcode.SaveAndUnlock, string.Empty);
                    this.ctrlCareerLadderBundle.ReloadControl();
                    btnSaveAndContinue.Enabled = false;
                }
            }
            else
                base.GoToPDLink("~/CreatePD/Factors.aspx");
        }

        #endregion

        #region [ Event Handlers ]

        protected void btnSaveAndContinue_Click(object sender, EventArgs e)
        {
            try
            {
                PositionDescription editPD = base.CurrentPD;
                bool isCLSODPD = editPD.PositionDescriptionTypeID == (int)PDChoiceType.CLStatementOfDifferencePD;

                UpdatePD(editPD);

                if (isCLSODPD)
                {
                    bool haserrors = false;
                    string validationErrors = base.GetValidationErros(ref haserrors);
                    if (haserrors)
                    {
                        //ctrlCareerLadderBundle.ValidationMessage = validationErrors;
                        ctrlCareerLadderBundle.SetMessage(enumValidationcode.ValidationErrors, validationErrors);
                        ctrlCareerLadderBundle.ReloadControl();
                    }
                    else
                    {
                        bool hasCareerLadderErrors = false;
                        string careerLadderErrors = base.GetCareerLadderErrors(ref hasCareerLadderErrors);
                        if (hasCareerLadderErrors)
                        {
                            this.ctrlCareerLadderBundle.SetMessage(enumValidationcode.ValidationErrors, careerLadderErrors);
                            //this.ctrlCareerLadderBundle.ValidationMessage = careerLadderErrors;
                            this.ctrlCareerLadderBundle.ReloadControl();
                        }
                        else
                            NextStep(editPD);
                    }
                }
                else
                {
                    NextStep(editPD);
                }
            }
            catch (Exception X)
            {
                base.HandleException(X);
            }
        }




        protected void btnReset_Click(object sender, EventArgs e)
        {
            txtFourthSubdivision.Text = String.Empty;
            txtSecondSubdivision.Text = String.Empty;
            txtFifthSubdivision.Text = String.Empty;
            txtEmpOfficeLocation.Text = String.Empty;
            txtDutyLocation.Text = String.Empty;
            rblSubjectToIAAction.ClearSelection();
            ddlReasonForSubmission.ClearSelection();

            txtBargaininigUnitStatus.Text = String.Empty;
            ddlService.ClearSelection();
            rblFairLaborStandardsAct.ClearSelection();
            rblFinancialStatementsRequired.ClearSelection();
            ddlPositionStatus.ClearSelection();
            txtPositionStatusRemarks.Text = String.Empty;
            txtCompetitiveLevelCode.Text = String.Empty;
            ddlPositionSensitivity.ClearSelection();
            rblDrugTestingRequired.ClearSelection();
            rblPhysicalExaminationRequired.ClearSelection();
            txtRemarks.Text = String.Empty;

            LoadData(true);
        }

        #endregion

        #region [ Private Properties ]

        private PositionDescription PD
        {
            get
            {
                if (pd == null)
                {
                    pd = base.CurrentPD;
                }

                return pd;
            }
        }

        private PositionWorkflowStatus WorkflowStatus
        {
            get
            {
                if (workflowStatus == null)
                {
                    workflowStatus = base.CurrentPDWorkflowStatus;
                }

                return workflowStatus;
            }
        }

        private bool HRPanelVisible
        {
            get
            {
                bool visible = false;
                PDStatus status = base.CurrentPD.GetCurrentPDStatus();
                if (PD != null && WorkflowStatus != null)
                {
                    if ((base.HasPermission(enumPermission.MaintainHRSection)) || (status == PDStatus.Published))
                    {
                        visible = true;
                    }
                }

                return visible;
            }
        }

        private bool HRPanelRequired
        {
            get
            {
                bool required = true;

                if ((WorkflowStatus.WorkflowStatusID == (int)PDStatus.Review ||
                    WorkflowStatus.WorkflowStatusID == (int)PDStatus.Revise ||
                    WorkflowStatus.WorkflowStatusID == (int)PDStatus.FinalReview) &&
                    base.HasPermission(enumPermission.MaintainHRSection))
                {
                    required = true;
                }

                return required;
            }
        }

        #endregion

        #region [ Private Fields ]
        private PositionDescription pd = null;
        private PositionWorkflowStatus workflowStatus = null;
        #endregion
    }
}
