using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiMessageBox;
using System.Globalization;
using System.Drawing.Imaging;
using System.Dynamic;
using System.Linq;
using System.Transactions;
using PopupControl;


namespace Dentistry
{
    public partial class PatientAdmission : Form
    {
        PopupControl.Popup p;

        string EditOrNewFlag = "New";

        public dynamic Patient = new System.Dynamic.ExpandoObject();
        public int? PatientId = null;



        public PatientAdmission()
        {
            InitializeComponent();

            this.EditOrNewFlag = "New";
            this.PatientId = 0;

        }

        #region FormNewIll_OverLoaded

        public PatientAdmission(int patientId)
        {
            InitializeComponent();

            this.EditOrNewFlag = "Edit";
            this.PatientId = patientId;


        }
        #endregion

        #region PatientAdmission_Load
        private void PatientAdmission_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();
            this.setDefaultValues();
            this.BirthDateTxt.Value = (Dentistry.UserControls.PersianDate)DateTime.Now;
            this.RecruitmentDateTxt.Value = (Dentistry.UserControls.PersianDate)DateTime.Now;

            var pcDate = new PersianCalendar();
            var currentDate = string.Format("{0}/{1}/{2}", pcDate.GetYear(DateTime.Now), pcDate.GetMonth(DateTime.Now).ToString("00"), pcDate.GetDayOfMonth(DateTime.Now).ToString("00"));
            var currentTime = string.Format("{0}:{1}", pcDate.GetHour(DateTime.Now), pcDate.GetMinute(DateTime.Now));
            this.RegisterDateTxt.Text = currentDate;
            this.RegisterTimeTxt.Text = currentTime;



            if (EditOrNewFlag == "Edit")
            {

                this.GetPatientInfo(this.PatientId.Value);
            }
        }
        #endregion


        private void PatientAdmission_Activated(object sender, EventArgs e)
        {
            this.PatientNameForSearchTxt_Leave(this.FirstNameForSearchTxt, null);
            this.PatientNameForSearchTxt_Leave(this.LastNameForSearchTxt, null);
        }

        #region LoadFormInit
        private void LoadFormInit()
        {
            // InsuranceBookletTypes
            dynamic sObj = new
            {
                EntityName = "BaseCoding_InsuranceBookletTypes"
            };
            var result = Dentistry.DataProvider.GetBaseCodingX(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;

            if (dd != null)
            {
                var insuranceBookletTypeList = (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;
                this.InsuranceBookletTypeCbo.DataSource = insuranceBookletTypeList;
                this.InsuranceBookletTypeCbo.ValueMember = "Id";
                this.InsuranceBookletTypeCbo.DisplayMember = "Title";
            }

            // MaritalStatus
            sObj = new
            {
                EntityName = "BaseCoding_MaritalStatus"
            };
            result = Dentistry.DataProvider.GetBaseCodingX(sObj);
            dd = result != null && result.Data != null ? result.Data : null;

            if (dd != null)
            {
                var maritalStatusList = (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;
                this.MaritalStatusCbo.DataSource = maritalStatusList;
                this.MaritalStatusCbo.ValueMember = "Id";
                this.MaritalStatusCbo.DisplayMember = "Title";
            }

            // EducationLevels
            sObj = new
            {
                EntityName = "BaseCoding_EducationLevels"
            };
            result = Dentistry.DataProvider.GetBaseCodingX(sObj);
            dd = result != null && result.Data != null ? result.Data : null;

            if (dd != null)
            {
                var educationLevelList = (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;
                this.EducationLevelCbo.DataSource = educationLevelList;
                this.EducationLevelCbo.ValueMember = "Id";
                this.EducationLevelCbo.DisplayMember = "Title";
            }

            // Job
            sObj = new
            {
                EntityName = "BaseCoding_Job"
            };
            result = Dentistry.DataProvider.GetBaseCodingX(sObj);
            dd = result != null && result.Data != null ? result.Data : null;

            if (dd != null)
            {
                var jobList = (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;
                this.JobCbo.DataSource = jobList;
                this.JobCbo.ValueMember = "Id";
                this.JobCbo.DisplayMember = "Title";
            }

            // Nationalities
            sObj = new
            {
                EntityName = "BaseCoding_Nationalities"
            };
            result = Dentistry.DataProvider.GetBaseCodingX(sObj);
            dd = result != null && result.Data != null ? result.Data : null;

            if (dd != null )
            {
                var nationalityList = (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;
                this.NationalityCbo.DataSource = nationalityList;
                this.NationalityCbo.ValueMember = "Id";
                this.NationalityCbo.DisplayMember = "Title";

                this.NationalityCbo.SelectedValue = 1;
            }


            ////////////////////////////////////////////////////////////////////////////////////////////////////

            sObj = new { };           
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
               
                this.DoctorCbo.SelectedIndexChanged -= new EventHandler(this.DoctorCbo_SelectedIndexChanged);
                this.DoctorCbo.DataSource = doctors;
                this.DoctorCbo.ValueMember = "Id";
                this.DoctorCbo.DisplayMember = "Title";
                this.DoctorCbo.SelectedIndexChanged += new EventHandler(DoctorCbo_SelectedIndexChanged);
            }

            ///////////////////////////////////////////////////////////////////////////////////////////////////
           

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


            var insurers = Publics.AddDefaultItemToComboDynamicList(insurerList);

            if (insurers != null)
            {
                this.BasicInsurerCbo.SelectedIndexChanged -= new EventHandler(this.BaseInsurerCbo_SelectedIndexChanged);
                this.BasicInsurerCbo.DataSource = insurers;
                this.BasicInsurerCbo.ValueMember = "Id";
                this.BasicInsurerCbo.DisplayMember = "Title";
                this.BasicInsurerCbo.SelectedIndexChanged += new EventHandler(BaseInsurerCbo_SelectedIndexChanged);
            }
        }
        #endregion


        #region setDefaultValues
        private void setDefaultValues()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            JsonResponse<dynamic> result = Dentistry.DataProvider.GetOfficeInfoX(sObj);

            if (result == null || result.Success == false)
                return;
            var dd = result.Data;

            int count = System.Linq.Enumerable.Count(dd);
            if (count < 1)
                return;
            var obj = dd[0];

            if (obj == null)
                return;


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

        private void GetPatientInfo(int patientId)
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.PatientId = patientId;


            JsonResponse<dynamic> result = DataProvider.GetOnePatientInfoX(sObj); // Patient  &  PatientInsurance
            if (result.Data != null)
            {
                var patient = result.Data;
               
                this.Patient = patient;

                if (patient.DoctorId != null)
                {
                    var doctorId = Publics.GetPropertyValue<int>(patient, "DoctorId");
                    this.DoctorCbo.SelectedIndex = Publics.GetComboIndex(this.DoctorCbo, doctorId);
                }


                //this.DoctorCbo.SelectedIndex = 2;
                this.FirstNameTxt.Text = Publics.GetPropertyValue<string>(patient, "FirstName");
                this.LastNameTxt.Text = Publics.GetPropertyValue<string>(patient, "FirstNameLastName");
                this.FatherNameTxt.Text = Publics.GetPropertyValue<string>(patient, "FatherName");
                this.NationalCodeTxt.Text = Publics.GetPropertyValue<string>(patient, "NationalCode");
                int genderId = Publics.GetPropertyValue<int>(patient, "GenderId");
                switch (genderId)
                {
                    case 1:
                        rdoMale.Checked = true;
                        break;
                    case 2:
                        rdoFemale.Checked = true;
                        break;
                    case 3:
                        rdoNone.Checked = true;
                        break;
                    default:
                        rdoMale.Checked = false;
                        rdoMale.Checked = false;
                        rdoNone.Checked = false;
                        break;
                }


             
                this.textBoxPresenter.Text = Publics.GetPropertyValue<string>(patient, "Presenter");

                var jobId = Publics.GetPropertyValue<int>(patient, "JobId");
                this.JobCbo.SelectedIndex = Publics.GetComboIndex(this.JobCbo, jobId);

                var maritalStatusId = Publics.GetPropertyValue<int>(patient, "MaritalStatusId");
                this.MaritalStatusCbo.SelectedIndex = Publics.GetComboIndex(this.MaritalStatusCbo, maritalStatusId);

                var educationLevelId = Publics.GetPropertyValue<int>(patient, "EducationLevelId");
                this.EducationLevelCbo.SelectedIndex = Publics.GetComboIndex(this.EducationLevelCbo, educationLevelId);

                var nationalityId = Publics.GetPropertyValue<int>(patient, "NationalityId");
                this.NationalityCbo.SelectedIndex = Publics.GetComboIndex(this.NationalityCbo, nationalityId);


                this.MobilePhoneTxt.Text = Publics.GetPropertyValue<string>(patient, "MobilePhone");
                this.FixedPhoneTxt.Text = Publics.GetPropertyValue<string>(patient, "FixedPhone");
                this.AddressTxt.Text = Publics.GetPropertyValue<string>(patient, "Address");


                if (patient.Date != null)
                    this.RecruitmentDateTxt.Value = Publics.GetPropertyValue<DateTime>(patient, "Date");

                if (patient.BirthDate != null)
                    this.BirthDateTxt.Value = Publics.GetPropertyValue<DateTime>(patient, "BirthDate");


                var insurerId = Publics.GetPropertyValue<int>(patient, "BI_InsurerId");
                this.BasicInsurerCbo.SelectedIndex = Publics.GetComboIndex(this.BasicInsurerCbo, insurerId);

                this.InsuredNumberTxt.Text = Publics.GetPropertyValue<string>(patient, "BI_InsuredNumber");              

                this.ExpirationDateTxt.Value = Publics.GetPropertyValue<DateTime>(patient, "BI_ExpirationDate");


                if (patient.Date != null)
                {
                    DateTime dt = Publics.GetPropertyValue<DateTime>(patient, "Date");
                    this.RegisterDateTxt.Text = new PersianDateTime(dt).Date.ToString("yyyy/MM/dd");
                    this.RegisterTimeTxt.Text = new PersianDateTime(dt).ToString("hh:mm");
                }

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void textBoxNationalCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
        }

        private void BaseInsurerCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.InsurerId = Convert.ToInt32(this.BasicInsurerCbo.SelectedValue);

            JsonResponse<dynamic> result = DataProvider.GetInsurersX(sObj);
            if (result.Success != true || result.Data == null)
                return;

            var dd = result.Data;
            var obj = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).FirstOrDefault() : null;

            if (obj == null)
                return;

            this.PercentLbl.Text = Convert.ToString(obj.InsurerPercent);
        }

        public DataTable getListDataTable(IEnumerable<dynamic> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PatientId", typeof(int));
            dt.Columns.Add("PatientName", typeof(string));
            dt.Columns.Add("NationalCode", typeof(string));
            dt.Columns.Add("FatherName", typeof(string));

            foreach (var item in list)
                dt.Rows.Add(
                    item.PatientId,
                    item.PatientName,
                    item.NationalCode,
                    item.FatherName
                    );

            return dt;
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            bool isSearch = false;

            dynamic sObj = new System.Dynamic.ExpandoObject();
            if(this.NationalCodeForSearchTxt.Text.Trim() != "")
            {
                isSearch = true;
                sObj.NationalCode = this.NationalCodeForSearchTxt.Text;
            }
            
            if (this.FirstNameForSearchTxt.Text != this.FirstNameForSearchTxt.Tag.ToString())
            {
                isSearch = true;
                sObj.FirstName = this.FirstNameForSearchTxt.Text;
            }
                
            if (this.LastNameForSearchTxt.Text != this.LastNameForSearchTxt.Tag.ToString())
            {
                isSearch = true;
                sObj.LastName = this.LastNameForSearchTxt.Text;
            }

            if (!isSearch)
                return;

            JsonResponse<dynamic> result = Dentistry.DataProvider.GetPatientsX(sObj);
            if (result == null || result.Success == false)
                return;
            var data = result.Data;

            var dd = (data != null && (Enumerable.Count(data) > 0)) ? data : null;

            IEnumerable<dynamic> list = dd != null ? (dd as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true)
                                                                                  .Select(i =>
                                                                                  new
                                                                                  {
                                                                                      PatientId = (int)i.PatientId,
                                                                                      PatientName = (string)i.PatientName,
                                                                                      NationalCode = (string)i.NationalCode,
                                                                                      FatherName = (string)i.FatherName,
                                                                                  }).ToList() : Enumerable.Empty<dynamic>();



            
            DataTable dt = getListDataTable(list);
            this.dgSearchPatients.DataSource = dt;
            this.dgSearchPatients.Refresh();
            this.dgSearchPatientsPnl.Parent = panel2;

            p = null;
            Point location = new Point();
            if (p == null)
            {
                

                Panel panel = this.dgSearchPatientsPnl;
                          
                panel.Width = 700;
                panel.Height = 400;

                p = new PopupControl.Popup(panel);
                p.Closed += new ToolStripDropDownClosedEventHandler(p_Closed);
                p.RightToLeft = RightToLeft.Yes;

                p.ShowingAnimation = p.HidingAnimation = PopupAnimations.Blend;

                Rectangle screen = Screen.PrimaryScreen.Bounds;
                location = new Point(
                  (screen.Width - panel.Width) / 2,
                  (screen.Height - panel.Height) / 2);


                

            }


            p.Hide();
            this.dgSearchPatientsPnl.Visible = true;
            p.Show(location.X, location.Y);
            this.dgSearchPatients.DataSource = new DataTable();
        }

        void p_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (p != null)
            {
                p.Close();
                p = null;
            }
        }

        private void PatientAdmission_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F4)
            {
                this.btnSearch_Click(this, e);
            }
            if (e.KeyCode == Keys.F8)
            {
                this.SaveBtn_Click(this, e);
            }
        }

        private void dgSearchPatients_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            this.PatientId = Convert.ToInt32(this.dgSearchPatients.Rows[e.RowIndex].Cells["PatientIdColumn"].Value);

            this.GetPatientInfo(this.PatientId.Value);
        }

        private void SearchItems_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch_Click(this, e);
            }
        }


        #region ValidateForm
        public bool ValidatePatientInfo()
        {
            bool Flag = true;
            if (string.IsNullOrEmpty(this.FirstNameTxt.Text))
            {
                this.Error_FirstNameTxt.Visible = true;
                Flag = false;
            }
            else
                this.Error_FirstNameTxt.Visible = false;


            if (string.IsNullOrEmpty(this.LastNameTxt.Text))
            {
                this.Error_LastNameTxt.Visible = true;
                Flag = false;
            }
            else
                this.Error_LastNameTxt.Visible = false;

            if (string.IsNullOrEmpty(this.BirthDateTxt.Text))
            {
                this.Error_BirthDateTxt.Visible = true;
                Flag = false;
            }
            else
                this.Error_BirthDateTxt.Visible = false;


            string nationalCode = this.NationalCodeTxt.Text.Trim();
            if (!string.IsNullOrEmpty(nationalCode))
            {
                if (Publics.IsValidNationalCode(nationalCode) == false)
                {
                    FMessageBox.Show("لطفا کد ملی را صحیح وارد كنيد", "خطا", FMessageBoxButtons.OK, FMessageBoxIcons.Error);
                    this.Error_NationalCodeTxt.Visible = true;
                    Flag = false;
                }
                else
                    this.Error_NationalCodeTxt.Visible = false;
            }
            else
            {
                this.Error_NationalCodeTxt.Visible = true;
                Flag = false;
            }



            if ((string.IsNullOrEmpty(this.FixedPhoneTxt.Text)) && (string.IsNullOrEmpty(this.MobilePhoneTxt.Text)))
            {
                FMessageBox.Show("لطفا حداقل یک شماره تلفن وارد كنيد", "خطا", FMessageBoxButtons.OK, FMessageBoxIcons.Error);
                Flag = false;
            }

            if (rdoFemale.Checked == false && rdoMale.Checked == false)
            {
                FMessageBox.Show("لطفا جنسیت مشخص گردد", "خطا", FMessageBoxButtons.OK, FMessageBoxIcons.Error);
                Flag = false;
            }





            return Flag;
        }


        #endregion

        #region SaveBtn_Click
        private void SaveBtn_Click(object sender, EventArgs e)
        {


            //if (this.ValidatePatientInfo() == false)
            //{

            //    return;
            //}

            using (TransactionScope ts = new TransactionScope(TransactionScopeOption.Required, new System.TimeSpan(0, 15, 0)))
                try
                {
                    int? patientId = null;
                    // ذخیره اطلاعات بیمار
                    this.patientInformationSave();
                    if (this.PatientId == 0)
                        throw new Exception("کد بیمار موجود نمیباشد");
                    // ذخیره مراجعه بیمار
                    this.patientInsuranceSave();

                    ts.Complete();
                    FarsiMessageBox.FMessageBox.Show("پذیرش بیمار با موفقیت ثبت شد", "پیام", FMessageBoxButtons.OK, FMessageBoxIcons.Information, FMessageBoxDefaultButtons.Button1);
                    this.DialogResult = DialogResult.OK;
                }

                catch (SqlException exp)
                {
                    ts.Dispose();
                    MessageBox.Show(exp.ToString());
                    this.Close();
                }


        }
        #endregion

        private void patientInformationSave()
        {

            try
            {
                dynamic iObj = new ExpandoObject();
                iObj.ActionType = EditOrNewFlag;
                iObj.DoctorId = Convert.ToInt32(this.DoctorCbo.SelectedValue);

                iObj.FirstName = Publics.RemoveSpaces(this.FirstNameTxt.Text.Trim());
                iObj.LastName = Publics.RemoveSpaces(this.LastNameTxt.Text.Trim());
                iObj.FatherName = Publics.RemoveSpaces(this.FatherNameTxt.Text.Trim());
                iObj.NationalCode = Publics.RemoveSpaces(this.NationalCodeTxt.Text.Trim());

                iObj.GenderId = rdoMale.Checked == true ? int.Parse(this.rdoMale.Tag.ToString()) : int.Parse(this.rdoFemale.Tag.ToString());
                iObj.BirthDate = Class.Date.ToChristianByTime(this.BirthDateTxt.Value.ToString());
                iObj.Date = Class.Date.ToChristianByTime(this.RecruitmentDateTxt.Value.ToString());
                iObj.JobId = Convert.ToInt32(this.JobCbo.SelectedValue);
                iObj.Presenter = Publics.RemoveSpaces(this.textBoxPresenter.Text.Trim());
                iObj.MaritalStatusId = Convert.ToInt32(this.MaritalStatusCbo.SelectedValue);
                iObj.EducationLevelId = Convert.ToInt32(this.EducationLevelCbo.SelectedValue);
                iObj.NationalityId = Convert.ToInt32(this.NationalityCbo.SelectedValue);
                iObj.FixedPhone = this.FixedPhoneTxt.Text.Trim();
                iObj.MobilePhone = this.MobilePhoneTxt.Text.Trim();
                iObj.Address = this.AddressTxt.Text.Trim();




                if (EditOrNewFlag == "Edit")
                    iObj.PatientId = this.PatientId;

                JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientX(iObj);

                if (result.Success == false)
                {
                    FarsiMessageBox.FMessageBox.Show(result.Message, "خطا", FMessageBoxButtons.OK, FMessageBoxIcons.Error, FMessageBoxDefaultButtons.Button1);
                    return;
                }
                else
                {
                    this.PatientId = Convert.ToInt32(result.Data);
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }

        private void patientInsuranceSave()
        {
            try
            {
                dynamic iObj = new ExpandoObject();
                iObj = new ExpandoObject();
                iObj.ActionType = "New";
                iObj.PatientId = this.PatientId;
                iObj.InsuranceTypeId = 1; // بیمه پایه
                iObj.InsurerId = Constant.FreeInsurerId;
                if (this.BasicInsurerCbo.SelectedValue != null)
                    if (Convert.ToInt32(this.BasicInsurerCbo.SelectedValue) > -1)
                        iObj.InsurerId = Convert.ToInt32(this.BasicInsurerCbo.SelectedValue);

                if (this.InsuranceBookletTypeCbo.SelectedValue != null)
                    if (Convert.ToInt32(this.InsuranceBookletTypeCbo.SelectedValue) > -1)
                        iObj.InsuranceBookletType = Convert.ToInt32(this.InsuranceBookletTypeCbo.SelectedValue);
              
                iObj.InsuredNumber = this.InsuredNumberTxt.Text.Trim();                
                iObj.ExpirationDate = Class.Date.ToChristianByTime(this.ExpirationDateTxt.Value.ToString());
                iObj.Percent = this.PercentLbl.Text.Trim();
                iObj.MaxPay = null;
                

                JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientInsuranceX(iObj);

                if (result.Success == false)
                {
                    FarsiMessageBox.FMessageBox.Show(result.Message, "خطا", FMessageBoxButtons.OK, FMessageBoxIcons.Error, FMessageBoxDefaultButtons.Button1);
                    return;
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }


        private void DoctorCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cbo = sender as System.Windows.Forms.ComboBox;
            Dentistry.AppConfigs.SelectedDoctorId = Convert.ToInt32(cbo.SelectedValue);

        }



        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
            if (((TextBox)sender).Text.Length > 10)
                e.Handled = true;
        }

        private void PatientNameForSearchTxt_Enter(object sender, EventArgs e)
        {
            TextBox textBox = ((TextBox)sender);
            if (textBox.Text == textBox.Tag.ToString())
            {
                textBox.Text = "";
            }
        }

        private void PatientNameForSearchTxt_Leave(object sender, EventArgs e)
        {
            TextBox textBox = ((TextBox)sender);
            if (textBox.Text == "")
            {
                textBox.Text = textBox.Tag.ToString();

            }
        }


    }

}

