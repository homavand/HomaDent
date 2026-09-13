namespace Dentistry
{
    partial class PatientsBlackList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgPatients = new System.Windows.Forms.DataGridView();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.ButtonDelete = new System.Windows.Forms.ToolStripButton();
            this.ButtonRemoveFromBlackListAndAddToIllList = new System.Windows.Forms.ToolStripButton();
            this.ColumnPatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColDoctorTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnPresenter = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnNationalCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalPayable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalDiscount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTotalBalance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnMobilePhone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnComment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColPatientId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPatients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.dgPatients);
            this.panel1.Controls.Add(this.bindingNavigator1);
            this.panel1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1160, 437);
            this.panel1.TabIndex = 24;
            // 
            // dgPatients
            // 
            this.dgPatients.AllowUserToAddRows = false;
            this.dgPatients.AllowUserToDeleteRows = false;
            this.dgPatients.AllowUserToResizeColumns = false;
            this.dgPatients.AllowUserToResizeRows = false;
            this.dgPatients.BackgroundColor = System.Drawing.Color.White;
            this.dgPatients.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgPatients.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPatients.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgPatients.ColumnHeadersHeight = 35;
            this.dgPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgPatients.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnPatientId,
            this.ColumnFullName,
            this.ColDoctorTitle,
            this.ColumnPresenter,
            this.ColumnNationalCode,
            this.ColTotalPrice,
            this.ColTotalPayable,
            this.ColTotalDiscount,
            this.ColTotalBalance,
            this.ColumnMobilePhone,
            this.ColumnComment,
            this.ColPatientId,
            this.ColIsDeleted});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgPatients.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgPatients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgPatients.EnableHeadersVisualStyles = false;
            this.dgPatients.GridColor = System.Drawing.Color.White;
            this.dgPatients.Location = new System.Drawing.Point(0, 0);
            this.dgPatients.MultiSelect = false;
            this.dgPatients.Name = "dgPatients";
            this.dgPatients.ReadOnly = true;
            this.dgPatients.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgPatients.RowHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgPatients.RowHeadersVisible = false;
            this.dgPatients.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dgPatients.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgPatients.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dgPatients.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.dgPatients.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.dgPatients.RowTemplate.Height = 30;
            this.dgPatients.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPatients.Size = new System.Drawing.Size(1160, 407);
            this.dgPatients.TabIndex = 10;
            this.dgPatients.VirtualMode = true;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.AutoSize = false;
            this.bindingNavigator1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.bindingNavigator1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonDelete,
            this.ButtonRemoveFromBlackListAndAddToIllList});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 407);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bindingNavigator1.Size = new System.Drawing.Size(1160, 30);
            this.bindingNavigator1.TabIndex = 6;
            this.bindingNavigator1.Text = "bindingNavigator1";
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Image = global::Dentistry.Properties.Resources.remove;
            this.ButtonDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(176, 27);
            this.ButtonDelete.Text = "حذف از لیست بیماران مطب";
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonRemoveFromBlackListAndAddToIllList
            // 
            this.ButtonRemoveFromBlackListAndAddToIllList.Image = global::Dentistry.Properties.Resources.Symbols_Critical_16xLG;
            this.ButtonRemoveFromBlackListAndAddToIllList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonRemoveFromBlackListAndAddToIllList.Name = "ButtonRemoveFromBlackListAndAddToIllList";
            this.ButtonRemoveFromBlackListAndAddToIllList.Size = new System.Drawing.Size(332, 27);
            this.ButtonRemoveFromBlackListAndAddToIllList.Text = "حذف از لیست بیماران غیرفعال و افزودن به لیست بیماران";
            this.ButtonRemoveFromBlackListAndAddToIllList.Click += new System.EventHandler(this.ButtonRemoveFromBlackListAndAddToIllList_Click);
            // 
            // ColumnPatientId
            // 
            this.ColumnPatientId.DataPropertyName = "PatientId";
            this.ColumnPatientId.HeaderText = "کدبیمار";
            this.ColumnPatientId.Name = "ColumnPatientId";
            this.ColumnPatientId.ReadOnly = true;
            this.ColumnPatientId.Width = 80;
            // 
            // ColumnFullName
            // 
            this.ColumnFullName.DataPropertyName = "PatientName";
            this.ColumnFullName.HeaderText = "نام بیمار";
            this.ColumnFullName.Name = "ColumnFullName";
            this.ColumnFullName.ReadOnly = true;
            this.ColumnFullName.Width = 150;
            // 
            // ColDoctorTitle
            // 
            this.ColDoctorTitle.DataPropertyName = "DoctorTitle";
            this.ColDoctorTitle.HeaderText = "نام پزشک";
            this.ColDoctorTitle.Name = "ColDoctorTitle";
            this.ColDoctorTitle.ReadOnly = true;
            // 
            // ColumnPresenter
            // 
            this.ColumnPresenter.DataPropertyName = "Presenter";
            this.ColumnPresenter.HeaderText = "معرف";
            this.ColumnPresenter.Name = "ColumnPresenter";
            this.ColumnPresenter.ReadOnly = true;
            this.ColumnPresenter.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnNationalCode
            // 
            this.ColumnNationalCode.DataPropertyName = "NationalCode";
            this.ColumnNationalCode.HeaderText = "كدملي";
            this.ColumnNationalCode.Name = "ColumnNationalCode";
            this.ColumnNationalCode.ReadOnly = true;
            this.ColumnNationalCode.Visible = false;
            // 
            // ColTotalPrice
            // 
            this.ColTotalPrice.DataPropertyName = "Total_Patient_Charge";
            dataGridViewCellStyle2.Format = "N0";
            dataGridViewCellStyle2.NullValue = null;
            this.ColTotalPrice.DefaultCellStyle = dataGridViewCellStyle2;
            this.ColTotalPrice.HeaderText = " مبلغ حساب";
            this.ColTotalPrice.Name = "ColTotalPrice";
            this.ColTotalPrice.ReadOnly = true;
            this.ColTotalPrice.Width = 120;
            // 
            // ColTotalPayable
            // 
            this.ColTotalPayable.DataPropertyName = "Total_Patient_Paid";
            dataGridViewCellStyle3.Format = "N0";
            dataGridViewCellStyle3.NullValue = null;
            this.ColTotalPayable.DefaultCellStyle = dataGridViewCellStyle3;
            this.ColTotalPayable.HeaderText = " مبلغ پرداختی";
            this.ColTotalPayable.Name = "ColTotalPayable";
            this.ColTotalPayable.ReadOnly = true;
            this.ColTotalPayable.Width = 120;
            // 
            // ColTotalDiscount
            // 
            this.ColTotalDiscount.DataPropertyName = "Total_Patient_Discount";
            dataGridViewCellStyle4.Format = "N0";
            dataGridViewCellStyle4.NullValue = null;
            this.ColTotalDiscount.DefaultCellStyle = dataGridViewCellStyle4;
            this.ColTotalDiscount.HeaderText = " تخفیفات";
            this.ColTotalDiscount.Name = "ColTotalDiscount";
            this.ColTotalDiscount.ReadOnly = true;
            this.ColTotalDiscount.Width = 120;
            // 
            // ColTotalBalance
            // 
            this.ColTotalBalance.DataPropertyName = "Total_Patient_Remianed";
            dataGridViewCellStyle5.Format = "N0";
            dataGridViewCellStyle5.NullValue = null;
            this.ColTotalBalance.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColTotalBalance.HeaderText = "مانده حساب";
            this.ColTotalBalance.Name = "ColTotalBalance";
            this.ColTotalBalance.ReadOnly = true;
            this.ColTotalBalance.Width = 120;
            // 
            // ColumnMobilePhone
            // 
            this.ColumnMobilePhone.DataPropertyName = "MobilePhone";
            this.ColumnMobilePhone.HeaderText = "تلفن همراه";
            this.ColumnMobilePhone.Name = "ColumnMobilePhone";
            this.ColumnMobilePhone.ReadOnly = true;
            this.ColumnMobilePhone.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnMobilePhone.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColumnComment
            // 
            this.ColumnComment.DataPropertyName = "Comment";
            this.ColumnComment.HeaderText = "توضیحات";
            this.ColumnComment.Name = "ColumnComment";
            this.ColumnComment.ReadOnly = true;
            this.ColumnComment.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnComment.Width = 200;
            // 
            // ColPatientId
            // 
            this.ColPatientId.DataPropertyName = "PatientId";
            this.ColPatientId.HeaderText = "PatientId";
            this.ColPatientId.Name = "ColPatientId";
            this.ColPatientId.ReadOnly = true;
            this.ColPatientId.Visible = false;
            // 
            // ColIsDeleted
            // 
            this.ColIsDeleted.DataPropertyName = "IsDeleted";
            this.ColIsDeleted.HeaderText = "IsDeleted";
            this.ColIsDeleted.Name = "ColIsDeleted";
            this.ColIsDeleted.ReadOnly = true;
            this.ColIsDeleted.Visible = false;
            // 
            // PatientsBlackList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(1184, 461);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximumSize = new System.Drawing.Size(1200, 500);
            this.MinimumSize = new System.Drawing.Size(1200, 500);
            this.Name = "PatientsBlackList";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "لیست بیماران غیرفعال";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPatients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripButton ButtonDelete;
        private System.Windows.Forms.ToolStripButton ButtonRemoveFromBlackListAndAddToIllList;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColBirthDate;
        private System.Windows.Forms.DataGridView dgPatients;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDoctorTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnPresenter;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnNationalCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalPrice;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalPayable;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalDiscount;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTotalBalance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnMobilePhone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnComment;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColPatientId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIsDeleted;
    }
}