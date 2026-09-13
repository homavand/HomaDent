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

        public DbSet<BaseCoding> BaseCodings { get; set; }
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

        // Convenience DbSets for the lookup subtypes used directly in query
        // filters throughout Provider.cs (LoadFormInitInfo, GetPatientsX, ...).
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<MaritalStatus> MaritalStatuses { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Specialty> Specialties { get; set; }
        public DbSet<ServiceGroup> ServiceGroups { get; set; }
        public DbSet<StaffType> StaffTypes { get; set; }
        public DbSet<PayType> PayTypes { get; set; }
        public DbSet<CostType> CostTypes { get; set; }
        public DbSet<BargainSide> BargainSides { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<ChequeStatus> ChequeStatuses { get; set; }
        public DbSet<ChequeType> ChequeTypes { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<InsuranceBox> InsuranceBoxes { get; set; }
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<InsuranceBookletType> InsuranceBookletTypes { get; set; }
        public DbSet<SpecialDiseas> SpecialDiseases { get; set; }
        public DbSet<SpecialDrug> SpecialDrugs { get; set; }
        public DbSet<SpecialCommentType> SpecialCommentTypes { get; set; }
        public DbSet<CheckupType> CheckupTypes { get; set; }
        public DbSet<PersonRelationType> PersonRelationTypes { get; set; }
        public DbSet<ItemUnit> ItemUnits { get; set; }
        public DbSet<ToothNumber> ToothNumbers { get; set; }
        public DbSet<ToothPart> ToothParts { get; set; }
        public DbSet<ToothSegment> ToothSegments { get; set; }

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

            // ---------------------------------------------------------------
            // Table-Per-Type (TPT) for the BaseCoding lookup family.
            // Verified against the actual dental.db: each lookup type has its
            // OWN physical table (e.g. "BaseCoding_Genders",
            // "BaseCoding_Specialties", ...), sharing its Id as a PK/FK back
            // to the shared "BaseCodings" table. This is NOT a single-table
            // TPH design with a Discriminator column - that column does not
            // exist in the real schema.
            // ---------------------------------------------------------------
            modelBuilder.Entity<AdmissionType>().ToTable("BaseCoding_AdmissionTypes");
            modelBuilder.Entity<Bank>().ToTable("BaseCoding_Banks");
            modelBuilder.Entity<BargainSide>().ToTable("BaseCoding_BargainSides");
            modelBuilder.Entity<CheckupType>().ToTable("BaseCoding_CheckupTypes");
            modelBuilder.Entity<ChequeStatus>().ToTable("BaseCoding_ChequeStatus");
            modelBuilder.Entity<ChequeType>().ToTable("BaseCoding_ChequeTypes");
            modelBuilder.Entity<CodingICD10>().ToTable("BaseCoding_CodingICD10");
            modelBuilder.Entity<CostType>().ToTable("BaseCoding_CostTypes");
            modelBuilder.Entity<DentalUnit>().ToTable("BaseCoding_DentalUnits");
            modelBuilder.Entity<Diagnosis>().ToTable("BaseCoding_Diagnosis");
            modelBuilder.Entity<DiagnosisStatus>().ToTable("BaseCoding_DiagnosisStatus");
            modelBuilder.Entity<DrugFrequency>().ToTable("BaseCoding_DrugFrequencies");
            modelBuilder.Entity<DrugRoute>().ToTable("BaseCoding_DrugRoutes");
            modelBuilder.Entity<DrugShape>().ToTable("BaseCoding_DrugShapes");
            modelBuilder.Entity<Drug>().ToTable("BaseCoding_Drugs");
            modelBuilder.Entity<EducationLevel>().ToTable("BaseCoding_EducationLevels");
            modelBuilder.Entity<Gender>().ToTable("BaseCoding_Genders");
            modelBuilder.Entity<HealthcareProvider>().ToTable("BaseCoding_HealthcareProviders");
            modelBuilder.Entity<InsuranceBookletType>().ToTable("BaseCoding_InsuranceBookletTypes");
            modelBuilder.Entity<InsuranceBox>().ToTable("BaseCoding_InsuranceBoxs");
            modelBuilder.Entity<InsuranceType>().ToTable("BaseCoding_InsuranceTypes");
            modelBuilder.Entity<Insurance>().ToTable("BaseCoding_Insurances");
            modelBuilder.Entity<ItemUnit>().ToTable("BaseCoding_ItemUnits");
            modelBuilder.Entity<Job>().ToTable("BaseCoding_Jobs");
            modelBuilder.Entity<MaritalStatus>().ToTable("BaseCoding_MaritalStatus");
            modelBuilder.Entity<Nationality>().ToTable("BaseCoding_Nationalities");
            modelBuilder.Entity<OrdinalTerm>().ToTable("BaseCoding_OrdinalTerms");
            modelBuilder.Entity<OrganizationType>().ToTable("BaseCoding_OrganizationTypes");
            modelBuilder.Entity<PayStatus>().ToTable("BaseCoding_PayStatus");
            modelBuilder.Entity<PayType>().ToTable("BaseCoding_PayTypes");
            modelBuilder.Entity<PersonRelationType>().ToTable("BaseCoding_PersonRelationTypes");
            modelBuilder.Entity<ReferredReason>().ToTable("BaseCoding_ReferredReasons");
            modelBuilder.Entity<ReferredType>().ToTable("BaseCoding_ReferredTypes");
            modelBuilder.Entity<ServiceGroup>().ToTable("BaseCoding_ServiceGroups");
            modelBuilder.Entity<ServiceUnit>().ToTable("BaseCoding_ServiceUnits");
            modelBuilder.Entity<Severity>().ToTable("BaseCoding_Severities");
            modelBuilder.Entity<SpecialCommentType>().ToTable("BaseCoding_SpecialCommentTypes");
            modelBuilder.Entity<SpecialDiseas>().ToTable("BaseCoding_SpecialDiseases");
            modelBuilder.Entity<SpecialDrug>().ToTable("BaseCoding_SpecialDrugs");
            modelBuilder.Entity<Specialty>().ToTable("BaseCoding_Specialties");
            modelBuilder.Entity<StaffType>().ToTable("BaseCoding_StaffTypes");
            modelBuilder.Entity<StuffTransactionType>().ToTable("BaseCoding_StuffTransactionTypes");
            modelBuilder.Entity<StuffType>().ToTable("BaseCoding_StuffTypes");
            modelBuilder.Entity<SubstanceType>().ToTable("BaseCoding_SubstanceTypes");
            modelBuilder.Entity<ToothNumber>().ToTable("BaseCoding_ToothNumbers");
            modelBuilder.Entity<ToothPart>().ToTable("BaseCoding_ToothParts");
            modelBuilder.Entity<ToothSegment>().ToTable("BaseCoding_ToothSegments");

            // TPT for Staff / Doctor - verified against the real schema:
            // "Staffs" holds the shared columns, "Staff_Doctors" holds the
            // doctor-only columns (MedicalNumber, SpecialtyId), keyed by the
            // same Id. NOT a single-table TPH design.
            modelBuilder.Entity<Doctor>().ToTable("Staff_Doctors");
        }
    }
}
