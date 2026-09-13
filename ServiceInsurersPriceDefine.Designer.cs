namespace Dentistry
{
    partial class ServiceInsurersPriceDefine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.serviceTitleTxt = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgInsurersPrices = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.serviceFreePriceTxt = new System.Windows.Forms.Label();
            this.datePnl = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ColumnIsCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnInsurerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInsurerTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFreePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInsurerPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InsurerFreePriceTxt = new Dentistry.UserControls.CurrencyTextBox();
            this.InsurerPriceTxt = new Dentistry.UserControls.CurrencyTextBox();
            this.DefineDateTxt = new Dentistry.UserControls.PersianDateTimePicker();
            this.RunDateTxt = new Dentistry.UserControls.PersianDateTimePicker();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgInsurersPrices)).BeginInit();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.datePnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // serviceTitleTxt
            // 
            this.serviceTitleTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceTitleTxt.BackColor = System.Drawing.Color.Transparent;
            this.serviceTitleTxt.Font = new System.Drawing.Font("Vazir", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceTitleTxt.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.serviceTitleTxt.Location = new System.Drawing.Point(38, 13);
            this.serviceTitleTxt.Name = "serviceTitleTxt";
            this.serviceTitleTxt.Padding = new System.Windows.Forms.Padding(5);
            this.serviceTitleTxt.Size = new System.Drawing.Size(695, 32);
            this.serviceTitleTxt.TabIndex = 169;
            this.serviceTitleTxt.Text = "...";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel2.Controls.Add(this.InsurerFreePriceTxt);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.InsurerPriceTxt);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 437);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(837, 64);
            this.panel2.TabIndex = 168;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(322, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 20);
            this.label7.TabIndex = 171;
            this.label7.Text = "قیمت بیمه :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(739, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 170;
            this.label6.Text = "قیمت آزاد :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.Color.White;
            this.okBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.okBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Font = new System.Drawing.Font("Vazir", 9.5F, System.Drawing.FontStyle.Bold);
            this.okBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.okBtn.Location = new System.Drawing.Point(14, 16);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(150, 30);
            this.okBtn.TabIndex = 124;
            this.okBtn.Text = "تایید";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(739, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 55;
            this.label2.Text = "عنوان خدمت :";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgInsurersPrices, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.panel4, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 103F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(843, 574);
            this.tableLayoutPanel1.TabIndex = 26;
            // 
            // dgInsurersPrices
            // 
            this.dgInsurersPrices.AllowUserToAddRows = false;
            this.dgInsurersPrices.AllowUserToDeleteRows = false;
            this.dgInsurersPrices.AllowUserToResizeColumns = false;
            this.dgInsurersPrices.AllowUserToResizeRows = false;
            this.dgInsurersPrices.BackgroundColor = System.Drawing.Color.White;
            this.dgInsurersPrices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgInsurersPrices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            this.dgInsurersPrices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgInsurersPrices.ColumnHeadersHeight = 30;
            this.dgInsurersPrices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgInsurersPrices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIsCheck,
            this.ColumnInsurerId,
            this.ColumnInsurerTitle,
            this.ColumnFreePrice,
            this.ColumnInsurerPrice});
            this.dgInsurersPrices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInsurersPrices.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgInsurersPrices.EnableHeadersVisualStyles = false;
            this.dgInsurersPrices.GridColor = System.Drawing.Color.White;
            this.dgInsurersPrices.Location = new System.Drawing.Point(3, 106);
            this.dgInsurersPrices.MultiSelect = false;
            this.dgInsurersPrices.Name = "dgInsurersPrices";
            this.dgInsurersPrices.ReadOnly = true;
            this.dgInsurersPrices.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgInsurersPrices.RowHeadersVisible = false;
            this.dgInsurersPrices.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dgInsurersPrices.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir FD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgInsurersPrices.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgInsurersPrices.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dgInsurersPrices.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgInsurersPrices.RowTemplate.Height = 40;
            this.dgInsurersPrices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgInsurersPrices.Size = new System.Drawing.Size(837, 325);
            this.dgInsurersPrices.TabIndex = 170;
            this.dgInsurersPrices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInsurersPrices_CellClick);
            this.dgInsurersPrices.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInsurersPrices_CellContentClick);
            this.dgInsurersPrices.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dgInsurersPrices_KeyDown);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.Controls.Add(this.datePnl);
            this.panel3.Controls.Add(this.okBtn);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 507);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(837, 64);
            this.panel3.TabIndex = 26;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.serviceFreePriceTxt);
            this.panel4.Controls.Add(this.serviceTitleTxt);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.label6);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(3, 3);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(837, 97);
            this.panel4.TabIndex = 27;
            // 
            // serviceFreePriceTxt
            // 
            this.serviceFreePriceTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceFreePriceTxt.BackColor = System.Drawing.Color.WhiteSmoke;
            this.serviceFreePriceTxt.Font = new System.Drawing.Font("Vazir FD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceFreePriceTxt.ForeColor = System.Drawing.Color.Crimson;
            this.serviceFreePriceTxt.Location = new System.Drawing.Point(516, 53);
            this.serviceFreePriceTxt.Name = "serviceFreePriceTxt";
            this.serviceFreePriceTxt.Padding = new System.Windows.Forms.Padding(5);
            this.serviceFreePriceTxt.Size = new System.Drawing.Size(217, 32);
            this.serviceFreePriceTxt.TabIndex = 173;
            this.serviceFreePriceTxt.Text = "0";
            this.serviceFreePriceTxt.TextChanged += new System.EventHandler(this.serviceFreePriceTxt_TextChanged);
            // 
            // datePnl
            // 
            this.datePnl.Controls.Add(this.DefineDateTxt);
            this.datePnl.Controls.Add(this.RunDateTxt);
            this.datePnl.Controls.Add(this.label8);
            this.datePnl.Controls.Add(this.label9);
            this.datePnl.Dock = System.Windows.Forms.DockStyle.Right;
            this.datePnl.Location = new System.Drawing.Point(324, 0);
            this.datePnl.Name = "datePnl";
            this.datePnl.Size = new System.Drawing.Size(513, 64);
            this.datePnl.TabIndex = 126;
            this.datePnl.Visible = false;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(422, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 22);
            this.label8.TabIndex = 125;
            this.label8.Text = "تاریخ تعریف :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.DimGray;
            this.label9.Location = new System.Drawing.Point(174, 21);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 22);
            this.label9.TabIndex = 126;
            this.label9.Text = "تاریخ اجرا :";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(724, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 20);
            this.label1.TabIndex = 174;
            this.label1.Text = "قیمت آزاد :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ColumnIsCheck
            // 
            this.ColumnIsCheck.FalseValue = "False";
            this.ColumnIsCheck.HeaderText = "";
            this.ColumnIsCheck.Name = "ColumnIsCheck";
            this.ColumnIsCheck.ReadOnly = true;
            this.ColumnIsCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIsCheck.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIsCheck.TrueValue = "True";
            this.ColumnIsCheck.Width = 50;
            // 
            // ColumnInsurerId
            // 
            this.ColumnInsurerId.DataPropertyName = "InsurerId";
            this.ColumnInsurerId.HeaderText = "InsurerId";
            this.ColumnInsurerId.Name = "ColumnInsurerId";
            this.ColumnInsurerId.ReadOnly = true;
            this.ColumnInsurerId.Visible = false;
            this.ColumnInsurerId.Width = 20;
            // 
            // ColumnInsurerTitle
            // 
            this.ColumnInsurerTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnInsurerTitle.DataPropertyName = "InsurerTitle";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ColumnInsurerTitle.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnInsurerTitle.HeaderText = "بیمه گر";
            this.ColumnInsurerTitle.Name = "ColumnInsurerTitle";
            this.ColumnInsurerTitle.ReadOnly = true;
            // 
            // ColumnFreePrice
            // 
            this.ColumnFreePrice.DataPropertyName = "FreePrice";
            this.ColumnFreePrice.HeaderText = "قیمت آزاد";
            this.ColumnFreePrice.Name = "ColumnFreePrice";
            this.ColumnFreePrice.ReadOnly = true;
            this.ColumnFreePrice.Width = 200;
            // 
            // ColumnInsurerPrice
            // 
            this.ColumnInsurerPrice.DataPropertyName = "InsurerPrice";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "N0";
            this.ColumnInsurerPrice.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnInsurerPrice.HeaderText = "قیمت بیمه";
            this.ColumnInsurerPrice.Name = "ColumnInsurerPrice";
            this.ColumnInsurerPrice.ReadOnly = true;
            this.ColumnInsurerPrice.Width = 200;
            // 
            // InsurerFreePriceTxt
            // 
            this.InsurerFreePriceTxt.AllowPoint = false;
            this.InsurerFreePriceTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsurerFreePriceTxt.Font = new System.Drawing.Font("Vazir FD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsurerFreePriceTxt.Location = new System.Drawing.Point(521, 17);
            this.InsurerFreePriceTxt.MaxLength = 18;
            this.InsurerFreePriceTxt.MinLength = 0;
            this.InsurerFreePriceTxt.MoveToNextOnEnterKey = true;
            this.InsurerFreePriceTxt.Name = "InsurerFreePriceTxt";
            this.InsurerFreePriceTxt.ShowToolTip = true;
            this.InsurerFreePriceTxt.Size = new System.Drawing.Size(200, 31);
            this.InsurerFreePriceTxt.TabIndex = 175;
            this.InsurerFreePriceTxt.Text = "0";
            this.InsurerFreePriceTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InsurerFreePriceTxt.TextChanged += new System.EventHandler(this.FreePriceTxt_TextChanged);
            // 
            // InsurerPriceTxt
            // 
            this.InsurerPriceTxt.AllowPoint = false;
            this.InsurerPriceTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsurerPriceTxt.Font = new System.Drawing.Font("Vazir FD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsurerPriceTxt.Location = new System.Drawing.Point(119, 17);
            this.InsurerPriceTxt.MaxLength = 18;
            this.InsurerPriceTxt.MinLength = 0;
            this.InsurerPriceTxt.MoveToNextOnEnterKey = true;
            this.InsurerPriceTxt.Name = "InsurerPriceTxt";
            this.InsurerPriceTxt.ShowToolTip = true;
            this.InsurerPriceTxt.Size = new System.Drawing.Size(200, 31);
            this.InsurerPriceTxt.TabIndex = 173;
            this.InsurerPriceTxt.Text = "0";
            this.InsurerPriceTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InsurerPriceTxt.TextChanged += new System.EventHandler(this.InsurerPriceTxt_TextChanged);
            // 
            // DefineDateTxt
            // 
            this.DefineDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DefineDateTxt.BackColor = System.Drawing.Color.White;
            this.DefineDateTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DefineDateTxt.Location = new System.Drawing.Point(270, 19);
            this.DefineDateTxt.Name = "DefineDateTxt";
            this.DefineDateTxt.ShowTime = false;
            this.DefineDateTxt.Size = new System.Drawing.Size(150, 25);
            this.DefineDateTxt.TabIndex = 127;
            this.DefineDateTxt.Text = "persianDateTimePicker1";
            // 
            // RunDateTxt
            // 
            this.RunDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.RunDateTxt.BackColor = System.Drawing.Color.White;
            this.RunDateTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RunDateTxt.Location = new System.Drawing.Point(22, 19);
            this.RunDateTxt.Name = "RunDateTxt";
            this.RunDateTxt.ShowTime = false;
            this.RunDateTxt.Size = new System.Drawing.Size(150, 25);
            this.RunDateTxt.TabIndex = 128;
            this.RunDateTxt.Text = "persianDateTimePicker1";
            // 
            // ServiceInsurersPriceDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(873, 604);
            this.Controls.Add(this.tableLayoutPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ServiceInsurersPriceDefine";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  تعریف قیمت بیمه گرها برای ی خدمت";
            this.Load += new System.EventHandler(this.ServiceInsurersPriceDefine_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgInsurersPrices)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.datePnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label serviceTitleTxt;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label2;
        private UserControls.CurrencyTextBox InsurerPriceTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridView dgInsurersPrices;
        private System.Windows.Forms.Label serviceFreePriceTxt;
        private UserControls.CurrencyTextBox InsurerFreePriceTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel datePnl;
        private UserControls.PersianDateTimePicker DefineDateTxt;
        private UserControls.PersianDateTimePicker RunDateTxt;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInsurerId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInsurerTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFreePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInsurerPrice;
    }
}