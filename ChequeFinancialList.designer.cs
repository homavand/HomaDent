namespace Dentistry
{
    partial class ChequeFinancialList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgCheques = new System.Windows.Forms.DataGridView();
            this.ColumnChequeTypeTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSolarDateOfIssuance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnSolarDateOfMaturity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChequeAmount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChequeStatusTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNumberOfCheque = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnBankTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPatientFinancialId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnCostId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChequeTypeId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnChequeStatusId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingNavigatorCheque = new System.Windows.Forms.BindingNavigator(this.components);
            this.ButtonNew = new System.Windows.Forms.ToolStripButton();
            this.ButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBox3 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripTextBox4 = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox1 = new Dentistry.UserControls.ExPanel();
            this.lblTaDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ToDateTxt = new Dentistry.UserControls.PersianDateTimePicker();
            this.FromDateTxt = new Dentistry.UserControls.PersianDateTimePicker();
            this.searchBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.DateOfMaturityRdo = new System.Windows.Forms.RadioButton();
            this.DateOfIssuanceRdo = new System.Windows.Forms.RadioButton();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.chequeActionTypeCbo = new System.Windows.Forms.ComboBox();
            this.PanelX2 = new Dentistry.UserControls.ExPanel();
            this.labelPas_label = new System.Windows.Forms.Label();
            this.CashChequeInTxt = new Dentistry.UserControls.MoneyLabel();
            this.BouncedChequeOutTxt = new Dentistry.UserControls.MoneyLabel();
            this.label11 = new System.Windows.Forms.Label();
            this.CashChequeOutTxt = new Dentistry.UserControls.MoneyLabel();
            this.label9 = new System.Windows.Forms.Label();
            this.NoneChequeOutTxt = new Dentistry.UserControls.MoneyLabel();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BouncedChequeInTxt = new Dentistry.UserControls.MoneyLabel();
            this.labelBargasht_label = new System.Windows.Forms.Label();
            this.NoneChequeInTxt = new Dentistry.UserControls.MoneyLabel();
            this.labelNoPas_label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgCheques)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorCheque)).BeginInit();
            this.bindingNavigatorCheque.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.PanelX2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgCheques
            // 
            this.dgCheques.AllowUserToAddRows = false;
            this.dgCheques.AllowUserToDeleteRows = false;
            this.dgCheques.AllowUserToResizeColumns = false;
            this.dgCheques.AllowUserToResizeRows = false;
            this.dgCheques.BackgroundColor = System.Drawing.Color.White;
            this.dgCheques.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgCheques.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCheques.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgCheques.ColumnHeadersHeight = 30;
            this.dgCheques.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgCheques.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnChequeTypeTitle,
            this.ColumnSolarDateOfIssuance,
            this.ColumnSolarDateOfMaturity,
            this.ColumnChequeAmount,
            this.ColumnChequeStatusTitle,
            this.ColumnNumberOfCheque,
            this.ColumnBankTitle,
            this.ColumnTitle,
            this.ColumnComment,
            this.ColumnPatientFinancialId,
            this.ColumnCostId,
            this.ColumnChequeTypeId,
            this.ColumnChequeStatusId,
            this.ColumnIsDeleted});
            this.dgCheques.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgCheques.EnableHeadersVisualStyles = false;
            this.dgCheques.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.dgCheques.Location = new System.Drawing.Point(0, 0);
            this.dgCheques.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dgCheques.MultiSelect = false;
            this.dgCheques.Name = "dgCheques";
            this.dgCheques.ReadOnly = true;
            this.dgCheques.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCheques.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.dgCheques.RowHeadersVisible = false;
            this.dgCheques.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgCheques.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgCheques.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dgCheques.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgCheques.RowTemplate.Height = 30;
            this.dgCheques.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCheques.Size = new System.Drawing.Size(1224, 534);
            this.dgCheques.TabIndex = 5;
            this.dgCheques.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewCheque_CellDoubleClick);
            this.dgCheques.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewCheque_CellFormatting);
            this.dgCheques.SelectionChanged += new System.EventHandler(this.dataGridViewCheque_SelectionChanged);
            // 
            // ColumnChequeTypeTitle
            // 
            this.ColumnChequeTypeTitle.DataPropertyName = "ChequeTypeTitle";
            this.ColumnChequeTypeTitle.HeaderText = "نوع عملیات";
            this.ColumnChequeTypeTitle.Name = "ColumnChequeTypeTitle";
            this.ColumnChequeTypeTitle.ReadOnly = true;
            // 
            // ColumnSolarDateOfIssuance
            // 
            this.ColumnSolarDateOfIssuance.DataPropertyName = "SolarDateOfIssuance";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.ColumnSolarDateOfIssuance.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnSolarDateOfIssuance.HeaderText = "تاریخ صدور";
            this.ColumnSolarDateOfIssuance.Name = "ColumnSolarDateOfIssuance";
            this.ColumnSolarDateOfIssuance.ReadOnly = true;
            // 
            // ColumnSolarDateOfMaturity
            // 
            this.ColumnSolarDateOfMaturity.DataPropertyName = "SolarDateOfMaturity";
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.ColumnSolarDateOfMaturity.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnSolarDateOfMaturity.HeaderText = "تاریخ سررسید";
            this.ColumnSolarDateOfMaturity.Name = "ColumnSolarDateOfMaturity";
            this.ColumnSolarDateOfMaturity.ReadOnly = true;
            // 
            // ColumnChequeAmount
            // 
            this.ColumnChequeAmount.DataPropertyName = "Amount";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Vazir FD", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.ColumnChequeAmount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnChequeAmount.HeaderText = "مبلغ چک";
            this.ColumnChequeAmount.Name = "ColumnChequeAmount";
            this.ColumnChequeAmount.ReadOnly = true;
            this.ColumnChequeAmount.Width = 150;
            // 
            // ColumnChequeStatusTitle
            // 
            this.ColumnChequeStatusTitle.DataPropertyName = "ChequeStatusTitle";
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnChequeStatusTitle.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnChequeStatusTitle.HeaderText = "وضعیت چک";
            this.ColumnChequeStatusTitle.Name = "ColumnChequeStatusTitle";
            this.ColumnChequeStatusTitle.ReadOnly = true;
            this.ColumnChequeStatusTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // ColumnNumberOfCheque
            // 
            this.ColumnNumberOfCheque.DataPropertyName = "ChequeNumber";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            dataGridViewCellStyle6.Format = "C0";
            dataGridViewCellStyle6.NullValue = null;
            this.ColumnNumberOfCheque.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnNumberOfCheque.HeaderText = "شماره چک";
            this.ColumnNumberOfCheque.Name = "ColumnNumberOfCheque";
            this.ColumnNumberOfCheque.ReadOnly = true;
            this.ColumnNumberOfCheque.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnBankTitle
            // 
            this.ColumnBankTitle.DataPropertyName = "BankTitle";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnBankTitle.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnBankTitle.HeaderText = "بانک";
            this.ColumnBankTitle.Name = "ColumnBankTitle";
            this.ColumnBankTitle.ReadOnly = true;
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.DataPropertyName = "Title";
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnTitle.DefaultCellStyle = dataGridViewCellStyle8;
            this.ColumnTitle.HeaderText = "عنوان";
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.ReadOnly = true;
            this.ColumnTitle.Width = 250;
            // 
            // ColumnComment
            // 
            this.ColumnComment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnComment.DataPropertyName = "Comment";
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnComment.DefaultCellStyle = dataGridViewCellStyle9;
            this.ColumnComment.HeaderText = "توضیحات";
            this.ColumnComment.Name = "ColumnComment";
            this.ColumnComment.ReadOnly = true;
            this.ColumnComment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnPatientFinancialId
            // 
            this.ColumnPatientFinancialId.DataPropertyName = "PatientFinancialId";
            this.ColumnPatientFinancialId.HeaderText = "PatientFinancialId";
            this.ColumnPatientFinancialId.Name = "ColumnPatientFinancialId";
            this.ColumnPatientFinancialId.ReadOnly = true;
            this.ColumnPatientFinancialId.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnPatientFinancialId.Visible = false;
            // 
            // ColumnCostId
            // 
            this.ColumnCostId.DataPropertyName = "CostId";
            this.ColumnCostId.HeaderText = "CostId";
            this.ColumnCostId.Name = "ColumnCostId";
            this.ColumnCostId.ReadOnly = true;
            this.ColumnCostId.Visible = false;
            // 
            // ColumnChequeTypeId
            // 
            this.ColumnChequeTypeId.DataPropertyName = "ChequeTypeId";
            this.ColumnChequeTypeId.HeaderText = "ChequeTypeId";
            this.ColumnChequeTypeId.Name = "ColumnChequeTypeId";
            this.ColumnChequeTypeId.ReadOnly = true;
            this.ColumnChequeTypeId.Visible = false;
            // 
            // ColumnChequeStatusId
            // 
            this.ColumnChequeStatusId.DataPropertyName = "ChequeStatusId";
            this.ColumnChequeStatusId.HeaderText = "ChequeStatusId";
            this.ColumnChequeStatusId.Name = "ColumnChequeStatusId";
            this.ColumnChequeStatusId.ReadOnly = true;
            this.ColumnChequeStatusId.Visible = false;
            // 
            // ColumnIsDeleted
            // 
            this.ColumnIsDeleted.DataPropertyName = "IsDeleted";
            this.ColumnIsDeleted.HeaderText = "IsDeleted";
            this.ColumnIsDeleted.Name = "ColumnIsDeleted";
            this.ColumnIsDeleted.ReadOnly = true;
            this.ColumnIsDeleted.Visible = false;
            // 
            // bindingNavigatorCheque
            // 
            this.bindingNavigatorCheque.AddNewItem = null;
            this.bindingNavigatorCheque.AutoSize = false;
            this.bindingNavigatorCheque.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.bindingNavigatorCheque.CountItem = null;
            this.bindingNavigatorCheque.DeleteItem = null;
            this.bindingNavigatorCheque.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigatorCheque.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingNavigatorCheque.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigatorCheque.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNew,
            this.ButtonEdit});
            this.bindingNavigatorCheque.Location = new System.Drawing.Point(0, 534);
            this.bindingNavigatorCheque.MoveFirstItem = null;
            this.bindingNavigatorCheque.MoveLastItem = null;
            this.bindingNavigatorCheque.MoveNextItem = null;
            this.bindingNavigatorCheque.MovePreviousItem = null;
            this.bindingNavigatorCheque.Name = "bindingNavigatorCheque";
            this.bindingNavigatorCheque.Padding = new System.Windows.Forms.Padding(5);
            this.bindingNavigatorCheque.PositionItem = null;
            this.bindingNavigatorCheque.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bindingNavigatorCheque.Size = new System.Drawing.Size(1224, 40);
            this.bindingNavigatorCheque.TabIndex = 4;
            this.bindingNavigatorCheque.Text = "bindingNavigator1";
            // 
            // ButtonNew
            // 
            this.ButtonNew.AutoSize = false;
            this.ButtonNew.Image = global::Dentistry.Properties.Resources.NewDocument;
            this.ButtonNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(120, 29);
            this.ButtonNew.Text = "جدید";
            this.ButtonNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonNew.Visible = false;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.AutoSize = false;
            this.ButtonEdit.Image = global::Dentistry.Properties.Resources.pencil_005_16xLG;
            this.ButtonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(200, 29);
            this.ButtonEdit.Text = "ویرایش - تغییر وضعیت چک";
            this.ButtonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // toolStripTextBox3
            // 
            this.toolStripTextBox3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox3.Name = "toolStripTextBox3";
            this.toolStripTextBox3.Size = new System.Drawing.Size(100, 21);
            // 
            // toolStripTextBox4
            // 
            this.toolStripTextBox4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.toolStripTextBox4.Name = "toolStripTextBox4";
            this.toolStripTextBox4.Size = new System.Drawing.Size(100, 21);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.BackColor = System.Drawing.SystemColors.Control;
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(165, 6);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgCheques);
            this.panel1.Controls.Add(this.bindingNavigatorCheque);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(3, 73);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1224, 574);
            this.panel1.TabIndex = 10;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.groupBox1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PanelX2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(10, 10);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1230, 750);
            this.tableLayoutPanel1.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.BorderColor = System.Drawing.Color.Silver;
            this.groupBox1.Controls.Add(this.lblTaDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.ToDateTxt);
            this.groupBox1.Controls.Add(this.FromDateTxt);
            this.groupBox1.Controls.Add(this.searchBtn);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.DateOfMaturityRdo);
            this.groupBox1.Controls.Add(this.DateOfIssuanceRdo);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.chequeActionTypeCbo);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1224, 64);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lblTaDate
            // 
            this.lblTaDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTaDate.AutoSize = true;
            this.lblTaDate.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaDate.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.lblTaDate.Location = new System.Drawing.Point(456, 22);
            this.lblTaDate.Name = "lblTaDate";
            this.lblTaDate.Size = new System.Drawing.Size(21, 20);
            this.lblTaDate.TabIndex = 182;
            this.lblTaDate.Text = "تا ";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label3.Location = new System.Drawing.Point(637, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 20);
            this.label3.TabIndex = 181;
            this.label3.Text = "از ";
            // 
            // ToDateTxt
            // 
            this.ToDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToDateTxt.BackColor = System.Drawing.Color.White;
            this.ToDateTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.ToDateTxt.Location = new System.Drawing.Point(303, 19);
            this.ToDateTxt.Name = "ToDateTxt";
            this.ToDateTxt.ShowTime = false;
            this.ToDateTxt.Size = new System.Drawing.Size(150, 25);
            this.ToDateTxt.TabIndex = 180;
            this.ToDateTxt.Text = "persianDateTimePicker1";
            // 
            // FromDateTxt
            // 
            this.FromDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.FromDateTxt.BackColor = System.Drawing.Color.White;
            this.FromDateTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.FromDateTxt.Location = new System.Drawing.Point(484, 19);
            this.FromDateTxt.Name = "FromDateTxt";
            this.FromDateTxt.ShowTime = false;
            this.FromDateTxt.Size = new System.Drawing.Size(150, 25);
            this.FromDateTxt.TabIndex = 179;
            this.FromDateTxt.Text = "persianDateTimePicker1";
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.White;
            this.searchBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.searchBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.searchBtn.Location = new System.Drawing.Point(16, 18);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(150, 30);
            this.searchBtn.TabIndex = 170;
            this.searchBtn.Text = "جستجو";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.White;
            this.label6.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(1133, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(83, 20);
            this.label6.TabIndex = 40;
            this.label6.Text = "نوع عملیات : ";
            // 
            // DateOfMaturityRdo
            // 
            this.DateOfMaturityRdo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateOfMaturityRdo.AutoSize = true;
            this.DateOfMaturityRdo.Checked = true;
            this.DateOfMaturityRdo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateOfMaturityRdo.Location = new System.Drawing.Point(677, 21);
            this.DateOfMaturityRdo.Name = "DateOfMaturityRdo";
            this.DateOfMaturityRdo.Size = new System.Drawing.Size(99, 24);
            this.DateOfMaturityRdo.TabIndex = 39;
            this.DateOfMaturityRdo.TabStop = true;
            this.DateOfMaturityRdo.Text = "تاریخ سررسید";
            this.DateOfMaturityRdo.UseVisualStyleBackColor = true;
            // 
            // DateOfIssuanceRdo
            // 
            this.DateOfIssuanceRdo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DateOfIssuanceRdo.AutoSize = true;
            this.DateOfIssuanceRdo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DateOfIssuanceRdo.Location = new System.Drawing.Point(778, 21);
            this.DateOfIssuanceRdo.Name = "DateOfIssuanceRdo";
            this.DateOfIssuanceRdo.Size = new System.Drawing.Size(86, 24);
            this.DateOfIssuanceRdo.TabIndex = 38;
            this.DateOfIssuanceRdo.Text = "تاریخ صدور";
            this.DateOfIssuanceRdo.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1733, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(62, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "نوع نمایش :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1733, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "بر اساس :";
            // 
            // chequeActionTypeCbo
            // 
            this.chequeActionTypeCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chequeActionTypeCbo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chequeActionTypeCbo.FormattingEnabled = true;
            this.chequeActionTypeCbo.Location = new System.Drawing.Point(932, 19);
            this.chequeActionTypeCbo.Name = "chequeActionTypeCbo";
            this.chequeActionTypeCbo.Size = new System.Drawing.Size(200, 28);
            this.chequeActionTypeCbo.TabIndex = 1;
            this.chequeActionTypeCbo.SelectedIndexChanged += new System.EventHandler(this.cmbActionType_SelectedIndexChanged);
            this.chequeActionTypeCbo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cmbActionType_KeyPress);
            // 
            // PanelX2
            // 
            this.PanelX2.BackColor = System.Drawing.Color.White;
            this.PanelX2.BorderColor = System.Drawing.Color.Silver;
            this.PanelX2.Controls.Add(this.labelPas_label);
            this.PanelX2.Controls.Add(this.CashChequeInTxt);
            this.PanelX2.Controls.Add(this.BouncedChequeOutTxt);
            this.PanelX2.Controls.Add(this.label11);
            this.PanelX2.Controls.Add(this.CashChequeOutTxt);
            this.PanelX2.Controls.Add(this.label9);
            this.PanelX2.Controls.Add(this.NoneChequeOutTxt);
            this.PanelX2.Controls.Add(this.label10);
            this.PanelX2.Controls.Add(this.label8);
            this.PanelX2.Controls.Add(this.label7);
            this.PanelX2.Controls.Add(this.BouncedChequeInTxt);
            this.PanelX2.Controls.Add(this.labelBargasht_label);
            this.PanelX2.Controls.Add(this.NoneChequeInTxt);
            this.PanelX2.Controls.Add(this.labelNoPas_label);
            this.PanelX2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelX2.Location = new System.Drawing.Point(3, 653);
            this.PanelX2.Name = "PanelX2";
            this.PanelX2.Size = new System.Drawing.Size(1224, 94);
            this.PanelX2.TabIndex = 8;
            this.PanelX2.TabStop = false;
            // 
            // labelPas_label
            // 
            this.labelPas_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPas_label.AutoSize = true;
            this.labelPas_label.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPas_label.Location = new System.Drawing.Point(533, 18);
            this.labelPas_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPas_label.Name = "labelPas_label";
            this.labelPas_label.Size = new System.Drawing.Size(146, 20);
            this.labelPas_label.TabIndex = 45;
            this.labelPas_label.Text = "جمع چک های پاس شده :";
            // 
            // CashChequeInTxt
            // 
            this.CashChequeInTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CashChequeInTxt.BackColor = System.Drawing.Color.Transparent;
            this.CashChequeInTxt.CurrencyGroupSeparator = ",";
            this.CashChequeInTxt.CurrencySymbol = "";
            this.CashChequeInTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashChequeInTxt.ForeColor = System.Drawing.Color.DarkGreen;
            this.CashChequeInTxt.Location = new System.Drawing.Point(359, 19);
            this.CashChequeInTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CashChequeInTxt.Name = "CashChequeInTxt";
            this.CashChequeInTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CashChequeInTxt.Size = new System.Drawing.Size(170, 18);
            this.CashChequeInTxt.TabIndex = 46;
            // 
            // BouncedChequeOutTxt
            // 
            this.BouncedChequeOutTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BouncedChequeOutTxt.BackColor = System.Drawing.Color.Transparent;
            this.BouncedChequeOutTxt.CurrencyGroupSeparator = ",";
            this.BouncedChequeOutTxt.CurrencySymbol = "";
            this.BouncedChequeOutTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BouncedChequeOutTxt.ForeColor = System.Drawing.Color.DarkRed;
            this.BouncedChequeOutTxt.Location = new System.Drawing.Point(33, 59);
            this.BouncedChequeOutTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BouncedChequeOutTxt.Name = "BouncedChequeOutTxt";
            this.BouncedChequeOutTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BouncedChequeOutTxt.Size = new System.Drawing.Size(170, 18);
            this.BouncedChequeOutTxt.TabIndex = 58;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(533, 58);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(146, 20);
            this.label11.TabIndex = 53;
            this.label11.Text = "جمع چک های پاس شده :";
            // 
            // CashChequeOutTxt
            // 
            this.CashChequeOutTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CashChequeOutTxt.BackColor = System.Drawing.Color.Transparent;
            this.CashChequeOutTxt.CurrencyGroupSeparator = ",";
            this.CashChequeOutTxt.CurrencySymbol = "";
            this.CashChequeOutTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CashChequeOutTxt.ForeColor = System.Drawing.Color.DarkGreen;
            this.CashChequeOutTxt.Location = new System.Drawing.Point(359, 59);
            this.CashChequeOutTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CashChequeOutTxt.Name = "CashChequeOutTxt";
            this.CashChequeOutTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.CashChequeOutTxt.Size = new System.Drawing.Size(170, 18);
            this.CashChequeOutTxt.TabIndex = 54;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(207, 58);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 20);
            this.label9.TabIndex = 57;
            this.label9.Text = "جمع چک های برگشتی :";
            // 
            // NoneChequeOutTxt
            // 
            this.NoneChequeOutTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NoneChequeOutTxt.BackColor = System.Drawing.Color.Transparent;
            this.NoneChequeOutTxt.CurrencyGroupSeparator = ",";
            this.NoneChequeOutTxt.CurrencySymbol = "";
            this.NoneChequeOutTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoneChequeOutTxt.ForeColor = System.Drawing.Color.DarkBlue;
            this.NoneChequeOutTxt.Location = new System.Drawing.Point(708, 59);
            this.NoneChequeOutTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NoneChequeOutTxt.Name = "NoneChequeOutTxt";
            this.NoneChequeOutTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NoneChequeOutTxt.Size = new System.Drawing.Size(170, 18);
            this.NoneChequeOutTxt.TabIndex = 56;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(882, 58);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 20);
            this.label10.TabIndex = 55;
            this.label10.Text = " جمع چک های پاس نشده :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.BackColor = System.Drawing.Color.DeepPink;
            this.label8.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(1051, 52);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(165, 31);
            this.label8.TabIndex = 52;
            this.label8.Text = "برداشت از حساب";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.label7.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(1051, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(165, 31);
            this.label7.TabIndex = 51;
            this.label7.Text = "واریز به حساب";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BouncedChequeInTxt
            // 
            this.BouncedChequeInTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BouncedChequeInTxt.BackColor = System.Drawing.Color.Transparent;
            this.BouncedChequeInTxt.CurrencyGroupSeparator = ",";
            this.BouncedChequeInTxt.CurrencySymbol = "";
            this.BouncedChequeInTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BouncedChequeInTxt.ForeColor = System.Drawing.Color.DarkRed;
            this.BouncedChequeInTxt.Location = new System.Drawing.Point(33, 19);
            this.BouncedChequeInTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.BouncedChequeInTxt.Name = "BouncedChequeInTxt";
            this.BouncedChequeInTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.BouncedChequeInTxt.Size = new System.Drawing.Size(170, 18);
            this.BouncedChequeInTxt.TabIndex = 50;
            // 
            // labelBargasht_label
            // 
            this.labelBargasht_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelBargasht_label.AutoSize = true;
            this.labelBargasht_label.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBargasht_label.Location = new System.Drawing.Point(207, 18);
            this.labelBargasht_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBargasht_label.Name = "labelBargasht_label";
            this.labelBargasht_label.Size = new System.Drawing.Size(136, 20);
            this.labelBargasht_label.TabIndex = 49;
            this.labelBargasht_label.Text = "جمع چک های برگشتی :";
            // 
            // NoneChequeInTxt
            // 
            this.NoneChequeInTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.NoneChequeInTxt.BackColor = System.Drawing.Color.Transparent;
            this.NoneChequeInTxt.CurrencyGroupSeparator = ",";
            this.NoneChequeInTxt.CurrencySymbol = "";
            this.NoneChequeInTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NoneChequeInTxt.ForeColor = System.Drawing.Color.DarkBlue;
            this.NoneChequeInTxt.Location = new System.Drawing.Point(708, 19);
            this.NoneChequeInTxt.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.NoneChequeInTxt.Name = "NoneChequeInTxt";
            this.NoneChequeInTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.NoneChequeInTxt.Size = new System.Drawing.Size(170, 18);
            this.NoneChequeInTxt.TabIndex = 48;
            // 
            // labelNoPas_label
            // 
            this.labelNoPas_label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelNoPas_label.AutoSize = true;
            this.labelNoPas_label.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelNoPas_label.Location = new System.Drawing.Point(882, 18);
            this.labelNoPas_label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelNoPas_label.Name = "labelNoPas_label";
            this.labelNoPas_label.Size = new System.Drawing.Size(155, 20);
            this.labelNoPas_label.TabIndex = 47;
            this.labelNoPas_label.Text = " جمع چک های پاس نشده :";
            // 
            // ChequeFinancials
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1250, 770);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "ChequeFinancials";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Tag = "9";
            this.Text = "اطلاعات و  کنترل چک ها";
            this.Load += new System.EventHandler(this.ChequeControl_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.FormChequeControl_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgCheques)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorCheque)).EndInit();
            this.bindingNavigatorCheque.ResumeLayout(false);
            this.bindingNavigatorCheque.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.PanelX2.ResumeLayout(false);
            this.PanelX2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgCheques;
        private System.Windows.Forms.BindingNavigator bindingNavigatorCheque;
        private System.Windows.Forms.ToolStripButton ButtonNew;
        private System.Windows.Forms.ToolStripButton ButtonEdit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox3;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBox4;
        private UserControls.ExPanel groupBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox chequeActionTypeCbo;
        private UserControls.ExPanel  PanelX2;
        private UserControls.MoneyLabel CashChequeInTxt;
        private System.Windows.Forms.Label labelPas_label;
        private UserControls.MoneyLabel NoneChequeInTxt;
        private System.Windows.Forms.Label labelNoPas_label;
        private UserControls.MoneyLabel BouncedChequeInTxt;
        private System.Windows.Forms.Label labelBargasht_label;
        private System.Windows.Forms.RadioButton DateOfMaturityRdo;
        private System.Windows.Forms.RadioButton DateOfIssuanceRdo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private UserControls.MoneyLabel BouncedChequeOutTxt;
        private System.Windows.Forms.Label label9;
        private UserControls.MoneyLabel NoneChequeOutTxt;
        private System.Windows.Forms.Label label10;
        private UserControls.MoneyLabel CashChequeOutTxt;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblTaDate;
        private System.Windows.Forms.Label label3;
        private UserControls.PersianDateTimePicker ToDateTxt;
        private UserControls.PersianDateTimePicker FromDateTxt;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChequeTypeTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSolarDateOfIssuance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSolarDateOfMaturity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChequeAmount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChequeStatusTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNumberOfCheque;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnBankTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPatientFinancialId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnCostId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChequeTypeId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnChequeStatusId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIsDeleted;
    }
}