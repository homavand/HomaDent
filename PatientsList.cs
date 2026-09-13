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
    public partial class PatientsList : Form
    {

        TextBox qText;

        public PatientsList()
        {
            InitializeComponent();
            this.LoadFormInit();
        }

        private void PatientsGrid_Load(object sender, EventArgs e)
        {
            this.sortByCodeRdo.Checked = true;

            this.FillDataGridView();
            this.FirstNameTxt.GotFocus += new EventHandler(this.FirstNameTxt_GotFocus);
            this.LastNameTxt.GotFocus += new EventHandler(this.LastNameTxt_GotFocus);

            
        }

        private void PatientsList_Shown(object sender, EventArgs e)
        {

        }

        private void PatientsList_Activated(object sender, EventArgs e)
        {

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

            var doctors = Publics.AddDefaultItemToComboDynamicList(doctorList);


            this.doctorCbo.SelectedIndexChanged -= new EventHandler(doctorCbo_SelectedIndexChanged);
            this.doctorCbo.DataSource = doctors;
            this.doctorCbo.ValueMember = "Id";
            this.doctorCbo.DisplayMember = "Title";
            if (this.doctorCbo.Items.Count < 2)
            {
                doctorCbo.SelectedIndex = 1;
            }
            if (Dentistry.AppConfigs.SelectedDoctorId != -1)
            {
                this.doctorCbo.SelectedIndex = Publics.GetComboIndex(this.doctorCbo, Dentistry.AppConfigs.SelectedDoctorId);
            }
            this.doctorCbo.SelectedIndexChanged += new EventHandler(doctorCbo_SelectedIndexChanged);

            /////////////////////////////////////////////////////////////////////////////////////////////

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

            this.insurerCbo.DataSource = list;
            this.insurerCbo.ValueMember = "Id";
            this.insurerCbo.DisplayMember = "Title";
        }
        #endregion

        private void doctorCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Windows.Forms.ComboBox cbo = (System.Windows.Forms.ComboBox)sender;

            Dentistry.AppConfigs.SelectedDoctorId = Convert.ToInt32(cbo.SelectedValue);

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

                if (doctorCbo.SelectedValue != null && int.Parse(doctorCbo.SelectedValue.ToString()) > -1)
                    sObj.DoctorId = doctorCbo.SelectedValue;
                if (insurerCbo.SelectedValue != null && int.Parse(insurerCbo.SelectedValue.ToString()) > -1)
                    sObj.insurerId = insurerCbo.SelectedValue;
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

                JsonResponse<dynamic> result = Dentistry.DataProvider.GetListPatientInfoX(sObj);
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
                                                                                          RegisterDate = (string)i.SolarDate,
                                                                                          Age = (int)i.Age,
                                                                                          GenderId = (int)i.GenderId,                                                                                     
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

                if (this.sortByCodeRdo.Checked == true)
                    list = list.OrderBy(i => i.PatientId).ToList();

                if (this.sortByNameRdo.Checked == true)
                    list = list.OrderBy(i => i.PatientName).ToList();

                if (this.rxPatientNameTxt.DataBindings["Tag"] == null)
                    this.rxPatientNameTxt.DataBindings.Add("Tag", list, "PatientId");
                if (this.rxPatientNameTxt.DataBindings["Text"] == null)
                    this.rxPatientNameTxt.DataBindings.Add("Text", list, "PatientName");
                if (this.rxPatientRegisterDateTxt.DataBindings["Text"] == null)
                    this.rxPatientRegisterDateTxt.DataBindings.Add("Text", list, "RegisterDate");
                if (this.rxDoctorTxt.DataBindings["Text"] == null)
                    this.rxDoctorTxt.DataBindings.Add("Text", list, "DoctorTitle");
                if (this.rxPatientNationalCodeTxt.DataBindings["Text"] == null)
                    this.rxPatientNationalCodeTxt.DataBindings.Add("Text", list, "NationalCode", true);
                if (this.rxPatientPresenterTxt.DataBindings["Text"] == null)
                    this.rxPatientPresenterTxt.DataBindings.Add("Text", list, "Presenter");
                if (this.rxPatientAgeTxt.DataBindings["Text"] == null)
                    this.rxPatientAgeTxt.DataBindings.Add("Text", list, "Age");
                if (this.rxPatientBasicInsurerTxt.DataBindings["Text"] == null)
                    this.rxPatientBasicInsurerTxt.DataBindings.Add("Text", list, "BasicInsurer");
                if (this.rxPatientPhoneTxt.DataBindings["Text"] == null)
                    this.rxPatientPhoneTxt.DataBindings.Add("Text", list, "Phone");
                if (this.rxTotalChargeTxt.DataBindings["Text"] == null)
                    this.rxTotalChargeTxt.DataBindings.Add("Text", list, "totalCharge");
                if (this.rxTotalDiscountTxt.DataBindings["Text"] == null)
                    this.rxTotalDiscountTxt.DataBindings.Add("Text", list, "totalDiscount");
                if (this.rxTotalPaidTxt.DataBindings["Text"] == null)
                    this.rxTotalPaidTxt.DataBindings.Add("Text", list, "totalPaid");
                if (this.rxTotalRemianedTxt.DataBindings["Text"] == null)
                    this.rxTotalRemianedTxt.DataBindings.Add("Text", list, "totalRemianed");

                if (this.rxPatientGenderImg.DataBindings["Tag"] == null)
                    this.rxPatientGenderImg.DataBindings.Add("Tag", list, "GenderId");


                this.dataRepeater1.Visible = true;

                this.dataRepeater1.DataSource = list;

                this.dataRepeater1.Refresh();


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

            Control ctr = e.DataRepeaterItem.Controls["patientGenderImg"];
            if (ctr != null)
            {
                PictureBox imgCtr = (PictureBox)ctr;
                string genderId = Convert.ToString(imgCtr.Tag);

                imgCtr.Image = null;
                if (genderId == "1")
                    imgCtr.Image = global::Dentistry.Properties.Resources.male;
                if (genderId == "2")
                    imgCtr.Image = global::Dentistry.Properties.Resources.female;
            }
            HandleItem(e.DataRepeaterItem);
        }

        private void dataRepeater1_CurrentItemIndexChanged(object sender, EventArgs e)
        {
            if (dataRepeater1.CurrentItem == null)
            {
               
                return;
            }

            var control = dataRepeater1.CurrentItem.Controls["patientNameTxt"];

            string patientId = Convert.ToString(control.Tag);



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



        private void numberTxt_TextChanged(object sender, EventArgs e)
        {
            Control ctr = (Label)sender;
            string txt = ctr.Text;
            if (string.IsNullOrEmpty(txt))
                return;
            double val = Convert.ToDouble(txt);
            ctr.Text = Publics.ToRial(val);
            
            if (ctr.Name == "totalRemianedTxt")
            {
                if(val < 0)
                    ctr.BackColor = System.Drawing.Color.AliceBlue;
                else
                    ctr.BackColor = System.Drawing.Color.LavenderBlush;
            }
        }

        private void patientGeneralDocBtn_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.بیماران_مشاهده_پرونده_عمومی_بیمار) == false)
                return;

            var control = dataRepeater1.CurrentItem.Controls["patientNameTxt"];

            if (control == null)
                return;

            int patientId = Convert.ToInt32(Convert.ToString(control.Tag));

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

            var control = dataRepeater1.CurrentItem.Controls["patientNameTxt"];

            if (control == null)
                return;

            int patientId = Convert.ToInt32(Convert.ToString(control.Tag));

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

            var control = dataRepeater1.CurrentItem.Controls["patientNameTxt"];

            if (control == null)
                return;

            int patientId = Convert.ToInt32(Convert.ToString(control.Tag));

            try
            {
                bool Flag;
                PatientDelete formDelete = new PatientDelete();
                formDelete.ShowDialog();
                if (formDelete.DialogResult == DialogResult.OK)
                {
                    dynamic iObj = new System.Dynamic.ExpandoObject();
                    iObj.ActionType = "Edit";
                    iObj.PatientId = patientId;
                    iObj.Comment = formDelete.textBoxComment.Text.Trim();
                    iObj.IsDeleted = true;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientX(iObj);

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
            PatientsBlackList form = new PatientsBlackList();

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
                if (this.rxPatientUpdateBtn.Enabled == true)
                    this.patientUpdateBtn_LinkClicked(this, null);
            }
            #endregion

            #region F8
            if (e.KeyCode == Keys.F8)
            {
                if (this.rxPatientDeleteBtn.Enabled == true)
                    this.patientDeleteBtn_LinkClicked(this, null);
            }
            #endregion

            #region Enter for Search
            if (e.KeyCode == Keys.Enter)
                patientsSearchBtn_Click(sender, e);
            #endregion
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

     

        private void SetCharItems()
        {
            int x = this.FaCharPnl.Right - 17;
            int y = this.FaCharPnl.Top;

            this.FaCharPnl.Size = new Size(850, 95);

            int j = 0;
            for (int i = 1; i <= 31; i++)
            {
                string id = "btn" + i;

                if (i == 17)
                {
                    j = 0;
                    x = this.FaCharPnl.Right - 17;
                    y = y + 40;
                }

                j++;
                var btn = this.FaCharPnl.Controls.Find(id, true)[0];
                btn.Size = new Size(36, 32);
                btn.Location = new Point(x - j * (btn.Width + 10), y + 4);
            }

        }

        private void btnChar_Click(object sender, EventArgs e)
        {
            Button btn = ((Button)sender);
            
            if (this.qText == null)
                this.qText = this.FirstNameTxt;

            TextBox txt = this.qText;
            txt.Focus();
            string str = txt.Text;
            txt.Text = str + btn.Tag.ToString();
            txt.SelectionStart = txt.Text.Length;
            txt.SelectionLength = 0;


        }

        private void FirstNameTxt_GotFocus(Object sender, EventArgs e)
        {

            this.qText = (TextBox)sender;
        }

        private void LastNameTxt_GotFocus(Object sender, EventArgs e)
        {
            this.qText = (TextBox)sender;
        }

        private void PatientNameTxt_TextChanged(object sender, EventArgs e)
        {
            this.FillDataGridView();
        }

        private void FaSwitchBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //FaSwitchBtn.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            //EnSwitchBtn.FlatAppearance.BorderColor = Color.Silver;
        }

        private void EnSwitchBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            //EnSwitchBtn.FlatAppearance.BorderColor = Color.DeepSkyBlue;
            //FaSwitchBtn.FlatAppearance.BorderColor = Color.Silver;
        }
    }
}
