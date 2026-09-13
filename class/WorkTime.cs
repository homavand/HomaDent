using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Management;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Text;
using System.Web.Routing;


namespace Dentistry.Class
{          
    public class WorkTime
    {

        public WorkTime(DateTime date)
        {
            this.Date = date;
            this.Time_8to9 = false;
            this.Time_9to10 = false;
            this.Time_10to11 = false;
            this.Time_11to12 = false;
            this.Time_12to13 = false;
            this.Time_13to14 = false;
            this.Time_14to15 = false;
            this.Time_15to16 = false;
            this.Time_16to17 = false;
            this.Time_17to18 = false;
            this.Time_18to19 = false;
            this.Time_19to20 = false;
            this.Time_20to21 = false;
            this.Time_21to22 = false;
        }
            
            
        public DateTime Date { get; set; }
        public string SolarDate {
            get { return string.Format(" {0}   {1}" , new PersianDateTime(this.Date).Date.ToString("yyyy/MM/dd") , new PersianDateTime(this.Date).DayName) ; }
        }
        public bool Time_8to9  { get; set; }
        public bool Time_9to10 { get; set; }
        public bool Time_10to11 { get; set; }
        public bool Time_11to12 { get; set; }
        public bool Time_12to13 { get; set; }
        public bool Time_13to14 { get; set; }
        public bool Time_14to15 { get; set; }
        public bool Time_15to16 { get; set; }
        public bool Time_16to17 { get; set; }
        public bool Time_17to18 { get; set; }
        public bool Time_18to19 { get; set; }
        public bool Time_19to20 { get; set; }
        public bool Time_20to21 { get; set; }
        public bool Time_21to22 { get; set; }



        public WorkTime AddTimeSliceToDate(dynamic obj)
        {
                
            var x = new RouteValueDictionary(obj);

            TimeSpan? startTime = null;
            TimeSpan? endTime = null;
                
            if (x.HasValue("StartTime"))
                startTime = x.GetValue<TimeSpan>("StartTime");

            if (x.HasValue("EndTime"))
                endTime = x.GetValue<TimeSpan>("EndTime");

            if (startTime == null || endTime == null)
                return null;

            if (startTime >= TimeSpan.Parse("08:00") && TimeSpan.Parse("14:00") >= endTime)
            {
                if (startTime <= TimeSpan.Parse("08:00") && TimeSpan.Parse("09:00") <= endTime)
                {
                    this.Time_8to9 = true;
                }
                else if (startTime <= TimeSpan.Parse("09:00") && TimeSpan.Parse("10:00") <= endTime)
                {
                    this.Time_9to10 = true;
                }
                else if (startTime <= TimeSpan.Parse("10:00") && TimeSpan.Parse("11:00") <= endTime)
                {
                    this.Time_10to11 = true;
                }
                else if (startTime <= TimeSpan.Parse("11:00") && TimeSpan.Parse("12:00") <= endTime)
                {
                    this.Time_11to12 = true;
                }
                else if (startTime <= TimeSpan.Parse("12:00") && TimeSpan.Parse("13:00") <= endTime)
                {
                    this.Time_12to13 = true;
                }
                else if (startTime <= TimeSpan.Parse("13:00") && TimeSpan.Parse("14:00") <= endTime)
                {
                    this.Time_13to14 = true;
                }
            }
            else
            {
                if (startTime <= TimeSpan.Parse("14:00") && TimeSpan.Parse("15:00") <= endTime)
                {
                    this.Time_14to15 = true;
                }
                else if (startTime <= TimeSpan.Parse("15:00") && TimeSpan.Parse("16:00") <= endTime)
                {
                    this.Time_15to16 = true;
                }
                else if (startTime <= TimeSpan.Parse("16:00") && TimeSpan.Parse("17:00") <= endTime)
                {
                    this.Time_16to17 = true;
                }
                else if (startTime <= TimeSpan.Parse("17:00") && TimeSpan.Parse("18:00") <= endTime)
                {
                    this.Time_17to18 = true;
                }
                else if (startTime <= TimeSpan.Parse("18:00") && TimeSpan.Parse("19:00") <= endTime)
                {
                    this.Time_18to19 = true;
                }
                else if (startTime <= TimeSpan.Parse("19:00") && TimeSpan.Parse("20:00") <= endTime)
                {
                    this.Time_19to20 = true;
                }
                else if (startTime <= TimeSpan.Parse("20:00") && TimeSpan.Parse("21:00") <= endTime)
                {
                    this.Time_20to21 = true;
                }
                else if (startTime <= TimeSpan.Parse("21:00") && TimeSpan.Parse("22:00") <= endTime)
                {
                    this.Time_21to22 = true;
                }
            }

            return this;
        }

    }
    
}
