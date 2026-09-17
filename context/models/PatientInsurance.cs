using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{

    [Table("PatientInsurances")]
    public class PatientInsurance
    {
        public int Id { get; set; }

        [Required]
        public string InsuredNumber { get; set; }

        public string InsuranceBookletSerialNumber { get; set; }
        public string IntroLetterNum { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public string PageNumber { get; set; }
        public int Percent { get; set; }
        public double? MaxPay { get; set; }
        public string IssuedPlaceCode { get; set; }
        public string InsurerAgentCode { get; set; }
        public string HID { get; set; }
        public string SHEBAD { get; set; }
        public bool IsDeleted { get; set; }

        public int InsurerId { get; set; }
        public virtual Insurer Insurer { get; set; }

        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int? InsuranceBookletTypeId { get; set; }
        public virtual InsuranceBookletType InsuranceBookletType { get; set; }

        public int? InsuranceTypeId { get; set; }
        public virtual InsuranceType InsuranceType { get; set; }

        public int? PersonRelationTypeId { get; set; }
        public virtual PersonRelationType PersonRelationType { get; set; }
    }
}
