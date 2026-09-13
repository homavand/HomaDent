using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dentistry
{
    public partial class BaseCodingDefine : Form
    {
        public string FormName = "";
        public string TableName = "";
        public string EntityName = "";
        public string ActionType = "New";
        public int Id = 0;
        
        public BaseCodingDefine(string entityName, string formName, string tableName, string actionType, int? id = null)
        {
            InitializeComponent();

            this.Text = formName;
            this.TableName = tableName;
            this.EntityName = entityName;
            this.ActionType = actionType;

            MakeFormByEntity(this.EntityName);

            if (id != null)
            {
                this.Id = id.Value;
                FetchEntityInfo(tableName, this.Id);
            }
                
        }

        public void MakeFormByEntity(string tableName)
        {
            if (this.EntityName == "ServiceGroup")
            {
                ColorPnl.Visible = true;
                Panel1.BringToFront();
            }
            if (this.EntityName == "Branch")
            {
                BankPnl.Visible = true;
                Panel1.BringToFront();

                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.ISBank = true;
                JsonResponse<dynamic> result = DataProvider.LoadFormInitInfo(sObj);
                if (result == null || result.Success == false || result.Data == null)
                    return;

                var dd = result.Data.Bank;
                IEnumerable<dynamic> listBank = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).ToList() : null;

                if (listBank != null)
                {
                    this.BankCbo.DataSource = listBank;
                    this.BankCbo.ValueMember = "Id";
                    this.BankCbo.DisplayMember = "Title";
                }
            }
            
        }

        public void FetchEntityInfo(string tableName , int id)
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.EntityName = tableName;
            sObj.Id = id;
            JsonResponse<dynamic> result = DataProvider.GetBaseCodingX(sObj);
            if (result == null || result.Success == false)
                return;

            var dd = result.Data;
            dynamic obj = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).FirstOrDefault() : null;

            if (obj != null)
            {
                this.CodeTxt.Text = Publics.GetPropertyValue<string>(obj, "Id");
                this.TitleTxt.Text = Publics.GetPropertyValue<string>(obj, "Title");

                if (Publics.GetPropertyValue<bool>(obj, "IsDeleted") == true)
                    this.IsDeActiveChk.Checked = true;
                else
                    this.IsActiveChk.Checked = true;
              

                this.ColorLbl.BackColor = Color.Empty;
                if (this.EntityName == "ServiceGroup")
                {
                    this.ColorLbl.BackColor = obj.Color != null ? Color.FromArgb(Convert.ToInt32((obj.Color.ToString()))) : null;
                }
            }
        }

        #region ValidateForm
        private bool ValidateForm()
        {

            bool Flag = true;
            if (this.TitleTxt.Text.Trim() == string.Empty)
            {
                this.Error_TitleTxt.Visible = true;
                Flag = false;
            }
            else
                this.Error_TitleTxt.Visible = false;


            return Flag;
        }
        #endregion

        private void OkBtn_Click(object sender, EventArgs e)
        {
            try
            {

                if (this.ValidateForm() == false)
                    return;

                dynamic iObj = new ExpandoObject();
                iObj.EntityName = this.TableName;
                iObj.Code = this.CodeTxt.Text;
                iObj.Title = Publics.FixCharacters(Publics.RemoveSpaces(this.TitleTxt.Text.Trim().ToString()));
                iObj.IsDeleted = iObj.IsDeleted = IsActiveChk.Checked == true ? false : true;  

                

                if (this.EntityName == "ServiceGroup")
                {
                    iObj.Color = ColorLbl.BackColor == Color.White ? 0 : Convert.ToInt32(ColorLbl.BackColor.ToArgb());
                }

                if (ActionType == "New")
                {
                }
                if (ActionType == "Edit")
                {
                    iObj.Id = this.Id;
                }


                JsonResponse<dynamic> result = Dentistry.DataProvider.DefineBaseCodingX(iObj);

                if (result != null && result.Success == true && result.Data != null)
                {

                }

                this.Close();
            }
            catch (System.Exception exp)
            {

                ErrorClass.WriteErrorsToFile(this.Name, exp.TargetSite.Name.ToString(), exp.Message, DateTime.Now);
                this.Close();
            }
        }

        private void ColorLbl_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ColorLbl.BackColor = colorDialog1.Color;
            }
        }
    }
}
