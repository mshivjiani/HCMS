using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;
using Telerik.Web.UI;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.OrganizationChart.Positions.Exceptions;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.WebFramework.Controls.RadGrid;
using System.Web.UI.HtmlControls;

namespace HCMS.OrgChart.Controls.Positions
{
    public partial class ctrlNewFPPSPositions : OrgChartRequiredUserControlBase
    {
        private string _FPPSVacancyWordPhrase = string.Empty;
        private string _WFPVacancyWordPhrase = string.Empty;
        private string _excludeConfirmationMessage = string.Empty;
        private string _excludeConfirmationTitle = string.Empty;
        private string _includeConfirmationMessage = string.Empty;
        private string _includeConfirmationTitle = string.Empty;

        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.buttonChartPositions.Click += new EventHandler(buttonChartPositions_Click);
            this.buttonOrganizationChartDetails.Click += new EventHandler(buttonOrganizationChartDetails_Click);
            this.gridPositions.ItemCreated += new GridItemEventHandler(gridPositions_ItemCreated);
            this.gridPositions.ItemCommand += new GridCommandEventHandler(gridPositions_ItemCommand);
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
            _includeConfirmationMessage = GetLocalResourceObject("IncludeConfirmationMessage").ToString();
            _includeConfirmationTitle = GetLocalResourceObject("IncludeConfirmationTitle").ToString();
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
            base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(), chart.OrganizationName, chart.OrgCode.OrganizationCodeValue));
            customOrgChartDetails.BindData(chart);
            setView(chart);
            bindNewFPPSPositionsGrid();
        }

        private void setView(OrganizationChart chart)
        {
            if (chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Undefined || chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Approval || chart.OrgWorkflowStatusID == enumOrgWorkflowStatus.Published)
            {
                this.gridPositions.Columns[0].Visible = false;  // Exclude Column
                this.gridPositions.Columns[1].Visible = false;  // Include Column
            }
        }

        #region Grid Methods and Events

        private void bindNewFPPSPositionsGrid()
        {
            try
            {
                this.gridPositions.DataSource = WorkforcePlanningPositionManager.Instance.GetNewFPPSPositionsByOrganizationChart(base.CurrentOrgChartID);
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
                    imageButtonExclude.Attributes.Add("onclick", string.Format("customConfirm(this, '{0}', '{1}', 125, null); return false;", _excludeConfirmationMessage, _excludeConfirmationTitle));
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
                WorkforcePlanningPosition itemPosition = e.Item.DataItem as WorkforcePlanningPosition;
                Literal literalEmployeeName = e.Item.FindControl("literalEmployeeName") as Literal;
                HyperLink linkPositionTitle = e.Item.FindControl("linkPositionTitle") as HyperLink;
                HyperLink linkInclude = e.Item.FindControl("linkInclude") as HyperLink;
                Literal literalPositionNumberBaseSuffix = e.Item.FindControl("literalPositionNumberBaseSuffix") as Literal;
                Literal literalPayPlanGrade = e.Item.FindControl("literalPayPlanGrade") as Literal;
                Literal literalSeriesNumber = e.Item.FindControl("literalSeriesNumber") as Literal;
                Literal literalNoExclude = e.Item.FindControl("literalNoExclude") as Literal;
                Literal literalDirectChildCount = e.Item.FindControl("literalDirectChildCount") as Literal;
                ImageButton imageButtonExclude = e.Item.FindControl("imageButtonExclude") as ImageButton;

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

                literalEmployeeName.Text = itemPosition.PositionStatusHistory.HasValue && itemPosition.PositionStatusHistory.Value == (int)enumOrgPositionStatusHistoryType.ActiveEmployee ?
                                            HttpUtility.HtmlEncode(itemPosition.FullNameReverse) : vacantPhrase;

                linkPositionTitle.Text = HttpUtility.HtmlEncode(itemPosition.PositionTitle);
                linkPositionTitle.NavigateUrl = string.Format("~/OrgChart/UpdateNewFPPSPosition.aspx?editPosID={0}", itemPosition.WFPPositionID);
                linkInclude.NavigateUrl = string.Format("~/OrgChart/UpdateNewFPPSPosition.aspx?editPosID={0}", itemPosition.WFPPositionID);

                literalPayPlanGrade.Text = HttpUtility.HtmlEncode(string.Format("{0}-{1}", itemPosition.PayPlanAbbreviation, itemPosition.Grade));
                literalSeriesNumber.Text = itemPosition.PaddedSeriesID;
                literalDirectChildCount.Text = itemPosition.DirectChildCount.ToString();

                // exclude root node AND check to make sure that there are no children
                bool okToExclude = (itemPosition.DirectChildCount == 0);

                literalNoExclude.Visible = !okToExclude;
                imageButtonExclude.Visible = okToExclude;

                imageButtonExclude.CommandArgument = itemPosition.WFPPositionID.ToString();
            }
        }

        private void gridPositions_ItemCommand(object sender, GridCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "Exclude")
                {
                    OrganizationChartPosition position = new OrganizationChartPosition()
                    {
                        OrganizationChartID = base.CurrentOrgChartID,
                        WFPPositionID = int.Parse(e.CommandArgument.ToString()),
                        UpdatedByID =CurrentUserID 
                    };

                    OrganizationChartPositionManager.Instance.Exclude(position);
                    this.bindNewFPPSPositionsGrid();

                    // refresh chart data
                    base.RefreshOrgChartDataOnly();

                    // reload validations
                    this.customOrgChartDetails.BindData(base.CurrentOrgChart);
                }                
            }
            catch (PositionContainsSubordinatesException)
            {
                customPositionsErrorMessage.ErrorMessage = GetLocalResourceObject("PositionContainsSubordinatesExceptionMessage").ToString();
                this.bindNewFPPSPositionsGrid();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }

        private void gridViewItems_PageIndexChanged(object source, GridPageChangedEventArgs e)
        {
            bindNewFPPSPositionsGrid();
        }

        private void gridViewItems_PageSizeChanged(object source, GridPageSizeChangedEventArgs e)
        {
            bindNewFPPSPositionsGrid();
        }

        #endregion

        #region Button Click Event

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

        #endregion

        protected override void ToggleReadOnlyView(enumNavigationMode selectedMode)
        {
            try
            {
                bool accessOK = (selectedMode == enumNavigationMode.Insert || selectedMode == enumNavigationMode.Edit);
                customReadOnlyLabel.Visible = !accessOK;
                
                this.gridPositions.Columns[0].Visible = accessOK;
                this.gridPositions.Columns[1].Visible = accessOK;
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
    }
}