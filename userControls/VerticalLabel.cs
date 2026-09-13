using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Dentistry.Class
{
    public partial class VerticalLabel : System.Windows.Forms.Label
    {

        #region Variables

        private double rotationAngle;
        private string text;


        #endregion


        #region Properties

        [Description("Rotation Angle"), Category("Appearance")]
        public double RotationAngle
        {
            get
            {
                return rotationAngle;
            }
            set
            {
                rotationAngle = value;
                this.Invalidate();
            }
        }

        [Description("Display Text"), Category("Appearance")]
        public override string Text
        {
            get
            {
                return text;
            }
            set
            {
                text = value;
                this.Invalidate();
            }
        }

        #endregion

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics graphics = e.Graphics;

            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment = StringAlignment.Center;
            stringFormat.Trimming = StringTrimming.None;

            Brush textBrush = new SolidBrush(this.ForeColor);

            //Getting the width and height of the text, which we are going to write
            float width = graphics.MeasureString(text, this.Font).Width;
            float height = graphics.MeasureString(text, this.Font).Height;

            //The radius is set to 0.9 of the width or height, b'cos not to
            //hide and part of the text at any stage
            float radius = 0f;
            if (ClientRectangle.Width < ClientRectangle.Height)
            {
                radius = ClientRectangle.Width * 0.9f / 2;
            }
            else
            {
                radius = ClientRectangle.Height * 0.9f / 2;
            }

            //Setting the text according to the selection
            double angle = (rotationAngle / 180) * Math.PI;
            graphics.TranslateTransform(
                (ClientRectangle.Width + (float)(height * Math.Sin(angle)) - (float)(width * Math.Cos(angle))) / 2,
                (ClientRectangle.Height - (float)(height * Math.Cos(angle)) - (float)(width * Math.Sin(angle))) / 2);
            graphics.RotateTransform((float)rotationAngle);
            graphics.DrawString(text, this.Font, textBrush, 0, 0);
            graphics.ResetTransform();
        }
    }
}
