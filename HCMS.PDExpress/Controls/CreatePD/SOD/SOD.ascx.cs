using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

using Telerik.Web.UI;

using HCMS.Business.Base;
using HCMS.Business.Common;
using HCMS.Business.Search;
using HCMS.Business.PD;
using HCMS.Business.Lookups;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.WebFramework.BaseControls;

namespace HCMS.PDExpress.Controls.CreatePD.SOD
{
    public partial class SOD : CreatePDUserControlBase
    {
        PDStatus _currentStatus = PDStatus.Null;
        PositionDescription _currentPD = new PositionDescription();
        bool _isEdit = false;

        #region Page Events

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
        }

        protected override void OnLoad(EventArgs e)
        {
            if (base.CurrentAssociatedPDID != NULLPDID) //New SOD
            {
                CurrentLocalPD = base.CurrentSODFullPerformancePD;
            }
            else
            {
                CurrentStatus = base.CurrentPD.GetCurrentPDStatus();
                CurrentLocalPD = base.CurrentPD;
            }
            if (!IsPostBack)
            {
                loadData();
            }

            base.OnLoad(e);
        }
        private void BindOptions()
        {
            rblText2Options.Items.Clear();
            List<SODParagraphOptions> optionsList = LookupWrapper.GetAllSODParagraphOptions(false);
            ListItem lItem;
            foreach (SODParagraphOptions SODOption in optionsList)
            {
                lItem = new ListItem(string.Format("<b>{0}</b><br />{1}", SODOption.SODParagraphOptionName, SODOption.SODParagraphOptionText), SODOption.SODParagraphOptionID.ToString());
                rblText2Options.Items.Add(lItem);
            }
        }

        private void loadData()
        {
            BindOptions();

            if (base.CurrentAssociatedPDID != NULLPDID) //New SOD  
            {
                lblSODHeader.Text = string.Format("Statement of Difference for PD No. {0} with Grade Level {1}-{2}.", this.CurrentLocalPD.PositionDescriptionID, this.CurrentLocalPD.PayPlanAbbrev, this.CurrentLocalPD.ProposedFPGrade);

                txtText1.Text = string.Format("The below statements along with the Full Performance PD - {0} constitute a complete PD at the level of this SOD.", this.CurrentLocalPD.PositionDescriptionID);
            }
            else
            {

                //  if (!IsPostBack) // commented this check because this method is called from btn_cancel also
                //  {
                //If the base.currentPD is SOD, that means it's in edit mode.
                PDChoiceType? currentPDChoiceType = (PDChoiceType)this.CurrentLocalPD.PositionDescriptionTypeID;
                if (currentPDChoiceType == PDChoiceType.CLStatementOfDifferencePD || currentPDChoiceType == PDChoiceType.StatementOfDifferencePD)
                {
                    PositionDescription AssociatedFPLPD = new PositionDescription(CurrentLocalPD.AssociatedFullPD);

                    lblSODHeader.Text = string.Format("Statement of Difference for PD No. {0} with Grade Level {1}-{2}.", AssociatedFPLPD.PositionDescriptionID, AssociatedFPLPD.PayPlanAbbrev, AssociatedFPLPD.ProposedFPGrade);

                    SetProgressBar();
                    ctrlCreatePDWorkflowNote.Visible = true;
                    IsEdit = true;
                    ControlUtility.SafeTextBoxAssign(txtText1, this.CurrentLocalPD.ParagraphOneText);
                    ControlUtility.SafeTextBoxAssign(txtText3, this.CurrentLocalPD.ParagraphThreeText);
                    ControlUtility.SafeListControlSelect(rblText2Options, this.CurrentLocalPD.ParagraphTwoText);
                }
                //}
            }
        }

        protected override void OnPreRender(EventArgs e)
        {//CurrentLocalPD will not be a SOD for the first time when SOD is not yet generated because the currentlocalpd is set to
            //current full performance pd.
            PDChoiceType? currentPDChoiceType = (PDChoiceType)this.CurrentLocalPD.PositionDescriptionTypeID;

            bool isSODGenerated = (currentPDChoiceType == PDChoiceType.CLStatementOfDifferencePD || currentPDChoiceType == PDChoiceType.StatementOfDifferencePD);
            //btn to create sod should be visible only when sod is yet not generated
            btnCreateSOD.Visible = !isSODGenerated;
            if (isSODGenerated)
            {
                //btn submit and save should be visible when sod is generated
                btnSubmit.Visible = isSODGenerated;
                //changed this because now we are no longer directing them to approvals but are directing them to occupation  
                //btnSubmit.Text = (base.CurrentPD.GetCurrentPDStatus() == PDStatus.Draft) && base.HasPermission(enumPermission.CompleteSupervisoryCertification) ? "Submit for Review" : "Submit";

                btnCancel.Text = isSODGenerated ? "Reset" : "Cancel";
                // set read-only fields/buttons
                bool isEditable = !base.IsPDReadOnly;
                bool isPDCreator = base.CurrentPD.PDCreatorID.Equals(base.CurrentUser.UserID);
                bool isPDCreatorSupervisor = base.isPDCreatorSupervisor(false);
                bool isHMEnabled = (isPDCreator || isPDCreatorSupervisor);
                bool hasHRGroupPermission = (base.HasPermission(enumPermission.CompleteHRCertification) || base.HasPermission(enumPermission.MaintainEvaluationStatements) ||
                        base.HasPermission(enumPermission.MaintainHRSection) || base.HasPermission(enumPermission.MaintainFactorRecommendation) ||
                            base.HasPermission(enumPermission.PublishPD));
                bool enableSave = false;

                switch (CurrentStatus)
                {
                    case PDStatus.Draft:
                    case PDStatus.Revise:
                        enableSave = isEditable && isHMEnabled;
                        btnSubmit.Enabled = enableSave;
                        btnCancel.Enabled = enableSave;
                        break;
                    case PDStatus.Review:
                        bool isHREnabled = hasHRGroupPermission;
                        enableSave = isEditable && (isHMEnabled || isHREnabled);
                        btnSubmit.Enabled = enableSave;
                        btnCancel.Enabled = enableSave;
                        break;
                    case PDStatus.FinalReview:
                    case PDStatus.Published:
                        btnSubmit.Enabled = false;//HR should not be allowed to change the options.
                        btnCancel.Enabled = false;

                        break;
                    default: //takes care of PUBLISHED status as well
                        btnSubmit.Enabled = isEditable;
                        btnCancel.Enabled = isEditable;

                        break;
                }
            }
            base.OnPreRender(e);
        }

        private void SetProgressBar()
        {
            switch (CurrentStatus)
            {
                case PDStatus.Draft:
                    this.ctrlCreatePDMapStatusProgress.PercentComplete = Convert.ToSingle(20.00);
                    break;
                case PDStatus.Review:
                    this.ctrlCreatePDMapStatusProgress.PercentComplete = Convert.ToSingle(40.00);
                    break;
                case PDStatus.Revise:
                    this.ctrlCreatePDMapStatusProgress.PercentComplete = Convert.ToSingle(60.00);
                    //this.btnSubmit.Text = "Save and ";
                    break;
                case PDStatus.FinalReview:
                    this.ctrlCreatePDMapStatusProgress.PercentComplete = Convert.ToSingle(80.00);
                    //this.btnSubmit.Text = "Go To Approvals";
                    break;
                case PDStatus.Published:
                    this.ctrlCreatePDMapStatusProgress.PercentComplete = Convert.ToSingle(100.00);
                    break;
                default:
                    this.ctrlCreatePDMapStatusProgress.PercentComplete = Convert.ToSingle(20.00);
                    break;
            }

        }


        #endregion

        #region Properties

        private bool IsEdit
        {
            get
            {
                return this._isEdit;
            }
            set
            {
                this._isEdit = value;
            }
        }

        private PDStatus CurrentStatus
        {
            get { return _currentStatus; }
            set { _currentStatus = value; }
        }

        private PositionDescription CurrentLocalPD
        {
            get { return _currentPD; }
            set { _currentPD = value; }
        }

        #endregion

        #region Custom Validators

        protected void cvSODOptions_ServerValidate(object source, ServerValidateEventArgs args)
        {
            try
            {
                bool isSelected = false;

                foreach (ListItem item in rblText2Options.Items)
                {
                    if (item.Selected)
                    {
                        isSelected = true;
                    }
                }

                if (!isSelected)
                {
                    args.IsValid = false;
                    cvSODOptions.ErrorMessage = "You must select at least one of the paragraph 2 options to create statement of difference.";
                }
                else
                    args.IsValid = true;
            }
            catch (Exception X)
            {
                base.HandleException(X);
            }
        }

        #endregion

        #region Button Events

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    //Commenting code to validate as we are no longer updating the status from here
                    // string validationerrors = string.Empty;

                    //  validationerrors = CurrentPD.Validate();

                    // if (validationerrors.Length == 0)
                    // {
                    PositionDescription SODPD = this.CurrentLocalPD;
                    DateTime currentTime = DateTime.Now;

                    //Update SOD
                    SODPD.ParagraphOneText = txtText1.Text;
                    SODPD.ParagraphThreeText = txtText3.Text;
                    SODPD.ParagraphTwoText = rblText2Options.SelectedItem.Value;
                    SODPD.UpdatedByID = base.CurrentUser.UserID;
                    SODPD.UpdateDate = currentTime;
                    SODPD.Update();
                    base.CurrentPDID = SODPD.PositionDescriptionID;
                    base.SafeRedirect("~/CreatePD/Occupation.aspx");
                    //if (base.HasPermission(enumPermission.CompleteSupervisoryCertification) || base.HasPermission(enumPermission.CompleteHRCertification))
                    //{
                    //    base.GoToPDLink("~/CreatePD/Approvals.aspx");
                    //}
                    //}
                    //else
                    //{
                    //    base.PrintMessage(validationerrors, true, true);
                    //}
                }
            }
            catch (Exception X)
            {
                base.HandleException(X);
            }
        }

        protected void btnCreateSOD_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    PositionDescription SODPD = new PositionDescription();
                    DateTime currentTime = DateTime.Now;

                    SODPD.PDCreatorID = base.CurrentUser.UserID;
                    SODPD.AssociatedFullPD = this.CurrentLocalPD.PositionDescriptionID;
                    SODPD.ParagraphOneText = txtText1.Text;
                    SODPD.ParagraphThreeText = txtText3.Text;
                    SODPD.ParagraphTwoText = rblText2Options.SelectedItem.Value;
                    SODPD.CreateSOD();

                    if (SODPD.PositionDescriptionID != NULLPDID)
                    {
                        base.CurrentPDID = SODPD.PositionDescriptionID;
                        base.SafeRedirect("~/CreatePD/Occupation.aspx");
                    }
                    else
                        base.PrintErrorMessage("PD Express could not create a statement of difference PD for the selected position description.", true);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            bool isSODGenerated = (this.CurrentLocalPD.PositionDescriptionTypeID == (int)PDChoiceType.StatementOfDifferencePD);
            if (isSODGenerated)
            {
                //reset the options
                loadData();

            }
            else
            {

                base.SafeRedirect("~/CreatePD/PDTypeChoice.aspx");
            }
        }

        #endregion
    }
}
