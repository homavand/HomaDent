using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dentistry
{
    public partial class WorkTimesDefine : Form
    {
        Dictionary<int, string> WeekDays = new Dictionary<int, string>();
        public int DoctorId = 0;
        public WorkTimesDefine(int doctorId)
        {
            InitializeComponent();
            this.DoctorId = doctorId;
            this.LoadFormInit();
            
            
            WeekDays.Add(1, DayOfWeek.Saturday.ToString());
            WeekDays.Add(2, DayOfWeek.Sunday.ToString());
            WeekDays.Add(3, DayOfWeek.Monday.ToString());
            WeekDays.Add(4, DayOfWeek.Tuesday.ToString());
            WeekDays.Add(5, DayOfWeek.Wednesday.ToString());
            WeekDays.Add(6, DayOfWeek.Thursday.ToString());
            WeekDays.Add(7, DayOfWeek.Friday.ToString());

            

            
        }

        private void WorkTimesDefine_Load(object sender, EventArgs e)
        {
            var date = new PersianDateTime(DateTime.Now).Date;
            this.fromDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, date.Month, 1);
            this.toDateTxt.Value = DateTime.Now;

            this.FillGrid_dgVisitTimeOnOff();
            dgVisitTimeOnOff.Columns[0].Selected = false;
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

            this.doctorCbo.SelectedIndexChanged -= new EventHandler(this.DoctorCbo_SelectedIndexChanged);
            this.doctorCbo.DataSource = list;
            this.doctorCbo.ValueMember = "Id";
            this.doctorCbo.DisplayMember = "Title";
            this.doctorCbo.SelectedIndexChanged += new EventHandler(this.DoctorCbo_SelectedIndexChanged);

            this.doctorCbo.SelectedIndex = Publics.GetComboIndex(this.doctorCbo, this.DoctorId); 
        }
        #endregion

        #region CreateTimeTable
        private void CreateTimeTable(int timeSlice)
        {
            if (dgVisitTimeOnOff.Rows.Count > 0)
            {
                dgVisitTimeOnOff.Rows.Clear();
            }

            int hourStart = 8;
            int len = (22 - 8);
            for (int i = 0; i < len; i++)
            {
                TimeSpan st = new TimeSpan(hourStart, 0, 0);
                int hourEnd = ++hourStart;
                TimeSpan et = new TimeSpan(hourEnd, 0, 0);

                DataGridViewRow dr = new DataGridViewRow();
                dr.CreateCells(dgVisitTimeOnOff);

                dr.Cells[0].Value = st.ToString(@"hh\:mm") + " - " + et.ToString(@"hh\:mm");
                dr.Cells[0].Tag = st;

                dgVisitTimeOnOff.Rows.Add(dr);
            }
        }
        #endregion

        #region FillGrid_dgVisitTimeOnOff
        private void FillGrid_dgVisitTimeOnOff()
        {
            if (doctorCbo.SelectedValue == null)
                throw new Exception("پزشکی وارد نشده است");

            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.DoctorId = doctorCbo.SelectedValue;
            sObj.IsDeleted = false;
           
            if ((this.fromDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.fromDateTxt.Value.ToString())))
                sObj.FromDate = Class.Date.ToChristianByTime(this.fromDateTxt.Value.ToString());

            if ((this.toDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.toDateTxt.Value.ToString())))
                sObj.ToDate = Class.Date.ToChristianByTime(this.toDateTxt.Value.ToString());


            var result = Dentistry.DataProvider.GetCalendarTimesX(sObj);

            if (result != null && result.Success == false && result.Data == null)
                return;

            //int timeSlice = Convert.ToInt32(this.TimeSliceCbo.SelectedValue);
            this.CreateTimeTable(60);            
          
            var items = result.Data;            
            
            for (int i = 0; i < items.Count; i++)
            {
                var obj = items[i];
                foreach (var item in WeekDays)
                {
                    int key = item.Key;
                    string value = item.Value;

                    if (obj.DayOfWeek == value)
                    {
                        int len = dgVisitTimeOnOff.Rows.Count;
                        for (int j = 0; j < len; j++)
                        {
                            TimeSpan startTime = TimeSpan.Parse(Convert.ToString(obj.StartTime));
                            TimeSpan endTime = TimeSpan.Parse(Convert.ToString(obj.EndTime));
                            string cTime = Convert.ToString(dgVisitTimeOnOff.Rows[j].Cells["Column0"].Tag);
                            TimeSpan tTime = TimeSpan.Parse(cTime);

                            if (tTime >= startTime  && tTime < endTime)
                            {
                                dgVisitTimeOnOff.Rows[j].Cells[key].Style.BackColor = Color.LightBlue;
                            }
                            if (j == len-1 && tTime <= endTime)
                            {
                                dgVisitTimeOnOff.Rows[j].Cells[key].Style.BackColor = Color.LightBlue;
                            }
                        }
                    }
                }

            }
            
            
           
        }

        #endregion

        
       
        private void btnCreateTable_Click(object sender, EventArgs e)
        {
            if (FarsiMessageBox.FMessageBox.Show("آیا برای ایجاد مطمئن هستید؟" + Environment.NewLine + "در صورت تایید اطلاعات قبلی پاک خواهند شد", "هشدار", FarsiMessageBox.FMessageBoxButtons.OKCancel, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1) == System.Windows.Forms.DialogResult.OK)
            {
                dynamic iObj = new System.Dynamic.ExpandoObject();               
                iObj.DoctorId = doctorCbo.SelectedValue;
                iObj.FromDate = Class.Date.ToChristianByTime(this.fromDateTxt.Value.ToString());
                iObj.ToDate = Class.Date.ToChristianByTime(this.toDateTxt.Value.ToString());

                JsonResponse<dynamic> result = Dentistry.DataProvider.DeleteWorkTimeX(iObj);
                if (result != null && result.Success == true)                
                {
                    FarsiMessageBox.FMessageBox.Show("اطلاعات با موفقیت پاک شدند", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    dgVisitTimeOnOff.Enabled = true;
                    btnSelect.Enabled = true;
                    //int timeSlice = Convert.ToInt32(this.TimeSliceCbo.SelectedValue);
                    this.CreateTimeTable(60);
                }
            }
           
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgVisitTimeOnOff.CurrentCell == null)
            {
                MessageBox.Show("انتخابی موجود نمی باشد");
                return;
            }

            foreach (DataGridViewCell item in dgVisitTimeOnOff.SelectedCells)
            {
                if (item.Style.BackColor == Color.LightBlue)
                {
                    item.Style.BackColor = Color.White;
                }
                else
                {                    
                    item.Style.BackColor = Color.LightBlue;
                }
                item.Selected = false;
            }
            

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var doctorId = Convert.ToInt32(doctorCbo.SelectedValue);

            if (doctorId == -1 )
            {
                FarsiMessageBox.FMessageBox.Show("لطفا پزشک موردنظر را انتخاب کنید", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information);
                doctorCbo.Focus();
                return;
            }
         
            dynamic iObj = new System.Dynamic.ExpandoObject();
            iObj.DoctorId = doctorCbo.SelectedValue;
            iObj.FromDate = Class.Date.ToChristian(this.fromDateTxt.Value.ToString());
            iObj.ToDate = Class.Date.ToChristian(this.toDateTxt.Value.ToString());

            List<dynamic> weekDayTimes = new List<dynamic>();

            if (doctorCbo.SelectedIndex >= 0 && dgVisitTimeOnOff.Enabled == true)
            {

                string[] dayNames = { DayOfWeek.Saturday.ToString(), DayOfWeek.Sunday.ToString(), DayOfWeek.Monday.ToString(), DayOfWeek.Tuesday.ToString(), DayOfWeek.Wednesday.ToString(), DayOfWeek.Thursday.ToString(), DayOfWeek.Friday.ToString() };

                try
                {

                    for (int i = 1; i < dgVisitTimeOnOff.Columns.Count; i++)
                    {
                        for (int j = 0; j < dgVisitTimeOnOff.Rows.Count; j++)
                        {

                            if (dgVisitTimeOnOff.Rows[j].Cells[i].Style.BackColor == Color.LightBlue)
                            {
                                var tag = dgVisitTimeOnOff.Rows[j].Cells["Column0"].Tag;
                                var cellValue = Convert.ToString(dgVisitTimeOnOff.Rows[j].Cells["Column0"].Value);
                                string dayName = dayNames[i - 1].ToString();
                                string startTime = cellValue.Split('-')[0];
                                string endTime = cellValue.Split('-')[1];

                                weekDayTimes.Add(new { DayName = dayName, StartTime = startTime, EndTime = endTime });


                            }
                        }

                    }

                    iObj.WeekDayTimes = weekDayTimes;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefineWorkTimeX(iObj);
                    if (result.Success == true)
                    {
                        FarsiMessageBox.FMessageBox.Show("اطلاعات با موفقیت ثبت شدند", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    }
                    else
                    {
                        FarsiMessageBox.FMessageBox.Show("خظا در ثبت اطلاعات", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    }



                }
                catch (Exception)
                {

                }

            }
            else
            {
                FarsiMessageBox.FMessageBox.Show("لطفا نام دکتر را انتخاب کنید", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
            }
            
        }

      

        private void dataGridView1_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            if(e.Cell.ColumnIndex==0)
            dgVisitTimeOnOff.ClearSelection();
        }

        private void DoctorCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillGrid_dgVisitTimeOnOff();
        }

        
    }
}
