 using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;
using System.Data.SqlClient;
using System.Runtime.InteropServices;
using FarsiMessageBox;
using System.Threading;
using Dentistry;


namespace Dentistry
{
    public partial class MainForm : Form, IMessageFilter
    {

        private Boolean formClosingFlag = false;
        Button xBtn = null;

        #region FormMain
        public MainForm()
        {
            InitializeComponent();
            
            //this.MinimumSize = new Size(Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
            //this.MaximumSize = new Size(Screen.PrimaryScreen.Bounds.Width, Screen.PrimaryScreen.Bounds.Height);
            //Application.AddMessageFilter(this);
            SetReportFixedValues();
            
        }
        #endregion

        #region Disable MouseWheel in Combobox
        public bool PreFilterMessage(ref Message m)
        {
            if (m.Msg == 0x20a)
            {
                // WM_MOUSEWHEEL, find the control at screen position m.LParam
                Point pos = new Point(m.LParam.ToInt32() & 0xffff, m.LParam.ToInt32() >> 16);
                IntPtr hWnd = WindowFromPoint(pos);
                if (hWnd != IntPtr.Zero && hWnd != m.HWnd && Control.FromHandle(hWnd) != null)
                {
                    SendMessage(hWnd, m.Msg, m.WParam, m.LParam);
                    return true;
                }
            }
            return false;

        }

        [DllImport("user32.dll")]
        private static extern IntPtr WindowFromPoint(Point pt);
        [DllImport("user32.dll")]
        private static extern IntPtr SendMessage(IntPtr hWnd, int msg, IntPtr wp, IntPtr lp);

        #endregion

        #region FormMain_Load
        private void FormMain_Load(object sender, EventArgs e)
        {
            //string s = Properties.Settings.Default.LoginCount.ToString();
            //if (! Publics.CheckLogin())
            //{
            //    FMessageBox.Show("مهلت استفاده آزمایشی از نرم افزار تمام شده است.لطفا جهت خرید نرم افزار با واحد پشتیبانی تماس بگیرید", "خطا", FMessageBoxButtons.OK, FMessageBoxIcons.Error, FMessageBoxDefaultButtons.Button1);
            //    Application.Exit();
            //}


            Dashboard Mdiform = new Dashboard();
            this.FormShow(Mdiform);

            

            // ReminderList.FillReminderList();
            Publics.FetchSettings();
          
            
        }
        #endregion       

        #region FormMain_FormClosing
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                //if(System.Net.Dns.GetHostName().ToLower()!="server")
                //if (this.formClosingFlag == false)
                //{
                //    DialogResult res = FMessageBox.Show("آیا برای خروج اطمینان دارید؟", "خروج؟", FMessageBoxButtons.YesNo, FMessageBoxIcons.Question);
                //    if (res == DialogResult.No)
                //        e.Cancel = true;
                //    else
                //    {
                //        FormBackup FormBackup = new FormBackup();
                //        FormBackup.ShowDialog();
                //        Publics.SaveSettings();
                //    }

                //}


            }
            catch
            {
            }
        }
        #endregion
          
        #region FormShow
        private void FormShow(Form form)
        {

            bool flag;
            flag = CallChildForm(form.Name.ToString());
            if (flag == true)
            {
                form.Activate();
            }
            else
            {
                CloseActiveForm();
                form.MdiParent = this;
                form.Dock = DockStyle.Fill;
                form.Show();
            }

        }
        #endregion
       
        #region CreateInstance
        Object CreateInstance(String name)
        {
            try
            {
                Type type = this.GetType();
                System.Reflection.Assembly assembly = type.Assembly;
                return assembly.CreateInstance(type.Namespace + "." + name, false);
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
                return null;
            }
        }
        #endregion

        #region CallChildForm
        private bool CallChildForm(string formName)
        {


            bool flag = false;

            for (int i = 0; i < this.MdiChildren.Length && flag == false; i++)
                if (this.MdiChildren[i].Name == formName.ToString())
                {
                    flag = true;
                    break;
                }
            return flag;
        }
        #endregion

        #region CloseActiveForm
        private void CloseActiveForm()
        {
            if (this.ActiveMdiChild != null)
                this.ActiveMdiChild.Close();
        }
        #endregion

        #region SetReport
        private void SetReportFixedValues()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            JsonResponse<dynamic> result = Dentistry.DataProvider.GetOfficeInfoX(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;
            int count = System.Linq.Enumerable.Count(result.Data);
            if (count < 1)
                return;
            var rr = result.Data[0];
            if (rr != null)
            {
                Dentistry.AppConfigs.DoctorName    = rr.DoctorName;
                Dentistry.AppConfigs.NezamPezeshki = rr.NezamPezeshki;
                Dentistry.AppConfigs.PhoneNumber   = rr.PhoneNumber;
                Dentistry.AppConfigs.OfficeAddress = rr.OfficeAddress;
            }           
        }
        #endregion

        #region buttonFormGsmAdvanced_Click
        private void buttonFormGsmAdvanced_Click(object sender, EventArgs e)
        {
          

            //MDIForm Mdiform = new MDIForm();
            //this.FormShow(Mdiform);
        }
        #endregion

        private void buttonX_MouseHover(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == this.xBtn)
                return;

            var imgName = ((Button)sender).AccessibleName;
            //imgName = imgName.Substring(0, imgName.Length - 1);
            imgName += "-ON";
            //((Button)sender).Image = Publics.GetImageByName(imgName);
            
            btn.BackColor = Color.Transparent;
            Color color = ColorTranslator.FromHtml("#dbb2ff");
            btn.ForeColor = color;
            btn.FlatAppearance.BorderColor = color; 
        }

        private void buttonX_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn == this.xBtn)
                return;

            var rm = new System.Resources.ResourceManager("Dentistry.Properties.Resources", this.GetType().Assembly);

            var imgName = ((Button)sender).AccessibleName;            
            imgName += "-OFF";
            //((Button)sender).Image = (System.Drawing.Bitmap)rm.GetObject(imgName);


            btn.BackColor = ColorTranslator.FromHtml("#493D57");
            Color color = System.Drawing.Color.FromArgb(((int)(((byte)(205)))), ((int)(((byte)(200)))), ((int)(((byte)(250)))));
            btn.ForeColor = color;
            Color borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(146)))), ((int)(((byte)(141)))), ((int)(((byte)(168)))));
            btn.FlatAppearance.BorderColor = Color.FromArgb(250, borderColor);
            //89, 87, 117
        }

        private void ResetButtons()
        {
            foreach (Control btn in ((Control)this.panelMenu).Controls)
            {
                if (btn is Button)
                {
                    buttonX_MouseLeave(btn, null);
                }
            }


        }

        private void buttonX_Click(object sender, EventArgs e)
        {
            

            Button btn = (Button)sender;
            this.xBtn = btn;

            this.ResetButtons();
            this.buttonX_MouseHover(btn, null);
            //Color color = ColorTranslator.FromHtml("#dbb2ff");
            
            //btn.ForeColor = color;
            //btn.FlatAppearance.BorderColor = color;

            var formName = btn.Tag.ToString().Trim();

            //ResetButton(sender);
            Form form = null;
            switch (formName)
            {                             
                case "SettingsForm":
                    if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.تنظیمات_مشاهده) == false)
                        return;
                    form = new SettingsForm();
                    if (form != null)
                    {
                        this.FormShow(form);
                    }
                    break;
                case "VisitsList":
                    if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.نوبت_دهی_مشاهده) == false)
                        return;
                    form = new VisitsList();
                    form.ShowDialog(this);
                    form.Dispose();
                    break;
              
                case "PatientsList":
                    if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.بیماران_مشاهده) == false)
                        return;
                    form = new PatientsList();
                    if (form != null)
                    {
                        this.FormShow(form);
                    }
                    break;
                case "PatientInfo":
                    if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.بیماران_مشاهده_پرونده_عمومی_بیمار) == false)
                        return;
                    form = new PatientInfo(0);
                    form.ShowDialog(this);
                    form.Dispose();
                    break;
                case "PatientsServices":
                    if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_خدمات__مشاهده) == false)
                        return;
                    form = new PatientServicesFinancialList();
                    if (form != null)
                    {
                        this.FormShow(form);
                    }
                    break;
                case "PatientsFinancials":
                    if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_تراکنش_ها_مشاهده) == false)
                        return;
                    form = new PatientTransactionList();
                    if (form != null)
                    {
                        this.FormShow(form);
                    }
                    break;
                case "Costs":
                    if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_هزینه_ها_مشاهده) == false)
                        return;
                    form = new CostFinancialList();
                    if (form != null)
                    {
                        this.FormShow(form);
                    }
                    break;
                case "InsuranceFinancials":
                    if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_بیمه_ها_مشاهده) == false)
                        return;
                    form = new InsuranceFinancialList();
                    if (form != null)
                    {
                        this.FormShow(form);
                    }
                    break;
                case "Cheques":
                    if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.مدیریت_چک_ها_مشاهده) == false)
                        return;
                    form = new ChequeFinancialList();
                    if (form != null)
                    {
                        this.FormShow(form);
                    }
                    break;
                case "Report":
                    if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.گزارشات_مشاهده) == false)
                        return;
                    form = new ReportList();
                    form.ShowDialog(this);
                    form.Dispose();

                    break;
                default:

                    form = CreateInstance(formName) as Form;
                    if (form != null)
                    {                                              
                        this.FormShow(form);
                    }
                    break;

            }
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
           
            //ControlPaint.DrawBorder(e.Graphics, this.panel2.ClientRectangle,
            //                      color, 5, ButtonBorderStyle.Dotted,
            //                      color, 5, ButtonBorderStyle.Dotted,
            //                      color, 5, ButtonBorderStyle.Dotted,
            //                      color, 5, ButtonBorderStyle.Dotted);




        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            #region 0
            if (e.Control && (e.KeyCode == Keys.D0 || e.KeyCode == Keys.NumPad0))
            {
                buttonX_Click(DashboardBtn, e);
            }
            #endregion

            #region 1
            if (e.Control && (e.KeyCode == Keys.D1 || e.KeyCode == Keys.NumPad1))
            {
                buttonX_Click(SettingBtn, e);
            }
            #endregion

            #region 2
            if (e.Control && (e.KeyCode == Keys.D2 || e.KeyCode == Keys.NumPad2))
            {
                buttonX_Click(VisitBtn, e);
            }
            #endregion

            #region 3
            if (e.Control && (e.KeyCode == Keys.D3 || e.KeyCode == Keys.NumPad3))
            {
                buttonX_Click(PatientBtn, e);
            }
            #endregion

            #region 4
            if (e.Control && (e.KeyCode == Keys.D4 || e.KeyCode == Keys.NumPad4))
            {
                buttonX_Click(PatientsDocsBtn, e);
            }
            #endregion

            #region 5
            if (e.Control && (e.KeyCode == Keys.D5 || e.KeyCode == Keys.NumPad5))
            {
                buttonX_Click(PatientActionsBtn, e);
            }
            #endregion

            #region 6
            if (e.Control && (e.KeyCode == Keys.D6 || e.KeyCode == Keys.NumPad6))
            {
                buttonX_Click(PatientFinancialsBtn, e);
            }
            #endregion

            #region 7
            if (e.Control && (e.KeyCode == Keys.D7 || e.KeyCode == Keys.NumPad7))
            {
                buttonX_Click(CostRegisterBtn, e);
            }
            #endregion

            #region 8
            if (e.Control && (e.KeyCode == Keys.D8 || e.KeyCode == Keys.NumPad8))
            {
                buttonX_Click(InsuranceBtn, e);
            }
            
            #endregion

            #region 9
            if (e.Control && (e.KeyCode == Keys.D9 || e.KeyCode == Keys.NumPad9))
            {
                buttonX_Click(ReportBtn, e);
            }
            #endregion

        }
    }
}



