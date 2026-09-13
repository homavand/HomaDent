using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Linq;

namespace Dentistry
{
    public partial class OfficeSetting : Form
    {

        public OfficeSetting()
        {
            InitializeComponent();
            this.LoadFormInit();
            this.FillControls();
        }

        #region LoadFormInit
        private void LoadFormInit()
        {

            dynamic sObj = new
            {
                IsInsuranceBookletType = true,
                IsMaritalStatus = true,
                IsEducationLevel = true,
                IsNationality = true,
            };
            var result = Dentistry.DataProvider.LoadFormInitInfo(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;

            if (dd == null)
                return;

            if (dd.MaritalStatus != null)
            {
                var maritalStatus = (Enumerable.Count(dd.MaritalStatus) > 0) ? (dd.MaritalStatus as IEnumerable<dynamic>).Select(i => i).ToList() : null;
                this.MaritalStatusCbo.DataSource = maritalStatus;
                this.MaritalStatusCbo.ValueMember = "Id";
                this.MaritalStatusCbo.DisplayMember = "Title";
            }

            if (dd.EducationLevel != null)
            {
                var educationLevel = (Enumerable.Count(dd.EducationLevel) > 0) ? (dd.EducationLevel as IEnumerable<dynamic>).Select(i => i).ToList() : null;
                this.EducationLevelCbo.DataSource = educationLevel;
                this.EducationLevelCbo.ValueMember = "Id";
                this.EducationLevelCbo.DisplayMember = "Title";
            }

            if (dd.Nationality != null)
            {
                var nationality = (Enumerable.Count(dd.Nationality) > 0) ? (dd.Nationality as IEnumerable<dynamic>).Select(i => i).ToList() : null;
                this.NationalityCbo.DataSource = nationality;
                this.NationalityCbo.ValueMember = "Id";
                this.NationalityCbo.DisplayMember = "Title";

                this.NationalityCbo.SelectedIndex = 1;
            }

            ////////////////////////////////////////////////////////////////////////////////////////

            sObj = new System.Dynamic.ExpandoObject();
            result = DataProvider.GetDoctorsX(sObj);
            if (result == null || result.Success == false)
                return;

            dd = result.Data;
            var doctorList = (dd as IEnumerable<dynamic>)
                                        .Select(i =>
                                        new
                                        {
                                            Id = (int)i.DoctorId,
                                            Title = (string)i.FullName
                                        }).ToList();

            var doctors = Publics.AddDefaultItemToComboDynamicList(doctorList);

            if (doctors != null)
            {
                this.DoctorCbo.DataSource = doctors;
                this.DoctorCbo.ValueMember = "Id";
                this.DoctorCbo.DisplayMember = "Title";
            
            }


            sObj = new { };
            result = Dentistry.DataProvider.GetInsurersX(sObj);
            dd = result != null && result.Data != null ? result.Data : null;

            IEnumerable<dynamic> insurerList = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i =>
                new
                {
                    Id = i.InsurerId,
                    Title = i.InsurerTitle,
                }
            ).OrderBy(i => i.Id).ToList() : Enumerable.Empty<dynamic>();

            var list = Publics.AddDefaultItemToComboDynamicList(insurerList);

            this.BasicInsurerCbo.DataSource = list;
            this.BasicInsurerCbo.ValueMember = "Id";
            this.BasicInsurerCbo.DisplayMember = "Title";





        }
        #endregion

        #region FillControls
        private void FillControls()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            JsonResponse<dynamic> result = Dentistry.DataProvider.GetOfficeInfoX(sObj);

            if (result == null || result.Success == false)
                return;
            var dd = result.Data;
           
            int count = System.Linq.Enumerable.Count(dd);
            if (count < 1)
                return;
            var obj = dd[0] ;

            if (obj == null)
                return;

            this.OfficeNameTxt.Text = obj.OfficeName;
            this.DocterNameTxt.Text = obj.DoctorName;
            this.OfficeCodeTxt.Text = obj.OfficeCode;               
            this.NezamPezeshkiTxt.Text = obj.NezamPezeshki;
            this.PhoneNumberTxt.Text    = obj.PhoneNumber;
            this.OfficeAddressTxt.Text  = obj.OfficeAddress;
            if (obj.Email != null)
                this.EmailTxt.Text = obj.Email;
            if (obj.Website != null)
                this.WebSiteTxt.Text = obj.Website;

            if (obj.OfficeType != null )
            {
                int officeType = Convert.ToInt32(obj.OfficeType);

                if (officeType == 1)
                    this.OfficeTypeRdo1.Checked = true;
                else if (officeType == 2)
                    this.OfficeTypeRdo2.Checked = true;
            }

            if (obj.DefaultDoctorId != null)
            {
                var defaultDoctorId = Publics.GetPropertyValue<int>(obj, "DefaultDoctorId");
                this.DoctorCbo.SelectedIndex = Publics.GetComboIndex(this.DoctorCbo, defaultDoctorId);
            }
                
            if (obj.DefaultBasicInsurerId != null)
            {
                var defaultBasicInsurerId = Publics.GetPropertyValue<int>(obj, "DefaultBasicInsurerId");
                this.BasicInsurerCbo.SelectedIndex = Publics.GetComboIndex(this.BasicInsurerCbo, defaultBasicInsurerId);
            }
               
            if (obj.DefaultMaritalStatusId != null)
            {
                var defaultMaritalStatusId = Publics.GetPropertyValue<int>(obj, "DefaultMaritalStatusId");
                this.MaritalStatusCbo.SelectedIndex = Publics.GetComboIndex(this.MaritalStatusCbo, defaultMaritalStatusId);
            }

            if (obj.DefaultEducationLevelId != null)
            {
                var defaultEducationLevelId = Publics.GetPropertyValue<int>(obj, "DefaultEducationLevelId");
                this.EducationLevelCbo.SelectedIndex = Publics.GetComboIndex(this.EducationLevelCbo, defaultEducationLevelId);
            }
               
            if (obj.DefaultNationalityId != null)
            {
                var defaultNationalityId = Publics.GetPropertyValue<int>(obj, "DefaultNationalityId");
                this.NationalityCbo.SelectedIndex = Publics.GetComboIndex(this.NationalityCbo, defaultNationalityId);
            }              
            
        }
        #endregion 

        #region buttonOk_Click
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_اطلاعات_مطب_ثبت_اطلاعات_مطب) == false)
                return;

            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.ActionType = "Edit";
            sObj.Id = 1;
            sObj.OfficeName = this.OfficeNameTxt.Text;
            sObj.DoctorName = this.DocterNameTxt.Text;
            sObj.OfficeCode = this.OfficeCodeTxt.Text; ;
            sObj.OfficeType = this.OfficeTypeRdo1.Checked == true ? 1 : 2 ;
            sObj.NezamPezeshki = this.NezamPezeshkiTxt.Text;
            sObj.PhoneNumber = this.PhoneNumberTxt.Text;
            sObj.OfficeAddress = this.OfficeAddressTxt.Text; 
            sObj.Email = this.EmailTxt.Text;
            sObj.Website = this.WebSiteTxt.Text;

            if (this.DoctorCbo.SelectedValue != null && this.DoctorCbo.SelectedIndex > 0)
                sObj.DefaultDoctorId = Convert.ToInt32(this.DoctorCbo.SelectedValue);
            if (this.BasicInsurerCbo.SelectedValue != null && this.BasicInsurerCbo.SelectedIndex > 0)
                sObj.DefaultBasicInsurerId = Convert.ToInt32(this.BasicInsurerCbo.SelectedValue);
            if (this.MaritalStatusCbo.SelectedValue != null && this.MaritalStatusCbo.SelectedIndex > 0)
                sObj.DefaultMaritalStatusId = Convert.ToInt32(this.MaritalStatusCbo.SelectedValue);
            if (this.EducationLevelCbo.SelectedValue != null && this.EducationLevelCbo.SelectedIndex > 0)
                sObj.DefaultEducationLevelId = Convert.ToInt32(this.EducationLevelCbo.SelectedValue);
            if (this.NationalityCbo.SelectedValue != null && this.NationalityCbo.SelectedIndex > 0)
                sObj.DefaultNationalityId = Convert.ToInt32(this.NationalityCbo.SelectedValue);

            JsonResponse<dynamic> result = DataProvider.DefineOfficeX(sObj);
            if (result != null || result.Success == true)
            {
                FarsiMessageBox.FMessageBox.Show("اطلاعات با موفقیت ثبت شد", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }
         

        }
        #endregion

      

       

        private void label10_Click(object sender, EventArgs e)
        {

        }
    }
}
