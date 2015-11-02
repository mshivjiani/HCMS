using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Site.Utilities;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.OrganizationChart;
using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.OrganizationChart.Positions.Exceptions;
using Telerik.Web.UI;

namespace HCMS.OrgChart.Controls.Positions
{
    public partial class ctrlIncludePositions : OrgChartRequiredUserControlBase
    {
        private const string EDITPOSIDKEY = "editPosID";
        private const string VIEWPOSIDKEY = "viewPosID";

        private int EditPositionID
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

        private int SelectedChildOrgCodeID
        {
            get
            {
                if (ViewState["SelectedChildOrgCodeID"] == null)
                    ViewState["SelectedChildOrgCodeID"] = -1;

                return (int)ViewState["SelectedChildOrgCodeID"];
            }
            set
            {
                ViewState["SelectedChildOrgCodeID"] = value;
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.dropDownChildOrgCodes.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropDownChildOrgCodes_SelectedIndexChanged);            
            this.customValSelectedPositions.ServerValidate += new ServerValidateEventHandler(customValSelectedPositions_ServerValidate);
            this.buttonChartPositions.Click += new EventHandler(buttonChartPositions_Click);
            this.buttonOrganizationChartDetails.Click += new EventHandler(buttonOrganizationChartDetails_Click);
            this.buttonInclude.Click += new EventHandler(buttonInclude_Click);
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

            int tempPositionID = -1;
            bool isOK = int.TryParse(Request.QueryString[EDITPOSIDKEY], out tempPositionID);

            if (isOK)
            {
                OrganizationChartPosition position = OrganizationChartPositionManager.Instance.GetByID(chart.OrganizationChartID, tempPositionID);

                if (position.WFPPositionID == -1)
                    base.PrintErrorMessage(GetLocalResourceObject("PositionDoesNotExistMessage").ToString());
                else
                {
                    this.EditPositionID = position.WFPPositionID;
                    base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(), position.PositionLineItemFullNameReverse));
                    this.customOrgChartDetails.BindData(chart);
                    this.literalReportsToPositionTitleLineItem.Text = position.PositionLineItemFullNameReverse;
                    this.literalPrimaryOrgCode.Text = chart.OrgCode.NewOrgCodeLine;
                    this.rowChildOrgCodes.Visible = (chart.OrganizationChartTypeID == enumOrgChartType.MultiOrg);

                    if (chart.OrganizationChartTypeID == enumOrgChartType.MultiOrg)
                    {
                        // bind list of child org codes
                        this.bindMultipleChildOrgCodes(chart.OrgCode.OrganizationCodeID);
                    }

                    // show all positions in primary org code
                    bindAvailablePositions(-1);
                }
            }
            else
                base.PrintErrorMessage(GetLocalResourceObject("PositionIDQuerystringNotValidMessage").ToString());
        }

        private void bindAvailablePositions(int selectedChildOrgCode)
        {
            WorkforcePlanningPositionCollection positionList = null;
            string noPositionsMessage = string.Empty;

            if (selectedChildOrgCode == -1)
            {
                noPositionsMessage = GetLocalResourceObject("NoPositionListDataPrimary").ToString();
                positionList = WorkforcePlanningPositionManager.Instance.GetPositionsForInclusionInChart(base.CurrentOrgChartID);
            }
            else
            {
                noPositionsMessage = GetLocalResourceObject("NoPositionListDataChild").ToString();
                positionList = WorkforcePlanningPositionManager.Instance.GetPositionsForInclusionInChart(base.CurrentOrgChartID, selectedChildOrgCode);
            }

            bool hasData = (positionList.Count > 0);
            this.listboxPositions.Visible = hasData;
            this.panelNoPositions.Visible = !hasData;
            this.buttonInclude.Enabled = hasData;

            if (hasData)
                ControlUtility.BindRadListBoxControlWithBackground(this.listboxPositions, positionList, "PositionLineItemFullNameReverse", "WFPPositionID", string.Empty);
            else
                this.literalNoPositionsMessage.Text = noPositionsMessage;
        }

        private void bindMultipleChildOrgCodes(int primaryOrgCode)
        {
            OrganizationCode chartOrgCode = new OrganizationCode();

            chartOrgCode.OrganizationCodeID = primaryOrgCode;
            OrganizationCodeCollection listOrgCodes = chartOrgCode.GetChildrenOrganizations();

            ControlUtility.BindRadComboBoxControl(this.dropDownChildOrgCodes, listOrgCodes, null, "NewOrgCodeLine", "OrganizationCodeID", "<<-- Select Child Organization Code Filter -->>");
        }

        private void dropDownChildOrgCodes_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                int tempSelectedID = ControlUtility.GetDropdownValue(this.dropDownChildOrgCodes);
                this.SelectedChildOrgCodeID = tempSelectedID;

                this.bindAvailablePositions(tempSelectedID);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void customValSelectedPositions_ServerValidate(object source, ServerValidateEventArgs e)
        {
            bool isOK = false;

            try
            {
                isOK = (this.listboxPositions.CheckedItems.Count > 0);
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }

            e.IsValid = isOK;
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

        private void buttonInclude_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    List<int> selectedPositions = new List<int>();

                    foreach (var item in this.listboxPositions.CheckedItems)
                        selectedPositions.Add(int.Parse(item.Value));

                    // include all positions
                    OrganizationChartPositionManager.Instance.Include(base.CurrentOrgChartID, this.EditPositionID, enumOrgPositionType.Undefined,
                            enumOrgPositionGroupType.Undefined, enumOrgPositionPlacementType.Undefined, selectedPositions, CurrentUserID);
                    goToPositionManager();
                }
            }
            catch (CircularPositionReferenceException)
            {
                // show message
                this.customErrorMessage.ErrorMessage = GetLocalResourceObject("CircularPositionReferenceExceptionMessage").ToString();

                // rebind position list
                this.bindAvailablePositions(this.SelectedChildOrgCodeID);
            }
            catch (InvalidChartPositionException)
            {
                // show message
                this.customErrorMessage.ErrorMessage = GetLocalResourceObject("InvalidPositionInListExceptionMessage").ToString();

                // rebind position list
                this.bindAvailablePositions(this.SelectedChildOrgCodeID);
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
                
                // Special case here: the only purpose of the "Include Position" page is to include positions into the organization chart (there is no 
                // "read-only" component to this page -- as such -- we simply redirect back to the position manager page)
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