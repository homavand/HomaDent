using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Globalization;

namespace Dentistry
{
    public partial class ReportList : Form
    {
        public ReportList()
        {
            InitializeComponent();

            List<dynamic> data = new List<dynamic>();
                data.Add(new { Id = 1 , Title= "گزارش دریافتی مطب از بیماران" });               
                data.Add(new { Id = 3, Title = "لیست سرویس های انجام شده" });
                data.Add(new { Id = 4, Title = "گزارش وضعیت بیمه ها" });
                data.Add(new { Id = 2, Title = "گزارش هزینه ها" });
                data.Add(new { Id = 5, Title = "گزارش وضعیت شرکتهای طرف حساب" });
                data.Add(new { Id = 6, Title = "گزارش چک های دریافتی از بیماران" });             
                data.Add(new { Id = 7, Title = "گزارش چک های پرداختی برای هزینه ها" });
                //data.Add(new { Id = 9, Title = "گزارش وضعیت چک های واریزی" });
                data.Add(new { Id = 10, Title = "گزارش لیست بیماران طلبکار" });
                data.Add(new { Id = 11, Title = "گزارش لیست بیماران بدهکار" });
                data.Add(new { Id = 12, Title = "گزارش کلی مطب" });
         

            this.dgReports.DataSource = data;

            
            PersianCalendar persianCalendar = new PersianCalendar();
          
            //MinDate1.Value = (Dentistry.UserControls.PersianDate)persianCalendar.ToDateTime(persianCalendar.GetYear((DateTime)DateTime.Now), persianCalendar.GetMonth((DateTime)DateTime.Now), 1, 0, 0, 0, 0);
            //MaxDate1.Value = (Dentistry.UserControls.PersianDate)DateTime.Now;

           
        }


        private void SelectReport(string id)
        {
            this.panelM.Controls.Clear();

            switch (id)
            {
                case "1":
                    ReportViewer11 reportViewer11 = new ReportViewer11("PatientPaysReport");
                    this.panelM.Controls.Add(reportViewer11.panel1);

                    break;
                case "2":
                    ReportViewer22 ReportViewer012 = new ReportViewer22("CostFinancialsReport");
                    this.panelM.Controls.Add(ReportViewer012.panel1);
                    break;
                case "3":
                    ReportViewer11 reportViewer013 = new ReportViewer11("PatientsServicesReport");
                    this.panelM.Controls.Add(reportViewer013.panel1);
                    break;
                case "4":
                    ReportViewer11 ReportViewer014 = new ReportViewer11("InsurerFinancialsReport");
                    this.panelM.Controls.Add(ReportViewer014.panel1);
                    break;
                case "5":
                    ReportViewer22 ReportViewer02 = new ReportViewer22("AccountPartyCompanyFinancialsReport");
                    this.panelM.Controls.Add(ReportViewer02.panel1);
                    break;
                case "6":
                    ReportViewer44 ReportViewer041 = new ReportViewer44("PatientChequesReport");
                    this.panelM.Controls.Add(ReportViewer041.panel1);
                    break;
                case "7":
                    ReportViewer44 ReportViewer042 = new ReportViewer44("CostChequesReport");
                    this.panelM.Controls.Add(ReportViewer042.panel1);
                    break;
             
                case "10":
                    ReportViewer33 ReportViewer031 = new ReportViewer33("CreditorPatientsReport");
                    this.panelM.Controls.Add(ReportViewer031.panel1);
                    break;
                case "11":
                    ReportViewer33 ReportViewer032 = new ReportViewer33("DebtorPatientsReport");
                    this.panelM.Controls.Add(ReportViewer032.panel1);
                    break;
                case "12":
                    ReportViewer11 ReportViewer04 = new ReportViewer11("OfficeResultantReport");
                    this.panelM.Controls.Add(ReportViewer04.panel1);
                    break;


            }
        }        

        //private void treeView1_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if(e.KeyCode == Keys.Enter)
        //    if (sender is TreeView)
        //        if(treeView1.SelectedNode != null)
        //            treeView1_NodeMouseDoubleClick(this , null);
        //}

        private void ReportList_Load(object sender, EventArgs e)
        {
       
         //treeView1.SelectedNode=treeView1.Nodes[0].Nodes[0];
         //SelectNode(treeView1.SelectedNode.Name);

        }

        private void dgReports_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            var reportId = Convert.ToInt32(this.dgReports["ColId", e.RowIndex].Value);
            var reportTitle = Convert.ToString(this.dgReports["ColTitle", e.RowIndex].Value);
            this.ReportTitleLbl.Text = reportTitle;
            SelectReport(reportId.ToString());
        }
    }
}
