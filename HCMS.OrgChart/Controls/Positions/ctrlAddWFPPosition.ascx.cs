using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.Common;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.OrganizationChart;
using HCMS.Business.Lookups;
using HCMS.WebFramework.Site.Wrappers;
using Telerik.Web.UI;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.Business.OrganizationChart.Positions.Exceptions;

namespace HCMS.OrgChart.Controls.Positions
{
    public partial class ctrlAddWFPPosition : OrgChartRequiredUserControlBase
    {
        private const string VIEWPOSIDKEY = "viewPosID";

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.checkboxIsEncumbered.CheckedChanged += new EventHandler(checkboxIsEncumbered_CheckedChanged);
            this.dropDownPayPlan.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropDownPayPlan_SelectedIndexChanged);
            this.dropDownDutyStationCountries.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropDownDutyStationCountries_SelectedIndexChanged);
            this.buttonChartPositions.Click += new EventHandler(buttonChartPositions_Click);
            this.buttonOrganizationChartDetails.Click += new EventHandler(buttonOrganizationChartDetails_Click);
            this.buttonSave.Click += new EventHandler(buttonSave_Click);
            this.buttonCancel.Click += new EventHandler(buttonCancel_Click);
            base.OnInit(e);
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

            // validation check for base.CurrentOrgChart is in OrgChartRequiredUserControlBase
            base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(), chart.OrganizationName, chart.OrgCode.OrganizationCodeValue));
            customOrgChartDetails.BindData(chart);

            // show org code section based on chart type
            bool isSingleChartType = (chart.OrganizationChartTypeID == enumOrgChartType.SingleOrg);
            this.rowSingleOrgCode.Visible = isSingleChartType;
            this.rowMultipleOrgCodes.Visible = !isSingleChartType;

            if (isSingleChartType)
                this.literalSingleOrgCode.Text = chart.OrgCode.DetailLine;
            else
                bindMultipleChildOrgCodes(chart.OrgCode.OrganizationCodeID);

            bindPayPlans();
            bindFPLAndCurrentGrade();
            bindDutyStationCountries();
            bindDutyStationStates();
            bindPositionTypesSupervisoryStatues();
            bindOrgPositionTypes();
            bindParentPositions();
            bindPositionBoxPlacement();
            bindPositionBoxLocationGroupTypes();

            // load default values
            int defaultCountryID = (int)enumCountries.UnitedStates;
            this.dropDownDutyStationCountries.SelectedValue = defaultCountryID.ToString();
            toggleDutyStates(defaultCountryID);

            this.dropDownOrganizationPositionTypes.SelectedValue = ((int)enumOrgPositionType.FWS_Employee).ToString();
        }

        #region Bind Dropdowns

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
            //3580:Add New WFP: FPL and Current Grade Drop down - remove 100 from the option
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

        private void bindParentPositions()
        {
            OrganizationChartPositionCollection positionList = OrganizationChartPositionManager.Instance.GetOrganizationChartPositions(base.CurrentOrgChartID);

            ControlUtility.BindRadComboBoxControl(this.dropDownParentPositions, positionList, null, "PositionLineItemFullName", "WFPPositionID", "<<-- Select Reports To Position -->>");

            if (positionList.Count > 0 && Request.QueryString[VIEWPOSIDKEY] != null)
            {
                int tempID = -1;
                bool isOk = int.TryParse(Request.QueryString[VIEWPOSIDKEY], out tempID);

                if (isOk)
                    // load by parent if querystring exists
                    this.dropDownParentPositions.SelectedValue = Request.QueryString[VIEWPOSIDKEY];
            }
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

        private void toggleDutyStates(int countryID)
        {
            bool isUS = (countryID == (int)enumCountries.UnitedStates);
            this.rowDutyStationState.Visible = isUS;
        }

        private void dropDownDutyStationCountries_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                int countryID = int.Parse(this.dropDownDutyStationCountries.SelectedValue);
                toggleDutyStates(countryID);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
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

        private OrganizationChartPosition buildNewPosition()
        {
            OrganizationChart chart = base.CurrentOrgChart;
            int calculatedOrgCodeID = -1;
            int dutyCountryID = ControlUtility.GetDropdownValue(this.dropDownDutyStationCountries);

            if (chart.OrganizationChartTypeID == enumOrgChartType.SingleOrg)
                calculatedOrgCodeID = chart.OrgCode.OrganizationCodeID;
            else
                calculatedOrgCodeID = int.Parse(this.dropDownMultipleOrgCodes.SelectedValue);

            // now add position and include in the current chart
            OrganizationChartPosition newPosition = new OrganizationChartPosition()
            {
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
                DutyStationStateID = (dutyCountryID == -1) ? (int ?) null : dutyCountryID,
                DutyStationDescription = this.textboxDutyStationCity.Text,
                eOrgPositionType = (enumOrgPositionType)ControlUtility.GetDropdownValue(this.dropDownOrganizationPositionTypes),
                SupervisoryStatus = ControlUtility.GetDropdownValue(this.dropDownPositionTypesSupervisoryStatuses),
                ReportsToID = ControlUtility.GetDropdownValue(this.dropDownParentPositions),
                PositionGroupType = (enumOrgPositionGroupType) ControlUtility.GetDropdownValue(this.dropDownPositionLocationGroupTypes),
                PositionPlacementType = (enumOrgPositionPlacementType) ControlUtility.GetDropdownValue(this.dropDownPositionPlacements)
            };

            if (this.checkboxIsEncumbered.Checked)
            {
                newPosition.FirstName = this.textboxFirstName.Text;
                newPosition.LastName = this.textboxLastName.Text;
                newPosition.MiddleName = this.textboxMiddleName.Text;
                newPosition.EmployeeName = string.Format("{0} {1} {2}", 
                        this.textboxFirstName.Text.Trim(), 
                        string.IsNullOrWhiteSpace(this.textboxMiddleName.Text) ? string.Empty : this.textboxMiddleName.Text.Trim(), 
                        this.textboxLastName.Text.Trim());
                newPosition.PositionStatusHistory = (int) enumOrgPositionStatusHistoryType.ActiveEmployee;
            }
            else
                newPosition.PositionStatusHistory = (int) enumOrgPositionStatusHistoryType.ActiveVacant;

            return newPosition;
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    OrganizationChartPosition newPosition = buildNewPosition();

                    OrganizationChartPositionManager.Instance.Add(newPosition);
                    goToPositionManager();
                }
            }
            catch (InvalidParentChartPositionException)
            {
                // show message
                this.customAddNewErrorMessage.ErrorMessage = GetLocalResourceObject("ParentNotInPositionExceptionMessage").ToString();

                // rebind parent position list
                this.bindParentPositions();
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

        #endregion

        protected override void ToggleReadOnlyView(enumNavigationMode selectedMode)
        {
            try
            {
                bool accessOK = (selectedMode == enumNavigationMode.Insert || selectedMode == enumNavigationMode.Edit);
                this.customReadOnlyLabel.Visible = !accessOK;
                
                // Special case here: the only purpose of the "Add Position" page is to add a position (there is no "read-only" component 
                // to this page -- as such -- we simply redirect back to the position manager page)
                if (!accessOK)
                    base.GoToOrgChartPositionManager();
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }
    }
}