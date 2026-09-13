using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using PopupControl;

namespace Dentistry.UserControls
{


    [DefaultEvent("ValueChanged")]
    [ToolboxBitmap(typeof(DateTimePicker))]
    [DefaultProperty("Value")]
    public class PersianDateTimePicker : Control
    {
        public delegate void onValueChanged(object sender, PersianMonthCalendarEventArgs e);

        private enum DatePartTypes
        {
            None,
            Day,
            Month,
            Year
        }

        private Pen borderPen = new Pen(Brushes.RoyalBlue, 1.25f);

        private SolidBrush selectedBrush = new SolidBrush(Color.RoyalBlue);

        private StringFormat sf = StringFormat.GenericDefault;

        private RectangleF rectYear;

        private RectangleF rectMonth;

        private RectangleF rectDay;

        private RectangleF rectSep1;

        private RectangleF rectSep2;

        private RectangleF rectFillYear;

        private RectangleF rectFillMonth;

        private RectangleF rectFillDay;

        private RectangleF rectHour;

        private RectangleF rectMinute;

        private RectangleF rectSepHour;

        private RectangleF rectFillHour;

        private RectangleF rectFillMinute;

        private Rectangle rectComboButton;

        private PersianDate persianValue = PersianDate.MinValue;

        private DatePartTypes selectedCommand = DatePartTypes.None;

        private Popup popup;

        private PersianMonthCalendar persianMonthCalendar;

        private bool keepFocus = false;

        private bool sizeChanging = false;

        protected bool IsOpen = false;

        private bool showTime = false;

        private bool isInitFirst = false;

        private Font font = new Font("Vazir FD", 9.75f, FontStyle.Bold);

        private Graphics graphic;

        private string _digit = "";

        private IContainer components = null;

        [Category("Behavior")]
        [Description("The value of control")]
        [TypeConverter(typeof(PersianDateConverter))]
        [Bindable(true)]
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
                    if (!base.DesignMode && value == PersianDate.MinValue && !isInitFirst)
                    {
                        value = PersianDate.Now;
                        isInitFirst = true;
                    }
                    PersianDate persianDate = persianValue;
                    if (value != persianDate)
                    {
                        persianValue = value;
                        OnValueChanged(value, persianDate);
                    }
                }
                catch (ArgumentException)
                {
                }
            }
        }

        [Category("Behavior")]
        [Description("set show display time ")]
        public bool ShowTime
        {
            get
            {
                return showTime;
            }
            set
            {
                showTime = value;
                DrawDate(Graphic);
            }
        }

        public override Font Font
        {
            get
            {
                return font;
            }
            set
            {
                font = value;
                base.Font = value;
            }
        }

        protected Graphics Graphic
        {
            get
            {
                if (graphic == null && base.IsHandleCreated)
                {
                    graphic = CreateGraphics();
                }
                return graphic;
            }
        }

        public event onValueChanged ValueChanged;

        public PersianDateTimePicker()
        {
            InitializeComponent();
            SetStyle(ControlStyles.OptimizedDoubleBuffer, value: true);
            SetStyle(ControlStyles.Selectable, value: true);
            SetStyle(ControlStyles.StandardClick, value: true);
            SetStyle(ControlStyles.FixedWidth, value: true);
            persianMonthCalendar = new PersianMonthCalendar();
            persianMonthCalendar.ValueChanged += persianMonthCalendar_ValueChanged;
            persianMonthCalendar.PopupClosed += persianMonthCalendar_PopupClosed;
            popup = new Popup(persianMonthCalendar);
            if (SystemInformation.IsComboBoxAnimationEnabled)
            {
                popup.ShowingAnimation = PopupAnimations.TopToBottom | PopupAnimations.Slide;
                popup.HidingAnimation = PopupAnimations.BottomToTop | PopupAnimations.Slide;
            }
            else
            {
                popup.ShowingAnimation = (popup.HidingAnimation = PopupAnimations.None);
            }
            sf.Alignment = StringAlignment.Near;
            sf.Trimming |= StringTrimming.Word;
        }

        ~PersianDateTimePicker()
        {
            popup = null;
            if (Graphic != null)
                Graphic.Dispose();
            if (sf != null)
                sf.Dispose();
            persianMonthCalendar = null;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (rectComboButton == Rectangle.Empty)
            {
                UpdateRectangle(Value);
            }
            Rectangle clientRectangle = base.ClientRectangle;
            clientRectangle.Width--;
            clientRectangle.Height--;
            e.Graphics.DrawRectangle(borderPen, clientRectangle);
            DrawComboButton(e.Graphics, ButtonState.Normal);
            DrawDate(e.Graphics);
            e.Graphics.DrawString("/", Font, Brushes.Black, rectSep1, sf);
            e.Graphics.DrawString("/", Font, Brushes.Black, rectSep2, sf);
            if (showTime)
            {
                e.Graphics.DrawString(":", Font, Brushes.Black, rectSepHour, sf);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            Focus();
            if (rectFillYear.Contains(e.Location))
            {
                selectedCommand = DatePartTypes.Year;
                DrawDate(Graphic);
            }
            else if (rectMonth.Contains(e.Location))
            {
                selectedCommand = DatePartTypes.Month;
                DrawDate(Graphic);
            }
            else if (rectComboButton.Contains(e.Location))
            {
                DrawComboButton(Graphic, ButtonState.Pushed);
                ShowCalendar();
            }
            else if (rectDay.Contains(e.Location))
            {
                selectedCommand = DatePartTypes.Day;
                DrawDate(Graphic);
            }
            else if (!showTime)
            {
                selectedCommand = DatePartTypes.Day;
                DrawDate(Graphic);
            }
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            DrawComboButton(Graphic, ButtonState.Normal);
            base.OnMouseUp(e);
        }

        protected override void OnLostFocus(EventArgs e)
        {
            if (keepFocus)
            {
                keepFocus = false;
            }
            SetDateTimeByKeyboardBuffer();
            selectedCommand = DatePartTypes.None;
            Invalidate();
            base.OnLostFocus(e);
        }

        protected override void OnLeave(EventArgs e)
        {
            base.OnLeave(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            if (e.Delta < 0)
            {
                OnPreviewKeyDown(new PreviewKeyDownEventArgs(Keys.Down));
            }
            else
            {
                OnPreviewKeyDown(new PreviewKeyDownEventArgs(Keys.Up));
            }
            base.OnMouseWheel(e);
        }

        protected override void OnGotFocus(EventArgs e)
        {
            if (!keepFocus)
            {
                selectedCommand = DatePartTypes.Day;
                DrawDate(Graphic);
            }
            base.OnGotFocus(e);
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (keyData == Keys.Left || keyData == Keys.Right || keyData == Keys.Up || keyData == Keys.Down)
            {
                return false;
            }
            return base.ProcessDialogKey(keyData);
        }

        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
                {
                    SetDateTimeByKeyboardBuffer();
                }
                switch (e.KeyCode)
                {
                    case Keys.Left:
                        if (selectedCommand == DatePartTypes.None)
                        {
                            return;
                        }
                        keepFocus = true;
                        switch (selectedCommand)
                        {
                            case DatePartTypes.Day:
                                selectedCommand = DatePartTypes.Month;
                                break;
                            case DatePartTypes.Month:
                                selectedCommand = DatePartTypes.Year;
                                break;
                            case DatePartTypes.Year:
                                if (!showTime)
                                {
                                    selectedCommand = DatePartTypes.Day;
                                }
                                break;
                        }
                        DrawDate(Graphic);
                        break;
                    case Keys.Right:
                        if (selectedCommand == DatePartTypes.None)
                        {
                            return;
                        }
                        keepFocus = true;
                        switch (selectedCommand)
                        {
                            case DatePartTypes.Day:
                                if (!showTime)
                                {
                                    selectedCommand = DatePartTypes.Year;
                                }
                                break;
                            case DatePartTypes.Month:
                                selectedCommand = DatePartTypes.Day;
                                break;
                            case DatePartTypes.Year:
                                selectedCommand = DatePartTypes.Month;
                                break;
                        }
                        DrawDate(Graphic);
                        break;
                    case Keys.Up:
                        if (selectedCommand == DatePartTypes.None)
                        {
                            return;
                        }
                        keepFocus = true;
                        switch (selectedCommand)
                        {
                            case DatePartTypes.Day:
                                {
                                    int daysInMonth = -1;
                                    if ((daysInMonth = persianValue.GetDaysInMonth()) != persianValue.Day)
                                    {
                                        Value = Value.AddDays(1);
                                    }
                                    else
                                    {
                                        Value = new PersianDate(persianValue.Year, persianValue.Month, 1);
                                    }
                                    break;
                                }
                            case DatePartTypes.Month:
                                if (persianValue.Month != 12)
                                {
                                    Value = new PersianDate(persianValue.Year, persianValue.Month + 1, persianValue.Day);
                                }
                                else
                                {
                                    Value = new PersianDate(persianValue.Year, 1, persianValue.Day);
                                }
                                break;
                            case DatePartTypes.Year:
                                if (persianValue.Year != 1500)
                                {
                                    Value = new PersianDate(persianValue.Year + 1, persianValue.Month, persianValue.Day);
                                }
                                else
                                {
                                    Value = new PersianDate(1300, persianValue.Month, persianValue.Day);
                                }
                                break;
                        }
                        break;
                    case Keys.Down:
                        if (selectedCommand == DatePartTypes.None)
                        {
                            return;
                        }
                        keepFocus = true;
                        switch (selectedCommand)
                        {
                            case DatePartTypes.Day:
                                {
                                    int daysInMonth = (daysInMonth = persianValue.GetDaysInMonth());
                                    if (1 != persianValue.Day)
                                    {
                                        Value = Value.AddDays(-1);
                                    }
                                    else
                                    {
                                        Value = new PersianDate(persianValue.Year, persianValue.Month, daysInMonth);
                                    }
                                    break;
                                }
                            case DatePartTypes.Month:
                                if (persianValue.Month != 1)
                                {
                                    Value = new PersianDate(persianValue.Year, persianValue.Month - 1, persianValue.Day);
                                }
                                else
                                {
                                    Value = new PersianDate(persianValue.Year, 12, persianValue.Day);
                                }
                                break;
                            case DatePartTypes.Year:
                                if (persianValue.Year != 1300)
                                {
                                    Value = new PersianDate(persianValue.Year - 1, persianValue.Month, persianValue.Day);
                                }
                                else
                                {
                                    Value = new PersianDate(1500, persianValue.Month, persianValue.Day);
                                }
                                break;
                        }
                        break;
                    case Keys.Return:
                        if (e.Control)
                        {
                            ShowCalendar();
                        }
                        break;
                }
                int keyCode = (int)e.KeyCode;
                int num = -1;
                if (keyCode >= 48 && keyCode <= 57)
                {
                    num = keyCode - 48;
                }
                if (keyCode >= 96 && keyCode <= 105)
                {
                    num = keyCode - 96;
                }
                if (num != -1)
                {
                    DrawDigit(Graphic, num);
                }
            }
            catch (ArgumentException)
            {
            }
            base.OnPreviewKeyDown(e);
        }

        protected override void OnFontChanged(EventArgs e)
        {
            UpdateRectangle(Value);
            base.OnFontChanged(e);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (!sizeChanging)
            {
                UpdateRectangle(Value);
            }
        }

        private void DrawDate(Graphics gr)
        {
            if (gr != null)
            {
                UpdateRectangle(Value);
                gr.FillRectangle(Brushes.White, rectFillMonth);
                gr.FillRectangle(Brushes.White, rectFillDay);
                gr.FillRectangle(Brushes.White, rectFillYear);
                if (showTime)
                {
                    gr.FillRectangle(Brushes.White, rectFillMinute);
                    gr.FillRectangle(Brushes.White, rectFillHour);
                }
                Brush brush3;
                Brush brush2;
                Brush brush;
                Brush brush4 = (brush3 = (brush2 = (brush = Brushes.Black)));
                switch (selectedCommand)
                {
                    case DatePartTypes.Day:
                        gr.FillRectangle(selectedBrush, rectFillDay);
                        brush3 = Brushes.White;
                        break;
                    case DatePartTypes.Month:
                        gr.FillRectangle(selectedBrush, rectFillMonth);
                        brush2 = Brushes.White;
                        break;
                    case DatePartTypes.Year:
                        gr.FillRectangle(selectedBrush, rectFillYear);
                        brush = Brushes.White;
                        break;
                }
                gr.DrawString(Value.Year.ToString("0000"), font, brush, rectYear, sf);
                gr.DrawString(Value.Month.ToString("00"), font, brush2, rectMonth, sf);
                gr.DrawString(Value.Day.ToString("00"), font, brush3, rectDay, sf);
                if (!showTime)
                {
                }
            }
        }

        private void DrawComboButton(Graphics gr, ButtonState state)
        {
            ControlPaint.DrawComboButton(gr, rectComboButton, state);
        }

        private void DrawDigit(Graphics gr, int digit)
        {
            if (gr == null)
            {
                return;
            }
            if (rectComboButton == Rectangle.Empty)
            {
                UpdateRectangle(Value);
            }
            StringFormat stringFormat = new StringFormat();
            stringFormat.Alignment |= StringAlignment.Far;
            string text = "";
            switch (selectedCommand)
            {
                case DatePartTypes.Day:
                    gr.FillRectangle(selectedBrush, rectFillDay);
                    text = _digit;
                    text += digit;
                    if (Convert.ToInt32(text) <= persianValue.GetDaysInMonth())
                    {
                        _digit = text;
                    }
                    else
                    {
                        _digit = digit.ToString();
                    }
                    gr.DrawString(_digit, font, Brushes.White, rectDay, stringFormat);
                    break;
                case DatePartTypes.Month:
                    text = _digit;
                    text += digit;
                    if (Convert.ToInt32(text) <= 12)
                    {
                        _digit = text;
                    }
                    else
                    {
                        _digit = digit.ToString();
                    }
                    gr.FillRectangle(selectedBrush, rectFillMonth);
                    gr.DrawString(_digit, font, Brushes.White, rectMonth, stringFormat);
                    break;
                case DatePartTypes.Year:
                    if (_digit.Length < 4)
                    {
                        text = _digit;
                        text += digit;
                        if (Convert.ToInt32(text) <= 1500)
                        {
                            _digit = text;
                        }
                        else
                        {
                            _digit = digit.ToString();
                        }
                        gr.FillRectangle(selectedBrush, rectFillYear);
                        gr.DrawString(_digit, font, Brushes.White, rectYear, stringFormat);
                    }
                    else
                    {
                        _digit = "";
                    }
                    break;
            }
        }

        private int GetTop(Control ct, int topTotal)
        {
            if (ct != null)
            {
                topTotal += GetTop(ct.Parent, ct.Location.Y);
            }
            return topTotal;
        }

        private int GetLeft(Control ct, int leftTotal)
        {
            if (ct != null)
            {
                leftTotal += GetLeft(ct.Parent, ct.Location.X);
            }
            return leftTotal;
        }

        private void SetDateTimeByKeyboardBuffer()
        {
            if (_digit.Length <= 0)
            {
                return;
            }
            int num = Convert.ToInt32(_digit);
            _digit = "";
            switch (selectedCommand)
            {
                case DatePartTypes.Day:
                    Value = new PersianDate(persianValue.Year, persianValue.Month, num);
                    break;
                case DatePartTypes.Month:
                    Value = new PersianDate(persianValue.Year, num, persianValue.Day);
                    break;
                case DatePartTypes.Year:
                    if (num < 100)
                    {
                        num += 1300;
                    }
                    Value = new PersianDate(num, persianValue.Month, persianValue.Day);
                    break;
            }
        }

        private void ShowCalendar()
        {
            if (IsOpen)
            {
                popup.Hide();
                IsOpen = false;
            }
            else
            {
                IsOpen = true;
                persianMonthCalendar.Value = Value;
                popup.Show(this);
            }
        }

        private void UpdateRectangle(PersianDate curDate)
        {
            bool flag = 0 == 0;
            sizeChanging = true;
            Graphics graphics = Graphic;
            if (graphics != null)
            {
                SizeF sizeF = graphics.MeasureString(curDate.Year.ToString("0000"), font, 0, sf);
                base.Height = (int)sizeF.Height + 4;
                float num = (float)base.Height / 2f - sizeF.Height / 2f;
                rectYear = new RectangleF(2f, num, sizeF.Width, sizeF.Height);
                sizeF = graphics.MeasureString("/", font, 0, sf);
                rectSep1 = new RectangleF(rectYear.Right - sizeF.Width / 3.5f + 2f, num, sizeF.Width, sizeF.Height);
                sizeF = graphics.MeasureString(curDate.Month.ToString("00"), font, 0, sf);
                rectMonth = new RectangleF(rectSep1.Right - rectSep1.Width / 3.5f, num, sizeF.Width, sizeF.Height);
                rectSep2 = new RectangleF(rectMonth.Right - rectSep1.Width / 4f + 2f, num, rectSep1.Width, rectSep1.Height);
                sizeF = graphics.MeasureString(curDate.Day.ToString("00"), font, 0, sf);
                rectDay = new RectangleF(rectSep2.Right - rectSep1.Width / 3.7f, num, sizeF.Width, sizeF.Height);
                rectFillYear = rectYear;
                rectFillYear.Height -= 1f;
                rectFillMonth = rectMonth;
                rectFillMonth.Height -= 1f;
                rectFillDay = rectDay;
                rectFillDay.Height -= 1f;
                rectComboButton = new Rectangle(base.Width - 21, (int)rectYear.Y, 20, base.Height - 1);
                sizeChanging = false;
            }
        }

        protected virtual void OnValueChanged(PersianDate curDate, PersianDate oldDate)
        {
            if (!(curDate == oldDate))
            {
                if (!PersianDate.ValidDate(curDate))
                {
                    curDate = oldDate;
                }
                DrawDate(Graphic);
                if (this.ValueChanged != null)
                {
                    this.ValueChanged(this, new PersianMonthCalendarEventArgs
                    {
                        CurrentValue = curDate,
                        OldValue = oldDate
                    });
                }
            }
        }

        private void persianMonthCalendar_PopupClosed(object sender, EventArgs e)
        {
            IsOpen = false;
            popup.Hide();
            selectedCommand = DatePartTypes.Day;
            Value = persianMonthCalendar.Value;
        }

        private void persianMonthCalendar_ValueChanged(object sender, PersianMonthCalendarEventArgs e)
        {
            selectedCommand = DatePartTypes.Day;
            Value = e.CurrentValue;
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
            base.SuspendLayout();
            this.BackColor = System.Drawing.Color.White;
            this.Font = new System.Drawing.Font("Vazir FD", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 178);
            base.Size = new System.Drawing.Size(175, 20);
            base.ResumeLayout(false);

            this.Value = DateTime.Now;
        }
    }

}