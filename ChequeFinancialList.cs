using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarsiMessageBox;
using System.Linq;

namespace Dentistry
{
    public partial class ChequeFinancialList : Form
    {
        
        bool FromToday = false;
        bool DateOfMaturity = false;
        bool DateOfIssuance = false;
        bool Cheque_Pas = false;
        bool Cheque_NoPas = false;
        bool Cheque_Bargasht = false;
        bool SearchType = false;
        int ChequeTypeID = 0;

        #region FormChequeControl
        public ChequeFinancialList()
        {
            InitializeComponent();

          
            
        }
        #endregion

        private void ChequeControl_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();
            this.FillDataGridView_dgCheques();

            var date = new PersianDateTime(DateTime.Now).Date;
            this.FromDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, date.Month, 1);
            this.ToDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, date.Month, date.DaysInMonth);

            this.dgCheques_ColumnOrder();
        }

        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new
            {
                EntityName = "BaseCoding_ChequeTypes"
            };
            var result = Dentistry.DataProvider.GetBaseCodingX(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;

            IEnumerable<dynamic> chequeTypeList = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : Enumerable.Empty<dynamic>();

            this.chequeActionTypeCbo.SelectedIndexChanged -= new EventHandler(this.cmbActionType_SelectedIndexChanged);         
            this.chequeActionTypeCbo.DataSource = chequeTypeList;
            this.chequeActionTypeCbo.ValueMember = "Id";
            this.chequeActionTypeCbo.DisplayMember = "Title";
            this.chequeActionTypeCbo.SelectedIndexChanged += new EventHandler(this.cmbActionType_SelectedIndexChanged);

        }
        #endregion

        private void dgCheques_ColumnOrder()
        {
            dgCheques.AutoGenerateColumns = false;
            dgCheques.Columns["ColumnSolarDateOfIssuance"].DisplayIndex = 0;
            dgCheques.Columns["ColumnChequeTypeTitle"].DisplayIndex = 1;
            dgCheques.Columns["ColumnChequeAmount"].DisplayIndex = 2;
            dgCheques.Columns["ColumnSolarDateOfMaturity"].DisplayIndex = 3;
            dgCheques.Columns["ColumnNumberOfCheque"].DisplayIndex = 4;
            dgCheques.Columns["ColumnBankTitle"].DisplayIndex = 5;                    
            dgCheques.Columns["ColumnChequeStatusTitle"].DisplayIndex = 6;
            dgCheques.Columns["ColumnTitle"].DisplayIndex = 7;
            dgCheques.Columns["ColumnComment"].DisplayIndex = 8;
        }

        #region FillDateGridView
        public DataTable getListDataTable(IEnumerable<dynamic> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("PatientFinancialId", typeof(int));
            dt.Columns.Add("CostId", typeof(int));
            dt.Columns.Add("ChequeNumber", typeof(string));
            dt.Columns.Add("SolarDateOfIssuance", typeof(string));
            dt.Columns.Add("SolarDateOfMaturity", typeof(string));         
            
            dt.Columns.Add("Amount", typeof(double));
            dt.Columns.Add("BankTitle", typeof(string));
            dt.Columns.Add("ChequeTypeId", typeof(int));
            dt.Columns.Add("ChequeTypeTitle", typeof(string));
            dt.Columns.Add("ChequeStatusId", typeof(int));
            dt.Columns.Add("ChequeStatusTitle", typeof(string));      

        
         
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Comment", typeof(string));
            dt.Columns.Add("IsDeleted", typeof(bool));

            foreach (var item in list)
                dt.Rows.Add(
                    item.PatientFinancialId,
                    item.CostId,
                    item.ChequeNumber,
                    item.SolarDateOfIssuance,
                    item.SolarDateOfMaturity,                                   
                    item.Amount,                    
                    item.BankTitle,
                    item.ChequeTypeId,
                    item.ChequeTypeTitle,
                    item.ChequeStatusId,
                    item.ChequeStatusTitle,
                               
                    item.Title,
                    item.Comment,
                    item.IsDeleted
                    );

            return dt;
        }
        private void FillDataGridView_dgCheques()
        {
           
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.PayTypeId = 3;
            //sObj.FromDate = Class.Date.ToChristianByTime(this.FromDateTxt.Value.ToString());
            //sObj.ToDate = Class.Date.ToChristianByTime(this.ToDateTxt.Value.ToString());

            if (this.DateOfIssuanceRdo.Checked == true)
                sObj.IsDateOfIssuance = true;
            if (this.DateOfMaturityRdo.Checked == true)
                sObj.IsDateOfMaturity = true;
            
           

            if (this.Cheque_Pas == true)
                sObj.ChequeStatusId = 1;

            if (this.Cheque_NoPas == true)
                sObj.ChequeStatusId = 0;

            if (this.Cheque_Bargasht == true)
                sObj.ChequeStatusId = 2;

            var data1 = Dentistry.DataProvider.GetPatientTransactionsX(sObj);
            var d1 = (data1 != null && data1.Data != null) ? data1.Data : null;         

            IEnumerable<dynamic> list1 = d1 != null && (Enumerable.Count(d1) > 0) ? (d1 as IEnumerable<dynamic>)
                    .Select(i =>
                          new
                          {
                              PatientFinancialId = (int)i.PatientFinancialId,
                              CostId = (int)-1,

                              ChequeNumber = (string)i.ChequeNumber,                            
                              i.SolarDateOfIssuance ,                         
                              i.SolarDateOfMaturity,
                              BankTitle = (string)i.BankTitle,
                              Amount = (double)i.Amount,
                              ChequeTypeId = 1, // برداشت
                              ChequeTypeTitle = (string)i.ChequeTypeTitle,
                              ChequeStatusId = (int)i.ChequeStatusId,
                              ChequeStatusTitle = (string)i.ChequeStatusTitle,
                              Title = string.Format("{0} : {1}" , "بیمار", (string)i.PatientName),
                              Comment = (string)i.Comment,
                              IsDeleted = Convert.ToBoolean(i.IsDeleted),
                          }
                    ).ToList() 
                    : Enumerable.Empty<dynamic>();

            var data2 = Dentistry.DataProvider.GetCostFinancialsX(sObj);
            var d2 = (data2 != null && data2.Data != null) ? data2.Data : null;

            IEnumerable<dynamic> list2 = d2 != null && (Enumerable.Count(d2) > 0) ? (d2 as IEnumerable<dynamic>)
                    .Select(i =>
                          new
                          {
                              PatientFinancialId = (int)-1,
                              CostId = (int)i.CostId,
                              ChequeNumber = (string)i.ChequeNumber,
                              i.SolarDateOfIssuance,
                              i.SolarDateOfMaturity,
                              BankTitle = (string)i.BankTitle,
                              Amount = (double)i.Amount,
                              ChequeTypeId = 2, // واریز
                              ChequeTypeTitle = (string)i.ChequeTypeTitle,
                              ChequeStatusId = (int)i.ChequeStatusId,
                              ChequeStatusTitle = (string)i.ChequeStatusTitle,
                              Title = string.Format("{0} : {1}", "هزینه", (string)i.CostTitle),
                              Comment = (string)i.Comment,
                              IsDeleted = Convert.ToBoolean(i.IsDeleted),
                          }
                    ).ToList()
                    : Enumerable.Empty<dynamic>();

            IEnumerable<dynamic> list = list1;
            list = list.Concat(list2.ToList());

            if (this.chequeActionTypeCbo.SelectedIndex > 0)
            {
                int chequeTypeId = Convert.ToInt32(this.chequeActionTypeCbo.SelectedValue.ToString());
                list = list.Where(i => i.ChequeTypeId == chequeTypeId).ToList();
            }

            if (this.DateOfIssuanceRdo.Checked == true)
            {
                string fromDate = Class.Date.ToChristianByTime(this.FromDateTxt.Value.ToString());
                string toDate = Class.Date.ToChristianByTime(this.ToDateTxt.Value.ToString());
                string fromDateSolar = Publics.GetSolarDate(fromDate);
                string toDateSolar = Publics.GetSolarDate(toDate);

                list = list.Where(i => string.Compare(i.SolarDateOfIssuance, fromDateSolar) >= 0  &&  string.Compare(i.SolarDateOfIssuance, toDateSolar) <= 0).ToList();
            }

            if (this.DateOfMaturityRdo.Checked == true)
            {
                string fromDate = Class.Date.ToChristianByTime(this.FromDateTxt.Value.ToString());
                string toDate = Class.Date.ToChristianByTime(this.ToDateTxt.Value.ToString());
                string fromDateSolar = Publics.GetSolarDate(fromDate);
                string toDateSolar = Publics.GetSolarDate(toDate);

                list = list.Where(i => string.Compare(i.SolarDateOfMaturity, fromDateSolar) >= 0 && string.Compare(i.SolarDateOfMaturity, toDateSolar) <= 0).ToList();
            }

            DataTable dt = getListDataTable(list);
            this.dgCheques.DataSource = dt;

            var noneChequesTotal_IN = list.Where(i => i.ChequeTypeId == 2 && i.ChequeStatusId == 1).Sum(i => (double)i.Amount);

            var cashChequesTotal_IN = list.Where(i => i.ChequeTypeId == 2 && i.ChequeStatusId == 2).Sum(i => (double)i.Amount);

            var bouncedChequesTotal_IN = list.Where(i => i.ChequeTypeId == 2 && i.ChequeStatusId == 3).Sum(i => (double)i.Amount);

            var noneChequesTotal_OUT = list.Where(i => i.ChequeTypeId == 1 && i.ChequeStatusId == 1).Sum(i => (double)i.Amount);

            var cashChequesTotal_OUT = list.Where(i => i.ChequeTypeId == 1 && i.ChequeStatusId == 2).Sum(i => (double)i.Amount);

            var bouncedChequesTotal_OUT = list.Where(i => i.ChequeTypeId == 1 && i.ChequeStatusId == 3).Sum(i => (double)i.Amount);

          

            this.NoneChequeInTxt.Text = noneChequesTotal_IN.ToString();
            this.CashChequeInTxt.Text = cashChequesTotal_IN.ToString();            
            this.BouncedChequeInTxt.Text = bouncedChequesTotal_IN.ToString();

            this.NoneChequeOutTxt.Text = noneChequesTotal_OUT.ToString();
            this.CashChequeOutTxt.Text = cashChequesTotal_OUT.ToString();            
            this.BouncedChequeOutTxt.Text = bouncedChequesTotal_OUT.ToString();

           
        }
        #endregion


        #region dataGridViewCheque_CellDoubleClick
        private void dataGridViewCheque_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.ButtonEdit_Click(this, null);
        }
        #endregion

        #region dataGridViewCheque_SelectionChanged
        private void dataGridViewCheque_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dgCheques.CurrentCell != null) && (this.dgCheques.CurrentRow.Selected))
            {
                this.ButtonEdit.Enabled = true;
                
            }
            else
            {
                this.ButtonEdit.Enabled = false;
                

            }
        }
        #endregion

        #region dataGridViewCheque_CellFormatting
        private void dataGridViewCheque_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
     
            if (this.dgCheques["ColumnChequeTypeId", e.RowIndex].Value != null )
            {
                var chequeTypeId = this.dgCheques["ColumnChequeTypeId", e.RowIndex].Value.ToString();
               
              
                if (chequeTypeId == "2")
                {
                    this.dgCheques.Rows[e.RowIndex].Cells["ColumnChequeAmount"].Style.ForeColor = Color.Blue;                    
                }
                if(chequeTypeId == "1")
                    this.dgCheques.Rows[e.RowIndex].Cells["ColumnChequeAmount"].Style.ForeColor = Color.Crimson;
               
            }

            if (this.dgCheques["ColumnChequeStatusId", e.RowIndex].Value != null)
            {
                Color color = Color.White;
                switch (this.dgCheques["ColumnChequeStatusId", e.RowIndex].Value.ToString())
                {
                    case "1":
                        color = Color.WhiteSmoke;
                        break;
                    case "2":
                        color = Color.FromArgb(212, 255, 210);
                        break;
                    case "3":
                        color = Color.FromArgb(255, 225, 235);
                        break;


                }
                this.dgCheques.Rows[e.RowIndex].Cells["ColumnChequeStatusTitle"].Style.BackColor = color;
                                                       
            }
        }
        #endregion




        #region comboBoxCheque_SelectedIndexChanged
        private void comboBoxCheque_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillDataGridView_dgCheques();
            this.dgCheques.CurrentCell = null;
            this.dataGridViewCheque_SelectionChanged(this, null);
            this.ChequeTypeID = int.Parse(this.chequeActionTypeCbo.SelectedValue.ToString());
            
        }
        #endregion

        #region ButtonNew_Click
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_چک_ها_جدید) == false)
                return;

            ChequeFinancialDefine form = new ChequeFinancialDefine();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.FillDataGridView_dgCheques();
            }
            form.Dispose();
            

        }
        #endregion

        #region ButtonEdit_Click
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_چک_ها_ویرایش) == false)
                return;

            if (this.dgCheques.CurrentCell == null)
                return;

       
            int patientFinancialId = Convert.ToInt32(this.dgCheques["ColumnPatientFinancialId", this.dgCheques.CurrentRow.Index].Value);   
            int costId = Convert.ToInt32(this.dgCheques["ColumnCostId", this.dgCheques.CurrentRow.Index].Value);

           
            ChequeFinancialDefine form = new ChequeFinancialDefine(patientFinancialId, costId);

            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.FillDataGridView_dgCheques();
            }
            form.Dispose();

        }
        #endregion

        
       

        private void FormChequeControl_KeyDown(object sender, KeyEventArgs e)
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
            this.FillDataGridView_dgCheques();
            this.SearchType = false;
            this.dgCheques.CurrentCell = null;
            this.dataGridViewCheque_SelectionChanged(this, null);
        }

        private void cmbActionType_SelectedIndexChanged(object sender, EventArgs e)
        {
        
            //this.FillDataGridView();                                   
        }

  

        private void cmbActionType_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

    

       

      
    }
}
