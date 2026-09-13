
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PopupControl;

namespace Dentistry.UserControls
{
    internal class MonthUC : UserControl
    {
        private IContainer components = null;

        private RadioButton radioButton1;

        private RadioButton radioButton2;

        private RadioButton radioButton3;

        private RadioButton radioButton4;

        private RadioButton radioButton5;

        private RadioButton radioButton6;

        private RadioButton radioButton7;

        private RadioButton radioButton8;

        private RadioButton radioButton9;

        private RadioButton radioButton10;

        private RadioButton radioButton11;

        private RadioButton radioButton12;

        public event EventHandler MonthChanged;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.radioButton5 = new System.Windows.Forms.RadioButton();
            this.radioButton6 = new System.Windows.Forms.RadioButton();
            this.radioButton7 = new System.Windows.Forms.RadioButton();
            this.radioButton8 = new System.Windows.Forms.RadioButton();
            this.radioButton9 = new System.Windows.Forms.RadioButton();
            this.radioButton10 = new System.Windows.Forms.RadioButton();
            this.radioButton11 = new System.Windows.Forms.RadioButton();
            this.radioButton12 = new System.Windows.Forms.RadioButton();
            base.SuspendLayout();
            this.radioButton1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton1.BackColor = System.Drawing.Color.White;
            this.radioButton1.ForeColor = System.Drawing.Color.Black;
            this.radioButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton1.Location = new System.Drawing.Point(6, 4);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(140, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.Tag = "1";
            this.radioButton1.Text = "فروردین";
            this.radioButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton1.UseVisualStyleBackColor = false;
            this.radioButton1.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton1.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton1.Click += new System.EventHandler(radioButton_Click);
            this.radioButton2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton2.BackColor = System.Drawing.Color.White;
            this.radioButton2.ForeColor = System.Drawing.Color.Black;
            this.radioButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton2.Location = new System.Drawing.Point(6, 29);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(140, 24);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.Tag = "2";
            this.radioButton2.Text = "اردیبهشت";
            this.radioButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton2.UseVisualStyleBackColor = false;
            this.radioButton2.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton2.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton2.Click += new System.EventHandler(radioButton_Click);
            this.radioButton3.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton3.BackColor = System.Drawing.Color.White;
            this.radioButton3.ForeColor = System.Drawing.Color.Black;
            this.radioButton3.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton3.Location = new System.Drawing.Point(6, 54);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(140, 24);
            this.radioButton3.TabIndex = 1;
            this.radioButton3.Tag = "3";
            this.radioButton3.Text = "خرداد";
            this.radioButton3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton3.UseVisualStyleBackColor = false;
            this.radioButton3.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton3.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton3.Click += new System.EventHandler(radioButton_Click);
            this.radioButton4.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton4.BackColor = System.Drawing.Color.White;
            this.radioButton4.ForeColor = System.Drawing.Color.Black;
            this.radioButton4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton4.Location = new System.Drawing.Point(6, 79);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(140, 24);
            this.radioButton4.TabIndex = 1;
            this.radioButton4.Tag = "4";
            this.radioButton4.Text = "تیر";
            this.radioButton4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton4.UseVisualStyleBackColor = false;
            this.radioButton4.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton4.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton4.Click += new System.EventHandler(radioButton_Click);
            this.radioButton5.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton5.BackColor = System.Drawing.Color.White;
            this.radioButton5.ForeColor = System.Drawing.Color.Black;
            this.radioButton5.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton5.Location = new System.Drawing.Point(6, 104);
            this.radioButton5.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton5.Name = "radioButton5";
            this.radioButton5.Size = new System.Drawing.Size(140, 24);
            this.radioButton5.TabIndex = 1;
            this.radioButton5.Tag = "5";
            this.radioButton5.Text = "مرداد";
            this.radioButton5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton5.UseVisualStyleBackColor = false;
            this.radioButton5.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton5.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton5.Click += new System.EventHandler(radioButton_Click);
            this.radioButton6.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton6.BackColor = System.Drawing.Color.White;
            this.radioButton6.ForeColor = System.Drawing.Color.Black;
            this.radioButton6.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton6.Location = new System.Drawing.Point(6, 129);
            this.radioButton6.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton6.Name = "radioButton6";
            this.radioButton6.Size = new System.Drawing.Size(140, 24);
            this.radioButton6.TabIndex = 1;
            this.radioButton6.Tag = "6";
            this.radioButton6.Text = "شهریور";
            this.radioButton6.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton6.UseVisualStyleBackColor = false;
            this.radioButton6.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton6.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton6.Click += new System.EventHandler(radioButton_Click);
            this.radioButton7.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton7.BackColor = System.Drawing.Color.White;
            this.radioButton7.ForeColor = System.Drawing.Color.Black;
            this.radioButton7.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton7.Location = new System.Drawing.Point(6, 155);
            this.radioButton7.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton7.Name = "radioButton7";
            this.radioButton7.Size = new System.Drawing.Size(140, 24);
            this.radioButton7.TabIndex = 1;
            this.radioButton7.Tag = "7";
            this.radioButton7.Text = "مهر";
            this.radioButton7.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton7.UseVisualStyleBackColor = false;
            this.radioButton7.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton7.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton7.Click += new System.EventHandler(radioButton_Click);
            this.radioButton8.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton8.BackColor = System.Drawing.Color.White;
            this.radioButton8.ForeColor = System.Drawing.Color.Black;
            this.radioButton8.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton8.Location = new System.Drawing.Point(6, 180);
            this.radioButton8.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton8.Name = "radioButton8";
            this.radioButton8.Size = new System.Drawing.Size(140, 24);
            this.radioButton8.TabIndex = 1;
            this.radioButton8.Tag = "8";
            this.radioButton8.Text = "آبان";
            this.radioButton8.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton8.UseVisualStyleBackColor = false;
            this.radioButton8.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton8.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton8.Click += new System.EventHandler(radioButton_Click);
            this.radioButton9.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton9.BackColor = System.Drawing.Color.White;
            this.radioButton9.Font = new System.Drawing.Font("Tahoma", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
            this.radioButton9.ForeColor = System.Drawing.Color.Black;
            this.radioButton9.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton9.Location = new System.Drawing.Point(6, 206);
            this.radioButton9.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton9.Name = "radioButton9";
            this.radioButton9.Size = new System.Drawing.Size(140, 24);
            this.radioButton9.TabIndex = 1;
            this.radioButton9.Tag = "9";
            this.radioButton9.Text = "آذر";
            this.radioButton9.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton9.UseVisualStyleBackColor = false;
            this.radioButton9.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton9.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton9.Click += new System.EventHandler(radioButton_Click);
            this.radioButton10.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton10.BackColor = System.Drawing.Color.White;
            this.radioButton10.ForeColor = System.Drawing.Color.Black;
            this.radioButton10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton10.Location = new System.Drawing.Point(6, 231);
            this.radioButton10.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton10.Name = "radioButton10";
            this.radioButton10.Size = new System.Drawing.Size(140, 24);
            this.radioButton10.TabIndex = 1;
            this.radioButton10.Tag = "10";
            this.radioButton10.Text = "دی";
            this.radioButton10.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton10.UseVisualStyleBackColor = false;
            this.radioButton10.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton10.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton10.Click += new System.EventHandler(radioButton_Click);
            this.radioButton11.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton11.BackColor = System.Drawing.Color.White;
            this.radioButton11.ForeColor = System.Drawing.Color.Black;
            this.radioButton11.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton11.Location = new System.Drawing.Point(6, 256);
            this.radioButton11.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton11.Name = "radioButton11";
            this.radioButton11.Size = new System.Drawing.Size(140, 24);
            this.radioButton11.TabIndex = 1;
            this.radioButton11.Tag = "11";
            this.radioButton11.Text = "بهمن";
            this.radioButton11.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton11.UseVisualStyleBackColor = false;
            this.radioButton11.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton11.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton11.Click += new System.EventHandler(radioButton_Click);
            this.radioButton12.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            this.radioButton12.BackColor = System.Drawing.Color.White;
            this.radioButton12.ForeColor = System.Drawing.Color.Black;
            this.radioButton12.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.radioButton12.Location = new System.Drawing.Point(6, 282);
            this.radioButton12.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton12.Name = "radioButton12";
            this.radioButton12.Size = new System.Drawing.Size(140, 24);
            this.radioButton12.TabIndex = 1;
            this.radioButton12.Tag = "12";
            this.radioButton12.Text = "اسفند";
            this.radioButton12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.radioButton12.UseVisualStyleBackColor = false;
            this.radioButton12.MouseLeave += new System.EventHandler(radioButton_MouseLeave);
            this.radioButton12.MouseEnter += new System.EventHandler(radioButton_MouseEnter);
            this.radioButton12.Click += new System.EventHandler(radioButton_Click);
            base.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            base.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            base.Controls.Add(this.radioButton12);
            base.Controls.Add(this.radioButton11);
            base.Controls.Add(this.radioButton10);
            base.Controls.Add(this.radioButton9);
            base.Controls.Add(this.radioButton8);
            base.Controls.Add(this.radioButton7);
            base.Controls.Add(this.radioButton6);
            base.Controls.Add(this.radioButton5);
            base.Controls.Add(this.radioButton4);
            base.Controls.Add(this.radioButton3);
            base.Controls.Add(this.radioButton2);
            base.Controls.Add(this.radioButton1);
            this.Font = new System.Drawing.Font("Vazir FD", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
            base.Name = "MonthUC";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            base.Size = new System.Drawing.Size(150, 310);
            base.ResumeLayout(false);
        }

        public MonthUC()
        {
            InitializeComponent();
        }

        private void radioButton_MouseEnter(object sender, EventArgs e)
        {
            RadioButton radioButton = sender as RadioButton;
            radioButton.ForeColor = Color.White;
            radioButton.BackColor = Color.RoyalBlue;
        }

        private void radioButton_MouseLeave(object sender, EventArgs e)
        {
            SetColors(sender as RadioButton);
        }

        private static void SetColors(RadioButton radioButton)
        {
            if (radioButton.Checked)
            {
                radioButton.ForeColor = Color.White;
                radioButton.BackColor = Color.RoyalBlue;
            }
            else
            {
                radioButton.ForeColor = Color.Black;
                radioButton.BackColor = Color.White;
            }
        }

        private void radioButton_Click(object sender, EventArgs e)
        {
            foreach (object control in base.Controls)
            {
                if (control is RadioButton)
                {
                    SetColors((RadioButton)control);
                }
            }
            if (this.MonthChanged != null)
            {
                this.MonthChanged(sender, EventArgs.Empty);
            }
            (base.Parent as Popup).Close();
        }

        public void ActiveRadioByTagID(int monthNo)
        {
            foreach (object control in base.Controls)
            {
                if (control is RadioButton && int.Parse(((RadioButton)control).Tag.ToString()) == monthNo)
                {
                    ((RadioButton)control).Checked = true;
                    SetColors((RadioButton)control);
                }
            }
        }
    }

}