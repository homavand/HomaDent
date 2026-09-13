using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections;
using FarsiMessageBox;
using System.Linq;
using System.Dynamic;

namespace Dentistry
{
    public partial class SpecialDiseaseList : Form
    {
        int PatientId;
        

        #region FormSelectIllness
        public SpecialDiseaseList(int PatientId)
        {
        InitializeComponent();

            
            this.PatientId = PatientId;

            this.FillDataGrideView();

        }
        #endregion

        #region FormSelectIllness_Activated
        private void FormSelectIllness_Activated(object sender, EventArgs e)
        {
            this.dataGridViewSelectIllness.CurrentCell = null;
            
        }
        #endregion

        public DataTable getListDataTable(IEnumerable<dynamic> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("IsCheck", typeof(bool));


            foreach (var item in list)
                dt.Rows.Add(
                    item.Id,
                    item.Title,
                    item.IsCheck
                    );

            return dt;
        }

        #region FillDataGrideView
        public void FillDataGrideView()
        {
            try
            {
                dynamic sObj = new
                {
                    PatientId = this.PatientId,
                };
                var result = Dentistry.DataProvider.GetPatientSpecialDiseases(sObj);
                var dd = result != null && result.Data != null ? result.Data : null;


                IEnumerable<dynamic> list = (dd != null && Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>)
                                                                                 .Select(i =>
                                                                                 new 
                                                                                 {
                                                                                     Id = (int)i.Id,
                                                                                     Title = (string)i.Title,
                                                                                     IsCheck = (bool)i.IsCheck
                                                                                 }).ToList() : Enumerable.Empty<dynamic>();

                DataTable dt = getListDataTable(list);
                this.dataGridViewSelectIllness.DataSource = dt;

           

            }
            catch (System.Exception exp)
            {
            this.Close();
            }
        }
        #endregion
   
        #region dataGridViewSelectIllness_CellContentClick
        private void dataGridViewSelectIllness_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }
        #endregion

        private void dataGridViewSelectIllness_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           
            if (e.RowIndex >= 0 && ((DataGridView)sender).Columns[e.ColumnIndex].Name.Equals("ColumnIsCheck"))                
            {
                this.dataGridViewSelectIllness["ColumnIsCheck", e.RowIndex].ReadOnly = false;
                this.dataGridViewSelectIllness["ColumnIsCheck", e.RowIndex].Value = !Convert.ToBoolean(this.dataGridViewSelectIllness["ColumnIsCheck", e.RowIndex].Value);
                 
                bool flag = Convert.ToBoolean(this.dataGridViewSelectIllness.Rows[e.RowIndex].Cells["ColumnIsCheck"].Value);

                JsonResponse<dynamic> result = null;
                if (flag)
                {
                    dynamic iiObj = new ExpandoObject();
                    iiObj.ActionType = "New";
                    iiObj.PatientId = this.PatientId;
                    iiObj.SpecialDiseasId = Convert.ToInt32(this.dataGridViewSelectIllness["ColumnSpecialDiseaseId", e.RowIndex].Value);


                    result = Dentistry.DataProvider.DefinePatientSpecialDiseasesX(iiObj);
                                       
                }
                else
                {
                    dynamic iiObj = new ExpandoObject();
                    iiObj.ActionType = "Delete";
                    iiObj.PatientId = this.PatientId;
                    iiObj.SpecialDiseasId = Convert.ToInt32(this.dataGridViewSelectIllness["ColumnSpecialDiseaseId", e.RowIndex].Value);


                    result = Dentistry.DataProvider.DefinePatientSpecialDiseasesX(iiObj);
                   
                }

                //if (result != null && result.Success == true && result.Data != null)
                //    FMessageBox.Show("اطلاعات با موفقیت ثبت شدند", "پیام", FMessageBoxButtons.OK, FMessageBoxIcons.Information, FMessageBoxDefaultButtons.Button1);
            }            
        }





    }
}
