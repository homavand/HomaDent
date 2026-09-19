namespace Dentistry
{
    partial class PatientDocDefine
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
            this.ComboDate = new Dentistry.UserControls.PersianDateTimePicker();
            this.Error_textBoxDocName = new System.Windows.Forms.Label();
            this.Error_textBoxDate = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDocName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.PatientNameLbl = new System.Windows.Forms.Label();
            this.panel2 = new Dentistry.UserControls.ExPanel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.bindingNavigator1 = new System.Windows.Forms.BindingNavigator(this.components);
            this.linkLabelReadFromFile = new System.Windows.Forms.ToolStripButton();
            this.linkLabelReadFromScanner = new System.Windows.Forms.ToolStripButton();
            this.linkLabelWebcam = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.panelComment = new Dentistry.UserControls.ExPanel();
            this.textBoxComment = new System.Windows.Forms.TextBox();
            this.panelCommentHeader = new Dentistry.UserControls.ExPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.OkBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).BeginInit();
            this.bindingNavigator1.SuspendLayout();
            this.panelComment.SuspendLayout();
            this.panelCommentHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // ComboDate
            // 
            this.ComboDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ComboDate.BackColor = System.Drawing.Color.White;
            this.ComboDate.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ComboDate.Location = new System.Drawing.Point(619, 124);
            this.ComboDate.Name = "ComboDate";
            this.ComboDate.ShowTime = false;
            this.ComboDate.Size = new System.Drawing.Size(155, 25);
            this.ComboDate.TabIndex = 2;
            this.ComboDate.Text = "persianDateTimePicker1";
            // 
            // Error_textBoxDocName
            // 
            this.Error_textBoxDocName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxDocName.AutoSize = true;
            this.Error_textBoxDocName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxDocName.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxDocName.Location = new System.Drawing.Point(512, 85);
            this.Error_textBoxDocName.Name = "Error_textBoxDocName";
            this.Error_textBoxDocName.Size = new System.Drawing.Size(13, 13);
            this.Error_textBoxDocName.TabIndex = 95;
            this.Error_textBoxDocName.Text = "*";
            this.Error_textBoxDocName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxDocName.Visible = false;
            // 
            // Error_textBoxDate
            // 
            this.Error_textBoxDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Error_textBoxDate.AutoSize = true;
            this.Error_textBoxDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Error_textBoxDate.ForeColor = System.Drawing.Color.Red;
            this.Error_textBoxDate.Location = new System.Drawing.Point(602, 132);
            this.Error_textBoxDate.Name = "Error_textBoxDate";
            this.Error_textBoxDate.Size = new System.Drawing.Size(13, 13);
            this.Error_textBoxDate.TabIndex = 94;
            this.Error_textBoxDate.Text = "*";
            this.Error_textBoxDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Error_textBoxDate.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(780, 128);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 18);
            this.label2.TabIndex = 13;
            this.label2.Text = "تاریخ :";
            // 
            // textBoxDocName
            // 
            this.textBoxDocName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxDocName.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxDocName.Location = new System.Drawing.Point(528, 78);
            this.textBoxDocName.Name = "textBoxDocName";
            this.textBoxDocName.Size = new System.Drawing.Size(246, 26);
            this.textBoxDocName.TabIndex = 1;
            this.textBoxDocName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(780, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 18);
            this.label3.TabIndex = 0;
            this.label3.Text = "عنوان :";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.PatientNameLbl);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.ComboDate);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.panelComment);
            this.panel1.Controls.Add(this.textBoxDocName);
            this.panel1.Controls.Add(this.Error_textBoxDocName);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.Error_textBoxDate);
            this.panel1.Location = new System.Drawing.Point(14, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(843, 345);
            this.panel1.TabIndex = 64;
            // 
            // PatientNameLbl
            // 
            this.PatientNameLbl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.PatientNameLbl.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PatientNameLbl.ForeColor = System.Drawing.Color.Black;
            this.PatientNameLbl.Location = new System.Drawing.Point(528, 15);
            this.PatientNameLbl.Name = "PatientNameLbl";
            this.PatientNameLbl.Padding = new System.Windows.Forms.Padding(3);
            this.PatientNameLbl.Size = new System.Drawing.Size(292, 35);
            this.PatientNameLbl.TabIndex = 101;
            this.PatientNameLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.BorderColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.splitContainer1);
            this.panel2.Location = new System.Drawing.Point(15, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(484, 300);
            this.panel2.TabIndex = 8;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox);
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.bindingNavigator1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(484, 300);
            this.splitContainer1.SplitterDistance = 266;
            this.splitContainer1.TabIndex = 101;
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.Color.White;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(484, 266);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 4;
            this.pictureBox.TabStop = false;
            // 
            // bindingNavigator1
            // 
            this.bindingNavigator1.AddNewItem = null;
            this.bindingNavigator1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bindingNavigator1.CountItem = null;
            this.bindingNavigator1.DeleteItem = null;
            this.bindingNavigator1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bindingNavigator1.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bindingNavigator1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.bindingNavigator1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.linkLabelReadFromFile,
            this.linkLabelReadFromScanner,
            this.linkLabelWebcam,
            this.toolStripSeparator2,
            this.toolStripButton2});
            this.bindingNavigator1.Location = new System.Drawing.Point(0, 0);
            this.bindingNavigator1.MoveFirstItem = null;
            this.bindingNavigator1.MoveLastItem = null;
            this.bindingNavigator1.MoveNextItem = null;
            this.bindingNavigator1.MovePreviousItem = null;
            this.bindingNavigator1.Name = "bindingNavigator1";
            this.bindingNavigator1.PositionItem = null;
            this.bindingNavigator1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.bindingNavigator1.Size = new System.Drawing.Size(484, 30);
            this.bindingNavigator1.TabIndex = 6;
            this.bindingNavigator1.Text = "bindingNavigatorBank";
            // 
            // linkLabelReadFromFile
            // 
            this.linkLabelReadFromFile.AutoSize = false;
            this.linkLabelReadFromFile.ForeColor = System.Drawing.Color.Black;
            this.linkLabelReadFromFile.Image = global::Dentistry.Properties.Resources.folder;
            this.linkLabelReadFromFile.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabelReadFromFile.Name = "linkLabelReadFromFile";
            this.linkLabelReadFromFile.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.linkLabelReadFromFile.Size = new System.Drawing.Size(130, 27);
            this.linkLabelReadFromFile.Text = "رسانه ذخيره سازي";
            this.linkLabelReadFromFile.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelReadFromFile.Click += new System.EventHandler(this.linkLabelReadFromFile_LinkClicked);
            // 
            // linkLabelReadFromScanner
            // 
            this.linkLabelReadFromScanner.AutoSize = false;
            this.linkLabelReadFromScanner.ForeColor = System.Drawing.Color.Black;
            this.linkLabelReadFromScanner.Image = global::Dentistry.Properties.Resources.SpecialDocument;
            this.linkLabelReadFromScanner.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabelReadFromScanner.Name = "linkLabelReadFromScanner";
            this.linkLabelReadFromScanner.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.linkLabelReadFromScanner.Size = new System.Drawing.Size(80, 27);
            this.linkLabelReadFromScanner.Text = " اسکنر";
            this.linkLabelReadFromScanner.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelReadFromScanner.Click += new System.EventHandler(this.linkLabelReadFromScanner_LinkClicked);
            // 
            // linkLabelWebcam
            // 
            this.linkLabelWebcam.AutoSize = false;
            this.linkLabelWebcam.Image = global::Dentistry.Properties.Resources.Picture_24x24;
            this.linkLabelWebcam.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabelWebcam.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.linkLabelWebcam.Name = "linkLabelWebcam";
            this.linkLabelWebcam.Size = new System.Drawing.Size(80, 27);
            this.linkLabelWebcam.Text = "دوربين";
            this.linkLabelWebcam.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkLabelWebcam.Click += new System.EventHandler(this.linkLabelWebcam_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 30);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.AutoSize = false;
            this.toolStripButton2.Image = global::Dentistry.Properties.Resources.remove;
            this.toolStripButton2.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(80, 27);
            this.toolStripButton2.Text = "پاك كردن";
            this.toolStripButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolStripButton2.Visible = false;
            // 
            // panelComment
            // 
            this.panelComment.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelComment.BackColor = System.Drawing.Color.Transparent;
            this.panelComment.BorderColor = System.Drawing.Color.LightGray;
            this.panelComment.Controls.Add(this.textBoxComment);
            this.panelComment.Controls.Add(this.panelCommentHeader);
            this.panelComment.Location = new System.Drawing.Point(528, 171);
            this.panelComment.Name = "panelComment";
            this.panelComment.Size = new System.Drawing.Size(292, 143);
            this.panelComment.TabIndex = 24;
            // 
            // textBoxComment
            // 
            this.textBoxComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxComment.Location = new System.Drawing.Point(0, 22);
            this.textBoxComment.Multiline = true;
            this.textBoxComment.Name = "textBoxComment";
            this.textBoxComment.Size = new System.Drawing.Size(292, 121);
            this.textBoxComment.TabIndex = 3;
            // 
            // panelCommentHeader
            // 
            this.panelCommentHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.panelCommentHeader.BorderColor = System.Drawing.Color.LightGray;
            this.panelCommentHeader.Controls.Add(this.label4);
            this.panelCommentHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCommentHeader.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelCommentHeader.Location = new System.Drawing.Point(0, 0);
            this.panelCommentHeader.Name = "panelCommentHeader";
            this.panelCommentHeader.Size = new System.Drawing.Size(292, 22);
            this.panelCommentHeader.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Vazir", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(125, 2);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 18);
            this.label4.TabIndex = 4;
            this.label4.Text = "توضیحات";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.InitialDirectory = "desktop";
            // 
            // OkBtn
            // 
            this.OkBtn.BackColor = System.Drawing.Color.White;
            this.OkBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.OkBtn.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.OkBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(234)))), ((int)(((byte)(234)))));
            this.OkBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.OkBtn.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OkBtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.OkBtn.Location = new System.Drawing.Point(707, 376);
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(150, 30);
            this.OkBtn.TabIndex = 65;
            this.OkBtn.Text = "تایید ";
            this.OkBtn.UseVisualStyleBackColor = false;
            this.OkBtn.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // PatientDocDefine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(869, 420);
            this.Controls.Add(this.OkBtn);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "PatientDocDefine";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "فرم وارد کردن اسناد";
            this.Load += new System.EventHandler(this.PatientDocDefine_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingNavigator1)).EndInit();
            this.bindingNavigator1.ResumeLayout(false);
            this.bindingNavigator1.PerformLayout();
            this.panelComment.ResumeLayout(false);
            this.panelComment.PerformLayout();
            this.panelCommentHeader.ResumeLayout(false);
            this.panelCommentHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ExPanel panelComment;
        private System.Windows.Forms.TextBox textBoxComment;
        private UserControls.ExPanel panelCommentHeader;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Error_textBoxDocName;
        private System.Windows.Forms.Label Error_textBoxDate;
        private UserControls.ExPanel panel2;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDocName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.BindingNavigator bindingNavigator1;
        private System.Windows.Forms.ToolStripButton linkLabelReadFromFile;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton linkLabelReadFromScanner;
        private Dentistry.UserControls.PersianDateTimePicker ComboDate;
        private System.Windows.Forms.ToolStripButton linkLabelWebcam;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label PatientNameLbl;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button OkBtn;
    }
}