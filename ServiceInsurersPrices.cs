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
using DNTPersianUtils.Core;

namespace Dentistry
{
    public partial class ServiceInsurersPrices : Form
    {
        private int? passServiceId = null;

        private int serviceGroupId = 0;
        public int ServiceGroupId {
            set {
               
                this.serviceGroupId = value;
                
                this.FillDatagrid_dgServices();
            }
            get {
                return this.serviceGroupId;
            }
        }


        private int serviceId = 0;
        public int ServiceId
        {
            set
            {

                this.serviceId = value;

                this.FillDatagrid_dgInsurersPrices();
            }
            get
            {
                return this.serviceId;
            }
        }

        
        public ServiceInsurersPrices(int? serviceId = null)
        {
            InitializeComponent();

            this.passServiceId = serviceId;
            this.LoadFormInit();
            

        }

        private void ServiceInsurersPrices_Load(object sender, EventArgs e)
        {
            

            if (this.passServiceId == null)
                return;

            this.sgRdo0.Checked = true;
            

            this.FillDatagrid_dgServices();

            this.dgServices.SelectionChanged += new EventHandler(this.dgServices_SelectionChanged);

            foreach (DataGridViewRow row in this.dgServices.Rows)
            {

                object val = row.Cells["ColumnServiceId"].Value;
                int id = Convert.ToInt32(val);
                if (this.passServiceId.Value == id)
                {
                    row.Selected = true;
                    row.Cells["ColumnServiceTitle"].Selected = true;

                    dgServices_SelectionChanged(this, null);


                }

            }

            dgServices_Init();
            dgInsurersPrices_Init();

            //FillDatagrid_dgInsurersPrices();
        }

        private void dgServices_Init()
        {
            dgServices.AutoGenerateColumns = false;

            dgServices.Columns["ColumnServiceCode"].DisplayIndex = 0;
            dgServices.Columns["ColumnServiceTitle"].DisplayIndex = 1;
            
            

            this.dgServices.Columns["ColumnServiceCode"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgServices.Columns["ColumnServiceTitle"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgServices.Columns["ColumnServiceFreePrice"].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;

            this.dgServices.Columns["ColumnServiceCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            this.dgServices.Columns["ColumnServiceTitle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.dgServices.Columns["ColumnServiceFreePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

           

        }
        private void dgInsurersPrices_Init()
        {
            dgInsurersPrices.AutoGenerateColumns = false;
            dgInsurersPrices.Columns["ColumnInsurerServiceTarefeChangeId"].Visible = false;
            dgInsurersPrices.Columns["ColumnInsurerId"].Visible = true;
            dgInsurersPrices.Columns["ColumnServiceId2"].Visible = false;

            dgInsurersPrices.Columns["ColumnInsurerId"].DisplayIndex = 0;
            dgInsurersPrices.Columns["ColumnInsurerTitle"].DisplayIndex = 1;
            dgInsurersPrices.Columns["ColumnFreePrice"].DisplayIndex = 2;
            dgInsurersPrices.Columns["ColumnInsurerPrice"].DisplayIndex = 3;
            dgInsurersPrices.Columns["ColumnInsurerShare"].DisplayIndex = 4;
            dgInsurersPrices.Columns["ColumnFranchiseShare"].DisplayIndex = 5;
            dgInsurersPrices.Columns["ColumnFreeShare"].DisplayIndex = 6;
            dgInsurersPrices.Columns["ColumnPatientShare"].DisplayIndex = 7;
            dgInsurersPrices.Columns["ColumnSolarDefineDate"].DisplayIndex = 8;

            this.dgInsurersPrices.Columns["ColumnInsurerId"].DefaultCellStyle.ForeColor = Color.White;
            this.dgInsurersPrices.Columns["ColumnInsurerId"].DefaultCellStyle.SelectionForeColor = Color.White;

            foreach(DataGridViewColumn col in this.dgInsurersPrices.Columns)
            {
                if (col.Name != "ColumnInsurerId")
                    col.DefaultCellStyle.SelectionForeColor = Color.Black;
            }
            
        }


        #region LoadFormInit
        private void LoadFormInit()
        {
            

        }
        #endregion

             
        private void FillDatagrid_dgServices()
        {
            dynamic iObj = new System.Dynamic.ExpandoObject();
            if (this.ServiceGroupId != 0)
                iObj.ServiceGroupId = this.ServiceGroupId;

            var result = DataProvider.GetServicesX(iObj);
            if (result != null && result.Success == false && result.Data == null)
                return;

            var dd = result.Data;
            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).Select(i =>
                                                                             new
                                                                             {
                                                                                 i.ServiceId ,
                                                                                 i.ServiceCode,
                                                                                 i.ServiceTitle,
                                                                                 i.ServiceGroupId ,
                                                                                 i.ServiceFreePrice,
                                                                             }).ToList() : Enumerable.Empty<dynamic>();


            

            this.dgServices.DataSource = list;
            this.dgServices.CurrentCell = null;
            if (this.dgServices.Rows.Count < 1)
                this.ServiceId = 0;

        }

        private void dgServices_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

            
        }


        private void dgServices_SelectionChanged(object sender, EventArgs e)
        {
            this.serviceCodeTxt.Text = "";
            this.serviceTitleTxt.Text = "";
            this.serviceFreePriceTxt.Text = "";
            this.dgInsurersPrices.DataSource = null;

            DataGridViewRow currentRow = this.dgServices.CurrentRow;
            if (currentRow == null)
                return;
            this.ServiceId = Convert.ToInt32(currentRow.Cells["ColumnServiceId"].Value);
            this.serviceCodeTxt.Text = currentRow.Cells["ColumnServiceCode"].Value.ToString();
            this.serviceTitleTxt.Text = currentRow.Cells["ColumnServiceTitle"].Value.ToString();
            this.serviceFreePriceTxt.Text = currentRow.Cells["ColumnServiceFreePrice"].Value.ToString();
        }

        public DataTable getListDataTable(IEnumerable<dynamic> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ServiceId", typeof(int));
            dt.Columns.Add("InsurerId", typeof(int));
            dt.Columns.Add("InsurerTitle", typeof(string));
            dt.Columns.Add("FreePrice", typeof(string));
            dt.Columns.Add("InsurerPrice", typeof(string)); 
            dt.Columns.Add("InsurerShare", typeof(string));
            dt.Columns.Add("FranchiseShare", typeof(string));
            dt.Columns.Add("FreeShare", typeof(string));
            dt.Columns.Add("PatientShare", typeof(string));
            dt.Columns.Add("SolarDefineDate", typeof(string));
            dt.Columns.Add("SolarRunDate", typeof(string));
          
                             
            foreach (var item in list)
                dt.Rows.Add(
                    item.ServiceId,
                    item.InsurerId,
                    item.InsurerTitle,
                    item.FreePrice,
                    item.InsurerPrice,
                    item.InsurerShare,
                    item.FranchiseShare,
                    item.FreeShare,
                    item.PatientShare,
                    item.SolarDefineDate,
                    item.SolarRunDate                
                    );

            return dt;
        }

        private void FillDatagrid_dgInsurersPrices()
        {
           

            dynamic sObj = new System.Dynamic.ExpandoObject();            
            sObj.ServiceId = this.ServiceId;
            
            JsonResponse<dynamic> result = Dentistry.DataProvider.GetInsurersServicePricingX(sObj);
            if (result == null )
                return;

            if(result.Success == false)
            {                          
               
                return;
            }

            var dd = (result.Data != null ) ? result.Data : null;

            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>)
                                                                        //.Where(i => i.InsurerId > 0)
                                                                        .Select(i =>
                                                                        new 
                                                                        {                                                                                                                                                                       
                                                                            i.ServiceId,
                                                                            i.InsurerId,
                                                                            InsurerTitle = string.Format("{0}  {1}", i.InsurerTitle, i.InsurerId == 0 ? "" : "("+i.InsurerPercent+"%)"),
                                                                            FreePrice = Publics.ToRial(i.FreePrice),
                                                                            InsurerPrice = Publics.ToRial(i.InsurerPrice),
                                                                            InsurerShare = Publics.ToRial(i.InsurerShare),
                                                                            FranchiseShare = Publics.ToRial(i.FranchiseShare),
                                                                            FreeShare = Publics.ToRial(i.FreeShare),
                                                                            PatientShare = Publics.ToRial(i.PatientShare),
                                                                            SolarDefineDate = i.SolarDefineDate,
                                                                            SolarRunDate = i.SolarRunDate,
                                                                                      
                                                                        }).ToList() : Enumerable.Empty<dynamic>();


          

            DataTable dt = getListDataTable(list);          
            this.dgInsurersPrices.DataSource = dt;
            this.dgInsurersPrices.CurrentCell = null;
        }

    

        private void ButtonServicePricing_Click(object sender, EventArgs e)
        {

            if (this.ServiceId == null)
                return;
            ServiceInsurersPriceDefine form = new ServiceInsurersPriceDefine(this.ServiceId);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                this.FillDatagrid_dgInsurersPrices();

            //string insurerTitle = Convert.ToString(this.dgInsurersPrices["ColumnInsurerTitle", this.dgInsurersPrices.CurrentRow.Index].Value);
            //this.InsurerTitleLbl.Text = insurerTitle;

            
            
        }

    

    
    
        private void dgInsurersPrices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && ((DataGridView)sender).Columns[e.ColumnIndex].Name.Equals("ColumnIsCheck"))
            {

                this.dgInsurersPrices["ColumnIsCheck", e.RowIndex].ReadOnly = false;
                bool flag = Convert.ToBoolean(this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnIsCheck"].Value);
                if (flag == true)
                    this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnIsCheck"].Value = false;
                else
                    this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnIsCheck"].Value = true;

                int id  = Convert.ToInt32(this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnInsurerId"].Value);
                bool ch = Convert.ToBoolean(this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnIsCheck"].Value);

               
              
            }
        }

     

       
        private void dgInsurersPrices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgInsurersPrices_CellFormatting();
        }

        private void dgInsurersPrices_CellFormatting()
        {
            try
            {
                foreach (DataGridViewRow row in this.dgInsurersPrices.Rows)
                {
                    

                    if (this.dgInsurersPrices["ColumnServiceId2", row.Index].Value == null)
                    {                       
                        row.DefaultCellStyle.BackColor = Color.LavenderBlush;

                    }
                }



            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
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

        private void dgInsurersPrices_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {            
            var valueid = this.dgInsurersPrices.Rows[e.RowIndex].Cells[0].Value;
            if (this.dgInsurersPrices.Columns[e.ColumnIndex].Name.Equals("ColumnInsurerId"))
            {
                string insurerId = this.dgInsurersPrices[e.ColumnIndex, e.RowIndex].Value.ToString();
                if(Convert.ToInt32(insurerId) == 0)
                {
                   
                    this.dgInsurersPrices.Rows[e.RowIndex].DefaultCellStyle.BackColor = ColorTranslator.FromHtml("#D1FFBD");
                    this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnInsurerPrice"].Value = "";
                    this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnInsurerShare"].Value = "";
                    this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnFranchiseShare"].Value = "";
                    this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnFreeShare"].Value = "";
                    //this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnFreeShare"].Value = "";
                    

                }

            }

            //if (this.dgInsurersPrices.Columns[e.ColumnIndex].Name.Trim().Equals("ColumnFreeShare"))
            //{
            //    double value = Convert.ToDouble(e.Value);
            //    if (value <0)
            //        this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnFreeShare"].Style.ForeColor = Color.Red;             
            //    else
            //        this.dgInsurersPrices.Rows[e.RowIndex].Cells["ColumnFreeShare"].Style.ForeColor = Color.DarkGreen;

            //}
        }

        private void ServiceGroupRdo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdoX = sender as RadioButton;
            if (rdoX == null || rdoX.Checked != true)
                return;

            var pnlList = this.ServiceGroupPnl.Controls.OfType<UserControls.ExPanel>().ToList();

            foreach (var pnl in pnlList)
            {
                if (pnl != null)
                {
                    RadioButton rdo = pnl.Controls.OfType<RadioButton>().FirstOrDefault();

                    if (rdo != null && rdo != rdoX)
                        rdo.Checked = false;
                }
            }

            this.ServiceGroupId = Convert.ToInt32(rdoX.Tag);
            this.serviceGroupTxt.Text = rdoX.Text;

        }

        private void dgServices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {

        }

     
    }
}
