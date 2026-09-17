using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    [Table("Patients")]
    public class Patient
    {
        public int Id { get; set; }

        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }
        [Required] public string FatherName { get; set; }
        [Required] public string NationalCode { get; set; }

        public DateTime? BirthDate { get; set; }
        public DateTime Date { get; set; }
        public string Presenter { get; set; }
        public string FixedPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }

        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        public int NationalityId { get; set; }
        public virtual Nationality Nationality { get; set; }

        public int? MaritalStatusId { get; set; }
        [ForeignKey("MaritalStatusId")]
        public virtual MaritalStatus MaritalStatu { get; set; } // name kept as in original model (typo: "Statu")

        public int? EducationLevelId { get; set; }
        public virtual EducationLevel EducationLevel { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        public int? JobId { get; set; }
        public virtual Job Job { get; set; }

        public virtual ICollection<PatientTooth> PatientTeeth { get; set; }
        public virtual ICollection<PatientSpecialComment> PatientSpecialComments { get; set; }
        public virtual ICollection<PatientSpecialDisease> PatientSpecialDiseases { get; set; }
        public virtual ICollection<PatientSpecialDrug> PatientSpecialDrugs { get; set; }
        public virtual ICollection<PatientService> PatientServices { get; set; }
        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }
        public virtual ICollection<PatientFollowup> PatientFollowups { get; set; }
        public virtual ICollection<PatientFinancial> PatientFinancials { get; set; }
        public virtual ICollection<PatientDocument> PatientDocuments { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }

        public Patient()
        {
            PatientTeeth = new HashSet<PatientTooth>();
            PatientSpecialComments = new HashSet<PatientSpecialComment>();
            PatientSpecialDiseases = new HashSet<PatientSpecialDisease>();
            PatientSpecialDrugs = new HashSet<PatientSpecialDrug>();
            PatientServices = new HashSet<PatientService>();
            PatientInsurances = new HashSet<PatientInsurance>();
            PatientFollowups = new HashSet<PatientFollowup>();
            PatientFinancials = new HashSet<PatientFinancial>();
            PatientDocuments = new HashSet<PatientDocument>();
            Visits = new HashSet<Visit>();
        }
    }
}
