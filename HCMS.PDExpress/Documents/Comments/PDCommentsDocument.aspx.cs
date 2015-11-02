using System;

using HCMS.WebFramework.BasePages;
using HCMS.WebFramework.Site.Utilities;
using PDBus = HCMS.Business.PD;
using PDReports = HCMS.Reports;

namespace HCMS.PDExpress.Documents.Comments
{
    public partial class PDCommentsDocument : PageBase
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
                    PDReports.CareerLadderDocuments.PDComments pdcommentsdoc = new PDReports.CareerLadderDocuments.PDComments();
                    pdcommentsdoc.ReportParameters["PositionDescriptionID"].Value = this.PDID;
                    string docName = string.Format("PositionDescription Comments{0}.pdf", PDID);
                    ControlUtility.ExportToPDF(docName, pdcommentsdoc);
                }
                else
                {
                    PDReports.Comments.PDComments pdcommentsdoc = new PDReports.Comments.PDComments();
                    pdcommentsdoc.ReportParameters["PDID"].Value = this.PDID;
                    string docName = string.Format("PositionDescription Comments{0}.pdf", PDID);
                    ControlUtility.ExportToPDF(docName, pdcommentsdoc);
                }
            }
            base.Page_Load(sender, e);
        }
    }
}

