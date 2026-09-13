using FarsiMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry
{
    public partial class StaffDefine : Form
    {
        Thread ShowOpenFileDialog;
        public string EditOrNewFlag;
        int? StaffId = null;
        int? UserId = null;

        public StaffDefine()
        {
            InitializeComponent();

            this.EditOrNewFlag = "New";
            this.pictureBox.Image = global::Dentistry.Properties.Resources.Default;


            this.recruitmentDateCbo.Value = (Dentistry.UserControls.PersianDate)DateTime.Now;
        }

        public StaffDefine(int staffId)
        {
            InitializeComponent();

            this.EditOrNewFlag = "Edit";

            this.StaffId = staffId;
        }

        private void StaffDefine_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();
            if (this.EditOrNewFlag == "Edit" && this.StaffId != null)
                FetchStaffInfo(this.StaffId.Value);
        }

        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new
            {
                IsGender = true,
                IsStaffType = true,
                IsSpecialty = true,
            };
            var result = Dentistry.DataProvider.LoadFormInitInfo(sObj);
            if (result != null && result.Success == false && result.Data == null)
                return;

            var dd = result.Data;


            IEnumerable<dynamic> staffTypeList = dd.StaffType != null && (Enumerable.Count(dd.StaffType) > 0) ? (dd.StaffType as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList() : null;
            IEnumerable<dynamic> specialtyList = dd.Specialty != null && (Enumerable.Count(dd.Specialty) > 0) ? (dd.Specialty as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList() : null;
            IEnumerable<dynamic> genderList = dd.Gender != null && (Enumerable.Count(dd.Gender) > 0) ? (dd.Gender as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList() : null;


            this.staffTypeCbo.DataSource = staffTypeList;
            this.staffTypeCbo.ValueMember = "Id";
            this.staffTypeCbo.DisplayMember = "Title";

            this.specialtyCbo.DataSource = specialtyList;
            this.specialtyCbo.ValueMember = "Id";
            this.specialtyCbo.DisplayMember = "Title";

            this.genderCbo.DataSource = genderList;
            this.genderCbo.ValueMember = "Id";
            this.genderCbo.DisplayMember = "Title";


        }
        #endregion

        public void FetchStaffInfo(int staffId)
        {
            try
            {

                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.StaffId = staffId;

                JsonResponse<dynamic> result = Dentistry.DataProvider.GetStaffsX(sObj);
                if (result == null || result.Success == false || result.Data == null)
                    return;

                var dd = result.Data;
                var obj = (dd != null && Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).FirstOrDefault() : null;

                if (obj != null)
                {
                    if (Publics.IsPropertyExist(obj, "FirstName") && obj.FirstName != null)
                        this.firstNameTxt.Text = obj.FirstName;
                    if (Publics.IsPropertyExist(obj, "LastName") && obj.LastName != null)
                        this.lastNameTxt.Text = obj.LastName;
                    if (Publics.IsPropertyExist(obj, "MobilePhone") && obj.MobilePhone != null)
                        this.mobilePhoneTxt.Text = obj.MobilePhone;
                    if (Publics.IsPropertyExist(obj, "Address") && obj.Address != null)
                        this.AddressTxt.Text = obj.Address;
                    if (Publics.IsPropertyExist(obj, "NationalCode") && obj.NationalCode != null)
                        this.nationalCodeTxt.Text = obj.NationalCode;
                    if (Publics.IsPropertyExist(obj, "Comment") && obj.Comment != null)
                        this.CommentTxt.Text = obj.Comment;

                    var staffTypeId = Publics.GetPropertyValue<int>(obj, "StaffTypeId");
                    this.staffTypeCbo.SelectedIndex = Publics.GetComboIndex(this.staffTypeCbo, staffTypeId);

                    var specialtyId = Publics.GetPropertyValue<int>(obj, "SpecialtyId");
                    this.specialtyCbo.SelectedIndex = Publics.GetComboIndex(this.specialtyCbo, specialtyId);

                    var genderId = Publics.GetPropertyValue<int>(obj, "GenderId");
                    this.genderCbo.SelectedIndex = Publics.GetComboIndex(this.genderCbo, genderId);

                    if (obj.Date != null)
                        this.recruitmentDateCbo.Value = (DateTime)obj.Date;


                    if (Publics.IsPropertyExist(obj, "Picture") && obj.Picture != null)
                    {
                        byte[] RegistrationImage = (byte[])obj.Picture;
                        MemoryStream memoryStream = new MemoryStream(RegistrationImage, 0, RegistrationImage.Length);
                        pictureBox.Image = Image.FromStream(memoryStream);
                    }


                    this.UserId = obj.UserId;

                    if (Convert.ToBoolean(obj.IsDeleted) == true)
                        this.IsDeActiveChk.Checked = true;
                    else
                        this.IsActiveChk.Checked = true;
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }
        #region ValidateForm
        private bool ValidateForm()
        {

            bool Flag = true;
            if (string.IsNullOrEmpty(this.firstNameTxt.Text.Trim()))
            {
                this.Error_FirstNameTxt.Visible = true;
                Flag = false;
            }
            else
                this.Error_FirstNameTxt.Visible = false;


            if (string.IsNullOrEmpty(this.lastNameTxt.Text.Trim()))
            {
                this.Error_LastNameTxt.Visible = true;
                Flag = false;
            }
            else
                this.Error_LastNameTxt.Visible = false;









            return Flag;

        }
        #endregion        
        private void okBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.ValidateForm() == false)
                    return;

                MemoryStream memoryStream = new MemoryStream();
                pictureBox.Image.Save(memoryStream, pictureBox.Image.RawFormat);
                byte[] RegisterationImage = (byte[])memoryStream.GetBuffer();
                memoryStream.Close();

                int? staffId = null;

                dynamic iObj = new ExpandoObject();
                iObj.ActionType = EditOrNewFlag;

                iObj.StaffTypeId = int.Parse(this.staffTypeCbo.SelectedValue.ToString());
                iObj.FirstName = Publics.RemoveSpaces(this.firstNameTxt.Text.Trim());
                iObj.LastName = Publics.RemoveSpaces(this.lastNameTxt.Text.Trim());
                iObj.NationalCode = Publics.RemoveSpaces(this.nationalCodeTxt.Text.Trim());
                iObj.MedicalCouncilCode = null;
                iObj.GenderId = Convert.ToInt32(this.genderCbo.SelectedValue);
                iObj.Date = Class.Date.ToChristianByTime(this.recruitmentDateCbo.Value.ToString());

                iObj.SpecialtyId = this.specialtyCbo.SelectedValue;
                iObj.MobilePhone = this.mobilePhoneTxt.Text.Trim();
                iObj.Address = this.AddressTxt.Text.Trim();
                iObj.Comment = this.CommentTxt.Text.Trim();
                iObj.Picture = RegisterationImage;

                iObj.IsDeleted = IsActiveChk.Checked == true ? false : true;

                if (EditOrNewFlag == "Edit")
                    iObj.StaffId = this.StaffId;

                JsonResponse<dynamic> result = Dentistry.DataProvider.DefineStaffX(iObj);

                if (result != null && result.Success == true && result.Data != null)
                {
                    this.StaffId = Convert.ToInt32(result.Data.StaffId);
                    FMessageBox.Show(Dentistry.AppConfigs.strSuccessRegister, Dentistry.AppConfigs.strRegister, FMessageBoxButtons.OK);
                }

                this.Close();
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }

        private void buttonOpenPic_Click(object sender, EventArgs e)
        {
            try
            {

                ShowOpenFileDialog = new Thread(this.OpenFileDialog);

                if (ShowOpenFileDialog.ThreadState == ThreadState.Unstarted)
                {
                    ShowOpenFileDialog.SetApartmentState(ApartmentState.STA);
                    ShowOpenFileDialog.Start();
                }
                else if (ShowOpenFileDialog.ThreadState == ThreadState.Stopped)
                {
                    ShowOpenFileDialog.Start();
                    ShowOpenFileDialog.Join();
                }
            }
            catch (Exception exp)
            {
                ShowOpenFileDialog.Abort();
            }
        }

        #region OpenFileDialog
        public void OpenFileDialog()
        {

            OpenFileDialog OpenFileDialog = new OpenFileDialog();
            OpenFileDialog.Filter = "Image files" +
            " (*.gif,*.jpg,*.jpeg,*.bmp,*.wmf,*.png)" +
            "|*.gif;*.jpg;*.jpeg;*.bmp;*.wmf;*.png|All" +
            " files (*.*)|*.*";
            OpenFileDialog.FilterIndex = 1;
            OpenFileDialog.Title = "Open Picture Files";

            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {

                Image Image = Image.FromFile(OpenFileDialog.FileName);
                this.pictureBox.Image = Image;
            }
        }
        #endregion

        private void buttonDeletePic_Click(object sender, EventArgs e)
        {
            this.pictureBox.Image = global::Dentistry.Properties.Resources.Default;
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, Color.Silver, ButtonBorderStyle.Solid);
        }

    }
}
