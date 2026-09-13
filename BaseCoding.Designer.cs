namespace Dentistry
{
    partial class BaseCodings
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
            this.dgListItem = new System.Windows.Forms.DataGridView();
            this.Column_IsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_IsDeletedPic = new System.Windows.Forms.DataGridViewImageColumn();
            this.Column_Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Title = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Terminology = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgList = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnEntity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsCanChange = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelForm = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bindingNavigatorCost = new System.Windows.Forms.BindingNavigator(this.components);
            this.ButtonNew = new System.Windows.Forms.ToolStripButton();
            this.ButtonEdit = new System.Windows.Forms.ToolStripButton();
            this.ButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgListItem)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).BeginInit();
            this.panelForm.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorCost)).BeginInit();
            this.bindingNavigatorCost.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgListItem
            // 
            this.dgListItem.AllowUserToAddRows = false;
            this.dgListItem.AllowUserToDeleteRows = false;
            this.dgListItem.AllowUserToResizeColumns = false;
            this.dgListItem.AllowUserToResizeRows = false;
            this.dgListItem.BackgroundColor = System.Drawing.Color.White;
            this.dgListItem.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgListItem.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgListItem.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgListItem.ColumnHeadersHeight = 35;
            this.dgListItem.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgListItem.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_IsDeleted,
            this.Column_IsDeletedPic,
            this.Column_Id,
            this.Column_Title,
            this.Column_Terminology,
            this.Column_Comment});
            this.dgListItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgListItem.EnableHeadersVisualStyles = false;
            this.dgListItem.GridColor = System.Drawing.Color.White;
            this.dgListItem.Location = new System.Drawing.Point(10, 10);
            this.dgListItem.MultiSelect = false;
            this.dgListItem.Name = "dgListItem";
            this.dgListItem.ReadOnly = true;
            this.dgListItem.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgListItem.RowHeadersVisible = false;
            this.dgListItem.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgListItem.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir", 9.5F);
            this.dgListItem.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgListItem.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dgListItem.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgListItem.RowTemplate.Height = 35;
            this.dgListItem.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgListItem.Size = new System.Drawing.Size(655, 480);
            this.dgListItem.TabIndex = 8;
            this.dgListItem.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgListItem_CellDoubleClick);
            this.dgListItem.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgListItem_DataBindingComplete);
            this.dgListItem.SelectionChanged += new System.EventHandler(this.dgListItem_SelectionChanged);
            // 
            // Column_IsDeleted
            // 
            this.Column_IsDeleted.DataPropertyName = "IsDeleted";
            this.Column_IsDeleted.HeaderText = "حذف شده";
            this.Column_IsDeleted.Name = "Column_IsDeleted";
            this.Column_IsDeleted.ReadOnly = true;
            this.Column_IsDeleted.Visible = false;
            this.Column_IsDeleted.Width = 70;
            // 
            // Column_IsDeletedPic
            // 
            this.Column_IsDeletedPic.HeaderText = "فعال";
            this.Column_IsDeletedPic.Name = "Column_IsDeletedPic";
            this.Column_IsDeletedPic.ReadOnly = true;
            this.Column_IsDeletedPic.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column_IsDeletedPic.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // Column_Id
            // 
            this.Column_Id.DataPropertyName = "Id";
            this.Column_Id.HeaderText = "کد";
            this.Column_Id.Name = "Column_Id";
            this.Column_Id.ReadOnly = true;
            // 
            // Column_Title
            // 
            this.Column_Title.DataPropertyName = "Title";
            this.Column_Title.HeaderText = "عنوان";
            this.Column_Title.Name = "Column_Title";
            this.Column_Title.ReadOnly = true;
            this.Column_Title.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Column_Title.Width = 300;
            // 
            // Column_Terminology
            // 
            this.Column_Terminology.DataPropertyName = "Terminology";
            this.Column_Terminology.HeaderText = "Terminology";
            this.Column_Terminology.Name = "Column_Terminology";
            this.Column_Terminology.ReadOnly = true;
            this.Column_Terminology.Visible = false;
            this.Column_Terminology.Width = 200;
            // 
            // Column_Comment
            // 
            this.Column_Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column_Comment.DataPropertyName = "Comment";
            this.Column_Comment.HeaderText = "توضیحات";
            this.Column_Comment.Name = "Column_Comment";
            this.Column_Comment.ReadOnly = true;
            // 
            // dgList
            // 
            this.dgList.AllowUserToAddRows = false;
            this.dgList.AllowUserToDeleteRows = false;
            this.dgList.AllowUserToResizeColumns = false;
            this.dgList.AllowUserToResizeRows = false;
            this.dgList.BackgroundColor = System.Drawing.Color.White;
            this.dgList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgList.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgList.ColumnHeadersHeight = 35;
            this.dgList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnTitle,
            this.ColumnEntity,
            this.ColumnTable,
            this.ColumnIsCanChange});
            this.dgList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgList.EnableHeadersVisualStyles = false;
            this.dgList.GridColor = System.Drawing.Color.White;
            this.dgList.Location = new System.Drawing.Point(10, 10);
            this.dgList.MultiSelect = false;
            this.dgList.Name = "dgList";
            this.dgList.ReadOnly = true;
            this.dgList.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgList.RowHeadersVisible = false;
            this.dgList.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgList.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir", 9.5F);
            this.dgList.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgList.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dgList.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgList.RowTemplate.Height = 35;
            this.dgList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgList.Size = new System.Drawing.Size(274, 515);
            this.dgList.TabIndex = 7;
            // 
            // ColumnId
            // 
            this.ColumnId.DataPropertyName = "Id";
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTitle.DataPropertyName = "Title";
            this.ColumnTitle.HeaderText = "عنوان";
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.ReadOnly = true;
            this.ColumnTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnEntity
            // 
            this.ColumnEntity.DataPropertyName = "Entity";
            this.ColumnEntity.HeaderText = "موجودیت";
            this.ColumnEntity.Name = "ColumnEntity";
            this.ColumnEntity.ReadOnly = true;
            this.ColumnEntity.Visible = false;
            this.ColumnEntity.Width = 170;
            // 
            // ColumnTable
            // 
            this.ColumnTable.DataPropertyName = "Table";
            this.ColumnTable.HeaderText = "جدول";
            this.ColumnTable.Name = "ColumnTable";
            this.ColumnTable.ReadOnly = true;
            this.ColumnTable.Visible = false;
            this.ColumnTable.Width = 170;
            // 
            // ColumnIsCanChange
            // 
            this.ColumnIsCanChange.HeaderText = "IsCanChange";
            this.ColumnIsCanChange.Name = "ColumnIsCanChange";
            this.ColumnIsCanChange.ReadOnly = true;
            this.ColumnIsCanChange.Visible = false;
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = "حذف شده";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewImageColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // panelForm
            // 
            this.panelForm.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panelForm.ColumnCount = 3;
            this.panelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.panelForm.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.panelForm.Controls.Add(this.panel1, 0, 0);
            this.panelForm.Controls.Add(this.panel2, 2, 0);
            this.panelForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelForm.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.panelForm.Location = new System.Drawing.Point(0, 0);
            this.panelForm.Name = "panelForm";
            this.panelForm.Padding = new System.Windows.Forms.Padding(15);
            this.panelForm.RowCount = 1;
            this.panelForm.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.panelForm.Size = new System.Drawing.Size(1021, 571);
            this.panelForm.TabIndex = 1;
            this.panelForm.Paint += new System.Windows.Forms.PaintEventHandler(this.BasePnl_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.dgListItem);
            this.panel1.Controls.Add(this.bindingNavigatorCost);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(18, 18);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(10);
            this.panel1.Size = new System.Drawing.Size(675, 535);
            this.panel1.TabIndex = 8;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // bindingNavigatorCost
            // 
            this.bindingNavigatorCost.AddNewItem = null;
            this.bindingNavigatorCost.AutoSize = false;
            this.bindingNavigatorCost.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.bindingNavigatorCost.CountItem = null;
            this.bindingNavigatorCost.DeleteItem = null;
            this.bindingNavigatorCost.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigatorCost.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.bindingNavigatorCost.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigatorCost.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonNew,
            this.ButtonEdit,
            this.ButtonDelete});
            this.bindingNavigatorCost.Location = new System.Drawing.Point(10, 490);
            this.bindingNavigatorCost.MoveFirstItem = null;
            this.bindingNavigatorCost.MoveLastItem = null;
            this.bindingNavigatorCost.MoveNextItem = null;
            this.bindingNavigatorCost.MovePreviousItem = null;
            this.bindingNavigatorCost.Name = "bindingNavigatorCost";
            this.bindingNavigatorCost.Padding = new System.Windows.Forms.Padding(5);
            this.bindingNavigatorCost.PositionItem = null;
            this.bindingNavigatorCost.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bindingNavigatorCost.Size = new System.Drawing.Size(655, 35);
            this.bindingNavigatorCost.TabIndex = 9;
            // 
            // ButtonNew
            // 
            this.ButtonNew.AutoSize = false;
            this.ButtonNew.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonNew.Image = global::Dentistry.Properties.Resources.NewDocument;
            this.ButtonNew.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonNew.Name = "ButtonNew";
            this.ButtonNew.Size = new System.Drawing.Size(120, 29);
            this.ButtonNew.Text = "جدید";
            this.ButtonNew.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonNew.Click += new System.EventHandler(this.ButtonNew_Click);
            // 
            // ButtonEdit
            // 
            this.ButtonEdit.AutoSize = false;
            this.ButtonEdit.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonEdit.Image = global::Dentistry.Properties.Resources.pencil_005_16xLG;
            this.ButtonEdit.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonEdit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonEdit.Name = "ButtonEdit";
            this.ButtonEdit.Size = new System.Drawing.Size(120, 29);
            this.ButtonEdit.Text = "ویرایش";
            this.ButtonEdit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.AutoSize = false;
            this.ButtonDelete.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ButtonDelete.Image = global::Dentistry.Properties.Resources.remove24;
            this.ButtonDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(120, 29);
            this.ButtonDelete.Text = "حذف";
            this.ButtonDelete.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.dgList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(709, 18);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(10);
            this.panel2.Size = new System.Drawing.Size(294, 535);
            this.panel2.TabIndex = 9;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
            // 
            // BaseCodings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1021, 571);
            this.Controls.Add(this.panelForm);
            this.Name = "BaseCodings";
            this.Text = "BaseCodings";
            ((System.ComponentModel.ISupportInitialize)(this.dgListItem)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgList)).EndInit();
            this.panelForm.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigatorCost)).EndInit();
            this.bindingNavigatorCost.ResumeLayout(false);
            this.bindingNavigatorCost.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.DataGridView dgList;
        public System.Windows.Forms.DataGridView dgListItem;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnEntity;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIsCanChange;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.BindingNavigator bindingNavigatorCost;
        private System.Windows.Forms.ToolStripButton ButtonNew;
        private System.Windows.Forms.ToolStripButton ButtonEdit;
        private System.Windows.Forms.ToolStripButton ButtonDelete;
        public System.Windows.Forms.TableLayoutPanel panelForm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_IsDeleted;
        private System.Windows.Forms.DataGridViewImageColumn Column_IsDeletedPic;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Title;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Terminology;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Comment;
    }
}