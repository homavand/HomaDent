namespace Dentistry
{
    partial class SpecialDiseaseList
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
            this.dataGridViewSelectIllness = new System.Windows.Forms.DataGridView();
            this.ColumnSpecialDiseaseId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnIsCheck = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.ColumnIllnessName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel_Illness = new UserControls.ExPanel();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectIllness)).BeginInit();
            this.panel_Illness.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridViewSelectIllness
            // 
            this.dataGridViewSelectIllness.AllowUserToAddRows = false;
            this.dataGridViewSelectIllness.AllowUserToDeleteRows = false;
            this.dataGridViewSelectIllness.AllowUserToOrderColumns = true;
            this.dataGridViewSelectIllness.AllowUserToResizeColumns = false;
            this.dataGridViewSelectIllness.AllowUserToResizeRows = false;
            this.dataGridViewSelectIllness.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewSelectIllness.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewSelectIllness.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(82)))), ((int)(((byte)(60)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 2);
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelectIllness.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewSelectIllness.ColumnHeadersHeight = 26;
            this.dataGridViewSelectIllness.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridViewSelectIllness.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnSpecialDiseaseId,
            this.ColumnIsCheck,
            this.ColumnIllnessName});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewSelectIllness.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewSelectIllness.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewSelectIllness.GridColor = System.Drawing.Color.White;
            this.dataGridViewSelectIllness.Location = new System.Drawing.Point(0, 0);
            this.dataGridViewSelectIllness.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dataGridViewSelectIllness.Name = "dataGridViewSelectIllness";
            this.dataGridViewSelectIllness.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Empty;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewSelectIllness.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewSelectIllness.RowHeadersVisible = false;
            this.dataGridViewSelectIllness.RowTemplate.DefaultCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.dataGridViewSelectIllness.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.White;
            this.dataGridViewSelectIllness.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            this.dataGridViewSelectIllness.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.White;
            this.dataGridViewSelectIllness.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewSelectIllness.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewSelectIllness.Size = new System.Drawing.Size(239, 280);
            this.dataGridViewSelectIllness.TabIndex = 5;
            this.dataGridViewSelectIllness.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectIllness_CellClick);
            this.dataGridViewSelectIllness.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewSelectIllness_CellContentClick);
            // 
            // ColumnSpecialDiseaseId
            // 
            this.ColumnSpecialDiseaseId.DataPropertyName = "Id";
            this.ColumnSpecialDiseaseId.HeaderText = "SpecialDiseasId";
            this.ColumnSpecialDiseaseId.Name = "ColumnSpecialDiseaseId";
            this.ColumnSpecialDiseaseId.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.ColumnSpecialDiseaseId.Visible = false;
            // 
            // ColumnIsCheck
            // 
            this.ColumnIsCheck.DataPropertyName = "IsCheck";
            this.ColumnIsCheck.FalseValue = "False";
            this.ColumnIsCheck.HeaderText = "انتخاب";
            this.ColumnIsCheck.Name = "ColumnIsCheck";
            this.ColumnIsCheck.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnIsCheck.TrueValue = "True";
            this.ColumnIsCheck.Width = 50;
            // 
            // ColumnIllnessName
            // 
            this.ColumnIllnessName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnIllnessName.DataPropertyName = "Title";
            this.ColumnIllnessName.HeaderText = "نام بیماری";
            this.ColumnIllnessName.Name = "ColumnIllnessName";
            // 
            // panel_Illness
            // 
            this.panel_Illness.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Illness.BackColor = System.Drawing.Color.Transparent;
            this.panel_Illness.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.panel_Illness.Controls.Add(this.dataGridViewSelectIllness);
            this.panel_Illness.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel_Illness.Location = new System.Drawing.Point(30, 32);
            this.panel_Illness.Name = "panel_Illness";
            this.panel_Illness.Size = new System.Drawing.Size(239, 280);
            this.panel_Illness.TabIndex = 0;
            // 
            // FormSpecialDisease
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(306, 413);
            this.Controls.Add(this.panel_Illness);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FormSpecialDisease";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Activated += new System.EventHandler(this.FormSelectIllness_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSelectIllness)).EndInit();
            this.panel_Illness.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewSelectIllness;
        public UserControls.ExPanel panel_Illness;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnSpecialDiseaseId;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ColumnIsCheck;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnIllnessName;
    }
}