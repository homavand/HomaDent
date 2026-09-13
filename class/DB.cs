using FarsiMessageBox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry
{
    internal class DB
    {

        public static string DbSource = "";
        public static string Access = "";
        public static string ConnectionString = "";
        private static SQLiteConnection connection;

        static void ReadConfig()
        {
            try
            {
                using (FileStream fs = new FileStream(Application.StartupPath + "\\Config.dat", FileMode.Open, FileAccess.Read))
                {

                    StreamReader sr = new StreamReader(fs);
                    string text = sr.ReadToEnd();
                    string[] lines = text.Split('\n');

                    DbSource = lines[0].TrimEnd('\r');
                    Access = lines[1].TrimEnd('\r');
                    ConnectionString = lines[2].TrimEnd('\r');
                }
            }
            catch (Exception)
            {
            }

        }

        
        public static SQLiteConnection GetConnection()
        {
            try
            {
                ReadConfig();

                // 1. تنظیم DataDirectory به ریشه پروژه (اگر فایل در ریشه است)
                string projectDirectory = Path.GetFullPath(AppDomain.CurrentDomain.BaseDirectory);
                AppDomain.CurrentDomain.SetData("DataDirectory", projectDirectory);

                // 2. دریافت مسیر واقعی
                string dataDir = AppDomain.CurrentDomain.GetData("DataDirectory").ToString();
                string dbPath = Path.Combine(dataDir, "Database", "Dental.db");

                // 3. بررسی وجود فایل
                if (!File.Exists(dbPath))
                {
                    throw new FileNotFoundException($"فایل دیتابیس در مسیر {dbPath} پیدا نشد!");
                }

                Console.WriteLine($"✅ دیتابیس پیدا شد: {dbPath}");

                // 4. ایجاد Connection
                var conStr = ConfigurationManager.ConnectionStrings["DentalContext"].ConnectionString;
                connection = new SQLiteConnection(conStr);

                return connection;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"❌ خطا: {ex.Message}");
                throw;
            }
        }


    }
}
