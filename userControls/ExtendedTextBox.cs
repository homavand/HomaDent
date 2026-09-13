using Dentistry.UserControls;
using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Dentistry.UserControls
{
    public class ExtendedTextBox : TextBox
    {
        public enum ExtendedTextBoxLanguages
        {
            English,
            Farsi,
            Bilingual
        }
        private IContainer components = null;
        private ToolTip ToolTip;
        private string language;
        private int minLength;
        private ExtendedTextBox.ExtendedTextBoxLanguages extendedTextBoxLanguage;
        private bool allowExtendedCharacters;
        private bool moveToNextOnEnterKey;
        private bool showToolTip;
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
        public bool AllowExtendedCharacters
        {
            get
            {
                return this.allowExtendedCharacters;
            }
            set
            {
                this.allowExtendedCharacters = value;
            }
        }
        public ExtendedTextBox.ExtendedTextBoxLanguages ExtendedTextBoxLanguage
        {
            get
            {
                return this.extendedTextBoxLanguage;
            }
            set
            {
                if (value == ExtendedTextBox.ExtendedTextBoxLanguages.English)
                {
                    this.extendedTextBoxLanguage = ExtendedTextBox.ExtendedTextBoxLanguages.English;
                }
                if (value == ExtendedTextBox.ExtendedTextBoxLanguages.Farsi)
                {
                    this.extendedTextBoxLanguage = ExtendedTextBox.ExtendedTextBoxLanguages.Farsi;
                }
                if (value == ExtendedTextBox.ExtendedTextBoxLanguages.Bilingual)
                {
                    this.extendedTextBoxLanguage = ExtendedTextBox.ExtendedTextBoxLanguages.Bilingual;
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
                if (value >= 0)
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
                if (value > 0)
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
        public ExtendedTextBox()
        {
            this.ToolTip = new ToolTip();
            base.KeyPress += new KeyPressEventHandler(this.ExtendedTextBox_KeyPress);
            base.TextChanged += new EventHandler(this.ExtendedTextBox_TextChanged);
            base.Enter += new EventHandler(this.ExtendedTextBox_Enter);
            base.Leave += new EventHandler(this.ExtendedTextBox_Leave);
            base.MouseEnter += new EventHandler(this.ExtendedTextBox_MouseEnter);
            base.MouseLeave += new EventHandler(this.ExtendedTextBox_MouseLeave);
            this.minLength = 0;
            this.MaxLength = 20;
            this.extendedTextBoxLanguage = ExtendedTextBox.ExtendedTextBoxLanguages.English;
            this.allowExtendedCharacters = true;
            this.moveToNextOnEnterKey = true;
            this.showToolTip = true;
        }
        private void ExtendedTextBox_MouseEnter(object sender, EventArgs e)
        {
            if (this.Text.Trim().Length != 0 && this.showToolTip)
            {
                this.ToolTip.SetToolTip(this, this.Text);
            }
        }
        private void ExtendedTextBox_MouseLeave(object sender, EventArgs e)
        {
            this.ToolTip.SetToolTip(this, "");
        }
        private void ExtendedTextBox_TextChanged(object sender, EventArgs e)
        {
            this.Text = Publics.FixCharacters(this.Text);
        }
        private void ExtendedTextBox_KeyPress(object sender, KeyPressEventArgs e)
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
                    if ((nextControl.GetType() == checkBox.GetType() || nextControl.GetType() == button.GetType() || nextControl.GetType() == radioButton.GetType() || nextControl.GetType() == extendedTextBox.GetType() || nextControl.GetType() == numberTextBox.GetType() || nextControl.GetType() == currencyTextBox.GetType() ||  nextControl.GetType() == dataGridView.GetType() || nextControl.GetType() == comboBox.GetType()) && nextControl.CanFocus)
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
                if (e.KeyChar == '\r')
                {
                    e.Handled = false;
                }
                else
                {
                    e.KeyChar = Publics.FixTwoSomeCharacter(e.KeyChar);
                    if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.Farsi && !this.allowExtendedCharacters)
                    {
                        if (Publics.AllowedFarsiCharacters.IndexOf(e.KeyChar, 0) != -1 || e.KeyChar == '\b' || e.KeyChar == '\u0016' || e.KeyChar == '\u0003' || e.KeyChar == '\u001a')
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.Farsi && this.allowExtendedCharacters)
                    {
                        if (Publics.AllowedExtendedFarsiCharacters.IndexOf(e.KeyChar, 0) != -1 || e.KeyChar == '\b' || e.KeyChar == '\u0016' || e.KeyChar == '\u0003' || e.KeyChar == '\u001a')
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.English && !this.allowExtendedCharacters)
                    {
                        if (Publics.AllowedEnglishCharacters.IndexOf(e.KeyChar, 0) != -1 || e.KeyChar == '\b' || e.KeyChar == '\u0016' || e.KeyChar == '\u0003' || e.KeyChar == '\u001a')
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.English && this.allowExtendedCharacters)
                    {
                        if (Publics.AllowedExtendedEnglishCharacters.IndexOf(e.KeyChar, 0) != -1 || e.KeyChar == '\b' || e.KeyChar == '\u0016' || e.KeyChar == '\u0003' || e.KeyChar == '\u001a')
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.Bilingual && !this.allowExtendedCharacters)
                    {
                        if ((Publics.AllowedFarsiCharacters + Publics.AllowedEnglishCharacters).IndexOf(e.KeyChar, 0) != -1 || e.KeyChar == '\b' || e.KeyChar == '\u0016' || e.KeyChar == '\u0003' || e.KeyChar == '\u001a')
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                    if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.Bilingual && this.allowExtendedCharacters)
                    {
                        if ((Publics.AllowedExtendedFarsiCharacters + Publics.AllowedExtendedEnglishCharacters).IndexOf(e.KeyChar, 0) != -1 || e.KeyChar == '\b' || e.KeyChar == '\u0016' || e.KeyChar == '\u0003' || e.KeyChar == '\u001a')
                        {
                            e.Handled = false;
                        }
                        else
                        {
                            e.Handled = true;
                        }
                    }
                }
            }
        }
        public bool IsValid()
        {
            string text = "";
            if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.Farsi && !this.allowExtendedCharacters)
            {
                text = "^[" + Publics.AllowedFarsiCharacters + "]{";
                text += this.MinLength.ToString();
                text += ",";
                text += this.MaxLength.ToString();
                text += "}$";
            }
            if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.Farsi && this.allowExtendedCharacters)
            {
                text = "^[" + Publics.AllowedExtendedFarsiCharacters + "]{";
                text += this.MinLength.ToString();
                text += ",";
                text += this.MaxLength.ToString();
                text += "}$";
            }
            if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.English && !this.allowExtendedCharacters)
            {
                text = "^[" + Publics.AllowedEnglishCharacters + "]{";
                text += this.MinLength.ToString();
                text += ",";
                text += this.MaxLength.ToString();
                text += "}$";
            }
            if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.English && this.allowExtendedCharacters)
            {
                text = "^[" + Publics.AllowedExtendedEnglishCharacters + "]{";
                text += this.MinLength.ToString();
                text += ",";
                text += this.MaxLength.ToString();
                text += "}$";
            }
            if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.Bilingual && this.allowExtendedCharacters)
            {
                text = string.Concat(new string[]
                {
                    "^[",                    
                    Publics.AllowedExtendedEnglishCharacters,
                    Publics.AllowedExtendedFarsiCharacters,
                    "]{"
                });
                text += this.MinLength.ToString();
                text += ",";
                text += this.MaxLength.ToString();
                text += "}$";
            }
            if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.Bilingual && !this.allowExtendedCharacters)
            {
                text = "^[" + Publics.AllowedEnglishCharacters + Publics.AllowedFarsiCharacters + "]{";
                text += this.MinLength.ToString();
                text += ",";
                text += this.MaxLength.ToString();
                text += "}$";
            }

            var flag = Regex.IsMatch(this.Text, text); 
            return flag;
        }
        private void ExtendedTextBox_Enter(object sender, EventArgs e)
        {
            this.language = Application.CurrentInputLanguage.LayoutName;
            if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.Farsi)
            {
                for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
                {
                    if (InputLanguage.InstalledInputLanguages[i].LayoutName == "Farsi")
                    {
                        Application.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                    }
                }
            }
            if (this.extendedTextBoxLanguage == ExtendedTextBox.ExtendedTextBoxLanguages.English)
            {
                for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
                {
                    if (InputLanguage.InstalledInputLanguages[i].LayoutName == "US")
                    {
                        Application.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                    }
                }
            }
        }
        private void ExtendedTextBox_Leave(object sender, EventArgs e)
        {
            for (int i = 0; i < InputLanguage.InstalledInputLanguages.Count; i++)
            {
                if (InputLanguage.InstalledInputLanguages[i].LayoutName == this.language)
                {
                    Application.CurrentInputLanguage = InputLanguage.InstalledInputLanguages[i];
                }
            }
        }
    }
}
