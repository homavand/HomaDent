using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SparksToothChart;
using System.Data.SqlClient;
using System.IO;
using System.Drawing.Imaging;
using System.Collections;
using System.Dynamic;
using DNTPersianUtils.Core;
using PopupControl;


namespace Dentistry
{
    public partial class PatientServiceDefine : Form
    {
        private bool _isSyncingSelection = false;
        PopupControl.Popup p;
        //---------------------------------------------------
        int patientId = 0;
        public int PatientId
        {
            get { return this.patientId; }
            set
            {
                if (value < 0) 
                    this.patientId = 0;
                else
                    this.patientId = value;

                Dentistry.AppConfigs.SelectedPatientId = this.patientId;

                TeethChart.ResetTeeth();

                
            }

        }

        //---------------------------------------------------

        
        int? patientServiceId = null;
        public int? PatientServiceId
        {
            get { return this.patientServiceId; }
            set
            {
                if (value > 0)
                {
                    this.patientServiceId = value;
                    GetPatientServiceInfo(this.PatientServiceId.Value);
                }

            }
        }

        //---------------------------------------------------
    
        int doctorId = 0;
        public int DoctorId
        {
            get { return this.doctorId; }
            set
            {
                if (value > 0)                
                    this.doctorId = value;                                    
                else
                    this.doctorId = this.DefaultDoctorId;

                this.DoctorCbo.SelectedIndex = Publics.GetComboIndex(this.DoctorCbo, this.doctorId);

            }
        }

        //---------------------------------------------------

        int basicInsurerId = 0;
        public int BasicInsurerId
        {
            get { return this.basicInsurerId; }
            set
            {
                if (value < 0) 
                    this.basicInsurerId = 0;
                else
                    this.basicInsurerId = value;

            }

        }

        //---------------------------------------------------

        private int serviceGroupId = -1;
        public int ServiceGroupId
        {
            set
            {
                this.serviceGroupId = value;
                this.FillGrid_dgService(this.serviceGroupId);
            }
            get
            {
                return this.serviceGroupId;
            }
        }

        //---------------------------------------------------

        private int serviceId = -1;
        public int ServiceId
        {
            set
            {
                this.serviceId = value;
                this.FetchServiceFinancialInfo();
            }
            get
            {
                return this.serviceId;
            }
        }


        public ArrayList ToothNumbers;

        public dynamic PatientServiceInfo;

        //---------------------------------------------------
        int DefaultDoctorId = 0;
        bool IsNeed4ToothNumber = true;
        public int CheckupTypeId = 0;
                    
        public dynamic ServiceTarefe = null;       
        public string BasicInsurerTitle = "";
        public bool ChartIsInPrimaryMode = false;

        public PatientServiceDefine(int patientId, int checkupTypeId , int? patientServiceId = null)
        {
            InitializeComponent();

            this.PatientId = patientId;
            this.CheckupTypeId = checkupTypeId;
            this.patientServiceId = patientServiceId;
        
            
        }

   
        private void PatientActionDefine_Load(object sender, EventArgs e)
        {
            

            this.LoadFormInit();

            this.DefaultDoctorId = Dentistry.AppInfo.DefaultDoctorId;

            if (this.PatientId > 0)
            {
                this.GetPatientInfo(this.patientId);

            }

            ServiceDateCbo.Text = new PersianDateTime(DateTime.Now).ToString("yyyy/MM/dd");            
        }

        private void PatientServiceDefine_Shown(object sender, EventArgs e)
        {
            dgServiceGroup1.CellEnter += this.dgServiceGroup_CellEnter;
            dgServiceGroup2.CellEnter += this.dgServiceGroup_CellEnter;
            dgServiceGroup3.CellEnter += this.dgServiceGroup_CellEnter;
            dgServices.CellEnter += this.dgServices_CellEnter;
            if (this.PatientServiceId > 0)
            {
                GetPatientServiceInfo(this.PatientServiceId.Value);
            }
        }


        #region LoadFormInit
        private void LoadFormInit()
        {
          
            dynamic sObj = new
            {
                IsServiceGroup = true,             
            };

            var result = Dentistry.DataProvider.LoadFormInitInfo(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;

            if (dd == null)
                return;
                        
            var serviceGroup = (dd.ServiceGroup as IEnumerable<dynamic>).Where(i => i.Id > 0)
                .Select(i => new
                        {
                            i.Id,
                            i.Title,
                            i.Color
                        }
                    ).ToList() ;
                       
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("Id", typeof(string));
            dt1.Columns.Add("Title", typeof(string));
            dt1.Columns.Add("Color", typeof(string));

            DataTable dt2 = new DataTable();
            dt2.Columns.Add("Id", typeof(string));
            dt2.Columns.Add("Title", typeof(string));
            dt2.Columns.Add("Color", typeof(string));

            DataTable dt3 = new DataTable();
            dt3.Columns.Add("Id", typeof(string));
            dt3.Columns.Add("Title", typeof(string));
            dt3.Columns.Add("Color", typeof(string));

            for (int i=0; i < serviceGroup.Count(); i++ )
            {
                var item = serviceGroup[i];
                if (i % 3 == 0)
                {
                    dt1.Rows.Add(
                        item.Id,
                        item.Title,
                        item.Color
                        );
                }
                else if (i % 3 == 1)
                {
                    dt2.Rows.Add(
                        item.Id,
                        item.Title,
                        item.Color
                        );
                }
                else 
                {
                    dt3.Rows.Add(
                        item.Id,
                        item.Title,
                        item.Color
                        );
                }
            }

          
            //this.dgServiceGroup1.RowEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgServiceGroup_RowEnter);
            this.dgServiceGroup1.DataSource = dt1;
                     
            //this.dgServiceGroup2.RowEnter -= new System.Windows.Forms.DataGridViewCellEventHandler(this.dgServiceGroup_RowEnter);
            this.dgServiceGroup2.DataSource = dt2;

            this.dgServiceGroup3.DataSource = dt3;


            ////////////////////////////////////////////////////////////////////////////////////////////
            
            sObj = new System.Dynamic.ExpandoObject();
            result = DataProvider.GetDoctorsX(sObj);
            if (result == null || result.Success == false)
                return;

            dd = result.Data;
            var doctorList = (dd as IEnumerable<dynamic>)
                                        .Select(i =>
                                        new
                                        {
                                            Id = (int)i.DoctorId,
                                            Title = (string)i.FullName
                                        }).ToList();

            var doctors = Publics.AddDefaultItemToComboDynamicList(doctorList);

            this.DoctorCbo.DataSource = doctors;
            this.DoctorCbo.ValueMember = "Id";
            this.DoctorCbo.DisplayMember = "Title";
            if (this.DoctorCbo.Items.Count < 2)
            {
                DoctorCbo.SelectedIndex = 1;
            }

        }
        #endregion

      

        public void GetPatientInfo(int patientId)
        {
            dynamic sObj = new
            {
                PatientId = patientId
            };

            var result = Dentistry.DataProvider.GetOnePatientInfoX(sObj);

            var dd = result != null && result.Data != null ? result.Data : null;
            
            if (dd != null)
            {
                
                this.DoctorId = 0;
                this.BasicInsurerId = Constant.FreeInsurerId;
                this.BasicInsurerTitle = Constant.FreeInsurerTitle;

                var patient = dd.Patient;
                if (patient != null)
                {
                    this.DoctorId = Publics.GetPropertyValue<int>(patient, "DoctorId");
                    this.patientNameTxt.Text = Publics.GetPropertyValue<string>(patient, "PatientName");
                }

                var patientInsurance = dd.PatientInsurance;
                if (patientInsurance != null)
                {
                    
                    this.BasicInsurerId = Publics.GetPropertyValue<int>(patientInsurance, "BI_InsurerId");
                    this.BasicInsurerTitle = Publics.GetPropertyValue<string>(patientInsurance, "BI_InsurerTitle");
                    this.patientInsuranceTxt.Text = this.BasicInsurerTitle;
                    bool IsInsurerExpired = patientInsurance.BI_ExpirationDate != null ? 
                                            (DateTime.Now <= patientInsurance.BI_ExpirationDate) ? false : true 
                                            : true;
                }
                                             
                
            }
        }

        public void GetPatientServiceInfo(int patientServiceId)
        {           
            dynamic sObj = new ExpandoObject();          
            sObj.PatientServiceId = patientServiceId;

            var data = Dentistry.DataProvider.GetPatientServicesX(sObj);
            if (data == null || data.Data == null)
                return;

            var dd = data.Data;

            if (dd != null && (Enumerable.Count(dd) > 0))
            {
                var patientService = data.Data[0];

                Class.PatientService obj = new Class.PatientService(patientService);
                this.CheckupTypeId = Publics.GetPropertyValue<int>(obj, "CheckupTypeId");

                this.DoctorId = Publics.GetPropertyValue<int>(obj, "DoctorId");               
                this.ServiceGroupId = Publics.GetPropertyValue<int>(obj, "ServiceGroupId");
                this.ServiceId = Publics.GetPropertyValue<int>(obj, "ServiceId");
                
                


                ServiceDateCbo.Value = obj.Date;

                var toothCount = Publics.GetPropertyValue<int>(obj, "ToothCount");
                if (toothCount > 0)
                {
                    this.ToothNumbers = new ArrayList();

                    if (obj.Tooths != null)
                    {
                        foreach (var tooth in obj.Tooths)
                        {
                            var toothName = ToothInfoClass.ToothIdToToothName(tooth.ToothId);

                            this.ToothNumbers.Add(toothName);
                        }
                    }
                }
              
            }

            if (this.ToothNumbers != null)
            {
                foreach (string toothName in this.ToothNumbers)
                {
                    if (ToothGraphic.IsPrimary(toothName))
                        this.chkAtfal.Checked = true;
                }
            }


            dynamic patientServiceInfo = new
            {
                PatientId = this.PatientId,
                DoctorId  = this.DoctorId,
                ServiceGroupId = this.ServiceGroupId,
                ServiceId = this.ServiceId,
                ToothNumbers = this.ToothNumbers
            };

            this.PatientServiceInfo = patientServiceInfo;


            this.SetRegisterdPatientServiceInfoInForm();


        }


        public void SetRegisterdPatientServiceInfoInForm()
        {
            if (this.PatientServiceInfo == null)
                return;

            _isSyncingSelection = true;
            try
            {
                var doctorId = Publics.GetPropertyValue<int>(this.PatientServiceInfo, "DoctorId");
                this.DoctorCbo.SelectedIndex = Publics.GetComboIndex(this.DoctorCbo, doctorId);

                var serviceGroupId = Publics.GetPropertyValue<int>(this.PatientServiceInfo, "ServiceGroupId");

                DataGridView[] groupGrids = { dgServiceGroup1, dgServiceGroup2, dgServiceGroup3 };
                string[] idColumns = { "ColumnServiceGroupId1", "ColumnServiceGroupId2", "ColumnServiceGroupId3" };

                DataGridView dg = null;
                int rowIndex = -1;
                for (int g = 0; g < groupGrids.Length && rowIndex == -1; g++)
                {
                    foreach (DataGridViewRow row in groupGrids[g].Rows)
                    {
                        if (Convert.ToInt32(row.Cells[idColumns[g]].Value) == serviceGroupId)
                        {
                            dg = groupGrids[g];
                            rowIndex = row.Index;
                            break;
                        }
                    }
                }

                // ⬅️ صریحاً هر سه گرید رو قبل از ست کردن Selection جدید پاک می‌کنیم
                dgServiceGroup1.ClearSelection();
                dgServiceGroup2.ClearSelection();
                dgServiceGroup3.ClearSelection();

                if (rowIndex != -1)
                    dg.CurrentCell = dg.Rows[rowIndex].Cells[1];

                var serviceId = Publics.GetPropertyValue<int>(this.PatientServiceInfo, "ServiceId");

                rowIndex = -1;
                foreach (DataGridViewRow row in dgServices.Rows)
                {
                    if (Convert.ToInt32(row.Cells["ColumnServiceId"].Value) == serviceId)
                    {
                        rowIndex = row.Index;
                        break;
                    }
                }
                if (rowIndex != -1)
                    dgServices.CurrentCell = dgServices.Rows[rowIndex].Cells[1];

                if (this.PatientServiceInfo.ToothNumbers != null)
                {
                    foreach (string toothName in this.ToothNumbers)
                    {
                        TeethChart.SetSelected(toothName, true);
                    }

                    if (this.ChartIsInPrimaryMode)
                    {
                        TeethChart.ChartSetToPrimary();
                    }
                }
            }
            finally
            {
                _isSyncingSelection = false;
            }
        }

        private void chkAtfal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtfal.Checked)
            {
                this.ChartIsInPrimaryMode = true;
                TeethChart.ChartSetToPrimary();
            }
            else
            {
                this.ChartIsInPrimaryMode = false;
                TeethChart.ResetTeeth();
            }
            this.SetRegisterdPatientServiceInfoInForm();
        }

        #region checkValidate()      
        private bool checkValidate()
        {
            

            if (IsNeed4ToothNumber == true && TeethChart.SelectedTeeth.Length == 0)
            {
                FarsiMessageBox.FMessageBox.Show("لطفا دندان را انتخاب نمایید", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return false; 
            }        
            if (this.DoctorCbo.SelectedValue == null || Convert.ToInt32(this.DoctorCbo.SelectedValue) < 1)
            {
                FarsiMessageBox.FMessageBox.Show("لطفا نام دکتر را انتخاب نمایید", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return false;
            }
           
            if (this.dgServices.CurrentRow == null || this.dgServices.CurrentRow.Selected == false)
            {
                FarsiMessageBox.FMessageBox.Show("لطفا نام زیر سرویس را انتخاب نمایید", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return false;
            }
            
            return true;
        }
        #endregion

        private void ServiceColorLbl_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ServiceColorLbl.BackColor = colorDialog1.Color;
            }
        }

       
                 


        private void SaveActionBtn_Click(object sender, EventArgs e)
        {
            if (!checkValidate())
                return;

            if (FarsiMessageBox.FMessageBox.Show("آیا برای ثبت درمان برای این بیمار مطمئن هستید؟", "پیام", FarsiMessageBox.FMessageBoxButtons.OKCancel, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1) != System.Windows.Forms.DialogResult.OK)
            {
                return;
            }

            try
            {
                List<int> toothIds = new List<int>();

                for (int i = 0; i < TeethChart.SelectedTeeth.Length; i++)
                {
                    ToothGraphic tooth = TeethChart.GetToothInfo(TeethChart.SelectedTeeth[i].ToString());
                                                           
                    int toothId = ToothInfoClass.ToothNameToToothId(tooth.ToothId);
                    toothIds.Add(toothId);
                   
                }

                
                dynamic iObj = new ExpandoObject();
                iObj.ActionType = this.PatientServiceId == null ? "New" : "Edit";
                iObj.PatientServiceId = this.PatientServiceId;
                iObj.PatientId = this.PatientId;
                iObj.CheckupTypeId = this.CheckupTypeId;
               
                iObj.ServiceGroupId = this.ServiceGroupId;
                iObj.ServiceId = this.ServiceId;
                iObj.ToothIds = toothIds;
                iObj.ProviderStaffId = DoctorCbo.SelectedValue;               
                
                iObj.Date = Class.Date.ToChristianByTime(ServiceDateCbo.Value.ToString(), true);  
                iObj.Comment = "";
                iObj.IsHadMoreTooth = false;

                var obj = this.ServiceTarefe;
                iObj.InsurerServiceTarefeChangeId = Publics.GetPropertyValue<int>(obj, "InsurerServiceTarefeChangeId");  
                iObj.ServicePrice   = Publics.GetPropertyValue<double>(obj, "FreePrice");
                iObj.InsurerPrice   = Publics.GetPropertyValue<double>(obj, "InsurerPrice"); 
                iObj.InsurerShare   = Publics.GetPropertyValue<double>(obj, "InsurerShare"); 
                iObj.FranchiseShare = Publics.GetPropertyValue<double>(obj, "FranchiseShare"); 
                iObj.FreeShare      = Publics.GetPropertyValue<double>(obj, "FreeShare");                

                JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientServiceX(iObj);
                if (result != null && result.Success == true)
                {                  
                    FarsiMessageBox.FMessageBox.Show(" ثبت درمان با موفقیت انجام شد", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    this.DialogResult = DialogResult.OK;
                }               
            }
            catch (Exception ex)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در ثبت درمان ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
            }
            
        }

 
        private void dgServiceGroup_CellFormatting(DataGridView dg)
        {            
            string tag = dg.Tag.ToString();

            foreach (DataGridViewRow row in dg.Rows)
            {
                var color = row.Cells["ColumnServiceGroupColor" + tag].Value;
                Color parsedColor = Color.FromArgb(Convert.ToInt32(color));
                var cell = row.Cells["ColumnServiceGroupColor" + tag];
                cell.Style.BackColor = parsedColor;
                cell.Style.SelectionBackColor = parsedColor;
               
            }
                      
        }


        #region FillGrid_dgService
        private void FillGrid_dgService(int serviceGroupId)
        {
            
            dynamic sObj = new
            {
                ServiceGroupId = serviceGroupId,
                IsDeleted = false
            };

            var result = DataProvider.GetServicesX(sObj);
            if (result == null || result.Success == false)
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
                                                                            }).ToList() : Enumerable.Empty<dynamic>();

            DataTable dt = new DataTable();
            dt.Columns.Add("ServiceId", typeof(int));
            dt.Columns.Add("ServiceCode", typeof(string));
            dt.Columns.Add("ServiceTitle", typeof(string));
            dt.Columns.Add("ServiceColor", typeof(int));


            foreach (var item in list)
                dt.Rows.Add(
                    item.ServiceId,
                    item.ServiceCode,
                    item.ServiceTitle,
                    item.ServiceColor
                    );

         
            this.dgServices.DataSource = dt;            
            //this.dgServices.CurrentCell = null;
            


        }
        #endregion


     

        private void FetchServiceFinancialInfo()
        {

            dynamic sObj = new
            {
                InsurerId = this.BasicInsurerId,
                ServiceId = this.ServiceId,
                ServiceDate = string.Format("{0} {1}", this.ServiceDateCbo.Value.ToString(), DateTime.Now.ToString("HH:mm")).ToGregorianDateTime()
            };

            var data = Dentistry.DataProvider.GetInsurersServicePricingX(sObj);

            if (data == null)
            {
                FarsiMessageBox.FMessageBox.Show(Constant.NoResult, "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }
            if(data.Success == false)
            {
                if(data.Data == 2)
                {
                    FarsiMessageBox.FMessageBox.Show(data.Message, "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    this.ServiceTarefe = null;
                    this.ServicePriceTxt.Text = "0";
                }

                return;
            }
            if (data.Data == null)
            {
                FarsiMessageBox.FMessageBox.Show(Constant.NoData, "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }
           
            var dd = data.Data ;

            var obj = (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).FirstOrDefault() : null;
         
            if (obj == null)
                return;

            this.ServiceTarefe = obj;
           
            var freePrice       = Publics.GetPropertyValue<int>(obj, "FreePrice");
            var insurerPrice    = Publics.GetPropertyValue<int>(obj, "InsurerPrice");
            var insurerShare    = Publics.GetPropertyValue<int>(obj, "InsurerShare");
            var franchiseShare  = Publics.GetPropertyValue<int>(obj, "FranchiseShare");
            var freeShare       = Publics.GetPropertyValue<int>(obj, "FreeShare");
            var solarDefineDate = Publics.GetPropertyValue<string>(obj, "SolarDefineDate");
            var solarRunDate    = Publics.GetPropertyValue<string>(obj, "SolarRunDate");
            int patientShare    = franchiseShare + freeShare;           

            this.ServicePriceTxt.Text = Publics.ToRial(freePrice);

            List<KeyValuePair<int, object>> sList = new List<KeyValuePair<int, object>>()
                {
                    new KeyValuePair<int, dynamic>(1, new {key="InsurerTitle", title= " بیمه پایه ", value = this.BasicInsurerTitle }),
                    new KeyValuePair<int, dynamic>(2, new {key="FreePrice", title= " قیمت آزاد ", value = Publics.ToRial(freePrice) }),
                    new KeyValuePair<int, dynamic>(3, new {key="InsurerPrice", title= " قیمت بیمه ", value = Publics.ToRial(insurerPrice) }),
                    new KeyValuePair<int, dynamic>(4, new {key="InsurerShare", title= " سهم بیمه ", value = Publics.ToRial(insurerShare) }),
                    new KeyValuePair<int, dynamic>(5, new {key="FranchiseShare", title= " فرانشیز", value = Publics.ToRial(franchiseShare) }),
                    new KeyValuePair<int, dynamic>(6, new {key="FreeShare", title= " مابالتفاوت ", value = Publics.ToRial(freeShare) }),
                    new KeyValuePair<int, dynamic>(6, new {key="SolarDefineDate", title= " تاریخ تعریف ", value = (solarDefineDate) }),
                    new KeyValuePair<int, dynamic>(6, new {key="SolarRunDate", title= " تاریخ اجرا ", value = (solarRunDate) }),
                    new KeyValuePair<int, dynamic>(6, new {key="PatientShare", title= " سهم بیمار ", value = Publics.ToRial(patientShare) }),
                };



            DataTable dt = new DataTable();
            dt.Columns.Add("Key", typeof(string));
            dt.Columns.Add("Title", typeof(string));
            dt.Columns.Add("Value", typeof(string));


            foreach (var item in sList)
            {
                dynamic d = item.Value;
                dt.Rows.Add(
                    d.key,
                    d.title,
                    d.value
                    );
            }
            this.dgServiceFinancialsPnl.Parent = panel4;
            this.dgServiceFinancialsPnl.Visible = false;
            this.dgServiceFinancials.DataSource = dt;
            this.dgServiceFinancials.Refresh();

        }

        private void dgServiceGroup_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dg = ((DataGridView)sender);
            this.dgServiceGroup_CellFormatting(dg);
            dg.CurrentCell = null;

            //dg.CellEnter -= this.dgServiceGroup_CellEnter;
            //dg.CellEnter += this.dgServiceGroup_CellEnter;

           
        }

       

        private void dgServiceGroup_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_isSyncingSelection)
                return;

            DataGridView dg = ((DataGridView)sender);
           
            int index = 0;

            if (dg == this.dgServiceGroup1)
            {
                index = 1;
                dgServiceGroup2.ClearSelection();
                dgServiceGroup3.ClearSelection();
            }
            else if (dg == this.dgServiceGroup2)
            {
                index = 2;
                dgServiceGroup1.ClearSelection();
                dgServiceGroup3.ClearSelection();
            }
            else if (dg == this.dgServiceGroup3)
            {
                index = 3;
                dgServiceGroup1.ClearSelection();
                dgServiceGroup2.ClearSelection();
            }                                   

            this.ServiceGroupId = Convert.ToInt32(dg.Rows[e.RowIndex].Cells[0].Value);

            string title = "لیست خدمات - ";
            string serviceGroupTitle = Convert.ToString(dg.Rows[e.RowIndex].Cells[1].Value);
            this.ServiceGroupTitleTxt.Text = title + serviceGroupTitle;
            this.ServiceGroupNameTxt.Text = serviceGroupTitle;
            this.ServiceTitleTxt.Text = "...";

            var color = dg.Rows[e.RowIndex].Cells[2].Value;
            if (color != null)
            {
                ServiceColorLbl.BackColor = Color.FromArgb(Convert.ToInt32(color));
                
            }
            else
                ServiceColorLbl.BackColor = Color.White;
           
        }

        private void dgServices_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            dg.CurrentCell = null;
            //dg.CellEnter -= this.dgServices_CellEnter;
            //dg.CellEnter += this.dgServices_CellEnter;

        }

        private void dgServices_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (_isSyncingSelection)
                return;

            int serviceId = Convert.ToInt32(this.dgServices["ColumnServiceId", e.RowIndex].Value);
            if (serviceId != this.ServiceId)
                this.ServiceId = serviceId;

            if (this.dgServices.CurrentRow != null)
            {
               
                this.ServiceTitleTxt.Text = this.dgServices.CurrentRow.Cells["ColumnServiceTitle"].Value.ToString();                
                
                
            }
            else
            {                
                this.ServiceTitleTxt.Text = "...";
               
            }

        }

        private void ServiceFinancialBtn_Click(object sender, EventArgs e)
        {
            //p = null;
           
            if (p == null)
            {

                Panel panel = this.dgServiceFinancialsPnl;
                this.dgServiceFinancialsPnl.Visible = true;
                panel.Width = 400;
                panel.Height = 400;
                p = new PopupControl.Popup(panel);
                p.Closed += new ToolStripDropDownClosedEventHandler(p_Closed);
                p.RightToLeft = RightToLeft.Yes;

                p.ShowingAnimation = p.HidingAnimation = PopupAnimations.Blend;

               

               
            }
            Rectangle screen = Screen.PrimaryScreen.Bounds;
            Point location = new Point(
                (screen.Width - this.dgServiceFinancialsPnl.Width) / 2,
                (screen.Height - this.dgServiceFinancialsPnl.Height) / 2);

            p.Hide();
            if(this.ServiceId == -1 )
            {
                FarsiMessageBox.FMessageBox.Show(Constant.NoService, "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }
            if(this.ServiceTarefe == null)
            {
                FarsiMessageBox.FMessageBox.Show(Constant.NoInsurancePriceRecordForService, "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }

            p.Show(location.X, location.Y);
        }

        void p_Closed(object sender, ToolStripDropDownClosedEventArgs e)
        {
            if (p != null)
            {
                //p.Close();
                p = null;
            }
        }
    }
}
