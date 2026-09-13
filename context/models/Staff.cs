using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    // Staff and Doctor share ONE physical table ("Staffs") via TPH inheritance
    // - see DentalContext.OnModelCreating.
    [Table("Staffs")]
    public class Staff
    {
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        public string NationalCode { get; set; }

        public string MedicalCouncilCode { get; set; }

        [Required]
        public string Date { get; set; }

        public string FixedPhone { get; set; }
        public string MobilePhone { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }

        public int StaffTypeId { get; set; }
        public virtual StaffType StaffType { get; set; }

        public int GenderId { get; set; }
        public virtual Gender Gender { get; set; }

        // The base "Staffs" table has its OWN SpecialtyId column, separate from
        // Doctor's SpecialtyId (which lives in the "Staff_Doctors" table via
        // TPT) - found while converting GetStaffsX, which reads this generic,
        // all-staff-types specialty. Named differently here to avoid clashing
        // with Doctor.SpecialtyId; [Column] maps it back to the real column.
        [Column("SpecialtyId")]
        public int? StaffSpecialtyId { get; set; }
        public virtual Specialty StaffSpecialty { get; set; }
    }

    public class Doctor : Staff
    {
        [Required]
        public string MedicalNumber { get; set; }

        public int? SpecialtyId { get; set; }
        public virtual Specialty Specialty { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual ICollection<PatientService> PatientServices { get; set; }
        public virtual ICollection<PatientFollowup> PatientFollowups { get; set; }
        public virtual ICollection<WorkTime> WorkTimes { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }

        public Doctor()
        {
            Patients = new HashSet<Patient>();
            PatientServices = new HashSet<PatientService>();
            PatientFollowups = new HashSet<PatientFollowup>();
            WorkTimes = new HashSet<WorkTime>();
            Visits = new HashSet<Visit>();
        }
    }
}
