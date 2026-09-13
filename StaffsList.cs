using FarsiMessageBox;
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
    public partial class StaffsList : Form
    {
        public StaffsList()
        {
            InitializeComponent();

            this.FillGrid_dgStaffs();

            this.LoadFormInit();
            this.dgColumnOrder();

        }

        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new
            {
                EntityName = "BaseCoding_StaffTypes"
            };
            var result = Dentistry.DataProvider.GetBaseCodingX(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;
          
            IEnumerable<dynamic> staffTypeList = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;

            
            this.staffTypeCbo.DataSource = staffTypeList;
            this.staffTypeCbo.ValueMember = "Id";
            this.staffTypeCbo.DisplayMember = "Title";
           

            this.staffTypeCbo.SelectedIndex = -1;
        }
        #endregion

        private void dgColumnOrder()
        {
            dgStaffs.AutoGenerateColumns = false;
            dgStaffs.Columns["ColumnStaffId"].Visible = false;
            dgStaffs.Columns["ColumnIsDeleted"].Visible = false;
            dgStaffs.Columns["ColumnStaffFullName"].DisplayIndex = 0;
            dgStaffs.Columns["ColumnStaffTypeTitle"].DisplayIndex = 1;
            dgStaffs.Columns["ColumnUserName"].DisplayIndex = 2;
            dgStaffs.Columns["ColumnIsDeletedPic"].DisplayIndex = 3;
        }

        #region FillGrid_dgServices
        public void FillGrid_dgStaffs()
        {
            try
            {

                dynamic sObj = new System.Dynamic.ExpandoObject();

                if(this.staffTypeCbo.SelectedIndex > 0)
                    sObj.StaffTypeId = Convert.ToInt32(this.staffTypeCbo.SelectedValue);
                if(!string.IsNullOrEmpty(this.staffFirstNameTxt.Text))
                    sObj.FirstName = this.staffFirstNameTxt.Text;
                if(string.IsNullOrEmpty(this.staffLastNameTxt.Text))
                    sObj.LastName = this.staffLastNameTxt.Text;
                if(Convert.ToBoolean(this.IsDeletedChk.Checked) != true)
                    sObj.IsDeleted = false;
             

                var result = DataProvider.GetStaffsX(sObj);
                if (result == null || result.Success == false)
                    return;

                var dd = result.Data;
                var list = (dd as IEnumerable<dynamic>)                                            
                                            .Select(i =>
                                            new
                                            {                                                
                                                StaffId = (int)i.StaffId,
                                                StaffFullName = string.Format("{0} {1}",(string)i.FirstName,(string)i.LastName),                                               
                                                StaffTypeTitle = (string)i.StaffTypeTitle,
                                                UserName = (string)i.UserName,
                                                IsDeleted = Convert.ToBoolean(i.IsDeleted)
                                            }).ToList();


                this.dgStaffs.DataSource = list;


            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message);
                this.Close();
            }
        }
        #endregion

        private void searchBtn_Click(object sender, EventArgs e)
        {
            this.FillGrid_dgStaffs();
        }

        private void dgStaffs_CellFormatting()
        {
            foreach (DataGridViewRow row in this.dgStaffs.Rows)
            {
                if (Convert.ToBoolean(this.dgStaffs["ColumnIsDeleted", row.Index].Value) == false)
                {
                    this.dgStaffs.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                    ((DataGridViewImageCell)this.dgStaffs["ColumnIsDeletedPic", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.tinyCheck;
                }
                else
                {
                    this.dgStaffs.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Crimson;
                    ((DataGridViewImageCell)this.dgStaffs["ColumnIsDeletedPic", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.emptyPoint;
                }
            }

              
        }

        private void dgStaffs_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgStaffs_CellFormatting();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, Color.Silver, ButtonBorderStyle.Solid);
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_کارمندان_جدید) == false)
                return;

            StaffDefine form = new StaffDefine();
            form.ShowDialog();
            FillGrid_dgStaffs();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_کارمندان_ویرایش) == false)
                return;
            try
            {
                int id = Convert.ToInt32(this.dgStaffs.CurrentRow.Cells["ColumnStaffId"].Value);
                StaffDefine form = new StaffDefine(id);
                form.ShowDialog(this);
                form.Dispose();
                this.FillGrid_dgStaffs();


            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_کارمندان_حذف) == false)
                return;

            if (this.dgStaffs.CurrentCell == null)
                return;

            try
            {

                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    dynamic iObj = new System.Dynamic.ExpandoObject();
                    iObj.ActionType = "Edit";
                    iObj.StaffId = int.Parse(this.dgStaffs.CurrentRow.Cells["ColumnStaffId"].Value.ToString());
                    iObj.IsDeleted = true;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefineStaffX(iObj);
                    if (result != null && result.Success == true)
                    {
                        this.FillGrid_dgStaffs();
                    }


                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }

    

        private void dgStaffs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.ButtonEdit_Click(this, null);
        }

        private void dgStaffs_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dgStaffs.CurrentRow != null) && (this.dgStaffs.CurrentRow.Selected))
            {
                this.ButtonEdit.Enabled = true;
                this.ButtonDelete.Enabled = true;
            }
            else
            {
                this.ButtonEdit.Enabled = false;
                this.ButtonDelete.Enabled = false;

            }
        }

        private void dgStaffs_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgStaffs.Columns["ColumnIsDeleted"].Visible == false)
            {
                if (Convert.ToBoolean(this.dgStaffs["ColumnIsDeleted", e.RowIndex].Value) == true)
                    this.dgStaffs.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;

            }
        }
    }
}
