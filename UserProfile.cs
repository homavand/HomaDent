using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using FarsiMessageBox;
using System.Data.SqlClient;
using System.Linq;
using System.Dynamic;

namespace Dentistry
{
    public partial class UserProfile : Form
    {
        public int? UserId = null;
        public UserProfile()
        {
            InitializeComponent();

            this.UserId = Dentistry.AppConfigs.CurrentUserId;

        }

        private void UserProfile_Load(object sender, EventArgs e)
        {
            if (this.UserId != null)
                FetchProfile(this.UserId.Value);
        }

        #region FetchProfile
        private void FetchProfile(int userId)
        {

            dynamic sObj = new
            {
                UserId = userId
            };

            JsonResponse<dynamic> result = Dentistry.DataProvider.GetUserX(sObj);

            if (result == null || result.Success == false || result.Data == null)
                return;

            var dd = result.Data;

            var user = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true)
                                                                                  .Select(i => i).FirstOrDefault() : null;

            if (user == null)
                throw new Exception("خطا در واکشی اطلاعات");


            if (user != null)
            {                 
                this.UserNameTxt.Text   = user.UserName;
                this.textBoxOldPass.Tag = user.UserPass;
                this.EmailTxt.Text      = user.Email;
                    
                //this.FillDataGrideView();               
            }

        }
        #endregion

   

        #region buttonOk_Click
        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!ValidateForm())
                return;

            dynamic iObj = new ExpandoObject();
            iObj.UserId = this.UserId;
            iObj.UserName = UserNameTxt.Text;
            if (this.checkBox.Checked)
                iObj.UserPass = this.textBoxPass.Text;
            iObj.Email = this.EmailTxt.Text.ToString();

            JsonResponse<dynamic> result = Dentistry.DataProvider.DefineUserX(iObj);

            if (result != null && result.Success == true && result.Data != null)
            {
                Dentistry.AppConfigs.CurrentUserName = this.UserNameTxt.Text;

                this.buttonCancel_Click(this, null);
            }

         

        }
        #endregion

        #region buttonCancel_Click
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region ValidateForm
        private bool ValidateForm()
        {

            bool Flag = true;

            //if(string.IsNullOrEmpty(this.textBoxUserName.Text))
            //{
            //    this.Error_NewPass.Visible = true;
            //    Flag = false;
            //}
            //else
            //    this.Error_NewPass.Visible = false;

            if (checkBox.Checked)
            {
                if (String.IsNullOrEmpty(textBoxOldPass.Text))
                {
                    
                    this.Error_OldPass.Visible = true;
                    Flag = false;
                }
                else
                {
                    this.Error_OldPass.Visible = false;
                }
              

                if (String.IsNullOrEmpty(textBoxPass.Text))
                {

                    this.Error_NewPass.Visible = true;
                    Flag = false;
                }
                else
                {
                    this.Error_NewPass.Visible = false;
                }
                if (String.IsNullOrEmpty(textBoxRepeatPass.Text))
                {

                    this.Error_RepeatPass.Visible = true;
                    Flag = false;
                }
                else
                {
                    this.Error_RepeatPass.Visible = false;
                }

                if(Flag)
                if (string.Compare(textBoxOldPass.Text, textBoxOldPass.Tag.ToString(), true) != 0)
                {
                    Error_OldPass_Message.Visible = true;
                    Flag = false;
                }
                else
                {
                    Error_OldPass_Message.Visible = false;
                }

                if (Flag)
                if (string.Compare(this.textBoxPass.Text, this.textBoxRepeatPass.Text) != 0)
                {
                    Error_RepeatPass.Visible = true;
                    Flag = false;
                }
                else
                {
                    Error_RepeatPass.Visible = false;
                }

             
            }

            var email = this.EmailTxt.Text.ToString();
            if (string.IsNullOrEmpty(email) == false)
            {
                
                try
                {
                    var addr = new System.Net.Mail.MailAddress(email);
                    if (addr.Address == email)
                        Error_Email.Visible = false;
                    
                }
                catch
                {
                    Error_Email.Visible = true;
                    Flag = false;
                }

              
            }

            return Flag;
            
        }


        #endregion      

        

        #region tabControl_SelectedIndexChanged
        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Name.ToString() == "tab1")
            {

            }
            else if (tabControl.SelectedTab.Name.ToString() == "tab2")
            {               
                
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox.Checked)
                panelPass.Enabled = true;
            else
            {
                panelPass.Enabled = false;
                foreach(Control ctr in panelPass.Controls)
                  if(ctr is Label)
                      if(ctr.Name.StartsWith("Error"))
                          ctr.Visible=false;
            }
        }
        #endregion

       
       
    }
}
