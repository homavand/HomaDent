using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Data.SqlClient;
using System.Linq;

namespace Dentistry
{
    public partial class ReportViewer44 : Form
    {
        string reportName;
        frm_Report fr_report;
        List<object> param;
        List<object> value;
    
        public ReportViewer44(string reportName)
        {
            InitializeComponent();

            PersianCalendar persianCalendar = new PersianCalendar();
            MinDate.Value = (Dentistry.UserControls.PersianDate)persianCalendar.ToDateTime(persianCalendar.GetYear((DateTime)DateTime.Now), persianCalendar.GetMonth((DateTime)DateTime.Now), 1, 0, 0, 0, 0);
            MaxDate.Value = (Dentistry.UserControls.PersianDate)DateTime.Now;
            this.reportName = reportName;
            fr_report = new frm_Report();
            this.ReportPnl.Controls.Add(fr_report.panel_Report);
        }

        private IEnumerable<dynamic> GetPatientsCheques()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.PayTypeId = 3;
            sObj.FromDate = Class.Date.ToChristianByTime(this.MinDate.Value.ToString());
            sObj.ToDate = Class.Date.ToChristianByTime(this.MaxDate.Value.ToString());

            if (this.DateOfIssuanceChk.Checked == true)
                sObj.IsDateOfIssuance = true;
            else
                sObj.IsDateOfMaturity = true;
                      

            JsonResponse<dynamic> result = Dentistry.DataProvider.GetPatientFinancialsX(sObj);

            if (result != null && (result.Success == false || result.Data == null))
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return null;
            }
            

            var dd = result.Data != null ? result.Data  : null;

            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) >= 0) ? (dd as IEnumerable<dynamic>).Where(i => i.IsDeleted != true )
                    .Select(i =>
                        new
                        {
                            ChequeNumber = (string)i.ChequeNumber,
                            SolarDateOfIssuance = (string)i.SolarDateOfIssuance,
                            SolarDateOfMaturity = (string)i.SolarDateOfMaturity,
                            BankId = (int?)i.BankId,
                            BankTitle = (string)i.BankTitle,
                            ChequeAmount = (double)i.Amount,
                            Comment = (string)i.Comment,
                            ChequeTypeId = (int?)i.ChequeTypeId,
                            ChequeTypeTitle = (string)i.ChequeTypeTitle,
                            ChequeStatusId = (int?)i.ChequeStatusId,
                            ChequeStatusTitle = (string)i.ChequeStatusTitle,

                            PatientId = (int?)i.PatientId,
                            PatientName = (string)i.PatientName,
                        }).ToList() : Enumerable.Empty<dynamic>();

            return list;
        }

        private IEnumerable<dynamic> GetCostsCheques()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.PayTypeId = 3;
            sObj.FromDate = Class.Date.ToChristianByTime(this.MinDate.Value.ToString());
            sObj.ToDate = Class.Date.ToChristianByTime(this.MaxDate.Value.ToString());

            if (this.DateOfIssuanceChk.Checked == true)
                sObj.IsDateOfIssuance = true;
            else
                sObj.IsDateOfMaturity = true;


            JsonResponse<dynamic> result = Dentistry.DataProvider.GetCostFinancialsX(sObj);

            if (result != null && (result.Success == false || result.Data == null))
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return null;
            }

            var dd = result.Data != null ? result.Data : null;

            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) >= 0) ? (dd as IEnumerable<dynamic>).Where(i => i.IsDeleted != true )
                    .Select(i =>
                        new
                        {
                            ChequeNumber = (string)i.ChequeNumber,
                            SolarDateOfIssuance = (string)i.SolarDateOfIssuance,
                            SolarDateOfMaturity = (string)i.SolarDateOfMaturity,
                            BankId = (int?)i.BankId,
                            BankTitle = (string)i.BankTitle,
                            ChequeAmount = (double)i.Amount,
                            Comment = (string)i.Comment,
                            ChequeTypeId = (int?)i.ChequeTypeId,
                            ChequeTypeTitle = (string)i.ChequeTypeTitle,
                            ChequeStatusId = (int?)i.ChequeStatusId,
                            ChequeStatusTitle = (string)i.ChequeStatusTitle,

                            CostId = (int?)i.CostId,
                            CostTitle = (string)i.CostTitle,
                        }).ToList() : Enumerable.Empty<dynamic>();

            return list;
        }


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

            string reportName = "";
            string reportTitle = "";
            dynamic data = null;

            switch (this.reportName)
            {
             
                case "PatientChequesReport":

                    reportTitle = this.DateOfIssuanceChk.Checked == true ? "بر اساس تاریخ صدور" : "بر اساس تاریخ سررسید";
                    param.Add("ReportTitle");
                    value.Add("لیست چک های دریافتی از بیماران - " + reportTitle);

                    data = this.GetPatientsCheques();
                    reportName = "rpt_PatientsCheques";
                    break;
                case "CostChequesReport":

                    reportTitle = this.DateOfIssuanceChk.Checked == true ? "بر اساس تاریخ صدور" : "بر اساس تاریخ سررسید";
                    param.Add("ReportTitle");
                    value.Add("وضعیت چکهای کشیده شده - " + reportTitle);

                    data = this.GetCostsCheques();
                    reportName = "rpt_CostsChequesX";

                    break;

             
                default:
                    isOk = false;
                    break;

            }

            if (!isOk)
                return;

            if (data == null || reportName == "")
                return;

            fr_report.RunReport(reportName, param, value, data);
        }
        #endregion

    }
}
