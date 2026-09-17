using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiMessageBox;
using System.Linq;
using System.Dynamic;

namespace Dentistry
{
    public partial class PatientsBlackList : Form
    {

        public PatientsBlackList()
        {
            InitializeComponent();

            this.FillDataGridView();
        }

        #region FillDataGridView
        private void FillDataGridView()
        {
            try
            {

                dynamic sObj = new
                {                   
                    IsDeleted = true
                };

                                    
                var result = Dentistry.DataProvider.GetPatientsInfoX(sObj);

                var dd = (result != null && result.Success != false && (Enumerable.Count(result.Data) > 0)) ? result.Data : null;
                IEnumerable<dynamic> list = dd != null ? (dd as IEnumerable<dynamic>)
                                                                .Select(i =>
                                                                new
                                                                {
                                                                    PatientId = (int)i.PatientId,                                                                                                                                                                                                    
                                                                    PatientName = Convert.ToString(i.FirstName) + " " + Convert.ToString(i.LastName),                                                                   
                                                                    NationalCode = (string)i.NationalCode,                                                                                                                    
                                                                    Presenter = (string)i.Presenter,                                                                   
                                                                    MobilePhone = (string)i.MobilePhone,                                                                                                                                
                                                                    Comment = (string)i.Comment,                                                                   
                                                                  
                                                                    DoctorTitle = (string)i.DoctorTitle,                                                                    

                                                                    Total_Patient_Charge = (double?)i.Total_Patient_Charge,
                                                                    Total_Patient_Paid = (double?)i.Total_Patient_Paid,
                                                                    Total_Patient_Discount = (double?)i.Total_Patient_Discount,
                                                                    Total_Patient_Remianed = (double?)i.Total_Patient_Remianed,
                                                                  
                                                                }).ToList() : Enumerable.Empty<dynamic>();


                this.dgPatients.DataSource = list;

            }
            catch (System.Exception exp)
            {
                 ErrorClass.WriteErrorsToFile(this.Name, exp.TargetSite.Name.ToString(), exp.Message, DateTime.Now);
                this.Close();
            }
        }
        #endregion

        #region ButtonRemoveFromBlackListAndAddToIllList_Click
        private void ButtonRemoveFromBlackListAndAddToIllList_Click(object sender, EventArgs e)
        {
            if (this.dgPatients.CurrentCell == null)
                return;

            try
            {

                if (FMessageBox.Show(Dentistry.AppConfigs.strRemoveFromBlackListAndAddToIllsList, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    dynamic iObj = new ExpandoObject();
                    iObj.PatientId = Convert.ToInt32(this.dgPatients["ColumnPatientId", this.dgPatients.CurrentRow.Index].Value); 
                    iObj.ActionType = "Edit";
                    iObj.Comment = "";
                    iObj.IsDeleted = false;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientX(iObj);
                    if (result != null && result.Success == true && result.Data != null)
                    {
                        this.FillDataGridView();

                        this.DialogResult = DialogResult.OK;
                    }

             
                }
            }
            catch (Exception exp)
            {
                 ErrorClass.WriteErrorsToFile(this.Name, exp.TargetSite.Name.ToString(), exp.Message, DateTime.Now);
            }
        }
        #endregion

        #region ButtonDelete_Click
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (this.dgPatients.CurrentCell == null)
                return;

            try
            {

                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    dynamic sObj = new System.Dynamic.ExpandoObject();
                    sObj.PatientId = Convert.ToInt32(this.dgPatients["ColumnPatientId", this.dgPatients.CurrentRow.Index].Value);

                    var data = Dentistry.DataProvider.RemovePatientFromDatabaseX(sObj);
                    var dd = (data != null && data.Data != null) ? data.Data : null;
                    bool Flag = Convert.ToBoolean(dd);                    
                   
                    System.IO.File.Delete(Application.StartupPath + "\\Images\\" + this.dgPatients["ColumnPatientId", this.dgPatients.CurrentRow.Index].Value.ToString() + ".jpg");
                    
                    if (Flag)
                    {
                        this.FillDataGridView();
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception exp)
            {
                 ErrorClass.WriteErrorsToFile(this.Name, exp.TargetSite.Name.ToString(), exp.Message, DateTime.Now);
            }
        }
        #endregion

       
    }
}
