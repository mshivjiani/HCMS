using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;

using EvoPdf;
using EvoPdf.PdfMerge;
using HCMS.Business.OrganizationChart;
using HCMS.Business.OrganizationChart.Processing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using HCMS.Business.OrganizationChart.Published;

namespace HCMS.WebFramework.Site.Builders
{
    public class OrganizationChartPDFBuilder
    {
        #region Object Declarations
        // template keys
        private const string RegionNameKey = "%REGIONNAME%";
        private const string ProgramNameKey = "%PROGRAMNAME%";
        private const string OrganizationNameKey = "%ORGNAME%";
        private const string OrgCodeValueKey = "%ORGCODEVALUE%";
        private const string ChartImageKey = "%CHARTIMAGE%";
        private const string ApprovedNameKey = "%APPROVEDNAME%";
        private const string ApprovedDateKey = "%APPROVEDDATE%";
        private const string CityStateKey = "%CITYSTATE%";

        private const string EVOPDF_LicenseKey = "TMLRw9bTw9LU0sPWzdPD0NLN0tHN2tra2g==";
        private HttpContext _context = null;
        private string _reportOriginalTemplateHTML = string.Empty;
        
        #endregion

        #region Constructor

        public OrganizationChartPDFBuilder(HttpContext loadContext, string reportTemplateFilePath)
        {
            _context = loadContext;

            // load template contents
            loadTemplateContents(reportTemplateFilePath);
        }

        #endregion

        #region Methods

        public void BuildChart(IOrganizationChart chart, ITemporaryDocument tempDoc)
        {
            if (chart == null)
                throw new Exception("IOrganizationChart cannot be null");
            else if (tempDoc == null)
                throw new Exception("ITemporaryDocument cannot be null");
            else
            {
                string imageFileName = string.Format("{0}-{1}.png", tempDoc.DocumentID, tempDoc.UserID);
                string imageFileNameAndPath = Path.Combine(this._context.Server.MapPath("./Generated/"), imageFileName);

                // load data and chart image into HTML template
                string templateHTML = getTemplateWithData(chart, tempDoc, imageFileName, imageFileNameAndPath);

                //// TODO-ARJ: REMOVE LINE
                //using (StreamWriter output = new StreamWriter(string.Format(this._context.Server.MapPath(".") + string.Format("/{0}.html", tempDoc.DocumentID))))
                //    output.Write(templateHTML);

                // build PDF document and write to response
                buildPDFDocument(chart, templateHTML);

                // Delete temporary document
                deleteTemporaryFile(imageFileNameAndPath);
            }
        }

        #endregion

        private void loadTemplateContents(string reportTemplateFilePath)
        {
            try
            {
                using (StreamReader sr = new StreamReader(reportTemplateFilePath))
                {
                    string fileContents = sr.ReadToEnd();
                    this._reportOriginalTemplateHTML = fileContents;
                }
            }
            catch (Exception)
            {	
                // if error encountered -- build a simple html document that just has the image for embedding the chart
                this._reportOriginalTemplateHTML = string.Format("<html><body>{0}</body></html>", ChartImageKey);
            }
        }

        private string getTemplateWithData(IOrganizationChart chart, ITemporaryDocument tempDoc, string imageFileName, string imageFileNameAndPath)
        {
            // replace header template keys with values from IOrganizationchart
            const string underLineValue = "<span style=\"display: inline-block; width: 200px; border-bottom: 1px solid #000000;\"></span>";

            bool containsCity = !string.IsNullOrWhiteSpace(chart.OrgCode.MailCity);
            bool containsState = !string.IsNullOrWhiteSpace(chart.OrgCode.MailStateAbbr);
            string cityStateLine = string.Empty;

            if (containsCity && containsState)
                cityStateLine = string.Format(" - {0}, {1}", chart.OrgCode.MailCity, chart.OrgCode.MailStateAbbr);
            else if (containsCity)
                cityStateLine = string.Format(" - {0}", chart.OrgCode.MailCity);
            else if (containsState)
                cityStateLine = string.Format(" - {0}", chart.OrgCode.MailStateAbbr);

            string newHTML = this._reportOriginalTemplateHTML.
                            Replace(RegionNameKey, chart.OrgCode.Region).
                            Replace(ProgramNameKey, chart.OrgCode.Program).
                            Replace(OrganizationNameKey, chart.OrgCode.OrganizationName).
                            Replace(OrgCodeValueKey, chart.OrgCode.OrganizationCodeValue).
                            Replace(CityStateKey, cityStateLine);

            string finalHTML = string.Empty;

            if (chart is OrganizationChartLog)
            {
                // published chart
                OrganizationChartLog chartLog = (OrganizationChartLog)chart;
                string approvedByLine = string.IsNullOrWhiteSpace(chartLog.ApprovedFor) ?
                                        chartLog.ApprovedBy.FullName :
                                        string.Format("{0} (For {1})", chartLog.ApprovedBy.FullName, chartLog.ApprovedFor);

                finalHTML = newHTML.Replace(ApprovedNameKey, approvedByLine).
                                        Replace(ApprovedDateKey, chartLog.ApprovedBy.ActionDate.Value.ToShortDateString());
            }
            else
            {
                // in-process chart
                finalHTML = newHTML.Replace(ApprovedNameKey, underLineValue).
                                                Replace(ApprovedDateKey, underLineValue);
            }

            // now load chart image
            string imageHTML = string.Empty;
            using (MemoryStream ms = new MemoryStream(tempDoc.DocumentData))
            {
                using (Image chartImage = Image.FromStream(ms))
                {
                    // save image to generated directory
                    chartImage.Save(imageFileNameAndPath);

                    // replace image in html
                    imageHTML = string.Format("<img src=\"./Generated/{0}\" />", imageFileName);
                }
            }

            return finalHTML.Replace(ChartImageKey, imageHTML);
        }

        private void buildPDFDocument(IOrganizationChart chart, string templateHTML)
        {
            HtmlToPdfConverter pdfConverter = new HtmlToPdfConverter();
           
            pdfConverter.ClipHtmlView = false;

            pdfConverter.PdfDocumentOptions.EnhancedGraphicsQuality = true;
            pdfConverter.PdfDocumentOptions.ImagesScalingEnabled = false;
            pdfConverter.PdfDocumentOptions.JpegCompressionEnabled = false;  // no compression -- give me the full size image (will be larger in size, but will be the "clearest" in terms of clarity)
            pdfConverter.PdfDocumentOptions.JpegCompressionLevel = 0;   // no compression

            pdfConverter.PdfDocumentOptions.SinglePage = true;
            pdfConverter.PdfDocumentOptions.FitWidth = false;
            pdfConverter.PdfDocumentOptions.FitHeight = false;
            pdfConverter.PdfDocumentOptions.StretchToFit = false;
            pdfConverter.PdfDocumentOptions.AutoSizePdfPage = false;
            pdfConverter.PdfDocumentOptions.AvoidImageBreak = false;
            pdfConverter.PdfDocumentOptions.TopMargin = 5;
            pdfConverter.PdfDocumentOptions.RightMargin = 15;
            pdfConverter.PdfDocumentOptions.LeftMargin = 15;
            pdfConverter.PdfDocumentOptions.BottomMargin = 10;
            pdfConverter.PdfDocumentOptions.PdfPageOrientation = PdfPageOrientation.Landscape;
            pdfConverter.PdfDocumentOptions.AvoidTextBreak = true;
            pdfConverter.LicenseKey = EVOPDF_LicenseKey;

            // Use the current page URL as base URL
            string baseUrl = HttpContext.Current.Request.Url.AbsoluteUri;
            byte[] documentByteArray = pdfConverter.ConvertHtml(templateHTML, baseUrl);

            //-----------------------------------------------
            // Added to support opening with a zoom level of 100
            // If this isn't needed, all of the code below can be replaced with the one commented line above
            //Document pdfDocument = pdfConverter.ConvertHtmlToPdfDocumentObject(templateHTML, baseUrl);
            //PdfPage goToPage = pdfDocument.Pages[0];

            //PointF pointLocation = new PointF(10f, 10f);
            //ExplicitDestination zoomDestination = new ExplicitDestination(goToPage, pointLocation, DestinationViewMode.XYZ);
            //zoomDestination.ZoomPercentage = 100;

            //pdfDocument.OpenAction.Action = new PdfActionGoTo(zoomDestination);
            //byte[] documentByteArray = pdfDocument.Save();
            //-----------------------------------------------
            //-----------------------------------------------

            this._context.Response.AddHeader("Content-Type", "application/pdf");

            // Instruct the browser to open the PDF file as an attachment or inline
            this._context.Response.AddHeader("Content-Disposition", String.Format("attachment; filename=orgChart_{0}.pdf; size={1}",
                chart.OrgCode.OrganizationCodeValue, documentByteArray.Length.ToString()));

            // Write the PDF document buffer to HTTP response
            this._context.Response.BinaryWrite(documentByteArray);
        }

        private void deleteTemporaryFile(string imageFileAndPath)
        {
            try
            {
                // the temporary document stored in the database has already been deleted by this point
                // we are just deleting the physical rendering on disk
                File.Delete(imageFileAndPath);
            }
            catch (Exception)
            {	
                // do nothing -- we don't error out if the OS cannot delete the file
            }
        }
    }
}
