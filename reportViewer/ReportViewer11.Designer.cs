namespace Dentistry
{
    partial class ReportViewer11
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelDetails = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.MinDate = new Dentistry.UserControls.PersianDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxDate = new Dentistry.UserControls.PersianDateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReportPnl = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panelDetails.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.White;
            this.panelDetails.Controls.Add(this.buttonOK);
            this.panelDetails.Controls.Add(this.label4);
            this.panelDetails.Controls.Add(this.MinDate);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.MaxDate);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(800, 64);
            this.panelDetails.TabIndex = 4;
            this.panelDetails.Tag = "2";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label4.Location = new System.Drawing.Point(730, 23);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 83;
            this.label4.Text = "از تاریخ :";
            // 
            // MinDate
            // 
            this.MinDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinDate.BackColor = System.Drawing.Color.White;
            this.MinDate.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.MinDate.Location = new System.Drawing.Point(561, 20);
            this.MinDate.Name = "MinDate";
            this.MinDate.ShowTime = false;
            this.MinDate.Size = new System.Drawing.Size(167, 25);
            this.MinDate.TabIndex = 84;
            this.MinDate.Text = "persianDateTimePicker1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label2.Location = new System.Drawing.Point(472, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 85;
            this.label2.Text = "تا تاریخ :";
            // 
            // MaxDate
            // 
            this.MaxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxDate.BackColor = System.Drawing.Color.White;
            this.MaxDate.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.MaxDate.Location = new System.Drawing.Point(302, 20);
            this.MaxDate.Name = "MaxDate";
            this.MaxDate.ShowTime = false;
            this.MaxDate.Size = new System.Drawing.Size(167, 25);
            this.MaxDate.TabIndex = 86;
            this.MaxDate.Text = "persianDateTimePicker2";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.ReportPnl);
            this.panel1.Controls.Add(this.panelDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 450);
            this.panel1.TabIndex = 7;
            // 
            // ReportPnl
            // 
            this.ReportPnl.BackColor = System.Drawing.Color.Transparent;
            this.ReportPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportPnl.Location = new System.Drawing.Point(0, 64);
            this.ReportPnl.Name = "ReportPnl";
            this.ReportPnl.Size = new System.Drawing.Size(800, 386);
            this.ReportPnl.TabIndex = 6;
            // 
            // buttonOK
            // 
            this.buttonOK.BackColor = System.Drawing.Color.White;
            this.buttonOK.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.buttonOK.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.buttonOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOK.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold);
            this.buttonOK.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.buttonOK.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOK.Location = new System.Drawing.Point(26, 18);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(150, 31);
            this.buttonOK.TabIndex = 177;
            this.buttonOK.Text = "گزارش";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // ReportViewer11
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.panel1);
            this.Name = "ReportViewer11";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "ReportViewer11";
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label label4;
        private Dentistry.UserControls.PersianDateTimePicker MinDate;
        private System.Windows.Forms.Label label2;
        private Dentistry.UserControls.PersianDateTimePicker MaxDate;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ReportPnl;
        private System.Windows.Forms.Button buttonOK;
    }
}