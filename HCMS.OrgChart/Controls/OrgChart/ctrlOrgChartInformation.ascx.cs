using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BaseControls;

namespace HCMS.OrgChart.Controls.OrgChart
{
    public partial class ctrlOrgChartInformation : OrgChartRequiredUserControlBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void ToggleReadOnlyView(enumNavigationMode selectedMode)
        {
            throw new NotImplementedException();
        }
    }
}