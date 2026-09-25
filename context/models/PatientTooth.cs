using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    // Nullability corrected against the real "PatientTeeth" table schema
    // (verified via PRAGMA table_info): only Id and PatientId are NOT NULL -
    // every other column, including Visible/Rotate/ColorRCT/etc., allows
    // NULL. The previous version of this model declared most of those as
    // non-nullable value types (int/bool), which happened to still work
    // because no current row has NULLs in those specific columns, but
    // "Surface" already had 22 of 25 rows NULL - found while converting
    // DefinePatientTeethX/GetPatientTeethInfos to LINQ. Made nullable here
    // to avoid a latent read crash and to let inserts store a real NULL the
    // same way the original Dapper code could.
    [Table("PatientTeeth")]
    public class PatientTooth
    {
        public long Id { get; set; }
        public DateTime? Date { get; set; }
        public bool? Visible { get; set; }
        public int? Rotate { get; set; }
        public int? TipB { get; set; }
        public int? TipM { get; set; }
        public int? ShiftM { get; set; }
        public int? ShiftO { get; set; }
        public int? ShiftB { get; set; }
        public bool? IsRCT { get; set; }
        public int? ColorRCT { get; set; }
        public bool? IsBU { get; set; }
        public int? ColorBU { get; set; }
        public bool? IsImplant { get; set; }
        public int? ColorImplant { get; set; }
        public bool? IsCrown { get; set; }
        public bool? IsPontic { get; set; }
        public bool? IsSealant { get; set; }
        public int? ColorSealant { get; set; }
        public bool? IsMissiong { get; set; } // name kept as in original model (typo)

        public string Surface { get; set; }
        public int? SurfaceColor { get; set; }

        public bool? Surface_B { get; set; }
        public int? Surface_B_Color { get; set; }
        public bool? Surface_F { get; set; }
        public int? Surface_F_Color { get; set; }
        public bool? Surface_C { get; set; }
        public int? Surface_C_Color { get; set; }
        public bool? Surface_D { get; set; }
        public int? Surface_D_Color { get; set; }
        public bool? Surface_E { get; set; }
        public int? Surface_E_Color { get; set; }
        public bool? Surface_L { get; set; }
        public int? Surface_L_Color { get; set; }
        public bool? Surface_M { get; set; }
        public int? Surface_M_Color { get; set; }
        public bool? Surface_O { get; set; }
        public int? Surface_O_Color { get; set; }
        public bool? Surface_I { get; set; }
        public int? Surface_I_Color { get; set; }
        public bool? Surface_V { get; set; }
        public int? Surface_V_Color { get; set; }

        public int? Mobility { get; set; }
        public int? ColorMobility { get; set; }

        public int? Fracture { get; set; }
        public int? ColorFracture { get; set; }

        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int? ToothId { get; set; }
        public virtual Tooth Tooth { get; set; }
    }
}