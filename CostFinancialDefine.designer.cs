namespace Dentistry
{
    partial class CostFinancialDefine
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelCheque = new System.Windows.Forms.Panel();
            this.MaturityDateCbo = new Dentistry.UserControls.PersianDateTimePicker();
            this.chequeStatusTxt = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.Error_textBoxDateOfMaturity = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Error_textBoxNumberOfCheque = new System.Windows.Forms.Label();
            this.ChequeNumberTxt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.BankCbo = new System.Windows.Forms.ComboBox();
            this.Panelx1 = new System.Windows.Forms.Panel();
            this.TransactionDateTxt = new Dentistry.UserControls.PersianDateTimePicker();
            this.PayTypePnl = new System.Windows.Forms.Panel();
            this.panel6 = new Dentistry.UserControls.ExPanel();
            this.PayType1Rdo = new System.Windows.Forms.RadioButton();
            this.panel8 = new Dentistry.UserControls.ExPanel();
            this.PayType4Rdo = new System.Windows.Forms.RadioButton();
            this.panel4 = new Dentistry.UserControls.ExPanel();
            this.PayType2Rdo = new System.Windows.Forms.RadioButton();
            this.panel7 = new Dentistry.UserControls.ExPanel();
            this.PayType3Rdo = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.Error_comboBoxCostTitle = new System.Windows.Forms.Label();
            this.panelBargainSide = new System.Windows.Forms.Panel();
            this.Error_comboBoxBargainSide = new System.Windows.Forms.Label();
            this.BargainSideCbo = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.costTitleLbl = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.Error_textBoxDate = new System.Windows.Forms.Label();
            this.Error_textBoxPrice = new System.Windows.Forms.Label();
            this.CommentTxt = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.AmountTxt = new Dentistry.UserControls.CurrencyTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.factorNumberPnl = new System.Windows.Forms.Panel();
            this.Error_textBoxFactorNumber = new System.Windows.Forms.Label();
            this.factorNumberTxt = new Dentistry.UserControls.NumberTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.dgCostTypes = new System.Windows.Forms.DataGridView();
            this.ColumnId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColumnDeleted = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.okBtn = new System.Windows.Forms.Button();
            this.PanelCheque.SuspendLayout();
            this.Panelx1.SuspendLayout();
            this.PayTypePnl.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel7.SuspendLayout();
            this.panelBargainSide.SuspendLayout();
            this.factorNumberPnl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCostTypes)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelCheque
            // 
            this.PanelCheque.BackColor = System.Drawing.Color.White;
            this.PanelCheque.Controls.Add(this.MaturityDateCbo);
            this.PanelCheque.Controls.Add(this.chequeStatusTxt);
            this.PanelCheque.Controls.Add(this.label6);
            this.PanelCheque.Controls.Add(this.Error_textBoxDateOfMaturity);
            this.PanelCheque.Controls.Add(this.label1);
            this.PanelCheque.Controls.Add(this.Error_textBoxNumberOfCheque);
            this.PanelCheque.Controls.Add(this.ChequeNumberTxt);
            this.PanelCheque.Controls.Add(this.label7);
            this.PanelCheque.Controls.Add(this.label4);
            this.PanelCheque.Controls.Add(this.BankCbo);
            this.PanelCheque.Enabled = false;
            this.PanelCheque.Location = new System.Drawing.Point(350, 264);
            this.PanelCheque.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PanelCheque.Name = "PanelCheque";
            this.PanelCheque.Size = new System.Drawing.Size(707, 114);
            this.PanelCheque.TabIndex = 32;
            // 
            // MaturityDateCbo
            // 
            this.MaturityDateCbo.BackColor = System.Drawing.Color.White;
            this.MaturityDateCbo.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.MaturityDateCbo.Location = new System.Drawing.Point(40, 20);
            this.MaturityDateCbo.Name = "MaturityDateCbo";
            this.MaturityDateCbo.ShowTime = false;
            this.MaturityDateCbo.Size = new System.Drawing.Size(175, 25);
            this.MaturityDateCbo.TabIndex = 10;
            this.MaturityDateCbo.Text = "persianDateTimePicker1";
            // 
            // chequeStatusTxt
            // 
            this.chequeStatusTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chequeStatusTxt.BackColor = System.Drawing.Color.Transparent;
            this.chequeStatusTxt.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.chequeStatusTxt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chequeStatusTxt.Location = new System.Drawing.Point(40, 66);
            this.chequeStatusTxt.Name = "chequeStatusTxt";
            this.chequeStatusTxt.Padding = new System.Windows.Forms.Padding(4);
            this.chequeStatusTxt.Size = new System.Drawing.Size(175, 25);
            this.chequeStatusTxt.TabIndex = 107;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(221, 69);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(82, 20);
            this.label6.TabIndex = 106;
            this.label6.Text = "وضعیت چک :";
            // 
            // Error_textBoxDateOfMaturity
            // 
            this.Error_textBoxDateOfMaturity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxDateOfMaturity.AutoSize = true;
            this.Error_textBoxDateOfMaturity.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxDateOfMaturity.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxDateOfMaturity.Location = new System.Drawing.Point(25, 27);
            this.Error_textBoxDateOfMaturity.Name = "Error_textBoxDateOfMaturity";
            this.Error_textBoxDateOfMaturity.Size = new System.Drawing.Size(13, 13);
            this.Error_textBoxDateOfMaturity.TabIndex = 93;
            this.Error_textBoxDateOfMaturity.Text = "*";
            this.Error_textBoxDateOfMaturity.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxDateOfMaturity.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(610, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 20);
            this.label1.TabIndex = 29;
            this.label1.Text = "نام بانک :";
            // 
            // Error_textBoxNumberOfCheque
            // 
            this.Error_textBoxNumberOfCheque.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxNumberOfCheque.AutoSize = true;
            this.Error_textBoxNumberOfCheque.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxNumberOfCheque.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxNumberOfCheque.Location = new System.Drawing.Point(348, 27);
            this.Error_textBoxNumberOfCheque.Name = "Error_textBoxNumberOfCheque";
            this.Error_textBoxNumberOfCheque.Size = new System.Drawing.Size(13, 13);
            this.Error_textBoxNumberOfCheque.TabIndex = 89;
            this.Error_textBoxNumberOfCheque.Text = "*";
            this.Error_textBoxNumberOfCheque.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxNumberOfCheque.Visible = false;
            // 
            // ChequeNumberTxt
            // 
            this.ChequeNumberTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChequeNumberTxt.BackColor = System.Drawing.Color.White;
            this.ChequeNumberTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.ChequeNumberTxt.Location = new System.Drawing.Point(363, 19);
            this.ChequeNumberTxt.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.ChequeNumberTxt.Name = "ChequeNumberTxt";
            this.ChequeNumberTxt.Size = new System.Drawing.Size(240, 28);
            this.ChequeNumberTxt.TabIndex = 9;
            this.ChequeNumberTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(221, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 20);
            this.label7.TabIndex = 28;
            this.label7.Text = "تاریخ سررسید :";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(610, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 20);
            this.label4.TabIndex = 25;
            this.label4.Text = "شماره چک :";
            // 
            // BankCbo
            // 
            this.BankCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BankCbo.DisplayMember = "Id";
            this.BankCbo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BankCbo.FormattingEnabled = true;
            this.BankCbo.Location = new System.Drawing.Point(363, 64);
            this.BankCbo.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.BankCbo.Name = "BankCbo";
            this.BankCbo.Size = new System.Drawing.Size(240, 28);
            this.BankCbo.TabIndex = 11;
            this.BankCbo.ValueMember = "Id";
            // 
            // Panelx1
            // 
            this.Panelx1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panelx1.BackColor = System.Drawing.Color.White;
            this.Panelx1.Controls.Add(this.TransactionDateTxt);
            this.Panelx1.Controls.Add(this.PayTypePnl);
            this.Panelx1.Controls.Add(this.label2);
            this.Panelx1.Controls.Add(this.Error_comboBoxCostTitle);
            this.Panelx1.Controls.Add(this.panelBargainSide);
            this.Panelx1.Controls.Add(this.costTitleLbl);
            this.Panelx1.Controls.Add(this.label13);
            this.Panelx1.Controls.Add(this.Error_textBoxDate);
            this.Panelx1.Controls.Add(this.Error_textBoxPrice);
            this.Panelx1.Controls.Add(this.CommentTxt);
            this.Panelx1.Controls.Add(this.label10);
            this.Panelx1.Controls.Add(this.label11);
            this.Panelx1.Controls.Add(this.AmountTxt);
            this.Panelx1.Controls.Add(this.label12);
            this.Panelx1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.Panelx1.Location = new System.Drawing.Point(350, 12);
            this.Panelx1.Name = "Panelx1";
            this.Panelx1.Size = new System.Drawing.Size(707, 244);
            this.Panelx1.TabIndex = 35;
            // 
            // TransactionDateTxt
            // 
            this.TransactionDateTxt.BackColor = System.Drawing.Color.White;
            this.TransactionDateTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.TransactionDateTxt.Location = new System.Drawing.Point(40, 162);
            this.TransactionDateTxt.Name = "TransactionDateTxt";
            this.TransactionDateTxt.ShowTime = false;
            this.TransactionDateTxt.Size = new System.Drawing.Size(175, 25);
            this.TransactionDateTxt.TabIndex = 7;
            this.TransactionDateTxt.Text = "persianDateTimePicker1";
            // 
            // PayTypePnl
            // 
            this.PayTypePnl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.PayTypePnl.Controls.Add(this.panel6);
            this.PayTypePnl.Controls.Add(this.panel8);
            this.PayTypePnl.Controls.Add(this.panel4);
            this.PayTypePnl.Controls.Add(this.panel7);
            this.PayTypePnl.Location = new System.Drawing.Point(166, 112);
            this.PayTypePnl.Name = "PayTypePnl";
            this.PayTypePnl.Size = new System.Drawing.Size(438, 40);
            this.PayTypePnl.TabIndex = 168;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.BackColor = System.Drawing.Color.White;
            this.panel6.BorderBottomWidth = 2;
            this.panel6.BorderColor = System.Drawing.Color.LimeGreen;
            this.panel6.BorderLeftWidth = 0;
            this.panel6.BorderRightWidth = 0;
            this.panel6.BorderTopWidth = 0;
            this.panel6.Controls.Add(this.PayType1Rdo);
            this.panel6.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel6.Location = new System.Drawing.Point(334, 5);
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
            this.PayType1Rdo.TabIndex = 2;
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
            this.panel8.Location = new System.Drawing.Point(13, 5);
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
            this.panel4.BorderColor = System.Drawing.Color.LimeGreen;
            this.panel4.BorderLeftWidth = 0;
            this.panel4.BorderRightWidth = 0;
            this.panel4.BorderTopWidth = 0;
            this.panel4.Controls.Add(this.PayType2Rdo);
            this.panel4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.panel4.Location = new System.Drawing.Point(227, 5);
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
            this.panel7.Location = new System.Drawing.Point(120, 5);
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
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F);
            this.label2.Location = new System.Drawing.Point(610, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.TabIndex = 103;
            this.label2.Text = "نوع تراکنش :";
            // 
            // Error_comboBoxCostTitle
            // 
            this.Error_comboBoxCostTitle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_comboBoxCostTitle.AutoSize = true;
            this.Error_comboBoxCostTitle.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_comboBoxCostTitle.ForeColor = System.Drawing.Color.Red;
            this.Error_comboBoxCostTitle.Location = new System.Drawing.Point(312, 24);
            this.Error_comboBoxCostTitle.Name = "Error_comboBoxCostTitle";
            this.Error_comboBoxCostTitle.Size = new System.Drawing.Size(13, 13);
            this.Error_comboBoxCostTitle.TabIndex = 89;
            this.Error_comboBoxCostTitle.Text = "*";
            this.Error_comboBoxCostTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_comboBoxCostTitle.Visible = false;
            // 
            // panelBargainSide
            // 
            this.panelBargainSide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBargainSide.BackColor = System.Drawing.Color.Transparent;
            this.panelBargainSide.Controls.Add(this.Error_comboBoxBargainSide);
            this.panelBargainSide.Controls.Add(this.BargainSideCbo);
            this.panelBargainSide.Controls.Add(this.label8);
            this.panelBargainSide.Enabled = false;
            this.panelBargainSide.Location = new System.Drawing.Point(0, 67);
            this.panelBargainSide.Name = "panelBargainSide";
            this.panelBargainSide.Size = new System.Drawing.Size(707, 44);
            this.panelBargainSide.TabIndex = 42;
            this.panelBargainSide.Tag = "1";
            // 
            // Error_comboBoxBargainSide
            // 
            this.Error_comboBoxBargainSide.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_comboBoxBargainSide.AutoSize = true;
            this.Error_comboBoxBargainSide.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_comboBoxBargainSide.ForeColor = System.Drawing.Color.Red;
            this.Error_comboBoxBargainSide.Location = new System.Drawing.Point(312, 16);
            this.Error_comboBoxBargainSide.Name = "Error_comboBoxBargainSide";
            this.Error_comboBoxBargainSide.Size = new System.Drawing.Size(13, 13);
            this.Error_comboBoxBargainSide.TabIndex = 92;
            this.Error_comboBoxBargainSide.Text = "*";
            this.Error_comboBoxBargainSide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_comboBoxBargainSide.Visible = false;
            // 
            // BargainSideCbo
            // 
            this.BargainSideCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BargainSideCbo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BargainSideCbo.FormattingEnabled = true;
            this.BargainSideCbo.Location = new System.Drawing.Point(331, 7);
            this.BargainSideCbo.Name = "BargainSideCbo";
            this.BargainSideCbo.Size = new System.Drawing.Size(272, 28);
            this.BargainSideCbo.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(610, 12);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = " طرف حساب :";
            // 
            // costTitleLbl
            // 
            this.costTitleLbl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.costTitleLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(240)))), ((int)(((byte)(255)))));
            this.costTitleLbl.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.costTitleLbl.Location = new System.Drawing.Point(331, 16);
            this.costTitleLbl.Name = "costTitleLbl";
            this.costTitleLbl.Padding = new System.Windows.Forms.Padding(5);
            this.costTitleLbl.Size = new System.Drawing.Size(272, 29);
            this.costTitleLbl.TabIndex = 102;
            this.costTitleLbl.Text = "عنوان هزینه انتخاب نشده است";
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(610, 20);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 20);
            this.label13.TabIndex = 101;
            this.label13.Text = "عنوان هزینه :";
            // 
            // Error_textBoxDate
            // 
            this.Error_textBoxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxDate.AutoSize = true;
            this.Error_textBoxDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxDate.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxDate.Location = new System.Drawing.Point(25, 169);
            this.Error_textBoxDate.Name = "Error_textBoxDate";
            this.Error_textBoxDate.Size = new System.Drawing.Size(13, 13);
            this.Error_textBoxDate.TabIndex = 99;
            this.Error_textBoxDate.Text = "*";
            this.Error_textBoxDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxDate.Visible = false;
            // 
            // Error_textBoxPrice
            // 
            this.Error_textBoxPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxPrice.AutoSize = true;
            this.Error_textBoxPrice.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxPrice.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxPrice.Location = new System.Drawing.Point(348, 168);
            this.Error_textBoxPrice.Name = "Error_textBoxPrice";
            this.Error_textBoxPrice.Size = new System.Drawing.Size(13, 13);
            this.Error_textBoxPrice.TabIndex = 98;
            this.Error_textBoxPrice.Text = "*";
            this.Error_textBoxPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxPrice.Visible = false;
            // 
            // CommentTxt
            // 
            this.CommentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentTxt.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentTxt.Location = new System.Drawing.Point(40, 204);
            this.CommentTxt.Name = "CommentTxt";
            this.CommentTxt.Size = new System.Drawing.Size(563, 28);
            this.CommentTxt.TabIndex = 8;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(221, 166);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(43, 20);
            this.label10.TabIndex = 92;
            this.label10.Text = "تاریخ :";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(610, 209);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(68, 20);
            this.label11.TabIndex = 96;
            this.label11.Text = "توضیحات :";
            // 
            // AmountTxt
            // 
            this.AmountTxt.AllowPoint = false;
            this.AmountTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AmountTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AmountTxt.Location = new System.Drawing.Point(363, 161);
            this.AmountTxt.MaxLength = 18;
            this.AmountTxt.MinLength = 0;
            this.AmountTxt.MoveToNextOnEnterKey = true;
            this.AmountTxt.Name = "AmountTxt";
            this.AmountTxt.ShowToolTip = true;
            this.AmountTxt.Size = new System.Drawing.Size(240, 28);
            this.AmountTxt.TabIndex = 6;
            this.AmountTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(610, 166);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(77, 20);
            this.label12.TabIndex = 94;
            this.label12.Text = "مبلغ هزینه :";
            // 
            // factorNumberPnl
            // 
            this.factorNumberPnl.AutoScroll = true;
            this.factorNumberPnl.BackColor = System.Drawing.Color.White;
            this.factorNumberPnl.Controls.Add(this.Error_textBoxFactorNumber);
            this.factorNumberPnl.Controls.Add(this.factorNumberTxt);
            this.factorNumberPnl.Controls.Add(this.label9);
            this.factorNumberPnl.Enabled = false;
            this.factorNumberPnl.Location = new System.Drawing.Point(350, 386);
            this.factorNumberPnl.Name = "factorNumberPnl";
            this.factorNumberPnl.Size = new System.Drawing.Size(707, 52);
            this.factorNumberPnl.TabIndex = 42;
            this.factorNumberPnl.Tag = "1";
            // 
            // Error_textBoxFactorNumber
            // 
            this.Error_textBoxFactorNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxFactorNumber.AutoSize = true;
            this.Error_textBoxFactorNumber.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxFactorNumber.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxFactorNumber.Location = new System.Drawing.Point(348, 20);
            this.Error_textBoxFactorNumber.Name = "Error_textBoxFactorNumber";
            this.Error_textBoxFactorNumber.Size = new System.Drawing.Size(13, 13);
            this.Error_textBoxFactorNumber.TabIndex = 89;
            this.Error_textBoxFactorNumber.Text = "*";
            this.Error_textBoxFactorNumber.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxFactorNumber.Visible = false;
            // 
            // factorNumberTxt
            // 
            this.factorNumberTxt.AllowPoint = false;
            this.factorNumberTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.factorNumberTxt.Font = new System.Drawing.Font("Vazir FD", 9.75F);
            this.factorNumberTxt.InsertZeroToLeft = false;
            this.factorNumberTxt.Location = new System.Drawing.Point(363, 12);
            this.factorNumberTxt.MaxLength = 10;
            this.factorNumberTxt.MinLength = 0;
            this.factorNumberTxt.MoveToNextOnEnterKey = true;
            this.factorNumberTxt.Name = "factorNumberTxt";
            this.factorNumberTxt.ShowToolTip = true;
            this.factorNumberTxt.Size = new System.Drawing.Size(240, 28);
            this.factorNumberTxt.TabIndex = 12;
            this.factorNumberTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(610, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "شماره فاکتور :";
            // 
            // dgCostTypes
            // 
            this.dgCostTypes.AllowUserToAddRows = false;
            this.dgCostTypes.AllowUserToDeleteRows = false;
            this.dgCostTypes.AllowUserToResizeColumns = false;
            this.dgCostTypes.AllowUserToResizeRows = false;
            this.dgCostTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dgCostTypes.BackgroundColor = System.Drawing.Color.White;
            this.dgCostTypes.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgCostTypes.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            this.dgCostTypes.ColumnHeadersHeight = 30;
            this.dgCostTypes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgCostTypes.ColumnHeadersVisible = false;
            this.dgCostTypes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColumnId,
            this.ColumnTitle,
            this.ColumnDeleted});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.Padding = new System.Windows.Forms.Padding(2);
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.Transparent;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgCostTypes.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgCostTypes.EnableHeadersVisualStyles = false;
            this.dgCostTypes.GridColor = System.Drawing.Color.Gainsboro;
            this.dgCostTypes.Location = new System.Drawing.Point(15, 41);
            this.dgCostTypes.MultiSelect = false;
            this.dgCostTypes.Name = "dgCostTypes";
            this.dgCostTypes.ReadOnly = true;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgCostTypes.RowHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.dgCostTypes.RowHeadersVisible = false;
            this.dgCostTypes.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Vazir", 9.5F);
            this.dgCostTypes.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dgCostTypes.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(225)))), ((int)(((byte)(243)))));
            this.dgCostTypes.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.dgCostTypes.RowTemplate.Height = 30;
            this.dgCostTypes.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgCostTypes.Size = new System.Drawing.Size(321, 397);
            this.dgCostTypes.TabIndex = 163;
            this.dgCostTypes.SelectionChanged += new System.EventHandler(this.dgCostTypes_SelectionChanged);
            // 
            // ColumnId
            // 
            this.ColumnId.DataPropertyName = "Id";
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnId.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColumnId.HeaderText = "Id";
            this.ColumnId.Name = "ColumnId";
            this.ColumnId.ReadOnly = true;
            this.ColumnId.Visible = false;
            this.ColumnId.Width = 150;
            // 
            // ColumnTitle
            // 
            this.ColumnTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ColumnTitle.DataPropertyName = "Title";
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnTitle.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColumnTitle.HeaderText = "Title";
            this.ColumnTitle.Name = "ColumnTitle";
            this.ColumnTitle.ReadOnly = true;
            // 
            // ColumnDeleted
            // 
            this.ColumnDeleted.DataPropertyName = "IsDeleted";
            this.ColumnDeleted.HeaderText = "IsDeleted";
            this.ColumnDeleted.Name = "ColumnDeleted";
            this.ColumnDeleted.ReadOnly = true;
            this.ColumnDeleted.Visible = false;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Indigo;
            this.label5.Location = new System.Drawing.Point(11, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(85, 20);
            this.label5.TabIndex = 165;
            this.label5.Text = "انواع هزینه ها";
            // 
            // okBtn
            // 
            this.okBtn.BackColor = System.Drawing.Color.White;
            this.okBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.okBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.okBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.okBtn.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.okBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.okBtn.Location = new System.Drawing.Point(907, 453);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(150, 30);
            this.okBtn.TabIndex = 13;
            this.okBtn.Text = "تایید ";
            this.okBtn.UseVisualStyleBackColor = false;
            this.okBtn.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // CostFinancialDefine
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1073, 504);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgCostTypes);
            this.Controls.Add(this.factorNumberPnl);
            this.Controls.Add(this.Panelx1);
            this.Controls.Add(this.PanelCheque);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "CostFinancialDefine";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.CostRegisterDefine_Load);
            this.PanelCheque.ResumeLayout(false);
            this.PanelCheque.PerformLayout();
            this.Panelx1.ResumeLayout(false);
            this.Panelx1.PerformLayout();
            this.PayTypePnl.ResumeLayout(false);
            this.panel6.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel7.ResumeLayout(false);
            this.panelBargainSide.ResumeLayout(false);
            this.panelBargainSide.PerformLayout();
            this.factorNumberPnl.ResumeLayout(false);
            this.factorNumberPnl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCostTypes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel PanelCheque;
        private System.Windows.Forms.Label Error_textBoxDateOfMaturity;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label Error_textBoxNumberOfCheque;
        private System.Windows.Forms.TextBox ChequeNumberTxt;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox BankCbo;
        private System.Windows.Forms.Panel Panelx1;
        private System.Windows.Forms.Label Error_comboBoxCostTitle;
        private System.Windows.Forms.Panel panelBargainSide;
        private System.Windows.Forms.Label Error_comboBoxBargainSide;
        private System.Windows.Forms.ComboBox BargainSideCbo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel factorNumberPnl;
        private System.Windows.Forms.Label Error_textBoxFactorNumber;
        private UserControls.NumberTextBox factorNumberTxt;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label Error_textBoxDate;
        private System.Windows.Forms.Label Error_textBoxPrice;
        private System.Windows.Forms.TextBox CommentTxt;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private UserControls.CurrencyTextBox AmountTxt;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dgCostTypes;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label costTitleLbl;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label chequeStatusTxt;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PayTypePnl;
        private UserControls.ExPanel panel6;
        private System.Windows.Forms.RadioButton PayType1Rdo;
        private UserControls.ExPanel panel8;
        private System.Windows.Forms.RadioButton PayType4Rdo;
        private UserControls.ExPanel panel4;
        private System.Windows.Forms.RadioButton PayType2Rdo;
        private UserControls.ExPanel panel7;
        private System.Windows.Forms.RadioButton PayType3Rdo;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColumnDeleted;
        private UserControls.PersianDateTimePicker TransactionDateTxt;
        private UserControls.PersianDateTimePicker MaturityDateCbo;
    }
}