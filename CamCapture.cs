using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.IO;
using WebCam_Capture;

namespace Dentistry
{
    public partial class CamCapture : Form
    {
        private Image Image;
        private string imgPath;
        public string ImgPath
        {
            get
            {
                return this.imgPath;
            }
            set
            {
                this.imgPath = value;
            }
        }

        public CamCapture()
        {
            InitializeComponent();
            this.LoadCam();
        }

        private void buttonCapture_Click(object sender, EventArgs e)
        {
            try
		{
			this.cam.Stop();
			this.Image = this.pictureBox1.Image;
           
            EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
            EncoderParameters encoderParameters = new EncoderParameters(1);
            encoderParameters.Param[0] = encoderParameter;
            ImageCodecInfo encoderInfo = CamCapture.GetEncoderInfo("image/jpeg");

            this.Image.Save(string.Concat(Application.StartupPath, "\\Temp.jpeg"),encoderInfo , encoderParameters);
            this.ImgPath = string.Concat(Application.StartupPath, "\\Temp.jpeg");
			this.pictureBox1.Image = null;
			base.Close();
		}
		catch
		{
			MessageBox.Show(@"Capturing of image failed
            Please check if the camera is installed and functional!", "MediPAC+ D", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			base.Close();
		}
        }

        private void FormCamCapture_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.cam.Stop();
            this.cam.Dispose();
        }

        private void FormCamCapture_Load(object sender, EventArgs e)
        {
            this.cam.CaptureHeight = this.pictureBox1.Height;
            this.cam.CaptureWidth = this.pictureBox1.Width;
            this.cam.ImageCaptured += new WebCam_Capture.WebCamCapture.WebCamEventHandler(this.cam_ImageCaptured);
            this.LoadCam();
        }

        private void cam_ImageCaptured(object source, WebcamEventArgs e)
        {
            this.pictureBox1.Image = e.WebCamImage;
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            int num = 0;
            num++;
            while (num < (int)imageEncoders.Length)
            {
                if (imageEncoders[num].MimeType == mimeType)
                {
                    return imageEncoders[num];
                }
            }
            return null;
        }

        public void LoadCam()
	    {
		    try
		    {
			    if (this.cam.CheckCam((long)0))
			    {
				    this.cam.TimeToCapture_milliseconds = 20;
				    this.cam.Start((long)0);
				    this.buttonCapture.Focus();
			    }
			    else
			    {
                    this.buttonCapture.Enabled = false;
				    FarsiMessageBox.FMessageBox.Show(@"برنامه با شكست مواجه شد" + Environment.NewLine + "لطفا از صحت نصب دوربين بر روي سيستم اطمينان حاصل فرماييد", "خطا در اتصال" ,FarsiMessageBox.FMessageBoxButtons.OK,FarsiMessageBox.FMessageBoxIcons.Information);
				    base.Close();
			    }
		    }
		    catch
		    {
                FarsiMessageBox.FMessageBox.Show(@"برنامه با شكست مواجه شد" + Environment.NewLine + "لطفا از صحت نصب دوربين بر روي سيستم اطمينان حاصل فرماييد", "خطا در اتصال", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information);
                base.Close();
		    }
	    }
    }
}
