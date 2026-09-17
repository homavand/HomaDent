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
        string CountAnbar = "0";
        int StaffId = -1;
        
        delegate void TaskDelegate();
        public static int TodayPatientCount = 0;
        public static int TodayChequeCount = 0;
        public static int FollowUpPatientCount = 0;

        public Dashboard()
        {
            InitializeComponent();


            this.LoadInformation();

            //this.ClockTread();

        }

        private void MDIForm_Load(object sender, EventArgs e)
        {
            for (int i = tabControl1.TabPages.Count - 1; i >= 0; i--)
            {
                TabPage tab = tabControl1.TabPages[i];
                tabControl1.SelectedTab = tab;
            }

        }

        private void Dashboard_Shown(object sender, EventArgs e)
        {
            var date = new PersianDateTime(DateTime.Now).Date;
            this.fromDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, 1, 1);
            this.toDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, date.Month, date.Day);

            this.FillChartList();
            this.dgCosts_ColumnOrder();
        }

        #region LoadInformation
        private void LoadInformation()
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

       
        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {

            TabPage tab = tabControl1.SelectedTab;
            if (tab.Name.ToString() == "tabPage1")
            {
                

               

            }
            if (tab.Name.ToString() == "tabPage2")
            {
                


            }
         
         

            this.GetCheque();
            this.GetPatients();
            this.GetFollowUpPatients();
        }



        #region TodayPatients

        private void dgCosts_ColumnOrder()
        {
            dgTodayPatients.AutoGenerateColumns = false;
            dgTodayPatients.Columns["ColumnPatientName"].DisplayIndex = 0;
            dgTodayPatients.Columns["ColumnDoctorTitle"].DisplayIndex = 1;
            dgTodayPatients.Columns["ColumnSolarDate"].DisplayIndex = 2;
            dgTodayPatients.Columns["ColumnFromTime"].DisplayIndex = 3;
            dgTodayPatients.Columns["ColumnToTime"].DisplayIndex = 4;
            dgTodayPatients.Columns["ColumnServiceGroupTitle"].DisplayIndex = 5;
            dgTodayPatients.Columns["ColumnMobile"].DisplayIndex = 6;
        
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
                var dd = result.Data ;
                list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true)
                                                                                  .Select(i =>
                                                                                  new
                                                                                  {
                                                                                      i.Id ,
                                                                                      i.PatientId ,
                                                                                      i.PatientName ,
                                                                                      i.DoctorId ,
                                                                                      i.DoctorTitle ,                                                                                  
                                                                                      i.ServiceGroupId ,
                                                                                      i.ServiceGroupTitle ,                                                                                                                                                                          
                                                                                      i.SolarDate ,                                                                                  
                                                                                      i.StartTime ,
                                                                                      i.EndTime ,                                                                                      
                                                                                      i.Color ,                                                                                                                                                                         
                                                                                      i.MobilePhone
                                                                                  }).ToList() : null;

            }

            this.dgTodayPatients.DataSource = list;
            TodayPatientCount = list != null && Enumerable.Count(list) > 0 ? Enumerable.Count(list) : 0;

            tabPage1.Text = " بیماران  ( " + TodayPatientCount.ToString() + " ) ";
        }
       
        #endregion

        #region GetTodayCheque
        private void GetCheque()
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
            sObj.IsDateOfMaturity = true;
            sObj.FromDate = fromDate;
            sObj.ToDate = toDate;

            var data = Dentistry.DataProvider.GetPatientTransactionsX(sObj);
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

            dgTodayCheque.DataSource = list;
            TodayChequeCount = list != null && Enumerable.Count(list) > 0 ? Enumerable.Count(list) : 0;
            tabPage2.Text = " سر رسید چک ها  ( " + TodayChequeCount.ToString() + " ) ";
        }
        private void dgTodayCheque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            ChequeFinancialDefine form = new ChequeFinancialDefine(int.Parse(this.dgTodayCheque["ColumnChequeID", this.dgTodayCheque.CurrentRow.Index].Value.ToString()));
            form.ShowDialog(this);
            form.Dispose();
            this.GetCheque();
        }
        #endregion

        #region GetFollowUpPatients
        private void GetFollowUpPatients()
        {
            try
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

                FollowUpPatientCount = list != null && Enumerable.Count(list) > 0 ? Enumerable.Count(list) : 0;
                tabPage4.Text = " فالوآپ بیماران  ( " + FollowUpPatientCount.ToString() + " ) ";

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
            catch (SqlException exp)
            {
                this.Close();
            }
        }

        public void FillListView(IEnumerable<dynamic> rows, DateTime date)
        {

            IEnumerable<dynamic> list = rows;

            try
            {

                string dateString = string.Format("{0}/{1}/{2}", date.Year.ToString(), date.Month.ToString(), date.Day.ToString());
                string dateStr = Class.Date.ToSolar(dateString);

                ListViewGroup grp;
                grp = lvPatientFollowUp.Groups.Add(dateStr, dateStr);
                

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


                    lvPatientFollowUp.Items.Add(item);

                }
            }


            catch (Exception exp)
            {
                MessageBox.Show("can't get data because of the followeing error \n" + exp.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        #endregion

       
        private void AddString(string text)
        {
            if (this.tabControl1.InvokeRequired)
            {
                SetTextCallback2 stc = new SetTextCallback2(AddString);
                this.Invoke(stc, new object[] { text });
            }
            else
            {
                tabControl1.TabPages[4].Text = " پیش نویس اس ام اس   ( " + text + " ) ";
            }
        }

        private delegate void SetTextCallback(DataGridViewRow ctl);
        private delegate void SetTextCallback2(string text);
         

        private void BackupBtn_Click(object sender, EventArgs e)
        {
            BackupRestore ff = new BackupRestore();
            ff.ShowDialog(this);
            ff.Dispose();

        }

     

        private void daysRdo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdoX = sender as RadioButton;
            if (rdoX == null || rdoX.Checked != true)
                return;

            var pnlList = this.dysTypePnl.Controls.OfType<UserControls.ExPanel>().ToList();
            var rdoList = new List<RadioButton>();

            foreach (var pnl in pnlList)
            {
                if (pnl != null)
                {
                    RadioButton rdo = pnl.Controls.OfType<RadioButton>().FirstOrDefault();
                    rdo.CheckedChanged -= new System.EventHandler(this.daysRdo_CheckedChanged);
                    if (rdo != null && rdo != rdoX)
                        rdo.Checked = false;
                    rdo.CheckedChanged += new System.EventHandler(this.daysRdo_CheckedChanged);
                    
                }
            }



            int val = Convert.ToInt32(rdoX.Tag);

            switch (val)
            {
               
                case 1:
                 
                    break;
          
                case 3:
                    

                    break;
                case 5:
                  
                    break;

                default:
                   
                    break;
            }

            this.tabControl1_SelectedIndexChanged(this, null);

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