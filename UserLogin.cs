using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Dentistry.Class;
using System.Data.SqlClient;
using System.Globalization;
using FarsiMessageBox;
using System.Net.Mail;
using System.Linq;

namespace Dentistry
{
    public partial class UserLogin : Form
    {

        string replay=string.Empty;
        string userPass=string.Empty;
        private int nTry = 0;
        public UserLogin()
        {
            InitializeComponent();
    
        }

    

  
    private void LoginForm_Load(object sender, EventArgs e)
    {
        this.Activate();        
        this.AcceptButton = (Button)this.okBtn;

            this.userNameTxt.Select();
          

        }



 

    private void btnGetPass_Click(object sender, EventArgs e)
    {       
            try
            {
                string email = "";//Convert.ToString(this.sendPassToEmailBtn.Tag);

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("email@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "HomavandDental@gmail.com";
                    mail.Body = "Your Password is : " + Convert.ToString(this.userPassTxt.Tag);
                    mail.IsBodyHtml = true;
                    //mail.Attachments.Add(new Attachment("C:\\file.zip"));

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Port = 25;
                        smtp.UseDefaultCredentials = true;
                        smtp.Credentials = new System.Net.NetworkCredential("HomavandDental@gmail.com", "homavand1344", "smtp.gmail.com");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

          

                
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
    }

        private void okBtn_Click(object sender, EventArgs e)
        {
           
            int? userId = IsAuthentic(this.userNameTxt.Text, this.userPassTxt.Text);
            if (userId != null)
            {
                dynamic sObj = new
                {
                    UserId = userId
                };

                JsonResponse<dynamic> result = Dentistry.DataProvider.GetUserPermissionsX(sObj);
                if (result == null || result.Success == false || result.Data == null)
                    return;

                var dd = result.Data;
                IEnumerable<dynamic> userPermissions = dd != null ? (dd as IEnumerable<dynamic>)
                                                                    .Select(i => new
                                                                    {
                                                                        i.AppActionId,
                                                                        i.Value

                                                                    }).ToList() : Enumerable.Empty<dynamic>();



                Dentistry.AppConfigs.CurrentUserPermissions = userPermissions;

                this.DialogResult = DialogResult.OK;
            }
            else
            {
                if (nTry++ > 2)
                {

                    this.DialogResult = DialogResult.Abort;
                }
                else
                {
                    this.commentTxt.Text = string.Format("...شما {0} فرصت دیگر دارید", (3 - nTry + 1).ToString());
                    // this.DialogResult = DialogResult.Abort;
                }
            }
            
        }

        public int? IsAuthentic(string userName, string userPass)
        {
            try
            {
                if ((userName.Trim() == string.Empty) || (userPass.Trim() == string.Empty))
                    return null;

                JsonResponse<dynamic> result = null;

                dynamic sObj = new
                {
                    IsUserLogin = true,
                    UserName = userName,
                    UserPass = userPass
                };

                result = Dentistry.DataProvider.GetUserX(sObj);

                if (result == null || result.Success == false)
                {
                    return null;
                }

                var dd = result.Data;

                int userCount = dd != null ? Enumerable.Count(dd) : 0;

                if (userCount != 1)
                    return null;

                var userObj = (dd as IEnumerable<dynamic>).Select(i => i).FirstOrDefault();

                if (userObj == null)
                    return null;

                if (Convert.ToBoolean(userObj.IsDeleted) == true)
                {
                    FMessageBox.Show(Dentistry.AppConfigs.strIsDeActiveUser, Dentistry.AppConfigs.strErrorCaption, FMessageBoxButtons.OK, FMessageBoxIcons.Question);
                    return null;
                }

                int userId = userObj.UserId != null ? Convert.ToInt32(userObj.UserId.ToString()) : -1;
                if (userId == -1)
                    return null;


                Dentistry.AppConfigs.CurrentUserId = userId;
                Dentistry.AppConfigs.CurrentUserName = userObj.UserName != null ? userObj.UserName.ToString() : "NullUser";


               

                return userId;
            }catch(Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return null;
            }

        }

     
    }
}