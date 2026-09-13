using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dentistry
{
    public partial class BaseCodings : Form
    {
        public string EntityName = null;
        public string TableName = null;
        public BaseCodings()
        {
            InitializeComponent();
            this.FillDataGrid_dgList();
        }

        #region FillDataGrid_dgUserPermission
        public void FillDataGrid_dgList()
        {
            try
            {
                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.IsBaseTable = true;
                var data = DataProvider.LoadFormInitInfo(sObj);
                var dd = data != null && data.Data != null ? data.Data : null;

                
               IEnumerable <dynamic> list = dd != null && dd.BaseTable != null && (Enumerable.Count(dd.BaseTable) > 0) ? (dd.BaseTable as IEnumerable<dynamic>).Select(i =>
                    new
                    {
                        i.Id,
                        i.Title,
                        i.Entity,
                        i.Table
                    }
                ).ToList() : null;

                this.dgList.SelectionChanged -= new System.EventHandler(this.dgList_SelectionChanged);
                this.dgList.DataSource = list;
                this.dgList.CurrentCell = null;
                this.dgList.SelectionChanged += new System.EventHandler(this.dgList_SelectionChanged);
            }
            catch (System.Exception exp)
            {
                this.Close();
            }
        }
        #endregion


        #region FillDataGrid_dgListItems

        public DataTable getListDataTable(IEnumerable<dynamic> list)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Terminology", typeof(string));
            dt.Columns.Add("IsDeleted", typeof(bool));
            dt.Columns.Add("Comment", typeof(string));
        
            foreach (var item in list)
                dt.Rows.Add(
                    item.Id,
                    item.Title,
                    item.Terminology,
                    item.IsDeleted,
                    item.Comment                                
                    );

            return dt;
        }
        public void FillDataGrid_dgListItems(string entity)
        {
            try
            {

                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.EntityName = entity;
                JsonResponse<dynamic> result = DataProvider.GetBaseCodingX(sObj);
                if (result == null || result.Success == false )
                    return;

                var dd = result.Data;
                IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i =>
                    new
                    {
                        Id = (int)i.Id,
                        Title = (string)i.Title,
                        Terminology = (string)i.Terminology,
                        IsDeleted = Convert.ToBoolean(i.IsDeleted),
                        Comment = (string)i.Comment,
                    }
                ).ToList() : Enumerable.Empty<dynamic>();

                DataTable dt = getListDataTable(list);
                this.dgListItem.DataSource = dt;
                //this.dgListItem.SelectedRows.Clear();

            }
            catch (System.Exception exp)
            {
                this.Close();
            }
        }
        #endregion


      

        private void dgList_SelectionChanged(object sender, EventArgs e)
        {
            var tableName = this.dgList.CurrentRow.Cells["ColumnTable"].Value;
            var entityName = this.dgList.CurrentRow.Cells["ColumnEntity"].Value;

            if ((((DataGridView)sender).CurrentRow != null) && (((DataGridView)sender).CurrentRow.Selected))
            {
                this.TableName = Convert.ToString(tableName);
                this.EntityName = Convert.ToString(entityName);
                this.ButtonNew.Enabled = true;
                this.ButtonEdit.Enabled = false;
                this.ButtonDelete.Enabled = false;
            }
            else
            {
                this.ButtonNew.Enabled = false;
                this.ButtonEdit.Enabled = false;
                this.ButtonDelete.Enabled = false;
            }

            if (this.dgList.CurrentCell == null)
                return;

            FillDataGrid_dgListItems(tableName.ToString());
        }

        private void dgListItem_SelectionChanged(object sender, EventArgs e)
        {
            

            if ((((DataGridView)sender).CurrentRow != null) && (((DataGridView)sender).CurrentRow.Selected))
            {
                if (this.EntityName == "CostType" && ((this.dgListItem.CurrentRow.Cells["Column_Id"].Value.ToString() == "1") || (this.dgListItem.CurrentRow.Cells["Column_Id"].Value.ToString() == "2")))
                {
                    this.ButtonEdit.Enabled = false;
                    this.ButtonDelete.Enabled = false;
                }
                else
                {
                    this.ButtonEdit.Enabled = true;
                    this.ButtonDelete.Enabled = true;
                }
                this.EntityName = Convert.ToString(this.EntityName);                
                this.ButtonEdit.Enabled = true;
                this.ButtonDelete.Enabled = true;
            }
            else
            {
                this.ButtonEdit.Enabled = false;
                this.ButtonDelete.Enabled = false;
            }

            if (this.dgListItem.CurrentCell == null)
                return;
        }

        private void dgListItem_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dgListItem_CellFormatting();
        }

        private void dgListItem_CellFormatting()
        {
            try
            {
                foreach (DataGridViewRow row in this.dgListItem.Rows)
                    if (Convert.ToBoolean(this.dgListItem["Column_IsDeleted", row.Index].Value) == false)
                    {
                        this.dgListItem.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                        ((DataGridViewImageCell)this.dgListItem["Column_IsDeletedPic", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.tinyCheck;
                    }
                    else
                    {
                        this.dgListItem.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Crimson;
                        ((DataGridViewImageCell)this.dgListItem["Column_IsDeletedPic", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.emptyPoint;
                    }

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        private void ButtonNew_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_کدینگ_پایه_جدبد) == false)
                return;
            var title = this.dgList.CurrentRow.Cells["ColumnTitle"].Value;
            var tableName  = this.dgList.CurrentRow.Cells["ColumnTable"].Value;
            var entityName = this.dgList.CurrentRow.Cells["ColumnEntity"].Value;
            if (tableName == null)
                return;

            BaseCodingDefine form = new BaseCodingDefine(entityName.ToString(), title.ToString(), tableName.ToString(), "New");
            form.ShowDialog(this);

            this.FillDataGrid_dgListItems(tableName.ToString());

            form.Dispose();
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_کدینگ_پایه_ویرایش) == false)
                return;
            var title = this.dgList.CurrentRow.Cells["ColumnTitle"].Value;
            var tableName = this.dgList.CurrentRow.Cells["ColumnTable"].Value;
            var entityName = this.dgList.CurrentRow.Cells["ColumnEntity"].Value;
            if (tableName == null)
                return;

            int id = Convert.ToInt32(this.dgListItem.CurrentRow.Cells["Column_Id"].Value);

            BaseCodingDefine form = new BaseCodingDefine(entityName.ToString(), title.ToString(), tableName.ToString(), "Edit", id);
            if (form != null)
                form.ShowDialog(this);

            this.FillDataGrid_dgListItems(tableName.ToString());

            form.Dispose();
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_کدینگ_پایه_حذف) == false)
                return;
            if (this.dgListItem.CurrentCell == null)
                return;

            int id = Convert.ToInt32(this.dgListItem.CurrentRow.Cells["Column_Id"].Value);
            var tableName = this.dgList.CurrentRow.Cells["ColumnTable"].Value;

            if(id == 0)
            {
                MessageBox.Show(" رکورد با کد 0 قابل حذف نمی باشد");
                return;
            }

            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.ActionName = "Delete";
            sObj.EntityName = tableName;
            sObj.Id = id;
            sObj.IsDeleted = true;
            JsonResponse<dynamic> result = DataProvider.DefineBaseCodingX(sObj);
            if (result == null || result.Success == false)
                return;

            this.FillDataGrid_dgListItems(tableName.ToString());
           
        }

        private void dgListItem_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.ButtonEdit_Click(this, null);
        }

        private void BasePnl_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, Color.Silver, ButtonBorderStyle.Solid);
        }

      
    }
}
