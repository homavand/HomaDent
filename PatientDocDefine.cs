using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarsiMessageBox;
using System.IO;
using System.Data.SqlClient;
using System.Drawing.Imaging;
using System.Globalization;
using System.Dynamic;
using System.Linq;

namespace Dentistry
{
    public partial class PatientDocDefine : Form
    {
        int PatientId = 0;
        int PatientDocId = 0;
        string PatientName = "";
        string EditOrNewFlag = string.Empty;

        public PatientDocDefine(int patientId, string patientName)
        {
            InitializeComponent();

            this.EditOrNewFlag = "New";
            this.PatientId = patientId;
            this.PatientName = patientName;
            this.ComboDate.Value = (Dentistry.UserControls.PersianDate)DateTime.Now;
        }

        public PatientDocDefine(int patientDocId,int patientId, string patientName)
        {
            InitializeComponent();

            
            this.EditOrNewFlag = "Edit";
            this.PatientId=patientId;
            this.PatientName = patientName;
            this.PatientDocId = patientDocId;
            
        }

        private void PatientDocDefine_Load(object sender, EventArgs e)
        {

            PatientNameLbl.Text = this.PatientName;

            if (this.EditOrNewFlag == "Edit")
            {
                try
                {
                    System.Drawing.Image Image = null;

                    dynamic sObj = new System.Dynamic.ExpandoObject();
                    sObj.DocId = this.PatientDocId != 0 ? this.PatientDocId : (int?)null;

                    var data = Dentistry.DataProvider.GetPatientDocsX(sObj);
                    IEnumerable<dynamic> list = data != null && data.Data != null && (Enumerable.Count(data.Data) > 0) ? (data.Data as IEnumerable<dynamic>).Select(i => i).ToList() : null;
                    dynamic obj = list != null ? list.FirstOrDefault() : null;

                    if (obj != null)
                    {                        
                        this.textBoxDocName.Text = Convert.ToString(obj.Title);
                        this.textBoxComment.Text = Convert.ToString(obj.Comment);
                        this.pictureBox.ImageLocation = Convert.ToString(obj.ImagePath);

                        this.ComboDate.Value = (DateTime)obj.Date;

                        if (obj.Image == null)
                            FMessageBox.Show("فایل شما از رسانه ی ذخیره سازی حذف شده", Dentistry.AppConfigs.strCaptionInformation, FMessageBoxButtons.OK, FMessageBoxIcons.Question);
                        else
                        {
                            byte[] RegistrationImage = (byte[])obj.Image;
                            MemoryStream memoryStream = new MemoryStream(RegistrationImage);
                            Image = Image.FromStream(memoryStream);
                            memoryStream.Close();
                            this.pictureBox.ImageLocation = string.Empty;
                            this.pictureBox.Image = (Image)Image;
                        }
                    }

                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message.ToString());
                    this.Close();
                }
            }
         
        }


        #region linkLabelReadFromFile_LinkClicked
        private void linkLabelReadFromFile_LinkClicked(object sender, EventArgs e)
        {
           
            openFileDialog1.AddExtension = true;
            openFileDialog1.Filter = "Image Files(*.bmp;*.jpg;*.gif;*.png;*.tif)|*.bmp;*.jpg;*.gif;*.png;*.tif";
      
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                Size size = new Size(185, 159);
                Bitmap bitmap =  CaptureSnap.ResizeImage(Convert.ToString(openFileDialog1.FileName), size);

                
                this.pictureBox.Image = bitmap;
                this.pictureBox.ImageLocation = openFileDialog1.FileName;
            }
            openFileDialog1.Dispose();
        }
        #endregion

        #region linkLabelReadFromScanner_LinkClicked
        private void linkLabelReadFromScanner_LinkClicked(object sender, EventArgs e)
        {
            try
            {
                ImageAcquisition ImageAcquisition = new ImageAcquisition();

                if (ImageAcquisition.SelectDevice() == true)
                {
                    if (ImageAcquisition.Capture() != null)
                    {
                        this.pictureBox.Image = ImageAcquisition.Capture();

                        int NewWidth = ImageAcquisition.Capture().Width;

                        int NewHeight = ImageAcquisition.Capture().Height;

                        System.Drawing.Bitmap bmpOut = new System.Drawing.Bitmap(NewWidth, NewHeight);

                        System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmpOut);

                        g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

                        g.FillRectangle(System.Drawing.Brushes.White, 0, 0, NewWidth, NewHeight);

                        g.DrawImage(new System.Drawing.Bitmap(ImageAcquisition.Capture()), 0, 0, NewWidth, NewHeight);

                        String saveImagePath = Application.StartupPath + @"\Images\Thumbnail\1.jpg";

                        bmpOut.Save(saveImagePath);

                        this.pictureBox.ImageLocation = saveImagePath;
                    }
                    else
                    {
                        FMessageBox.Show("موردی اسکن نشده است", Dentistry.AppConfigs.strErrorCaption, FMessageBoxButtons.OK);
                    }
                }
                else
                {
                    FMessageBox.Show("فعال سازی اسکنر دچار اشکال گردیده است", Dentistry.AppConfigs.strErrorCaption, FMessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                FMessageBox.Show(ex.Message, Dentistry.AppConfigs.strErrorCaption, FMessageBoxButtons.OK);
            }



         
            //switch (fupProduct.FileName.Substring(fupProduct.FileName.IndexOf('.') + 1).ToLower())
            //{
            //    case "jpg":
            //        bmpOut.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //        break;
            //    case "jpeg":
            //        bmpOut.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //        break;
            //    case "tiff":
            //        bmpOut.Save(stream, System.Drawing.Imaging.ImageFormat.Tiff);
            //        break;
            //    case "png":
            //        bmpOut.Save(stream, System.Drawing.Imaging.ImageFormat.Png);
            //        break;
            //    case "gif":
            //        bmpOut.Save(stream, System.Drawing.Imaging.ImageFormat.Gif);
            //        break;
            //}

            //String saveImagePath = Application.StartupPath + "/Images/Thumbnail/" + fupProduct.FileName.Substring(fupProduct.FileName.IndexOf('.'));
        }
        #endregion

        #region buttonOk_Click
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (this.pictureBox.Image == null)
            {
                FMessageBox.Show("عکسی جهت ذخیره سازی انتخاب نشده است", Dentistry.AppConfigs.strErrorCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Question);
                return;
            }

            if (!this.ValidateForm())
            {
                FMessageBox.Show("اطلاعات ضروری کامل وارد نشده است", Dentistry.AppConfigs.strErrorCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Question);
                return;
            }
              

            try
            {
                
                Bitmap bitmap = new Bitmap(pictureBox.Image);
                Graphics g = Graphics.FromImage(bitmap);
                
                MemoryStream memoryStream = new MemoryStream();
                pictureBox.Image.Save(memoryStream , pictureBox.Image.RawFormat);
                byte[] RegisterationImage = memoryStream.GetBuffer();

                //version 2
                if (pictureBox.ImageLocation != "")
                    AdddocName(pictureBox.ImageLocation, "(" + this.PatientId + ")" + " - " + textBoxDocName.Text);

                dynamic iObj = new ExpandoObject();
                iObj.PatientId = this.PatientId; 
                iObj.Date = Class.Date.ToChristianByTime(this.ComboDate.Value.ToString()); 
                iObj.Title = this.textBoxDocName.Text.Trim(); 
                iObj.ImagePath = this.pictureBox.ImageLocation; 
                iObj.Image = RegisterationImage;               
                iObj.Comment = this.textBoxComment.Text.Trim().ToString();
                iObj.IsDeleted = false;

                if (this.EditOrNewFlag == "New")
                {
                }
                else if (this.EditOrNewFlag == "Edit")
                {
                    iObj.DocId = this.PatientDocId;
                }

                JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientDocumentX(iObj);

                if (result != null && result.Success == true && result.Data != null)
                {
                    this.DialogResult = DialogResult.OK;
                }
           

                this.Close();

            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }
        #endregion

        public void AdddocName(string pPath, string docName)
        {
            Image image = Image.FromFile(pPath);
            Bitmap bmp = new Bitmap(image);
            bmp.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            ImageCodecInfo iciJpegCodec = null;
            //find the correct Codec and specify its quality
            EncoderParameter epQuality = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            // Get all image codecs that are available
            ImageCodecInfo[] iciCodecs = ImageCodecInfo.GetImageEncoders();
            // Store the quality parameter in the list of encoder parameters
            EncoderParameters epParameters = new EncoderParameters(1);
            epParameters.Param[0] = epQuality;
            // Loop through all the image codecs
            for (int i = 0; i < iciCodecs.Length; i++)
            {
                // Until the one that we are interested in is found, which is image/jpeg
                if (iciCodecs[i].MimeType == "image/jpeg")
                {
                    iciJpegCodec = iciCodecs[i];
                    break;
                }
            }

            using (Graphics gr = Graphics.FromImage(bmp))
            { 
                StringFormat sf = new StringFormat();
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;

                gr.DrawImage(image, new Rectangle(0, 0, bmp.Width, bmp.Height),new Rectangle(0, 0, bmp.Width, bmp.Height+20),GraphicsUnit.Pixel);
                Rectangle rec = new Rectangle(0, bmp.Height - 20, bmp.Width, 20);
                gr.FillRectangle(new SolidBrush(Color.White),rec);
                gr.DrawString(docName, new Font("Tahoma", 9), Brushes.Black, rec, sf);
            }

    
  


            bmp.Save(pPath + "test", iciJpegCodec, epParameters);
            bmp.Dispose();
        }    

        #region buttonCancel_Click
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ValidateForm
        private bool ValidateForm()
        {
            bool Flag = true;

            if (string.IsNullOrEmpty(this.ComboDate.Text) )
            {
                this.Error_textBoxDate.Visible = true;
                Flag = false;
            }
            else
                this.Error_textBoxDate.Visible = false;

            if (this.textBoxDocName.Text == string.Empty)
            {
                this.Error_textBoxDocName.Visible = true;
                Flag = false;
            }
            else
                this.Error_textBoxDocName.Visible = false;


            return Flag;
        }


        #endregion

        #region AdjustBrightness
        public static Bitmap AdjustBrightness(Bitmap Image, int Value)
        {
            System.Drawing.Bitmap TempBitmap = Image;
            float FinalValue = (float)Value / 255.0f;
            System.Drawing.Bitmap NewBitmap = new System.Drawing.Bitmap(TempBitmap.Width, TempBitmap.Height);
            System.Drawing.Graphics NewGraphics = System.Drawing.Graphics.FromImage(NewBitmap);
            float[][] FloatColorMatrix ={
                     new float[] {1, 0, 0, 0, 0},
                     new float[] {0, 1, 0, 0, 0},
                     new float[] {0, 0, 1, 0, 0},
                     new float[] {0, 0, 0, 1, 0},
                     new float[] {FinalValue, FinalValue, FinalValue, 1, 1}
                 };

            System.Drawing.Imaging.ColorMatrix NewColorMatrix = new System.Drawing.Imaging.ColorMatrix(FloatColorMatrix);
            System.Drawing.Imaging.ImageAttributes Attributes = new System.Drawing.Imaging.ImageAttributes();
            Attributes.SetColorMatrix(NewColorMatrix);
            NewGraphics.DrawImage(TempBitmap, new System.Drawing.Rectangle(0, 0, TempBitmap.Width, TempBitmap.Height), 0, 0, TempBitmap.Width, TempBitmap.Height, System.Drawing.GraphicsUnit.Pixel, Attributes);
            Attributes.Dispose();
            NewGraphics.Dispose();
            return NewBitmap;
        }
        #endregion

        #region linkLabelWebcam_Click
        private void linkLabelWebcam_Click(object sender, EventArgs e)
        {
            Image img = this.pictureBox.Image;
            this.pictureBox.Image = null;
            CamCapture formCamCapture = new CamCapture();
            formCamCapture.ShowDialog(this);
            this.pictureBox.ImageLocation = formCamCapture.ImgPath;
            if (this.pictureBox.Image == null)
            {
                this.pictureBox.Image = img;
            }
        }
        #endregion

       
    }
}
