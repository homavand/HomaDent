using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Routing;

namespace Dentistry.Class
{
    public class ToothInfo : IEquatable<ToothInfo>
    {
        public ToothInfo()
        {
            this.ToothId = 0;
            this.Visible = true;
            this.Rotate = 0;
            this.TipB = 0;
            this.TipM = 0;
            this.ShiftM = 0;
            this.ShiftO = 0;
            this.ShiftB = 0;
            this.IsRCT = false;
            this.ColorRCT = 0;
            this.IsBU = false;
            this.ColorBU = 0;
            this.IsImplant = false;
            this.ColorImplant = 0;
            this.IsCrown = false;
            this.IsPontic = false;
            this.IsSealant = false;
            this.ColorSealant = 0;
            this.SurfaceColor = 0;
            this.Surface = "";
            this.IsMissiong = false;
            this.Surface_B = false;
            this.Surface_B_Color = 0;
            this.Surface_F = false;
            this.Surface_F_Color = 0;
            this.Surface_C = false;
            this.Surface_C_Color = 0;
            this.Surface_D = false;
            this.Surface_D_Color = 0;
            this.Surface_E = false;
            this.Surface_E_Color = 0;
            this.Surface_L = false;
            this.Surface_L_Color = 0;
            this.Surface_M = false;
            this.Surface_M_Color = 0;
            this.Surface_O = false;
            this.Surface_O_Color = 0;
            this.Surface_I = false;
            this.Surface_I_Color = 0;
            this.Surface_V = false;
            this.Surface_V_Color = 0;
            this.Mobility = 0;
            this.ColorMobility = 0;
            this.Fracture = 0;
            this.ColorFracture = 0;
            this.Description = "";
            this.IsDeleted = false;
            this.IsChanged = false;
        }
        public ToothInfo(dynamic obj) : this()
        {
            ToothInfo tooth = new ToothInfo();
            var x = new RouteValueDictionary(obj);

            if (x.HasValue("Id"))
                this.Id = x.GetValue<int>("Id");
            if (x.HasValue("PatientId"))
                this.PatientId = x.GetValue<int>("PatientId");
            if (x.HasValue("ToothId"))
                this.ToothId = x.GetValue<int>("ToothId");

            if (x.HasValue("Visible"))
                this.Visible = x.GetValue<bool>("Visible");
            if (x.HasValue("Rotate"))
                this.Rotate = x.GetValue<int>("Rotate");
            if (x.HasValue("TipB"))
                this.TipB = x.GetValue<int>("TipB");
            if (x.HasValue("TipM"))
                this.TipM = x.GetValue<int>("TipM");
            if (x.HasValue("ShiftM"))
                this.ShiftM = x.GetValue<int>("ShiftM");
            if (x.HasValue("ShiftO"))
                this.ShiftO = x.GetValue<int>("ShiftO");
            if (x.HasValue("ShiftB"))
                this.ShiftB = x.GetValue<int>("ShiftB");
            if (x.HasValue("IsRCT"))
                this.IsRCT = x.GetValue<bool>("IsRCT");
            if (x.HasValue("ColorRCT"))
                this.ColorRCT = x.GetValue<int>("ColorRCT");
            if (x.HasValue("IsBU"))
                this.IsBU = x.GetValue<bool>("IsBU");
            if (x.HasValue("ColorBU"))
                this.ColorBU = x.GetValue<int>("ColorBU");
            if (x.HasValue("IsImplant"))
                this.IsImplant = x.GetValue<bool>("IsImplant");
            if (x.HasValue("ColorImplant"))
                this.ColorImplant = x.GetValue<int>("ColorImplant");
            if (x.HasValue("IsCrown"))
                this.IsCrown = x.GetValue<bool>("IsCrown");
            if (x.HasValue("IsPontic"))
                this.IsPontic = x.GetValue<bool>("IsPontic");
            if (x.HasValue("IsSealant"))
                this.IsSealant = x.GetValue<bool>("IsSealant");
            if (x.HasValue("ColorSealant"))
                this.ColorSealant = x.GetValue<int>("ColorSealant");
            if (x.HasValue("IsMissiong"))
                this.IsMissiong = x.GetValue<bool>("IsMissiong");

            if (x.HasValue("Surface"))
                this.Surface = x.GetValue<string>("Surface");
            if (x.HasValue("SurfaceColor"))
                this.SurfaceColor = x.GetValue<int>("SurfaceColor");



            if (x.HasValue("Surface_B"))
                this.Surface_B = x.GetValue<bool>("Surface_B");
            if (x.HasValue("Surface_B_Color"))
                this.Surface_B_Color = x.GetValue<int>("Surface_B_Color");
            if (x.HasValue("Surface_F"))
                this.Surface_F = x.GetValue<bool>("Surface_F");
            if (x.HasValue("Surface_F_Color"))
                this.Surface_F_Color = x.GetValue<int>("Surface_F_Color");
            if (x.HasValue("Surface_C"))
                this.Surface_C = x.GetValue<bool>("Surface_C");
            if (x.HasValue("Surface_C_Color"))
                this.Surface_C_Color = x.GetValue<int>("Surface_C_Color");
            if (x.HasValue("Surface_D"))
                this.Surface_D = x.GetValue<bool>("Surface_D");
            if (x.HasValue("Surface_D_Color"))
                this.Surface_D_Color = x.GetValue<int>("Surface_D_Color");
            if (x.HasValue("Surface_E"))
                this.Surface_E = x.GetValue<bool>("Surface_E");
            if (x.HasValue("Surface_E_Color"))
                this.Surface_E_Color = x.GetValue<int>("Surface_E_Color");
            if (x.HasValue("Surface_L"))
                this.Surface_L = x.GetValue<bool>("Surface_L");
            if (x.HasValue("Surface_L_Color"))
                this.Surface_L_Color = x.GetValue<int>("Surface_L_Color");
            if (x.HasValue("Surface_M"))
                this.Surface_M = x.GetValue<bool>("Surface_M");
            if (x.HasValue("Surface_M_Color"))
                this.Surface_M_Color = x.GetValue<int>("Surface_M_Color");
            if (x.HasValue("Surface_O"))
                this.Surface_O = x.GetValue<bool>("Surface_O");
            if (x.HasValue("Surface_O_Color"))
                this.Surface_O_Color = x.GetValue<int>("Surface_O_Color");
            if (x.HasValue("Surface_I"))
                this.Surface_I = x.GetValue<bool>("Surface_I");
            if (x.HasValue("Surface_I_Color"))
                this.Surface_I_Color = x.GetValue<int>("Surface_I_Color");
            if (x.HasValue("Surface_V"))
                this.Surface_V = x.GetValue<bool>("Surface_V");
            if (x.HasValue("Surface_V_Color"))
                this.Surface_V_Color = x.GetValue<int>("Surface_V_Color");
            if (x.HasValue("Mobility"))
                this.Mobility = x.GetValue<int>("Mobility");
            if (x.HasValue("ColorMobility"))
                this.ColorMobility = x.GetValue<int>("ColorMobility");
            if (x.HasValue("Fracture"))
                this.Fracture = x.GetValue<int>("Fracture");
            if (x.HasValue("ColorFracture"))
                this.ColorFracture = x.GetValue<int>("ColorFracture");


            if (x.HasValue("Description"))
                this.Description = x.GetValue<string>("Description");
            if (x.HasValue("IsDeleted"))
                this.IsDeleted = x.GetValue<bool>("IsDeleted");

            this.IsChanged = false;
        }

        public int Id { get; set; }
        public int PatientId { get; set; }
        public int ToothId { get; set; }
        public bool Visible { get; set; }
        public int Rotate { get; set; }
        public int TipB { get; set; }
        public int TipM { get; set; }
        public int ShiftM { get; set; }
        public int ShiftO { get; set; }
        public int ShiftB { get; set; }
        public bool IsRCT { get; set; }
        public int ColorRCT { get; set; }
        public bool IsBU { get; set; }
        public int ColorBU { get; set; }
        public bool IsImplant { get; set; }
        public int ColorImplant { get; set; }
        public bool IsCrown { get; set; }
        public bool IsPontic { get; set; }
        public bool IsSealant { get; set; }
        public int ColorSealant { get; set; }
        public int SurfaceColor { get; set; }
        public string Surface { get; set; }
        public bool IsMissiong { get; set; }


        public bool Surface_B { get; set; }
        public int Surface_B_Color { get; set; }
        public bool Surface_F { get; set; }
        public int Surface_F_Color { get; set; }
        public bool Surface_C { get; set; }
        public int Surface_C_Color { get; set; }
        public bool Surface_D { get; set; }
        public int Surface_D_Color { get; set; }
        public bool Surface_E { get; set; }
        public int Surface_E_Color { get; set; }
        public bool Surface_L { get; set; }
        public int Surface_L_Color { get; set; }
        public bool Surface_M { get; set; }
        public int Surface_M_Color { get; set; }
        public bool Surface_O { get; set; }
        public int Surface_O_Color { get; set; }
        public bool Surface_I { get; set; }
        public int Surface_I_Color { get; set; }
        public bool Surface_V { get; set; }
        public int Surface_V_Color { get; set; }

        public int Mobility { get; set; }
        public int ColorMobility { get; set; }
        public int Fracture { get; set; }
        public int ColorFracture { get; set; }

        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsChanged { get; set; }



        public bool Equals(ToothInfo other)
        {
            if (other == null)
                return false;
            bool isEquals = true;

            //if (this.ToothId != other.ToothId) isEquals = false;
            if (this.Visible != other.Visible) isEquals = false;
            else if (this.Rotate != other.Rotate) isEquals = false;
            else if (this.TipB != other.TipB) isEquals = false;
            else if (this.TipM != other.TipM) isEquals = false;
            else if (this.ShiftM != other.ShiftM) isEquals = false;
            else if (this.ShiftO != other.ShiftO) isEquals = false;
            else if (this.ShiftB != other.ShiftB) isEquals = false;
            else if (this.IsRCT != other.IsRCT) isEquals = false;
            else if (this.ColorRCT != other.ColorRCT) isEquals = false;
            else if (this.IsBU != other.IsBU) isEquals = false;
            else if (this.ColorBU != other.ColorBU) isEquals = false;
            else if (this.IsImplant != other.IsImplant) isEquals = false;
            else if (this.ColorImplant != other.ColorImplant) isEquals = false;
            else if (this.IsCrown != other.IsCrown) isEquals = false;
            else if (this.IsPontic != other.IsPontic) isEquals = false;
            else if (this.IsSealant != other.IsSealant) isEquals = false;
            else if (this.ColorSealant != other.ColorSealant) isEquals = false;
            else if (this.SurfaceColor != other.SurfaceColor) isEquals = false;
            else if (this.Surface != other.Surface) isEquals = false;
            else if (this.IsMissiong != other.IsMissiong) isEquals = false;
            else if (this.Surface_B != other.Surface_B) isEquals = false;
            else if (this.Surface_B_Color != other.Surface_B_Color) isEquals = false;
            else if (this.Surface_F != other.Surface_F) isEquals = false;
            else if (this.Surface_F_Color != other.Surface_F_Color) isEquals = false;
            else if (this.Surface_C != other.Surface_C) isEquals = false;
            else if (this.Surface_C_Color != other.Surface_C_Color) isEquals = false;
            else if (this.Surface_D != other.Surface_D) isEquals = false;
            else if (this.Surface_D_Color != other.Surface_D_Color) isEquals = false;
            else if (this.Surface_E != other.Surface_E) isEquals = false;
            else if (this.Surface_E_Color != other.Surface_E_Color) isEquals = false;
            else if (this.Surface_L != other.Surface_L) isEquals = false;
            else if (this.Surface_L_Color != other.Surface_L_Color) isEquals = false;
            else if (this.Surface_M != other.Surface_M) isEquals = false;
            else if (this.Surface_M_Color != other.Surface_M_Color) isEquals = false;
            else if (this.Surface_O != other.Surface_O) isEquals = false;
            else if (this.Surface_O_Color != other.Surface_O_Color) isEquals = false;
            else if (this.Surface_I != other.Surface_I) isEquals = false;
            else if (this.Surface_I_Color != other.Surface_I_Color) isEquals = false;
            else if (this.Surface_V != other.Surface_V) isEquals = false;
            else if (this.Surface_V_Color != other.Surface_V_Color) isEquals = false;
            else if (this.Mobility != other.Mobility) isEquals = false;
            else if (this.ColorMobility != other.ColorMobility) isEquals = false;
            else if (this.Fracture != other.Fracture) isEquals = false;
            else if (this.ColorFracture != other.ColorFracture) isEquals = false;
            else if (this.Description != other.Description) isEquals = false;
            else if (this.IsDeleted != other.IsDeleted) isEquals = false;


            return isEquals;
        }
        //public System.Drawing.Bitmap ToothImage
        //{
        //    get
        //    {
        //        if (this.Tooths == null)
        //            return null;
        //        if (this.ToothCount > 0 && this.ToothCount < 4)
        //        {
        //            Image[] imgages = new Image[3];
        //            for (int i = 0; i < this.Tooths.Count(); i++)
        //            {
        //                dynamic item = this.Tooths.ElementAt(i);
        //                if (item == null && item.ToothImage == null)
        //                    continue;

        //                byte[] imgByte = item.ToothImage;
        //                System.IO.MemoryStream tempstream = new System.IO.MemoryStream(imgByte);
        //                imgages[i] = Image.FromStream(tempstream);
        //            }

        //            return Publics.MergeImage(imgages);
        //        }

        //        return null;
        //    }
        //}


    }
}
