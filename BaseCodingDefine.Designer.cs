namespace Dentistry
{
    partial class BaseCodingDefine
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
            this.OkBtn = new System.Windows.Forms.Button();
            this.Panel1 = new System.Windows.Forms.Panel();
            this.IsActiveChk = new System.Windows.Forms.RadioButton();
            this.IsDeActiveChk = new System.Windows.Forms.RadioButton();
            this.label12 = new System.Windows.Forms.Label();
            this.ColorPnl = new System.Windows.Forms.Panel();
            this.ColorLbl = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.BankPnl = new System.Windows.Forms.Panel();
            this.BankCbo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CommentTxt = new System.Windows.Forms.TextBox();
            this.CodeTxt = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Error_TitleTxt = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TitleTxt = new System.Windows.Forms.TextBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Panel1.SuspendLayout();
            this.ColorPnl.SuspendLayout();
            this.BankPnl.SuspendLayout();
            this.SuspendLayout();
            // 
            // OkBtn
            // 
            this.OkBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.OkBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.OkBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(141)))), ((int)(((byte)(168)))));
            this.OkBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkBtn.ForeColor = System.Drawing.Color.White;
            this.OkBtn.Image = global::Dentistry.Properties.Resources.Ok;
            this.OkBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.OkBtn.Location = new System.Drawing.Point(419, 254);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(100, 30);
            this.OkBtn.TabIndex = 95;
            this.OkBtn.Text = "تایید ";
            this.OkBtn.UseVisualStyleBackColor = false;
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // Panel1
            // 
            this.Panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel1.BackColor = System.Drawing.Color.White;
            this.Panel1.Controls.Add(this.IsActiveChk);
            this.Panel1.Controls.Add(this.IsDeActiveChk);
            this.Panel1.Controls.Add(this.label12);
            this.Panel1.Controls.Add(this.ColorPnl);
            this.Panel1.Controls.Add(this.BankPnl);
            this.Panel1.Controls.Add(this.label4);
            this.Panel1.Controls.Add(this.CommentTxt);
            this.Panel1.Controls.Add(this.CodeTxt);
            this.Panel1.Controls.Add(this.label2);
            this.Panel1.Controls.Add(this.Error_TitleTxt);
            this.Panel1.Controls.Add(this.label1);
            this.Panel1.Controls.Add(this.TitleTxt);
            this.Panel1.Location = new System.Drawing.Point(12, 12);
            this.Panel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Panel1.Name = "Panel1";
            this.Panel1.Padding = new System.Windows.Forms.Padding(5);
            this.Panel1.Size = new System.Drawing.Size(507, 235);
            this.Panel1.TabIndex = 96;
            // 
            // IsActiveChk
            // 
            this.IsActiveChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsActiveChk.BackColor = System.Drawing.Color.Honeydew;
            this.IsActiveChk.Checked = true;
            this.IsActiveChk.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsActiveChk.Location = new System.Drawing.Point(343, 126);
            this.IsActiveChk.Name = "IsActiveChk";
            this.IsActiveChk.Padding = new System.Windows.Forms.Padding(5);
            this.IsActiveChk.Size = new System.Drawing.Size(90, 30);
            this.IsActiveChk.TabIndex = 4;
            this.IsActiveChk.TabStop = true;
            this.IsActiveChk.Text = "فعال";
            this.IsActiveChk.UseVisualStyleBackColor = false;
            // 
            // IsDeActiveChk
            // 
            this.IsDeActiveChk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.IsDeActiveChk.BackColor = System.Drawing.Color.LavenderBlush;
            this.IsDeActiveChk.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IsDeActiveChk.Location = new System.Drawing.Point(245, 126);
            this.IsDeActiveChk.Name = "IsDeActiveChk";
            this.IsDeActiveChk.Padding = new System.Windows.Forms.Padding(5);
            this.IsDeActiveChk.Size = new System.Drawing.Size(90, 30);
            this.IsDeActiveChk.TabIndex = 5;
            this.IsDeActiveChk.Text = "غیر فعال";
            this.IsDeActiveChk.UseVisualStyleBackColor = false;
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(440, 131);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 20);
            this.label12.TabIndex = 177;
            this.label12.Text = "وضعیت :";
            // 
            // ColorPnl
            // 
            this.ColorPnl.Controls.Add(this.ColorLbl);
            this.ColorPnl.Controls.Add(this.label5);
            this.ColorPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ColorPnl.Location = new System.Drawing.Point(5, 162);
            this.ColorPnl.Name = "ColorPnl";
            this.ColorPnl.Size = new System.Drawing.Size(497, 34);
            this.ColorPnl.TabIndex = 111;
            this.ColorPnl.Visible = false;
            // 
            // ColorLbl
            // 
            this.ColorLbl.AutoSize = true;
            this.ColorLbl.BackColor = System.Drawing.Color.White;
            this.ColorLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorLbl.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ColorLbl.Location = new System.Drawing.Point(362, 9);
            this.ColorLbl.Name = "ColorLbl";
            this.ColorLbl.Size = new System.Drawing.Size(18, 15);
            this.ColorLbl.TabIndex = 6;
            this.ColorLbl.Text = "   ";
            this.ColorLbl.Click += new System.EventHandler(this.ColorLbl_Click);
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label5.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(435, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 20);
            this.label5.TabIndex = 106;
            this.label5.Text = "رنگ :";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BankPnl
            // 
            this.BankPnl.Controls.Add(this.BankCbo);
            this.BankPnl.Controls.Add(this.label3);
            this.BankPnl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BankPnl.Location = new System.Drawing.Point(5, 196);
            this.BankPnl.Name = "BankPnl";
            this.BankPnl.Size = new System.Drawing.Size(497, 34);
            this.BankPnl.TabIndex = 110;
            this.BankPnl.Visible = false;
            // 
            // BankCbo
            // 
            this.BankCbo.Font = new System.Drawing.Font("Vazir", 8F, System.Drawing.FontStyle.Bold);
            this.BankCbo.FormattingEnabled = true;
            this.BankCbo.Location = new System.Drawing.Point(214, 5);
            this.BankCbo.Name = "BankCbo";
            this.BankCbo.Size = new System.Drawing.Size(182, 25);
            this.BankCbo.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label3.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(435, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 25);
            this.label3.TabIndex = 106;
            this.label3.Text = "بانک :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label4.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DimGray;
            this.label4.Location = new System.Drawing.Point(440, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 24);
            this.label4.TabIndex = 108;
            this.label4.Text = "توضیحات : ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CommentTxt
            // 
            this.CommentTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CommentTxt.BackColor = System.Drawing.Color.White;
            this.CommentTxt.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CommentTxt.Location = new System.Drawing.Point(81, 87);
            this.CommentTxt.MaxLength = 50;
            this.CommentTxt.Name = "CommentTxt";
            this.CommentTxt.Size = new System.Drawing.Size(352, 28);
            this.CommentTxt.TabIndex = 3;
            // 
            // CodeTxt
            // 
            this.CodeTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CodeTxt.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CodeTxt.Location = new System.Drawing.Point(251, 15);
            this.CodeTxt.Name = "CodeTxt";
            this.CodeTxt.Size = new System.Drawing.Size(182, 28);
            this.CodeTxt.TabIndex = 1;
            this.CodeTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label2.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.DimGray;
            this.label2.Location = new System.Drawing.Point(440, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 24);
            this.label2.TabIndex = 104;
            this.label2.Text = "کد : ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Error_TitleTxt
            // 
            this.Error_TitleTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_TitleTxt.AutoSize = true;
            this.Error_TitleTxt.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_TitleTxt.ForeColor = System.Drawing.Color.Red;
            this.Error_TitleTxt.Location = new System.Drawing.Point(62, 59);
            this.Error_TitleTxt.Name = "Error_TitleTxt";
            this.Error_TitleTxt.Size = new System.Drawing.Size(13, 13);
            this.Error_TitleTxt.TabIndex = 102;
            this.Error_TitleTxt.Text = "*";
            this.Error_TitleTxt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_TitleTxt.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.label1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(440, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 24);
            this.label1.TabIndex = 100;
            this.label1.Text = "عنوان : ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TitleTxt
            // 
            this.TitleTxt.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TitleTxt.BackColor = System.Drawing.Color.White;
            this.TitleTxt.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleTxt.Location = new System.Drawing.Point(81, 51);
            this.TitleTxt.MaxLength = 50;
            this.TitleTxt.Name = "TitleTxt";
            this.TitleTxt.Size = new System.Drawing.Size(352, 28);
            this.TitleTxt.TabIndex = 2;
            // 
            // BaseCodingDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(246)))), ((int)(((byte)(241)))), ((int)(((byte)(248)))));
            this.ClientSize = new System.Drawing.Size(531, 296);
            this.Controls.Add(this.Panel1);
            this.Controls.Add(this.OkBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BaseCodingDefine";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "تعریف کدینگ پایه";
            this.Panel1.ResumeLayout(false);
            this.Panel1.PerformLayout();
            this.ColorPnl.ResumeLayout(false);
            this.ColorPnl.PerformLayout();
            this.BankPnl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button OkBtn;
        private System.Windows.Forms.Panel Panel1;
        private System.Windows.Forms.Label Error_TitleTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TitleTxt;
        private System.Windows.Forms.TextBox CodeTxt;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CommentTxt;
        private System.Windows.Forms.Panel BankPnl;
        private System.Windows.Forms.ComboBox BankCbo;
        private System.Windows.Forms.Panel ColorPnl;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label ColorLbl;
        private System.Windows.Forms.ColorDialog colorDialog1;
        public System.Windows.Forms.RadioButton IsActiveChk;
        public System.Windows.Forms.RadioButton IsDeActiveChk;
        private System.Windows.Forms.Label label12;
    }
}