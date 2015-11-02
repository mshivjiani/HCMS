using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Positions;
using HCMS.Business.OrganizationChart.Positions.Collections;
using HCMS.Business.OrganizationChart.Published.Positions;
using HCMS.Business.OrganizationChart.Published;
using HCMS.WebFramework.Site.Sessions;
using HCMS.Business.OrganizationChart.Processing;

namespace HCMS.OrgChart.Controls.OrgChart
{
    public partial class ctrlViewOrgChart : OrgChartRequiredUserControlBase
    {
        #region Properties

        private string PreviewTitleInProcess
        {
            get
            {
                if (ViewState["PreviewTitleInProcess"] == null)
                    ViewState["PreviewTitleInProcess"] = GetLocalResourceObject("PreviewTitleInProcess").ToString();

                return ViewState["PreviewTitleInProcess"].ToString();
            }
        }

        private string PreviewTitlePublished
        {
            get
            {
                if (ViewState["PreviewTitlePublished"] == null)
                    ViewState["PreviewTitlePublished"] = GetLocalResourceObject("PreviewTitlePublished").ToString();

                return ViewState["PreviewTitlePublished"].ToString();
            }
        }

        #endregion
        
        protected override void OnInit(EventArgs e)
        {
            this.buttonChartPositions.Click += new EventHandler(buttonChartPositions_Click);
            this.buttonOrganizationChartDetails.Click += new EventHandler(buttonOrganizationChartDetails_Click);
            base.OnInit(e);
        }

        public void BindChart(OrganizationChart chart, OrganizationChartTypeViews viewType)
        {
            try
            {
                this.customOrgChartDetails.BindData(chart);

                // set chart generation parameters
                ChartGenerationParameters chartParameters = new ChartGenerationParameters()
                {
                    ChartType = viewType
                };

                if (viewType == OrganizationChartTypeViews.InProcess)
                {
                    // get in process chart
                    int chartID = base.CurrentOrgChartID;
                    chartParameters.ID = chartID;

                    this.customDisplayChart.PreviewTitle = this.PreviewTitleInProcess;
                    OrganizationChartPositionCollection positionList = OrganizationChartPositionManager.Instance.GetOrganizationChartPositions(chartID);

                    // pass position list and starting point of the in-process chart                    
                    this.customDisplayChart.BindChart(chartParameters, positionList.ToList<IChartPosition>(), chart.StartPointWFPPositionID);
                }
                else if (viewType == OrganizationChartTypeViews.Published)
                {
                    int chartLogID = base.CurrentOrgChart.PublishedOrganizationChartLogID;
                    chartParameters.ID = chartLogID;
                    ChartGenerationParametersSessionWrapper.Parameters = chartParameters;

                    this.customDisplayChart.PreviewTitle = this.PreviewTitlePublished;

                    // Load up chart log based on most recent published version
                    OrganizationChartLog chartLog = OrganizationChartLogManager.Instance.GetByID(chartLogID);
                    IList<OrganizationChartPositionLog> positionList = OrganizationChartPositionLogManager.Instance.GetOrganizationChartPositionLogs(chartLogID);

                    // pass position list and starting point OF THE PUBLISHED CHART (not the in-process chart)
                    this.customDisplayChart.BindChart(chartParameters, positionList.ToList<IChartPosition>(), chartLog.StartPointWFPPositionID);
                }
            }
            catch (Exception ex)
            {	
                base.HandleException(ex);
            }
        }

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