using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Linq;

namespace Dentistry
{
    public partial class ReportViewer33 : Form
    {
        string reportName;
        ReportForm fr_report;
        List<object> param;
        List<object> value;
        string query;

        public ReportViewer33(string reportName)
        {
            InitializeComponent();

            this.reportName = reportName;

            fr_report = new ReportForm();
            this.ReportPnl.Controls.Add(fr_report.panel_Report);
        }

        #region GetDebtorPatients
        private IEnumerable<dynamic> GetDebtorPatients()
        {
            if ((this.radioButton_WithBlackList.Checked == false) && (this.radioButton_WithoutBlackList.Checked == false))
                return null;
                               
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.IsDebtor = true;
         
            if (this.radioButton_WithoutBlackList.Checked)
                sObj.IsDeleted = false;

          
            JsonResponse<dynamic> result = Dentistry.DataProvider.GetPatientsInfoX(sObj);
            if (result.Success == false || result.Data == null)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return null;
            }

            var dd = result.Data != null ? result.Data : null;
            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) >= 0) ? (dd as IEnumerable<dynamic>).ToList() : Enumerable.Empty<dynamic>();

            return list;


            
        }
        #endregion

        #region GetCreditorPatients
        private IEnumerable<dynamic> GetCreditorPatients()
        {
            if ((this.radioButton_WithBlackList.Checked == false) && (this.radioButton_WithoutBlackList.Checked == false))
                return null;                          

            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.IsCreditor = true;

            if (this.radioButton_WithoutBlackList.Checked)
                sObj.IsDeleted = false;

         
            JsonResponse<dynamic> result = Dentistry.DataProvider.GetPatientsInfoX(sObj);
            if (result.Success == false || result.Data == null)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return null;
            }

            var dd = result.Data != null ? result.Data : null;
            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) >= 0) ? (dd as IEnumerable<dynamic>).ToList() : Enumerable.Empty<dynamic>();

            return list;

           
        
        }
        #endregion

      

        #region buttonReport_Click
        private void buttonReport_Click(object sender, EventArgs e)
        {
            List<object> param = new List<object>();
            List<object> value = new List<object>();



            string reportTitle = "";
            dynamic data = null;

            switch (this.reportName)
            {
                case "DebtorPatientsReport":
                    param.Add("ReportTitle");
                    value.Add("لیست بیماران بدهکار");
                    param.Add("Mablag");                   
                    value.Add("مبلغ بدهی");

                    data = this.GetDebtorPatients() ; 
                    break;
                case "CreditorPatientsReport":
                    param.Add("ReportTitle");
                    value.Add("لیست بیماران طلبکار");
                    param.Add("Mablag");               
                    value.Add("مبلغ طلب");

                    data = this.GetCreditorPatients() ; 
                    break;
            }

            if (data == null)
                return;

            fr_report.RunReport("rpt_Creditor_Debtor", param, value, data);
        }
        #endregion

     
    }
}
