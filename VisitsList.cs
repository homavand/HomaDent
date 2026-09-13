
using Dentistry.Class;
using Dentistry.UserControls;
using PopupControl;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.Calendar;


namespace Dentistry
{
    
    public partial class VisitsList : Form
    {
        
        int PatientId;
        bool flag = false;
        int currentDateIndex = 0;
        int TimeSlice = 15;


        List<CalendarItem> _items = new List<CalendarItem>();
        CalendarItem contextItem = null;

       
        public DatePattern GetDatePattern(DateTime dt)
        {
            DatePattern o = new DatePattern();

            PersianCalendar pdate = new PersianCalendar();

            int startDayDiff = 0;
            int endDayDiff = 0;
            DayOfWeek dayOfWeek = pdate.GetDayOfWeek(dt);

            switch (dayOfWeek)
            {
                case DayOfWeek.Saturday:
                    startDayDiff = 0;
                    endDayDiff = 6;
                    break;

                case DayOfWeek.Sunday:
                    startDayDiff = 1;
                    endDayDiff = 5;
                    break;
                case DayOfWeek.Monday:
                    startDayDiff = 2;
                    endDayDiff = 4;
                    break;
                case DayOfWeek.Tuesday:
                    startDayDiff = 3;
                    endDayDiff = 3;
                    break;
                case DayOfWeek.Wednesday:
                    startDayDiff = 4;
                    endDayDiff = 2;
                    break;
                case DayOfWeek.Thursday:
                    startDayDiff = 5;
                    endDayDiff = 1;
                    break;
                case DayOfWeek.Friday:
                    startDayDiff = 6;
                    endDayDiff = 0;
                    break;
            }

            //day
            var persianCurrentDateTime = new PersianDateTime(dt);
            DateTime sDayDate = new PersianDateTime(persianCurrentDateTime.Year, persianCurrentDateTime.Month, persianCurrentDateTime.Day).ToDateTime();
            DateTime eDayDate = new PersianDateTime(persianCurrentDateTime.Year, persianCurrentDateTime.Month, persianCurrentDateTime.Day).ToDateTime();

            //week
            DateTime sDate = dt.AddDays(-1 * startDayDiff);
            DateTime eDate = dt.AddDays(1 * endDayDiff);
            var persianStartWeekDate = new PersianDateTime(sDate);
            var persianEndWeekDate = new PersianDateTime(eDate);
            DateTime sWeekDate = new PersianDateTime(persianStartWeekDate.Year, persianStartWeekDate.Month, persianStartWeekDate.Day).ToDateTime();
            DateTime eWeekDate = new PersianDateTime(persianEndWeekDate.Year, persianEndWeekDate.Month, persianEndWeekDate.Day).ToDateTime();



            //month
            persianCurrentDateTime = new PersianDateTime(dt);
            DateTime sMonthDate = new PersianDateTime(persianCurrentDateTime.Year, persianCurrentDateTime.Month, 1).ToDateTime();
            DateTime eMonthDate = new PersianDateTime(persianCurrentDateTime.Year, persianCurrentDateTime.Month, persianCurrentDateTime.DaysInMonth).ToDateTime();

            calendar1.FirstDayOfWeek = DayOfWeek.Saturday;

            o.CurrentDate     = dt;
            o.StartDayDate    = sDayDate;
            o.EndDayDate      = eDayDate;
            o.StartWeekDate   = sWeekDate;
            o.EndWeekDate     = eWeekDate;
            o.StartMonthDate  = sMonthDate;
            o.EndMonthDate    = eMonthDate;
            

            return o;
        }

        public VisitsList()
        {
            InitializeComponent();
                   
        }
       

        private void TimeVisit_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();
            
            vScroll.Maximum = calendar1.Days[0].TimeUnits.Length / 3;
            rdWeek.Checked = true;

            PersianMonthCalendarEventArgs g = new PersianMonthCalendarEventArgs();
            g.CurrentValue = PersianDate.Now;
            persianMonth.Value = g.CurrentValue;

         
            
        }

        private void WorkTimeVisits_Shown(object sender, EventArgs e)
        {
            this.timeScale15Rdo.Checked = true;
            this.rdWeek.Checked = true;
            LoadItem();
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

            this.DoctorCbo.SelectedIndexChanged -= new EventHandler(DoctorCbo_SelectedIndexChanged);
            this.DoctorCbo.DataSource = list;
            this.DoctorCbo.ValueMember = "Id";
            this.DoctorCbo.DisplayMember = "Title";
            this.DoctorCbo.SelectedIndexChanged += new EventHandler(DoctorCbo_SelectedIndexChanged);

            

            var dsDoctor = (DoctorCbo.DataSource as IEnumerable<dynamic>);
            if (dsDoctor != null && Enumerable.Count(dsDoctor) <= 2)
            {
                DoctorCbo.SelectedIndex = 1;
            }

            if(Dentistry.AppConfigs.SelectedDoctorId != -1)
            {
                DoctorCbo.SelectedIndex = Publics.GetComboIndex(this.DoctorCbo, Dentistry.AppConfigs.SelectedDoctorId) ;
            }
          

        }
        #endregion
       
        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked == false)
                return;
            PersianMonthCalendarEventArgs g = new PersianMonthCalendarEventArgs();
            g.CurrentValue = persianMonth.Value;
            persianMonth_ValueChanged(sender, g);
        }

        private void persianMonth_ValueChanged(object sender, PersianMonthCalendarEventArgs e)
        {
            
            PersianDate currentPersianDate = e.CurrentValue;
            
            DateTime currentDate = DateTime.Parse(Class.Date.ToChristianByTime(currentPersianDate.ToString()));

            DatePattern dpObj = new DatePattern();
            dpObj = GetDatePattern(currentDate);

            
            calendar1.FirstDayOfWeek = DayOfWeek.Saturday;


            //DateTime StartMonth = currentDate.AddDays(0 - currentDate.Day);
            //DateTime EndMonth = StartMonth.AddMonths(1).AddSeconds(-1);

            //int dayOf = Convert.ToInt32(pdate.GetDayOfWeek(currentDate));

            DateTime startDate = currentDate;
            DateTime endDate   = currentDate;

            if (rdDay.Checked)
            {
                startDate = dpObj.StartDayDate.Value;
                endDate   = dpObj.EndDayDate.Value;
                //calendar1.Mode = System.Windows.Forms.Calendar.Calendar.CalendarMode.Daily;
            }
            else if (rdWeek.Checked)
            {
                startDate = dpObj.StartWeekDate.Value;
                endDate   = dpObj.EndWeekDate.Value;                
            }
            else if (rdMonth.Checked)
            {
                startDate = dpObj.StartMonthDate.Value;
                endDate   = dpObj.EndMonthDate.Value;
            }

            

            calendar1.SetViewRange(startDate, endDate);
            this.btnSearch_Click(this, e);

        }


        private void PlaceItems()
        {
            var tempItems = new List<CalendarItem>();
            foreach (CalendarItem item in _items)
            {
                if (calendar1.ViewIntersects(item))
                {

                    if (item.EndDate < DateTime.Now)
                    {
                        item.Locked = true;
                        item.BackgroundColor = Color.Red;
                    }
                    tempItems.Add(item);
                }
            }
            calendar1.Items.AddRange(tempItems);
        }


        #region LoadInfo

        private void LoadItem()
        {
            try
            {             
                IEnumerable <dynamic> list = null;
                dynamic sObj = new System.Dynamic.ExpandoObject();

                sObj.DoctorId = this.DoctorCbo.SelectedValue;
                sObj.FromDate = this.calendar1.ViewStart.Date.ToShortDateString();
                sObj.ToDate   = this.calendar1.ViewEnd.Date.ToShortDateString();
                sObj.IsDeleted = false;
              
                
                var result = Dentistry.DataProvider.GetCalendarTimesX(sObj);
                if (result != null && result.Success == true && result.Data != null)
                {
                    var dd = result.Data;                    
                    list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : Enumerable.Empty<dynamic>();

                }

                this.calendar1.Refresh();

                List<dynamic> activeDays = new List<dynamic>();
                if (list != null )
                {
                    List<CalendarHighlightRange> calendarHighlightRangeList = new List<CalendarHighlightRange>();

                    foreach (dynamic obj in list)
                    {
                        if (obj == null)
                            return;

                        if (obj.Date == null)
                            return;

                        var items = this.calendar1.Days.ToList().Where(i => i.Date == ((DateTime)obj.Date).Date).Select(i => i);

                        if (items.Any())
                        {
                            var day = items.SingleOrDefault();

                            if (obj.DayOfWeek == null || obj.StartTime == null || obj.EndTime == null)
                                return;

                            CalendarHighlightRange calendarHighlightRange = new CalendarHighlightRange();
                            calendarHighlightRange.DayOfWeek = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), Convert.ToString(obj.DayOfWeek));
                            calendarHighlightRange.StartTime = TimeSpan.Parse(Convert.ToString(obj.StartTime));
                            calendarHighlightRange.EndTime = TimeSpan.Parse(Convert.ToString(obj.EndTime));

                            calendarHighlightRangeList.Add(calendarHighlightRange);
                        }

                    }

                    this.calendar1.HighlightRanges = calendarHighlightRangeList.ToArray();

                }


                sObj = new System.Dynamic.ExpandoObject();
                sObj.DoctorId = Convert.ToInt32(DoctorCbo.SelectedValue) > 0 ? Convert.ToInt32(DoctorCbo.SelectedValue) : (int?)null;                
                sObj.FromDate = this.calendar1.ViewStart.Date.ToShortDateString();
                sObj.ToDate = this.calendar1.ViewEnd.Date.ToShortDateString();
                sObj.IsDeleted = false;

                list = null;
                result = DataProvider.GetVisitX(sObj);
                if (result != null && result.Success == true && result.Data != null)
                {
                    var dd = result.Data;
                    list = dd != null  && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;

                }


                if (list != null  &&  list.Count() > 0)
                {
                    foreach (dynamic obj in list)
                    {
                        if (obj == null)
                            return;
                        if (obj.Date == null || obj.PatientId == null)
                            return;

                        DateTime date = DateTime.Parse(Convert.ToString(obj.Date));
                        TimeSpan startTime = (obj.StartTime);
                        TimeSpan endTime = (obj.EndTime);
                        var startDateTime = date.Add(startTime);
                        var endDateTime = date.Add(endTime);
                        CalendarItem cal = new CalendarItem(calendar1,
                                                            startDateTime,
                                                            endDateTime,                                                            
                                                            Convert.ToInt32(obj.DoctorId),
                                                            Convert.ToInt32(obj.PatientId),
                                                            Convert.ToString(obj.PatientName),
                                                            Convert.ToInt32(obj.ServiceGroupId),
                                                            Convert.ToString(obj.ServiceGroupTitle),
                                                            Convert.ToString(obj.Description), 
                                                            Convert.ToInt32(obj.Id),
                                                            Color.FromArgb(Convert.ToInt32(obj.Color))
                                                            );

                        if (Convert.ToString(obj.Color) != "0") //(!(item.R == 0 && item.G == 0 && item.B == 0))
                        {
                            cal.ApplyColor(Color.FromArgb(Convert.ToInt32(Convert.ToString(obj.Color)))); //(item.A, item.R, item.G, item.B));
                        }

                        _items.Add(cal);
                    }
                }

                //PlaceItems();
            }
            catch (Exception exp)
            {

            }
        }
        #endregion

        private void calendar1_LoadItems(object sender, CalendarLoadEventArgs e)
        {
            //LoadItem();
            PlaceItems();
        }

        private void calendar1_ItemCreated(object sender, CalendarItemCancelEventArgs e)
        {
            _items.Add(e.Item);
        }

        private void calendar1_ItemDeleted(object sender, CalendarItemEventArgs e)
        {
            _items.Remove(e.Item);
        }

        

        private void calendar1_ItemDoubleClick(object sender, CalendarItemEventArgs e)
        {

         
            bool createItem = true;
            bool highLight = false;
            if (calendar1.SelectedElementStart != null)
            {
                TimeSpan xTime = new TimeSpan(calendar1.SelectedElementStart.Date.Hour, 
                                               calendar1.SelectedElementStart.Date.Minute, 
                                               0);

                // این خط کد جهت فعال / غیر فعال کردن تایم های حضور و عدم حضور دکتر در مطب می باشد
                CalendarHighlightRange[] high = this.calendar1.HighlightRanges;
                for (int i = 0; i < high.Length; i++)
                {
                    if (high[i].DayOfWeek == calendar1.SelectedElementStart.Date.DayOfWeek)
                    {
                        if (xTime >= high[i].StartTime && xTime < high[i].EndTime)
                        {
                            createItem = true;
                            highLight = true;
                            break;
                        }
                        else
                        {
                            createItem = false;
                        }
                    }
                    else
                    {
                        highLight = false;
                    }
                }

                if (highLight)
                {
                    if (createItem)
                    {
                        if (calendar1.SelectedElementStart.Date >= DateTime.Now)
                        {
                            TimeSpan sTime = new TimeSpan(calendar1.SelectedElementStart.Date.Hour,
                                                          calendar1.SelectedElementStart.Date.Minute,
                                                          0);
                            TimeSpan eTime = new TimeSpan(calendar1.SelectedElementEnd.Date.Hour,
                                                          calendar1.SelectedElementEnd.Date.Minute,
                                                          0).Add(new TimeSpan(0, this.TimeSlice, 0)
                                                         );

                            VisitDefine appoinment = new VisitDefine(
                                                               calendar1.SelectedElementStart.Date,
                                                               sTime,
                                                               eTime, 
                                                               Convert.ToInt32(DoctorCbo.SelectedValue), 
                                                               null);
                            appoinment.ShowDialog();
                            if (appoinment.DialogResult == DialogResult.OK && appoinment.Flag == true)
                            {
                                DateTime date = DateTime.Parse(appoinment.DateTxt.Text);
                                DateTime dt;
                                if (!DateTime.TryParseExact(appoinment.FromTimeTxt.Text, "HH:mm", CultureInfo.InvariantCulture,
                                                                              DateTimeStyles.None, out dt))
                                {
                                    // handle validation error
                                }
                                TimeSpan timeS = dt.TimeOfDay;
                                if (!DateTime.TryParseExact(appoinment.ToTimeTxt.Text, "HH:mm", CultureInfo.InvariantCulture,
                                                                              DateTimeStyles.None, out dt))
                                {
                                    // handle validation error
                                }
                                TimeSpan timeE = dt.TimeOfDay;

                                DateTime startTime = new DateTime(date.Year, date.Month, date.Day, timeS.Hours, timeS.Minutes, 0);
                               
                                DateTime endtTime = new DateTime(date.Year, date.Month, date.Day, timeE.Hours, timeE.Minutes, 0);


                               
                                string txt = string.Format("{0} - {1} - {2}", appoinment.PatientName , appoinment.ServiceGroupTitle , appoinment.DoctorName);
                                
                                calendar1.CreateItemOnSelectionDouble(appoinment.PatientId, appoinment.PatientName, appoinment.ServiceGroupId, appoinment.ServiceGroupTitle, "", false, startTime, endtTime, appoinment.DoctorId, appoinment.VisitId, Color.FromArgb(Convert.ToInt32((appoinment.VisitColor))) );

                                //PlaceItems();
                            }
                        }
                        else
                            FarsiMessageBox.FMessageBox.Show("پایان وقت ویزیت", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);

                    }
                    else
                    {
                        FarsiMessageBox.FMessageBox.Show("برای این ساعت از روز اجازه پذیزش داده نشده است", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    }
                }
                else
                {
                    FarsiMessageBox.FMessageBox.Show("برای این ساعت از روز اجازه پذیزش داده نشده است", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                }
            }
            else if (e.Item != null)
            {
                var obj = e.Item;
                TimeSpan stTime = new TimeSpan(obj.StartDate.Hour, obj.StartDate.Minute, 0);
                TimeSpan edTime = new TimeSpan(obj.EndDate.Hour, obj.EndDate.Minute, 0);

                CalendarHighlightRange[] high = this.calendar1.HighlightRanges;
                // این خط کد جهت فعال / غیر فعال کردن تایم های حضور و عدم حضور دکتر در مطب می باشد
                //for (int i = 0; i < high.Length; i++)
                //{
                //    if (high[i].DayOfWeek == obj.Date.DayOfWeek)
                //    {
                //        if (stTime >= high[i].StartTime && stTime <= high[i].EndTime)
                //        {
                //            CreateItem = true;
                //        }
                //        else
                //        {
                //            CreateItem = false;
                //        }
                //        HighLight = true;
                //        break;
                //    }
                //    else
                //    {
                //        HighLight = false;
                //    }
                //}
                if (highLight)
                {
                    if (createItem)
                    {
                        VisitDefine workTimeVisitDefine = new VisitDefine(
                                                           obj.Date, 
                                                           new TimeSpan(obj.StartDate.Hour, obj.StartDate.Minute, 0), 
                                                           new TimeSpan(obj.EndDate.Hour, obj.EndDate.Minute, 0),
                                                           obj.DoctorId,
                                                           obj.VisitId
                                                           );
                        workTimeVisitDefine.ShowDialog();
                        if (workTimeVisitDefine.Flag)
                        {

                            obj.Text = workTimeVisitDefine.PatientName;                            

                        }
                    }
                    else
                    {
                        FarsiMessageBox.FMessageBox.Show("برای این ساعت از روز اجازه پذیزش داده نشده است", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    }
                }
                else
                {
                    FarsiMessageBox.FMessageBox.Show("برای این ساعت از روز اجازه پذیزش داده نشده است", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                }

                this.btnSearch_Click(this,null);
            }
        }

        
        
        private void btnSearch_Click(object sender, EventArgs e)
        {
            calendar1.Items.Clear();

            _items.RemoveRange(0, _items.Count);
            LoadItem();
            PlaceItems();
            
        }

      

        private void editItemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FarsiMessageBox.FMessageBox.Show("آیا از حذف این آیتم مطمئن هستید؟", "پیام", FarsiMessageBox.FMessageBoxButtons.OKCancel, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1) == System.Windows.Forms.DialogResult.OK)
            {
                foreach (CalendarItem item in calendar1.GetSelectedItems())
                {
                    try
                    {
                        dynamic iObj = new ExpandoObject();
                        iObj.Id = Convert.ToInt32(item.VisitId);
                        iObj.IsDeleted = true;

                        JsonResponse<dynamic> result = Dentistry.DataProvider.DefineVisitX(iObj);

                        if (result != null && result.Success == true && result.Data != null)
                        {
                            FarsiMessageBox.FMessageBox.Show("اطلاعات با موفقیت حذف شدند", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                        }                      
                    }
                    catch (Exception)
                    {

                    }
                }
                calendar1.DeleteSelectedItems();

            }
        }

      
       
        private void vScroll_Scroll(object sender, ScrollEventArgs e)
        {
            calendar1.ScrollTimeUnits2(-e.NewValue);
        }

        private void TimeVisit_KeyUp(object sender, KeyEventArgs e)
        {
        
        }

        private void calendar1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                editItemToolStripMenuItem_Click(sender, e);
            }
        }

        private void DoctorCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cmb = (System.Windows.Forms.ComboBox)sender;
            Dentistry.AppConfigs.SelectedDoctorId = Convert.ToInt32(cmb.SelectedValue);
        }

        private void timeScaleRdo_CheckedChanged(object sender, EventArgs e)
        {
            if (sender != null )
            {
                this.TimeSlice = Convert.ToInt32(((RadioButton)sender).Tag);
                switch(this.TimeSlice)
                {
                    case 10:
                        calendar1.TimeScale = CalendarTimeScale.TenMinutes;
                        break;
                    case 15:
                        calendar1.TimeScale = CalendarTimeScale.FifteenMinutes;
                        break;
                    case 20:
                        calendar1.TimeScale = CalendarTimeScale.twentyMinutes;
                        break;
                    case 30:
                        calendar1.TimeScale = CalendarTimeScale.ThirtyMinutes;
                        break;                   
                    case 60:
                        calendar1.TimeScale = CalendarTimeScale.SixtyMinutes;
                        break;
                    default:
                        calendar1.TimeScale = CalendarTimeScale.FifteenMinutes;
                        break;
                }
              
              
            }
            else
            {
                calendar1.TimeScale = CalendarTimeScale.FifteenMinutes;

            }

            vScroll.Maximum = calendar1.Days[0].TimeUnits.Length / 2;
        }

        private void calendar1_DayHeaderClick(object sender, CalendarDayEventArgs e)
        {
          

            switch (calendar1.Mode)
            {
                case System.Windows.Forms.Calendar.Calendar.CalendarMode.Monthly:
                    //currentDateIndex = e.CalendarDay.Index;
                    calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
                    break;
                case System.Windows.Forms.Calendar.Calendar.CalendarMode.Weekly:
                    calendar1.SetViewRange(e.CalendarDay.Date, e.CalendarDay.Date);
                    break;
                case System.Windows.Forms.Calendar.Calendar.CalendarMode.Daily:

                    DateTime currentDate = e.CalendarDay.Date;
                    DatePattern dpObj = new DatePattern();
                    dpObj = GetDatePattern(currentDate);

                    calendar1.SetViewRange(dpObj.StartWeekDate.Value, dpObj.EndWeekDate.Value);
                    break;

            }



        }
        private void calendar1_DayHeaderDoubleClick(object sender, CalendarDayEventArgs e)
        {
            var date = PersianDate.Parse(e.CalendarDay.DayTop.Date);
            persianMonth.Value = date;
            persianMonth.Refresh();
        }

        private void calendar1_CalendarModeChange(object sender, CalendarLoadEventArgs e)
        {
            var calendarMode = calendar1.Mode;
            switch (calendarMode)
            {
                case System.Windows.Forms.Calendar.Calendar.CalendarMode.Daily:
                    rdDay.CheckedChanged -= new System.EventHandler(this.rdo_CheckedChanged);
                    rdDay.Checked = true;
                    rdDay.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
                    break;
                case System.Windows.Forms.Calendar.Calendar.CalendarMode.Weekly:
                    rdWeek.CheckedChanged -= new System.EventHandler(this.rdo_CheckedChanged);
                    rdWeek.Checked = true;
                    rdWeek.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
                    break;
                case System.Windows.Forms.Calendar.Calendar.CalendarMode.Monthly:
                    rdMonth.CheckedChanged -= new System.EventHandler(this.rdo_CheckedChanged);
                    rdMonth.Checked = true;
                    rdMonth.CheckedChanged += new System.EventHandler(this.rdo_CheckedChanged);
                    break;
                default:
                   
                    break;
            }



        }

        
    }
}
