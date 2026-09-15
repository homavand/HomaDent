using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using Dentistry.Models;

namespace Dentistry.Context
{
    public class DentalContext : DbContext
    {
        // "DentalContext" must match a <connectionStrings> entry in App.config
        // pointing to your SQLite provider (System.Data.SQLite.EF6).
        public DentalContext() : base("name=DentalContext")
        {
        }

        public DbSet<BaseTable> BaseTables { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Insurer> Insurers { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Tooth> Teeth { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<PatientTooth> PatientTeeth { get; set; }
        public DbSet<PatientSpecialDrug> PatientSpecialDrugs { get; set; }
        public DbSet<PatientSpecialDisease> PatientSpecialDiseases { get; set; }
        public DbSet<PatientSpecialComment> PatientSpecialComments { get; set; }
        public DbSet<PatientService> PatientServices { get; set; }
        public DbSet<PatientInsurance> PatientInsurances { get; set; }
        public DbSet<PatientFollowup> PatientFollowups { get; set; }
        public DbSet<PatientFinancial> PatientFinancials { get; set; }
        public DbSet<PatientDocument> PatientDocuments { get; set; }
        public DbSet<InsurerServiceTarefeChange> InsurerServiceTarefeChanges { get; set; }
        public DbSet<InsurerFinancial> InsurerFinancials { get; set; }
        public DbSet<AppAction> AppActions { get; set; }
        public DbSet<UserPermission> UserPermissions { get; set; }

        // BaseCoding lookup family - flattened, standalone entities (see
        // models/BaseCoding.cs). Every type gets its own DbSet since
        // there is no more shared BaseCodings DbSet + OfType<T>() to fall
        // back on - update any Provider.cs code that used to do
        // `context.BaseCodings.OfType<X>()` to use `context.Xs` below instead.
        public DbSet<AdmissionType> AdmissionTypes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BargainSide> BargainSides { get; set; }
        public DbSet<CheckupType> CheckupTypes { get; set; }
        public DbSet<ChequeStatus> ChequeStatuses { get; set; }
        public DbSet<ChequeType> ChequeTypes { get; set; }
        public DbSet<CostType> CostTypes { get; set; }
        public DbSet<DentalUnit> DentalUnits { get; set; }
        public DbSet<Diagnosis> Diagnoses { get; set; }
        public DbSet<DiagnosisStatus> DiagnosisStatuses { get; set; }
        public DbSet<DrugFrequency> DrugFrequencies { get; set; }
        public DbSet<DrugRoute> DrugRoutes { get; set; }
        public DbSet<DrugShape> DrugShapes { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<HealthcareProvider> HealthcareProviders { get; set; }
        public DbSet<InsuranceBookletType> InsuranceBookletTypes { get; set; }
        public DbSet<InsuranceBox> InsuranceBoxes { get; set; }
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<ItemUnit> ItemUnits { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<OrdinalTerm> OrdinalTerms { get; set; }
        public DbSet<OrganizationType> OrganizationTypes { get; set; }
        public DbSet<PayStatus> PayStatuses { get; set; }
        public DbSet<PayType> PayTypes { get; set; }
        public DbSet<PersonRelationType> PersonRelationTypes { get; set; }
        public DbSet<ReferredReason> ReferredReasons { get; set; }
        public DbSet<ReferredType> ReferredTypes { get; set; }
        public DbSet<ServiceGroup> ServiceGroups { get; set; }
        public DbSet<ServiceUnit> ServiceUnits { get; set; }
        public DbSet<Severity> Severities { get; set; }
        public DbSet<SpecialCommentType> SpecialCommentTypes { get; set; }
        public DbSet<SpecialDiseas> SpecialDiseases { get; set; }
        public DbSet<SpecialDrug> SpecialDrugs { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<StaffType> StaffTypes { get; set; }
        public DbSet<StuffTransactionType> StuffTransactionTypes { get; set; }
        public DbSet<StuffType> StuffTypes { get; set; }
        public DbSet<SubstanceType> SubstanceTypes { get; set; }
        public DbSet<ToothNumber> ToothNumbers { get; set; }
        public DbSet<ToothPart> ToothParts { get; set; }
        public DbSet<ToothSegment> ToothSegments { get; set; }
        public DbSet<CodingICD10> CodingICD10s { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //throw new System.Exception("MARKER-TEST-12345 — این همون فایلیه که اجرا میشه");
            // Prevents "multiple cascade paths" configuration errors, which are
            // common in a model where many tables reference Patient/Doctor/etc.
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            // ---------------------------------------------------------------
            // Composite keys for pure junction (many-to-many link) tables.
            // These tables have no surrogate "Id" column in the database -
            // the natural composite key IS the primary key.
            // ---------------------------------------------------------------
            modelBuilder.Entity<PatientSpecialDrug>()
                .HasKey(x => new { x.PatientId, x.SpecialDrugId });

            modelBuilder.Entity<PatientSpecialDisease>()
                .HasKey(x => new { x.PatientId, x.SpecialDiseasId });

            modelBuilder.Entity<UserPermission>()
                .HasKey(x => new { x.UserId, x.AppActionId });

            // BaseCoding lookup family: mapping now lives via [Table("...")]
            // attributes directly on each class in models/BaseCoding.cs (flat,
            // standalone tables - no more shared-table TPT inheritance).

            // TPT for Staff / Doctor - verified against the real schema:
            // "Staffs" holds the shared columns, "Staff_Doctors" holds the
            // doctor-only columns (MedicalNumber, SpecialtyId), keyed by the
            // same Id. NOT a single-table TPH design.
            modelBuilder.Entity<Doctor>().ToTable("Staff_Doctors");
        }
    }
}
