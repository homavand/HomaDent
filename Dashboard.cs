using FarsiMessageBox;
using PopupControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.Routing;
using System.Windows.Forms;
using DNTPersianUtils.Core;

namespace Dentistry
{
    public partial class Dashboard : Form
    {
        List<PatientVisitRow> TodayPatientList = new List<PatientVisitRow>();
        List<PatientVisitRow> TomorrowPatientList = new List<PatientVisitRow>();
        List<PatientVisitRow> AfterTomorrowPatientList = new List<PatientVisitRow>();

        List<PatientChequeRow> CurrentWeekChequeList = new List<PatientChequeRow>();
        List<PatientChequeRow> NextWeekChequeList = new List<PatientChequeRow>();

        private BindingSource patientBindingSource = new BindingSource();
        private BindingSource chequeBindingSource = new BindingSource();

        string CountAnbar = "0";
        int StaffId = -1;
        
        delegate void TaskDelegate();
        public static int TodayPatientCount = 0;
        public static int TodayChequeCount = 0;
        public static int FollowUpPatientCount = 0;

        public Dashboard()
        {
            InitializeComponent();

            this.dgPatient.AutoGenerateColumns = false;
            this.dgCheque.AutoGenerateColumns = false;
            //this.dgFollowup.AutoGenerateColumns = false;
            dgPatient.DataSource = patientBindingSource;
            dgCheque.DataSource = chequeBindingSource;




        }

        private void Dashboard_Load(object sender, EventArgs e)
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
            catch (Exception exp)
            {
                this.Close();
            }

        }

        private void Dashboard_Shown(object sender, EventArgs e)
        {
            var date = new PersianDateTime(DateTime.Now).Date;
            this.fromDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, 1, 1);
            this.toDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, date.Month, date.Day);

            this.FillChartList();
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

        private void LinkPatient_Click(object sender, LinkLabelLinkClickedEventArgs e)
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
            PatientPnl.Size = new Size(696, 250);
            p = new PopupControl.Popup(PatientPnl);
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
            ChequePnl.Size = new Size(696, 250);
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
            FollowupPnl.Size = new Size(696, 250);
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

            DateTime fromDate = new DateTime(tomorrow.Year, tomorrow.Month, tomorrow.Day, 0, 0, 0);
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

            var result = Dentistry.DataProvider.GetPatientTransactionsX(sObj);
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


        #region FillChartList
        private void FillChartList()
        {

            dynamic sObj = new System.Dynamic.ExpandoObject();
          
            if (this.fromDateTxt.Value.ToString() != string.Empty) 
                sObj.FromDate = string.Format("{0} 00:00:01", this.fromDateTxt.Value.ToString()).ToGregorianDateTime();

            if (this.toDateTxt.Value.ToString() != string.Empty)
                sObj.ToDate = string.Format("{0} 23:59:59", this.toDateTxt.Value.ToString()).ToGregorianDateTime();

            //CostChart

            YearLbl.Text = "";
            var data = Dentistry.DataProvider.GetClinicStatisticsX(sObj);
            var dd = data != null && data.Data != null ? data.Data : null;

            if (dd == null)
                return;

            var patientsServiceData   = dd.PatientsFinancial != null ? (dd.PatientsService as IEnumerable<dynamic>) : Enumerable.Empty<dynamic>();
            var patientsFinancialData = dd.PatientsFinancial != null ? (dd.PatientsFinancial as IEnumerable<dynamic>) : Enumerable.Empty<dynamic>();
            var costsFinancialData    = dd.CostsFinancial != null ? (dd.CostsFinancial as IEnumerable<dynamic>) : Enumerable.Empty<dynamic>();
            var insurersFinancialData = dd.InsurersFinancial != null ? (dd.InsurersFinancial as IEnumerable<dynamic>) : Enumerable.Empty<dynamic>();
            //var monthServices = dd.MonthServices != null ? dd.MonthServices : null;
            //var patientsAgeRange = dd.PatientsAgeRange != null ? dd.PatientsAgeRange : null;

            if (patientsServiceData != null)
            {
                System.Windows.Forms.DataVisualization.Charting.Series seriesA = null;
                if (patientsServiceChart.Series.Count > 0 && patientsServiceChart.Series["a"] != null)
                {

                }
                else
                {
                    patientsServiceChart.Series.Add("a");
                }
                
                patientsServiceChart.Series["a"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

                System.Windows.Forms.DataVisualization.Charting.DataPoint[] item = new System.Windows.Forms.DataVisualization.Charting.DataPoint[12];

                if(patientsServiceChart.Series["a"].Points.Count>0)
                for(int i= patientsServiceChart.Series["a"].Points.Count-1; i>=0; i--)
                {                        
                    System.Windows.Forms.DataVisualization.Charting.DataPoint p = patientsServiceChart.Series["a"].Points[i];
                    patientsServiceChart.Series["a"].Points.Remove(p);                       
                }
                    
                for (int i = 0; i < patientsServiceData.Count(); i++)
                {
                    var obj = patientsServiceData.ElementAt(i);
                    item[i] = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                    item[i].LegendText = Convert.ToString(obj.Title) + " : " + obj.Value.ToString();
                    item[i].XValue = 0;
                    item[i].Font = new System.Drawing.Font("Vazir", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    item[i].YValues[0] = Convert.ToInt32(obj.Value);
                    item[i].ToolTip = " تعداد مراجعات  " + Convert.ToString(obj.Title) + " ماه    " + Convert.ToString(obj.Value) + " نفر ";

                    patientsServiceChart.Series["a"].Points.Add(item[i]);
                    
                }
                
                
            }

            if (patientsFinancialData != null)
            {

                System.Windows.Forms.DataVisualization.Charting.Series seriesA = null;
                if (patientsFinancialChart.Series.Count > 0 && patientsFinancialChart.Series["a"] != null)
                {

                }
                else
                {
                    patientsFinancialChart.Series.Add("a");
                }

                string[] titleData = (patientsFinancialData as IEnumerable<dynamic>).Select(i => (string)i.Title).ToArray();


                patientsFinancialChart.Series["a"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

                System.Windows.Forms.DataVisualization.Charting.DataPoint[] item = new System.Windows.Forms.DataVisualization.Charting.DataPoint[12];

                if (patientsFinancialChart.Series["a"].Points.Count > 0)
                    for (int i = patientsFinancialChart.Series["a"].Points.Count - 1; i >= 0; i--)
                    {
                        System.Windows.Forms.DataVisualization.Charting.DataPoint p = patientsFinancialChart.Series["a"].Points[i];
                        patientsFinancialChart.Series["a"].Points.Remove(p);
                    }

                var monthServicesObj = new RouteValueDictionary(patientsFinancialData);


                for (int i = 0; i < patientsFinancialData.Count(); i++)
                {
                    var obj = patientsFinancialData.ElementAt(i);
                    item[i] = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                    item[i].LegendText = Convert.ToString(obj.Title) + " : " + obj.Value.ToString();
                    item[i].XValue = 0;
                    item[i].Font = new System.Drawing.Font("Vazir", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    item[i].YValues[0] = Convert.ToInt32(obj.Value);
                    item[i].ToolTip = " تعداد مراجعات  " + Convert.ToString(obj.Title) + " ماه    " + Convert.ToString(obj.Value) + " نفر ";

                    patientsFinancialChart.Series["a"].Points.Add(item[i]);
                }

            }

            if (costsFinancialData != null)
            {


                System.Windows.Forms.DataVisualization.Charting.Series seriesA = null;
                if (costsFinancialChart.Series.Count > 0 && costsFinancialChart.Series["a"] != null)
                {

                }
                else
                {
                    costsFinancialChart.Series.Add("a");
                }

                costsFinancialChart.Series["a"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

                System.Windows.Forms.DataVisualization.Charting.DataPoint[] item = new System.Windows.Forms.DataVisualization.Charting.DataPoint[12];

                if (costsFinancialChart.Series["a"].Points.Count > 0)
                    for (int i = costsFinancialChart.Series["a"].Points.Count - 1; i >= 0; i--)
                    {
                        System.Windows.Forms.DataVisualization.Charting.DataPoint p = costsFinancialChart.Series["a"].Points[i];
                        costsFinancialChart.Series["a"].Points.Remove(p);
                    }

                var monthServicesObj = new RouteValueDictionary(costsFinancialData);


                for (int i = 0; i < costsFinancialData.Count(); i++)
                {
                    var obj = costsFinancialData.ElementAt(i);
                    item[i] = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                    item[i].LegendText = Convert.ToString(obj.Title) + " : " + obj.Value.ToString();
                    item[i].XValue = 0;
                    item[i].YValues[0] = Convert.ToInt32(obj.Value);
                    item[i].ToolTip = " تعداد هزینه ها  " + Convert.ToString(obj.Title) + " ماه    " + Convert.ToString(obj.Value) + " نفر ";

                    costsFinancialChart.Series["a"].Points.Add(item[i]);
                }

            }

            if (insurersFinancialData != null)
            {

                System.Windows.Forms.DataVisualization.Charting.Series seriesA = null;
                if (insurersFinancialChart.Series.Count > 0 && insurersFinancialChart.Series["a"] != null)
                {

                }
                else
                {
                    insurersFinancialChart.Series.Add("a");
                }

                insurersFinancialChart.Series["a"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

                System.Windows.Forms.DataVisualization.Charting.DataPoint[] item = new System.Windows.Forms.DataVisualization.Charting.DataPoint[12];

                if (insurersFinancialChart.Series["a"].Points.Count > 0)
                    for (int i = insurersFinancialChart.Series["a"].Points.Count - 1; i >= 0; i--)
                    {
                        System.Windows.Forms.DataVisualization.Charting.DataPoint p = insurersFinancialChart.Series["a"].Points[i];
                        insurersFinancialChart.Series["a"].Points.Remove(p);
                    }

                var monthServicesObj = new RouteValueDictionary(insurersFinancialData);


                for (int i = 0; i < insurersFinancialData.Count(); i++)
                {
                    var obj = insurersFinancialData.ElementAt(i);
                    item[i] = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
                    item[i].LegendText = Convert.ToString(obj.Title) + " : " + obj.Value.ToString();
                    item[i].XValue = 0;
                    item[i].YValues[0] = Convert.ToInt32(obj.Value);
                    item[i].ToolTip = " تعداد هزینه ها  " + Convert.ToString(obj.Title) + " ماه    " + Convert.ToString(obj.Value) + " نفر ";

                    insurersFinancialChart.Series["a"].Points.Add(item[i]);
                }

            }






            // xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx
            //if (monthServices != null)
            //{

            //    string[] MonthName = { "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی", "بهمن", "اسفند" };

            //    chart1.Series.Add("a");

            //    chart1.Series["a"].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            //    System.Windows.Forms.DataVisualization.Charting.DataPoint[] item = new System.Windows.Forms.DataVisualization.Charting.DataPoint[12];


            //    var monthServicesObj = new RouteValueDictionary(monthServices);


            //    for (int i = 0; i < monthServicesObj.Count() ; i++)
            //    {
            //        var obj = monthServicesObj.ElementAt(i);
            //        item[i] = new System.Windows.Forms.DataVisualization.Charting.DataPoint();
            //        item[i].LegendText = MonthName[i] + " تعداد :" + obj.Value.ToString();
            //        item[i].XValue = 0;
            //        item[i].YValues[0] = Convert.ToInt32(obj.Value);
            //        item[i].ToolTip = " تعداد مراجعات  " + MonthName[i] + " ماه    " + obj.Value.ToString() + " نفر ";

            //        chart1.Series["a"].Points.Add(item[i]);
            //    }
            //}








        }

        #endregion


        private delegate void SetTextCallback(DataGridViewRow ctl);
        private delegate void SetTextCallback2(string text);
         

        private void BackupBtn_Click(object sender, EventArgs e)
        {
            BackupRestore ff = new BackupRestore();
            ff.ShowDialog(this);
            ff.Dispose();

        }

     

    

        private void dysTypePnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.FillChartList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int PatientId = 1;
            if (PatientId == 0)
                return;

            int x1 = 0, y1 = 0;
            PopupControl.Popup p;
           
            SpecialDiseaseList FormSelectIllness = new SpecialDiseaseList(PatientId);

            p = new PopupControl.Popup(FormSelectIllness.panel_Illness);
            x1 = FormSelectIllness.panel_Illness.Width;
            y1 = FormSelectIllness.panel_Illness.Height;
            p.ShowingAnimation = p.HidingAnimation = PopupAnimations.None;

            
            p.Hide();
            p.Show(MousePosition.X, MousePosition.Y - y1 / 2);
            p = null;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //using (var context = new DentalContext())
                //{
                //    try
                //    {
                     
                //        // 2. ایجاد Staff جدید
                //        var staff = new Staff
                //        {
                //            FirstName = "FirstName",
                //            LastName = "LastName",
                //            NationalCode = "1234567890",
                //            Date = DateTime.Now.ToString(),
                //            FixedPhone = "021-12345678",
                //            MobilePhone = "09123456789",
                //            Address = "تهران، خیابان ...",
                //            Comment = "توضیحات",
                //            IsDeleted = false,
                //            StaffTypeId = 2,
                //            GenderId = 1  // حتماً باید مقداردهی شود
                //        };

                //        // 3. اضافه کردن به Context
                //        context.Staffs.Add(staff);

                //        // 4. ذخیره در دیتابیس
                //        int result = context.SaveChanges();
                //        Console.WriteLine($"✅ {result} رکورد ذخیره شد. Staff Id: {staff.Id}");
                //    }
                //    catch (Exception ex)
                //    {
                //        Console.WriteLine($"❌ خطا: {ex.Message}");
                //        if (ex.InnerException != null)
                //            Console.WriteLine($"Inner Exception: {ex.InnerException.Message}");
                //    }
                //}

                  
               
            }
            catch(Exception exp)
            {

            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                using (var db = new Context.DentalContext())
                {
                    var banks = db.Banks.ToList();
                }
            }
            catch (Exception ex)
            {
                System.IO.File.WriteAllText(@"C:\temp\bank_error.txt",
                    ex.GetType().Name + ": " + ex.Message + "\r\n\r\nSTACK:\r\n" + ex.StackTrace +
                    (ex.InnerException != null ? "\r\n\r\nINNER: " + ex.InnerException.Message + "\r\n" + ex.InnerException.StackTrace : ""));
            }
        }

        
    }
}