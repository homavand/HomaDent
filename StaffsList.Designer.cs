namespace Dentistry
{
    partial class StaffsList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.bindingNavigatorService = new System.Windows.Forms.BindingNavigator(this.components);
            this.ButtonNew = new System.Windows.Forms.ToolStripButton();
            this.ButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.ButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgStaffs = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.staffTypeCbo = new System.Windows.Forms.ComboBox();
            this.staffFirstNameTxt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.searchBtn = new System.Windows.Forms.Button();
            this.staffLastNameTxt = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IsDeletedChk = new System.Windows.Forms.CheckBox();
            this.panelForm = new System.Windows.Forms.Panel();
            this.ColumnStaffFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnStaffTypeTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsDeletedPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnStaffId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsDeleted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorService)).BeginInit();
            this.bindingNavigatorService.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStaffs)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelForm.SuspendLayout();
            this.SuspendLayout();
            // 
            // bindingNavigatorService
            // 
            this.bindingNavigatorService.AddNewItem = null;
            this.bindingNavigatorService.AutoSize = false;
            this.bindingNavigatorService.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.bindingNavigatorService.CountItem = null;
            this.bindingNavigatorService.DeleteItem = null;
            this.bindingNavigatorService.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bindingNavigatorService.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.bindingNavigatorService.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigatorService.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNew,
            this.ButtonEdit,
            this.ButtonDelete});
            this.bindingNavigatorService.Location = new System.Drawing.Point(0, 515);
            this.bindingNavigatorService.MoveFirstItem = null;
            this.bindingNavigatorService.MoveLastItem = null;
            this.bindingNavigatorService.MoveNextItem = null;
            this.bindingNavigatorService.MovePreviousItem = null;
            this.bindingNavigatorService.Name = "bindingNavigatorService";
            this.bindingNavigatorService.PositionItem = null;
            this.bindingNavigatorService.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bindingNavigatorService.Size = new System.Drawing.Size(1001, 40);
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
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.bindingNavigatorService, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.dgStaffs, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
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
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1001, 555);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // dgStaffs
            // 
            this.dgStaffs.AllowUserToAddRows = false;
            this.dgStaffs.AllowUserToDeleteRows = false;
            this.dgStaffs.AllowUserToResizeColumns = false;
            this.dgStaffs.AllowUserToResizeRows = false;
            this.dgStaffs.BackgroundColor = System.Drawing.Color.White;
            this.dgStaffs.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgStaffs.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgStaffs.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgStaffs.ColumnHeadersHeight = 35;
            this.dgStaffs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgStaffs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnStaffFullName,
            this.ColumnStaffTypeTitle,
            this.ColumnUserName,
            this.ColumnIsDeletedPic,
            this.ColumnStaffId,
            this.ColumnIsDeleted});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgStaffs.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgStaffs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgStaffs.EnableHeadersVisualStyles = false;
            this.dgStaffs.GridColor = System.Drawing.Color.White;
            this.dgStaffs.Location = new System.Drawing.Point(3, 146);
            this.dgStaffs.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.dgStaffs.MultiSelect = false;
            this.dgStaffs.Name = "dgStaffs";
            this.dgStaffs.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgStaffs.RowHeadersVisible = false;
            this.dgStaffs.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgStaffs.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgStaffs.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgStaffs.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dgStaffs.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgStaffs.RowTemplate.Height = 35;
            this.dgStaffs.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStaffs.Size = new System.Drawing.Size(995, 363);
            this.dgStaffs.TabIndex = 5;
            this.dgStaffs.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStaffs_CellDoubleClick);
            this.dgStaffs.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgStaffs_CellFormatting);
            this.dgStaffs.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgStaffs_DataBindingComplete);
            this.dgStaffs.SelectionChanged += new System.EventHandler(this.dgStaffs_SelectionChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.staffTypeCbo);
            this.panel1.Controls.Add(this.staffFirstNameTxt);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.searchBtn);
            this.panel1.Controls.Add(this.staffLastNameTxt);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.IsDeletedChk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.panel1.Size = new System.Drawing.Size(995, 124);
            this.panel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(893, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "نام :";
            // 
            // staffTypeCbo
            // 
            this.staffTypeCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.staffTypeCbo.BackColor = System.Drawing.Color.White;
            this.staffTypeCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.staffTypeCbo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffTypeCbo.FormattingEnabled = true;
            this.staffTypeCbo.Location = new System.Drawing.Point(672, 15);
            this.staffTypeCbo.Name = "staffTypeCbo";
            this.staffTypeCbo.Size = new System.Drawing.Size(217, 28);
            this.staffTypeCbo.TabIndex = 1;
            // 
            // staffFirstNameTxt
            // 
            this.staffFirstNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.staffFirstNameTxt.BackColor = System.Drawing.Color.White;
            this.staffFirstNameTxt.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffFirstNameTxt.Location = new System.Drawing.Point(672, 50);
            this.staffFirstNameTxt.Name = "staffFirstNameTxt";
            this.staffFirstNameTxt.Size = new System.Drawing.Size(217, 28);
            this.staffFirstNameTxt.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(893, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "نوع کارمند :";
            // 
            // searchBtn
            // 
            this.searchBtn.BackColor = System.Drawing.Color.White;
            this.searchBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.searchBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.searchBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchBtn.Font = new System.Drawing.Font("Vazir", 9.5F, System.Drawing.FontStyle.Bold);
            this.searchBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.searchBtn.Location = new System.Drawing.Point(17, 80);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(150, 30);
            this.searchBtn.TabIndex = 31;
            this.searchBtn.Text = "جستجو";
            this.searchBtn.UseVisualStyleBackColor = false;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // staffLastNameTxt
            // 
            this.staffLastNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.staffLastNameTxt.BackColor = System.Drawing.Color.White;
            this.staffLastNameTxt.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.staffLastNameTxt.Location = new System.Drawing.Point(672, 85);
            this.staffLastNameTxt.Name = "staffLastNameTxt";
            this.staffLastNameTxt.Size = new System.Drawing.Size(217, 28);
            this.staffLastNameTxt.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(893, 90);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام خانوادگی :";
            // 
            // IsDeletedChk
            // 
            this.IsDeletedChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsDeletedChk.AutoSize = true;
            this.IsDeletedChk.BackColor = System.Drawing.Color.LavenderBlush;
            this.IsDeletedChk.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsDeletedChk.Location = new System.Drawing.Point(443, 88);
            this.IsDeletedChk.Name = "IsDeletedChk";
            this.IsDeletedChk.Size = new System.Drawing.Size(151, 24);
            this.IsDeletedChk.TabIndex = 35;
            this.IsDeletedChk.Text = "نمایش موارد حذف شده";
            this.IsDeletedChk.UseVisualStyleBackColor = false;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelForm.Controls.Add(this.tableLayoutPanel1);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(15);
            this.panelForm.Size = new System.Drawing.Size(1031, 585);
            this.panelForm.TabIndex = 3;
            // 
            // ColumnStaffFullName
            // 
            this.ColumnStaffFullName.DataPropertyName = "StaffFullName";
            this.ColumnStaffFullName.HeaderText = "نام کارمند";
            this.ColumnStaffFullName.Name = "ColumnStaffFullName";
            this.ColumnStaffFullName.Width = 300;
            // 
            // ColumnStaffTypeTitle
            // 
            this.ColumnStaffTypeTitle.DataPropertyName = "StaffTypeTitle";
            this.ColumnStaffTypeTitle.HeaderText = "نوع کارمند";
            this.ColumnStaffTypeTitle.Name = "ColumnStaffTypeTitle";
            this.ColumnStaffTypeTitle.Width = 150;
            // 
            // ColumnUserName
            // 
            this.ColumnUserName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnUserName.DataPropertyName = "UserName";
            this.ColumnUserName.HeaderText = "نام کاربری";
            this.ColumnUserName.Name = "ColumnUserName";
            // 
            // ColumnIsDeletedPic
            // 
            this.ColumnIsDeletedPic.HeaderText = "رویت ";
            this.ColumnIsDeletedPic.Name = "ColumnIsDeletedPic";
            this.ColumnIsDeletedPic.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIsDeletedPic.Width = 50;
            // 
            // ColumnStaffId
            // 
            this.ColumnStaffId.DataPropertyName = "StaffId";
            this.ColumnStaffId.HeaderText = "StaffId";
            this.ColumnStaffId.Name = "ColumnStaffId";
            this.ColumnStaffId.Visible = false;
            this.ColumnStaffId.Width = 20;
            // 
            // ColumnIsDeleted
            // 
            this.ColumnIsDeleted.DataPropertyName = "IsDeleted";
            this.ColumnIsDeleted.HeaderText = "IsDeleted";
            this.ColumnIsDeleted.Name = "ColumnIsDeleted";
            this.ColumnIsDeleted.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIsDeleted.Visible = false;
            this.ColumnIsDeleted.Width = 50;
            // 
            // StaffsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1031, 585);
            this.Controls.Add(this.panelForm);
            this.Name = "StaffsList";
            this.Text = "Staffs";
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorService)).EndInit();
            this.bindingNavigatorService.ResumeLayout(false);
            this.bindingNavigatorService.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgStaffs)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelForm.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingNavigator bindingNavigatorService;
        private System.Windows.Forms.ToolStripButton ButtonNew;
        private System.Windows.Forms.ToolStripButton ButtonEdit;
        private System.Windows.Forms.ToolStripButton ButtonDelete;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgStaffs;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox staffTypeCbo;
        private System.Windows.Forms.TextBox staffFirstNameTxt;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.TextBox staffLastNameTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox IsDeletedChk;
        public System.Windows.Forms.Panel panelForm;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStaffFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStaffTypeTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserName;
        private System.Windows.Forms.DataGridViewImageColumn ColumnIsDeletedPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStaffId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsDeleted;
    }
}