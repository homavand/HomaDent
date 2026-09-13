
using Dentistry.Class;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;
namespace Dentistry.UserControls
{
    public class NumberTextBox : TextBox
    {
        private IContainer components = null;
        private ToolTip ToolTip;
        private string characterSet = "0123456789";
        private int minLength;
        private bool allowPoint;
        private bool moveToNextOnEnterKey;
        private bool showToolTip;
        private bool insertZeroToLeft;
        public bool InsertZeroToLeft
        {
            get
            {
                return this.insertZeroToLeft;
            }
            set
            {
                this.insertZeroToLeft = value;
            }
        }
        public bool ShowToolTip
        {
            get
            {
                return this.showToolTip;
            }
            set
            {
                this.showToolTip = value;
            }
        }
        public bool MoveToNextOnEnterKey
        {
            get
            {
                return this.moveToNextOnEnterKey;
            }
            set
            {
                this.moveToNextOnEnterKey = value;
            }
        }
        public bool AllowPoint
        {
            get
            {
                return this.allowPoint;
            }
            set
            {
                this.allowPoint = value;
                if (value)
                {
                    this.characterSet += ".";
                }
                else
                {
                    this.characterSet = this.characterSet.Replace(".", "");
                }
            }
        }
        public int MinLength
        {
            get
            {
                return this.minLength;
            }
            set
            {
                if (value >= 0 && value <= 18)
                {
                    this.minLength = value;
                    if (this.MaxLength < value)
                    {
                        this.MaxLength = value;
                    }
                }
            }
        }
        public override int MaxLength
        {
            get
            {
                return base.MaxLength;
            }
            set
            {
                if (value > 0 && value <= 18)
                {
                    base.MaxLength = value;
                    if (this.MinLength > value)
                    {
                        this.MinLength = value;
                    }
                }
            }
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing && this.components != null)
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }
        private void InitializeComponent()
        {
            this.components = new Container();
        }
        public NumberTextBox()
        {
            this.ToolTip = new ToolTip();
            base.KeyPress += new KeyPressEventHandler(this.NumberTextBox_KeyPress);
            base.TextChanged += new EventHandler(this.NumberTextBox_TextChanged);
            base.Enter += new EventHandler(this.NumberTextBox_Enter);
            base.Leave += new EventHandler(this.NumberTextBox_Leave);
            base.MouseEnter += new EventHandler(this.NumberTextBox_MouseEnter);
            base.MouseLeave += new EventHandler(this.NumberTextBox_MouseLeave);
            this.MinLength = 0;
            this.MaxLength = 10;
            base.SelectionStart = 0;
            this.moveToNextOnEnterKey = true;
            this.showToolTip = true;
            this.insertZeroToLeft = false;
        }
        private void NumberTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (this.Text.Trim().Length != 0 && this.showToolTip)
            {
                this.ToolTip.SetToolTip(this, this.Text);
            }
        }
        private void NumberTextBox_MouseLeave(object sender, EventArgs e)
        {
            this.ToolTip.SetToolTip(this, "");
        }
        private void NumberTextBox_TextChanged(object sender, EventArgs e)
        {
        }
        private void NumberTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r' && this.moveToNextOnEnterKey)
            {
                Control nextControl = base.Parent.GetNextControl(this, true);
                CheckBox checkBox = new CheckBox();
                Button button = new Button();
                RadioButton radioButton = new RadioButton();
                ExtendedTextBox extendedTextBox = new ExtendedTextBox();
                NumberTextBox numberTextBox = new NumberTextBox();
                CurrencyTextBox currencyTextBox = new CurrencyTextBox();

                ComboBox comboBox = new ComboBox();
                DataGridView dataGridView = new DataGridView();
                while (nextControl != null)
                {
                    if ((nextControl.GetType() == checkBox.GetType() || nextControl.GetType() == button.GetType() || nextControl.GetType() == radioButton.GetType() || nextControl.GetType() == extendedTextBox.GetType() || nextControl.GetType() == numberTextBox.GetType() || nextControl.GetType() == currencyTextBox.GetType() || nextControl.GetType() == dataGridView.GetType() || nextControl.GetType() == comboBox.GetType()) && nextControl.CanFocus)
                    {
                        break;
                    }
                    nextControl = base.Parent.GetNextControl(nextControl, true);
                }
                if (nextControl != null)
                {
                    nextControl.Focus();
                }
                e.Handled = true;
            }
            else
            {
                if (this.characterSet.IndexOf(e.KeyChar, 0) != -1 || e.KeyChar == '\b' || e.KeyChar == '\u0016' || e.KeyChar == '\u0003' || e.KeyChar == '\u001a')
                {
                    e.Handled = false;
                }
                else
                {
                    e.Handled = true;
                }
            }
        }
        public bool IsValid()
        {
            string text = "^[" + this.characterSet + "]{";
            text += this.MinLength.ToString();
            text += ",";
            text += this.MaxLength.ToString();
            text += "}$";
            return Regex.IsMatch(this.Text, text);
        }
        public long GetNumber()
        {
            long result;
            if (this.IsValid() && this.Text.Length != 0)
            {
                result = long.Parse(this.Text);
            }
            else
            {
                result = 0L;
            }
            return result;
        }
        private void NumberTextBox_Enter(object sender, EventArgs e)
        {
        }
        private void NumberTextBox_Leave(object sender, EventArgs e)
        {
            if (this.Text.Length != 0 && this.insertZeroToLeft && this.Text.Length < this.MaxLength)
            {
                int length = this.Text.Length;
                for (int i = 0; i < this.MaxLength - length; i++)
                {
                    this.Text = this.Text.Insert(0, "0");
                }
            }
        }

    }

}