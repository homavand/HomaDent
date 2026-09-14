using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dentistry.Class;

namespace Dentistry
{
    public partial class WorkTimeDefine : Form
    {
        int? DoctorId = null;
        string DoctorName = "";
        DateTime? Date = null;
       
       
        bool? Flag = null;

        public WorkTimeDefine()
        {
            InitializeComponent();
        }

        public WorkTimeDefine(int doctorId, string doctorName, string currentDateTime)
        {
            InitializeComponent();

            DoctorId = doctorId;
            DoctorName = doctorName;
            Date = Convert.ToDateTime(currentDateTime.Split('#')[0]);

            string time = Convert.ToString(currentDateTime.Split('#')[1]);
            TimeSpan startTime = new TimeSpan();
            TimeSpan endTime = new TimeSpan();
            if (TimeSpan.TryParseExact(
              time,
              @"hh\:mm",
              System.Globalization.CultureInfo.InvariantCulture,
              out startTime))
            {
                TimeSpan oneHour = new TimeSpan(1, 0, 0);
                endTime = startTime.Add(oneHour);
            }
            else
            {
                return;
            }
                       
            //TimeSpan startTime = new TimeSpan(Convert.ToInt32(time.Trim().Split('-')[0]),0,0);
            //TimeSpan endTime = new TimeSpan(Convert.ToInt32(time.Trim().Split('-')[1]),0,0);

            if (!string.IsNullOrEmpty(currentDateTime.Split('#')[2] ))
                Flag = Convert.ToBoolean(currentDateTime.Split('#')[2]);
        
            doctorTxt.Text = DoctorName;
            dateTxt.Text = new PersianDateTime(Date.Value).Date.ToString("yyyy/MM/dd") + "   " + new PersianDateTime(Date.Value).DayName;
            fromTimeTxt.Text = Convert.ToString(startTime);
            toTimeTxt.Text = Convert.ToString(endTime);

            if (Flag == null)
                return;

            if (Flag.Value)
            {
                rdoAddToList.Enabled = false;
            }
            else
            {
                rdoRemoveToList.Enabled = false;
            }
        }

        private void rdo_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton rdo = ((RadioButton)sender);

            if(rdo.Name == "rdoRemoveToList")
            {
                rdoAddToList.Checked = !rdoRemoveToList.Checked;
            }
            if (rdo.Name == "rdoAddToList")
            {
                rdoRemoveToList.Checked = !rdoAddToList.Checked;
            }

        }

        public bool ValidatePatientInfo()
        {
            bool isValid = true;

            System.Text.RegularExpressions.Regex regStr;

            regStr = new System.Text.RegularExpressions.Regex(@"^(?:[01]?[0-9]|2[0-3]):[0-5][0-9]$");
            if (!regStr.IsMatch(fromTimeTxt.Text))
            {
                errorProvider1.SetError(fromTimeTxt, "*");
                isValid = false;
            }

            if (!regStr.IsMatch(toTimeTxt.Text))
            {
                errorProvider1.SetError(toTimeTxt, "*");
                isValid = false;
            }
            return isValid;
        }
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (this.ValidatePatientInfo() == false)
            {
                return;
            }

            dynamic iObj = new System.Dynamic.ExpandoObject();
            iObj.DoctorId = DoctorId;
            iObj.FromDate = Date;
            iObj.ToDate = Date;
            iObj.IsDeleted = Flag;
            List<dynamic> weekDayTimes = new List<dynamic>();

            
            TimeSpan sTime = TimeSpan.Parse(this.fromTimeTxt.Text);
            TimeSpan eTime = TimeSpan.Parse(this.toTimeTxt.Text);
           
            var dayName = Date.Value.ToString("dddd");
            while(sTime < eTime)
            {                    
                weekDayTimes.Add(new { DayName = dayName, StartTime = sTime, EndTime = sTime.Add(TimeSpan.FromHours(1)) });
                sTime = sTime.Add(TimeSpan.FromHours(1));
            }
                

            iObj.WeekDayTimes = weekDayTimes;

            JsonResponse<dynamic> result = Dentistry.DataProvider.DefineWorkTimeX(iObj);
            if (result.Success == true)
            {
                FarsiMessageBox.FMessageBox.Show("اطلاعات با موفقیت ثبت شدند", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                //this.DialogResult = DialogResult.OK;
            }
            else
            {
                FarsiMessageBox.FMessageBox.Show("خظا در ثبت اطلاعات", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
            }


                
           
                
            
         
        }
    }
}
