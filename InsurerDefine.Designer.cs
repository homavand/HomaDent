namespace Dentistry
{
    partial class InsurerDefine
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
            this.PanelX1 = new Dentistry.UserControls.ExPanel();
            this.OkBtn = new System.Windows.Forms.Button();
            this.IsActiveChk = new System.Windows.Forms.RadioButton();
            this.IsDeActiveChk = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CommentTxt = new System.Windows.Forms.TextBox();
            this.Error_PercentTxt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.IsExtraChk = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.InsurerTitleTxt = new System.Windows.Forms.TextBox();
            this.IsBasicChk = new System.Windows.Forms.CheckBox();
            this.Error_InsurerTitleTxt = new System.Windows.Forms.Label();
            this.PercentTxt = new Dentistry.UserControls.CurrencyTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.InsuranceBoxCbo = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.Error_InsuranceCbo = new System.Windows.Forms.Label();
            this.InsuranceCbo = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.startDateTxt = new Dentistry.UserControls.PersianDateTimePicker();
            this.endDateTxt = new Dentistry.UserControls.PersianDateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.PanelX1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelX1
            // 
            this.PanelX1.BackColor = System.Drawing.Color.White;
            this.PanelX1.BorderColor = System.Drawing.Color.Gainsboro;
            this.PanelX1.Controls.Add(this.endDateTxt);
            this.PanelX1.Controls.Add(this.label3);
            this.PanelX1.Controls.Add(this.startDateTxt);
            this.PanelX1.Controls.Add(this.label7);
            this.PanelX1.Controls.Add(this.OkBtn);
            this.PanelX1.Controls.Add(this.IsActiveChk);
            this.PanelX1.Controls.Add(this.IsDeActiveChk);
            this.PanelX1.Controls.Add(this.label12);
            this.PanelX1.Controls.Add(this.panel1);
            this.PanelX1.Controls.Add(this.CommentTxt);
            this.PanelX1.Controls.Add(this.Error_PercentTxt);
            this.PanelX1.Controls.Add(this.label1);
            this.PanelX1.Controls.Add(this.IsExtraChk);
            this.PanelX1.Controls.Add(this.label16);
            this.PanelX1.Controls.Add(this.InsurerTitleTxt);
            this.PanelX1.Controls.Add(this.IsBasicChk);
            this.PanelX1.Controls.Add(this.Error_InsurerTitleTxt);
            this.PanelX1.Controls.Add(this.PercentTxt);
            this.PanelX1.Controls.Add(this.label4);
            this.PanelX1.Controls.Add(this.label2);
            this.PanelX1.Controls.Add(this.InsuranceBoxCbo);
            this.PanelX1.Controls.Add(this.label13);
            this.PanelX1.Controls.Add(this.label11);
            this.PanelX1.Controls.Add(this.Error_InsuranceCbo);
            this.PanelX1.Controls.Add(this.InsuranceCbo);
            this.PanelX1.Controls.Add(this.label5);
            this.PanelX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelX1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelX1.Location = new System.Drawing.Point(15, 15);
            this.PanelX1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.PanelX1.Name = "PanelX1";
            this.PanelX1.Size = new System.Drawing.Size(827, 467);
            this.PanelX1.TabIndex = 100;
            this.PanelX1.TabStop = false;
            // 
            // OkBtn
            // 
            this.OkBtn.BackColor = System.Drawing.Color.White;
            this.OkBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.OkBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.Font = new System.Drawing.Font("Vazir", 9.5F, System.Drawing.FontStyle.Bold);
            this.OkBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.OkBtn.Location = new System.Drawing.Point(20, 420);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(150, 30);
            this.OkBtn.TabIndex = 10;
            this.OkBtn.Text = "تایید ";
            this.OkBtn.UseVisualStyleBackColor = false;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // IsActiveChk
            // 
            this.IsActiveChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsActiveChk.BackColor = System.Drawing.Color.Honeydew;
            this.IsActiveChk.Checked = true;
            this.IsActiveChk.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsActiveChk.Location = new System.Drawing.Point(581, 352);
            this.IsActiveChk.Name = "IsActiveChk";
            this.IsActiveChk.Padding = new System.Windows.Forms.Padding(5);
            this.IsActiveChk.Size = new System.Drawing.Size(90, 34);
            this.IsActiveChk.TabIndex = 8;
            this.IsActiveChk.TabStop = true;
            this.IsActiveChk.Text = "فعال";
            this.IsActiveChk.UseVisualStyleBackColor = false;
            // 
            // IsDeActiveChk
            // 
            this.IsDeActiveChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsDeActiveChk.BackColor = System.Drawing.Color.LavenderBlush;
            this.IsDeActiveChk.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsDeActiveChk.Location = new System.Drawing.Point(483, 352);
            this.IsDeActiveChk.Name = "IsDeActiveChk";
            this.IsDeActiveChk.Padding = new System.Windows.Forms.Padding(5);
            this.IsDeActiveChk.Size = new System.Drawing.Size(90, 34);
            this.IsDeActiveChk.TabIndex = 9;
            this.IsDeActiveChk.Text = "غیر فعال";
            this.IsDeActiveChk.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(685, 359);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(59, 21);
            this.label12.TabIndex = 160;
            this.label12.Text = "وضعیت :";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(69, 161);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(692, 1);
            this.panel1.TabIndex = 119;
            // 
            // CommentTxt
            // 
            this.CommentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentTxt.Location = new System.Drawing.Point(84, 317);
            this.CommentTxt.Name = "CommentTxt";
            this.CommentTxt.Size = new System.Drawing.Size(588, 28);
            this.CommentTxt.TabIndex = 7;
            // 
            // Error_PercentTxt
            // 
            this.Error_PercentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_PercentTxt.AutoSize = true;
            this.Error_PercentTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_PercentTxt.ForeColor = System.Drawing.Color.Red;
            this.Error_PercentTxt.Location = new System.Drawing.Point(549, 195);
            this.Error_PercentTxt.Name = "Error_PercentTxt";
            this.Error_PercentTxt.Size = new System.Drawing.Size(16, 21);
            this.Error_PercentTxt.TabIndex = 116;
            this.Error_PercentTxt.Text = "*";
            this.Error_PercentTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_PercentTxt.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(685, 227);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 28);
            this.label1.TabIndex = 115;
            this.label1.Text = "نوع بیمه :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // IsExtraChk
            // 
            this.IsExtraChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsExtraChk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.IsExtraChk.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsExtraChk.Location = new System.Drawing.Point(472, 227);
            this.IsExtraChk.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.IsExtraChk.Name = "IsExtraChk";
            this.IsExtraChk.Size = new System.Drawing.Size(99, 28);
            this.IsExtraChk.TabIndex = 6;
            this.IsExtraChk.Text = "بیمه تکمیلی";
            this.IsExtraChk.UseVisualStyleBackColor = false;
            // 
            // label16
            // 
            this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(561, 188);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(20, 21);
            this.label16.TabIndex = 114;
            this.label16.Text = "%";
            // 
            // InsurerTitleTxt
            // 
            this.InsurerTitleTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsurerTitleTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsurerTitleTxt.Location = new System.Drawing.Point(84, 107);
            this.InsurerTitleTxt.Name = "InsurerTitleTxt";
            this.InsurerTitleTxt.Size = new System.Drawing.Size(588, 28);
            this.InsurerTitleTxt.TabIndex = 3;
            // 
            // IsBasicChk
            // 
            this.IsBasicChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsBasicChk.BackColor = System.Drawing.Color.WhiteSmoke;
            this.IsBasicChk.Checked = true;
            this.IsBasicChk.CheckState = System.Windows.Forms.CheckState.Checked;
            this.IsBasicChk.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsBasicChk.Location = new System.Drawing.Point(578, 227);
            this.IsBasicChk.Margin = new System.Windows.Forms.Padding(3, 8, 3, 8);
            this.IsBasicChk.Name = "IsBasicChk";
            this.IsBasicChk.Size = new System.Drawing.Size(93, 28);
            this.IsBasicChk.TabIndex = 5;
            this.IsBasicChk.Text = "بیمه پایه";
            this.IsBasicChk.UseVisualStyleBackColor = false;
            // 
            // Error_InsurerTitleTxt
            // 
            this.Error_InsurerTitleTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_InsurerTitleTxt.AutoSize = true;
            this.Error_InsurerTitleTxt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_InsurerTitleTxt.ForeColor = System.Drawing.Color.Red;
            this.Error_InsurerTitleTxt.Location = new System.Drawing.Point(69, 111);
            this.Error_InsurerTitleTxt.Name = "Error_InsurerTitleTxt";
            this.Error_InsurerTitleTxt.Size = new System.Drawing.Size(13, 13);
            this.Error_InsurerTitleTxt.TabIndex = 115;
            this.Error_InsurerTitleTxt.Text = "*";
            this.Error_InsurerTitleTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_InsurerTitleTxt.Visible = false;
            // 
            // PercentTxt
            // 
            this.PercentTxt.AllowPoint = false;
            this.PercentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PercentTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PercentTxt.Location = new System.Drawing.Point(583, 185);
            this.PercentTxt.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.PercentTxt.MaxLength = 10;
            this.PercentTxt.MinLength = 0;
            this.PercentTxt.MoveToNextOnEnterKey = true;
            this.PercentTxt.Name = "PercentTxt";
            this.PercentTxt.ShowToolTip = true;
            this.PercentTxt.Size = new System.Drawing.Size(88, 28);
            this.PercentTxt.TabIndex = 4;
            this.PercentTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PercentTxt.TextChanged += new System.EventHandler(this.PercentTxt_TextChanged);
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(682, 318);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(136, 25);
            this.label4.TabIndex = 3;
            this.label4.Text = "توضیحات :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(682, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(131, 26);
            this.label2.TabIndex = 1;
            this.label2.Text = "درصد بیمه :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InsuranceBoxCbo
            // 
            this.InsuranceBoxCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsuranceBoxCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InsuranceBoxCbo.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsuranceBoxCbo.FormattingEnabled = true;
            this.InsuranceBoxCbo.Location = new System.Drawing.Point(401, 61);
            this.InsuranceBoxCbo.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.InsuranceBoxCbo.Name = "InsuranceBoxCbo";
            this.InsuranceBoxCbo.Size = new System.Drawing.Size(271, 29);
            this.InsuranceBoxCbo.TabIndex = 2;
            this.InsuranceBoxCbo.SelectedIndexChanged += new System.EventHandler(this.InsuranceBoxCbo_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(677, 62);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(136, 25);
            this.label13.TabIndex = 110;
            this.label13.Text = " صندوق بیمه :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(682, 110);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(136, 21);
            this.label11.TabIndex = 108;
            this.label11.Text = "عنوان بیمه گر :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Error_InsuranceCbo
            // 
            this.Error_InsuranceCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_InsuranceCbo.AutoSize = true;
            this.Error_InsuranceCbo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_InsuranceCbo.ForeColor = System.Drawing.Color.Red;
            this.Error_InsuranceCbo.Location = new System.Drawing.Point(386, 23);
            this.Error_InsuranceCbo.Name = "Error_InsuranceCbo";
            this.Error_InsuranceCbo.Size = new System.Drawing.Size(13, 13);
            this.Error_InsuranceCbo.TabIndex = 83;
            this.Error_InsuranceCbo.Text = "*";
            this.Error_InsuranceCbo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_InsuranceCbo.Visible = false;
            // 
            // InsuranceCbo
            // 
            this.InsuranceCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.InsuranceCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.InsuranceCbo.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.InsuranceCbo.FormattingEnabled = true;
            this.InsuranceCbo.Location = new System.Drawing.Point(401, 16);
            this.InsuranceCbo.Margin = new System.Windows.Forms.Padding(3, 9, 3, 9);
            this.InsuranceCbo.Name = "InsuranceCbo";
            this.InsuranceCbo.Size = new System.Drawing.Size(271, 29);
            this.InsuranceCbo.TabIndex = 1;
            this.InsuranceCbo.SelectedIndexChanged += new System.EventHandler(this.InsuranceCbo_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(678, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "عتوان بیمه :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(250, 187);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(131, 26);
            this.label7.TabIndex = 161;
            this.label7.Text = "تاریخ شروع :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // startDateTxt
            // 
            this.startDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.startDateTxt.BackColor = System.Drawing.Color.White;
            this.startDateTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.startDateTxt.Location = new System.Drawing.Point(84, 188);
            this.startDateTxt.Name = "startDateTxt";
            this.startDateTxt.ShowTime = false;
            this.startDateTxt.Size = new System.Drawing.Size(160, 25);
            this.startDateTxt.TabIndex = 162;
            this.startDateTxt.Text = "persianDateTimePicker1";
            // 
            // endDateTxt
            // 
            this.endDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.endDateTxt.BackColor = System.Drawing.Color.White;
            this.endDateTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.endDateTxt.Location = new System.Drawing.Point(84, 230);
            this.endDateTxt.Name = "endDateTxt";
            this.endDateTxt.ShowTime = false;
            this.endDateTxt.Size = new System.Drawing.Size(160, 25);
            this.endDateTxt.TabIndex = 164;
            this.endDateTxt.Text = "persianDateTimePicker1";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(250, 229);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(131, 26);
            this.label3.TabIndex = 163;
            this.label3.Text = "تاریخ خاتمه :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // InsurerDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(857, 497);
            this.Controls.Add(this.PanelX1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InsurerDefine";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Tag = "";
            this.Text = "تعریف بیمه گر و قرارداد";
            this.Load += new System.EventHandler(this.InsurerDefine_Load);
            this.PanelX1.ResumeLayout(false);
            this.PanelX1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ExPanel PanelX1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label Error_InsuranceCbo;
        private System.Windows.Forms.ComboBox InsuranceCbo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private UserControls.CurrencyTextBox PercentTxt;
        private System.Windows.Forms.ComboBox InsuranceBoxCbo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox IsExtraChk;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox IsBasicChk;
        private System.Windows.Forms.Label Error_InsurerTitleTxt;
        private System.Windows.Forms.Label Error_PercentTxt;
        private System.Windows.Forms.TextBox InsurerTitleTxt;
        private System.Windows.Forms.TextBox CommentTxt;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.RadioButton IsActiveChk;
        public System.Windows.Forms.RadioButton IsDeActiveChk;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Label label7;
        private UserControls.PersianDateTimePicker endDateTxt;
        private System.Windows.Forms.Label label3;
        private UserControls.PersianDateTimePicker startDateTxt;
    }
}