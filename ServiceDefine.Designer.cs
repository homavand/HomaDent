namespace Dentistry
{
    partial class ServiceDefine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelControls = new Dentistry.UserControls.ExPanel();
            this.OkBtn = new System.Windows.Forms.Button();
            this.IsActiveChk = new System.Windows.Forms.RadioButton();
            this.IsDeActiveChk = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.ServiceCodeTxt = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.serviceGroupTitleLbl = new System.Windows.Forms.Label();
            this.dgServiceGroup = new System.Windows.Forms.DataGridView();
            this.ColumnServiceGroupId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceGroupColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnColor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceGroupTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnServiceGroupIsDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Error_ServicePrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.ServicePriceTxt = new Dentistry.UserControls.CurrencyTextBox();
            this.CommentTxt = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.IsMoreToothChk = new System.Windows.Forms.CheckBox();
            this.ServiceTitleTxt = new System.Windows.Forms.TextBox();
            this.ColorLbl = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Error_ServiceTitle = new System.Windows.Forms.Label();
            this.Error_ServiceCode = new System.Windows.Forms.Label();
            this.Error_ServiceGroup = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.IsToothNumberChk = new System.Windows.Forms.CheckBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.panelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgServiceGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControls
            // 
            this.panelControls.BackColor = System.Drawing.Color.White;
            this.panelControls.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.panelControls.Controls.Add(this.OkBtn);
            this.panelControls.Controls.Add(this.IsActiveChk);
            this.panelControls.Controls.Add(this.IsDeActiveChk);
            this.panelControls.Controls.Add(this.label12);
            this.panelControls.Controls.Add(this.ServiceCodeTxt);
            this.panelControls.Controls.Add(this.panel1);
            this.panelControls.Controls.Add(this.label7);
            this.panelControls.Controls.Add(this.serviceGroupTitleLbl);
            this.panelControls.Controls.Add(this.dgServiceGroup);
            this.panelControls.Controls.Add(this.Error_ServicePrice);
            this.panelControls.Controls.Add(this.label5);
            this.panelControls.Controls.Add(this.ServicePriceTxt);
            this.panelControls.Controls.Add(this.CommentTxt);
            this.panelControls.Controls.Add(this.label6);
            this.panelControls.Controls.Add(this.IsMoreToothChk);
            this.panelControls.Controls.Add(this.ServiceTitleTxt);
            this.panelControls.Controls.Add(this.ColorLbl);
            this.panelControls.Controls.Add(this.label4);
            this.panelControls.Controls.Add(this.Error_ServiceTitle);
            this.panelControls.Controls.Add(this.Error_ServiceCode);
            this.panelControls.Controls.Add(this.Error_ServiceGroup);
            this.panelControls.Controls.Add(this.pictureBox);
            this.panelControls.Controls.Add(this.label3);
            this.panelControls.Controls.Add(this.label1);
            this.panelControls.Controls.Add(this.label2);
            this.panelControls.Controls.Add(this.IsToothNumberChk);
            this.panelControls.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelControls.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panelControls.Location = new System.Drawing.Point(15, 15);
            this.panelControls.Name = "panelControls";
            this.panelControls.Size = new System.Drawing.Size(835, 451);
            this.panelControls.TabIndex = 24;
            this.panelControls.Load += new System.EventHandler(this.panelControls_Load);
            // 
            // OkBtn
            // 
            this.OkBtn.BackColor = System.Drawing.Color.White;
            this.OkBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.OkBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.Font = new System.Drawing.Font("Vazir", 9.5F, System.Drawing.FontStyle.Bold);
            this.OkBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.OkBtn.Location = new System.Drawing.Point(16, 405);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(150, 30);
            this.OkBtn.TabIndex = 32;
            this.OkBtn.Text = "تایید ";
            this.OkBtn.UseVisualStyleBackColor = false;
            this.OkBtn.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // IsActiveChk
            // 
            this.IsActiveChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsActiveChk.BackColor = System.Drawing.Color.Honeydew;
            this.IsActiveChk.Checked = true;
            this.IsActiveChk.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsActiveChk.Location = new System.Drawing.Point(357, 332);
            this.IsActiveChk.Name = "IsActiveChk";
            this.IsActiveChk.Padding = new System.Windows.Forms.Padding(5);
            this.IsActiveChk.Size = new System.Drawing.Size(90, 34);
            this.IsActiveChk.TabIndex = 172;
            this.IsActiveChk.TabStop = true;
            this.IsActiveChk.Text = "فعال";
            this.IsActiveChk.UseVisualStyleBackColor = false;
            // 
            // IsDeActiveChk
            // 
            this.IsDeActiveChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsDeActiveChk.BackColor = System.Drawing.Color.LavenderBlush;
            this.IsDeActiveChk.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsDeActiveChk.Location = new System.Drawing.Point(259, 332);
            this.IsDeActiveChk.Name = "IsDeActiveChk";
            this.IsDeActiveChk.Padding = new System.Windows.Forms.Padding(5);
            this.IsDeActiveChk.Size = new System.Drawing.Size(90, 34);
            this.IsDeActiveChk.TabIndex = 173;
            this.IsDeActiveChk.Text = "غیر فعال";
            this.IsDeActiveChk.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(459, 339);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 20);
            this.label12.TabIndex = 174;
            this.label12.Text = "وضعیت :";
            // 
            // ServiceCodeTxt
            // 
            this.ServiceCodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ServiceCodeTxt.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.ServiceCodeTxt.Location = new System.Drawing.Point(64, 63);
            this.ServiceCodeTxt.Name = "ServiceCodeTxt";
            this.ServiceCodeTxt.Size = new System.Drawing.Size(386, 28);
            this.ServiceCodeTxt.TabIndex = 33;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Lavender;
            this.panel1.Location = new System.Drawing.Point(35, 216);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(484, 5);
            this.panel1.TabIndex = 171;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(459, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 20);
            this.label7.TabIndex = 170;
            this.label7.Text = "گروه خدمت :";
            // 
            // serviceGroupTitleLbl
            // 
            this.serviceGroupTitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.serviceGroupTitleLbl.BackColor = System.Drawing.Color.Lavender;
            this.serviceGroupTitleLbl.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.serviceGroupTitleLbl.Location = new System.Drawing.Point(64, 27);
            this.serviceGroupTitleLbl.Name = "serviceGroupTitleLbl";
            this.serviceGroupTitleLbl.Padding = new System.Windows.Forms.Padding(5);
            this.serviceGroupTitleLbl.Size = new System.Drawing.Size(387, 29);
            this.serviceGroupTitleLbl.TabIndex = 169;
            this.serviceGroupTitleLbl.Text = "گروه خدمت انتخاب نشده است";
            // 
            // dgServiceGroup
            // 
            this.dgServiceGroup.AllowUserToAddRows = false;
            this.dgServiceGroup.AllowUserToDeleteRows = false;
            this.dgServiceGroup.AllowUserToResizeColumns = false;
            this.dgServiceGroup.AllowUserToResizeRows = false;
            this.dgServiceGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgServiceGroup.BackgroundColor = System.Drawing.Color.White;
            this.dgServiceGroup.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgServiceGroup.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgServiceGroup.ColumnHeadersHeight = 30;
            this.dgServiceGroup.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgServiceGroup.ColumnHeadersVisible = false;
            this.dgServiceGroup.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnServiceGroupId,
            this.ColumnServiceGroupColor,
            this.ColumnColor,
            this.ColumnServiceGroupTitle,
            this.ColumnServiceGroupIsDeleted});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgServiceGroup.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgServiceGroup.EnableHeadersVisualStyles = false;
            this.dgServiceGroup.GridColor = System.Drawing.Color.White;
            this.dgServiceGroup.Location = new System.Drawing.Point(574, 29);
            this.dgServiceGroup.MultiSelect = false;
            this.dgServiceGroup.Name = "dgServiceGroup";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgServiceGroup.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgServiceGroup.RowHeadersVisible = false;
            this.dgServiceGroup.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir", 9.5F);
            this.dgServiceGroup.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgServiceGroup.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.dgServiceGroup.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgServiceGroup.RowTemplate.Height = 30;
            this.dgServiceGroup.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgServiceGroup.Size = new System.Drawing.Size(240, 337);
            this.dgServiceGroup.TabIndex = 166;
            this.dgServiceGroup.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgServiceGroup_CellFormatting);
            this.dgServiceGroup.CellPainting += new System.Windows.Forms.DataGridViewCellPaintingEventHandler(this.dgServiceGroup_CellPainting);
            this.dgServiceGroup.SelectionChanged += new System.EventHandler(this.dgServiceGroup_SelectionChanged);
            // 
            // ColumnServiceGroupId
            // 
            this.ColumnServiceGroupId.DataPropertyName = "Id";
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnServiceGroupId.DefaultCellStyle = dataGridViewCellStyle1;
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
            // ColumnColor
            // 
            this.ColumnColor.HeaderText = "";
            this.ColumnColor.Name = "ColumnColor";
            this.ColumnColor.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.ColumnColor.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColumnColor.Width = 30;
            // 
            // ColumnServiceGroupTitle
            // 
            this.ColumnServiceGroupTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnServiceGroupTitle.DataPropertyName = "Title";
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnServiceGroupTitle.DefaultCellStyle = dataGridViewCellStyle2;
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
            // Error_ServicePrice
            // 
            this.Error_ServicePrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_ServicePrice.AutoSize = true;
            this.Error_ServicePrice.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_ServicePrice.ForeColor = System.Drawing.Color.Red;
            this.Error_ServicePrice.Location = new System.Drawing.Point(42, 179);
            this.Error_ServicePrice.Name = "Error_ServicePrice";
            this.Error_ServicePrice.Size = new System.Drawing.Size(15, 16);
            this.Error_ServicePrice.TabIndex = 157;
            this.Error_ServicePrice.Text = "*";
            this.Error_ServicePrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_ServicePrice.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(458, 174);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(67, 20);
            this.label5.TabIndex = 155;
            this.label5.Text = "تعرفه آزاد :";
            // 
            // ServicePriceTxt
            // 
            this.ServicePriceTxt.AllowPoint = false;
            this.ServicePriceTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ServicePriceTxt.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.ServicePriceTxt.Location = new System.Drawing.Point(64, 169);
            this.ServicePriceTxt.MaxLength = 18;
            this.ServicePriceTxt.MinLength = 0;
            this.ServicePriceTxt.MoveToNextOnEnterKey = true;
            this.ServicePriceTxt.Name = "ServicePriceTxt";
            this.ServicePriceTxt.ShowToolTip = true;
            this.ServicePriceTxt.Size = new System.Drawing.Size(386, 28);
            this.ServicePriceTxt.TabIndex = 5;
            this.ServicePriceTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CommentTxt
            // 
            this.CommentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentTxt.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.CommentTxt.Location = new System.Drawing.Point(64, 134);
            this.CommentTxt.Name = "CommentTxt";
            this.CommentTxt.Size = new System.Drawing.Size(386, 28);
            this.CommentTxt.TabIndex = 4;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(459, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 20);
            this.label6.TabIndex = 152;
            this.label6.Text = "توضیحات :";
            // 
            // IsMoreToothChk
            // 
            this.IsMoreToothChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsMoreToothChk.AutoSize = true;
            this.IsMoreToothChk.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsMoreToothChk.Location = new System.Drawing.Point(206, 297);
            this.IsMoreToothChk.Name = "IsMoreToothChk";
            this.IsMoreToothChk.Size = new System.Drawing.Size(243, 24);
            this.IsMoreToothChk.TabIndex = 8;
            this.IsMoreToothChk.Text = "میتواند برروی بیش از 1 دندان انجام گیرد";
            this.IsMoreToothChk.UseVisualStyleBackColor = true;
            // 
            // ServiceTitleTxt
            // 
            this.ServiceTitleTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ServiceTitleTxt.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.ServiceTitleTxt.Location = new System.Drawing.Point(64, 98);
            this.ServiceTitleTxt.Name = "ServiceTitleTxt";
            this.ServiceTitleTxt.Size = new System.Drawing.Size(386, 28);
            this.ServiceTitleTxt.TabIndex = 3;
            // 
            // ColorLbl
            // 
            this.ColorLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ColorLbl.AutoSize = true;
            this.ColorLbl.BackColor = System.Drawing.Color.Black;
            this.ColorLbl.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColorLbl.Location = new System.Drawing.Point(432, 236);
            this.ColorLbl.Name = "ColorLbl";
            this.ColorLbl.Size = new System.Drawing.Size(17, 18);
            this.ColorLbl.TabIndex = 6;
            this.ColorLbl.Text = "   ";
            this.ColorLbl.Click += new System.EventHandler(this.ColorLbl_Click);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(314, 236);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(118, 20);
            this.label4.TabIndex = 118;
            this.label4.Text = "رنگ نمایش گرافیکی ";
            // 
            // Error_ServiceTitle
            // 
            this.Error_ServiceTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_ServiceTitle.AutoSize = true;
            this.Error_ServiceTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_ServiceTitle.ForeColor = System.Drawing.Color.Red;
            this.Error_ServiceTitle.Location = new System.Drawing.Point(42, 107);
            this.Error_ServiceTitle.Name = "Error_ServiceTitle";
            this.Error_ServiceTitle.Size = new System.Drawing.Size(15, 16);
            this.Error_ServiceTitle.TabIndex = 117;
            this.Error_ServiceTitle.Text = "*";
            this.Error_ServiceTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_ServiceTitle.Visible = false;
            // 
            // Error_ServiceCode
            // 
            this.Error_ServiceCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_ServiceCode.AutoSize = true;
            this.Error_ServiceCode.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_ServiceCode.ForeColor = System.Drawing.Color.Red;
            this.Error_ServiceCode.Location = new System.Drawing.Point(42, 72);
            this.Error_ServiceCode.Name = "Error_ServiceCode";
            this.Error_ServiceCode.Size = new System.Drawing.Size(15, 16);
            this.Error_ServiceCode.TabIndex = 116;
            this.Error_ServiceCode.Text = "*";
            this.Error_ServiceCode.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_ServiceCode.Visible = false;
            // 
            // Error_ServiceGroup
            // 
            this.Error_ServiceGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_ServiceGroup.AutoSize = true;
            this.Error_ServiceGroup.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_ServiceGroup.ForeColor = System.Drawing.Color.Red;
            this.Error_ServiceGroup.Location = new System.Drawing.Point(42, 35);
            this.Error_ServiceGroup.Name = "Error_ServiceGroup";
            this.Error_ServiceGroup.Size = new System.Drawing.Size(15, 16);
            this.Error_ServiceGroup.TabIndex = 115;
            this.Error_ServiceGroup.Text = "*";
            this.Error_ServiceGroup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_ServiceGroup.Visible = false;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(-131, 19);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(100, 103);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 114;
            this.pictureBox.TabStop = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(743, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 34;
            this.label3.Text = "گروه خدمات";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(459, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "عتوان خدمت :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(459, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "کد خدمت :";
            // 
            // IsToothNumberChk
            // 
            this.IsToothNumberChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsToothNumberChk.AutoSize = true;
            this.IsToothNumberChk.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsToothNumberChk.Location = new System.Drawing.Point(301, 266);
            this.IsToothNumberChk.Name = "IsToothNumberChk";
            this.IsToothNumberChk.Size = new System.Drawing.Size(148, 24);
            this.IsToothNumberChk.TabIndex = 7;
            this.IsToothNumberChk.Text = "تاکید برای شماره دندان";
            this.IsToothNumberChk.UseVisualStyleBackColor = true;
            // 
            // ServiceDefine
            // 
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(865, 481);
            this.Controls.Add(this.panelControls);
            this.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ServiceDefine";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = " تعریف سرویس  ";
            this.Load += new System.EventHandler(this.ServiceDefine_Load);
            this.panelControls.ResumeLayout(false);
            this.panelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgServiceGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ExPanel panelControls;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Error_ServiceTitle;
        private System.Windows.Forms.Label Error_ServiceCode;
        private System.Windows.Forms.Label Error_ServiceGroup;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.CheckBox IsToothNumberChk;
        public System.Windows.Forms.Label ColorLbl;
        private System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.TextBox ServiceTitleTxt;
        public System.Windows.Forms.CheckBox IsMoreToothChk;
        public System.Windows.Forms.TextBox CommentTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Error_ServicePrice;
        private System.Windows.Forms.Label label5;
        private UserControls.CurrencyTextBox ServicePriceTxt;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.DataGridView dgServiceGroup;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label serviceGroupTitleLbl;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.TextBox ServiceCodeTxt;
        public System.Windows.Forms.RadioButton IsActiveChk;
        public System.Windows.Forms.RadioButton IsDeActiveChk;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceGroupId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceGroupColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnColor;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceGroupTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnServiceGroupIsDeleted;
    }
}
