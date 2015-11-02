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
using JNPBus = HCMS.Business.JNP;
using JNPReports = HCMS.JNP.Reports;
using HCMS.Business.JQ;
using HCMS.Business.JQ.Collections;
using HCMS.Business.JNP;
using HCMS.WebFramework.BaseControls;


namespace HCMS.JNP.Documents
{
    public partial class OpenJNPDocument : PageBase
    {
        private long StaffingObjectID
        {
            get
            {
                if (Request.QueryString["id"] == null)
                    return -1;
                else
                    return Convert.ToInt64(Request.QueryString["id"]);
            }
        }

        private enumDocumentType DocumentTypeID
        {
            get
            {
                if (Request.QueryString["typeid"] == null)
                    return enumDocumentType.Unknown;
                else
                    return (enumDocumentType)(Enum.Parse(typeof(enumDocumentType), Request.QueryString["typeid"].ToString()));

            }
        }

        private enumDocumentFormat DocumentFormat
        {
            get
            {
                if (Request.QueryString["documentformat"] == null)
                    return enumDocumentFormat.Unknown;
                else
                    return (enumDocumentFormat)(Enum.Parse(typeof(enumDocumentFormat), Request.QueryString["documentformat"].ToString()));

            }
        }

        private const string CurrentJNP = "CurrentJNP";
        private const string CURRENTNAVMODE = "CurrentNavMode";
        private JNPackage _currentpackage = null;
        protected  JNPackage CurrentPackage
        {
            get
            {
                if (HttpContext.Current.Session[CurrentJNP] != null)
                {
                    _currentpackage = (JNPackage)HttpContext.Current.Session[CurrentJNP];
                }

                return _currentpackage;
            }
        }
        protected   enumNavigationMode CurrentNavMode
        {
            get
            {
                enumNavigationMode currentNavMode = enumNavigationMode.None;
                if (Session[CURRENTNAVMODE] == null)
                {
                    Session[CURRENTNAVMODE] = enumNavigationMode.View;
                }
                currentNavMode = (enumNavigationMode)Session[CURRENTNAVMODE];
                return currentNavMode;
            }
        }
        protected override void Page_Load(object sender, EventArgs e)
        {

            string docFormat = "";
            if(Request.QueryString["documentformat"] !=null)
                docFormat= Request.QueryString["documentformat"].ToString();

            if(docFormat == "DOC") docFormat="DOCX";

            if (this.StaffingObjectID > 0 && this.DocumentTypeID > 0)
            {
                string docName = string.Empty;

                switch (DocumentTypeID)
                {
                    case enumDocumentType.JNP:
                        JNPReports.JobAnalysis currentJNPWorkflowComments = new JNPReports.JobAnalysis();
                        docName = string.Format("JobAnalysis{0}." + docFormat, StaffingObjectID);
                        currentJNPWorkflowComments.ReportParameters["jNPID"].Value = StaffingObjectID;
                        currentJNPWorkflowComments.ReportParameters["documentObjectTypeId"].Value = Request.QueryString["typeid"];
                        currentJNPWorkflowComments.ReportParameters["jAID"].Value = Request.QueryString["jaid"];

                        if(docFormat== enumDocumentFormat.DOCX.ToString())
                            ControlUtility.ExportToDoc(docName, currentJNPWorkflowComments);
                        if (docFormat == enumDocumentFormat.PDF.ToString())
                            ControlUtility.ExportToPDF(docName, currentJNPWorkflowComments);

                        break;
                    case enumDocumentType.JA:
                        JNPReports.JobAnalysis currentJobAnalysisDoc = new JNPReports.JobAnalysis();
                        docName = string.Format("JobAnalysis{0}." + docFormat, StaffingObjectID);
                        currentJobAnalysisDoc.ReportParameters["jNPID"].Value = StaffingObjectID;
                        currentJobAnalysisDoc.ReportParameters["documentObjectTypeId"].Value = Request.QueryString["typeid"];
                        currentJobAnalysisDoc.ReportParameters["jAID"].Value = Request.QueryString["jaid"];
                        

                        if(docFormat== enumDocumentFormat.DOCX.ToString())
                             ControlUtility.ExportToDoc(docName, currentJobAnalysisDoc);
                        if (docFormat == enumDocumentFormat.PDF.ToString())
                            ControlUtility.ExportToPDF(docName, currentJobAnalysisDoc);

                        break;
                    case enumDocumentType.CR:
                        JNPReports.CategoryRating currentCategoryRatingdoc = new JNPReports.CategoryRating();
                        docName = string.Format("CategoryRating{0}." + docFormat, StaffingObjectID);
                        currentCategoryRatingdoc.ReportParameters["jNPID"].Value = StaffingObjectID;
                        currentCategoryRatingdoc.ReportParameters["documentObjectTypeId"].Value = Request.QueryString["typeid"];
                        currentCategoryRatingdoc.ReportParameters["jAID"].Value = Request.QueryString["jaid"];
                        currentCategoryRatingdoc.ReportParameters["cRID"].Value = Request.QueryString["crid"];
                        
                        if(docFormat== enumDocumentFormat.DOCX.ToString())
                            ControlUtility.ExportToDoc(docName, currentCategoryRatingdoc);
                        if (docFormat == enumDocumentFormat.PDF.ToString())
                            ControlUtility.ExportToPDF(docName, currentCategoryRatingdoc);

                        break;
                    case enumDocumentType.JQ:
                        if ((DocumentFormat == enumDocumentFormat.PDF) || (DocumentFormat == enumDocumentFormat.DOCX))
                        {
                            JNPReports.JobQuestionaire currentJobQuestionairePDFDoc = new JNPReports.JobQuestionaire();
                            docName = string.Format("JobQuestionaire{0}." + docFormat, StaffingObjectID);
                            currentJobQuestionairePDFDoc.ReportParameters["jNPID"].Value = StaffingObjectID;
                            currentJobQuestionairePDFDoc.ReportParameters["documentObjectTypeId"].Value = Request.QueryString["typeid"];

                            if (docFormat == enumDocumentFormat.DOCX.ToString())
                                ControlUtility.ExportToDoc(docName, currentJobQuestionairePDFDoc);
                            if (docFormat == enumDocumentFormat.PDF.ToString())
                                ControlUtility.ExportToPDF(docName, currentJobQuestionairePDFDoc);

                        }
                        else if (DocumentFormat == enumDocumentFormat.UTF8)
                        {
                            JQManager jqManager = new JQManager();
                            docName = string.Format("JobQuestionaire{0}.txt", StaffingObjectID);
                            string jobQuestionnaireUTF8Doc = jqManager.CreateUTF8JobQuestionnaireReport(StaffingObjectID);
                            ControlUtility.ExportToUTF8(docName, jobQuestionnaireUTF8Doc);
                        }
                        break;
                    case enumDocumentType.Comments:
                        JNPReports.JNPComments jnpWorkflowComments = new JNPReports.JNPComments();
                        docName = string.Format("JAXComments{0}." + docFormat, StaffingObjectID);
                        jnpWorkflowComments.ReportParameters["jNPID"].Value = StaffingObjectID;
                        jnpWorkflowComments.ReportParameters["documentObjectTypeId"].Value = Request.QueryString["typeid"];

                        if (docFormat == enumDocumentFormat.DOCX.ToString())
                            ControlUtility.ExportToDoc(docName, jnpWorkflowComments);
                        if (docFormat == enumDocumentFormat.PDF.ToString())
                           ControlUtility.ExportToPDF(docName, jnpWorkflowComments);

                        break;
                    case enumDocumentType.All:
                     bool CRActive =false;
                     long crid = Convert.ToInt64(Request.QueryString["crid"]);
                     if (CurrentPackage != null)
                     {
                         CRActive = CurrentPackage.HasActiveCR();

                         //updating order if printing in edit mode by clicking Print All button from within the package
                         if (CurrentNavMode != enumNavigationMode.View)
                         {
                             JQManager jm = new JQManager();
                             // load Factors
                             JQFactorCollection listFactors = jm.GetJQFactorCollectionByJQID(CurrentPackage.JQID);
                             jm.UpdateOrder(CurrentPackage.JQID , listFactors ,CurrentUser.UserID);
                         }
                     }
                     else
                     {
                         
                         if (crid > 0)
                         {
                             HCMS.Business.CR.CategoryRating categoryRating = HCMS.Business.CR.CategoryRatingManager.GetByID(crid);
                             CRActive = (bool)categoryRating.IsActive;
                         }
                         else
                         {
                             CRActive = false;
                         }
                     }
                    JNPReports.JNPReport JNPReportAllDoc = new JNPReports.JNPReport();
                    docName = string.Format("JNPReportAll{0}." + docFormat, StaffingObjectID);

                    if (!CRActive)
                    {
                        JNPReportAllDoc.subReportCR.Visible = false;
                        JNPReportAllDoc.groupHeaderSection3.Visible = false;
                    } 

                    JNPReportAllDoc.ReportParameters["jNPID"].Value = StaffingObjectID;
                    JNPReportAllDoc.ReportParameters["documentObjectTypeId"].Value = enumDocumentType.All ;
                    JNPReportAllDoc.ReportParameters["jAID"].Value = Request.QueryString["jaid"];
                    JNPReportAllDoc.ReportParameters["cRID"].Value = crid;

                    if (docFormat == enumDocumentFormat.DOCX.ToString())
                        ControlUtility.ExportToDoc(docName, JNPReportAllDoc);
                    if (docFormat == enumDocumentFormat.PDF.ToString())
                        ControlUtility.ExportToPDF(docName, JNPReportAllDoc);
                        
                        break;
                    default:
                        break;

                }
            }

            base.Page_Load(sender, e);
        }

    }
}
