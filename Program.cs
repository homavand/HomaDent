using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Threading;
using System.IO;
using System.Data.SqlClient;
using FarsiMessageBox;
using System.Data;
using System.Net;



namespace Dentistry
{

    static class Program
    {
        /// <summary>
        /// Product Name:     Dentistry
        /// Version:          1.0.0.0
        /// "Develop by:      Mohammad Babaha"
        /// Copyright ©  2020 
        /// Address:          
        /// Email:            homavand.co@Gmail.com
        /// </summary>


        static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            Exception error = e.Exception;
            string errorMsg = error.Message + "\n\nStack Trace:\n" + error.StackTrace;
            MessageBox.Show(errorMsg, "خطا");
        }

        static void Application_ApplicationExit(object sender, EventArgs e)
        {

        }



        [STAThread]
        static void Main()
        {
            // TEMPORARY DIAGNOSTIC - logs every exception thrown anywhere in
            // the process (even ones caught internally and never shown to
            // the user) with a timestamp and stack trace, to
            // C:\temp\firstchance_exceptions.txt. Remove once done
            // diagnosing the startup slowness - this adds real overhead per
            // exception and is not meant to ship.
            AppDomain.CurrentDomain.FirstChanceException += (sender, e) =>
            {
                try
                {
                    File.AppendAllText(@"C:\temp\firstchance_exceptions.txt",
                        DateTime.Now.ToString("HH:mm:ss.fff") + " | " +
                        e.Exception.GetType().FullName + " | " +
                        e.Exception.Message + "\r\n" +
                        e.Exception.StackTrace + "\r\n\r\n");
                }
                catch { /* never let logging itself crash the app */ }
            };

            bool instanceCountOne = false;
            using (System.Threading.Mutex Mutex = new System.Threading.Mutex(true, "Mutex", out instanceCountOne))
            {
                if (!instanceCountOne)
                {
                    MessageBox.Show("برنامه هم اکنون در حال اجرا می باشد");
                    return;
                }

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);
                Application.ApplicationExit += new EventHandler(Application_ApplicationExit);

                DB.GetConnection();

                //string key = Publics.PSW.ToString();
                //if (DB.Access !=  key)
                //    Application.Run(new AccessForm());


                //Application.Run(new PatientsDocs());
                //return;
                //Application.Run(new VisitsList());
                //return;

                UserLogin login = new UserLogin();

                try
                {
                    if (login.ShowDialog() != DialogResult.OK)
                        return;

                    login.Dispose();

                    if (!Dentistry.AppInfo.Load())
                    {
                        MessageBox.Show(
                            "خطا در بارگذاری اطلاعات مطب. برنامه بسته می‌شود.",
                            "خطا",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);
                        return;
                    }

                    Application.Run(new MainForm());
                }
                finally
                {
                    login.Dispose();
                    Mutex.ReleaseMutex();
                }
            }
        }



    }
}