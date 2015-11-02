using System;
using System.ComponentModel;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

using HCMS.Business.OrganizationChart.Processing;
using HCMS.WebFramework.Site.Sessions;
using HCMS.WebFramework.Base.WebServices;
using System.Drawing.Imaging;
using HCMS.WebFramework.Site.Utilities;

namespace HCMS.OrgChart.Processing
{
    /// <summary>
    /// Summary description for ImageProcessor
    /// *
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    [ToolboxItem(false)]
    public class ImageProcessor : WebServiceBase
    {
        /// <summary>
        /// This method handles the uploading of the snapshot of the chart that was converted to an image by html2canvas.
        /// This image is stored in the database (alternative to file system storage).
        /// </summary>
        /// <param name="imageData"></param>
        [WebMethod(EnableSession=true)]
        public void Upload(int chartID, int type, string imageData)
        {
            try
            {
                // base.LogExceptionOnly(Session["CurrentUserID"] == null ? "IMAGEPROCESSOR SERVICE -- SESSION IS NULL" : string.Format("IMAGEPROCESSOR SERVICE -- SESSION == {0}", Session["CurrentUserID"]));
                int currentUserID = UserSessionWrapper.CurrentUserID;
                
                if (currentUserID == -1)
                    throw new Exception("App Timeout");
                else
                {
                    // we only check to see if it is "In Process" and if it is not -- default to published
                    OrganizationChartTypeViews selectedChartView = (type == (int)OrganizationChartTypeViews.InProcess) ? OrganizationChartTypeViews.InProcess : OrganizationChartTypeViews.Published;

                    byte[] imageByteData = Convert.FromBase64String(imageData);          // convert from base64
                    using (MemoryStream ms = new MemoryStream(imageByteData))
                    {
                        //////------------------------------------------------------------------------------
                        ////// FOR TESTING PURPOSES ONLY: Temporarily save image for offline review
                        ////using (Image chartImage = Image.FromStream(ms))
                        ////{
                        ////    // save image to generated directory
                        ////    chartImage.Save(@"C:\HCMS\HCMS.OrgChart\Processing\Generated\" + string.Format("testImage_{0}_{1}_{2}.png", chartImage.Width, chartImage.Height, chartImage.PixelFormat.ToString()));
                        ////}
                        //////------------------------------------------------------------------------------

                        using (Bitmap bmp = new Bitmap(ms))
                        {
                            PixelFormat selectedPixelFormat = PixelFormat.Format32bppArgb;

                            using (Bitmap trimmedBMP = ImageManager.CropWhitespaceAndAlpha(bmp, selectedPixelFormat))
                            {
                                byte[] trimmedByteData = ImageManager.ConvertToByteArray(trimmedBMP, ImageFormat.Png);

                                // store in database -- cleaner than file system
                                // allows it to work in load-balanced environments with no issues
                                TemporaryDocument newDocument = new TemporaryDocument()
                                {
                                    UserID = currentUserID,
                                    DocumentData = trimmedByteData
                                };

                                Guid newGuidValue = TemporaryDocumentRepository.Instance.Save(newDocument);
                                ChartGenerationParametersSessionWrapper.Parameters = new ChartGenerationParameters()
                                {
                                    ID = chartID,
                                    ChartType = selectedChartView,
                                    DocumentID = newGuidValue
                                };
                            }
                        }
                    }

                    // Normally, we would allow garbage collection to happen as dictated by the sytem
                    // We need to call it now due to the vast amount of memory used in the previous operation
                    // Test and monitor the following
                    GC.Collect();
                }
            }
            catch (Exception ex)
            {
                if (!(ex is ThreadAbortException))
                {
                    if (ex is OutOfMemoryException)
                        throw new Exception("MemoryException");
                    else
                    {
                        if (ex.Message == "App Timeout")
                            throw ex;
                        else
                        {
                            if (ex.InnerException == null)
                                base.LogExceptionOnly(ex);
                            else
                                base.LogExceptionOnly(ex.InnerException);

                            // throw new Exception("We've encountered an error while processing your request.  Please contact the system administrator.");
                            throw;
                        }
                    }
                }
            }
        }
    }
}
