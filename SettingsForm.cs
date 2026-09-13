using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Dentistry
{
    public partial class SettingsForm : Form
    {
   
        #region FormSettings
        public SettingsForm()
        {
            InitializeComponent();

            this.tabControlSettings_Selected(this, null);
        }
        #endregion

        private void tabControlSettings_Selected(object sender, TabControlEventArgs e)
        {

            if (tabControlSettings.SelectedTab.Name.ToString() == "tabPage0")
            {
                this.panelX0.Controls.Clear();
                UserList form = new UserList();
                form.TopLevel = false;
                this.panelX0.Controls.Add(form);
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }           
            if (tabControlSettings.SelectedTab.Name.ToString() == "tabPage2")
            {
                this.panelReport.Controls.Clear();
                OfficeSetting form = new OfficeSetting();
                form.TopLevel = false;
                this.panelReport.Controls.Add(form);
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
            if (tabControlSettings.SelectedTab.Name.ToString() == "tabPage3")
            {
                this.panelStaffs.Controls.Clear();
                StaffsList form = new StaffsList();
                form.TopLevel = false;
                this.panelStaffs.Controls.Add(form);
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }

            if (tabControlSettings.SelectedTab.Name.ToString() == "tabPage7")
            {
                this.panel_Service.Controls.Clear();
                ServiceList form = new ServiceList();                
                form.TopLevel = false;
                this.panel_Service.Controls.Add(form);
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();

                //this.panel_Service.Controls.Add(form.panelForm);                
                //form.panelForm.Dock = DockStyle.Fill;
            }

            if (tabControlSettings.SelectedTab.Name.ToString() == "tabPage1")
            {
                this.panel_Insurer.Controls.Clear();
                InsurerList form = new InsurerList();
                form.TopLevel = false;
                this.panel_Insurer.Controls.Add(form);
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }

            
            if (tabControlSettings.SelectedTab.Name.ToString() == "tabPage8")
            {
                this.panelDivideTime.Controls.Clear();
                WorkTimes form = new WorkTimes();
                form.TopLevel = false;
                this.panelDivideTime.Controls.Add(form);
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }

           
            if (tabControlSettings.SelectedTab.Name.ToString() == "tabPage11")
            {
                this.BaseCodingPnl.Controls.Clear();
                BaseCodings form = new BaseCodings();
                form.TopLevel = false;
                this.BaseCodingPnl.Controls.Add(form);
                form.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                form.Dock = DockStyle.Fill;
                form.Show();
            }
        }
    
    }
}
