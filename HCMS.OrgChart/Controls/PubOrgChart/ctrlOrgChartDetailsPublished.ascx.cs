using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Published;

namespace HCMS.OrgChart.Controls.PubOrgChart
{
    public partial class ctrlOrgChartDetailsPublished : PubOrgChartRequiredUserControlBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.buttonChartPositions.Click += new EventHandler(buttonChartPositions_Click);
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
            OrganizationChartLog chartLog = base.CurrentOrgChartLog;

            if (chartLog.OrganizationChartLogID == -1)
                base.PrintErrorMessage(GetLocalResourceObject("OrganizationChartLogNotFoundMessage").ToString());
            else
            {
                // load data
                base.SetPageTitle(string.Format(GetLocalResourceObject("PageTitle").ToString(), chartLog.OrganizationName, chartLog.OrgCode.OrganizationCodeValue));
                this.customPubOrgChartDetails.BindData(chartLog);
            }
        }

        #region Button Click Events

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

        #endregion
    }
}