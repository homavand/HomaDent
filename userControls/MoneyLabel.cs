
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
namespace Dentistry.UserControls
{
    public class MoneyLabel : Label
    {
        private string strCrncyGrpSep;
        private string strCrncySymbol;
        private IContainer components = null;
        public override string Text
        {
            get
            {
                return base.Text;
            }
            set
            {
             
                if (value != null)
                {
                    if (value.IndexOf(this.strCrncySymbol) > 0)
                    {
                        value = value.Replace(this.strCrncySymbol, string.Empty);
                    }
                    if (value.IndexOf(this.strCrncyGrpSep) > 0)
                    {
                        value = value.Replace(this.strCrncyGrpSep, string.Empty);
                    }
                }
                decimal num;
                decimal.TryParse(value, out num);
                value = num != 0 ? num.ToString("#,#") : "0";
                if (value != string.Empty)
                {
                    value = value.Insert(value.Length, this.strCrncySymbol);
                }
                base.Text = value;
            }
        }
        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
            }
        }
        public string CurrencySymbol
        {
            get
            {
                return this.strCrncySymbol;
            }
            set
            {
                this.strCrncySymbol = value;
            }
        }
        public string CurrencyGroupSeparator
        {
            get
            {
                return this.strCrncyGrpSep;
            }
            set
            {
                this.strCrncyGrpSep = value.Trim();
            }
        }
        public string Value
        {
            get
            {
                return base.Text.Replace(this.strCrncyGrpSep, string.Empty).Replace(this.strCrncySymbol, string.Empty);
            }
        }
        public MoneyLabel()
        {
            this.InitializeComponent();
            this.strCrncySymbol = "  ریال ";
            this.strCrncyGrpSep = ",";
            base.RightToLeft = RightToLeft.Yes;
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
            base.SuspendLayout();
            this.BackColor = Color.Transparent;
            base.ResumeLayout(false);
        }
    }
}
