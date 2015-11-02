using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.Business.Lookups;
using HCMS.Business.Lookups.Collections;
using HCMS.Business.Lookups.Repositories;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Exceptions;
using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.Common;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.Business.OrganizationChart.Published;
using Telerik.Web.UI;
using HCMS.Business.Security;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.Business.OrganizationChart.Positions;

namespace HCMS.OrgChart.Controls.OrgChart
{
    public partial class ctrlCreateOrgChart : OrgChartUserControlBase
    {
        #region Enumerations

        private enum CreationType : int
        {
            None = -1,
            New = 1,
            NewFromTemplate = 2
        }

        private enum RootNodeMode : int
        {
            None = -1,
            SelectNode = 1,
            CreateNewWFP = 2
        }

        #endregion

        #region Properties

        private CreationType SelectedCreationType
        {
            get
            {
                if (ViewState["SelectedCreationType"] == null)
                    ViewState["SelectedCreationType"] = CreationType.None;

                return (CreationType)ViewState["SelectedCreationType"];
            }
            set
            {
                ViewState["SelectedCreationType"] = value;
            }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.dropDownChartTypes.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropDownChartTypes_SelectedIndexChanged);
            this.radioListOrgCode.SelectedIndexChanged += new EventHandler(radioListOrgCode_SelectedIndexChanged);
            this.dropDownOrganizationCodes.SelectedIndexChanged += new RadComboBoxSelectedIndexChangedEventHandler(dropDownOrganizationCodes_SelectedIndexChanged);
            this.radioListRootNode.SelectedIndexChanged += new EventHandler(radioListRootNode_SelectedIndexChanged);
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
            // load chart types
            ControlUtility.BindRadComboBoxControl(this.dropDownChartTypes, OrgChartTypeRepository.Instance.GetAllOrgChartTypes(), null, "OrgChartTypeDesc", "OrgChartTypeID", "<<-- Select Organization Chart Type -->>");
        }

        private void printOrgCodeListMessage(string message)
        {
            bool hasMessage = !string.IsNullOrWhiteSpace(message);

            panelOrgCodeInner.Visible = !hasMessage;
            literalOrgCodeListMessage.Visible = hasMessage;

            literalOrgCodeListMessage.Text = message;
        }

        private void toggleChartTypeView()
        {
            try
            {
                resetOrgChartPanels();
                enumOrgChartType selectedChartType = (enumOrgChartType)int.Parse(this.dropDownChartTypes.SelectedValue);

                if (selectedChartType == enumOrgChartType.Undefined)
                    printOrgCodeListMessage(GetLocalResourceObject("NoChartTypeSelectedMessage").ToString());
                else
                {
                    OrgCodeFormatTypes selectedOrgCodeFormat = (OrgCodeFormatTypes)int.Parse(radioListOrgCode.SelectedValue);
                    toggleOrganizationCodeView(selectedChartType, selectedOrgCodeFormat);
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void toggleOrganizationCodeView(enumOrgChartType selectedChartType, OrgCodeFormatTypes listFormat)
        {
            // Get data based on chart type            
            OrganizationCodeCollection listOrgCodes = base.CurrentUser.GetAvailableOrganizationCodesByChartType(selectedChartType, listFormat);

            if (listOrgCodes.Count == 0)
                // display message if there is no organization codes
                printOrgCodeListMessage(GetLocalResourceObject("NoOrgCodesAvailableMessage").ToString());
            else
            {
                printOrgCodeListMessage(string.Empty);
                string displayTextField = (listFormat == OrgCodeFormatTypes.NewOrgCode) ? "NewOrgCodeLine" : "OldOrgCodeLine";

                //remove Org Code 0 from the list
                OrganizationCode spdOrgCode=new OrganizationCode ();
                spdOrgCode.OrganizationCodeID =1;
                listOrgCodes.Remove(spdOrgCode);
                // show org codes if there is data
                ControlUtility.BindRadComboBoxControl(dropDownOrganizationCodes, listOrgCodes, null, displayTextField, "OrganizationCodeID", "<<--Select Organization -->>");
            }
        }

        private void resetOrgChartPanels()
        {
            this.panelInProcessChart.Visible = false;
            this.panelPublishedChart.Visible = false;
            this.panelNoInProcessNoPublished.Visible = false;
            this.panelRootNodeSelection.Visible = true;
            this.panelRootNodeCreateWFP.Visible = false;

            // set default root node selection to "SELECTION FROM LIST"
            this.radioListRootNode.SelectedValue = ((int)RootNodeMode.SelectNode).ToString();

            // disable save button
            this.buttonSave.Enabled = false;
        }

        private void bindRootPositionsByOrgCode(int orgCodeID)
        {
            // load positions based on org code
            WorkforcePlanningPositionCollection listPositions = WorkforcePlanningPositionManager.Instance.GetByOrgCode(orgCodeID);
            ControlUtility.BindRadComboBoxControl(this.dropDownRootPositions, listPositions, null, "PositionLineItemFullNameReverse", "WFPPositionID", "<<-- Select Top Level Position -->>");
        }

        private void dropDownChartTypes_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            toggleChartTypeView();
        }

        private void radioListOrgCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            toggleChartTypeView();
        }

        private void setChartView(Panel panelChart, CreationType selectedType, bool enableSave)
        {
            panelChart.Visible = true;
            this.SelectedCreationType = selectedType;
            this.buttonSave.Enabled = enableSave;
        }

        private void radioListRootNode_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                RootNodeMode selectedMode = (RootNodeMode)int.Parse(this.radioListRootNode.SelectedValue);

                panelRootNodeSelection.Visible = (selectedMode == RootNodeMode.SelectNode);
                panelRootNodeCreateWFP.Visible = (selectedMode == RootNodeMode.CreateNewWFP);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void dropDownOrganizationCodes_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            try
            {
                enumOrgChartType selectedChartType = (enumOrgChartType)int.Parse(this.dropDownChartTypes.SelectedValue);
                int orgCodeID = ControlUtility.GetDropdownValue(this.dropDownOrganizationCodes, "-1");

                // reset panel view
                resetOrgChartPanels();

                if (orgCodeID != -1)
                {
                    // Three POSSIBLE STATES:
                    // A. Existing In-Progress Chart
                    // B. No In-Process Chart but has a Published Chart
                    // C. No In-Process Chart/No Published Chart

                    // State 1: Existing In-Progress Chart
                    OrganizationChart chart = OrganizationChartManager.Instance.GetByOrgCodeAndChartType(orgCodeID, selectedChartType);

                    if (chart.OrganizationChartID != -1)
                        // Chart is In-Process
                        setChartView(this.panelInProcessChart, CreationType.None, false);
                    else
                    {
                        // No In-Process Chart -- now check published charts
                        OrganizationChartLog chartLog = OrganizationChartLogManager.Instance.GetByOrgCodeAndChartType(orgCodeID, selectedChartType);

                        if (chartLog.OrganizationChartLogID == -1)
                        {
                            // State 3: No In-Process Chart/No Published Chart
                            setChartView(this.panelNoInProcessNoPublished, CreationType.New, true);

                            // bind root positions by org code
                            bindRootPositionsByOrgCode(orgCodeID);
                        }
                        else
                            // State 2: No In-Process Chart but has a Published Chart
                            setChartView(this.panelPublishedChart, CreationType.NewFromTemplate, true);
                    }
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #region Button Click Events

        private void buttonSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    int newOrgChartID = -1;
                    OrganizationChart newChart = new OrganizationChart()
                    {
                        OrganizationChartTypeID = (enumOrgChartType)int.Parse(this.dropDownChartTypes.SelectedValue),
                        OrgCode = new OrganizationCode()
                        {
                            OrganizationCodeID = ControlUtility.GetDropdownValue(this.dropDownOrganizationCodes, "-1")
                        },
                        CreatedBy = new ActionUser(base.CurrentUserID)
                    };

                    if (this.SelectedCreationType == CreationType.NewFromTemplate)
                    {
                        // create org chart from template
                        newOrgChartID = OrganizationChartManager.Instance.CreateFromPublished(newChart, true);

                        // set new org chart ID
                        base.ResetCurrentOrgChart(newOrgChartID);

                        // load newly created organization chart
                        base.GoToOrgChartLink("~/OrgChart/OrgChartDetails.aspx", enumNavigationMode.Edit);
                    }
                    else if (this.SelectedCreationType == CreationType.New)
                    {
                        // create NEW org chart
                        RootNodeMode selectedMode = (RootNodeMode)int.Parse(this.radioListRootNode.SelectedValue);

                        // set root node (if mode is "SELECT") -- default action is to "Create New WFP" if no starting point is specified
                        if (selectedMode == RootNodeMode.SelectNode)
                            newChart.StartPointWFPPositionID = ControlUtility.GetDropdownValue(this.dropDownRootPositions, "-1");

                        newOrgChartID = OrganizationChartManager.Instance.CreateNew(newChart, true);

                        // set new org chart ID
                        base.ResetCurrentOrgChart(newOrgChartID);

                        if (selectedMode == RootNodeMode.SelectNode)
                            // load newly created organization chart
                            base.GoToOrgChartLink("~/OrgChart/OrgChartDetails.aspx", enumNavigationMode.Edit);
                        else
                            // allow user to immediately edit root node
                            base.GoToOrgChartLink(string.Format("~/OrgChart/UpdateChartPosition.aspx?editPosID={0}", newChart.StartPointWFPPositionID), enumNavigationMode.Edit);
                    }
                }
            }
            catch (NoPublishedChartAvailableException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("NoPublishedChartExceptionMessage").ToString(), true);
            }
            catch (ChartAlreadyInProgressException)
            {
                base.PrintErrorMessage(GetLocalResourceObject("InProgressChartExceptionMessage").ToString(), true);
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            try
            {
                base.GoToOrgChartTracker();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion
    }
}