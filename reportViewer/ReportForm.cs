using Stimulsoft.Report;
using Stimulsoft.Report.Render;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Dentistry
{
    public partial class ReportForm : Form
    {
        StiReport myReport = new StiReport();
        public ReportForm()
        {
            InitializeComponent();
            
            
            //StiOptions.Preview.Window.ShowParametersButton = false;

        }

        public void RunReport(string ReportName, List<object> Parameters, List<object> Values , dynamic obj)
        {
            var _assembly = Assembly.GetExecutingAssembly();
            var ss = Application.ProductName;
            var r = _assembly.GetManifestResourceStream(Application.ProductName + ".reports." + ReportName + ".mrt");            
            myReport.Load(r);

            myReport.Dictionary.Variables["TodayDate"].ValueObject = Publics.GetSolarDateTime(DateTime.Now);
            myReport.Dictionary.Variables["DoctorName"].ValueObject = Dentistry.AppConfigs.DoctorName;
            myReport.Dictionary.Variables["NezamPezeshki"].ValueObject = Dentistry.AppConfigs.NezamPezeshki;
            myReport.Dictionary.Variables["PhoneNumber"].ValueObject = Dentistry.AppConfigs.PhoneNumber;
            myReport.Dictionary.Variables["OfficeAddress"].ValueObject = Dentistry.AppConfigs.OfficeAddress;           

            for (int i = 0; i < Parameters.Count; i++)
            {
                myReport.Dictionary.Variables[Parameters[i].ToString()].ValueObject = Values[i];
                myReport.Dictionary.Variables[Parameters[i].ToString()].RequestFromUser = false;
            }
           
         
            myReport.RegData("Data", obj);

            myReport.Dictionary.Synchronize();
            myReport.Compile();
            myReport.Render();

            stiViewerControl1.Report = myReport;

            stiViewerControl1.SetParametersButtonChecked(false);

        }

        public void RunReport(string ReportName, List<object> Parameters, List<object> Values)
        {
            var _assembly = Assembly.GetExecutingAssembly();
            var r = _assembly.GetManifestResourceStream(Application.ProductName + ".Reports." + ReportName + ".mrt");
            myReport.Load(r);
            myReport.Dictionary.Databases.Clear();
            myReport.Dictionary.Databases.Add(new Stimulsoft.Report.Dictionary.StiSqlDatabase("Connection", Dentistry.AppConfigs.ConnectionString));
            for (int i = 0; i < Parameters.Count; i++)
            {
                myReport.Dictionary.Variables[Parameters[i].ToString()].ValueObject = Values[i];
                myReport.Dictionary.Variables[Parameters[i].ToString()].RequestFromUser = false;
            }
           
            myReport.Compile();
            myReport.Render();
            stiViewerControl1.Report = myReport;
        }
      
        public void RunReport(string ReportName, string Query, List<object> Parameters, List<object> Values)
        {
            var _assembly = Assembly.GetExecutingAssembly();
            var r = _assembly.GetManifestResourceStream(Application.ProductName + ".Reports." + ReportName + ".mrt");
            myReport.Load(r);
           
            myReport.Dictionary.Databases.Clear();
            myReport.Dictionary.Databases.Add(new Stimulsoft.Report.Dictionary.StiSqlDatabase("Connection", Dentistry.AppConfigs.ConnectionString));
            Stimulsoft.Report.Dictionary.StiSqlSource sqlSource = (myReport.Dictionary.DataSources[0] as Stimulsoft.Report.Dictionary.StiSqlSource);
            sqlSource.SqlCommand = Query;
            myReport.Dictionary.Synchronize();

            for (int i = 0; i < Parameters.Count; i++)
            {
                myReport.Dictionary.Variables[Parameters[i].ToString()].ValueObject = Values[i];
                myReport.Dictionary.Variables[Parameters[i].ToString()].RequestFromUser = false;
            }

            //myReport.DataSources[""] = null;
            myReport.Compile();
            myReport.Render();
            stiViewerControl1.Report = myReport;
        }
      
    }
}
