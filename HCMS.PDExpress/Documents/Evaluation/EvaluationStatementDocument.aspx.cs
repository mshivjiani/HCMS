using System;

using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site.Utilities;
using PDBus = HCMS.Business.PD;
using PDReports = HCMS.Reports;
namespace HCMS.PDExpress.Documents.Evaluation
{
    public partial class EvaluationStatementDocument : PageBase
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
                    PDReports.CareerLadderDocuments.EvalStatement evaldoc = new PDReports.CareerLadderDocuments.EvalStatement();
                    evaldoc.ReportParameters["PositionDescriptionID"].Value = this.PDID;
                    string docName = string.Format("EvaluationStatement{0}.pdf", PDID);
                    ControlUtility.ExportToPDF(docName, evaldoc);
                }
                else
                {
                    PDReports.Evaluation.EvalStatement evaldoc = new PDReports.Evaluation.EvalStatement();
                    evaldoc.ReportParameters["PositionDescriptionID"].Value = this.PDID;
                    string docName = string.Format("EvaluationStatement{0}.pdf", PDID);
                    ControlUtility.ExportToPDF(docName, evaldoc);
                }
            }
            base.Page_Load(sender, e);
        }
    }
}
