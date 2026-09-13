using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.Dynamic;

namespace Dentistry
{
    public partial class VisitDefine : Form
    {
        
        
        public bool Flag = false;
        public int PatientId = -1;
        public int DoctorId = -1;
        public int ServiceGroupId = 11;
        public DateTime StartDate;
        public DateTime EndDate;
        public TimeSpan EndTime;
        public string PatientName;
        public string DoctorName;
        public int VisitId = 0;        
        public string ServiceGroupTitle = "";
        public int VisitColor = 0;

        public VisitDefine(DateTime date, TimeSpan start, TimeSpan end, int doctorId, int? visitId = null)
        {
            InitializeComponent();

            this.DateTxt.Text = date.ToString("yyyy/MM/dd");
            this.FromTimeTxt.Text = start.ToString();
            this.ToTimeTxt.Text = end.ToString();
            
            this.DoctorId = doctorId;
            this.DoctorCbo.SelectedIndex = Publics.GetComboIndex(this.DoctorCbo, this.DoctorId);

            this.EndTime = end;

            //int diff = Convert.ToInt32((end - start).TotalMinutes);
            //this.trackBar1.Value = diff;

            SolarDateTxt.Text = new PersianDateTime(date).Date.ToString("yyyy/MM/dd") ;
            StartDate = new DateTime(date.Year, date.Month, date.Day, start.Hours, start.Minutes, start.Seconds);
            EndDate = new DateTime(date.Year, date.Month, date.Day, end.Hours, end.Minutes, end.Seconds);


            if (visitId != null)
            {
                this.VisitId = visitId.Value;               
            }


        }

        private void VisitDefine_Load(object sender, EventArgs e)
        {
            this.LoadFormInit();

            if (this.VisitId > 0)
            {               
                this.FetchVisitInfo(this.VisitId);
            }
        }

        private void VisitDefine_Shown(object sender, EventArgs e)
        {
            PlusBtn.TabStop = false;
            PlusBtn.FlatStyle = FlatStyle.Flat;
            PlusBtn.FlatAppearance.BorderSize = 0;
            PlusBtn.FlatAppearance.BorderColor = Color.FromArgb(0, 255, 255, 255);
        }

        #region LoadFormInit
        private void LoadFormInit()
        {

            dynamic sObj = new
            {
                IsDeleted = false
            };
            var result = Dentistry.DataProvider.GetPatientsX(sObj);
            var dd = result != null && result.Data != null ? result.Data : null;
            var patientList = (dd as IEnumerable<dynamic>)
                 .Select(i =>
                 new
                 {
                     Id = (int)i.PatientId,
                     Title = (string)i.PatientName,
                     TitleX = string.Format("{0} ({1})", i.PatientName, i.PatientId),

                 }).ToList();

            var patients = Publics.AddDefaultItemToComboDynamicList(patientList);

            this.PatientCbo.SelectedIndexChanged -= new EventHandler(this.PatientCbo_SelectedIndexChanged);
            this.PatientCbo.DataSource = patients;
            this.PatientCbo.ValueMember = "Id";
            this.PatientCbo.DisplayMember = "Title";
            Publics.AutoComplete(this.PatientCbo, patients);
            this.PatientCbo.SelectedIndexChanged += new EventHandler(this.PatientCbo_SelectedIndexChanged);


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

            this.DoctorCbo.SelectedIndexChanged -= new EventHandler(this.DoctorCbo_SelectedIndexChanged);
            this.DoctorCbo.DataSource = doctors;
            this.DoctorCbo.ValueMember = "Id";
            this.DoctorCbo.DisplayMember = "Title";
            Publics.AutoComplete(this.DoctorCbo, doctors);
            this.DoctorCbo.SelectedIndexChanged += new EventHandler(this.DoctorCbo_SelectedIndexChanged);


            var dsDoctor = (DoctorCbo.DataSource as IEnumerable<dynamic>);
            if (dsDoctor != null && Enumerable.Count(dsDoctor) <= 2)
            {
                DoctorCbo.SelectedIndex = dsDoctor.Count() - 1;
            }

            //if (Dentistry.Config.SelectedDoctorId != -1)
            //{
            //    DoctorCbo.SelectedIndex = Publics.GetComboIndex(this.DoctorCbo, Dentistry.Config.SelectedDoctorId);
            //}

        }
        #endregion

        private void FetchVisitInfo(int id)
        {
            try
            {

                dynamic sObj = new System.Dynamic.ExpandoObject();
                sObj.Id = id;

                var data = Dentistry.DataProvider.GetVisitX(sObj);
                var dd = (data != null && data.Data != null) ? data.Data : null;

                var obj = dd != null && (Enumerable.Count(dd) > 0) ? (dd as IEnumerable<dynamic>).Select(i => i).FirstOrDefault() : null;


                if (obj != null)
                {
                    this.PatientId = Publics.GetPropertyValue<int>(obj, "PatientId");
                    this.DoctorId = Publics.GetPropertyValue<int>(obj, "DoctorId");
                    this.ServiceGroupId = Publics.GetPropertyValue<int>(obj, "ServiceGroupId");

                    int serviceGroupId = obj.ServiceGroupId != null ? Convert.ToInt32(obj.ServiceGroupId) : 0;
                    this.DoctorCbo.SelectedIndex = Publics.GetComboIndex(this.DoctorCbo, this.DoctorId);
                    this.PatientCbo.SelectedIndex = Publics.GetComboIndex(this.PatientCbo, this.PatientId);

                    foreach (var pnl in this.ServiceGroupPnl.Controls.OfType<UserControls.ExPanel>().ToList())
                    {
                        var rdoX = pnl.Controls.OfType<RadioButton>().ToList().Where(i => Convert.ToInt32(i.Tag) == this.ServiceGroupId).Select(i => i).SingleOrDefault();

                        if (rdoX != null)
                        {
                            rdoX.Checked = true;
                            break;
                        }

                    }

                }

            }
            catch (System.Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }

        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            // موقتی
            if (Dentistry.Publics.GetCurrentUserPermission1((int)Enums.AppActions.نوبت_دهی__ثبت_نوبت_دهی_بیماران) == false)
                return;
            if (this.DoctorId == -1)
            {
                FarsiMessageBox.FMessageBox.Show("لطفا اطلاعات پزشک را وارد نمایید", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }

            if (this.PatientId == -1)
            {
                FarsiMessageBox.FMessageBox.Show("لطفا اطلاعات بیمار را وارد نمایید", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }

            if (DateTxt.Text == "" || FromTimeTxt.Text == "" || ToTimeTxt.Text == "")
            {
                FarsiMessageBox.FMessageBox.Show("لطفا اطلاعات را کامل وارد نمایید", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return;
            }

            DateTime dt;
            if (!DateTime.TryParseExact(FromTimeTxt.Text, "HH:mm", CultureInfo.InvariantCulture,
                                                          DateTimeStyles.None, out dt))
            {
                // handle validation error
            }
            TimeSpan timeS = dt.TimeOfDay;
            if (!DateTime.TryParseExact(ToTimeTxt.Text, "HH:mm", CultureInfo.InvariantCulture,
                                                          DateTimeStyles.None, out dt))
            {
                // handle validation error
            }
            TimeSpan timeE = dt.TimeOfDay;
           

            DateTime date = DateTime.Parse(DateTxt.Text);
            DateTime startDate = new DateTime(date.Year, date.Month, date.Day, timeS.Hours, timeS.Minutes, 0);
            DateTime endDate = new DateTime(date.Year, date.Month, date.Day, timeE.Hours, timeE.Minutes, 0);

            string description = String.Format("{0} : {1}  -  {2} " , "نوع درمان", this.ServiceGroupTitle, this.DescriptionTxt.Text) ;            

            this.VisitColor = ColorLbl.BackColor == Color.White ? 0 : Convert.ToInt32(ColorLbl.BackColor.ToArgb()); 

            dynamic iObj = new ExpandoObject();
            iObj.DoctorId = this.DoctorId;
            iObj.PatientId = this.PatientId;        
            iObj.ServiceGroupId = this.ServiceGroupId;
            iObj.Date = DateTime.Parse(DateTxt.Text);
            iObj.StartTime = startDate.TimeOfDay;
            iObj.EndTime = endDate.TimeOfDay;
            iObj.Description = description;
            iObj.Color = this.VisitColor;
            iObj.IsDeleted = false;
            iObj.Description = description;

            int retId = 0;
            if (this.VisitId > 0)
            {
                iObj.Id = this.VisitId;
               
            }
            JsonResponse<dynamic> result = Dentistry.DataProvider.DefineVisitX(iObj);    
            if (result != null && result.Success == true && result.Data != null)
            {
                    retId = result.Data.Id != null ? result.Data.Id : 0;
                    this.DialogResult = DialogResult.OK;
            }
            this.VisitId = retId;
            Flag = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Flag = false;
            this.Close();
        }

        private void btnNewIll_Click(object sender, EventArgs e)
        {

            PatientAdmission form = new PatientAdmission();
            form.ShowDialog(this);
            form.Dispose();
            //???
            this.LoadFormInit();
        }

        private void DoctorCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamic obj = (((ComboBox)sender).SelectedItem);
            if (obj == null)
                return;
            this.DoctorId = Publics.GetPropertyValue<int>(obj, "Id");
            this.DoctorName = Publics.GetPropertyValue<string>(obj, "Title");
         
        }

        private void PatientCbo_SelectedIndexChanged(object sender, EventArgs e)
        {
            dynamic obj = ((ComboBox)sender).SelectedItem;
            if (obj == null)
                return;
            this.PatientId = Publics.GetPropertyValue<int>(obj, "Id");
            this.PatientName = Publics.GetPropertyValue<string>(obj, "Title");
        }

       

        private void ColorLbl_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                ColorLbl.BackColor = colorDialog1.Color;
            }
        }

        private void rdoServiceGroup_CheckedChanged(object sender, EventArgs e)
        {
            Color color = Color.White;

            RadioButton rdoX = sender as RadioButton;
            if (rdoX == null || rdoX.Checked != true)
                return;

            var pnlList = this.ServiceGroupPnl.Controls.OfType<UserControls.ExPanel>().ToList();

            foreach (var pnl in pnlList)
            {
                if (pnl != null)
                {
                    RadioButton rdo = pnl.Controls.OfType<RadioButton>().FirstOrDefault();

                    if (rdo != null && rdo != rdoX)
                        rdo.Checked = false;

                    if (rdo == rdoX)
                        color = pnl.BorderColor;
                }
            }
            
            var serviceGroupId = rdoX.Tag;           
            this.ServiceGroupId = Convert.ToInt32(serviceGroupId);
            this.ServiceGroupTitle = rdoX.Text;
            ColorLbl.BackColor = color;
        }

        private void tbPlus_Scroll(object sender, EventArgs e)
        {
            
            

        }


        private int smallChangeValue = 15;
        private int trackValue;
        private bool blockRecursion = false;
       

        private int plusValueBefore = 0;
        

      

        private void PlusBtn_Click(object sender, EventArgs e)
        {
            TimeSpan fromTime;
            if (!TimeSpan.TryParse(this.FromTimeTxt.Text, out fromTime))
            {
                // handle validation error
            }
            TimeSpan toTime;
            if (!TimeSpan.TryParse(this.ToTimeTxt.Text, out toTime))
            {
                // handle validation error
            }


            TimeSpan newToTime = toTime + new TimeSpan(0, 15, 0);
            if (newToTime <= fromTime)
                this.MinusBtn.Enabled = false;
            else
            {
                this.MinusBtn.Enabled = true;
                this.ToTimeTxt.Text = newToTime.ToString(@"hh\:mm");
            }
            
        }

        private void MinusBtn_Click(object sender, EventArgs e)
        {
            TimeSpan fromTime;
            if (!TimeSpan.TryParse(this.FromTimeTxt.Text, out fromTime))
            {
                // handle validation error
            }

            TimeSpan toTime;
            if (!TimeSpan.TryParse(this.ToTimeTxt.Text, out toTime))
            {
                // handle validation error
            }

            TimeSpan newToTime = toTime - new TimeSpan(0, 15, 0);
            if (newToTime <= fromTime)
                this.MinusBtn.Enabled = false;
            else
            {
                this.MinusBtn.Enabled = true;
                this.ToTimeTxt.Text = newToTime.ToString(@"hh\:mm");
            }
            
        }
    }
}
