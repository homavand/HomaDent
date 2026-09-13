using FarsiMessageBox;
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
    public partial class InsurerDefine : Form
    {
        string EditOrNewFlag = "New";
        public int InsurerId = -1;
        public string InsurerTitle = "";
        public InsurerDefine()
        {
            InitializeComponent();
        }
        #region FormNewIll_OverLoaded
        public InsurerDefine(int insurerId)
        {
            InitializeComponent();

            this.EditOrNewFlag = "Edit";
            this.InsurerId = insurerId;
        

        }
        #endregion

        private void InsurerDefine_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();

            this.InsuranceCbo.SelectedIndex = -1;
            this.InsuranceBoxCbo.SelectedIndex = -1;
          

            if (EditOrNewFlag == "Edit")
            {
                this.FetchInsurerInfo(this.InsurerId);
            }
        }

        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new
            {
                EntityName = "BaseCoding_Insurances"
            };
            var result = Dentistry.DataProvider.GetBaseCodingX(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;

            var insuranceList = dd != null && dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;
            this.InsuranceCbo.SelectedIndexChanged -= new EventHandler(this.InsuranceCbo_SelectedIndexChanged);
            this.InsuranceCbo.DataSource = insuranceList;
            this.InsuranceCbo.ValueMember = "Id";
            this.InsuranceCbo.DisplayMember = "Title";

            if (this.InsuranceCbo.Items.Count > 0 && this.InsuranceCbo.Items.Count <= 2)
            {
                InsuranceCbo.SelectedIndex = 1;
            }
            this.InsuranceCbo.SelectedIndexChanged += new EventHandler(InsuranceCbo_SelectedIndexChanged);


            sObj = new
            {
                EntityName = "BaseCoding_InsuranceBoxs"
            };
            result = Dentistry.DataProvider.GetBaseCodingX(sObj);
            dd = result != null && result.Data != null ? result.Data : null;
           
            var insuranceBoxList = dd != null && dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;
            this.InsuranceBoxCbo.SelectedIndexChanged -= new EventHandler(this.InsuranceBoxCbo_SelectedIndexChanged);
            this.InsuranceBoxCbo.DataSource = insuranceBoxList;
            this.InsuranceBoxCbo.ValueMember = "Id";
            this.InsuranceBoxCbo.DisplayMember = "Title";
            if (this.InsuranceBoxCbo.Items.Count > 0 && this.InsuranceBoxCbo.Items.Count <= 2)
            {
                InsuranceBoxCbo.SelectedIndex = 1;
            }
            this.InsuranceBoxCbo.SelectedIndexChanged += new EventHandler(InsuranceBoxCbo_SelectedIndexChanged);


        }
        #endregion

        public void FetchInsurerInfo(int insurerId)
        {
            try
            {

                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.InsurerId = insurerId;



                JsonResponse<dynamic> result = DataProvider.GetInsurersX(sObj);
                if (result.Success != true || result.Data == null)
                    return;

                var dd = result.Data;
                var obj = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).FirstOrDefault() : null;

                if (obj == null)
                    return;

                var insuranceId = Publics.GetPropertyValue<int>(obj, "InsuranceId");
                this.InsuranceCbo.SelectedIndex = Publics.GetComboIndex(this.InsuranceCbo, insuranceId);
                //this.InsuranceCbo.SelectedValue = Convert.ToInt32(obj.InsuranceId);

                var insuranceBoxId = Publics.GetPropertyValue<int>(obj, "InsuranceBoxId");
                this.InsuranceBoxCbo.SelectedIndex = Publics.GetComboIndex(this.InsuranceBoxCbo, insuranceBoxId);
                //this.InsuranceBoxCbo.SelectedValue = Convert.ToInt32(obj.InsuranceBoxId);

                this.InsurerTitleTxt.Text = obj.InsurerTitle;


                if (Convert.ToBoolean(obj.IsDeleted) == true)
                    this.IsDeActiveChk.Checked = true;
                else
                    this.IsActiveChk.Checked = true;

                if (obj.IsBasic == true)
                    IsBasicChk.Checked = true;
                else
                    IsBasicChk.Checked = false;

                if (obj.IsExtra == true)
                    IsExtraChk.Checked = true;
                else
                    IsExtraChk.Checked = false;

                this.PercentTxt.Text = Convert.ToString(obj.InsurerPercent);
                this.CommentTxt.Text = obj.Comment;

            


            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }

        public bool ValidateForm()
        {
            bool Flag = true;
            if (this.InsuranceCbo.SelectedIndex < 0)
            {
                this.Error_InsuranceCbo.Visible = true;
                Flag = false;
            }
            else
                this.Error_InsuranceCbo.Visible = false;


   


            if (string.IsNullOrEmpty(this.PercentTxt.Text))
            {
                this.Error_PercentTxt.Visible = true;
                Flag = false;
            }
            else
                this.Error_PercentTxt.Visible = false;

           

            if (IsBasicChk.Checked == false && IsExtraChk.Checked == false)
            {
                FMessageBox.Show("لطفا نوع بیمه مشخص گردد", "خطا", FMessageBoxButtons.OK, FMessageBoxIcons.Error);
                Flag = false;
            }




            return Flag;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm() == false)
                return;
            try
            {
                
                JsonResponse<dynamic> result = null;               
                dynamic iObj = new ExpandoObject();
                iObj.ActionType = this.EditOrNewFlag;                
                iObj.InsuranceId = this.InsuranceCbo.SelectedValue != null ? int.Parse(this.InsuranceCbo.SelectedValue.ToString()) : (int?)null;
                iObj.InsuranceBoxId = this.InsuranceBoxCbo.SelectedValue != null ? int.Parse(this.InsuranceBoxCbo.SelectedValue.ToString()) : (int?)null;
                iObj.InsurerTitle = this.InsurerTitleTxt.Text.Trim();                
                iObj.IsDeleted = IsActiveChk.Checked == true ? false : true;


                iObj.InsurerPercent = this.PercentTxt.Text.Trim();
                iObj.IsBasic = this.IsBasicChk.Checked;
                iObj.IsExtra = this.IsExtraChk.Checked;
                iObj.Comment = this.CommentTxt.Text;

                if(this.EditOrNewFlag == "Edit")
                    iObj.Id = this.InsurerId;

                result = Dentistry.DataProvider.DefineInsurerX(iObj);

                if (result != null && result.Success == true && result.Data != null)
                {
                    this.InsurerId = Convert.ToInt32(result.Data.Id);
                    this.DialogResult = DialogResult.OK;
                  
                }
                



                this.Close();
            }
            catch (System.Exception exp)
            {
                ErrorClass.WriteErrorsToFile(this.Name, exp.TargetSite.Name.ToString(), exp.Message, DateTime.Now);
            }

        }

        private void InsuranceCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string insuranceTitle = string.IsNullOrEmpty(((ComboBox)sender).Text) ? "" : ((ComboBox)sender).Text ;
            string insuranceBoxTitle = InsuranceBoxCbo.Text;

            this.InsurerTitle = string.Format("{0} - {1}", insuranceTitle, insuranceBoxTitle);
            this.InsurerTitle = this.InsurerTitle.ToString().TrimEnd().TrimEnd('-');
            this.InsurerTitleTxt.Text = this.InsurerTitle;
        }

        private void InsuranceBoxCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string insuranceBoxTitle = string.IsNullOrEmpty(((ComboBox)sender).Text) ? "" : ((ComboBox)sender).Text;
            string insuranceTitle = InsuranceCbo.Text;

            this.InsurerTitle = string.Format("{0} - {1}", insuranceTitle, insuranceBoxTitle);

            this.InsurerTitleTxt.Text = this.InsurerTitle;
        }

        private void PercentTxt_TextChanged(object sender, EventArgs e)
        {
            int val = string.IsNullOrEmpty(((TextBox)sender).Text) ? 0 : Convert.ToInt32(((TextBox)sender).Text);
            if (val < 0)
                ((TextBox)sender).Text = "0";
            if(val > 100)
                ((TextBox)sender).Text = "100";
        }
    }
}
