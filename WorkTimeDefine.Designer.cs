namespace Dentistry
{
    partial class WorkTimeDefine
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
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.toTimeTxt = new System.Windows.Forms.MaskedTextBox();
            this.fromTimeTxt = new System.Windows.Forms.MaskedTextBox();
            this.doctorTxt = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.rdoRemoveToList = new System.Windows.Forms.RadioButton();
            this.rdoAddToList = new System.Windows.Forms.RadioButton();
            this.dateTxt = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnOk = new System.Windows.Forms.Button();
            this.errorProvider1 = new System.Windows.Forms.ErrorProvider(this.components);
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.toTimeTxt);
            this.panel1.Controls.Add(this.fromTimeTxt);
            this.panel1.Controls.Add(this.doctorTxt);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.rdoRemoveToList);
            this.panel1.Controls.Add(this.rdoAddToList);
            this.panel1.Controls.Add(this.dateTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Font = new System.Drawing.Font("Vazir", 9.5F);
            this.panel1.Location = new System.Drawing.Point(18, 18);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(549, 267);
            this.panel1.TabIndex = 0;
            // 
            // toTimeTxt
            // 
            this.toTimeTxt.Font = new System.Drawing.Font("Vazir", 9.5F);
            this.toTimeTxt.Location = new System.Drawing.Point(190, 110);
            this.toTimeTxt.Mask = "00:00";
            this.toTimeTxt.Name = "toTimeTxt";
            this.toTimeTxt.Size = new System.Drawing.Size(60, 27);
            this.toTimeTxt.TabIndex = 51;
            this.toTimeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toTimeTxt.ValidatingType = typeof(System.DateTime);
            // 
            // fromTimeTxt
            // 
            this.fromTimeTxt.Font = new System.Drawing.Font("Vazir", 9.5F);
            this.fromTimeTxt.Location = new System.Drawing.Point(352, 109);
            this.fromTimeTxt.Mask = "00:00";
            this.fromTimeTxt.Name = "fromTimeTxt";
            this.fromTimeTxt.Size = new System.Drawing.Size(60, 27);
            this.fromTimeTxt.TabIndex = 50;
            this.fromTimeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.fromTimeTxt.ValidatingType = typeof(System.DateTime);
            // 
            // doctorTxt
            // 
            this.doctorTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doctorTxt.BackColor = System.Drawing.Color.Lavender;
            this.doctorTxt.Font = new System.Drawing.Font("Vazir", 9.5F, System.Drawing.FontStyle.Bold);
            this.doctorTxt.ForeColor = System.Drawing.Color.SlateBlue;
            this.doctorTxt.Location = new System.Drawing.Point(45, 13);
            this.doctorTxt.Name = "doctorTxt";
            this.doctorTxt.Padding = new System.Windows.Forms.Padding(3);
            this.doctorTxt.Size = new System.Drawing.Size(433, 30);
            this.doctorTxt.TabIndex = 48;
            this.doctorTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(484, 18);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(48, 20);
            this.label5.TabIndex = 47;
            this.label5.Text = "پزشک :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Location = new System.Drawing.Point(35, 151);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(450, 2);
            this.panel2.TabIndex = 46;
            // 
            // rdoRemoveToList
            // 
            this.rdoRemoveToList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoRemoveToList.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.rdoRemoveToList.Location = new System.Drawing.Point(282, 215);
            this.rdoRemoveToList.Name = "rdoRemoveToList";
            this.rdoRemoveToList.Padding = new System.Windows.Forms.Padding(5);
            this.rdoRemoveToList.Size = new System.Drawing.Size(243, 35);
            this.rdoRemoveToList.TabIndex = 45;
            this.rdoRemoveToList.TabStop = true;
            this.rdoRemoveToList.Text = "از لیست ساعت کاری مطب حذف شود";
            this.rdoRemoveToList.UseVisualStyleBackColor = false;
            this.rdoRemoveToList.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdoAddToList
            // 
            this.rdoAddToList.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoAddToList.BackColor = System.Drawing.Color.YellowGreen;
            this.rdoAddToList.Location = new System.Drawing.Point(282, 170);
            this.rdoAddToList.Name = "rdoAddToList";
            this.rdoAddToList.Padding = new System.Windows.Forms.Padding(5);
            this.rdoAddToList.Size = new System.Drawing.Size(243, 35);
            this.rdoAddToList.TabIndex = 44;
            this.rdoAddToList.TabStop = true;
            this.rdoAddToList.Text = "به لیست ساعت کاری مطب اضافه شود";
            this.rdoAddToList.UseVisualStyleBackColor = false;
            this.rdoAddToList.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // dateTxt
            // 
            this.dateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dateTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dateTxt.Font = new System.Drawing.Font("Vazir", 9.5F, System.Drawing.FontStyle.Bold);
            this.dateTxt.Location = new System.Drawing.Point(45, 61);
            this.dateTxt.Name = "dateTxt";
            this.dateTxt.Padding = new System.Windows.Forms.Padding(5);
            this.dateTxt.Size = new System.Drawing.Size(433, 30);
            this.dateTxt.TabIndex = 43;
            this.dateTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(252, 114);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(62, 20);
            this.label3.TabIndex = 9;
            this.label3.Text = "تا ساعت :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(414, 113);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(62, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "از ساعت :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(484, 65);
            this.label2.Name = "label2";
            this.label2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "تاریخ :";
            // 
            // btnOk
            // 
            this.btnOk.BackColor = System.Drawing.Color.White;
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.btnOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOk.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.btnOk.Location = new System.Drawing.Point(417, 300);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(150, 30);
            this.btnOk.TabIndex = 62;
            this.btnOk.Text = "تایید ";
            this.btnOk.UseVisualStyleBackColor = false;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // errorProvider1
            // 
            this.errorProvider1.ContainerControl = this;
            this.errorProvider1.RightToLeft = true;
            // 
            // WorkTimeDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(584, 343);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "WorkTimeDefine";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label dateTxt;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton rdoRemoveToList;
        private System.Windows.Forms.RadioButton rdoAddToList;
        private System.Windows.Forms.Label doctorTxt;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.MaskedTextBox fromTimeTxt;
        public System.Windows.Forms.MaskedTextBox toTimeTxt;
        private System.Windows.Forms.ErrorProvider errorProvider1;
    }
}