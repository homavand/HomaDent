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

namespace Dentistry
{
    public partial class ChequeFinancialDefine : Form
    {

        string EditOrNewFlag = "";
        int? PatientFinancialId = null;
        int? CostId = null;

        #region FormChequeControl_NewEdit
        public ChequeFinancialDefine()
        {
            InitializeComponent();
        

          

            this.EditOrNewFlag = "New";
        }
        #endregion

        #region FormChequeControl_NewEdit_OverLoaded
        public ChequeFinancialDefine(int patientFinancialId=-1, int costId=-1)
        {
            InitializeComponent();

            try
            {

                if (patientFinancialId != -1)
                {
                    this.PatientFinancialId = patientFinancialId;
                    FetchChequeInfo(patientFinancialId,  true, false);
                }

                if (costId != -1)
                {
                    this.CostId = costId;
                    FetchChequeInfo(costId, false, true);
                }

                this.EditOrNewFlag = "Edit";
               
                           
            }
            catch (System.Exception exp)
            {
                 ErrorClass.WriteErrorsToFile(this.Name, exp.TargetSite.Name.ToString(), exp.Message, DateTime.Now);
                this.Close();
            }
        }
        #endregion

        #region LoadFormInit
        private void LoadFormInit()
        {
            

        }
        #endregion

        #region FetchCostInfo
        private void FetchChequeInfo(int id, bool isForPatient = false, bool isForCost = false)
        {
            try
            {

                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.Id = id;

                dynamic data = null;

                if (isForPatient)
                    data = Dentistry.DataProvider.GetPatientFinancialsX(sObj);
                if (isForCost)
                    data = Dentistry.DataProvider.GetCostFinancialsX(sObj);

                var dd = (data != null && data.Data != null) ? data.Data : null;

                IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>)
                        .Select(i =>
                              new
                              {
                                  Id = (int)i.Id ,                                  
                                  Type = isForPatient ? "patient" : isForCost ? "cost" : "",
                                  Title = isForPatient ? (string)i.PatientName : isForCost ? (string)i.CostTitle : "",

                                  i.Amount,
                                  i.ChequeNumber,
                                  i.SolarDateOfIssuance,
                                  i.SolarDateOfMaturity,
                                  i.BankId,
                                  i.BankTitle,
                                  i.ChequeTypeId,
                                  i.ChequeTypeTitle,
                                  i.ChequeStatusId,
                                  i.ChequeStatusTitle,                                                                    
                                  i.Comment,
                                  i.IsDeleted,
                              }
                        ).ToList()
                        : Enumerable.Empty<dynamic>();
                
                
                var obj = list.Count()>0 ? list.FirstOrDefault() : null;

                if (obj != null)
                {


                    int chequeTypeId = Publics.GetPropertyValue<int>(obj, "ChequeTypeId");
                    foreach (var pnl in this.chequeTypePnl.Controls.OfType<Dentistry.UserControls.ExPanel>().ToList())
                    {
                        if(chequeTypeId == 1)
                        {
                            PayOutPnl.Visible = false;
                            PayInPnl.Visible = true;
                        }
                        if (chequeTypeId == 2)
                        {
                            PayOutPnl.Visible = true;
                            PayInPnl.Visible = false;
                        }
                      
                    }

                    int chequeStatusId = Publics.GetPropertyValue<int>(obj, "ChequeStatusId");
                    foreach (var pnl in this.chequeStatusPnl.Controls.OfType<Dentistry.UserControls.ExPanel>().ToList())
                    {
                        var rdoX = pnl.Controls.OfType<RadioButton>().ToList().Where(i => Convert.ToInt32(i.Tag) == chequeStatusId).Select(i => i).SingleOrDefault();

                        if (rdoX != null)
                        {
                            rdoX.Checked = true;
                            break;
                        }

                    }

                    this.amountTxt.Text = Publics.GetPropertyValue<string>(obj, "Amount");
                    this.ChequeNumberTxt.Text = Publics.GetPropertyValue<string>(obj, "ChequeNumber"); 
                    this.BankTxt.Text = Publics.GetPropertyValue<string>(obj, "BankTitle");                    
                    this.DateOfIssuanceTxt.Text = Publics.GetPropertyValue<string>(obj, "SolarDateOfIssuance");
                    this.DateOfMaturityTxt.Text = Publics.GetPropertyValue<string>(obj, "SolarDateOfMaturity");
                    this.CommentTxt.Text = Publics.GetPropertyValue<string>(obj, "Comment");

                  
                    


                }

            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }

        }
        #endregion





        #region buttonOk_Click
        private void buttonOk_Click(object sender, EventArgs e)
        {
        
            try
            {
     
            
               
                int chequeStatusId = 0;

                foreach (var pnl in this.chequeStatusPnl.Controls.OfType<UserControls.ExPanel>().ToList())
                {
                    var rdoX = pnl.Controls.OfType<RadioButton>().ToList().Where(i => Convert.ToBoolean(i.Checked) == true).Select(i => i).SingleOrDefault();

                    if (rdoX != null)
                    {
                        chequeStatusId = Convert.ToInt32(rdoX.Tag);
                        break;
                    }

                }

                JsonResponse<dynamic> result = null;

                dynamic iObj = new ExpandoObject();
                iObj.ActionType = "EditChequeStatus";                
                iObj.ChequeStatusId = chequeStatusId; 
              
                     
                if(this.PatientFinancialId != null)
                {
                    iObj.Id = this.PatientFinancialId.Value;
                    result = Dentistry.DataProvider.DefinePatientFinancialX(iObj);
                }
                if (this.CostId != null)
                {
                    iObj.Id = this.CostId.Value;
                    result = Dentistry.DataProvider.DefineCostX(iObj);
                }
        

                if (result.Success == true)
                {                    
                    this.DialogResult = DialogResult.OK;
                }


                this.Close();

            }
            catch (System.Exception exp)
            {
                ErrorClass.WriteErrorsToFile(this.Name, exp.TargetSite.Name.ToString(), exp.Message, DateTime.Now);
                this.Close();
            }
        }
        #endregion

     

        private void ChequeStatusRdo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdoX = sender as RadioButton;
            if (rdoX == null || rdoX.Checked != true)
                return;

            var pnlList = this.chequeStatusPnl.Controls.OfType<UserControls.ExPanel>().ToList();

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
               
                    break;
                case 1:
                  
                    break;
             
                default:
                  
                    break;
            }
        }

        private void ChequeControlDefine_Paint(object sender, PaintEventArgs e)
        {
          
        }
    }
}
