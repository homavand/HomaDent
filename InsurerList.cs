using FarsiMessageBox;
using PopupControl;
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
    public partial class InsurerList : Form
    {
       
        public InsurerList()
        {
            InitializeComponent();
            this.LoadFormInit();
            this.FillDataGridView_dgInsurers();
            this.dgColumnOrder();
        }

        private void InsurerList_Load(object sender, EventArgs e)
        {
            
        }

        #region LoadFormInit
        private void LoadFormInit()
        {

            dynamic sObj = new
            {
                IsInsurance = true,
                IsInsuranceBox = true,
            };
            var data = DataProvider.LoadFormInitInfo(sObj);
            var dd = data != null && data.Data != null ? data.Data : null;

            if (dd == null)
                return;

            var insuranceList = dd != null && dd.Insurance != null && (Enumerable.Count(dd.Insurance) > 0) ? (dd.Insurance as IEnumerable<dynamic>).Select(i => i).ToList() : null;
            var insuranceBoxList = dd != null && dd.InsuranceBox != null && (Enumerable.Count(dd.InsuranceBox) > 0) ? (dd.InsuranceBox as IEnumerable<dynamic>).Select(i => i).ToList() : null;          
            

            this.InsuranceCbo.DataSource = insuranceList;
            this.InsuranceCbo.ValueMember = "Id";
            this.InsuranceCbo.DisplayMember = "Title";

            this.InsuranceBoxCbo.DataSource = insuranceBoxList;
            this.InsuranceBoxCbo.ValueMember = "Id";
            this.InsuranceBoxCbo.DisplayMember = "Title";
        }
        #endregion

        private void dgColumnOrder()
        {
            dgInsurers.AutoGenerateColumns = false;
            dgInsurers.Columns["ColumnInsurerId"].Visible = false;
            dgInsurers.Columns["ColumnIsBasic"].Visible = false;
            dgInsurers.Columns["ColumnIsExtra"].Visible = false;
            dgInsurers.Columns["ColumnIsDeleted"].Visible = false;
            dgInsurers.Columns["ColumnInsurerTitle"].DisplayIndex = 0;
            dgInsurers.Columns["ColumnInsuranceTitle"].DisplayIndex = 1;
            dgInsurers.Columns["ColumnInsuranceBoxTitle"].DisplayIndex = 2;
            dgInsurers.Columns["ColumnOutPatientPercent"].DisplayIndex = 3;
            dgInsurers.Columns["ColumnIsBasicImg"].DisplayIndex = 4;
            dgInsurers.Columns["ColumnIsExtraImg"].DisplayIndex = 5;
            dgInsurers.Columns["ColumnIsDeletedPic"].DisplayIndex = 6;
        }

        private void FillDataGridView_dgInsurers()
        {

            dynamic sObj = new System.Dynamic.ExpandoObject();

            if (this.InsuranceCbo.SelectedIndex > 0)
                sObj.InsuranceId = Convert.ToInt32(this.InsuranceCbo.SelectedValue);

            if (this.InsuranceBoxCbo.SelectedIndex > 0)
                sObj.InsuranceBoxId = Convert.ToInt32(this.InsuranceBoxCbo.SelectedValue);

            if (!string.IsNullOrEmpty(this.InsurerTxt.Text))
                sObj.InsurerTitle = this.InsurerTxt.Text;

            if (Convert.ToBoolean(this.IsDeletedChk.Checked) != true)
                sObj.IsDeleted = false;

            var data = DataProvider.GetInsurersX(sObj);
            var dd = data != null && data.Data != null ? data.Data : null;

            if (dd == null)
                return;

            IEnumerable<dynamic> insurerList = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select( i =>
             new
             {
                 i.InsurerId,
                 i.InsurerTitle,
                 i.InsuranceTitle,
                 i.InsuranceBoxTitle,
                 i.IsDeleted,
                
                 i.IsBasic,
                 i.IsExtra,
                 i.InsurerPercent
             }
              
            ).OrderBy(i => i.InsurerId).ToList() : Enumerable.Empty<dynamic>();

            this.dgInsurers.DataSource = insurerList;

            
        }

        #region ButtonNew_Click
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_بیمه_گرها_جدبد) == false)
                return;

            InsurerDefine form = new InsurerDefine();
            var result = form.ShowDialog(this);
            if(result == DialogResult.OK)
                this.FillDataGridView_dgInsurers();
            form.Dispose();
            
        }
        #endregion

        #region ButtonEdit_Click
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_بیمه_گرها_ویرایش) == false)
                return;


            try
            {
                
                if (this.dgInsurers.CurrentCell == null)
                    return;

                InsurerDefine form = new InsurerDefine(Convert.ToInt32(this.dgInsurers["ColumnInsurerId", this.dgInsurers.CurrentRow.Index].Value));
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                    this.FillDataGridView_dgInsurers();
                form.Dispose();
               

            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }
        #endregion

        #region ButtonDelete_Click
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_بیمه_گرها_حذف) == false)
                return;

            if (this.dgInsurers.CurrentCell == null)
                return;
            
            try
            {
                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    dynamic iObj = new ExpandoObject();
                    iObj.ActionType = "Edit";
                    iObj.Id = Convert.ToInt32(this.dgInsurers["ColumnInsurerId", this.dgInsurers.CurrentRow.Index].Value);
                    iObj.IsDeleted = true;

                    if (iObj.Id == 0)
                    {
                        FMessageBox.Show(Dentistry.AppConfigs.strZeroItemDelete, Dentistry.AppConfigs.strCaptionInformation, FMessageBoxButtons.OK, FMessageBoxIcons.Information);
                        return;
                    }

                    JsonResponse<dynamic> result = DataProvider.DefineInsurerX(iObj);
                 
                    if (result != null && result.Success == true && result.Data != null)
                    {
                        this.FillDataGridView_dgInsurers();
                    }


                    
                }
            }
            catch (System.Exception exp)
            {
                ErrorClass.WriteErrorsToFile(this.Name, exp.TargetSite.Name.ToString(), exp.Message, DateTime.Now);
                this.Close();

            }
        }
        #endregion


    
      

     

        private void dgInsurers_CellFormatting()
        {
            try
            {
                foreach (DataGridViewRow row in this.dgInsurers.Rows)
                {
                    if (Convert.ToBoolean(this.dgInsurers["ColumnIsDeleted", row.Index].Value) == false)
                    {
                        this.dgInsurers.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                        ((DataGridViewImageCell)this.dgInsurers["ColumnIsDeletedPic", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.tinyCheck;
                    }
                    else
                    {
                        this.dgInsurers.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Crimson;
                        ((DataGridViewImageCell)this.dgInsurers["ColumnIsDeletedPic", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.emptyPoint;
                    }
                    if (Convert.ToBoolean(this.dgInsurers["ColumnIsDeleted", row.Index].Value) == true)
                        this.dgInsurers.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Red;

                    if (Convert.ToBoolean(this.dgInsurers["ColumnIsBasic", row.Index].Value) == true)
                        ((DataGridViewImageCell)this.dgInsurers["ColumnIsBasicImg", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.Ok2;
                    else
                        ((DataGridViewImageCell)this.dgInsurers["ColumnIsBasicImg", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.emptyPoint;

                    if (Convert.ToBoolean(this.dgInsurers["ColumnIsExtra", row.Index].Value) == true)
                        ((DataGridViewImageCell)this.dgInsurers["ColumnIsExtraImg", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.Ok2;
                    else
                        ((DataGridViewImageCell)this.dgInsurers["ColumnIsExtraImg", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.emptyPoint;

                }

                
              
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
                       
        }

       

        private void dgInsurers_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgInsurers_CellFormatting();
        }
       
        private void dgInsurers_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.ButtonEdit_Click(this, null);
        }

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.FillDataGridView_dgInsurers();
        }
    }
}
