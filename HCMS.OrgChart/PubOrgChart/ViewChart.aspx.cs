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
    public partial class ViewChart : OrgChartPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.customViewChart.TitleChanged += new UserControlBase.TitleChangedHandler(customViewChart_TitleChanged);
            base.OnInit(e);
        }

        private void customViewChart_TitleChanged(string newTitle)
        {
            base.PageTitle = newTitle;
        }
    }
}