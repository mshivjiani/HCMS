using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.WebFramework.Site.Utilities;
using HCMS.WebFramework.Site.Wrappers;
using HCMS.Business.OrganizationChart.Positions.Exceptions;

namespace HCMS.OrgChart.Controls.Positions
{
    public partial class ctrlAbolishedPositionDetails : OrgChartRequiredUserControlBase
    {
        private const string EDITPOSIDKEY = "editPosID";

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

        protected override void OnInit(EventArgs e)
        {
            this.Page.Load += new EventHandler(Page_Load);
            this.buttonChartPositions.Click += new EventHandler(buttonChartPositions_Click);
            this.buttonOrganizationChartDetails.Click += new EventHandler(buttonOrganizationChartDetails_Click);
            this.buttonMapNewParents.Click += new EventHandler(buttonMapNewParents_Click);        
            this.buttonCancel.Click += new EventHandler(buttonCancel_Click);
            this.buttonCancelReadOnly.Click += new EventHandler(buttonCancel_Click);
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
            int tempPositionID = -1;
            bool isOK = int.TryParse(Request.QueryString[EDITPOSIDKEY], out tempPositionID);

            if (isOK)
            {
                WorkforcePlanningPosition position = WorkforcePlanningPositionManager.Instance.GetAbolishedPositionByID(tempPositionID);

                if (position.WFPPositionID == -1)
                    base.PrintErrorMessage(GetLocalResourceObject("PositionDoesNotExistMessage").ToString());
                else
                {
                    OrganizationChart chart = base.CurrentOrgChart;
            
                    this.EditPositionID = position.WFPPositionID;
                    this.customOrgChartDetails.BindData(chart);
                    this.customFPPSPositionInformation.BindData(position, chart.StartPointWFPPositionID);

                    bool isRoot = (chart.StartPointWFPPositionID == position.WFPPositionID);
                    this.AccessOK = (base.CurrentOrgChartNavMode == enumNavigationMode.Insert || base.CurrentOrgChartNavMode == enumNavigationMode.Edit);
                    bool actionsOK = this.AccessOK && (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Draft || chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Review);
                    bool okToSetParents = !isRoot && actionsOK && (position.DirectChildCount > 0);

                    this.panelMapParents.Visible = okToSetParents;
                    this.buttonCancelReadOnly.Visible = !okToSetParents;
                    this.literalDirectChildCount.Text = position.DirectChildCount.ToString();
                    
                    if (okToSetParents)
                        bindParentPositions(position.WFPPositionID);
                }
            }
            else
                base.PrintErrorMessage(GetLocalResourceObject("PositionIDQuerystringNotValidMessage").ToString());
        }

        private void bindParentPositions(int excludeWFPPositionID)
        {
            OrganizationChartPositionCollection positionList = OrganizationChartPositionManager.Instance.GetOrganizationChartPositionsExcludePath(base.CurrentOrgChartID, excludeWFPPositionID);

            // load this position list, but exclude the entire path starting with the currently edited WFPPositionID and everything underneath (this is done to prevent circular references)
            ControlUtility.BindRadComboBoxControl(this.dropDownParentPositions, positionList, null, "PositionLineItemFullName", "WFPPositionID", "<<-- Select New Reports To Position -->>");
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

        private void buttonMapNewParents_Click(object sender, EventArgs e)
        {
            try
            {
                if (Page.IsValid)
                {
                    OrganizationChartPositionManager.Instance.FixAbolished(base.CurrentOrgChartID,
                                this.EditPositionID, ControlUtility.GetDropdownValue(this.dropDownParentPositions),
                                (AbolishedFixActions)int.Parse(this.radioListActions.SelectedValue),CurrentUserID);

                    goToSourcePage();
                }
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void goToSourcePage()
        {
            base.SafeRedirect("~/OrgChart/AbolishedPositions.aspx");
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

                this.buttonMapNewParents.Visible = tempAccessOK;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
    }
}