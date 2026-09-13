namespace Dentistry.UserControls
{
    partial class ToothLabel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ToothInfoBorder = new Dentistry.UserControls.ExPanel();
            this.ToothLbl = new System.Windows.Forms.Label();
            this.ToothInfoBorder.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToothInfoBorder
            // 
            this.ToothInfoBorder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ToothInfoBorder.BackColor = System.Drawing.Color.Transparent;
            this.ToothInfoBorder.BorderBottomWidth = 3;
            this.ToothInfoBorder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(91)))), ((int)(((byte)(126)))));
            this.ToothInfoBorder.BorderLeftWidth = 3;
            this.ToothInfoBorder.BorderRightWidth = 3;
            this.ToothInfoBorder.BorderTopWidth = 3;
            this.ToothInfoBorder.Controls.Add(this.ToothLbl);
            this.ToothInfoBorder.Location = new System.Drawing.Point(5, 5);
            this.ToothInfoBorder.Name = "ToothInfoBorder";
            this.ToothInfoBorder.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ToothInfoBorder.Size = new System.Drawing.Size(30, 25);
            this.ToothInfoBorder.TabIndex = 58;
            this.ToothInfoBorder.Load += new System.EventHandler(this.ToothInfoBorder_Load);
            // 
            // ToothLbl
            // 
            this.ToothLbl.BackColor = System.Drawing.Color.Transparent;
            this.ToothLbl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ToothLbl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ToothLbl.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ToothLbl.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(91)))), ((int)(((byte)(126)))));
            this.ToothLbl.Location = new System.Drawing.Point(0, 0);
            this.ToothLbl.Name = "ToothLbl";
            this.ToothLbl.Size = new System.Drawing.Size(30, 25);
            this.ToothLbl.TabIndex = 12;
            this.ToothLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ToothLbl.Click += new System.EventHandler(this.ToothInfo_Click);
            // 
            // ToothLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ToothInfoBorder);
            this.Name = "ToothLabel";
            this.Size = new System.Drawing.Size(40, 35);
            this.ToothInfoBorder.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private UserControls.ExPanel ToothInfoBorder;
        private System.Windows.Forms.Label ToothLbl;
    }
}
