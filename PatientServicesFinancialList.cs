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
                                   
            IEnumerable<dynamic> serviceGroupList = dd.ServiceGroup != null && (Enumerable.Count(dd.ServiceGroup) > 0) ? (dd.ServiceGroup as IEnumerable<dynamic>).Select(i => i)
                                                                                .Select(i =>
                                                                                  new
                                                                                  {
                                                                                      Id = (int)i.Id,
                                                                                      Title = (string)i.Title,

                                                                                  }).ToList() : Enumerable.Empty<dynamic>();

            var serviceGroups = Publics.AddDefaultItemToComboDynamicList(serviceGroupList);

            this.ServiceGroupCbo.DataSource = serviceGroups;
            this.ServiceGroupCbo.ValueMember = "Id";
            this.ServiceGroupCbo.DisplayMember = "Title";

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

            this.DoctorCbo.DataSource = doctors;
            this.DoctorCbo.ValueMember = "Id";
            this.DoctorCbo.DisplayMember = "Title";


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

            this.InsurerCbo.DataSource = list;
            this.InsurerCbo.ValueMember = "Id";
            this.InsurerCbo.DisplayMember = "Title";

        }
        #endregion

    

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

            if (this.ServiceGroupCbo.SelectedIndex > 0)
                sObj.ServiceGroupId = Convert.ToInt32(this.ServiceGroupCbo.SelectedValue);

            if (this.InsurerCbo.SelectedIndex > 0)
                sObj.BasicInsurerId = Convert.ToInt32(this.InsurerCbo.SelectedValue);

            if (this.DoctorCbo.SelectedIndex > 0)
                sObj.ProviderStaffId = Convert.ToInt32(this.InsurerCbo.SelectedValue);


            if ((this.FromDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.FromDateTxt.Value.ToString())))
                sObj.FromDate = string.Format("{0} 00:00:01", this.FromDateTxt.Value.ToString()).ToGregorianDateTime();

            if ((this.ToDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.ToDateTxt.Value.ToString())))
                sObj.ToDate = string.Format("{0} 23:59:59", this.ToDateTxt.Value.ToString()).ToGregorianDateTime();




            JsonResponse<dynamic> result = Dentistry.DataProvider.GetPatientServicesX(sObj);

            if (result == null || result.Success == false || result.Data == null)
                return;
            var dd = result.Data;

            var rawList = (dd as IEnumerable<dynamic>).ToList();
            var patientServiceObjs = rawList.Select(i => new Class.PatientService(i)).ToList();

            var list = patientServiceObjs
                       .Select(i =>
                       new
                       {
                           PatientServiceId = (int)i.Id,
                           i.PatientId ,
                           i.PatientName,
                           i.ServiceGroupTitle,
                           ServiceTitle = string.Format("{0} ({1})", i.ServiceTitle, i.ServiceGroupTitle),
                           i.ServiceCount,
                           i.SolarDate ,
                           i.BasicInsurerTitle ,
                           i.DoctorTitle ,
                           i.ProviderStaffTitle ,
                       
                           i.ServicePrice ,
                           i.InsurerPrice ,
                           i.InsurerShare ,
                           i.FranchiseShare ,
                           i.FreeShare ,
                           i.PatientShare ,                                                                                            
                           i.CheckupTypeId ,
                           i.ToothImage,
                       
                       }).ToList() ;


            if (list == null)
                return;

            this.dgPatientServices.DataSource = list;




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
