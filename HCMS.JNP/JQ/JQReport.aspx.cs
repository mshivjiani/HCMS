using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using HCMS.WebFramework.Site.Utilities;
using JNPReports = HCMS.JNP.Reports;
using HCMS.WebFramework.Site.Utilities;
using System.Collections;
using HCMS.WebFramework.BasePages;
using HCMS.Business.JQ;

namespace HCMS.JNP.JQ
{
    public partial class JQReport :    System.Web.UI.Page  
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string docName = string.Empty;
            long JNPID = -1;
            if (Request.QueryString["JNPID"] != null)
            {
                JNPID = Convert.ToInt64(Request.QueryString["JNPID"]); 
                
                if (Request.QueryString["ReportFormat"] == enumDocumentFormat.PDF.ToString())
                {
                    JNPReports.JobQuestionaire currentJobQuestionairePDFDoc = new JNPReports.JobQuestionaire();
                    docName = string.Format("JobQuestionaire{0}.pdf", JNPID);
                    currentJobQuestionairePDFDoc.ReportParameters["jNPID"].Value = JNPID;
                    currentJobQuestionairePDFDoc.ReportParameters["documentObjectTypeId"].Value = Convert.ToInt32(enumDocumentType.JQ);
                    ControlUtility.ExportToPDF(docName, currentJobQuestionairePDFDoc);              
                }
                else
                {
                    JQManager jqManager = new JQManager();
                    docName = string.Format("JobQuestionaire{0}.txt", JNPID);
                    string jobQuestionnaireUTF8Doc = jqManager.CreateUTF8JobQuestionnaireReport(JNPID);
                    ControlUtility.ExportToUTF8(docName, jobQuestionnaireUTF8Doc);
                }
            }                  
        }
    }
}