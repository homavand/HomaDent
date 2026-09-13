using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Dynamic;
using DNTPersianUtils.Core;
using FarsiMessageBox;

namespace Dentistry
{
    public partial class InsuranceFinancialDefine : Form
    {
        string EditOrNewFlag;
        int InsurerFinancialId = -1;

        #region FormInsuranceList_NewEdit
        public InsuranceFinancialDefine()
        {
            InitializeComponent();

            this.LoadFormInit();
            this.EditOrNewFlag = "New";
     
            this.registerDateTxt.Text = new PersianDateTime(DateTime.Now).ToString("dddd d MMMM yyyy ساعت hh:mm tt");
        }
        #endregion

        #region FormInsuranceList_NewEdit_Overloaded
        public InsuranceFinancialDefine(int insurerFinancialId)
        {
            try
            {
                InitializeComponent();

                
                this.EditOrNewFlag = "Edit";
                this.InsurerFinancialId = insurerFinancialId;

                

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }
        #endregion

        #region InsuranceDefine_Load
        private void InsuranceDefine_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();
            this.GetInsurerInfo();
            this.DateTxt_ValueChanged(this, null);
        }
        #endregion

        #region LoadFormInit
        private void LoadFormInit()
        {

            dynamic sObj = new System.Dynamic.ExpandoObject();           

            var data = Dentistry.DataProvider.GetInsurersX(sObj);
            var dd = data != null && data.Data != null ? data.Data : null;

            IEnumerable<dynamic> insurerList = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i =>
            new
            {
                Id = i.InsurerId,
                Title = i.InsurerTitle,
            }

            ).OrderBy(i => i.Id).ToList() : Enumerable.Empty<dynamic>();

           
            this.insurerCbo.SelectedIndexChanged -= new EventHandler(this.insurerCbo_SelectedIndexChanged);
            insurerCbo.DataSource = insurerList;
            insurerCbo.ValueMember = "Id";
            insurerCbo.DisplayMember = "Title";
            this.insurerCbo.SelectedIndexChanged += new EventHandler(this.insurerCbo_SelectedIndexChanged);
        }
        #endregion

        public void GetInsurerInfo()
        {
            if (this.InsurerFinancialId != -1)
            {
                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.Id = this.InsurerFinancialId;

                JsonResponse<dynamic> result = Dentistry.DataProvider.GetInsuranceFinancialsX(sObj);
                if (result.Success != true || result.Data == null)
                    return;
                var dd = result.Data;
                var list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;
                var obj = (list != null) ? list.FirstOrDefault() : null;


                if (obj != null)
                {
                    var insurerId = Publics.GetPropertyValue<int>(obj, "InsurerId");
                    this.insurerCbo.SelectedIndex = Publics.GetComboIndex(this.insurerCbo, insurerId);
                    //this.insurerCbo.SelectedValue = obj.InsurerId != null ? obj.InsurerId : 0;

                    this.FromDateTxt.Value = obj.FromDate;
                    this.ToDateTxt.Value = obj.ToDate;
                    this.requestedValueTxt.SetText(Convert.ToString(obj.RequestedValue));
                    this.receivedValueTxt.SetText(Convert.ToString(obj.ReceivedValue));
                    this.deductionValueTxt.Text = Convert.ToString(obj.DeductionValue);
                    this.registerDateTxt.Text = new PersianDateTime((DateTime)obj.Date).ToString("yyyy/MM/dd");
                    this.commentTxt.Text = Convert.ToString(obj.Comment);

                }



            }
        }

        public void GetPatientsServicesInsuranceFinancialInfo()
        {
            dynamic sObj = new ExpandoObject();

            sObj.CheckupTypeId = 2;
           
            //if (this.insurerCbo.SelectedIndex > 0)
            sObj.BasicInsurerId = Convert.ToInt32(this.insurerCbo.SelectedValue);
            
            if ((this.FromDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.FromDateTxt.Value.ToString())))
                sObj.FromDate = string.Format("{0} 00:00:01", this.FromDateTxt.Value.ToString()).ToGregorianDateTime();

            if ((this.ToDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.ToDateTxt.Value.ToString())))
                sObj.ToDate = string.Format("{0} 23:59:59", this.ToDateTxt.Value.ToString()).ToGregorianDateTime();


            JsonResponse<dynamic> result = Dentistry.DataProvider.GetPatientServicesX(sObj);

            if (result == null || result.Success == false || result.Data == null)
                return;
            var dd = result.Data;

            if (dd == null)
                return;

            IEnumerable<dynamic> patientsServicesList = dd != null && (Enumerable.Count(dd) >= 0) ? (dd as IEnumerable<dynamic>)
                .Select(i => new Class.PatientService(i))
                   .Select(i =>
                   new
                   {
                       PatientServiceId = i.Id,
                       i.ServiceGroupId,
                       i.ServiceGroupTitle,
                       i.ServiceId,
                       i.ServiceTitle,                    
                       i.BasicInsurerId,
                       i.BasicInsurerTitle,
                       i.ProviderStaffTitle,
                       i.ProviderStaffPercent,

                       InsurerPrice = (double)i.InsurerPrice,
                       InsurerShare = (double)i.InsurerShare,
                       FranchiseShare = (double)i.FranchiseShare,
                    
                       i.ToothCount,                     
                       i.PatientId,
                       i.DoctorId,
                       i.Date,
                       i.SolarDate,
                   }).ToList() : Enumerable.Empty<dynamic>();

            if (patientsServicesList == null)
                return;

            var totalResult =
                        (from item in patientsServicesList
                            group item by new { item.BasicInsurerId } into gItem

                            select new
                            {
                                BasicInsurerId = gItem.Key.BasicInsurerId,
                                BasicInsurerTitle = gItem.First().BasicInsurerTitle,
                                PatientsCountValue = gItem.Select(b => b.PatientId).Distinct().Count(),
                                ServicesCountValue = gItem.Count(),
                                InsurerPriceValue = gItem.Sum(b => (double)b.InsurerPrice),
                                InsurerShareValue = gItem.Sum(b => (double)b.InsurerShare),
                                FranchiseShareValue = gItem.Sum(b => (double)b.FranchiseShare),

                            }).ToList();

          
            var info = totalResult != null ? totalResult.SingleOrDefault() : null;
            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("نام بیمه گر  ",      info == null ? "" : Convert.ToString(info.BasicInsurerTitle)),
                new KeyValuePair<string, string>("تعداد نسخ(بیمار)  ", info == null ? "" : Convert.ToString(info.PatientsCountValue)),
                new KeyValuePair<string, string>("تعداد خدمات ",       info == null ? "" : Convert.ToString(info.ServicesCountValue)),
                new KeyValuePair<string, string>("کل قیمت بیمه ",      info == null ? "" : Convert.ToString(info.InsurerPriceValue)),
                new KeyValuePair<string, string>("کل سهم بیمه",        info == null ? "" : Convert.ToString(info.InsurerShareValue)),
              
                new KeyValuePair<string, string>("مبلغ درخواستی از بیمه",   info == null ? "" : Convert.ToString(info.InsurerShareValue)),
                new KeyValuePair<string, string>("مبلغ دریافتی از بیمه",   info == null ? "" : Convert.ToString("0")),
                new KeyValuePair<string, string>("کسورات اعمالی از بیمه",   info == null ? "" : Convert.ToString("0")),
            };
            this.dgPatientServicesInfo.DataSource = list;
            this.dgPatientServicesInfo.CurrentCell = null;
            

          
        }

        #region buttonOk_Click
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm() == false)
                return;
            try
            {
               
                dynamic iObj = new ExpandoObject();
                                
               
                double requestedValue = double.Parse(this.requestedValueTxt.Text.Trim().ToString());
                double receivedValue = double.Parse(this.receivedValueTxt.Text.Trim().ToString());
                double deductionValue = double.Parse(this.deductionValueTxt.Text);
                double remainPrice = requestedValue - (receivedValue - deductionValue);

                iObj.InsurerId = int.Parse(this.insurerCbo.SelectedValue.ToString());
                iObj.Date = DateTime.Now;
                iObj.FromDate = Class.Date.ToChristianByTime(this.FromDateTxt.Value.ToString());
                iObj.ToDate = Class.Date.ToChristianByTime(this.ToDateTxt.Value.ToString());
                iObj.RequestedValue = requestedValue;
                iObj.ReceivedValue = receivedValue;
                iObj.DeductionValue = deductionValue;
                iObj.RemainPrice = remainPrice;
                iObj.Comment = this.commentTxt.Text.Trim().ToString();
                iObj.IsDeleted = false;
               

                if (this.EditOrNewFlag == "New")
                {
                }
                else if (this.EditOrNewFlag == "Edit")
                {
                    iObj.Id = this.InsurerFinancialId;                       
                }


                JsonResponse<dynamic> result = Dentistry.DataProvider.DefineInsurerFinancialsX(iObj);

                if (result != null && result.Success == true && result.Data != null)
                {
                }



                this.buttonCancel_Click(this, null);

            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }
        #endregion

        #region buttonCancel_Click
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ValidateForm
        private bool ValidateForm()
        {
            bool Flag = true;
            if (this.insurerCbo.SelectedIndex < 1)
            {
                FMessageBox.Show(Dentistry.AppConfigs.strSelectInsurer, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.OK, FMessageBoxIcons.Question);
                this.Error_comboBoxInsurance.Visible = true;
                Flag = false;
            }
            else
                this.Error_comboBoxInsurance.Visible = false;

            

            if ((this.requestedValueTxt.Text == string.Empty) || (this.requestedValueTxt.IsValid() == false))
                this.requestedValueTxt.SetText("0");

            if ((this.receivedValueTxt.Text == string.Empty) || (this.receivedValueTxt.IsValid() == false))
                this.receivedValueTxt.SetText("0");

            if ((this.deductionValueTxt.Text == string.Empty) || (this.deductionValueTxt.IsValid() == false))
                this.deductionValueTxt.SetText("0");

            return Flag;
        }





        #endregion

        private void DateTxt_ValueChanged(object sender, Dentistry.UserControls.PersianMonthCalendarEventArgs e)
        {
          
            string fromDate = string.Format("{0}/{1}/{2}", FromDateTxt.Value.Year, FromDateTxt.Value.Month, FromDateTxt.Value.Day);
            string toDate   = string.Format("{0}/{1}/{2}", ToDateTxt.Value.Year, ToDateTxt.Value.Month, ToDateTxt.Value.Day);

            tblTxt.Text = string.Format("جمع خدمات انجام شده از تاریخ  {0}  تا تاریخ  {1}", fromDate, toDate);

            this.GetPatientsServicesInsuranceFinancialInfo();
        }

        private void dgPatientServicesInfo_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (Convert.ToString(this.dgPatientServicesInfo["ColumnKey", e.RowIndex].Value) == "مبلغ درخواستی از بیمه")
                this.dgPatientServicesInfo.Rows[e.RowIndex].Cells["ColumnValue"].Style.ForeColor = Color.Blue;
            if (Convert.ToString(this.dgPatientServicesInfo["ColumnKey", e.RowIndex].Value) == "مبلغ دریافتی از بیمه")
                this.dgPatientServicesInfo.Rows[e.RowIndex].Cells["ColumnValue"].Style.ForeColor = Color.DarkGreen;
            if (Convert.ToString(this.dgPatientServicesInfo["ColumnKey", e.RowIndex].Value) == "کسورات اعمالی از بیمه")
                this.dgPatientServicesInfo.Rows[e.RowIndex].Cells["ColumnValue"].Style.ForeColor = Color.DeepPink;

        }

        private void FinancialValueTxt_TextChanged(object sender, EventArgs e)
        {
            double requestedValue = string.IsNullOrEmpty(this.requestedValueTxt.Text) == true ? 0 : Convert.ToDouble(this.requestedValueTxt.Text);
            double receivedValue = string.IsNullOrEmpty(this.receivedValueTxt.Text) == true ? 0 : Convert.ToDouble(this.receivedValueTxt.Text);

            double deductionValue = requestedValue - receivedValue;
            this.deductionValueTxt.Text = Convert.ToString(deductionValue);


        }

        private void deductionValueTxt_TextChanged(object sender, EventArgs e)
        {
            double requestedValue = string.IsNullOrEmpty(this.requestedValueTxt.Text) == true ? 0 : Convert.ToDouble(this.requestedValueTxt.Text);
            double receivedValue = string.IsNullOrEmpty(this.receivedValueTxt.Text) == true ? 0 : Convert.ToDouble(this.receivedValueTxt.Text);
            double deductionValue = string.IsNullOrEmpty(this.deductionValueTxt.Text) == true ? 0 : Convert.ToDouble(this.deductionValueTxt.Text);

            double remainValue = requestedValue - (receivedValue + deductionValue);
            this.remainValueTxt.Text = Convert.ToString(remainValue);
        }

        private void insurerCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (sender == null || ((ComboBox)sender).SelectedValue == null)
                return;

            this.GetPatientsServicesInsuranceFinancialInfo();
        }
    }
}
