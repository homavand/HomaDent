using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Security.Principal;
using System.Data;
using System.Data.SqlClient;

using FarsiMessageBox;
using System.Drawing;
using System.Xml;

namespace Dentistry
{
    class AppConfigs
    {
       
        public static int SelectedPatientId = 0;
        public static int SelectedDoctorId = -1;
        public static string ConnectionString;
        public static string ServerIP;
        public static int CurrentUserId = 0;
        public static string CurrentUserName = string.Empty;
        public static dynamic CurrentUserPermissions = null;
        public static bool IsUser = true;
        public static bool IsAdd = true;
        public static bool IsEdit = true;
        public static bool IsDelete = true;
        public static bool IsShow = true;
        public static string BackupPath = string.Empty;
        public static string strUnhandledExceptionMessage= "خروج از برنامه به علت خطا .";
        public static string strAreYouSure_Cancel = "در صورت انصراف تغییرات ذخیره نخواهد شد. آیا اطمینان دارید ؟";
        public static string strRegister = "ثبت اطلاعات ...";
        public static string strExclamation = "هشدار ...";
        public static string strIsDeActiveUser = ".حساب کاربری شما غیرفعال است";
        public static string strAddBlackList = "آیا از انتقال بیمار به لیست بیماران غیرفعال مطمئن هستید؟";
        public static string strCaptionInformation = "توجه";
        public static string strStoredProcedureError = " خطا در درج اطلاعات";
        public static string strAreYouSure_Delete = "آیا از حذف سطر جاری اطمینان دارید ؟";
        public static string strErrorCaption = "خطا ";
        public static string strStarField = "لطفا داده های فیلدهای ستاره دار را وارد کنید";
        public static string strPermission = "شما مجوز دسترسی به  این اقدام را ندارید";
        public static string strNoRow = "سطری با این مشخصات وجود ندارد";
        public static string strDuplicate = "سطری با این مشخصات وجود دارد";
        public static string strDuplicateColor = "رنگ انتخاب شده تکراری می باشد";
        public static string strDuplicatePersonel = "این پرسنل حساب کاربری دارد";
        public static string strDuplicateUser = "این نام کاربری قبلا ثبت شده است";
        public static string strDuplicate1 = "سطری با این مشخصات وجود دارد \n آیا مایل به افزودن این سطر هستید؟";
        public static string strDependencyDelete = "این گزینه مورد استفاده قرار گرفته و امکان حذف وجود ندارد";
        public static string strZeroItemDelete = "  امکان حذف این گزینه وجود ندارد";
        public static string strBackUpQuestion = "کاربر گرامی آیا مایلید از اطلاعات , فایل پشتیبان تهیه شود؟";
        public static string strRemoveFromBlackListAndAddToIllsList = " آیا میخواهید این بیماراز لیست بیماران غیر فعال حذف" + "\n" + " و به لیست بیماران فعال افزوده شود؟ ";
        public static string strSelectInsurer = "لطفا سازمان بیمه گر را انتخاب کنید";
        public static string strSuccessRegister = "اطلاعات با موفقیت ثبت شد";
        /// <summary>
        /// Default Values For Reports
        /// </summary>
        public static string DoctorName, NezamPezeshki, PhoneNumber, OfficeAddress,ToDayDate;









      




    }
}
