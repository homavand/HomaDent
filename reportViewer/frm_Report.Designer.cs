namespace Dentistry
{
    partial class frm_Report
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
            this.stiViewerControl1 = new Stimulsoft.Report.Viewer.StiViewerControl();
            this.panel_Report = new System.Windows.Forms.Panel();
            this.panel_Report.SuspendLayout();
            this.SuspendLayout();
            // 
            // stiViewerControl1
            // 
            this.stiViewerControl1.AllowDrop = true;
            this.stiViewerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.stiViewerControl1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.stiViewerControl1.Location = new System.Drawing.Point(0, 0);
            this.stiViewerControl1.Name = "stiViewerControl1";
            this.stiViewerControl1.Report = null;
            this.stiViewerControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.stiViewerControl1.ShowBookmarksPanel = false;
            this.stiViewerControl1.ShowCloseButton = false;
            this.stiViewerControl1.ShowDotMatrixModeButton = false;
            this.stiViewerControl1.ShowOpen = false;
            this.stiViewerControl1.ShowPageDelete = false;
            this.stiViewerControl1.ShowPageNew = false;
            this.stiViewerControl1.ShowSendEMail = false;
            this.stiViewerControl1.ShowThumbsPanel = false;
            this.stiViewerControl1.ShowZoom = true;
            this.stiViewerControl1.Size = new System.Drawing.Size(833, 483);
            this.stiViewerControl1.TabIndex = 0;
            this.stiViewerControl1.ThumbsPanelEnabled = false;
            // 
            // panel_Report
            // 
            this.panel_Report.Controls.Add(this.stiViewerControl1);
            this.panel_Report.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel_Report.Location = new System.Drawing.Point(0, 0);
            this.panel_Report.Name = "panel_Report";
            this.panel_Report.Size = new System.Drawing.Size(833, 483);
            this.panel_Report.TabIndex = 1;
            // 
            // frm_Report
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(833, 483);
            this.Controls.Add(this.panel_Report);
            this.Name = "frm_Report";
            this.Text = "frm_Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panel_Report.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Stimulsoft.Report.Viewer.StiViewerControl stiViewerControl1;
        public System.Windows.Forms.Panel panel_Report;
    }
}