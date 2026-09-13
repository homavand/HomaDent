namespace Dentistry
{
    partial class SelectSpecialDrugList
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
            this.panel_Drug = new UserControls.ExPanel();
            this.dataGridViewSelectSpecialDrug = new System.Windows.Forms.DataGridView();
            this.ColumnSpecialDrugID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnSpecialDrugName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Drug.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectSpecialDrug)).BeginInit();
            this.SuspendLayout();
            // 
            // panel_Drug
            // 
            this.panel_Drug.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Drug.BackColor = System.Drawing.Color.Transparent;
            this.panel_Drug.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.panel_Drug.Controls.Add(this.dataGridViewSelectSpecialDrug);
            this.panel_Drug.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_Drug.Location = new System.Drawing.Point(40, 26);
            this.panel_Drug.Name = "panel_Drug";
            this.panel_Drug.Size = new System.Drawing.Size(250, 280);
            this.panel_Drug.TabIndex = 0;
            // 
            // dataGridViewSelectSpecialDrug
            // 
            this.dataGridViewSelectSpecialDrug.AllowUserToAddRows = false;
            this.dataGridViewSelectSpecialDrug.AllowUserToDeleteRows = false;
            this.dataGridViewSelectSpecialDrug.AllowUserToResizeColumns = false;
            this.dataGridViewSelectSpecialDrug.AllowUserToResizeRows = false;
            this.dataGridViewSelectSpecialDrug.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSelectSpecialDrug.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSelectSpecialDrug.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(60)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelectSpecialDrug.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSelectSpecialDrug.ColumnHeadersHeight = 26;
            this.dataGridViewSelectSpecialDrug.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSelectSpecialDrug.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSpecialDrugID,
            this.ColumnIsCheck,
            this.ColumnSpecialDrugName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSelectSpecialDrug.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSelectSpecialDrug.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelectSpecialDrug.GridColor = System.Drawing.Color.White;
            this.dataGridViewSelectSpecialDrug.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSelectSpecialDrug.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewSelectSpecialDrug.MultiSelect = false;
            this.dataGridViewSelectSpecialDrug.Name = "dataGridViewSelectSpecialDrug";
            this.dataGridViewSelectSpecialDrug.ReadOnly = true;
            this.dataGridViewSelectSpecialDrug.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelectSpecialDrug.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSelectSpecialDrug.RowHeadersVisible = false;
            this.dataGridViewSelectSpecialDrug.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewSelectSpecialDrug.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewSelectSpecialDrug.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewSelectSpecialDrug.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridViewSelectSpecialDrug.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewSelectSpecialDrug.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelectSpecialDrug.Size = new System.Drawing.Size(250, 280);
            this.dataGridViewSelectSpecialDrug.TabIndex = 5;
            this.dataGridViewSelectSpecialDrug.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectSpecialDrug_CellClick);
          
            // 
            // ColumnSpecialDrugID
            // 
            this.ColumnSpecialDrugID.DataPropertyName = "Id";
            this.ColumnSpecialDrugID.HeaderText = "Column1";
            this.ColumnSpecialDrugID.Name = "ColumnSpecialDrugID";
            this.ColumnSpecialDrugID.ReadOnly = true;
            this.ColumnSpecialDrugID.Visible = false;
            // 
            // ColumnIsCheck
            // 
            this.ColumnIsCheck.DataPropertyName = "IsCheck";
            this.ColumnIsCheck.FalseValue = false;
            this.ColumnIsCheck.HeaderText = "انتخاب";
            this.ColumnIsCheck.Name = "ColumnIsCheck";
            this.ColumnIsCheck.ReadOnly = true;
            this.ColumnIsCheck.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnIsCheck.TrueValue = true;
            this.ColumnIsCheck.Width = 50;
            // 
            // ColumnSpecialDrugName
            // 
            this.ColumnSpecialDrugName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnSpecialDrugName.DataPropertyName = "Title";
            this.ColumnSpecialDrugName.HeaderText = "لیست داروها";
            this.ColumnSpecialDrugName.Name = "ColumnSpecialDrugName";
            this.ColumnSpecialDrugName.ReadOnly = true;
            // 
            // FormSelectSpecialDrug
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(317, 377);
            this.Controls.Add(this.panel_Drug);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSelectSpecialDrug";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Activated += new System.EventHandler(this.FormSelectSpecialDrug_Activated);
            this.panel_Drug.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectSpecialDrug)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSelectSpecialDrug;
        public UserControls.ExPanel panel_Drug;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpecialDrugID;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpecialDrugName;

    }
}