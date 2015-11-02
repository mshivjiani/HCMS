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
using PDReports = HCMS.Reports;

namespace HCMS.PDExpress.Documents.CodingInfo
{
    public partial class CodingInfoDocument : PageBase
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
            PDReports.CodingInfo.CodingInfo codingInfodoc = new PDReports.CodingInfo.CodingInfo();
            if (this.PDID > 0)
            {
                codingInfodoc.ReportParameters["PositionDescriptionID"].Value = this.PDID;
                string docName = string.Format("CodingInformation{0}.pdf", PDID);
                ControlUtility.ExportToPDF(docName, codingInfodoc);
            }
            base.Page_Load(sender, e);
        }
    }
}
