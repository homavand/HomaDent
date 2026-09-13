using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PopupControl;

namespace Dentistry
{
    public partial class DashboardX : Form
    {
        public DashboardX()
        {
            InitializeComponent();
        }

        private void DashboardX_Load(object sender, EventArgs e)
        {
            var todayDate = new PersianDateTime(DateTime.Now).Date;
            var TomorrowDate = todayDate.AddDays(1);
            var AfterTomorrowDate = todayDate.AddDays(2);

            this.TodayPatientLbl.Text = "امروز";
            this.TomorrowPatientLbl.Text = TomorrowDate.DayName;
            this.AfterTomorrowPatientLbl.Text = AfterTomorrowDate.DayName;
        }

        private void LinkPatient_Click(object sender, EventArgs e)
        {
            var link = ((LinkLabel)sender);
            var title = "---";
            switch (link.Tag.ToString())
            {
                case "Today":
                    title = this.TodayPatientLbl.Text;
                    break;
                case "Tomorrow":
                    title = this.TomorrowPatientLbl.Text;
                    break;
                case "AfterTomorrow":
                    title = this.AfterTomorrowPatientLbl.Text;
                    break;
            }
            
            Show_PatientPanel(link, title);
            
        }

        private void Show_PatientPanel(Control ctrl, string title)
        {
            
            int x1 = 0, y1 = 0;
            PopupControl.Popup p;

            PatientPanelTitleLbl.Text = title;
            p = new PopupControl.Popup(PatientPnl);
            x1 = PatientPnl.Width;
            y1 = ctrl.Location.Y;
            p.ShowingAnimation = p.HidingAnimation = PopupAnimations.None;

            var x2 = MousePosition.X;
            var y2 = MousePosition.Y;
            p.Hide();
            //p.Show(MousePosition.X, MousePosition.Y);
            p.Show(x2 - x1 , y2 + 10);
            p = null;
        }

        private void LinkCheque_Click(object sender, EventArgs e)
        {
            

        }

        private void LinkCheque_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var link = ((LinkLabel)sender);
            var title = "---";
            switch (link.Tag.ToString())
            {
                case "CurrentWeek":
                    title = this.CurrentWeekChequeLbl.Text;
                    break;
                case "NextWeek":
                    title = this.NextWeekChequeLbl.Text;
                    break;
              
            }

            Show_ChequePanel(link, title);
        }

        private void Show_ChequePanel(Control ctrl, string title)
        {

            int x1 = 0, y1 = 0;
            PopupControl.Popup p;

            ChequePanelTitleLbl.Text = title;
            p = new PopupControl.Popup(ChequePnl);
            x1 = PatientPnl.Width;
            y1 = ctrl.Location.Y;
            p.ShowingAnimation = p.HidingAnimation = PopupAnimations.None;

            var x2 = MousePosition.X;
            var y2 = MousePosition.Y;
            p.Hide();
            //p.Show(MousePosition.X, MousePosition.Y);
            p.Show(x2 - x1, y2 + 10);
            p = null;
        }

        private void LinkFollowup_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var link = ((LinkLabel)sender);
            var title = "---";
            switch (link.Tag.ToString())
            {
                case "CurrentWeek":
                    title = this.CurrentWeekFollowupLbl.Text;
                    break;
             

            }

            Show_FollowupPanel(link, title);
        }

        private void Show_FollowupPanel(Control ctrl, string title)
        {

            int x1 = 0, y1 = 0;
            PopupControl.Popup p;

            FollowupPanelTitleLbl.Text = title;
            p = new PopupControl.Popup(FollowupPnl);
            x1 = PatientPnl.Width;
            y1 = ctrl.Location.Y;
            p.ShowingAnimation = p.HidingAnimation = PopupAnimations.None;

            var x2 = MousePosition.X;
            var y2 = MousePosition.Y;
            p.Hide();
            //p.Show(MousePosition.X, MousePosition.Y);
            p.Show(x2 - x1, y2 + 10);
            p = null;
        }
    }
}
