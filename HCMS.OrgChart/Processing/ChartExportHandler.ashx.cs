using System;
using System.Web;
using System.Web.SessionState;

using EvoPdf;
using HCMS.Business.OrganizationChart.Processing;
using HCMS.WebFramework.Site.Sessions;
using HCMS.Business.OrganizationChart;
using System.Threading.Tasks;
using EvoPdf.PdfMerge;
using System.IO;
using System.Drawing;

using HCMS.Business.OrganizationChart.Published;
using HCMS.WebFramework.Site.Builders;
using HCMS.WebFramework.Base.Handlers;
using HCMS.WebFramework.Site.Wrappers;

namespace HCMS.OrgChart.Processing
{
    /// <summary>
    /// Summary description for ChartExportHandler
    /// </summary>
    public class ChartExportHandler : HandlerBase, IHttpHandler, IRequiresSessionState 
    {
        private const string MyTrackerURL = "~/Tracker/OrgChartTracker.aspx";
        
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                ChartGenerationParameters chartParameters = ChartGenerationParametersSessionWrapper.Parameters;

                if (UserSessionWrapper.CurrentUserID == -1 || chartParameters.ID == -1 || chartParameters.DocumentID == Guid.Empty || chartParameters.ChartType == OrganizationChartTypeViews.None)
                    context.Response.Redirect(MyTrackerURL, false);
                else
                {
                    int currentUserID = UserSessionWrapper.CurrentUserID;

                    // get TemporaryDocument by documentID and userID
                    TemporaryDocument currentDocument = TemporaryDocumentRepository.Instance.GetByID(chartParameters.DocumentID, currentUserID);

                    if (currentDocument.DocumentID == Guid.Empty)
                        context.Response.Redirect(MyTrackerURL, false);
                    else
                    {
                        // Get IOrganizationChart
                        IOrganizationChart chart = null;

                        if (chartParameters.ChartType == OrganizationChartTypeViews.InProcess)
                            // In-Process
                            chart = OrganizationChartManager.Instance.GetByID(chartParameters.ID);
                        else
                            // Published Chart -- This will have the "ApprovedBy", "OnBehalfOf" and "ApprovedDate"
                            chart = OrganizationChartLogManager.Instance.GetByID(chartParameters.ID);

                        // Pass to PDF Builder
                        OrganizationChartPDFBuilder builder = new OrganizationChartPDFBuilder(context, context.Server.MapPath(ConfigWrapper.OrgChartTemplateFilePath));
                        builder.BuildChart(chart, currentDocument);
                        
                        try
                        {
                            // Delete temporary document from database
                            TemporaryDocumentRepository.Instance.Delete(chartParameters.DocumentID, currentUserID);
                        }
                        catch (Exception ex)
                        {
                            // log if there is an error, but don't prevent execution
                            base.LogExceptionOnly(ex);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException == null)
                    base.LogExceptionOnly(ex);
                else
                    base.LogExceptionOnly(ex.InnerException);

                // throw new Exception("Error Encountered");
                throw new Exception(ex.ToString());
            }

            context.Response.End();
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}