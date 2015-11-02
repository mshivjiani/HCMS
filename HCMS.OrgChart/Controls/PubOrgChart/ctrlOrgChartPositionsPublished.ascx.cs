using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Published;
using HCMS.Business.OrganizationChart.Published.Positions;
using HCMS.WebFramework.Controls.RadGrid;
using Telerik.Web.UI;
using System.Web.UI.HtmlControls;

namespace HCMS.OrgChart.Controls.PubOrgChart
{
    public partial class ctrlOrgChartPositionsPublished : PubOrgChartRequiredUserControlBase
    {
        private string _nameNotAvailable = string.Empty;
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
            this.gridPositions.ItemDataBound += new GridItemEventHandler(gridPositions_ItemDataBound);
            this.gridPositions.PageIndexChanged += new GridPageChangedEventHandler(gridViewItems_PageIndexChanged);
            this.gridPositions.PageSizeChanged += new GridPageSizeChangedEventHandler(gridViewItems_PageSizeChanged);
            base.OnInit(e);
        }

        private void loadResources()
        {
            // load the resources that are used multiple times
            _nameNotAvailable = GetLocalResourceObject("NameNotAvailableMessage").ToString();
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
            OrganizationChartLog chartLog = base.CurrentOrgChartLog;

            // validation check for base.CurrentOrgChartLog is in PubOrgChartRequiredUserControlBase
            base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(), chartLog.OrganizationName, chartLog.OrgCode.OrganizationCodeValue));

            int tempPositionID = -1;
            bool isTempIDOK = true;

            // check drill down value -- not certain if there is a global 
            if (Request.QueryString[POSITIONIDKEY] != null)
                isTempIDOK = int.TryParse(Request.QueryString[POSITIONIDKEY], out tempPositionID);

            if (isTempIDOK)
            {
                setView(chartLog, tempPositionID);
                this.customPubOrgChartDetails.BindData(chartLog);
                bindPositionsGrid();
            }
            else
                base.PrintErrorMessage(GetLocalResourceObject("InvalidPositionIDParameterMessage").ToString());
        }

        private void setView(OrganizationChartLog chart, int tempPositionID)
        {
            bool showDrillDown = (tempPositionID != -1);
            this.panelDrillUp.Visible = showDrillDown;

            if (showDrillDown)
            {
                // 1. load position and see if it is valid
                // 2. set this.DrillPositionID
                // 3. check to see if it is broken hierarchy
                // 4. load reports to ID

                OrganizationChartPositionLog testPosition = OrganizationChartPositionLogManager.Instance.GetByID(chart.OrganizationChartLogID, tempPositionID);

                if (testPosition.WFPPositionID == -1)
                    base.PrintErrorMessage(GetLocalResourceObject("DrillPositionIDNotFoundInChartMessage").ToString());
                else
                {
                    // 2. set this.DrillPositionID
                    this.DrillPositionID = tempPositionID;

                    // show drill down position name/title
                    //if (testPosition.PositionStatusHistory.HasValue &&
                    //    testPosition.PositionStatusHistory.Value == (int)enumOrgPositionStatusHistoryType.ActiveEmployee &&
                    //    !string.IsNullOrWhiteSpace(testPosition.FullName))
                    //    this.literalDrillPositionDetails.Text = string.Format("{0} ({1})", testPosition.FullName, testPosition.PositionTitle);
                    //else
                    if (string.IsNullOrWhiteSpace(testPosition.FullName))
                        this.literalDrillPositionDetails.Text = string.Format("{0} ({1})", _nameNotAvailable, testPosition.PositionTitle);
                    else
                        this.literalDrillPositionDetails.Text = string.Format("{0} ({1})", testPosition.FullName, testPosition.PositionTitle);

                    // 3. check to see if it is broken hierarchy
                    // 4. load reports to ID (if not -1)
                    bool showUpOneLevel = testPosition.IsInChartHierarchy && testPosition.ReportsToID != -1;
                    bool isCurrentPositionRoot = (testPosition.WFPPositionID == chart.StartPointWFPPositionID);

                    if (showUpOneLevel)
                    {
                        string upOneLevelURL = string.Empty;

                        if (isCurrentPositionRoot)
                            // this is the root node of the chart -- next is to show all positions
                            upOneLevelURL = "~/PubOrgChart/OrgChartPositions.aspx#positionlist";
                        else
                            upOneLevelURL = string.Format("~/PubOrgChart/OrgChartPositions.aspx?posID={0}#positionlist", testPosition.ReportsToID);

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
                IList<OrganizationChartPositionLog> positionList = null;
                string noRecordsMessage = string.Empty;

                if (this.DrillPositionID == -1)
                {
                    noRecordsMessage = GetLocalResourceObject("NoPositionRecordsMessage").ToString();
                    positionList = OrganizationChartPositionLogManager.Instance.GetOrganizationChartPositionLogs(base.CurrentOrgChartLogID);
                }
                else
                {
                    noRecordsMessage = GetLocalResourceObject("NoPositionDrillDownRecordsMessage").ToString();
                    positionList = OrganizationChartPositionLogManager.Instance.GetSubordinateOrganizationChartPositionLogsByParent(base.CurrentOrgChartLogID, this.DrillPositionID);
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

        private void gridPositions_ItemDataBound(object sender, GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                OrganizationChartPositionLog itemPosition = e.Item.DataItem as OrganizationChartPositionLog;
                Literal literalEmployeeName = e.Item.FindControl("literalEmployeeName") as Literal;
                HyperLink linkPositionTitle = e.Item.FindControl("linkPositionTitle") as HyperLink;
                Literal literalPositionNumberBaseSuffix = e.Item.FindControl("literalPositionNumberBaseSuffix") as Literal;
                Literal literalPayPlanGrade = e.Item.FindControl("literalPayPlanGrade") as Literal;
                Literal literalSeriesNumber = e.Item.FindControl("literalSeriesNumber") as Literal;
                Literal literalStarForChildCount = e.Item.FindControl("literalStarForChildCount") as Literal;
                HyperLink linkChildCount = e.Item.FindControl("linkChildCount") as HyperLink;
                Literal literalChildCount = e.Item.FindControl("literalChildCount") as Literal;
                Literal literalRootParentInHierarchy = e.Item.FindControl("literalRootParentInHierarchy") as Literal;
                Image imageInHierarchy = e.Item.FindControl("imageInHierarchy") as Image;
                Image imageNotInHierarchy = e.Item.FindControl("imageNotInHierarchy") as Image;
                Image imageParentInHierarchy = e.Item.FindControl("imageParentInHierarchy") as Image;
                Image imageParentNotInHierarchy = e.Item.FindControl("imageParentNotInHierarchy") as Image;
                HtmlGenericControl divTopLevelPosition = e.Item.FindControl("divTopLevelPosition") as HtmlGenericControl;

                bool isRoot = (itemPosition.WFPPositionID != -1 && itemPosition.WFPPositionID == base.CurrentOrgChartLog.StartPointWFPPositionID);
                divTopLevelPosition.Visible = isRoot;

                linkPositionTitle.Text = HttpUtility.HtmlEncode(itemPosition.PositionTitle);
                string linkPositionEditURL = string.Format("~/PubOrgChart/ViewChartPosition.aspx?viewPosID={0}", itemPosition.WFPPositionID);

                if (this.DrillPositionID != -1)
                    linkPositionEditURL += string.Format("&posID={0}", this.DrillPositionID);

                linkPositionTitle.NavigateUrl = linkPositionEditURL;

                bool hasPNB = !string.IsNullOrWhiteSpace(itemPosition.PositionNumberBase) && !string.IsNullOrWhiteSpace(itemPosition.PositionNumberSuffix);
                literalPositionNumberBaseSuffix.Visible = hasPNB;

                // In Theory: at this point -- these should all be Active Employees -- we do the following checks just to be safe
                if (hasPNB)
                    literalPositionNumberBaseSuffix.Text = HttpUtility.HtmlEncode(string.Format("{0}-{1}", itemPosition.PositionNumberBase, itemPosition.PositionNumberSuffix));

                // Repeat -- In Theory: at this point -- these should all be Active Employees -- we do the following check just to be safe
                if (string.IsNullOrWhiteSpace(itemPosition.FullName))
                    literalEmployeeName.Text = _nameNotAvailable;
                else
                    literalEmployeeName.Text = itemPosition.FullNameReverse;

                literalPayPlanGrade.Text = HttpUtility.HtmlEncode(string.Format("{0}-{1}", itemPosition.PayPlanAbbreviation, itemPosition.Grade));
                literalSeriesNumber.Text = itemPosition.PaddedSeriesID;

                // set direct child count
                bool hasChildrenAndInHierarchy = (itemPosition.DirectChildCount > 0);
                linkChildCount.Visible = hasChildrenAndInHierarchy;
                literalChildCount.Visible = !hasChildrenAndInHierarchy;
                literalStarForChildCount.Visible = hasChildrenAndInHierarchy;

                if (hasChildrenAndInHierarchy)
                {
                    linkChildCount.Text = itemPosition.DirectChildCount.ToString();
                    linkChildCount.NavigateUrl = string.Format("~/PubOrgChart/OrgChartPositions.aspx?posID={0}#positionlist", itemPosition.WFPPositionID);
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
                base.GoToPublishedOrganizationChartDetails();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        #endregion
    }
}