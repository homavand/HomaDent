using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    // Pure junction table (Patient <-> SpecialDiseas). No surrogate Id column
    // exists in the database - the composite key (PatientId, SpecialDiseasId)
    // is configured in DentalContext.OnModelCreating.
    [Table("PatientSpecialDiseases")]
    public class PatientSpecialDisease
    {
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int SpecialDiseasId { get; set; }
        [ForeignKey("SpecialDiseasId")]
        public virtual SpecialDiseas SpecialDisea { get; set; } // name kept as in original model
    }
}
