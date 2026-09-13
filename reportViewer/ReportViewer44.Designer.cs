namespace Dentistry
{
    partial class ReportViewer44
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
            this.DateOfMaturityChk = new System.Windows.Forms.RadioButton();
            this.DateOfIssuanceChk = new System.Windows.Forms.RadioButton();
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
            this.panelDetails.Controls.Add(this.DateOfMaturityChk);
            this.panelDetails.Controls.Add(this.DateOfIssuanceChk);
            this.panelDetails.Controls.Add(this.label4);
            this.panelDetails.Controls.Add(this.MinDate);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.MaxDate);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(984, 100);
            this.panelDetails.TabIndex = 4;
            this.panelDetails.Tag = "2";
            // 
            // DateOfMaturityChk
            // 
            this.DateOfMaturityChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateOfMaturityChk.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateOfMaturityChk.Location = new System.Drawing.Point(497, 59);
            this.DateOfMaturityChk.Name = "DateOfMaturityChk";
            this.DateOfMaturityChk.Size = new System.Drawing.Size(150, 30);
            this.DateOfMaturityChk.TabIndex = 103;
            this.DateOfMaturityChk.TabStop = true;
            this.DateOfMaturityChk.Text = "براساس تاریخ سررسید";
            this.DateOfMaturityChk.UseVisualStyleBackColor = true;
            // 
            // DateOfIssuanceChk
            // 
            this.DateOfIssuanceChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateOfIssuanceChk.Checked = true;
            this.DateOfIssuanceChk.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateOfIssuanceChk.Location = new System.Drawing.Point(755, 59);
            this.DateOfIssuanceChk.Name = "DateOfIssuanceChk";
            this.DateOfIssuanceChk.Padding = new System.Windows.Forms.Padding(3);
            this.DateOfIssuanceChk.Size = new System.Drawing.Size(150, 30);
            this.DateOfIssuanceChk.TabIndex = 102;
            this.DateOfIssuanceChk.TabStop = true;
            this.DateOfIssuanceChk.Text = "براساس تاریخ صدور";
            this.DateOfIssuanceChk.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label4.Location = new System.Drawing.Point(907, 22);
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
            this.MinDate.Location = new System.Drawing.Point(738, 18);
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
            this.label2.Location = new System.Drawing.Point(649, 20);
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
            this.MaxDate.Location = new System.Drawing.Point(480, 16);
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
            this.panel1.Size = new System.Drawing.Size(984, 561);
            this.panel1.TabIndex = 6;
            // 
            // ReportPnl
            // 
            this.ReportPnl.BackColor = System.Drawing.Color.Transparent;
            this.ReportPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportPnl.Location = new System.Drawing.Point(0, 100);
            this.ReportPnl.Name = "ReportPnl";
            this.ReportPnl.Size = new System.Drawing.Size(984, 461);
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
            this.buttonOK.Location = new System.Drawing.Point(26, 49);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(150, 31);
            this.buttonOK.TabIndex = 180;
            this.buttonOK.Text = "گزارش";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // ReportViewer44
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(984, 561);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ReportViewer44";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
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
        private System.Windows.Forms.RadioButton DateOfMaturityChk;
        private System.Windows.Forms.RadioButton DateOfIssuanceChk;
        private System.Windows.Forms.Button buttonOK;
    }
}