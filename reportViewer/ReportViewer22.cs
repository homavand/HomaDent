using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace Dentistry
{
    public partial class ReportViewer22 : Form
    {
        string reportName;
        ReportForm fr_report;
        List<object> param;
        List<object> value;
        public ReportViewer22(string reportName)
        {
            InitializeComponent();

            this.LoadFormInit();
            this.reportName = reportName;
            switch (this.reportName)
            {

                case "CostFinancialsReport":
                    this.CostTypePnl.Visible = true;
                    this.AccountPartyPnl.Visible = false;                 
                    break;

                case "AccountPartyCompanyFinancialsReport":
                    this.CostTypePnl.Visible = false;
                    this.AccountPartyPnl.Visible = true;
                    break;
                default:
                    this.CostTypePnl.Visible = false;
                    this.AccountPartyPnl.Visible = false;
                    break;

            }

            fr_report = new ReportForm();
            this.ReportPnl.Controls.Add(fr_report.panel_Report);
        }

        #region LoadFormInit
        private void LoadFormInit()
        {

            dynamic sObj = new
            {
                IsCostType = true,
                //IsPayType = true,
                IsBargainSide = true,              
            };
            var data = Dentistry.DataProvider.LoadFormInitInfo(sObj);
            var dd = data != null && data.Data != null ? data.Data : null;

            if (dd == null)
                return;

            IEnumerable<dynamic> listCostType = dd.CostType != null && (Enumerable.Count(dd.CostType) > 0) ? (dd.CostType as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).Where(i => i.Id != 1).ToList() : null;
            //IEnumerable<dynamic> listPayType = dd.PayType != null && (Enumerable.Count(dd.PayType) > 0) ? (dd.PayType as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList() : null;
            IEnumerable<dynamic> listBargainSide = dd.BargainSide != null && (Enumerable.Count(dd.BargainSide) > 0) ? (dd.BargainSide as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).ToList() : null;

            this.CostTypeCbo.DataSource = listCostType;
            this.CostTypeCbo.ValueMember = "Id";
            this.CostTypeCbo.DisplayMember = "Title";

            this.AccountPartyCompanyCbo.DataSource = listBargainSide;
            this.AccountPartyCompanyCbo.ValueMember = "Id";
            this.AccountPartyCompanyCbo.DisplayMember = "Title";



        }
        #endregion

        #region CostFinancial
        private dynamic GetCostFinancials()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();

            sObj.FromDate = Class.Date.ToChristianByTime(this.MinDate.Value.ToString());
            sObj.ToDate = Class.Date.ToChristianByTime(this.MaxDate.Value.ToString());

            if(this.CostTypeCbo.SelectedIndex > 0)
                sObj.CostTypeId = Convert.ToInt32(this.CostTypeCbo.SelectedValue);

            JsonResponse<dynamic> result = Dentistry.DataProvider.GetCostFinancialInfoX(sObj);
            if (result.Success == false || result.Data == null)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return null;
            }
            var dd = result.Data != null ? result.Data : null;
            return dd;
            
        }
        #endregion

        #region GetAccountPartyCompanyFinancialTransaction
        private dynamic GetAccountPartyCompanyFinancialTransactions()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();

           
            sObj.FromDate = Class.Date.ToChristianByTime(this.MinDate.Value.ToString());
            sObj.ToDate = Class.Date.ToChristianByTime(this.MaxDate.Value.ToString());

            if (this.AccountPartyCompanyCbo.SelectedIndex > 0)
                sObj.BargainSideId = Convert.ToInt32(this.AccountPartyCompanyCbo.SelectedValue);

            JsonResponse<dynamic> result = Dentistry.DataProvider.GetAccountPartyCompanyFinancialTransactionX(sObj);
            if (result.Success == false || result.Data == null)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return null;
            }
           
            var dd = result.Data != null ? result.Data : null;
            
            return dd;
        }
        #endregion

        #region buttonReport_Click
        private void buttonReport_Click(object sender, EventArgs e)
        {
            bool isOk = true;
            param = new List<object>();
            value = new List<object>();

            param.Add("FromDate");
            value.Add(this.MinDate.Value.ToString());
            param.Add("ToDate");
            value.Add(this.MaxDate.Value.ToString());

            string reportTitle = "";
            dynamic data = null;

            switch (this.reportName)
            {

                case "CostFinancialsReport":              

                    reportTitle = "";
                    param.Add("ReportTitle");
                    value.Add("گزارش هزینه ها - " + reportTitle);

                    data = this.GetCostFinancials();
                    fr_report.RunReport("rpt_CostsFinancialX", param, value, data);

                    break;

                case "AccountPartyCompanyFinancialsReport":
              
                    reportTitle = "گزارش مالی طرف های حساب";
                   
                    param.Add("ReportTitle");
                    value.Add("گزارش هزینه ها - " + reportTitle);

                    data = this.GetAccountPartyCompanyFinancialTransactions();
                    fr_report.RunReport("rpt_AccountPartyCompanyFinancial", param, value, data);

                    break;
             
                default:
                    isOk = false;
                    break;

            }

           
            

           
        }
        #endregion
    }
}
