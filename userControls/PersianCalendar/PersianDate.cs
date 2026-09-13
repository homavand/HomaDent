
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;


namespace Dentistry.UserControls
{
    //[Serializable]
    public struct PersianDate : IComparable, IComparable<PersianDate>, IComparer, IComparer<PersianDate>, ICloneable
    {
        private static readonly PersianCalendar calendar = new PersianCalendar();

        public static readonly PersianDate MinValue = new PersianDate(1, 1, 1);

        public static readonly PersianDate MaxValue = new PersianDate(1500, 12, 29);

        private string[] weekArray;

        private string[] monthsArray;

        private int year;

        private int month;

        private int day;

        private DayOfWeek dayOfWeek;

        public int Year
        {
            get
            {
                return year;
            }
        }


        public int Month
        {
            get
            {
                return month;
            }
        }


        public int Day
        {
            get
            {
                return day;
            }
        }


        public DayOfWeek DayOfWeek
        {
            get
            {
                return dayOfWeek;
            }
        }


        public static PersianDate Now
        {
            get
            {
                return Parse(DateTime.Now);
            }
        }


        public PersianDate(int year, int month, int day)
        {
            if (!ValidDate(year, month, day))
            {
                throw new ArgumentException("Date time is not valid");
            }
            this.year = year;
            this.month = ((month <= 0) ? 1 : month);
            this.day = ((day <= 0) ? 1 : day);
            weekArray = new string[7] { "ش", "ی", "د", "س", "چ", "پ", "ج" };
            monthsArray = new string[12]
            {
            "فروردین", "اردیبهشت", "خرداد", "تیر", "مرداد", "شهریور", "مهر", "آبان", "آذر", "دی",
            "بهمن", "اسفند"
            };
            DateTime time = calendar.ToDateTime(year, month, day, 0, 0, 0, 0);
            dayOfWeek = calendar.GetDayOfWeek(time);
        }

        public static bool ValidDate(int year, int month, int day, int hour, int minute, int second)
        {
            bool result = true;
            try
            {
                calendar.ToDateTime(year, month, day, hour, minute, second, 0);
            }
            catch (ArgumentException)
            {
                result = false;
            }
            return result;
        }

        [Obsolete("please use valid date method ValidDate(1388,05,06,04,10,20) ")]
        public static bool ValidDate(int year, int month, int day)
        {
            bool result = true;
            try
            {
                calendar.ToDateTime(year, month, day, 0, 0, 0, 0);
            }
            catch (ArgumentException)
            {
                result = false;
            }
            return result;
        }

        public static bool ValidDate(PersianDate persianDate)
        {
            return ValidDate(persianDate.Year, persianDate.Month, persianDate.Day, 0, 0, 0);
        }

        public static int Compare2Date(PersianDate persianDate1, PersianDate persianDate2)
        {
            if (persianDate1.year > persianDate2.Year)
            {
                return 1;
            }
            if (persianDate1.year < persianDate2.Year)
            {
                return -1;
            }
            if (persianDate1.month > persianDate2.Month)
            {
                return 1;
            }
            if (persianDate1.month < persianDate2.Month)
            {
                return -1;
            }
            if (persianDate1.day > persianDate2.Day)
            {
                return 1;
            }
            if (persianDate1.day < persianDate2.Day)
            {
                return -1;
            }
            return 0;
        }

        public static PersianDate Parse(DateTime date)
        {
            PersianDate result = new PersianDate(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
            result.dayOfWeek = calendar.GetDayOfWeek(date);
            return result;
        }

        public static PersianDate Parse(string dateString)
        {
            return MinValue;
        }

        public PersianDate AddHours(int value)
        {
            try
            {
                return ((DateTime)this).AddHours(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersianDate AddMinutes(int value)
        {
            try
            {
                return ((DateTime)this).AddMinutes(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersianDate AddSeconds(int value)
        {
            try
            {
                return ((DateTime)this).AddSeconds(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersianDate AddDays(int value)
        {
            try
            {
                return ((DateTime)this).AddDays(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersianDate AddMonths(int value)
        {
            try
            {
                return ((DateTime)this).AddMonths(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public PersianDate AddYears(int value)
        {
            try
            {
                return ((DateTime)this).AddYears(value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int GetDaysInMonth()
        {
            return calendar.GetDaysInMonth(year, month);
        }

        public int GetDaysInYear()
        {
            return calendar.GetDaysInYear(year);
        }

        internal PersianDate GetLastSaturday()
        {
            PersianDate persianDate = AddDays(-(day + 1));
            return persianDate.AddDays(-(GetWeekNo(persianDate.dayOfWeek) - 1));
        }

        private int GetWeekNo(DayOfWeek week)
        {
            switch (week)
            {
                case DayOfWeek.Saturday:
                    return 1;
                case DayOfWeek.Sunday:
                    return 2;
                case DayOfWeek.Monday:
                    return 3;
                case DayOfWeek.Tuesday:
                    return 4;
                case DayOfWeek.Wednesday:
                    return 5;
                case DayOfWeek.Thursday:
                    return 6;
                case DayOfWeek.Friday:
                    return 7;
                default:
                    return -1;
            }
        }

        public string ToString(string format)
        {
            format = Regex.Replace(format, "dd", day.ToString("00"));
            format = Regex.Replace(format, "MM", month.ToString("00"));
            format = Regex.Replace(format, "yyyy", year.ToString("0000"), RegexOptions.IgnoreCase);
            format = Regex.Replace(format, "DD", weekArray[GetWeekNo(calendar.GetDayOfWeek(this)) - 1]);
            format = Regex.Replace(format, "ND", weekArray[GetWeekNo(dayOfWeek) - 1]);
            format = Regex.Replace(format, "NM", monthsArray[month - 1]);
            return format;
        }

        public override string ToString()
        {
            return string.Format("{0:D4}/{1:D2}/{2:D2}", year, month, day);
        }

        public override bool Equals(object obj)
        {
            if (obj is PersianDate)
            {
                return (PersianDate)obj == this;
            }
            return false;
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public static bool operator ==(PersianDate persianDate1, PersianDate persianDate2)
        {
            return persianDate1.Day == persianDate2.Day && persianDate1.Month == persianDate2.Month && persianDate1.Year == persianDate2.Year;
        }

        public static bool operator !=(PersianDate persianDate1, PersianDate persianDate2)
        {
            return persianDate1.Day != persianDate2.Day || persianDate1.Month != persianDate2.Month || persianDate1.Year != persianDate2.Year;
        }

        public static bool operator >(PersianDate persianDate1, PersianDate persianDate2)
        {
            return Compare2Date(persianDate1, persianDate2) == 1;
        }

        public static bool operator <(PersianDate persianDate1, PersianDate persianDate2)
        {
            return Compare2Date(persianDate1, persianDate2) == -1;
        }

        public static bool operator >=(PersianDate persianDate1, PersianDate persianDate2)
        {
            int num = Compare2Date(persianDate1, persianDate2);
            return num == 1 || num == 0;
        }

        public static bool operator <=(PersianDate persianDate1, PersianDate persianDate2)
        {
            int num = Compare2Date(persianDate1, persianDate2);
            return num == -1 || num == 0;
        }

        public static implicit operator DateTime(PersianDate persianDate)
        {
            if (ValidDate(persianDate))
            {
                return calendar.ToDateTime(persianDate.Year, persianDate.Month, persianDate.Day, 0, 0, 0, 0);
            }
            return DateTime.MinValue;
        }

        public static implicit operator PersianDate(DateTime date)
        {
            if (date.Equals(DateTime.MinValue))
            {
                return MinValue;
            }
            return Parse(date);
        }

        public int CompareTo(object obj)
        {
            if (!(obj is PersianDate))
            {
                new ArgumentException("obj is not PersianDate");
            }
            return CompareTo((PersianDate)obj);
        }

        public int CompareTo(PersianDate other)
        {
            return Compare2Date(this, other);
        }

        public int Compare(object x, object y)
        {
            if (!(x is PersianDate))
            {
                throw new ArgumentException("x is not PersianDate");
            }
            if (!(y is PersianDate))
            {
                throw new ArgumentException("y is not PersianDate");
            }
            return Compare2Date((PersianDate)x, (PersianDate)y);
        }

        public int Compare(PersianDate x, PersianDate y)
        {
            return Compare2Date(x, y);
        }

        public object Clone()
        {
            return (PersianDate)MemberwiseClone();
        }
    }

}