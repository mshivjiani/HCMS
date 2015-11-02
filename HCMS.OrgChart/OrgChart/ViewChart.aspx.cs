using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BasePages;
using HCMS.Business.OrganizationChart;
using HCMS.WebFramework.Site.Utilities;

namespace HCMS.OrgChart.OrgChart
{
    public partial class ViewChart : OrgChartPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
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
            SiteUtility.RefreshOrgChartDataOnly();
            OrganizationChart chart = SiteUtility.CurrentOrgChart;

            base.PageTitle = string.Format(GetLocalResourceObject("PageTitle").ToString(), chart.OrganizationName, chart.OrgCode.OrganizationCodeValue);
            this.customViewChart.BindChart(chart, OrganizationChartTypeViews.InProcess);
        }
    }
}