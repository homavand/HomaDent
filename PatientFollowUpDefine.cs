using FarsiMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dentistry
{
    public partial class PatientFollowUpDefine : Form
    {
        public int PatientId = 0;
        public int DoctorId = 0;
        string ActionType = "";
        public PatientFollowUpDefine(int patientId, string patientName, int doctorId)
        {
            InitializeComponent();
            this.ActionType = "New";
            this.PatientId = patientId;
            this.DoctorId = doctorId;
            patientNameTxt.Text = patientName;
            // this.FillDataGridView();
        }

        private void FormFollowUp_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();
            this.FillDataGridView();
        }


        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            var result = DataProvider.GetDoctorsX(sObj);
            if (result == null || result.Success == false)
                return;

            var dd = result.Data;
            var doctorList = (dd as IEnumerable<dynamic>)
                                        .Select(i =>
                                        new
                                        {
                                            Id = (int)i.DoctorId,
                                            Title = (string)i.FullName
                                        }).ToList();

            var list = Publics.AddDefaultItemToComboDynamicList(doctorList);


            this.doctorCbo.DataSource = list;
            this.doctorCbo.ValueMember = "Id";
            this.doctorCbo.DisplayMember = "Title";
            if (this.DoctorId > 0)
            {            
                this.doctorCbo.SelectedIndex = Publics.GetComboIndex(this.doctorCbo, this.DoctorId);
            }
        }
        #endregion

        #region FilldataGridView
        private void FillDataGridView()
        {
           
            dynamic sObj = new System.Dynamic.ExpandoObject();            
            sObj.PatientId = this.PatientId;
            //sObj.DoctorId = Convert.ToInt32(doctorCbo.SelectedValue);
            //sObj.FromDate = new DateTime(DateTime.Now.Year , DateTime.Now.Month, DateTime.Now.Day,0,0,0);
            //sObj.ToDate = DateTime.Parse(Class.Date.ToChristianByTime(followUpDateTxt.Value.ToString())); 
            sObj.IsDeleted = false;

            var result = DataProvider.GetPatientFollowUpsX(sObj);
            if (result != null && result.Success == true && result.Data != null)
            {
                var dd = result.Data;
                IEnumerable<dynamic> list = dd != null && dd != null && (Enumerable.Count(dd) > 0) 
                                            ? (dd as IEnumerable<dynamic>)
                                                .OrderByDescending(i => i.Date)
                                                .Select(i => new
                                                    {
                                                        i.Id,
                                                        i.Comment,
                                                        i.SolarDate,
                                                        i.SolarFollowUpDate,
                                                        i.IsDeleted
                                                }
                                                )
                                                .ToList() 
                                            : Enumerable.Empty<dynamic>();
                dataGridViewFollowUp.DataSource = list;
            }
            
        }
        #endregion

       
      
        private void ComboBoxAZDate_ValueChanged(object sender, Dentistry.UserControls.PersianMonthCalendarEventArgs e)
        {
            
            if (dataGridViewFollowUp.Rows.Count > 0)
            {
            
            }
            else
            {
             
            }
            DateTime followUpDate = DateTime.Parse(Class.Date.ToChristianByTime(followUpDateTxt.Value.ToString()));
            TimeSpan ts = followUpDate.Date - DateTime.Now.Date;
            int totalDay = (int)ts.TotalDays;
            commentTxt.Text = string.Format(" بیمار نیاز به {0} روز استراحت پزشکی دارد", totalDay.ToString());

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
           
            if (this.doctorCbo.SelectedValue.ToString() == "-1")
                return;
            if (DateTime.Parse(Class.Date.ToChristianByTime(followUpDateTxt.Value.ToString())) <= DateTime.Now)
            {
                FarsiMessageBox.FMessageBox.Show("تاریخ انتخاب شده باید بزرگتر از تاریخ امروز باشد", AppConfigs.strErrorCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Error);
                return;
            }

            if (dataGridViewFollowUp.Rows.Count > 0)
            {
                if (FarsiMessageBox.FMessageBox.Show("کاربر گرامی با تایید عملیات ، وقت های ویزیت کاربر بین تاریخ انتخاب شده حذف خواهند شد.آیا برای ادامه مطمئن هستید؟","هشدار",FMessageBoxButtons.OKCancel,FMessageBoxIcons.Question,FMessageBoxDefaultButtons.Button1) != System.Windows.Forms.DialogResult.OK)
                {
                    return;
                }
                else
                {
                    
                }
            }

           
            int doctorId = Convert.ToInt32(this.doctorCbo.SelectedValue);

            dynamic iObj = new ExpandoObject();
            iObj.ActionType = this.ActionType;
            iObj.DoctorId = doctorId;
            iObj.PatientId = this.PatientId;
            iObj.Comment = commentTxt.Text;
            iObj.Date =  DateTime.Now;
            iObj.FollowUpDate = Class.Date.ToChristianByTime(followUpDateTxt.Value.ToString());
            iObj.IsDeleted = false;

            JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientFollowUpsX(iObj);
            if (result != null && result.Success == true && result.Data != null)
            {
                FMessageBox.Show("اطلاعات با موفقیت ثبت شدند", "پیام", FMessageBoxButtons.OK, FMessageBoxIcons.Information, FMessageBoxDefaultButtons.Button1);
                this.FillDataGridView();
            }
            //this.textBoxForje.Clear();
        }

      
    }
}
