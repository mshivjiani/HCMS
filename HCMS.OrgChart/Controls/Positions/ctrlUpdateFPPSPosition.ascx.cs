using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.Business.OrganizationChart.Positions.Exceptions;
using HCMS.Business.OrganizationChart;
using HCMS.Business.Lookups;

namespace HCMS.OrgChart.Controls.Positions
{
    public partial class ctrlUpdateFPPSPosition : OrgChartRequiredUserControlBase
    {
        private const string VIEWPOSIDKEY = "viewPosID";
        private string _NotSpecifiedLine = string.Empty;

        public int EditPositionID
        {
            get
            {
                if (ViewState["EditPositionID"] == null)
                    ViewState["EditPositionID"] = -1;

                return (int)ViewState["EditPositionID"];
            }
            set
            {
                ViewState["EditPositionID"] = value;
            }
        }

        public int OriginalReportsToID
        {
            get
            {
                if (ViewState["OriginalReportsToID"] == null)
                    ViewState["OriginalReportsToID"] = -1;

                return (int)ViewState["OriginalReportsToID"];
            }
            set
            {
                ViewState["OriginalReportsToID"] = value;
            }
        }

        public bool AccessOK
        {
            get
            {
                if (ViewState["AccessOK"] == null)
                    ViewState["AccessOK"] = false;

                return (bool)ViewState["AccessOK"];
            }
            set
            {
                ViewState["AccessOK"] = value;
            }
        }

        public bool IsChartPosition
        {
            get
            {
                if (ViewState["IsChartPosition"] == null)
                    ViewState["IsChartPosition"] = false;

                return (bool)ViewState["IsChartPosition"];
            }
            set
            {
                ViewState["IsChartPosition"] = value;
            }
        }

        public bool TopLevelEditOK
        {
            get
            {
                if (ViewState["TopLevelEditOK"] == null)
                    ViewState["TopLevelEditOK"] = false;

                return (bool)ViewState["TopLevelEditOK"];
            }
            set
            {
                ViewState["TopLevelEditOK"] = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.buttonChartPositions.Click += new EventHandler(buttonChartPositions_Click);
            this.buttonOrganizationChartDetails.Click += new EventHandler(buttonOrganizationChartDetails_Click);
            this.buttonIncludePosition.Click += new EventHandler(buttonIncludePosition_Click);
            this.buttonUpdatePosition.Click += new EventHandler(buttonUpdatePosition_Click);
            this.buttonCancel.Click += new EventHandler(buttonCancel_Click);
            base.OnInit(e);
        }

        public void BindData(IWorkforcePlanningPosition position)
        {
            try
            {
                this.panelMainInner.Visible = true;
                this.EditPositionID = position.WFPPositionID;

                OrganizationCode orgCode = new OrganizationCode(position.OrganizationCodeID);

                if (orgCode.ReportingOrganizationCode == -1)
                    customErrorMessage.ErrorMessage = string.Format(GetLocalResourceObject("NullReportingOrganizationCode").ToString(), orgCode.OrganizationName, orgCode.OrganizationCodeValue);
                
                loadMultiUseResources();
                bindOrgPositionTypes();
                bindParentPositions(position.WFPPositionID);
                bindPositionBoxPlacement();
                bindPositionBoxLocationGroupTypes();

                loadData(position);
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }

        private void loadMultiUseResources()
        {
            _NotSpecifiedLine = GetLocalResourceObject("DataNotSpecified").ToString();
        }

        private void setCleanLine(Literal literalItem, string fieldData)
        {
            literalItem.Text = (string.IsNullOrWhiteSpace(fieldData)) ? _NotSpecifiedLine : HttpUtility.HtmlEncode(fieldData);
        }

        private void loadData(IWorkforcePlanningPosition position)
        {
            base.RefreshOrgChartDataOnly();
            OrganizationChart chart = base.CurrentOrgChart;
            bool tempIsChartPosition = position is OrganizationChartPosition;
            this.IsChartPosition = tempIsChartPosition;
            this.customOrgChartDetails.BindData(chart);
            this.customOrgChartDetails.RedirectSuffix = tempIsChartPosition ? "pos" : "newfpps";
            this.customFPPSPositionInformation.BindData(position, chart.StartPointWFPPositionID);

            if (position.PositionStatusHistory.HasValue && position.PositionStatusHistory.Value == (int)enumOrgPositionStatusHistoryType.ActiveEmployee)
                base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(), position.PositionLineItemFullName));
            else
                base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(),
                    string.Format("{0} {1}", position.PositionTitle, GetLocalResourceObject("VacantWordPhrase").ToString())));

            // This is a nested control and as such, the use is a little different from the other user controls -- we need to check read/write permission here
            // This is because we load this control by an explicit Bind -- not in page load
            this.OriginalReportsToID = position.ReportsToID;
            this.AccessOK = (base.CurrentOrgChartNavMode == enumNavigationMode.Insert || base.CurrentOrgChartNavMode == enumNavigationMode.Edit);
            bool actionsOK = this.AccessOK &&
                            (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft || chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Review);
            bool isRoot = (position.WFPPositionID == base.CurrentOrgChart.StartPointWFPPositionID);
            bool isTopLevelEditOk = (base.HasHRGroupPermission || base.IsAdmin) || !isRoot;
            this.TopLevelEditOK = isTopLevelEditOk;

            this.buttonIncludePosition.Visible = actionsOK && !tempIsChartPosition;
            this.buttonUpdatePosition.Visible = actionsOK && tempIsChartPosition;
            
            this.rowReportsToPositionRoot.Visible = !isTopLevelEditOk;
            this.rowReportsToPositionUpdate.Visible = isTopLevelEditOk;
            this.requiredParentPosition.Enabled = !isRoot;      // parent position is required for all positions except the root node
            this.spanPositionRequired.Visible = !isRoot;         // hide the required asterisk "*"

            this.rowLocationGroupType.Visible = !isRoot;
            this.rowPlacementType.Visible = !isRoot;

            this.dropDownOrganizationPositionTypes.SelectedValue = ((int)position.eOrgPositionType).ToString();

            if (isTopLevelEditOk)
            {
                if (position.ReportsToID != -1)
                    this.dropDownParentPositions.SelectedValue = position.ReportsToID.ToString();
            }
            else
                literalReportsToPosition.Text = position.ReportsToFullNameReverse;

            if (tempIsChartPosition && !isRoot)
            {
                // only set if this is a chart position AND it is not the root node position
                OrganizationChartPosition chartPosition = position as OrganizationChartPosition;

                this.dropDownPositionPlacements.SelectedValue = ((int) chartPosition.PositionPlacementType).ToString();
                this.dropDownPositionLocationGroupTypes.SelectedValue = ((int) chartPosition.PositionGroupType).ToString();
            }
        }

        private void bindOrgPositionTypes()
        {
            ControlUtility.BindRadComboBoxControl(this.dropDownOrganizationPositionTypes, LookupWrapper.GetAllOrgPositionTypes(false), null, "OrgPositionTypeDesc", "OrgPositionTypeID", "<<-- Select Organization Position Type -->>");
        }

        private void bindParentPositions(int selectedRootNodeID)
        {
            bool isRoot = (selectedRootNodeID == base.CurrentOrgChart.StartPointWFPPositionID);

            IList<IWorkforcePlanningPosition> positionList = null;

            if (isRoot)
                positionList = WorkforcePlanningPositionManager.Instance.GetRootNodeParentPositionsForChart(base.CurrentOrgChartID).ToList<IWorkforcePlanningPosition>();
            else
                // not a root node -- normal position listing
                positionList = OrganizationChartPositionManager.Instance.GetOrganizationChartPositionsExcludePath(base.CurrentOrgChartID, selectedRootNodeID).ToList<IWorkforcePlanningPosition>();

            // load this position list, but exclude the entire path starting with the currently edited WFPPositionID and everything underneath (this is done to prevent circular references)
            ControlUtility.BindRadComboBoxControl(this.dropDownParentPositions, positionList, null, "PositionLineItemFullNameReverse", "WFPPositionID", "<<-- Select Reports To Position -->>");
        }

        private void bindPositionBoxPlacement()
        {
            ControlUtility.BindRadComboBoxControl(this.dropDownPositionPlacements, LookupWrapper.GetOrgChartPositionPlacementTypes(false), null, "PlacementTypeName", "PlacementTypeID", "<<-- Use Default Placement -->>");
        }

        private void bindPositionBoxLocationGroupTypes()
        {
            ControlUtility.BindRadComboBoxControl(this.dropDownPositionLocationGroupTypes, LookupWrapper.GetOrgChartPositionGroupTypes(false), null, "GroupTypeName", "GroupTypeID", "<<-- Use Default Location -->>");
        }

        #region Button Click Events

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

        private void buttonOrganizationChartDetails_Click(object sender, EventArgs e)
        {
            try
            {
                base.GoToOrgChartManagerDetails();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private OrganizationChartPosition buildPosition()
        {
            OrganizationChartPosition position = new OrganizationChartPosition()
            {
                OrganizationChartID = base.CurrentOrgChartID,
                WFPPositionID = this.EditPositionID,
                eOrgPositionType = (enumOrgPositionType)ControlUtility.GetDropdownValue(this.dropDownOrganizationPositionTypes),
                PositionGroupType = (enumOrgPositionGroupType)ControlUtility.GetDropdownValue(this.dropDownPositionLocationGroupTypes),
                PositionPlacementType = (enumOrgPositionPlacementType)ControlUtility.GetDropdownValue(this.dropDownPositionPlacements),
                UpdatedByID =CurrentUserID
            };

            if (this.TopLevelEditOK)
                position.ReportsToID = ControlUtility.GetDropdownValue(this.dropDownParentPositions);
            else
                position.ReportsToID = this.OriginalReportsToID;

            return position;
        }

        private void buttonIncludePosition_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    OrganizationChartPosition position = buildPosition();
                    OrganizationChartPositionManager.Instance.Include(position);
                    goToSourcePage();
                }
            }
            catch (CircularPositionReferenceException)
            {
                // show message
                this.customErrorMessage.ErrorMessage = GetLocalResourceObject("CircularPositionReferenceExceptionMessage").ToString();
            }
            catch (InvalidChartPositionException)
            {
                // unique case -- if this exception occurs then the position isn't available
                // just redirect to the New FPPS page
                this.goToSourcePage();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonUpdatePosition_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    OrganizationChartPosition position = buildPosition();
                    OrganizationChartPositionManager.Instance.UpdateFPPS(position);
                    goToSourcePage();
                }
            }
            catch (InvalidParentChartPositionException)
            {
                // show message
                this.customErrorMessage.ErrorMessage = GetLocalResourceObject("ParentNotInPositionExceptionMessage").ToString();

                // rebind parent position list
                this.bindParentPositions(this.EditPositionID);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void goToSourcePage()
        {
            string returnURL = this.IsChartPosition ? "~/OrgChart/OrgChartPositions.aspx" : "~/OrgChart/NewFPPSPositions.aspx";

            if (this.IsChartPosition)
            {
                if (Request.QueryString[VIEWPOSIDKEY] == null)
                    returnURL += "#positionlist";
                else
                    returnURL += string.Format("?posID={0}#positionlist", Request.QueryString[VIEWPOSIDKEY]);
            }

            base.SafeRedirect(returnURL);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                goToSourcePage();
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
                bool tempAccessOK = (selectedMode == enumNavigationMode.Insert || selectedMode == enumNavigationMode.Edit);
                this.customReadOnlyLabel.Visible = !tempAccessOK;
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }
    }
}