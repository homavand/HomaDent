namespace Dentistry
{
    partial class UserList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserList));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelForm = new Dentistry.UserControls.ExPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgUser = new System.Windows.Forms.DataGridView();
            this.bindingNavigatorUser = new System.Windows.Forms.BindingNavigator(this.components);
            this.ButtonNew = new System.Windows.Forms.ToolStripButton();
            this.ButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.ButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.userNameLbl = new System.Windows.Forms.Label();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.label1 = new System.Windows.Forms.Label();
            this.miniToolStrip = new System.Windows.Forms.BindingNavigator(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnIsDeletedUser = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnUserName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsDeletedPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.ColumnUserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorUser)).BeginInit();
            this.bindingNavigatorUser.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).BeginInit();
            this.SuspendLayout();
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelForm.BorderColor = System.Drawing.Color.Transparent;
            this.panelForm.Controls.Add(this.splitContainer1);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(15);
            this.panelForm.Size = new System.Drawing.Size(1012, 565);
            this.panelForm.TabIndex = 0;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.Location = new System.Drawing.Point(15, 15);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgUser);
            this.splitContainer1.Panel1.Controls.Add(this.bindingNavigatorUser);
            this.splitContainer1.Panel1.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.panel1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(982, 535);
            this.splitContainer1.SplitterDistance = 453;
            this.splitContainer1.SplitterWidth = 15;
            this.splitContainer1.TabIndex = 9;
            // 
            // dgUser
            // 
            this.dgUser.AllowUserToAddRows = false;
            this.dgUser.AllowUserToDeleteRows = false;
            this.dgUser.AllowUserToResizeRows = false;
            this.dgUser.BackgroundColor = System.Drawing.Color.White;
            this.dgUser.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgUser.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgUser.ColumnHeadersHeight = 35;
            this.dgUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgUser.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnIsDeletedUser,
            this.ColumnUserName,
            this.ColumnIsDeleted,
            this.ColumnIsDeletedPic,
            this.ColumnUserId});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgUser.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgUser.EnableHeadersVisualStyles = false;
            this.dgUser.GridColor = System.Drawing.Color.White;
            this.dgUser.Location = new System.Drawing.Point(0, 0);
            this.dgUser.MultiSelect = false;
            this.dgUser.Name = "dgUser";
            this.dgUser.ReadOnly = true;
            this.dgUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgUser.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgUser.RowHeadersVisible = false;
            this.dgUser.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgUser.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgUser.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dgUser.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgUser.RowTemplate.Height = 35;
            this.dgUser.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgUser.Size = new System.Drawing.Size(453, 500);
            this.dgUser.TabIndex = 7;
            this.dgUser.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUser_CellClick);
            this.dgUser.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgUser_CellDoubleClick);
            this.dgUser.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgUser_CellFormatting);
            this.dgUser.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgUser_DataBindingComplete);
            this.dgUser.SelectionChanged += new System.EventHandler(this.dgUser_SelectionChanged);
            // 
            // bindingNavigatorUser
            // 
            this.bindingNavigatorUser.AddNewItem = null;
            this.bindingNavigatorUser.AutoSize = false;
            this.bindingNavigatorUser.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.bindingNavigatorUser.CountItem = null;
            this.bindingNavigatorUser.DeleteItem = null;
            this.bindingNavigatorUser.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigatorUser.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingNavigatorUser.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigatorUser.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNew,
            this.ButtonEdit,
            this.ButtonDelete});
            this.bindingNavigatorUser.Location = new System.Drawing.Point(0, 500);
            this.bindingNavigatorUser.MoveFirstItem = null;
            this.bindingNavigatorUser.MoveLastItem = null;
            this.bindingNavigatorUser.MoveNextItem = null;
            this.bindingNavigatorUser.MovePreviousItem = null;
            this.bindingNavigatorUser.Name = "bindingNavigatorUser";
            this.bindingNavigatorUser.PositionItem = null;
            this.bindingNavigatorUser.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bindingNavigatorUser.Size = new System.Drawing.Size(453, 35);
            this.bindingNavigatorUser.TabIndex = 8;
            this.bindingNavigatorUser.Text = "bindingNavigatorUser";
            // 
            // ButtonNew
            // 
            this.ButtonNew.AutoSize = false;
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
            this.ButtonDelete.Image = global::Dentistry.Properties.Resources.Symbols_Critical_16xLG;
            this.ButtonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(100, 27);
            this.ButtonDelete.Text = "حذف";
            this.ButtonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 535);
            this.panel1.TabIndex = 11;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.userNameLbl);
            this.panel2.Controls.Add(this.treeView1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 535);
            this.panel2.TabIndex = 12;
            // 
            // userNameLbl
            // 
            this.userNameLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.userNameLbl.BackColor = System.Drawing.Color.Transparent;
            this.userNameLbl.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userNameLbl.ForeColor = System.Drawing.Color.Indigo;
            this.userNameLbl.Location = new System.Drawing.Point(200, 1);
            this.userNameLbl.Name = "userNameLbl";
            this.userNameLbl.Padding = new System.Windows.Forms.Padding(5);
            this.userNameLbl.Size = new System.Drawing.Size(184, 30);
            this.userNameLbl.TabIndex = 2;
            this.userNameLbl.Text = "...";
            this.userNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.treeView1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.treeView1.Location = new System.Drawing.Point(19, 48);
            this.treeView1.Name = "treeView1";
            this.treeView1.RightToLeftLayout = true;
            this.treeView1.Size = new System.Drawing.Size(475, 467);
            this.treeView1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Crimson;
            this.label1.Location = new System.Drawing.Point(384, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(5);
            this.label1.Size = new System.Drawing.Size(130, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "سطج دسترسی کاربر";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // miniToolStrip
            // 
            this.miniToolStrip.AccessibleName = "New item selection";
            this.miniToolStrip.AccessibleRole = System.Windows.Forms.AccessibleRole.ButtonDropDown;
            this.miniToolStrip.AddNewItem = null;
            this.miniToolStrip.AutoSize = false;
            this.miniToolStrip.CanOverflow = false;
            this.miniToolStrip.CountItem = null;
            this.miniToolStrip.DeleteItem = null;
            this.miniToolStrip.Dock = System.Windows.Forms.DockStyle.None;
            this.miniToolStrip.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.miniToolStrip.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.miniToolStrip.Location = new System.Drawing.Point(644, 5);
            this.miniToolStrip.MoveFirstItem = null;
            this.miniToolStrip.MoveLastItem = null;
            this.miniToolStrip.MoveNextItem = null;
            this.miniToolStrip.MovePreviousItem = null;
            this.miniToolStrip.Name = "miniToolStrip";
            this.miniToolStrip.PositionItem = null;
            this.miniToolStrip.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.miniToolStrip.Size = new System.Drawing.Size(976, 30);
            this.miniToolStrip.TabIndex = 6;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Medium_228_32x.png");
            this.imageList1.Images.SetKeyName(1, "access_none.png");
            this.imageList1.Images.SetKeyName(2, "access_yes.png");
            this.imageList1.Images.SetKeyName(3, "access_no.png");
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.DataPropertyName = "Picture";
            this.dataGridViewImageColumn1.HeaderText = "";
            this.dataGridViewImageColumn1.Image = global::Dentistry.Properties.Resources.right;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn1.Width = 30;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.DataPropertyName = "Picture";
            this.dataGridViewImageColumn2.HeaderText = "تصویر پرسنل";
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Stretch;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn2.Visible = false;
            this.dataGridViewImageColumn2.Width = 40;
            // 
            // ColumnIsDeletedUser
            // 
            this.ColumnIsDeletedUser.DataPropertyName = "IsDeletedUser";
            this.ColumnIsDeletedUser.HeaderText = "IsDeletedUser";
            this.ColumnIsDeletedUser.Name = "ColumnIsDeletedUser";
            this.ColumnIsDeletedUser.ReadOnly = true;
            this.ColumnIsDeletedUser.Visible = false;
            // 
            // ColumnUserName
            // 
            this.ColumnUserName.DataPropertyName = "UserName";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColumnUserName.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColumnUserName.HeaderText = "نام کاربری";
            this.ColumnUserName.Name = "ColumnUserName";
            this.ColumnUserName.ReadOnly = true;
            this.ColumnUserName.Width = 400;
            // 
            // ColumnIsDeleted
            // 
            this.ColumnIsDeleted.DataPropertyName = "IsDeleted";
            this.ColumnIsDeleted.HeaderText = "کاربر فعال ";
            this.ColumnIsDeleted.Name = "ColumnIsDeleted";
            this.ColumnIsDeleted.ReadOnly = true;
            this.ColumnIsDeleted.Visible = false;
            this.ColumnIsDeleted.Width = 50;
            // 
            // ColumnIsDeletedPic
            // 
            this.ColumnIsDeletedPic.HeaderText = "فعال";
            this.ColumnIsDeletedPic.Name = "ColumnIsDeletedPic";
            this.ColumnIsDeletedPic.ReadOnly = true;
            this.ColumnIsDeletedPic.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIsDeletedPic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ColumnIsDeletedPic.Width = 50;
            // 
            // ColumnUserId
            // 
            this.ColumnUserId.DataPropertyName = "UserId";
            this.ColumnUserId.HeaderText = "UserId";
            this.ColumnUserId.Name = "ColumnUserId";
            this.ColumnUserId.ReadOnly = true;
            this.ColumnUserId.Visible = false;
            // 
            // UserList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1012, 565);
            this.Controls.Add(this.panelForm);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "UserList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "6";
            this.Text = "  اطلاعات پرسنلی";
            this.panelForm.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgUser)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorUser)).EndInit();
            this.bindingNavigatorUser.ResumeLayout(false);
            this.bindingNavigatorUser.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.miniToolStrip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView dgUser;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnStaffTypeTitle;
        private System.Windows.Forms.SplitContainer splitContainer1;
        public UserControls.ExPanel panelForm;
        private System.Windows.Forms.BindingNavigator miniToolStrip;
        private System.Windows.Forms.BindingNavigator bindingNavigatorUser;
        private System.Windows.Forms.ToolStripButton ButtonNew;
        private System.Windows.Forms.ToolStripButton ButtonEdit;
        private System.Windows.Forms.ToolStripButton ButtonDelete;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.Label userNameLbl;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIsDeletedUser;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIsDeleted;
        private System.Windows.Forms.DataGridViewImageColumn ColumnIsDeletedPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnUserId;
    }
}