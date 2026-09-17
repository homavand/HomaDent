using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    // Pure junction table (Patient <-> SpecialDrug). No surrogate Id column
    // exists in the database - the composite key (PatientId, SpecialDrugId)
    // is configured in DentalContext.OnModelCreating.
    [Table("PatientSpecialDrugs")]
    public class PatientSpecialDrug
    {
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int SpecialDrugId { get; set; }
        public virtual SpecialDrug SpecialDrug { get; set; }
    }
}
