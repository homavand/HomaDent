using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;
using System.Threading;
using FarsiMessageBox;
using PopupControl;
using System.Dynamic;
using System.Linq;

namespace Dentistry
{
    public partial class UserList : Form
    {
        private int UserId;
        PopupControl.Popup p;
        bool dgUserLoadFlag = false;

        #region FormPersonnel
        public UserList()
        {
            try
            {
                InitializeComponent();

                this.FillDataGrid_dgUser();


                //this.dataGridViewPersonnel.Columns[1].DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;


                //this.FillPersonelComboBox_Sexuality();

            }
            catch (System.Exception exp)
            {
                FMessageBox.Show(Dentistry.AppConfigs.strUnhandledExceptionMessage, Dentistry.AppConfigs.strErrorCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Error);
                this.Close();
            }
        }
        #endregion


        #region FillDataGrid_dgUser
        public void FillDataGrid_dgUser()
        {
            try
            {
                dynamic sObj = new
                {
                    
                };                         

                JsonResponse<dynamic> result = Dentistry.DataProvider.GetUserX(sObj);
                if (result == null || result.Success == false || result.Data == null)
                    return;
               
                var dd = result.Data;
                IEnumerable<dynamic> list = dd != null ? (dd as IEnumerable<dynamic>)
                                                                    .Select(i => new
                                                                    {
                                                                        UserId = (int?)i.UserId,                                                                 
                                                                        UserTitle = (string)i.UserTitle,
                                                                        UserName = (string)i.UserName,
                                                                                        
                                                                        IsDeleted = Convert.ToBoolean(i.IsDeleted),
                                                                                      
                                                                    }).ToList() : Enumerable.Empty<dynamic>();

                this.dgUser.DataSource = list;
               
                

                dgUserLoadFlag = true;
            }
            catch (SqlException exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }
        #endregion

        

        private void getUserPermissions(int userId)
        {
           
            dynamic sObj = new
            {
                UserId = userId
            };

            JsonResponse<dynamic> result = Dentistry.DataProvider.GetUserPermissionsX(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;

            IEnumerable<dynamic> userPermissions = result.Data != null ? (result.Data as IEnumerable<dynamic>)
                                                                .Select(i => new
                                                                {
                                                                    AppActionId = (int)i.AppActionId,
                                                                    FormTitle = (string)i.FormTitle,
                                                                    GroupTitle = (string)i.GroupTitle,
                                                                    ActionTitle = (string)i.ActionTitle,
                                                                    Value = i.Value == null ? false : Convert.ToBoolean(i.Value)

                                                                }).ToList() : Enumerable.Empty<dynamic>();




            var actionsList =
                        (from item in userPermissions
                         group item by new { item.FormTitle } into g1

                         select new
                         {
                             FormTitle = g1.Key.FormTitle,
                             Groups = (from item2 in g1
                                       group item2 by new { item2.GroupTitle } into g2
                                       select new
                                       {
                                           GroupTitle = g2.Key.GroupTitle,
                                           Actions = g2.Where(a => a.GroupTitle == g2.Key.GroupTitle)
                                              .Select(a =>
                                                  new
                                                  {
                                                      AppActionId = (int)a.AppActionId,
                                                      ActionTitle = (string)a.ActionTitle,
                                                      Value = (bool?)a.Value ?? false
                                                  }
                                             ).ToList()
                                       }
                                      ).ToList()

                         }).ToList();



            treeView1.Nodes.Clear();
            treeView1.ImageList = imageList1;

            foreach (var f in actionsList)
            {               
                TreeNode fNode = new TreeNode(f.FormTitle);
                fNode.ForeColor = Color.Blue;
                fNode.ImageIndex = 0;
                treeView1.Nodes.Add(fNode);
                
               
                foreach (var g in f.Groups)
                {
                        
                    TreeNode gNode = null;
                    if (g.GroupTitle != null)
                    {
                        gNode = new TreeNode(g.GroupTitle);
                        gNode.ForeColor = Color.DodgerBlue;
                        gNode.ImageIndex = 1;
                        fNode.Nodes.Add(gNode);
                    }
                   

                    

                    foreach (var a in g.Actions)
                    {
                        TreeNode aNode = new TreeNode();
                        aNode.Tag = a.AppActionId;

                        if (gNode == null)
                            aNode = fNode.Nodes.Add(string.Format("{0} ({1})", a.ActionTitle, a.AppActionId));
                        else
                            aNode = gNode.Nodes.Add(string.Format("{0} ({1})", a.ActionTitle, a.AppActionId));
                      
                        if (a.Value == true)
                            aNode.ImageIndex = 2;
                        else
                            aNode.ImageIndex = 3;

                        

                    }
                   
                    
                }
            }

            treeView1.ExpandAll();
        }

     
        #region dataGridViewPersonnel_CellDoubleClick
        private void dgUser_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex < 0)
                return;
            this.ButtonEdit_Click(this, null);
            

        }
        #endregion

        private void dgUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.dgUser.CurrentRow == null)
                return;

            this.userNameLbl.Text = Convert.ToString( this.dgUser.CurrentRow.Cells["ColumnUserName"].Value );
            int userId = Convert.ToInt32(this.dgUser.CurrentRow.Cells["ColumnUserId"].Value);
            getUserPermissions(userId);
        }

        #region dataGridViewPersonnel_SelectionChanged
        private void dgUser_SelectionChanged(object sender, EventArgs e)
        {

            if (dgUserLoadFlag == false)
                return;

            if ((this.dgUser.CurrentCell != null) && (this.dgUser.CurrentCell.Selected))
            {

                if (this.dgUser.CurrentRow.Cells["ColumnUserId"].Value != null && Convert.ToInt32(this.dgUser.CurrentRow.Cells["ColumnUserId"].Value) == Dentistry.AppConfigs.CurrentUserId)
                {
                    this.ButtonDelete.Enabled = false;
                }
                else
                {
                    this.ButtonDelete.Enabled = true;
                }

                this.ButtonEdit.Enabled = true;

                this.UserId = Convert.ToInt32(dgUser["ColumnUserId", ((DataGridView)sender).CurrentRow.Index].Value);
                //FillDataGrid_dgUserPermission(this.UserId);
                



            }
            else
            {
                this.ButtonEdit.Enabled = false;
                this.ButtonDelete.Enabled = false;
            }
        }
        #endregion

     

        #region dataGridViewPersonnel_CellFormatting
        private void dgUser_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgUser.Columns["ColumnIsDeleted"].Visible == false)
            {
                if (Convert.ToBoolean(this.dgUser["ColumnIsDeleted", e.RowIndex].Value) == true)
                    this.dgUser.Rows[e.RowIndex].DefaultCellStyle.ForeColor = Color.Red;

            }
        }
        #endregion        

        #region ButtonNew_Click
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_کاربران_و_سطح_دسترسی_جدبد) == false)
                return;
            UserDefine form = new UserDefine();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.FillDataGrid_dgUser();
            }
            form.Dispose();

        }
        #endregion

        #region ButtonEdit
        private void ButtonEdit_Click(object sender, EventArgs e)
        {

            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_کاربران_و_سطح_دسترسی_ویرایش) == false)
                return;

            int userId = Convert.ToInt32(this.dgUser.CurrentRow.Cells["ColumnUserId"].Value);
            UserDefine form = new UserDefine(userId);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
            {
                this.FillDataGrid_dgUser();
            }
            form.Dispose();
            
            
        }
        #endregion

        #region ButtonDelete
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_کاربران_و_سطح_دسترسی_حذف) == false)
                return;
            try
            {
                if (this.dgUser.CurrentCell == null)
                    return;
                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    dynamic iObj = new ExpandoObject();
                    iObj.ActionType = "Delete";
                    iObj.StaffId = Convert.ToInt32(this.dgUser["ColumnStaffId", this.dgUser.CurrentRow.Index].Value);
                    iObj.IsDeleted = true;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefineStaffX(iObj);

                    if (result != null && result.Success == true && result.Data != null)
                    {
                        this.FillDataGrid_dgUser();
                    }

                   
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message);
                this.Close();
            }
        }
        #endregion


        private void dataGridView_CellFormatting()
        {
            try
            {
                foreach (DataGridViewRow row in this.dgUser.Rows)
                    if (Convert.ToBoolean(this.dgUser["ColumnIsDeleted", row.Index].Value) == false)
                    {
                        this.dgUser.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                        ((DataGridViewImageCell)this.dgUser["ColumnIsDeletedPic", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.tinyCheck;
                    }
                    else
                    {
                        this.dgUser.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Crimson;
                        ((DataGridViewImageCell)this.dgUser["ColumnIsDeletedPic", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.emptyPoint;
                    }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        private void dgUser_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgUser.CurrentCell = null;
            this.dataGridView_CellFormatting();
        }

      
      
     
    }
}
