using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.OrganizationChart;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;
using HCMS.Business.OrganizationChart.Positions.Exceptions;
using HCMS.WebFramework.Controls.RadGrid;

namespace HCMS.OrgChart.Controls.Positions
{
    public partial class ctrlOrgChartPositions : OrgChartRequiredUserControlBase
    {
        private string _FPPSVacancyWordPhrase = string.Empty;
        private string _WFPVacancyWordPhrase = string.Empty;        
        private string _excludeConfirmationMessage = string.Empty;
        private string _excludeConfirmationTitle = string.Empty;
        private string _childCountFormatLine = string.Empty;
        private const string POSITIONIDKEY = "posID";

        #region Properties

        private int DrillPositionID
        {
            get
            {
                if (ViewState["DrillPositionID"] == null)
                    ViewState["DrillPositionID"] = -1;

                return (int)ViewState["DrillPositionID"];
            }
            set
            {
                ViewState["DrillPositionID"] = value;
            }
        }

        #endregion

        protected override void OnInit(EventArgs e)
        {            
            this.Load += new EventHandler(Page_Load);
            this.buttonOrganizationChartDetails.Click += new EventHandler(buttonOrganizationChartDetails_Click);
            this.buttonAddNewWFP.Click += new EventHandler(buttonAddNewWFP_Click);
            this.gridPositions.ItemCommand += new GridCommandEventHandler(gridPositions_ItemCommand);
            this.gridPositions.ItemCreated += new GridItemEventHandler(gridPositions_ItemCreated);
            this.gridPositions.ItemDataBound += new GridItemEventHandler(gridPositions_ItemDataBound);
            this.gridPositions.PageIndexChanged += new GridPageChangedEventHandler(gridViewItems_PageIndexChanged);
            this.gridPositions.PageSizeChanged += new GridPageSizeChangedEventHandler(gridViewItems_PageSizeChanged);
            base.OnInit(e);
        }
         
        private void loadResources()
        {
            // load the resources that are used multiple times
            _FPPSVacancyWordPhrase = GetLocalResourceObject("FPPSVacancyWordPhrase").ToString();
            _WFPVacancyWordPhrase = GetLocalResourceObject("WFPVacancyWordPhrase").ToString();            
            _excludeConfirmationMessage = GetLocalResourceObject("ExcludeConfirmationMessage").ToString();
            _excludeConfirmationTitle = GetLocalResourceObject("ExcludeConfirmationTitle").ToString();
            _childCountFormatLine = GetLocalResourceObject("ChildCountFormatLine").ToString();
        }

        private void Page_Load(object sender, EventArgs e)
        {
            try
            {
                loadResources();

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
            // load data
            base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(), chart.OrganizationName, chart.OrgCode.OrganizationCodeValue));

            int tempPositionID = -1;
            bool isTempIDOK = true;

            // check drill down value -- not certain if there is a global 
            if (Request.QueryString[POSITIONIDKEY] != null)
                isTempIDOK = int.TryParse(Request.QueryString[POSITIONIDKEY], out tempPositionID);

            if (isTempIDOK)
            {
                setView(chart, tempPositionID);

                customOrgChartDetails.BindData(chart);
                bindPositionsGrid();
            }
            else
                base.PrintErrorMessage(GetLocalResourceObject("InvalidPositionIDParameterMessage").ToString());
        }

        private void setView(OrganizationChart chart, int tempPositionID)
        {
            if (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Undefined || chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Approval || chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Published)
            {
                this.gridPositions.Columns[0].Visible = false;  // Exclude Column
                this.gridPositions.Columns[1].Visible = false;  // Include Column
                this.buttonAddNewWFP.Visible = false;   // Add New WFP button
            }

            bool showDrillDown = (tempPositionID != -1);
            this.panelDrillUp.Visible = showDrillDown;

            if (showDrillDown)
            {
                // 1. load position and see if it is valid
                // 2. set this.DrillPositionID
                // 3. check to see if it is broken hierarchy
                // 4. load reports to ID

                OrganizationChartPosition testPosition = OrganizationChartPositionManager.Instance.GetByID(base.CurrentOrgChartID, tempPositionID);

                if (testPosition.WFPPositionID == -1)
                    base.PrintErrorMessage(GetLocalResourceObject("DrillPositionIDNotFoundInChartMessage").ToString());
                else
                {
                    // 2. set this.DrillPositionID
                    this.DrillPositionID = tempPositionID;

                    // show drill down position name/title
                    if (testPosition.PositionStatusHistory.HasValue &&
                        testPosition.PositionStatusHistory.Value == (int)enumOrgPositionStatusHistoryType.ActiveEmployee &&
                        !string.IsNullOrWhiteSpace(testPosition.FullName))
                        this.literalDrillPositionDetails.Text = string.Format("{0} ({1})", testPosition.FullName, testPosition.PositionTitle);
                    else
                        this.literalDrillPositionDetails.Text = string.Format("{0} ({1})", _FPPSVacancyWordPhrase, testPosition.PositionTitle);

                    // 3. check to see if it is broken hierarchy
                    // 4. load reports to ID (if not -1)
                    bool showUpOneLevel = testPosition.IsInChartHierarchy && testPosition.ReportsToID != -1;
                    bool isCurrentPositionRoot = (testPosition.WFPPositionID == chart.StartPointWFPPositionID);

                    if (showUpOneLevel)
                    {
                        string upOneLevelURL = string.Empty;

                        if (isCurrentPositionRoot)
                            // this is the root node of the chart -- next is to show all positions
                            upOneLevelURL = "~/OrgChart/OrgChartPositions.aspx#positionlist";
                        else
                            upOneLevelURL = string.Format("~/OrgChart/OrgChartPositions.aspx?posID={0}#positionlist", testPosition.ReportsToID);

                        this.linkDrillUpOneLevel.NavigateUrl = upOneLevelURL;
                        this.linkDrillUpOneLevelArrow.NavigateUrl = upOneLevelURL;
                    }

                    this.tdDrillUpOneLevel.Visible = showUpOneLevel && !isCurrentPositionRoot;
                    this.tdDrillUpOneLevelArrow.Visible = showUpOneLevel && !isCurrentPositionRoot;

                    this.tdDrillUpOneLevelArrowDisabled.Visible = !testPosition.IsInChartHierarchy;
                    this.tdDrillUpOneLevelDisabled.Visible = !testPosition.IsInChartHierarchy;
                }
            }
        }

        #region Grid Methods and Events

        private void bindPositionsGrid()
        {
            try
            {
                OrganizationChartPositionCollection positionList = null;
                string noRecordsMessage = string.Empty;

                if (this.DrillPositionID == -1)
                {
                    noRecordsMessage = GetLocalResourceObject("NoPositionRecordsMessage").ToString();
                    positionList = OrganizationChartPositionManager.Instance.GetOrganizationChartPositions(base.CurrentOrgChartID);
                }
                else
                {
                    noRecordsMessage = GetLocalResourceObject("NoPositionDrillDownRecordsMessage").ToString();
                    positionList = OrganizationChartPositionManager.Instance.GetOrganizationChartSubordinatePositionsByPosition(base.CurrentOrgChartID, this.DrillPositionID);
                }

                this.gridPositions.MasterTableView.NoRecordsTemplate = new NoRecordsTemplate(noRecordsMessage);
                this.gridPositions.DataSource = positionList;
                this.gridPositions.DataBind();
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }            
        }

        private void gridPositions_ItemCreated(object sender, GridItemEventArgs e)
        {
            try
            {
                if (e.Item is GridDataItem)
                {
                    ImageButton imageButtonExclude = e.Item.FindControl("imageButtonExclude") as ImageButton;
                    string confirmationScript = string.Format("customConfirm(this, '{0}', '{1}', 125, null); return false;", _excludeConfirmationMessage, _excludeConfirmationTitle);

                    imageButtonExclude.Attributes.Add("onclick", confirmationScript);
                }
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }

        private void gridPositions_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                OrganizationChartPosition itemPosition = e.Item.DataItem as OrganizationChartPosition;
                Literal literalEmployeeName = e.Item.FindControl("literalEmployeeName") as Literal;
                HyperLink linkPositionTitle = e.Item.FindControl("linkPositionTitle") as HyperLink;
                Literal literalPositionNumberBaseSuffix = e.Item.FindControl("literalPositionNumberBaseSuffix") as Literal;
                Literal literalPayPlanGrade = e.Item.FindControl("literalPayPlanGrade") as Literal;
                Literal literalNoExclude = e.Item.FindControl("literalNoExclude") as Literal;
                Literal literalSeriesNumber = e.Item.FindControl("literalSeriesNumber") as Literal;
                ImageButton imageButtonExclude = e.Item.FindControl("imageButtonExclude") as ImageButton;
                Literal literalStarForChildCount = e.Item.FindControl("literalStarForChildCount") as Literal;
                HyperLink linkChildCount = e.Item.FindControl("linkChildCount") as HyperLink;
                Literal literalChildCount = e.Item.FindControl("literalChildCount") as Literal;
                Literal literalRootParentInHierarchy = e.Item.FindControl("literalRootParentInHierarchy") as Literal;
                Image imageInHierarchy = e.Item.FindControl("imageInHierarchy") as Image;
                Image imageNotInHierarchy = e.Item.FindControl("imageNotInHierarchy") as Image;
                Image imageParentInHierarchy = e.Item.FindControl("imageParentInHierarchy") as Image;
                Image imageParentNotInHierarchy = e.Item.FindControl("imageParentNotInHierarchy") as Image;
                HtmlGenericControl divTopLevelPosition = e.Item.FindControl("divTopLevelPosition") as HtmlGenericControl;
                HyperLink linkInclude = e.Item.FindControl("linkInclude") as HyperLink;

                bool isRoot = (itemPosition.WFPPositionID != -1 && itemPosition.WFPPositionID == base.CurrentOrgChart.StartPointWFPPositionID);
                divTopLevelPosition.Visible = isRoot;                
                imageButtonExclude.CommandArgument = itemPosition.WFPPositionID.ToString();

                // exclude root node AND check to make sure that there are no children
                bool okToExclude = (!isRoot && itemPosition.ChartChildCount == 0);

                literalNoExclude.Visible = !okToExclude;
                imageButtonExclude.Visible = okToExclude;
                linkPositionTitle.Text = HttpUtility.HtmlEncode(itemPosition.PositionTitle);

                string linkPositionEditURL = string.Format("~/OrgChart/UpdateChartPosition.aspx?editPosID={0}", itemPosition.WFPPositionID);
                string linkIncludeURL = string.Format("~/OrgChart/IncludePositions.aspx?editPosID={0}", itemPosition.WFPPositionID);

                if (this.DrillPositionID != -1)
                {
                    linkPositionEditURL += string.Format("&viewPosID={0}", this.DrillPositionID);
                    linkIncludeURL += string.Format("&viewPosID={0}", this.DrillPositionID);
                }

                linkPositionTitle.NavigateUrl = linkPositionEditURL;
                linkInclude.NavigateUrl = linkIncludeURL;

                bool isFPPSOnly = !string.IsNullOrWhiteSpace(itemPosition.PositionNumberBase) && !string.IsNullOrWhiteSpace(itemPosition.PositionNumberSuffix);
                literalPositionNumberBaseSuffix.Visible = isFPPSOnly;

                string vacantPhrase = string.Empty;

                if (isFPPSOnly)
                {
                    vacantPhrase = _FPPSVacancyWordPhrase;
                    literalPositionNumberBaseSuffix.Text = HttpUtility.HtmlEncode(string.Format("{0}-{1}", itemPosition.PositionNumberBase, itemPosition.PositionNumberSuffix));
                }
                else
                    vacantPhrase = _WFPVacancyWordPhrase;

                literalEmployeeName.Text = HttpUtility.HtmlEncode(itemPosition.PositionStatusHistory.HasValue && itemPosition.PositionStatusHistory.Value == (int)enumOrgPositionStatusHistoryType.ActiveEmployee ?
                                            itemPosition.FullNameReverse : vacantPhrase);

                literalPayPlanGrade.Text = HttpUtility.HtmlEncode(string.Format("{0}-{1}", itemPosition.PayPlanAbbreviation, itemPosition.Grade));
                literalSeriesNumber.Text = itemPosition.PaddedSeriesID;

                // set direct child count
                bool hasTotalChildrenAndInHierarchy = (itemPosition.DirectChildCount > 0);
                linkChildCount.Visible = hasTotalChildrenAndInHierarchy;
                literalChildCount.Visible = !hasTotalChildrenAndInHierarchy;
                literalStarForChildCount.Visible = hasTotalChildrenAndInHierarchy;

                if (hasTotalChildrenAndInHierarchy)
                {
                    linkChildCount.Text = string.Format(_childCountFormatLine, itemPosition.ChartChildCount, itemPosition.DirectChildCount);
                    linkChildCount.NavigateUrl = string.Format("~/OrgChart/OrgChartPositions.aspx?posID={0}#positionlist", itemPosition.WFPPositionID);
                }
                else
                    literalChildCount.Text = itemPosition.DirectChildCount.ToString();

                // set image in/not in chart hierarchy display
                imageInHierarchy.Visible = itemPosition.IsInChartHierarchy;
                imageNotInHierarchy.Visible = !itemPosition.IsInChartHierarchy;

                // set image PARENT in/not in chart hierarchy display
                imageParentInHierarchy.Visible = !isRoot && itemPosition.IsParentInChartHierarchy;
                imageParentNotInHierarchy.Visible = !isRoot && !itemPosition.IsParentInChartHierarchy;
                literalRootParentInHierarchy.Visible = isRoot;
            }
        }

        private void gridPositions_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Exclude")
                {
                    OrganizationChartPositionManager manager = new OrganizationChartPositionManager();
                    OrganizationChartPosition position = new OrganizationChartPosition()
                    {
                        OrganizationChartID = base.CurrentOrgChartID,
                        WFPPositionID =  int.Parse(e.CommandArgument.ToString()),
                        UpdatedByID =CurrentUserID 
                    };

                    manager.Exclude(position);
                    this.bindPositionsGrid();

                    // refresh chart data
                    base.RefreshOrgChartDataOnly();

                    // reload validations
                    this.customOrgChartDetails.BindData(base.CurrentOrgChart);
                }
            }
            catch (PositionContainsSubordinatesException)
            {
                customPositionsErrorMessage.ErrorMessage = GetLocalResourceObject("PositionContainsSubordinatesExceptionMessage").ToString();
                this.bindPositionsGrid();
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }

        private void gridViewItems_PageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            bindPositionsGrid();
        }

        private void gridViewItems_PageSizeChanged(object source, GridPageSizeChangedEventArgs e)
        {
            bindPositionsGrid();
        }

        #endregion

        #region Button Click Event

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

        private void buttonAddNewWFP_Click(object sender, EventArgs e)
        {
            try
            {
                string link = "~/OrgChart/AddWFPPosition.aspx";

                if (this.DrillPositionID != -1)
                    link += string.Format("?viewPosID={0}", this.DrillPositionID);

                base.SafeRedirect(link);
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
                this.gridPositions.Columns[0].Visible = accessOK;
                this.gridPositions.Columns[1].Visible = accessOK;
                this.buttonAddNewWFP.Visible = accessOK;
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }
    }
}