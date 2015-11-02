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
namespace HCMS.OrgChart.Reports
{
    public partial class OrgChartCustomReportExport : PageBase 
    {
       
        protected override void Page_Load(object sender, EventArgs e)
        {
           
            if (Session["OrgPositions"] != null)
            {            
                string docName = string.Empty;
                String selectedOrg=string.Empty ;
                if(Session["CustomReportsOrg"]!=null)
                    selectedOrg =Session ["CustomReportsOrg"].ToString ();
                docName = string.Format("{0}-OrgPositions.xlsx",selectedOrg);
                DataTable dtPositions = (DataTable)Session["OrgPositions"];
               
                ControlUtility.ExportDataTableToExcelEPP(dtPositions, docName, "Sheet1");
            }
            base.Page_Load(sender, e);
        }
    }
}