using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart.Positions;
using Telerik.Web.UI;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.Business.OrganizationChart.Positions.Exceptions;

namespace HCMS.OrgChart.Controls.Positions
{
    public partial class ctrlUpdateWFPPosition : OrgChartRequiredUserControlBase
    {
        private const string VIEWPOSIDKEY = "viewPosID";

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
            this.checkboxIsEncumbered.CheckedChanged += new EventHandler(checkboxIsEncumbered_CheckedChanged);
            this.dropDownPayPlan.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropDownPayPlan_SelectedIndexChanged);
            this.dropDownDutyStationCountries.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropDownDutyStationCountries_SelectedIndexChanged);
            this.buttonChartPositions.Click += new EventHandler(buttonChartPositions_Click);
            this.buttonOrganizationChartDetails.Click += new EventHandler(buttonOrganizationChartDetails_Click);
            this.buttonSave.Click += new EventHandler(buttonSave_Click);
            this.buttonCancel.Click += new EventHandler(buttonCancel_Click);
            this.buttonDeletePosition.Click += new EventHandler(buttonDeletePosition_Click);
            base.OnInit(e);
        }

        public void BindData(OrganizationChartPosition position)
        {
            try
            {
                this.panelMainInner.Visible = true;
                this.EditPositionID = position.WFPPositionID;

                OrganizationCode orgCode = new OrganizationCode(position.OrganizationCodeID);

                if (orgCode.ReportingOrganizationCode == -1)
                    customErrorMessage.ErrorMessage = string.Format(GetLocalResourceObject("NullReportingOrganizationCode").ToString(), orgCode.OrganizationName, orgCode.OrganizationCodeValue);
                
                bindPayPlans();
                bindFPLAndCurrentGrade();
                bindDutyStationCountries();
                bindDutyStationStates();
                bindPositionTypesSupervisoryStatues();
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

        private void loadData(OrganizationChartPosition position)
        {
            base.RefreshOrgChartDataOnly();
            OrganizationChart chart = base.CurrentOrgChart;
            customOrgChartDetails.BindData(chart);

            bool isActiveEmployee = (position.PositionStatusHistory.HasValue && position.PositionStatusHistory.Value == (int)enumOrgPositionStatusHistoryType.ActiveEmployee);

            if (isActiveEmployee)
                base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(), position.PositionLineItemFullName));
            else
                base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(),
                    string.Format("{0} {1}", position.PositionTitle, GetLocalResourceObject("VacantWordPhrase").ToString())));

            // This is a nested control and as such, the use is a little different from the other user controls -- we need to check read/write permission here
            // This is because we load this control by an explicit Bind -- not in page load
            this.OriginalReportsToID = position.ReportsToID;
            bool isRoot = (position.WFPPositionID == base.CurrentOrgChart.StartPointWFPPositionID);
            this.AccessOK = (base.CurrentOrgChartNavMode == enumNavigationMode.Insert || base.CurrentOrgChartNavMode == enumNavigationMode.Edit);
            bool actionsOK = this.AccessOK &&
                            (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft || chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Review);

            this.buttonDeletePosition.Visible = actionsOK && (position.DirectChildCount == 0) && !isRoot;
            this.buttonSave.Visible = actionsOK;

            // show org code section based on chart type
            bool isSingleChartType = (chart.OrganizationChartTypeID == enumOrgChartType.SingleOrg);
            this.rowSingleOrgCode.Visible = isSingleChartType;
            this.rowMultipleOrgCodes.Visible = !isSingleChartType;

            if (isSingleChartType)
                this.literalSingleOrgCode.Text = chart.OrgCode.DetailLine;
            else
            {
                bindMultipleChildOrgCodes(chart.OrgCode.OrganizationCodeID);
                this.dropDownMultipleOrgCodes.SelectedValue = position.OrganizationCodeID.ToString();
            }

            // load all other data fields
            this.textboxPositionTitle.Text = position.PositionTitle;

            this.panelPositionNameInner.Visible = isActiveEmployee;
            this.checkboxIsEncumbered.Checked = isActiveEmployee;

            if (isActiveEmployee)
            {
                this.textboxFirstName.Text = position.FirstName;
                this.textboxMiddleName.Text = position.MiddleName;
                this.textboxLastName.Text = position.LastName;
            }

            this.dropDownPayPlan.SelectedValue = position.PayPlanID.ToString();
            bindSeries(position.PayPlanID);
            this.dropDownSeries.SelectedValue = position.SeriesID.ToString();

            this.dropDownFPLGrades.SelectedValue = position.FPLGrade.ToString();
            this.dropDownCurrentGrades.SelectedValue = position.Grade.ToString();

            bool isUS = position.DutyStationCountryID == (int)enumCountries.UnitedStates;
            this.dropDownDutyStationCountries.SelectedValue = position.DutyStationCountryID.ToString();
            this.rowDutyStationState.Visible = isUS;

            if (isUS)
                this.dropDownDutyStationStates.SelectedValue = position.DutyStationStateID.ToString();

            this.textboxDutyStationCity.Text = position.DutyStationDescription;
            this.dropDownPositionTypesSupervisoryStatuses.SelectedValue = position.SupervisoryStatus.ToString();
            this.dropDownOrganizationPositionTypes.SelectedValue = ((int)position.eOrgPositionType).ToString();

            // in theory -- the root should not be a WFP, but would rather be safe            
            bool isTopLevelEditOk = (base.HasHRGroupPermission || base.IsAdmin) || !isRoot;
            this.TopLevelEditOK = isTopLevelEditOk;

            this.rowReportsToPositionRoot.Visible = !isTopLevelEditOk;
            this.rowReportsToPositionUpdate.Visible = isTopLevelEditOk;
            this.requiredParentPosition.Enabled = !isRoot;      // parent position is required for all positions except the root node
            this.spanPositionRequired.Visible = !isRoot;         // hide the required asterisk "*"

            this.rowLocationGroupType.Visible = !isRoot;
            this.rowPlacementType.Visible = !isRoot;

            if (isTopLevelEditOk)
            {
                if (position.ReportsToID != -1)
                    this.dropDownParentPositions.SelectedValue = position.ReportsToID.ToString();
            }
            else
                literalReportsToPosition.Text = position.ReportsToFullNameReverse;
          
            if (!isRoot)
            {
                this.dropDownPositionPlacements.SelectedValue = ((int)position.PositionPlacementType).ToString();
                this.dropDownPositionLocationGroupTypes.SelectedValue = ((int)position.PositionGroupType).ToString();
            }
        }

        #region Bind Dropdown Lists

        private void bindMultipleChildOrgCodes(int primaryOrgCode)
        {
            OrganizationCode chartOrgCode = new OrganizationCode();

            chartOrgCode.OrganizationCodeID = primaryOrgCode;
            OrganizationCodeCollection listOrgCodes = chartOrgCode.GetChildrenOrganizations();

            // listOrgCodes.OrderBy(oc => oc.OrganizationName);
            ControlUtility.BindRadComboBoxControl(this.dropDownMultipleOrgCodes, listOrgCodes, null, "NewOrgCodeLine", "OrganizationCodeID", "<<-- Select Organization Code -->>");
        }

        private void bindPayPlans()
        {
            ControlUtility.BindRadComboBoxControl(this.dropDownPayPlan, LookupWrapper.GetAllPayPlans(false), null, "PayPlanTitle", "PayPlanID", "<<-- Select Pay Plan -->>");
        }

        private void bindFPLAndCurrentGrade()
        {
            GradeCollection gradeList = LookupWrapper.GetAllGrades(false);

            //3580 -Add New WFP: FPL and Current Grade Drop down - remove 100 from the option
            Grade othergrade = new Grade();
            othergrade.GradeID = 100;
            gradeList.Remove(othergrade);
            ControlUtility.BindRadComboBoxControl(this.dropDownFPLGrades, gradeList, null, "GradeID", "GradeID", "<<-- Select FPL -->>");
            ControlUtility.BindRadComboBoxControl(this.dropDownCurrentGrades, gradeList, null, "GradeID", "GradeID", "<<-- Select Current Grade -->>");
        }

        private void bindDutyStationCountries()
        {
            ControlUtility.BindRadComboBoxControl(this.dropDownDutyStationCountries, LookupWrapper.GetAllCountries(false), null, "CountryName", "CountryID", "<<-- Select Duty Station Country -->>");
        }

        private void bindDutyStationStates()
        {
            ControlUtility.BindRadComboBoxControl(this.dropDownDutyStationStates, LookupWrapper.GetAllStates(false), null, "StateName", "StateID", "<<-- Select Duty Station State -->>");
        }

        private void bindPositionTypesSupervisoryStatues()
        {
            ControlUtility.BindRadComboBoxControl(this.dropDownPositionTypesSupervisoryStatuses, LookupWrapper.GetAllSupervisoryStatus(false), null, "Title", "SupervisorStatusID", "<<-- Select Position Type -->>");
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

        #endregion

        #region AutoPostback Events/Methods

        private void checkboxIsEncumbered_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                panelPositionNameInner.Visible = this.checkboxIsEncumbered.Checked;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void bindSeries(int payPlanID)
        {
            bool showSeries = false;

            if (payPlanID != -1)
            {
                SeriesCollection seriesList = LookupWrapper.GetAllSeriesByPayPlan(false, payPlanID);
                ControlUtility.BindRadComboBoxControl(this.dropDownSeries, seriesList, null, "DetailLine", "SeriesID", "<<-- Select Series -->>");
                showSeries = (seriesList.Count > 0);
            }

            this.tdSeries.Visible = showSeries;
            this.tdSeriesLabel.Visible = showSeries;
        }

        private void dropDownPayPlan_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                int payPlanID = int.Parse(this.dropDownPayPlan.SelectedValue);
                bindSeries(payPlanID);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void dropDownDutyStationCountries_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                int countryID = int.Parse(this.dropDownDutyStationCountries.SelectedValue);
                bool isUS = (countryID == (int)enumCountries.UnitedStates);

                this.rowDutyStationState.Visible = isUS;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion

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
            OrganizationChart chart = base.CurrentOrgChart;
            int calculatedOrgCodeID = -1;
            int dutyCountryID = ControlUtility.GetDropdownValue(this.dropDownDutyStationCountries);

            if (chart.OrganizationChartTypeID == enumOrgChartType.SingleOrg)
                calculatedOrgCodeID = chart.OrgCode.OrganizationCodeID;
            else
                calculatedOrgCodeID = int.Parse(this.dropDownMultipleOrgCodes.SelectedValue);

            // now add position and include in the current chart
            OrganizationChartPosition position = new OrganizationChartPosition()
            {
                WFPPositionID = this.EditPositionID,
                OrganizationChartID = chart.OrganizationChartID,
                OrganizationCodeID = calculatedOrgCodeID,
                CreatedByID = base.CurrentUserID,
                PositionTitle = this.textboxPositionTitle.Text,
                PayPlanID = ControlUtility.GetDropdownValue(this.dropDownPayPlan),
                SeriesID = ControlUtility.GetDropdownValue(this.dropDownSeries),
                RegionID = chart.OrgCode.RegionID,
                FPLGrade = ControlUtility.GetDropdownValue(this.dropDownFPLGrades),
                Grade = ControlUtility.GetDropdownValue(this.dropDownCurrentGrades),
                DutyStationCountryID = dutyCountryID,
                DutyStationStateID = (dutyCountryID == -1) ? (int?)null : dutyCountryID,
                DutyStationDescription = this.textboxDutyStationCity.Text,
                eOrgPositionType = (enumOrgPositionType)ControlUtility.GetDropdownValue(this.dropDownOrganizationPositionTypes),
                SupervisoryStatus = ControlUtility.GetDropdownValue(this.dropDownPositionTypesSupervisoryStatuses),                
                PositionGroupType = (enumOrgPositionGroupType)ControlUtility.GetDropdownValue(this.dropDownPositionLocationGroupTypes),
                PositionPlacementType = (enumOrgPositionPlacementType)ControlUtility.GetDropdownValue(this.dropDownPositionPlacements),
                UpdatedByID =CurrentUserID 
            };

            if (this.TopLevelEditOK)
                position.ReportsToID = ControlUtility.GetDropdownValue(this.dropDownParentPositions);
            else
                position.ReportsToID = this.OriginalReportsToID;

            if (this.checkboxIsEncumbered.Checked)
            {
                position.FirstName = this.textboxFirstName.Text;
                position.LastName = this.textboxLastName.Text;
                position.MiddleName = this.textboxMiddleName.Text;
                position.EmployeeName = string.Format("{0} {1} {2}",
                        this.textboxFirstName.Text.Trim(),
                        string.IsNullOrWhiteSpace(this.textboxMiddleName.Text) ? string.Empty : this.textboxMiddleName.Text.Trim(),
                        this.textboxLastName.Text.Trim());
                position.PositionStatusHistory = (int)enumOrgPositionStatusHistoryType.ActiveEmployee;
            }
            else
                position.PositionStatusHistory = (int)enumOrgPositionStatusHistoryType.ActiveVacant;

            return position;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    OrganizationChartPosition position = buildPosition();
                    OrganizationChartPositionManager.Instance.UpdateWFP(position);
                    goToPositionManager();
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

        private void goToPositionManager()
        {
            string returnURL = "~/OrgChart/OrgChartPositions.aspx";

            if (Request.QueryString[VIEWPOSIDKEY] == null)
                returnURL += "#positionlist";
            else
                returnURL += string.Format("?posID={0}#positionlist", Request.QueryString[VIEWPOSIDKEY]);

            base.SafeRedirect(returnURL);
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                goToPositionManager();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonDeletePosition_Click(object sender, EventArgs e)
        {
            try
            {
                // delete position
                WorkforcePlanningPositionManager.Instance.Delete(this.EditPositionID,base.CurrentOrgChartID ,base.CurrentUserID);
                goToPositionManager();
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