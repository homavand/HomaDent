using FarsiMessageBox;
using Microsoft.VisualBasic.PowerPacks;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry
{
    public partial class PatientsList_Backup : Form
    {
        public PatientsList_Backup()
        {
            InitializeComponent();
            this.LoadFormInit();
        }

        private void PatientsGrid_Load(object sender, EventArgs e)
        {

            this.FillDataGridView();


        }

        #region LoadFormInit
        private void LoadFormInit()
        {

            dynamic sObj = new System.Dynamic.ExpandoObject();
            var result = Provider.GetDoctorsX(sObj);
            if (result == null || result.Success == false)
                return;

            var dd = result.Data;
            var doctorList = (dd as IEnumerable<dynamic>)
                                        .Select(i =>
                                        new
                                        {
                                            Id = (int)i.StaffId,
                                            Title = (string)i.FullName
                                        }).ToList();

            var doctors = Publics.AddDefaultItemToComboDynamicList(doctorList);

            this.doctorCbo.SelectedIndexChanged -= new EventHandler(doctorCbo_SelectedIndexChanged);
            this.doctorCbo.DataSource = doctors;
            this.doctorCbo.ValueMember = "Id";
            this.doctorCbo.DisplayMember = "Title";
            if (this.doctorCbo.Items.Count < 2)
            {
                doctorCbo.SelectedIndex = 1;
            }
            if (Dentistry.Config.SelectedDoctorId != -1)
            {
                this.doctorCbo.SelectedIndex = Publics.GetComboIndex(this.doctorCbo, Dentistry.Config.SelectedDoctorId);
            }
            this.doctorCbo.SelectedIndexChanged += new EventHandler(doctorCbo_SelectedIndexChanged);


            dynamic sObj = new System.Dynamic.ExpandoObject();

            result = Dentistry.Provider.GetInsurersX(sObj);
             dd = result != null && result.Data != null ? result.Data : null;

            IEnumerable<dynamic> insurerList = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i =>
                new
                {
                    Id = i.InsurerId,
                    Title = i.InsurerTitle,
                }
            ).OrderBy(i => i.Id).ToList() : Enumerable.Empty<dynamic>();


            var list = Publics.AddDefaultItemToComboDynamicList(insurerList);

            this.insurerCbo.DataSource = list;
            this.insurerCbo.ValueMember = "Id";
            this.insurerCbo.DisplayMember = "Title";
        }
        #endregion

        private void doctorCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cbo = (System.Windows.Forms.ComboBox)sender;

            Dentistry.Config.SelectedDoctorId = Convert.ToInt32(cbo.SelectedValue);

        }

        #region FillDataGridView

        public void FillDataGridView()
        {
            try
            {
                string nationalCode = this.NationalCodeTxt.Text.Trim();
                if (!string.IsNullOrEmpty(nationalCode))
                {
                    if (Publics.IsValidNationalCode(nationalCode) == false)
                    {
                        FMessageBox.Show("لطفا کد ملی را صحیح وارد كنيد", "خطا", FMessageBoxButtons.OK, FMessageBoxIcons.Error);
                        return;
                    }
                }

                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.IsDeleted = false;

                if (doctorCbo.SelectedValue != null && int.Parse(doctorCbo.SelectedValue.ToString()) > 0)
                    sObj.DoctorId = doctorCbo.SelectedValue;
                if (insurerCbo.SelectedValue != null && int.Parse(insurerCbo.SelectedValue.ToString()) > 0)
                    sObj.DoctorId = insurerCbo.SelectedValue;
                if (!string.IsNullOrEmpty(nationalCode))
                    sObj.NationalCode = nationalCode;
                if (!string.IsNullOrEmpty(this.FirstNameTxt.Text.Trim()))
                    sObj.FirstName = Publics.FixCharacters(this.FirstNameTxt.Text.Trim());
                if (!string.IsNullOrEmpty(this.LastNameTxt.Text.Trim()))
                    sObj.LastName = Publics.FixCharacters(this.LastNameTxt.Text.Trim());
                if (!string.IsNullOrEmpty(this.PresenterTxt.Text.Trim()))
                    sObj.Presenter = Publics.FixCharacters(this.PresenterTxt.Text.Trim());

                if (this.debtorPatientsChk.Checked == true)
                    sObj.IsDebtor = true;

                if (this.creditorPatientsChk.Checked == true)
                    sObj.IsCreditor = true;

                JsonResponse<dynamic> result = Dentistry.Provider.GetPatientsX(sObj);
                if (result == null || result.Success == false)
                    return;
                var data = result.Data;

                var dd = (data != null && (Enumerable.Count(data) > 0)) ? data : null;

                IEnumerable<dynamic> list = dd != null ? (dd as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true)
                                                                                      .Select(i =>
                                                                                      new
                                                                                      {
                                                                                          PatientId = (int)i.PatientId,
                                                                                          PatientName = string.Format("{0} {1} - ({2})", i.FirstName, i.LastName, i.PatientId),
                                                                                          NationalCode = (string)i.NationalCode,
                                                                                          Age = (int)i.Age,
                                                                                          GenderId = (int)i.GenderId,
                                                                                          Job = (string)i.Job,
                                                                                          Presenter = (string)i.Presenter,
                                                                                          Phone = string.IsNullOrEmpty((string)i.MobilePhone) ? (string)i.FixedPhone : (string)i.MobilePhone,
                                                                                          Comment = (string)i.Comment,
                                                                                          IsDeleted = Convert.ToBoolean(i.IsDeleted),
                                                                                          DoctorTitle = (string)i.DoctorTitle,

                                                                                          BasicInsurer = (string)i.BI_InsurerTitle,
                                                                                          BI_InsuredNumber = (string)i.BI_InsuredNumber,


                                                                                          totalCharge = (double)i.Total_Patient_Charge,
                                                                                          totalPaid = (double)i.Total_Patient_Paid - (double)i.Total_Patient_Refund,
                                                                                          totalDiscount = (double)i.Total_Patient_Discount,
                                                                                          totalRemianed = (double)i.Total_Patient_Remianed,

                                                                                      }).ToList() : Enumerable.Empty<dynamic>();


                if (this.patientNameTxt.DataBindings["Tag"] == null)
                    this.patientNameTxt.DataBindings.Add("Tag", list, "PatientId");
                if (this.patientNameTxt.DataBindings["Text"] == null)
                    this.patientNameTxt.DataBindings.Add("Text", list, "PatientName");
                if (this.doctorTxt.DataBindings["Text"] == null)
                    this.doctorTxt.DataBindings.Add("Text", list, "DoctorTitle");
                if (this.patientNationalCodeTxt.DataBindings["Text"] == null)
                    this.patientNationalCodeTxt.DataBindings.Add("Text", list, "NationalCode", true);
                if (this.patientPresenterTxt.DataBindings["Text"] == null)
                    this.patientPresenterTxt.DataBindings.Add("Text", list, "Presenter");
                if (this.patientAgeTxt.DataBindings["Text"] == null)
                    this.patientAgeTxt.DataBindings.Add("Text", list, "Age");
                if (this.patientBasicInsurerTxt.DataBindings["Text"] == null)
                    this.patientBasicInsurerTxt.DataBindings.Add("Text", list, "BasicInsurer");
                if (this.patientPhoneTxt.DataBindings["Text"] == null)
                    this.patientPhoneTxt.DataBindings.Add("Text", list, "Phone");
                if (this.totalChargeTxt.DataBindings["Text"] == null)
                    this.totalChargeTxt.DataBindings.Add("Text", list, "totalCharge");
                if (this.totalDiscountTxt.DataBindings["Text"] == null)
                    this.totalDiscountTxt.DataBindings.Add("Text", list, "totalDiscount");
                if (this.totalPaidTxt.DataBindings["Text"] == null)
                    this.totalPaidTxt.DataBindings.Add("Text", list, "totalPaid");
                if (this.totalRemianedTxt.DataBindings["Text"] == null)
                    this.totalRemianedTxt.DataBindings.Add("Text", list, "totalRemianed");

                this.dataRepeater1.Visible = true;

                this.dataRepeater1.DataSource = list;



            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }
        #endregion


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
        }

        private void dataRepeater1_CurrentItemIndexChanged(object sender, EventArgs e)
        {
            if (dataRepeater1.CurrentItem == null)
            {
                this.patientClinicalInfoBtn.Enabled = false;
                return;
            }

            string patientId = Convert.ToString(dataRepeater1.CurrentItem.Controls["patientNameTxt"].Tag);

            this.patientClinicalInfoBtn.Enabled = true;

            //if (dataRepeater1.CurrentItem.Controls["patientNameTxt"].Tag == "0")
            //{
            //    //this.lowStockWarningLabel.Visible = true;
            //}
            //else
            //{
            //    //this.lowStockWarningLabel.Visible = false;
            //}
            foreach (Control c in dataRepeater1.Controls)
            {
                c.BackColor = Color.White;
            }
            dataRepeater1.CurrentItem.BackColor = Color.FromArgb(247, 247, 247);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {


            if (e.Argument == null)
                return;
            if (((IEnumerable<dynamic>)e.Argument).Count() > 0)
            {

                Button[] pationtInfo = new Button[((IEnumerable<dynamic>)e.Argument).Count()];
                int i = 0;
                foreach (dynamic obj in ((IEnumerable<dynamic>)e.Argument))
                {
                    //this.dataRepeater1.AddNew();
                }
            }
        }





        private void numberTxt_TextChanged(object sender, EventArgs e)
        {
            string txt = ((Label)sender).Text;
            if (string.IsNullOrEmpty(txt))
                return;
            double val = Convert.ToDouble(txt);
            ((Label)sender).Text = Publics.ToRial(val);
        }

        private void patientGeneralDocBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.بیماران_مشاهده_پرونده_عمومی_بیمار) == false)
                return;
            int patientId = Convert.ToInt32(Convert.ToString(dataRepeater1.CurrentItem.Controls["patientNameTxt"].Tag));

            PatientInfo form = new PatientInfo(patientId);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {

            }
            form.Dispose();

        }

        private void patientUpdateBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.بیماران_ویرایش) == false)
                return;

            if (dataRepeater1.CurrentItem == null)
                return;

            int patientId = Convert.ToInt32(Convert.ToString(dataRepeater1.CurrentItem.Controls["patientNameTxt"].Tag));

            PatientAdmission form = new PatientAdmission(patientId);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                this.FillDataGridView();
            form.Dispose();


        }

        private void patientDeleteBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.بیماران_حذف) == false)
                return;

            if (dataRepeater1.CurrentItem == null)
                return;

            int patientId = Convert.ToInt32(Convert.ToString(dataRepeater1.CurrentItem.Controls["patientNameTxt"].Tag));

            try
            {
                bool Flag;
                PatientDelete formDelete = new PatientDelete();
                formDelete.ShowDialog();
                if (formDelete.DialogResult == DialogResult.Yes)
                {
                    dynamic iObj = new System.Dynamic.ExpandoObject();
                    iObj.ActionType = "Edit";
                    iObj.PatientId = patientId;
                    iObj.Comment = formDelete.textBoxComment.Text.Trim();
                    iObj.IsDeleted = true;

                    JsonResponse<dynamic> result = Dentistry.Provider.DefinePatientX(iObj);

                    if (result.Success == false)
                    {
                        FarsiMessageBox.FMessageBox.Show(result.Message, "خطا", FMessageBoxButtons.OK, FMessageBoxIcons.Error, FMessageBoxDefaultButtons.Button1);
                        return;
                    }

                    this.FillDataGridView();
                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());

            }
        }



        private void blackListBtn_Click(object sender, EventArgs e)
        {
            BlackList form = new BlackList();

            var result = form.ShowDialog();
            if (result == DialogResult.OK)
            {
                this.FillDataGridView();
            }

        }

        private void patientRegisterBtn_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.بیماران_جدبد) == false)
                return;
            PatientAdmission form = new PatientAdmission();

            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.FillDataGridView();
            }

            form.Dispose();
        }



        private void patientsSearchBtn_Click(object sender, EventArgs e)
        {
            this.FillDataGridView();
        }

        private void clinicPatients_KeyDown(object sender, KeyEventArgs e)
        {
            #region F2
            if (e.KeyCode == Keys.F2)
            {
                this.patientRegisterBtn_Click(this, null);
            }
            #endregion

            #region F4
            if (e.KeyCode == Keys.F4 && e.Modifiers != Keys.Alt)
            {
                if (this.patientUpdateBtn.Enabled == true)
                    this.patientUpdateBtn_LinkClicked(this, null);
            }
            #endregion

            #region F8
            if (e.KeyCode == Keys.F8)
            {
                if (this.patientDeleteBtn.Enabled == true)
                    this.patientDeleteBtn_LinkClicked(this, null);
            }
            #endregion

            #region Enter for Search
            if (e.KeyCode == Keys.Enter)
                patientsSearchBtn_Click(sender, e);
            #endregion
        }

        private void patientClinicalInfoBtn_Click(object sender, EventArgs e)
        {
            Form form = new PatientClinical(0);
            form.ShowDialog(this);
            form.Dispose();
        }

        private void debtorPatientsChk_CheckedChanged(object sender, EventArgs e)
        {
            if (((CheckBox)sender).Checked == true)
                this.creditorPatientsChk.Checked = false;
        }

        private void creditorPatientsChk_CheckedChanged(object sender, EventArgs e)
        {
            if (this.creditorPatientsChk.Checked == true)
                this.debtorPatientsChk.Checked = false;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, Color.Silver, ButtonBorderStyle.Solid);
        }
    }
}
