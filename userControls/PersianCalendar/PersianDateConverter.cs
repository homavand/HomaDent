
using System;
using System.ComponentModel;
using System.Globalization;

namespace Dentistry.UserControls
{
    public class PersianDateConverter : ExpandableObjectConverter
    {
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value is string)
            {
                try
                {
                    if (value == null || value.ToString().Length != 0)
                    {
                        string[] array = value.ToString().Split('/');
                        int year = Convert.ToInt32(array[0]);
                        int month = Convert.ToInt32(array[1]);
                        int day = Convert.ToInt32(array[2]);
                        return new PersianDate(year, month, day);
                    }
                    return PersianDate.MinValue;
                }
                catch (Exception ex)
                {
                    throw new FormatException(ex.Message);
                }
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value is PersianDate && destinationType == typeof(string))
            {
                return ((PersianDate)value).ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }
    }
}