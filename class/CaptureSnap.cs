using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Dentistry
{
    internal class CaptureSnap
    {
        public static string imageFileName;

        static CaptureSnap()
        {
            CaptureSnap.imageFileName = "";
        }

        public CaptureSnap()
        {
        }

        public static Bitmap ResizeImage(string str, Size newSize)
        {
            Bitmap bitmap = new Bitmap(str);
            bitmap = (Bitmap)bitmap.GetThumbnailImage(newSize.Width, newSize.Height, new System.Drawing.Image.GetThumbnailImageAbort(CaptureSnap.ThumbnailCallback), IntPtr.Zero);
            return bitmap;
        }

        private static bool ThumbnailCallback()
        {
            return true;
        }
    }

}
