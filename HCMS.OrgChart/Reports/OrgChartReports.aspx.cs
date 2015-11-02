using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
namespace HCMS.OrgChart.Reports
{
    public partial class OrgChartReports : OrgChartPageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
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