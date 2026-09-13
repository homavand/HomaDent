using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiMessageBox;
using PopupControl;
using System.Dynamic;
using System.Linq;
using DNTPersianUtils.Core;

namespace Dentistry
{
    public partial class InsuranceFinancialList : Form
    {
        PopupControl.Popup p;

        bool SearchType = false;

        #region FormInsurance
        public InsuranceFinancialList()
        {
            InitializeComponent();

           

        }
       

        private void InsuranceFinancialList_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();
            this.FillDataGridView_dgInsurerFinancials();
            this.dgInsurerFinancials_ColumnOrder();
        }

       
        private void FormInsurance_Activated(object sender, EventArgs e)
        {
            this.dgInsurerFinancials.CurrentCell = null;
            this.insurerCbo.Focus();
        }
        #endregion

        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();

            var result = Dentistry.DataProvider.GetInsurersX(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;
           
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
            this.insurerCbo.SelectedIndex = 0;

            //this.insurerCbo.SelectedIndex = Publics.GetComboIndex(this.insurerCbo, -1);
        }
        #endregion

        private void dgInsurerFinancials_ColumnOrder()
        {
            dgInsurerFinancials.AutoGenerateColumns = false;
            dgInsurerFinancials.Columns["ColumnSolarDate"].DisplayIndex = 0;
            dgInsurerFinancials.Columns["ColumnInsurerTitle"].DisplayIndex = 1;
            dgInsurerFinancials.Columns["ColumnFromSolarDate"].DisplayIndex = 2;
            dgInsurerFinancials.Columns["ColumnToSolarDate"].DisplayIndex = 3;
            dgInsurerFinancials.Columns["ColumnRequestedValue"].DisplayIndex = 4;
            dgInsurerFinancials.Columns["ColumnReceivedValue"].DisplayIndex = 5;
            dgInsurerFinancials.Columns["ColumnDeductionValue"].DisplayIndex = 6;
            dgInsurerFinancials.Columns["ColumnRemainPrice"].DisplayIndex = 7;
            dgInsurerFinancials.Columns["ColumnComment"].DisplayIndex = 8;
        }

        #region FillDataGridView_dgInsurance

        public DataTable getListDataTable_dgInsurerFinancials(IEnumerable<dynamic> list)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("InsurerFinancialId", typeof(int));
            dt.Columns.Add("InsurerTitle", typeof(string));
            dt.Columns.Add("SolarDate", typeof(string));
            dt.Columns.Add("FromSolarDate", typeof(string));
            dt.Columns.Add("ToSolarDate", typeof(string));
            dt.Columns.Add("RequestedValue", typeof(double));
            dt.Columns.Add("ReceivedValue", typeof(double));
            dt.Columns.Add("DeductionValue", typeof(double));
            dt.Columns.Add("RemainPrice", typeof(double));
            dt.Columns.Add("Comment", typeof(string));


            foreach (var i in list)
                dt.Rows.Add(
                    i.InsurerFinancialId,
                    i.InsurerTitle,
                    i.SolarDate,
                    i.FromSolarDate,
                    i.ToSolarDate,
                    i.RequestedValue,
                    i.ReceivedValue,
                    i.DeductionValue,
                    i.RemainPrice,
                    i.Comment
                    );

            return dt;
        }
        public void FillDataGridView_dgInsurerFinancials()
        {
            try
            {
                
                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.InsurerId = this.insurerCbo.SelectedValue != null && Convert.ToInt32(this.insurerCbo.SelectedValue) != -1 
                                 ? Convert.ToInt32(this.insurerCbo.SelectedValue.ToString()) 
                                 : (int?)null;
                sObj.FromDate  = Class.Date.ToChristianByTime(this.FromDateTxt.Value.ToString());
                sObj.ToDate    = Class.Date.ToChristianByTime(this.ToDateTxt.Value.ToString());

                JsonResponse<dynamic> result = Dentistry.DataProvider.GetInsuranceFinancialsX(sObj);
                if (result == null || result.Success == false )
                    return;
                var data = result.Data ;
              
                var dd = (data != null && (Enumerable.Count(data) > 0)) ? data : null;

                IEnumerable<dynamic> list = dd != null ? (dd as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true)
                                                                                      .Select(i =>
                                                                                      new
                                                                                      {
                                                                                          i.InsurerFinancialId ,
                                                                                          i.InsurerId ,
                                                                                          i.InsurerTitle ,                                                                                        
                                                                                          i.SolarDate ,
                                                                                          i.FromSolarDate ,
                                                                                          i.ToSolarDate ,
                                                                                          i.RequestedValue ,
                                                                                          i.ReceivedValue ,
                                                                                          i.DeductionValue ,
                                                                                          i.RemainPrice ,
                                                                                          i.Comment ,
                                                                                      }).OrderBy(i => i.InsurerId).ToList() : Enumerable.Empty<dynamic>();

                DataTable dt = this.getListDataTable_dgInsurerFinancials(list);
                this.dgInsurerFinancials.DataSource = dt;

                var totalResult =
                                         (from item in list
                                          group item by new { item.InsurerId } into gItem

                                          select new
                                          {
                                              InsurerId = gItem.Key.InsurerId,
                                              InsurerTitle = gItem.First().InsurerTitle,
                                              RequestedValue = gItem.Sum(b => (double)b.RequestedValue),
                                              ReceivedValue  = gItem.Sum(b => (double)b.ReceivedValue),
                                              DeductionValue = gItem.Sum(b => (double)b.DeductionValue),

                                          }).ToList();

                var total = new
                {
                    RequestedValue = totalResult.Sum(i => (double)i.RequestedValue),
                    ReceivedValue = totalResult.Sum(i => (double)i.ReceivedValue),
                    DeductionValue = totalResult.Sum(i => (double)i.DeductionValue),
                };
               
                if (total != null)
                {

                    var ff = dd;
                    this.RequestedValueTxt.Text = total.RequestedValue.ToString();
                    this.ReceivedValueTxt.Text = total.ReceivedValue.ToString();
                    this.DeductionValueTxt.Text = total.DeductionValue.ToString();
                    
                }
               
            }
            catch (System.Exception exp)
            {
                this.Close();
            }
        }
        #endregion


        private void dgPatientServices_ColumnOrder()
        {
            dgPatientServices.AutoGenerateColumns = false;
            dgPatientServices.Columns["ColumnPatientServiceId"].Visible = false;
           
            dgPatientServices.Columns["ColumnServiceSolarDate"].DisplayIndex = 0;
            dgPatientServices.Columns["ColumnServiceGroupTitle"].DisplayIndex = 1;
            dgPatientServices.Columns["ColumnServiceTite"].DisplayIndex = 2;
            dgPatientServices.Columns["ColumnToothImage"].DisplayIndex = 3;            
            dgPatientServices.Columns["ColumnServicePrice"].DisplayIndex = 4;
            dgPatientServices.Columns["ColumnInsurerPrice"].DisplayIndex = 5;
            dgPatientServices.Columns["ColumnInsurerShare"].DisplayIndex = 6;
            dgPatientServices.Columns["ColumnPatientName"].DisplayIndex = 7;
            dgPatientServices.Columns["ColumnProviderStaffTitle"].DisplayIndex = 8;
            dgPatientServices.Columns["ColumnBasicInsurerTitle"].DisplayIndex = 9;
        }
        public void FillDataGridView_dgPatientsServices(int basicInsurerId, DateTime fromDate, DateTime toDate)
        {
            this.dgPatientServices_ColumnOrder();

            dynamic sObj = new ExpandoObject();
            sObj.CheckupTypeId = 2;
            sObj.BasicInsurerId = basicInsurerId;
            sObj.FromDate = fromDate;
            sObj.ToDate = toDate;


            //if (this.insurerCbo.SelectedIndex > 0)
            //    sObj.BasicInsurerId = Convert.ToInt32(this.insurerCbo.SelectedValue);

            //if ((this.FromDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.FromDateTxt.Value.ToString())))
            //    sObj.FromDate = string.Format("{0} 00:00:01", this.FromDateTxt.Value.ToString()).ToGregorianDateTime();

            //if ((this.ToDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.ToDateTxt.Value.ToString())))
            //    sObj.ToDate = string.Format("{0} 23:59:59", this.ToDateTxt.Value.ToString()).ToGregorianDateTime();




            JsonResponse<dynamic> result = Dentistry.DataProvider.GetPatientServicesX(sObj);

            if (result == null || result.Success == false || result.Data == null)
                return;
            var dd = result.Data;

            if (dd == null)
                return;

            var list = dd != null && (Enumerable.Count(dd) >= 0) ? (dd as IEnumerable<dynamic>)
                .Select(i => new Class.PatientService(i))
                   .Select(i =>
                   new
                   {
                       PatientServiceId = i.Id,                     
                       i.ServiceGroupTitle,                       
                       i.ServiceTitle,                                        
                       i.BasicInsurerTitle,
                       i.ProviderStaffTitle,                     
                       i.ServicePrice,
                       i.InsurerPrice,
                       i.InsurerShare,                                              
                     
                       i.PatientName,                                            
                       i.SolarDate,                  
                       i.ToothImage,
                   }).ToList() : null;




            if (list == null)
                return;

            

            this.dgPatientServices.DataSource = list;

          

            //this.dgPatientsPrices.Refresh();
        }

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

        #region dataGridViewInsurance_CellDoubleClick
        private void dataGridViewInsurance_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.ButtonEdit_Click(this, null);
        }
        #endregion

        #region dataGridViewInsurance_SelectionChanged
        private void dataGridViewInsurance_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dgInsurerFinancials.CurrentCell != null) && (this.dgInsurerFinancials.CurrentRow.Selected))
            {
                this.ButtonEdit.Enabled = true;
                this.ButtonDelete.Enabled = true;
            }
            else
            {
                this.ButtonEdit.Enabled = false;
                this.ButtonDelete.Enabled = false;

            }
        }
        #endregion

        #region dataGridViewInsurance_CellFormatting
        private void dataGridViewInsurance_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgInsurerFinancials.Columns[e.ColumnIndex].Name.Trim().Equals("ColumnRemainPrice"))
            {
                String stringValue = e.Value.ToString();
                if (stringValue == null)
                    return;
                if (int.Parse(e.Value.ToString()) < 0)
                {
                    this.dgInsurerFinancials.Rows[e.RowIndex].Cells["ColumnRemainPrice"].Style.ForeColor = Color.Red;
                    e.Value = int.Parse(e.Value.ToString().Replace("-", "")).ToString("#,#");
                }
                else
                    this.dgInsurerFinancials.Rows[e.RowIndex].Cells["ColumnRemainPrice"].Style.ForeColor = Color.Blue;


            }
        }
        #endregion



     

        #region comboBoxInsurance_SelectedIndexChanged
        private void comboBoxInsurance_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillDataGridView_dgInsurerFinancials();
        }
        #endregion

        #region ButtonNew_Click
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_بیمه_ها_جدید) == false)
                return;

            InsuranceFinancialDefine form = new InsuranceFinancialDefine();
            form.ShowDialog();
            this.FillDataGridView_dgInsurerFinancials();
        }
        #endregion

        #region ButtonEdit_Click
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_بیمه_ها_ویرایش) == false)
                return;

            int insurerFinancialId = Convert.ToInt32(this.dgInsurerFinancials["ColumnInsurerFinancialId", this.dgInsurerFinancials.CurrentRow.Index].Value);
            InsuranceFinancialDefine form = new InsuranceFinancialDefine(insurerFinancialId);
            form.ShowDialog();
            this.FillDataGridView_dgInsurerFinancials();
        }
        #endregion

        #region ButtonDelete_Click
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_بیمه_ها_حذف) == false)
                return;

            if (this.dgInsurerFinancials.CurrentCell == null)
                return;

            try
            {
                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    int insurerFinancialId = Convert.ToInt32(this.dgInsurerFinancials["ColumnInsurerFinancialId", this.dgInsurerFinancials.CurrentRow.Index].Value);

                    dynamic iObj = new ExpandoObject();
                    iObj.Id = insurerFinancialId;
                    iObj.IsDeleted = true;                 
                  
                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefineInsurerFinancialsX(iObj);

                    if (result != null && result.Success == true && result.Data != null)
                    {
                        this.FillDataGridView_dgInsurerFinancials();
                    }
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }
        #endregion

     

        private void FormInsurance_KeyDown(object sender, KeyEventArgs e)
        {
            #region F2
            if (e.KeyCode == Keys.F2)
            {
                if (this.ButtonNew.Enabled == true)
                    this.ButtonNew_Click(this, null);
            }
            #endregion

            #region F4
            if (e.KeyCode == Keys.F4 && e.Modifiers != Keys.Alt)
            {
                if (this.ButtonEdit.Enabled == true)
                    this.ButtonEdit_Click(this, null);
            }
            #endregion

            #region F8
            if (e.KeyCode == Keys.F8)
            {
                if (this.ButtonDelete.Enabled == true)
                    this.ButtonDelete_Click(this, null);
            }
            #endregion

            #region Enter for Search
            if (e.KeyCode == Keys.Enter)
                btnSearch_Click(sender, e);
            #endregion
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.SearchType = true;
            this.FillDataGridView_dgInsurerFinancials();
            
            this.SearchType = false;
        }

       

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedTab == tabPage2)
            {
                if (this.dgInsurerFinancials.CurrentRow == null)
                    return;

                var insurerFinancialId = Convert.ToInt32(this.dgInsurerFinancials["ColumnInsurerFinancialId", this.dgInsurerFinancials.CurrentRow.Index].Value);

                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.Id = insurerFinancialId;

                JsonResponse<dynamic> result = Dentistry.DataProvider.GetInsuranceFinancialsX(sObj);
                if (result.Success != true || result.Data == null)
                    return;
                var dd = result.Data;
                var list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;
                var obj = (list != null) ? list.FirstOrDefault() : null;


                if (obj != null)
                {
                    int basicInsurerId = Convert.ToInt32(obj.InsurerId);

                    DateTime fDate = Convert.ToDateTime(obj.FromDate);
                    DateTime tDate = Convert.ToDateTime(obj.ToDate);

                    DateTime fromDate = Convert.ToDateTime(string.Format("{0} 00:00:01", fDate.ToShortDateString()));
                    DateTime toDate = Convert.ToDateTime(string.Format("{0} 00:00:01", tDate.ToShortDateString()));

                  
                    this.FillDataGridView_dgPatientsServices(basicInsurerId, fromDate, toDate);

                }
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }
    }
}