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
            bool instanceCountOne = false;
                using (System.Threading.Mutex Mutex = new System.Threading.Mutex(true, "Mutex", out instanceCountOne))
                {
                    if (instanceCountOne)
                    {
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

                        if (login.ShowDialog() == DialogResult.OK)
                        {
                            login.Dispose();
                            
                            Application.Run(new MainForm());
                           
                            Mutex.ReleaseMutex();
                        }
                        else
                            login.Dispose();
                       
                    }
                    else
                    {
                        MessageBox.Show("برنامه هم اکنون در حال اجرا می باشد");
                    }
                }
           
        }
      
        
    
    }
}
