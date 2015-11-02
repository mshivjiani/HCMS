using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart.Published;
using HCMS.Business.OrganizationChart.Published.Positions;
using HCMS.Business.OrganizationChart;
using HCMS.WebFramework.Site.Sessions;
using HCMS.Business.OrganizationChart.Processing;

namespace HCMS.OrgChart.Controls.PubOrgChart
{
    public partial class ctrlViewOrgChart : PubOrgChartRequiredUserControlBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.buttonChartPositions.Click += new EventHandler(buttonChartPositions_Click);
            this.buttonOrganizationChartDetails.Click += new EventHandler(buttonOrganizationChartDetails_Click);
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
            try
            {
                OrganizationChartLog chartLog = base.CurrentOrgChartLog;
                this.customPubOrgChartDetails.BindData(chartLog);

                // set chart generation parameters
                ChartGenerationParameters genParams = new ChartGenerationParameters()
                {
                    ID = chartLog.OrganizationChartLogID,
                    ChartType = OrganizationChartTypeViews.Published
                };

                base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(), chartLog.OrganizationName, chartLog.OrgCode.OrganizationCodeValue));
                IList<OrganizationChartPositionLog> positionList = OrganizationChartPositionLogManager.Instance.GetOrganizationChartPositionLogs(chartLog.OrganizationChartLogID);
                this.customDisplayChart.BindChart(genParams, positionList.ToList<IChartPosition>(), chartLog.StartPointWFPPositionID);
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
                base.GoToPublishedOrganizationChartPositions();
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