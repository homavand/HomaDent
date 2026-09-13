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

namespace Dentistry
{
    public partial class ServiceList : Form
    {
        private int serviceGroupId = 0;
        public int ServiceGroupId
        {
            set { 
                this.serviceGroupId = value;
                this.FillGrid_dgServices();
            }
            get { return this.serviceGroupId; }
        }

        

        #region FormService
        public ServiceList()
        {
            InitializeComponent();
        }
        #endregion

        private void ServiceList_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();

            this.dgServices_Init();
        }
        
        private void dgServices_Init()
        {
            dgServices.AutoGenerateColumns = false;
            dgServices.Columns["ColumnServiceId"].Visible = false;
            dgServices.Columns["ColumnIsDeleted"].Visible = false;
            dgServices.Columns["ColumnServiceCode"].DisplayIndex = 0;
            dgServices.Columns["ColumnServiceTitle"].DisplayIndex = 1;
            dgServices.Columns["ColumnServiceFreePrice"].DisplayIndex = 2;
            dgServices.Columns["ColumnPriceDefineDate"].DisplayIndex = 3;
            dgServices.Columns["ColumnIsDeletedPic"].DisplayIndex = 4;

            dgServices.Columns["ColumnServiceCode"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;            
            dgServices.Columns["ColumnServiceTitle"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dgServices.Columns["ColumnServiceFreePrice"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgServices.Columns["ColumnPriceDefineDate"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

        }

        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new
            {
                EntityName = "BaseCoding_ServiceGroups"
            };
            var result = Dentistry.DataProvider.GetBaseCodingX(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;
           
            IEnumerable<dynamic> serviceGroupList = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>)
                                                                            .Select(i =>
                                                                                new
                                                                                {
                                                                                    i.Id,
                                                                                    i.Title,
                                                                                    i.Color,
                                                                                    i.IsDeleted,
                                                                                }).ToList() : Enumerable.Empty<dynamic>();


            this.dgServiceGroup.SelectionChanged -= new System.EventHandler(this.dgServiceGroup_SelectionChanged);
            this.dgServiceGroup.DataSource = serviceGroupList;
            //this.dgServiceGroup.CurrentCell = null;
            this.dgServiceGroup.SelectionChanged += new System.EventHandler(this.dgServiceGroup_SelectionChanged);
        }
        #endregion

      

        #region FillGrid_dgServices
        public void FillGrid_dgServices(bool flag = false)
        {
            try
            {
                
                dynamic sObj = new System.Dynamic.ExpandoObject();

                //if(flag == true)
                //{
                if (this.ServiceGroupId != 0 )
                    sObj.ServiceGroupId = this.ServiceGroupId;

                //if(!string.IsNullOrEmpty(this.ServiceCodeTxt.Text))
                //    sObj.ServiceCode    = this.ServiceCodeTxt.Text; 
                //if(!string.IsNullOrEmpty(this.ServiceTitleTxt.Text))
                //    sObj.ServiceTitle   = this.ServiceTitleTxt.Text;                  
               
                if (Convert.ToBoolean(this.IsDeletedChk.Checked) != true)
                    sObj.IsDeleted = false;
             

                var result = DataProvider.GetServicesX(sObj);
                if (result == null || result.Success == false )
                    return;

                var dd = result.Data;
                IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i)
                                                                              .Select(i =>                                                                              
                                                                                new
                                                                                {
                                                                                    i.ServiceId,
                                                                                    i.ServiceCode,
                                                                                    i.ServiceTitle,
                                                                                    i.ServiceColor,
                                                                                    i.IsDeleted,
                                                                                    i.ServiceFreePrice,
                                                                                    i.PriceDefineDate

                                                                                }).ToList() : Enumerable.Empty<dynamic>();
              

              
                this.dgServices.DataSource = list;

               
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message);
                this.Close();
            }
        }
        #endregion

      
        #region dataGridViewService_CellDoubleClick
        private void dataGridViewService_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.ButtonEdit_Click(this, null);
        }
        #endregion

        #region dataGridViewService_SelectionChanged
        private void dataGridViewService_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dgServices.CurrentRow != null) && (this.dgServices.CurrentRow.Selected))
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
        #endregion

        #region dataGridViewService_DataBindingComplete
        private void dataGridViewService_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            this.dataGridViewService_CellFormatting();
        }
        #endregion

        #region dataGridViewService_CellFormatting
        private void dataGridViewService_CellFormatting()
        {
            try
            {
                foreach (DataGridViewRow row in this.dgServices.Rows)
                {
                    if (Convert.ToBoolean(this.dgServices["ColumnIsDeleted", row.Index].Value) == false)
                    {
                        this.dgServices.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Black;
                        ((DataGridViewImageCell)this.dgServices["ColumnIsDeletedPic", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.tinyCheck;
                    }
                    else
                    {
                        this.dgServices.Rows[row.Index].DefaultCellStyle.ForeColor = Color.Crimson;
                        ((DataGridViewImageCell)this.dgServices["ColumnIsDeletedPic", row.Index]).Value = (Image)global::Dentistry.Properties.Resources.emptyPoint;
                    }

                   

                    if (this.dgServices["ColumnServiceColor", row.Index].Value != null)
                    {
                        string color = this.dgServices["ColumnServiceColor", row.Index].Value.ToString();
                        DataGridViewCell cell = this.dgServices["ColumnColor", row.Index];                   
                        cell.Style.BackColor =  Color.FromArgb(Convert.ToInt32(color));
                     
                    }
                }
                
                   

            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }
        #endregion

        #region ButtonNew_Click
        private void ButtonNew_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_خدمات_مطب_جدبد) == false)
                return;


            //this.ActiveControls();
            ServiceDefine form = new ServiceDefine();
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                this.FillGrid_dgServices();
        }
        #endregion

        #region ButtonEdit_Click
        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_خدمات_مطب_ویرایش) == false)
                return;
            try
            {
                
                int id = Convert.ToInt32(this.dgServices.CurrentRow.Cells["ColumnServiceId"].Value);
                ServiceDefine form = new ServiceDefine(id);
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                    this.FillGrid_dgServices();
                form.Dispose();
               

                                     
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }
        #endregion 

        #region ButtonDelete_Click
        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_خدمات_مطب_حذف) == false)
                return;

            if (this.dgServices.CurrentCell == null)
                return;

            try
            {

                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    dynamic iObj = new System.Dynamic.ExpandoObject();
                    iObj.ActionType = "Edit";
                    iObj.Id = int.Parse(this.dgServices.CurrentRow.Cells["ColumnServiceId"].Value.ToString());
                    iObj.IsDeleted = true;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefineServiceX(iObj);
                    if (result != null && result.Success == true)
                    {
                        this.FillGrid_dgServices();
                    }

                    
                }
            }
            catch(System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }
        #endregion

     

        #region buttonCancel_Click
        private void buttonCancel_Click(object sender, EventArgs e)
        {
           
        }
        #endregion 
        
      
      

        private void ButtonServicePricing_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_خدمات_مطب_تعرفه_گذاری_خدمات) == false)
                return;
            int? serviceId = null;
            serviceId = Convert.ToInt32(this.dgServices["ColumnServiceId", this.dgServices.CurrentRow.Index].Value);
            ServiceInsurersPrices form = new ServiceInsurersPrices(serviceId);
            //form.EditOrNewFlag = "New";
            form.ShowDialog();
            //if (form.Flag)
            //    FillGrid_dgServices();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, Color.Silver, ButtonBorderStyle.Solid);
        }

        private void dgServiceGroup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgServiceGroup.Columns[e.ColumnIndex].Name.Trim().Equals("ColumnGroupColor"))
            {
                var color = this.dgServiceGroup.Rows[e.RowIndex].Cells["ColumnServiceGroupColor"].Value;
                this.dgServiceGroup.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(Convert.ToInt32(color));
                //this.dgServiceGroup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
        }
        private void dgServiceGroup_SelectionChanged(object sender, EventArgs e)
        {
            if(this.dgServiceGroup.Focus())
                if ((this.dgServiceGroup.CurrentRow != null) && (((DataGridView)sender).CurrentRow.Selected))
                {
                    this.ServiceGroupId = Convert.ToInt32(this.dgServiceGroup.CurrentRow.Cells["ColumnServiceGroupId"].Value);
                    this.serviceGroupTitleLbl.Text = Convert.ToString(this.dgServiceGroup.CurrentRow.Cells["ColumnServiceGroupTitle"].Value);
               
                }
        }

        private void IsDeletedChk_CheckedChanged(object sender, EventArgs e)
        {
            this.FillGrid_dgServices();
        }

       
    }
}
