namespace Dentistry
{
    partial class PatientFinancialDefine
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
            this.PosPanel = new System.Windows.Forms.Panel();
            this.btn_Connect = new System.Windows.Forms.Button();
            this.ChooseBankCbo = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.Error_textBoxPayableMoney = new System.Windows.Forms.Label();
            this.Error_textBoxDate = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TransactionPanel = new System.Windows.Forms.Panel();
            this.PayTypePnl = new System.Windows.Forms.Panel();
            this.panel1 = new Dentistry.UserControls.ExPanel();
            this.PayType6Rdo = new System.Windows.Forms.RadioButton();
            this.panel9 = new Dentistry.UserControls.ExPanel();
            this.PayType5Rdo = new System.Windows.Forms.RadioButton();
            this.panel6 = new Dentistry.UserControls.ExPanel();
            this.PayType1Rdo = new System.Windows.Forms.RadioButton();
            this.panel8 = new Dentistry.UserControls.ExPanel();
            this.PayType4Rdo = new System.Windows.Forms.RadioButton();
            this.panel4 = new Dentistry.UserControls.ExPanel();
            this.PayType2Rdo = new System.Windows.Forms.RadioButton();
            this.panel7 = new Dentistry.UserControls.ExPanel();
            this.PayType3Rdo = new System.Windows.Forms.RadioButton();
            this.TransactionDateTxt = new Dentistry.UserControls.PersianDateTimePicker();
            this.commentTxt = new Dentistry.UserControls.ExtendedTextBox();
            this.amountTxt = new Dentistry.UserControls.CurrencyTextBox();
            this.ChequePanel = new System.Windows.Forms.Panel();
            this.MaturityDateCbo = new Dentistry.UserControls.PersianDateTimePicker();
            this.chequeStatusTxt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Error_textBoxDateOfMaturity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Error_textBoxNumberOfCheque = new System.Windows.Forms.Label();
            this.ChequeNumberTxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BankCbo = new System.Windows.Forms.ComboBox();
            this.OkBtn = new System.Windows.Forms.Button();
            this.panel3 = new Dentistry.UserControls.ExPanel();
            this.PatientNameTxt = new System.Windows.Forms.TextBox();
            this.PatientCodeTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.PanelX1 = new Dentistry.UserControls.ExPanel();
            this.PatientRemianedTxt = new Dentistry.UserControls.MoneyLabel();
            this.label12 = new System.Windows.Forms.Label();
            this.PosPanel.SuspendLayout();
            this.TransactionPanel.SuspendLayout();
            this.PayTypePnl.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel9.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.ChequePanel.SuspendLayout();
            this.panel3.SuspendLayout();
            this.PanelX1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PosPanel
            // 
            this.PosPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PosPanel.BackColor = System.Drawing.Color.White;
            this.PosPanel.Controls.Add(this.btn_Connect);
            this.PosPanel.Controls.Add(this.ChooseBankCbo);
            this.PosPanel.Controls.Add(this.label11);
            this.PosPanel.Enabled = false;
            this.PosPanel.Location = new System.Drawing.Point(11, 420);
            this.PosPanel.Name = "PosPanel";
            this.PosPanel.Size = new System.Drawing.Size(837, 47);
            this.PosPanel.TabIndex = 95;
            // 
            // btn_Connect
            // 
            this.btn_Connect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Connect.BackColor = System.Drawing.Color.White;
            this.btn_Connect.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.btn_Connect.ForeColor = System.Drawing.Color.Black;
            this.btn_Connect.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn_Connect.Location = new System.Drawing.Point(462, 11);
            this.btn_Connect.Name = "btn_Connect";
            this.btn_Connect.Size = new System.Drawing.Size(28, 22);
            this.btn_Connect.TabIndex = 94;
            this.btn_Connect.Text = "...";
            this.btn_Connect.UseVisualStyleBackColor = false;
            this.btn_Connect.Click += new System.EventHandler(this.btn_Connect_Click);
            // 
            // ChooseBankCbo
            // 
            this.ChooseBankCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChooseBankCbo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ChooseBankCbo.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.ChooseBankCbo.FormattingEnabled = true;
            this.ChooseBankCbo.Location = new System.Drawing.Point(496, 9);
            this.ChooseBankCbo.Name = "ChooseBankCbo";
            this.ChooseBankCbo.Size = new System.Drawing.Size(240, 28);
            this.ChooseBankCbo.TabIndex = 22;
            this.ChooseBankCbo.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseBank_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(745, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(73, 18);
            this.label11.TabIndex = 20;
            this.label11.Text = "انتخاب بانک :";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.label9.Location = new System.Drawing.Point(744, 158);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(68, 20);
            this.label9.TabIndex = 23;
            this.label9.Text = "توضیحات :";
            // 
            // Error_textBoxPayableMoney
            // 
            this.Error_textBoxPayableMoney.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxPayableMoney.AutoSize = true;
            this.Error_textBoxPayableMoney.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxPayableMoney.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxPayableMoney.Location = new System.Drawing.Point(521, 119);
            this.Error_textBoxPayableMoney.Name = "Error_textBoxPayableMoney";
            this.Error_textBoxPayableMoney.Size = new System.Drawing.Size(13, 13);
            this.Error_textBoxPayableMoney.TabIndex = 94;
            this.Error_textBoxPayableMoney.Text = "*";
            this.Error_textBoxPayableMoney.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxPayableMoney.Visible = false;
            // 
            // Error_textBoxDate
            // 
            this.Error_textBoxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxDate.AutoSize = true;
            this.Error_textBoxDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxDate.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxDate.Location = new System.Drawing.Point(521, 78);
            this.Error_textBoxDate.Name = "Error_textBoxDate";
            this.Error_textBoxDate.Size = new System.Drawing.Size(13, 13);
            this.Error_textBoxDate.TabIndex = 90;
            this.Error_textBoxDate.Text = "*";
            this.Error_textBoxDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxDate.Visible = false;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.label3.Location = new System.Drawing.Point(744, 117);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 20);
            this.label3.TabIndex = 19;
            this.label3.Text = "مبلغ :";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.label8.Location = new System.Drawing.Point(744, 75);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "تاریخ :";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.label2.Location = new System.Drawing.Point(744, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 20;
            this.label2.Text = "نوع تراکنش :";
            // 
            // TransactionPanel
            // 
            this.TransactionPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionPanel.BackColor = System.Drawing.Color.White;
            this.TransactionPanel.Controls.Add(this.PayTypePnl);
            this.TransactionPanel.Controls.Add(this.TransactionDateTxt);
            this.TransactionPanel.Controls.Add(this.commentTxt);
            this.TransactionPanel.Controls.Add(this.label9);
            this.TransactionPanel.Controls.Add(this.Error_textBoxPayableMoney);
            this.TransactionPanel.Controls.Add(this.Error_textBoxDate);
            this.TransactionPanel.Controls.Add(this.label3);
            this.TransactionPanel.Controls.Add(this.label8);
            this.TransactionPanel.Controls.Add(this.label2);
            this.TransactionPanel.Controls.Add(this.amountTxt);
            this.TransactionPanel.Font = new System.Drawing.Font("Tahoma", 9F);
            this.TransactionPanel.Location = new System.Drawing.Point(12, 112);
            this.TransactionPanel.Name = "TransactionPanel";
            this.TransactionPanel.Size = new System.Drawing.Size(836, 203);
            this.TransactionPanel.TabIndex = 95;
            // 
            // PayTypePnl
            // 
            this.PayTypePnl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PayTypePnl.Controls.Add(this.panel1);
            this.PayTypePnl.Controls.Add(this.panel9);
            this.PayTypePnl.Controls.Add(this.panel6);
            this.PayTypePnl.Controls.Add(this.panel8);
            this.PayTypePnl.Controls.Add(this.panel4);
            this.PayTypePnl.Controls.Add(this.panel7);
            this.PayTypePnl.Location = new System.Drawing.Point(58, 14);
            this.PayTypePnl.Name = "PayTypePnl";
            this.PayTypePnl.Size = new System.Drawing.Size(682, 40);
            this.PayTypePnl.TabIndex = 96;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderBottomWidth = 2;
            this.panel1.BorderColor = System.Drawing.Color.Red;
            this.panel1.BorderLeftWidth = 0;
            this.panel1.BorderRightWidth = 0;
            this.panel1.BorderTopWidth = 0;
            this.panel1.Controls.Add(this.PayType6Rdo);
            this.panel1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel1.Location = new System.Drawing.Point(42, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(100, 30);
            this.panel1.TabIndex = 129;
            this.panel1.TabStop = false;
            this.panel1.Tag = "4";
            // 
            // PayType6Rdo
            // 
            this.PayType6Rdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PayType6Rdo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayType6Rdo.Location = new System.Drawing.Point(0, 0);
            this.PayType6Rdo.Name = "PayType6Rdo";
            this.PayType6Rdo.Padding = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.PayType6Rdo.Size = new System.Drawing.Size(100, 30);
            this.PayType6Rdo.TabIndex = 119;
            this.PayType6Rdo.TabStop = true;
            this.PayType6Rdo.Tag = "6";
            this.PayType6Rdo.Text = "تخفیف";
            this.PayType6Rdo.UseVisualStyleBackColor = false;
            this.PayType6Rdo.CheckedChanged += new System.EventHandler(this.PayTypeRdo_CheckedChanged);
            // 
            // panel9
            // 
            this.panel9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.BorderBottomWidth = 2;
            this.panel9.BorderColor = System.Drawing.Color.Red;
            this.panel9.BorderLeftWidth = 0;
            this.panel9.BorderRightWidth = 0;
            this.panel9.BorderTopWidth = 0;
            this.panel9.Controls.Add(this.PayType5Rdo);
            this.panel9.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel9.Location = new System.Drawing.Point(149, 5);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(100, 30);
            this.panel9.TabIndex = 128;
            this.panel9.TabStop = false;
            this.panel9.Tag = "4";
            // 
            // PayType5Rdo
            // 
            this.PayType5Rdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PayType5Rdo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayType5Rdo.Location = new System.Drawing.Point(0, 0);
            this.PayType5Rdo.Name = "PayType5Rdo";
            this.PayType5Rdo.Padding = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.PayType5Rdo.Size = new System.Drawing.Size(100, 30);
            this.PayType5Rdo.TabIndex = 119;
            this.PayType5Rdo.TabStop = true;
            this.PayType5Rdo.Tag = "5";
            this.PayType5Rdo.Text = "بازپرداخت";
            this.PayType5Rdo.UseVisualStyleBackColor = false;
            this.PayType5Rdo.CheckedChanged += new System.EventHandler(this.PayTypeRdo_CheckedChanged);
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderBottomWidth = 2;
            this.panel6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel6.BorderLeftWidth = 0;
            this.panel6.BorderRightWidth = 0;
            this.panel6.BorderTopWidth = 0;
            this.panel6.Controls.Add(this.PayType1Rdo);
            this.panel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel6.Location = new System.Drawing.Point(578, 5);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(100, 30);
            this.panel6.TabIndex = 125;
            this.panel6.TabStop = false;
            this.panel6.Tag = "4";
            // 
            // PayType1Rdo
            // 
            this.PayType1Rdo.Checked = true;
            this.PayType1Rdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PayType1Rdo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayType1Rdo.Location = new System.Drawing.Point(0, 0);
            this.PayType1Rdo.Name = "PayType1Rdo";
            this.PayType1Rdo.Padding = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.PayType1Rdo.Size = new System.Drawing.Size(100, 30);
            this.PayType1Rdo.TabIndex = 119;
            this.PayType1Rdo.TabStop = true;
            this.PayType1Rdo.Tag = "1";
            this.PayType1Rdo.Text = " نقدی";
            this.PayType1Rdo.UseVisualStyleBackColor = false;
            this.PayType1Rdo.CheckedChanged += new System.EventHandler(this.PayTypeRdo_CheckedChanged);
            // 
            // panel8
            // 
            this.panel8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel8.BackColor = System.Drawing.Color.White;
            this.panel8.BorderBottomWidth = 2;
            this.panel8.BorderColor = System.Drawing.Color.Orange;
            this.panel8.BorderLeftWidth = 0;
            this.panel8.BorderRightWidth = 0;
            this.panel8.BorderTopWidth = 0;
            this.panel8.Controls.Add(this.PayType4Rdo);
            this.panel8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel8.Location = new System.Drawing.Point(257, 5);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(100, 30);
            this.panel8.TabIndex = 127;
            this.panel8.TabStop = false;
            this.panel8.Tag = "4";
            // 
            // PayType4Rdo
            // 
            this.PayType4Rdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PayType4Rdo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayType4Rdo.Location = new System.Drawing.Point(0, 0);
            this.PayType4Rdo.Name = "PayType4Rdo";
            this.PayType4Rdo.Padding = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.PayType4Rdo.Size = new System.Drawing.Size(100, 30);
            this.PayType4Rdo.TabIndex = 119;
            this.PayType4Rdo.TabStop = true;
            this.PayType4Rdo.Tag = "4";
            this.PayType4Rdo.Text = "ثبت فاکتور";
            this.PayType4Rdo.UseVisualStyleBackColor = false;
            this.PayType4Rdo.CheckedChanged += new System.EventHandler(this.PayTypeRdo_CheckedChanged);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.Color.White;
            this.panel4.BorderBottomWidth = 2;
            this.panel4.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.panel4.BorderLeftWidth = 0;
            this.panel4.BorderRightWidth = 0;
            this.panel4.BorderTopWidth = 0;
            this.panel4.Controls.Add(this.PayType2Rdo);
            this.panel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel4.Location = new System.Drawing.Point(471, 5);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(100, 30);
            this.panel4.TabIndex = 124;
            this.panel4.TabStop = false;
            this.panel4.Tag = "4";
            // 
            // PayType2Rdo
            // 
            this.PayType2Rdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PayType2Rdo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayType2Rdo.Location = new System.Drawing.Point(0, 0);
            this.PayType2Rdo.Name = "PayType2Rdo";
            this.PayType2Rdo.Padding = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.PayType2Rdo.Size = new System.Drawing.Size(100, 30);
            this.PayType2Rdo.TabIndex = 119;
            this.PayType2Rdo.TabStop = true;
            this.PayType2Rdo.Tag = "2";
            this.PayType2Rdo.Text = "کارت خوان";
            this.PayType2Rdo.UseVisualStyleBackColor = false;
            this.PayType2Rdo.CheckedChanged += new System.EventHandler(this.PayTypeRdo_CheckedChanged);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.BackColor = System.Drawing.Color.White;
            this.panel7.BorderBottomWidth = 2;
            this.panel7.BorderColor = System.Drawing.Color.DodgerBlue;
            this.panel7.BorderLeftWidth = 0;
            this.panel7.BorderRightWidth = 0;
            this.panel7.BorderTopWidth = 0;
            this.panel7.Controls.Add(this.PayType3Rdo);
            this.panel7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel7.Location = new System.Drawing.Point(364, 5);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(100, 30);
            this.panel7.TabIndex = 126;
            this.panel7.TabStop = false;
            this.panel7.Tag = "4";
            // 
            // PayType3Rdo
            // 
            this.PayType3Rdo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PayType3Rdo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PayType3Rdo.Location = new System.Drawing.Point(0, 0);
            this.PayType3Rdo.Name = "PayType3Rdo";
            this.PayType3Rdo.Padding = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.PayType3Rdo.Size = new System.Drawing.Size(100, 30);
            this.PayType3Rdo.TabIndex = 119;
            this.PayType3Rdo.TabStop = true;
            this.PayType3Rdo.Tag = "3";
            this.PayType3Rdo.Text = " چک";
            this.PayType3Rdo.UseVisualStyleBackColor = false;
            this.PayType3Rdo.CheckedChanged += new System.EventHandler(this.PayTypeRdo_CheckedChanged);
            // 
            // TransactionDateTxt
            // 
            this.TransactionDateTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TransactionDateTxt.BackColor = System.Drawing.Color.White;
            this.TransactionDateTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TransactionDateTxt.Location = new System.Drawing.Point(536, 73);
            this.TransactionDateTxt.Name = "TransactionDateTxt";
            this.TransactionDateTxt.ShowTime = false;
            this.TransactionDateTxt.Size = new System.Drawing.Size(200, 25);
            this.TransactionDateTxt.TabIndex = 1;
            this.TransactionDateTxt.Text = "persianDateTimePicker1";
            // 
            // commentTxt
            // 
            this.commentTxt.AllowExtendedCharacters = true;
            this.commentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.commentTxt.ExtendedTextBoxLanguage = Dentistry.UserControls.ExtendedTextBox.ExtendedTextBoxLanguages.Bilingual;
            this.commentTxt.Font = new System.Drawing.Font("Vazir FD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.commentTxt.Location = new System.Drawing.Point(90, 156);
            this.commentTxt.MaxLength = 500;
            this.commentTxt.MinLength = 0;
            this.commentTxt.MoveToNextOnEnterKey = true;
            this.commentTxt.Name = "commentTxt";
            this.commentTxt.ShowToolTip = true;
            this.commentTxt.Size = new System.Drawing.Size(646, 26);
            this.commentTxt.TabIndex = 3;
            // 
            // amountTxt
            // 
            this.amountTxt.AllowPoint = false;
            this.amountTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.amountTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.amountTxt.Location = new System.Drawing.Point(536, 112);
            this.amountTxt.MaxLength = 18;
            this.amountTxt.MinLength = 0;
            this.amountTxt.MoveToNextOnEnterKey = true;
            this.amountTxt.Name = "amountTxt";
            this.amountTxt.ShowToolTip = true;
            this.amountTxt.Size = new System.Drawing.Size(200, 28);
            this.amountTxt.TabIndex = 2;
            this.amountTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChequePanel
            // 
            this.ChequePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChequePanel.BackColor = System.Drawing.Color.White;
            this.ChequePanel.Controls.Add(this.MaturityDateCbo);
            this.ChequePanel.Controls.Add(this.chequeStatusTxt);
            this.ChequePanel.Controls.Add(this.label6);
            this.ChequePanel.Controls.Add(this.Error_textBoxDateOfMaturity);
            this.ChequePanel.Controls.Add(this.label1);
            this.ChequePanel.Controls.Add(this.Error_textBoxNumberOfCheque);
            this.ChequePanel.Controls.Add(this.ChequeNumberTxt);
            this.ChequePanel.Controls.Add(this.label4);
            this.ChequePanel.Controls.Add(this.label5);
            this.ChequePanel.Controls.Add(this.BankCbo);
            this.ChequePanel.Enabled = false;
            this.ChequePanel.Location = new System.Drawing.Point(12, 322);
            this.ChequePanel.Name = "ChequePanel";
            this.ChequePanel.Size = new System.Drawing.Size(836, 90);
            this.ChequePanel.TabIndex = 96;
            // 
            // MaturityDateCbo
            // 
            this.MaturityDateCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MaturityDateCbo.BackColor = System.Drawing.Color.White;
            this.MaturityDateCbo.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaturityDateCbo.Location = new System.Drawing.Point(90, 10);
            this.MaturityDateCbo.Name = "MaturityDateCbo";
            this.MaturityDateCbo.ShowTime = false;
            this.MaturityDateCbo.Size = new System.Drawing.Size(175, 25);
            this.MaturityDateCbo.TabIndex = 109;
            this.MaturityDateCbo.Text = "persianDateTimePicker1";
            // 
            // chequeStatusTxt
            // 
            this.chequeStatusTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chequeStatusTxt.BackColor = System.Drawing.Color.LavenderBlush;
            this.chequeStatusTxt.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.chequeStatusTxt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chequeStatusTxt.Location = new System.Drawing.Point(90, 56);
            this.chequeStatusTxt.Name = "chequeStatusTxt";
            this.chequeStatusTxt.Padding = new System.Windows.Forms.Padding(4);
            this.chequeStatusTxt.Size = new System.Drawing.Size(175, 25);
            this.chequeStatusTxt.TabIndex = 117;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(271, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 116;
            this.label6.Text = "وضعیت چک :";
            // 
            // Error_textBoxDateOfMaturity
            // 
            this.Error_textBoxDateOfMaturity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxDateOfMaturity.AutoSize = true;
            this.Error_textBoxDateOfMaturity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxDateOfMaturity.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxDateOfMaturity.Location = new System.Drawing.Point(75, 16);
            this.Error_textBoxDateOfMaturity.Name = "Error_textBoxDateOfMaturity";
            this.Error_textBoxDateOfMaturity.Size = new System.Drawing.Size(13, 13);
            this.Error_textBoxDateOfMaturity.TabIndex = 115;
            this.Error_textBoxDateOfMaturity.Text = "*";
            this.Error_textBoxDateOfMaturity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxDateOfMaturity.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(744, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 113;
            this.label1.Text = "نام بانک :";
            // 
            // Error_textBoxNumberOfCheque
            // 
            this.Error_textBoxNumberOfCheque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxNumberOfCheque.AutoSize = true;
            this.Error_textBoxNumberOfCheque.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxNumberOfCheque.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxNumberOfCheque.Location = new System.Drawing.Point(481, 17);
            this.Error_textBoxNumberOfCheque.Name = "Error_textBoxNumberOfCheque";
            this.Error_textBoxNumberOfCheque.Size = new System.Drawing.Size(13, 13);
            this.Error_textBoxNumberOfCheque.TabIndex = 114;
            this.Error_textBoxNumberOfCheque.Text = "*";
            this.Error_textBoxNumberOfCheque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxNumberOfCheque.Visible = false;
            // 
            // ChequeNumberTxt
            // 
            this.ChequeNumberTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChequeNumberTxt.BackColor = System.Drawing.Color.White;
            this.ChequeNumberTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.ChequeNumberTxt.Location = new System.Drawing.Point(496, 9);
            this.ChequeNumberTxt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ChequeNumberTxt.Name = "ChequeNumberTxt";
            this.ChequeNumberTxt.Size = new System.Drawing.Size(240, 28);
            this.ChequeNumberTxt.TabIndex = 108;
            this.ChequeNumberTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(271, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 112;
            this.label4.Text = "تاریخ سررسید :";
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(744, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 111;
            this.label5.Text = "شماره چک :";
            // 
            // BankCbo
            // 
            this.BankCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BankCbo.DisplayMember = "Id";
            this.BankCbo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BankCbo.FormattingEnabled = true;
            this.BankCbo.Location = new System.Drawing.Point(496, 54);
            this.BankCbo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BankCbo.Name = "BankCbo";
            this.BankCbo.Size = new System.Drawing.Size(240, 28);
            this.BankCbo.TabIndex = 110;
            this.BankCbo.ValueMember = "Id";
            // 
            // OkBtn
            // 
            this.OkBtn.BackColor = System.Drawing.Color.White;
            this.OkBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.OkBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.OkBtn.Location = new System.Drawing.Point(698, 477);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(150, 30);
            this.OkBtn.TabIndex = 6;
            this.OkBtn.Text = "تایید ";
            this.OkBtn.UseVisualStyleBackColor = false;
            this.OkBtn.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderColor = System.Drawing.Color.WhiteSmoke;
            this.panel3.Controls.Add(this.PatientNameTxt);
            this.panel3.Controls.Add(this.PatientCodeTxt);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Location = new System.Drawing.Point(11, 15);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(837, 40);
            this.panel3.TabIndex = 96;
            this.panel3.TabStop = false;
            // 
            // PatientNameTxt
            // 
            this.PatientNameTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PatientNameTxt.Font = new System.Drawing.Font("Vazir", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatientNameTxt.Location = new System.Drawing.Point(56, 8);
            this.PatientNameTxt.Name = "PatientNameTxt";
            this.PatientNameTxt.ReadOnly = true;
            this.PatientNameTxt.Size = new System.Drawing.Size(343, 22);
            this.PatientNameTxt.TabIndex = 23;
            // 
            // PatientCodeTxt
            // 
            this.PatientCodeTxt.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.PatientCodeTxt.Font = new System.Drawing.Font("Vazir", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatientCodeTxt.Location = new System.Drawing.Point(492, 9);
            this.PatientCodeTxt.Name = "PatientCodeTxt";
            this.PatientCodeTxt.ReadOnly = true;
            this.PatientCodeTxt.Size = new System.Drawing.Size(233, 22);
            this.PatientCodeTxt.TabIndex = 22;

            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(409, 10);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(62, 20);
            this.label10.TabIndex = 21;
            this.label10.Text = "نام بیمار :";
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(731, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "کد بیمار :";
            // 
            // PanelX1
            // 
            this.PanelX1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(73)))));
            this.PanelX1.BorderBottomWidth = 0;
            this.PanelX1.BorderColor = System.Drawing.Color.Silver;
            this.PanelX1.BorderLeftWidth = 0;
            this.PanelX1.BorderRightWidth = 0;
            this.PanelX1.BorderTopWidth = 0;
            this.PanelX1.Controls.Add(this.PatientRemianedTxt);
            this.PanelX1.Controls.Add(this.label12);
            this.PanelX1.Location = new System.Drawing.Point(12, 56);
            this.PanelX1.Name = "PanelX1";
            this.PanelX1.Size = new System.Drawing.Size(836, 50);
            this.PanelX1.TabIndex = 26;
            this.PanelX1.TabStop = false;
            // 
            // PatientRemianedTxt
            // 
            this.PatientRemianedTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PatientRemianedTxt.BackColor = System.Drawing.Color.Transparent;
            this.PatientRemianedTxt.CurrencyGroupSeparator = ",";
            this.PatientRemianedTxt.CurrencySymbol = "  ریال ";
            this.PatientRemianedTxt.Font = new System.Drawing.Font("Vazir FD", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatientRemianedTxt.ForeColor = System.Drawing.Color.DeepPink;
            this.PatientRemianedTxt.Location = new System.Drawing.Point(357, 10);
            this.PatientRemianedTxt.Name = "PatientRemianedTxt";
            this.PatientRemianedTxt.Padding = new System.Windows.Forms.Padding(5);
            this.PatientRemianedTxt.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.PatientRemianedTxt.Size = new System.Drawing.Size(367, 30);
            this.PatientRemianedTxt.TabIndex = 50;
            this.PatientRemianedTxt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.PatientRemianedTxt.TextChanged += new System.EventHandler(this.RemianedLbl_TextChanged);
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(175)))), ((int)(((byte)(171)))), ((int)(((byte)(194)))));
            this.label12.Location = new System.Drawing.Point(730, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(79, 20);
            this.label12.TabIndex = 20;
            this.label12.Text = "مانده بدهی :";
            // 
            // PatientFinancialDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(860, 516);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.TransactionPanel);
            this.Controls.Add(this.PanelX1);
            this.Controls.Add(this.ChequePanel);
            this.Controls.Add(this.PosPanel);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PatientFinancialDefine";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم پرداخت";
            this.Load += new System.EventHandler(this.PatientFinancialDefine_Load);
            this.PosPanel.ResumeLayout(false);
            this.PosPanel.PerformLayout();
            this.TransactionPanel.ResumeLayout(false);
            this.TransactionPanel.PerformLayout();
            this.PayTypePnl.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel9.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.ChequePanel.ResumeLayout(false);
            this.ChequePanel.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.PanelX1.ResumeLayout(false);
            this.PanelX1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label Error_textBoxPayableMoney;
        private System.Windows.Forms.Label label3;
        private UserControls.CurrencyTextBox amountTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Error_textBoxDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label8;
        private UserControls.ExtendedTextBox commentTxt;
        private System.Windows.Forms.Panel PosPanel;
        private Dentistry.UserControls.PersianDateTimePicker TransactionDateTxt;
        private System.Windows.Forms.ComboBox ChooseBankCbo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button btn_Connect;
        private UserControls.ExPanel PanelX1;
        private System.Windows.Forms.Label label12;
        private UserControls.MoneyLabel PatientRemianedTxt;
        private System.Windows.Forms.Panel TransactionPanel;
        private System.Windows.Forms.Panel ChequePanel;
        private UserControls.ExPanel panel4;
        private System.Windows.Forms.RadioButton PayType2Rdo;
        private System.Windows.Forms.Panel PayTypePnl;
        private UserControls.ExPanel panel9;
        private System.Windows.Forms.RadioButton PayType5Rdo;
        private UserControls.ExPanel panel6;
        private System.Windows.Forms.RadioButton PayType1Rdo;
        private UserControls.ExPanel panel8;
        private System.Windows.Forms.RadioButton PayType4Rdo;
        private UserControls.ExPanel panel7;
        private System.Windows.Forms.RadioButton PayType3Rdo;
        private UserControls.ExPanel panel1;
        private System.Windows.Forms.RadioButton PayType6Rdo;
        private UserControls.ExPanel panel3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox PatientNameTxt;
        private System.Windows.Forms.TextBox PatientCodeTxt;
        private System.Windows.Forms.Button OkBtn;
        private UserControls.PersianDateTimePicker MaturityDateCbo;
        private System.Windows.Forms.Label chequeStatusTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label Error_textBoxDateOfMaturity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Error_textBoxNumberOfCheque;
        private System.Windows.Forms.TextBox ChequeNumberTxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox BankCbo;
    }
}