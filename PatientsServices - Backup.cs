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
    public partial class PatientsServices : Form
    {
        public int ServiceGroupId = -1;
        public PatientsServices()
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
            sObj.IsInsurer = true;
            sObj.IsDoctor = true;
            //sObj.IsSpecialty = true;
            sObj.IsServiceGroup = true;
            sObj.IsService = true;

            JsonResponse<dynamic> result = Dentistry.Provider.LoadFormInitInfo(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;

            var dd = (result.Data != null) ? result.Data : null;
            IEnumerable<dynamic> list_Insurer = dd.Insurer != null && (Enumerable.Count(dd.Insurer) > 0) ? (dd.Insurer as IEnumerable<dynamic>).Select(i => i).ToList() : null;
            IEnumerable<dynamic> list_Doctor = dd.Doctor != null && (Enumerable.Count(dd.Doctor) > 0) ? (dd.Doctor as IEnumerable<dynamic>).Select(i => i).ToList() : null;
            IEnumerable<dynamic> list_Specialty = dd.Specialty != null && (Enumerable.Count(dd.Specialty) > 0) ? (dd.Specialty as IEnumerable<dynamic>).Select(i => i).ToList() : null;

            IEnumerable<dynamic> list_ServiceGroup = dd.ServiceGroup != null && (Enumerable.Count(dd.ServiceGroup) > 0) ? (dd.ServiceGroup as IEnumerable<dynamic>).Select(i => i)
                                                                                .Select(i =>
                                                                                  new
                                                                                  {
                                                                                      ServiceGroupId = (int)i.Id,
                                                                                      ServiceGroupTitle = (string)i.Title,

                                                                                  }).ToList() : Enumerable.Empty<dynamic>();

            IEnumerable<dynamic> list_Service = dd.Service != null ? (dd.Service as IEnumerable<dynamic>) 
                                                                           .Where(i => Convert.ToInt32(i.Id) != 0)
                                                                           .Select(i =>
                                                                            new
                                                                            {
                                                                                ServiceId = (int)i.Id,
                                                                                ServiceTitle = string.Format("{0} - ({1})", (string)i.Title, (string)i.Code),
                                                                                ServiceGroupId = (int)i.ServiceGroupId,
                                                                                ServiceGroupTitle = list_ServiceGroup.Where(j => j.ServiceGroupId == i.ServiceGroupId).FirstOrDefault().ServiceGroupTitle,
                                                                                IsCheck = true,
                                                                            }).ToList() : Enumerable.Empty<dynamic>();
          
            this.insurerCbo.SelectedIndexChanged -= new EventHandler(this.InsurerCbo_SelectedIndexChanged);
            this.insurerCbo.DataSource = list_Insurer;
            this.insurerCbo.ValueMember = "Id";
            this.insurerCbo.DisplayMember = "Title";
            this.insurerCbo.SelectedIndexChanged += new EventHandler(this.InsurerCbo_SelectedIndexChanged);

            

            this.doctorCbo.SelectedIndexChanged -= new EventHandler(this.DoctorCbo_SelectedIndexChanged);
            this.doctorCbo.DataSource = list_Doctor;
            this.doctorCbo.ValueMember = "Id";
            this.doctorCbo.DisplayMember = "Title";
            this.doctorCbo.SelectedIndexChanged += new EventHandler(this.DoctorCbo_SelectedIndexChanged);

        


        }
        #endregion

   


        public void FillDataGridView_dgPatientsServices()
        {
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




            JsonResponse<dynamic> result = Dentistry.Provider.GetPatientServicesX(sObj);

            if (result == null || result.Success == false || result.Data == null)
                return;
            var dd = result.Data;

            if (dd == null)
                return;

            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) >= 0) ? (dd as IEnumerable<dynamic>)
                .Select(i => new MyClasses.PatientService(i))
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
                       ToothImage = ((int)i.ToothCount) == 1 ? i.ToothImage : null ,
                       ToothImage1 = Image.FromFile(@"D:\999-4.png")
                   }).Where(i => i.CheckupTypeId == 2).ToList() : Enumerable.Empty<dynamic>();




            if (list == null)
                return;          

            if (this.patientNameTxt.DataBindings["Tag"] == null)
                this.patientNameTxt.DataBindings.Add("Tag", list, "PatientId");
            if (this.patientNameTxt.DataBindings["Text"] == null)
                this.patientNameTxt.DataBindings.Add("Text", list, "PatientName");
            if (this.doctorTxt.DataBindings["Text"] == null)
                this.doctorTxt.DataBindings.Add("Text", list, "DoctorTitle");
            if (this.patientBasicInsurerTxt.DataBindings["Text"] == null)
                this.patientBasicInsurerTxt.DataBindings.Add("Text", list, "BasicInsurerTitle");

          
            if (this.serviceTxt.DataBindings["Text"] == null)
                this.serviceTxt.DataBindings.Add("Text", list, "ServiceTitle", true);
            if (this.serviceDateTxt.DataBindings["Text"] == null)
                this.serviceDateTxt.DataBindings.Add("Text", list, "SolarDate", true);

            if (this.servicePriceTxt.DataBindings["Text"] == null)
                this.servicePriceTxt.DataBindings.Add("Text", list, "ServicePrice");
           
            if (this.insurerPriceTxt.DataBindings["Text"] == null)
                this.insurerPriceTxt.DataBindings.Add("Text", list, "InsurerPrice");

            if (this.insurerShareTxt.DataBindings["Text"] == null)
                this.insurerShareTxt.DataBindings.Add("Text", list, "InsurerShare");

            if (this.franchiseShareTxt.DataBindings["Text"] == null)
                this.franchiseShareTxt.DataBindings.Add("Text", list, "FranchiseShare");

            this.freeShareTxt.DataBindings.Clear();
            this.freeShareTxt.DataBindings.Add("Text", list, "FreeShare");

            if (this.patientShareTxt.DataBindings["Text"] == null)
                this.patientShareTxt.DataBindings.Add("Text", list, "PatientShare");


            //this.serviceToothImg.DataBindings.Clear();
            //this.serviceToothImg.DataBindings.Add(new Binding("Image", list, "ToothImage", true));

            //this.pictureBox1.DataBindings.Clear();
            //this.pictureBox1.DataBindings.Add(new Binding("Image", list, "ToothImage1", true));

            
            this.dataRepeater1.Visible = true;

            this.dataRepeater1.DataSource = list;


           

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

        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            //if (e.DataRepeaterItem.ItemIndex % 2 == 0)
            //    e.DataRepeaterItem.BackColor = Color.White;
            //else
            //    e.DataRepeaterItem.BackColor = Color.WhiteSmoke;

            HandleItem(e.DataRepeaterItem);

            dynamic currItem = ((IEnumerable<dynamic>)dataRepeater1.DataSource).ToList()[e.DataRepeaterItem.ItemIndex];
            var img = currItem.ToothImage;

            if (img == null || Convert.IsDBNull(img))
                return;

            Microsoft.VisualBasic.PowerPacks.DataRepeaterItem item = e.DataRepeaterItem;

            ((PictureBox)e.DataRepeaterItem.Controls["serviceToothImg"]).Image = (Image)img;
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
