using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.BaseControls;

namespace HCMS.OrgChart.OrgChart
{
    public partial class AddWFPPosition : OrgChartPageBase
    {
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.customAddWFPPosition.TitleChanged += new UserControlBase.TitleChangedHandler(customAddWFPPosition_TitleChanged);
            base.OnInit(e);
        }

        private void customAddWFPPosition_TitleChanged(string newTitle)
        {
            base.PageTitle = newTitle;
        }
    }
}