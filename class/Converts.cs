
using System;
namespace Dentistry.Class
{
    public class Converts
    {
        private static string[] Literal20 = new string[]
        {
            "",
            "يك",
            "دو",
            "سه",
            "چهار",
            "پنج",
            "شش",
            "هفت",
            "هشت",
            "نه",
            "ده",
            "يازده",
            "دوازده",
            "سيزده",
            "چهارده",
            "پانزده",
            "شانزده",
            "هفده",
            "هجده",
            "نوزده"
        };
        private static string[] Literal100 = new string[]
        {
            "",
            "ده",
            "بيست",
            "سي",
            "چهل",
            "پنجاه",
            "شصت",
            "هفتاد",
            "هشتاد",
            "نود"
        };
        private static string[] Literal1000 = new string[]
        {
            "",
            "صد",
            "دويست",
            "سيصد",
            "چهارصد",
            "پانصد",
            "ششصد",
            "هفتصد",
            "هشتصد",
            "نهصد"
        };
        private static string[] GroupLiteral = new string[]
        {
            "",
            " هزار",
            " ميليون",
            " ميليارد",
            " تیلیارد"
        };
        public static string ToFarsiLiteral(ulong n)
        {
            uint[] array = new uint[5];
            string text = "";
            array[0] = (uint)(n % 1000uL);
            array[1] = (uint)(n % 1000000uL / 1000uL);
            array[2] = (uint)(n % 1000000000uL / 1000000uL);
            array[3] = (uint)(n % 1000000000000uL / 1000000000uL);
            array[4] = (uint)(n % 1000000000000000uL / 1000000000000uL);
            if (array[0] != 0u)
            {
                text = Converts.ToFarsiLiteral3(array[0]);
            }
            if (array[1] != 0u)
            {
                if (array[0] != 0u)
                {
                    text = " و " + text;
                }
                text = Converts.GroupLiteral[1] + text;
                text = Converts.ToFarsiLiteral3(array[1]) + text;
            }
            if (array[2] != 0u)
            {
                if (array[0] != 0u || array[1] != 0u)
                {
                    text = " و " + text;
                }
                text = Converts.GroupLiteral[2] + text;
                text = Converts.ToFarsiLiteral3(array[2]) + text;
            }
            if (array[3] != 0u)
            {
                if (array[0] != 0u || array[1] != 0u || array[2] != 0u)
                {
                    text = " و " + text;
                }
                text = Converts.GroupLiteral[3] + text;
                text = Converts.ToFarsiLiteral3(array[3]) + text;
            }
            if (array[4] != 0u)
            {
                if (array[0] != 0u || array[1] != 0u || array[2] != 0u || array[3] != 0u)
                {
                    text = " و " + text;
                }
                text = Converts.GroupLiteral[4] + text;
                text = Converts.ToFarsiLiteral3(array[4]) + text;
            }
            if (text == "")
            {
                text = "صفر";
            }
            return text;
        }
        public static string ToFarsiLiteral(uint n)
        {
            uint[] array = new uint[4];
            string text = "";
            array[0] = n % 1000u;
            array[1] = n % 1000000u / 1000u;
            array[2] = n % 1000000000u / 1000000u;
            array[3] = n / 1000000000u;
            if (array[0] != 0u)
            {
                text = Converts.ToFarsiLiteral3(array[0]);
            }
            if (array[1] != 0u)
            {
                if (array[0] != 0u)
                {
                    text = " و " + text;
                }
                text = Converts.GroupLiteral[1] + text;
                text = Converts.ToFarsiLiteral3(array[1]) + text;
            }
            if (array[2] != 0u)
            {
                if (array[0] != 0u || array[1] != 0u)
                {
                    text = " و " + text;
                }
                text = Converts.GroupLiteral[2] + text;
                text = Converts.ToFarsiLiteral3(array[2]) + text;
            }
            if (array[3] != 0u)
            {
                if (array[0] != 0u || array[1] != 0u || array[2] != 0u)
                {
                    text = " و " + text;
                }
                text = Converts.GroupLiteral[3] + text;
                text = Converts.ToFarsiLiteral3(array[3]) + text;
            }
            if (text == "")
            {
                text = "صفر";
            }
            return text;
        }
        private static string ToFarsiLiteral3(uint n)
        {
            string text = "";
            if (n % 20u != 0u)
            {
                if (text != "")
                {
                    text = " " + text;
                }
                if (n % 100u < 20u)
                {
                    text = Converts.Literal20[(int)((UIntPtr)(n % 20u))] + text;
                    n -= n % 20u;
                }
                else
                {
                    text = Converts.Literal20[(int)((UIntPtr)(n % 10u))] + text;
                    n -= n % 10u;
                }
            }
            if (n % 100u != 0u)
            {
                if (text != "")
                {
                    text = " و " + text;
                }
                text = Converts.Literal100[(int)((UIntPtr)(n % 100u / 10u))] + text;
                n -= n % 100u;
            }
            if (n % 1000u != 0u)
            {
                if (text != "")
                {
                    text = " و " + text;
                }
                text = Converts.Literal1000[(int)((UIntPtr)(n % 1000u / 100u))] + text;
                n -= n % 1000u;
            }
            return text;
        }
        public static string ToCurrency(int number, char separator)
        {
            string text = number.ToString();
            int num = (number > 0) ? 0 : 1;
            for (int i = text.Length - 3; i > num; i -= 3)
            {
                text = text.Insert(i, separator.ToString());
            }
            return text;
        }
        public static string ToCurrency(long number, char separator)
        {
            string text = number.ToString();
            int num = (number > 0L) ? 0 : 1;
            for (int i = text.Length - 3; i > num; i -= 3)
            {
                text = text.Insert(i, separator.ToString());
            }
            return text;
        }
    }
}
