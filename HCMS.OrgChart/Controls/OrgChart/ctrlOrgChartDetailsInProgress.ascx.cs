using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.Lookups;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.OrganizationChart.Exceptions;
using HCMS.Business.Security;
using HCMS.WebFramework.Security;
using System.Web.Security;
using System.Configuration;
using HCMS.Business.Positions.Exceptions;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.OrgChart.Controls.OrgChart
{
    public partial class ctrlOrgChartDetailsInProgress : OrgChartRequiredUserControlBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.checkboxReplaceRoot.CheckedChanged += new EventHandler(checkboxReplaceRoot_CheckedChanged);
            this.checkboxSignAs.CheckedChanged += new EventHandler(checkboxSignAs_CheckedChanged);
            this.checkboxSignAsImport.CheckedChanged += new EventHandler(checkboxSignAsImport_CheckedChanged);
            this.buttonSaveNewRoot.Click += new EventHandler(buttonSaveNewRoot_Click);
            this.buttonCancelNewRoot.Click += new EventHandler(buttonCancelNewRoot_Click);
            this.buttonChartPositions.Click += new EventHandler(buttonChartPositions_Click);
            this.buttonDeleteOrgChart.Click += new EventHandler(buttonDeleteOrgChart_Click);
            this.buttonSubmitToDraft.Click += new EventHandler(buttonSubmitToDraft_Click);
            this.buttonSubmitToReview.Click += new EventHandler(buttonSubmitToReview_Click);
            this.buttonSubmitToApprove.Click += new EventHandler(buttonSubmitToApprove_Click);
            this.buttonSignAndPublish.Click += new EventHandler(buttonSignAndPublish_Click);
            this.customValPassword.ServerValidate += new ServerValidateEventHandler(customValPassword_ServerValidate);
            base.OnInit(e);
        }

        private void toggleReplaceRoot(bool isChecked)
        {
            this.panelReplaceRoot.Visible = isChecked; 

            this.buttonDeleteOrgChart.Enabled = !isChecked;
            this.buttonSubmitToDraft.Enabled = !isChecked;
            this.buttonSubmitToReview.Enabled = !isChecked;
            this.buttonSubmitToApprove.Enabled = !isChecked;

            if (isChecked)
            {
                WorkforcePlanningPositionCollection listPositions = WorkforcePlanningPositionManager.Instance.GetPotentialRootReplacementPositions(base.CurrentOrgChartID);

                bool hasData = listPositions.Count > 0;
                this.buttonSaveNewRoot.Enabled = hasData;

                // bind root position dropdown
                ControlUtility.BindRadComboBoxControl(this.dropDownPositions, listPositions, null, "PositionLineItemFullNameReverse", "WFPPositionID", "<<-- Select New Top Level Position -->>");
            }
        }

        private void checkboxReplaceRoot_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                toggleReplaceRoot(this.checkboxReplaceRoot.Checked);
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }

        private void checkboxSignAs_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                this.rowSignAsFor.Visible = this.checkboxSignAs.Checked;
                this.rowSignAsSystemImport.Visible = this.checkboxSignAs.Checked && base.IsSystemAdministrator;

                // reset import section
                toggleImportDisplay(false);
                this.checkboxSignAsImport.Checked = false;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void toggleImportDisplay(bool asImport)
        {
            this.textboxSigningAsFor.Enabled = !asImport;

            if (asImport)
                this.textboxSigningAsFor.Text = GetLocalResourceObject("SystemImportName").ToString();
            else
                this.textboxSigningAsFor.Text = string.Empty;
        }

        private void checkboxSignAsImport_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                toggleImportDisplay(this.checkboxSignAsImport.Checked);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                    loadData();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void loadData()
        {
            base.RefreshOrgChartDataOnly();
            OrganizationChart chart = base.CurrentOrgChart;

            if (chart.OrganizationChartID == -1)
                base.PrintErrorMessage(GetLocalResourceObject("OrganizationChartNotFoundMessage").ToString());
            else
            {
                // load data
                base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(), chart.OrganizationName, chart.OrgCode.OrganizationCodeValue));
                this.customOrgChartDetails.BindData(chart);

                // set workflow button view
                setView(chart);

                string mailAddressLineItem = GetLocalResourceObject("NullMailAddressLineItem").ToString();

                if (chart.OrgCode != null && (!string.IsNullOrWhiteSpace(chart.OrgCode.MailCity) || !string.IsNullOrWhiteSpace(chart.OrgCode.MailStateAbbr)))
                {
                    if (string.IsNullOrWhiteSpace(chart.OrgCode.MailCity))
                        // MailCity is null -- use State
                        mailAddressLineItem = chart.OrgCode.MailStateAbbr;
                    else if (string.IsNullOrWhiteSpace(chart.OrgCode.MailStateAbbr))
                        // MailState is null -- use city
                        mailAddressLineItem = chart.OrgCode.MailCity;
                    else
                        // use both
                        mailAddressLineItem = string.Format("{0}, {1}", chart.OrgCode.MailCity, chart.OrgCode.MailStateAbbr);
                }

                this.literalOrgCodeLocation.Text = mailAddressLineItem;

                string topPositionLineItem = string.Empty;

                if (chart.StartPointWFPPositionID == -1)
                    topPositionLineItem = GetLocalResourceObject("NoTopLevelPositionMessage").ToString();
                else
                    topPositionLineItem = chart.StartPointPositionLineItemFullName;

                this.literalTopLevelPosition.Text = topPositionLineItem;
                this.literalWorkflowStatus.Text = chart.OrgWorkflowStatusName;

                if (chart.CreatedBy != null)
                {
                    bool hasCreatedByName = !string.IsNullOrWhiteSpace(chart.CreatedBy.FullName);
                    this.rowCreatedOn.Visible = chart.CreatedBy.ActionDate.HasValue;
                    this.rowCreatedBy.Visible = hasCreatedByName;

                    if (chart.CreatedBy.ActionDate.HasValue)
                        this.literalCreatedDate.Text = chart.CreatedBy.ActionDate.Value.ToString();

                    if (hasCreatedByName)
                        this.literalCreatedByFullName.Text = chart.CreatedBy.FullName;
                }

                if (chart.CheckedOutBy != null)
                {
                    bool hasCheckedOutInfo = chart.CheckedOutBy.ActionDate.HasValue && !string.IsNullOrWhiteSpace(chart.CheckedOutBy.FullName);
                    this.rowCheckedOut.Visible =  hasCheckedOutInfo;

                    if (hasCheckedOutInfo)
                        this.literalCheckedOutBy.Text = string.Format(GetLocalResourceObject("CheckedOutLineMessage").ToString(), 
                            chart.CheckedOutBy.FullName, chart.CheckedOutBy.ActionDate.Value.ToString());
                }

                if (chart.UpdatedBy != null)
                {
                    bool hasLastUpdatedName = !string.IsNullOrWhiteSpace(chart.UpdatedBy.FullName);
                    this.rowUpdatedOn.Visible = chart.UpdatedBy.ActionDate.HasValue;
                    this.rowUpdatedBy.Visible = hasLastUpdatedName;

                    if (chart.UpdatedBy.ActionDate.HasValue)
                        this.literalLastUpdated.Text = chart.UpdatedBy.ActionDate.Value.ToString();

                    if (hasLastUpdatedName)
                        this.literalLastUpdatedBy.Text = chart.UpdatedBy.FullName;
                }
            }
        }

        private void setView(OrganizationChart chart)
        {
            // set visibility of buttons
            bool isRootAcknowledged = chart.IsRootAcknowledged;
            
            // show for Draft or Review
            this.buttonDeleteOrgChart.Visible = (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft || chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Review);
            this.rowReplaceRoot.Visible = (base.CurrentOrgChartNavMode == enumNavigationMode.Edit) && 
                (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft || chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Review);

            // Only show Submit to Review/Approval/Sign and Publish if there are no Abolished Positions
            // We always show Submit to Draft (unless the chart is already in Draft)
            this.spanSubmitActionButtons.Visible = (isRootAcknowledged && chart.AbolishedPositionCount == 0 && chart.BrokenHierarchyCount == 0 && chart.StartPointWFPPositionID != -1);
            
            //-----------------------------------------------------
            // workflow buttons
            // show for Review and Approve
            this.buttonSubmitToDraft.Visible = (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Review || chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Approval);

            // show for Draft
            this.buttonSubmitToReview.Visible = (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft);

            // show for Draft or Review
            this.buttonSubmitToApprove.Visible = (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft || chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Review);

            // show for Approve
            bool showApproval = (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Approval);
            this.buttonSignAndPublish.Visible = showApproval;
            this.rowPublish.Visible = showApproval;

            // now set button labels
            string submitToString = GetLocalResourceObject("SubmitButtonPrefix").ToString();
            string revertToString = GetLocalResourceObject("RevertButtonPrefix").ToString();
            string draftSuffix = GetLocalResourceObject("DraftSuffix").ToString();
            string reviewSuffix = GetLocalResourceObject("ReviewSuffix").ToString();
            string approvalSuffix = GetLocalResourceObject("ApprovalSuffix").ToString();

            if (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft)
            {
                this.buttonSubmitToReview.Text = string.Format(submitToString, reviewSuffix);
                this.buttonSubmitToApprove.Text = string.Format(submitToString, approvalSuffix);
            }
            else if (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Review)
            {
                this.buttonSubmitToDraft.Text = string.Format(revertToString, draftSuffix);
                this.buttonSubmitToApprove.Text = string.Format(submitToString, approvalSuffix);
            }
            else if (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Approval)
                this.buttonSubmitToDraft.Text = string.Format(revertToString, draftSuffix);
        }

        #region Button Click Events

        private void buttonSaveNewRoot_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    OrganizationChart chart = new OrganizationChart()
                    {
                        OrganizationChartID = base.CurrentOrgChartID,
                        UpdatedBy = new ActionUser(base.CurrentUserID),
                        StartPointWFPPositionID = int.Parse(this.dropDownPositions.SelectedValue)
                    };

                    // save new top level position
                    OrganizationChartManager.Instance.UpdateRootNode(chart);

                    // reset replace root section
                    this.checkboxReplaceRoot.Checked = false;
                    this.toggleReplaceRoot(false);

                    // reload page data
                    loadData();
                }
            }
            catch (InvalidRootNodePositionReplacementException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("InvalidRootNodePositionReplacementExceptionMessage").ToString(), true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonCancelNewRoot_Click(object sender, EventArgs e)
        {
            try
            {
                this.checkboxReplaceRoot.Checked = false;
                this.toggleReplaceRoot(false);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonChartPositions_Click(object sender, EventArgs e)
        {
            try
            {
                base.GoToOrgChartPositionManager();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonDeleteOrgChart_Click(object sender, EventArgs e)
        {
            try
            {
                // Delete this organization chart
                OrganizationChartManager.Instance.Delete(base.CurrentOrgChartID);

                // clear org chart session
                base.ClearCurrentOrgChart();

                // go to tracker
                base.GoToOrgChartTracker();
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }

        #endregion

        #region Button Events -- Org Chart Workflow
        
        private void buttonSubmitToDraft_Click(object sender, EventArgs e)
        {
            try
            {
                // change status to draft
                OrganizationChartManager.Instance.SubmitToNextStatus(base.CurrentOrgChartID, enumOrgWorkflowStatus.Draft, base.CurrentUserID);

                base.ClearCurrentOrgChart();
                base.GoToOrgChartTracker();
            }            
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonSubmitToReview_Click(object sender, EventArgs e)
        {
            try
            {
                // change status to review
                OrganizationChartManager.Instance.SubmitToNextStatus(base.CurrentOrgChartID, enumOrgWorkflowStatus.Review, base.CurrentUserID);

                base.ClearCurrentOrgChart();
                base.GoToOrgChartTracker();
            }
            catch (MissingRootNodePositionException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("MissingRootNodePositionExceptionMessage").ToString(), true);
            }
            catch (AbolishedPositionsExistException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("AbolishedPositionsExistExceptionMessage").ToString(), true);
            }
            catch (ChartBrokenHierarchyException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("BrokenHierarchyExceptionMessage").ToString(), true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonSubmitToApprove_Click(object sender, EventArgs e)
        {
            try
            {
                // change status to approval
                OrganizationChartManager.Instance.SubmitToNextStatus(base.CurrentOrgChartID, enumOrgWorkflowStatus.Approval, base.CurrentUserID);

                base.ClearCurrentOrgChart();
                base.GoToOrgChartTracker();
            }
            catch (MissingRootNodePositionException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("MissingRootNodePositionExceptionMessage").ToString(), true);
            }
            catch (AbolishedPositionsExistException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("AbolishedPositionsExistExceptionMessage").ToString(), true);
            }
            catch (ChartBrokenHierarchyException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("BrokenHierarchyExceptionMessage").ToString(), true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void customValPassword_ServerValidate(object source, ServerValidateEventArgs e)
        {
            bool isValid = false;

            try
            {
                isValid = Membership.ValidateUser(base.CurrentUser.MappedUserName, this.textboxPassword.Text);
            }
            catch (Exception)
            {
                // do nothing 
                isValid = false;
            }

            e.IsValid = isValid;
        }

        private void buttonSignAndPublish_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    // Update Publish stored procedure to pull first and last name from user ID)
                    int updatedByUserID = base.CurrentUserID;
                    int approvedByUserID = (!this.checkboxSignAs.Checked || (this.checkboxSignAs.Checked && !this.checkboxSignAsImport.Checked)) ?
                                        updatedByUserID : ConfigWrapper.SystemImportUserID;
                    //changing updated by userid to system import userid as per email specification from Pam 9/9/2015
                    if (approvedByUserID == ConfigWrapper.SystemImportUserID)
                    {
                        updatedByUserID = ConfigWrapper.SystemImportUserID;
                    }
                    string signingAsFor = (this.checkboxSignAs.Checked && !this.checkboxSignAsImport.Checked) ? this.textboxSigningAsFor.Text : string.Empty;

                    OrganizationChartManager.Instance.Publish(base.CurrentOrgChartID, approvedByUserID, updatedByUserID, signingAsFor);

                    base.ClearCurrentOrgChart();
                    base.GoToOrgChartTracker();
                }
            }
            catch (MissingRootNodePositionException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("MissingRootNodePositionExceptionMessage").ToString(), true);
            }
            catch (AbolishedPositionsExistException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("AbolishedPositionsExistExceptionMessage").ToString(), true);
            }
            catch (ChartBrokenHierarchyException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("BrokenHierarchyExceptionMessage").ToString(), true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

        protected override void ToggleReadOnlyView(enumNavigationMode selectedMode)
        {
            try
            {
                bool accessOK = (selectedMode == enumNavigationMode.Insert || selectedMode == enumNavigationMode.Edit);
                customReadOnlyLabel.Visible = !accessOK;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
    }
}