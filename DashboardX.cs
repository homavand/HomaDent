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
        List<PatientVisitRow> TodayPatientList = new List<PatientVisitRow>();
        List<PatientVisitRow> TomorrowPatientList = new List<PatientVisitRow>();
        List<PatientVisitRow> AfterTomorrowPatientList = new List<PatientVisitRow>();

        List<PatientChequeRow> CurrentWeekChequeList = new List<PatientChequeRow>();
        List<PatientChequeRow> NextWeekChequeList = new List<PatientChequeRow>();

        private BindingSource patientBindingSource = new BindingSource();
        private BindingSource chequeBindingSource = new BindingSource();

        public DashboardX()
        {
          
            InitializeComponent();
            this.dgPatient.AutoGenerateColumns = false;
            this.dgCheque.AutoGenerateColumns = false;
            //this.dgFollowup.AutoGenerateColumns = false;
            dgPatient.DataSource = patientBindingSource;
            dgCheque.DataSource = chequeBindingSource;

        }

        private void DashboardX_Load(object sender, EventArgs e)
        {
            var todayDate = new PersianDateTime(DateTime.Now).Date;
            var TomorrowDate = todayDate.AddDays(1);
            var AfterTomorrowDate = todayDate.AddDays(2);

            this.TodayPatientLbl.Text = "امروز";
            this.TomorrowPatientLbl.Text = TomorrowDate.DayName;
            this.AfterTomorrowPatientLbl.Text = AfterTomorrowDate.DayName;

            try
            {

                LoadUserInfo();
                GetPatients_Today();
                GetPatients_Tomorrow();
                GetPatients_AfterTomorrow();
                GetCheque_CurrentWeek();
                GetCheque_NextWeek();
                GetFollowup_CurrentWeek();
            }
            catch(Exception exp)
            {
                this.Close();
            }
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
            //dgPatient.DataSource = Enumerable.Empty<dynamic>();
            switch (link.Tag.ToString())
            {
                case "Today":
                    title = this.TodayPatientLbl.Text;
                    patientBindingSource.DataSource = TodayPatientList;                    
                    break;
                case "Tomorrow":
                    title = this.TomorrowPatientLbl.Text;
                    patientBindingSource.DataSource = TomorrowPatientList;
                    break;
                case "AfterTomorrow":
                    title = this.AfterTomorrowPatientLbl.Text;
                    patientBindingSource.DataSource = AfterTomorrowPatientList;
                    break;
            }
            patientBindingSource.ResetBindings(false);
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

        private void LinkCheque_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            var link = ((LinkLabel)sender);
            var title = "---";
            switch (link.Tag.ToString())
            {
                case "CurrentWeek":
                    title = this.CurrentWeekChequeLbl.Text;
                    chequeBindingSource.DataSource = CurrentWeekChequeList;
                    break;
                case "NextWeek":
                    title = this.NextWeekChequeLbl.Text;
                    chequeBindingSource.DataSource = NextWeekChequeList;
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
            DateTime toDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, 23, 59, 59);

           var list = GetPatientList(fromDate, toDate);
            TodayPatientList = list;           
            int count = Enumerable.Count(list);
            this.TodayPatientTxt.Text = count.ToString();

        }
    

        private void GetPatients_Tomorrow()
        {
            int days = 0;
            DateTime today = DateTime.Now;
            DateTime tomorrow = today.AddDays(1);
           
            DateTime fromDate = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day , 0, 0, 0);
            DateTime toDate = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 23, 59, 59);

            var list = GetPatientList(fromDate, toDate);
            TomorrowPatientList = list;
            int count = Enumerable.Count(list);
            this.TomorrowPatientTxt.Text = count.ToString();

        }
     
        private void GetPatients_AfterTomorrow()
        {
            int days = 0;
            DateTime today = DateTime.Now;
            DateTime afterTomorrow = today.AddDays(2);

            DateTime fromDate = new DateTime(afterTomorrow.Year, afterTomorrow.Month, afterTomorrow.Day, 0, 0, 0);
            DateTime toDate = new DateTime(afterTomorrow.Year, afterTomorrow.Month, afterTomorrow.Day, 23, 59, 59);

         
            var list = GetPatientList(fromDate, toDate);
            AfterTomorrowPatientList = list;
            int count = Enumerable.Count(list);
            this.AfterTomorrowPatientTxt.Text = count.ToString();

        }
        private List<PatientVisitRow> GetPatientList(DateTime fromDate, DateTime toDate)
        {                   
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.FromDate = fromDate;
            sObj.ToDate = toDate;
            sObj.IsDeleted = false;
            var result = Dentistry.DataProvider.GetVisitX(sObj);

            //IEnumerable<dynamic> list = null;


            var data = (result != null && result.Data != null && result.Data != null && (Enumerable.Count(result.Data) > 0)) ? result.Data : null;
            //var list = data != null ? (data as IEnumerable<dynamic>)
            //                        .Select(i =>
            //                        new
            //                        {
            //                            i.PatientId,
            //                            i.PatientName,
            //                            i.DoctorId,
            //                            i.DoctorTitle,
            //                            i.ServiceGroupId,
            //                            i.ServiceGroupTitle,
            //                            i.SolarDate,
            //                            i.StartTime,
            //                            i.EndTime,
            //                            i.MobilePhone
            //                        }).ToList() : Enumerable.Empty<dynamic>();


            List<PatientVisitRow> list = data != null
            ? (data as IEnumerable<dynamic>).Select(i => new PatientVisitRow
            {
                PatientId = Publics.GetPropertyValue<int>(i, "PatientId"),
                PatientName = Publics.GetPropertyValue<string>(i, "PatientName"),
                DoctorId = Publics.GetPropertyValue<int?>(i, "DoctorId"),
                DoctorTitle = Publics.GetPropertyValue<string>(i, "DoctorTitle"),
                ServiceGroupId = Publics.GetPropertyValue<int?>(i, "ServiceGroupId"),
                ServiceGroupTitle = Publics.GetPropertyValue<string>(i, "ServiceGroupTitle"),
                SolarDate = Publics.GetPropertyValue<string>(i, "SolarDate"),
                StartTime = Publics.GetPropertyValue<string>(i, "StartTime"),
                EndTime = Publics.GetPropertyValue<string>(i, "EndTime"),
                MobilePhone = Publics.GetPropertyValue<string>(i, "MobilePhone"),
            }).ToList()
            : new List<PatientVisitRow>();


            return list;
        
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
           
            List<PatientChequeRow> list = GetChequeList(fromDate, toDate);
            CurrentWeekChequeList = list;
            int count = Enumerable.Count(list);
            this.CurrentWeekChequeTxt.Text = count.ToString();              
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

            List<PatientChequeRow> list = GetChequeList(fromDate, toDate);
            NextWeekChequeList = list;
            int count = Enumerable.Count(list);
            this.NextWeekChequeTxt.Text = count.ToString();
        }

        private List<PatientChequeRow> GetChequeList(DateTime fromDate, DateTime toDate)
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.PayTypeId = 3; //  چک
            sObj.IsDateOfMaturity = true;
            sObj.FromDate = fromDate;
            sObj.ToDate = toDate;

            var result = Dentistry.DataProvider.GetPatientFinancialsX(sObj);
            var data = (result != null && result.Data != null && result.Data != null && (Enumerable.Count(result.Data) > 0)) ? result.Data : null;

            //IEnumerable<dynamic> list = data != null ? (data as IEnumerable<dynamic>)
            //                                                                .Select(i =>
            //                                                                new
            //                                                                {
            //                                                                    i.PatientName,
            //                                                                    i.ChequeTypeTitle,
            //                                                                    i.SolarDateOfMaturity,
            //                                                                    i.ChequeNumber,
            //                                                                    i.Amount,
            //                                                                    i.Comment,
            //                                                                }).ToList() : Enumerable.Empty<dynamic>();

            List<PatientChequeRow> list = data != null
            ? (data as IEnumerable<dynamic>).Select(i => new PatientChequeRow
            {
                PatientId = Publics.GetPropertyValue<int>(i, "PatientId"),
                PatientName = Publics.GetPropertyValue<string>(i, "PatientName"),
                ChequeTypeTitle = Publics.GetPropertyValue<string>(i, "ChequeTypeTitle"),
                SolarDateOfMaturity = Publics.GetPropertyValue<string>(i, "SolarDateOfMaturity"),             
                ChequeNumber = Publics.GetPropertyValue<string>(i, "ChequeNumber"),
                Amount = Publics.GetPropertyValue<double>(i, "Amount"),
                Comment = Publics.GetPropertyValue<string>(i, "Comment"),              
            }).ToList()
            : new List<PatientChequeRow>();

            return list;
        }
       
        private void GetFollowup_CurrentWeek()
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

            IEnumerable<dynamic> list = GetFollowupList(fromDate, toDate);
            
            int count = Enumerable.Count(list);
            this.CurrentWeekFollowupTxt.Text = count.ToString();

            this.dgFollowup.Items.Clear();

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

        private IEnumerable<dynamic> GetFollowupList(DateTime fromDate, DateTime toDate)
        {
            
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.FromDate = fromDate;
            sObj.toDate = toDate;
            sObj.IsDeleted = null;

            var result = DataProvider.GetPatientFollowUpsX(sObj);
            var data = (result != null && result.Data != null && result.Data != null && (Enumerable.Count(result.Data) > 0)) ? result.Data : null;
            IEnumerable<dynamic> list = data != null 
                                        ? (data as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList()
                                        : Enumerable.Empty<dynamic>();

            return list;
                
        
        }

        public void FillListView(IEnumerable<dynamic> rows, DateTime date)
        {

            IEnumerable<dynamic> list = rows;

            try
            {

                string dateString = string.Format("{0}/{1}/{2}", date.Year.ToString(), date.Month.ToString(), date.Day.ToString());
                string dateStr = Class.Date.ToSolar(dateString);

                ListViewGroup grp;
                grp = dgFollowup.Groups.Add(dateStr, dateStr);


                if (list.Count() <= 0)
                {
                    FarsiMessageBox.FMessageBox.Show("در این تاریخ عملباتی وچود ندارد", "No Info", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information);
                    return;
                }

                foreach (dynamic obj in list)
                {

                    ListViewItem item = new ListViewItem(grp);


                    if (obj.PatientName != null)
                        item.SubItems.Add(obj.PatientName);
                    if (obj.SolarDate != null)
                        item.SubItems.Add(obj.SolarDate);
                    if (obj.MobilePhone != null)
                        item.SubItems.Add(obj.MobilePhone);
                    if (obj.Comment != null)
                        item.SubItems.Add(obj.Comment);


                    dgFollowup.Items.Add(item);

                }
            }


            catch (Exception exp)
            {
                MessageBox.Show("can't get data because of the followeing error \n" + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }

    public class PatientVisitRow
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public int? DoctorId { get; set; }
        public string DoctorTitle { get; set; }
        public int? ServiceGroupId { get; set; }
        public string ServiceGroupTitle { get; set; }
        public string SolarDate { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string MobilePhone { get; set; }
    }

    public class PatientChequeRow
    {
        public int PatientId { get; set; }
        public string PatientName { get; set; }
        public string ChequeTypeTitle { get; set; }
        public string SolarDateOfMaturity { get; set; }
        public string ChequeNumber { get; set; }
        public double Amount { get; set; }
        public string Comment { get; set; }
    }
                                                                            
}
