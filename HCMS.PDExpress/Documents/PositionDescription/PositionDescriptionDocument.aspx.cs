using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;


using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site;
using HCMS.WebFramework.Site.Utilities;
using PDBus = HCMS.Business.PD;
using PDReports = HCMS.Reports;
using TReports = Telerik.Reporting;
using Telerik.Reporting.Processing;

namespace HCMS.PDExpress.Documents.PositionDescription
{
    public partial class PositionDescriptionDocument : PageBase
    {
        protected long PDID
        {
            get
            {
                if (Request.QueryString["PDID"] == null)
                    return -1;
                else
                    return Convert.ToInt64(Request.QueryString["PDID"]);
            }
        }

        protected override void Page_Load(object sender, EventArgs e)
        {
            if (this.PDID > 0)
            {
                PDBus.PositionDescription currentPD = new HCMS.Business.PD.PositionDescription(PDID);
                string docName = string.Format("PositionDescriptionDocument{0}.pdf", PDID);
                if (currentPD.PositionDescriptionTypeID == (int)PDChoiceType.StatementOfDifferencePD)
                {
                    PDReports.PositionDescription.SODPDDocument pddoc = new PDReports.PositionDescription.SODPDDocument();
                    pddoc.ReportParameters["PositionDescriptionID"].Value = this.PDID;
                    ControlUtility.ExportToPDF(docName, pddoc);
                }
                else if (currentPD.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD)
                {
                    PDReports.CareerLadderDocuments.PDDocument pddoc = new PDReports.CareerLadderDocuments.PDDocument();
                    pddoc.ReportParameters["PositionDescriptionID"].Value = this.PDID;
                    ControlUtility.ExportToPDF(docName, pddoc);
                }
                else
                {
                    PDReports.PositionDescription.PDDocument pddoc = new PDReports.PositionDescription.PDDocument();
                    pddoc.ReportParameters["PositionDescriptionID"].Value = this.PDID;
                    ControlUtility.ExportToPDF(docName, pddoc);
                }
            }
            base.Page_Load(sender, e);
        }
    }
}
