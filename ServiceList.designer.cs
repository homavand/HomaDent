namespace Dentistry
{
    partial class ServiceList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgServices = new System.Windows.Forms.DataGridView();
            this.ColumnServiceCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceFreePrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPriceDefineDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsDeletedPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnServiceId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsDeleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingNavigatorService = new System.Windows.Forms.BindingNavigator(this.components);
            this.ButtonNew = new System.Windows.Forms.ToolStripButton();
            this.ButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.ButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.ButtonServicePricing = new System.Windows.Forms.ToolStripButton();
            this.IsDeletedChk = new System.Windows.Forms.CheckBox();
            this.panelForm = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.serviceGroupTitleLbl = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.dgServiceGroup = new System.Windows.Forms.DataGridView();
            this.ColumnServiceGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceGroupColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnGroupColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceGroupTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceGroupIsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgServices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorService)).BeginInit();
            this.bindingNavigatorService.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgServiceGroup)).BeginInit();
            this.SuspendLayout();
            // 
            // dgServices
            // 
            this.dgServices.AllowUserToAddRows = false;
            this.dgServices.AllowUserToDeleteRows = false;
            this.dgServices.AllowUserToResizeColumns = false;
            this.dgServices.AllowUserToResizeRows = false;
            this.dgServices.BackgroundColor = System.Drawing.Color.White;
            this.dgServices.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgServices.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgServices.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgServices.ColumnHeadersHeight = 35;
            this.dgServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgServices.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnServiceCode,
            this.ColumnServiceTitle,
            this.ColumnColor,
            this.ColumnServiceFreePrice,
            this.ColumnPriceDefineDate,
            this.ColumnIsDeletedPic,
            this.ColumnServiceId,
            this.ColumnServiceColor,
            this.ColumnIsDeleted});
            this.dgServices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgServices.EnableHeadersVisualStyles = false;
            this.dgServices.GridColor = System.Drawing.Color.White;
            this.dgServices.Location = new System.Drawing.Point(0, 50);
            this.dgServices.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dgServices.MultiSelect = false;
            this.dgServices.Name = "dgServices";
            this.dgServices.ReadOnly = true;
            this.dgServices.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgServices.RowHeadersVisible = false;
            this.dgServices.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgServices.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgServices.RowTemplate.DefaultCellStyle.Padding = new System.Windows.Forms.Padding(5);
            this.dgServices.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dgServices.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgServices.RowTemplate.DividerHeight = 5;
            this.dgServices.RowTemplate.Height = 35;
            this.dgServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgServices.Size = new System.Drawing.Size(880, 420);
            this.dgServices.TabIndex = 5;
            this.dgServices.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewService_CellDoubleClick);
            this.dgServices.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridViewService_DataBindingComplete);
            this.dgServices.SelectionChanged += new System.EventHandler(this.dataGridViewService_SelectionChanged);
            // 
            // ColumnServiceCode
            // 
            this.ColumnServiceCode.DataPropertyName = "ServiceCode";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold);
            this.ColumnServiceCode.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnServiceCode.HeaderText = "کد خدمت";
            this.ColumnServiceCode.Name = "ColumnServiceCode";
            this.ColumnServiceCode.ReadOnly = true;
            this.ColumnServiceCode.Width = 150;
            // 
            // ColumnServiceTitle
            // 
            this.ColumnServiceTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnServiceTitle.DataPropertyName = "ServiceTitle";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold);
            this.ColumnServiceTitle.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColumnServiceTitle.HeaderText = "خدمت";
            this.ColumnServiceTitle.Name = "ColumnServiceTitle";
            this.ColumnServiceTitle.ReadOnly = true;
            // 
            // ColumnColor
            // 
            this.ColumnColor.HeaderText = "";
            this.ColumnColor.Name = "ColumnColor";
            this.ColumnColor.ReadOnly = true;
            this.ColumnColor.Width = 30;
            // 
            // ColumnServiceFreePrice
            // 
            this.ColumnServiceFreePrice.DataPropertyName = "ServiceFreePrice";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.ColumnServiceFreePrice.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColumnServiceFreePrice.HeaderText = "قیمت آزاد";
            this.ColumnServiceFreePrice.Name = "ColumnServiceFreePrice";
            this.ColumnServiceFreePrice.ReadOnly = true;
            this.ColumnServiceFreePrice.Width = 150;
            // 
            // ColumnPriceDefineDate
            // 
            this.ColumnPriceDefineDate.DataPropertyName = "PriceDefineDate";
            this.ColumnPriceDefineDate.HeaderText = "تاریخ قیمت دهی";
            this.ColumnPriceDefineDate.Name = "ColumnPriceDefineDate";
            this.ColumnPriceDefineDate.ReadOnly = true;
            this.ColumnPriceDefineDate.Width = 120;
            // 
            // ColumnIsDeletedPic
            // 
            this.ColumnIsDeletedPic.HeaderText = "فعال";
            this.ColumnIsDeletedPic.Name = "ColumnIsDeletedPic";
            this.ColumnIsDeletedPic.ReadOnly = true;
            this.ColumnIsDeletedPic.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIsDeletedPic.Width = 50;
            // 
            // ColumnServiceId
            // 
            this.ColumnServiceId.DataPropertyName = "ServiceId";
            this.ColumnServiceId.HeaderText = "ServiceId";
            this.ColumnServiceId.Name = "ColumnServiceId";
            this.ColumnServiceId.ReadOnly = true;
            this.ColumnServiceId.Visible = false;
            this.ColumnServiceId.Width = 20;
            // 
            // ColumnServiceColor
            // 
            this.ColumnServiceColor.DataPropertyName = "ServiceColor";
            this.ColumnServiceColor.HeaderText = "";
            this.ColumnServiceColor.Name = "ColumnServiceColor";
            this.ColumnServiceColor.ReadOnly = true;
            this.ColumnServiceColor.Visible = false;
            // 
            // ColumnIsDeleted
            // 
            this.ColumnIsDeleted.DataPropertyName = "IsDeleted";
            this.ColumnIsDeleted.HeaderText = "قابل رویت ";
            this.ColumnIsDeleted.Name = "ColumnIsDeleted";
            this.ColumnIsDeleted.ReadOnly = true;
            this.ColumnIsDeleted.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIsDeleted.Visible = false;
            this.ColumnIsDeleted.Width = 50;
            // 
            // bindingNavigatorService
            // 
            this.bindingNavigatorService.AddNewItem = null;
            this.bindingNavigatorService.AutoSize = false;
            this.bindingNavigatorService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.bindingNavigatorService.CountItem = null;
            this.bindingNavigatorService.DeleteItem = null;
            this.bindingNavigatorService.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigatorService.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.bindingNavigatorService.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigatorService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNew,
            this.ButtonEdit,
            this.ButtonDelete,
            this.ButtonServicePricing});
            this.bindingNavigatorService.Location = new System.Drawing.Point(0, 470);
            this.bindingNavigatorService.MoveFirstItem = null;
            this.bindingNavigatorService.MoveLastItem = null;
            this.bindingNavigatorService.MoveNextItem = null;
            this.bindingNavigatorService.MovePreviousItem = null;
            this.bindingNavigatorService.Name = "bindingNavigatorService";
            this.bindingNavigatorService.PositionItem = null;
            this.bindingNavigatorService.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bindingNavigatorService.Size = new System.Drawing.Size(880, 40);
            this.bindingNavigatorService.TabIndex = 4;
            this.bindingNavigatorService.Text = "bindingNavigator1";
            // 
            // ButtonNew
            // 
            this.ButtonNew.AutoSize = false;
            this.ButtonNew.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNew.Image = global::Dentistry.Properties.Resources.NewDocument;
            this.ButtonNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(100, 27);
            this.ButtonNew.Text = "جدید";
            this.ButtonNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.AutoSize = false;
            this.ButtonEdit.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEdit.Image = global::Dentistry.Properties.Resources.pencil_005_16xLG;
            this.ButtonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(100, 27);
            this.ButtonEdit.Text = "ویرایش";
            this.ButtonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.AutoSize = false;
            this.ButtonDelete.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDelete.Image = global::Dentistry.Properties.Resources.remove24;
            this.ButtonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(100, 27);
            this.ButtonDelete.Text = "حذف";
            this.ButtonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonServicePricing
            // 
            this.ButtonServicePricing.AutoSize = false;
            this.ButtonServicePricing.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonServicePricing.Image = global::Dentistry.Properties.Resources.UniformGridElement_10696;
            this.ButtonServicePricing.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonServicePricing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonServicePricing.Name = "ButtonServicePricing";
            this.ButtonServicePricing.Size = new System.Drawing.Size(200, 27);
            this.ButtonServicePricing.Text = "تعرفه بیمه ای خدمات";
            this.ButtonServicePricing.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonServicePricing.Click += new System.EventHandler(this.ButtonServicePricing_Click);
            // 
            // IsDeletedChk
            // 
            this.IsDeletedChk.AutoSize = true;
            this.IsDeletedChk.BackColor = System.Drawing.Color.LavenderBlush;
            this.IsDeletedChk.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsDeletedChk.Location = new System.Drawing.Point(20, 11);
            this.IsDeletedChk.Name = "IsDeletedChk";
            this.IsDeletedChk.Padding = new System.Windows.Forms.Padding(2);
            this.IsDeletedChk.Size = new System.Drawing.Size(199, 28);
            this.IsDeletedChk.TabIndex = 35;
            this.IsDeletedChk.Text = "نمایش موارد حذف شده           ";
            this.IsDeletedChk.UseVisualStyleBackColor = false;
            this.IsDeletedChk.CheckedChanged += new System.EventHandler(this.IsDeletedChk_CheckedChanged);
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelForm.Controls.Add(this.tableLayoutPanel1);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(15);
            this.panelForm.Size = new System.Drawing.Size(1126, 546);
            this.panelForm.TabIndex = 2;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel3, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1096, 516);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgServices);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.bindingNavigatorService);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(3, 3);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(880, 510);
            this.panel3.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.serviceGroupTitleLbl);
            this.panel2.Controls.Add(this.IsDeletedChk);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(880, 50);
            this.panel2.TabIndex = 0;
            // 
            // serviceGroupTitleLbl
            // 
            this.serviceGroupTitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceGroupTitleLbl.BackColor = System.Drawing.Color.Transparent;
            this.serviceGroupTitleLbl.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceGroupTitleLbl.Location = new System.Drawing.Point(563, 10);
            this.serviceGroupTitleLbl.Name = "serviceGroupTitleLbl";
            this.serviceGroupTitleLbl.Padding = new System.Windows.Forms.Padding(5);
            this.serviceGroupTitleLbl.Size = new System.Drawing.Size(311, 28);
            this.serviceGroupTitleLbl.TabIndex = 170;
            this.serviceGroupTitleLbl.Text = "...";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(899, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(194, 510);
            this.panel1.TabIndex = 9;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.Controls.Add(this.dgServiceGroup);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(0, 50);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(7);
            this.panel4.Size = new System.Drawing.Size(194, 460);
            this.panel4.TabIndex = 172;
            // 
            // dgServiceGroup
            // 
            this.dgServiceGroup.AllowUserToAddRows = false;
            this.dgServiceGroup.AllowUserToDeleteRows = false;
            this.dgServiceGroup.AllowUserToResizeColumns = false;
            this.dgServiceGroup.AllowUserToResizeRows = false;
            this.dgServiceGroup.BackgroundColor = System.Drawing.Color.White;
            this.dgServiceGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgServiceGroup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgServiceGroup.ColumnHeadersHeight = 30;
            this.dgServiceGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgServiceGroup.ColumnHeadersVisible = false;
            this.dgServiceGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnServiceGroupId,
            this.ColumnServiceGroupColor,
            this.ColumnGroupColor,
            this.ColumnServiceGroupTitle,
            this.ColumnServiceGroupIsDeleted});
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgServiceGroup.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgServiceGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgServiceGroup.EnableHeadersVisualStyles = false;
            this.dgServiceGroup.GridColor = System.Drawing.Color.White;
            this.dgServiceGroup.Location = new System.Drawing.Point(7, 7);
            this.dgServiceGroup.MultiSelect = false;
            this.dgServiceGroup.Name = "dgServiceGroup";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgServiceGroup.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgServiceGroup.RowHeadersVisible = false;
            this.dgServiceGroup.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgServiceGroup.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir", 9.5F);
            this.dgServiceGroup.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgServiceGroup.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dgServiceGroup.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgServiceGroup.RowTemplate.DividerHeight = 5;
            this.dgServiceGroup.RowTemplate.Height = 35;
            this.dgServiceGroup.RowTemplate.ReadOnly = true;
            this.dgServiceGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgServiceGroup.Size = new System.Drawing.Size(180, 446);
            this.dgServiceGroup.TabIndex = 168;
            this.dgServiceGroup.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgServiceGroup_CellFormatting);
            // 
            // ColumnServiceGroupId
            // 
            this.ColumnServiceGroupId.DataPropertyName = "Id";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnServiceGroupId.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnServiceGroupId.HeaderText = "Id";
            this.ColumnServiceGroupId.Name = "ColumnServiceGroupId";
            this.ColumnServiceGroupId.Visible = false;
            this.ColumnServiceGroupId.Width = 150;
            // 
            // ColumnServiceGroupColor
            // 
            this.ColumnServiceGroupColor.DataPropertyName = "Color";
            this.ColumnServiceGroupColor.HeaderText = "ColumnServiceGroupColor";
            this.ColumnServiceGroupColor.Name = "ColumnServiceGroupColor";
            this.ColumnServiceGroupColor.Visible = false;
            // 
            // ColumnGroupColor
            // 
            dataGridViewCellStyle6.Padding = new System.Windows.Forms.Padding(10);
            this.ColumnGroupColor.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnGroupColor.HeaderText = "";
            this.ColumnGroupColor.Name = "ColumnGroupColor";
            this.ColumnGroupColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnGroupColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnGroupColor.Width = 30;
            // 
            // ColumnServiceGroupTitle
            // 
            this.ColumnServiceGroupTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnServiceGroupTitle.DataPropertyName = "Title";
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnServiceGroupTitle.DefaultCellStyle = dataGridViewCellStyle7;
            this.ColumnServiceGroupTitle.HeaderText = "Title";
            this.ColumnServiceGroupTitle.Name = "ColumnServiceGroupTitle";
            // 
            // ColumnServiceGroupIsDeleted
            // 
            this.ColumnServiceGroupIsDeleted.DataPropertyName = "IsDeleted";
            this.ColumnServiceGroupIsDeleted.HeaderText = "IsDeleted";
            this.ColumnServiceGroupIsDeleted.Name = "ColumnServiceGroupIsDeleted";
            this.ColumnServiceGroupIsDeleted.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(3, 0, 3, 5);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(15);
            this.label1.Size = new System.Drawing.Size(194, 50);
            this.label1.TabIndex = 171;
            this.label1.Text = "گروه های خدمت";
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "IsToothNumber";
            this.dataGridViewImageColumn1.HeaderText = "تاکیید برای شماره دندان";
            this.dataGridViewImageColumn1.Image = global::Dentistry.Properties.Resources.tinyCheck;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.Width = 120;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "رویت ";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // ServiceList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.GhostWhite;
            this.ClientSize = new System.Drawing.Size(1126, 546);
            this.Controls.Add(this.panelForm);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ServiceList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.ServiceList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgServices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorService)).EndInit();
            this.bindingNavigatorService.ResumeLayout(false);
            this.bindingNavigatorService.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgServiceGroup)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgServices;
        private System.Windows.Forms.BindingNavigator bindingNavigatorService;
        private System.Windows.Forms.ToolStripButton ButtonNew;
        private System.Windows.Forms.ToolStripButton ButtonEdit;
        private System.Windows.Forms.ToolStripButton ButtonDelete;
        private System.Windows.Forms.CheckBox IsDeletedChk;
        public System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.ToolStripButton ButtonServicePricing;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgServiceGroup;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label serviceGroupTitleLbl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceGroupColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnGroupColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceGroupTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceGroupIsDeleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceFreePrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPriceDefineDate;
        private System.Windows.Forms.DataGridViewImageColumn ColumnIsDeletedPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceColor;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsDeleted;
    }
}