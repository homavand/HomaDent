
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using PopupControl;


namespace Dentistry.UserControls
{

    [DefaultProperty("Value")]
    [ToolboxBitmap(typeof(MonthCalendar))]
    [DefaultEvent("ValueChanged")]
    public class PersianMonthCalendar : Control
    {
        public delegate void onValueChanged(object sender, PersianMonthCalendarEventArgs e);

        private class CellInfo
        {
            public Rectangle Rectangle;

            public PersianDate Value;
        }

        private string[] monthsArray = new string[12]
        {
        "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
        "بهمن", "اسفند"
        };

        private string[] weekArray = new string[7] { "ش", "ی", "د", "س", "چ", "پ", "ج" };

        private Pen blackPen = new Pen(Brushes.Gray, 1f);

        private Pen whitePen = new Pen(Brushes.White, 1.5f);

        private Color titleBackColor = Color.FromArgb(230, 230, 230);

        private Color titleForeColor = Color.Black;

        private Color markColor = Color.Green;

        //private SolidBrush brush = new SolidBrush(Color.FromArgb(73, 61, 87));
        private SolidBrush brush = new SolidBrush(Color.FromArgb(0, 0, 0));

        private SolidBrush markBrush = new SolidBrush(Color.Green);

        private StringFormat sf = StringFormat.GenericDefault;

        private PersianDate persianValue;

        private Font weekFont = new Font("Vazir FD", 9.75f, FontStyle.Regular);

        private CellInfo[] cells = null;

        private CellInfo selectedCell = null;

        private CellInfo oldSelectedCell = null;

        private List<PersianDate> markDateList;

        private int iSelectedCellIndex = -1;

        private bool showToday = true;

        private bool isMarkListSorted = false;

        private bool keepFocus = false;

        private Popup p;

        private MonthUC mo;

        private IContainer components = null;

        private PictureBox headerPanel;

        private NumericUpDown yearNumericUpDown;

        private Label monthLabel;

        private Label SepratorLabel;

        private Label yearLabel;

        private PictureBox bodyPanel;

        private PictureBox nextMonthButton;

        private PictureBox prevMonthButton;

        private ContextMenuStrip gotoTodayMenuStrip;

        private ToolStripMenuItem gotoTodayMitem;

        private System.Windows.Forms.LinkLabel todayLink;

        [Bindable(true)]
        [Category("Behavior")]
        [TypeConverter(typeof(PersianDateConverter))]
        [Description("The value of control")]
        public PersianDate Value
        {
            get
            {
                return persianValue;
            }
            set
            {
                try
                {
                    if (!base.DesignMode && value == PersianDate.MinValue)
                    {
                        value = PersianDate.Now;
                    }
                    OnValueChanged(value, persianValue);
                    persianValue = value;
                }
                catch (ArgumentException)
                {
                }
            }
        }

        [Bindable(true)]
        [Category("Behavior")]
        [Description("The ShowToday of control")]
        public bool ShowToday
        {
            get
            {
                return showToday;
            }
            set
            {
                showToday = value;
            }
        }
        
        [Category("Behavior")]
        [Bindable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Description("The ShowToday of control")]
        public List<PersianDate> MarkDates => markDateList;

        [DefaultValue("SystemColors.ActiveCaption")]
        [Category("Apperance")]
        [Description("The TitleBackColor of control in color")]
        [Bindable(true)]
        public Color TitleBackColor
        {
            get
            {
                return titleBackColor;
            }
            set
            {
                if (value != titleBackColor)
                {
                    titleBackColor = value;
                    brush = new SolidBrush(value);
                    headerPanel.BackColor = value;
                    Invalidate();
                    if (this.TitleBackColorChanged != null)
                    {
                        this.TitleBackColorChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        [Bindable(true)]
        [Category("Apperance")]
        [DefaultValue("Color.Black")]
        [Description("The TitleForeColor of control in color")]
        public Color TitleForeColor
        {
            get
            {
                return titleForeColor;
            }
            set
            {
                if (value != titleForeColor)
                {
                    titleForeColor = value;
                    Color color3 = (yearLabel.ForeColor = (monthLabel.ForeColor = value));
                    if (this.TitleForeColorChanged != null)
                    {
                        this.TitleForeColorChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        [Category("Apperance")]
        [Description("The TitleForeColor of control in color")]
        [DefaultValue("Color.Green")]
        [Bindable(true)]
        public Color MarkColor
        {
            get
            {
                return markColor;
            }
            set
            {
                markColor = value;
                markBrush = new SolidBrush(value);
            }
        }

        public event onValueChanged ValueChanged;

        public event EventHandler TitleBackColorChanged;

        public event EventHandler TitleForeColorChanged;

        internal event EventHandler PopupClosed;

        public PersianMonthCalendar()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
            SetStyle(ControlStyles.Selectable, value: true);
            sf.Alignment = StringAlignment.Center;           
            persianValue = PersianDate.Now;
            todayLink.Location = new Point(8, base.Height - todayLink.Height - 7);
            todayLink.Text = persianValue.ToString("امروز: dd NM yyyy");
            todayLink.Tag = persianValue;
            markDateList = new List<PersianDate>();
            FillCells(persianValue);
        }

        private void DarwWithArrangment(Graphics gr)
        {
            if (gr == null)
            {
                gr = Graphics.FromHwnd(bodyPanel.Handle);
            }
            int num = bodyPanel.Width -7 ;
            int num2 = 25;
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            string[] array = weekArray;
            foreach (string s in array)
            {
                num -= 30;
                gr.DrawString(s, weekFont, Brushes.Indigo, new Rectangle(num, 0, num2, 20), sf);
            }
            gr.DrawLine(blackPen, new Point(4, 20), new Point(bodyPanel.Width - 7, 20));
            int num3 = 0;
            CellInfo[] array2 = cells;
            foreach (CellInfo cellInfo in array2)
            {
                SizeF sizeF = gr.MeasureString(cellInfo.Value.Day.ToString(), Font);
                var pt = new Rectangle(cellInfo.Rectangle.X, cellInfo.Rectangle.Y + 2, cellInfo.Rectangle.Width, cellInfo.Rectangle.Height);
                if (cellInfo.Value.Day == Value.Day && cellInfo.Value.Month == Value.Month)
                {
                    
                    gr.FillRectangle(brush, cellInfo.Rectangle);
                    gr.DrawString(cellInfo.Value.Day.ToString("00"),new Font(Font.FontFamily,Font.Size,FontStyle.Bold), Brushes.White, pt, sf);
                    selectedCell = cellInfo;
                    iSelectedCellIndex = num3;
                }
                else if (cellInfo.Value.Month != Value.Month)
                {
                    gr.DrawString(cellInfo.Value.Day.ToString("00"), Font, Brushes.Silver, pt, sf);
                }
                else
                {                    
                    gr.DrawString(cellInfo.Value.Day.ToString("00"),  Font, Brushes.Black, pt, sf);
                }
                if (cellInfo.Value == (PersianDate)todayLink.Tag)
                {
                    gr.DrawRectangle(blackPen, cellInfo.Rectangle);
                }
                if (IsMarkDate(cellInfo.Value))
                {
                    gr.DrawRectangle(new Pen(markBrush, 1.25f), cellInfo.Rectangle);
                }
                num3++;
            }
        }

        private void DrawChangeDayInMonth(Graphics gr, CellInfo oldSelected, PersianDate curDate)
        {
            if (gr == null)
            {
                gr = Graphics.FromHwnd(bodyPanel.Handle);
            }
            gr.SmoothingMode = SmoothingMode.AntiAlias;
            SizeF sizeF = gr.MeasureString(selectedCell.Value.Day.ToString("00"), Font);
            gr.FillRectangle(brush, selectedCell.Rectangle);

            var pt1 = new Rectangle(selectedCell.Rectangle.X, selectedCell.Rectangle.Y + 2, selectedCell.Rectangle.Width, selectedCell.Rectangle.Height);

            gr.DrawString(selectedCell.Value.Day.ToString("00"), new Font(Font.FontFamily, Font.Size, FontStyle.Bold), Brushes.White, pt1, sf);
            if (oldSelected != null)
            {
                sizeF = gr.MeasureString(oldSelected.Value.Day.ToString("00"), Font);
                gr.FillRectangle(Brushes.White, oldSelected.Rectangle);
                if (!((PersianDate)todayLink.Tag == oldSelected.Value) && !IsMarkDate(oldSelected.Value))
                {
                    gr.DrawRectangle(whitePen, oldSelected.Rectangle);
                }

                var pt2 = new Rectangle(oldSelected.Rectangle.X, oldSelected.Rectangle.Y + 2, oldSelected.Rectangle.Width, oldSelected.Rectangle.Height);
                gr.DrawString(oldSelected.Value.Day.ToString("00"), Font, Brushes.Black, pt2, sf);
                gr.Dispose();
            }
        }

        private void FillCells(PersianDate date)
        {
            PersianDate minValue = PersianDate.MinValue;
            if (date == PersianDate.MinValue)
            {
                return;
            }
            if (markDateList.Count > 0 && !isMarkListSorted)
            {
                markDateList.Sort();
                isMarkListSorted = true;
            }
            cells = new CellInfo[42];
            int num = 0;
            int ww = 25;
            int hh = 20;
            int num4 = bodyPanel.Width;
            int num5 = 27;
            minValue = date.GetLastSaturday();
            for (int i = 0; i < 6; i++)
            {
                num4 = bodyPanel.Width - 6;
                for (int j = 0; j < 7; j++)
                {
                    num4 -= 30;
                    cells[num] = new CellInfo();
                    cells[num].Value = minValue;
                    cells[num].Rectangle = new Rectangle(num4, num5, ww, hh);
                    num++;
                    minValue = minValue.AddDays(1);
                }
                num5 += 20;
            }
        }

        private void ChangeValueByPoint(Point point)
        {
            int num = 0;
            CellInfo[] array = cells;
            foreach (CellInfo cellInfo in array)
            {
                if (cellInfo.Value == selectedCell.Value)
                {
                    num++;
                    continue;
                }
                if (cellInfo.Rectangle.Contains(point))
                {
                    oldSelectedCell = selectedCell;
                    selectedCell = cellInfo;
                    iSelectedCellIndex = num;
                    Value = cellInfo.Value;
                    break;
                }
                num++;
            }
        }

        private bool IsMarkDate(PersianDate date)
        {
            int num = markDateList.BinarySearch(date);
            return num > -1;
        }

        public void Active()
        {
            todayLink.Focus();
        }

        public virtual void GotoToday()
        {
            try
            {
                Value = (PersianDate)todayLink.Tag;
            }
            catch (Exception)
            {
            }
        }

        protected virtual void OnValueChanged(PersianDate curDate, PersianDate oldDate)
        {
            if (this.ValueChanged != null)
            {
                this.ValueChanged(this, new PersianMonthCalendarEventArgs
                {
                    CurrentValue = curDate,
                    OldValue = oldDate
                });
            }
            if (selectedCell == null || curDate.Month != oldDate.Month || curDate.Year != oldDate.Year || curDate == PersianDate.Now)
            {
                FillCells(curDate);
                bodyPanel.Invalidate();
            }
            else
            {
                DrawChangeDayInMonth(null, oldSelectedCell, curDate);
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            todayLink.Focus();
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            switch (keyData)
            {
                case Keys.Left:
                    keepFocus = true;
                    if (iSelectedCellIndex < 41)
                    {
                        oldSelectedCell = selectedCell;
                        selectedCell = cells[++iSelectedCellIndex];
                    }
                    Value = Value.AddDays(1);
                    return true;
                case Keys.Right:
                    keepFocus = true;
                    if (iSelectedCellIndex - 1 >= 0)
                    {
                        oldSelectedCell = selectedCell;
                        selectedCell = cells[--iSelectedCellIndex];
                    }
                    Value = Value.AddDays(-1);
                    return true;
                case Keys.Up:
                    keepFocus = true;
                    if (iSelectedCellIndex - 7 >= 0)
                    {
                        oldSelectedCell = selectedCell;
                        selectedCell = cells[iSelectedCellIndex - 7];
                        iSelectedCellIndex -= 7;
                    }
                    Value = Value.AddDays(-7);
                    break;
                case Keys.Down:
                    keepFocus = true;
                    if (iSelectedCellIndex + 7 < 42)
                    {
                        oldSelectedCell = selectedCell;
                        selectedCell = cells[iSelectedCellIndex + 7];
                        iSelectedCellIndex += 7;
                    }
                    Value = Value.AddDays(7);
                    break;
                case Keys.Return:
                case Keys.Escape:
                    keepFocus = false;
                    if (this.PopupClosed != null)
                    {
                        this.PopupClosed(this, EventArgs.Empty);
                    }
                    return true;
                case Keys.Tab:
                    keepFocus = false;
                    break;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void nextMonthButton_Click(object sender, EventArgs e)
        {
            try
            {
                Value = Value.AddDays(persianValue.GetDaysInMonth());
            }
            catch (ArgumentException)
            {
            }
        }

        private void prevMonthButton_Click(object sender, EventArgs e)
        {
            try
            {
                Value = Value.AddDays((persianValue.Month > 7) ? (-30) : (-31));
            }
            catch (ArgumentException)
            {
            }
        }

        private void gotoTodayMitem_Click(object sender, EventArgs e)
        {
            try
            {
                Value = PersianDate.Now;
            }
            catch (ArgumentException)
            {
            }
        }

        private void monthMitem_Click(object sender, EventArgs e)
        {
            try
            {
                Value = new PersianDate(persianValue.Year, Convert.ToInt32(((ToolStripMenuItem)sender).Tag), persianValue.Day);
            }
            catch (ArgumentException)
            {
            }
        }

        private void monthLabel_Click(object sender, EventArgs e)
        {
            if (p == null)
            {
                mo = new MonthUC();
                mo.MonthChanged += delegate (object s, EventArgs ee)
                {
                    try
                    {
                        Value = new PersianDate(persianValue.Year, int.Parse(((RadioButton)s).Tag.ToString()), persianValue.Day);
                    }
                    catch (ArgumentException)
                    {
                    }
                };
                p = new Popup(mo);
                if (!SystemInformation.IsComboBoxAnimationEnabled)
                {
                    PopupAnimations popupAnimations3 = (p.ShowingAnimation = (p.HidingAnimation = PopupAnimations.None));
                }
                else
                {
                    p.ShowingAnimation = PopupAnimations.TopToBottom | PopupAnimations.Slide;
                    p.HidingAnimation = PopupAnimations.BottomToTop | PopupAnimations.Slide;
                }
            }
            p.Hide();
            mo.ActiveRadioByTagID(persianValue.Month);
            p.Show(monthLabel);
        }

        private void yearLabel_Click(object sender, EventArgs e)
        {
            yearNumericUpDown.Visible = true;
            yearNumericUpDown.Value = Value.Year;
        }

        private void headerPanel_Click(object sender, EventArgs e)
        {
            if (yearNumericUpDown.Visible)
            {
                yearNumericUpDown.Visible = false;
                try
                {
                    PersianDate persianDate2 = (Value = new PersianDate((int)yearNumericUpDown.Value, persianValue.Month, persianValue.Day));
                }
                catch (ArgumentException)
                {
                }
            }
        }

        private void nextMonthButton_MouseDown(object sender, MouseEventArgs e)
        {
            //((PictureBox)sender).Image = Dentistry.Properties.Resources.R_On;
        }

        private void prevMonthButton_MouseDown(object sender, MouseEventArgs e)
        {
           // ((PictureBox)sender).Image = Dentistry.Properties.Resources.L_Off;
        }

        private void bodyPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ChangeValueByPoint(e.Location);
                keepFocus = true;
                todayLink.Focus();
                if (this.PopupClosed != null)
                {
                    this.PopupClosed(this, EventArgs.Empty);
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                gotoTodayMenuStrip.Show(bodyPanel, e.Location);
            }
        }

        private void nextMonthButton_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = Dentistry.Properties.Resources.right;
        }

        private void prevMonthButton_MouseUp(object sender, MouseEventArgs e)
        {
            ((PictureBox)sender).Image = Dentistry.Properties.Resources.left;
        }

        private void todayLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                GotoToday();
                if (this.PopupClosed != null)
                {
                    this.PopupClosed(this, EventArgs.Empty);
                }
            }
            catch (ArgumentException)
            {
            }
        }

        private void yearNumericUpDown_Validating(object sender, CancelEventArgs e)
        {
            yearNumericUpDown.Visible = false;
            try
            {
                Value = new PersianDate((int)yearNumericUpDown.Value, persianValue.Month, persianValue.Day);
            }
            catch (ArgumentException)
            {
            }
        }

        private void bodyPanel_Paint(object sender, PaintEventArgs e)
        {
            
            if (cells != null)
            {
                sf.Alignment = StringAlignment.Center;
                DarwWithArrangment(e.Graphics);
                monthLabel.Location = new Point(125, monthLabel.Location.Y);
                SepratorLabel.Location = new Point(113, monthLabel.Location.Y);
                yearLabel.Location = new Point(80, monthLabel.Location.Y);
                monthLabel.Text = Value.Month.ToString("00");
                yearLabel.Text = Value.Year.ToString("0000");
            }
        }

        private void PersianMonthCalendar_LostFocus(object sender, EventArgs e)
        {
            if (keepFocus)
            {
                bodyPanel.Focus();
            }
            keepFocus = false;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.yearNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.gotoTodayMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.gotoTodayMitem = new System.Windows.Forms.ToolStripMenuItem();
            this.todayLink = new System.Windows.Forms.LinkLabel();
            this.nextMonthButton = new System.Windows.Forms.PictureBox();
            this.prevMonthButton = new System.Windows.Forms.PictureBox();
            this.bodyPanel = new System.Windows.Forms.PictureBox();
            this.headerPanel = new System.Windows.Forms.PictureBox();
            this.monthLabel = new System.Windows.Forms.Label();
            this.SepratorLabel = new System.Windows.Forms.Label();
            this.yearLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).BeginInit();
            this.gotoTodayMenuStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nextMonthButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevMonthButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodyPanel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // yearNumericUpDown
            // 
            this.yearNumericUpDown.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.yearNumericUpDown.Font = new System.Drawing.Font("Vazir FD", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yearNumericUpDown.ForeColor = System.Drawing.Color.Black;
            this.yearNumericUpDown.Location = new System.Drawing.Point(52, 2);
            this.yearNumericUpDown.Maximum = new decimal(new int[] {
            1500,
            0,
            0,
            0});
            this.yearNumericUpDown.Minimum = new decimal(new int[] {
            1290,
            0,
            0,
            0});
            this.yearNumericUpDown.Name = "yearNumericUpDown";
            this.yearNumericUpDown.Size = new System.Drawing.Size(64, 26);
            this.yearNumericUpDown.TabIndex = 2;
            this.yearNumericUpDown.Value = new decimal(new int[] {
            1386,
            0,
            0,
            0});
            this.yearNumericUpDown.Visible = false;
            this.yearNumericUpDown.Validating += new System.ComponentModel.CancelEventHandler(this.yearNumericUpDown_Validating);
            // 
            // gotoTodayMenuStrip
            // 
            this.gotoTodayMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gotoTodayMitem});
            this.gotoTodayMenuStrip.Name = "monthMenuStrip";
            this.gotoTodayMenuStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.gotoTodayMenuStrip.Size = new System.Drawing.Size(130, 26);
            // 
            // gotoTodayMitem
            // 
            this.gotoTodayMitem.Name = "gotoTodayMitem";
            this.gotoTodayMitem.Size = new System.Drawing.Size(129, 22);
            this.gotoTodayMitem.Tag = "12";
            this.gotoTodayMitem.Text = "برو به امروز";
            this.gotoTodayMitem.Click += new System.EventHandler(this.gotoTodayMitem_Click);
            // 
            // todayLink
            // 
            this.todayLink.AutoSize = true;
            this.todayLink.CausesValidation = false;
            this.todayLink.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.todayLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.todayLink.Location = new System.Drawing.Point(12, 150);
            this.todayLink.Name = "todayLink";
            this.todayLink.Size = new System.Drawing.Size(0, 19);
            this.todayLink.TabIndex = 8;
            this.todayLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.todayLink_LinkClicked);
            // 
            // nextMonthButton
            // 
            this.nextMonthButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.nextMonthButton.Image = global::Dentistry.Properties.Resources.right;
            this.nextMonthButton.Location = new System.Drawing.Point(200, 6);
            this.nextMonthButton.Name = "nextMonthButton";
            this.nextMonthButton.Size = new System.Drawing.Size(21, 15);
            this.nextMonthButton.TabIndex = 6;
            this.nextMonthButton.TabStop = false;
            this.nextMonthButton.Click += new System.EventHandler(this.nextMonthButton_Click);
            this.nextMonthButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.nextMonthButton_MouseDown);
            this.nextMonthButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.nextMonthButton_MouseUp);
            // 
            // prevMonthButton
            // 
            this.prevMonthButton.Image = global::Dentistry.Properties.Resources.left;
            this.prevMonthButton.Location = new System.Drawing.Point(9, 6);
            this.prevMonthButton.Name = "prevMonthButton";
            this.prevMonthButton.Size = new System.Drawing.Size(21, 15);
            this.prevMonthButton.TabIndex = 7;
            this.prevMonthButton.TabStop = false;
            this.prevMonthButton.Click += new System.EventHandler(this.prevMonthButton_Click);
            this.prevMonthButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.prevMonthButton_MouseDown);
            this.prevMonthButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.prevMonthButton_MouseUp);
            // 
            // bodyPanel
            // 
            this.bodyPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bodyPanel.Location = new System.Drawing.Point(0, 26);
            this.bodyPanel.Name = "bodyPanel";
            this.bodyPanel.Size = new System.Drawing.Size(230, 180);
            this.bodyPanel.TabIndex = 5;
            this.bodyPanel.TabStop = false;
            this.bodyPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.bodyPanel_Paint);
            this.bodyPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.bodyPanel_MouseDown);
            // 
            // headerPanel
            // 
            this.headerPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.headerPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(255)))));

            this.headerPanel.Controls.Add(this.monthLabel);
            this.headerPanel.Controls.Add(this.SepratorLabel);
            this.headerPanel.Controls.Add(this.yearLabel);
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Size = new System.Drawing.Size(230, 26);
            this.headerPanel.TabIndex = 2;
            this.headerPanel.TabStop = false;
            this.headerPanel.Click += new System.EventHandler(this.headerPanel_Click);
            // 
            // monthLabel
            // 
            this.monthLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monthLabel.AutoSize = true;
            this.monthLabel.BackColor = System.Drawing.Color.Transparent;
            this.monthLabel.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.monthLabel.ForeColor = System.Drawing.Color.Black;
            this.monthLabel.Location = new System.Drawing.Point(170, 5);
            this.monthLabel.Name = "monthLabel";
            this.monthLabel.Size = new System.Drawing.Size(27, 21);
            this.monthLabel.TabIndex = 1;
            this.monthLabel.Text = "08";
            this.monthLabel.Click += new System.EventHandler(this.monthLabel_Click);
            // 
            // SepratorLabel
            // 
            this.SepratorLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SepratorLabel.AutoSize = true;
            this.SepratorLabel.BackColor = System.Drawing.Color.Transparent;
            this.SepratorLabel.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.SepratorLabel.ForeColor = System.Drawing.Color.Black;
            this.SepratorLabel.Location = new System.Drawing.Point(161, 6);
            this.SepratorLabel.Name = "SepratorLabel";
            this.SepratorLabel.Size = new System.Drawing.Size(15, 21);
            this.SepratorLabel.TabIndex = 5;
            this.SepratorLabel.Text = "-";
            // 
            // yearLabel
            // 
            this.yearLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.yearLabel.AutoSize = true;
            this.yearLabel.BackColor = System.Drawing.Color.Transparent;
            this.yearLabel.Font = new System.Drawing.Font("Vazir FD", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.yearLabel.ForeColor = System.Drawing.Color.Black;
            this.yearLabel.Location = new System.Drawing.Point(125, 5);
            this.yearLabel.Name = "yearLabel";
            this.yearLabel.Size = new System.Drawing.Size(45, 21);
            this.yearLabel.TabIndex = 3;
            this.yearLabel.Text = "1386";
            this.yearLabel.Click += new System.EventHandler(this.yearLabel_Click);
            // 
            // PersianMonthCalendar
            // 
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.todayLink);
            this.Controls.Add(this.yearNumericUpDown);
            this.Controls.Add(this.nextMonthButton);
            this.Controls.Add(this.prevMonthButton);
            this.Controls.Add(this.bodyPanel);
            this.Controls.Add(this.headerPanel);
            this.Font = new System.Drawing.Font("Vazir FD", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximumSize = new System.Drawing.Size(230, 200);
            this.MinimumSize = new System.Drawing.Size(230, 200);
            this.Size = new System.Drawing.Size(230, 200);
            this.LostFocus += new System.EventHandler(this.PersianMonthCalendar_LostFocus);
            ((System.ComponentModel.ISupportInitialize)(this.yearNumericUpDown)).EndInit();
            this.gotoTodayMenuStrip.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.nextMonthButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prevMonthButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bodyPanel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.headerPanel)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.headerPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
    }

}