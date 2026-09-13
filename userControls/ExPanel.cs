using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Windows.Forms;

namespace Dentistry.UserControls
{
    [Designer("System.Windows.Forms.Design.ParentControlDesigner, System.Design", typeof(IDesigner)), ToolboxBitmap(typeof(Panel))]
    public class ExPanel : UserControl
    {
        private Color borderColor;
        private int borderLeftWidth;
        private int borderRightWidth;
        private int borderBottomWidth;
        private int borderTopWidth;
        private IContainer components = null;
        private Panel panelBottom;
        private Panel panelTop;
        private Panel panelRight;
        private Panel panelLeft;
        [DefaultValue(typeof(Color), "White")]
        public Color BorderColor
        {
            get
            {
                return this.borderColor;
            }
            set
            {
                this.borderColor = value;
                this.panelBottom.BackColor = this.borderColor;
                this.panelLeft.BackColor = this.borderColor;
                this.panelRight.BackColor = this.borderColor;
                this.panelTop.BackColor = this.borderColor;
            }
        }
        [DefaultValue(1)]
        public int BorderLeftWidth
        {
            get
            {
                return this.borderLeftWidth;
            }
            set
            {
                if (value >= 0 || value <= 10)
                {
                    this.borderLeftWidth = value;
                    this.panelLeft.Size = new Size(this.borderLeftWidth, this.panelLeft.Size.Height);
                }
            }
        }
        [DefaultValue(1)]
        public int BorderRightWidth
        {
            get
            {
                return this.borderRightWidth;
            }
            set
            {
                if (value >= 0 || value <= 10)
                {
                    this.borderRightWidth = value;
                    this.panelRight.Size = new Size(this.borderRightWidth, this.panelRight.Size.Height);
                }
            }
        }
        [DefaultValue(1)]
        public int BorderBottomWidth
        {
            get
            {
                return this.borderBottomWidth;
            }
            set
            {
                if (value >= 0 || value <= 10)
                {
                    this.borderBottomWidth = value;
                    this.panelBottom.Size = new Size(this.panelBottom.Size.Width, this.borderBottomWidth);
                }
            }
        }
        [DefaultValue(1)]
        public int BorderTopWidth
        {
            get
            {
                return this.borderTopWidth;
            }
            set
            {
                if (value >= 0 || value <= 10)
                {
                    this.borderTopWidth = value;
                    this.panelTop.Size = new Size(this.panelTop.Size.Width, this.borderTopWidth);
                }
            }
        }
        public ExPanel()
        {
            this.InitializeComponent();
            this.BackColor = Color.Transparent;
            this.borderColor = Color.WhiteSmoke;
            this.borderLeftWidth = 1;
            this.borderRightWidth = 1;
            this.borderTopWidth = 1;
            this.borderBottomWidth = 1;
            base.Size = new Size(100, 20);
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
            this.panelBottom = new Panel();
            this.panelTop = new Panel();
            this.panelRight = new Panel();
            this.panelLeft = new Panel();
            base.SuspendLayout();
            this.panelBottom.BackColor = Color.WhiteSmoke;
            this.panelBottom.Dock = DockStyle.Bottom;
            this.panelBottom.Location = new Point(0, 149);
            this.panelBottom.Name = "panelBottom";
            this.panelBottom.Size = new Size(368, 1);
            this.panelBottom.TabIndex = 0;
            this.panelTop.BackColor = Color.WhiteSmoke;
            this.panelTop.Dock = DockStyle.Top;
            this.panelTop.Location = new Point(0, 0);
            this.panelTop.Name = "panelTop";
            this.panelTop.Size = new Size(368, 1);
            this.panelTop.TabIndex = 1;
            this.panelRight.BackColor = Color.WhiteSmoke;
            this.panelRight.Dock = DockStyle.Right;
            this.panelRight.Location = new Point(367, 1);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new Size(1, 148);
            this.panelRight.TabIndex = 2;
            this.panelLeft.BackColor = Color.WhiteSmoke;
            this.panelLeft.Dock = DockStyle.Left;
            this.panelLeft.Location = new Point(0, 1);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new Size(1, 148);
            this.panelLeft.TabIndex = 3;
            base.AutoScaleDimensions = new SizeF(96F, 96F);
            base.AutoScaleMode = AutoScaleMode.Dpi;
            base.Controls.Add(this.panelLeft);
            base.Controls.Add(this.panelRight);
            base.Controls.Add(this.panelTop);
            base.Controls.Add(this.panelBottom);
            base.Name = "Panel";
            base.Size = new Size(368, 150);
            base.ResumeLayout(false);
        }
    }
}
