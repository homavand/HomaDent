using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using FarsiMessageBox;
using System.Threading;
using System.Globalization;
using System.Linq;
using System.Dynamic;

namespace Dentistry
{
    public partial class UserDefine : Form
    {
        Thread ShowOpenFileDialog;
        string EditOrNewFlag;
        int? StaffId = null;
        int? UserId = null;
        dynamic actionList = null;

        public UserDefine()
        {
            InitializeComponent();

            this.EditOrNewFlag = "New";
        }

        public UserDefine(int userId)
        {
            InitializeComponent();

            this.EditOrNewFlag = "Edit";
            this.UserId = userId;


        }

        private void UserDefine_Load(object sender, EventArgs e)
        {
           
            this.FillDataGrid_dgStaffs();

            if (EditOrNewFlag == "Edit" && this.UserId != null)
                FetchUserInfo(this.UserId.Value);
        }

        public void FetchUserInfo(int userId)
        {
            try
            {

                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.UserId = userId;

                JsonResponse<dynamic> result = Dentistry.DataProvider.GetUserX(sObj);
                if (result == null || result.Success == false || result.Data == null)
                    return;

                var dd = result.Data;
                var obj = (dd != null && Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).FirstOrDefault() : null;

                if (obj != null)
                {

                    int staffId = obj.StaffId != null ? Convert.ToInt32(obj.StaffId) : 0;

                    int rowIndex = -1;
                    foreach (DataGridViewRow row in dgStaffs.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["ColumnStaffId"].Value) == staffId)
                        {
                            //    row.Selected = true;
                            rowIndex = row.Index;
                            break;
                        }
                    }
                    dgStaffs.ClearSelection();
                    //dgStaffs.CurrentCell = dgStaffs.Rows[rowIndex].Cells[1];
                    dgStaffs.CurrentRow.Selected = false;
                    if (rowIndex > -1)
                        dgStaffs.Rows[rowIndex].Selected = true;

                    this.UserId = Publics.GetPropertyValue<int>(obj, "UserId");
                
                    this.UserNameTxt.Text = Publics.GetPropertyValue<string>(obj, "UserName");
                    this.UserPassTxt.Text = Publics.GetPropertyValue<string>(obj, "UserPass");

                    if (Convert.ToBoolean(obj.IsDeleted) == true)
                        this.IsDeActiveChk.Checked = true;
                    else
                        this.IsActiveChk.Checked = true;
                }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }

      

        #region FillDataGrid_dgUser
        public void FillDataGrid_dgStaffs()
        {
            try
            {
                dynamic sObj = new
                {

                };

                JsonResponse<dynamic> result = Dentistry.DataProvider.GetStaffsX(sObj);
                if (result == null || result.Success == false || result.Data == null)
                    return;

                var dd = result.Data;
                IEnumerable<dynamic> list = dd != null ? (dd as IEnumerable<dynamic>)
                                                        .Where(i => Convert.ToBoolean(i.IsDeleted) != true)
                                                        .Select(i => new
                                                        {
                                                            UserId = (int?)i.UserId,
                                                            StaffId = (int)i.StaffId,
                                                            StaffTitle = (string)i.FullName,
                                                            UserName = (string)i.UserName,
                                                            //StaffTypeTitle = (string)i.StaffTypeTitle,                                                                                         
                                                            IsDeleted = Convert.ToBoolean(i.IsDeleted),

                                                        }).ToList() : Enumerable.Empty<dynamic>();

                this.dgStaffs.DataSource = list;


            }
            catch (SqlException exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }
        #endregion

        #region buttonCancel_Click
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region buttonOk_Click
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.ValidateForm() == false)
                    return;



                int? staffId = null;

                dynamic iObj = new ExpandoObject();
                iObj.ActionType = EditOrNewFlag;



                if (this.StaffId != null)
                    iObj.StaffId = this.StaffId;



                // User Define    
                iObj.UserId = this.UserId;
                iObj.UserName = this.UserNameTxt.Text.Trim().ToString();
                iObj.UserPass = this.UserPassTxt.Text.Trim().ToString();
                iObj.IsDeleted = IsActiveChk.Checked == true ? false : true;

                JsonResponse<dynamic> result = Dentistry.DataProvider.DefineUserX(iObj);

                if (result != null && result.Success == true && result.Data != null)
                {
                    this.UserId = Convert.ToInt32(result.Data.UserId);
                    FMessageBox.Show(Dentistry.AppConfigs.strSuccessRegister, Dentistry.AppConfigs.strRegister, FMessageBoxButtons.OK);
                }


                this.Close();
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }

        }
        #endregion

        #region ValidateForm
        private bool ValidateForm()
        {

            bool Flag = true;
            if ((this.UserNameTxt.Text.Trim() == string.Empty) || (this.UserNameTxt.IsValid() == false))
            {
                this.Error_UserNameTxt.Visible = true;
                Flag = false;
            }
            else
                this.Error_UserNameTxt.Visible = false;


            if ((this.UserPassTxt.Text.Trim() == string.Empty) || (this.UserPassTxt.IsValid() == false))
            {
                this.Error_UserPassTxt.Visible = true;
                Flag = false;
            }
            else
                this.Error_UserPassTxt.Visible = false;

            return Flag;

        }
        #endregion










        private void getUserPermissions()
        {
            if (this.UserId == null)
                return;


            dynamic sObj = new
            {
                UserId = this.UserId
            };

            JsonResponse<dynamic> result = Dentistry.DataProvider.GetUserPermissionsX(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;

            var dd = result.Data;
            IEnumerable<dynamic> userPermissions = dd != null ? (dd as IEnumerable<dynamic>)
                                                                .Select(i => new
                                                                {
                                                                    AppActionId = (int)i.AppActionId,
                                                                    Value = Convert.ToBoolean(i.Value)

                                                                }).ToList() : Enumerable.Empty<dynamic>();







            foreach (var item in userPermissions)
            {
                int key = item.AppActionId;
                bool val = item.Value != null ? (bool)item.Value : false;

                //foreach (Control c in this.userPermissionsPnl.Controls)
                //{                  
                //    if (c.GetType().Name == "Label")
                //        sb.Append(c.Name + " " + c.GetType().Name + "!!!\r\n");
                //    else
                //        sb.Append(c.Name + " " + c.GetType().Name + "\r\n");
                //}
                ////Control ctr =
                ///
                string cName = string.Format("chk{0}", key);
                var ctr = this.userPermissionsPnl.Controls.Find(cName, true).Single();
                if (ctr != null)
                {
                    var tag = ctr.Tag != null ? ctr.Tag : 0;
                    if (key == Convert.ToInt32(tag))
                        ((CheckBox)ctr).Checked = val;
                }



            }


        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, Color.Silver, ButtonBorderStyle.Solid);
        }

        private void dataRepeater1_DrawItem(object sender, Microsoft.VisualBasic.PowerPacks.DataRepeaterItemEventArgs e)
        {
            Microsoft.VisualBasic.PowerPacks.DataRepeaterItem row = e.DataRepeaterItem;

            int index = row.ItemIndex;
            var item = actionList[index];
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((TabControl)sender).SelectedIndex == 1 && this.UserId == null)
            {
                FMessageBox.Show("کاربر ثبت نشده است"+Environment.NewLine+"لطفا ابتدا کاربر را ثبت کنید", "اخطار", FMessageBoxButtons.OK);
                this.tabControl1.SelectedIndex = 0;
                return;
            }
            if (((TabControl)sender).SelectedIndex == 1)
                getUserPermissions();
        }

        private void addUserPermissions_Click(object sender, EventArgs e)
        {
            if (UserId == null)
                throw new Exception("UserId وارد نشده است");

            List<int> actionIds = new List<int>();
            foreach (Control ctr in this.userPermissionsPnl.Controls)
            {
                if (ctr.GetType() != typeof(CheckBox))
                    continue;

                CheckBox chk = ((CheckBox)ctr);
                if (chk.Checked == true)
                {
                    int actionId = Convert.ToInt32(chk.Tag);
                    if (!actionIds.Contains(actionId))
                        actionIds.Add(actionId);
                }
            }


            dynamic iObj = new ExpandoObject();
            iObj.UserId = this.UserId;
            iObj.AppActionIds = actionIds;


            JsonResponse<dynamic> result = Dentistry.DataProvider.DefineUserPermissionsX(iObj);

            if (result != null && result.Success == true)
            {
                FMessageBox.Show(Dentistry.AppConfigs.strSuccessRegister, Dentistry.AppConfigs.strRegister, FMessageBoxButtons.OK);
            }
        }

        private void dgStaffs_SelectionChanged(object sender, EventArgs e)
        {
            if (this.dgStaffs.CurrentRow == null)
                return;

            DataGridViewRow row = this.dgStaffs.CurrentRow;

            var staffIdObj = row.Cells["ColumnStaffId"].Value;
            if (staffIdObj != null)
                this.StaffId = Convert.ToInt32(staffIdObj);

            var staffTitleObj = row.Cells["ColumnStaffTitle"].Value;
            if (staffTitleObj != null)
                this.staffTxt.Text = Convert.ToString(staffTitleObj);

            var userIdObj = row.Cells["ColumnUserId"].Value;
            int userId = Convert.ToInt32(userIdObj);
            //if (userId > 0 && userId != this.UserId)
            //    this.staffTxt.BackColor = Color.LavenderBlush;
            //else
            //    this.staffTxt.BackColor = Color.Honeydew;

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
