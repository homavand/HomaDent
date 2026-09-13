using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiMessageBox;
using System.Globalization;
using System.Dynamic;
using System.Linq;
using System.Collections;

namespace Dentistry
{
    public partial class CostFinancialDefine : Form
    {
        string EditOrNewFlag;
        int? CostId = null;     
        int CostTypeId = 0;
        int BargainSideId = 0;
       
        int PayTypeId = 1;
    
       
        #region CostRegister_NewEdit
        public CostFinancialDefine()
        {
            InitializeComponent();

            
          

            this.EditOrNewFlag = "New";
            this.TransactionDateTxt.Value = DateTime.Now;
            this.MaturityDateCbo.Value = DateTime.Now;


        }
        #endregion


        #region CostRegister_NewEdit_OverLoaded
        public CostFinancialDefine(int costId)
        {
            InitializeComponent();
           

            this.EditOrNewFlag = "Edit";
            this.CostId = costId;
            
        }
        #endregion

        private void CostRegisterDefine_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();
            if(this.EditOrNewFlag == "Edit")
                FetchEntityInfo(this.CostId.Value);
        }

        #region LoadFormInit
        private void LoadFormInit()
        {

            dynamic sObj = new
            {
                IsCostType = true,
                //IsPayType = true,
                IsBargainSide = true,
                IsBank = true,
            };
            var data = Dentistry.DataProvider.LoadFormInitInfo(sObj);
            var dd = data != null && data.Data != null ? data.Data : null;

            if (dd == null)
                return;

            IEnumerable<dynamic> listCostType = dd.CostType != null && (Enumerable.Count(dd.CostType) > 0) ? (dd.CostType as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).Where(i => i.Id != 0).ToList() : null;
            //IEnumerable<dynamic> listPayType = dd.PayType != null && (Enumerable.Count(dd.PayType) > 0) ? (dd.PayType as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList() : null;
            IEnumerable<dynamic> listBargainSide = dd.BargainSide != null && (Enumerable.Count(dd.BargainSide) > 0) ? (dd.BargainSide as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList() : null;
            IEnumerable<dynamic> listBank = dd.Bank != null && (Enumerable.Count(dd.Bank) > 0) ? (dd.Bank as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList() : null;           
            //

            this.dgCostTypes.SelectionChanged -= new System.EventHandler(this.dgCostTypes_SelectionChanged);
            this.dgCostTypes.DataSource = listCostType;
            this.dgCostTypes.CurrentCell = null;
            this.dgCostTypes.SelectionChanged += new System.EventHandler(this.dgCostTypes_SelectionChanged);
            //

            this.BargainSideCbo.DataSource = dd.BargainSide;
            this.BargainSideCbo.ValueMember = "Id";
            this.BargainSideCbo.DisplayMember = "Title";

            //

        

           

            this.BankCbo.SelectedIndexChanged -= new EventHandler(this.comboBoxBank_SelectedIndexChanged);            
            BankCbo.DataSource = listBank;
            BankCbo.ValueMember = "Id";
            BankCbo.DisplayMember = "Title";
            this.BankCbo.SelectedIndexChanged += new EventHandler(this.comboBoxBank_SelectedIndexChanged);

            //
            

        }
        #endregion

        #region FetchEntityInfo
        private void FetchEntityInfo(int id)
        {
            try
            {

                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.CostId = id;

                var data = Dentistry.DataProvider.GetCostFinancialsX(sObj);
                var dd = (data != null && data.Data != null) ? data.Data : null;

                var obj = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).FirstOrDefault() : null;
               

                if (obj != null)
                {
                    int costTypeId = obj.CostTypeId != null ? Convert.ToInt32(obj.CostTypeId) : 0;

                    int rowIndex = -1;
                    foreach (DataGridViewRow row in dgCostTypes.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["ColumnId"].Value) == costTypeId)
                        {
                        //    row.Selected = true;
                            rowIndex = row.Index;
                            break;
                        }
                    }
                    dgCostTypes.ClearSelection();
                    dgCostTypes.CurrentCell = dgCostTypes.Rows[rowIndex].Cells[1];
                    dgCostTypes.CurrentRow.Selected = false;
                    dgCostTypes.Rows[rowIndex].Selected = true;

                   

                    int payTypeId = obj.PayTypeId != null ? Convert.ToInt32(obj.PayTypeId) : 0;

                    foreach (var pnl in this.PayTypePnl.Controls.OfType<UserControls.ExPanel>().ToList())
                    {
                        var rdoX = pnl.Controls.OfType<RadioButton>().ToList().Where(i => Convert.ToInt32(i.Tag) == payTypeId).Select(i => i).SingleOrDefault();

                        if (rdoX != null)
                        {
                            rdoX.Checked = true;
                            break;
                        }

                    }

                    this.AmountTxt.SetText(Convert.ToString(obj.Amount));
                    //بررسی شود
                    this.factorNumberTxt.Text = obj.FactorNumber;

                  
                    this.TransactionDateTxt.Value = obj.Date;

                    this.CommentTxt.Text = obj.Comment;

                    var bargainSideId = Publics.GetPropertyValue<int>(obj, "BargainSideId");
                    this.BargainSideCbo.SelectedIndex = Publics.GetComboIndex(this.BargainSideCbo, bargainSideId);  
                 

                    if (payTypeId == 3)
                    {                        
                        var bankId = Publics.GetPropertyValue<int>(obj, "BankId");
                        this.BankCbo.SelectedIndex = Publics.GetComboIndex(this.BankCbo, bankId);
                        this.MaturityDateCbo.Value = Publics.GetPropertyValue<DateTime>(obj, "DateOfMaturity");
                        this.ChequeNumberTxt.Text = Publics.GetPropertyValue<string>(obj, "ChequeNumber");
                        this.chequeStatusTxt.Text = Publics.GetPropertyValue<string>(obj, "ChequeStatusTitle");
                    }
                }

            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }

        }
        #endregion




      

        #region comboBoxBank_SelectedIndexChanged
        private void comboBoxBank_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }
        #endregion


  

        #region buttonOk_Click
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm() == false)
                return;
            try
            {
                
                dynamic iObj = new ExpandoObject();
                if (this.CostId != null)
                {
                    iObj.Id = this.CostId;
                }
                iObj.ActionType = "New";
                iObj.CostTypeId = this.CostTypeId;
                iObj.PayTypeId = this.PayTypeId;             
                iObj.Amount = double.Parse(this.AmountTxt.GetPoorText());
                iObj.FactorNumber = this.factorNumberTxt.Text.Trim().ToString();
                iObj.Date = Class.Date.ToChristianByTime(this.TransactionDateTxt.Value.ToString());

                if (this.PayTypeId == 2)
                {
                }
                if (this.PayTypeId == 3)
                {
                    iObj.ChequeNumber = this.ChequeNumberTxt.Text.Trim();
                    iObj.BankId = this.BankCbo.SelectedValue != null ? int.Parse(this.BankCbo.SelectedValue.ToString()) : (int?)null;
                    iObj.ChequeTypeId = 1; // برداشت
                    iObj.ChequeStatusId = 1;
                    iObj.DateOfIssuance = Class.Date.ToChristianByTime(this.TransactionDateTxt.Value.ToString());
                    iObj.DateOfMaturity = Class.Date.ToChristianByTime(this.MaturityDateCbo.Value.ToString());
                }
                
                iObj.Comment = this.CommentTxt.Text.Trim().ToString();
                iObj.IsDeleted = false;

                if (this.CostTypeId == 1)
                {
                  
                    iObj.BargainSideId = Convert.ToInt32(this.BargainSideCbo.SelectedValue);
                    iObj.CostTitle = Convert.ToString(this.BargainSideCbo.Text);
                }
                else
                {
                    iObj.BargainSideId = 0;
                    iObj.CostTitle = this.costTitleLbl.Text;
                }

                JsonResponse<dynamic> result = Dentistry.DataProvider.DefineCostX(iObj);

                if (result != null && result.Success == true && result.Data != null)
                {
                    this.DialogResult = DialogResult.OK;
                }


                this.Close();
            }
            catch (System.Exception exp)
            {
                 ErrorClass.WriteErrorsToFile(this.Name, exp.TargetSite.Name.ToString(), exp.Message, DateTime.Now);
            }
        }
        #endregion

        #region ValidateForm
        private bool ValidateForm()
        {
            bool Flag = true;
            if (this.CostTypeId == 0)
            {
                this.Error_comboBoxCostTitle.Visible = true;
                Flag = false;
            }
            else
                this.Error_comboBoxCostTitle.Visible = false;



           
            if (this.CostTypeId == 1 )
            {
                int? bargainSideId = Convert.ToInt32(BargainSideCbo.SelectedValue);
                if(bargainSideId == null || bargainSideId < 1)
                {
                    this.Error_comboBoxBargainSide.Visible = true;
                    Flag = false;
                }
                else
                    this.Error_comboBoxBargainSide.Visible = false;
            }
           

           



            if (this.PayTypeId == 3)
            {
                if (this.ChequeNumberTxt.Text == string.Empty)
                {
                    this.Error_textBoxNumberOfCheque.Visible = true;
                    Flag = false;
                }
                else
                    this.Error_textBoxNumberOfCheque.Visible = false;

                if (string.IsNullOrEmpty(this.MaturityDateCbo.Text))
                {
                    this.Error_textBoxDateOfMaturity.Visible = true;
                    Flag = false;
                }
                else
                    this.Error_textBoxDateOfMaturity.Visible = false;



            }

            if (this.PayTypeId == 4)
                if (this.factorNumberTxt.Text == string.Empty)
                {
                    this.Error_textBoxFactorNumber.Visible = true;
                    Flag = false;
                }
                else
                    this.Error_textBoxFactorNumber.Visible = false;





            if ((this.AmountTxt.Text == string.Empty) || (this.AmountTxt.IsValid() == false))
            {
                this.Error_textBoxPrice.Visible = true;
                Flag = false;
            }
            else
                this.Error_textBoxPrice.Visible = false;




            if (string.IsNullOrEmpty(this.TransactionDateTxt.Text))
            {
                this.Error_textBoxDate.Visible = true;
                Flag = false;
            }
            else
                this.Error_textBoxDate.Visible = false;

            return Flag;
        }





        #endregion

        private void dgCostTypes_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dgCostTypes.CurrentRow != null) && (((DataGridView)sender).CurrentRow.Selected))
            {
                this.CostTypeId = Convert.ToInt32(this.dgCostTypes.CurrentRow.Cells["ColumnId"].Value);
                this.costTitleLbl.Text = Convert.ToString(this.dgCostTypes.CurrentRow.Cells["ColumnTitle"].Value);
                
                if(this.CostTypeId == 1)
                    this.panelBargainSide.Enabled = true;
                else
                    this.panelBargainSide.Enabled = false;
            }
        }

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

            this.PayTypeId = Convert.ToInt32(rdoX.Tag);
           
            switch (this.PayTypeId)
            {
                case 1:
                    break;
                case 2:
                    break;
                case 3:
                    this.PanelCheque.Enabled = true;
                    this.factorNumberPnl.Enabled = false;
                    this.ChequeNumberTxt.Text = string.Empty;
                    this.MaturityDateCbo.Value = DateTime.Now;
                    this.BankCbo.SelectedIndex = -1;
                    break;
                case 4:
                    this.PanelCheque.Enabled = false;
                    this.factorNumberPnl.Enabled = true;
                    break;

                default:
                    this.PanelCheque.Enabled = false;
                    this.factorNumberPnl.Enabled = false;
                    this.factorNumberTxt.Text = string.Empty;
                    break;
            }
        }

       
    }
}





