using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.OrgChart.OrgChart
{
    public partial class CreateOrgChart : OrgChartPageBase
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
                base.PageTitle = GetLocalResourceObject("PageTitle").ToString();
            }
            catch (Exception ex)
            {
                base.HandleException(ex);
            }
        }
    }
}