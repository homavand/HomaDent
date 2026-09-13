using DNTPersianUtils.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry
{
    public partial class PatientServicesFinancialList : Form
    {
        public int ServiceGroupId = -1;
        public PatientServicesFinancialList()
        {
            InitializeComponent();
        }

        private void PatientsServices_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();

            var date = new PersianDateTime(DateTime.Now).Date;
            this.FromDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, date.Month, 1);
            this.ToDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, date.Month, date.DaysInMonth);

            this.FillDataGridView_dgPatientsServices();
        }

        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();          
            sObj.IsServiceGroup = true;

            JsonResponse<dynamic> result = Dentistry.DataProvider.LoadFormInitInfo(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;

            var dd = (result.Data != null) ? result.Data : null;
                                   
            IEnumerable<dynamic> list_ServiceGroup = dd.ServiceGroup != null && (Enumerable.Count(dd.ServiceGroup) > 0) ? (dd.ServiceGroup as IEnumerable<dynamic>).Select(i => i)
                                                                                .Select(i =>
                                                                                  new
                                                                                  {
                                                                                      ServiceGroupId = (int)i.Id,
                                                                                      ServiceGroupTitle = (string)i.Title,

                                                                                  }).ToList() : Enumerable.Empty<dynamic>();


            ///////////////////////////////////////////////////////////////////////////////////////////////

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

            this.doctorCbo.SelectedIndexChanged -= new EventHandler(this.DoctorCbo_SelectedIndexChanged);
            this.doctorCbo.DataSource = doctors;
            this.doctorCbo.ValueMember = "Id";
            this.doctorCbo.DisplayMember = "Title";
            this.doctorCbo.SelectedIndexChanged += new EventHandler(this.DoctorCbo_SelectedIndexChanged);


            ///////////////////////////////////////////////////////////////////////////////////////////////


            sObj = new System.Dynamic.ExpandoObject();
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

            this.insurerCbo.SelectedIndexChanged -= new EventHandler(this.InsurerCbo_SelectedIndexChanged);
            this.insurerCbo.DataSource = list;
            this.insurerCbo.ValueMember = "Id";
            this.insurerCbo.DisplayMember = "Title";
            this.insurerCbo.SelectedIndexChanged += new EventHandler(this.InsurerCbo_SelectedIndexChanged);

        }
        #endregion

        private void FillDataGrid_dgService()
        {
            dynamic sObj = new
            {
                IsDeleted = false
            };
            var result = DataProvider.GetServicesX(sObj);
            if (result == null || result.Success == false)
                return;

            var dd = result.Data;
            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i)
                                                                          .Select(i =>
                                                                            new
                                                                            {
                                                                                i.ServiceId,
                                                                                i.ServiceCode,
                                                                                i.ServiceTitle,
                                                                                i.ServiceColor,
                                                                                i.IsDeleted,
                                                                                i.ServiceFreePrice,
                                                                                i.PriceDefineDate

                                                                            }).ToList() : Enumerable.Empty<dynamic>();

            //IEnumerable<dynamic> list_Service = dd.Service != null ? (dd.Service as IEnumerable<dynamic>)
            //                                                              .Where(i => Convert.ToInt32(i.Id) != 0)
            //                                                              .Select(i =>
            //                                                               new
            //                                                               {
            //                                                                   ServiceId = (int)i.Id,
            //                                                                   ServiceTitle = string.Format("{0} - ({1})", (string)i.Title, (string)i.Code),
            //                                                                   ServiceGroupId = (int)i.ServiceGroupId,
            //                                                                   ServiceGroupTitle = list_ServiceGroup.Where(j => j.ServiceGroupId == i.ServiceGroupId).FirstOrDefault().ServiceGroupTitle,
            //                                                                   IsCheck = true,
            //                                                               }).ToList() : Enumerable.Empty<dynamic>();

            //this.dgServices.DataSource = list;
        }

        private void dgPatientServices_ColumnOrder()
        {
            
            dgPatientServices.AutoGenerateColumns = false;
            dgPatientServices.Columns["ColumnPatientServiceId"].Visible = false;
            dgPatientServices.Columns["ColumnCheckupTypeId"].Visible = false;
            dgPatientServices.Columns["ColumnServiceGroupId"].Visible = false;
            dgPatientServices.Columns["ColumnServiceSolarDate"].DisplayIndex = 0;
            dgPatientServices.Columns["ColumnServiceGroupTitle"].DisplayIndex = 1;
            dgPatientServices.Columns["ColumnServiceTite"].DisplayIndex = 2;
            dgPatientServices.Columns["ColumnToothImage"].DisplayIndex = 3;
            dgPatientServices.Columns["ColumnPatientName"].DisplayIndex = 4;
            dgPatientServices.Columns["ColumnProviderStaffTitle"].DisplayIndex = 5;
            dgPatientServices.Columns["ColumnServicePrice"].DisplayIndex = 6;
            dgPatientServices.Columns["ColumnInsurerPrice"].DisplayIndex = 7;
            dgPatientServices.Columns["ColumnInsurerShare"].DisplayIndex = 8;
            dgPatientServices.Columns["ColumnFranchiseShare"].DisplayIndex = 9;
            dgPatientServices.Columns["ColumnFreeShare"].DisplayIndex = 10;
        }

        public void FillDataGridView_dgPatientsServices()
        {
            this.dgPatientServices_ColumnOrder();

            dynamic sObj = new ExpandoObject();

            sObj.CheckupTypeId = 2;

            if (this.ServiceGroupId != -1)
                sObj.ServiceGroupId = this.ServiceGroupId;

            if (this.insurerCbo.SelectedIndex > 0)
                sObj.BasicInsurerId = Convert.ToInt32(this.insurerCbo.SelectedValue);

            if (this.doctorCbo.SelectedIndex > 0)
                sObj.ProviderStaffId = Convert.ToInt32(this.insurerCbo.SelectedValue);


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

            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) >= 0) ? (dd as IEnumerable<dynamic>)
                .Select(i => new Class.PatientService(i))
                   .Select(i =>
                   new
                   {
                       PatientServiceId = (int)i.Id,
                       PatientId = (int)i.PatientId,
                       PatientName = (string)i.PatientName,
                       ServiceGroupTitle = (string)i.ServiceGroupTitle,
                       ServiceTitle = string.Format("{0} ({1})", i.ServiceTitle, i.ServiceGroupTitle),
                       ServiceCount = (int)i.ServiceCount,
                       SolarDate = (string)i.SolarDate,
                       BasicInsurerTitle = (string)i.BasicInsurerTitle,
                       DoctorTitle = (string)i.DoctorTitle,
                       ProviderStaffTitle = (string)i.ProviderStaffTitle,
                       
                       ServicePrice = (double)i.ServicePrice,
                       InsurerPrice = (double)i.InsurerPrice,
                       InsurerShare = (double)i.InsurerShare,
                       FranchiseShare = (double)i.FranchiseShare,
                       FreeShare = (double)i.FreeShare,
                       PatientShare = (double)i.PatientShare,                       
                                                                     
                       CheckupTypeId = (int)i.CheckupTypeId,
                       i.ToothImage,
                       
                   }).Where(i => i.CheckupTypeId == 2).ToList() : Enumerable.Empty<dynamic>();




            if (list == null)
                return;




            this.dgPatientServices.DataSource = list.Where(i => Convert.ToInt32(i.CheckupTypeId) == 2).ToList();




            var total = new
            {
                ServicePrice = list.Any() ? list.Sum(item => (double)item.ServicePrice) : 0,
                InsurerPrice = list.Any() ? list.Sum(item => (double)item.InsurerPrice) : 0,
                InsurerShare = list.Any() ? list.Sum(item => (double)item.InsurerShare) : 0,
                FranchiseShare = list.Any() ? list.Sum(item => (double)item.FranchiseShare) : 0,
                FreeShare = list.Any() ? list.Sum(item => (double)item.FreeShare) : 0,
                PatientShare = list.Any() ? list.Sum(item => (double)item.PatientShare) : 0,
            };

            if (total != null)
            {

                var ff = dd;
                this.servicePriceTotalTxt.Text = total.ServicePrice.ToString();
                this.insurerShareTotalTxt.Text = total.InsurerShare.ToString();
                this.franchiseShareTotalTxt.Text = total.FranchiseShare.ToString();
                this.freeShareTotalTxt.Text = total.FreeShare.ToString();
                this.patientShareTotalTxt.Text = total.PatientShare.ToString();
            }
            //this.dgPatientsPrices.Refresh();
        }
        //private byte[] StoreImage(string ChosenFile)
        //{
        //    try
        //    {
        //        using (Image img = Image.FromFile(ChosenFile))
        //        using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
        //        {
        //            img.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
        //            ms.Close();
        //            byte[] img_byte = ms.ToArray();
        //            return img_byte;
        //        }
        //    }
        //    catch (Exception e) { 
        //        MessageBox.Show(e.ToString());
        //        return null;
        //    }
        //}
        void HandleItem(Microsoft.VisualBasic.PowerPacks.DataRepeaterItem item)
        {
            //if (items.Contains(item))
            //    return;
            var handler = new Class.DataRepeaterItemHelper(item);
            //items.Add(item);
        }

       

        private void InsurerCbo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DoctorCbo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void SearchBtn_Click(object sender, EventArgs e)
        {
            this.FillDataGridView_dgPatientsServices();
            
        }

        private void numberTxt_TextChanged(object sender, EventArgs e)
        {
            string txt = ((Label)sender).Text;
            if (string.IsNullOrEmpty(txt))
                return;
            double val = Convert.ToDouble(txt);
            ((Label)sender).Text = Publics.ToRial(val);
        }
    }
}
