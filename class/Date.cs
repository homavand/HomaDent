using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DNTPersianUtils.Core;

namespace Dentistry.Class
{
    class Date
    {
        public static string Format(string date, char separator='/')
        {
            if (date.IndexOf(separator, 5) == 6)
            {
                date = date.Insert(5, "0");
            }
            if (date.Length == 9)
            {
                date = date.Insert(8, "0");
            }
            return date;
        }
        public static bool IsLeapYear(int year)
        {
            return (year + 1) % 4 == 0;
        }
        public static bool IsLeapYear(string year)
        {
            return Regex.IsMatch(year, "^\\d{4}$") && (int.Parse(year) + 1) % 4 == 0;
        }
        public static string GetSolar(char separator = '/')
        {
            return Date.ToSolar(string.Concat(new string[]
            {
                DateTime.Now.Year.ToString(),
                separator.ToString(),
                DateTime.Now.Month.ToString(),
                separator.ToString(),
                DateTime.Now.Day.ToString()
            }), separator);
        }
        public static string GetChristian(char separator = '/')
        {
            return Date.Format(string.Concat(new string[]
            {
                DateTime.Now.Year.ToString(),
                separator.ToString(),
                DateTime.Now.Month.ToString(),
                separator.ToString(),
                DateTime.Now.Day.ToString()
            }), separator);
        }
        public static string ToSolar(string date, char separator = '/')
        {
            date = date.Replace(separator, '/');
            string pattern = "^\\d{4}/\\d{1,2}/\\d{1,2}$";
            string result;
            if (!Regex.IsMatch(date, pattern))
            {
                result = "";
            }
            else
            {
                int[] array = new int[]
                {
                    0,
                    31,
                    28,
                    31,
                    30,
                    31,
                    30,
                    31,
                    31,
                    30,
                    31,
                    30,
                    31
                };
                string[] array2 = date.Split(new char[]
                {
                    '/'
                });
                int num = int.Parse(array2[0]);
                int num2 = int.Parse(array2[1]);
                int num3 = int.Parse(array2[2]);
                if (num % 4 == 0)
                {
                    array[2] = 29;
                }
                int num4 = num3;
                for (int i = 1; i < num2; i++)
                {
                    num4 += array[i];
                }
                int num5;
                if (num4 <= 79)
                {
                    num5 = num - 622;
                }
                else
                {
                    num5 = num - 621;
                }
                int j;
                if (num4 > 79)
                {
                    j = num4 - 79;
                }
                else
                {
                    if ((num5 + 1) % 4 == 0)
                    {
                        j = num4 + 287;
                    }
                    else
                    {
                        j = num4 + 286;
                    }
                }
                int num6;
                if (j <= 186)
                {
                    num6 = 1;
                    while (j > 31)
                    {
                        j -= 31;
                        num6++;
                    }
                }
                else
                {
                    j -= 186;
                    num6 = 7;
                    while (j > 30)
                    {
                        j -= 30;
                        num6++;
                    }
                }
                int num7 = j;
                result = Date.Format(string.Concat(new string[]
                {
                    num5.ToString(),
                    separator.ToString(),
                    num6.ToString(),
                    separator.ToString(),
                    num7.ToString()
                }), separator);
            }
            return result;
        }
        public static bool IsValid(string date, char separator='/')
        {
            date = date.Replace(separator, '/');
            bool result;
            if (Regex.IsMatch(date, "^\\d{4}/\\d{1,2}/\\d{1,2}$"))
            {
                string[] array = date.Split(new char[]
                {
                    '/'
                });
                int num = int.Parse(array[2]);
                int num2 = int.Parse(array[1]);
                int year = int.Parse(array[0]);
                if (num2 > 12 || num2 < 1 || num > 31 || num < 1)
                {
                    result = false;
                }
                else
                {
                    if (num2 == 12)
                    {
                        if (Date.IsLeapYear(year) && num > 30)
                        {
                            result = false;
                            return result;
                        }
                        if (!Date.IsLeapYear(year) && num > 29)
                        {
                            result = false;
                            return result;
                        }
                    }
                    result = ((num2 <= 6 || num <= 30) && (num2 > 6 || num <= 31));
                }
            }
            else
            {
                result = false;
            }
            return result;
        }
        public static string ToChristian(string date, char separator='/')
        {
            
            date = date.Replace(separator, '/');
            string result;
            if (!Regex.IsMatch(date, "^\\d{4}/\\d{1,2}/\\d{1,2}$"))
            {
                result = "";
            }
            else
            {
                int[] array = new int[]
                {
                    0,
                    31,
                    28,
                    31,
                    30,
                    31,
                    30,
                    31,
                    31,
                    30,
                    31,
                    30,
                    31
                };
                string[] array2 = date.Split(new char[]
                {
                    '/'
                });
                int num  = int.Parse(array2[0]);
                int num2 = int.Parse(array2[1]);
                int num3 = int.Parse(array2[2]);
                int num4 = num3;
                for (int i = 1; i < num2; i++)
                {
                    if (i < 7)
                    {
                        num4 += 31;
                    }
                    else
                    {
                        num4 += 30;
                    }
                }
                num4 += 79;
                num += 621;
                int num5;
                if (num % 4 == 0)
                {
                    num5 = 1;
                }
                else
                {
                    num5 = 0;
                }
                if (num4 > num5 + 365)
                {
                    num4 = num4 - 365 - num5;
                    num++;
                }
                if (num % 4 == 0)
                {
                    num5 = 1;
                }
                else
                {
                    num5 = 0;
                }
                num2 = 1;
                for (int i = 1; i < 12; i++)
                {
                    num3 = array[i];
                    if (i == 2)
                    {
                        num3 += num5;
                    }
                    if (num4 > num3)
                    {
                        num4 -= num3;
                        num2 = i + 1;
                    }
                    else
                    {
                        i = 12;
                    }
                }
                num3 = num4;
                result = Date.Format(string.Concat(new string[]
                {
                    num.ToString(),
                    separator.ToString(),
                    num2.ToString(),
                    separator.ToString(),
                    num3.ToString()
                }), separator);
            }
            return result;
        }
        public static string ToChristianByTime(string date, bool? hasTime = false)
        {
            var time = "00:00";

            if (hasTime.Value)
                time = DateTime.Now.ToString("HH:mm");
            
            return string.Format("{0} {1}", date, time).ToGregorianDateTime().Value.ToString("yyyy/MM/dd HH:mm");
        }

        public static string GetSolarDayName()
        {
            string result = "";
            string text = DateTime.Now.DayOfWeek.ToString();
            switch (text)
            {
                case "Saturday":
                    result = "شنبه";
                    break;
                case "Sunday":
                    result = "يكشنبه";
                    break;
                case "Monday":
                    result = "دوشنبه";
                    break;
                case "Tuesday":
                    result = "سه شنبه";
                    break;
                case "Wednesday":
                    result = "چهارشنبه";
                    break;
                case "Thursday":
                    result = "پنجشنبه";
                    break;
                case "Friday":
                    result = "جمعه";
                    break;
            }
            return result;
        }
        public static int GetSolarDay()
        {
            string text = Date.GetSolar('/');
            text = text.Substring(8, 2);
            return int.Parse(text);
        }
        public static int GetSolarDay(string ChristianDate, char separator = '/')
        {
            string text = Date.ToSolar(ChristianDate, separator);
            text = text.Substring(8, 2);
            return int.Parse(text);
        }
        public static int GetSolarYear()
        {
            string text = Date.GetSolar('/');
            text = text.Substring(0, 4);
            return int.Parse(text);
        }
        public static string GetSolarMonthName()
        {
            string result = "";
            string text = Date.GetSolar('/');
            text = text.Substring(5, 2);
            switch (int.Parse(text))
            {
                case 1:
                    result = "فروردين";
                    break;
                case 2:
                    result = "ارديبهشت";
                    break;
                case 3:
                    result = "خرداد";
                    break;
                case 4:
                    result = "تير";
                    break;
                case 5:
                    result = "مرداد";
                    break;
                case 6:
                    result = "شهريور";
                    break;
                case 7:
                    result = "مهر";
                    break;
                case 8:
                    result = "آبان";
                    break;
                case 9:
                    result = "آذر";
                    break;
                case 10:
                    result = "دي";
                    break;
                case 11:
                    result = "بهمن";
                    break;
                case 12:
                    result = "اسفند";
                    break;
            }
            return result;
        }
    }
}
