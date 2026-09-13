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
using System.Linq;
using System.Dynamic;

namespace Dentistry
{
    public partial class CostFinancialList : Form
    {
         
        bool flag = false;
        int CostTypeId = 0;
        int BargainSideId = 0;

        #region CostRegister
        public CostFinancialList()
        {
            InitializeComponent();

           

        }

        private void CostRegister_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();
            var date = new PersianDateTime(DateTime.Now).Date;
            this.FromDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, date.Month, 1);
            this.ToDateTxt.Value = DateTime.Now;
            this.FillDataGridView_dgCosts();

            this.dgCosts_ColumnOrder();
        }

        #endregion

        #region LoadFormInit
        private void LoadFormInit()
        {

            

            dynamic sObj = new
            {
                IsCostType = true,
                IsBargainSide = true,
            };
            var result = Dentistry.DataProvider.LoadFormInitInfo(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;

            var dd = result.Data;

            IEnumerable<dynamic> CostTypeList = dd.CostType != null && (Enumerable.Count(dd.CostType) > 0) ? (dd.CostType as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList() : Enumerable.Empty<dynamic>();

            this.costTypeCbo.SelectedIndexChanged -= new EventHandler(this.comboBoxCostType_SelectedIndexChanged);
            this.costTypeCbo.DataSource = CostTypeList;
            this.costTypeCbo.ValueMember = "Id";
            this.costTypeCbo.DisplayMember = "Title";
            this.costTypeCbo.SelectedIndexChanged += new EventHandler(this.comboBoxCostType_SelectedIndexChanged);


            IEnumerable<dynamic> bargainSideList = dd.BargainSide != null && (Enumerable.Count(dd.BargainSide) > 0) ? (dd.BargainSide as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList() : Enumerable.Empty<dynamic>();

            this.bargainSideCbo.SelectedIndexChanged -= new EventHandler(this.comboBoxBargainSide_SelectedIndexChanged);            
            this.bargainSideCbo.DataSource = bargainSideList;
            this.bargainSideCbo.ValueMember = "Id";
            this.bargainSideCbo.DisplayMember = "Title";
            this.bargainSideCbo.SelectedIndexChanged += new EventHandler(this.comboBoxBargainSide_SelectedIndexChanged);

        }
        #endregion

        private void dgCosts_ColumnOrder()
        {
            dgCosts.AutoGenerateColumns = false;
            dgCosts.Columns["ColumnSolarDate"].DisplayIndex = 0;
            dgCosts.Columns["ColumnCostName"].DisplayIndex = 1;
            dgCosts.Columns["ColumnCostAmount"].DisplayIndex = 2;
            dgCosts.Columns["ColumnPayStatusTitle"].DisplayIndex = 3;
            dgCosts.Columns["ColumnComment"].DisplayIndex = 4;
            dgCosts.Columns["ColumnNumberOfCheque"].DisplayIndex = 5;         
            dgCosts.Columns["ColumnSolarDateOfMaturity"].DisplayIndex = 6;


        }

        #region FillDataGridView_dgCosts
        private void FillDataGridView_dgCosts()
        {
            try
            {
                dynamic sObj = new System.Dynamic.ExpandoObject();

                if (this.costTypeCbo.SelectedIndex > 0)
                    sObj.CostTypeId = int.Parse(this.costTypeCbo.SelectedValue.ToString());
                if (this.bargainSideCbo.SelectedIndex > 0)
                    sObj.BargainSideId = int.Parse(this.bargainSideCbo.SelectedValue.ToString());

                if ((this.FromDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.FromDateTxt.Value.ToString())))
                    sObj.FromDate = Class.Date.ToChristianByTime(this.FromDateTxt.Value.ToString());

                if ((this.ToDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.ToDateTxt.Value.ToString())))
                    sObj.ToDate   = Class.Date.ToChristianByTime(this.ToDateTxt.Value.ToString());


                int payTypeId = 0;
                var pnlList = this.PayTypePnl.Controls.OfType<UserControls.ExPanel>().ToList();

                foreach (var pnl in pnlList)
                {
                    if (pnl != null)
                    {
                        RadioButton rdo = pnl.Controls.OfType<RadioButton>().FirstOrDefault();

                        if (rdo != null && rdo.Checked == true)
                            payTypeId = Convert.ToInt32(rdo.Tag);
                    }
                }
                if (payTypeId != 0)
                    sObj.PayTypeId = payTypeId;

                var data = Dentistry.DataProvider.GetCostFinancialsX(sObj);
                var dd = (data != null && data.Data != null ) ? data.Data : null;
                IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>)
                        .Select(i => 
                             new
                             {
                                 CostId = (int)i.CostId,
                                 CostTypeId = (int?)i.CostTypeId,
                                 PayTypeId = (int?)i.PayTypeId,
                                 CostTitle = (string)i.CostTitle,
                                 Amount = (double)i.Amount,                                 
                                 PayTypeTitle = (string)i.PayTypeTitle,                                 
                                 SolarDate = (string)i.SolarDate,
                                 Comment = (string)i.Comment,
                                 FactorNumber = (string)i.FactorNumber,
                       
                                 NumberOfCheque = (string)i.ChequeNumber,                                                                                              
                                 i.SolarDateOfMaturity,
                                 IsDeleted = Convert.ToBoolean(i.IsDeleted),
                             }
                         ).ToList() : Enumerable.Empty<dynamic>();

                this.dgCosts.DataSource = list;

                if (list == null)
                    return;

                var totalResult =
                            (from item in list
                            group item by new { item.PayTypeId } into gItem
                            select new
                            {
                                PayTypeId = gItem.Key.PayTypeId,
                                CostTypeId = gItem.First().CostTypeId,
                                Total = gItem.Sum(b => Convert.ToInt32(b.Amount)),

                            }).ToList();

                var total = new
                {
                    TotalCash = totalResult.Where(i => i.PayTypeId == 1).Any() ? totalResult.Where(i => i.PayTypeId == 1).FirstOrDefault().Total : 0,
                    TotalPos = totalResult.Where(i => i.PayTypeId == 2).Any() ? totalResult.Where(i => i.PayTypeId == 2).FirstOrDefault().Total : 0,
                    TotalCheque = totalResult.Where(i => i.PayTypeId == 3).Any() ? totalResult.Where(i => i.PayTypeId == 3).FirstOrDefault().Total : 0,                    
                    TotalFaktor = totalResult.Where(i => i.PayTypeId == 4 && i.CostTypeId == 1).Any() ? totalResult.Where(i => i.PayTypeId == 4 && i.CostTypeId == 1).FirstOrDefault().Total : 0,
                };
             
                if (total != null)
                {

                    var ff = dd;
                    this.TotalCashPriceTxt.Text   = total.TotalCash.ToString();
                    this.TotalChequePriceTxt.Text = total.TotalCheque.ToString();
                    this.TotalFaktorPriceTxt.Text = total.TotalFaktor.ToString();
                    this.BarayandTxt.Text         = ((total.TotalCash + total.TotalCheque) - total.TotalFaktor).ToString();
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }

        }
        #endregion

        #region dataGridViewCost_CellDoubleClick
        private void dataGridViewCost_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.ButtonEdit_Click(this, null);
        }
        #endregion

        #region dataGridViewCost_SelectionChanged
        private void dataGridViewCost_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dgCosts.CurrentCell != null) && (this.dgCosts.CurrentRow.Selected))
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

        #region dataGridViewCost_CellFormatting
        private void dataGridViewCost_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgCosts.Columns["ColumnIsDeleted"].Visible == false)
            {                
                if (Convert.ToBoolean(this.dgCosts["ColumnIsDeleted", e.RowIndex].Value) == true)
                    this.dgCosts.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Crimson;

            }
            if (this.dgCosts.Columns[e.ColumnIndex].Name.Trim().Equals("ColumnCostName")) 
            {
                if (Convert.ToInt32(this.dgCosts["ColumnCostTypeId", e.RowIndex].Value) == 1)
                    this.dgCosts.Rows[e.RowIndex].Cells["ColumnCostName"].Style.BackColor = Color.Linen;

            }
            
            if (this.dgCosts["ColumnPayTypeId", e.RowIndex].Value != null)
                switch (this.dgCosts["ColumnPayTypeId", e.RowIndex].Value.ToString())
                {
                    case "1":
                        this.dgCosts.Rows[e.RowIndex].Cells["ColumnCostAmount"].Style.ForeColor = Color.DarkGreen;
                        break;
                    case "2":
                        this.dgCosts.Rows[e.RowIndex].Cells["ColumnCostAmount"].Style.ForeColor = Color.DarkRed;
                        break;
                    case "3":
                        this.dgCosts.Rows[e.RowIndex].Cells["ColumnCostAmount"].Style.ForeColor = Color.DarkBlue;
                        break;
                    

                }
               
            if (this.dgCosts.Columns[e.ColumnIndex].Name.Trim().Equals("ColumnPayStatusTitle"))
            {
                //String stringValue = e.Value as string;
                //if (stringValue == null)
                //    return;
                //if (stringValue == "پرداخت با چک")
                //{
                //    ((DataGridViewImageCell)this.dataGridViewCost["ColumnOtherInfo", e.RowIndex]).Value = (Image)global ::Dentistry.Properties.Resources.cheque;
                //    this.dataGridViewCost["ColumnOtherInfo", e.RowIndex].Tag = 1;
                //}
                //else
                //{
                //    ((DataGridViewImageCell)this.dataGridViewCost["ColumnOtherInfo", e.RowIndex]).Value = (Image)global ::Dentistry.Properties.Resources.Empty;
                //    this.dataGridViewCost["ColumnOtherInfo", e.RowIndex].Tag = 0;
                //}
            }
        }
        #endregion


        private void PayTypeRdo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdoX = sender as RadioButton;
            if (rdoX == null || rdoX.Checked != true)
                return;

            var pnlList = this.PayTypePnl.Controls.OfType<UserControls.ExPanel>().ToList();

            foreach (var pnl in pnlList)
            {
                if (pnl != null)
                {
                    RadioButton rdo = pnl.Controls.OfType<RadioButton>().FirstOrDefault();

                    if (rdo != null && rdo != rdoX)
                        rdo.Checked = false;
                }
            }

        
        }

        private void dataGridViewFinancial_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }


       

        #region comboBoxCostType_SelectedIndexChanged
        private void comboBoxCostType_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            this.costTypeCbo.ResetText();
            
            if (Convert.ToInt32(this.costTypeCbo.SelectedValue) == 1)
            {
                this.bargainSideCbo.Enabled = true;                
                this.bargainSideCbo.SelectedIndex = 0;

                this.labelBargainSide.Enabled = true;
                flag = true;
            }
            else
            {
                this.labelBargainSide.Enabled = false;
                this.bargainSideCbo.SelectedIndex = 0;
                this.bargainSideCbo.Enabled = false;
                flag = false;
            }

            this.dgCosts.CurrentCell = null;
            this.dataGridViewCost_SelectionChanged(this, null);

           
        }
        #endregion

        

        #region comboBoxBargainSide_SelectedIndexChanged
        private void comboBoxBargainSide_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           // this.FillDataGridView();
        }
        #endregion

        #region ButtonNew_Click
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_هزینه_ها_جدید) == false)
                return;

            CostFinancialDefine form = new CostFinancialDefine();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.FillDataGridView_dgCosts();
            }
            form.Dispose();
           
        }
        #endregion

        #region ButtonEdit_Click
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_هزینه_ها_ویرایش) == false)
                return;

            try
            {
               

                if (this.dgCosts.CurrentCell == null)
                    return;

                int costId = Convert.ToInt32(dgCosts.CurrentRow.Cells["ColumnCostID"].Value);
                CostFinancialDefine form = new CostFinancialDefine(costId);
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    this.FillDataGridView_dgCosts();
                }
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
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_هزینه_ها_حذف) == false)
                return;

            if (this.dgCosts.CurrentCell == null)
                return;

            try
            {
                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    dynamic iObj = new ExpandoObject();
                    iObj.ActionType = "Delete";
                    iObj.Id = Convert.ToInt32(dgCosts.CurrentRow.Cells["ColumnCostID"].Value);


                    var result = Dentistry.DataProvider.DefineCostX(iObj);

                    if (result != null && result.Success == true && result.Data != null)
                    {
                        this.FillDataGridView_dgCosts();
                    }

                   
                    this.dataGridViewCost_SelectionChanged(this, null);
                }
            }
            catch (System.Exception exp)
            {
                 ErrorClass.WriteErrorsToFile(this.Name, exp.TargetSite.Name.ToString(), exp.Message, DateTime.Now);
                this.Close();

            }
        }
        #endregion



        #region buttonInfo_Click
        private void FetchCostTotalInfo()
        {
            if (this.costTypeCbo.DataSource == null )
                this.CostTypeId = 0;
            else
                this.CostTypeId = Convert.ToInt32(this.costTypeCbo.SelectedValue);

            if (this.bargainSideCbo.DataSource == null)
                this.BargainSideId = 0;
            else
                this.BargainSideId = Convert.ToInt32(this.bargainSideCbo.SelectedValue);
     

            

        }
        #endregion

        private void CostRegister_KeyDown(object sender, KeyEventArgs e)
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
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {         
            this.FillDataGridView_dgCosts();          
        }     

       

            
        #region BarayandLbl_TextChanged
        private void BarayandLbl_TextChanged(object sender, EventArgs e)
        {
            if (this.BarayandTxt.Text.Trim() != string.Empty)
                if (this.BarayandTxt.Text.Trim().StartsWith("-"))
                {
                    this.BarayandTxt.Text = this.BarayandTxt.Text.TrimStart('-');
                    this.BarayandTxt.ForeColor = Color.Red;
                }
                else
                    this.BarayandTxt.ForeColor = Color.Blue;
        }
        #endregion

        
    }
}
