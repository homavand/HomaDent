using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry
{
    public partial class ReportViewer11 : Form
    {
        string reportName;
        ReportForm fr_report;
        List<object> param;
        List<object> value;


        public ReportViewer11(string reportName)
        {
            InitializeComponent();

            PersianCalendar persianCalendar = new PersianCalendar();
            MinDate.Value = (Dentistry.UserControls.PersianDate)persianCalendar.ToDateTime(persianCalendar.GetYear((DateTime)DateTime.Now), persianCalendar.GetMonth((DateTime)DateTime.Now), 1, 0, 0, 0, 0);
            MaxDate.Value = (Dentistry.UserControls.PersianDate)DateTime.Now;
            this.reportName = reportName;
            fr_report = new ReportForm();
            this.ReportPnl.Controls.Add(fr_report.panel_Report);
        }

       

        private void GetOfficeResultant()
        {
            dynamic sObj = new
            {
                FromDate = Class.Date.ToChristianByTime(this.MinDate.Value.ToString()),
                ToDate = Class.Date.ToChristianByTime(this.MaxDate.Value.ToString())
            };
            JsonResponse<dynamic> result = Dentistry.DataProvider.GetOfficeReportX(sObj);
            if (result.Success == false || result.Data == null)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }

            param.Add("ReportTitle");
            value.Add("گزارش کلی مطب");

            fr_report.RunReport("rpt_OfficeX", param, value, result.Data);
        }


        #region PatientsPays
        private void GetPatientPays()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();

            sObj.FromDate = Class.Date.ToChristianByTime(this.MinDate.Value.ToString());
            sObj.ToDate = Class.Date.ToChristianByTime(this.MaxDate.Value.ToString());

            param.Add("ReportTitle");
            value.Add("");

            JsonResponse<dynamic> result = Dentistry.DataProvider.GetPaymentFinancialInfoX(sObj);
            if (result.Success == false || result.Data == null)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }

            fr_report.RunReport("rpt_PatientsPays", param, value, result.Data);

        }
        #endregion



        #region PatientsServicesReport
        private void GetPatientServices()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();

            sObj.FromDate = Class.Date.ToChristianByTime(this.MinDate.Value.ToString());
            sObj.ToDate = Class.Date.ToChristianByTime(this.MaxDate.Value.ToString());

            param.Add("ReportTitle");
            value.Add("");

            JsonResponse<dynamic> result = Dentistry.DataProvider.GetServiceFinancialInfoX(sObj);
            if (result.Success == false || result.Data == null)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }

            fr_report.RunReport("rpt_PatientsServices", param, value, result.Data);


        }
        #endregion

        #region InsurerFinancial
        private void GetInsurerFinancials()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();

            sObj.FromDate = Class.Date.ToChristianByTime(this.MinDate.Value.ToString());
            sObj.ToDate = Class.Date.ToChristianByTime(this.MaxDate.Value.ToString());

            param.Add("ReportTitle");
            value.Add("");

            JsonResponse<dynamic> result = Dentistry.DataProvider.GetInsuranceFinancialInfoX(sObj);
            if (result.Success == false || result.Data == null)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }

            fr_report.RunReport("rpt_InsurancesFinancialX", param, value, result.Data);

        }
        #endregion

        #region buttonReport_Click
        private void buttonReport_Click(object sender, EventArgs e)
        {
            param = new List<object>();
            value = new List<object>();

            param.Add("FromDate");
            value.Add(this.MinDate.Value.ToString());
            param.Add("ToDate");
            value.Add(this.MaxDate.Value.ToString());



            switch (this.reportName)
            {
                case "OfficeResultantReport":
                    this.GetOfficeResultant();
                    break;            
                case "PatientPaysReport":
                    this.GetPatientPays();
                    break;
           
                case "PatientsServicesReport":
                    this.GetPatientServices();
                    break;
                case "InsurerFinancialsReport":
                    this.GetInsurerFinancials();
                    break;
            }
        }
        #endregion

     
    }
}
