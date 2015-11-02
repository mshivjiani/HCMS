using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
namespace HCMS.OrgChart.Common
{
    public partial class Help : OrgChartPageBase 
    {
        protected override void Page_Load(object sender, EventArgs e)
        {
            base.PageTitle = "Help";
        }
    }
}