using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    [Table("Insurers")]
    public class Insurer
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public bool? IsBasic { get; set; }
        public bool? IsExtra { get; set; }
        public int? InsurerPercent { get; set; }
        public string Comment { get; set; }
        public DateTime? DefineDate { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? IsDeleted { get; set; }
        public int? InsuranceId { get; set; }
        public virtual Insurance Insurance { get; set; }

        public int? InsuranceBoxId { get; set; }
        public virtual InsuranceBox InsuranceBox { get; set; }

        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }
        public virtual ICollection<InsurerServiceTarefeChange> InsurerServiceTarefeChanges { get; set; }
        public virtual ICollection<InsurerFinancial> InsurerFinancials { get; set; }

        public Insurer()
        {
            PatientInsurances = new HashSet<PatientInsurance>();
            InsurerServiceTarefeChanges = new HashSet<InsurerServiceTarefeChange>();
            InsurerFinancials = new HashSet<InsurerFinancial>();
        }
    }
}