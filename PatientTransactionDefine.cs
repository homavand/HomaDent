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
using DNTPersianUtils.Core;

namespace Dentistry
{
    public partial class PatientTransactionDefine : Form
    {
        
        ReportForm fr_report;
        List<object> param;
        List<object> value;
        string EditOrNewFlag;
        int PatientId;
        int? PatientFinancialId = null;
        int? OldPayTypeId = null;
        int? NewPayTypeId = null;

        string ConnectionType, PortName;
        int BoundRate;

        private int patientRemianed = 0;
        public int PatientRemianed
        {
            set { this.patientRemianed = value; }
            get { return this.patientRemianed; }
        }

        #region PatientFinancialDefine
        public PatientTransactionDefine(int PatientId)
        {
            InitializeComponent();
           
                                 
            this.PatientId = PatientId;                        
            this.EditOrNewFlag = "New";            
        }
       


        
        public PatientTransactionDefine(int patientId , int patientFinancialId)
        {
         
            InitializeComponent();

            this.PatientId = patientId;
            this.PatientFinancialId = patientFinancialId;
            this.EditOrNewFlag = "Edit";
          
        }
        #endregion

        #region PatientFinancialDefine_Load
        private void PatientFinancialDefine_Load(object sender, EventArgs e)
        {

            this.GetPatientName();
            this.LoadFormInit();           
            this.TransactionDateTxt.Value = (Dentistry.UserControls.PersianDate)DateTime.Now;

            if (this.EditOrNewFlag == "Edit")
                FetchEntityInfo(this.PatientFinancialId);

            

        }
        #endregion

        #region LoadPatientInfo
        private void GetPatientName()
        {
            if (this.PatientId < 1)
                return;

            dynamic sObj = new
            {
                PatientId = this.PatientId,
            };
            JsonResponse<dynamic> result = DataProvider.GetPatientsFullNameX(sObj); 
            if (result == null || result.Success == false || result.Data == null)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }
            var dd = result.Data;
            var patient = (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).FirstOrDefault() : null;
            if (patient == null)
                return;
            if (patient.PatientId != null)
                PatientCodeTxt.Text = Convert.ToString(patient.PatientId);
            if (patient.PatientName != null)
                PatientNameTxt.Text = Convert.ToString(patient.PatientName);
           

        }

        #endregion

        #region FetchEntityInfo
        private void FetchEntityInfo(int? id)
        {
            if (id == null)
                return;

            try
            {
                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.PatientId = this.PatientId;
                sObj.Id = id;

                var data = Dentistry.DataProvider.GetPatientTransactionsX(sObj);
                var obj = data != null && data.Data != null && (Enumerable.Count(data.Data) > 0) ? data.Data[0] : null;

                if (obj != null)
                {
                    int payTypeId = obj.PayTypeId != null ? Convert.ToInt32(obj.PayTypeId) : 0;
                   
                    foreach(var pnl in this.PayTypePnl.Controls.OfType<UserControls.ExPanel>().ToList())
                    {
                        var rdoX = pnl.Controls.OfType<RadioButton>().ToList().Where(i => Convert.ToInt32(i.Tag) == payTypeId).Select(i => i).SingleOrDefault();

                        if (rdoX != null)
                        {
                            rdoX.Checked = true;
                            break;
                        }
                            
                    }
                  

                    this.OldPayTypeId = payTypeId;
                    this.TransactionDateTxt.Value = Publics.GetPropertyValue<DateTime>(obj, "Date");
                    this.amountTxt.SetText(Publics.GetPropertyValue<string>(obj, "Amount"));
                    this.commentTxt.Text = Publics.GetPropertyValue<string>(obj, "Comment");  
                    if (obj.PayTypeId.ToString() == "2")
                    {
                    }
                    if (obj.PayTypeId.ToString() == "3")
                    {
                        var bankId = Publics.GetPropertyValue<int>(obj, "BankId");
                        this.BankCbo.SelectedIndex = Publics.GetComboIndex(this.BankCbo, bankId);
                        this.MaturityDateCbo.Value = Publics.GetPropertyValue<DateTime>(obj, "DateOfMaturity"); 
                        this.ChequeNumberTxt.Text = Publics.GetPropertyValue<string>(obj, "ChequeNumber");
                        this.chequeStatusTxt.Text =  Publics.GetPropertyValue<string>(obj, "ChequeStatusTitle");

                    }
                }                             

            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }

        }
        #endregion

        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new
            {
                ISBank = true,
               
            };
            var data = Dentistry.DataProvider.LoadFormInitInfo(sObj);
            var dd = data != null && data.Data != null ? data.Data : null;

            if (dd == null)
                return;

            IEnumerable<dynamic> listBank = dd.Bank != null && (Enumerable.Count(dd.Bank) > 0) ? (dd.Bank as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList() : null;

            BankCbo.DataSource = listBank;
            BankCbo.ValueMember = "Id";
            BankCbo.DisplayMember = "Title";

            ChooseBankCbo.SelectedIndexChanged -= new EventHandler(this.comboBoxChooseBank_SelectedIndexChanged);                     
            ChooseBankCbo.DataSource = listBank;
            ChooseBankCbo.ValueMember = "Id";
            ChooseBankCbo.DisplayMember = "Title";
            ChooseBankCbo.SelectedIndexChanged += new EventHandler(this.comboBoxChooseBank_SelectedIndexChanged);       

         
           
        }
        #endregion             
      
        #region buttonOk_Click
        private void buttonOk_Click(object sender, EventArgs e)
        {            
            try
            {

                var amount = double.Parse(this.amountTxt.GetPoorText());

                if (amount > this.PatientRemianed)
                    if (FarsiMessageBox.FMessageBox.Show("کاربر گرامی مبلغ وارد شده بیشتر از بدهی بیمار می باشد.آیا برای ادامه مطمئن هستید؟", "هشدار", FMessageBoxButtons.OKCancel, FMessageBoxIcons.Question, FMessageBoxDefaultButtons.Button1) != System.Windows.Forms.DialogResult.OK)
                    {
                        return;
                    }
                    

                if (this.ValidateForm() == false)
                    return;

                int? xPatientFinancialId = null;
     
                this.Enabled = false;
              

                dynamic iObj = new ExpandoObject();

                int payTypeId = 0;
                               
                foreach (var pnl in this.PayTypePnl.Controls.OfType<UserControls.ExPanel>().ToList())
                {
                    var rdoX = pnl.Controls.OfType<RadioButton>().ToList().Where(i => Convert.ToBoolean(i.Checked) == true).Select(i => i).SingleOrDefault();

                    if (rdoX != null)
                    {
                        payTypeId = Convert.ToInt32(rdoX.Tag);
                        
                        break;
                    }

                }
              

                

                iObj.ActionType = "New";
                if (this.PatientFinancialId != null)
                {
                    iObj.ActionType = "Edit";
                    iObj.Id = this.PatientFinancialId;
                }
                    
                iObj.PatientId = Convert.ToInt32(this.PatientId);
                iObj.PayTypeId = payTypeId;
                iObj.Date = Class.Date.ToChristianByTime(this.TransactionDateTxt.Value.ToString() , true );               
                iObj.Amount = amount;

                if (payTypeId == 2)
                {
                }
                if (payTypeId == 3)
                {
                    iObj.ChequeNumber = this.ChequeNumberTxt.Text.Trim();
                    iObj.BankId = this.BankCbo.SelectedValue != null ? int.Parse(this.BankCbo.SelectedValue.ToString()) : (int?)null;
                    iObj.ChequeTypeId = 2; // واریز
                    iObj.ChequeStatusId = 1;
                    iObj.DateOfIssuance = Class.Date.ToChristianByTime(this.TransactionDateTxt.Value.ToString());
                    iObj.DateOfMaturity = Class.Date.ToChristianByTime(this.MaturityDateCbo.Value.ToString());
                }

                iObj.Comment = this.commentTxt.Text.Trim().ToString();
                iObj.IsDeleted = false;

                JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientFinancialX(iObj);

                if (result != null && result.Success == true && result.Data != null)
                {
                    xPatientFinancialId = Publics.GetPropertyValue<int>(result.Data, "Id");  
                    if (xPatientFinancialId == null)
                        return;
                    this.DialogResult = DialogResult.OK;
                    PrintFish(xPatientFinancialId.Value);
                }

               
                this.Enabled = true ;
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                
            }
            finally
            {
                this.Close();
            }
        }
        #endregion

    

        #region ValidateForm
        private bool ValidateForm()
        {

            bool Flag = true;

         
            if ((this.amountTxt.Text.Trim() == string.Empty) || (this.amountTxt.IsValid() == false))
            {
                this.Error_textBoxPayableMoney.Visible = true;
                Flag = false;
            }
            else
            {
                this.Error_textBoxPayableMoney.Visible = false;
            }



            if (string.IsNullOrEmpty(this.TransactionDateTxt.Text))
            {
                this.Error_textBoxDate.Visible = true;
                Flag = false;
            }
            else
            {
                this.Error_textBoxDate.Visible = false;
            }


        
            return Flag;
        }


        #endregion

        

        private void comboBoxChooseBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            IEnumerable<dynamic> list = ChooseBankCbo.DataSource as IEnumerable<dynamic>;
            dynamic obj = null;
            foreach(dynamic item in list)
            {
                if(item != null && item.Id != null)
                    if (item.Id.ToString() == ((ComboBox)sender).SelectedValue.ToString())
                        obj = item;
            }
            
            this.BoundRate      = obj.BoundRate != null ? int.Parse(obj.BoundRate.ToString()) : null;
            this.ConnectionType = obj.ConnectionType != null ? obj.ConnectionType.ToString() : null;
            this.PortName       = obj.PortName != null ? obj.PortName.ToString() : null;

        }

        private void PrintFish(int payId)
        {

            fr_report = new ReportForm();
            param = new List<object>();
            value = new List<object>();

       
            param.Add("PayId");
            value.Add(payId);
            
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.Id = payId;            
            
            var data = Dentistry.DataProvider.GetPatientTransactionsX(sObj);

            fr_report.RunReport("rpt_PatientFish", param, value, data.Data);
            fr_report.ShowDialog();
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

            int val = Convert.ToInt32(rdoX.Tag);

            switch (val)
            {
                case 0:
                    this.PosPanel.Enabled = false;
                    this.ChequePanel.Enabled = false;

                    break;
                case 1:
                    this.PosPanel.Enabled = false;
                    this.ChequePanel.Enabled = false;
                    break;
                case 2:
                    this.PosPanel.Enabled = true;
                    this.ChequePanel.Enabled = false;
                    break;
                case 3:
                    this.PosPanel.Enabled = false;
                    this.ChequePanel.Enabled = true;

                    break;                
                case 4:
                    this.PosPanel.Enabled = false;
                    this.ChequePanel.Enabled = false;
                    break;

                default:
                    this.PosPanel.Enabled = false;
                    this.ChequePanel.Enabled = false;
                    break;
            }
        }


        private void btn_Connect_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm() == false)
                return;
          
            int pay = int.Parse(amountTxt.Text.Replace(",", "")) ;
            PosBank pos = new PosBank();

            
            string TraceNumber=pos.BankMellat(this.ConnectionType, this.PortName, this.BoundRate, pay.ToString());

            if (TraceNumber != "")
            {
               
                FMessageBox.Show("IS OK", TraceNumber, FMessageBoxButtons.OK, FMessageBoxIcons.Information);
            
            }
            else
            {
               
                FMessageBox.Show("Not OK", Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.OK, FMessageBoxIcons.Warning);
            }
        }
    }
}








