using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dentistry
{
    public partial class PatientSpecialCommentDefine : Form
    {
        
        public int SpecialCommentId = 0;
        public int SpecialCommentTypeId = -1;
        string EditOrNewFlag;

        int patientId = 0;
        public int PatientId
        {
            get { return this.patientId; }
            set
            {
                if ((value < 0) || (value == null))
                    this.patientId = 0;
                else
                    this.patientId = value;

                Dentistry.AppConfigs.SelectedPatientId = this.patientId;
              
            
            }

        }

        public PatientSpecialCommentDefine(int patientId)
        {
            InitializeComponent();
            this.EditOrNewFlag = "New";
            this.PatientId = patientId;
            this.dateTxt.Value = (Dentistry.UserControls.PersianDate)DateTime.Now;
        }

        public PatientSpecialCommentDefine(int patientId, int specialCommentId)
        {
            InitializeComponent();
            this.EditOrNewFlag = "Edit";
            this.PatientId = patientId;
            this.SpecialCommentId = specialCommentId;
        }

        private void PatientSpecialCommentDefine_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();
            if (this.EditOrNewFlag == "Edit")
                FetchEntityInfo(this.SpecialCommentId);
        }

        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new
            {
                EntityName = "BaseCoding_SpecialCommentTypes"
            };
            var result = Dentistry.DataProvider.GetBaseCodingX(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;
           
            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0)
                                        ? (dd as IEnumerable<dynamic>)
                                        .Where(i => Convert.ToBoolean(i.IsDeleted) != true)
                                        .Select(i => new
                                                {
                                                    Id = (int)i.Id,
                                                    Title = (string)i.Title
                                                }
                                            ).ToList()
                                        : null;

            this.dgSpecialCommentType.SelectionChanged -= new System.EventHandler(this.dgSpecialCommentType_SelectionChanged);
            this.dgSpecialCommentType.DataSource = list;
            this.dgSpecialCommentType.CurrentCell = null;
            this.dgSpecialCommentType.SelectionChanged += new System.EventHandler(this.dgSpecialCommentType_SelectionChanged);

        }
        #endregion

        #region FetchEntityInfo
        private void FetchEntityInfo(int id)
        {
            try
            {

                dynamic sObj = new
                {
                    PatientId = this.PatientId,
                    Id = this.SpecialCommentId
                };
                var result = Dentistry.DataProvider.GetPatientSpecialCommentsX(sObj);
                if (result != null && result.Success == false && result.Data == null)
                    return;

                var dd = result.Data;

                var obj = dd != null && (Enumerable.Count(dd) > 0) 
                                            ? (dd as IEnumerable<dynamic>).Select(i => i).FirstOrDefault() : null;


                if (obj != null)
                {
                    int specialCommentTypeId = obj.SpecialCommentTypeId != null ? Convert.ToInt32(obj.SpecialCommentTypeId) : 0;

                    int rowIndex = -1;
                    foreach (DataGridViewRow row in dgSpecialCommentType.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["ColumnId"].Value) == specialCommentTypeId)
                        {
                            //    row.Selected = true;
                            rowIndex = row.Index;
                            break;
                        }
                    }
                    dgSpecialCommentType.ClearSelection();
                    dgSpecialCommentType.CurrentCell = dgSpecialCommentType.Rows[rowIndex].Cells[1];
                    dgSpecialCommentType.CurrentRow.Selected = false;
                    dgSpecialCommentType.Rows[rowIndex].Selected = true;

                    
                    this.PatientId = Publics.GetPropertyValue<int>(obj, "PatientId");
                    if (obj.Date != null)
                        this.dateTxt.Value = Publics.GetPropertyValue<DateTime>(obj, "Date");
                    if (obj.Title != null)
                        this.commentTxt.Text = Publics.GetPropertyValue<string>(obj, "Title");



                }

            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }

        }
        #endregion

        private bool ValidateForm()
        {
            bool Flag = true;
            if (this.SpecialCommentTypeId < 0)
            {
                this.Error_comboBoxCostTitle.Visible = true;
                Flag = false;
            }
            else
                this.Error_comboBoxCostTitle.Visible = false;

            if (string.IsNullOrEmpty(this.dateTxt.Text))
            {
                this.Error_dateTxt.Visible = true;
                Flag = false;
            }
            else
                this.Error_dateTxt.Visible = false;

            return Flag;
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (this.ValidateForm() == false)
            return;
            try
            {



                dynamic iObj = new System.Dynamic.ExpandoObject();
                if (this.EditOrNewFlag == "Edit" && this.SpecialCommentId != 0)
                {
                    iObj.Id = this.SpecialCommentId;
                }
                if (this.PatientId != 0)
                {
                    iObj.PatientId = this.PatientId;
                }
                iObj.ActionType = this.EditOrNewFlag;
                iObj.SpecialCommentTypeId = this.SpecialCommentTypeId;
                iObj.Title = this.commentTxt.Text.Trim().ToString();
                iObj.Date = DateTime.Now;
                iObj.IsDeleted = false;



                JsonResponse<dynamic> result = Dentistry.DataProvider.DefineSpecialCommentX(iObj);

                if (result != null && result.Success == true && result.Data != null)
                {

                }

            }
            catch (System.Exception exp)
            {
                ErrorClass.WriteErrorsToFile(this.Name, exp.TargetSite.Name.ToString(), exp.Message, DateTime.Now);
            }
        }

        private void dgSpecialCommentType_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dgSpecialCommentType.CurrentRow != null) && (((DataGridView)sender).CurrentRow.Selected))
            {
                this.SpecialCommentTypeId = Convert.ToInt32(this.dgSpecialCommentType.CurrentRow.Cells["ColumnId"].Value);
                this.specialCommentTypeLbl.Text = Convert.ToString(this.dgSpecialCommentType.CurrentRow.Cells["ColumnTitle"].Value);

               
            }
        }


    }
}
