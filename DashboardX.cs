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

            GetCheque_CurrentWeek();
            GetCheque_NextWeek();
        }

        #region LoadInformation
        private void LoadUserInfo()
        {
            try
            {

                dynamic sObj = new
                {
                    UserId = AppConfigs.CurrentUserId
                };

                JsonResponse<dynamic> result = Dentistry.DataProvider.GetUserX(sObj);

                if (result == null || result.Success == false || result.Data == null)
                    return;

                var dd = result.Data;

                var user = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true)
                                                                                  .Select(i => i).FirstOrDefault() : null;

                if (user == null)
                    throw new Exception("خطا در واکشی اطلاعات");

                this.UserNameTxt.Text = Publics.GetPropertyValue<string>(user, "UserName");

            }
            catch (Exception exp)
            {
            }

        }
        #endregion

        private void btnUserProfile_Click(object sender, EventArgs e)
        {
            UserProfile formUserProfile = new UserProfile();
            formUserProfile.ShowDialog();
            formUserProfile.Dispose();
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

        private void GetPatients_Today()
        {
            int days = 0;
            DateTime dt = DateTime.Now;
            while (dt.DayOfWeek != DayOfWeek.Friday)
            {
                days++;
                dt = dt.AddDays(1);
            }
            DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime toDate = fromDate.AddDays(days);

            int count = GetChequeCount(fromDate, toDate);
            this.CurrentWeekChequeTxt.Text = count.ToString();

            IEnumerable<dynamic> list = GetChequeList(fromDate, toDate);
            dgTodayCheque.DataSource = list;

        }
        private void GetPatients()
        {
            int day = 0;
            foreach (var pnl in this.dysTypePnl.Controls.OfType<UserControls.ExPanel>().ToList())
            {
                var rdoX = pnl.Controls.OfType<RadioButton>().ToList().Where(i => Convert.ToBoolean(i.Checked) == true).Select(i => i).SingleOrDefault();

                if (rdoX != null)
                {
                    day = Convert.ToInt32(rdoX.Tag);

                    break;
                }

            }

            DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime toDate = fromDate.AddDays(day);

            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.FromDate = fromDate;
            sObj.ToDate = toDate;
            var result = Dentistry.DataProvider.GetVisitX(sObj);

            IEnumerable<dynamic> list = null;

            if (result != null && result.Success == true && result.Data != null)
            {
                var dd = result.Data;
                list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true)
                                                                                  .Select(i =>
                                                                                  new
                                                                                  {
                                                                                      i.Id,
                                                                                      i.PatientId,
                                                                                      i.PatientName,
                                                                                      i.DoctorId,
                                                                                      i.DoctorTitle,
                                                                                      i.ServiceGroupId,
                                                                                      i.ServiceGroupTitle,
                                                                                      i.SolarDate,
                                                                                      i.StartTime,
                                                                                      i.EndTime,
                                                                                      i.Color,
                                                                                      i.MobilePhone
                                                                                  }).ToList() : null;

            }

            this.dgTodayPatients.DataSource = list;
            TodayPatientCount = list != null && Enumerable.Count(list) > 0 ? Enumerable.Count(list) : 0;

            tabPage1.Text = " بیماران  ( " + TodayPatientCount.ToString() + " ) ";
        }

        private void GetCheque_CurrentWeek()
        {
            int days = 0;
            DateTime dt = DateTime.Now;
            while (dt.DayOfWeek != DayOfWeek.Friday)
            {
                days++;
                dt = dt.AddDays(1);
            }
            DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
            DateTime toDate = fromDate.AddDays(days);

            int count = GetChequeCount(fromDate, toDate);
            this.CurrentWeekChequeTxt.Text = count.ToString();

            IEnumerable<dynamic> list = GetChequeList(fromDate, toDate);
            dgTodayCheque.DataSource = list;
         
        }

        private void GetCheque_NextWeek()
        {
            int days = 7;
            DateTime dt = DateTime.Now;
            while (dt.DayOfWeek != DayOfWeek.Friday)
            {                
                dt = dt.AddDays(1);
            }
            DateTime fromDate = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
            DateTime toDate = fromDate.AddDays(days);

            int count = GetChequeCount(fromDate, toDate);
            this.NextWeekChequeTxt.Text = count.ToString();

            IEnumerable<dynamic> list = GetChequeList(fromDate, toDate);
            dgTodayCheque.DataSource = list;
        }

        private int GetChequeCount(DateTime fromDate , DateTime toDate)
        {            
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.PayTypeId = 14461; //  چک
            sObj.IsDateOfMaturity = true;
            sObj.FromDate = fromDate;
            sObj.ToDate = toDate;

            var data = Dentistry.DataProvider.GetPatientFinancialsX(sObj);
            int count = (data != null && data.Data != null && data.Data != null ) ? Enumerable.Count(data.Data) : 0;
            return count;
        }

        private IEnumerable<dynamic> GetChequeList(DateTime fromDate, DateTime toDate)
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.PayTypeId = 14461; //  چک
            sObj.IsDateOfMaturity = true;
            sObj.FromDate = fromDate;
            sObj.ToDate = toDate;

            var data = Dentistry.DataProvider.GetPatientFinancialsX(sObj);
            var dd = (data != null && data.Data != null && data.Data != null && (Enumerable.Count(data.Data) > 0)) ? data.Data : null;

            IEnumerable<dynamic> list = dd != null ? (dd as IEnumerable<dynamic>)
                                                                            .Select(i =>
                                                                            new
                                                                            {
                                                                                i.PatientName,
                                                                                i.ChequeTypeTitle,
                                                                                i.SolarDateOfMaturity,
                                                                                i.ChequeNumber,
                                                                                i.Amount,
                                                                                i.Comment,
                                                                            }).ToList() : null;

            return list;
            
        }

        private void GetFollowUpPatients()
        {
            try
            {
                int day = 7;
                
                DateTime fromDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 0, 0, 0);
                DateTime toDate = fromDate.AddDays(day);

                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.FromDate = fromDate;
                sObj.toDate = toDate;
                sObj.IsDeleted = null;

                var result = DataProvider.GetPatientFollowUpsX(sObj);
                if (result == null || result.Success == false)
                    return;


                var dd = result.Data;
                IEnumerable<dynamic> list = dd != null && dd != null && (Enumerable.Count(dd) > 0)
                                            ? (dd as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList()
                                            : Enumerable.Empty<dynamic>();

                if (list == null)
                    return;

                int FollowupCount = list != null && Enumerable.Count(list) > 0 ? Enumerable.Count(list) : 0;
                CurrentWeekFollowupTxt.Text =  FollowupCount.ToString() ;

                this.lvPatientFollowUp.Items.Clear();


                List<DateTime> listDate = new List<DateTime>();
                foreach (dynamic obj in list)
                {
                    if (obj == null)
                        break;
                    if (obj.FollowUpDate == null)
                        continue;
                    DateTime followUpDate = Publics.GetPropertyValue<DateTime>(obj, "FollowUpDate");
                    DateTime date = DateTime.Parse((followUpDate).ToShortDateString());
                    if (!listDate.Contains(date))
                        listDate.Add(date);

                }

                foreach (DateTime date in listDate)
                {
                    var rows = list.Where(i => ((DateTime)i.FollowUpDate).ToShortDateString() == ((DateTime)date).ToShortDateString()).Select(i => i).ToList();
                    if (rows == null)
                        continue;
                    FillListView(rows, date);
                }


            }
            catch (Exception exp)
            {
                this.Close();
            }
        }
    }
}
