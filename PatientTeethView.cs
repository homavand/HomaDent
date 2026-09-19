using SparksToothChart;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections;
using PopupControl;

namespace Dentistry
{
    public partial class PatientTeethView : Form
    {
        PopupControl.Popup pp;
        Color BtnDefaultColor = Color.FromArgb(58, 45, 73);
        Color BtnSelectedColor = Color.FromArgb(91, 68, 156);

        //Class.WaitFormFunc waitForm = new Class.WaitFormFunc();

        private string ToothName;

        // Guards against NumericBtn_ValueChanged firing (and calling
        // TeethChart.MoveTooth) when we are only programmatically syncing
        // the spinner controls to a newly-selected tooth's stored values in
        // SetSelectedTooth - not responding to an actual user edit.
        private bool _isSyncingSelectedToothUI = false;

        public int? PatientId = null;
        public int? DoctorId = null;

        public string SurfaceTooth = "";
        public ArrayList PatientServices = new ArrayList();
        public ArrayList TeethList = new ArrayList();
        public List<Class.ToothInfo> PatientTeeth = new List<Class.ToothInfo>();
        public enum TeethType
        {
            Primary,
            Permanent
        }
        public PatientTeethView(int patientId, string patientName, int doctorId)
        {
            InitializeComponent();

            this.PatientId = patientId;
            this.DoctorId = doctorId;
            this.Text = string.Format(" {0} ", patientName);
        }

        private void PatientTeethView_Load(object sender, EventArgs e)
        {

            //waitForm.Show(this);

            var swTotal = System.Diagnostics.Stopwatch.StartNew();
            var log = new System.Text.StringBuilder();
            var sw = System.Diagnostics.Stopwatch.StartNew();

            if (this.PatientId != null)
            {
                this.GetTeethData();
                log.AppendLine("1. GetTeethData(): " + sw.ElapsedMilliseconds + " ms"); sw.Restart();

                this.GetPatientTeethInfos(this.PatientId.Value);
                log.AppendLine("2. GetPatientTeethInfos(): " + sw.ElapsedMilliseconds + " ms"); sw.Restart();

                this.GetPatientServices(this.PatientId.Value);
                log.AppendLine("3. GetPatientServices(): " + sw.ElapsedMilliseconds + " ms"); sw.Restart();

                this.GetToothServices();
                log.AppendLine("4. GetToothServices(): " + sw.ElapsedMilliseconds + " ms"); sw.Restart();

                this.chkAtfal_CheckedChanged(this, null);
                log.AppendLine("5. chkAtfal_CheckedChanged(): " + sw.ElapsedMilliseconds + " ms"); sw.Restart();

                this.CheckTeethDescriptions();
                log.AppendLine("6. CheckTeethDescriptions(): " + sw.ElapsedMilliseconds + " ms"); sw.Restart();
            }

            this.SetToolTip();
            log.AppendLine("7. SetToolTip(): " + sw.ElapsedMilliseconds + " ms");
            log.AppendLine("TOTAL: " + swTotal.ElapsedMilliseconds + " ms");

            try
            {
                System.IO.File.AppendAllText(@"C:\temp\perf_log_teeth.txt",
                    "==== " + DateTime.Now.ToString("HH:mm:ss.fff") + " ====\r\n" + log.ToString() + "\r\n");
            }
            catch { /* ignore logging failures */ }

            //waitForm.Close();
        }

        private void GetPatientTeethInfos(int patientId)
        {
            this.ResetButton();
            TeethChart.ResetTeeth();

            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.PatientId = patientId;

            //JsonResponse<dynamic> result = DataProvider.GetPatientTeethInfos(sObj);
            JsonResponse<dynamic> result = DataProvider.GetPatientTeethInfos_diagnostic(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;
            var list = result.Data as IEnumerable<dynamic>;

            if (list != null)
            {
                //Parallel.ForEach(list, item =>
                //{
                //    Class.ToothInfo tooth = new Class.ToothInfo(item);

                //    bool isToothExist = PatientTeeth.Exists(x => x.ToothId == tooth.ToothId);
                //    if (!isToothExist)
                //        PatientTeeth.Add(tooth);
                //});
                foreach (dynamic item in list)
                {
                    Class.ToothInfo tooth = new Class.ToothInfo(item);

                    bool isToothExist = PatientTeeth.Exists(x => x.ToothId == tooth.ToothId);
                    if (!isToothExist)
                        PatientTeeth.Add(tooth);

                }
            }

        }
        private void GetTeethData()
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();

            JsonResponse<dynamic> result = DataProvider.GetToothX(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;
            var dd = result.Data;

            var list = dd != null ? (dd as IEnumerable<dynamic>)
                                                            .Select(i =>
                                                                new
                                                                {
                                                                    i.Id,
                                                                    Tooth = string.Join("  -  ", string.Format("({0}) {1}", i.ToothName, i.ToothTitle)),
                                                                    i.ToothImage,

                                                                }).ToList() : Enumerable.Empty<dynamic>();


            if (result == null || result.Success == false || result.Data == null)
                return;


            System.Collections.ArrayList arrayList = new System.Collections.ArrayList();

            foreach (var item in list as IEnumerable<dynamic>)
            {

                arrayList.Add(
                new
                {
                    item.Id,
                    item.Tooth,
                    item.ToothImage
                });

            }

            this.TeethList = arrayList;

        }
        public void GetPatientServices(int patientId)
        {
            dynamic sObj = new System.Dynamic.ExpandoObject();
            sObj.PatientId = patientId;
            sObj.IsDeleted = false;


            JsonResponse<dynamic> result = DataProvider.GetPatientServicesX(sObj);
            if (result == null || result.Success == false || result.Data == null)
                return;
            var dd = result.Data;

            IEnumerable<dynamic> list = dd != null && (Enumerable.Count(dd) >= 0) ? (dd as IEnumerable<dynamic>)
                  .Select(i =>
                  new
                  {
                      i.PatientServiceId,
                      i.ServiceGroupTitle,
                      i.ServiceTitle,
                      i.Tooths
                  }).ToList() : Enumerable.Empty<dynamic>();


            System.Collections.ArrayList serviceList = new System.Collections.ArrayList();

            foreach (var s in list as IEnumerable<dynamic>)
            {
                foreach (var t in s.Tooths as IEnumerable<dynamic>)
                {
                    serviceList.Add(
                    new
                    {
                        s.PatientServiceId,
                        s.ServiceGroupTitle,
                        s.ServiceTitle,
                        t.ToothId,
                        t.ToothImage

                    });
                }
            }

            this.PatientServices = serviceList;

        }

        public void GetToothServices(int toothId = 0)
        {


            foreach (DataGridViewRow row in this.dgToothServices.Rows)
            {
                row.Selected = false;
            }

            IEnumerable<dynamic> list = this.PatientServices.Count > 0 ? this.PatientServices.Cast<dynamic>()
                   .Select(i =>
                   new
                   {
                       i.PatientServiceId,
                       i.ToothId,
                       i.ToothImage,
                       Service = string.Format(" {0} - {1} ", i.ServiceGroupTitle, i.ServiceTitle),
                   }).ToList() : Enumerable.Empty<dynamic>();


            dgToothServices.AutoGenerateColumns = false;
            dgToothServices.Columns["ColumnPatientServiceId"].DisplayIndex = 0;
            dgToothServices.Columns["ColumnToothId"].DisplayIndex = 1;
            dgToothServices.Columns["ColumnToothImage"].DisplayIndex = 2;
            dgToothServices.Columns["ColumnServiceTitle"].DisplayIndex = 3;

            var data = toothId == 0 ? list : list.Where(i => i.ToothId == toothId).ToList();

            this.dgToothServices.Refresh();
            this.dgToothServices.Visible = false;
            this.dgToothServices.DataSource = data;
            this.dgToothServices.Visible = true;
            this.dgToothServices.Refresh();

        }

        private void SetPatientTeeth(TeethType teethType)
        {
            TeethChart.ResetTeeth();

            if (teethType is TeethType.Primary)
            {
                TeethChart.ChartSetToPrimary();

                var list = PatientTeeth.Select(x => x)
                                       .Where(x => x.ToothId >= 33 && x.ToothId <= 52)
                                       .ToList();

                foreach (dynamic toothInfo in list)
                {
                    this.MakeTooth(toothInfo);
                }

            }

            if (teethType is TeethType.Permanent)
            {

                var list = PatientTeeth.Select(x => x)
                                       .Where(x => x.ToothId >= 1 && x.ToothId <= 32)
                                       .ToList();

                foreach (dynamic toothInfo in list)
                {
                    this.MakeTooth(toothInfo);
                }
            }

            //TeethChart.Refresh();
            TeethChart.ResumeLayout();
        }

        public void MakeTooth(Class.ToothInfo toothInfo)
        {
            var obj = toothInfo;

            var toothName = ToothInfoClass.ToothIdToToothName(toothInfo.ToothId);
            ToothGraphic tooth = TeethChart.GetToothInfo(toothName);

            tooth.Visible = toothInfo.Visible;
            tooth.Rotate = toothInfo.Rotate;
            tooth.TipB = toothInfo.TipB;
            tooth.TipM = toothInfo.TipM;
            tooth.ShiftM = toothInfo.ShiftM;
            tooth.ShiftO = toothInfo.ShiftO;
            tooth.ShiftB = toothInfo.ShiftB;
            tooth.IsRCT = toothInfo.IsRCT;
            tooth.IsBU = toothInfo.IsBU;
            tooth.IsImplant = toothInfo.IsImplant;
            tooth.IsCrown = toothInfo.IsCrown;
            tooth.IsPontic = toothInfo.IsPontic;
            tooth.IsSealant = toothInfo.IsSealant;

            tooth.Description = toothInfo.Description;

            var surface_B = toothInfo.Surface_B;
            var surface_F = toothInfo.Surface_F;
            var surface_C = toothInfo.Surface_C;
            var surface_D = toothInfo.Surface_D;
            var surface_E = toothInfo.Surface_E;
            var surface_L = toothInfo.Surface_L;
            var surface_M = toothInfo.Surface_M;
            var surface_O = toothInfo.Surface_O;
            var surface_I = toothInfo.Surface_I;
            var surface_V = toothInfo.Surface_V;

            var surface_B_Color = Color.FromArgb(Convert.ToInt32(toothInfo.Surface_B_Color));
            var surface_F_Color = Color.FromArgb(Convert.ToInt32(toothInfo.Surface_F_Color));
            var surface_C_Color = Color.FromArgb(Convert.ToInt32(toothInfo.Surface_C_Color));
            var surface_D_Color = Color.FromArgb(Convert.ToInt32(toothInfo.Surface_D_Color));
            var surface_E_Color = Color.FromArgb(Convert.ToInt32(toothInfo.Surface_E_Color));
            var surface_L_Color = Color.FromArgb(Convert.ToInt32(toothInfo.Surface_L_Color));
            var surface_M_Color = Color.FromArgb(Convert.ToInt32(toothInfo.Surface_M_Color));
            var surface_O_Color = Color.FromArgb(Convert.ToInt32(toothInfo.Surface_O_Color));
            var surface_I_Color = Color.FromArgb(Convert.ToInt32(toothInfo.Surface_I_Color));
            var surface_V_Color = Color.FromArgb(Convert.ToInt32(toothInfo.Surface_V_Color));

            if (surface_B)
                this.SetToothGroupColor(tooth, ToothGroupType.B, surface_B_Color);

            if (surface_F)
                this.SetToothGroupColor(tooth, ToothGroupType.F, surface_F_Color);

            if (surface_C)
                this.SetToothGroupColor(tooth, ToothGroupType.Cementum, surface_C_Color);

            if (surface_D)
                this.SetToothGroupColor(tooth, ToothGroupType.D, surface_D_Color);

            if (surface_E)
                this.SetToothGroupColor(tooth, ToothGroupType.Enamel, surface_E_Color);

            if (surface_L)
                this.SetToothGroupColor(tooth, ToothGroupType.L, surface_L_Color);

            if (surface_M)
                this.SetToothGroupColor(tooth, ToothGroupType.M, surface_M_Color);

            if (surface_O)
                this.SetToothGroupColor(tooth, ToothGroupType.O, surface_O_Color);

            if (surface_I)
                this.SetToothGroupColor(tooth, ToothGroupType.I, surface_I_Color);

            if (surface_V)
                this.SetToothGroupColor(tooth, ToothGroupType.V, surface_V_Color);

            tooth.ColorRCT = Color.FromArgb(Convert.ToInt32(toothInfo.ColorRCT));
            tooth.ColorBU = Color.FromArgb(Convert.ToInt32(toothInfo.ColorBU));
            tooth.ColorImplant = Color.FromArgb(Convert.ToInt32(toothInfo.ColorImplant));
            tooth.ColorSealant = Color.FromArgb(Convert.ToInt32(toothInfo.ColorSealant));

            string surface = "";
            surface = toothInfo.Surface;
            tooth.Surface = surface;



            if (tooth.IsImplant)
            {
                TeethChart.SetImplant(tooth.ToothId, tooth.ColorImplant);
            }
            if (tooth.IsBU)
            {
                TeethChart.SetBU(tooth.ToothId, tooth.ColorBU);
            }
            if (tooth.IsRCT)
            {
                TeethChart.SetRCT(tooth.ToothId, tooth.ColorRCT);
            }
            if (tooth.Visible == false)
            {
                TeethChart.SetInvisible(tooth.ToothId);
            }
            if (tooth.IsPontic)
            {
                TeethChart.SetPontic(tooth.ToothId, Color.Red);
            }

            //TeethChart.MoveTooth(tooth.ToothId, th.Rotate, th.TipM, th.TipB, th.ShiftM, th.ShiftO, th.ShiftB);
        }

        public void GetToothData(int toothId)
        {
            var tooth = this.TeethList.Count > 0 ? this.TeethList.Cast<dynamic>()
                                      .Where(i => i.Id == toothId)
                                      .Select(i =>
                                        new
                                        {
                                            i.Tooth,
                                            i.ToothImage,

                                        }).FirstOrDefault() : null;

            if (tooth == null)
                return;

            if (tooth.Tooth != null)
            {
                this.toothTxt.Text = Convert.ToString(tooth.Tooth); ;
            }

            if (tooth.ToothImage != null)
            {
                System.IO.MemoryStream memoryStream = new System.IO.MemoryStream((byte[])tooth.ToothImage);
                Image image = Image.FromStream(memoryStream);
                memoryStream.Close();
                this.toothImg.Image = image;
            }


        }


        private void SetToolTip()
        {
            toolTip1.SetToolTip(CxBtn, "Cementum");
            toolTip1.SetToolTip(ExBtn, "Enamel");
            toolTip1.SetToolTip(DxBtn, "D");
            toolTip1.SetToolTip(MxBtn, "M");
            toolTip1.SetToolTip(BFxBtn, "B\nF");
            toolTip1.SetToolTip(VxBtn, "V");
            toolTip1.SetToolTip(LxBtn, "L");
            toolTip1.SetToolTip(OIxBtn, "O\nI");

            toolTip1.SetToolTip(RightLbl, "Right");
            toolTip1.SetToolTip(LeftLbl, "Left");
        }

        private void TeethChart_ToothSelectedEvent(object sender, ToothEventArgs e)
        {
            TeethChart.TeethDeSelected();
            this.ResetButton();
            var toothName = e.ToothId;
            int toothId = ToothInfoClass.ToothNameToToothId(toothName);

            this.SetSelectedTooth(toothName);

            this.GetToothData(toothId);

            this.GetToothServices(toothId);
        }

        public void SetSelectedTooth(string toothName)
        {

            TeethChart.SetSelected(toothName, true);


            ToothGraphic tooth = TeethChart.GetToothInfo(toothName);

            _isSyncingSelectedToothUI = true;
            try
            {
                this.RotateBtn.Value = Convert.ToDecimal(tooth.Rotate);
                this.TipMxBtn.Value = Convert.ToDecimal(tooth.TipM);
                this.TipBxBtn.Value = Convert.ToDecimal(tooth.TipB);
                this.ShiftMxBtn.Value = Convert.ToDecimal(tooth.ShiftM);
                this.ShiftOxBtn.Value = Convert.ToDecimal(tooth.ShiftO);
                this.ShiftBxBtn.Value = Convert.ToDecimal(tooth.ShiftB);
            }
            finally
            {
                _isSyncingSelectedToothUI = false;
            }

            // Keep Tag ("previous value" used by NumericBtn_ValueChanged to
            // detect increment direction) in sync with this tooth's real
            // values - otherwise the first real user edit on this tooth
            // computes its direction against the previous tooth's leftover
            // value.
            this.RotateBtn.Tag = this.RotateBtn.Value;
            this.TipMxBtn.Tag = this.TipMxBtn.Value;
            this.TipBxBtn.Tag = this.TipBxBtn.Value;
            this.ShiftMxBtn.Tag = this.ShiftMxBtn.Value;
            this.ShiftOxBtn.Tag = this.ShiftOxBtn.Value;
            this.ShiftBxBtn.Tag = this.ShiftBxBtn.Value;

            var toothGroups = tooth.Groups;

            if (!tooth.IsImplant)
            {
                for (int i = 0; i < toothGroups.Count; i++)
                {
                    SparksToothChart.ToothGroup thGroup = (SparksToothChart.ToothGroup)toothGroups[i];
                    var group = thGroup.GroupType;

                    switch (group)
                    {
                        case (ToothGroupType.B):
                        case (ToothGroupType.F):
                            if (thGroup.PaintColor != Color.FromArgb(255, 255, 253, 209))
                                BFxBtn.BackColor = this.BtnSelectedColor;
                            else
                                BFxBtn.BackColor = this.BtnDefaultColor;
                            break;
                        case (ToothGroupType.Cementum):
                            if (thGroup.PaintColor != Color.FromArgb(255, 243, 234, 176))
                                CxBtn.BackColor = this.BtnSelectedColor;
                            else
                                CxBtn.BackColor = this.BtnDefaultColor;
                            break;
                        case (ToothGroupType.D):
                            if (thGroup.PaintColor != Color.FromArgb(255, 255, 253, 209))
                                DxBtn.BackColor = this.BtnSelectedColor;
                            else
                                DxBtn.BackColor = this.BtnDefaultColor;
                            break;
                        case (ToothGroupType.Enamel):
                            if (thGroup.PaintColor != Color.FromArgb(255, 255, 253, 209))
                                ExBtn.BackColor = this.BtnSelectedColor;
                            else
                                ExBtn.BackColor = this.BtnDefaultColor;
                            break;
                        case (ToothGroupType.L):
                            if (thGroup.PaintColor != Color.FromArgb(255, 255, 253, 209))
                                LxBtn.BackColor = this.BtnSelectedColor;
                            else
                                LxBtn.BackColor = this.BtnDefaultColor;
                            break;
                        case (ToothGroupType.M):
                            if (thGroup.PaintColor != Color.FromArgb(255, 255, 253, 209))
                                MxBtn.BackColor = this.BtnSelectedColor;
                            else
                                MxBtn.BackColor = this.BtnDefaultColor;
                            break;
                        case (ToothGroupType.O):
                            if (thGroup.PaintColor != Color.FromArgb(255, 255, 253, 209))
                                OIxBtn.BackColor = this.BtnSelectedColor;
                            else
                                OIxBtn.BackColor = this.BtnDefaultColor;
                            break;
                        case (ToothGroupType.V):
                            if (thGroup.PaintColor != Color.FromArgb(255, 255, 253, 209))
                                VxBtn.BackColor = this.BtnSelectedColor;
                            else
                                VxBtn.BackColor = this.BtnDefaultColor;
                            break;
                    }
                }
            }

            if (tooth.IsBU)
            {
                btnBuildup.BackColor = this.BtnSelectedColor;
            }
            else
            {
                btnBuildup.BackColor = this.BtnDefaultColor;
            }


            if (tooth.IsRCT)
            {
                btnRCT.BackColor = this.BtnSelectedColor;
            }
            else
            {
                btnRCT.BackColor = this.BtnDefaultColor;
            }

            if (tooth.IsImplant)
            {
                btnImplant.BackColor = this.BtnSelectedColor;
            }
            else
            {
                btnImplant.BackColor = this.BtnDefaultColor;
            }

            if (!tooth.Visible)
            {
                btnExtract.BackColor = this.BtnSelectedColor;
            }
            else
            {
                btnExtract.BackColor = this.BtnDefaultColor;
            }
        }





        private void chkAtfal_CheckedChanged(object sender, EventArgs e)
        {
            if (chkAtfal.Checked)
            {
                this.SetPatientTeeth(TeethType.Primary);
                this.PermanentTopThPnl.Visible = false;
                this.PermanentBotThPnl.Visible = false;
                this.PrimaryTopThPnl.Visible = true;
                this.PrimaryBotThPnl.Visible = true;
            }
            else
            {

                //this.FillChart(this.PatientServiceId.Value);
                this.SetPatientTeeth(TeethType.Permanent);
                this.PermanentTopThPnl.Visible = true;
                this.PermanentBotThPnl.Visible = true;
                this.PrimaryTopThPnl.Visible = false;
                this.PrimaryBotThPnl.Visible = false;
            }
        }



        private bool checkValidate_Teeth()
        {
            if (TeethChart.SelectedTeeth.Length == 0)
            {
                FarsiMessageBox.FMessageBox.Show("لطفا دندان را انتخاب نمایید", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                return false; ;
            }
            return true;
        }


        private void ResetButton()
        {
            this.RotateBtn.Tag = 0;
            this.ShiftMxBtn.Tag = 0;
            this.TipMxBtn.Tag = 0;
            this.ShiftOxBtn.Tag = 0;
            this.TipBxBtn.Tag = 0;
            this.ShiftBxBtn.Tag = 0;


            this.DxBtn.BackColor = this.BtnDefaultColor;
            this.LxBtn.BackColor = this.BtnDefaultColor;
            this.MxBtn.BackColor = this.BtnDefaultColor;
            this.OIxBtn.BackColor = this.BtnDefaultColor;
            this.VxBtn.BackColor = this.BtnDefaultColor;
            this.CxBtn.BackColor = this.BtnDefaultColor;
            this.ExBtn.BackColor = this.BtnDefaultColor;
            this.BFxBtn.BackColor = this.BtnDefaultColor;

            this.btnBuildup.BackColor = this.BtnDefaultColor;
            this.btnRCT.BackColor = this.BtnDefaultColor;
            this.btnImplant.BackColor = this.BtnDefaultColor;
            this.btnExtract.BackColor = this.BtnDefaultColor;
            this.btnReset.BackColor = this.BtnDefaultColor;
            this.btnX.BackColor = this.BtnDefaultColor;
        }

        private void NumericBtn_ValueChanged(object sender, EventArgs e)
        {
            if (_isSyncingSelectedToothUI)
                return;

            if (!checkValidate_Teeth())
                return;

            var ctr = ((NumericUpDown)sender);
            int oldValue = Convert.ToInt32(ctr.Tag);
            float increment = (float)Convert.ToDouble(ctr.Increment);

            if (ctr.Value < oldValue)
                increment = increment * (-1);

            for (int i = 0; i < TeethChart.SelectedTeeth.Length; i++)
            {
                ToothGraphic tooth = TeethChart.GetToothInfo(TeethChart.SelectedTeeth[i].ToString());
                //ToothGraphic th = new ToothGraphic(chart.SelectedTeeth[i].ToString());
                string ctrName = ctr.Name;
                switch (ctrName)
                {
                    case "RotateBtn":
                        TeethChart.MoveTooth(TeethChart.SelectedTeeth[i], increment, 0, 0, 0, 0, 0);
                        //AddMonement(i, Convert.ToInt32(ToothInitialType.Rotate), Convert.ToInt32(Rotate), Convert.ToInt32(sufr[i, 1]), sufr[i, 0], 1, 0, 0);
                        tooth.Rotate = Convert.ToInt32(ctr.Value);
                        break;
                    case "TipMxBtn":
                        TeethChart.MoveTooth(TeethChart.SelectedTeeth[i], 0, increment, 0, 0, 0, 0);
                        tooth.TipM = Convert.ToInt32(TipMxBtn.Value);
                        break;
                    case "TipBxBtn":
                        TeethChart.MoveTooth(TeethChart.SelectedTeeth[i], 0, 0, increment, 0, 0, 0);
                        tooth.TipB = Convert.ToInt32(TipBxBtn.Value);
                        break;
                    case "ShiftMxBtn":
                        TeethChart.MoveTooth(TeethChart.SelectedTeeth[i], 0, 0, 0, increment, 0, 0);
                        tooth.ShiftM = Convert.ToInt32(ShiftMxBtn.Value);
                        break;
                    case "ShiftOxBtn":
                        TeethChart.MoveTooth(TeethChart.SelectedTeeth[i], 0, 0, 0, 0, increment, 0);
                        tooth.ShiftO = Convert.ToInt32(ShiftOxBtn.Value);
                        break;
                    case "ShiftBxBtn":
                        TeethChart.MoveTooth(TeethChart.SelectedTeeth[i], 0, 0, 0, 0, 0, increment);
                        tooth.ShiftB = Convert.ToInt32(ShiftBxBtn.Value);
                        break;
                }

            }
            ctr.Tag = ctr.Value;
        }

        private void btnRCT_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.BackColor == this.BtnSelectedColor)
            {
                btn.BackColor = this.BtnDefaultColor;
            }
            else
            {
                btn.BackColor = this.BtnSelectedColor;
            }

            for (int i = 0; i < TeethChart.SelectedTeeth.Length; i++)
            {
                var toothId = TeethChart.SelectedTeeth[i];
                ToothGraphic tooth = TeethChart.GetToothInfo(toothId);

                if (!tooth.Visible)
                {
                    btn.BackColor = this.BtnDefaultColor;
                    FarsiMessageBox.FMessageBox.Show("این دندان Extract شده است", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    return;
                }

                if (tooth.IsImplant)
                {
                    btn.BackColor = this.BtnDefaultColor;
                    FarsiMessageBox.FMessageBox.Show("این دندان Implant شده است", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    return;
                }

                if (btn.BackColor == this.BtnSelectedColor)
                {
                    TeethChart.SetRCT(tooth.ToothId, colorLbl.BackColor);
                }
                else
                {
                    TeethChart.ResetRCT(tooth.ToothId);
                }
                //tooth.IsRCT = true;
                //tooth.ColorRCT = colorLbl.BackColor;//.ToArgb();

                //TeethChart.SetRCT(tooth.ToothId, colorLbl.BackColor);
                //TeethChart.Setvisible(tooth.ToothId);
            }
            TeethChart.Refresh();

        }



        private void btn_Buildup_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.BackColor == this.BtnSelectedColor)
            {
                btn.BackColor = this.BtnDefaultColor;
            }
            else
            {
                btn.BackColor = this.BtnSelectedColor;
            }

            for (int i = 0; i < TeethChart.SelectedTeeth.Length; i++)
            {
                var toothId = TeethChart.SelectedTeeth[i];
                ToothGraphic tooth = TeethChart.GetToothInfo(toothId);

                if (!tooth.Visible)
                {
                    btn.BackColor = this.BtnDefaultColor;
                    FarsiMessageBox.FMessageBox.Show("این دندان Extract شده است", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    return;
                }

                if (tooth.IsImplant)
                {
                    btn.BackColor = this.BtnDefaultColor;
                    FarsiMessageBox.FMessageBox.Show("این دندان Implant شده است", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    return;
                }

                if (btn.BackColor == this.BtnSelectedColor)
                {
                    TeethChart.SetBU(tooth.ToothId, colorLbl.BackColor);
                }
                else
                {
                    TeethChart.ResetBU(tooth.ToothId);
                }



            }
            TeethChart.Refresh();


        }

        private void btnDrawBigX_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.BackColor == this.BtnSelectedColor)
            {
                btn.BackColor = this.BtnDefaultColor;
            }
            else
            {
                btn.BackColor = this.BtnSelectedColor;
            }

            for (int i = 0; i < TeethChart.SelectedTeeth.Length; i++)
            {
                var toothId = TeethChart.SelectedTeeth[i];
                ToothGraphic tooth = TeethChart.GetToothInfo(toothId);

                if (!tooth.Visible)
                {
                    btn.BackColor = this.BtnDefaultColor;
                    FarsiMessageBox.FMessageBox.Show("این دندان Extract شده است", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    return;
                }

                if (tooth.IsImplant)
                {
                    btn.BackColor = this.BtnDefaultColor;
                    FarsiMessageBox.FMessageBox.Show("این دندان Implant شده است", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    return;
                }

                if (btn.BackColor == this.BtnSelectedColor)
                {
                    tooth.DrawBigX = true;
                }
                else
                {
                    tooth.DrawBigX = false;
                }


            }
            TeethChart.Refresh();

        }

        private void btnSealant_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.BackColor == this.BtnSelectedColor)
            {
                btn.BackColor = this.BtnDefaultColor;
            }
            else
            {
                btn.BackColor = this.BtnSelectedColor;
            }

            for (int i = 0; i < TeethChart.SelectedTeeth.Length; i++)
            {
                var toothId = TeethChart.SelectedTeeth[i];
                ToothGraphic tooth = TeethChart.GetToothInfo(toothId);

                if (!tooth.Visible)
                {
                    btn.BackColor = this.BtnDefaultColor;
                    FarsiMessageBox.FMessageBox.Show("این دندان Extract شده است", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    return;
                }

                if (tooth.IsImplant)
                {
                    btn.BackColor = this.BtnDefaultColor;
                    FarsiMessageBox.FMessageBox.Show("این دندان Implant شده است", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    return;
                }

                if (btn.BackColor == this.BtnSelectedColor)
                {
                    tooth.IsSealant = true;
                }
                else
                {
                    tooth.IsSealant = false;
                }
            }

            TeethChart.Refresh();
        }
        private void btnCrown_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.BackColor == this.BtnSelectedColor)
            {
                btn.BackColor = this.BtnDefaultColor;
            }
            else
            {
                btn.BackColor = this.BtnSelectedColor;
            }

            for (int i = 0; i < TeethChart.SelectedTeeth.Length; i++)
            {
                var toothId = TeethChart.SelectedTeeth[i];
                ToothGraphic tooth = TeethChart.GetToothInfo(toothId);

                if (!tooth.Visible)
                {
                    btn.BackColor = this.BtnDefaultColor;
                    FarsiMessageBox.FMessageBox.Show("این دندان Extract شده است", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    return;
                }

                if (tooth.IsImplant)
                {
                    btn.BackColor = this.BtnDefaultColor;
                    FarsiMessageBox.FMessageBox.Show("این دندان Implant شده است", "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    return;
                }

                if (btn.BackColor == this.BtnSelectedColor)
                {
                    TeethChart.SetCrown(tooth.ToothId, colorLbl.BackColor);
                }
                else
                {
                    TeethChart.ResetCrown(tooth.ToothId);
                }


            }
            TeethChart.Refresh();
        }
        private void btnImplant_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Color btnColor = btn.BackColor;

            this.ResetButton();

            btn.BackColor = btnColor;

            if (btn.BackColor == this.BtnSelectedColor)
            {
                btn.BackColor = this.BtnDefaultColor;
            }
            else
            {
                btn.BackColor = this.BtnSelectedColor;
            }

            for (int i = 0; i < TeethChart.SelectedTeeth.Length; i++)
            {
                var toothId = TeethChart.SelectedTeeth[i];
                ToothGraphic tooth = TeethChart.GetToothInfo(toothId);

                if (btn.BackColor == this.BtnSelectedColor)
                {
                    TeethChart.SetImplant(tooth.ToothId, colorLbl.BackColor);
                }
                else
                {
                    TeethChart.ResetImplant(tooth.ToothId);
                }




            }
            TeethChart.Refresh();

        }
        private void btnExtract_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Color btnColor = btn.BackColor;

            this.ResetButton();

            btn.BackColor = btnColor;

            if (btn.BackColor == this.BtnSelectedColor)
            {
                btn.BackColor = this.BtnDefaultColor;
            }
            else
            {
                btn.BackColor = this.BtnSelectedColor;
            }

            for (int i = 0; i < TeethChart.SelectedTeeth.Length; i++)
            {
                var toothId = TeethChart.SelectedTeeth[i];
                ToothGraphic tooth = TeethChart.GetToothInfo(toothId);


                if (btn.BackColor == this.BtnSelectedColor)
                {
                    TeethChart.SetExtract(tooth.ToothId);
                }
                else
                {
                    TeethChart.ResetExtract(tooth.ToothId);
                }

            }
            TeethChart.Refresh();

        }



        private void btnReset_Click(object sender, EventArgs e)
        {
            var result = FarsiMessageBox.FMessageBox.Show(String.Format("{0}\n\n{1}\n\n{2}", "کاربر گرامی", "Reset کردن دندان تمام حالتهای انتخابی را حذف میکند ", "آیا از انجام این اقدام اطمینان دارید؟"),
                                                          "پیام",
                                                          FarsiMessageBox.FMessageBoxButtons.OKCancel,
                                                          FarsiMessageBox.FMessageBoxIcons.Question,
                                                          FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
            if (result != System.Windows.Forms.DialogResult.OK)
                return;

            this.ResetButton();

            ToothGraphic tooth = null;
            for (int i = 0; i < TeethChart.SelectedTeeth.Length; i++)
            {
                var toothId = TeethChart.SelectedTeeth[i];
                tooth = TeethChart.GetToothInfo(toothId);

                //th.SetGroupColor((ToothGroupType)7,Color.Red);

                tooth.Reset();
            }
            TeethChart.Refresh();

        }
        private void colorLbl_Click(object sender, EventArgs e)
        {
            ColorDialog colorDialog1 = new ColorDialog();
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                colorLbl.BackColor = colorDialog1.Color;
            }

        }



        #region UpdateSurf
        private void UpdateSurf(object sender, EventArgs e)
        {

            if (!checkValidate_Teeth())
                return;

            var toothId = TeethChart.SelectedTeeth[0];
            ToothGraphic tooth = TeethChart.GetToothInfo(toothId);

            Color color = colorLbl.BackColor;


            Button btn = (Button)sender;

            if (btn.BackColor == this.BtnSelectedColor)
            {
                btn.BackColor = this.BtnDefaultColor;
            }
            else
            {
                btn.BackColor = this.BtnSelectedColor;
            }

            string Surfaces = tooth.Surface == null ? "" : tooth.Surface.ToString();

            if (TeethChart.SelectedTeeth.Length == 0)
            {
                return;
            }

            if (btn == MxBtn)
            {
                if (btn.BackColor == this.BtnSelectedColor)
                {
                    if (Surfaces.Contains('M') == false)
                        Surfaces += 'M';
                    tooth.SetGroupColor(ToothGroupType.M, color);
                }
                else
                {
                    if (Surfaces.Contains('M') == true)
                        Surfaces = Surfaces.Replace('M'.ToString(), String.Empty);
                    this.SetDefaultColors(tooth.Groups, ToothGroupType.M);
                }
            }

            if (btn == OIxBtn)
            {
                if (btn.BackColor == this.BtnSelectedColor)
                {
                    if (ToothGraphic.IsAnterior(tooth.ToothId))
                    {
                        if (Surfaces.Contains('I') == false)
                            Surfaces += 'I';
                        tooth.SetGroupColor(ToothGroupType.I, color);
                    }
                    else
                    {
                        if (Surfaces.Contains('O') == false)
                            Surfaces += 'O';
                        tooth.SetGroupColor(ToothGroupType.O, color);
                    }

                }
                else
                {
                    if (ToothGraphic.IsAnterior(tooth.ToothId))
                    {
                        if (Surfaces.Contains('I') == true)
                            Surfaces = Surfaces.Replace('I'.ToString(), String.Empty);
                        this.SetDefaultColors(tooth.Groups, ToothGroupType.I);
                    }
                    else
                    {
                        if (Surfaces.Contains('O') == true)
                            Surfaces = Surfaces.Replace('O'.ToString(), String.Empty);
                        this.SetDefaultColors(tooth.Groups, ToothGroupType.O);
                    }


                }
            }

            if (btn == DxBtn)
            {
                if (btn.BackColor == this.BtnSelectedColor)
                {
                    if (Surfaces.Contains('D') == false)
                        Surfaces += 'D';
                    tooth.SetGroupColor(ToothGroupType.D, color);
                }
                else
                {
                    if (Surfaces.Contains('D') == true)
                        Surfaces = Surfaces.Replace('D'.ToString(), String.Empty);
                    this.SetDefaultColors(tooth.Groups, ToothGroupType.D);
                }
            }

            if (btn == VxBtn)
            {
                if (btn.BackColor == this.BtnSelectedColor)
                {
                    if (Surfaces.Contains('V') == false)
                        Surfaces += 'V';
                    tooth.SetGroupColor(ToothGroupType.V, color);
                }
                else
                {
                    if (Surfaces.Contains('V') == true)
                        Surfaces = Surfaces.Replace('V'.ToString(), String.Empty);
                    this.SetDefaultColors(tooth.Groups, ToothGroupType.V);
                }
            }



            if (btn == BFxBtn)
            {
                if (btn.BackColor == this.BtnSelectedColor)
                {
                    if (ToothGraphic.IsAnterior(toothId))
                    {
                        if (Surfaces.Contains('F') == false)
                            Surfaces += 'F';
                        tooth.SetGroupColor(ToothGroupType.F, color);
                    }
                    else
                    {
                        if (Surfaces.Contains('B') == false)
                            Surfaces += 'B';
                        tooth.SetGroupColor(ToothGroupType.B, color);
                    }

                }
                else
                {
                    if (ToothGraphic.IsAnterior(toothId))
                    {
                        if (Surfaces.Contains('F') == true)
                            Surfaces = Surfaces.Replace('F'.ToString(), String.Empty);
                        this.SetDefaultColors(tooth.Groups, ToothGroupType.F);
                    }
                    else
                    {
                        if (Surfaces.Contains('B') == true)
                            Surfaces = Surfaces.Replace('B'.ToString(), String.Empty);
                        this.SetDefaultColors(tooth.Groups, ToothGroupType.B);
                    }


                }
            }

            if (btn == LxBtn)
            {
                if (btn.BackColor == this.BtnSelectedColor)
                {
                    if (Surfaces.Contains('L') == false)
                        Surfaces += 'L';
                    tooth.SetGroupColor(ToothGroupType.L, color);
                }
                else
                {
                    if (Surfaces.Contains('L') == true)
                        Surfaces = Surfaces.Replace('L'.ToString(), String.Empty);
                    this.SetDefaultColors(tooth.Groups, ToothGroupType.L);
                }
            }


            if (btn == CxBtn)
            {
                if (btn.BackColor == this.BtnSelectedColor)
                {
                    if (Surfaces.Contains('C') == false)
                        Surfaces += 'C';
                    tooth.SetGroupColor(ToothGroupType.Cementum, color);
                }
                else
                {
                    if (Surfaces.Contains('C') == true)
                        Surfaces = Surfaces.Replace('C'.ToString(), String.Empty);
                    this.SetDefaultColors(tooth.Groups, ToothGroupType.Cementum);
                }
            }


            if (btn == ExBtn)
            {
                if (btn.BackColor == this.BtnSelectedColor)
                {
                    if (Surfaces.Contains('E') == false)
                        Surfaces += 'E';
                    tooth.SetGroupColor(ToothGroupType.Enamel, color);
                }
                else
                {
                    if (Surfaces.Contains('E') == true)
                        Surfaces = Surfaces.Replace('E'.ToString(), String.Empty);
                    this.SetDefaultColors(tooth.Groups, ToothGroupType.Enamel);
                }
            }



            this.SurfaceTooth = Surfaces.Trim();
            //TeethChart.ClearSurfacesTeeth(tooth.ToothId);
            tooth.Surface = Surfaces.Trim();
            tooth.SurfaceColor = colorLbl.BackColor;

            //TeethChart.SetSurfaceColors(tooth.ToothId, tooth.Surface, tooth.SurfaceColor);

            TeethChart.Refresh();

        }

        private void SetDefaultColors(System.Collections.ArrayList Groups, ToothGroupType g)
        {
            for (int i = 0; i < Groups.Count; i++)
            {
                var group = ((ToothGroup)Groups[i]);

                if (group.GroupType != g)
                    continue;

                if (group.GroupType == ToothGroupType.Cementum)
                {
                    group.PaintColor = Color.FromArgb(255, 243, 234, 176);
                }
                else
                {
                    group.PaintColor = Color.FromArgb(255, 255, 253, 209);
                }

                if (group.GroupType == ToothGroupType.Canals || group.GroupType == ToothGroupType.Buildup)
                {
                    group.Visible = false;
                }
                else
                {
                    group.Visible = true;
                }
            }
        }

        #endregion
        private void SetToothGroupColor(ToothGraphic tooth, ToothGroupType g, Color color)
        {

            if (tooth == null)
                return;

            switch (g)
            {
                case (ToothGroupType.B):
                    tooth.SetGroupColor(ToothGroupType.B, color);
                    break;
                case (ToothGroupType.Cementum):
                    tooth.SetGroupColor(ToothGroupType.Cementum, color);
                    break;
                case (ToothGroupType.D):
                    tooth.SetGroupColor(ToothGroupType.D, color);
                    break;
                case (ToothGroupType.Enamel):
                    tooth.SetGroupColor(ToothGroupType.Enamel, color);
                    break;
                case (ToothGroupType.L):
                    tooth.SetGroupColor(ToothGroupType.L, color);
                    break;
                case (ToothGroupType.M):
                    tooth.SetGroupColor(ToothGroupType.M, color);
                    break;
                case (ToothGroupType.O):
                    tooth.SetGroupColor(ToothGroupType.O, color);
                    break;
                case (ToothGroupType.V):
                    tooth.SetGroupColor(ToothGroupType.V, color);
                    break;

            }


        }

        private Color? GetToothGroupColor(ToothGraphic tooth, ToothGroupType g)
        {
            Color? color = null;

            if (tooth == null)
                return color;



            var toothGroups = tooth.Groups;

            for (int i = 0; i < toothGroups.Count; i++)
            {
                SparksToothChart.ToothGroup thGroup = (SparksToothChart.ToothGroup)toothGroups[i];
                var group = thGroup.GroupType;

                if (group != g)
                    continue;

                switch (group)
                {
                    case (ToothGroupType.B):
                        color = thGroup.PaintColor;
                        break;
                    case (ToothGroupType.Cementum):
                        color = thGroup.PaintColor;
                        break;
                    case (ToothGroupType.D):
                        color = thGroup.PaintColor;
                        break;
                    case (ToothGroupType.Enamel):
                        color = thGroup.PaintColor;
                        break;
                    case (ToothGroupType.L):
                        color = thGroup.PaintColor;
                        break;
                    case (ToothGroupType.M):
                        color = thGroup.PaintColor;
                        break;
                    case (ToothGroupType.O):
                        color = thGroup.PaintColor;
                        break;
                    case (ToothGroupType.V):
                        color = thGroup.PaintColor;
                        break;
                }

                if (color != null)
                    break;
            }

            return color;
        }


        private void SaveActionBtn_Click(object sender, EventArgs e)
        {

            //if (FarsiMessageBox.FMessageBox.Show("آیا برای ثبت درمان برای این بیمار مطمئن هستید؟", "پیام", FarsiMessageBox.FMessageBoxButtons.OKCancel, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1) != System.Windows.Forms.DialogResult.OK)
            //{
            //    return;
            //}


            int patientServiceToothId = 0;

            try
            {
                List<dynamic> toothList = new List<dynamic>();

                var start = 1;
                var end = 32;
                if (this.chkAtfal.Checked)
                {
                    start = 33;
                    end = 52;
                }

                int counter = 0;
                for (int i = start; i <= end; i++)
                {
                    string toothNum = ToothInfoClass.ToothIdToToothName(i);
                    ToothGraphic tooth = TeethChart.GetToothInfo(toothNum);
                    int toothId = ToothInfoClass.ToothNameToToothId(tooth.ToothId);

                    Class.ToothInfo toothInfo_empty = new Class.ToothInfo();
                    Class.ToothInfo toothInfo_base = Convert_ToothGraphic_To_ToothInfo(tooth);
                    Class.ToothInfo toothInfo_db = PatientTeeth.Select(x => x).Where(x => x.ToothId == toothId).SingleOrDefault();

                    if (toothInfo_base.Equals(toothInfo_empty))
                        continue;
                    if (toothInfo_base.Equals(toothInfo_db))
                        continue;


                    dynamic iObj = new ExpandoObject();

                    iObj.PatientId = this.PatientId;
                    iObj.PatientServiceToothId = patientServiceToothId != 0 ? patientServiceToothId : (int?)null;
                    iObj.PatientServiceId = 0;
                    iObj.Date = Publics.ConvertDateTimeToString(DateTime.Now);
                    iObj.ToothId = toothInfo_base.ToothId;
                    iObj.Visible = toothInfo_base.Visible;
                    iObj.Rotate = toothInfo_base.Rotate;
                    iObj.TipB = toothInfo_base.TipB;
                    iObj.TipM = toothInfo_base.TipM;
                    iObj.ShiftM = toothInfo_base.ShiftM;
                    iObj.ShiftO = toothInfo_base.ShiftO;
                    iObj.ShiftB = toothInfo_base.ShiftB;
                    iObj.IsRCT = toothInfo_base.IsRCT;
                    iObj.ColorRCT = toothInfo_base.ColorRCT;
                    iObj.IsBU = toothInfo_base.IsBU;
                    iObj.ColorBU = toothInfo_base.ColorBU;
                    iObj.IsImplant = toothInfo_base.IsImplant;
                    iObj.ColorImplant = toothInfo_base.ColorImplant;
                    iObj.IsCrown = toothInfo_base.IsCrown;
                    iObj.IsPontic = toothInfo_base.IsPontic;
                    iObj.IsSealant = toothInfo_base.IsSealant;
                    iObj.ColorSealant = toothInfo_base.ColorSealant;

                    iObj.Surface = toothInfo_base.Surface;
                    iObj.SurfaceColor = toothInfo_base.SurfaceColor;

                    iObj.Surface_B = toothInfo_base.Surface_B;
                    iObj.Surface_B_Color = toothInfo_base.Surface_B_Color;

                    iObj.Surface_F = toothInfo_base.Surface_F;
                    iObj.Surface_F_Color = toothInfo_base.Surface_F_Color;

                    iObj.Surface_C = toothInfo_base.Surface_C;
                    iObj.Surface_C_Color = toothInfo_base.Surface_C_Color;

                    iObj.Surface_D = toothInfo_base.Surface_D;
                    iObj.Surface_D_Color = toothInfo_base.Surface_D_Color;

                    iObj.Surface_E = toothInfo_base.Surface_E;
                    iObj.Surface_E_Color = toothInfo_base.Surface_E_Color;

                    iObj.Surface_L = toothInfo_base.Surface_L;
                    iObj.Surface_L_Color = toothInfo_base.Surface_L_Color;

                    iObj.Surface_M = toothInfo_base.Surface_M;
                    iObj.Surface_M_Color = toothInfo_base.Surface_M_Color;

                    iObj.Surface_O = toothInfo_base.Surface_O;
                    iObj.Surface_O_Color = toothInfo_base.Surface_O_Color;

                    iObj.Surface_I = toothInfo_base.Surface_I;
                    iObj.Surface_I_Color = toothInfo_base.Surface_I_Color;

                    iObj.Surface_V = toothInfo_base.Surface_V;
                    iObj.Surface_V_Color = toothInfo_base.Surface_V_Color;

                    iObj.Description = tooth.Description;

                    JsonResponse<dynamic> result = Dentistry.DataProvider.DefinePatientTeethX(iObj);
                    if (result != null && result.Success == true)
                    {
                        counter++;
                    }
                    else
                    {
                        throw new Exception("خطا در ثبت عملیات");
                    }

                }

                if (counter > 0)
                {
                    string msg = string.Format("{1} {0}", counter, "مورد با موفقیت ثبت شد");
                    FarsiMessageBox.FMessageBox.Show(msg, "پیام", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Information, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
                    this.Close();
                }

            }
            catch (Exception exp)
            {
                FarsiMessageBox.FMessageBox.Show("خطا در ثبت اطلاعات ", "خطا", FarsiMessageBox.FMessageBoxButtons.OK, FarsiMessageBox.FMessageBoxIcons.Error, FarsiMessageBox.FMessageBoxDefaultButtons.Button1);
            }

            this.SurfaceTooth = "";
            this.ResetButton();

        }

        // Built once (see EnsureToothDescLabelCache) instead of walking the
        // whole control tree with Controls.Find("lt" + id, true) for every
        // tooth, every time CheckTeethDescriptions runs. With 286 controls
        // on this form and ~52 teeth, that was ~15,000 name comparisons per
        // call - and it's called more than once (Load + after edits).
        private Dictionary<string, Control> _toothDescLabelCache;

        private void EnsureToothDescLabelCache()
        {
            if (_toothDescLabelCache != null)
                return;

            _toothDescLabelCache = new Dictionary<string, Control>();
            foreach (ToothGraphic tooth in TeethChart.AllTeeth)
            {
                string key = "lt" + tooth.ToothId;
                if (_toothDescLabelCache.ContainsKey(key))
                    continue;

                var ctrs = this.Controls.Find(key, true);
                if (ctrs.Length > 0)
                    _toothDescLabelCache[key] = ctrs[0];
            }
        }

        private void CheckTeethDescriptions()
        {
            EnsureToothDescLabelCache();

            foreach (ToothGraphic tooth in TeethChart.AllTeeth)
            {
                string toothId = tooth.ToothId;
                if (!_toothDescLabelCache.TryGetValue("lt" + toothId, out var lbl))
                    continue;

                lbl.ForeColor = Color.Gray;

                if (!string.IsNullOrEmpty(tooth.Description))
                {
                    lbl.ForeColor = ColorTranslator.FromHtml("#dbb2ff");
                }
            }
        }

        private void ToothDescriptionPnl_Paint(object sender, PaintEventArgs e)
        {
            Panel pnl = ((Panel)sender);
            Color borderColor = ColorTranslator.FromHtml("#dbb2ff");
            ControlPaint.DrawBorder(e.Graphics, pnl.ClientRectangle, borderColor, ButtonBorderStyle.Solid);
        }

        private void ToothDesc_Click(object sender, EventArgs e)
        {
            var ctr = (Label)sender;
            int toothId = Convert.ToInt32(ctr.Tag);
            ToothIdLbl.Text = String.Format("{0} - {1}", "دندان شماره", toothId);
            this.ToothDescriptionPnl.RightToLeft = RightToLeft.Yes;

            TeethChart.TeethDeSelected();
            ToothGraphic tooth = TeethChart.GetToothInfo(toothId.ToString());
            this.ToothDescriptionTxt.Text = tooth.Description;
            TeethChart.SetSelected(tooth.ToothId, true);


            int x1 = 0, y1 = 0;
            if (pp == null)
            {
                this.ToothDescriptionPnl.BackColor = Color.FromArgb(58, 45, 73);
                this.ToothDescriptionPnl.Paint += new System.Windows.Forms.PaintEventHandler(this.ToothDescriptionPnl_Paint);
                pp = new PopupControl.Popup(this.ToothDescriptionPnl);
                pp.Closed += new ToolStripDropDownClosedEventHandler((sender1, e1) => pp_Closed(sender1, e1, toothId, this.ToothDescriptionTxt.Text));

                x1 = this.ToothDescriptionPnl.Width;
                y1 = this.ToothDescriptionPnl.Height;
                pp.ShowingAnimation = pp.HidingAnimation = PopupAnimations.None;

            }
            pp.Hide();
            if ((toothId >= 1 && toothId <= 16) || (toothId >= 33 && toothId <= 42))
                pp.Show(MousePosition.X - (x1 / 2), MousePosition.Y + 15);
            if ((toothId >= 17 && toothId <= 32) || (toothId >= 43 && toothId <= 52))
                pp.Show(MousePosition.X - (x1 / 2), MousePosition.Y - y1 - 15);
            //pp = null;
        }

        void pp_Closed(object sender, ToolStripDropDownClosedEventArgs e, int toothId, string description)
        {
            string toothNum = ToothInfoClass.ToothIdToToothName(toothId);
            ToothGraphic tooth = TeethChart.GetToothInfo(toothNum);
            TeethChart.SetSelected(tooth.ToothId, false);
            tooth.Description = description;
            pp = null;
            this.CheckTeethDescriptions();
        }




        private void ToothDescSaveBtn_Click(object sender, EventArgs e)
        {
            pp.Close();
            this.SaveActionBtn_Click(this, null);
        }

        private Class.ToothInfo Convert_ToothGraphic_To_ToothInfo(ToothGraphic toothGraphic)
        {
            Class.ToothInfo toothInfo = new Class.ToothInfo();

            toothInfo.ToothId = ToothInfoClass.ToothNameToToothId(toothGraphic.ToothId);
            toothInfo.Visible = toothGraphic.Visible;
            toothInfo.Rotate = toothGraphic.Rotate;
            toothInfo.TipB = toothGraphic.TipB;
            toothInfo.TipM = toothGraphic.TipM;
            toothInfo.ShiftM = toothGraphic.ShiftM;
            toothInfo.ShiftO = toothGraphic.ShiftO;
            toothInfo.ShiftB = toothGraphic.ShiftB;
            toothInfo.IsRCT = toothGraphic.IsRCT;
            toothInfo.ColorRCT = toothGraphic.ColorRCT.ToArgb();
            toothInfo.IsBU = toothGraphic.IsBU;
            toothInfo.ColorBU = toothGraphic.ColorBU.ToArgb();
            toothInfo.IsImplant = toothGraphic.IsImplant;
            toothInfo.ColorImplant = toothGraphic.ColorImplant.ToArgb();
            toothInfo.IsCrown = toothGraphic.IsCrown;
            toothInfo.IsPontic = toothGraphic.IsPontic;
            toothInfo.IsSealant = toothGraphic.IsSealant;
            toothInfo.ColorSealant = toothGraphic.ColorSealant.ToArgb();

            toothInfo.Surface = toothGraphic.Surface != null ? toothGraphic.Surface : "";
            toothInfo.SurfaceColor = toothGraphic.SurfaceColor.ToArgb();


            char[] surfaceArr = toothInfo.Surface.ToCharArray();

            if (surfaceArr.Contains('B'))
            {
                toothInfo.Surface_B = true;

                Color? color = this.GetToothGroupColor(toothGraphic, ToothGroupType.B);
                if (color != null)
                    toothInfo.Surface_B_Color = color.Value.ToArgb();

            }
            if (surfaceArr.Contains('F'))
            {
                toothInfo.Surface_F = true;

                Color? color = this.GetToothGroupColor(toothGraphic, ToothGroupType.F);
                if (color != null)
                    toothInfo.Surface_F_Color = color.Value.ToArgb();

            }
            if (surfaceArr.Contains('C'))
            {
                toothInfo.Surface_C = true;

                Color? color = this.GetToothGroupColor(toothGraphic, ToothGroupType.Cementum);
                if (color != null)
                    toothInfo.Surface_C_Color = color.Value.ToArgb();

            }
            if (surfaceArr.Contains('D'))
            {
                toothInfo.Surface_D = true;

                Color? color = this.GetToothGroupColor(toothGraphic, ToothGroupType.D);
                if (color != null)
                    toothInfo.Surface_D_Color = color.Value.ToArgb();

            }
            if (surfaceArr.Contains('E'))
            {
                toothInfo.Surface_E = true;

                Color? color = this.GetToothGroupColor(toothGraphic, ToothGroupType.Enamel);
                if (color != null)
                    toothInfo.Surface_E_Color = color.Value.ToArgb();

            }
            if (surfaceArr.Contains('L'))
            {
                toothInfo.Surface_L = true;

                Color? color = this.GetToothGroupColor(toothGraphic, ToothGroupType.L);
                if (color != null)
                    toothInfo.Surface_L_Color = color.Value.ToArgb();

            }
            if (surfaceArr.Contains('M'))
            {
                toothInfo.Surface_M = true;

                Color? color = this.GetToothGroupColor(toothGraphic, ToothGroupType.M);
                if (color != null)
                    toothInfo.Surface_M_Color = color.Value.ToArgb();

            }
            if (surfaceArr.Contains('O'))
            {
                toothInfo.Surface_O = true;

                Color? color = this.GetToothGroupColor(toothGraphic, ToothGroupType.O);
                if (color != null)
                    toothInfo.Surface_O_Color = color.Value.ToArgb();

            }
            if (surfaceArr.Contains('I'))
            {
                toothInfo.Surface_I = true;

                Color? color = this.GetToothGroupColor(toothGraphic, ToothGroupType.I);
                if (color != null)
                    toothInfo.Surface_I_Color = color.Value.ToArgb();

            }
            if (surfaceArr.Contains('V'))
            {
                toothInfo.Surface_V = true;

                Color? color = this.GetToothGroupColor(toothGraphic, ToothGroupType.V);
                if (color != null)
                    toothInfo.Surface_V_Color = color.Value.ToArgb();

            }

            toothInfo.Description = toothGraphic.Description;

            return toothInfo;
        }


    }
}
