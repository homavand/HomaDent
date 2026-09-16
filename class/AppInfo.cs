using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Dentistry
{
    public static class AppInfo
    {
        private static readonly object _lock = new object();
        private static bool _isLoaded = false;

        public static int DefaultDoctorId { get; private set; }
        // فیلدهای بیشتر Office رو همین‌جا اضافه کن، مثلاً:
        // public static string OfficeName { get; private set; }
        // public static string OfficePhone { get; private set; }

        public static bool IsLoaded => _isLoaded;

        /// <summary>
        /// باید قبل از Application.Run در Program.cs صدا زده بشه.
        /// در صورت شکست، false برمی‌گردونه تا خود Program تصمیم بگیره.
        /// </summary>
        public static bool Load()
        {
            lock (_lock)
            {
                try
                {
                    dynamic sObj = new System.Dynamic.ExpandoObject();
                    JsonResponse<dynamic> result = Dentistry.DataProvider.GetOfficeInfoX(sObj);

                    if (result == null || result.Success == false)
                        return false;

                    var dd = result.Data;
                    if (Enumerable.Count(dd) < 1)
                        return false;

                    var obj = dd[0];
                    if (obj == null)
                        return false;

                    DefaultDoctorId = obj.DefaultDoctorId != null
                        ? Publics.GetPropertyValue<int>(obj, "DefaultDoctorId")
                        : 0;

                    // بقیه فیلدها رو همینجا از obj بخون...

                    _isLoaded = true;
                    return true;
                }
                catch (Exception)
                {
                    _isLoaded = false;
                    return false;
                    // یا اگه لاگ داری: Logger.LogError(ex);
                }
            }
        }

        /// <summary>
        /// بعد از هر تغییر در تنظیمات Office (مثلاً از فرم تنظیمات) صدا زده بشه.
        /// </summary>
        public static bool Refresh()
        {
            return Load();
        }
    }
}