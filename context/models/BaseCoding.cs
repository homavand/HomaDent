using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    // Shared columns live in the physical "BaseCodings" table.
    // Each concrete subclass below maps to ITS OWN physical table
    // (Table-Per-Type / TPT) via DentalContext.OnModelCreating -
    // e.g. Gender -> "BaseCoding_Genders", Specialty -> "BaseCoding_Specialties".
    // This matches the real dental.db schema (verified against it),
    // NOT a single-table-with-Discriminator (TPH) design.
    [Table("BaseCodings")]
    public  class BaseCoding
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }

        [Column("Sort")]
        public int? Sort { get; set; }

        [Required]
        public string TerminologyId { get; set; }
        [Required]
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class AdmissionType : BaseCoding { }

    // Real table "BaseCoding_Banks" has 3 extra columns beyond Id.
    public class Bank : BaseCoding
    {
        public string ConnectionType { get; set; }
        public string PortName { get; set; }
        public string BoundRate { get; set; }

        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<PatientFinancial> PatientFinancials { get; set; }

        public Bank()
        {
            Costs = new HashSet<Cost>();
            PatientFinancials = new HashSet<PatientFinancial>();
        }
    }

    public class BargainSide : BaseCoding
    {
        public virtual ICollection<Cost> Costs { get; set; }

        public BargainSide()
        {
            Costs = new HashSet<Cost>();
        }
    }

    public class CheckupType : BaseCoding { }

    public class ChequeStatus : BaseCoding
    {
        public virtual ICollection<PatientFinancial> PatientFinancials { get; set; }

        public ChequeStatus()
        {
            PatientFinancials = new HashSet<PatientFinancial>();
        }
    }

    // Present in real DB ("BaseCoding_ChequeTypes") - was missing from the model.
    public class ChequeType : BaseCoding { }

    public class CostType : BaseCoding
    {
        public virtual ICollection<Cost> Costs { get; set; }

        public CostType()
        {
            Costs = new HashSet<Cost>();
        }
    }

    public class DentalUnit : BaseCoding { }
    public class Diagnosis : BaseCoding { }
    public class DiagnosisStatus : BaseCoding { }
    public class DrugFrequency : BaseCoding { }
    public class DrugRoute : BaseCoding { }
    public class DrugShape : BaseCoding { }
    public class Drug : BaseCoding { }

    public class EducationLevel : BaseCoding
    {
        public virtual ICollection<Patient> Patients { get; set; }

        public EducationLevel()
        {
            Patients = new HashSet<Patient>();
        }
    }

    public class Gender : BaseCoding
    {
        public virtual ICollection<Staff> Staffs { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }

        public Gender()
        {
            Staffs = new HashSet<Staff>();
            Patients = new HashSet<Patient>();
        }
    }

    // Present in real DB ("BaseCoding_HealthcareProviders") - was missing from the model.
    public class HealthcareProvider : BaseCoding { }

    public class InsuranceBookletType : BaseCoding
    {
        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }

        public InsuranceBookletType()
        {
            PatientInsurances = new HashSet<PatientInsurance>();
        }
    }

    public class InsuranceBox : BaseCoding
    {
        public virtual ICollection<Insurer> Insurers { get; set; }

        public InsuranceBox()
        {
            Insurers = new HashSet<Insurer>();
        }
    }

    public class InsuranceType : BaseCoding
    {
        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }

        public InsuranceType()
        {
            PatientInsurances = new HashSet<PatientInsurance>();
        }
    }

    public class Insurance : BaseCoding
    {
        public virtual ICollection<Insurer> Insurers { get; set; }

        public Insurance()
        {
            Insurers = new HashSet<Insurer>();
        }
    }

    // Real table "BaseCoding_ItemUnits" has 1 extra column beyond Id.
    public class ItemUnit : BaseCoding
    {
        public string Sign { get; set; }
    }

    public class Job : BaseCoding
    {
        public virtual ICollection<Patient> Patients { get; set; }

        public Job()
        {
            Patients = new HashSet<Patient>();
        }
    }

    public class MaritalStatus : BaseCoding
    {
        public virtual ICollection<Patient> Patients { get; set; }

        public MaritalStatus()
        {
            Patients = new HashSet<Patient>();
        }
    }

    public class Nationality : BaseCoding
    {
        public virtual ICollection<Patient> Patients { get; set; }

        public Nationality()
        {
            Patients = new HashSet<Patient>();
        }
    }

    public class OrdinalTerm : BaseCoding { }

    // Present in real DB ("BaseCoding_OrganizationTypes") - was missing from the model.
    public class OrganizationType : BaseCoding { }

    public class PayStatus : BaseCoding { }

    public class PayType : BaseCoding
    {
        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<PatientFinancial> PatientFinancials { get; set; }

        public PayType()
        {
            Costs = new HashSet<Cost>();
            PatientFinancials = new HashSet<PatientFinancial>();
        }
    }

    public class PersonRelationType : BaseCoding
    {
        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }

        public PersonRelationType()
        {
            PatientInsurances = new HashSet<PatientInsurance>();
        }
    }

    public class ReferredReason : BaseCoding { }
    public class ReferredType : BaseCoding { }

    // Real table "BaseCoding_ServiceGroups" has 1 extra column beyond Id.
    public class ServiceGroup : BaseCoding
    {
        public string Color { get; set; }

        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }

        public ServiceGroup()
        {
            Services = new HashSet<Service>();
            Visits = new HashSet<Visit>();
        }
    }

    public class ServiceUnit : BaseCoding { }
    public class Severity : BaseCoding { }

    public class SpecialCommentType : BaseCoding
    {
        public virtual ICollection<PatientSpecialComment> PatientSpecialComments { get; set; }

        public SpecialCommentType()
        {
            PatientSpecialComments = new HashSet<PatientSpecialComment>();
        }
    }

    public class SpecialDiseas : BaseCoding
    {
        public virtual ICollection<PatientSpecialDisease> PatientSpecialDiseases { get; set; }

        public SpecialDiseas()
        {
            PatientSpecialDiseases = new HashSet<PatientSpecialDisease>();
        }
    }

    public class SpecialDrug : BaseCoding
    {
        public virtual ICollection<PatientSpecialDrug> PatientSpecialDrugs { get; set; }

        public SpecialDrug()
        {
            PatientSpecialDrugs = new HashSet<PatientSpecialDrug>();
        }
    }

    public class Specialty : BaseCoding
    {
        public virtual ICollection<Doctor> Doctors { get; set; }

        public Specialty()
        {
            Doctors = new HashSet<Doctor>();
        }
    }

    public class StaffType : BaseCoding
    {
        public virtual ICollection<Staff> Staffs { get; set; }

        public StaffType()
        {
            Staffs = new HashSet<Staff>();
        }
    }

    public class StuffTransactionType : BaseCoding { }
    public class StuffType : BaseCoding { }
    public class SubstanceType : BaseCoding { }
    public class ToothNumber : BaseCoding { }
    public class ToothPart : BaseCoding { }
    public class ToothSegment : BaseCoding { }

    // Present in real DB ("BaseCoding_CodingICD10") - was missing from the model.
    public class CodingICD10 : BaseCoding { }

    [Table("BaseTables")]
    public class BaseTable
    {
        public int Id { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Entity { get; set; }
        [Required] public string Table { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
