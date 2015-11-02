using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BaseControls;
using HCMS.WebFramework.BasePages;

namespace HCMS.OrgChart.OrgChart
{
    public partial class OrgChartDetails : OrgChartPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.ctrlOrgChartDetailsInProgress.TitleChanged += new UserControlBase.TitleChangedHandler(ctrlOrgChartDetailsInProgress_TitleChanged);
            base.OnInit(e);
        }

        private void ctrlOrgChartDetailsInProgress_TitleChanged(string newTitle)
        {
            base.PageTitle = newTitle;
        }
    }
}