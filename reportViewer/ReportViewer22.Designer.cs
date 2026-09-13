namespace Dentistry
{
    partial class ReportViewer22
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
            this.panel3 = new System.Windows.Forms.Panel();
            this.CostTypePnl = new System.Windows.Forms.Panel();
            this.CostTypeCbo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AccountPartyPnl = new System.Windows.Forms.Panel();
            this.AccountPartyCompanyCbo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.MinDate = new Dentistry.UserControls.PersianDateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.MaxDate = new Dentistry.UserControls.PersianDateTimePicker();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ReportPnl = new System.Windows.Forms.Panel();
            this.buttonOK = new System.Windows.Forms.Button();
            this.panelDetails.SuspendLayout();
            this.panel3.SuspendLayout();
            this.CostTypePnl.SuspendLayout();
            this.AccountPartyPnl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelDetails
            // 
            this.panelDetails.BackColor = System.Drawing.Color.White;
            this.panelDetails.Controls.Add(this.buttonOK);
            this.panelDetails.Controls.Add(this.panel3);
            this.panelDetails.Controls.Add(this.label4);
            this.panelDetails.Controls.Add(this.MinDate);
            this.panelDetails.Controls.Add(this.label2);
            this.panelDetails.Controls.Add(this.MaxDate);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(1040, 100);
            this.panelDetails.TabIndex = 4;
            this.panelDetails.Tag = "2";
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.CostTypePnl);
            this.panel3.Controls.Add(this.AccountPartyPnl);
            this.panel3.Location = new System.Drawing.Point(196, 46);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(841, 49);
            this.panel3.TabIndex = 108;
            // 
            // CostTypePnl
            // 
            this.CostTypePnl.Controls.Add(this.CostTypeCbo);
            this.CostTypePnl.Controls.Add(this.label1);
            this.CostTypePnl.Dock = System.Windows.Forms.DockStyle.Right;
            this.CostTypePnl.Location = new System.Drawing.Point(53, 0);
            this.CostTypePnl.Name = "CostTypePnl";
            this.CostTypePnl.Size = new System.Drawing.Size(394, 49);
            this.CostTypePnl.TabIndex = 108;
            // 
            // CostTypeCbo
            // 
            this.CostTypeCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CostTypeCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CostTypeCbo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CostTypeCbo.FormattingEnabled = true;
            this.CostTypeCbo.Location = new System.Drawing.Point(44, 11);
            this.CostTypeCbo.Name = "CostTypeCbo";
            this.CostTypeCbo.Size = new System.Drawing.Size(267, 28);
            this.CostTypeCbo.TabIndex = 88;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label1.Location = new System.Drawing.Point(314, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 20);
            this.label1.TabIndex = 89;
            this.label1.Text = "نوع هزینه :";
            // 
            // AccountPartyPnl
            // 
            this.AccountPartyPnl.Controls.Add(this.AccountPartyCompanyCbo);
            this.AccountPartyPnl.Controls.Add(this.label7);
            this.AccountPartyPnl.Dock = System.Windows.Forms.DockStyle.Right;
            this.AccountPartyPnl.Location = new System.Drawing.Point(447, 0);
            this.AccountPartyPnl.Name = "AccountPartyPnl";
            this.AccountPartyPnl.Size = new System.Drawing.Size(394, 49);
            this.AccountPartyPnl.TabIndex = 107;
            // 
            // AccountPartyCompanyCbo
            // 
            this.AccountPartyCompanyCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AccountPartyCompanyCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccountPartyCompanyCbo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AccountPartyCompanyCbo.FormattingEnabled = true;
            this.AccountPartyCompanyCbo.Location = new System.Drawing.Point(45, 11);
            this.AccountPartyCompanyCbo.Name = "AccountPartyCompanyCbo";
            this.AccountPartyCompanyCbo.Size = new System.Drawing.Size(267, 28);
            this.AccountPartyCompanyCbo.TabIndex = 88;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label7.Location = new System.Drawing.Point(314, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(50, 20);
            this.label7.TabIndex = 89;
            this.label7.Text = "شرکت :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label4.Location = new System.Drawing.Point(957, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 20);
            this.label4.TabIndex = 103;
            this.label4.Text = "از تاریخ :";
            // 
            // MinDate
            // 
            this.MinDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MinDate.BackColor = System.Drawing.Color.White;
            this.MinDate.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.MinDate.Location = new System.Drawing.Point(788, 17);
            this.MinDate.Name = "MinDate";
            this.MinDate.ShowTime = false;
            this.MinDate.Size = new System.Drawing.Size(167, 25);
            this.MinDate.TabIndex = 104;
            this.MinDate.Text = "persianDateTimePicker1";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.label2.Location = new System.Drawing.Point(699, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 105;
            this.label2.Text = "تا تاریخ :";
            // 
            // MaxDate
            // 
            this.MaxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaxDate.BackColor = System.Drawing.Color.White;
            this.MaxDate.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.MaxDate.Location = new System.Drawing.Point(530, 15);
            this.MaxDate.Name = "MaxDate";
            this.MaxDate.ShowTime = false;
            this.MaxDate.Size = new System.Drawing.Size(167, 25);
            this.MaxDate.TabIndex = 106;
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
            this.panel1.Size = new System.Drawing.Size(1040, 561);
            this.panel1.TabIndex = 6;
            // 
            // ReportPnl
            // 
            this.ReportPnl.BackColor = System.Drawing.Color.Transparent;
            this.ReportPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportPnl.Location = new System.Drawing.Point(0, 100);
            this.ReportPnl.Name = "ReportPnl";
            this.ReportPnl.Size = new System.Drawing.Size(1040, 461);
            this.ReportPnl.TabIndex = 5;
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
            this.buttonOK.Location = new System.Drawing.Point(23, 55);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(150, 31);
            this.buttonOK.TabIndex = 178;
            this.buttonOK.Text = "گزارش";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // ReportViewer22
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(250)))));
            this.ClientSize = new System.Drawing.Size(1040, 561);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ReportViewer22";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.CostTypePnl.ResumeLayout(false);
            this.CostTypePnl.PerformLayout();
            this.AccountPartyPnl.ResumeLayout(false);
            this.AccountPartyPnl.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox AccountPartyCompanyCbo;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ReportPnl;
        private System.Windows.Forms.Label label4;
        private UserControls.PersianDateTimePicker MinDate;
        private System.Windows.Forms.Label label2;
        private UserControls.PersianDateTimePicker MaxDate;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel CostTypePnl;
        private System.Windows.Forms.ComboBox CostTypeCbo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel AccountPartyPnl;
        private System.Windows.Forms.Button buttonOK;
    }
}