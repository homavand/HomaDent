using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using FarsiMessageBox;
using PopupControl;
using System.Reflection;
using Stimulsoft.Report;
using System.Dynamic;
using System.Linq;
using System.IO;

namespace Dentistry
{
    public partial class PatientInfo : Form
    {

        public int SelectedTabIndex = 0;
        private DataSet DataSet = new DataSet();
        PopupControl.Popup p1;
        PopupControl.Popup p2;
        int patientId = 0;
        public int DoctorId;
        public int payTypeId = 0;

        public int PatientId
        {
            get { return this.patientId; }
            set
            {
                if (value < 0)
                    this.patientId = 0;
                else
                    this.patientId = value;

                //this.PatientId = Dentistry.Config.SelectedPatientId;
                //if (this.PatientCbo.DataSource != null)
                //    this.PatientCbo.SelectedValue = this.patientId;
                Dentistry.AppConfigs.SelectedPatientId = this.patientId;
                this.PatientCodeTxt.Text = this.PatientId.ToString();
                this.PatientCbo.SelectedIndex = Publics.GetComboIndex(this.PatientCbo, this.patientId);

                this.Cursor = Cursors.WaitCursor;
                try
                {
                    this.GetPatientInfo();
                    this.FillGrid_dgSpecialComment();
                    this.FillGrid_dgPatientSpecialDisease();
                    this.FillGrid_dgPatientSpecialDrugs();

                    // به‌جای this.tab0.Select() + this.tabControl_Selected(this, null)
                    // (که باعث اجرای دوباره‌ی FillGrid_dgPatientServices می‌شد)،
                    // تب رو صرفاً بصری فعال می‌کنیم و منطق لود رو صریح و یک‌بار صدا می‌زنیم
                    this.tabControl.SelectedTab = this.tab0;
                    this.SelectedTabIndex = 0;
                    this.FillGrid_dgPatientServices();
                }
                finally
                {
                    this.Cursor = Cursors.Default;
                }

            }
        }


        public int PayTypeId
        {
            get { return this.payTypeId; }
            set
            {
                if ((int)value < 0 && (int)value > 3)
                    this.payTypeId = 0;

                this.payTypeId = value;
            }
        }

        public PatientInfo(int patientId)
        {
            InitializeComponent();
            this.LoadFormInit();
            this.PatientId = patientId;
        }

        private void PatientInfo_Load(object sender, EventArgs e)
        {            
            this.dgPatientFinancialTransactions.MouseWheel += new MouseEventHandler(dgPatientFinancialTransactions_MouseWheel);
        }

        #region LoadFormInit
        private void LoadFormInit()
        {
            dynamic sObj = new
            {
                IsDeleted = false
            };
            var result = Dentistry.DataProvider.GetAllPatientsFullNamesX(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;

            var patientList = (dd as IEnumerable<dynamic>)
                   .Select(i =>
                   new
                   {
                       Id = (int)i.PatientId,
                       Title = (string)i.PatientName,

                   }).ToList();

            this.PatientCbo.SelectedIndexChanged -= new EventHandler(this.PatientCbo_SelectedIndexChanged);
            this.PatientCbo.TextChanged -= new EventHandler(this.PatientCbo_TextChanged);

            this.PatientCbo.DataSource = patientList;
            this.PatientCbo.ValueMember = "Id";
            this.PatientCbo.DisplayMember = "Title";

            Publics.AutoComplete(this.PatientCbo, patientList);

            this.PatientCbo.SelectedIndexChanged += new EventHandler(this.PatientCbo_SelectedIndexChanged);
            this.PatientCbo.TextChanged += new EventHandler(this.PatientCbo_TextChanged);

            this.PatientCbo.Focus();

        }
        #endregion

        private void dgPatientServices_ColumnOrder()
        {
            dgPatientServices.AutoGenerateColumns = false;
            dgPatientServices.Columns["ColumnPatientServiceId"].Visible = false;
            dgPatientServices.Columns["ColumnCheckupTypeId"].Visible = false;
            dgPatientServices.Columns["ColumnServiceGroupId"].Visible = false;
            dgPatientServices.Columns["ColumnServiceSolarDate"].DisplayIndex = 0;
            dgPatientServices.Columns["ColumnServiceGroupTitle"].DisplayIndex = 1;
            dgPatientServices.Columns["ColumnServiceTite"].DisplayIndex = 2;
            dgPatientServices.Columns["ColumnToothImage"].DisplayIndex = 3;
            dgPatientServices.Columns["ColumnProviderStaffTitle"].DisplayIndex = 4;

            dgPatientServices.Columns["ColumnServicePrice"].DisplayIndex = 5;
            dgPatientServices.Columns["ColumnInsurerPrice"].DisplayIndex = 6;
            dgPatientServices.Columns["ColumnInsurerShare"].DisplayIndex = 7;
            dgPatientServices.Columns["ColumnFranchiseShare"].DisplayIndex = 8;
            dgPatientServices.Columns["ColumnFreeShare"].DisplayIndex = 9;
        }

        private void dgPatientFinancialTransactions_ColumnOrder()
        {
            dgPatientFinancialTransactions.AutoGenerateColumns = false;
            dgPatientFinancialTransactions.Columns["ColumnTransactionSolarDate"].DisplayIndex = 0;
            dgPatientFinancialTransactions.Columns["ColumnTransactionAmount"].DisplayIndex = 1;
            dgPatientFinancialTransactions.Columns["ColumnPayTypeTitle"].DisplayIndex = 2;
            dgPatientFinancialTransactions.Columns["ColumnTransactionComment"].DisplayIndex = 3;

        }

        private void dgPatientDocs_ColumnOrder()
        {
            dgPatientDocs.AutoGenerateColumns = false;
            dgPatientDocs.Columns["ColumnDocumentSolarDate"].DisplayIndex = 0;
            dgPatientDocs.Columns["ColumnDocumentTitle"].DisplayIndex = 1;
            dgPatientDocs.Columns["ColumnDocumentImage"].DisplayIndex = 2;
            dgPatientDocs.Columns["ColumnDocumentComment"].DisplayIndex = 3;

        }



        #region LoadPatientAllInfo
        private void GetPatientInfo()
        {
            if (this.PatientId < 1)
                return;

            dynamic sObj = new
            {
                PatientId = this.PatientId,
            };
            JsonResponse<dynamic> result = DataProvider.GetOnePatientInfoX(sObj); // Patient  &  PatientInsurance
            if (result == null || result.Success == false || result.Data == null)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در واکشی داده ها ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }
            var dd = result.Data;

            dynamic patient = new ExpandoObject();
            patient.PatientId = 0;
            patient.DoctorId = 0;
            patient.PatientName = "";
            patient.NationalCode = "";
            patient.GenderTitle = "";
            patient.Age = "";
            patient.Presenter = "";
            patient.JobTitle = "";
            patient.FixedPhone = "";
            patient.MobilePhone = "";
            patient.Address = "";
            patient.DoctorTitle = "";


            if (dd != null)
            {
                patient = dd;

                if (patient == null)
                {
                    return;
                }

                this.DoctorId = patient.DoctorId;
            }

           

            List<KeyValuePair<string, string>> list = new List<KeyValuePair<string, string>>()
            {
                new KeyValuePair<string, string>("پزشک بیمار  ", Convert.ToString(patient.DoctorTitle)),
                new KeyValuePair<string, string>("كد بیمار  ", Convert.ToString(patient.PatientId)),
                new KeyValuePair<string, string>("نام بیمار", Convert.ToString(patient.PatientName)),
                new KeyValuePair<string, string>("كد ملی", Convert.ToString(patient.NationalCode)),
                new KeyValuePair<string, string>("معرف", Convert.ToString(patient.Presenter)),
                new KeyValuePair<string, string>("شغل", Convert.ToString(patient.JobTitle)),
                new KeyValuePair<string, string>("جنسیت :",  Convert.ToString(patient.GenderTitle)),
                new KeyValuePair<string, string>("سن", Convert.ToString(patient.Age)),
                new KeyValuePair<string, string>(" تلفن ثابت", Convert.ToString(patient.FixedPhone)),
                new KeyValuePair<string, string>("تلفن همراه", Convert.ToString(patient.MobilePhone)),
                new KeyValuePair<string, string>("آدرس", Convert.ToString(patient.Address)),
                new KeyValuePair<string, string>("بیمه گر پایه", Convert.ToString(Convert.ToString(patient.BI_InsurerTitle))),
                new KeyValuePair<string, string>("تاریخ انقضا",  Convert.ToString(patient.BI_ExpirationSolarDate)),


            };

            this.dgPatientInfo.DataSource = list;
            dgPatientInfo.CurrentCell = null;
            this.dgPatientInfo.Tag = patient;

            // ActionTypeRdo2.Checked = true; به PatientId setter منتقل شد
            // تا فقط یک‌بار ست بشه و رویداد CheckedChanged باعث فراخوانی اضافه‌ی
            // FillGrid_dgPatientServices نشه.
        }
        #endregion

        #region FillGrid_dgPatientServices
        private void FillGrid_dgPatientServices()
        {
            var swTotal = System.Diagnostics.Stopwatch.StartNew();
            var log = new System.Text.StringBuilder();

            this.dgPatientServices_ColumnOrder();

            int checkupTypeId = 2;

            dynamic sObj = new ExpandoObject();
            sObj.PatientId = this.PatientId;
            sObj.CheckupTypeId = checkupTypeId;

            var sw = System.Diagnostics.Stopwatch.StartNew();
            JsonResponse<dynamic> result = Dentistry.DataProvider.GetPatientServicesX(sObj);
            log.AppendLine("A. GetPatientServicesX() call: " + sw.ElapsedMilliseconds + " ms");

            if (result == null || result.Success == false)
                return;
            var dd = result.Data;

            if (dd == null)
                return;

            sw.Restart();
            var rawList = (dd as IEnumerable<dynamic>).ToList();
            log.AppendLine("B. Materialize dd to List (" + rawList.Count + " rows): " + sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            var patientServiceObjs = rawList.Select(i => new Class.PatientService(i)).ToList();
            log.AppendLine("C. new Class.PatientService(i) for all rows: " + sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            var patientServiceList = patientServiceObjs
                .Select(i =>
                new
                {
                    i.Id,
                    i.DoctorId,
                    i.ServiceGroupId,
                    i.ServiceGroupTitle,
                    i.ServiceTitle,
                    i.ProviderStaffTitle,
                    i.ServicePrice,
                    i.InsurerPrice,
                    i.InsurerShare,
                    i.FranchiseShare,
                    i.FreeShare,
                    i.SolarDateTime,
                    i.Comment,
                    i.CheckupTypeCode,
                    i.ToothImage,   // <-- suspect: decodes/resizes an image per row, no caching
        }).ToList();
            log.AppendLine("D. Project incl. .ToothImage (image decode) for all rows: " + sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            this.dgPatientServices.DataSource = patientServiceList;
            log.AppendLine("E. Set DataSource: " + sw.ElapsedMilliseconds + " ms");

            sw.Restart();
            this.dgPatientServices.Refresh();
            log.AppendLine("F. dgPatientServices.Refresh(): " + sw.ElapsedMilliseconds + " ms");

            log.AppendLine("TOTAL: " + swTotal.ElapsedMilliseconds + " ms");

            try
            {
                System.IO.File.AppendAllText(@"C:\temp\perf_log_grid.txt",
                    "==== " + DateTime.Now.ToString("HH:mm:ss.fff") + " ====\r\n" + log.ToString() + "\r\n");
            }
            catch { /* ignore logging failures */ }
        }
        private void FillGrid_dgPatientServices2()
        {
            this.dgPatientServices_ColumnOrder();


            int checkupTypeId = 2;

            dynamic sObj = new ExpandoObject();
            sObj.PatientId = this.PatientId;
            sObj.CheckupTypeId = checkupTypeId;

            JsonResponse<dynamic> result = Dentistry.DataProvider.GetPatientServicesX(sObj);

            if (result == null || result.Success == false || result.Data == null)
                return;
            var dd = result.Data;

            
            IEnumerable<dynamic> patientServiceList = dd != null && (Enumerable.Count(dd) >= 0) ? (dd as IEnumerable<dynamic>)
                .Select(i => new Class.PatientService(i))
                   .Select(i =>
                   new
                   {
                       i.Id,
                       i.DoctorId,
                       i.ServiceGroupId,
                       i.ServiceGroupTitle,
                       i.ServiceTitle,
                       i.ProviderStaffTitle,
                       i.ServicePrice,
                       i.InsurerPrice,
                       i.InsurerShare,
                       i.FranchiseShare,
                       i.FreeShare,


                       i.SolarDateTime,
                       i.Comment,
                       i.CheckupTypeCode,
                       i.ToothImage,
                   }).ToList() : Enumerable.Empty<dynamic>();



            this.dgPatientServices.DataSource = patientServiceList;
            this.dgPatientServices.Refresh();

        }
        #endregion


        #region linkLabelBaraat_LinkClicked
        private void linkLabelBaraat_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {



        }



        #endregion

        #region textBox_TextChanged
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            ((TextBox)sender).Text = (((TextBox)sender).Text != "0") ? ((TextBox)sender).Text : string.Empty;
        }
        #endregion




        private void PatientCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PatientCbo.SelectedValue == null || PatientCbo.SelectedValue == (object)-1)
                return;

            var patientId = Convert.ToInt32(this.PatientCbo.SelectedValue);

            if (this.PatientId != patientId)
                this.PatientId = patientId;

        }

        private void PatientCbo_TextChanged(object sender, EventArgs e)
        {
            if (this.PatientCbo.SelectedValue == null)
                return;

            var patientId = Convert.ToInt32(this.PatientCbo.SelectedValue);

            if (this.PatientId != patientId)
                this.PatientId = patientId;

        }


        private void dgActionX_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.ButtonEdit0_Click(this, null);
        }



        #region ButtonNew0_Click
        private void ButtonNew0_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار__درمان_های_انجام_شده_بیمار_جدید) == false)
                return;

            int patientId = Convert.ToInt32(this.PatientCbo.SelectedValue);
            if (patientId < 1)
                return;


            int checkupTypeId = 2;                                

            PatientServiceDefine form = new PatientServiceDefine(this.PatientId, checkupTypeId);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                this.FillGrid_dgPatientServices();
            form.Dispose();

        }
        #endregion

        #region ButtonEdit0_Click
        private void ButtonEdit0_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار__درمان_های_انجام_شده_بیمار_ویرایش) == false)
                return;

            if (this.dgPatientServices.CurrentCell == null)
                return;

          
            int checkupTypeId = 2;

            var patientServiceId = Convert.ToInt32(this.dgPatientServices["ColumnPatientServiceId", this.dgPatientServices.CurrentRow.Index].Value);

            PatientServiceDefine form = new PatientServiceDefine(this.PatientId, checkupTypeId, patientServiceId);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                this.FillGrid_dgPatientServices();
            form.Dispose();

        }
        #endregion

        #region ButtonDelete0_Click
        private void ButtonDelete0_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار__درمان_های_انجام_شده_بیمار_حذف) == false)
                return;

            if (dgPatientServices.CurrentCell == null)
                return;

            try
            {
                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    dynamic iObj = new ExpandoObject();
                    iObj.ActionType = "Delete";
                    iObj.PatientServiceId = Convert.ToInt32(dgPatientServices.CurrentRow.Cells["ColumnPatientServiceId"].Value);
                    iObj.IsDeleted = true;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientServiceX(iObj);
                    if (result != null && result.Success == true)
                    {
                        this.FillGrid_dgPatientServices();
                    }

                }
            }
            catch (System.Exception exp)
            {

                MessageBox.Show(exp.Message);


            }
        }
        #endregion



        private void ServiceGroupCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.FillGrid_dgPatientServices();
        }

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            if (tabControl.SelectedTab.Name.ToString() == "tab0")
            {
                this.SelectedTabIndex = 0;
                this.FillGrid_dgPatientServices();
            }


            if (tabControl.SelectedTab.Name.ToString() == "tab1")
            {
                this.SelectedTabIndex = 2;
                this.FillGrid_dgPatientFinancialTransactions();
            }

            if (tabControl.SelectedTab.Name.ToString() == "tab2")
            {
                this.SelectedTabIndex = 3;
                this.FillGrid_dgPatientDocs();
            }
        }

        private void BaraatBtn_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_مشاهده_فرم_برائت_بیمار) == false)
                return;

            if (Convert.ToInt32(this.PatientCbo.SelectedValue) < 1)
                return;
            try
            {

                dynamic sObj = new
                {
                    PatientId = this.PatientId,
                };
                var result = Dentistry.DataProvider.GetOnePatientInfoX(sObj); // Patient  &  PatientInsurance
                if (result == null || result.Success == false || result.Data == null)
                    return;
                var patient = result.Data;


                sObj = new
                {
                    PatientId = patientId,
                };
                result = Dentistry.DataProvider.GetPatientTransactionsX(sObj);
                if (result == null || result.Success == false || result.Data == null)
                    return;
                var patientFinancial = result.Data;

                sObj = new
                {
                    PatientId = patientId,
                };
                result = Dentistry.DataProvider.GetPatientSpecialDrug(sObj);
                if (result == null || result.Success == false || result.Data == null)
                    return;
                var patientSpecialDrug = (Enumerable.Count(result.Data) > 0) ? (result.Data as IEnumerable<dynamic>).Where(i => i.IsCheck == true).Select(i => i).ToList() : null;

                sObj = new
                {
                    PatientId = patientId,
                };
                result = Dentistry.DataProvider.GetPatientSpecialDiseases(sObj);
                if (result == null || result.Success == false || result.Data == null)
                    return;
                var patientSpecialDiseases = (Enumerable.Count(result.Data) > 0) ? (result.Data as IEnumerable<dynamic>).Where(i => i.IsCheck == true).Select(i => i).ToList() : null;


                frm_Report fr_report = new frm_Report();
                List<object> param = new List<object>();
                List<object> value = new List<object>();

                var data = new
                {
                    Patient = patient,
                    PatientInsurance = patient,
                    PatientFinancial = patientFinancial,
                    PatientSpecialIllness = patientSpecialDiseases,
                    PatientSpecialDrug = patientSpecialDrug,
                };

                fr_report.RunReport("rpt_PatientBaraat", param, value, data);
                fr_report.ShowDialog();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }


        #region PatientSpecialComments

        #region FillGrid_dgSpecialComment
        public void FillGrid_dgSpecialComment()
        {
            dynamic sObj = new
            {
                PatientId = this.PatientId,
                IsDeleted = false
            };
            var result = Dentistry.DataProvider.GetPatientSpecialCommentsX(sObj);
            if (result != null && result.Success == false && result.Data == null)
                return;

            var dd = result.Data;

            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0)
                                        ? (dd as IEnumerable<dynamic>).OrderByDescending(i => i.Date)
                                                                      .Select(i => new
                                                                      {
                                                                          i.Id,
                                                                          Title = (int)i.SpecialCommentTypeId == 0 ? (string)i.Title : string.Format("{0} : {1}", (string)i.SpecialCommentTypeTitle, (string)i.Title),
                                                                          i.SolarDate
                                                                      }
                                                                      ).ToList()
                                        : Enumerable.Empty<dynamic>();

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("SolarDate", typeof(string));
            dt.Columns.Add("Title", typeof(string));

            foreach (var item in list)
                dt.Rows.Add(
                    item.Id,
                    item.SolarDate,
                    item.Title
                    );

            //this.dgSpecialComment.SelectionChanged -= new System.EventHandler(this.dgSpecialComment_SelectionChanged); 
            this.dgSpecialComment.DataSource = dt;
            this.dgSpecialComment.CurrentCell = null;

            //this.dgSpecialComment.SelectionChanged += new System.EventHandler(this.dgSpecialComment_SelectionChanged);
        }
        #endregion

        #region dgSpecialComment_SelectionChanged
        private void dgSpecialComment_SelectionChanged(object sender, EventArgs e)
        {
            if (this.PatientId == 0)
            {
                //this.dgSpecialComment.CurrentCell = null;
                this.SpecialCommentsBtnNew.Enabled = false;
                this.SpecialCommentsBtnEdit.Enabled = false;
                this.SpecialCommentsBtnDelete.Enabled = false;
                return;

            }
            if ((this.dgSpecialComment.CurrentCell != null) && (this.dgSpecialComment.CurrentRow.Selected))
            {
                this.SpecialCommentsBtnEdit.Enabled = true;
                this.SpecialCommentsBtnDelete.Enabled = true;
            }
            else
            {
                this.SpecialCommentsBtnEdit.Enabled = false;
                this.SpecialCommentsBtnDelete.Enabled = false;

            }
        }
        #endregion

        #region SpecialCommentsBtnNew_Click
        private void SpecialCommentsBtnNew_Click(object sender, EventArgs e)
        {

            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_ملاحضات_ویژه_جدید) == false)
                return;

            if (this.PatientId == 0)
                return;


            PatientSpecialCommentDefine form = new PatientSpecialCommentDefine(this.PatientId);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                this.FillGrid_dgSpecialComment();
            form.Dispose();

        }



        #endregion

        #region SpecialCommentsBtnEdit_Click
        private void SpecialCommentsBtnEdit_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_ملاحضات_ویژه_ویرایش) == false)
                return;

            if (this.dgSpecialComment.CurrentCell != null)
            {
                if (this.PatientId == 0)
                    return;


                var id = Convert.ToInt32(dgSpecialComment.CurrentRow.Cells["ColumnId"].Value);

                PatientSpecialCommentDefine form = new PatientSpecialCommentDefine(this.PatientId, id);
                form.ShowDialog(this);
                form.Dispose();
                this.FillGrid_dgSpecialComment();
            }
            else
            {
                FarsiMessageBox.FMessageBox.Show(" لطفا رکوردی را برای ویرایش انتخاب نمایید", " هشدار ", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
            }
        }
        #endregion

        #region SpecialCommentsBtnDelete_Click
        private void SpecialCommentsBtnDelete_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_ملاحضات_ویژه_حذف) == false)
                return;

            try
            {

                if (this.dgSpecialComment.CurrentCell == null)
                    return;

                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    var id = Convert.ToInt32(dgSpecialComment.CurrentRow.Cells["ColumnId"].Value);

                    dynamic iObj = new System.Dynamic.ExpandoObject();
                    iObj.ActionType = "Delete";
                    iObj.Id = id;
                    iObj.PatientId = this.PatientId;
                    iObj.IsDeleted = true;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefineSpecialCommentX(iObj);
                    if (result != null && result.Success == true)
                    {
                        this.FillGrid_dgSpecialComment();
                    }

                    this.dgSpecialComment_SelectionChanged(this, null);
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message);
                this.Close();
            }
        }
        #endregion

        #endregion


        #region PatientSpecialDrugs

        #region  FillGrid_PatientSpecialDrugs
        private void FillGrid_dgPatientSpecialDrugs()
        {
            dynamic sObj = new
            {
                PatientId = this.PatientId,
            };
            var result = Dentistry.DataProvider.GetPatientSpecialDrug(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;

            IEnumerable<dynamic> list = (dd != null && Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Where(i => i.IsCheck == true).Select(i => i).ToList() : null;
            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("IsCheck", typeof(bool));
            dt.Columns.Add("Title", typeof(string));



            foreach (var item in list)
                dt.Rows.Add(
                    item.Id,
                    item.IsCheck,
                    item.Title
                    );

            this.dgPatientSpecialDrugs.DataSource = dt;
            this.dgPatientSpecialDrugs.CurrentCell = null;


        }
        #endregion

        #region PatientSpecialDrugsBtn_Clicked
        private void PatientSpecialDrugsBtn_Clicked(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_داروهای_خاص_انتخاب_و_حذف_دارو) == false)
                return;

            if (this.PatientId == 0)
                return;

            int x1 = 0, y1 = 0;
            if (p1 == null)
            {
                SelectSpecialDrugList form = new SelectSpecialDrugList(this.PatientId);

                p1 = new PopupControl.Popup(form.panel_Drug);
                p1.Closed += new ToolStripDropDownClosedEventHandler(p1_Closed2);
                x1 = form.panel_Drug.Width;
                y1 = form.panel_Drug.Height;
                p1.ShowingAnimation = p1.HidingAnimation = PopupAnimations.None;

            }
            p1.Hide();
            p1.Show(MousePosition.X, MousePosition.Y - y1 / 2);
            p1 = null;


        }

        void p1_Closed2(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.FillGrid_dgPatientSpecialDrugs();
        }
        #endregion

        #region dgPatientSpecialDrugs_SelectionChanged
        private void dgPatientSpecialDrugs_SelectionChanged(object sender, EventArgs e)
        {
            if (this.PatientId == 0)
            {
                this.dgPatientSpecialDrugs.CurrentCell = null;
                this.PatientSpecialDrugsBtn.Enabled = false;
                return;

            }
        }
        #endregion

        #endregion

        #region PatientSpecialDisease

        #region  FillGrid_dgPatientSpecialDisease
        private void FillGrid_dgPatientSpecialDisease()
        {
            dynamic sObj = new
            {
                PatientId = this.PatientId,
            };
            var result = Dentistry.DataProvider.GetPatientSpecialDiseases(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;
            IEnumerable<dynamic> list = (dd != null && Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Where(i => i.IsCheck == true).Select(i => i).ToList() : null;

            DataTable dt = new DataTable();
            dt.Columns.Add("Id", typeof(int));
            dt.Columns.Add("IsCheck", typeof(bool));
            dt.Columns.Add("Title", typeof(string));

            foreach (var item in list)
                dt.Rows.Add(
                    item.Id,
                    item.IsCheck,
                    item.Title
                    );

            this.dgPatientSpecialDisease.DataSource = dt;
            this.dgPatientSpecialDisease.CurrentCell = null;


        }
        #endregion

        #region PatientSpecialDiseaseBtn_Clicked
        private void PatientSpecialDiseaseBtn_Clicked(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_بیماریهای_خاص_انتخاب_و_حذف_بیماری) == false)
                return;

            if (this.PatientId == 0)
                return;

            int x1 = 0, y1 = 0;
            if (p2 == null)
            {
                SpecialDiseaseList FormSelectIllness = new SpecialDiseaseList(this.PatientId);

                p2 = new PopupControl.Popup(FormSelectIllness.panel_Illness);
                p2.Closed += new ToolStripDropDownClosedEventHandler(p2_Closed1);
                x1 = FormSelectIllness.panel_Illness.Width;
                y1 = FormSelectIllness.panel_Illness.Height;
                p2.ShowingAnimation = p2.HidingAnimation = PopupAnimations.None;

            }
            p2.Hide();
            p2.Show(MousePosition.X, MousePosition.Y - y1 / 2);
            p2 = null;




        }

        void p2_Closed1(object sender, ToolStripDropDownClosedEventArgs e)
        {
            this.FillGrid_dgPatientSpecialDisease();
        }
        #endregion

        #region dataGridViewIll_Illness_SelectionChanged
        private void dgPatientSpecialDisease_SelectionChanged(object sender, EventArgs e)
        {
            if (this.PatientId == 0)
            {
                this.dgPatientSpecialDisease.CurrentCell = null;
                this.PatientSpecialDiseaseBtn.Enabled = false;
                return;

            }
        }
        #endregion

        #endregion

        #region PatientFinancialTransactions

        #region FillGrid_dgPatientFinancialTransactions
        private void FillGrid_dgPatientFinancialTransactions()
        {
            this.dgPatientFinancialTransactions_ColumnOrder();

            if (this.PatientId == 0)
            {
                this.TotalDiscountTxt.Text = string.Empty;
                this.TotalRemianedTxt.Text = string.Empty;
                this.TotalPayableTxt.Text = string.Empty;
                this.TotalPriceTxt.Text = string.Empty;

                return;
            }

            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.PatientId = this.PatientId;

            //if ((this.FromDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.FromDateTxt.Value.ToString())))
            //    sObj.FromDate = Class.Date.ToChristianByTime(this.FromDateTxt.Value.ToString());

            //if ((this.ToDateTxt.Value.ToString() != string.Empty) && (Class.Date.IsValid(this.ToDateTxt.Value.ToString())))
            //    sObj.ToDate = Class.Date.ToChristianByTime(this.ToDateTxt.Value.ToString());

            if (this.PayTypeId != 0)
                sObj.PayTypeId = this.PayTypeId;

            var data = DataProvider.GetPatientTransactionsX(sObj);
            var dd = data != null && data.Data != null ? data.Data : null;

            Func<dynamic, string> GetComment = (dynamic obj) =>
            {
                int payTypeId = Publics.GetPropertyValue<int>(obj, "PayTypeId");
                string comment = Publics.GetPropertyValue<string>(obj, "Comment");
                string commentX = "";

                switch (payTypeId)
                {
                    case 1:
                        commentX = comment;
                        break;
                    case 2:
                        commentX = comment;
                        break;
                    case 3:
                        string chequeNumber = Publics.GetPropertyValue<string>(obj, "ChequeNumber");
                        string solarDateOfMaturity = Publics.GetPropertyValue<string>(obj, "SolarDateOfMaturity");
                        commentX = string.Format("{0} ({1}: {2}  -  {3}: {4})", comment, "شماره چک", chequeNumber, "تاریخ سررسید", solarDateOfMaturity);
                        break;
                    case 4:
                        commentX = comment;
                        break;
                }


                return commentX;
            };

            IEnumerable<dynamic> transactionList = dd != null && (Enumerable.Count(dd) >= 0) ? (dd as IEnumerable<dynamic>)
                  .Select(i =>
                  new
                  {
                      PatientFinancialId = (int)i.PatientFinancialId,
                      PayTypeId = (int)i.PayTypeId,
                      SolarDate = (string)i.SolarDate,
                      Amount = (decimal)i.Amount,
                      PayTypeTitle = (string)i.PayTypeTitle,
                      Comment = GetComment(i),
                  }).ToList() : Enumerable.Empty<dynamic>();



            this.dgPatientFinancialTransactions.DataSource = transactionList;



            data = DataProvider.GetPatientBillX(sObj);
            var ff = data != null && data.Data != null ? data.Data : null;

            this.TotalPriceTxt.Text = Publics.ToRial(Publics.GetPropertyValue<int>(ff, "Total_Patient_Charge"));
            this.TotalPayableTxt.Text = Publics.ToRial(Publics.GetPropertyValue<int>(ff, "Total_Patient_Paid"));
            this.TotalDiscountTxt.Text = Publics.ToRial(Publics.GetPropertyValue<int>(ff, "Total_Patient_Discount"));
            this.TotalRemianedTxt.Text = Publics.ToRial(Publics.GetPropertyValue<int>(ff, "Total_Patient_Remianed"));




        }
        #endregion

        #region dgPatientFinancialTransactions_CellDoubleClick
        private void dgPatientFinancialTransactions_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.ButtonEdit1_Click(this, null);
        }
        #endregion

        #region dgPatientFinancialTransactions_SelectionChanged
        private void dgPatientFinancialTransactions_SelectionChanged(object sender, EventArgs e)
        {

            if ((this.dgPatientFinancialTransactions.CurrentCell != null) && (this.dgPatientFinancialTransactions.CurrentRow.Selected))
            {
                this.ButtonEdit1.Enabled = true;
                this.ButtonDelete1.Enabled = true;
            }
            else
            {
                this.ButtonEdit1.Enabled = false;
                this.ButtonDelete1.Enabled = false;

            }

        }
        #endregion

        #region dgPatientFinancialTransactions_MouseWheel
        private void dgPatientFinancialTransactions_MouseWheel(object sender, MouseEventArgs e)
        {
            if (this.dgPatientFinancialTransactions.CurrentCell == null)
                return;
            dgPatientFinancialTransactions.EndEdit();
            if (e.Delta.Equals(120) && dgPatientFinancialTransactions.CurrentRow.Index != 0)
                SendKeys.Send("{Up}");

            else if (!e.Delta.Equals(120) && dgPatientFinancialTransactions.CurrentRow.Index != dgPatientFinancialTransactions.Rows.Count - 1)

                SendKeys.Send("{Down}");
        }
        #endregion

        #region PayTypeRdo_CheckedChanged
        private void PayTypeRdo_CheckedChanged(object sender, EventArgs e)
        {

            RadioButton rdoX = sender as RadioButton;
            if (rdoX == null || rdoX.Checked != true)
                return;

            var pnlList = this.PayTypePnl.Controls.OfType<UserControls.ExPanel>().ToList();

            foreach (var pnl in pnlList)
            {
                if (pnl != null)
                {
                    RadioButton rdo = pnl.Controls.OfType<RadioButton>().FirstOrDefault();

                    if (rdo != null && rdo != rdoX)
                        rdo.Checked = false;
                }
            }

            object tag = rdoX.Tag;
            if (tag == null)
                return;

            int val = Convert.ToInt32(tag);

            switch (val)
            {
                case 0:
                    this.PayTypeId = 0;
                    break;
                case 1:
                    this.PayTypeId = 1;
                    break;
                case 2:
                    this.PayTypeId = 2;
                    break;
                case 3:
                    this.PayTypeId = 3;
                    break;
                case 4:
                    this.PayTypeId = 4;
                    break;
                case 5:
                    this.PayTypeId = 4;
                    break;
                case 6:
                    this.PayTypeId = 4;
                    break;
                default:
                    this.PayTypeId = 5;
                    break;
            }


            this.FillGrid_dgPatientFinancialTransactions();

        }
        #endregion


        #region ButtonNew1_Click
        private void ButtonNew1_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_تراکنش_های_مالی_بیمار_جدید) == false)
                return;

            try
            {

                PatientFinancialDefine form = new PatientFinancialDefine(this.PatientId);
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                    this.FillGrid_dgPatientFinancialTransactions();
                form.Dispose();


            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }
        }
        #endregion 

        #region ButtonEdit1_Click
        private void ButtonEdit1_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_تراکنش_های_مالی_بیمار_ویرایش) == false)
                return;

            try
            {

                if (this.dgPatientFinancialTransactions.CurrentCell == null)
                    return;

                PatientFinancialDefine form = new PatientFinancialDefine(this.PatientId, Convert.ToInt32(this.dgPatientFinancialTransactions["ColumnPatientFinancialId", this.dgPatientFinancialTransactions.CurrentRow.Index].Value));
                var result = form.ShowDialog(this);
                if (result == DialogResult.OK)
                    this.FillGrid_dgPatientFinancialTransactions();
                form.Dispose();

            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.ToString());
                this.Close();
            }

        }
        #endregion

        #region ButtonDelete1_Click
        private void ButtonDelete1_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_تراکنش_های_مالی_بیمار_حذف) == false)
                return;

            if (this.dgPatientFinancialTransactions.CurrentCell == null)
                return;

            try
            {


                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    dynamic iObj = new ExpandoObject();
                    iObj.ActionType = "Delete";
                    iObj.Id = Convert.ToInt32(dgPatientFinancialTransactions.CurrentRow.Cells["ColumnPatientFinancialId"].Value);
                    iObj.IsDeleted = true;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientFinancialX(iObj);
                    if (result != null && result.Success == true)
                    {
                        this.FillGrid_dgPatientFinancialTransactions();
                    }

                }
            }
            catch (System.Exception exp)
            {

                MessageBox.Show(exp.Message);


            }


        }
        #endregion

        #region buttonSuratHesab_Click      
        private void ButtonSuratHesab_Click(object sender, EventArgs e)
        {

            frm_Report fr_report = new frm_Report();
            List<object> param = new List<object>();
            List<object> value = new List<object>();


            param.Add("ReportTitle");
            value.Add("صورتحساب بیمار");


            dynamic sObj = new
            {
                PatientId = this.PatientId,
                CheckupTypeId = 2
            };
           
            var result = Dentistry.DataProvider.GetOnePatientInfoX(sObj); // Patient  &  PatientInsurance
            if (result == null || result.Success == false || result.Data == null)
                return;
            var dd = result.Data;

            var patient = dd;

            sObj = new
            {
                PatientId = patientId,
            };
            result = Dentistry.DataProvider.GetPatientTransactionsX(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;
            var patientFinancial = result.Data;



            result = Dentistry.DataProvider.GetPatientServicesX(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;
            dd = result.Data;

            var patientServices = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>)
                                    .Select(i =>
                                    new Class.PatientService(i))
                                    .Select(i =>
                                        new
                                        {
                                            PatientServiceId = (int)i.Id,
                                            i.ServiceTitle,
                                            i.SolarDate,
                                            i.ServicePrice,
                                            i.Tooth,
                                            i.ToothImage,

                                        }).ToList() : null;



            var data = new
            {
                Patient = patient,
                PatientInsurance = patient,
                patientFinancial = patientFinancial,
                PatientServices = patientServices
            };
            fr_report.RunReport("rpt_PatientBill", param, value, data);
            fr_report.ShowDialog();
        }
        #endregion       

        private void BottonFish_Click(object sender, EventArgs e)
        {
            if (this.dgPatientFinancialTransactions.CurrentCell == null)
                return;

            var payId = Convert.ToInt32(this.dgPatientFinancialTransactions["ColumnPatientFinancialId", this.dgPatientFinancialTransactions.CurrentRow.Index].Value);

            frm_Report fr_report = new frm_Report();
            List<object> param = new List<object>();
            List<object> value = new List<object>();


            param.Add("PayId");
            value.Add(payId);

            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.Id = payId;

            var data = Dentistry.DataProvider.GetPatientTransactionsX(sObj);

            fr_report.RunReport("rpt_PatientFish", param, value, data.Data);
            fr_report.ShowDialog();
        }

        #region labelstale_TextChanged
        private void labelstale_TextChanged(object sender, EventArgs e)
        {
            if (this.TotalRemianedTxt.Text.Trim() != string.Empty)
                if (this.TotalRemianedTxt.Text.Trim().StartsWith("-"))
                {
                    this.TotalRemianedTxt.Text = this.TotalRemianedTxt.Text.TrimStart('-');
                    this.TotalRemianedTxt.ForeColor = Color.DeepSkyBlue;
                }
                else
                    this.TotalRemianedTxt.ForeColor = Color.DeepPink;

        }

        #endregion

        #endregion


        #region FillGrid_dgPatientDocs
        private void FillGrid_dgPatientDocs()
        {
            try
            {

                this.dgPatientDocs_ColumnOrder();
                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.PatientId = this.PatientId != 0 ? this.PatientId : (int?)null;

                JsonResponse<dynamic> result = Dentistry.DataProvider.GetPatientDocsX(sObj);


                if (result == null || result.Success != true && result.Data == null)
                    return;

                var dd = result.Data;
                IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Where(i => Convert.ToBoolean(i.IsDeleted) != true).Select(i =>
                    new
                    {
                        PatientDocumentId = (int)i.DocId,
                        SolarDate = (string)i.SolarDate,
                        Title = (string)i.Title,
                        ImagePath = (string)i.ImagePath,
                        Image = (byte[])i.Image,
                        Comment = (string)i.Comment,
                    }
                ).ToList() : Enumerable.Empty<dynamic>();



                this.dgPatientDocs.DataSource = list;
            }
            catch (System.Exception exp)
            {
                this.Close();
            }
        }
        #endregion


        private void dgPatientDocs_SelectionChanged(object sender, EventArgs e)
        {
            if ((this.dgPatientDocs.CurrentCell != null) && (this.dgPatientDocs.CurrentRow.Selected))
            {
                this.ButtonNew2.Enabled = true;
                this.ButtonEdit2.Enabled = true;
                this.ButtonDelete2.Enabled = true;
                this.ButtonPictureViewer.Enabled = true;
            }
            else
            {
                this.ButtonEdit2.Enabled = false;
                this.ButtonDelete2.Enabled = false;
                this.ButtonPictureViewer.Enabled = false;
                if (this.PatientCbo.SelectedIndex == -1)
                    this.ButtonNew2.Enabled = false;
                else
                    this.ButtonNew2.Enabled = true;
            }
        }

        private void dgPatientDocs_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            this.ButtonEdit2_Click(this, null);
        }

        private void ButtonNew2_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_اسناد_پزشکی_بیمار_جدید) == false)
                return;

            if (this.PatientCbo.SelectedIndex == -1)
                return;

            PatientDocDefine form = new PatientDocDefine(this.PatientId, this.PatientCbo.Text);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                this.FillGrid_dgPatientDocs();
            form.Dispose();

        }

        private void ButtonEdit2_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_اسناد_پزشکی_بیمار_ویرایش) == false)
                return;

            if (this.PatientCbo.SelectedIndex == -1)
                return;

            int id = Convert.ToInt32(this.dgPatientDocs["ColumnPatientDocumentId", this.dgPatientDocs.CurrentRow.Index].Value);
            PatientDocDefine form = new PatientDocDefine(id, this.PatientId, this.PatientCbo.Text);
            var result = form.ShowDialog(this);
            if (result == DialogResult.OK)
                this.FillGrid_dgPatientDocs();
            form.Dispose();
        }

        private void ButtonDelete2_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_اسناد_پزشکی_بیمار_حذف) == false)
                return;

            try
            {
                if (FMessageBox.Show(Dentistry.AppConfigs.strAreYouSure_Delete, Dentistry.AppConfigs.strExclamation, FMessageBoxButtons.YesNo, FMessageBoxIcons.Question) == DialogResult.Yes)
                {
                    int id = Convert.ToInt32(this.dgPatientDocs["ColumnPatientDocumentId", this.dgPatientDocs.CurrentRow.Index].Value);

                    dynamic iObj = new ExpandoObject();
                    iObj.DocId = id;
                    iObj.IsDeleted = true;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientDocumentX(iObj);

                    if (result != null && result.Success == true && result.Data != null)
                    {
                        this.FillGrid_dgPatientDocs();
                    }


                }
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.ToString());
            }
        }

        private void ButtonPictureViewer_Click(object sender, EventArgs e)
        {
            try
            {
                //Image img = ((PictureBox)sender).Image;
                //Bitmap bm = new Bitmap(img);
                ////byte[] RegistrationImage = (byte[])imgToByteArray(img); 
                ////MemoryStream memoryStream = new MemoryStream((RegistrationImage);
                ////System.Drawing.Image Image = Image.FromStream(memoryStream);
                //bm.Save(Application.StartupPath + "\\Temp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                //System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo(Application.StartupPath + "\\Temp.jpg");
                //System.Diagnostics.Process.Start(processStartInfo);


                string filePath = this.dgPatientDocs["ColumnImagePath", this.dgPatientDocs.CurrentRow.Index].Value.ToString();
                if (System.IO.File.Exists(filePath))
                {
                    System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo(filePath);
                    System.Diagnostics.Process.Start(processStartInfo);
                }
                else
                {
                    byte[] RegistrationImage = (byte[])this.dgPatientDocs["ColumnDocumentImage", this.dgPatientDocs.CurrentRow.Index].Value;
                    MemoryStream memoryStream = new MemoryStream(RegistrationImage);
                    System.Drawing.Image Image = Image.FromStream(memoryStream);
                    Image.Save(Application.StartupPath + "\\Temp.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                    System.Diagnostics.ProcessStartInfo processStartInfo = new System.Diagnostics.ProcessStartInfo(Application.StartupPath + "\\Temp.jpg");
                    System.Diagnostics.Process.Start(processStartInfo);
                }
            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
        }

        #region PatientTeethBtn_Click
        private void PatientTeethBtn_Click(object sender, EventArgs e)
        {
            if (this.PatientId == 0)
                return;

            string patientName = this.PatientCbo.Text;
            PatientTeethView form = new PatientTeethView(this.PatientId, patientName, this.DoctorId);
            form.ShowDialog(this);
            form.Dispose();


        }
        void p_Closed2(object sender, ToolStripDropDownClosedEventArgs e)
        {

        }


        #endregion

        private void btnFollowUp_Click(object sender, EventArgs e)
        {
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.پرونده_عمومی_بیمار_مشاهده_فرم_فالوآپ_بیمار) == false)
                return;

            string patientName = PatientCbo.GetItemText(PatientCbo.SelectedItem);
            PatientFollowUpDefine form = new PatientFollowUpDefine(this.PatientId, patientName, this.DoctorId);
            form.ShowDialog(this);
            form.Dispose();
        }

        #region textBoxPatientId_KeyDown
        private void PatientCodeTxt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var patientId = Convert.ToInt32(((TextBox)sender).Text);

                dynamic sObj = new
                {
                    PatientId = patientId
                };               
                var result = Dentistry.DataProvider.GetOnePatientInfoX(sObj); // Patient  &  PatientInsurance
                if (result == null || result.Success == false || result.Data == null)
                    return;
                var dd = result.Data;

                var patient = dd.Patient;

                sObj = new
                {
                    PatientId = patientId,
                };
                result = Dentistry.DataProvider.GetPatientTransactionsX(sObj); 
                if (result == null || result.Success == false || result.Data == null)
                    return;
                var patientFinancial = result.Data;
                if (patient != null )
                {                   
                    this.PatientId = Publics.GetPropertyValue<int>(patient, "PatientId");
                    //var patientName = Publics.GetPropertyExist<string>(patient, "PatientName");
                    //this.PatientRemianedTxt.Text = Publics.GetPropertyExist<string>(patient, "patientFinancial");

                }
                else
                {
                    this.PatientId = 0;
                    FarsiMessageBox.FMessageBox.Show("این بیمار موجود نمی باشد ", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);

                }

            }

        }
        #endregion

        private void PatientCodeTxt_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar < '0' || e.KeyChar > '9')
            {
                e.Handled = true;
            }
            if (e.KeyChar == '\b')
            {
                e.Handled = false;
            }
        }
        private void PatientCodeTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void PatientInfo_KeyDown(object sender, KeyEventArgs e)
        {
            #region F2
            if (e.KeyCode == Keys.F2)
            {
                //if (this.ButtonNew.Enabled == true)
                //    this.ButtonNew_Click(this, null);
            }
            #endregion

            #region F4
            if (e.KeyCode == Keys.F4 && e.Modifiers != Keys.Alt)
            {
                //if (this.ButtonEdit.Enabled == true)
                //    this.ButtonEdit_Click(this, null);
            }
            #endregion

            #region F8
            if (e.KeyCode == Keys.F8)
            {
                //if (this.ButtonDelete.Enabled == true)
                //    this.ButtonDelete_Click(this, null);
            }
            #endregion
        }

        private void dgPatientFinancialTransactions_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (this.dgPatientFinancialTransactions["ColumnPayTypeId", e.RowIndex].Value != null)
                switch (this.dgPatientFinancialTransactions["ColumnPayTypeId", e.RowIndex].Value.ToString())
                {
                    case "1":
                    case "2":
                        this.dgPatientFinancialTransactions.Rows[e.RowIndex].Cells["ColumnPayTypeTitle"].Style.ForeColor = Color.LimeGreen;
                        break;
                    case "3":
                    case "4":
                        this.dgPatientFinancialTransactions.Rows[e.RowIndex].Cells["ColumnPayTypeTitle"].Style.ForeColor = Color.DodgerBlue;
                        break;
                    case "5":
                    case "6":
                        this.dgPatientFinancialTransactions.Rows[e.RowIndex].Cells["ColumnPayTypeTitle"].Style.ForeColor = Color.DeepPink;
                        break;


                }
        }
    }
}