using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    [Table("Teeth")]
    public class Tooth
    {
        public int Id { get; set; }

        [Required] public string ToothName { get; set; }
        [Required] public string ToothTitle { get; set; }
        public int ToothGroup { get; set; }
        [Required] public byte[] ToothImage { get; set; }
        [Required] public string ToothModel { get; set; }
        [Required] public string ToothRegion { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<PatientTooth> PatientTeeth { get; set; }

        public Tooth()
        {
            PatientTeeth = new HashSet<PatientTooth>();
        }
    }
}
