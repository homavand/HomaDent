namespace Dentistry
{
    partial class InsuranceFinancialDefine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.deductionValueTxt = new Dentistry.UserControls.CurrencyTextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.Error_comboBoxInsurance = new System.Windows.Forms.Label();
            this.insurerCbo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Error_textBoxRequestedValue = new System.Windows.Forms.Label();
            this.commentTxt = new Dentistry.UserControls.ExtendedTextBox();
            this.receivedValueTxt = new Dentistry.UserControls.CurrencyTextBox();
            this.requestedValueTxt = new Dentistry.UserControls.CurrencyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.PanelX1 = new Dentistry.UserControls.ExPanel();
            this.remainValueTxt = new Dentistry.UserControls.CurrencyTextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.registerDateTxt = new System.Windows.Forms.Label();
            this.tblTxt = new System.Windows.Forms.Label();
            this.dgPatientServicesInfo = new System.Windows.Forms.DataGridView();
            this.ColumnKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ToDateTxt = new Dentistry.UserControls.PersianDateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.FromDateTxt = new Dentistry.UserControls.PersianDateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.OkBtn = new System.Windows.Forms.Button();
            this.PanelX1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatientServicesInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // deductionValueTxt
            // 
            this.deductionValueTxt.AllowPoint = false;
            this.deductionValueTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.deductionValueTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deductionValueTxt.Location = new System.Drawing.Point(468, 237);
            this.deductionValueTxt.MaxLength = 10;
            this.deductionValueTxt.MinLength = 0;
            this.deductionValueTxt.MoveToNextOnEnterKey = true;
            this.deductionValueTxt.Name = "deductionValueTxt";
            this.deductionValueTxt.ShowToolTip = true;
            this.deductionValueTxt.Size = new System.Drawing.Size(200, 28);
            this.deductionValueTxt.TabIndex = 6;
            this.deductionValueTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.deductionValueTxt.TextChanged += new System.EventHandler(this.deductionValueTxt_TextChanged);
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(682, 242);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 21);
            this.label7.TabIndex = 90;
            this.label7.Text = "کسورات :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Error_comboBoxInsurance
            // 
            this.Error_comboBoxInsurance.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_comboBoxInsurance.AutoSize = true;
            this.Error_comboBoxInsurance.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_comboBoxInsurance.ForeColor = System.Drawing.Color.Red;
            this.Error_comboBoxInsurance.Location = new System.Drawing.Point(452, 67);
            this.Error_comboBoxInsurance.Name = "Error_comboBoxInsurance";
            this.Error_comboBoxInsurance.Size = new System.Drawing.Size(13, 18);
            this.Error_comboBoxInsurance.TabIndex = 83;
            this.Error_comboBoxInsurance.Text = "*";
            this.Error_comboBoxInsurance.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_comboBoxInsurance.Visible = false;
            // 
            // insurerCbo
            // 
            this.insurerCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.insurerCbo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.insurerCbo.FormattingEnabled = true;
            this.insurerCbo.Location = new System.Drawing.Point(468, 58);
            this.insurerCbo.Name = "insurerCbo";
            this.insurerCbo.Size = new System.Drawing.Size(200, 28);
            this.insurerCbo.TabIndex = 1;
            this.insurerCbo.SelectedIndexChanged += new System.EventHandler(this.insurerCbo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(682, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(100, 21);
            this.label5.TabIndex = 7;
            this.label5.Text = "عنوان بیمه گر :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(682, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 21);
            this.label3.TabIndex = 87;
            this.label3.Text = "تاریخ ثبت :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Error_textBoxRequestedValue
            // 
            this.Error_textBoxRequestedValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxRequestedValue.AutoSize = true;
            this.Error_textBoxRequestedValue.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxRequestedValue.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxRequestedValue.Location = new System.Drawing.Point(453, 174);
            this.Error_textBoxRequestedValue.Name = "Error_textBoxRequestedValue";
            this.Error_textBoxRequestedValue.Size = new System.Drawing.Size(13, 18);
            this.Error_textBoxRequestedValue.TabIndex = 86;
            this.Error_textBoxRequestedValue.Text = "*";
            this.Error_textBoxRequestedValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxRequestedValue.Visible = false;
            // 
            // commentTxt
            // 
            this.commentTxt.AllowExtendedCharacters = true;
            this.commentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.commentTxt.ExtendedTextBoxLanguage = Dentistry.UserControls.ExtendedTextBox.ExtendedTextBoxLanguages.Farsi;
            this.commentTxt.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentTxt.Location = new System.Drawing.Point(37, 319);
            this.commentTxt.MaxLength = 500;
            this.commentTxt.MinLength = 0;
            this.commentTxt.MoveToNextOnEnterKey = true;
            this.commentTxt.Name = "commentTxt";
            this.commentTxt.ShowToolTip = true;
            this.commentTxt.Size = new System.Drawing.Size(631, 26);
            this.commentTxt.TabIndex = 7;
            // 
            // receivedValueTxt
            // 
            this.receivedValueTxt.AllowPoint = false;
            this.receivedValueTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.receivedValueTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.receivedValueTxt.Location = new System.Drawing.Point(468, 202);
            this.receivedValueTxt.MaxLength = 10;
            this.receivedValueTxt.MinLength = 0;
            this.receivedValueTxt.MoveToNextOnEnterKey = true;
            this.receivedValueTxt.Name = "receivedValueTxt";
            this.receivedValueTxt.ShowToolTip = true;
            this.receivedValueTxt.Size = new System.Drawing.Size(200, 28);
            this.receivedValueTxt.TabIndex = 5;
            this.receivedValueTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.receivedValueTxt.TextChanged += new System.EventHandler(this.FinancialValueTxt_TextChanged);
            // 
            // requestedValueTxt
            // 
            this.requestedValueTxt.AllowPoint = false;
            this.requestedValueTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.requestedValueTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.requestedValueTxt.Location = new System.Drawing.Point(468, 168);
            this.requestedValueTxt.MaxLength = 10;
            this.requestedValueTxt.MinLength = 0;
            this.requestedValueTxt.MoveToNextOnEnterKey = true;
            this.requestedValueTxt.Name = "requestedValueTxt";
            this.requestedValueTxt.ShowToolTip = true;
            this.requestedValueTxt.Size = new System.Drawing.Size(200, 28);
            this.requestedValueTxt.TabIndex = 4;
            this.requestedValueTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.requestedValueTxt.TextChanged += new System.EventHandler(this.FinancialValueTxt_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(682, 323);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 21);
            this.label4.TabIndex = 3;
            this.label4.Text = "توضیحات :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(682, 207);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(100, 21);
            this.label2.TabIndex = 1;
            this.label2.Text = "مبلغ دریافتی :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(682, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 21);
            this.label1.TabIndex = 0;
            this.label1.Text = "مبلغ درخواستی :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PanelX1
            // 
            this.PanelX1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelX1.BackColor = System.Drawing.Color.White;
            this.PanelX1.BorderColor = System.Drawing.Color.Gainsboro;
            this.PanelX1.Controls.Add(this.remainValueTxt);
            this.PanelX1.Controls.Add(this.label11);
            this.PanelX1.Controls.Add(this.registerDateTxt);
            this.PanelX1.Controls.Add(this.tblTxt);
            this.PanelX1.Controls.Add(this.dgPatientServicesInfo);
            this.PanelX1.Controls.Add(this.ToDateTxt);
            this.PanelX1.Controls.Add(this.label9);
            this.PanelX1.Controls.Add(this.label10);
            this.PanelX1.Controls.Add(this.FromDateTxt);
            this.PanelX1.Controls.Add(this.label6);
            this.PanelX1.Controls.Add(this.label8);
            this.PanelX1.Controls.Add(this.deductionValueTxt);
            this.PanelX1.Controls.Add(this.label7);
            this.PanelX1.Controls.Add(this.Error_comboBoxInsurance);
            this.PanelX1.Controls.Add(this.insurerCbo);
            this.PanelX1.Controls.Add(this.label1);
            this.PanelX1.Controls.Add(this.label5);
            this.PanelX1.Controls.Add(this.label2);
            this.PanelX1.Controls.Add(this.label3);
            this.PanelX1.Controls.Add(this.label4);
            this.PanelX1.Controls.Add(this.Error_textBoxRequestedValue);
            this.PanelX1.Controls.Add(this.requestedValueTxt);
            this.PanelX1.Controls.Add(this.commentTxt);
            this.PanelX1.Controls.Add(this.receivedValueTxt);
            this.PanelX1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.PanelX1.Location = new System.Drawing.Point(12, 12);
            this.PanelX1.Name = "PanelX1";
            this.PanelX1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PanelX1.Size = new System.Drawing.Size(796, 360);
            this.PanelX1.TabIndex = 98;
            this.PanelX1.TabStop = false;
            // 
            // remainValueTxt
            // 
            this.remainValueTxt.AllowPoint = false;
            this.remainValueTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.remainValueTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.remainValueTxt.Location = new System.Drawing.Point(468, 273);
            this.remainValueTxt.MaxLength = 10;
            this.remainValueTxt.MinLength = 0;
            this.remainValueTxt.MoveToNextOnEnterKey = true;
            this.remainValueTxt.Name = "remainValueTxt";
            this.remainValueTxt.ReadOnly = true;
            this.remainValueTxt.ShowToolTip = true;
            this.remainValueTxt.Size = new System.Drawing.Size(200, 28);
            this.remainValueTxt.TabIndex = 170;
            this.remainValueTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(682, 277);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(100, 21);
            this.label11.TabIndex = 169;
            this.label11.Text = "مانده :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // registerDateTxt
            // 
            this.registerDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.registerDateTxt.BackColor = System.Drawing.Color.Transparent;
            this.registerDateTxt.Font = new System.Drawing.Font("Vazir FD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.registerDateTxt.ForeColor = System.Drawing.Color.Black;
            this.registerDateTxt.Location = new System.Drawing.Point(373, 18);
            this.registerDateTxt.Name = "registerDateTxt";
            this.registerDateTxt.Padding = new System.Windows.Forms.Padding(5, 5, 2, 5);
            this.registerDateTxt.Size = new System.Drawing.Size(295, 30);
            this.registerDateTxt.TabIndex = 168;
            // 
            // tblTxt
            // 
            this.tblTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.tblTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tblTxt.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tblTxt.ForeColor = System.Drawing.Color.Black;
            this.tblTxt.Location = new System.Drawing.Point(37, 18);
            this.tblTxt.Name = "tblTxt";
            this.tblTxt.Padding = new System.Windows.Forms.Padding(5, 5, 2, 5);
            this.tblTxt.Size = new System.Drawing.Size(334, 30);
            this.tblTxt.TabIndex = 167;
            this.tblTxt.Text = "جمع خدمات انجام شده ";
            // 
            // dgPatientServicesInfo
            // 
            this.dgPatientServicesInfo.AllowUserToAddRows = false;
            this.dgPatientServicesInfo.AllowUserToDeleteRows = false;
            this.dgPatientServicesInfo.AllowUserToResizeColumns = false;
            this.dgPatientServicesInfo.AllowUserToResizeRows = false;
            this.dgPatientServicesInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPatientServicesInfo.BackgroundColor = System.Drawing.Color.White;
            this.dgPatientServicesInfo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPatientServicesInfo.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgPatientServicesInfo.ColumnHeadersHeight = 30;
            this.dgPatientServicesInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgPatientServicesInfo.ColumnHeadersVisible = false;
            this.dgPatientServicesInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnKey,
            this.ColumnValue});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPatientServicesInfo.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgPatientServicesInfo.EnableHeadersVisualStyles = false;
            this.dgPatientServicesInfo.GridColor = System.Drawing.Color.Gainsboro;
            this.dgPatientServicesInfo.Location = new System.Drawing.Point(37, 58);
            this.dgPatientServicesInfo.MultiSelect = false;
            this.dgPatientServicesInfo.Name = "dgPatientServicesInfo";
            this.dgPatientServicesInfo.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPatientServicesInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgPatientServicesInfo.RowHeadersVisible = false;
            this.dgPatientServicesInfo.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPatientServicesInfo.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgPatientServicesInfo.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.dgPatientServicesInfo.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgPatientServicesInfo.RowTemplate.Height = 30;
            this.dgPatientServicesInfo.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPatientServicesInfo.Size = new System.Drawing.Size(330, 251);
            this.dgPatientServicesInfo.TabIndex = 166;
            this.dgPatientServicesInfo.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgPatientServicesInfo_CellFormatting);
            // 
            // ColumnKey
            // 
            this.ColumnKey.DataPropertyName = "key";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnKey.DefaultCellStyle = dataGridViewCellStyle1;
            this.ColumnKey.HeaderText = "Key";
            this.ColumnKey.Name = "ColumnKey";
            this.ColumnKey.ReadOnly = true;
            this.ColumnKey.Width = 150;
            // 
            // ColumnValue
            // 
            this.ColumnValue.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnValue.DataPropertyName = "Value";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnValue.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnValue.HeaderText = "Value";
            this.ColumnValue.Name = "ColumnValue";
            this.ColumnValue.ReadOnly = true;
            // 
            // ToDateTxt
            // 
            this.ToDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateTxt.BackColor = System.Drawing.Color.White;
            this.ToDateTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ToDateTxt.Location = new System.Drawing.Point(468, 130);
            this.ToDateTxt.Name = "ToDateTxt";
            this.ToDateTxt.ShowTime = false;
            this.ToDateTxt.Size = new System.Drawing.Size(200, 25);
            this.ToDateTxt.TabIndex = 3;
            this.ToDateTxt.Text = "persianDateTimePicker1";
            this.ToDateTxt.ValueChanged += new Dentistry.UserControls.PersianDateTimePicker.onValueChanged(this.DateTxt_ValueChanged);
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(452, 135);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(13, 18);
            this.label9.TabIndex = 106;
            this.label9.Text = "*";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label9.Visible = false;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(682, 133);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(100, 21);
            this.label10.TabIndex = 105;
            this.label10.Text = "تا تاریخ :";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // FromDateTxt
            // 
            this.FromDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDateTxt.BackColor = System.Drawing.Color.White;
            this.FromDateTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FromDateTxt.Location = new System.Drawing.Point(468, 98);
            this.FromDateTxt.Name = "FromDateTxt";
            this.FromDateTxt.ShowTime = false;
            this.FromDateTxt.Size = new System.Drawing.Size(200, 25);
            this.FromDateTxt.TabIndex = 2;
            this.FromDateTxt.Text = "persianDateTimePicker1";
            this.FromDateTxt.ValueChanged += new Dentistry.UserControls.PersianDateTimePicker.onValueChanged(this.DateTxt_ValueChanged);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(452, 103);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 18);
            this.label6.TabIndex = 103;
            this.label6.Text = "*";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label6.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(682, 100);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(100, 21);
            this.label8.TabIndex = 102;
            this.label8.Text = "از تاریخ :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.BackColor = System.Drawing.Color.White;
            this.OkBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.OkBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.OkBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OkBtn.Location = new System.Drawing.Point(658, 391);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(150, 30);
            this.OkBtn.TabIndex = 99;
            this.OkBtn.Text = "تایید";
            this.OkBtn.UseVisualStyleBackColor = false;
            this.OkBtn.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // InsuranceFinancialDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(820, 437);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.PanelX1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InsuranceFinancialDefine";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  اطلاعات بیمه  ";
            this.Load += new System.EventHandler(this.InsuranceDefine_Load);
            this.PanelX1.ResumeLayout(false);
            this.PanelX1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatientServicesInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Error_comboBoxInsurance;
        private System.Windows.Forms.ComboBox insurerCbo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Error_textBoxRequestedValue;
        private UserControls.ExtendedTextBox commentTxt;
        private UserControls.CurrencyTextBox receivedValueTxt;
        private UserControls.CurrencyTextBox requestedValueTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private UserControls.CurrencyTextBox deductionValueTxt;
        private System.Windows.Forms.Label label7;
        private UserControls.ExPanel PanelX1;
        private Dentistry.UserControls.PersianDateTimePicker ToDateTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private Dentistry.UserControls.PersianDateTimePicker FromDateTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label tblTxt;
        private System.Windows.Forms.DataGridView dgPatientServicesInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnValue;
        private System.Windows.Forms.Label registerDateTxt;
        private UserControls.CurrencyTextBox remainValueTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button OkBtn;
    }
}