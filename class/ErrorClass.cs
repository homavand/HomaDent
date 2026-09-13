using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace Dentistry
{

    public class ErrorClass 
    {


        public static  string filePath = Application.StartupPath + "\\Error";

        #region WriteErrorsToFile
        public static void WriteErrorsToFile(string errorForm , string errorFunction , string errorText, DateTime errorDate)
        {
            FileStream file = new FileStream(filePath , FileMode.Append, FileAccess.Write);
            StreamWriter fr = new StreamWriter(file);

            fr.Write("Error Form: ");
            fr.WriteLine(errorForm);

            fr.Write("Error Function: ");
            fr.WriteLine(errorFunction);

            System.Globalization.PersianCalendar date = new System.Globalization.PersianCalendar();
            string error_Date =  string.Format("{0}/{1}/{2}", date.GetYear(errorDate), date.GetMonth(errorDate), date.GetDayOfMonth(errorDate));
            fr.Write("Error Date: ");
            fr.WriteLine(error_Date);

            fr.Write("Error Message: ");
            fr.Write(errorText);
          
            fr.WriteLine();
            fr.WriteLine("===================================================");
            fr.WriteLine();
            fr.Close();
            file.Close();

            
        }
        #endregion

     


    }
}
