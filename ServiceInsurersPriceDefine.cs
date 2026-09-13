using FarsiMessageBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DNTPersianUtils.Core;

namespace Dentistry
{
    public partial class ServiceInsurersPriceDefine : Form
    {
        public int? ServiceId = null;
        public double? ServiceFreePrice = null;
        public IEnumerable<dynamic> InsurerList = Enumerable.Empty<dynamic>();
        public List<int> InsurerIds = new List<int>();

        public ServiceInsurersPriceDefine(int serviceId)
        {
            InitializeComponent();

            this.ServiceId = serviceId;

        }

        private void ServiceInsurersPriceDefine_Load(object sender, EventArgs e)
        {
            this.DefineDateTxt.Value = DateTime.Now;
            this.RunDateTxt.Value = DateTime.Now;

            this.LoadFormInit();
            if (this.ServiceId == null)
                return;
            this.FetchServiceInfo(this.ServiceId.Value);
            this.dgInsurersPrices_Init();
            this.FillDataGrid_dgInsurersPrices();
        }


        private void dgInsurersPrices_Init()
        {
            dgInsurersPrices.AutoGenerateColumns = false;

            dgInsurersPrices.Columns["ColumnIsCheck"].DisplayIndex = 0;
            dgInsurersPrices.Columns["ColumnInsurerTitle"].DisplayIndex = 1;
            dgInsurersPrices.Columns["ColumnFreePrice"].DisplayIndex = 2;
            dgInsurersPrices.Columns["ColumnInsurerPrice"].DisplayIndex = 3;


            this.dgInsurersPrices.Columns["ColumnInsurerTitle"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgInsurersPrices.Columns["ColumnFreePrice"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgInsurersPrices.Columns["ColumnInsurerPrice"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgInsurersPrices.Columns["ColumnInsurerTitle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgInsurersPrices.Columns["ColumnFreePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgInsurersPrices.Columns["ColumnInsurerPrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

            
        }

        private void LoadFormInit()
        {


            dynamic sObj = new System.Dynamic.ExpandoObject();
            JsonResponse<dynamic> result = Dentistry.DataProvider.GetInsurersX(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;

            IEnumerable<dynamic> insurerList = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>)
                .Where(i => i.InsurerId > 0)
                .Select(i =>
                new
                {
                    InsurerId = i.InsurerId,
                    InsurerTitle = i.InsurerTitle,
                    FreePrice = 0,
                    InsurerPrice = 0
                }
            ).OrderBy(i => i.InsurerId).ToList() : Enumerable.Empty<dynamic>();

            this.InsurerList = insurerList;
            this.dgInsurersPrices.DataSource = InsurerList;


        }

        public void FetchServiceInfo(int serviceId)
        {
            try
            {

                dynamic iObj = new System.Dynamic.ExpandoObject();
                iObj.ServiceId = serviceId;

                var result = DataProvider.GetServicesX(iObj);
                if (result != null && result.Success == false && result.Data == null)
                    return;

                var dd = result.Data;
                IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).Select(i =>
                                                                                 new
                                                                                 {                                                                                    
                                                                                     i.ServiceCode,
                                                                                     i.ServiceTitle,                                                                                 
                                                                                     i.ServiceFreePrice,
                                                                                 }).ToList() : null;

                if (list == null)
                    return;

                var obj = list.FirstOrDefault();
                if (obj != null)
                {                 
                    this.serviceTitleTxt.Text = string.Format("{0} {1}", obj.ServiceTitle, obj.ServiceCode);                   
                    this.serviceFreePriceTxt.Text = Convert.ToString(obj.ServiceFreePrice);
                    this.ServiceFreePrice = Convert.ToDouble(obj.ServiceFreePrice);               
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }

        #region FillDataGrid_dgInsurersPrices

        private void FillDataGrid_dgInsurersPrices()
        {

            double insurerPrice = double.Parse(this.InsurerPriceTxt.GetPoorText());
            double freePrice = double.Parse(this.InsurerFreePriceTxt.GetPoorText());

            var insurerList = this.InsurerList != null && (Enumerable.Count(this.InsurerList) > 0) ? (this.InsurerList as IEnumerable<dynamic>)                                                                            
                                                                            .Select(i =>
                                                                               new
                                                                               {
                                                                                   //IsCheck = true,
                                                                                   i.InsurerId ,
                                                                                   i.InsurerTitle,                                                                                 
                                                                                   InsurerPrice = this.InsurerIds.Contains(Convert.ToInt32(i.InsurerId)) ? insurerPrice : i.InsurerPrice,
                                                                                   FreePrice = this.InsurerIds.Contains(Convert.ToInt32(i.InsurerId)) ? freePrice : i.FreePrice
                                                                               }).ToList() : Enumerable.Empty<dynamic>();


            this.dgInsurersPrices.DataSource = insurerList;

            foreach (DataGridViewRow row in dgInsurersPrices.Rows)
            {
                int insurerId = Convert.ToInt32(row.Cells["ColumnInsurerId"].Value);
                if (this.InsurerIds.Contains(insurerId))
                {
                    row.Cells["ColumnIsCheck"].Value = true;
                }
                else
                {
                    row.Cells["ColumnIsCheck"].Value = false;
                }
            }
        }
        #endregion

        private void OkBtn_Click(object sender, EventArgs e)
        {
           
            if (this.ServiceId == null)
            {
                FMessageBox.Show("لطفا خدمت موردنظر انتخاب شود", Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.OK, FMessageBoxIcons.Error);
                return;
            }

            double freePrice ;           
            double insurerPrice ;
            
            if (string.IsNullOrEmpty(this.InsurerFreePriceTxt.Text) || !double.TryParse(this.InsurerFreePriceTxt.Text, out freePrice))
            {
                MessageBox.Show(" لطفا قیمت کلینیکی خدمت را وارد کنید");
                return;
            }
            if (string.IsNullOrEmpty(this.InsurerPriceTxt.Text) || !double.TryParse(this.InsurerPriceTxt.Text, out insurerPrice))
            {
                MessageBox.Show(" لطفا قیمت بیمه ای خدمت را وارد کنید");
                return;
            }

            if(this.InsurerIds.Count() < 1)
            {
                MessageBox.Show(" لطفا بیمه ای  را انتخاب کنید");
                return;
            }

            
         


            DateTime? defineDate = string.Format("{0} {1}", this.DefineDateTxt.Value.ToString(), DateTime.Now.ToString("HH:mm")).ToGregorianDateTime();
            DateTime? runDate = string.Format("{0} {1}", this.RunDateTxt.Value.ToString(), DateTime.Now.ToString("HH:mm")).ToGregorianDateTime();

            //foreach (DataGridViewRow row in this.dgInsurersPrices.Rows)
            //{


            //}
            dynamic iObj = new System.Dynamic.ExpandoObject();
            iObj.ServiceId = this.ServiceId;
            iObj.InsurerIds = this.InsurerIds;
            iObj.FreePrice = freePrice;
            iObj.InsurerPrice = insurerPrice;
            iObj.DefineDate = defineDate;
            iObj.RunDate = runDate;

            JsonResponse<dynamic> result = Dentistry.DataProvider.DefineInsurersPricingX(iObj);

            if (result != null && result.Success == true)
            {
                this.DialogResult = DialogResult.OK;
            }

            
        

        }

        private void dgInsurersPrices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ((DataGridView)sender).Columns[e.ColumnIndex].Name.Equals("ColumnIsCheck"))
            {
                this.dgInsurersPrices["ColumnIsCheck", e.RowIndex].ReadOnly = false;
                this.dgInsurersPrices["ColumnIsCheck", e.RowIndex].Value = !Convert.ToBoolean(this.dgInsurersPrices["ColumnIsCheck", e.RowIndex].Value);

                bool isCheck = Convert.ToBoolean(this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnIsCheck"].Value);

                int insurerId = Convert.ToInt32(this.dgInsurersPrices["ColumnInsurerId", e.RowIndex].Value);

                if (Convert.ToBoolean(isCheck) == true)
                {
                    if (!InsurerIds.Contains(insurerId))
                    {
                        InsurerIds.Add(insurerId);
                    }

                }
                else
                {

                    if (InsurerIds.Contains(insurerId))
                    {
                        InsurerIds.Remove(insurerId);
                    }
                }

                this.FillDataGrid_dgInsurersPrices();
            }
        }

        private void serviceFreePriceTxt_TextChanged(object sender, EventArgs e)
        {
            string text = ((Label)sender).Text;
            if (!Publics.IsNumeric(text))
                return;
            double number = Convert.ToDouble(text);
            ((Label)sender).Text = Publics.ToRial(number);
        }
        private void InsurerPriceTxt_TextChanged(object sender, EventArgs e)
        {
            //double insurerPrice = Convert.ToDouble(this.InsurerPriceTxt.Text);
            //FillDataGrid_dgInsurersPrices();
            //foreach (DataGridViewRow row in dgInsurersPrices.Rows)
            //{
            //    if (Convert.ToBoolean(row.Cells["ColumnIsCheck"].Value) == true)
            //    {






            //    }
            //}

            this.FillDataGrid_dgInsurersPrices();
        }
        private void FreePriceTxt_TextChanged(object sender, EventArgs e)
        {
            this.FillDataGrid_dgInsurersPrices();
            this.FillDataGrid_dgInsurersPrices();
        }
        

        

        private void dgInsurersPrices_KeyDown(object sender, KeyEventArgs e)
        {
            DataGridViewColumn col = this.dgInsurersPrices.Columns["ColumnFreePrice"];
            if (e.KeyCode == Keys.Tab && dgInsurersPrices.CurrentCell.ColumnIndex == col.Index)
            {
                e.Handled = true;
                //DataGridViewCell cell = dgInsurersPrices.Rows[0].Cells[0];
                //dgInsurersPrices.CurrentCell = cell;
                dgInsurersPrices.BeginEdit(true);
            }
        }

        private void dgInsurersPrices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
            this.dgInsurersPrices.CellEnter += new DataGridViewCellEventHandler(myDataGrid_CellEnter);
        }

        void myDataGrid_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if ((this.dgInsurersPrices.Columns[e.ColumnIndex] is DataGridViewTextBoxColumn) ||
                (this.dgInsurersPrices.Columns[e.ColumnIndex] is DataGridViewComboBoxColumn))
            {
                this.dgInsurersPrices.BeginEdit(false);
            }
        }

      
    }
}
