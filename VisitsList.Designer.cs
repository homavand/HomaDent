namespace Dentistry
{
    partial class VisitsList
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
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.rdMonth = new System.Windows.Forms.RadioButton();
            this.rdWeek = new System.Windows.Forms.RadioButton();
            this.rdDay = new System.Windows.Forms.RadioButton();
            this.vScroll = new System.Windows.Forms.VScrollBar();
            this.DoctorCbo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.persianMonth = new Dentistry.UserControls.PersianMonthCalendar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.timeScale30Rdo = new System.Windows.Forms.RadioButton();
            this.timeScale15Rdo = new System.Windows.Forms.RadioButton();
            this.btnSearch = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.calendar1 = new System.Windows.Forms.Calendar.Calendar();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitter1.Location = new System.Drawing.Point(1127, 15);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 638);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // rdMonth
            // 
            this.rdMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdMonth.AutoSize = true;
            this.rdMonth.Font = new System.Drawing.Font("Vazir", 9.5F);
            this.rdMonth.ForeColor = System.Drawing.Color.White;
            this.rdMonth.Location = new System.Drawing.Point(48, 285);
            this.rdMonth.Name = "rdMonth";
            this.rdMonth.Size = new System.Drawing.Size(44, 24);
            this.rdMonth.TabIndex = 2;
            this.rdMonth.Text = "ماه";
            this.rdMonth.UseVisualStyleBackColor = true;
            this.rdMonth.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdWeek
            // 
            this.rdWeek.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdWeek.AutoSize = true;
            this.rdWeek.Font = new System.Drawing.Font("Vazir", 9.5F);
            this.rdWeek.ForeColor = System.Drawing.Color.White;
            this.rdWeek.Location = new System.Drawing.Point(122, 285);
            this.rdWeek.Name = "rdWeek";
            this.rdWeek.Size = new System.Drawing.Size(55, 24);
            this.rdWeek.TabIndex = 0;
            this.rdWeek.Text = "هفته";
            this.rdWeek.UseVisualStyleBackColor = true;
            this.rdWeek.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // rdDay
            // 
            this.rdDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rdDay.AutoSize = true;
            this.rdDay.Font = new System.Drawing.Font("Vazir", 9.5F);
            this.rdDay.ForeColor = System.Drawing.Color.White;
            this.rdDay.Location = new System.Drawing.Point(205, 285);
            this.rdDay.Name = "rdDay";
            this.rdDay.Size = new System.Drawing.Size(43, 24);
            this.rdDay.TabIndex = 1;
            this.rdDay.Text = "روز";
            this.rdDay.UseVisualStyleBackColor = true;
            this.rdDay.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
            // 
            // vScroll
            // 
            this.vScroll.Dock = System.Windows.Forms.DockStyle.Left;
            this.vScroll.Location = new System.Drawing.Point(0, 0);
            this.vScroll.Name = "vScroll";
            this.vScroll.Size = new System.Drawing.Size(17, 668);
            this.vScroll.TabIndex = 125;
            this.vScroll.Scroll += new System.Windows.Forms.ScrollEventHandler(this.vScroll_Scroll);
            // 
            // DoctorCbo
            // 
            this.DoctorCbo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.DoctorCbo.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DoctorCbo.FormattingEnabled = true;
            this.DoctorCbo.Location = new System.Drawing.Point(48, 45);
            this.DoctorCbo.Name = "DoctorCbo";
            this.DoctorCbo.Size = new System.Drawing.Size(200, 28);
            this.DoctorCbo.TabIndex = 0;
            this.DoctorCbo.Tag = "";
            this.DoctorCbo.SelectedIndexChanged += new System.EventHandler(this.DoctorCbo_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Vazir", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(198, 18);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label1.Size = new System.Drawing.Size(56, 23);
            this.label1.TabIndex = 112;
            this.label1.Text = "پزشک :";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(73)))));
            this.panel1.Controls.Add(this.persianMonth);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.btnSearch);
            this.panel1.Controls.Add(this.rdMonth);
            this.panel1.Controls.Add(this.vScroll);
            this.panel1.Controls.Add(this.rdWeek);
            this.panel1.Controls.Add(this.DoctorCbo);
            this.panel1.Controls.Add(this.rdDay);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(15, 15);
            this.panel1.MaximumSize = new System.Drawing.Size(270, 668);
            this.panel1.MinimumSize = new System.Drawing.Size(270, 668);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(270, 668);
            this.panel1.TabIndex = 5;
            // 
            // persianMonth
            // 
            this.persianMonth.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.persianMonth.BackColor = System.Drawing.Color.White;
            this.persianMonth.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.persianMonth.Location = new System.Drawing.Point(37, 315);
            this.persianMonth.MarkColor = System.Drawing.Color.Green;
            this.persianMonth.MaximumSize = new System.Drawing.Size(230, 200);
            this.persianMonth.MinimumSize = new System.Drawing.Size(230, 200);
            this.persianMonth.Name = "persianMonth";
            this.persianMonth.ShowToday = true;
            this.persianMonth.Size = new System.Drawing.Size(230, 200);
            this.persianMonth.TabIndex = 128;
            this.persianMonth.Text = "persianMonthCalendar1";
         
            this.persianMonth.ValueChanged += new Dentistry.UserControls.PersianMonthCalendar.onValueChanged(this.persianMonth_ValueChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.timeScale30Rdo);
            this.groupBox1.Controls.Add(this.timeScale15Rdo);
            this.groupBox1.Font = new System.Drawing.Font("Vazir", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(48, 94);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 115);
            this.groupBox1.TabIndex = 127;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = " زمان بندی :    ";
            // 
            // timeScale30Rdo
            // 
            this.timeScale30Rdo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeScale30Rdo.AutoSize = true;
            this.timeScale30Rdo.Location = new System.Drawing.Point(92, 74);
            this.timeScale30Rdo.Name = "timeScale30Rdo";
            this.timeScale30Rdo.Size = new System.Drawing.Size(76, 24);
            this.timeScale30Rdo.TabIndex = 2;
            this.timeScale30Rdo.Tag = "30";
            this.timeScale30Rdo.Text = "30 دقیقه";
            this.timeScale30Rdo.UseVisualStyleBackColor = true;
            this.timeScale30Rdo.CheckedChanged += new System.EventHandler(this.timeScaleRdo_CheckedChanged);
            // 
            // timeScale15Rdo
            // 
            this.timeScale15Rdo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.timeScale15Rdo.AutoSize = true;
            this.timeScale15Rdo.Location = new System.Drawing.Point(92, 42);
            this.timeScale15Rdo.Name = "timeScale15Rdo";
            this.timeScale15Rdo.Size = new System.Drawing.Size(76, 24);
            this.timeScale15Rdo.TabIndex = 1;
            this.timeScale15Rdo.Tag = "15";
            this.timeScale15Rdo.Text = "15 دقیقه";
            this.timeScale15Rdo.UseVisualStyleBackColor = true;
            this.timeScale15Rdo.CheckedChanged += new System.EventHandler(this.timeScaleRdo_CheckedChanged);
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(108)))), ((int)(((byte)(86)))), ((int)(((byte)(172)))));
            this.btnSearch.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearch.Font = new System.Drawing.Font("Vazir", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSearch.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(68)))), ((int)(((byte)(156)))));
            this.btnSearch.Location = new System.Drawing.Point(51, 562);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(199, 30);
            this.btnSearch.TabIndex = 126;
            this.btnSearch.Text = "تازه رسانی";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.calendar1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(285, 15);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(842, 638);
            this.panel2.TabIndex = 6;
            // 
            // calendar1
            // 
            this.calendar1.AllowItemEdit = false;
            this.calendar1.AllowItemResize = false;
            this.calendar1.AutoScroll = true;
            this.calendar1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            this.calendar1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.calendar1.FirstDayOfWeek = System.DayOfWeek.Saturday;
            this.calendar1.Font = new System.Drawing.Font("Vazir", 10F);
            this.calendar1.HighlightRanges = new System.Windows.Forms.Calendar.CalendarHighlightRange[0];
            this.calendar1.ItemsTimeFormat = "hh:mm tt";
            this.calendar1.Location = new System.Drawing.Point(0, 0);
            this.calendar1.Name = "calendar1";
            this.calendar1.Size = new System.Drawing.Size(842, 638);
            this.calendar1.TabIndex = 13;
            this.calendar1.Text = "calendar1";
            this.calendar1.LoadItems += new System.Windows.Forms.Calendar.Calendar.CalendarLoadEventHandler(this.calendar1_LoadItems);
            this.calendar1.DayHeaderClick += new System.Windows.Forms.Calendar.Calendar.CalendarDayEventHandler(this.calendar1_DayHeaderClick);
            this.calendar1.DayHeaderDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarDayEventHandler(this.calendar1_DayHeaderDoubleClick);
            this.calendar1.ItemCreated += new System.Windows.Forms.Calendar.Calendar.CalendarItemCancelEventHandler(this.calendar1_ItemCreated);
            this.calendar1.ItemDeleted += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDeleted);
            this.calendar1.ItemDoubleClick += new System.Windows.Forms.Calendar.Calendar.CalendarItemEventHandler(this.calendar1_ItemDoubleClick);
            this.calendar1.CalendarModeChange += new System.Windows.Forms.Calendar.Calendar.CalendarModeChangeHandler(this.calendar1_CalendarModeChange);
            this.calendar1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.calendar1_KeyUp);
            // 
            // VisitsList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(58)))), ((int)(((byte)(45)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1145, 668);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.splitter1);
            this.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.KeyPreview = true;
            this.Name = "VisitsList";
            this.Padding = new System.Windows.Forms.Padding(15);
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TimeVisit_Load);
            this.Shown += new System.EventHandler(this.WorkTimeVisits_Shown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TimeVisit_KeyUp);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Calendar.Calendar calendar1;
        private System.Windows.Forms.VScrollBar vScroll;
        private System.Windows.Forms.ComboBox DoctorCbo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdWeek;
        private System.Windows.Forms.RadioButton rdMonth;
        private System.Windows.Forms.RadioButton rdDay;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton timeScale30Rdo;
        private System.Windows.Forms.RadioButton timeScale15Rdo;
        private UserControls.PersianMonthCalendar persianMonth;
    }
}