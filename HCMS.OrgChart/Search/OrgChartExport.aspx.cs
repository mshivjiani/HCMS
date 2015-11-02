using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site;
using HCMS.WebFramework.Site.Utilities;
using System.Data;
namespace HCMS.OrgChart.Search
{
    public partial class OrgChartExport : PageBase
    {
        protected override void Page_Load(object sender, EventArgs e)
        {

            if (Session["OrgChartPositions"] != null)
            {
                DataTable dtPositions = (DataTable)Session["OrgChartPositions"];

                string docName = string.Empty;
                int OrganizationChartID=-1;
                string sheetName = string.Empty;

                if (Session["xlOrgChartID"] != null)
                {
                    OrganizationChartID = (int)Session["xlOrgChartID"];
                    docName = string.Format("OrganizationChartID_{0}.xlsx", OrganizationChartID.ToString());
                    sheetName = string.Format("OrganizationCharPositions");

                    ControlUtility.ExportDataTableToExcelEPP(dtPositions, docName,sheetName);
                }
            }
            base.Page_Load(sender, e);

        }
    }
}