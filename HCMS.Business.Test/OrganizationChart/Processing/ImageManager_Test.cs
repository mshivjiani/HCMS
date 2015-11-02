using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;
using System.Drawing.Imaging;
using HCMS.Business.OrganizationChart.Processing;

namespace HCMS.Business.Test.OrganizationChart.Processing
{
    [TestClass]
    public class ImageManager_Test
    {
        [TestMethod]
        public void CropAlpha_HashImplementation()
        {
            using (Image chartImage = Image.FromFile(@"C:\NTC Projects\HCMS\Solution\HCMS.Web Application\HCMS.Business.Test\OrganizationChart\Processing\Generated\testImageA.png"))
            {
                 // PixelFormat selectedPixelFormat = PixelFormat.Format32bppArgb;
                 PixelFormat selectedPixelFormat = PixelFormat.Format16bppArgb1555;

                 Bitmap bmp = new Bitmap(chartImage);

                // lower the format -- lowers the size and memory consumption
                using (Bitmap loweredBMP = new Bitmap(bmp).Clone(new Rectangle(0, 0, bmp.Width, bmp.Height), selectedPixelFormat))
                {
                    Rectangle cropZone = default(Rectangle);

                    using (Bitmap trimmedBMP = ImageManager.CropWhiteSpaceAlpha_HashImplementation(loweredBMP, selectedPixelFormat))
                    {
                        Assert.IsNotNull(trimmedBMP, "Trimmed BMP is null");
                        trimmedBMP.Save(@"C:\NTC Projects\HCMS\Solution\HCMS.Web Application\HCMS.Business.Test\OrganizationChart\Processing\Generated\trimmedBMP.png");
                    }
                }
            }
        }

        [TestMethod]
        public void CropWhitespaceAndAlpha()
        {
            Console.WriteLine(string.Format("1. GC.TotalMemory: {0}", GC.GetTotalMemory(false)));
            

            using (Image chartImage = Image.FromFile(@"C:\NTC Projects\HCMS\Solution\HCMS.Web Application\HCMS.Business.Test\OrganizationChart\Processing\Generated\testImage_Format32bppArgb.png"))
            {
                PixelFormat selectedPixelFormat = PixelFormat.Format32bppArgb;
                // PixelFormat selectedPixelFormat = PixelFormat.Format16bppArgb1555;

                Bitmap bmp = new Bitmap(chartImage);

                using (Bitmap trimmedBMP = ImageManager.CropWhitespaceAndAlpha(bmp, selectedPixelFormat))
                {
                    Console.WriteLine(string.Format("2. GC.TotalMemory: {0}", GC.GetTotalMemory(false)));

                    Assert.IsNotNull(trimmedBMP, "Trimmed BMP is null");
                    trimmedBMP.Save(@"C:\NTC Projects\HCMS\Solution\HCMS.Web Application\HCMS.Business.Test\OrganizationChart\Processing\Generated\trimmedBMP.png");
                }

                GC.Collect();
                Console.WriteLine(string.Format("FINAL GC.TotalMemory: {0}", GC.GetTotalMemory(false)));
            }
        }
    }
}
