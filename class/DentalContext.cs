using System.Data.Entity;
using Dental.EF.Entities;

namespace Dental.EF.Data
{
    public class DentalContext : DbContext
    {
        public DentalContext() : base("name=DentalContext") { }

        public DbSet<AdmissionType> AdmissionTypes { get; set; }
        public DbSet<Bank> Banks { get; set; }
        public DbSet<BargainSide> BargainSides { get; set; }
        public DbSet<CheckupType> CheckupTypes { get; set; }
        public DbSet<ChequeStatus> ChequeStatuss { get; set; }
        public DbSet<CostType> CostTypes { get; set; }
        public DbSet<DentalUnit> DentalUnits { get; set; }
        public DbSet<Diagnosis> Diagnosiss { get; set; }
        public DbSet<DiagnosisStatus> DiagnosisStatuss { get; set; }
        public DbSet<DrugFrequency> DrugFrequencys { get; set; }
        public DbSet<DrugRoute> DrugRoutes { get; set; }
        public DbSet<DrugShape> DrugShapes { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<EducationLevel> EducationLevels { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<InsuranceBookletType> InsuranceBookletTypes { get; set; }
        public DbSet<InsuranceBox> InsuranceBoxs { get; set; }
        public DbSet<InsuranceType> InsuranceTypes { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
        public DbSet<ItemUnit> ItemUnits { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<MaritalStatus> MaritalStatuss { get; set; }
        public DbSet<Nationality> Nationalitys { get; set; }
        public DbSet<OrdinalTerm> OrdinalTerms { get; set; }
        public DbSet<PayStatus> PayStatuss { get; set; }
        public DbSet<PayType> PayTypes { get; set; }
        public DbSet<PersonRelationType> PersonRelationTypes { get; set; }
        public DbSet<ReferredReason> ReferredReasons { get; set; }
        public DbSet<ReferredType> ReferredTypes { get; set; }
        public DbSet<ServiceGroup> ServiceGroups { get; set; }
        public DbSet<ServiceUnit> ServiceUnits { get; set; }
        public DbSet<Severity> Severitys { get; set; }
        public DbSet<SpecialCommentType> SpecialCommentTypes { get; set; }
        public DbSet<SpecialDiseas> SpecialDiseass { get; set; }
        public DbSet<SpecialDrug> SpecialDrugs { get; set; }
        public DbSet<Specialty> Specialtys { get; set; }
        public DbSet<StaffType> StaffTypes { get; set; }
        public DbSet<StuffTransactionType> StuffTransactionTypes { get; set; }
        public DbSet<StuffType> StuffTypes { get; set; }
        public DbSet<SubstanceType> SubstanceTypes { get; set; }
        public DbSet<ToothNumber> ToothNumbers { get; set; }
        public DbSet<ToothPart> ToothParts { get; set; }
        public DbSet<ToothSegment> ToothSegments { get; set; }
        public DbSet<BaseTable> BaseTables { get; set; }
        public DbSet<Config> Configs { get; set; }
        public DbSet<Cost> Costs { get; set; }
        public DbSet<Insurer> Insurers { get; set; }
        public DbSet<Office> Offices { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<WorkTime> WorkTimes { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Tooth> Teeth { get; set; }
        public DbSet<Staff> Staffs { get; set; }
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Staff>().ToTable("Staffs");
            modelBuilder.Entity<Doctor>().ToTable("Staff_Doctors");
            modelBuilder.Entity<BaseCoding>();
            modelBuilder.Entity<Cost>()
                .HasRequired(x => x.CostType)
                .WithMany(x => x.Costs)
                .HasForeignKey(x => x.CostTypeId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Cost>()
                .HasRequired(x => x.PayType)
                .WithMany(x => x.Costs)
                .HasForeignKey(x => x.PayTypeId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Cost>()
                .HasOptional(x => x.BargainSide)
                .WithMany(x => x.Costs)
                .HasForeignKey(x => x.BargainSideId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Cost>()
                .HasOptional(x => x.Bank)
                .WithMany(x => x.Costs)
                .HasForeignKey(x => x.BankId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Insurer>()
                .HasOptional(x => x.Insurance)
                .WithMany(x => x.Insurers)
                .HasForeignKey(x => x.InsuranceId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Insurer>()
                .HasOptional(x => x.InsuranceBox)
                .WithMany(x => x.Insurers)
                .HasForeignKey(x => x.InsuranceBoxId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Service>()
                .HasRequired(x => x.ServiceGroup)
                .WithMany(x => x.Services)
                .HasForeignKey(x => x.ServiceGroupId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Staff>()
                .HasRequired(x => x.StaffType)
                .WithMany(x => x.Staffs)
                .HasForeignKey(x => x.StaffTypeId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Staff>()
                .HasRequired(x => x.Gender)
                .WithMany(x => x.Staffs)
                .HasForeignKey(x => x.GenderId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Doctor>()
                .HasOptional(x => x.Specialty)
                .WithMany(x => x.Doctors)
                .HasForeignKey(x => x.SpecialtyId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Patient>()
                .HasRequired(x => x.Gender)
                .WithMany(x => x.Patients)
                .HasForeignKey(x => x.GenderId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Patient>()
                .HasRequired(x => x.Nationality)
                .WithMany(x => x.Patients)
                .HasForeignKey(x => x.NationalityId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Patient>()
                .HasOptional(x => x.MaritalStatu)
                .WithMany(x => x.Patients)
                .HasForeignKey(x => x.MaritalStatusId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Patient>()
                .HasOptional(x => x.EducationLevel)
                .WithMany(x => x.Patients)
                .HasForeignKey(x => x.EducationLevelId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Patient>()
                .HasRequired(x => x.Doctor)
                .WithMany(x => x.Patients)
                .HasForeignKey(x => x.DoctorId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientTooth>()
                .HasRequired(x => x.Patient)
                .WithMany(x => x.PatientTeeth)
                .HasForeignKey(x => x.PatientId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientTooth>()
                .HasRequired(x => x.Tooth)
                .WithMany(x => x.PatientTeeth)
                .HasForeignKey(x => x.ToothId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientSpecialComment>()
                .HasRequired(x => x.Patient)
                .WithMany(x => x.PatientSpecialComments)
                .HasForeignKey(x => x.PatientId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientSpecialComment>()
                .HasRequired(x => x.SpecialCommentType)
                .WithMany(x => x.PatientSpecialComments)
                .HasForeignKey(x => x.SpecialCommentTypeId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientSpecialDisease>()
                .HasRequired(x => x.Patient)
                .WithMany(x => x.PatientSpecialDiseases)
                .HasForeignKey(x => x.PatientId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientSpecialDisease>()
                .HasRequired(x => x.SpecialDisea)
                .WithMany(x => x.PatientSpecialDiseases)
                .HasForeignKey(x => x.SpecialDiseasId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientSpecialDrug>()
                .HasRequired(x => x.Patient)
                .WithMany(x => x.PatientSpecialDrugs)
                .HasForeignKey(x => x.PatientId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientSpecialDrug>()
                .HasRequired(x => x.SpecialDrug)
                .WithMany(x => x.PatientSpecialDrugs)
                .HasForeignKey(x => x.SpecialDrugId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientService>()
                .HasRequired(x => x.Patient)
                .WithMany(x => x.PatientServices)
                .HasForeignKey(x => x.PatientId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientService>()
                .HasRequired(x => x.Service)
                .WithMany(x => x.PatientServices)
                .HasForeignKey(x => x.ServiceId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientInsurance>()
                .HasRequired(x => x.Insurer)
                .WithMany(x => x.PatientInsurances)
                .HasForeignKey(x => x.InsurerId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientInsurance>()
                .HasRequired(x => x.Patient)
                .WithMany(x => x.PatientInsurances)
                .HasForeignKey(x => x.PatientId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientInsurance>()
                .HasOptional(x => x.InsuranceBookletType)
                .WithMany(x => x.PatientInsurances)
                .HasForeignKey(x => x.InsuranceBookletTypeId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientInsurance>()
                .HasOptional(x => x.InsuranceType)
                .WithMany(x => x.PatientInsurances)
                .HasForeignKey(x => x.InsuranceTypeId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientInsurance>()
                .HasOptional(x => x.PersonRelationType)
                .WithMany(x => x.PatientInsurances)
                .HasForeignKey(x => x.PersonRelationTypeId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientFollowup>()
                .HasRequired(x => x.Patient)
                .WithMany(x => x.PatientFollowups)
                .HasForeignKey(x => x.PatientId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientFollowup>()
                .HasRequired(x => x.Doctor)
                .WithMany(x => x.PatientFollowups)
                .HasForeignKey(x => x.DoctorId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<WorkTime>()
                .HasRequired(x => x.Doctor)
                .WithMany(x => x.WorkTimes)
                .HasForeignKey(x => x.DoctorId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientFinancial>()
                .HasRequired(x => x.Patient)
                .WithMany(x => x.PatientFinancials)
                .HasForeignKey(x => x.PatientId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientFinancial>()
                .HasRequired(x => x.PayType)
                .WithMany(x => x.PatientFinancials)
                .HasForeignKey(x => x.PayTypeId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientFinancial>()
                .HasOptional(x => x.Bank)
                .WithMany(x => x.PatientFinancials)
                .HasForeignKey(x => x.BankId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientFinancial>()
                .HasOptional(x => x.ChequeStatu)
                .WithMany(x => x.PatientFinancials)
                .HasForeignKey(x => x.ChequeStatusId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<PatientDocument>()
                .HasRequired(x => x.Patient)
                .WithMany(x => x.PatientDocuments)
                .HasForeignKey(x => x.PatientId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InsurerServiceTarefeChange>()
                .HasRequired(x => x.Insurer)
                .WithMany(x => x.InsurerServiceTarefeChanges)
                .HasForeignKey(x => x.InsurerId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InsurerServiceTarefeChange>()
                .HasRequired(x => x.Service)
                .WithMany(x => x.InsurerServiceTarefeChanges)
                .HasForeignKey(x => x.ServiceId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InsurerServiceTarefeChange>()
                .HasRequired(x => x.User)
                .WithMany(x => x.InsurerServiceTarefeChanges)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<InsurerFinancial>()
                .HasRequired(x => x.Insurer)
                .WithMany(x => x.InsurerFinancials)
                .HasForeignKey(x => x.InsurerId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<UserPermission>()
                .HasRequired(x => x.User)
                .WithMany(x => x.UserPermissions)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<UserPermission>()
                .HasRequired(x => x.AppAction)
                .WithMany(x => x.UserPermissions)
                .HasForeignKey(x => x.AppActionId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Visit>()
                .HasRequired(x => x.Doctor)
                .WithMany(x => x.Visits)
                .HasForeignKey(x => x.DoctorId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Visit>()
                .HasRequired(x => x.Patient)
                .WithMany(x => x.Visits)
                .HasForeignKey(x => x.PatientId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<Visit>()
                .HasOptional(x => x.ServiceGroup)
                .WithMany(x => x.Visits)
                .HasForeignKey(x => x.ServiceGroupId)
                .WillCascadeOnDelete(false);
            modelBuilder.Entity<AdmissionType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<Bank>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<BargainSide>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<CheckupType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<ChequeStatus>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<CostType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<DentalUnit>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<Diagnosis>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<DiagnosisStatus>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<DrugFrequency>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<DrugRoute>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<DrugShape>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<Drug>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<EducationLevel>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<Gender>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<InsuranceBookletType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<InsuranceBox>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<InsuranceType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<Insurance>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<Job>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<MaritalStatus>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<Nationality>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<OrdinalTerm>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<PayStatus>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<PayType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<PersonRelationType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<ReferredReason>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<ReferredType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<ServiceGroup>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<ServiceUnit>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<Severity>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<SpecialCommentType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<SpecialDiseas>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<SpecialDrug>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<Specialty>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<StaffType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<StuffTransactionType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<StuffType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<SubstanceType>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<ToothNumber>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<ToothPart>().Property(x => x.Sort).HasColumnName("SortOrder");
            modelBuilder.Entity<ToothSegment>().Property(x => x.Sort).HasColumnName("SortOrder");
        }
    }
}
