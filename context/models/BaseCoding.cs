using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{
    // ---------------------------------------------------------------
    // BaseCoding lookup family - FLATTENED (no more shared "BaseCodings"
    // table / no more TPT inheritance). Each type below maps directly,
    // standalone, to its own physical table (e.g. Gender -> table
    // "BaseCoding_Genders"), which now carries every column itself
    // (Code, Value, Title, Sort, TerminologyId, Description, IsDeleted,
    // plus any type-specific extra columns). Class names intentionally
    // do NOT carry the "BaseCoding_" prefix - only the physical [Table]
    // name does.
    //
    // NOTE: TerminologyId / Description are no longer [Required] - the
    // real column data is nullable and mostly NULL; the previous
    // [Required] attributes did not match the actual schema/data and
    // would have thrown EF validation errors on save.
    // ---------------------------------------------------------------

    [Table("BaseCoding_AdmissionTypes")]
    public class AdmissionType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    // Real table "BaseCoding_Banks" has 3 extra columns beyond Id.
    [Table("BaseCoding_Banks")]
    public class Bank
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

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

    [Table("BaseCoding_BargainSides")]
    public class BargainSide
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Cost> Costs { get; set; }

        public BargainSide()
        {
            Costs = new HashSet<Cost>();
        }
    }

    [Table("BaseCoding_CheckupTypes")]
    public class CheckupType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_ChequeStatus")]
    public class ChequeStatus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<PatientFinancial> PatientFinancials { get; set; }

        public ChequeStatus()
        {
            PatientFinancials = new HashSet<PatientFinancial>();
        }
    }

    // Present in real DB ("BaseCoding_ChequeTypes") - was missing from the model.
    [Table("BaseCoding_ChequeTypes")]
    public class ChequeType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_CostTypes")]
    public class CostType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Cost> Costs { get; set; }

        public CostType()
        {
            Costs = new HashSet<Cost>();
        }
    }

    [Table("BaseCoding_DentalUnits")]
    public class DentalUnit
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_Diagnosis")]
    public class Diagnosis
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_DiagnosisStatus")]
    public class DiagnosisStatus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_DrugFrequencies")]
    public class DrugFrequency
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_DrugRoutes")]
    public class DrugRoute
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_DrugShapes")]
    public class DrugShape
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_Drugs")]
    public class Drug
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_EducationLevels")]
    public class EducationLevel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public EducationLevel()
        {
            Patients = new HashSet<Patient>();
        }
    }

    [Table("BaseCoding_Genders")]
    public class Gender
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Staff> Staffs { get; set; }
        public virtual ICollection<Patient> Patients { get; set; }

        public Gender()
        {
            Staffs = new HashSet<Staff>();
            Patients = new HashSet<Patient>();
        }
    }

    // Present in real DB ("BaseCoding_HealthcareProviders") - was missing from the model.
    [Table("BaseCoding_HealthcareProviders")]
    public class HealthcareProvider
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_InsuranceBookletTypes")]
    public class InsuranceBookletType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }

        public InsuranceBookletType()
        {
            PatientInsurances = new HashSet<PatientInsurance>();
        }
    }

    [Table("BaseCoding_InsuranceBoxs")]
    public class InsuranceBox
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Insurer> Insurers { get; set; }

        public InsuranceBox()
        {
            Insurers = new HashSet<Insurer>();
        }
    }

    [Table("BaseCoding_InsuranceTypes")]
    public class InsuranceType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }

        public InsuranceType()
        {
            PatientInsurances = new HashSet<PatientInsurance>();
        }
    }

    [Table("BaseCoding_Insurances")]
    public class Insurance
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Insurer> Insurers { get; set; }

        public Insurance()
        {
            Insurers = new HashSet<Insurer>();
        }
    }

    // Real table "BaseCoding_ItemUnits" has 1 extra column beyond Id.
    [Table("BaseCoding_ItemUnits")]
    public class ItemUnit
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public string Sign { get; set; }
    }

    [Table("BaseCoding_Jobs")]
    public class Job
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public Job()
        {
            Patients = new HashSet<Patient>();
        }
    }

    [Table("BaseCoding_MaritalStatus")]
    public class MaritalStatus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public MaritalStatus()
        {
            Patients = new HashSet<Patient>();
        }
    }

    [Table("BaseCoding_Nationalities")]
    public class Nationality
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }

        public Nationality()
        {
            Patients = new HashSet<Patient>();
        }
    }

    [Table("BaseCoding_OrdinalTerms")]
    public class OrdinalTerm
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    // Present in real DB ("BaseCoding_OrganizationTypes") - was missing from the model.
    [Table("BaseCoding_OrganizationTypes")]
    public class OrganizationType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_PayStatus")]
    public class PayStatus
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_PayTypes")]
    public class PayType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<PatientFinancial> PatientFinancials { get; set; }

        public PayType()
        {
            Costs = new HashSet<Cost>();
            PatientFinancials = new HashSet<PatientFinancial>();
        }
    }

    [Table("BaseCoding_PersonRelationTypes")]
    public class PersonRelationType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<PatientInsurance> PatientInsurances { get; set; }

        public PersonRelationType()
        {
            PatientInsurances = new HashSet<PatientInsurance>();
        }
    }

    [Table("BaseCoding_ReferredReasons")]
    public class ReferredReason
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_ReferredTypes")]
    public class ReferredType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    // Real table "BaseCoding_ServiceGroups" has 1 extra column beyond Id.
    [Table("BaseCoding_ServiceGroups")]
    public class ServiceGroup
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public string Color { get; set; }

        public virtual ICollection<Service> Services { get; set; }
        public virtual ICollection<Visit> Visits { get; set; }

        public ServiceGroup()
        {
            Services = new HashSet<Service>();
            Visits = new HashSet<Visit>();
        }
    }

    [Table("BaseCoding_ServiceUnits")]
    public class ServiceUnit
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_Severities")]
    public class Severity
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_SpecialCommentTypes")]
    public class SpecialCommentType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<PatientSpecialComment> PatientSpecialComments { get; set; }

        public SpecialCommentType()
        {
            PatientSpecialComments = new HashSet<PatientSpecialComment>();
        }
    }

    [Table("BaseCoding_SpecialDiseases")]
    public class SpecialDiseas
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<PatientSpecialDisease> PatientSpecialDiseases { get; set; }

        public SpecialDiseas()
        {
            PatientSpecialDiseases = new HashSet<PatientSpecialDisease>();
        }
    }

    [Table("BaseCoding_SpecialDrugs")]
    public class SpecialDrug
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<PatientSpecialDrug> PatientSpecialDrugs { get; set; }

        public SpecialDrug()
        {
            PatientSpecialDrugs = new HashSet<PatientSpecialDrug>();
        }
    }

    [Table("BaseCoding_Specialties")]
    public class Specialty
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Doctor> Doctors { get; set; }

        public Specialty()
        {
            Doctors = new HashSet<Doctor>();
        }
    }

    [Table("BaseCoding_StaffTypes")]
    public class StaffType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Staff> Staffs { get; set; }

        public StaffType()
        {
            Staffs = new HashSet<Staff>();
        }
    }

    [Table("BaseCoding_StuffTransactionTypes")]
    public class StuffTransactionType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_StuffTypes")]
    public class StuffType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_SubstanceTypes")]
    public class SubstanceType
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_ToothNumbers")]
    public class ToothNumber
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_ToothParts")]
    public class ToothPart
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_ToothSegments")]
    public class ToothSegment
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

    // Present in real DB ("BaseCoding_CodingICD10") - was missing from the model.
    [Table("BaseCoding_CodingICD10")]
    public class CodingICD10
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Value { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public string TerminologyId { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
    }

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