using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dentistry.Models
{

    // Rebuilt against the real "PatientServices" table. The previous version
    // of this model had a "DoctorId"/"Doctor" nav property that does NOT
    // exist in the actual schema (a patient service's doctor is reached via
    // Patient.Doctor, not directly), and was missing several real columns:
    // ServiceGroupId, CheckupTypeId, ProviderDoctorId, PatientInsuranceId,
    // InsurerServiceTarefeChangeId. "Count" was also typed as string; the
    // real column is INTEGER.
    //
    // NOTE: the "ProviderStaffId" column was renamed to "ProviderDoctorId"
    // directly in the database. The property below (and its nav property)
    // follow that rename, and the rename has been propagated through the
    // API-facing input/output field names in the corresponding Get/Define
    // functions as well.
    [Table("PatientServices")]
    public class PatientService
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int? Count { get; set; }

        public bool IsHadMoreTooth { get; set; }
        public decimal ActionPrice { get; set; }
        public decimal? ServicePrice { get; set; }
        public decimal? InsurerPrice { get; set; }
        public decimal? InsurerShare { get; set; }
        public decimal? FranchiseShare { get; set; }
        public decimal? FreeShare { get; set; }
        public string ToothIds { get; set; }
        public string Comment { get; set; }
        public bool IsDeleted { get; set; }

        public long? PatientId { get; set; }
        public virtual Patient Patient { get; set; }

        public int ServiceId { get; set; }
        public virtual Service Service { get; set; }

        // Real table also carries its own ServiceGroupId (redundant with
        // Service.ServiceGroupId - the original raw query actually read the
        // group off the joined Service row, not this column).
        public int? ServiceGroupId { get; set; }
        public virtual ServiceGroup ServiceGroup { get; set; }

        public int? CheckupTypeId { get; set; }
        public virtual CheckupType CheckupType { get; set; }

        // Column renamed at the DB level from ProviderStaffId to
        // ProviderDoctorId (it always pointed at a Doctor - the name now
        // matches). NOTE: this still means EF requires a matching row in
        // BOTH Staffs and Staff_Doctors; a ProviderDoctorId that pointed at a
        // non-doctor staff member would silently fail to resolve (null nav,
        // excluded from inner-join-style queries) instead of throwing.
        public int? ProviderDoctorId { get; set; }
        public virtual Doctor ProviderDoctor { get; set; }

        public int? PatientInsuranceId { get; set; }
        public virtual PatientInsurance PatientInsurance { get; set; }

        public int? InsurerServiceTarefeChangeId { get; set; }
        public virtual InsurerServiceTarefeChange InsurerServiceTarefeChange { get; set; }
    }
}
