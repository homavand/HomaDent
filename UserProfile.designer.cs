namespace Dentistry
{
    partial class UserProfile
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panelProfile = new Dentistry.UserControls.ExPanel();
            this.Error_Email = new System.Windows.Forms.Label();
            this.EmailTxt = new Dentistry.UserControls.ExtendedTextBox();
            this.UserNameTxt = new Dentistry.UserControls.ExtendedTextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panelPass = new Dentistry.UserControls.ExPanel();
            this.textBoxRepeatPass = new Dentistry.UserControls.ExtendedTextBox();
            this.textBoxPass = new Dentistry.UserControls.ExtendedTextBox();
            this.Error_Compare = new System.Windows.Forms.Label();
            this.Error_OldPass_Message = new System.Windows.Forms.Label();
            this.textBoxOldPass = new Dentistry.UserControls.ExtendedTextBox();
            this.Error_OldPass = new System.Windows.Forms.Label();
            this.Error_NewPass = new System.Windows.Forms.Label();
            this.Error_RepeatPass = new System.Windows.Forms.Label();
            this.checkBox = new System.Windows.Forms.CheckBox();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab1 = new System.Windows.Forms.TabPage();
            this.buttonOk = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn4 = new System.Windows.Forms.DataGridViewImageColumn();
            this.panelProfile.SuspendLayout();
            this.panelPass.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tab1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label2.Location = new System.Drawing.Point(562, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "رمز  جدید :";
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label3.Location = new System.Drawing.Point(562, 109);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "تکرار رمز  :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label4.Location = new System.Drawing.Point(562, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "رمز  قبلی :";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label1.Location = new System.Drawing.Point(575, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "نام کاربری :";
            // 
            // panelProfile
            // 
            this.panelProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelProfile.BackColor = System.Drawing.Color.Transparent;
            this.panelProfile.BorderColor = System.Drawing.Color.Silver;
            this.panelProfile.Controls.Add(this.Error_Email);
            this.panelProfile.Controls.Add(this.EmailTxt);
            this.panelProfile.Controls.Add(this.UserNameTxt);
            this.panelProfile.Controls.Add(this.label1);
            this.panelProfile.Controls.Add(this.label6);
            this.panelProfile.Controls.Add(this.panelPass);
            this.panelProfile.Controls.Add(this.checkBox);
            this.panelProfile.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.panelProfile.Location = new System.Drawing.Point(8, 23);
            this.panelProfile.Name = "panelProfile";
            this.panelProfile.Size = new System.Drawing.Size(677, 323);
            this.panelProfile.TabIndex = 46;
            // 
            // Error_Email
            // 
            this.Error_Email.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_Email.AutoSize = true;
            this.Error_Email.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Error_Email.ForeColor = System.Drawing.Color.Red;
            this.Error_Email.Location = new System.Drawing.Point(30, 280);
            this.Error_Email.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error_Email.Name = "Error_Email";
            this.Error_Email.Size = new System.Drawing.Size(131, 18);
            this.Error_Email.TabIndex = 148;
            this.Error_Email.Text = "لطفا ایمیل معتبر وارد کنید";
            this.Error_Email.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_Email.Visible = false;
            // 
            // EmailTxt
            // 
            this.EmailTxt.AllowExtendedCharacters = true;
            this.EmailTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EmailTxt.BackColor = System.Drawing.Color.White;
            this.EmailTxt.ExtendedTextBoxLanguage = Dentistry.UserControls.ExtendedTextBox.ExtendedTextBoxLanguages.English;
            this.EmailTxt.Location = new System.Drawing.Point(169, 277);
            this.EmailTxt.Margin = new System.Windows.Forms.Padding(4);
            this.EmailTxt.MaxLength = 50;
            this.EmailTxt.MinLength = 0;
            this.EmailTxt.MoveToNextOnEnterKey = true;
            this.EmailTxt.Name = "EmailTxt";
            this.EmailTxt.ShowToolTip = true;
            this.EmailTxt.Size = new System.Drawing.Size(200, 26);
            this.EmailTxt.TabIndex = 147;
            this.EmailTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserNameTxt
            // 
            this.UserNameTxt.AllowExtendedCharacters = true;
            this.UserNameTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.UserNameTxt.BackColor = System.Drawing.Color.White;
            this.UserNameTxt.ExtendedTextBoxLanguage = Dentistry.UserControls.ExtendedTextBox.ExtendedTextBoxLanguages.English;
            this.UserNameTxt.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.UserNameTxt.Location = new System.Drawing.Point(394, 19);
            this.UserNameTxt.Margin = new System.Windows.Forms.Padding(4);
            this.UserNameTxt.MaxLength = 50;
            this.UserNameTxt.MinLength = 0;
            this.UserNameTxt.MoveToNextOnEnterKey = true;
            this.UserNameTxt.Name = "UserNameTxt";
            this.UserNameTxt.ShowToolTip = true;
            this.UserNameTxt.Size = new System.Drawing.Size(179, 28);
            this.UserNameTxt.TabIndex = 145;
            this.UserNameTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label6.ForeColor = System.Drawing.Color.Navy;
            this.label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.label6.Location = new System.Drawing.Point(377, 280);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(276, 20);
            this.label6.TabIndex = 47;
            this.label6.Text = "لطفا ایمیل خود را جهت بازیابی رمز عبور وارد نمائید";
            // 
            // panelPass
            // 
            this.panelPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelPass.BackColor = System.Drawing.Color.Transparent;
            this.panelPass.BorderColor = System.Drawing.Color.Silver;
            this.panelPass.Controls.Add(this.textBoxRepeatPass);
            this.panelPass.Controls.Add(this.textBoxPass);
            this.panelPass.Controls.Add(this.Error_Compare);
            this.panelPass.Controls.Add(this.Error_OldPass_Message);
            this.panelPass.Controls.Add(this.label4);
            this.panelPass.Controls.Add(this.textBoxOldPass);
            this.panelPass.Controls.Add(this.label3);
            this.panelPass.Controls.Add(this.label2);
            this.panelPass.Controls.Add(this.Error_OldPass);
            this.panelPass.Controls.Add(this.Error_NewPass);
            this.panelPass.Controls.Add(this.Error_RepeatPass);
            this.panelPass.Enabled = false;
            this.panelPass.Location = new System.Drawing.Point(13, 96);
            this.panelPass.Margin = new System.Windows.Forms.Padding(4);
            this.panelPass.Name = "panelPass";
            this.panelPass.Size = new System.Drawing.Size(650, 161);
            this.panelPass.TabIndex = 95;
            // 
            // textBoxRepeatPass
            // 
            this.textBoxRepeatPass.AllowExtendedCharacters = true;
            this.textBoxRepeatPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxRepeatPass.BackColor = System.Drawing.Color.White;
            this.textBoxRepeatPass.ExtendedTextBoxLanguage = Dentistry.UserControls.ExtendedTextBox.ExtendedTextBoxLanguages.English;
            this.textBoxRepeatPass.Location = new System.Drawing.Point(381, 106);
            this.textBoxRepeatPass.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxRepeatPass.MaxLength = 50;
            this.textBoxRepeatPass.MinLength = 0;
            this.textBoxRepeatPass.MoveToNextOnEnterKey = true;
            this.textBoxRepeatPass.Name = "textBoxRepeatPass";
            this.textBoxRepeatPass.PasswordChar = '*';
            this.textBoxRepeatPass.ShowToolTip = true;
            this.textBoxRepeatPass.Size = new System.Drawing.Size(179, 26);
            this.textBoxRepeatPass.TabIndex = 146;
            this.textBoxRepeatPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBoxPass
            // 
            this.textBoxPass.AllowExtendedCharacters = true;
            this.textBoxPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPass.BackColor = System.Drawing.Color.White;
            this.textBoxPass.ExtendedTextBoxLanguage = Dentistry.UserControls.ExtendedTextBox.ExtendedTextBoxLanguages.English;
            this.textBoxPass.Location = new System.Drawing.Point(381, 64);
            this.textBoxPass.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPass.MaxLength = 50;
            this.textBoxPass.MinLength = 0;
            this.textBoxPass.MoveToNextOnEnterKey = true;
            this.textBoxPass.Name = "textBoxPass";
            this.textBoxPass.PasswordChar = '*';
            this.textBoxPass.ShowToolTip = true;
            this.textBoxPass.Size = new System.Drawing.Size(179, 26);
            this.textBoxPass.TabIndex = 145;
            this.textBoxPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Error_Compare
            // 
            this.Error_Compare.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_Compare.AutoSize = true;
            this.Error_Compare.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Error_Compare.ForeColor = System.Drawing.Color.Red;
            this.Error_Compare.Location = new System.Drawing.Point(132, 110);
            this.Error_Compare.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error_Compare.Name = "Error_Compare";
            this.Error_Compare.Size = new System.Drawing.Size(211, 18);
            this.Error_Compare.TabIndex = 95;
            this.Error_Compare.Text = "رمز عبور جدید و تکرارش با هم برابر نیستند.";
            this.Error_Compare.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_Compare.Visible = false;
            // 
            // Error_OldPass_Message
            // 
            this.Error_OldPass_Message.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_OldPass_Message.AutoSize = true;
            this.Error_OldPass_Message.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Error_OldPass_Message.ForeColor = System.Drawing.Color.Red;
            this.Error_OldPass_Message.Location = new System.Drawing.Point(165, 24);
            this.Error_OldPass_Message.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error_OldPass_Message.Name = "Error_OldPass_Message";
            this.Error_OldPass_Message.Size = new System.Drawing.Size(178, 18);
            this.Error_OldPass_Message.TabIndex = 94;
            this.Error_OldPass_Message.Text = "رمز عبور قبلی اشتباه وارد شده است.";
            this.Error_OldPass_Message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_OldPass_Message.Visible = false;
            // 
            // textBoxOldPass
            // 
            this.textBoxOldPass.AllowExtendedCharacters = true;
            this.textBoxOldPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxOldPass.BackColor = System.Drawing.Color.White;
            this.textBoxOldPass.ExtendedTextBoxLanguage = Dentistry.UserControls.ExtendedTextBox.ExtendedTextBoxLanguages.English;
            this.textBoxOldPass.Location = new System.Drawing.Point(381, 21);
            this.textBoxOldPass.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxOldPass.MaxLength = 50;
            this.textBoxOldPass.MinLength = 0;
            this.textBoxOldPass.MoveToNextOnEnterKey = true;
            this.textBoxOldPass.Name = "textBoxOldPass";
            this.textBoxOldPass.PasswordChar = '*';
            this.textBoxOldPass.ShowToolTip = true;
            this.textBoxOldPass.Size = new System.Drawing.Size(179, 26);
            this.textBoxOldPass.TabIndex = 144;
            this.textBoxOldPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Error_OldPass
            // 
            this.Error_OldPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_OldPass.AutoSize = true;
            this.Error_OldPass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_OldPass.ForeColor = System.Drawing.Color.Red;
            this.Error_OldPass.Location = new System.Drawing.Point(355, 26);
            this.Error_OldPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error_OldPass.Name = "Error_OldPass";
            this.Error_OldPass.Size = new System.Drawing.Size(13, 13);
            this.Error_OldPass.TabIndex = 91;
            this.Error_OldPass.Text = "*";
            this.Error_OldPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_OldPass.Visible = false;
            // 
            // Error_NewPass
            // 
            this.Error_NewPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_NewPass.AutoSize = true;
            this.Error_NewPass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_NewPass.ForeColor = System.Drawing.Color.Red;
            this.Error_NewPass.Location = new System.Drawing.Point(355, 69);
            this.Error_NewPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error_NewPass.Name = "Error_NewPass";
            this.Error_NewPass.Size = new System.Drawing.Size(13, 13);
            this.Error_NewPass.TabIndex = 92;
            this.Error_NewPass.Text = "*";
            this.Error_NewPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_NewPass.Visible = false;
            // 
            // Error_RepeatPass
            // 
            this.Error_RepeatPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_RepeatPass.AutoSize = true;
            this.Error_RepeatPass.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_RepeatPass.ForeColor = System.Drawing.Color.Red;
            this.Error_RepeatPass.Location = new System.Drawing.Point(356, 114);
            this.Error_RepeatPass.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Error_RepeatPass.Name = "Error_RepeatPass";
            this.Error_RepeatPass.Size = new System.Drawing.Size(13, 13);
            this.Error_RepeatPass.TabIndex = 93;
            this.Error_RepeatPass.Text = "*";
            this.Error_RepeatPass.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_RepeatPass.Visible = false;
            // 
            // checkBox
            // 
            this.checkBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.checkBox.AutoSize = true;
            this.checkBox.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.checkBox.Location = new System.Drawing.Point(561, 71);
            this.checkBox.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox.Name = "checkBox";
            this.checkBox.Size = new System.Drawing.Size(103, 22);
            this.checkBox.TabIndex = 94;
            this.checkBox.Text = "ویرایش رمز عبور";
            this.checkBox.UseVisualStyleBackColor = true;
            this.checkBox.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tab1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tabControl.ItemSize = new System.Drawing.Size(200, 25);
            this.tabControl.Location = new System.Drawing.Point(10, 10);
            this.tabControl.Name = "tabControl";
            this.tabControl.RightToLeftLayout = true;
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(714, 441);
            this.tabControl.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl.TabIndex = 94;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tab1
            // 
            this.tab1.Controls.Add(this.buttonOk);
            this.tab1.Controls.Add(this.panelProfile);
            this.tab1.Location = new System.Drawing.Point(4, 29);
            this.tab1.Name = "tab1";
            this.tab1.Padding = new System.Windows.Forms.Padding(3);
            this.tab1.Size = new System.Drawing.Size(706, 408);
            this.tab1.TabIndex = 0;
            this.tab1.Text = "ویرایش مشخصات";
            this.tab1.UseVisualStyleBackColor = true;
            // 
            // buttonOk
            // 
            this.buttonOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOk.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.buttonOk.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(141)))), ((int)(((byte)(168)))));
            this.buttonOk.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.buttonOk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOk.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOk.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.buttonOk.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonOk.Location = new System.Drawing.Point(8, 360);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(100, 30);
            this.buttonOk.TabIndex = 47;
            this.buttonOk.Text = "تایید ";
            this.buttonOk.UseVisualStyleBackColor = false;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.HeaderText = " افزودن";
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn1.Width = 110;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.HeaderText = "ویرایش";
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = " حذف";
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn3.Width = 105;
            // 
            // dataGridViewImageColumn4
            // 
            this.dataGridViewImageColumn4.HeaderText = "رویت";
            this.dataGridViewImageColumn4.Name = "dataGridViewImageColumn4";
            this.dataGridViewImageColumn4.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewImageColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dataGridViewImageColumn4.Width = 110;
            // 
            // UserProfile
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(734, 461);
            this.Controls.Add(this.tabControl);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "UserProfile";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ويرايش پروفايل كاربران سيستم";
            this.Load += new System.EventHandler(this.UserProfile_Load);
            this.panelProfile.ResumeLayout(false);
            this.panelProfile.PerformLayout();
            this.panelPass.ResumeLayout(false);
            this.panelPass.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tab1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private UserControls.ExPanel panelProfile;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Error_RepeatPass;
        private System.Windows.Forms.Label Error_NewPass;
        private System.Windows.Forms.Label Error_OldPass;
        private System.Windows.Forms.CheckBox checkBox;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab1;
        private UserControls.ExPanel panelPass;
        private System.Windows.Forms.Label Error_OldPass_Message;
        private System.Windows.Forms.Label Error_Compare;
        private UserControls.ExtendedTextBox textBoxOldPass;
        private UserControls.ExtendedTextBox textBoxRepeatPass;
        private UserControls.ExtendedTextBox textBoxPass;
        private UserControls.ExtendedTextBox UserNameTxt;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Label Error_Email;
        private UserControls.ExtendedTextBox EmailTxt;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn4;
    }
}