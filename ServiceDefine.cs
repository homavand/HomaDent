using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dentistry
{
    public partial class ServiceDefine : Form
    {
        public string EditOrNewFlag;
        public int ServiceGroupId = 0;
        public int? ServiceId = null;
        public double? ServicePrice = null;
        public bool Flag = false;
        public ServiceDefine()
        {
            InitializeComponent();
            this.EditOrNewFlag = "New";
        }
        public ServiceDefine(int serviceId)
        {
            InitializeComponent();
            this.EditOrNewFlag = "Edit";
            this.ServiceId = serviceId;
        }

        private void ServiceDefine_Load(object sender, EventArgs e)
        {
            LoadFormInit();
          
            if(this.EditOrNewFlag == "Edit" && this.ServiceId != null)
            {
                this.FetchServiceInfo(this.ServiceId.Value);


            }
        }

        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new
            {
                IsServiceGroup = true,
            };
            var data = Dentistry.DataProvider.LoadFormInitInfo(sObj);
            var dd = data != null && data.Data != null ? data.Data : null;

            if (dd == null)
                return;


            IEnumerable<dynamic> listServiceGroup = dd.ServiceGroup != null && (Enumerable.Count(dd.ServiceGroup) > 0) ? (dd.ServiceGroup as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i => i).Where(i => i.Id != 0).ToList() : null;

            this.dgServiceGroup.SelectionChanged -= new System.EventHandler(this.dgServiceGroup_SelectionChanged);
            this.dgServiceGroup.DataSource = listServiceGroup;
            this.dgServiceGroup.CurrentCell = null;
            this.dgServiceGroup.SelectionChanged += new System.EventHandler(this.dgServiceGroup_SelectionChanged);

        }
        #endregion

        public void FetchServiceInfo(int serviceId)
        {
            try
            {

                dynamic iObj = new System.Dynamic.ExpandoObject();
                iObj.ServiceId = serviceId; 
                iObj.InsurerId = 0; // بیمه آزاد 

                 var result = DataProvider.GetServicesX(iObj);
                if (result != null && result.Success == false && result.Data == null)
                    return;

                var dd = result.Data;
                IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).Select(i =>
                                                                                 new
                                                                                 {
                                                                                     i.ServiceId,
                                                                                     i.ServiceGroupId,
                                                                                     i.ServiceGroupTitle,
                                                                                     i.ServiceCode,
                                                                                     i.ServiceTitle,
                                                                                     i.IsDeleted,
                                                                                     i.IsToothNumber,
                                                                                     i.IsMoreTooth,
                                                                                     i.ServiceColor,
                                                                                     i.Comment,
                                                                                     i.ServiceFreePrice,
                                                                                 }).ToList() : null;

                if (list == null)
                    return;

                var obj = list.FirstOrDefault();
                if (obj != null)
                {
                    this.ServiceGroupId = Publics.GetPropertyValue<int>(obj, "ServiceGroupId");

                    this.dgServiceGroup.ClearSelection();
                    int rowIndex = -1;
                    foreach (DataGridViewRow row in dgServiceGroup.Rows)
                    {
                        if (Convert.ToInt32(row.Cells["ColumnServiceGroupId"].Value) == this.ServiceGroupId)
                        {
                            row.Selected = true;
                            rowIndex = row.Index;
                            break;
                        }
                    }
                    
                    dgServiceGroup.CurrentCell = dgServiceGroup.Rows[rowIndex].Cells[2];
              
                    this.ServiceCodeTxt.Text = Publics.GetPropertyValue<string>(obj, "ServiceCode");
                    this.ServiceTitleTxt.Text = Publics.GetPropertyValue<string>(obj, "ServiceTitle");
                    this.ColorLbl.BackColor = obj.ServiceColor != null ? Color.FromArgb(Convert.ToInt32((obj.ServiceColor.ToString()))) : null;
                    this.IsToothNumberChk.Checked = Publics.GetPropertyValue<bool>(obj, "IsToothNumber");
                    this.IsMoreToothChk.Checked = Publics.GetPropertyValue<bool>(obj, "IsMoreTooth");
                   
                    this.CommentTxt.Text = Publics.GetPropertyValue<string>(obj, "Comment");
                    this.ServicePriceTxt.Text = Publics.GetPropertyValue<string>(obj, "ServiceFreePrice");
                    this.ServicePrice = Publics.GetPropertyValue<double>(obj, "ServiceFreePrice");

                    if (Publics.GetPropertyValue<bool>(obj, "IsDeleted") == true)
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


        

        #region ValidateForm
        private bool ValidateForm()
        {

            bool Flag = true;

            if (this.ServiceGroupId == 0)
            {
                this.Error_ServiceGroup.Visible = true;
                Flag = false;
            }
            else
                this.Error_ServiceGroup.Visible = false;

            if (string.IsNullOrEmpty(this.ServiceCodeTxt.Text))
            {
                this.Error_ServiceCode.Visible = true;
                Flag = false;
            }
            else
                this.Error_ServiceCode.Visible = false;

            if (string.IsNullOrEmpty(this.ServiceTitleTxt.Text))
            {
                this.Error_ServiceTitle.Visible = true;
                Flag = false;
            }
            else
                this.Error_ServiceTitle.Visible = false;

            

            return Flag;
        }
        #endregion

       
        #region buttonOk_Click
        private void buttonOk_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.ValidateForm() == false)
                    return;

            
                dynamic iObj = new ExpandoObject();
                iObj.ActionType = this.EditOrNewFlag ;
                if (this.EditOrNewFlag == "Edit")
                    iObj.Id = this.ServiceId;
                iObj.ServiceGroupId = this.ServiceGroupId;
                iObj.Code = this.ServiceCodeTxt.Text;
                iObj.Title = Publics.FixCharacters(Publics.RemoveSpaces(this.ServiceTitleTxt.Text));
                iObj.Color = Convert.ToInt32(ColorLbl.BackColor.ToArgb());
                iObj.IsToothNumber = Convert.ToBoolean(this.IsToothNumberChk.Checked);
                iObj.IsMoreTooth = Convert.ToBoolean(this.IsMoreToothChk.Checked);
                iObj.IsDeleted = IsActiveChk.Checked == true ? false : true;
                iObj.Comment = Publics.FixCharacters(Publics.RemoveSpaces(this.CommentTxt.Text.Trim().ToString()));
                if (!string.IsNullOrEmpty(this.ServicePriceTxt.Text))
                    iObj.ServiceFreePrice = Convert.ToDouble(this.ServicePriceTxt.Text);

                JsonResponse<dynamic> result = Dentistry.DataProvider.DefineServiceX(iObj);
                if (result != null && result.Success == true)
                {
                    this.ServiceId = result.Data != null ? result.Data : 0;
                    this.DialogResult = DialogResult.OK;
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

      

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ColorLbl_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ColorLbl.BackColor = colorDialog1.Color;
            }
        }

        private void panelControls_Load(object sender, EventArgs e)
        {

        }

        private void dgServiceGroup_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dgServiceGroup.CurrentRow != null) && (((DataGridView)sender).CurrentRow.Selected))
            {
                this.ServiceGroupId = Convert.ToInt32(this.dgServiceGroup.CurrentRow.Cells["ColumnServiceGroupId"].Value);
                this.serviceGroupTitleLbl.Text = Convert.ToString(this.dgServiceGroup.CurrentRow.Cells["ColumnServiceGroupTitle"].Value);
                this.ColorLbl.BackColor =  Color.FromArgb(Convert.ToInt32(this.dgServiceGroup.CurrentRow.Cells["ColumnServiceGroupColor"].Value)) ;

            }
        }

        private void dgServiceGroup_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgServiceGroup.Columns[e.ColumnIndex].Name.Trim().Equals("ColumnColor"))               
            {
                var color = this.dgServiceGroup.Rows[e.RowIndex].Cells["ColumnServiceGroupColor"].Value;
                this.dgServiceGroup.Rows[e.RowIndex].Cells[e.ColumnIndex].Style.BackColor = Color.FromArgb(Convert.ToInt32(color));           
                //this.dgServiceGroup.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = "";
            }
        }

        private void dgServiceGroup_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex != -1 && e.RowIndex != -1 && dgServiceGroup.Columns[e.ColumnIndex].Name.Trim().Equals("ColumnColor"))
            {
               
                  
             
                //Pen for bottom and right borders
                using (var gridlinePen = new Pen(dgServiceGroup.GridColor, 1))
                //Pen for selected cell borders
                using (var borderPen = new Pen(Color.White, 4))
                {
                    var topLeftPoint = new Point(e.CellBounds.Left, e.CellBounds.Top);
                    var topRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Top);
                    var bottomRightPoint = new Point(e.CellBounds.Right - 1, e.CellBounds.Bottom - 1);
                    var bottomleftPoint = new Point(e.CellBounds.Left, e.CellBounds.Bottom - 1);


                    //Paint all parts except borders.
                    e.Paint(e.CellBounds, DataGridViewPaintParts.All & ~DataGridViewPaintParts.Border);

                    //Draw selected cells border here
                    e.Graphics.DrawRectangle(borderPen, new Rectangle(e.CellBounds.Left+2 , e.CellBounds.Top+2 , e.CellBounds.Width-4 , e.CellBounds.Height-4));

              
                    if (e.RowIndex == 0)
                        e.Graphics.DrawLine(gridlinePen, topLeftPoint, topRightPoint);

                    //Left border of first column cells should be in background color
                    if (e.ColumnIndex == 0)
                        e.Graphics.DrawLine(gridlinePen, topLeftPoint, bottomleftPoint);

                    //Bottom border of last row cells should be in gridLine color
                    if (e.RowIndex == dgServiceGroup.RowCount - 1)
                        e.Graphics.DrawLine(gridlinePen, bottomRightPoint, bottomleftPoint);
                    else  //Bottom border of non-last row cells should be in background color
                        e.Graphics.DrawLine(gridlinePen, bottomRightPoint, bottomleftPoint);

                    //Right border of last column cells should be in gridLine color
                    if (e.ColumnIndex == dgServiceGroup.ColumnCount - 1)
                        e.Graphics.DrawLine(gridlinePen, bottomRightPoint, topRightPoint);
                    else //Right border of non-last column cells should be in background color
                        e.Graphics.DrawLine(gridlinePen, bottomRightPoint, topRightPoint);

                 
                    //We handled painting for this cell, Stop default rendering.
                    e.Handled = true;


                }
                    
                
            }
        }
    }
}
