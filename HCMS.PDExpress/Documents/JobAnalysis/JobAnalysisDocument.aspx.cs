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
using TReports = Telerik.Reporting;
using Telerik.Reporting.Processing;
using PDBus = HCMS.Business.PD;
using PDReports = HCMS.Reports;
namespace HCMS.PDExpress.Documents.JobAnalysis
{
    public partial class JobAnalysisDocument : PageBase
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
                if (currentPD.PositionDescriptionTypeID == (int)PDChoiceType.CareerLadderPD)
                {
                    PDReports.CareerLadderDocuments.JobAnalysis jobAnalysisDoc = new PDReports.CareerLadderDocuments.JobAnalysis();
                    jobAnalysisDoc.ReportParameters["PositionDescriptionID"].Value = this.PDID;
                    jobAnalysisDoc.PageSettings.Landscape = false;
                    string docName = string.Format("JobAnalysis{0}.pdf", PDID);
                    ControlUtility.ExportToPDF(docName, jobAnalysisDoc);
                }
                else
                {
                    PDReports.JobAnalysis.JobAnalysis jobAnalysisDoc = new PDReports.JobAnalysis.JobAnalysis();
                    jobAnalysisDoc.ReportParameters["PositionDescriptionID"].Value = this.PDID;
                    jobAnalysisDoc.PageSettings.Landscape = false;
                    string docName = string.Format("JobAnalysis{0}.pdf", PDID);
                    ControlUtility.ExportToPDF(docName, jobAnalysisDoc);
                }

            }
            base.Page_Load(sender, e);
        }
    }
}
