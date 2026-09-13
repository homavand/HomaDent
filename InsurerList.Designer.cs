namespace Dentistry
{
    partial class InsurerList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgInsurers = new System.Windows.Forms.DataGridView();
            this.bindingNavigatorCost = new System.Windows.Forms.BindingNavigator(this.components);
            this.ButtonNew = new System.Windows.Forms.ToolStripButton();
            this.ButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.ButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.panelForm = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.InsuranceBoxCbo = new System.Windows.Forms.ComboBox();
            this.InsuranceCbo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IsDeletedChk = new System.Windows.Forms.CheckBox();
            this.InsurerTxt = new System.Windows.Forms.TextBox();
            this.searchBtn = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnInsurerTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInsuranceTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInsuranceBoxTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnOutPatientPercent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsBasic = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsBasicImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnIsExtra = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsExtraImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnIsDeletedPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnIsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnInsurerId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgInsurers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorCost)).BeginInit();
            this.bindingNavigatorCost.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgInsurers
            // 
            this.dgInsurers.AllowUserToAddRows = false;
            this.dgInsurers.AllowUserToDeleteRows = false;
            this.dgInsurers.AllowUserToResizeColumns = false;
            this.dgInsurers.AllowUserToResizeRows = false;
            this.dgInsurers.BackgroundColor = System.Drawing.Color.White;
            this.dgInsurers.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgInsurers.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInsurers.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgInsurers.ColumnHeadersHeight = 35;
            this.dgInsurers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgInsurers.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnInsurerTitle,
            this.ColumnInsuranceTitle,
            this.ColumnInsuranceBoxTitle,
            this.ColumnOutPatientPercent,
            this.ColumnIsBasic,
            this.ColumnIsBasicImg,
            this.ColumnIsExtra,
            this.ColumnIsExtraImg,
            this.ColumnIsDeletedPic,
            this.ColumnIsDeleted,
            this.ColumnInsurerId});
            this.dgInsurers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgInsurers.EnableHeadersVisualStyles = false;
            this.dgInsurers.GridColor = System.Drawing.Color.White;
            this.dgInsurers.Location = new System.Drawing.Point(3, 143);
            this.dgInsurers.MultiSelect = false;
            this.dgInsurers.Name = "dgInsurers";
            this.dgInsurers.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgInsurers.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgInsurers.RowHeadersVisible = false;
            this.dgInsurers.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgInsurers.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgInsurers.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dgInsurers.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgInsurers.RowTemplate.Height = 35;
            this.dgInsurers.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgInsurers.Size = new System.Drawing.Size(1108, 409);
            this.dgInsurers.TabIndex = 0;
            this.dgInsurers.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgInsurers_CellDoubleClick);
            this.dgInsurers.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgInsurers_DataBindingComplete);
            // 
            // bindingNavigatorCost
            // 
            this.bindingNavigatorCost.AddNewItem = null;
            this.bindingNavigatorCost.AutoSize = false;
            this.bindingNavigatorCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.bindingNavigatorCost.CountItem = null;
            this.bindingNavigatorCost.DeleteItem = null;
            this.bindingNavigatorCost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bindingNavigatorCost.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingNavigatorCost.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigatorCost.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNew,
            this.ButtonEdit,
            this.ButtonDelete});
            this.bindingNavigatorCost.Location = new System.Drawing.Point(0, 555);
            this.bindingNavigatorCost.MoveFirstItem = null;
            this.bindingNavigatorCost.MoveLastItem = null;
            this.bindingNavigatorCost.MoveNextItem = null;
            this.bindingNavigatorCost.MovePreviousItem = null;
            this.bindingNavigatorCost.Name = "bindingNavigatorCost";
            this.bindingNavigatorCost.PositionItem = null;
            this.bindingNavigatorCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bindingNavigatorCost.Size = new System.Drawing.Size(1114, 40);
            this.bindingNavigatorCost.TabIndex = 7;
            // 
            // ButtonNew
            // 
            this.ButtonNew.AutoSize = false;
            this.ButtonNew.Image = global::Dentistry.Properties.Resources.NewDocument;
            this.ButtonNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(100, 29);
            this.ButtonNew.Text = "جدید";
            this.ButtonNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.AutoSize = false;
            this.ButtonEdit.Image = global::Dentistry.Properties.Resources.pencil_005_16xLG;
            this.ButtonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(100, 29);
            this.ButtonEdit.Text = "ویرایش";
            this.ButtonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.AutoSize = false;
            this.ButtonDelete.Image = global::Dentistry.Properties.Resources.Symbols_Critical_16xLG;
            this.ButtonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(100, 29);
            this.ButtonDelete.Text = "حذف";
            this.ButtonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelForm.Controls.Add(this.tableLayoutPanel1);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(15);
            this.panelForm.Size = new System.Drawing.Size(1144, 625);
            this.panelForm.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.bindingNavigatorCost, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgInsurers, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tableLayoutPanel1.Location = new System.Drawing.Point(15, 15);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 130F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1114, 595);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.InsuranceBoxCbo);
            this.panel2.Controls.Add(this.InsuranceCbo);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.IsDeletedChk);
            this.panel2.Controls.Add(this.InsurerTxt);
            this.panel2.Controls.Add(this.searchBtn);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1108, 124);
            this.panel2.TabIndex = 3;
            // 
            // InsuranceBoxCbo
            // 
            this.InsuranceBoxCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsuranceBoxCbo.BackColor = System.Drawing.Color.White;
            this.InsuranceBoxCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InsuranceBoxCbo.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsuranceBoxCbo.FormattingEnabled = true;
            this.InsuranceBoxCbo.Location = new System.Drawing.Point(782, 51);
            this.InsuranceBoxCbo.Name = "InsuranceBoxCbo";
            this.InsuranceBoxCbo.Size = new System.Drawing.Size(217, 29);
            this.InsuranceBoxCbo.TabIndex = 46;
            // 
            // InsuranceCbo
            // 
            this.InsuranceCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsuranceCbo.BackColor = System.Drawing.Color.White;
            this.InsuranceCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InsuranceCbo.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsuranceCbo.FormattingEnabled = true;
            this.InsuranceCbo.Location = new System.Drawing.Point(782, 17);
            this.InsuranceCbo.Name = "InsuranceCbo";
            this.InsuranceCbo.Size = new System.Drawing.Size(217, 29);
            this.InsuranceCbo.TabIndex = 38;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1003, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 21);
            this.label1.TabIndex = 47;
            this.label1.Text = "صندوق بیمه :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(1003, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 21);
            this.label3.TabIndex = 43;
            this.label3.Text = "عنوان بیمه :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1003, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 21);
            this.label2.TabIndex = 45;
            this.label2.Text = "عنوان بیمه گر :";
            // 
            // IsDeletedChk
            // 
            this.IsDeletedChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsDeletedChk.AutoSize = true;
            this.IsDeletedChk.BackColor = System.Drawing.Color.LavenderBlush;
            this.IsDeletedChk.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsDeletedChk.Location = new System.Drawing.Point(553, 88);
            this.IsDeletedChk.Name = "IsDeletedChk";
            this.IsDeletedChk.Size = new System.Drawing.Size(152, 25);
            this.IsDeletedChk.TabIndex = 44;
            this.IsDeletedChk.Text = "نمایش موارد حذف شده";
            this.IsDeletedChk.UseVisualStyleBackColor = false;
            // 
            // InsurerTxt
            // 
            this.InsurerTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsurerTxt.BackColor = System.Drawing.Color.White;
            this.InsurerTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsurerTxt.Location = new System.Drawing.Point(782, 86);
            this.InsurerTxt.Name = "InsurerTxt";
            this.InsurerTxt.Size = new System.Drawing.Size(217, 28);
            this.InsurerTxt.TabIndex = 39;
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.White;
            this.searchBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.searchBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.searchBtn.Location = new System.Drawing.Point(17, 80);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(150, 30);
            this.searchBtn.TabIndex = 42;
            this.searchBtn.Text = "جستجو";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "IsBasic";
            this.dataGridViewImageColumn1.HeaderText = "بیمه پایه";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 50;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "IsExtra";
            this.dataGridViewImageColumn2.HeaderText = "بیمه تکمیلی";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Width = 50;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "IsBasic";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.HeaderText = "بیمه تکمیلی";
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.ReadOnly = true;
            this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnInsurerTitle
            // 
            this.ColumnInsurerTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnInsurerTitle.DataPropertyName = "InsurerTitle";
            this.ColumnInsurerTitle.HeaderText = "عنوان بیمه گر";
            this.ColumnInsurerTitle.Name = "ColumnInsurerTitle";
            // 
            // ColumnInsuranceTitle
            // 
            this.ColumnInsuranceTitle.DataPropertyName = "InsuranceTitle";
            this.ColumnInsuranceTitle.HeaderText = "عنوان بیمه";
            this.ColumnInsuranceTitle.Name = "ColumnInsuranceTitle";
            this.ColumnInsuranceTitle.Width = 200;
            // 
            // ColumnInsuranceBoxTitle
            // 
            this.ColumnInsuranceBoxTitle.DataPropertyName = "InsuranceBoxTitle";
            this.ColumnInsuranceBoxTitle.HeaderText = "صندوق بیمه";
            this.ColumnInsuranceBoxTitle.Name = "ColumnInsuranceBoxTitle";
            this.ColumnInsuranceBoxTitle.Width = 200;
            // 
            // ColumnOutPatientPercent
            // 
            this.ColumnOutPatientPercent.DataPropertyName = "InsurerPercent";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnOutPatientPercent.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnOutPatientPercent.HeaderText = "درصد بیمه";
            this.ColumnOutPatientPercent.Name = "ColumnOutPatientPercent";
            // 
            // ColumnIsBasic
            // 
            this.ColumnIsBasic.DataPropertyName = "IsBasic";
            this.ColumnIsBasic.HeaderText = "IsBasic";
            this.ColumnIsBasic.Name = "ColumnIsBasic";
            this.ColumnIsBasic.Visible = false;
            // 
            // ColumnIsBasicImg
            // 
            this.ColumnIsBasicImg.HeaderText = " پایه";
            this.ColumnIsBasicImg.Name = "ColumnIsBasicImg";
            this.ColumnIsBasicImg.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIsBasicImg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIsBasicImg.Width = 70;
            // 
            // ColumnIsExtra
            // 
            this.ColumnIsExtra.DataPropertyName = "IsExtra";
            this.ColumnIsExtra.HeaderText = "IsExtra";
            this.ColumnIsExtra.Name = "ColumnIsExtra";
            this.ColumnIsExtra.Visible = false;
            // 
            // ColumnIsExtraImg
            // 
            this.ColumnIsExtraImg.HeaderText = " تکمیلی";
            this.ColumnIsExtraImg.Name = "ColumnIsExtraImg";
            this.ColumnIsExtraImg.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIsExtraImg.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIsExtraImg.Width = 70;
            // 
            // ColumnIsDeletedPic
            // 
            this.ColumnIsDeletedPic.HeaderText = "فعال";
            this.ColumnIsDeletedPic.Name = "ColumnIsDeletedPic";
            this.ColumnIsDeletedPic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIsDeletedPic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // ColumnIsDeleted
            // 
            this.ColumnIsDeleted.DataPropertyName = "IsDeleted";
            this.ColumnIsDeleted.HeaderText = "IsDeleted";
            this.ColumnIsDeleted.Name = "ColumnIsDeleted";
            this.ColumnIsDeleted.Visible = false;
            // 
            // ColumnInsurerId
            // 
            this.ColumnInsurerId.DataPropertyName = "InsurerId";
            this.ColumnInsurerId.HeaderText = "InsurerId";
            this.ColumnInsurerId.Name = "ColumnInsurerId";
            this.ColumnInsurerId.Visible = false;
            // 
            // InsurerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1144, 625);
            this.Controls.Add(this.panelForm);
            this.DoubleBuffered = true;
            this.Name = "InsurerList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Tag = "22";
            this.Text = "InsurerList";
            this.Load += new System.EventHandler(this.InsurerList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgInsurers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorCost)).EndInit();
            this.bindingNavigatorCost.ResumeLayout(false);
            this.bindingNavigatorCost.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.BindingNavigator bindingNavigatorCost;
        private System.Windows.Forms.ToolStripButton ButtonNew;
        private System.Windows.Forms.ToolStripButton ButtonEdit;
        private System.Windows.Forms.ToolStripButton ButtonDelete;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox InsurerTxt;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.CheckBox IsDeletedChk;
        private System.Windows.Forms.ComboBox InsuranceCbo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox InsuranceBoxCbo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInsurerTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInsuranceTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInsuranceBoxTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnOutPatientPercent;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIsBasic;
        private System.Windows.Forms.DataGridViewImageColumn ColumnIsBasicImg;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIsExtra;
        private System.Windows.Forms.DataGridViewImageColumn ColumnIsExtraImg;
        private System.Windows.Forms.DataGridViewImageColumn ColumnIsDeletedPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIsDeleted;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnInsurerId;
        public System.Windows.Forms.DataGridView dgInsurers;
    }
}