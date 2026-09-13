using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistry
{
    internal class Constant
    {
        // (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>) : Enumerable.Empty<dynamic>()

        public static int FreeInsurerId = 0;
        public static string FreeInsurerTitle = "آزاد";
        //کد بیمه اتباع خارجی
        public static int ForeginInsurerId = -1;
        public static Guid AdminUserId = new Guid("9635211e-7e44-45e4-b122-cdae8c05d559");
        public static Guid PermissionUserId = new Guid("af33d9b3-a08b-4f64-ab93-0c543f47046d");
        public static Guid پزشک_بیمارستان = new Guid("F4631595-69DE-45D4-9F6F-35510B918D8C");
        public static Guid پزشک_انجام_دهنده = new Guid("E5E397C0-B5F5-485A-A596-FE7382F76EA0");

        public static string NoResult = "خطا در اجرای دستور !";
        public static string NoData = "داده یی وجود نداره !";
        public static string NoInsurancePriceRecordForService = "قیمتی برای بیمه مورد نظر ثبت نشده است";
        public static string NoService = "خدمتی انتخاب نشده است";
    }
}
