using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Dentistry.Class
{
    [Serializable]
    public class ErrorObject
    {

        private string _errorForm = string.Empty;
        private string _errormMessage= string.Empty;
        private int _errorLline = 0;
        private DateTime _errorTime;

        public ErrorObject(string errorForm , string errorMessage , int errorLine , DateTime errorTime)
        {
            ErrorForm = errorForm;
            ErrorMessage = errorMessage;
            ErrorLine = errorLine;
            ErrorTIme = errorTime;
        }

        public string  ErrorForm
        {
            get { return this._errorForm; }
            set { this._errorForm = value ;}
        }

        public string ErrorMessage
        {
            get { return this._errormMessage; }
            set { this._errormMessage = value; }
        }

        public int ErrorLine
        {
            get { return this._errorLline; }
            set { this._errorLline = value; }
        }
        public DateTime ErrorTIme
        {
            get { return this._errorTime; }
            set { this._errorTime = value; }
        }

        public string ErrorSolarTime
        {
            get
            {
                System.Globalization.PersianCalendar date = new System.Globalization.PersianCalendar();
                return string.Format("{0}/{1}/{2}",date.GetYear(this._errorTime),date.GetMonth(this._errorTime),date.GetDayOfMonth(this._errorTime));
            }
        }


     
    }
}
