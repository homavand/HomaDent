namespace Dentistry
{
    partial class ReportViewer33
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
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton_WithoutBlackList = new System.Windows.Forms.RadioButton();
            this.radioButton_WithBlackList = new System.Windows.Forms.RadioButton();
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
            this.panelDetails.Controls.Add(this.label1);
            this.panelDetails.Controls.Add(this.radioButton_WithoutBlackList);
            this.panelDetails.Controls.Add(this.radioButton_WithBlackList);
            this.panelDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelDetails.Location = new System.Drawing.Point(0, 0);
            this.panelDetails.Name = "panelDetails";
            this.panelDetails.Size = new System.Drawing.Size(831, 78);
            this.panelDetails.TabIndex = 4;
            this.panelDetails.Tag = "2";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(725, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 20);
            this.label1.TabIndex = 90;
            this.label1.Text = "لیست بیماران :";
            // 
            // radioButton_WithoutBlackList
            // 
            this.radioButton_WithoutBlackList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton_WithoutBlackList.AutoSize = true;
            this.radioButton_WithoutBlackList.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_WithoutBlackList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.radioButton_WithoutBlackList.Location = new System.Drawing.Point(409, 28);
            this.radioButton_WithoutBlackList.Name = "radioButton_WithoutBlackList";
            this.radioButton_WithoutBlackList.Size = new System.Drawing.Size(145, 24);
            this.radioButton_WithoutBlackList.TabIndex = 89;
            this.radioButton_WithoutBlackList.Text = "بدون بیماران غیر فعال";
            this.radioButton_WithoutBlackList.UseVisualStyleBackColor = true;
            // 
            // radioButton_WithBlackList
            // 
            this.radioButton_WithBlackList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.radioButton_WithBlackList.AutoSize = true;
            this.radioButton_WithBlackList.Checked = true;
            this.radioButton_WithBlackList.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioButton_WithBlackList.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(57)))), ((int)(((byte)(85)))));
            this.radioButton_WithBlackList.Location = new System.Drawing.Point(578, 28);
            this.radioButton_WithBlackList.Name = "radioButton_WithBlackList";
            this.radioButton_WithBlackList.Size = new System.Drawing.Size(127, 24);
            this.radioButton_WithBlackList.TabIndex = 88;
            this.radioButton_WithBlackList.TabStop = true;
            this.radioButton_WithBlackList.Text = "با بیماران غیر فعال";
            this.radioButton_WithBlackList.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ReportPnl);
            this.panel1.Controls.Add(this.panelDetails);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(831, 475);
            this.panel1.TabIndex = 6;
            // 
            // ReportPnl
            // 
            this.ReportPnl.BackColor = System.Drawing.Color.Transparent;
            this.ReportPnl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ReportPnl.Location = new System.Drawing.Point(0, 78);
            this.ReportPnl.Name = "ReportPnl";
            this.ReportPnl.Size = new System.Drawing.Size(831, 397);
            this.ReportPnl.TabIndex = 7;
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
            this.buttonOK.Location = new System.Drawing.Point(29, 26);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(150, 31);
            this.buttonOK.TabIndex = 179;
            this.buttonOK.Text = "گزارش";
            this.buttonOK.UseVisualStyleBackColor = false;
            this.buttonOK.Click += new System.EventHandler(this.buttonReport_Click);
            // 
            // ReportViewer33
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(831, 475);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "ReportViewer33";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panelDetails.ResumeLayout(false);
            this.panelDetails.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton_WithoutBlackList;
        private System.Windows.Forms.RadioButton radioButton_WithBlackList;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ReportPnl;
        private System.Windows.Forms.Button buttonOK;
    }
}