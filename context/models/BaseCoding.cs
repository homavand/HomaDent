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

    // Shared shape for the flattened lookup family (Gender, PayType, ...).
    // Lets generic helpers (see DataProvider.GetFullCodingList<T>/
    // GetMinimalCodingList<T>) keep working with a single type-parameter
    // constraint now that there is no common BaseCoding base class to
    // constrain against.
    public interface IBaseCoding
    {
        int Id { get; set; }
        string Code { get; set; }
        string Value { get; set; }
        string Title { get; set; }
        int? Sort { get; set; }
        string TerminologyId { get; set; }
        string Description { get; set; }
        bool IsDeleted { get; set; }
    }

    [Table("BaseCoding_AdmissionTypes")]
    public class AdmissionType : IBaseCoding
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
    public class Bank : IBaseCoding
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
    public class BargainSide : IBaseCoding
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
    public class CheckupType : IBaseCoding
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
    public class ChequeStatus : IBaseCoding
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
    public class ChequeType : IBaseCoding
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
    public class CostType : IBaseCoding
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
    public class DentalUnit : IBaseCoding
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
    public class Diagnosis : IBaseCoding
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
    public class DiagnosisStatus : IBaseCoding
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
    public class DrugFrequency : IBaseCoding
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
    public class DrugRoute : IBaseCoding
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
    public class DrugShape : IBaseCoding
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
    public class Drug : IBaseCoding
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
    public class EducationLevel : IBaseCoding
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
    public class Gender : IBaseCoding
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
    public class HealthcareProvider : IBaseCoding
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
    public class InsuranceBookletType : IBaseCoding
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
    public class InsuranceBox : IBaseCoding
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
    public class InsuranceType : IBaseCoding
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
    public class Insurance : IBaseCoding
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
    public class ItemUnit : IBaseCoding
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
    public class Job : IBaseCoding
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
    public class MaritalStatus : IBaseCoding
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
    public class Nationality : IBaseCoding
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
    public class OrdinalTerm : IBaseCoding
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
    public class OrganizationType : IBaseCoding
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
    public class PayStatus : IBaseCoding
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
    public class PayType : IBaseCoding
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
    public class PersonRelationType : IBaseCoding
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
    public class ReferredReason : IBaseCoding
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
    public class ReferredType : IBaseCoding
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
    public class ServiceGroup : IBaseCoding
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
    public class ServiceUnit : IBaseCoding
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
    public class Severity : IBaseCoding
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
    public class SpecialCommentType : IBaseCoding
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
    public class SpecialDiseas : IBaseCoding
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
    public class SpecialDrug : IBaseCoding
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
    public class Specialty : IBaseCoding
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
    public class StaffType : IBaseCoding
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
    public class StuffTransactionType : IBaseCoding
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
    public class StuffType : IBaseCoding
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
    public class SubstanceType : IBaseCoding
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
    public class ToothNumber : IBaseCoding
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
    public class ToothPart : IBaseCoding
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
    public class ToothSegment : IBaseCoding
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
    public class CodingICD10 : IBaseCoding
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