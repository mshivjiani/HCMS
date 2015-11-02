using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Security.Cryptography;

namespace HCMS.Business.OrganizationChart.Processing
{
    public static class ImageManager
    {
        private static string yWhiteSpaceHashValue = string.Empty;
        private static string xWhiteSpaceHashValue = string.Empty;

        private enum YParseDirection : int
        {
            TopDown = 1,
            BottomUp = 2
        }

        private enum XParseDirection : int
        {
            LeftRight = 1,
            RightLeft = 2
        }

        public static byte[] ConvertToByteArray(Image img, ImageFormat selectedImageFormat)
        {
            byte[] byteArray = null;

            using (MemoryStream stream = new MemoryStream())
            {
                img.Save(stream, selectedImageFormat);
                stream.Close();

                byteArray = stream.ToArray();
            }

            return byteArray;
        }

        private static int getBytesPerPixel(PixelFormat selectedPixelFormat)
        {
            int byteValue = 4;

            switch (selectedPixelFormat)
            {
                case PixelFormat.Format16bppArgb1555:
                case PixelFormat.Format16bppGrayScale:
                case PixelFormat.Format16bppRgb555:
                case PixelFormat.Format16bppRgb565:
                    byteValue = 2;
                    break;
                case PixelFormat.Format32bppArgb:
                case PixelFormat.Format32bppPArgb:
                case PixelFormat.Format32bppRgb:
                    byteValue = 4;
                    break;
                default:
                    throw new NotImplementedException(string.Format("PixelFormat {0} is not supported.", selectedPixelFormat));
                    break;
            }

            return byteValue;
        }

        private static string hashByteArrayToString(byte[] arrInput)
        {
            StringBuilder sOutput = new StringBuilder(arrInput.Length);

            for (int i = 0; i < arrInput.Length; i++)
                sOutput.Append(arrInput[i].ToString("X2"));
            
            return sOutput.ToString();
        }

        private static string computeHash(byte[] lineBuffer)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] hash = md5.ComputeHash(lineBuffer);
            return hashByteArrayToString(lineBuffer);

            // return Convert.ToBase64String(lineBuffer);
        }

        private static string getHashRow(Bitmap source, PixelFormat selectedPixelFormat, int yCounter)
        {
            // copy 1 line of data
            BitmapData data = source.LockBits(new Rectangle(0, yCounter, source.Width, 1), ImageLockMode.ReadOnly, selectedPixelFormat);
            byte[] lineBuffer = new byte[data.Stride];

            // copy to line buffer
            Marshal.Copy(data.Scan0, lineBuffer, 0, lineBuffer.Length);

            // get hash of single line buffer
            string hashValue = computeHash(lineBuffer);

            // unlock bits
            if (data != null)
                source.UnlockBits(data);

            return hashValue;
        }

        private static string getHashColumn(Bitmap source, PixelFormat selectedPixelFormat, int xCounter)
        {
            // copy 1 line of data
            BitmapData data = source.LockBits(new Rectangle(xCounter, 0, 1, source.Height), ImageLockMode.ReadOnly, selectedPixelFormat);
            byte[] lineBuffer = new byte[data.Stride];

            // copy to line buffer
            Marshal.Copy(data.Scan0, lineBuffer, 0, lineBuffer.Length);

            // get hash of single line buffer
            string hashValue = computeHash(lineBuffer);

            // unlock bits
            if (data != null)
                source.UnlockBits(data);

            return hashValue;
        }

        private static int parseYImage(Bitmap source, PixelFormat selectedPixelFormat, YParseDirection direction)
        {
            int yCounter = (direction == YParseDirection.TopDown) ? 0 : (source.Height - 1);
            int yEndPoint = (direction == YParseDirection.TopDown) ? source.Height : 0;
            int yWork = yCounter;

            // worse case scenario: O(4)
            while ((direction == YParseDirection.TopDown && yCounter < yEndPoint) || (direction == YParseDirection.BottomUp && yCounter > yEndPoint))
            {
                string hashValue = getHashRow(source, selectedPixelFormat, yCounter);

                if (hashValue != yWhiteSpaceHashValue)
                {
                    // set yWork and break out of loop -- no need to finish
                    yWork = yCounter;
                    break;
                }

                if (direction == YParseDirection.TopDown)
                    yCounter++;
                else
                    yCounter--;
            }

            return yWork;
        }

        private static int parseXImage(Bitmap source, PixelFormat selectedPixelFormat, XParseDirection direction)
        {
            int xCounter = (direction == XParseDirection.LeftRight) ? 0 : (source.Width - 1);
            int xEndPoint = (direction == XParseDirection.LeftRight) ? source.Width : 0;
            int xWork = xCounter;

            // worse case scenario: O(4)
            while ((direction == XParseDirection.LeftRight && xCounter < xEndPoint) || (direction == XParseDirection.RightLeft && xCounter > xEndPoint))
            {
                string hashValue = getHashColumn(source, selectedPixelFormat, xCounter);

                if (hashValue != xWhiteSpaceHashValue)
                {
                    // set xwork and break out of loop -- no need to finish
                    xWork = xCounter;
                    break;
                }

                if (direction == XParseDirection.LeftRight)
                    xCounter++;
                else
                    xCounter--;
            }

            return xWork;
        }

        public static Bitmap CropWhiteSpaceAlpha_HashImplementation(Bitmap source, PixelFormat selectedPixelFormat)
        {
            // Algorithm:  Given the known size and the known color of the background, we should be able to 
            // take the hash of a single line (from index 0 to max width) and see if it equals a known hash value
            Bitmap returnBMP = source;

            // get first row hash as baseline
            // ASSUMPTION: This assumes there is at least a one padding pixel at the top of the chart
            // this is the baseline hash -- we have a padding on the chart
            // so we pull the hash from the first row
            yWhiteSpaceHashValue = getHashRow(source, selectedPixelFormat, 0);
            int yTop = parseYImage(source, selectedPixelFormat, YParseDirection.TopDown);
            bool isEmptyImage = (yTop == source.Height);

            if (!isEmptyImage)
            {
                xWhiteSpaceHashValue = getHashColumn(source, selectedPixelFormat, 0);
                int yBottom = parseYImage(source, selectedPixelFormat, YParseDirection.BottomUp);
                int xLeft = parseXImage(source, selectedPixelFormat, XParseDirection.LeftRight);
                int xRight = parseXImage(source, selectedPixelFormat, XParseDirection.RightLeft);

                Rectangle cropZone = Rectangle.FromLTRB(xLeft, yTop, xRight, yBottom);
                returnBMP = source.Clone(cropZone, selectedPixelFormat);
            }

            return returnBMP;
        }

        public static Bitmap CropWhitespaceAndAlpha(Bitmap source, PixelFormat selectedPixelFormat)
        {
            int BYTESPERPIXEL = getBytesPerPixel(selectedPixelFormat);
            Rectangle srcRect = default(Rectangle);
            BitmapData data = null;

            try
            {
                data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, selectedPixelFormat);
                byte[] buffer = new byte[data.Height * data.Stride];
                Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
                
                int xMin = int.MaxValue;
                int xMax = 0;
                int yMin = int.MaxValue;
                int yMax = 0;

                // worst case scenario: O^2 (squared)
                for (int y = 0; y < data.Height; y++)
                {
                    for (int x = 0; x < data.Width; x++)
                    {
                        byte alpha = buffer[y * data.Stride + BYTESPERPIXEL * x + 3];
                        if (alpha != 0)
                        {
                            if (x < xMin) xMin = x;
                            if (x > xMax) xMax = x;
                            if (y < yMin) yMin = y;
                            if (y > yMax) yMax = y;
                        }
                    }
                }
                if (xMax < xMin || yMax < yMin)
                {
                    // Image is empty...
                    return null;
                }

                int calcXMax = xMax + 5;
                int calcYMax = yMax + 5;

                srcRect = Rectangle.FromLTRB(xMin, yMin, 
                            calcXMax > data.Width ? data.Width : calcXMax, 
                            calcYMax > data.Height ? data.Height : calcYMax);
            }
            finally
            {
                if (data != null)
                    source.UnlockBits(data);
            }

            return source.Clone(srcRect, selectedPixelFormat);
        }

        //////public static Bitmap CropWhitespaceAndAlpha(Bitmap source)
        //////{
        //////    Rectangle srcRect = default(Rectangle);
        //////    BitmapData data = null;

        //////    try
        //////    {
        //////        data = source.LockBits(new Rectangle(0, 0, source.Width, source.Height), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
        //////        byte[] buffer = new byte[data.Height * data.Stride];
        //////        Marshal.Copy(data.Scan0, buffer, 0, buffer.Length);
        //////        int xMin = int.MaxValue;
        //////        int xMax = 0;
        //////        int yMin = int.MaxValue;
        //////        int yMax = 0;
        //////        for (int y = 0; y < data.Height; y++)
        //////        {
        //////            for (int x = 0; x < data.Width; x++)
        //////            {
        //////                byte alpha = buffer[y * data.Stride + 4 * x + 3];
        //////                if (alpha != 0)
        //////                {
        //////                    if (x < xMin) xMin = x;
        //////                    if (x > xMax) xMax = x;
        //////                    if (y < yMin) yMin = y;
        //////                    if (y > yMax) yMax = y;
        //////                }
        //////            }
        //////        }
        //////        if (xMax < xMin || yMax < yMin)
        //////        {
        //////            // Image is empty...
        //////            return null;
        //////        }

        //////        int calcXMax = xMax + 5;
        //////        int calcYMax = yMax + 5;

        //////        srcRect = Rectangle.FromLTRB(xMin, yMin,
        //////                    calcXMax > data.Width ? data.Width : calcXMax,
        //////                    calcYMax > data.Height ? data.Height : calcYMax);
        //////    }
        //////    finally
        //////    {
        //////        if (data != null)
        //////            source.UnlockBits(data);
        //////    }

        //////    //Bitmap dest = new Bitmap(srcRect.Width, srcRect.Height);
        //////    //Rectangle destRect = new Rectangle(0, 0, srcRect.Width, srcRect.Height);
        //////    //using (Graphics graphics = Graphics.FromImage(dest))
        //////    //{
        //////    //    graphics.DrawImage(source, destRect, srcRect, GraphicsUnit.Pixel);
        //////    //}
        //////    //return dest;

        //////    return source.Clone(srcRect, PixelFormat.Format32bppArgb);
        //////}
    }
}
