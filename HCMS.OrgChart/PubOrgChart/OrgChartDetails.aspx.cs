using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.BaseControls;

namespace HCMS.OrgChart.PubOrgChart
{
    public partial class OrgChartDetails : OrgChartPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.customOrgChartDetails.TitleChanged += new UserControlBase.TitleChangedHandler(customOrgChartDetails_TitleChanged);
            base.OnInit(e);
        }

        private void customOrgChartDetails_TitleChanged(string newTitle)
        {
            base.PageTitle = newTitle;
        }
    }
}