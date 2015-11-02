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
    public partial class ViewChartPosition : OrgChartPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.customViewChartPositionDetails.TitleChanged += new UserControlBase.TitleChangedHandler(customViewChartPositionDetails_TitleChanged);
            base.OnInit(e);
        }

        private void customViewChartPositionDetails_TitleChanged(string newTitle)
        {
            base.PageTitle = newTitle;
        }
    }
}