namespace Dentistry
{
    partial class PatientFollowUpDefine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.patientNameTxt = new System.Windows.Forms.Label();
            this.patientInformationSaveBtn = new System.Windows.Forms.Button();
            this.doctorCbo = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.followUpDateTxt = new Dentistry.UserControls.PersianDateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.commentTxt = new Dentistry.UserControls.ExtendedTextBox();
            this.dataGridViewFollowUp = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSolarDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSolarFollowUpDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFollowUp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dataGridViewFollowUp);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(797, 461);
            this.panel1.TabIndex = 143;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.patientNameTxt);
            this.panel2.Controls.Add(this.patientInformationSaveBtn);
            this.panel2.Controls.Add(this.doctorCbo);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.followUpDateTxt);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.commentTxt);
            this.panel2.Location = new System.Drawing.Point(19, 16);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(760, 207);
            this.panel2.TabIndex = 143;
            // 
            // patientNameTxt
            // 
            this.patientNameTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.patientNameTxt.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.patientNameTxt.Location = new System.Drawing.Point(455, 13);
            this.patientNameTxt.Name = "patientNameTxt";
            this.patientNameTxt.Padding = new System.Windows.Forms.Padding(3);
            this.patientNameTxt.Size = new System.Drawing.Size(200, 23);
            this.patientNameTxt.TabIndex = 148;
            // 
            // patientInformationSaveBtn
            // 
            this.patientInformationSaveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.patientInformationSaveBtn.BackColor = System.Drawing.Color.White;
            this.patientInformationSaveBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.patientInformationSaveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.patientInformationSaveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.patientInformationSaveBtn.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.patientInformationSaveBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.patientInformationSaveBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.patientInformationSaveBtn.Location = new System.Drawing.Point(19, 165);
            this.patientInformationSaveBtn.Name = "patientInformationSaveBtn";
            this.patientInformationSaveBtn.Size = new System.Drawing.Size(178, 30);
            this.patientInformationSaveBtn.TabIndex = 4;
            this.patientInformationSaveBtn.Text = "تایید و ثبت";
            this.patientInformationSaveBtn.UseVisualStyleBackColor = false;
            this.patientInformationSaveBtn.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // doctorCbo
            // 
            this.doctorCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.doctorCbo.Font = new System.Drawing.Font("Vazir", 9F);
            this.doctorCbo.FormattingEnabled = true;
            this.doctorCbo.Location = new System.Drawing.Point(455, 48);
            this.doctorCbo.Name = "doctorCbo";
            this.doctorCbo.Size = new System.Drawing.Size(200, 26);
            this.doctorCbo.TabIndex = 1;
            this.doctorCbo.Tag = "";
            // 
            // label18
            // 
            this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label18.Location = new System.Drawing.Point(659, 90);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(83, 20);
            this.label18.TabIndex = 105;
            this.label18.Text = "تاریخ فالوآپ :";
            // 
            // followUpDateTxt
            // 
            this.followUpDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.followUpDateTxt.BackColor = System.Drawing.Color.White;
            this.followUpDateTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.followUpDateTxt.Location = new System.Drawing.Point(455, 86);
            this.followUpDateTxt.Name = "followUpDateTxt";
            this.followUpDateTxt.ShowTime = false;
            this.followUpDateTxt.Size = new System.Drawing.Size(200, 25);
            this.followUpDateTxt.TabIndex = 2;
            this.followUpDateTxt.Text = "persianDateTimePicker1";
            this.followUpDateTxt.ValueChanged += new Dentistry.UserControls.PersianDateTimePicker.onValueChanged(this.ComboBoxAZDate_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(659, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(62, 20);
            this.label6.TabIndex = 54;
            this.label6.Text = "نام بیمار :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.Location = new System.Drawing.Point(659, 53);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 143;
            this.label4.Text = "نام پزشک :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(659, 127);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 145;
            this.label1.Text = "توضیحات :";
            // 
            // commentTxt
            // 
            this.commentTxt.AllowExtendedCharacters = true;
            this.commentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.commentTxt.BackColor = System.Drawing.Color.White;
            this.commentTxt.ExtendedTextBoxLanguage = Dentistry.UserControls.ExtendedTextBox.ExtendedTextBoxLanguages.Bilingual;
            this.commentTxt.Font = new System.Drawing.Font("Vazir", 9F);
            this.commentTxt.Location = new System.Drawing.Point(19, 123);
            this.commentTxt.MaxLength = 50;
            this.commentTxt.MinLength = 0;
            this.commentTxt.MoveToNextOnEnterKey = false;
            this.commentTxt.Name = "commentTxt";
            this.commentTxt.ShowToolTip = true;
            this.commentTxt.Size = new System.Drawing.Size(636, 26);
            this.commentTxt.TabIndex = 3;
            // 
            // dataGridViewFollowUp
            // 
            this.dataGridViewFollowUp.AllowUserToAddRows = false;
            this.dataGridViewFollowUp.AllowUserToDeleteRows = false;
            this.dataGridViewFollowUp.AllowUserToResizeColumns = false;
            this.dataGridViewFollowUp.AllowUserToResizeRows = false;
            this.dataGridViewFollowUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewFollowUp.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewFollowUp.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewFollowUp.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFollowUp.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridViewFollowUp.ColumnHeadersHeight = 30;
            this.dataGridViewFollowUp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewFollowUp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnComment,
            this.ColumnSolarDate,
            this.ColumnSolarFollowUpDate,
            this.ColumnIsDeleted});
            this.dataGridViewFollowUp.EnableHeadersVisualStyles = false;
            this.dataGridViewFollowUp.GridColor = System.Drawing.Color.White;
            this.dataGridViewFollowUp.Location = new System.Drawing.Point(19, 238);
            this.dataGridViewFollowUp.MultiSelect = false;
            this.dataGridViewFollowUp.Name = "dataGridViewFollowUp";
            this.dataGridViewFollowUp.ReadOnly = true;
            this.dataGridViewFollowUp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewFollowUp.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridViewFollowUp.RowHeadersVisible = false;
            this.dataGridViewFollowUp.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewFollowUp.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir FD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dataGridViewFollowUp.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewFollowUp.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dataGridViewFollowUp.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewFollowUp.RowTemplate.Height = 30;
            this.dataGridViewFollowUp.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewFollowUp.Size = new System.Drawing.Size(760, 201);
            this.dataGridViewFollowUp.TabIndex = 9;
            // 
            // ColumnId
            // 
            this.ColumnId.DataPropertyName = "Id";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            // 
            // ColumnComment
            // 
            this.ColumnComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComment.DataPropertyName = "Comment";
            this.ColumnComment.HeaderText = "توضیحات";
            this.ColumnComment.Name = "ColumnComment";
            this.ColumnComment.ReadOnly = true;
            // 
            // ColumnSolarDate
            // 
            this.ColumnSolarDate.DataPropertyName = "SolarDate";
            this.ColumnSolarDate.HeaderText = "تاریخ ثبت";
            this.ColumnSolarDate.Name = "ColumnSolarDate";
            this.ColumnSolarDate.ReadOnly = true;
            this.ColumnSolarDate.Width = 110;
            // 
            // ColumnSolarFollowUpDate
            // 
            this.ColumnSolarFollowUpDate.DataPropertyName = "SolarFollowUpDate";
            this.ColumnSolarFollowUpDate.HeaderText = "تاریخ فالوآپ";
            this.ColumnSolarFollowUpDate.Name = "ColumnSolarFollowUpDate";
            this.ColumnSolarFollowUpDate.ReadOnly = true;
            this.ColumnSolarFollowUpDate.Width = 110;
            // 
            // ColumnIsDeleted
            // 
            this.ColumnIsDeleted.DataPropertyName = "IsDeleted";
            this.ColumnIsDeleted.HeaderText = "حذف شده";
            this.ColumnIsDeleted.Name = "ColumnIsDeleted";
            this.ColumnIsDeleted.ReadOnly = true;
            this.ColumnIsDeleted.Visible = false;
            this.ColumnIsDeleted.Width = 80;
            // 
            // PatientFollowUpDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(797, 461);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "PatientFollowUpDefine";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فالو آپ";
            this.Load += new System.EventHandler(this.FormFollowUp_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewFollowUp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label6;
        private Dentistry.UserControls.PersianDateTimePicker followUpDateTxt;
        private System.Windows.Forms.ComboBox doctorCbo;
        private System.Windows.Forms.Label label4;
        private UserControls.ExtendedTextBox commentTxt;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DataGridView dataGridViewFollowUp;
        private System.Windows.Forms.Button patientInformationSaveBtn;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label patientNameTxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSolarDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSolarFollowUpDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIsDeleted;
    }
}