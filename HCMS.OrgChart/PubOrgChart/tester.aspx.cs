using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using HCMS.WebFramework.BasePages;

namespace HCMS.OrgChart.PubOrgChart
{
    public partial class tester : OrgChartPageBase
    {
        // TODO_ARJ: Delete this file
        protected override void OnInit(EventArgs e)
        {
            this.Load += new EventHandler(Page_Load);
            this.buttonSubmit.Click += new EventHandler(buttonSubmit_Click);
            base.OnInit(e);
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {

            int tempChartLogID = int.Parse(textboxChartLogID.Text);
            base.SetOrgChartLogID(tempChartLogID);

            // redirect to pub org chart details page
            base.SafeRedirect("~/PubOrgChart/OrgChartDetails.aspx");
        }

        private void Page_Load(object sender, EventArgs e)
        {
            
        }
    }
}