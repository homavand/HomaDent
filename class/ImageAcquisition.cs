using System;
using System.Collections.Generic;
using System.Text;

namespace Dentistry

{
    public class ImageAcquisition
    {
        private WIALib.WiaClass WiaClass;
        private WIALib.ItemClass ItemClass;
        private WIALib.CollectionClass CollectionClassDevices;
        private WIALib.CollectionClass CollectionClassPics;


        #region SelectDevice
        public bool SelectDevice()
        {
            try
            {
                object selectUsingUI;

                WiaClass = new WIALib.WiaClass();
                CollectionClassDevices = (WIALib.CollectionClass)WiaClass.Devices;

                if (WiaClass.Devices.Count == 0)
                    return false;

                selectUsingUI = System.Reflection.Missing.Value;

                ItemClass = (WIALib.ItemClass)WiaClass.Create(ref selectUsingUI);

                if (ItemClass == null)
                    return false;

                return true;
            }
            catch (System.Exception exp)
            {
                return false;
            }
        }
        #endregion

        #region Capture
        public System.Drawing.Image Capture()
        {
            try
            {
                CollectionClassPics = ItemClass.GetItemsFromUI(WIALib.WiaFlag.SingleImage, WIALib.WiaIntent.ImageTypeColor) as WIALib.CollectionClass;
                if (CollectionClassPics == null)
                    return null;

                ItemClass = (WIALib.ItemClass)System.Runtime.InteropServices.Marshal.CreateWrapperOfType(CollectionClassPics[0], typeof(WIALib.ItemClass));
                string imageFileName = System.IO.Path.GetTempFileName();
                ItemClass.Transfer(imageFileName, false);
                System.Drawing.Image Image = System.Drawing.Image.FromFile(imageFileName);

                System.Runtime.InteropServices.Marshal.ReleaseComObject(CollectionClassPics[0]);
                return Image;
            }
            catch (System.Exception exp)
            {
                return null;
            }
        }
        #endregion
    }
}
