using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dentistry.Class;

namespace Dentistry
{
    public partial class WorkTimes : Form
    {
        public int? DoctorId = null;
        public int Year = DateTime.Now.Year;
        public int Month = DateTime.Now.Month;
        public DateTime FromDate, ToDate;
        static int colNum = 1;
        object lockObj = new object();

        //Class.WaitFormFunc waitForm = new Class.WaitFormFunc();
        public WorkTimes()
        {
            InitializeComponent();

            this.dgWorkDays_ColumnOrder();
            var currentDate = new PersianDateTime(DateTime.Now).Date;
            this.SetYearRadioList(currentDate.Year);
            
            this.LoadFormInit();
        }

        private void dgWorkDays_ColumnOrder()
        {
            dgWorkDays.AutoGenerateColumns = false;
            
            dgWorkDays.Columns["ColumnDate"].Visible = false;
            dgWorkDays.Columns["ColumnSolarDate"].DisplayIndex = 0;            
            dgWorkDays.Columns["Col8"].DisplayIndex = 1;
            dgWorkDays.Columns["Col9"].DisplayIndex = 2;

            dgWorkDays.Columns["Col10"].DisplayIndex = 3;
            dgWorkDays.Columns["Col11"].DisplayIndex = 4;
            dgWorkDays.Columns["Col12"].DisplayIndex = 5;
            dgWorkDays.Columns["Col13"].DisplayIndex = 6;
            dgWorkDays.Columns["Col14"].DisplayIndex = 7;
            dgWorkDays.Columns["Col15"].DisplayIndex = 8;
            dgWorkDays.Columns["Col16"].DisplayIndex = 9;
            dgWorkDays.Columns["Col17"].DisplayIndex = 10;
            dgWorkDays.Columns["Col18"].DisplayIndex = 11;
            dgWorkDays.Columns["Col19"].DisplayIndex = 12;
            dgWorkDays.Columns["Col20"].DisplayIndex = 13;
            dgWorkDays.Columns["Col21"].DisplayIndex = 14;

            foreach (DataGridViewColumn col in dgWorkDays.Columns)
            {           
                col.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                col.HeaderCell.Style.Font = new Font("Vazir FD", 9.75F, FontStyle.Regular, GraphicsUnit.Point);
                
            }
          
        }

        #region LoadFormInit
        private void LoadFormInit()
        {

            dynamic sObj = new System.Dynamic.ExpandoObject();
            var result = DataProvider.GetDoctorsX(sObj);
            if (result == null || result.Success == false)
                return;

            var dd = result.Data;
            var doctorList = (dd as IEnumerable<dynamic>)
                                        .Select(i =>
                                        new
                                        {
                                            Id = (int)i.DoctorId,
                                            Title = (string)i.FullName
                                        }).ToList();

            var list = Publics.AddDefaultItemToComboDynamicList(doctorList);

            this.DoctorCbo.SelectedIndexChanged -= new EventHandler(this.DoctorCbo_SelectedIndexChanged);
            this.DoctorCbo.DataSource = list;
            this.DoctorCbo.ValueMember = "Id";
            this.DoctorCbo.DisplayMember = "Title";
            this.DoctorCbo.SelectedIndexChanged += new EventHandler(this.DoctorCbo_SelectedIndexChanged);

            var dsDoctor = (DoctorCbo.DataSource as IEnumerable<dynamic>);
            if (dsDoctor != null && Enumerable.Count(dsDoctor) <= 2)
            {
                DoctorCbo.SelectedIndex = 1;
            }

            if (Dentistry.AppConfigs.SelectedDoctorId != -1)
            {
                DoctorCbo.SelectedIndex = Publics.GetComboIndex(this.DoctorCbo, Dentistry.AppConfigs.SelectedDoctorId);
            }

        }
        #endregion

        public void SetYearRadioList(int currentYear)
        {
            this.CurrentYearRdo.Tag = currentYear;
            this.LastYearRdo.Tag = currentYear - 1;
            this.NextYearRdo.Tag = currentYear + 1;

            this.CurrentYearRdo.Text = string.Format("{0}", this.CurrentYearRdo.Tag);
            this.LastYearRdo.Text = string.Format("{0}", this.LastYearRdo.Tag);
            this.NextYearRdo.Text = string.Format("{0}", this.NextYearRdo.Tag);

            RadioButton rdo = this.YearPnl.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => Convert.ToInt32(r.Tag) == currentYear);
            if (rdo != null)
                rdo.Checked = true;

        }
        public void SetMonthRadioList(int currentMonth)
        {
            var pnl = this.MonthPnl.Controls.OfType<UserControls.ExPanel>()
                          .Where(i => Convert.ToInt32(i.Tag) == currentMonth).FirstOrDefault();

            if( pnl != null)
            {
                RadioButton rdo = pnl.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => Convert.ToInt32(r.Tag) == currentMonth);

                if (rdo != null)
                    rdo.Checked = true;
            }
            

        }
        

      
        private void FillDataGrid()
        {

            //waitForm.Show(this);

            DateTime fromDate = this.FromDate;
            DateTime toDate = this.ToDate;
            List<WorkTime> mDays = new List<WorkTime>();
            List<DateTime> days = new List<DateTime>();
            days = GetMonthDays(fromDate, toDate);

            //if (this.DoctorId == null)
            //{
            //    FarsiMessageBox.FMessageBox.Show("پزشکی انتخاب نشده است" + Environment.NewLine + "لطفا پزشک موردنطر را انتخاب کنید", "هشدار", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
            //    return ;

            //}


            dynamic sObj = new
            {
                DoctorId = this.DoctorId == null ? -1 : this.DoctorId,
                FromDate = fromDate,
                ToDate = toDate,
                IsDeleted = false
            };
            var result = Dentistry.DataProvider.GetCalendarTimesX(sObj);

            if (result != null && result.Success == false && result.Data == null)
                return ;

            var data = result.Data;
            
            var items =
            (data as IEnumerable<dynamic>)
            .GroupBy(x => x.Date)
            .Select(y => new 
                {
                    Date = y.Key,
                    Times = y.Select(i => i).Where(i => i.Date == y.Key).ToList()
                });

            for (int i=0; i<days.Count; i++)
            {
                var date = days[i];
                var dDate = new WorkTime(date);

                var item = items.Where(x => x.Date == date.Date).SingleOrDefault();
                if (item != null)
                {
                    var times = item.Times;
                    Parallel.ForEach(times, time =>
                    {
                        dDate = dDate.AddTimeSliceToDate(time);
                    });
                }

                mDays.Add(dDate);
            }


            //Parallel.ForEach(days, date =>
            //{
            //    var dDate = new MyClass.WorkTime(date);

            //    var item = items.Where(i => i.Date == date.Date).SingleOrDefault();
            //    if (item != null)
            //    {
            //        var times = item.Times;
            //        Parallel.ForEach(times, time =>
            //        {
            //            dDate = dDate.AddTimeSliceToDate(time);
            //        });
            //    }

            //    mDays.Add(dDate);

            //});

            this.dgWorkDays.DataSource = mDays.ToList().OrderBy(i => i.Date).ToList();

          

            //waitForm.Close();
        }

        private List<DateTime> GetMonthDays(DateTime fromDate, DateTime toDate)
        {
            List<WorkTime> xDateList = new List<WorkTime>();

            List<DateTime> days = new List<DateTime>();

            DateTime d = fromDate;
            while ( d <= toDate)
            {                
                days.Add(d);
                d = d.AddDays(1);
            }

            return days;

        }

     
        private void YearRdo_CheckedChanged(object sender, EventArgs e)
        {
            PersianDateTime currentDate = new PersianDateTime(DateTime.Now);
           

            LastYearRdo.BackColor = Color.DimGray;
            CurrentYearRdo.BackColor = Color.DimGray;
            NextYearRdo.BackColor = Color.DimGray;
            ((RadioButton)sender).BackColor = Color.DeepSkyBlue;

            if (((RadioButton)sender).Tag != null)
                this.Year = Convert.ToInt32(((RadioButton)sender).Tag);


            if(this.Year < currentDate.Year)
            {
                this.SetMonthRadioList(12);
            }
            else if (this.Year > currentDate.Year)
            {
                this.SetMonthRadioList(1);
            }
            else
            {
                this.SetMonthRadioList(currentDate.Month);
            }


        }

        private void rdoMonth_CheckedChanged(object sender, EventArgs e)
        {
           
            RadioButton rdoX = sender as RadioButton;
            if (rdoX == null || rdoX.Checked != true)
                return;

            var pnlList = this.MonthPnl.Controls.OfType<UserControls.ExPanel>().ToList();

            foreach (var pnl in pnlList)
            {
                if (pnl != null)
                {
                    RadioButton rdo = pnl.Controls.OfType<RadioButton>().FirstOrDefault();

                    if (rdo != null && rdo != rdoX)
                        rdo.Checked = false;
                }
            }
            
            List<WorkTime> days = new List<WorkTime>();

            var val = rdoX.Tag;

            int year = new PersianDateTime(DateTime.Now).Date.Year;
            DateTime fromDate = new DateTime();
            DateTime toDate = new DateTime();
            int month = Convert.ToInt32(val);

            
            fromDate = new PersianDateTime(year, month, 1).ToDateTime();
            toDate = new PersianDateTime(year, month, PersianDateTime.GetDaysInMonth(year, month)).ToDateTime();
           

            this.FromDate = fromDate;
            this.ToDate = toDate;

            if (this.DoctorId != null)
            {
                this.FillDataGrid();
            }
            
        }

        private void DoctorCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.DoctorId = Convert.ToInt32(((ComboBox)sender).SelectedValue);
            this.FillDataGrid();
        }

        private void dgWorkDays_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
            if (this.dgWorkDays.Columns[e.ColumnIndex].Name.Trim().Equals("ColumnDate") == true ||
                this.dgWorkDays.Columns[e.ColumnIndex].Name.Trim().Equals("ColumnSolarDate") == true
                )
            {
                var rowVal = this.dgWorkDays["ColumnDate", e.RowIndex].Value;
                var cellVal = Convert.ToString(rowVal).Split(' ')[0] ;
                this.dgWorkDays[e.ColumnIndex, e.RowIndex].Tag = cellVal;
            }
            else
            {
                bool flag = Convert.ToBoolean(e.Value);
                e.Value = "";
                if (this.dgWorkDays[e.ColumnIndex, e.RowIndex].Style == null)
                    return;
                if (flag == false)
                {
                    this.dgWorkDays[e.ColumnIndex, e.RowIndex].Style.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));

                }
                else
                    this.dgWorkDays[e.ColumnIndex, e.RowIndex].Style.BackColor = Color.LightBlue;

                var colVal = this.dgWorkDays.Columns[e.ColumnIndex].HeaderText.Trim();
                var rowVal = this.dgWorkDays["ColumnDate", e.RowIndex].Value;
                var cellVal = Convert.ToString(rowVal).Split(' ')[0] + '#' + Convert.ToString(colVal) + '#' + Convert.ToString(flag);
                this.dgWorkDays[e.ColumnIndex, e.RowIndex].Tag = cellVal;
            }
        }

        private void dgWorkDays_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dgWorkDays_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgWorkDays.Columns[e.ColumnIndex].Name.Trim().Equals("ColumnDate") == true ||
               this.dgWorkDays.Columns[e.ColumnIndex].Name.Trim().Equals("ColumnSolarDate") == true
               )
            {
                var cellVal = dgWorkDays[e.ColumnIndex, e.RowIndex].Tag.ToString() + "#8-22#";
                int doctorId = Convert.ToInt32(this.DoctorCbo.SelectedValue);
                string doctorName = this.DoctorCbo.Text;
                WorkTimeDefine form = new WorkTimeDefine(doctorId, doctorName, cellVal);
                form.ShowDialog(this);
                form.Dispose();
                this.FillDataGrid();
            }
            else
            {
                var cellVal = dgWorkDays[e.ColumnIndex,e.RowIndex].Tag.ToString();
                int doctorId = Convert.ToInt32(this.DoctorCbo.SelectedValue);
                string doctorName = this.DoctorCbo.Text;
                WorkTimeDefine form = new WorkTimeDefine(doctorId, doctorName, cellVal);
                form.ShowDialog(this);
                form.Dispose();
                this.FillDataGrid();

            }
        }

        private void CreateTimeBtn_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_تعیین_زمان_بازه_کار_مطب_ایجاد_برشهای_زمانی_جدید) == false)
                return;
            int doctorId = Convert.ToInt32(this.DoctorCbo.SelectedValue);
            WorkTimesDefine form = new WorkTimesDefine(doctorId);
            form.ShowDialog(this);
            form.Dispose();
            this.FillDataGrid();
        }
    }
}
