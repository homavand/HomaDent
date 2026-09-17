using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using FarsiMessageBox;
using PopupControl;
using DNTPersianUtils.Core;

namespace Dentistry
{
    public partial class PatientTransactionsFinancialList : Form
    {
        int patientId = 0;   
        PopupControl.Popup p;

        private Dictionary<int, String> PatientsList;
        private Dictionary<int, String> CBFilteredList;
        bool ComboBoxBusy;

        public int PatientId
        {
            get { return this.patientId; }
            set
            {
                if ((value < 0) || (value == null))
                    this.patientId = 0;
                else
                    this.patientId = value;
                
                //Dentistry.Config.SelectedPatientId = this.patientId;
            }
        }

        #region PatientFinancials
        public PatientTransactionsFinancialList()
        {
            InitializeComponent();                     
            this.PatientId = Dentistry.AppConfigs.SelectedPatientId;

            PatientsList = new Dictionary<int, String>();
            CBFilteredList = new Dictionary<int, String>();

        }

        private void FormPatientFinancials_Load(object sender, EventArgs e)
        {
            var date = new PersianDateTime(DateTime.Now).Date;
            this.FromDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, date.Month, 1);
            this.ToDateTxt.Value = new Dentistry.UserControls.PersianDate(date.Year, date.Month, date.Day);
            this.dgPatientFinancialTransactions.MouseWheel += new MouseEventHandler(dgPatientFinancialTransactions_MouseWheel);

            
            this.PatientId = Dentistry.AppConfigs.SelectedPatientId;
            this.LoadFormInit();
         



            if (this.PatientCbo.SelectedIndex > 0)
                this.FillGrid_dgPatientFinancialTransactions();

            this.dgPatientFinancialTransactions_ColumnOrder();
        }

        #endregion

        #region FormPatientFinancials_Activated
        private void FormPatientFinancials_Activated(object sender, EventArgs e)
        {
            this.dgPatientFinancialTransactions.CurrentCell = null;
            
        }
        #endregion

        #region LoadFormInit
        private void LoadFormInit()
        {

            dynamic sObj = new
            {
                IsDeleted = false
            };
            var result = Dentistry.DataProvider.GetAllPatientsFullNamesX(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;
            var patientList = (dd as IEnumerable<dynamic>)
                 .Select(i =>
                 new
                 {
                     Id = (int)i.PatientId,
                     Title = (string)i.PatientName,
                     TitleX = string.Format("{0} ({1})", i.PatientName, i.PatientId),

                 }).ToList();

            this.PatientCbo.SelectedIndexChanged -= new EventHandler(this.PatientNameCbo_SelectedIndexChanged);
            foreach(dynamic item in patientList)
            {
                this.PatientsList.Add(Convert.ToInt32(item.Id), Convert.ToString(item.TitleX));
            }
          
            //this.PatientCbo.DataSource = dd.Patient;
            //this.PatientCbo.ValueMember = "Id";
            //this.PatientCbo.DisplayMember = "Title";
            //Publics.AutoComplete(this.PatientCbo, dd.Patient);
            FilterList(false);
            this.PatientCbo.SelectedIndexChanged += new EventHandler(this.PatientNameCbo_SelectedIndexChanged);

            //this.PatientCbo.SelectedIndex = Publics.GetComboIndex(this.PatientCbo, this.patientId);

            //if (Dentistry.Config.SelectedPatientId != 0)
            //{
            //    try
            //    {
            //        this.PatientId = (int)Dentistry.Config.SelectedPatientId;
            //        DataTable dt1 = (DataTable)PatientCbo.DataSource;
            //        for (int i = 0; i < dt1.Rows.Count; ++i)
            //        {
            //            if (dt1.Rows[i][PatientCbo.ValueMember].ToString() == this.PatientId.ToString())
            //            {
            //                PatientCbo.SelectedIndex = i;
            //                break;
            //            }

            //        }
            //    }
            //    catch { }

            //}

            if (this.PatientCbo.SelectedIndex == 0)
                this.dgPatientFinancialTransactions_SelectionChanged(this, null);

        }
        #endregion

        private void FilterList(bool show)
        {
            if (ComboBoxBusy == false)
            {
                String orgText;

                ComboBoxBusy = true;
                orgText = PatientCbo.Text;

                PatientCbo.DroppedDown = false;

                CBFilteredList.Clear();

                foreach (KeyValuePair<int, string> item in PatientsList)
                {
                    if (item.Value.ToUpper().Contains(orgText.ToUpper()))
                        CBFilteredList.Add(item.Key, item.Value);
                }

                if (CBFilteredList.Count < 1)
                    CBFilteredList.Add(0, "---");

                PatientCbo.BeginUpdate();
                PatientCbo.DataSource = new BindingSource(CBFilteredList, null);
                PatientCbo.DisplayMember = "Value";
                PatientCbo.ValueMember = "Key";
                //PatientCbo.DisplayMember = "Key";
                //PatientCbo.ValueMember = "Value";
                PatientCbo.DroppedDown = show;
                PatientCbo.SelectedIndex = -1;
                PatientCbo.Text = orgText;
                PatientCbo.Select(PatientCbo.Text.Length, 0);
                PatientCbo.EndUpdate();
                Cursor.Current = Cursors.Default;

                ComboBoxBusy = false;
            }
        }

        #region PatientNameCbo_SelectedIndexChanged
        private void PatientNameCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (PatientCbo.SelectedValue == null)
                return;
            if (ComboBoxBusy == false)
            {
                FilterList(false);
            }

            if (this.PatientCbo.SelectedValue == null)
                return;

            this.PatientId = int.Parse(this.PatientCbo.SelectedValue.ToString());

            
            this.dgPatientFinancialTransactions.CurrentCell = null;
            this.dgPatientFinancialTransactions_SelectionChanged(this, null);

            //this.FillGrid_dgPatientFinancialTransactions();

        }
        #endregion

        private void PatientCbo_TextUpdate(object sender, EventArgs e)
        {
            FilterList(true);
        }

        private void dgPatientFinancialTransactions_ColumnOrder()
        {
            dgPatientFinancialTransactions.AutoGenerateColumns = false;
            dgPatientFinancialTransactions.Columns["ColumnSolarDate"].DisplayIndex = 0;
            dgPatientFinancialTransactions.Columns["ColumnTransactionId"].DisplayIndex = 1;
            dgPatientFinancialTransactions.Columns["ColumnPatientId"].DisplayIndex = 2;
            dgPatientFinancialTransactions.Columns["ColumnPatientName"].DisplayIndex = 3;
            dgPatientFinancialTransactions.Columns["ColumnPayable"].DisplayIndex = 4;
            dgPatientFinancialTransactions.Columns["ColumnPayTypeTitle"].DisplayIndex = 5;
            dgPatientFinancialTransactions.Columns["ColumnComment"].DisplayIndex = 6;
            dgPatientFinancialTransactions.Columns["ColumnChequeNumber"].DisplayIndex = 7;
            dgPatientFinancialTransactions.Columns["ColumnSolarDateOfMaturity"].DisplayIndex = 8;
        }

        public DataTable getListDataTable(IEnumerable<dynamic> list)
        {                                
            DataTable dt = new DataTable();
            dt.Columns.Add("TransactionId", typeof(int));
            dt.Columns.Add("SolarDate", typeof(string));
            dt.Columns.Add("PatientId", typeof(string));
            dt.Columns.Add("PatientName", typeof(string));
            dt.Columns.Add("Amount", typeof(double));
            dt.Columns.Add("PayTypeId", typeof(int));
            dt.Columns.Add("PayTypeTitle", typeof(string));
            dt.Columns.Add("ChequeNumber", typeof(string));
            dt.Columns.Add("SolarDateOfMaturity", typeof(string));
            dt.Columns.Add("ChequeStatusId", typeof(int));
            dt.Columns.Add("IsDeleted", typeof(bool));
           
          

            foreach (var item in list)
                dt.Rows.Add(
                    item.TransactionId,                  
                    item.SolarDate,
                    item.PatientId,
                    item.PatientName,
                    item.Amount,
                    item.PayTypeId,
                    item.PayTypeTitle,
                    item.ChequeNumber,
                    item.SolarDateOfMaturity,
                    item.ChequeStatusId,
                    item.IsDeleted
                  
                    );

            return dt;
        }

        #region FillGrid_dgPatientFinancialTransactions
        private void FillGrid_dgPatientFinancialTransactions()
        {

            


            this.PayType3Txt.Text = string.Empty;
            this.PayType5Txt.Text = string.Empty;
            this.PayType1Txt.Text = string.Empty;
            this.PayType2Txt.Text = string.Empty;


            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.PatientId = this.PatientId;

            if ((this.FromDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.FromDateTxt.Value.ToString())))
                sObj.FromDate = string.Format("{0} 00:00:01", this.FromDateTxt.Value.ToString()).ToGregorianDateTime();

            if ((this.ToDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.ToDateTxt.Value.ToString())))
                sObj.ToDate = string.Format("{0} 23:59:59", this.ToDateTxt.Value.ToString()).ToGregorianDateTime();

            foreach (var pnl in this.TransactionTypePnl.Controls.OfType<UserControls.ExPanel>().ToList())
            {
                var rdoX = pnl.Controls.OfType<RadioButton>().ToList().Where(i => i.Checked == true).Select(i => i).SingleOrDefault();

                if (rdoX != null)
                {
                    sObj.PayTypeId = Convert.ToInt32(rdoX.Tag);
                    break;
                }

            }

            JsonResponse<dynamic> result = DataProvider.GetPatientTransactionsX(sObj);
            if (result == null || result.Success != true || result.Data == null)
                return;
            var data = result.Data != null  ?  (result.Data as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true)
                .Select(i =>
                  new
                  {                 
                      TransactionId = (int)i.TransactionId,
                      PatientId = (int)i.PatientId,
                      SolarDate = (string)i.SolarDate,
                      Amount = (double)i.Amount,                     
                      PatientName = (string)i.PatientName,
                      PayTypeId = (int)i.PayTypeId,
                      PayTypeTitle = (string)i.PayTypeTitle,
                      Comment = (string)i.Comment,
                      ChequeNumber = (string)i.ChequeNumber,
                      SolarDateOfMaturity = (string)i.SolarDateOfMaturity,
                      ChequeStatusId = (int?)i.ChequeStatusId,
                      IsDeleted = Convert.ToBoolean(i.IsDeleted),
                  }).ToList() : Enumerable.Empty<dynamic>();

        


            var totalResult =
                            (from item in data
                            group item by new { item.PayTypeId } into gItem

                            select new
                            {
                                PayTypeId = gItem.Key.PayTypeId,
                                TotalAmount = gItem.Sum(i => (double)i.Amount),
                            }).ToList();



            DataTable dt = getListDataTable(data);
            this.dgPatientFinancialTransactions.DataSource = dt;

            if (totalResult == null && totalResult.Count < 1)
                return;
            this.PayType1Txt.Text = totalResult.Where(i => i.PayTypeId == 1).Any() ? Convert.ToString(totalResult.Where(i => i.PayTypeId == 1).FirstOrDefault().TotalAmount) : "0";
            this.PayType2Txt.Text = totalResult.Where(i => i.PayTypeId == 2).Any() ? Convert.ToString(totalResult.Where(i => i.PayTypeId == 2).FirstOrDefault().TotalAmount) : "0";
            this.PayType3Txt.Text = totalResult.Where(i => i.PayTypeId == 3).Any() ? Convert.ToString(totalResult.Where(i => i.PayTypeId == 3).FirstOrDefault().TotalAmount) : "0";
            this.PayType4Txt.Text = totalResult.Where(i => i.PayTypeId == 4).Any() ? Convert.ToString(totalResult.Where(i => i.PayTypeId == 4).FirstOrDefault().TotalAmount) : "0";
            this.PayType5Txt.Text = totalResult.Where(i => i.PayTypeId == 5).Any() ? Convert.ToString(totalResult.Where(i => i.PayTypeId == 5).FirstOrDefault().TotalAmount) : "0";
            this.PayType6Txt.Text = totalResult.Where(i => i.PayTypeId == 6).Any() ? Convert.ToString(totalResult.Where(i => i.PayTypeId == 6).FirstOrDefault().TotalAmount) : "0";




        }
        #endregion

        #region dgPatientFinancialTransactions_CellDoubleClick
        private void dgPatientFinancialTransactions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.ButtonEdit1_Click(this, null);
        }
        #endregion

        #region dgPatientFinancialTransactions_SelectionChanged
        private void dgPatientFinancialTransactions_SelectionChanged(object sender, EventArgs e)
        {
        
            if ((this.dgPatientFinancialTransactions.CurrentCell != null) && (this.dgPatientFinancialTransactions.CurrentRow.Selected))
            {
                this.ButtonEdit.Enabled = true;
                this.ButtonDelete.Enabled = true;
            }
            else
            {
                this.ButtonEdit.Enabled = false;
                this.ButtonDelete.Enabled = false;
                //if (this.PatientCbo.SelectedIndex == 0)
                //    this.ButtonNew.Enabled = false;
                //else
                //    this.ButtonNew.Enabled = true;
            }

        }
        #endregion

        #region dgPatientFinancialTransactions_MouseWheel
        private void dgPatientFinancialTransactions_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.dgPatientFinancialTransactions.CurrentCell == null)
                return;
            dgPatientFinancialTransactions.EndEdit();
            if (e.Delta.Equals(120) && dgPatientFinancialTransactions.CurrentRow.Index != 0)
                SendKeys.Send("{Up}");

            else if (!e.Delta.Equals(120) && dgPatientFinancialTransactions.CurrentRow.Index != dgPatientFinancialTransactions.Rows.Count - 1)

                SendKeys.Send("{Down}");
        }
        #endregion 

        #region ButtonNew1_Click
        private void ButtonNew1_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_تراکنش_ها_جدید) == false)
                return;

            try
            {

                int patientId = this.PatientCbo.SelectedValue != null ? int.Parse(this.PatientCbo.SelectedValue.ToString()) : -1;
                if (patientId <= 0)
                    return;

                PatientFinancialDefine form = new PatientFinancialDefine(this.PatientId);
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    this.FillGrid_dgPatientFinancialTransactions();
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

        #region ButtonEdit1_Click
        private void ButtonEdit1_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_تراکنش_ها_ویرایش) == false)
                return;

            try
            {
              
                if (this.PatientCbo.SelectedIndex == 0)
                    return;
                if(this.dgPatientFinancialTransactions.CurrentCell == null)
                    return;

                PatientFinancialDefine form = new PatientFinancialDefine(this.PatientId,int.Parse(this.dgPatientFinancialTransactions["ColumnTransactionId", this.dgPatientFinancialTransactions.CurrentRow.Index].Value.ToString()));
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                {
                    this.FillGrid_dgPatientFinancialTransactions();
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

        #region ButtonDelete1_Click
        private void ButtonDelete1_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_تراکنش_ها_حذف) == false)
                return;

            if (this.dgPatientFinancialTransactions.CurrentCell == null)
                return;

           
            try
            {


                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    dynamic iObj = new System.Dynamic.ExpandoObject();
                    iObj.ActionType = "Delete";
                    iObj.Id = Convert.ToInt32(dgPatientFinancialTransactions.CurrentRow.Cells["ColumnTransactionId"].Value);
                    iObj.IsDeleted = true;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientFinancialX(iObj);
                    if (result != null && result.Success == true)
                    {
                        this.FillGrid_dgPatientFinancialTransactions();
                    }

                }
            }
            catch (System.Exception exp)
            {

                MessageBox.Show(exp.Message);


            }
     
        }
        #endregion

        private void textBoxPayableMoney_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            
            //Help.ShowHelp(this.textBoxPayableMoney, @"c:\WinRAR.chm", HelpNavigator.Index);
        }

        private void PrintFish()
        {
            if (this.dgPatientFinancialTransactions.CurrentCell == null) 
                return;
            int payId = Convert.ToInt32(this.dgPatientFinancialTransactions["ColumnTransactionId", dgPatientFinancialTransactions.CurrentRow.Index].Value);

            frm_Report fr_report = new frm_Report();
            List<object> param = new List<object>();
            List<object> value = new List<object>();

            param.Add("PayId");
            value.Add(payId);

            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.Id = payId;

            var data = Dentistry.DataProvider.GetPatientTransactionsX(sObj);

            fr_report.RunReport("rpt_PatientFish", param, value, data.Data);
            fr_report.ShowDialog();


        }
        #region buttonSuratHesab_Click
        private void PrintSourathesab()
        {
            frm_Report fr_report = new frm_Report();
            List<object> param = new List<object>();
            List<object> value = new List<object>();


            param.Add("ReportTitle");
            value.Add("صورتحساب بیمار");

        
            var patientId = Convert.ToInt32(this.dgPatientFinancialTransactions["ColumnPatientId", this.dgPatientFinancialTransactions.CurrentRow.Index].Value);


            dynamic sObj = new
            {
                PatientId = patientId,
                CheckupTypeId = 2
            };
            var result = Dentistry.DataProvider.GetOnePatientInfoX(sObj); // Patient  &  PatientInsurance
            if (result == null || result.Success == false || result.Data == null)
                return;
            var patient = result.Data;


            sObj = new
            {
                PatientId = patientId,               
            };
            result = Dentistry.DataProvider.GetPatientTransactionsX(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;
            var patientFinancial = result.Data;




            result = Dentistry.DataProvider.GetPatientServicesX(sObj);
            var dd = result.Data;

            if (dd == null)
                return;

            var patientServices = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>)
                                    .Select(i =>
                                    new Class.PatientService(i))
                                    .Select(i =>
                                        new
                                        {
                                            PatientServiceId = (int)i.Id,
                                            
                                            i.ServiceTitle,
                                            
                                            i.SolarDate,
                                            i.ActionPrice,
                                            i.ServicePrice,                                           
                                            i.ToothTitle,
                                            i.ToothImage,

                                        }).ToList() : null;


            var data = new
            {
                Patient = patient,
                PatientInsurance = patient,
                patientFinancial = patientFinancial,
                PatientServices = patientServices
            };
            fr_report.RunReport("rpt_PatientBill", param, value, data);
            fr_report.ShowDialog();
            
        }
        private void buttonSuratHesab_Click(object sender, EventArgs e)
        {
            if (this.dgPatientFinancialTransactions.CurrentCell == null)
                return;
            PrintSourathesab();           
        }
        #endregion

      

        private void FormPatientFinancials_KeyDown(object sender, KeyEventArgs e)
        {
            #region F2
            if (e.KeyCode == Keys.F2)
            {
                if (this.ButtonNew.Enabled == true)
                    this.ButtonNew1_Click(this, null);
            }
            #endregion

            #region F4
            if (e.KeyCode == Keys.F4 && e.Modifiers != Keys.Alt)
            {
                if (this.ButtonEdit.Enabled == true)
                    this.ButtonEdit1_Click(this, null);
            }
            #endregion

            #region F8
            if (e.KeyCode == Keys.F8)
            {
                if (this.ButtonDelete.Enabled == true)
                    this.ButtonDelete1_Click(this, null);
            }
            #endregion
        }




        private void comboBoxFullName_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }

     

     
        #region labelstale_TextChanged
        private void labelstale_TextChanged(object sender, EventArgs e)
        {
            if (this.PayType5Txt.Text.Trim() != string.Empty)
                if (this.PayType5Txt.Text.Trim().StartsWith("-"))
                {
                    this.PayType5Txt.Text = this.PayType5Txt.Text.TrimStart('-');
                    this.PayType5Txt.ForeColor = Color.Blue;
                }
                else
                    this.PayType5Txt.ForeColor = Color.Red;

        }




        #endregion

        private void radioTransactionType_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdoX = sender as RadioButton;
            if (rdoX == null || rdoX.Checked != true)
                return;

            var pnlList = this.TransactionTypePnl.Controls.OfType<UserControls.ExPanel>().ToList();

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

            
        }

        private void SearchBtn_Click(object sender, EventArgs e)
        {
            this.FillGrid_dgPatientFinancialTransactions();
        }

        private void BottonFish_Click(object sender, EventArgs e)
        {
            this.PrintFish();
        }

        private void dgPatientFinancialTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgPatientFinancialTransactions["ColumnPayTypeId", e.RowIndex].Value != null)
                switch (this.dgPatientFinancialTransactions["ColumnPayTypeId", e.RowIndex].Value.ToString())
                {
                    case "1":
                    case "2":
                        this.dgPatientFinancialTransactions.Rows[e.RowIndex].Cells["ColumnPayTypeTitle"].Style.ForeColor = Color.LimeGreen;
                        break;
                    case "3":
                    case "4":
                        this.dgPatientFinancialTransactions.Rows[e.RowIndex].Cells["ColumnPayTypeTitle"].Style.ForeColor = Color.DodgerBlue;
                        break;
                    case "5":
                    case "6":
                        this.dgPatientFinancialTransactions.Rows[e.RowIndex].Cells["ColumnPayTypeTitle"].Style.ForeColor = Color.DeepPink;
                        break;


                }
        }

       
    }
}



