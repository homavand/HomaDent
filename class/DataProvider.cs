using System.Data.Entity;
using Dentistry.Context;
using Dentistry.Models;
using System;
using System.Dynamic;
using System.Web.Routing;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SQLite;


namespace Dentistry
{
    class DataProvider
    {

        // Shape: Id, Code, Value, Title, TerminologyId, SortOrder, IsDeleted
        // Constraint was "where T : BaseCoding" - the flattened lookup family
        // (see models/BaseCoding.cs) no longer has that shared base class, so
        // the constraint is now against the IBaseCoding interface every one
        // of those types implements instead.
        private static List<dynamic> GetFullCodingList<T>(DentalContext db) where T : class, IBaseCoding
        {
            return db.Set<T>()
                .OrderBy(b => b.Id)
                .Select(b => new
                {
                    b.Id,
                    b.Code,
                    b.Value,
                    b.Title,
                    b.TerminologyId,
                    SortOrder = b.Sort,
                    IsDeleted = b.IsDeleted
                })
                .ToList<dynamic>();
        }

        // Shape: Id, Title, IsDeleted
        private static List<dynamic> GetMinimalCodingList<T>(DentalContext db) where T : class, IBaseCoding
        {
            return db.Set<T>()
                .OrderBy(b => b.Id)
                .Select(b => new { b.Id, b.Title, IsDeleted = b.IsDeleted })
                .ToList<dynamic>();
        }

        public static JsonResponse<dynamic> LoadFormInitInfo(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);

                var IsBaseTable = x.HasValue("IsBaseTable") ? x.GetValue<bool>("IsBaseTable") : (bool?)null;
                var IsStaffType = x.HasValue("IsStaffType") ? x.GetValue<bool>("IsStaffType") : (bool?)null;
                var IsServiceGroup = x.HasValue("IsServiceGroup") ? x.GetValue<bool>("IsServiceGroup") : (bool?)null;
                var IsCostType = x.HasValue("IsCostType") ? x.GetValue<bool>("IsCostType") : (bool?)null;
                var IsPayStatus = x.HasValue("IsPayStatus") ? x.GetValue<bool>("IsPayStatus") : (bool?)null;
                var IsBargainSide = x.HasValue("IsBargainSide") ? x.GetValue<bool>("IsBargainSide") : (bool?)null;
                var IsInsurance = x.HasValue("IsInsurance") ? x.GetValue<bool>("IsInsurance") : (bool?)null;
                var IsInsuranceBox = x.HasValue("IsInsuranceBox") ? x.GetValue<bool>("IsInsuranceBox") : (bool?)null;
                var ISBank = x.HasValue("ISBank") ? x.GetValue<bool>("ISBank") : (bool?)null;
                var IsPayType = x.HasValue("IsPayType") ? x.GetValue<bool>("IsPayType") : (bool?)null;
                var IsChequeType = x.HasValue("IsChequeType") ? x.GetValue<bool>("IsChequeType") : (bool?)null;
                var IsChequeStatus = x.HasValue("IsChequeStatus") ? x.GetValue<bool>("IsChequeStatus") : (bool?)null;
                var IsSpecialDisease = x.HasValue("IsSpecialDisease") ? x.GetValue<bool>("IsSpecialDisease") : (bool?)null;
                var IsSpecialDrug = x.HasValue("IsSpecialDrug") ? x.GetValue<bool>("IsSpecialDrug") : (bool?)null;
                var IsSpecialCommentType = x.HasValue("IsSpecialCommentType") ? x.GetValue<bool>("IsSpecialCommentType") : (bool?)null;
                var IsMaxActionId = x.HasValue("IsMaxActionId") ? x.GetValue<bool>("IsMaxActionId") : (bool?)null;
                var IsMaxToothId = x.HasValue("IsMaxToothId") ? x.GetValue<bool>("IsMaxToothId") : (bool?)null;
                var IsSpecialty = x.HasValue("IsSpecialty") ? x.GetValue<bool>("IsSpecialty") : (bool?)null;
                var IsInsuranceBookletType = x.HasValue("IsInsuranceBookletType") ? x.GetValue<bool>("IsInsuranceBookletType") : (bool?)null;
                var IsToothNumber = x.HasValue("IsToothNumber") ? x.GetValue<bool>("IsToothNumber") : (bool?)null;
                var IsToothPart = x.HasValue("IsToothPart") ? x.GetValue<bool>("IsToothPart") : (bool?)null;
                var IsToothSegment = x.HasValue("IsToothSegment") ? x.GetValue<bool>("IsToothSegment") : (bool?)null;
                var IsMaritalStatus = x.HasValue("IsMaritalStatus") ? x.GetValue<bool>("IsMaritalStatus") : (bool?)null;
                var IsEducationLevel = x.HasValue("IsEducationLevel") ? x.GetValue<bool>("IsEducationLevel") : (bool?)null;
                var IsNationality = x.HasValue("IsNationality") ? x.GetValue<bool>("IsNationality") : (bool?)null;
                var IsCheckupType = x.HasValue("IsCheckupType") ? x.GetValue<bool>("IsCheckupType") : (bool?)null;
                var IsDiagnosis = x.HasValue("IsDiagnosis") ? x.GetValue<bool>("IsDiagnosis") : (bool?)null;
                var IsDiagnosisStatus = x.HasValue("IsDiagnosisStatus") ? x.GetValue<bool>("IsDiagnosisStatus") : (bool?)null;
                var IsDrugFrequency = x.HasValue("IsDrugFrequency") ? x.GetValue<bool>("IsDrugFrequency") : (bool?)null;
                var IsDrugRoute = x.HasValue("IsDrugRoute") ? x.GetValue<bool>("IsDrugRoute") : (bool?)null;
                var IsDrug = x.HasValue("IsDrug") ? x.GetValue<bool>("IsDrug") : (bool?)null;
                var IsDrugShape = x.HasValue("IsDrugShape") ? x.GetValue<bool>("IsDrugShape") : (bool?)null;
                var IsGender = x.HasValue("IsGender") ? x.GetValue<bool>("IsGender") : (bool?)null;
                var IsHealthcareProvider = x.HasValue("IsHealthcareProvider") ? x.GetValue<bool>("IsHealthcareProvider") : (bool?)null;
                var IsCodingICD10 = x.HasValue("IsCodingICD10") ? x.GetValue<bool>("IsCodingICD10") : (bool?)null;
                var IsInsuranceType = x.HasValue("IsInsuranceType") ? x.GetValue<bool>("IsInsuranceType") : (bool?)null;
                var IsItemUnit = x.HasValue("IsItemUnit") ? x.GetValue<bool>("IsItemUnit") : (bool?)null;
                var IsJob = x.HasValue("IsJob") ? x.GetValue<bool>("IsJob") : (bool?)null;
                var IsOrdinalTerm = x.HasValue("IsOrdinalTerm") ? x.GetValue<bool>("IsOrdinalTerm") : (bool?)null;
                var IsOrganizationType = x.HasValue("IsOrganizationType") ? x.GetValue<bool>("IsOrganizationType") : (bool?)null;
                var IsPersonRelationType = x.HasValue("IsPersonRelationType") ? x.GetValue<bool>("IsPersonRelationType") : (bool?)null;
                var IsReferredReason = x.HasValue("IsReferredReason") ? x.GetValue<bool>("IsReferredReason") : (bool?)null;
                var IsReferredType = x.HasValue("IsReferredType") ? x.GetValue<bool>("IsReferredType") : (bool?)null;
                var IsServiceUnit = x.HasValue("IsServiceUnit") ? x.GetValue<bool>("IsServiceUnit") : (bool?)null;
                var IsSeverity = x.HasValue("IsSeverity") ? x.GetValue<bool>("IsSeverity") : (bool?)null;
                var IsStuffTransactionType = x.HasValue("IsStuffTransactionType") ? x.GetValue<bool>("IsStuffTransactionType") : (bool?)null;
                var IsSubstanceType = x.HasValue("IsSubstanceType") ? x.GetValue<bool>("IsSubstanceType") : (bool?)null;

                using (var db = new DentalContext())
                {
                    dynamic BaseTable_List = null;
                    dynamic MaxActionId_Single = null;
                    dynamic MaxToothId_Single = null;
                    dynamic ServiceGroup_List = null;
                    dynamic Insurance_List = null;
                    dynamic InsuranceBox_List = null;
                    dynamic Bank_List = null;
                    dynamic StaffTypes_List = null;
                    dynamic CostType_List = null;
                    dynamic PayStatus_List = null;
                    dynamic BargainSide_List = null;
                    dynamic PayType_List = null;
                    dynamic ChequeType_List = null;
                    dynamic ChequeStatus_List = null;
                    dynamic SpecialDiseases_List = null;
                    dynamic SpecialDrug_List = null;
                    dynamic SpecialCommentType_List = null;
                    dynamic Specialty_List = null;
                    dynamic InsuranceBookletType_List = null;
                    dynamic ToothNumber_List = null;
                    dynamic ToothPart_List = null;
                    dynamic ToothSegment_List = null;
                    dynamic MaritalStatus_List = null;
                    dynamic EducationLevel_List = null;
                    dynamic Nationality_List = null;
                    dynamic CheckupType_List = null;
                    dynamic Diagnosis_List = null;
                    dynamic DiagnosisStatus_List = null;
                    dynamic DrugFrequency_List = null;
                    dynamic DrugRoute_List = null;
                    dynamic Drug_List = null;
                    dynamic DrugShape_List = null;
                    dynamic Gender_List = null;
                    dynamic HealthcareProvider_List = null;
                    dynamic CodingICD10_List = null;
                    dynamic InsuranceType_List = null;
                    dynamic ItemUnit_List = null;
                    dynamic Job_List = null;
                    dynamic OrdinalTerm_List = null;
                    dynamic OrganizationType_List = null;
                    dynamic PersonRelationType_List = null;
                    dynamic ReferredReason_List = null;
                    dynamic ReferredType_List = null;
                    dynamic ServiceUnit_List = null;
                    dynamic Severity_List = null;
                    dynamic StuffTransactionType_List = null;
                    dynamic SubstanceType_List = null;

                    // NOTE: Doctor_List, Personnel_List, PatientsTitles_List,
                    // Insurer_List, User_List, BankBranch_List and
                    // LastNameFirstChar_List existed in the original as
                    // declared variables placed into finalResult, but there
                    // was no corresponding "Is..." flag and no query ever
                    // populated them - they were always null (dead code).
                    // Preserved as always-null below; tell me if any of these
                    // should actually be implemented.

                    if (IsBaseTable == true)
                        BaseTable_List = db.BaseTables
                            .Where(b => b.IsDeleted != true)
                            .Select(b => new { b.Id, b.Title, b.Entity, b.Table })
                            .ToList();

                    if (IsMaxActionId == true)
                        MaxActionId_Single = new { Id = db.PatientServices.Select(ps => (int?)ps.Id).Max() ?? 0 };

                    if (IsMaxToothId == true)
                        MaxToothId_Single = new { Id = db.PatientTeeth.Select(pt => (int?)pt.Id).Max() ?? 0 };

                    if (IsServiceGroup == true)
                        ServiceGroup_List = db.ServiceGroups
                            .OrderBy(b => b.Id)
                            .Select(b => new { b.Id, b.Title, b.Color, IsDeleted = b.IsDeleted })
                            .ToList();

                    // NOTE: original Insurance/InsuranceBox projections omitted
                    // Value and SortOrder (unlike every other lookup) - preserved
                    // as-is since it may be intentional for how these are consumed.
                    if (IsInsurance == true)
                        Insurance_List = db.Insurances
                            .OrderBy(b => b.Id)
                            .Select(b => new { b.Id, b.Code, b.Title, b.TerminologyId, IsDeleted = b.IsDeleted })
                            .ToList();

                    if (IsInsuranceBox == true)
                        InsuranceBox_List = db.InsuranceBoxes
                            .OrderBy(b => b.Id)
                            .Select(b => new { b.Id, b.Code, b.Title, b.TerminologyId, IsDeleted = b.IsDeleted })
                            .ToList();

                    if (ISBank == true)
                        Bank_List = db.Banks
                            .OrderBy(b => b.Id)
                            .Select(b => new { b.Id, b.Title, IsDeleted = b.IsDeleted, b.ConnectionType, b.PortName, b.BoundRate })
                            .ToList();

                    if (IsStaffType == true)
                        StaffTypes_List = GetMinimalCodingList<StaffType>(db);

                    if (IsCostType == true)
                        CostType_List = GetMinimalCodingList<CostType>(db);

                    // NOTE: original PayStatus projection has no IsDeleted at all
                    // (unlike every other minimal lookup) - preserved as-is.
                    if (IsPayStatus == true)
                        PayStatus_List = db.Set<PayStatus>()
                            .OrderBy(b => b.Id)
                            .Select(b => new { b.Id, b.Title })
                            .ToList<dynamic>();

                    if (IsBargainSide == true)
                        BargainSide_List = GetMinimalCodingList<BargainSide>(db);

                    if (IsPayType == true)
                        PayType_List = GetMinimalCodingList<PayType>(db);

                    if (IsChequeType == true)
                        ChequeType_List = GetMinimalCodingList<ChequeType>(db);

                    if (IsChequeStatus == true)
                        ChequeStatus_List = GetMinimalCodingList<ChequeStatus>(db);

                    if (IsSpecialDisease == true)
                        SpecialDiseases_List = GetMinimalCodingList<SpecialDiseas>(db);

                    if (IsSpecialDrug == true)
                        SpecialDrug_List = GetMinimalCodingList<SpecialDrug>(db);

                    if (IsSpecialCommentType == true)
                        SpecialCommentType_List = GetMinimalCodingList<SpecialCommentType>(db);

                    if (IsSpecialty == true)
                        Specialty_List = GetMinimalCodingList<Specialty>(db);

                    if (IsInsuranceBookletType == true)
                        InsuranceBookletType_List = GetMinimalCodingList<InsuranceBookletType>(db);

                    if (IsToothNumber == true)
                        ToothNumber_List = GetMinimalCodingList<ToothNumber>(db);

                    if (IsToothPart == true)
                        ToothPart_List = GetMinimalCodingList<ToothPart>(db);

                    if (IsToothSegment == true)
                        ToothSegment_List = GetMinimalCodingList<ToothSegment>(db);

                    if (IsMaritalStatus == true)
                        MaritalStatus_List = GetFullCodingList<MaritalStatus>(db);

                    if (IsEducationLevel == true)
                        EducationLevel_List = GetFullCodingList<EducationLevel>(db);

                    if (IsNationality == true)
                        Nationality_List = GetFullCodingList<Nationality>(db);

                    if (IsCheckupType == true)
                        CheckupType_List = GetFullCodingList<CheckupType>(db);

                    if (IsDiagnosis == true)
                        Diagnosis_List = GetFullCodingList<Diagnosis>(db);

                    if (IsDiagnosisStatus == true)
                        DiagnosisStatus_List = GetFullCodingList<DiagnosisStatus>(db);

                    if (IsDrugFrequency == true)
                        DrugFrequency_List = GetFullCodingList<DrugFrequency>(db);

                    if (IsDrugRoute == true)
                        DrugRoute_List = GetFullCodingList<DrugRoute>(db);

                    if (IsDrug == true)
                        Drug_List = GetFullCodingList<Drug>(db);

                    if (IsDrugShape == true)
                        DrugShape_List = GetFullCodingList<DrugShape>(db);

                    if (IsGender == true)
                        Gender_List = GetFullCodingList<Gender>(db);

                    if (IsHealthcareProvider == true)
                        HealthcareProvider_List = GetFullCodingList<HealthcareProvider>(db);

                    if (IsCodingICD10 == true)
                        CodingICD10_List = GetFullCodingList<CodingICD10>(db);

                    if (IsInsuranceType == true)
                        InsuranceType_List = GetFullCodingList<InsuranceType>(db);

                    if (IsItemUnit == true)
                        ItemUnit_List = GetFullCodingList<ItemUnit>(db);

                    if (IsJob == true)
                        Job_List = GetFullCodingList<Job>(db);

                    if (IsOrdinalTerm == true)
                        OrdinalTerm_List = GetFullCodingList<OrdinalTerm>(db);

                    if (IsOrganizationType == true)
                        OrganizationType_List = GetFullCodingList<OrganizationType>(db);

                    if (IsPersonRelationType == true)
                        PersonRelationType_List = GetFullCodingList<PersonRelationType>(db);

                    if (IsReferredReason == true)
                        ReferredReason_List = GetFullCodingList<ReferredReason>(db);

                    if (IsReferredType == true)
                        ReferredType_List = GetFullCodingList<ReferredType>(db);

                    if (IsServiceUnit == true)
                        ServiceUnit_List = GetFullCodingList<ServiceUnit>(db);

                    if (IsSeverity == true)
                        Severity_List = GetFullCodingList<Severity>(db);

                    if (IsStuffTransactionType == true)
                        StuffTransactionType_List = GetFullCodingList<StuffTransactionType>(db);

                    if (IsSubstanceType == true)
                        SubstanceType_List = GetFullCodingList<SubstanceType>(db);

                    var finalResult = new
                    {
                        BaseTable = BaseTable_List,

                        Doctor = (dynamic)null,
                        Personnel = (dynamic)null,
                        StaffType = StaffTypes_List,
                        Patient = (dynamic)null,
                        ServiceGroup = ServiceGroup_List,

                        CostType = CostType_List,
                        PayStatus = PayStatus_List,
                        BargainSide = BargainSide_List,
                        Insurance = Insurance_List,
                        InsuranceBox = InsuranceBox_List,
                        Insurer = (dynamic)null,
                        User = (dynamic)null,
                        Bank = Bank_List,
                        BankBranch = (dynamic)null,
                        PayType = PayType_List,

                        ChequeType = ChequeType_List,
                        ChequeStatus = ChequeStatus_List,
                        SpecialDiseases = SpecialDiseases_List,
                        SpecialDrug = SpecialDrug_List,
                        PatientSpecialDiseases = (dynamic)null,
                        PatientSpecialDrug = (dynamic)null,
                        SpecialCommentType = SpecialCommentType_List,
                        LastNameFirstChar = (dynamic)null,
                        MaxActionId = MaxActionId_Single,
                        MaxToothId = MaxToothId_Single,
                        Specialty = Specialty_List,
                        InsuranceBookletType = InsuranceBookletType_List,

                        ToothNumber = ToothNumber_List,
                        ToothPart = ToothPart_List,
                        ToothSegment = ToothSegment_List,

                        MaritalStatus = MaritalStatus_List,
                        EducationLevel = EducationLevel_List,
                        Nationality = Nationality_List,

                        CheckupType = CheckupType_List,
                        Diagnosis = Diagnosis_List,
                        DiagnosisStatus = DiagnosisStatus_List,
                        DrugFrequency = DrugFrequency_List,
                        DrugRoute = DrugRoute_List,
                        Drug = Drug_List,
                        DrugShape = DrugShape_List,
                        Gender = Gender_List,
                        HealthcareProvider = HealthcareProvider_List,
                        CodingICD10 = CodingICD10_List,
                        InsuranceType = InsuranceType_List,
                        ItemUnit = ItemUnit_List,
                        Job = Job_List,
                        OrdinalTerm = OrdinalTerm_List,
                        OrganizationType = OrganizationType_List,
                        PersonRelationType = PersonRelationType_List,

                        ReferredReason = ReferredReason_List,
                        ReferredType = ReferredType_List,
                        ServiceUnit = ServiceUnit_List,
                        Severity = Severity_List,
                        StuffTransactionType = StuffTransactionType_List,
                        SubstanceType = SubstanceType_List,
                    };

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message };
            }
        }
        public static JsonResponse<dynamic> GetAllPatientsFullNamesX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                using (var db = new DentalContext())
                {
                    IQueryable<Patient> query = db.Patients
                        .Where(p => p.Id > 0);

                    if (IsDeleted != null)
                        query = query.Where(p => p.IsDeleted == IsDeleted.Value);

                    var rows = query.Select(p => new
                    {
                        p.Id,
                        p.FirstName,
                        p.LastName,

                    }).ToList();

                    var finalResult = rows.Select(i => new
                    {
                        i.Id,
                        PatientId = i.Id,
                        PatientName = (i.LastName ?? "") + " " + (i.FirstName ?? ""),

                    }).ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message };
            }
        }

        public static JsonResponse<dynamic> GetPatientsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                var NationalCode = x.HasValue("NationalCode") ? x.GetValue<string>("NationalCode") : null;
                var InsuredNumber = x.HasValue("InsuredNumber") ? x.GetValue<string>("InsuredNumber") : null;
                var FirstName = x.HasValue("FirstName") ? x.GetValue<string>("FirstName") : null;
                var LastName = x.HasValue("LastName") ? x.GetValue<string>("LastName") : null;
                var GenderId = x.HasValue("GenderId") ? x.GetValue<int>("GenderId") : (int?)null;
                var Presenter = x.HasValue("Presenter") ? x.GetValue<string>("Presenter") : null;
                var FixedPhone = x.HasValue("FixedPhone") ? x.GetValue<string>("FixedPhone") : null;
                var MobilePhone = x.HasValue("MobilePhone") ? x.GetValue<string>("MobilePhone") : null;

                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                var FromDateBirth = x.HasValue("FromDateBirth") ? x.GetValue<DateTime>("FromDateBirth") : (DateTime?)null;
                var ToDateBirth = x.HasValue("ToDateBirth") ? x.GetValue<DateTime>("ToDateBirth") : (DateTime?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                // NOTE: FromRemianed / ToRemianed / IsDebtor / IsCreditor were read
                // in the original method but never actually used anywhere in its
                // query or projection - dead parameters. Not reproduced here.

                using (var db = new DentalContext())
                {
                    IQueryable<Patient> query = db.Patients
                        .Include(p => p.Gender)
                        .Include(p => p.Doctor)
                        // original used an INNER JOIN to BaseCoding_Genders, so a
                        // patient without a resolvable Gender row was excluded
                        .Where(p => p.Id > 0);

                    if (PatientId != null)
                        query = query.Where(p => p.Id == PatientId.Value);

                    if (DoctorId != null)
                        query = query.Where(p => p.DoctorId == DoctorId.Value);

                    if (NationalCode != null)
                        // original: "NationalCode LIKE '{value}'" with no % wildcards -> exact match
                        query = query.Where(p => p.NationalCode == NationalCode);

                    if (InsuredNumber != null)
                        // original filtered on "BI_InsuredNumber", a column that exists
                        // nowhere in the schema or the query's result set - this branch
                        // was dead/broken code that would throw a SQL error if ever hit.
                        // Reinterpreted here as "patient has an insurance record with this
                        // InsuredNumber" (via PatientInsurances). CONFIRM this is intended
                        // before relying on it.
                        query = query.Where(p => p.PatientInsurances.Any(pi => pi.InsuredNumber == InsuredNumber));

                    if (FirstName != null)
                        query = query.Where(p => DbFunctions.Like(p.FirstName, "%" + FirstName + "%"));

                    if (LastName != null)
                        query = query.Where(p => DbFunctions.Like(p.LastName, "%" + LastName + "%"));

                    if (GenderId != null)
                        query = query.Where(p => p.GenderId == GenderId.Value);

                    if (Presenter != null)
                        query = query.Where(p => DbFunctions.Like(p.Presenter, "%" + Presenter + "%"));

                    if (FixedPhone != null)
                        query = query.Where(p => DbFunctions.Like(p.FixedPhone, "%" + FixedPhone + "%"));

                    if (MobilePhone != null)
                        query = query.Where(p => DbFunctions.Like(p.MobilePhone, "%" + MobilePhone + "%"));

                    if (FromDate != null)
                        query = query.Where(p => p.Date >= FromDate.Value);

                    if (ToDate != null)
                        query = query.Where(p => p.Date <= ToDate.Value);

                    if (FromDateBirth != null)
                        query = query.Where(p => p.BirthDate >= FromDateBirth.Value);

                    if (ToDateBirth != null)
                        query = query.Where(p => p.BirthDate <= ToDateBirth.Value);

                    if (IsDeleted != null)
                        query = query.Where(p => p.IsDeleted == IsDeleted.Value);

                    // Project only the columns we need (translatable to SQL).
                    var rows = query.Select(p => new
                    {
                        PatientId = p.Id,
                        p.FirstName,
                        p.LastName,
                        p.FatherName,
                        p.Date,
                        p.BirthDate,
                        p.JobId,
                        p.Presenter,
                        p.FixedPhone,
                        p.MobilePhone,
                        p.Address,
                        p.Comment,
                        p.IsDeleted,
                        p.GenderId,
                        GenderTitle = p.Gender.Title,
                        p.NationalityId,
                        p.MaritalStatusId,
                        p.EducationLevelId,
                        p.NationalCode,
                        p.DoctorId,
                        DoctorFirstName = p.Doctor.FirstName,
                        DoctorLastName = p.Doctor.LastName,
                        DoctorMedicalCouncilCode = p.Doctor.MedicalCouncilCode,
                        HasSpecialComment = p.PatientSpecialComments.Count()
                    }).ToList();

                    // Second pass in memory - mirrors the original's own two-pass
                    // shape (raw query -> patientResult -> finalResult), needed
                    // because Publics.GetDate / GetSolarDate / GetAge are plain C#
                    // helpers and can't be translated into SQL.
                    var finalResult = rows.Select(i => new
                    {
                        i.PatientId,
                        i.FirstName,
                        i.LastName,
                        PatientName = (i.LastName ?? "") + " " + (i.FirstName ?? ""),
                        i.FatherName,
                        Date = Publics.GetDate(i.Date),
                        SolarDate = Publics.GetSolarDate(i.Date),
                        BirthDate = Publics.GetDate(i.BirthDate),
                        SolarBirthDate = Publics.GetSolarDate(i.BirthDate),
                        i.NationalCode,
                        Age = Publics.GetAge(i.BirthDate),
                        i.GenderId,
                        i.GenderTitle,
                        JobId = i.JobId,   // nullable - original did an unchecked (int)cast here, which would throw on a null JobId
                        i.Presenter,
                        i.NationalityId,
                        i.MaritalStatusId,
                        i.EducationLevelId,
                        i.FixedPhone,
                        i.MobilePhone,
                        i.Address,
                        i.Comment,
                        i.IsDeleted,
                        i.DoctorId,
                        DoctorTitle = i.DoctorLastName != null ? (i.DoctorFirstName + " " + i.DoctorLastName) : null,
                        i.DoctorMedicalCouncilCode,
                        i.HasSpecialComment
                    }).ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message };
            }
        }

        public static JsonResponse<dynamic> GetOnePatientInfoX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;

                if (PatientId == null)
                    throw new Exception("بیمار مشخص نشده است");

                dynamic sObj = new
                {
                    PatientId = PatientId
                };

                JsonResponse<dynamic> result = DataProvider.GetListPatientInfoX(sObj);
                if (result == null || result.Success == false)
                    return null;
                var data = result.Data;
                var dd = (data != null && (Enumerable.Count(data) > 0))
                         ? data as IEnumerable<dynamic>
                         : Enumerable.Empty<dynamic>();

                var patientResult = dd.Select(i =>
                    new
                    {
                        PatientId = (int)i.PatientId,
                        FirstName = (string)i.FirstName,
                        LastName = (string)i.LastName,
                        PatientName = Convert.ToString(i.FirstName) + " " + Convert.ToString(i.LastName),
                        FatherName = (string)i.FatherName,
                        Date = Publics.GetDate(i.Date),
                        SolarDate = Publics.GetSolarDate(i.Date),
                        BirthDate = Publics.GetDate(i.BirthDate),
                        SolarBirthDate = Publics.GetSolarDate(i.BirthDate),
                        NationalCode = (string)i.NationalCode,
                        Age = Publics.GetAge(i.BirthDate),
                        GenderId = (int?)i.GenderId,
                        GenderTitle = (string)i.GenderTitle,
                        JobId = (int?)i.JobId,
                        JobTitle = i.JobTitle,
                        Presenter = (string)i.Presenter,
                        MaritalStatusId = (int?)i.MaritalStatusId,
                        EducationLevelId = (int?)i.EducationLevelId,
                        NationalityId = (int?)i.NationalityId,
                        FixedPhone = (string)i.FixedPhone,
                        MobilePhone = (string)i.MobilePhone,
                        Address = (string)i.Address,
                        IsDeleted = Convert.ToBoolean(i.IsDeleted),
                        DoctorId = i.DoctorId != null ? (int)i.DoctorId : -1,
                        DoctorTitle = (string)i.DoctorTitle,
                        DoctorMedicalCouncilCode = (string)i.DoctorMedicalCouncilCode,
                        HasSpecialComment = i.HasSpecialComment == null ? 0 : (int)i.HasSpecialComment,

                    }).SingleOrDefault();

                JsonResponse<dynamic> resultPatientInsuranceX = GetPatientInsuranceX(searchObj);
                if (resultPatientInsuranceX == null || resultPatientInsuranceX.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var piData = resultPatientInsuranceX.Data != null ? resultPatientInsuranceX.Data as IEnumerable<dynamic> : Enumerable.Empty<dynamic>();

                var patientInsuranceResult = piData.Select(i =>
                    new
                    {
                        BI_PatientInsuranceId = (int?)i.BI_PatientInsuranceId,
                        BI_InsurerId = (int?)i.BI_InsurerId,
                        BI_InsurerTitle = (string)i.BI_InsurerTitle,
                        BI_InsuredNumber = (string)i.BI_InsuredNumber,
                        BI_InsuranceBookletSerialNumber = (string)i.BI_InsuranceBookletSerialNumber,
                        BI_ExpirationDate = Publics.GetDate(i.BI_ExpirationDate),
                        BI_ExpirationSolarDate = Publics.GetSolarDate(i.BI_ExpirationDate)

                    }).SingleOrDefault();

                dynamic sObj1 = new
                {
                    PatientId = PatientId,
                    IsGetOnlyChecked = true
                };
                JsonResponse<dynamic> resultSpecialDiseasesX = GetPatientSpecialDiseases(sObj1);
                if (resultSpecialDiseasesX == null || resultSpecialDiseasesX.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var psdiData = resultSpecialDiseasesX.Data != null ? resultSpecialDiseasesX.Data as IEnumerable<dynamic> : Enumerable.Empty<dynamic>();


                var patientSpecialIllnessResult = psdiData.Select(i =>
                    new
                    {
                        Id = (int)i.Id,
                        Title = (string)i.Title,
                    }).ToList();

                dynamic sObj2 = new
                {
                    PatientId = PatientId,
                    IsGetOnlyChecked = true
                };
                JsonResponse<dynamic> resultSpecialDrugX = GetPatientSpecialDrug(sObj2);
                if (resultSpecialDrugX == null || resultSpecialDrugX.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات ");

                var psdrData = resultSpecialDrugX.Data != null ? resultSpecialDrugX.Data as IEnumerable<dynamic> : Enumerable.Empty<dynamic>();

                var patientSpecialDrugResult = psdrData.Select(i =>
                    new
                    {
                        Id = (int)i.Id,
                        Title = (string)i.Title,
                    }).ToList();

                JsonResponse<dynamic> resultData = GetPatientBillX(searchObj);
                if (resultData == null || resultData.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات ");

                var ff = resultData.Data != null ? resultData.Data as IEnumerable<dynamic> : Enumerable.Empty<dynamic>();

                var patientFinancial = new
                {
                    Total_Patient_Charge = Publics.GetPropertyValue<int>(ff, "Total_Patient_Charge"),
                    Total_Patient_Paid = Publics.GetPropertyValue<int>(ff, "Total_Patient_Paid"),
                    Total_Patient_Discount = Publics.GetPropertyValue<int>(ff, "Total_Patient_Discount"),
                    Total_Patient_Remianed = Publics.GetPropertyValue<int>(ff, "Total_Patient_Remianed"),
                };

                var finalResult = new
                {
                    Patient = patientResult,
                    PatientInsurance = patientInsuranceResult,
                    PatientFinancial = patientFinancial,
                    PatientSpecialIllness = patientSpecialIllnessResult,
                    PatientSpecialDrug = patientSpecialDrugResult,
                };

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetListPatientInfoX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                var InsurerId = x.HasValue("InsurerId") ? x.GetValue<int>("InsurerId") : (int?)null;
                var NationalCode = x.HasValue("NationalCode") ? x.GetValue<string>("NationalCode") : null;
                var InsuredNumber = x.HasValue("InsuredNumber") ? x.GetValue<string>("InsuredNumber") : null;
                var FirstName = x.HasValue("FirstName") ? x.GetValue<string>("FirstName") : null;
                var LastName = x.HasValue("LastName") ? x.GetValue<string>("LastName") : null;
                var GenderId = x.HasValue("GenderId") ? x.GetValue<int>("GenderId") : (int?)null;
                var Presenter = x.HasValue("Presenter") ? x.GetValue<string>("Presenter") : null;
                var FixedPhone = x.HasValue("FixedPhone") ? x.GetValue<string>("FixedPhone") : null;
                var MobilePhone = x.HasValue("MobilePhone") ? x.GetValue<string>("MobilePhone") : null;

                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                var FromDateBirth = x.HasValue("FromDateBirth") ? x.GetValue<DateTime>("FromDateBirth") : (DateTime?)null;
                var ToDateBirth = x.HasValue("ToDateBirth") ? x.GetValue<DateTime>("ToDateBirth") : (DateTime?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                var FromRemianed = x.HasValue("FromRemianed") ? x.GetValue<double>("FromRemianed") : (double?)null;
                var ToRemianed = x.HasValue("ToRemianed") ? x.GetValue<double>("ToRemianed") : (double?)null;
                var IsDebtor = x.HasValue("IsDebtor") ? x.GetValue<bool>("IsDebtor") : (bool?)null;
                var IsCreditor = x.HasValue("IsCreditor") ? x.GetValue<bool>("IsCreditor") : (bool?)null;

                // --- Pull in the 3 supporting datasets, same as the original ---

                JsonResponse<dynamic> resultPatientInsuranceX = GetPatientInsuranceX(new { IsDeleted = false });
                if (resultPatientInsuranceX == null || resultPatientInsuranceX.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var piData = resultPatientInsuranceX.Data != null ? resultPatientInsuranceX.Data as IEnumerable<dynamic> : Enumerable.Empty<dynamic>();

                var patientInsuranceResult = piData.Select(i =>
                    new
                    {
                        PatientId = (int?)i.PatientId,
                        BI_PatientInsuranceId = (int?)i.BI_PatientInsuranceId,
                        BI_InsurerId = (int?)i.BI_InsurerId,
                        BI_InsurerTitle = (string)i.BI_InsurerTitle,
                        BI_InsuredNumber = (string)i.BI_InsuredNumber,
                        BI_InsuranceBookletSerialNumber = (string)i.BI_InsuranceBookletSerialNumber,
                        BI_ExpirationDate = Publics.GetDate(i.BI_ExpirationDate),
                        BI_ExpirationSolarDate = Publics.GetSolarDate(i.BI_ExpirationDate)

                    }).ToList();

                // NOTE: GetPatientServicesX / GetPatientFinancialsX are not part of
                // this conversion batch - called exactly as before (still Dapper
                // internally for now). Nothing about this orchestration layer needs
                // to change once they're converted too, since the JsonResponse
                // contract stays the same.
                JsonResponse<dynamic> resultPatientServicesX = GetPatientServicesX(new { CheckupTypeId = 2, IsDeleted = false });
                if (resultPatientServicesX == null || resultPatientServicesX.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var psData = resultPatientServicesX.Data != null ? resultPatientServicesX.Data as IEnumerable<dynamic> : Enumerable.Empty<dynamic>();

                var patientServicesResult = psData.Select(i =>
                    new
                    {
                        PatientId = (int?)i.PatientId,
                        ServicePrice = i.ServicePrice != null ? (int)i.ServicePrice : 0,

                    }).ToList();

                JsonResponse<dynamic> resultPatientFinancialsX = GetPatientFinancialsX(new { IsDeleted = false });
                if (resultPatientFinancialsX == null || resultPatientFinancialsX.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var pfData = resultPatientFinancialsX.Data != null ? resultPatientFinancialsX.Data as IEnumerable<dynamic> : Enumerable.Empty<dynamic>();

                var patientFinancialResult = pfData.Select(i =>
                    new
                    {
                        PatientId = (int?)i.PatientId,
                        Amount = i.Amount != null ? (int)i.Amount : 0,
                        PayTypeId = (int?)i.PayTypeId,

                    }).ToList();

                // --- Main patient query, converted from the raw derived-table SQL ---

                using (var db = new DentalContext())
                {
                    IQueryable<Patient> query = db.Patients
                        .Include(p => p.Gender)
                        .Include(p => p.Doctor)
                        // original used an INNER JOIN to BaseCoding_Genders
                        .Where(p => p.Id > 0 && p.Gender != null);

                    if (PatientId != null)
                        query = query.Where(p => p.Id == PatientId.Value);

                    if (DoctorId != null)
                        query = query.Where(p => p.DoctorId == DoctorId.Value);

                    if (NationalCode != null)
                        query = query.Where(p => p.NationalCode == NationalCode);

                    if (InsuredNumber != null)
                        // original filtered on "BI_InsuredNumber", a column that
                        // doesn't exist in the derived table - dead/broken code.
                        // Reinterpreted as "patient has an insurance record with
                        // this InsuredNumber" (same call as made in GetPatientsX).
                        // CONFIRM this is intended.
                        query = query.Where(p => p.PatientInsurances.Any(pi => pi.InsuredNumber == InsuredNumber));

                    if (FirstName != null)
                        query = query.Where(p => DbFunctions.Like(p.FirstName, "%" + FirstName + "%"));

                    if (LastName != null)
                        query = query.Where(p => DbFunctions.Like(p.LastName, "%" + LastName + "%"));

                    if (GenderId != null)
                        query = query.Where(p => p.GenderId == GenderId.Value);

                    if (Presenter != null)
                        query = query.Where(p => DbFunctions.Like(p.Presenter, "%" + Presenter + "%"));

                    if (FixedPhone != null)
                        query = query.Where(p => DbFunctions.Like(p.FixedPhone, "%" + FixedPhone + "%"));

                    if (MobilePhone != null)
                        query = query.Where(p => DbFunctions.Like(p.MobilePhone, "%" + MobilePhone + "%"));

                    if (FromDate != null)
                        query = query.Where(p => p.Date >= FromDate.Value);

                    if (ToDate != null)
                        query = query.Where(p => p.Date <= ToDate.Value);

                    if (FromDateBirth != null)
                        query = query.Where(p => p.BirthDate >= FromDateBirth.Value);

                    if (ToDateBirth != null)
                        query = query.Where(p => p.BirthDate <= ToDateBirth.Value);

                    if (IsDeleted != null)
                        query = query.Where(p => p.IsDeleted == IsDeleted.Value);

                    var rows = query.Select(p => new
                    {
                        PatientId = p.Id,
                        p.FirstName,
                        p.LastName,
                        p.FatherName,
                        p.Date,
                        p.BirthDate,
                        p.JobId,
                        JobTitle = p.JobId != null ? p.Job.Title : "",
                        p.Presenter,
                        p.FixedPhone,
                        p.MobilePhone,
                        p.Address,
                        p.Comment,
                        p.IsDeleted,
                        p.GenderId,
                        GenderTitle = p.Gender.Title,
                        p.NationalityId,
                        p.MaritalStatusId,
                        p.EducationLevelId,
                        p.NationalCode,
                        p.DoctorId,
                        DoctorFirstName = p.Doctor.FirstName,
                        DoctorLastName = p.Doctor.LastName,
                        DoctorMedicalCouncilCode = p.Doctor.MedicalCouncilCode,
                        HasSpecialComment = p.PatientSpecialComments.Count()
                    }).ToList();

                    var patientResult = rows.Select(i => new
                    {
                        PatientId = i.PatientId,
                        i.FirstName,
                        i.LastName,
                        PatientName = (i.FirstName ?? "") + " " + (i.LastName ?? ""),
                        i.FatherName,
                        Date = Publics.GetDate(i.Date),
                        SolarDate = Publics.GetSolarDate(i.Date),
                        BirthDate = Publics.GetDate(i.BirthDate),
                        SolarBirthDate = Publics.GetSolarDate(i.BirthDate),
                        i.NationalCode,
                        Age = Publics.GetAge(i.BirthDate),
                        i.GenderId,
                        i.GenderTitle,
                        i.JobId,
                        i.JobTitle,
                        i.Presenter,
                        i.NationalityId,
                        i.MaritalStatusId,
                        i.EducationLevelId,
                        i.FixedPhone,
                        i.MobilePhone,
                        i.Address,
                        i.Comment,
                        i.IsDeleted,
                        i.DoctorId,
                        DoctorTitle = i.DoctorFirstName != null ? (i.DoctorFirstName + " " + i.DoctorLastName) : null,
                        i.DoctorMedicalCouncilCode,
                        i.HasSpecialComment
                    }).ToList();

                    // --- Join with the 3 supporting datasets + compute financial totals ---
                    // (pure in-memory LINQ, unchanged from the original)

                    var finalResult = patientResult.Select(i =>
                    {
                        var piItem = patientInsuranceResult.Where(j => j.PatientId == i.PatientId).Select(j => j).FirstOrDefault();
                        var totalCharge = patientServicesResult.Where(j => j.PatientId == i.PatientId).Select(j => j).Sum(j => j.ServicePrice);
                        var totalPaid = patientFinancialResult.Where(j => j.PatientId == i.PatientId)
                                                              .Where(j => j.PayTypeId == 1 || j.PayTypeId == 2 || j.PayTypeId == 3)
                                                              .Select(j => j).Sum(j => j.Amount);
                        var totalRefund = patientFinancialResult.Where(j => j.PatientId == i.PatientId)
                                                              .Where(j => j.PayTypeId == 5)
                                                              .Select(j => j).Sum(j => j.Amount);
                        var totalDiscount = patientFinancialResult.Where(j => j.PatientId == i.PatientId)
                                                              .Where(j => j.PayTypeId == 6)
                                                              .Select(j => j).Sum(j => j.Amount);
                        return new
                        {
                            i.PatientId,
                            i.FirstName,
                            i.LastName,
                            i.PatientName,
                            i.FatherName,
                            i.Date,
                            i.SolarDate,
                            i.BirthDate,
                            i.SolarBirthDate,
                            i.NationalCode,
                            i.Age,
                            i.GenderId,
                            i.GenderTitle,
                            i.JobId,
                            i.JobTitle,
                            i.Presenter,
                            i.NationalityId,
                            i.MaritalStatusId,
                            i.EducationLevelId,
                            i.FixedPhone,
                            i.MobilePhone,
                            i.Address,
                            i.Comment,
                            i.IsDeleted,
                            i.DoctorId,
                            i.DoctorTitle,
                            i.DoctorMedicalCouncilCode,
                            i.HasSpecialComment,

                            BI_PatientInsuranceId = piItem != null ? piItem.BI_PatientInsuranceId : 0,
                            BI_InsurerId = piItem != null ? piItem.BI_InsurerId : 0,
                            BI_InsurerTitle = piItem != null ? piItem.BI_InsurerTitle : "آزاد",
                            BI_InsuredNumber = piItem != null ? piItem.BI_InsuredNumber : "",
                            BI_InsuranceBookletSerialNumber = piItem != null ? piItem.BI_InsuranceBookletSerialNumber : "",
                            BI_ExpirationDate = piItem != null ? piItem.BI_ExpirationDate : (DateTime?)null,
                            BI_ExpirationSolarDate = piItem != null ? piItem.BI_ExpirationSolarDate : "",

                            Total_Patient_Charge = totalCharge,
                            Total_Patient_Paid = totalPaid,
                            Total_Patient_Refund = totalRefund,
                            Total_Patient_Discount = totalDiscount,
                            Total_Patient_Remianed = (totalCharge - ((totalPaid - totalRefund) + totalDiscount)),
                        };
                    }).ToList();

                    if (InsurerId != null)
                        finalResult = finalResult.Where(i => i.BI_InsurerId == InsurerId).ToList();

                    if (FromRemianed != null)
                        finalResult = finalResult.Where(i => i.Total_Patient_Remianed > FromRemianed).ToList();

                    if (ToRemianed != null)
                        finalResult = finalResult.Where(i => i.Total_Patient_Remianed < ToRemianed).ToList();

                    if (IsDebtor == true)
                        finalResult = finalResult.Where(i => i.Total_Patient_Remianed > 0).ToList();

                    if (IsCreditor == true)
                        finalResult = finalResult.Where(i => i.Total_Patient_Remianed < 0).ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }


        public static JsonResponse<dynamic> GetPatientInsuranceX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                using (var db = new DentalContext())
                {
                    //db.Database.Log = sql => System.IO.File.AppendAllText(@"C:\temp\ef_log.txt", sql + "\r\n");
                    // Original WHERE always hardcoded (InsuranceTypeId = 1) AND (IsDeleted = 0),
                    // then optionally ANDed a caller-supplied IsDeleted on top of that same
                    // hardcoded 0 - so calling this with IsDeleted = true always returns empty
                    // (0 AND true can never match). Preserved exactly as-is below.
                    IQueryable<PatientInsurance> query = db.PatientInsurances
                        .Include(pi => pi.Insurer)
                        .Include(pi => pi.PersonRelationType)
                        .Include(pi => pi.InsuranceBookletType)
                        .Where(pi => pi.InsuranceTypeId == 1 && pi.IsDeleted == false);

                    if (PatientId != null)
                        query = query.Where(pi => pi.PatientId == PatientId.Value);

                    if (IsDeleted != null)
                        query = query.Where(pi => pi.IsDeleted == IsDeleted.Value);

                    var rows = query.Select(pi => new
                    {
                        pi.PatientId,
                        BI_PatientInsuranceId = pi.Id,
                        BI_InsurerId = pi.InsurerId,
                        BI_InsuranceId = pi.Insurer.InsuranceId,
                        BI_InsuranceBoxId = pi.Insurer.InsuranceBoxId,
                        BI_InsurerTitle = pi.Insurer.Title,
                        BI_InsuredNumber = pi.InsuredNumber,
                        BI_InsuranceBookletSerialNumber = pi.InsuranceBookletSerialNumber,
                        BI_IntroLetterNum = pi.IntroLetterNum,
                        BI_OutPatientPercent = pi.Insurer.InsurerPercent,
                        BI_ContractStartDate = pi.Insurer.StartDate,
                        BI_ContractEndDate = pi.Insurer.EndDate,
                        BI_Percent = pi.Percent,
                        BI_MaxPay = pi.MaxPay,
                        BI_ExpirationDate = pi.ExpirationDate,
                        BI_PageNumber = pi.PageNumber,
                        BI_PersonRelationTypeId = pi.PersonRelationTypeId,
                        BI_PersonRelationTypeTitle = pi.PersonRelationType.Title,
                        BI_IssuedPlaceCode = pi.IssuedPlaceCode,
                        BI_InsurerAgentCode = pi.InsurerAgentCode,
                        BI_HID = pi.HID,
                        BI_SHEBAD = pi.SHEBAD,
                        BI_InsuranceBookletTypeId = pi.InsuranceBookletTypeId,
                        BI_InsuranceBookletTypeTitle = pi.InsuranceBookletType.Title
                    }).ToList();

                    var now = DateTime.Now;

                    // Second pass in memory: date math / Publics.GetDate() & GetSolarDate()
                    // are plain C# and can't be translated into SQL.
                    var finalResult = rows.Select(i => new
                    {
                        i.PatientId,
                        i.BI_PatientInsuranceId,
                        i.BI_InsurerId,
                        i.BI_InsuranceId,
                        i.BI_InsuranceBoxId,
                        i.BI_InsurerTitle,
                        i.BI_InsuredNumber,
                        i.BI_InsuranceBookletSerialNumber,
                        i.BI_InsuranceBookletTypeId,
                        i.BI_InsuranceBookletTypeTitle,
                        BI_IsActive = (i.BI_ExpirationDate != null && i.BI_ExpirationDate > now) ? 1 : 0,
                        i.BI_IntroLetterNum,
                        i.BI_OutPatientPercent,


                        BI_ContractStartDate = i.BI_ContractStartDate,
                        BI_ContractStartDateSolar = i.BI_ContractStartDate != null ? Publics.GetSolarDate(i.BI_ContractStartDate) : "",

                        BI_ContractEndDate = i.BI_ContractEndDate,
                        BI_ContractEndDateSolar = i.BI_ContractEndDate != null ? Publics.GetSolarDate(i.BI_ContractEndDate) : "",

                        BI_ExpirationDate = i.BI_ExpirationDate,
                        BI_ExpirationDateSolar = i.BI_ExpirationDate != null ? Publics.GetSolarDate(i.BI_ExpirationDate) : "",

                        i.BI_Percent,
                        i.BI_MaxPay,

                        BI_VDateDiff = i.BI_ExpirationDate != null ? (now.Date - i.BI_ExpirationDate.Value.Date).TotalDays : 0,
                        i.BI_PersonRelationTypeId,
                        i.BI_PersonRelationTypeTitle,
                        i.BI_PageNumber,
                        i.BI_IssuedPlaceCode,
                        i.BI_InsurerAgentCode,
                        i.BI_SHEBAD,
                        i.BI_HID,
                    }).ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };

            }
        }


        public static JsonResponse<dynamic> GetPatientSpecialDrug(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var IsGetOnlyChecked = x.HasValue("IsGetOnlyChecked") ? x.GetValue<bool>("IsGetOnlyChecked") : false;

                using (var db = new DentalContext())
                {
                    // original LEFT JOIN'ed on "b.PatientId = @PatientId" - if
                    // PatientId is null that condition can never match in SQL, so
                    // every row comes back unchecked. Reproduced with the "hasPatientId"
                    // guard below rather than letting a null PatientId throw/misbehave
                    // on the long comparison.
                    bool hasPatientId = PatientId != null;
                    long pid = PatientId ?? 0;

                    var finalResult = db.Set<SpecialDrug>()
                        .Where(a => a.Id != 0)
                        .Select(a => new
                        {
                            PatientId = PatientId,
                            Id = a.Id,
                            Title = a.Title,
                            IsCheck = hasPatientId && a.PatientSpecialDrugs.Any(b => b.PatientId == pid)
                        })
                        .ToList();

                    var result = IsGetOnlyChecked
                        ? finalResult.Where(i => i.IsCheck == true).ToList()
                        : finalResult;

                    return new JsonResponse<dynamic>() { Success = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }


        public static JsonResponse<dynamic> GetPatientSpecialDiseases(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var IsGetOnlyChecked = x.HasValue("IsGetOnlyChecked") ? x.GetValue<bool>("IsGetOnlyChecked") : false;

                using (var db = new DentalContext())
                {
                    // same null-PatientId behavior as GetPatientSpecialDrug - see note there.
                    bool hasPatientId = PatientId != null;
                    long pid = PatientId ?? 0;

                    var finalResult = db.Set<SpecialDiseas>()
                        .Where(a => a.Id != 0)
                        .Select(a => new
                        {
                            PatientId = PatientId,
                            Id = a.Id,
                            Title = a.Title,
                            IsCheck = hasPatientId && a.PatientSpecialDiseases.Any(b => b.PatientId == pid)
                        })
                        .ToList();

                    var result = IsGetOnlyChecked
                        ? finalResult.Where(i => i.IsCheck == true).ToList()
                        : finalResult;

                    return new JsonResponse<dynamic>() { Success = true, Data = result };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }



        public static JsonResponse<dynamic> GetPatientBillX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;

                if (PatientId == null)
                    throw new Exception("کد بیمار وارد نشده است");

                if (PatientId < 1)
                    return null;

                dynamic sObj = new
                {
                    PatientId = PatientId,
                    CheckupTypeId = 2,
                    IsDeleted = false
                };
                // NOTE: original called GetPatientServicesX(searchObj) here, NOT
                // GetPatientServicesX(sObj) - the sObj built just above (with
                // CheckupTypeId/IsDeleted) is unused; the caller's raw searchObj
                // is passed straight through instead. Preserved exactly as-is -
                // confirm whether this was intentional.
                var resultPatientServices = GetPatientServicesX(searchObj);
                if (resultPatientServices == null || resultPatientServices.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات سرویسهای بیمار ");

                var dataPatientServices = resultPatientServices.Data as IEnumerable<dynamic>;

                var patientServicesResult =
                            dataPatientServices
                            .Select(i =>
                            {
                                return new
                                {
                                    PatientId = (int)i.PatientId,
                                    PatientName = (string)i.PatientName,
                                    ServicePrice = (double)i.ServicePrice,
                                };
                            }).ToList();

                var patientServicesGroupByPatientResult =
                                    (from item in patientServicesResult
                                     group item by new { item.PatientId } into gItem

                                     select new
                                     {
                                         PatientId = gItem.Key,
                                         PatientName = gItem.First().PatientName,
                                         ServiceCount = gItem.Count(),
                                         Total_Patient_Charge = gItem.Sum(i => i.ServicePrice)
                                     }).ToList();

                sObj = new
                {
                    PatientId = PatientId,
                    IsDeleted = false
                };
                var resultPatientFinancials = GetPatientFinancialsX(sObj);
                if (resultPatientFinancials == null || resultPatientFinancials.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات تراکنشات مالی بیمار ");
                var dataPatientFinancials = resultPatientFinancials.Data as IEnumerable<dynamic>;

                var patientFinancialsResult =
                           dataPatientFinancials
                           .Select(i =>
                           {
                               return new
                               {
                                   PatientId = (int)i.PatientId,
                                   PatientName = (string)i.PatientName,
                                   Amount = (double)i.Amount,
                                   PayTypeId = (int)i.PayTypeId
                               };
                           }).ToList();

                var patientFinancialsGroupByPatientResult =
                                    (from item in patientFinancialsResult
                                     group item by new { item.PatientId } into gItem

                                     select new
                                     {
                                         PatientId = gItem.Key,
                                         Total_Patient_Paid = gItem.Where(i => i.PayTypeId == 1 || i.PayTypeId == 2 || i.PayTypeId == 3).Sum(i => i.Amount),
                                         Total_Patient_Refund = gItem.Where(i => i.PayTypeId == 5).Sum(i => i.Amount),
                                         Total_Patient_Discount = gItem.Where(i => i.PayTypeId == 6).Sum(i => i.Amount)
                                     }).ToList();

                var a = patientServicesGroupByPatientResult.FirstOrDefault();
                var b = patientFinancialsGroupByPatientResult.FirstOrDefault();
                var finalResult = (
                    new
                    {
                        PatientId = PatientId,
                        PatientName = a != null ? a.PatientName : "",
                        Total_Patient_Charge = a != null ? a.Total_Patient_Charge : 0,
                        Total_Patient_Paid = b != null ? b.Total_Patient_Paid : 0,
                        Total_Patient_Refund = b != null ? b.Total_Patient_Refund : 0,
                        Total_Patient_Discount = b != null ? b.Total_Patient_Discount : 0,
                        Total_Patient_Remianed = (a != null && b != null) ? (a.Total_Patient_Charge
                                                 - ((b.Total_Patient_Paid - b.Total_Patient_Refund)
                                                 + b.Total_Patient_Discount)) : 0,

                    });

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientServicesX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                var PatientServiceId = x.HasValue("PatientServiceId") ? x.GetValue<int>("PatientServiceId") : (int?)null;
                var BasicInsurerId = x.HasValue("BasicInsurerId") ? x.GetValue<int>("BasicInsurerId") : (int?)null; // in final result
                var ServiceGroupId = x.HasValue("ServiceGroupId") ? x.GetValue<int>("ServiceGroupId") : (int?)null;
                var ServiceId = x.HasValue("ServiceId") ? x.GetValue<int>("ServiceId") : (int?)null;
                var CheckupTypeId = x.HasValue("CheckupTypeId") ? x.GetValue<int>("CheckupTypeId") : (int)2;
                var ToothId = x.HasValue("ToothId") ? x.GetValue<int>("ToothId") : (int?)null;
                var ProviderDoctorId = x.HasValue("ProviderDoctorId") ? x.GetValue<int>("ProviderDoctorId") : (int?)null;
                var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                JsonResponse<dynamic> resultData = GetPatientInsuranceX(searchObj);
                if (resultData == null && resultData.Success != true && resultData.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var piiData = resultData.Data as IEnumerable<dynamic>;

                var resultPatientInsurance = piiData.Select(i =>
                            new
                            {
                                PatientId = i.PatientId,
                                BasicInsurerId = i.BI_InsurerId,
                                BasicInsurerTitle = i.BI_InsurerTitle,
                                BasicInsurerPercent = i.BI_Percent

                            }).ToList();

                resultData = GetToothX(searchObj);
                if (resultData == null || resultData.Success == false || resultData.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var tthData = resultData.Data as IEnumerable<dynamic>;

                var resultTeethX = tthData.Select(i =>
                                        new
                                        {
                                            ToothId = (int)i.Id,
                                            ToothName = (string)i.ToothName,
                                            ToothTitle = (string)i.ToothTitle,
                                            ToothGroup = (int)i.ToothGroup,
                                            ToothImage = (byte[])i.ToothImage

                                        }).ToList();

                using (var db = new DentalContext())
                {
                    IQueryable<PatientService> query = db.PatientServices
                        .Include(ps => ps.Service)
                        .Include(ps => ps.Service.ServiceGroup)
                        .Include(ps => ps.CheckupType)
                        .Include(ps => ps.Patient)
                        .Include(ps => ps.Patient.Doctor)
                        .Include(ps => ps.ProviderDoctor)
                        .Where(ps => ps.IsDeleted != true)
                        // original used INNER JOINs for svc/svg/cht/pp/staf1/staf2 -
                        // rows lacking any of these are excluded, same as here.
                        .Where(ps => ps.Service != null
                                  && ps.Service.ServiceGroup != null
                                  && ps.CheckupType != null
                                  && ps.Patient != null
                                  && ps.Patient.Doctor != null
                                  && ps.ProviderDoctor != null)
                        .Where(ps => ps.Id != 0);

                    if (PatientId != null)
                        query = query.Where(ps => ps.PatientId == PatientId.Value);

                    if (DoctorId != null)
                        // "DoctorId" in the original's derived table is pp.DoctorId
                        // (the patient's doctor), not a column on PatientServices.
                        query = query.Where(ps => ps.Patient.DoctorId == DoctorId.Value);

                    if (PatientServiceId != null)
                        query = query.Where(ps => ps.Id == PatientServiceId.Value);

                    // CheckupTypeId is never actually null here (defaults to 2
                    // above), so this filter is effectively always applied -
                    // preserved exactly as in the original.
                    // query = query.Where(ps => ps.CheckupTypeId == CheckupTypeId);

                    if (ServiceGroupId != null)
                        // original filtered on svc.ServiceGroupId (the Service's
                        // own group), not pps.ServiceGroupId - preserved.
                        query = query.Where(ps => ps.Service.ServiceGroupId == ServiceGroupId.Value);

                    if (ServiceId != null)
                        query = query.Where(ps => ps.ServiceId == ServiceId.Value);

                    if (ProviderDoctorId != null)
                        query = query.Where(ps => ps.ProviderDoctorId == ProviderDoctorId.Value);

                    if (Date != null)
                        query = query.Where(ps => ps.Date >= Date.Value.Date && ps.Date < Date.Value.Date.AddDays(1));

                    if (FromDate != null)
                        query = query.Where(ps => ps.Date >= FromDate.Value);

                    if (ToDate != null)
                        query = query.Where(ps => ps.Date <= ToDate.Value);

                    // NOTE on ToothId, from the original SQL:
                    //   ToothId == 0  -> no filter
                    //   ToothId == -1 -> "AND ToothGroup = 1" - but the derived
                    //                    table being filtered has NO "ToothGroup"
                    //                    column (that only exists on Teeth), so
                    //                    this branch was dead/broken - would have
                    //                    thrown a SQL error if ever hit.
                    //   ToothId == -2 -> same problem, "ToothGroup = 2".
                    //   otherwise     -> "AND @ToothId IN (ToothIds)", which in
                    //                    SQLite checks equality against the whole
                    //                    ToothIds string, not membership in the
                    //                    comma-separated list - almost never a
                    //                    real match either.
                    // The -1/-2 branches are left as no-ops below (can't safely
                    // guess intended semantics - confirm what they should do).
                    // The "normal" branch is reimplemented as an actual
                    // comma-separated membership check, done in memory after
                    // materializing (string.Split isn't reliably translatable
                    // to SQL by this LINQ provider).

                    var rows = query.Select(ps => new
                    {
                        PatientServiceId = ps.Id,
                        PatientId = ps.PatientId,
                        PatientName = ps.Patient.FirstName + " " + ps.Patient.LastName,
                        NationalCode = ps.Patient.NationalCode,
                        BirthDate = ps.Patient.BirthDate,
                        DoctorId = ps.Patient.DoctorId,
                        DoctorTitle = ps.Patient.Doctor.FirstName + " " + ps.Patient.Doctor.LastName,

                        ServiceGroupId = ps.Service.ServiceGroupId,
                        ServiceGroupTitle = ps.Service.ServiceGroup.Title,
                        CheckupTypeCode = ps.CheckupType.Code,
                        ServiceId = ps.Service.Id,
                        ServiceTitle = ps.Service.Title,
                        ps.Date,
                        ps.Comment,
                        ps.IsHadMoreTooth,
                        IsToothNumber = ps.Service.IsToothNumber,
                        ps.IsDeleted,
                        ps.ProviderDoctorId,
                        ProviderDoctorTitle = ps.ProviderDoctor.FirstName + " " + ps.ProviderDoctor.LastName,

                        ps.ActionPrice,
                        ps.ServicePrice,
                        ps.InsurerPrice,
                        ps.InsurerShare,
                        ps.FranchiseShare,
                        ps.FreeShare,
                        ps.ToothIds
                    }).ToList();

                    var resultX =
                        (from psItem in rows
                         join piItem in resultPatientInsurance on psItem.PatientId equals piItem.PatientId into piTemp
                         from piItem in piTemp.DefaultIfEmpty()

                         select new
                         {
                             PatientServiceId = psItem.PatientServiceId,
                             PatientId = (int)psItem.PatientId,
                             PatientName = psItem.PatientName,
                             NationalCode = psItem.NationalCode,
                             Age = Publics.GetAge(psItem.BirthDate),
                             DoctorId = psItem.DoctorId,
                             DoctorTitle = psItem.DoctorTitle,

                             BasicInsurerId = piItem != null ? (int)piItem.BasicInsurerId : Constant.FreeInsurerId,
                             BasicInsurerTitle = piItem != null ? (string)piItem.BasicInsurerTitle : Constant.FreeInsurerTitle,
                             BasicInsurerPercent = piItem != null ? (int)piItem.BasicInsurerPercent : 0,

                             ServiceGroupId = psItem.ServiceGroupId, //psItem.ServiceGroupId ?? -1,
                             ServiceGroupTitle = psItem.ServiceGroupTitle,
                             CheckupTypeCode = psItem.CheckupTypeCode,
                             ServiceId = psItem.ServiceId,
                             ServiceTitle = psItem.ServiceTitle,
                             Date = Publics.GetDate(psItem.Date),
                             SolarDate = Publics.GetSolarDate(psItem.Date),
                             SolarDateTime = Publics.GetSolarDateTime(psItem.Date),
                             Comment = psItem.Comment,
                             IsHadMoreTooth = psItem.IsHadMoreTooth,
                             IsToothNumber = psItem.IsToothNumber ?? false,
                             IsDeleted = psItem.IsDeleted,
                             ProviderDoctorId = psItem.ProviderDoctorId ?? 0,
                             ProviderDoctorTitle = psItem.ProviderDoctorTitle,

                             ActionPrice = psItem.ActionPrice,
                             ServicePrice = psItem.ServicePrice ?? 0,
                             InsurerPrice = psItem.InsurerPrice ?? 0,
                             InsurerShare = psItem.InsurerShare ?? 0,
                             FranchiseShare = psItem.FranchiseShare ?? 0,
                             FreeShare = psItem.FreeShare ?? 0,

                             ToothIds = psItem.ToothIds ?? "",
                         }).OrderByDescending(i => i.Date).ToList();

                    if (BasicInsurerId != null)
                        resultX = resultX.Where(i => i.BasicInsurerId == BasicInsurerId).ToList();

                    if (ToothId != null && ToothId != 0 && ToothId != -1 && ToothId != -2)
                        resultX = resultX.Where(i =>
                            (i.ToothIds ?? "").Split(',')
                                .Select(s => s.Trim())
                                .Where(s => s.Length > 0)
                                .Select(int.Parse)
                                .Contains(ToothId.Value)
                        ).ToList();

                    var finalResult =
                                        (from item in resultX
                                         let ToothIdList = item.ToothIds?.Split(',')?.Where(s => s.Trim().Length > 0)?.Select(s => Int32.Parse(s.Trim()))?.ToList() ?? new List<int>()

                                         let freePrice = item != null ? item.ServicePrice : 0
                                         let insurerPrice = item != null ? item.InsurerPrice : 0
                                         let insurerPercent = item != null ? item.BasicInsurerPercent : 0
                                         let insurerServiceTarefe = new Class.InsurerServiceTarefe(freePrice, insurerPrice, insurerPercent)

                                         select new
                                         {
                                             Id = item.PatientServiceId,
                                             item.PatientServiceId,
                                             item.PatientId,
                                             item.PatientName,
                                             item.NationalCode,
                                             item.DoctorId,
                                             item.DoctorTitle,
                                             item.BasicInsurerId,
                                             item.BasicInsurerTitle,
                                             item.ServiceGroupId,
                                             item.ServiceGroupTitle,
                                             item.ServiceId,
                                             item.ServiceTitle,
                                             item.IsHadMoreTooth,
                                             item.Date,
                                             item.SolarDate,
                                             item.SolarDateTime,
                                             item.Comment,
                                             item.CheckupTypeCode,
                                             item.ProviderDoctorId,
                                             item.ProviderDoctorTitle,

                                             item.ActionPrice,
                                             ServicePrice = insurerServiceTarefe.ServicePrice,
                                             InsurerPrice = insurerServiceTarefe.InsurerPrice,
                                             InsurerShare = insurerServiceTarefe.InsurerShare,
                                             FranchiseShare = insurerServiceTarefe.FranchiseShare,
                                             FreeShare = insurerServiceTarefe.FreeShare,

                                             item.ToothIds,
                                             ToothCount = ToothIdList.Count(),
                                             Tooths = resultTeethX.Where(th => ToothIdList.Contains(th.ToothId)).Select(th =>
                                                 new
                                                 {
                                                     ToothId = (int)th.ToothId,
                                                     ToothName = (string)th.ToothName,
                                                     ToothTitle = (string)th.ToothTitle,
                                                     ToothGroup = (int)th.ToothGroup,
                                                     ToothImage = (byte[])th.ToothImage,
                                                 }
                                                )
                                         }).ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientFinancialsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var PayTypeId = x.HasValue("PayTypeId") ? x.GetValue<int>("PayTypeId") : (int?)null;
                var PayTypeIds = x.HasValue("PayTypeIds")
                    ? x.GetValue<IEnumerable>("PayTypeIds").OfType<object>().Select(i => int.Parse(Convert.ToString(i))).ToList()
                    : null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                var FromAmount = x.HasValue("FromAmount") ? x.GetValue<double>("FromAmount") : (double?)null;
                var ToAmount = x.HasValue("ToAmount") ? x.GetValue<double>("ToAmount") : (double?)null;
                var IsDateOfIssuance = x.HasValue("IsDateOfIssuance") ? x.GetValue<bool>("IsDateOfIssuance") : (bool?)null;
                var IsDateOfMaturity = x.HasValue("IsDateOfMaturity") ? x.GetValue<bool>("IsDateOfMaturity") : (bool?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                using (var db = new DentalContext())
                {
                    // Bank/ChequeStatu عمداً Include نشدن: چون هر دو Optional (FK قابل
                    // null) و زیرکلاس TPT از BaseCoding هستن، Include زدن روی این نوع
                    // Navigation باعث میشه EF یه ساب‌کوئری تو در تو بسازه که موقع
                    // Materialize کردن تو پروایدر SQLite خطای NullReferenceException میده.
                    // PayType اجباریه (FK غیر nullable)، پس Include زدنش مشکلی نداره.
                    IQueryable<PatientFinancial> query = db.PatientFinancials
                        .Include(pf => pf.Patient)
                        .Include(pf => pf.PayType)
                        .Where(pf => pf.Patient != null && pf.PayType != null)
                        .Where(pf => pf.PatientId != 0)
                        // original compared the raw column with "<> 1" (no IFNULL
                        // here, unlike GetPatientServicesX), so a NULL IsDeleted row
                        // would NOT satisfy "<> 1" in SQL's three-valued logic and
                        // gets excluded. "== false" reproduces that: NULL never
                        // equals false either.
                        .Where(pf => pf.IsDeleted == false);

                    if (PatientId != null && PatientId != 0)
                        query = query.Where(pf => pf.PatientId == PatientId.Value);

                    if (Id != null)
                        query = query.Where(pf => pf.Id == Id.Value);

                    if (PayTypeId != null && PayTypeId != 0)
                        query = query.Where(pf => pf.PayTypeId == PayTypeId.Value);

                    if (PayTypeIds != null && PayTypeIds.Count > 0)
                        query = query.Where(pf => PayTypeIds.Contains(pf.PayTypeId));

                    if (FromAmount != null)
                        query = query.Where(pf => pf.Amount >= (decimal)FromAmount.Value);

                    if (ToAmount != null)
                        query = query.Where(pf => pf.Amount <= (decimal)ToAmount.Value);

                    var materialized = query.ToList();

                    // دفاعی: رکوردهایی که PatientId/PayTypeIدشون به ردیف ناموجود اشاره
                    // می‌کنه از فیلترهای بالا رد میشن (چون اون‌ها فقط null نبودن ستون
                    // رو چک می‌کنن، نه وجود واقعی ردیف رو).
                    materialized = materialized.Where(pf => pf.Patient != null && pf.PayType != null).ToList();

                    // Bank و ChequeStatus جدا و ساده خونده میشن (نه با Include) تا از
                    // باگ بالا دور بمونیم.
                    var banks = db.Banks.ToList();
                    var chequeStatuses = db.ChequeStatuses.ToList();

                    // همون شاخه‌بندی مستقل (نه else-if) قبلی: اگه هم IsDateOfIssuance
                    // و هم IsDateOfMaturity ست شده باشن، هر دو فیلتر بازه‌ی تاریخ با
                    // هم اعمال میشن؛ فقط وقتی هیچ‌کدوم ست نشده، فیلتر ساده‌ی Date اجرا میشه.
                    if (IsDateOfIssuance != null)
                    {
                        if (FromDate != null)
                            materialized = materialized.Where(pf => pf.DateOfIssuance >= FromDate.Value).ToList();
                        if (ToDate != null)
                            materialized = materialized.Where(pf => pf.DateOfIssuance <= ToDate.Value).ToList();
                    }

                    if (IsDateOfMaturity != null)
                    {
                        if (FromDate != null)
                            materialized = materialized.Where(pf => pf.DateOfMaturity >= FromDate.Value).ToList();
                        if (ToDate != null)
                            materialized = materialized.Where(pf => pf.DateOfMaturity <= ToDate.Value).ToList();
                    }



                    var rows = materialized.Select(pf => new
                    {
                        Id = pf.Id,
                        PatientId = pf.PatientId,
                        PatientName = pf.Patient.FirstName + " " + pf.Patient.LastName,
                        Date = pf.Date,
                        PayTypeId = pf.PayTypeId,
                        PayTypeTitle = pf.PayType.Title,
                        Amount = pf.Amount,
                        TransactionCode = pf.TransactionCode,
                        ChequeNumber = pf.ChequeNumber,
                        BankId = pf.BankId,
                        BankTitle = pf.BankId != null ? banks.FirstOrDefault(b => b.Id == pf.BankId.Value)?.Title : null,
                        DateOfIssuance = pf.DateOfIssuance,
                        DateOfMaturity = pf.DateOfMaturity,
                        ChequeStatusId = pf.ChequeStatusId,
                        ChequeStatusTitle = pf.ChequeStatusId != null ? chequeStatuses.FirstOrDefault(c => c.Id == pf.ChequeStatusId.Value)?.Title : null,
                        Comment = pf.Comment,
                        IsDeleted = pf.IsDeleted,
                    }).ToList();

                    // RowNumber reproduces "ROW_NUMBER() OVER (ORDER BY [Date])" from
                    // the original: 1-based, ascending by Date, assigned AFTER all the
                    // WHERE filters above (SQL window functions run post-filter).
                    var withRowNumber = rows
                        .OrderBy(i => i.Date)
                        .Select((i, idx) => new
                        {
                            RowNumber = idx + 1,
                            Id = i.Id,
                            PatientFinancialId = i.Id,
                            TransactionId = i.Id,
                            PatientId = i.PatientId,
                            Date = Publics.GetDate(i.Date),
                            SolarDate = Publics.GetSolarDateTime(i.Date),
                            Amount = (double)i.Amount,
                            PatientName = i.PatientName,
                            PayTypeId = i.PayTypeId,
                            PayTypeTitle = i.PayTypeTitle,
                            TransactionCode = i.TransactionCode,

                            ChequeNumber = i.ChequeNumber,
                            BankId = i.BankId,
                            BankTitle = i.BankTitle,
                            DateOfIssuance = Publics.GetDate(i.DateOfIssuance),
                            SolarDateOfIssuance = Publics.GetSolarDate(i.DateOfIssuance),
                            DateOfMaturity = Publics.GetDate(i.DateOfMaturity),
                            SolarDateOfMaturity = Publics.GetSolarDate(i.DateOfMaturity),
                            ChequeTypeId = 1, // برداشت
                            ChequeTypeTitle = "برداشت",
                            ChequeStatusId = i.ChequeStatusId,
                            ChequeStatusTitle = i.ChequeStatusTitle,

                            Comment = i.Comment,
                            IsDeleted = i.IsDeleted ?? false,
                        }).ToList();

                    var finalResult = withRowNumber.OrderByDescending(i => i.Date).ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientSpecialCommentsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                using (var db = new DentalContext())
                {
                    // original used an INNER JOIN to BaseCoding_SpecialCommentTypes -
                    // rows lacking a matching type are excluded, same as here. There
                    // is no base "IsDeleted <> 1" filter in the original (unlike most
                    // other Get*X functions) - deleted rows are returned unless the
                    // caller explicitly filters on IsDeleted, preserved as-is.
                    IQueryable<PatientSpecialComment> query = db.PatientSpecialComments
                        .Include(pspc => pspc.SpecialCommentType)
                        .Where(pspc => pspc.SpecialCommentType != null);

                    if (Id != null)
                        query = query.Where(pspc => pspc.Id == Id.Value);

                    if (PatientId != null)
                        query = query.Where(pspc => pspc.PatientId == PatientId.Value);

                    if (IsDeleted != null)
                        query = query.Where(pspc => pspc.IsDeleted == IsDeleted.Value);

                    var finalResult = query.Select(pspc => new
                    {
                        Id = pspc.Id,
                        Title = pspc.Title,
                        PatientId = pspc.PatientId,
                        Date = pspc.Date,
                        SpecialCommentTypeId = pspc.SpecialCommentTypeId,
                        SpecialCommentTypeTitle = pspc.SpecialCommentType.Title,
                        IsDeleted = pspc.IsDeleted
                    })
                    .ToList()
                    .Select(i => new
                    {
                        i.Id,
                        i.Title,
                        i.PatientId,
                        Date = Publics.GetDate(i.Date),
                        SolarDate = Publics.GetSolarDate(i.Date),
                        i.SpecialCommentTypeId,
                        i.SpecialCommentTypeTitle,
                        i.IsDeleted
                    })
                    .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientDocsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var DocId = x.HasValue("DocId") ? x.GetValue<int>("DocId") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;

                using (var db = new DentalContext())
                {
                    // original used an INNER JOIN to Patients - rows lacking a
                    // matching patient are excluded, same as here.
                    IQueryable<PatientDocument> query = db.PatientDocuments
                        .Include(pdoc => pdoc.Patient)
                        .Where(pdoc => pdoc.Patient != null);

                    if (DocId != null)
                        query = query.Where(pdoc => pdoc.Id == DocId.Value);

                    if (PatientId != null)
                        query = query.Where(pdoc => pdoc.PatientId == PatientId.Value);

                    if (FromDate != null)
                        query = query.Where(pdoc => pdoc.Date >= FromDate.Value);

                    // NOTE: original SQL used "AND Date >= @ToDate" here too (not
                    // "<="), which looks like a copy-paste bug - it doesn't actually
                    // apply an upper bound. Reproduced exactly as-is; confirm with
                    // the team whether ToDate should really cap the range with "<=".
                    if (ToDate != null)
                        query = query.Where(pdoc => pdoc.Date >= ToDate.Value);

                    var finalResult = query
                        .Select(pdoc => new
                        {
                            DocId = pdoc.Id,
                            PatientId = pdoc.PatientId,
                            PatientName = pdoc.Patient.FirstName + " " + pdoc.Patient.LastName,
                            Date = pdoc.Date,
                            Title = pdoc.Title,
                            ImagePath = pdoc.ImagePath,
                            Image = pdoc.Image,
                            IsDeleted = pdoc.IsDeleted,
                            Comment = pdoc.Comment
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.DocId,
                            i.PatientId,
                            i.PatientName,
                            Date = Publics.GetDate(i.Date),
                            SolarDate = Publics.GetSolarDate(i.Date),
                            i.Title,
                            i.ImagePath,
                            i.Image,
                            i.IsDeleted,
                            i.Comment
                        })
                        .OrderByDescending(i => i.Date)
                        .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientFollowUpsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                using (var db = new DentalContext())
                {
                    // NOTE / BUG FIX vs. the original SQL: the original's derived
                    // "temp" table did NOT select pflp.DoctorId at all, even though
                    // the outer WHERE filtered on "DoctorId = @DoctorId" and the
                    // final projection unconditionally read "i.DoctorId" - both of
                    // which reference a column that doesn't exist in that derived
                    // table. That would throw ("no such column: DoctorId" from
                    // SQLite, or a missing-member error from Dapper's dynamic row)
                    // on every single call, filtered or not - there's no working
                    // behavior to preserve here. DoctorId IS a real column directly
                    // on PatientFollowups, so it's included below as clearly
                    // intended. Please confirm this reading with the team.
                    IQueryable<PatientFollowup> query = db.PatientFollowups
                        .Include(pflp => pflp.Patient)
                        // original used an INNER JOIN to Patients - rows lacking a
                        // matching patient are excluded, same as here.
                        .Where(pflp => pflp.Patient != null);

                    if (Id != null)
                        query = query.Where(pflp => pflp.Id == Id.Value);

                    if (DoctorId != null)
                        query = query.Where(pflp => pflp.DoctorId == DoctorId.Value);

                    if (PatientId != null)
                        query = query.Where(pflp => pflp.PatientId == PatientId.Value);

                    if (FromDate != null)
                        query = query.Where(pflp => pflp.FollowupDate >= FromDate.Value);

                    if (ToDate != null)
                        query = query.Where(pflp => pflp.FollowupDate <= ToDate.Value);

                    if (IsDeleted != null)
                        query = query.Where(pflp => pflp.IsDeleted == IsDeleted.Value);

                    var finalResult = query
                        .Select(pflp => new
                        {
                            pflp.Id,
                            pflp.DoctorId,
                            pflp.PatientId,
                            PatientName = pflp.Patient.FirstName + " " + pflp.Patient.LastName,
                            MobilePhone = pflp.Patient.MobilePhone,
                            Date = pflp.Date,
                            FollowUpDate = pflp.FollowupDate,
                            pflp.Comment,
                            pflp.IsDeleted
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.Id,
                            i.DoctorId,
                            i.PatientId,
                            i.PatientName,
                            i.MobilePhone,
                            Date = Publics.GetDate(i.Date),
                            SolarDate = Publics.GetSolarDate(i.Date),
                            FollowUpDate = Publics.GetDate(i.FollowUpDate),
                            SolarFollowUpDate = Publics.GetSolarDate(i.FollowUpDate),
                            i.Comment,
                            i.IsDeleted
                        })
                        .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientTeethInfos(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientServiceToothId = x.HasValue("PatientServiceToothId") ? x.GetValue<int>("PatientServiceToothId") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var ToothId = x.HasValue("ToothId") ? x.GetValue<int>("ToothId") : (int?)null;

                using (var db = new DentalContext())
                {
                    IQueryable<PatientTooth> query = db.PatientTeeth
                        .Where(thi => thi.IsDeleted != true);

                    if (PatientServiceToothId != null)
                        query = query.Where(thi => thi.Id == PatientServiceToothId.Value);

                    if (PatientId != null)
                        query = query.Where(thi => thi.PatientId == PatientId.Value);

                    if (ToothId != null)
                        query = query.Where(thi => thi.ToothId == ToothId.Value);

                    // model fields are genuinely nullable (matches the real DB
                    // schema - Surface alone is NULL on 22 of the 25 current rows),
                    // so every "!= null ? val : 0" / Convert.ToBoolean guard from
                    // the original is restored here via ?? defaults.
                    var resultX = query
                        .Select(thi => new
                        {
                            thi.PatientId,
                            ToothId = thi.ToothId ?? 0,
                            Visible = thi.Visible ?? false,
                            Rotate = thi.Rotate ?? 0,
                            TipB = thi.TipB ?? 0,
                            TipM = thi.TipM ?? 0,
                            ShiftM = thi.ShiftM ?? 0,
                            ShiftO = thi.ShiftO ?? 0,
                            ShiftB = thi.ShiftB ?? 0,
                            IsRCT = thi.IsRCT ?? false,
                            ColorRCT = thi.ColorRCT ?? 0,
                            IsBU = thi.IsBU ?? false,
                            ColorBU = thi.ColorBU ?? 0,
                            IsImplant = thi.IsImplant ?? false,
                            ColorImplant = thi.ColorImplant ?? 0,
                            IsCrown = thi.IsCrown ?? false,
                            IsPontic = thi.IsPontic ?? false,
                            IsSealant = thi.IsSealant ?? false,
                            ColorSealant = thi.ColorSealant ?? 0,
                            Surface = thi.Surface ?? "",
                            SurfaceColor = thi.SurfaceColor ?? 0,
                            Surface_B = thi.Surface_B ?? false,
                            Surface_B_Color = thi.Surface_B_Color ?? 0,
                            Surface_F = thi.Surface_F ?? false,
                            Surface_F_Color = thi.Surface_F_Color ?? 0,
                            Surface_C = thi.Surface_C ?? false,
                            Surface_C_Color = thi.Surface_C_Color ?? 0,
                            Surface_D = thi.Surface_D ?? false,
                            Surface_D_Color = thi.Surface_D_Color ?? 0,
                            Surface_E = thi.Surface_E ?? false,
                            Surface_E_Color = thi.Surface_E_Color ?? 0,
                            Surface_L = thi.Surface_L ?? false,
                            Surface_L_Color = thi.Surface_L_Color ?? 0,
                            Surface_M = thi.Surface_M ?? false,
                            Surface_M_Color = thi.Surface_M_Color ?? 0,
                            Surface_O = thi.Surface_O ?? false,
                            Surface_O_Color = thi.Surface_O_Color ?? 0,
                            Surface_I = thi.Surface_I ?? false,
                            Surface_I_Color = thi.Surface_I_Color ?? 0,
                            Surface_V = thi.Surface_V ?? false,
                            Surface_V_Color = thi.Surface_V_Color ?? 0,
                            Description = thi.Description ?? "",
                        })
                        .ToList();

                    // NOTE: preserved as-is from the original - grouping by ToothId
                    // and mixing Sum() (Rotate/TipB/TipM/Shift*) with First() (all
                    // the other fields) only makes sense if there's normally a
                    // single PatientTeeth row per tooth; if duplicates ever exist,
                    // the Sum() fields would silently over-count while the First()
                    // fields would silently ignore the duplicate. Not changed here.
                    var finalResult = (from item in resultX
                                       group item by new { item.ToothId } into gItem
                                       select new
                                       {
                                           ToothId = gItem.Key.ToothId,
                                           Visible = gItem.Select(t => t.Visible).First(),
                                           Rotate = gItem.Sum(t => t.Rotate),
                                           TipB = gItem.Sum(t => t.TipB),
                                           TipM = gItem.Sum(t => t.TipM),
                                           ShiftM = gItem.Sum(t => t.ShiftM),
                                           ShiftO = gItem.Sum(t => t.ShiftO),
                                           ShiftB = gItem.Sum(t => t.ShiftB),

                                           IsRCT = gItem.Select(t => t.IsRCT).First(),
                                           ColorRCT = gItem.Select(t => t.ColorRCT).First(),
                                           IsBU = gItem.Select(t => t.IsBU).First(),
                                           ColorBU = gItem.Select(t => t.ColorBU).First(),
                                           IsImplant = gItem.Select(t => t.IsImplant).First(),
                                           ColorImplant = gItem.Select(t => t.ColorImplant).First(),
                                           IsCrown = gItem.Select(t => t.IsCrown).First(),
                                           IsPontic = gItem.Select(t => t.IsPontic).First(),
                                           IsSealant = gItem.Select(t => t.IsSealant).First(),
                                           ColorSealant = gItem.Select(t => t.ColorSealant).First(),
                                           SurfaceColor = gItem.Select(t => t.SurfaceColor).First(),
                                           Surface = gItem.Select(t => t.Surface).First(),

                                           Surface_B = gItem.Select(t => t.Surface_B).First(),
                                           Surface_B_Color = gItem.Select(t => t.Surface_B_Color).First(),
                                           Surface_F = gItem.Select(t => t.Surface_F).First(),
                                           Surface_F_Color = gItem.Select(t => t.Surface_F_Color).First(),
                                           Surface_C = gItem.Select(t => t.Surface_C).First(),
                                           Surface_C_Color = gItem.Select(t => t.Surface_C_Color).First(),
                                           Surface_D = gItem.Select(t => t.Surface_D).First(),
                                           Surface_D_Color = gItem.Select(t => t.Surface_D_Color).First(),
                                           Surface_E = gItem.Select(t => t.Surface_E).First(),
                                           Surface_E_Color = gItem.Select(t => t.Surface_E_Color).First(),
                                           Surface_L = gItem.Select(t => t.Surface_L).First(),
                                           Surface_L_Color = gItem.Select(t => t.Surface_L_Color).First(),
                                           Surface_M = gItem.Select(t => t.Surface_M).First(),
                                           Surface_M_Color = gItem.Select(t => t.Surface_M_Color).First(),
                                           Surface_O = gItem.Select(t => t.Surface_O).First(),
                                           Surface_O_Color = gItem.Select(t => t.Surface_O_Color).First(),
                                           Surface_I = gItem.Select(t => t.Surface_I).First(),
                                           Surface_I_Color = gItem.Select(t => t.Surface_I_Color).First(),
                                           Surface_V = gItem.Select(t => t.Surface_V).First(),
                                           Surface_V_Color = gItem.Select(t => t.Surface_V_Color).First(),

                                           Description = gItem.Select(t => t.Description).First(),
                                       }).ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetAccountPartyCompanyFinancialTransactionX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var BargainSideId = x.HasValue("BargainSideId") ? x.GetValue<int>("BargainSideId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;

                using (var db = new DentalContext())
                {
                    // First result set: the bargain-side (account party company)
                    // itself. Original had no null-guard on BargainSideId before
                    // filtering - a null id simply matches nothing (SingleOrDefault
                    // -> null), reproduced the same way here.
                    var infoResult = BargainSideId == null
                        ? null
                        : db.BargainSides
                            .Where(bs => bs.Id == BargainSideId.Value)
                            .Select(bs => new
                            {
                                BargainSideId = bs.Id,
                                BargainSideTitle = bs.Title,
                                IsDeleted = bs.IsDeleted
                            })
                            .SingleOrDefault();

                    // Second result set: cost transactions for that bargain side.
                    // Original hardcoded "CostTypeId = 1" (unconditional, not a
                    // search parameter) and always filtered on BargainSideId (no
                    // null-guard) - both preserved as-is.
                    IQueryable<Cost> query = db.Costs
                        .Include(cc => cc.CostType)
                        .Include(cc => cc.BargainSide)
                        .Include(cc => cc.PayType)
                        // original used an INNER JOIN to BaseCoding_CostTypes - rows
                        // lacking a matching cost type are excluded, same as here.
                        .Where(cc => cc.CostType != null)
                        .Where(cc => cc.CostTypeId == 1)
                        .Where(cc => cc.BargainSideId == BargainSideId);

                    if (FromDate != null)
                        query = query.Where(cc => cc.Date >= FromDate.Value);

                    if (ToDate != null)
                        query = query.Where(cc => cc.Date <= ToDate.Value);

                    var dataResult = query
                        .OrderBy(cc => cc.Date)
                        .Select(cc => new
                        {
                            CostTypeId = cc.CostTypeId,
                            PayTypeId = cc.PayTypeId,
                            PayTypeTitle = cc.PayType != null ? cc.PayType.Title : null,
                            Date = cc.Date,
                            // CASE WHEN cc.BargainSideId <> 0 THEN ac.Title ELSE ct.Title END,
                            // reproduced exactly (falls back to CostType.Title when
                            // BargainSideId is null or 0).
                            CostTitle = (cc.BargainSideId != null && cc.BargainSideId != 0)
                                ? (cc.BargainSide != null ? cc.BargainSide.Title : null)
                                : cc.CostType.Title,
                            Amount = cc.Amount,
                            comment = cc.Comment
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.CostTypeId,
                            i.PayTypeId,
                            i.PayTypeTitle,
                            CostDate = Publics.GetDate(i.Date),
                            CostSolarDate = Publics.GetSolarDate(i.Date),
                            i.CostTitle,
                            i.Amount,
                            i.comment
                        })
                        .ToList();

                    var finalResult = new
                    {
                        Info = infoResult,
                        Data = dataResult,
                    };

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetOfficeReportX(dynamic searchObj)
        {
            try
            {
                JsonResponse<dynamic> result = null;
                IEnumerable<dynamic> data = null;

                //
                // Patient Services
                //
                result = GetPatientServicesX(searchObj);
                if (result == null || result.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات ");

                data = result.Data as IEnumerable<dynamic>;

                var patientServicesResult =
                            data
                            .Select(i =>
                            {
                                return new
                                {
                                    PatientId = (int)i.PatientId,
                                    PatientName = (string)i.PatientName,
                                    DoctorId = (int)i.DoctorId,
                                    DoctorTitle = (string)i.DoctorTitle,
                                    ServiceGroupId = (int)i.ServiceGroupId,
                                    ServiceGroupTitle = (string)i.ServiceGroupTitle,
                                    ServiceTitle = (string)i.ServiceTitle,
                                    ServicePrice = (double)i.ServicePrice,
                                    InsurerPrice = (double)i.InsurerPrice,
                                    InsurerShare = (double)i.InsurerShare,
                                    FranchiseShare = (double)i.FranchiseShare,
                                    FreeShare = (double)i.FreeShare,
                                };
                            }).ToList();

                var patientServicesGroupByServiceGroupResult =
                                    (from item in patientServicesResult
                                     group item by new { item.ServiceGroupId } into gItem
                                     select new
                                     {
                                         ServiceGroupId = gItem.Key,
                                         TitleX = gItem.First().ServiceGroupTitle,
                                         NumberX = gItem.Count(),
                                         TotalX = gItem.Sum(i => i.ServicePrice),
                                         PercentX = (gItem.Sum(i => i.ServicePrice) / patientServicesResult.Sum(i => i.ServicePrice)) * 100,
                                     }).OrderByDescending(i => i.TitleX).ToList();

                //
                // PatientFinancials
                //
                result = GetPatientFinancialsX(searchObj);
                // NOTE: preserved as-is from the original - this uses "&&" where the
                // first block above (correctly) uses "||". Since C#'s "&&" evaluates
                // its right operand whenever the left one is true, "result == null &&
                // result.Success != true" would throw a NullReferenceException on
                // result.Success the moment result is actually null, instead of
                // raising the intended Persian error message. In practice this
                // branch is only reached with a non-null result, so it hasn't
                // surfaced - but it's not doing what it looks like it's doing.
                if (result == null && result.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات ");

                data = result.Data as IEnumerable<dynamic>;

                var patientPaymentsResult =
                            data
                            .Select(i =>
                            {
                                return new
                                {
                                    PatientFinancialId = (int)i.PatientFinancialId,
                                    Amount = (decimal)i.Amount,
                                    PatientName = (string)i.PatientName,
                                    PayTypeId = (int?)i.PayTypeId,
                                    PayTypeTitle = (string)i.PayTypeTitle,
                                    Comment = (string)i.Comment
                                };
                            }).ToList();

                var patientPaymentsGroupByPayTypeResult =
                                    (from item in patientPaymentsResult
                                     group item by new { item.PayTypeId } into gItem
                                     select new
                                     {
                                         PayTypeId = gItem.Key,
                                         TitleX = gItem.First().PayTypeTitle,
                                         NumberX = gItem.Count(),
                                         TotalX = gItem.Sum(i => i.Amount),
                                         PercentX = (gItem.Sum(i => i.Amount) / patientPaymentsResult.Sum(i => i.Amount)) * 100,
                                     }).OrderByDescending(i => i.TitleX).ToList();

                //
                // Insurer Financial
                //
                result = GetInsuranceFinancialsX(searchObj);
                if (result == null && result.Success != true && result.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");

                data = result.Data as IEnumerable<dynamic>;

                var insurerFinancialResult =
                            data
                            .Select(i =>
                            {
                                return new
                                {
                                    InsuranceId = (int)i.InsuranceId,
                                    InsurerId = (int)i.InsurerId,
                                    InsurerTitle = (string)i.InsurerTitle,
                                    RequestedValue = (double)i.RequestedValue,
                                    ReceivedValue = (double)i.ReceivedValue,
                                    DeductionValue = (double)i.DeductionValue,
                                    RemainPrice = (double)i.RemainPrice,
                                    Comment = (string)i.Comment,
                                };
                            }).Where(i => i.InsurerId != 0).ToList();

                var insurerFinancialGroupByInsurerResult =
                                    (from item in insurerFinancialResult
                                     group item by new { item.InsurerId } into gItem
                                     select new
                                     {
                                         PayTypeId = gItem.Key,
                                         TitleX = gItem.First().InsurerTitle,
                                         NumberX = gItem.Count(),
                                         TotalX = gItem.Sum(i => i.ReceivedValue),
                                         PercentX = (gItem.Sum(i => i.ReceivedValue) / insurerFinancialResult.Sum(i => i.ReceivedValue)) * 100,
                                     }).OrderByDescending(i => i.TitleX).ToList();

                //
                //Cost Financial
                //
                result = GetCostFinancialsX(searchObj);
                if (result == null && result.Success != true && result.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");

                data = result.Data as IEnumerable<dynamic>;

                var costFinancialResult =
                            data
                            .Select(i =>
                            {
                                return new
                                {
                                    CostTitle = (string)i.CostTitle,
                                    CostTypeId = (int?)i.CostTypeId,
                                    CostTypeTitle = (string)i.CostTypeTitle,
                                    Amount = (double)i.Amount,
                                    BargainSideId = (int?)i.BargainSideId,
                                    BargainSideTitle = (string)i.BargainSideTitle,
                                    PayTypeId = (int?)i.PayTypeId,
                                    PayTypeTitle = (string)i.PayTypeTitle,
                                };
                            }).Where(i => i.PayTypeId != 4).ToList();

                var costFinancialGroupByInsurerResult =
                                    (from item in costFinancialResult
                                     group item by new { item.CostTypeId } into gItem
                                     let totalAmount = costFinancialResult.Sum(i => i.Amount)
                                     select new
                                     {
                                         PayTypeId = gItem.Key,
                                         TitleX = gItem.First().CostTitle,
                                         NumberX = gItem.Count(),
                                         TotalX = gItem.Sum(i => i.Amount),
                                         PercentX = (gItem.Sum(i => i.Amount) / totalAmount) * 100,
                                     }).OrderByDescending(i => i.TitleX).ToList();

                var finalResult = new
                {
                    Action = patientServicesGroupByServiceGroupResult,
                    Financial = patientPaymentsGroupByPayTypeResult,
                    Insurance = insurerFinancialGroupByInsurerResult,
                    Cost = costFinancialGroupByInsurerResult,
                };

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetCostFinancialInfoX(dynamic searchObj)
        {
            try
            {
                // NOTE: "&&" here has the same short-circuit issue flagged in
                // GetOfficeReportX (would NRE on resultData.Success if resultData
                // were ever actually null) - preserved as in the original.
                JsonResponse<dynamic> resultData = GetCostFinancialsX(searchObj);
                if (resultData == null && resultData.Success != true && resultData.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");

                var data = resultData.Data as IEnumerable<dynamic>;

                var detailResult =
                            data
                            .Select(i =>
                            {
                                return new
                                {
                                    CostId = (int)i.CostId,
                                    CostTitle = (string)i.CostTitle,
                                    CostTypeId = (int?)i.CostTypeId,
                                    CostTypeTitle = (string)i.CostTypeTitle,
                                    Amount = (double)i.Amount,

                                    PayTypeId = (int?)i.PayTypeId,
                                    PayTypeTitle = (string)i.PayTypeTitle,

                                    SolarDate = (string)i.SolarDate,
                                    Comment = (string)i.Comment,
                                };
                            }).ToList();

                var totalResult =
                                    (from item in detailResult
                                     group item by new { item.CostTypeId } into gItem
                                     let totalAmount = detailResult.Sum(i => i.Amount)
                                     select new
                                     {
                                         CostTypeId = gItem.Key,
                                         TitleX = gItem.First().CostTitle,
                                         NumberX = gItem.Count(),
                                         TotalX = gItem.Sum(i => i.Amount),
                                         PercentX = totalAmount == 0 ? 0 : (gItem.Sum(i => i.Amount) / totalAmount) * 100,
                                     }).OrderByDescending(i => i.TitleX).ToList();

                var finalResult = new
                {
                    DataTotal = totalResult,
                    DataDetail = detailResult,
                };

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetInsuranceFinancialInfoX(dynamic searchObj)
        {
            try
            {
                // NOTE: "&&" short-circuit issue as the other GetXFinancialInfoX
                // functions, preserved as in the original.
                JsonResponse<dynamic> resultData = GetInsuranceFinancialsX(searchObj);
                if (resultData == null && resultData.Success != true && resultData.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");

                var data = resultData.Data as IEnumerable<dynamic>;

                var detailResult =
                            data.Select(i =>
                            {
                                return new
                                {
                                    InsuranceId = (int)i.InsuranceId,
                                    InsurerId = (int)i.InsurerId,
                                    InsurerTitle = (string)i.InsurerTitle,
                                    SolarDate = (string)i.SolarDate,
                                    FromSolarDate = (string)i.FromSolarDate,
                                    ToSolarDate = (string)i.ToSolarDate,
                                    RequestedValue = (double)i.RequestedValue,
                                    ReceivedValue = (double)i.ReceivedValue,
                                    DeductionValue = (double)i.DeductionValue,
                                    RemainPrice = (double)i.RemainPrice,
                                    Comment = (string)i.Comment,
                                };
                            }).Where(i => i.InsurerId != 0).ToList();

                var totalResult =
                                    (from item in detailResult
                                     group item by new { item.InsurerId } into gItem
                                     let totalReceived = detailResult.Sum(i => i.ReceivedValue)
                                     select new
                                     {
                                         PayTypeId = gItem.Key,
                                         TitleX = gItem.First().InsurerTitle,
                                         NumberX = gItem.Count(),
                                         TotalX = gItem.Sum(i => i.ReceivedValue),
                                         PercentX = totalReceived == 0 ? 0 : (gItem.Sum(i => i.ReceivedValue) / totalReceived) * 100,
                                     }).OrderByDescending(i => i.TitleX).ToList();

                var finalResult = new
                {
                    DataTotal = totalResult,
                    DataDetail = detailResult,
                };

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetInsuranceFinancialsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var InsuranceId = x.HasValue("InsuranceId") ? x.GetValue<int>("InsuranceId") : (int?)null;
                var InsurerId = x.HasValue("InsurerId") ? x.GetValue<int>("InsurerId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;

                using (var db = new DentalContext())
                {
                    // original used an INNER JOIN to Insurers - rows lacking a
                    // matching insurer are excluded, same as here.
                    IQueryable<InsurerFinancial> query = db.InsurerFinancials
                        .Include(insf => insf.Insurer)
                        .Where(insf => insf.Insurer != null);

                    // NOTE: "Id" here filters on the InsurerFinancial's own Id
                    // (aliased "InsurerFinancialId" in the original SQL) - preserved.
                    if (Id != null)
                        query = query.Where(insf => insf.Id == Id.Value);

                    if (InsuranceId != null)
                        query = query.Where(insf => insf.Insurer.InsuranceId == InsuranceId.Value);

                    if (InsurerId != null)
                        query = query.Where(insf => insf.InsurerId == InsurerId.Value);

                    if (FromDate != null)
                        query = query.Where(insf => insf.FromDate >= FromDate.Value);

                    if (ToDate != null)
                        query = query.Where(insf => insf.ToDate <= ToDate.Value);

                    var finalResult = query
                        .Select(insf => new
                        {
                            Id = insf.Id,
                            InsuranceId = insf.Insurer.InsuranceId,
                            InsurerId = insf.InsurerId,
                            InsurerTitle = insf.Insurer.Title,
                            RegisterDate = insf.Date,
                            FromDate = insf.FromDate,
                            ToDate = insf.ToDate,
                            RequestedValue = insf.RequestedValue,
                            ReceivedValue = insf.ReceivedValue ?? 0,
                            DeductionValue = insf.DeductionValue ?? 0,
                            RemainPrice = insf.RemainPrice ?? 0,
                            Comment = insf.Comment,
                            IsDeleted = insf.IsDeleted ?? false
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.Id,
                            InsurerFinancialId = i.Id,
                            i.InsuranceId,
                            i.InsurerId,
                            i.InsurerTitle,
                            Date = Publics.GetDate(i.RegisterDate),
                            SolarDate = Publics.GetSolarDate(i.RegisterDate),
                            FromDate = Publics.GetDate(i.FromDate),
                            FromSolarDate = Publics.GetSolarDate(i.FromDate),
                            ToDate = Publics.GetDate(i.ToDate),
                            ToSolarDate = Publics.GetSolarDate(i.ToDate),
                            RequestedValue = (double)i.RequestedValue,
                            ReceivedValue = (double)i.ReceivedValue,
                            DeductionValue = (double)i.DeductionValue,
                            RemainPrice = (double)i.RemainPrice,
                            i.Comment,
                            i.IsDeleted
                        })
                        .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetCostFinancialsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var CostId = x.HasValue("CostId") ? x.GetValue<int>("CostId") : (int?)null;
                var CostTypeId = x.HasValue("CostTypeId") ? x.GetValue<int>("CostTypeId") : (int?)null;
                var BargainSideId = x.HasValue("BargainSideId") ? x.GetValue<int>("BargainSideId") : (int?)null;
                var PayTypeId = x.HasValue("PayTypeId") ? x.GetValue<int>("PayTypeId") : (int?)null;
                var PayTypeIds = x.HasValue("PayTypeIds")
                    ? x.GetValue<IEnumerable>("PayTypeIds").OfType<object>().Select(i => int.Parse(Convert.ToString(i))).ToList()
                    : null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;

                using (var db = new DentalContext())
                {
                    // original used an INNER JOIN to BaseCoding_CostTypes - rows
                    // lacking a matching cost type are excluded, same as here. The
                    // Bank/PayType/BargainSide/ChequeStatus joins were all LEFT
                    // JOINs (optional) in the original - reproduced with Include()
                    // and no existence filter on those.
                    IQueryable<Cost> query = db.Costs
                        .Include(cc => cc.CostType)
                        .Include(cc => cc.BargainSide)
                        .Include(cc => cc.PayType)
                        .Include(cc => cc.Bank)
                        .Include(cc => cc.ChequeStatus)
                        .Where(cc => cc.CostType != null)
                        .Where(cc => cc.IsDeleted != true);

                    // "Id" and "CostId" both filter the same underlying column in
                    // the original (both map to the "CostId" alias) - preserved.
                    if (Id != null)
                        query = query.Where(cc => cc.Id == Id.Value);

                    if (CostId != null)
                        query = query.Where(cc => cc.Id == CostId.Value);

                    if (CostTypeId != null)
                        query = query.Where(cc => cc.CostTypeId == CostTypeId.Value);

                    if (BargainSideId != null)
                        query = query.Where(cc => cc.BargainSideId == BargainSideId.Value);

                    if (FromDate != null)
                        query = query.Where(cc => cc.Date >= FromDate.Value);

                    if (ToDate != null)
                        query = query.Where(cc => cc.Date <= ToDate.Value);

                    if (PayTypeId != null && PayTypeId != 0)
                        query = query.Where(cc => cc.PayTypeId == PayTypeId.Value);

                    if (PayTypeIds != null && PayTypeIds.Count > 0)
                        query = query.Where(cc => PayTypeIds.Contains(cc.PayTypeId));

                    var finalResult = query
                        .Select(cc => new
                        {
                            CostId = cc.Id,
                            // CASE WHEN cc.BargainSideId <> 0 THEN ac.Title ELSE ct.Title END,
                            // reproduced exactly (falls back to CostType.Title when
                            // BargainSideId is null or 0).
                            CostTitle = (cc.BargainSideId != null && cc.BargainSideId != 0)
                                ? (cc.BargainSide != null ? cc.BargainSide.Title : null)
                                : cc.CostType.Title,
                            CostTypeId = cc.CostTypeId,
                            CostTypeTitle = cc.CostType.Title,
                            Amount = cc.Amount,
                            BargainSideId = cc.BargainSideId,
                            BargainSideTitle = cc.BargainSide != null ? cc.BargainSide.Title : null,
                            PayTypeId = cc.PayTypeId,
                            PayTypeTitle = cc.PayType != null ? cc.PayType.Title : null,
                            FactorNumber = cc.FactorNumber,
                            Date = cc.Date,
                            ChequeNumber = cc.ChequeNumber,
                            BankId = cc.BankId,
                            BankTitle = cc.Bank != null ? cc.Bank.Title : null,
                            DateOfIssuance = cc.DateOfIssuance,
                            DateOfMaturity = cc.DateOfMaturity,
                            ChequeStatusId = cc.ChequeStatusId,
                            ChequeStatusTitle = cc.ChequeStatus != null ? cc.ChequeStatus.Title : null,
                            Comment = cc.Comment,
                            IsDeleted = cc.IsDeleted ?? false
                        })
                        .ToList()
                        .Select(i => new
                        {
                            Id = i.CostId,
                            i.CostId,
                            i.CostTitle,
                            CostTypeId = (int?)i.CostTypeId,
                            i.CostTypeTitle,
                            Amount = (double)i.Amount,
                            i.BargainSideId,
                            i.BargainSideTitle,
                            i.PayTypeId,
                            i.PayTypeTitle,
                            i.FactorNumber,
                            Date = Publics.GetDate(i.Date),
                            SolarDate = Publics.GetSolarDate(i.Date),
                            i.ChequeNumber,
                            i.BankId,
                            i.BankTitle,
                            DateOfIssuance = Publics.GetDate(i.DateOfIssuance),
                            SolarDateOfIssuance = Publics.GetSolarDate(i.DateOfIssuance),
                            DateOfMaturity = Publics.GetDate(i.DateOfMaturity),
                            SolarDateOfMaturity = Publics.GetSolarDate(i.DateOfMaturity),
                            ChequeTypeId = 2, // واریز
                            ChequeTypeTitle = "واریز",
                            i.ChequeStatusId,
                            i.ChequeStatusTitle,
                            i.Comment,
                            i.IsDeleted
                        })
                        .OrderByDescending(i => i.Date)
                        .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPaymentFinancialInfoX(dynamic searchObj)
        {
            try
            {
                JsonResponse<dynamic> resultData = GetPatientFinancialsX(searchObj);
                if (resultData == null && resultData.Success != true && resultData.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");

                var data = resultData.Data as IEnumerable<dynamic>;

                var detailResult =
                            data
                            .Select(i =>
                            {
                                return new
                                {
                                    PatientFinancialId = (int)i.PatientFinancialId,
                                    Date = (DateTime?)i.Date,
                                    SolarDate = (string)i.SolarDate,
                                    Amount = (decimal)i.Amount,
                                    PatientName = (string)i.PatientName,
                                    PayTypeId = (int?)i.PayTypeId,
                                    PayTypeTitle = (string)i.PayTypeTitle,
                                    Comment = (string)i.Comment
                                };
                            }).ToList();

                // NOTE: unlike most of the other GetXFinancialInfoX functions, the
                // original had no .OrderByDescending(i => i.TitleX) here - preserved
                // as-is (unordered).
                var totalResult =
                                   (from item in detailResult
                                    group item by new { item.PayTypeId } into gItem
                                    let totalAmount = detailResult.Sum(i => i.Amount)
                                    select new
                                    {
                                        PayTypeId = gItem.Key,
                                        TitleX = gItem.First().PayTypeTitle,
                                        NumberX = gItem.Count(),
                                        TotalX = gItem.Sum(i => i.Amount),
                                        PercentX = totalAmount == 0 ? 0 : (gItem.Sum(i => i.Amount) / totalAmount) * 100,
                                    }).ToList();

                var finalResult = new
                {
                    DataTotal = totalResult,
                    DataDetail = detailResult,
                };

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetServicesX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var ServiceId = x.HasValue("ServiceId") ? x.GetValue<int>("ServiceId") : (int?)null;
                var InsurerId = x.HasValue("InsurerId") ? x.GetValue<int>("InsurerId") : (int?)null;
                var ServiceGroupId = x.HasValue("ServiceGroupId") ? x.GetValue<int>("ServiceGroupId") : (int?)null;
                var ServiceCode = x.HasValue("ServiceCode") ? x.GetValue<string>("ServiceCode") : null;
                var ServiceTitle = x.HasValue("ServiceTitle") ? x.GetValue<string>("ServiceTitle") : null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;
                var IsMoreTooth = x.HasValue("IsMoreTooth") ? x.GetValue<bool>("IsMoreTooth") : (bool?)null;

                using (var db = new DentalContext())
                {
                    // original hardcoded "WHERE ServiceId <> 0" (unconditional, not a
                    // search parameter) - preserved. Original used an INNER JOIN to
                    // BaseCoding_ServiceGroups - rows lacking a matching group are
                    // excluded, same as here.
                    IQueryable<Service> serviceQuery = db.Services
                        .Include(svc => svc.ServiceGroup)
                        .Where(svc => svc.ServiceGroup != null)
                        .Where(svc => svc.Id != 0);

                    if (ServiceId != null)
                        serviceQuery = serviceQuery.Where(svc => svc.Id == ServiceId.Value);

                    if (ServiceGroupId != null && ServiceGroupId > 0)
                        serviceQuery = serviceQuery.Where(svc => svc.ServiceGroupId == ServiceGroupId.Value);

                    if (ServiceCode != null)
                        serviceQuery = serviceQuery.Where(svc => svc.Code == ServiceCode);

                    if (ServiceTitle != null)
                        serviceQuery = serviceQuery.Where(svc => DbFunctions.Like(svc.Title, "%" + ServiceTitle + "%"));

                    if (IsDeleted != null && IsDeleted != false)
                        serviceQuery = serviceQuery.Where(svc => svc.IsDeleted != true);

                    if (IsMoreTooth != null)
                        serviceQuery = serviceQuery.Where(svc => svc.IsMoreTooth == IsMoreTooth.Value);

                    var serviceResult = serviceQuery
                        .OrderBy(svc => svc.ServiceGroupId).ThenBy(svc => svc.Title)
                        .Select(svc => new
                        {
                            ServiceId = svc.Id,
                            svc.ServiceGroupId,
                            ServiceGroupTitle = svc.ServiceGroup.Title,
                            ServiceCode = svc.Code,
                            ServiceTitle = svc.Title,
                            IsDeleted = svc.IsDeleted ?? false,
                            IsToothNumber = svc.IsToothNumber ?? false,
                            IsMoreTooth = svc.IsMoreTooth ?? false,
                            ServiceColor = svc.Color,
                            svc.Comment
                        })
                        .ToList();

                    // Original: a self-join against a "MAX(DefineDate) per
                    // ServiceId/InsurerId" subquery - fetch the candidate rows and do
                    // the same grouping/self-join in-memory, since ties on
                    // DefineDate would return multiple rows from the SQL join too
                    // (not collapsed to one).
                    IQueryable<InsurerServiceTarefeChange> tarefeQuery = db.InsurerServiceTarefeChanges;

                    if (ServiceId != null)
                        tarefeQuery = tarefeQuery.Where(i => i.ServiceId == ServiceId.Value);

                    if (InsurerId != null)
                        tarefeQuery = tarefeQuery.Where(i => i.InsurerId == InsurerId.Value);

                    var tarefeRaw = tarefeQuery
                        .Select(i => new
                        {
                            i.Id,
                            i.ServiceId,
                            i.InsurerId,
                            i.FreePrice,
                            i.InsurerPrice,
                            i.DefineDate,
                            i.RunDate
                        })
                        .ToList();

                    var maxDefineDates = tarefeRaw
                        .GroupBy(i => new { i.ServiceId, i.InsurerId })
                        .Select(g => new { g.Key.ServiceId, g.Key.InsurerId, DefineDate = g.Max(i => i.DefineDate) })
                        .ToList();

                    var tarefeResult = (
                        from i in tarefeRaw
                        join g in maxDefineDates
                            on new { i.ServiceId, i.InsurerId, i.DefineDate } equals new { g.ServiceId, g.InsurerId, g.DefineDate }
                        select new
                        {
                            i.Id,
                            i.ServiceId,
                            i.InsurerId,
                            FreePrice = (double)(i.FreePrice ?? 0),
                            InsurerPrice = (double)(i.InsurerPrice ?? 0),
                            DefineDate = Publics.GetDate(i.DefineDate),
                            SolarDefineDate = Publics.GetSolarDate(i.DefineDate),
                            RunDate = Publics.GetDate(i.RunDate),
                            SolarRunDate = Publics.GetSolarDate(i.RunDate),
                        }).ToList();

                    var finalResult = (
                                from sItem in serviceResult
                                let itItem = tarefeResult.Where(i => i.InsurerId == Constant.FreeInsurerId && i.ServiceId == sItem.ServiceId)
                                                         .OrderByDescending(i => i.Id)
                                                         .FirstOrDefault()

                                select new
                                {
                                    sItem.ServiceId,
                                    sItem.ServiceGroupId,
                                    sItem.ServiceGroupTitle,
                                    sItem.ServiceCode,
                                    sItem.ServiceTitle,
                                    sItem.IsDeleted,
                                    sItem.IsToothNumber,
                                    sItem.IsMoreTooth,
                                    sItem.ServiceColor,
                                    sItem.Comment,

                                    ServiceFreePrice = itItem != null ? itItem.FreePrice : 0,
                                    PriceDefineDate = itItem != null ? itItem.SolarDefineDate : "",
                                }).ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetServiceFinancialInfoX(dynamic searchObj)
        {
            try
            {
                JsonResponse<dynamic> resultData = GetPatientServicesX(searchObj);

                if (resultData == null && resultData.Success != true && resultData.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");

                var data = resultData.Data as IEnumerable<dynamic>;

                var resultX =
                            data.Where(i => i.PatientServiceId != null
                                                && Convert.ToInt32(i.CheckupTypeId) == 2

                                        )
                            .Select(i =>
                            {

                                return new Class.PatientService(i)
                                {
                                    PatientId = (int)i.PatientId,
                                    PatientName = (string)i.PatientName,
                                    DoctorId = (int)i.DoctorId,
                                    DoctorTitle = (string)i.DoctorTitle,
                                    ServiceGroupId = (int)i.ServiceGroupId,
                                    ServiceGroupTitle = (string)i.ServiceGroupTitle,
                                    ServiceId = (int)i.ServiceId,
                                    ServiceTitle = (string)i.ServiceTitle,
                                    SolarDate = (string)i.SolarDate,
                                    Comment = (string)i.Comment,

                                    ActionPrice = (double)i.ActionPrice,
                                    ServicePrice = (double)i.ServicePrice,
                                    InsurerPrice = (double)i.InsurerPrice,
                                    InsurerShare = (double)i.InsurerShare,
                                    FranchiseShare = (double)i.FranchiseShare,
                                    FreeShare = (double)i.FreeShare,
                                };
                            }).ToList();

                var totalResult = (from item in resultX
                                   group item by new { item.ServiceGroupId } into gItem
                                   let FullSum = resultX.Sum(b => b.ActionPrice)
                                   select new
                                   {
                                       ServiceGroupId = gItem.Key.ServiceGroupId,
                                       TitleX = gItem.First().ServiceGroupTitle,
                                       NumberX = gItem.Count(),
                                       TotalX = gItem.Sum(a => a.ActionPrice),
                                       PercentX = (gItem.Sum(a => a.ActionPrice) / FullSum) * 100,

                                   }).ToList();

                // BUG FIX vs. the original: it read "i.Tooth" here, a property that
                // does not exist anywhere on GetPatientServicesX's result (which
                // exposes "ToothIds" and a "Tooths" detail list, never a "Tooth"
                // singular). Since "data"/"resultX" are accessed dynamically, that
                // would throw a RuntimeBinderException on every call - there's no
                // working behavior to preserve. Used "ToothIds" (the raw
                // comma-separated tooth numbers) as the closest match to
                // "ToothNumbers" below; if the intent was actually a friendly
                // name list (e.g. joining Tooths[].ToothTitle), please confirm.
                var detailResult = resultX.Select(i =>
                    new
                    {
                        PatientName = (string)i.PatientName,
                        ServiceGroupTitle = (string)i.ServiceGroupTitle,
                        ServiceTitle = (string)i.ServiceTitle,
                        SolarDate = (string)i.SolarDate,
                        ToothNumbers = (string)i.ToothIds,
                        ActionPrice = (decimal)i.ActionPrice,
                    }).ToList();

                var finalResult = new
                {
                    DataTotal = totalResult,
                    DataDetail = detailResult,
                };

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetClinicStatisticsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;

                JsonResponse<dynamic> result = null;
                IEnumerable<dynamic> data = null;

                var sObj = new
                {
                    FromDate = FromDate,
                    ToDate = ToDate,
                    IsDeleted = false
                };
                result = GetPatientServicesX(sObj);
                if (result == null || result.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات تراکنشات مالی بیمار ");
                data = result.Data as IEnumerable<dynamic>;

                var patientServicesResult =
                           data
                           .Select(i =>
                           {
                               return new
                               {
                                   PatientServiceId = (int)i.PatientServiceId,
                                   ServiceGroupTitle = (string)i.ServiceGroupTitle
                               };
                           }).ToList();

                var patientServicesGroupByResult =
                                     (from item in patientServicesResult
                                      group item by new { item.ServiceGroupTitle } into gItem
                                      let xItem = gItem.FirstOrDefault()
                                      select new
                                      {
                                          Title = gItem.Key.ServiceGroupTitle,
                                          Value = gItem.Count()
                                      }).ToList();

                //
                // Patient Financials
                //
                sObj = new
                {
                    FromDate = FromDate,
                    ToDate = ToDate,
                    IsDeleted = false
                };
                result = GetPatientFinancialsX(sObj);
                if (result == null || result.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات تراکنشات مالی بیمار ");
                data = result.Data as IEnumerable<dynamic>;

                var patientFinancialsResult =
                           data
                           .Select(i =>
                           {
                               return new
                               {
                                   Amount = (double)i.Amount,
                                   PayTypeId = (int)i.PayTypeId,
                                   PayTypeTitle = (string)i.PayTypeTitle
                               };
                           }).ToList();

                var patientFinancialsGroupByResult =
                                     (from item in patientFinancialsResult
                                      group item by new { item.PayTypeTitle } into gItem
                                      let xItem = gItem.FirstOrDefault()
                                      select new
                                      {
                                          Title = gItem.Key.PayTypeTitle,
                                          Value = gItem.Sum(t => (int)t.Amount),
                                      }).ToList();

                //
                // Costs Financial
                //
                sObj = new
                {
                    FromDate = FromDate,
                    ToDate = ToDate,
                    IsDeleted = false
                };
                result = GetCostFinancialsX(sObj);
                if (result == null || result.Success != true)
                    throw new Exception("خطا در واکشی اطلاعات تراکنشات مالی بیمار ");
                data = result.Data as IEnumerable<dynamic>;

                var costFinancialsResult =
                           data
                           .Select(i =>
                           {
                               return new
                               {
                                   Amount = (double)i.Amount,
                                   CostTypeId = (int)i.PayTypeId,
                                   CostTypeTitle = (string)i.PayTypeTitle
                               };
                           }).ToList();

                var costFinancialsGroupByResult =
                                     (from item in costFinancialsResult
                                      group item by new { item.CostTypeTitle } into gItem
                                      let xItem = gItem.FirstOrDefault()
                                      select new
                                      {
                                          Title = gItem.Key.CostTypeTitle,
                                          Value = gItem.Sum(t => (int)t.Amount),
                                      }).ToList();

                // --------------------------------------------------------------------------------------------------

                // Insurers Financial

                result = GetPatientServicesX(searchObj);
                if (result == null && result.Success != true && result.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");
                data = result.Data as IEnumerable<dynamic>;

                var insurersFinancialResultX =
                                  (from psItem in data
                                   select new
                                   {
                                       Id = psItem.BasicInsurerId,
                                       Title = psItem.BasicInsurerTitle,
                                       InsurerShare = (int)psItem.InsurerShare,
                                       FreeValue = (int)psItem.ServicePrice - (int)psItem.InsurerShare,
                                   }).ToList();

                var insurersFinancialGroupByTempResult =
                                  (from item in insurersFinancialResultX
                                   group item by new { item.Id } into gItem
                                   let xItem = gItem.FirstOrDefault()
                                   select new
                                   {
                                       Id = xItem.Id,
                                       Title = xItem.Title,
                                       InsurerShare = gItem.Sum(t => (int)t.InsurerShare),
                                       FreeValue = gItem.Sum(t => (int)t.FreeValue),
                                   }).ToList();

                var insurersFinancialGroupByResult =
                                 (from item in insurersFinancialGroupByTempResult
                                  select new
                                  {
                                      Title = item.Title,
                                      Value = item.Id == 0 ? item.FreeValue + (insurersFinancialGroupByTempResult.Where(i => i.Id != 0).Sum(i => i.FreeValue)) : item.InsurerShare,
                                  }).ToList();

                var finalResult = new
                {
                    PatientsService = patientServicesGroupByResult,
                    PatientsFinancial = patientFinancialsGroupByResult,
                    CostsFinancial = costFinancialsGroupByResult,
                    InsurersFinancial = insurersFinancialGroupByResult
                };

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetToothX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var ToothId = x.HasValue("ToothId") ? x.GetValue<int>("ToothId") : (int?)null;
                var ToothIds = x.HasValue("ToothIds")
                    ? x.GetValue<IEnumerable>("ToothIds").OfType<object>().Select(i => int.Parse(Convert.ToString(i))).ToList()
                    : null;

                using (var db = new DentalContext())
                {
                    // original had no IsDeleted filter at all (WHERE 1=1 only) -
                    // preserved as-is.
                    IQueryable<Tooth> query = db.Teeth;

                    if (ToothId != null)
                        query = query.Where(t => t.Id == ToothId.Value);

                    if (ToothIds != null && ToothIds.Count > 0)
                        query = query.Where(t => ToothIds.Contains(t.Id));

                    var finalResult = query
                        .Select(t => new
                        {
                            t.Id,
                            t.ToothName,
                            t.ToothTitle,
                            t.ToothGroup,
                            t.ToothImage,
                            t.ToothRegion,
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.Id,
                            i.ToothName,
                            i.ToothTitle,
                            // NOTE: original was "string.Join(\"  -  \", string.Format(...))"
                            // - string.Join called with a single string (not an array)
                            // just returns that string unchanged, so despite the name
                            // this never actually joins anything. Reproduced exactly
                            // (equivalent to plain string.Format).
                            Tooth = string.Join("  -  ", string.Format("({0}) {1}", i.ToothName, i.ToothTitle)),
                            i.ToothGroup,
                            i.ToothImage,
                            i.ToothRegion,
                        })
                        .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetOfficeInfoX(dynamic searchObj)
        {
            try
            {
                // NOTE: DocterId was read from searchObj in the original but never
                // actually used anywhere in the query - preserved (read, unused).
                var x = new RouteValueDictionary(searchObj);
                var DocterId = x.HasValue("DocterId") ? x.GetValue<int>("DocterId") : (int?)null;

                using (var db = new DentalContext())
                {
                    var finalResult = db.Offices
                        .Where(o => o.Id == 1)
                        .Select(o => new
                        {
                            o.OfficeName,
                            o.DoctorName,
                            o.OfficeCode,
                            o.OfficeType,
                            o.NezamPezeshki,
                            o.PhoneNumber,
                            o.OfficeAddress,
                            o.Email,
                            o.Website,
                            o.ModifiedDate,
                            o.IsDeleted,
                            o.DefaultDoctorId,
                            o.DefaultBasicInsurerId,
                            o.DefaultMaritalStatusId,
                            o.DefaultEducationLevelId,
                            o.DefaultNationalityId
                        })
                        .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetAppointmentedPatientsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var ServiceGroupId = x.HasValue("ServiceGroupId") ? x.GetValue<int>("ServiceGroupId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;

                using (var db = new DentalContext())
                {
                    // BUG FIX vs. the original: the raw SQL selected "vst.StarTime"
                    // (typo) - the real column is "StartTime" - so the query would
                    // fail immediately with "no such column: StarTime" on every
                    // call. It also selected the service group's id as bare
                    // "svcg.Id" (no alias) and never selected a "DoctorId" column at
                    // all, while the outer WHERE filtered on "ServiceGroupId" and
                    // "DoctorId" - neither of which existed in that derived table,
                    // and the final projection unconditionally read "i.ServiceGroupId"
                    // too. There's no working behavior to preserve here; fixed to use
                    // the real columns (vst.StartTime, vst.ServiceGroupId,
                    // vst.DoctorId).
                    IQueryable<Visit> query = db.Visits
                        .Include(vst => vst.Patient)
                        .Include(vst => vst.Doctor)
                        .Include(vst => vst.ServiceGroup)
                        // original used INNER JOINs to Patients and Staffs - rows
                        // lacking either are excluded, same as here. The
                        // ServiceGroups join was LEFT (optional), same as here too.
                        .Where(vst => vst.Patient != null && vst.Doctor != null);

                    if (DoctorId != null)
                        query = query.Where(vst => vst.DoctorId == DoctorId.Value);

                    if (PatientId != null)
                        query = query.Where(vst => vst.PatientId == PatientId.Value);

                    if (ServiceGroupId != null)
                        query = query.Where(vst => vst.ServiceGroupId == ServiceGroupId.Value);

                    if (FromDate != null)
                        query = query.Where(vst => vst.Date >= FromDate.Value);

                    if (ToDate != null)
                        query = query.Where(vst => vst.Date <= ToDate.Value);

                    var finalResult = query
                        .Select(vst => new
                        {
                            PatientId = vst.PatientId,
                            PatientName = vst.Patient.FirstName + " " + vst.Patient.LastName,
                            MobilePhone = vst.Patient.MobilePhone,
                            Date = vst.Date,
                            StarTime = vst.StartTime,
                            EndTime = vst.EndTime,
                            Tamas = "",
                            ServiceGroupId = vst.ServiceGroupId,
                            ServiceGroupTitle = vst.ServiceGroup != null ? vst.ServiceGroup.Title : null,
                            StaffId = vst.Doctor.Id,
                            DoctorTitle = vst.Doctor.FirstName + " " + vst.Doctor.LastName,
                            MedicalCouncilCode = vst.Doctor.MedicalCouncilCode
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.PatientId,
                            i.PatientName,
                            i.MobilePhone,
                            Date = Publics.GetSolarDate(i.Date),
                            i.StarTime,
                            i.EndTime,
                            i.Tamas,
                            i.ServiceGroupId,
                            i.ServiceGroupTitle,
                            i.StaffId,
                            i.DoctorTitle,
                            i.MedicalCouncilCode
                        })
                        .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetVisitX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var ServiceGroupId = x.HasValue("ServiceGroupId") ? x.GetValue<int>("ServiceGroupId") : (int?)null;
                var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                using (var db = new DentalContext())
                {
                    // original used an INNER JOIN to Patients - rows lacking a
                    // matching patient are excluded, same as here. Staffs/Doctor and
                    // ServiceGroups were LEFT JOINs (optional), same as here too.
                    IQueryable<Visit> query = db.Visits
                        .Include(vst => vst.Patient)
                        .Include(vst => vst.Doctor)
                        .Include(vst => vst.ServiceGroup)
                        .Where(vst => vst.Patient != null);

                    if (Id != null)
                        query = query.Where(vst => vst.Id == Id.Value);

                    if (DoctorId != null)
                        query = query.Where(vst => vst.DoctorId == DoctorId.Value);

                    if (PatientId != null)
                        query = query.Where(vst => vst.PatientId == PatientId.Value);

                    if (ServiceGroupId != null)
                        query = query.Where(vst => vst.ServiceGroupId == ServiceGroupId.Value);

                    if (Date != null)
                        query = query.Where(vst => vst.Date == Date.Value);

                    if (FromDate != null)
                        query = query.Where(vst => vst.Date >= FromDate.Value);

                    if (ToDate != null)
                        query = query.Where(vst => vst.Date <= ToDate.Value);

                    if (IsDeleted != null)
                        query = query.Where(vst => vst.IsDeleted == IsDeleted.Value);

                    var resultList = query
                                    .Select(vst => new
                                    {
                                        vst.Id,
                                        PatientId = (int?)vst.PatientId,
                                        PatientName = vst.Patient.FirstName + " " + vst.Patient.LastName,
                                        vst.DoctorId,
                                        DoctorTitle = vst.Doctor != null ? vst.Doctor.FirstName + " " + vst.Doctor.LastName : null,
                                        MedicalCouncilCode = vst.Doctor != null ? vst.Doctor.MedicalCouncilCode : null,
                                        vst.ServiceGroupId,
                                        ServiceGroupTitle = vst.ServiceGroup != null ? vst.ServiceGroup.Title : null,
                                        Date = vst.Date,
                                        StartTimeRaw = vst.StartTimeRaw,   // فیلد خام مپ‌شده
                                        EndTimeRaw = vst.EndTimeRaw,       // فیلد خام مپ‌شده
                                        vst.Description,
                                        vst.Color,
                                        IsDeleted = vst.IsDeleted ?? false,
                                        MobilePhone = vst.Patient.MobilePhone
                                    })
                                    .AsEnumerable()   // از اینجا به بعد در حافظه (LINQ to Objects)
                                    .Select(i => new
                                    {
                                        i.Id,
                                        i.PatientId,
                                        i.PatientName,
                                        i.DoctorId,
                                        i.DoctorTitle,
                                        i.MedicalCouncilCode,
                                        i.ServiceGroupId,
                                        i.ServiceGroupTitle,
                                        i.Date,
                                        StartTime = TimeSpan.TryParse(i.StartTimeRaw, out var st) ? st : TimeSpan.Zero,
                                        EndTime = TimeSpan.TryParse(i.EndTimeRaw, out var et) ? et : TimeSpan.Zero,
                                        i.Description,
                                        i.Color,
                                        i.IsDeleted,
                                        i.MobilePhone
                                    })
                                    .ToList();

                    var finalResult = resultList.Select(i => new
                    {
                        i.Id,
                        i.PatientId,
                        i.PatientName,
                        i.DoctorId,
                        i.DoctorTitle,
                        i.MedicalCouncilCode,
                        i.ServiceGroupId,
                        i.ServiceGroupTitle,
                        Date = Publics.GetDate(i.Date),
                        SolarDate = Publics.GetSolarDate(i.Date),
                        StartTime = i.StartTime,
                        EndTime = i.EndTime,
                        i.Description,
                        i.Color,
                        i.IsDeleted,
                        i.MobilePhone,

                        CountItems = resultList != null && resultList.Count > 0 ? resultList.Count() : 0,
                    }).ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetStaffsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var StaffId = x.HasValue("StaffId") ? x.GetValue<int>("StaffId") : (int?)null;
                var StaffTypeId = x.HasValue("StaffTypeId") ? x.GetValue<int>("StaffTypeId") : (int?)null;
                var FirstName = x.HasValue("FirstName") ? x.GetValue<string>("FirstName") : null;
                var LastName = x.HasValue("LastName") ? x.GetValue<string>("LastName") : null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                using (var db = new DentalContext())
                {
                    // NOTE: staf.Date is a string column (see Staff model) - FromDate/
                    // ToDate compare against it the same (string) way the original did.
                    IQueryable<Staff> staffQuery = db.Staffs
                        .Include(staf => staf.StaffType)
                        .Include(staf => staf.Gender)
                        .Include(staf => staf.StaffSpecialty)
                        // original used an INNER JOIN to BaseCoding_StaffTypes - rows
                        // lacking a matching staff type are excluded, same as here.
                        .Where(staf => staf.StaffType != null);

                    if (StaffId != null)
                        staffQuery = staffQuery.Where(staf => staf.Id == StaffId.Value);

                    if (StaffTypeId != null)
                        staffQuery = staffQuery.Where(staf => staf.StaffTypeId == StaffTypeId.Value);

                    if (FirstName != null)
                        staffQuery = staffQuery.Where(staf => DbFunctions.Like(staf.FirstName, "%" + FirstName + "%"));

                    if (LastName != null)
                        staffQuery = staffQuery.Where(staf => DbFunctions.Like(staf.LastName, "%" + LastName + "%"));

                    if (FromDate != null)
                    {
                        var fromDateStr = Publics.ConvertDateTimeToString(FromDate);
                        staffQuery = staffQuery.Where(staf => string.Compare(staf.Date, fromDateStr) >= 0);
                    }

                    if (ToDate != null)
                    {
                        var toDateStr = Publics.ConvertDateTimeToString(ToDate);
                        staffQuery = staffQuery.Where(staf => string.Compare(staf.Date, toDateStr) <= 0);
                    }

                    if (IsDeleted != null)
                        staffQuery = staffQuery.Where(staf => staf.IsDeleted == IsDeleted.Value);

                    // original used a LEFT JOIN to Users on "usr.StaffId = staf.Id" -
                    // with no de-duplication, so more than one user account linked to
                    // the same staff row would multiply that staff's row in the
                    // result, same as reproduced here (GroupJoin + DefaultIfEmpty).
                    var joined =
                        from staf in staffQuery
                        join usr in db.Users on staf.Id equals usr.StaffId into usrGroup
                        from usr in usrGroup.DefaultIfEmpty()
                        select new { staf, usr };

                    var finalResult = joined
                        .Select(j => new
                        {
                            Id = j.staf.Id,
                            StaffId = j.staf.Id,
                            j.staf.FirstName,
                            j.staf.LastName,
                            FullName = j.staf.FirstName + "  " + j.staf.LastName,
                            j.staf.NationalCode,
                            j.staf.FixedPhone,
                            j.staf.MobilePhone,
                            j.staf.Address,
                            j.staf.Comment,
                            IsDeleted = j.staf.IsDeleted,
                            Date = j.staf.Date,
                            j.staf.GenderId,
                            GenderTitle = j.staf.Gender != null ? j.staf.Gender.Title : null,
                            j.staf.StaffTypeId,
                            StaffTypeTitle = j.staf.StaffType.Title,
                            SpecialtyId = j.staf.StaffSpecialtyId,
                            SpecialtyTitle = j.staf.StaffSpecialty != null ? j.staf.StaffSpecialty.Title : null,
                            UserId = (int?)(j.usr != null ? j.usr.Id : (int?)null),
                            UserName = j.usr != null ? j.usr.UserName : null,
                            UserPass = j.usr != null ? j.usr.UserPass : null,
                            IsDeletedUser = j.usr != null ? j.usr.IsDeleted : (bool?)null
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.Id,
                            i.StaffId,
                            i.FirstName,
                            i.LastName,
                            i.FullName,
                            Title = i.FullName,
                            i.NationalCode,
                            i.FixedPhone,
                            i.MobilePhone,
                            i.Address,
                            i.Comment,
                            i.IsDeleted,
                            Date = Publics.GetDate(i.Date),
                            SolarRecruitmentDate = Publics.GetSolarDate(i.Date),
                            i.GenderId,
                            i.GenderTitle,
                            i.StaffTypeId,
                            i.StaffTypeTitle,
                            i.SpecialtyId,
                            i.SpecialtyTitle,
                            i.UserId,
                            i.UserName,
                            i.UserPass,
                            IsDeletedUser = i.IsDeletedUser ?? false
                        })
                        .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetDoctorsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var StaffId = x.HasValue("StaffId") ? x.GetValue<int>("StaffId") : (int?)null;

                using (var db = new DentalContext())
                {
                    // BUG FIX vs. the original SQL (three separate issues, verified
                    // against the actual DB):
                    //  1) "SELECT ... SpecialtyId ..." was unqualified while BOTH
                    //     joined tables (Staff_Doctors AND Staffs) have a column
                    //     named SpecialtyId - SQLite rejects this outright with
                    //     "ambiguous column name: SpecialtyId". The join was
                    //     explicitly "spi ON spi.Id = staf.SpecialtyId" (the base
                    //     Staff table's generic SpecialtyId, not Doctor's own), so
                    //     that's the one used below (staf.StaffSpecialtyId).
                    //  2) The final projection read "i.Title" and
                    //     "i.SolarRecruitmentDate", neither of which was ever
                    //     selected by the query (only FullName, GenderTitle,
                    //     StaffTypeTitle, SpecialtyTitle were).
                    // All three would make this function fail on every call - no
                    // working behavior to preserve. Fixed to mirror the sibling
                    // GetStaffsX conventions (Title = FullName, SolarRecruitmentDate
                    // computed via Publics.GetSolarDate).
                    //
                    // Also: Doctor is TPT-mapped onto Staffs + Staff_Doctors, so
                    // querying db.Doctors directly already gives the equivalent of
                    // the original's "Staff_Doctors doc LEFT JOIN Staff staf" (EF's
                    // TPT query does this join itself) without a separate manual join.
                    IQueryable<Doctor> query = db.Doctors
                        .Include(doc => doc.Gender)
                        .Include(doc => doc.StaffType)
                        .Include(doc => doc.StaffSpecialty);

                    if (StaffId != null)
                        query = query.Where(doc => doc.Id == StaffId.Value);

                    var finalResult = query
                        .Select(doc => new
                        {
                            Id = doc.Id,
                            DoctorId = doc.Id,
                            doc.FirstName,
                            doc.LastName,
                            FullName = doc.FirstName + "  " + doc.LastName,
                            doc.NationalCode,
                            doc.FixedPhone,
                            doc.MobilePhone,
                            doc.Address,
                            doc.Comment,
                            doc.IsDeleted,
                            doc.Date,
                            doc.GenderId,
                            GenderTitle = doc.Gender != null ? doc.Gender.Title : null,
                            doc.StaffTypeId,
                            StaffTypeTitle = doc.StaffType != null ? doc.StaffType.Title : null,
                            SpecialtyId = doc.StaffSpecialtyId,
                            SpecialtyTitle = doc.StaffSpecialty != null ? doc.StaffSpecialty.Title : null,
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.Id,
                            i.DoctorId,
                            i.FirstName,
                            i.LastName,
                            i.FullName,
                            Title = i.FullName,
                            i.NationalCode,
                            i.FixedPhone,
                            i.MobilePhone,
                            i.Address,
                            i.Comment,
                            IsDeleted = i.IsDeleted,
                            Date = Convert.ToDateTime(i.Date),
                            SolarRecruitmentDate = Publics.GetSolarDate(i.Date),
                            i.GenderId,
                            i.GenderTitle,
                            i.StaffTypeId,
                            i.StaffTypeTitle,
                            i.SpecialtyId,
                            i.SpecialtyTitle,
                        })
                        .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetInsurersX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var InsuranceId = x.HasValue("InsuranceId") ? x.GetValue<int>("InsuranceId") : (int?)null;
                var InsuranceBoxId = x.HasValue("InsuranceBoxId") ? x.GetValue<int>("InsuranceBoxId") : (int?)null;
                var InsurerId = x.HasValue("InsurerId") ? x.GetValue<int>("InsurerId") : (int?)null;
                var InsurerTitle = x.HasValue("InsurerTitle") ? x.GetValue<string>("InsurerTitle") : null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                using (var db = new DentalContext())
                {
                    // original used INNER JOINs to both Insurances and
                    // InsuranceBoxes - rows lacking either are excluded, same as here.
                    IQueryable<Insurer> query = db.Insurers
                        .Include(insr => insr.Insurance)
                        .Include(insr => insr.InsuranceBox)
                        .Where(insr => insr.Insurance != null && insr.InsuranceBox != null);

                    if (InsuranceId != null)
                        query = query.Where(insr => insr.InsuranceId == InsuranceId.Value);

                    if (InsuranceBoxId != null)
                        query = query.Where(insr => insr.InsuranceBoxId == InsuranceBoxId.Value);

                    if (InsurerId != null)
                        query = query.Where(insr => insr.Id == InsurerId.Value);

                    if (InsurerTitle != null)
                        query = query.Where(insr => DbFunctions.Like(insr.Title, "%" + InsurerTitle + "%"));

                    if (IsDeleted != null)
                        query = query.Where(insr => insr.IsDeleted == IsDeleted.Value);

                    var finalResult = query
                        .Select(insr => new
                        {
                            InsurerId = insr.Id,
                            insr.Title,
                            insr.IsDeleted,
                            insr.InsuranceId,
                            InsuranceTitle = insr.Insurance.Title,
                            insr.InsuranceBoxId,
                            InsuranceBoxTitle = insr.InsuranceBox.Title,
                            insr.IsBasic,
                            insr.IsExtra,
                            insr.InsurerPercent,
                            insr.Comment
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.InsurerId,
                            InsurerTitle = i.Title,
                            IsDeleted = i.IsDeleted,
                            InsuranceId = i.InsuranceId ?? 0,
                            i.InsuranceTitle,
                            InsuranceBoxId = i.InsuranceBoxId ?? 0,
                            i.InsuranceBoxTitle,
                            IsBasic = i.IsBasic ?? false,
                            IsExtra = i.IsExtra ?? false,
                            InsurerPercent = (float)(i.InsurerPercent ?? 0),
                            i.Comment
                        })
                        .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetInsurersServicePricingX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var InsuranceId = x.HasValue("InsuranceId") ? x.GetValue<int>("InsuranceId") : (int?)null;
                var InsurerId = x.HasValue("InsurerId") ? x.GetValue<int>("InsurerId") : (int?)null;
                var ServiceId = x.HasValue("ServiceId") ? x.GetValue<int>("ServiceId") : (int?)null;
                var ServiceDate = x.HasValue("ServiceDate") ? x.GetValue<DateTime>("ServiceDate") : DateTime.Now;

                using (var db = new DentalContext())
                {
                    // original had no joins/IsDeleted filter at all (WHERE 1=1 only)
                    // - preserved as-is.
                    IQueryable<Insurer> insurerQuery = db.Insurers;

                    if (InsuranceId != null)
                        insurerQuery = insurerQuery.Where(insrr => insrr.InsuranceId == InsuranceId.Value);

                    if (InsurerId != null)
                        insurerQuery = insurerQuery.Where(insrr => insrr.Id == InsurerId.Value);

                    var insurersResult = insurerQuery
                        .Select(insrr => new
                        {
                            InsurerId = insrr.Id,
                            InsurerTitle = insrr.Title,
                            InsuranceId = insrr.InsuranceId ?? 0,
                            InsuranceBoxId = insrr.InsuranceBoxId ?? 0,
                            IsBasic = insrr.IsBasic ?? false,
                            IsExtra = insrr.IsExtra ?? false,
                            InsurerPercent = insrr.InsurerPercent ?? 0,
                            IsDeleted = insrr.IsDeleted,
                        })
                        .ToList();

                    if (insurersResult.Count == 0)
                        throw new Exception("1");

                    // NOTE: ServiceDate is read from searchObj but never actually
                    // used to filter either query, in the original - preserved.
                    IQueryable<InsurerServiceTarefeChange> tarefeQuery = db.InsurerServiceTarefeChanges;

                    if (ServiceId != null)
                        tarefeQuery = tarefeQuery.Where(instc => instc.ServiceId == ServiceId.Value);

                    if (InsurerId != null)
                        tarefeQuery = tarefeQuery.Where(instc => instc.InsurerId == InsurerId.Value);

                    var tarefeResult = tarefeQuery
                        .Select(instc => new
                        {
                            Id = (int?)instc.Id,
                            ServiceId = (int?)instc.ServiceId,
                            InsurerId = (int?)instc.InsurerId,
                            FreePrice = instc.FreePrice,
                            InsurerPrice = instc.InsurerPrice,
                            DefineDate = instc.DefineDate,
                            RunDate = instc.RunDate,
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.Id,
                            i.ServiceId,
                            i.InsurerId,
                            FreePrice = (decimal)(i.FreePrice ?? 0),
                            InsurerPrice = (decimal)(i.InsurerPrice ?? 0),
                            DefineDate = Publics.GetDate(i.DefineDate),
                            SolarDefineDate = Publics.GetSolarDate(i.DefineDate),
                            RunDate = Publics.GetDate(i.RunDate),
                            SolarRunDate = Publics.GetSolarDate(i.RunDate),
                        })
                        .ToList();

                    if (tarefeResult.Count == 0)
                        throw new Exception("2");

                    var finalResult = (
                                from iItem in insurersResult
                                let itItem = tarefeResult.Where(i => i.InsurerId == iItem.InsurerId)
                                                         .OrderByDescending(i => i.DefineDate)
                                                         .OrderByDescending(i => i.Id)
                                                         .FirstOrDefault()
                                let insurerServiceTarefeChangeId = itItem != null ? itItem.Id : 0
                                let serviceId = itItem != null ? itItem.ServiceId : 0
                                let freePrice = itItem != null ? itItem.FreePrice : 0
                                let insurerPrice = itItem != null ? itItem.InsurerPrice : 0
                                let defineDate = itItem != null && itItem.DefineDate != null ? itItem.DefineDate.Value : DateTime.Now
                                let solarDefineDate = itItem != null ? itItem.SolarDefineDate : ""
                                let runDate = itItem != null && itItem.RunDate != null ? itItem.RunDate.Value : DateTime.Now
                                let solarRunDate = itItem != null ? itItem.SolarRunDate : ""
                                let insurerPercent = iItem != null ? iItem.InsurerPercent : 0

                                let serviceFinancial = new Class.InsurerServiceTarefe(freePrice, insurerPrice, insurerPercent)
                                select new
                                {
                                    iItem.InsuranceId,
                                    iItem.InsuranceBoxId,
                                    iItem.InsurerTitle,
                                    iItem.IsBasic,
                                    iItem.IsExtra,
                                    iItem.InsurerPercent,
                                    iItem.IsDeleted,
                                    iItem.InsurerId,

                                    InsurerServiceTarefeChangeId = insurerServiceTarefeChangeId,
                                    ServiceId = serviceId,

                                    FreePrice = freePrice,
                                    InsurerPrice = insurerPrice,
                                    DefineDate = defineDate,
                                    SolarDefineDate = solarDefineDate,
                                    RunDate = runDate,
                                    SolarRunDate = solarRunDate,

                                    serviceFinancial.InsurerShare,
                                    serviceFinancial.FranchiseShare,
                                    serviceFinancial.FreeShare,
                                    serviceFinancial.PatientShare,
                                }).ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "2")
                    return new JsonResponse<dynamic>() { Success = false, Data = 2, Message = Constant.NoInsurancePriceRecordForService };

                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetCalendarTimesX(dynamic searchObj)
        {
            try
            {
                // NOTE: TimeId is read from searchObj in the original but never
                // actually used anywhere in the query - preserved (read, unused).
                var x = new RouteValueDictionary(searchObj);
                var TimeId = x.HasValue("TimeId") ? x.GetValue<int>("TimeId") : (int?)null;
                var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                using (var db = new DentalContext())
                {
                    // original had no join/existence filter at all (plain "FROM
                    // WorkTimes WHERE 1=1") - preserved as-is.
                    IQueryable<WorkTime> query = db.WorkTimes;

                    if (DoctorId != null)
                        query = query.Where(w => w.DoctorId == DoctorId.Value);

                    if (FromDate != null)
                        query = query.Where(w => w.Date >= FromDate.Value);

                    if (ToDate != null)
                        query = query.Where(w => w.Date <= ToDate.Value);

                    if (IsDeleted != null)
                        query = query.Where(w => w.IsDeleted == IsDeleted.Value);

                    var resultList = query
                        .OrderBy(w => w.Date)
                        .AsEnumerable()
                        .Select(w => new
                        {
                            w.Id,
                            w.DoctorId,
                            w.Date,
                            StartTime = w.StartTime,
                            EndTime = w.EndTime,
                            w.Description,
                            IsDeleted = w.IsDeleted ?? false,
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.Id,
                            i.DoctorId,
                            Date = Publics.GetDate(i.Date),
                            DayOfWeek = Publics.GetDate(i.Date)?.ToString("dddd") ?? "",
                            StartTime = i.StartTime.ToString(@"hh\:mm\:ss"),
                            EndTime = i.EndTime.ToString(@"hh\:mm\:ss"),
                            StartDateTime = Publics.GetDate(string.Format("{0} {1}", i.Date, i.StartTime.ToString(@"hh\:mm\:ss"))),
                            EndDateTime = Publics.GetDate(string.Format("{0} {1}", i.Date, i.EndTime.ToString(@"hh\:mm\:ss"))),
                            i.Description,
                            i.IsDeleted,
                        })
                        .ToList();

                    var finalResult = resultList;

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetUserX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var UserId = x.HasValue("UserId") ? x.GetValue<int>("UserId") : (int?)null;
                var StaffId = x.HasValue("StaffId") ? x.GetValue<int>("StaffId") : (int?)null;
                var UserName = x.HasValue("UserName") ? x.GetValue<string>("UserName") : null;
                var UserPass = x.HasValue("UserPass") ? x.GetValue<string>("UserPass") : null;
                var IsUserLogin = x.HasValue("IsUserLogin") ? x.GetValue<bool>("IsUserLogin") : (bool?)null;
                var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                if (IsUserLogin == true)
                {
                    if (UserName == null)
                        throw new Exception(" نام کاربری وارد نشده است");
                    if (UserPass == null)
                        throw new Exception(" کلمه عبور وارد نشده است");
                }

                using (var db = new DentalContext())
                {
                    // original had no existence filter on Staff at all (LEFT JOIN,
                    // optional) - preserved as-is.
                    IQueryable<User> query = db.Users
                        .Include(user => user.Staff);

                    if (UserId != null)
                        query = query.Where(user => user.Id == UserId.Value);

                    if (StaffId != null)
                        query = query.Where(user => user.StaffId == StaffId.Value);

                    // NOTE: preserved exactly as in the original SQL - it compared
                    // "UserName = LOWER(@val)" (lower-cases only the search term, not
                    // the stored column), which is a case-SENSITIVE match against a
                    // fully-lowercased value, not the case-insensitive match the
                    // LOWER() call suggests was intended. Likely worth revisiting for
                    // login matching specifically - confirm with the team.
                    if (UserName != null)
                        query = query.Where(user => user.UserName == UserName.ToLower());

                    if (UserPass != null)
                        query = query.Where(user => user.UserPass == UserPass.ToLower());

                    if (IsDeleted != null)
                        query = query.Where(user => user.IsDeleted == IsDeleted.Value);

                    var resultList = query
                        .Select(user => new
                        {
                            user.Id,
                            user.UserName,
                            user.UserPass,
                            staffName = user.Staff != null ? user.Staff.FirstName + " " + user.Staff.LastName : null,
                            user.StaffId,
                            user.Email,
                            user.IsDeleted
                        })
                        .ToList()
                        .Select(i => new
                        {
                            i.Id,
                            UserId = i.Id,
                            i.UserName,
                            i.UserPass,
                            UserTitle = i.staffName,
                            i.StaffId,
                            i.Email,
                            IsDeleted = i.IsDeleted
                        })
                        .ToList();

                    var finalResult = resultList;

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                // NOTE: preserved from the original - a WPF/WinForms MessageBox call
                // directly inside a data-access function is an unusual layering
                // choice (UI code in the data layer); worth revisiting, but kept
                // as-is here since removing it would be a behavior change.
                System.Windows.MessageBox.Show(ex.Message);
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetUserPermissionsX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var UserId = x.HasValue("UserId") ? x.GetValue<int>("UserId") : (int?)null;

                // NOTE: preserved from the original - this constructs an Exception
                // but never throws it, so a missing UserId silently does nothing here.
                if (UserId == null)
                {
                    var _unused = new Exception("UserId وارد نشده است");
                }

                using (var db = new DentalContext())
                {
                    // LEFT JOIN with the UserId condition inside the join (not a
                    // WHERE filter) - every AppAction is still returned, with Value
                    // defaulting to 0 (IFNULL) when there's no matching permission
                    // row for this specific user. Reproduced with a filtered
                    // GroupJoin + DefaultIfEmpty so all AppActions rows survive.
                    var finalResult = (
                        from appA in db.AppActions
                        join usrP in db.UserPermissions.Where(u => u.UserId == UserId) on appA.Id equals usrP.AppActionId into usrPGroup
                        from usrP in usrPGroup.DefaultIfEmpty()
                        select new
                        {
                            AppActionId = appA.Id,
                            appA.FormTitle,
                            appA.GroupTitle,
                            appA.ActionTitle,
                            Value = usrP != null ? usrP.Value : false
                        })
                        .ToList();

                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> DefineServiceX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var ServiceGroupId = x.HasValue("ServiceGroupId") ? x.GetValue<int>("ServiceGroupId") : (int?)null;
                    var Code = x.HasValue("Code") ? x.GetValue<string>("Code") : null;
                    var Title = x.HasValue("Title") ? x.GetValue<string>("Title") : null;
                    var Color = x.HasValue("Color") ? x.GetValue<int>("Color") : (int?)null;
                    var IsToothNumber = x.HasValue("IsToothNumber") ? x.GetValue<bool>("IsToothNumber") : (bool?)false;
                    var IsMoreTooth = x.HasValue("IsMoreTooth") ? x.GetValue<bool>("IsMoreTooth") : (bool?)false;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;
                    var DefineDate = DateTime.Now;
                    var ModifiedDate = (DateTime?)DateTime.Now;
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                    var ServiceFreePrice = x.HasValue("ServiceFreePrice") ? x.GetValue<double>("ServiceFreePrice") : (double?)null;

                    int? serviceId;

                    if (ActionType == "New")
                    {
                        var service = new Service
                        {
                            ServiceGroupId = ServiceGroupId ?? 0,
                            Code = Code,
                            Title = Title,
                            Color = Color,
                            IsToothNumber = IsToothNumber,
                            IsMoreTooth = IsMoreTooth,
                            DefineDate = DefineDate,
                            ModifiedDate = ModifiedDate,
                            IsDeleted = IsDeleted,
                            Comment = Comment
                        };
                        db.Services.Add(service);
                        db.SaveChanges();
                        serviceId = service.Id;
                    }
                    else if (ActionType == "Edit")
                    {
                        // NOTE: preserved from the original - this constructs an
                        // Exception but never throws it, so a missing Id silently
                        // does nothing here.
                        if (Id == null)
                        {
                            var _unused = new Exception("ServiceId وازد نشده است");
                        }

                        var service = db.Services.FirstOrDefault(s => s.Id == Id.Value);
                        if (service == null)
                            throw new Exception("Service not found");

                        if (ServiceGroupId != null)
                            service.ServiceGroupId = ServiceGroupId.Value;
                        if (Code != null)
                            service.Code = Code;
                        if (Title != null)
                            service.Title = Title;
                        if (Color != null)
                            service.Color = Color.Value;
                        // IsToothNumber/IsMoreTooth/ModifiedDate/IsDeleted default to
                        // a real value (never null) above, so - same as the original
                        // SQL's "if (x != null)" checks - these are effectively always
                        // applied on Edit too, even when the caller didn't explicitly
                        // pass them.
                        if (IsToothNumber != null)
                            service.IsToothNumber = IsToothNumber.Value;
                        if (IsMoreTooth != null)
                            service.IsMoreTooth = IsMoreTooth.Value;
                        if (ModifiedDate != null)
                            service.ModifiedDate = ModifiedDate.Value;
                        if (IsDeleted != null)
                            service.IsDeleted = IsDeleted.Value;
                        if (Comment != null)
                            service.Comment = Comment;

                        db.SaveChanges();
                        serviceId = Id.Value;
                    }
                    else
                    {
                        serviceId = null;
                    }

                    if (serviceId != null && ServiceFreePrice != null)
                    {
                        dynamic iObj = new ExpandoObject();
                        iObj.ServiceId = serviceId;
                        iObj.InsurerIds = new List<int>() { 0 };
                        iObj.FreePrice = Convert.ToDouble(ServiceFreePrice);
                        iObj.InsurerPrice = Convert.ToDouble(0);
                        iObj.DefineDate = DateTime.Now;
                        iObj.RunDate = DateTime.Now;

                        // RESOLVED: DefineInsurersPricingX is now converted and
                        // accepts this function's own DentalContext, so the pricing
                        // insert shares the same transaction as the Service
                        // insert/update above - a failure here rolls back both,
                        // matching the original's atomicity.
                        JsonResponse<dynamic> result = DefineInsurersPricingX(iObj, db);

                        if (result == null || result.Success == false)
                        {
                            throw new Exception("خطا در درج تعرفه خدمت");
                        }
                    }

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = serviceId };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefinePatientServiceX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var Id = x.HasValue("PatientServiceId") ? x.GetValue<int>("PatientServiceId") : (int?)null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var CheckupTypeId = x.HasValue("CheckupTypeId") ? x.GetValue<int>("CheckupTypeId") : (int?)null;
                    var ServiceGroupId = x.HasValue("ServiceGroupId") ? x.GetValue<int>("ServiceGroupId") : (int?)null;
                    var ServiceId = x.HasValue("ServiceId") ? x.GetValue<int>("ServiceId") : (int?)null;
                    var ProviderDoctorId = x.HasValue("ProviderDoctorId") ? x.GetValue<int>("ProviderDoctorId") : (int?)null;
                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                    var IsHadMoreTooth = x.HasValue("IsHadMoreTooth") ? x.GetValue<bool>("IsHadMoreTooth") : (bool?)null;
                    var InsurerServiceTarefeChangeId = x.HasValue("InsurerServiceTarefeChangeId") ? x.GetValue<int>("InsurerServiceTarefeChangeId") : (int?)null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;
                    var ServicePrice = x.HasValue("ServicePrice") ? x.GetValue<double>("ServicePrice") : (double?)null;
                    var InsurerPrice = x.HasValue("InsurerPrice") ? x.GetValue<double>("InsurerPrice") : (double?)null;
                    var InsurerShare = x.HasValue("InsurerShare") ? x.GetValue<double>("InsurerShare") : (double?)null;
                    var FranchiseShare = x.HasValue("FranchiseShare") ? x.GetValue<double>("FranchiseShare") : (double?)null;
                    var FreeShare = x.HasValue("FreeShare") ? x.GetValue<double>("FreeShare") : (double?)null;

                    var ToothList = x.HasValue("ToothIds")
                        ? string.Join(" , ", x.GetValue<IEnumerable>("ToothIds").OfType<object>().Select(i => i).ToArray())
                        : null;

                    int patientServiceId = 0;

                    if (ActionType == "New" || ActionType == "Edit")
                    {
                        if (ActionType == "New")
                        {
                            if (PatientId == null)
                                throw new Exception("PatientId  وارد نشده است");
                        }
                        if (ActionType == "Edit")
                        {
                            if (Id == null)
                                throw new Exception("Id  وارد نشده است");
                        }

                        // "Edit" here doesn't update the existing row in place - it soft-
                        // deletes it (IsDeleted = 1) and always inserts a brand new row,
                        // a history/versioning pattern. Preserved as-is.
                        if (Id != null)
                        {
                            var oldService = db.PatientServices.FirstOrDefault(ps => ps.Id == Id.Value);
                            if (oldService != null)
                                oldService.IsDeleted = true;
                        }

                        var newService = new PatientService
                        {
                            PatientId = PatientId ?? 0,
                            ProviderDoctorId = ProviderDoctorId,
                            ServiceGroupId = ServiceGroupId,
                            ServiceId = ServiceId ?? 0,
                            ToothIds = ToothList,
                            CheckupTypeId = CheckupTypeId,
                            // Date is a required (non-nullable) column - same as the
                            // original, a missing Date fails the operation (there it
                            // would be a NOT NULL constraint error from SQLite; here it's
                            // Nullable<T>.Value throwing instead - both land in the same
                            // catch block below with the same net effect).
                            Date = Date.Value,
                            Comment = Comment,
                            IsHadMoreTooth = IsHadMoreTooth ?? false,
                            InsurerServiceTarefeChangeId = InsurerServiceTarefeChangeId,
                            // original hardcoded 0 (not deleted) here regardless of the
                            // IsDeleted parameter - preserved as-is.
                            IsDeleted = false,
                            // original bound ActionPrice to the same @ServicePrice
                            // parameter as ServicePrice itself - preserved as-is.
                            ActionPrice = (decimal)(ServicePrice ?? 0),
                            ServicePrice = (decimal?)ServicePrice,
                            InsurerPrice = (decimal?)InsurerPrice,
                            InsurerShare = (decimal?)InsurerShare,
                            FranchiseShare = (decimal?)FranchiseShare,
                            FreeShare = (decimal?)FreeShare
                        };
                        db.PatientServices.Add(newService);
                        db.SaveChanges();
                        patientServiceId = (int)newService.Id;
                    }

                    if (ActionType == "Delete")
                    {
                        var service = db.PatientServices.FirstOrDefault(ps => ps.Id == Id.Value);
                        if (service != null)
                            service.IsDeleted = true;

                        db.SaveChanges();
                    }

                    var finalResult =
                    new
                    {
                        Id = patientServiceId
                    };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefinePatientTeethX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);

                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var Id = x.HasValue("PatientServiceToothId") ? x.GetValue<int>("PatientServiceToothId") : (int?)null;
                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var ToothId = x.HasValue("ToothId") ? x.GetValue<int>("ToothId") : (int?)null;
                    var Visible = x.HasValue("Visible") ? x.GetValue<bool>("Visible") : false;
                    var Rotate = x.HasValue("Rotate") ? x.GetValue<int>("Rotate") : (int?)null;
                    var TipB = x.HasValue("TipB") ? x.GetValue<int>("TipB") : (int?)null;
                    var TipM = x.HasValue("TipM") ? x.GetValue<int>("TipM") : (int?)null;
                    var ShiftM = x.HasValue("ShiftM") ? x.GetValue<int>("ShiftM") : (int?)null;
                    var ShiftO = x.HasValue("ShiftO") ? x.GetValue<int>("ShiftO") : (int?)null;
                    var ShiftB = x.HasValue("ShiftB") ? x.GetValue<int>("ShiftB") : (int?)null;
                    var IsRCT = x.HasValue("IsRCT") ? x.GetValue<bool>("IsRCT") : false;
                    var ColorRCT = x.HasValue("ColorRCT") ? x.GetValue<int>("ColorRCT") : (int?)null;
                    var IsBU = x.HasValue("IsBU") ? x.GetValue<bool>("IsBU") : false;
                    var ColorBU = x.HasValue("ColorBU") ? x.GetValue<int>("ColorBU") : (int?)null;
                    var IsImplant = x.HasValue("IsImplant") ? x.GetValue<bool>("IsImplant") : false;
                    var ColorImplant = x.HasValue("ColorImplant") ? x.GetValue<int>("ColorImplant") : (int?)null;
                    var IsCrown = x.HasValue("IsCrown") ? x.GetValue<bool>("IsCrown") : false;
                    var IsPontic = x.HasValue("IsPontic") ? x.GetValue<bool>("IsPontic") : false;

                    var IsSealant = x.HasValue("IsSealant") ? x.GetValue<bool>("IsSealant") : false;
                    var ColorSealant = x.HasValue("ColorSealant") ? x.GetValue<int>("ColorSealant") : (int?)null;
                    var SurfaceColor = x.HasValue("SurfaceColor") ? x.GetValue<int>("SurfaceColor") : (int?)null;
                    var Surface = x.HasValue("Surface") ? x.GetValue<string>("Surface") : null;
                    var Surface_B = x.HasValue("Surface_B") ? x.GetValue<bool>("Surface_B") : false;
                    var Surface_B_Color = x.HasValue("Surface_B_Color") ? x.GetValue<int>("Surface_B_Color") : (int?)null;
                    var Surface_F = x.HasValue("Surface_F") ? x.GetValue<bool>("Surface_F") : false;
                    var Surface_F_Color = x.HasValue("Surface_F_Color") ? x.GetValue<int>("Surface_F_Color") : (int?)null;
                    var Surface_C = x.HasValue("Surface_C") ? x.GetValue<bool>("Surface_C") : false;
                    var Surface_C_Color = x.HasValue("Surface_C_Color") ? x.GetValue<int>("Surface_C_Color") : (int?)null;
                    var Surface_D = x.HasValue("Surface_D") ? x.GetValue<bool>("Surface_D") : false;
                    var Surface_D_Color = x.HasValue("Surface_D_Color") ? x.GetValue<int>("Surface_D_Color") : (int?)null;
                    var Surface_E = x.HasValue("Surface_E") ? x.GetValue<bool>("Surface_E") : false;
                    var Surface_E_Color = x.HasValue("Surface_E_Color") ? x.GetValue<int>("Surface_E_Color") : (int?)null;
                    var Surface_L = x.HasValue("Surface_L") ? x.GetValue<bool>("Surface_L") : false;
                    var Surface_L_Color = x.HasValue("Surface_L_Color") ? x.GetValue<int>("Surface_L_Color") : (int?)null;
                    var Surface_M = x.HasValue("Surface_M") ? x.GetValue<bool>("Surface_M") : false;
                    var Surface_M_Color = x.HasValue("Surface_M_Color") ? x.GetValue<int>("Surface_M_Color") : (int?)null;
                    var Surface_O = x.HasValue("Surface_O") ? x.GetValue<bool>("Surface_O") : false;
                    var Surface_O_Color = x.HasValue("Surface_O_Color") ? x.GetValue<int>("Surface_O_Color") : (int?)null;
                    var Surface_I = x.HasValue("Surface_I") ? x.GetValue<bool>("Surface_I") : false;
                    var Surface_I_Color = x.HasValue("Surface_I_Color") ? x.GetValue<int>("Surface_I_Color") : (int?)null;
                    var Surface_V = x.HasValue("Surface_V") ? x.GetValue<bool>("Surface_V") : false;
                    var Surface_V_Color = x.HasValue("Surface_V_Color") ? x.GetValue<int>("Surface_V_Color") : (int?)null;

                    var Description = x.HasValue("Description") ? x.GetValue<string>("Description") : null;

                    if (ToothId == null)
                        throw new Exception("کد دندان وارد نشده است");

                    // original soft-deleted any existing row for this
                    // patient+tooth (IsDeleted = 1) before inserting the new one -
                    // a history/versioning pattern, preserved as-is.
                    var oldTeeth = db.PatientTeeth.Where(pt => pt.PatientId == (PatientId ?? 0) && pt.ToothId == ToothId.Value);
                    foreach (var oldTooth in oldTeeth)
                        oldTooth.IsDeleted = true;

                    var newTooth = new PatientTooth
                    {
                        PatientId = PatientId ?? 0,
                        Date = Date,
                        ToothId = ToothId,
                        Visible = Visible,
                        Rotate = Rotate,
                        TipB = TipB,
                        TipM = TipM,
                        ShiftM = ShiftM,
                        ShiftO = ShiftO,
                        ShiftB = ShiftB,
                        IsRCT = IsRCT,
                        ColorRCT = ColorRCT,
                        IsBU = IsBU,
                        ColorBU = ColorBU,
                        IsImplant = IsImplant,
                        ColorImplant = ColorImplant,
                        IsCrown = IsCrown,
                        IsPontic = IsPontic,
                        IsSealant = IsSealant,
                        ColorSealant = ColorSealant,
                        Surface = Surface,
                        SurfaceColor = SurfaceColor,
                        Surface_B = Surface_B,
                        Surface_B_Color = Surface_B_Color,
                        Surface_F = Surface_F,
                        Surface_F_Color = Surface_F_Color,
                        Surface_C = Surface_C,
                        Surface_C_Color = Surface_C_Color,
                        Surface_D = Surface_D,
                        Surface_D_Color = Surface_D_Color,
                        Surface_E = Surface_E,
                        Surface_E_Color = Surface_E_Color,
                        Surface_L = Surface_L,
                        Surface_L_Color = Surface_L_Color,
                        Surface_M = Surface_M,
                        Surface_M_Color = Surface_M_Color,
                        Surface_O = Surface_O,
                        Surface_O_Color = Surface_O_Color,
                        Surface_I = Surface_I,
                        Surface_I_Color = Surface_I_Color,
                        Surface_V = Surface_V,
                        Surface_V_Color = Surface_V_Color,
                        Description = Description,
                        IsDeleted = false
                    };
                    db.PatientTeeth.Add(newTooth);
                    db.SaveChanges();

                    int patientServiceToothId = (int)newTooth.Id;

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = patientServiceToothId };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefineVisitX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                    var ServiceGroupId = x.HasValue("ServiceGroupId") ? x.GetValue<int>("ServiceGroupId") : (int?)null;

                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var StartTime = x.HasValue("StartTime") ? x.GetValue<TimeSpan>("StartTime") : (TimeSpan?)null;
                    var EndTime = x.HasValue("EndTime") ? x.GetValue<TimeSpan>("EndTime") : (TimeSpan?)null;

                    var Description = x.HasValue("Description") ? x.GetValue<string>("Description") : null;
                    var Color = x.HasValue("Color") ? x.GetValue<int>("Color") : (int?)null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                    int? id = null;

                    if (Id != null)
                    {
                        // BUG (preserved as-is, flagged loudly): the original SQL's
                        // "Id == -1" branch had NO "WHERE Id = @Id" at all, so it
                        // updated EVERY row in Visits with whatever fields were
                        // provided - not just one. Reproduced exactly below, but
                        // this looks like a real hazard (mass-updating the whole
                        // table) rather than intentional behavior - please confirm
                        // with the team before relying on it; consider guarding
                        // this branch off entirely if nothing intentionally passes
                        // Id = -1 to mean "update all visits".
                        IEnumerable<Visit> targets = Id != -1
                            ? db.Visits.Where(v => v.Id == Id.Value).ToList()
                            : db.Visits.ToList();

                        foreach (var visit in targets)
                        {
                            if (PatientId != null)
                                visit.PatientId = PatientId.Value;
                            if (DoctorId != null)
                                visit.DoctorId = DoctorId.Value;
                            if (ServiceGroupId != null)
                                visit.ServiceGroupId = ServiceGroupId.Value;
                            if (Date != null)
                                visit.Date = Date.Value;
                            if (StartTime != null)
                                visit.StartTime = StartTime.Value;
                            if (EndTime != null)
                                visit.EndTime = EndTime.Value;
                            if (Description != null)
                                visit.Description = Description;
                            if (Color != null)
                                visit.Color = Color.Value;
                            if (IsDeleted != null)
                                visit.IsDeleted = IsDeleted.Value;
                        }

                        db.SaveChanges();
                        // original's SELECT last_insert_rowid() after an UPDATE is
                        // irrelevant here anyway - the final result below always
                        // uses the supplied Id.Value in the Id != null case,
                        // matching the original.
                    }
                    else
                    {
                        var visit = new Visit
                        {
                            PatientId = PatientId ?? 0,
                            DoctorId = DoctorId ?? 0,
                            ServiceGroupId = ServiceGroupId,
                            Date = Date ?? default(DateTime),
                            StartTime = StartTime ?? default(TimeSpan),
                            EndTime = EndTime ?? default(TimeSpan),
                            Description = Description,
                            Color = Color,
                            IsDeleted = IsDeleted
                        };
                        db.Visits.Add(visit);
                        db.SaveChanges();
                        id = visit.Id;
                    }

                    var finalResult =
                        new
                        {
                            Id = (Id != null) ? Id.Value : id
                        };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DeleteWorkTimeX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                    var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                    var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;

                    if (DoctorId == null)
                        throw new Exception("کد پزشک وارد نشده است");
                    //if (FromDate == null || ToDate == null)
                    //    throw new Exception("تاریخ وارد نشده است");

                    // NOTE: preserved from the original - the FromDate/ToDate range
                    // condition was commented out in the SQL itself, so this is a
                    // hard DELETE (not a soft-delete) of every WorkTimes row for this
                    // doctor, regardless of FromDate/ToDate (both parsed but unused).
                    var targets = db.WorkTimes.Where(w => w.DoctorId == DoctorId.Value);
                    db.WorkTimes.RemoveRange(targets);
                    db.SaveChanges();

                    dynamic finalResult = null;

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefineWorkTimeX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                    var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                    var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                    var Description = x.HasValue("Description") ? x.GetValue<string>("Description") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : false;

                    if (DoctorId == null)
                        throw new Exception("کد پزشک وارد نشده است");
                    if (FromDate == null || ToDate == null)
                        throw new Exception("تاریخ وارد نشده است");

                    dynamic finalResult = null;

                    IEnumerable<dynamic> WeekDayTimes = x.GetValue<IEnumerable>("WeekDayTimes").OfType<dynamic>().Select(i => i).ToArray();
                    List<dynamic> WorkTime = new List<dynamic>();

                    foreach (dynamic day in WeekDayTimes)
                    {
                        WorkTime.Add(new { DoctorId = DoctorId, DayName = day.DayName, StartTime = (TimeSpan)day.StartTime, EndTime = (TimeSpan)day.EndTime, Description = "", IsDeleted = IsDeleted });
                    }

                    DateTime fromDate = FromDate.Value;
                    DateTime toDate = ToDate.Value;
                    var dates = new List<DateTime>();
                    for (var dt = fromDate; dt <= toDate; dt = dt.AddDays(1))
                    {
                        dates.Add(dt);
                    }

                    foreach (DateTime date in dates)
                        foreach (dynamic day in WorkTime)
                        {
                            if (date.DayOfWeek.ToString() == Convert.ToString(day.DayName))
                            {
                                TimeSpan startTime = day.StartTime;
                                TimeSpan endTime = day.EndTime;

                                if (IsDeleted == false)
                                {
                                    // "replace" pattern: soft-delete any exact
                                    // DoctorId+Date+StartTime+EndTime match, then
                                    // always insert a fresh row - preserved as-is.
                                    var exactMatches = db.WorkTimes
                                                       .Where(w => w.DoctorId == DoctorId.Value && w.Date == date.Date)
                                                       .AsEnumerable() // از اینجا به بعد در حافظه اجرا میشه
                                                       .Where(w => w.StartTime == startTime && w.EndTime == endTime);
                                    foreach (var m in exactMatches)
                                        m.IsDeleted = true;

                                    db.WorkTimes.Add(new WorkTime
                                    {
                                        DoctorId = DoctorId.Value,
                                        Date = date.Date,
                                        StartTime = startTime,
                                        EndTime = endTime,
                                        Description = "",
                                        IsDeleted = false
                                    });
                                }
                                else
                                {
                                    // range-contained match gets soft-deleted, no
                                    // insert - preserved as-is.
                                    var rangeMatches = db.WorkTimes
                                                        .Where(w => w.DoctorId == DoctorId.Value && w.Date == date.Date)
                                                        .AsEnumerable()
                                                        .Where(w => w.StartTime >= startTime && w.EndTime <= endTime);
                                    foreach (var m in rangeMatches)
                                        m.IsDeleted = true;
                                }

                                db.SaveChanges();
                            }
                        }

                    finalResult = 1;

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefineUserPermissionsX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var UserId = x.HasValue("UserId") ? x.GetValue<int>("UserId") : (int?)null;
                    var AppActionIds = x.HasValue("AppActionIds") ? x.GetValue<IEnumerable>("AppActionIds").OfType<object>().Select(i => Convert.ToInt32(i)).ToArray() : null;

                    var Value = x.HasValue("Value") ? x.GetValue<bool>("Value") : (bool?)null;
                    var DefineDate = x.HasValue("DefineDate") ? x.GetValue<DateTime>("DefineDate") : DateTime.Now;

                    // NOTE: preserved from the original - this constructs an
                    // Exception but never throws it, so a missing UserId silently
                    // does nothing here.
                    if (UserId == null)
                    {
                        var _unused = new Exception("UserId وارد نشده است");
                    }
                    if (AppActionIds == null || AppActionIds.Count() < 1)
                        throw new Exception(" AppActionId وارد نشده است");

                    // NOTE / BUG (preserved as-is, flagged): the original SQL's
                    // INSERT hardcoded "Value = 1" for every row - the actual @Value
                    // parameter was bound but never referenced anywhere in the
                    // query. That means this function can only ever grant the
                    // listed permissions, never revoke them (passing Value=false
                    // has no effect) - please confirm with the team whether that's
                    // intentional.
                    var existing = db.UserPermissions.Where(up => up.UserId == UserId);
                    db.UserPermissions.RemoveRange(existing);

                    foreach (var appActionId in AppActionIds)
                    {
                        db.UserPermissions.Add(new UserPermission
                        {
                            UserId = UserId.Value,
                            AppActionId = appActionId,
                            Value = true
                        });
                    }

                    db.SaveChanges();

                    transactionScope.Commit();

                    return new JsonResponse<dynamic>() { Success = true, Data = true };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        // The original accepted an optional SQLiteTransaction so callers (like
        // DefineServiceX) could fold this insert into their own transaction
        // instead of opening a separate one. The EF equivalent of that is an
        // optional shared DentalContext: when the caller passes one, this
        // function adds to it and calls SaveChanges() but leaves commit/rollback
        // to the caller; when called standalone (externalDb == null), it opens
        // and manages its own context + transaction, same as before.
        public static JsonResponse<dynamic> DefineInsurersPricingX(dynamic searchObj, DentalContext externalDb = null)
        {
            var db = externalDb ?? new DentalContext();
            var ownsContext = externalDb == null;
            System.Data.Entity.DbContextTransaction transactionScope = null;
            if (ownsContext)
                transactionScope = db.Database.BeginTransaction();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var ServiceId = x.HasValue("ServiceId") ? x.GetValue<int>("ServiceId") : (int?)null;
                var InsurerIds = x.HasValue("InsurerIds") ? x.GetValue<IEnumerable>("InsurerIds").OfType<object>().Select(i => Convert.ToInt32(i)).ToArray() : null;
                var FreePrice = x.HasValue("FreePrice") ? x.GetValue<double>("FreePrice") : (double?)null;
                var InsurerPrice = x.HasValue("InsurerPrice") ? x.GetValue<double>("InsurerPrice") : (double?)null;
                var DefineDate = x.HasValue("DefineDate") ? x.GetValue<DateTime>("DefineDate") : DateTime.Now;
                var RunDate = x.HasValue("RunDate") ? x.GetValue<DateTime>("RunDate") : DateTime.Now;

                if (ServiceId == null)
                    throw new Exception(" خدمت انتخاب نشده است");
                if (InsurerIds == null || InsurerIds.Count() < 1)
                    throw new Exception(" بیمه گر انتخاب نشده است");

                // original inserted one row per matching Insurers.Id in InsurerIds
                // (via "WHERE Id IN {0}") - only ids that actually exist as
                // insurers produce a row, same as here.
                var matchingInsurerIds = db.Insurers
                    .Where(insr => InsurerIds.Contains(insr.Id))
                    .Select(insr => insr.Id)
                    .ToList();

                InsurerServiceTarefeChange lastAdded = null;
                foreach (var insurerId in matchingInsurerIds)
                {
                    var tarefe = new InsurerServiceTarefeChange
                    {
                        InsurerId = insurerId,
                        ServiceId = ServiceId.Value,
                        DefineDate = DefineDate,
                        RunDate = RunDate,
                        FreePrice = (decimal?)FreePrice,
                        InsurerPrice = (decimal?)InsurerPrice,
                        UserId = null
                    };
                    db.InsurerServiceTarefeChanges.Add(tarefe);
                    lastAdded = tarefe;
                }

                db.SaveChanges();

                var id = lastAdded != null ? lastAdded.Id : 0;

                if (ownsContext)
                    transactionScope.Commit();

                var finalResult = new { Id = id };

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                if (ownsContext)
                    transactionScope.Rollback();
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
            finally
            {
                if (ownsContext)
                {
                    transactionScope?.Dispose();
                    db.Dispose();
                }
            }
        }

        public static JsonResponse<dynamic> RemovePatientFromDatabaseX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;

                    if (PatientId == null)
                        throw new Exception("PatientId Not Find");

                    // hard DELETE (not soft-delete), same six tables the original
                    // touched - PatientTeeth, PatientInsurances, Visits, and
                    // PatientFollowups are NOT cleaned up here, same as the
                    // original, so rows in those tables can be left referencing a
                    // since-deleted PatientId. Worth flagging to the team, but
                    // reproduced exactly as the original scoped it.
                    db.PatientServices.RemoveRange(db.PatientServices.Where(ps => ps.PatientId == PatientId));
                    db.PatientDocuments.RemoveRange(db.PatientDocuments.Where(pd => pd.PatientId == PatientId));
                    db.PatientFinancials.RemoveRange(db.PatientFinancials.Where(pf => pf.PatientId == PatientId));
                    db.PatientSpecialComments.RemoveRange(db.PatientSpecialComments.Where(psc => psc.PatientId == PatientId));
                    db.PatientSpecialDrugs.RemoveRange(db.PatientSpecialDrugs.Where(psd => psd.PatientId == PatientId));
                    db.PatientSpecialDiseases.RemoveRange(db.PatientSpecialDiseases.Where(psd => psd.PatientId == PatientId));

                    var patient = db.Patients.FirstOrDefault(p => p.Id == PatientId.Value);
                    if (patient != null)
                        db.Patients.Remove(patient);

                    db.SaveChanges();

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = true };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = false, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> GetBaseCodingX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var EntityName = x.HasValue("EntityName") ? x.GetValue<string>("EntityName") : null;
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var Title = x.HasValue("Title") ? x.GetValue<string>("Title") : null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                if (EntityName == null)
                    throw new Exception("EntityName IS NULL");

                Type entityType;
                if (!_baseCodingTypeMap.TryGetValue(EntityName, out entityType))
                    throw new Exception("EntityName نامعتبر است: " + EntityName);

                using (var db = new DentalContext())
                {
                    // Entity type is only known at run time (it comes from the
                    // caller as a string), so LINQ can't be written against it at
                    // compile time. db.Set(Type) + reflection mirrors what the
                    // original did with "SELECT * FROM {EntityName}".
                    var idProp = entityType.GetProperty("Id");
                    var titleProp = entityType.GetProperty("Title");
                    var isDeletedProp = entityType.GetProperty("IsDeleted");
                    var codeProp = entityType.GetProperty("Code");
                    // NOTE: the original read "i.Terminology", but the real column
                    // (and the model property) is "TerminologyId" - "Terminology"
                    // doesn't exist, so the original threw on every call. Fixed here.
                    var terminologyProp = entityType.GetProperty("TerminologyId");
                    var descriptionProp = entityType.GetProperty("Description");
                    var colorProp = entityType.GetProperty("Color");

                    // Materialized to a plain in-memory list before filtering: the
                    // Where clauses below call GetValue() via reflection, which EF's
                    // query provider can't translate to SQL against an IQueryable.
                    IEnumerable<object> items = ((System.Collections.IEnumerable)db.Set(entityType)).Cast<object>().ToList();

                    if (Id != null)
                        items = items.Where(i => (int)idProp.GetValue(i) == Id.Value);
                    if (Title != null)
                        items = items.Where(i => (string)titleProp.GetValue(i) == Title);
                    if (IsDeleted != null)
                        items = items.Where(i => (bool)isDeletedProp.GetValue(i) == IsDeleted.Value);

                    var resultList = items
                        .OrderBy(i => (int)idProp.GetValue(i))
                        .Select(i => new
                        {
                            Id = (int)idProp.GetValue(i),
                            Code = codeProp.GetValue(i) as string,
                            Title = titleProp.GetValue(i) as string,
                            Terminology = (terminologyProp.GetValue(i) as string) ?? "",
                            IsDeleted = (bool)isDeletedProp.GetValue(i),
                            Comment = (descriptionProp.GetValue(i) as string) ?? "",
                            Color = ParseColor(colorProp?.GetValue(i)),
                        })
                        .ToList<dynamic>();

                    return new JsonResponse<dynamic>() { Success = true, Data = resultList };
                }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static string GetSettings()
        {
            try
            {
                using (var db = new DentalContext())
                {
                    var office = db.Offices.FirstOrDefault(o => o.Id == 1);
                    return office?.BackupPath;
                }
            }
            catch (Exception ex)
            {
                return "Error";
            }
        }

        public static JsonResponse<dynamic> DefinePatientX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                    var FirstName = x.HasValue("FirstName") ? x.GetValue<string>("FirstName") : null;
                    var LastName = x.HasValue("LastName") ? x.GetValue<string>("LastName") : null;
                    var FatherName = x.HasValue("FatherName") ? x.GetValue<string>("FatherName") : null;
                    var NationalCode = x.HasValue("NationalCode") ? x.GetValue<string>("NationalCode") : null;
                    var GenderId = x.HasValue("GenderId") ? x.GetValue<int>("GenderId") : (int?)null;
                    var BirthDate = x.HasValue("BirthDate") ? x.GetValue<DateTime>("BirthDate") : (DateTime?)null;
                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var JobId = x.HasValue("JobId") ? x.GetValue<int>("JobId") : (int?)null;
                    var Presenter = x.HasValue("Presenter") ? x.GetValue<string>("Presenter") : null;
                    var MaritalStatusId = x.HasValue("MaritalStatusId") ? x.GetValue<int>("MaritalStatusId") : (int?)null;
                    var EducationLevelId = x.HasValue("EducationLevelId") ? x.GetValue<int>("EducationLevelId") : (int?)null;
                    var NationalityId = x.HasValue("NationalityId") ? x.GetValue<int>("NationalityId") : (int?)null;
                    var FixedPhone = x.HasValue("FixedPhone") ? x.GetValue<string>("FixedPhone") : null;
                    var MobilePhone = x.HasValue("MobilePhone") ? x.GetValue<string>("MobilePhone") : null;
                    var Address = x.HasValue("Address") ? x.GetValue<string>("Address") : null;
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                    if (NationalCode != null)
                    {
                        var exists = db.Patients.Any(p => p.NationalCode == NationalCode
                            && (PatientId == null || p.Id != PatientId.Value));
                        if (exists)
                            return new JsonResponse<dynamic>() { Success = false, Data = null, Message = "بیماری با این کد ملی وجود دارد" };
                    }

                    int patientId;

                    if (ActionType == "New")
                    {
                        var patient = new Patient
                        {
                            DoctorId = DoctorId ?? 0,
                            FirstName = FirstName,
                            LastName = LastName,
                            FatherName = FatherName,
                            NationalCode = NationalCode,
                            GenderId = GenderId ?? 0,
                            BirthDate = BirthDate,
                            // "Date" is non-nullable on the model - original bound NULL
                            // when absent, which would have failed either way; defaulting
                            // to now avoids a guaranteed crash while keeping the same intent.
                            Date = Date ?? DateTime.Now,
                            JobId = JobId,
                            Presenter = Presenter,
                            MaritalStatusId = MaritalStatusId,
                            EducationLevelId = EducationLevelId,
                            NationalityId = NationalityId ?? 0,
                            FixedPhone = FixedPhone,
                            MobilePhone = MobilePhone,
                            Address = Address,
                            Comment = Comment
                        };
                        db.Patients.Add(patient);
                        db.SaveChanges();
                        patientId = (int)patient.Id;
                    }
                    else if (ActionType == "Edit")
                    {
                        if (PatientId == null)
                            throw new Exception("Id وارد نشده است");

                        var patient = db.Patients.FirstOrDefault(p => p.Id == PatientId.Value);
                        if (patient == null)
                            throw new Exception("Patient not found");

                        if (DoctorId != null) patient.DoctorId = DoctorId.Value;
                        if (FirstName != null) patient.FirstName = FirstName;
                        if (LastName != null) patient.LastName = LastName;
                        if (FatherName != null) patient.FatherName = FatherName;
                        if (NationalCode != null) patient.NationalCode = NationalCode;
                        if (GenderId != null) patient.GenderId = GenderId.Value;
                        if (BirthDate != null) patient.BirthDate = BirthDate;
                        if (Date != null) patient.Date = Date.Value;
                        if (JobId != null) patient.JobId = JobId;
                        if (Presenter != null) patient.Presenter = Presenter;
                        if (MaritalStatusId != null) patient.MaritalStatusId = MaritalStatusId;
                        if (EducationLevelId != null) patient.EducationLevelId = EducationLevelId;
                        if (NationalityId != null) patient.NationalityId = NationalityId.Value;
                        if (FixedPhone != null) patient.FixedPhone = FixedPhone;
                        if (MobilePhone != null) patient.MobilePhone = MobilePhone;
                        if (Address != null) patient.Address = Address;
                        if (Comment != null) patient.Comment = Comment;
                        if (IsDeleted != null) patient.IsDeleted = IsDeleted.Value;

                        db.SaveChanges();
                        patientId = PatientId.Value;
                    }
                    else
                    {
                        throw new Exception("ActionType نامعتبر است");
                    }

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = patientId };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefineStaffX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var Id = x.HasValue("StaffId") ? x.GetValue<int>("StaffId") : (int?)null;
                    var StaffTypeId = x.HasValue("StaffTypeId") ? x.GetValue<int>("StaffTypeId") : (int?)null;
                    var SpecialtyId = x.HasValue("SpecialtyId") ? x.GetValue<int>("SpecialtyId") : (int?)null;
                    var FirstName = x.HasValue("FirstName") ? x.GetValue<string>("FirstName") : null;
                    var LastName = x.HasValue("LastName") ? x.GetValue<string>("LastName") : null;
                    var NationalCode = x.HasValue("NationalCode") ? x.GetValue<string>("NationalCode") : null;
                    var MedicalCouncilCode = x.HasValue("MedicalCouncilCode") ? x.GetValue<string>("MedicalCouncilCode") : null;
                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var GenderId = x.HasValue("GenderId") ? x.GetValue<int>("GenderId") : (int?)null;
                    var FixedPhone = x.HasValue("FixedPhone") ? x.GetValue<string>("FixedPhone") : null;
                    var MobilePhone = x.HasValue("MobilePhone") ? x.GetValue<string>("MobilePhone") : null;
                    var Address = x.HasValue("Address") ? x.GetValue<string>("Address") : null;
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                    int staffId;

                    if (ActionType == "New")
                    {
                        var staff = new Staff
                        {
                            StaffTypeId = StaffTypeId ?? 0,
                            FirstName = FirstName,
                            LastName = LastName,
                            NationalCode = NationalCode,
                            MedicalCouncilCode = MedicalCouncilCode,
                            StaffSpecialtyId = SpecialtyId,
                            // Staff.Date is modelled as a string (kept as in the original model).
                            Date = Publics.ConvertDateTimeToString(Date),
                            GenderId = GenderId ?? 0,
                            FixedPhone = FixedPhone,
                            MobilePhone = MobilePhone,
                            Address = Address,
                            Comment = Comment
                        };
                        db.Staffs.Add(staff);
                        db.SaveChanges();
                        staffId = staff.Id;
                    }
                    else if (ActionType == "Edit")
                    {
                        if (Id == null)
                            throw new Exception("Id Is Not Define");

                        var staff = db.Staffs.FirstOrDefault(s => s.Id == Id.Value);
                        if (staff == null)
                            throw new Exception("Staff not found");

                        if (StaffTypeId != null) staff.StaffTypeId = StaffTypeId.Value;
                        if (FirstName != null) staff.FirstName = FirstName;
                        if (LastName != null) staff.LastName = LastName;
                        if (NationalCode != null) staff.NationalCode = NationalCode;
                        if (MedicalCouncilCode != null) staff.MedicalCouncilCode = MedicalCouncilCode;
                        if (SpecialtyId != null) staff.StaffSpecialtyId = SpecialtyId;
                        if (Date != null) staff.Date = Publics.ConvertDateTimeToString(Date);
                        if (GenderId != null) staff.GenderId = GenderId.Value;
                        if (FixedPhone != null) staff.FixedPhone = FixedPhone;
                        if (MobilePhone != null) staff.MobilePhone = MobilePhone;
                        if (Address != null) staff.Address = Address;
                        if (Comment != null) staff.Comment = Comment;
                        if (IsDeleted != null) staff.IsDeleted = IsDeleted.Value;

                        db.SaveChanges();
                        staffId = Id.Value;
                    }
                    else if (ActionType == "Delete")
                    {
                        if (Id == null)
                            throw new Exception("Id Is Not Define");

                        var staff = db.Staffs.FirstOrDefault(s => s.Id == Id.Value);
                        if (staff != null)
                            staff.IsDeleted = true;

                        var relatedUsers = db.Users.Where(u => u.StaffId == Id.Value);
                        foreach (var u in relatedUsers)
                            u.IsDeleted = true;

                        db.SaveChanges();
                        staffId = Id.Value;
                    }
                    else
                    {
                        throw new Exception("ActionType نامعتبر است");
                    }

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = new { StaffId = staffId } };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefineSpecialCommentX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var SpecialCommentTypeId = x.HasValue("SpecialCommentTypeId") ? x.GetValue<int>("SpecialCommentTypeId") : (int?)null;
                    var Title = x.HasValue("Title") ? x.GetValue<string>("Title") : null;
                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                    if (PatientId == null)
                        throw new Exception("کد بیمار وارد نشده است");

                    int id;

                    if (ActionType == "New")
                    {
                        var comment = new PatientSpecialComment
                        {
                            PatientId = PatientId.Value,
                            SpecialCommentTypeId = SpecialCommentTypeId ?? 0,
                            Title = Title,
                            Date = Date ?? DateTime.Now,
                            IsDeleted = IsDeleted ?? false
                        };
                        db.PatientSpecialComments.Add(comment);
                        db.SaveChanges();
                        id = comment.Id;
                    }
                    else if (ActionType == "Edit")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        var comment = db.PatientSpecialComments.FirstOrDefault(c => c.Id == Id.Value);
                        if (comment == null)
                            throw new Exception("PatientSpecialComment not found");

                        if (PatientId != null) comment.PatientId = PatientId.Value;
                        if (SpecialCommentTypeId != null) comment.SpecialCommentTypeId = SpecialCommentTypeId.Value;
                        if (Title != null) comment.Title = Title;
                        if (Date != null) comment.Date = Date.Value;
                        if (IsDeleted != null) comment.IsDeleted = IsDeleted.Value;

                        db.SaveChanges();
                        id = Id.Value;
                    }
                    else if (ActionType == "Delete")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        var comment = db.PatientSpecialComments.FirstOrDefault(c => c.Id == Id.Value);
                        if (comment != null)
                            db.PatientSpecialComments.Remove(comment);

                        db.SaveChanges();
                        id = Id.Value;
                    }
                    else
                    {
                        throw new Exception("ActionType نامعتبر است");
                    }

                    var finalResult = new { Id = id };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefineCostX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var CostTypeId = x.HasValue("CostTypeId") ? x.GetValue<int>("CostTypeId") : (int?)null;
                    var BargainSideId = x.HasValue("BargainSideId") ? x.GetValue<int>("BargainSideId") : (int?)null;
                    var PayTypeId = x.HasValue("PayTypeId") ? x.GetValue<int>("PayTypeId") : (int?)null;
                    var Amount = x.HasValue("Amount") ? x.GetValue<double>("Amount") : (double?)null;
                    var CostTitle = x.HasValue("CostTitle") ? x.GetValue<string>("CostTitle") : null;
                    var FactorNumber = x.HasValue("FactorNumber") ? x.GetValue<string>("FactorNumber") : null;
                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var ChequeNumber = x.HasValue("ChequeNumber") ? x.GetValue<string>("ChequeNumber") : null;
                    var BankId = x.HasValue("BankId") ? x.GetValue<int>("BankId") : (int?)null;
                    var ChequeStatusId = x.HasValue("ChequeStatusId") ? x.GetValue<int>("ChequeStatusId") : (int?)null;
                    var DateOfIssuance = x.HasValue("DateOfIssuance") ? x.GetValue<string>("DateOfIssuance") : null;
                    var DateOfMaturity = x.HasValue("DateOfMaturity") ? x.GetValue<string>("DateOfMaturity") : null;
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                    int id;

                    if (ActionType == "New" || ActionType == "Edit")
                    {
                        if (ActionType == "Edit" && Id == null)
                            throw new Exception("Id is Null");

                        // DateOfIssuance/DateOfMaturity arrive as pre-formatted strings
                        // (same as the original), but the model stores them as
                        // DateTime? - parsed via Publics.ConvertStringToDateTime, the
                        // counterpart to ConvertDateTimeToString used elsewhere.
                        // History/versioning pattern, same as the original: the old
                        // row (if any) is soft-deleted and a brand new row is always
                        // inserted, rather than updating in place.
                        if (Id != null)
                        {
                            var oldCost = db.Costs.FirstOrDefault(c => c.Id == Id.Value);
                            if (oldCost != null)
                                oldCost.IsDeleted = true;
                        }

                        var cost = new Cost
                        {
                            CostTypeId = CostTypeId ?? 0,
                            BargainSideId = BargainSideId,
                            PayTypeId = PayTypeId ?? 0,
                            Amount = (decimal)(Amount ?? 0),
                            Title = CostTitle,
                            FactorNumber = FactorNumber,
                            Date = Date ?? DateTime.Now,
                            ChequeNumber = ChequeNumber,
                            BankId = BankId,
                            ChequeStatusId = ChequeStatusId,
                            DateOfIssuance = Publics.ConvertStringToDateTime(DateOfIssuance),
                            DateOfMaturity = Publics.ConvertStringToDateTime(DateOfMaturity),
                            Comment = Comment,
                            IsDeleted = IsDeleted ?? false
                        };
                        db.Costs.Add(cost);
                        db.SaveChanges();
                        id = cost.Id;
                    }
                    else if (ActionType == "Delete")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        var cost = db.Costs.FirstOrDefault(c => c.Id == Id.Value);
                        if (cost != null)
                            cost.IsDeleted = true;

                        db.SaveChanges();
                        id = Id.Value;
                    }
                    else if (ActionType == "EditChequeStatus")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        var cost = db.Costs.FirstOrDefault(c => c.Id == Id.Value);
                        if (cost != null)
                            cost.ChequeStatusId = ChequeStatusId;

                        db.SaveChanges();
                        id = Id.Value;
                    }
                    else
                    {
                        throw new Exception("ActionType نامعتبر است");
                    }

                    var finalResult = new { Id = id };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefinePatientFinancialX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var PayTypeId = x.HasValue("PayTypeId") ? x.GetValue<int>("PayTypeId") : (int?)null;
                    var Amount = x.HasValue("Amount") ? x.GetValue<double>("Amount") : (double?)null;
                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var ChequeNumber = x.HasValue("ChequeNumber") ? x.GetValue<string>("ChequeNumber") : null;
                    var BankId = x.HasValue("BankId") ? x.GetValue<int>("BankId") : (int?)null;
                    var ChequeStatusId = x.HasValue("ChequeStatusId") ? x.GetValue<int>("ChequeStatusId") : (int?)null;
                    var DateOfIssuance = x.HasValue("DateOfIssuance") ? x.GetValue<string>("DateOfIssuance") : null;
                    var DateOfMaturity = x.HasValue("DateOfMaturity") ? x.GetValue<string>("DateOfMaturity") : null;
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                    int id;

                    if (ActionType == "New" || ActionType == "Edit")
                    {
                        if (ActionType == "Edit" && Id == null)
                            throw new Exception("Id is Null");

                        // Same history/versioning pattern as DefineCostX above.
                        if (Id != null)
                        {
                            var oldFinancial = db.PatientFinancials.FirstOrDefault(f => f.Id == Id.Value);
                            if (oldFinancial != null)
                                oldFinancial.IsDeleted = true;
                        }

                        var financial = new PatientFinancial
                        {
                            PatientId = PatientId ?? 0,
                            PayTypeId = PayTypeId ?? 0,
                            Amount = (decimal)(Amount ?? 0),
                            Date = Date ?? DateTime.Now,
                            ChequeNumber = ChequeNumber,
                            BankId = BankId,
                            ChequeStatusId = ChequeStatusId,
                            DateOfIssuance = Publics.ConvertStringToDateTime(DateOfIssuance),
                            DateOfMaturity = Publics.ConvertStringToDateTime(DateOfMaturity),
                            Comment = Comment,
                            IsDeleted = IsDeleted ?? false
                        };
                        db.PatientFinancials.Add(financial);
                        db.SaveChanges();
                        id = financial.Id;
                    }
                    else if (ActionType == "Delete")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        var financial = db.PatientFinancials.FirstOrDefault(f => f.Id == Id.Value);
                        if (financial != null)
                            financial.IsDeleted = true;

                        db.SaveChanges();
                        id = Id.Value;
                    }
                    else if (ActionType == "EditChequeStatus")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        var financial = db.PatientFinancials.FirstOrDefault(f => f.Id == Id.Value);
                        if (financial != null)
                            financial.ChequeStatusId = ChequeStatusId;

                        db.SaveChanges();
                        id = Id.Value;
                    }
                    else
                    {
                        throw new Exception("ActionType نامعتبر است");
                    }

                    var finalResult = new { Id = id };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefineUserX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var UserId = x.HasValue("UserId") ? x.GetValue<int>("UserId") : (int?)null;
                    var StaffId = x.HasValue("StaffId") ? x.GetValue<int>("StaffId") : (int?)null;
                    var UserName = x.HasValue("UserName") ? x.GetValue<string>("UserName") : null;
                    var UserPass = x.HasValue("UserPass") ? x.GetValue<string>("UserPass") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                    // User.Email is [Required] on the model, but this operation
                    // (same as the original SQL) never supplies one. Validation is
                    // disabled for this save only, so behavior matches the original
                    // (no Email column in the original INSERT/UPDATE either).
                    db.Configuration.ValidateOnSaveEnabled = false;

                    int userId;

                    if (UserId != null)
                    {
                        var user = db.Users.FirstOrDefault(u => u.Id == UserId.Value);
                        if (user == null)
                            throw new Exception("User not found");

                        if (UserName != null) user.UserName = UserName;
                        if (UserPass != null) user.UserPass = UserPass;
                        if (IsDeleted != null) user.IsDeleted = IsDeleted.Value;

                        db.SaveChanges();
                        userId = UserId.Value;
                    }
                    else
                    {
                        var user = new User
                        {
                            StaffId = StaffId,
                            UserName = UserName,
                            UserPass = UserPass,
                            IsDeleted = IsDeleted ?? false
                        };
                        db.Users.Add(user);
                        db.SaveChanges();
                        userId = user.Id;
                    }

                    var finalResult = new { UserId = userId };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefineInsurerFinancialsX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var InsurerId = x.HasValue("InsurerId") ? x.GetValue<int>("InsurerId") : (int?)null;
                    var RequestedValue = x.HasValue("RequestedValue") ? x.GetValue<double>("RequestedValue") : (double?)null;
                    var ReceivedValue = x.HasValue("ReceivedValue") ? x.GetValue<double>("ReceivedValue") : (double?)null;
                    var DeductionValue = x.HasValue("DeductionValue") ? x.GetValue<double>("DeductionValue") : (double?)null;
                    var RemainPrice = x.HasValue("RemainPrice") ? x.GetValue<double>("RemainPrice") : (double?)null;
                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                    var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                    int id;

                    if (Id != null)
                    {
                        var financial = db.InsurerFinancials.FirstOrDefault(f => f.Id == Id.Value);
                        if (financial == null)
                            throw new Exception("InsurerFinancial not found");

                        if (InsurerId != null) financial.InsurerId = InsurerId.Value;
                        if (RequestedValue != null) financial.RequestedValue = (decimal)RequestedValue.Value;
                        if (ReceivedValue != null) financial.ReceivedValue = (decimal)ReceivedValue.Value;
                        if (DeductionValue != null) financial.DeductionValue = (decimal)DeductionValue.Value;
                        if (RemainPrice != null) financial.RemainPrice = (decimal)RemainPrice.Value;
                        if (Date != null) financial.Date = Date.Value;
                        if (FromDate != null) financial.FromDate = FromDate;
                        if (ToDate != null) financial.ToDate = ToDate;
                        if (Comment != null) financial.Comment = Comment;
                        if (IsDeleted != null) financial.IsDeleted = IsDeleted;

                        db.SaveChanges();
                        id = Id.Value;
                    }
                    else
                    {
                        var financial = new InsurerFinancial
                        {
                            InsurerId = InsurerId ?? 0,
                            RequestedValue = (decimal)(RequestedValue ?? 0),
                            ReceivedValue = (decimal?)ReceivedValue,
                            DeductionValue = (decimal?)DeductionValue,
                            RemainPrice = (decimal?)RemainPrice,
                            Date = Date ?? DateTime.Now,
                            FromDate = FromDate,
                            ToDate = ToDate,
                            Comment = Comment,
                            IsDeleted = IsDeleted ?? false
                        };
                        db.InsurerFinancials.Add(financial);
                        db.SaveChanges();
                        id = financial.Id;
                    }

                    var finalResult = new { InsurerFinancialId = id };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefinePatientDocumentX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var DocId = x.HasValue("DocId") ? x.GetValue<int>("DocId") : (int?)null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var Title = x.HasValue("Title") ? x.GetValue<string>("Title") : null;
                    var ImagePath = x.HasValue("ImagePath") ? x.GetValue<string>("ImagePath") : null;
                    var Image = x.HasValue("Image") ? x.GetValue<byte[]>("Image") : null;
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                    int id;

                    if (DocId != null)
                    {
                        var doc = db.PatientDocuments.FirstOrDefault(d => d.Id == DocId.Value);
                        if (doc == null)
                            throw new Exception("PatientDocument not found");

                        if (PatientId != null) doc.PatientId = PatientId.Value;
                        if (Date != null) doc.Date = Date.Value;
                        if (Title != null) doc.Title = Title;
                        if (ImagePath != null) doc.ImagePath = ImagePath;
                        if (Image != null) doc.Image = Image;
                        if (Comment != null) doc.Comment = Comment;
                        if (IsDeleted != null) doc.IsDeleted = IsDeleted.Value;
                        // NOTE: the original also set "ModifiedDate" here, but that
                        // column doesn't exist on PatientDocuments (verified against
                        // the real schema) - dropped as dead/broken code.

                        db.SaveChanges();
                        id = DocId.Value;
                    }
                    else
                    {
                        var doc = new PatientDocument
                        {
                            PatientId = PatientId ?? 0,
                            Date = Date ?? DateTime.Now,
                            Title = Title,
                            ImagePath = ImagePath,
                            Image = Image,
                            Comment = Comment,
                            IsDeleted = IsDeleted ?? false
                        };
                        db.PatientDocuments.Add(doc);
                        db.SaveChanges();
                        id = doc.Id;
                    }

                    // NOTE: property kept as "InsuranceId" to match the original's
                    // (mislabeled) result key, in case the caller depends on it.
                    var finalResult = new { InsuranceId = id };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefinePatientFollowUpsX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var FollowUpDate = x.HasValue("FollowUpDate") ? x.GetValue<DateTime>("FollowUpDate") : (DateTime?)null;
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                    int id = 0;

                    if (ActionType == "Edit")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        var followUp = db.PatientFollowups.FirstOrDefault(f => f.Id == Id.Value);
                        if (followUp == null)
                            throw new Exception("PatientFollowup not found");

                        if (DoctorId != null) followUp.DoctorId = DoctorId.Value;
                        if (PatientId != null) followUp.PatientId = PatientId.Value;
                        if (Date != null) followUp.Date = Date.Value;
                        if (FollowUpDate != null) followUp.FollowupDate = FollowUpDate;
                        if (Comment != null) followUp.Comment = Comment;
                        if (IsDeleted != null) followUp.IsDeleted = IsDeleted;

                        db.SaveChanges();
                        id = Id.Value;
                    }
                    else if (ActionType == "New")
                    {
                        var followUp = new PatientFollowup
                        {
                            DoctorId = DoctorId ?? 0,
                            PatientId = PatientId ?? 0,
                            Date = Date ?? DateTime.Now,
                            FollowupDate = FollowUpDate,
                            Comment = Comment,
                            IsDeleted = IsDeleted ?? false
                        };
                        db.PatientFollowups.Add(followUp);
                        db.SaveChanges();
                        id = followUp.Id;
                    }
                    else if (ActionType == "Delete")
                    {
                        // preserved as-is - the original had an empty branch here too,
                        // so "Delete" is currently a no-op.
                    }

                    var finalResult = new { MessageId = id };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefinePatientInsuranceX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    // NOTE: ActionType is read by the original too but never actually
                    // branched on - this always soft-deletes the patient's existing
                    // insurance rows and inserts a fresh one. Preserved as-is.
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var InsurerId = x.HasValue("InsurerId") ? x.GetValue<int>("InsurerId") : (int?)null;
                    var InsuranceTypeId = x.HasValue("InsuranceTypeId") ? x.GetValue<int>("InsuranceTypeId") : 1;
                    var ExpirationDate = x.HasValue("ExpirationDate") ? x.GetValue<DateTime>("ExpirationDate") : (DateTime?)null;
                    var InsuredNumber = x.HasValue("InsuredNumber") ? x.GetValue<string>("InsuredNumber") : null;
                    var InsuranceBookletSerialNumber = x.HasValue("InsuranceBookletSerialNumber") ? x.GetValue<string>("InsuranceBookletSerialNumber") : null;
                    var Percent = x.HasValue("Percent") ? x.GetValue<float>("Percent") : (float?)null;
                    var MaxPay = x.HasValue("MaxPay") ? x.GetValue<float>("MaxPay") : (float?)null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                    if (PatientId != null)
                    {
                        var existing = db.PatientInsurances.Where(pi => pi.PatientId == PatientId.Value);
                        foreach (var pi in existing)
                            pi.IsDeleted = true;
                    }

                    var insurance = new PatientInsurance
                    {
                        InsurerId = InsurerId ?? 0,
                        PatientId = PatientId ?? 0,
                        InsuranceTypeId = InsuranceTypeId,
                        InsuredNumber = InsuredNumber,
                        InsuranceBookletSerialNumber = InsuranceBookletSerialNumber,
                        ExpirationDate = ExpirationDate,
                        // Percent is non-nullable int on the model.
                        Percent = (int)(Percent ?? 0),
                        MaxPay = (double?)MaxPay,
                        IsDeleted = IsDeleted ?? false
                    };
                    db.PatientInsurances.Add(insurance);
                    db.SaveChanges();
                    var id = insurance.Id;

                    var finalResult = new { Id = (Id != null) ? Id.Value : id };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefineInsurerX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var InsuranceId = x.HasValue("InsuranceId") ? x.GetValue<int>("InsuranceId") : (int?)null;
                    var InsuranceBoxId = x.HasValue("InsuranceBoxId") ? x.GetValue<int>("InsuranceBoxId") : (int?)null;
                    var Title = x.HasValue("InsurerTitle") ? x.GetValue<string>("InsurerTitle") : null;
                    var InsurerPercent = x.HasValue("InsurerPercent") ? x.GetValue<int>("InsurerPercent") : (int?)null;
                    var IsBasic = x.HasValue("IsBasic") ? x.GetValue<bool>("IsBasic") : (bool?)null;
                    var IsExtra = x.HasValue("IsExtra") ? x.GetValue<bool>("IsExtra") : (bool?)null;
                    var StartDate = x.HasValue("StartDate") ? x.GetValue<DateTime>("StartDate") : (DateTime?)null;
                    var EndDate = x.HasValue("EndDate") ? x.GetValue<DateTime>("EndDate") : (DateTime?)null;
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                    if (ActionType == "Edit" && Id == null)
                        throw new Exception("Id وارد نشده است");

                    // History/versioning pattern, same as DefineCostX: soft-delete the
                    // old row (New has nothing to soft-delete, matching the original's
                    // Id = -1 sentinel), then always insert a fresh row.
                    if (ActionType == "Edit" && Id != null)
                    {
                        var oldInsurer = db.Insurers.FirstOrDefault(i => i.Id == Id.Value);
                        if (oldInsurer != null)
                            oldInsurer.IsDeleted = true;
                    }

                    var insurer = new Insurer
                    {
                        InsuranceId = InsuranceId,
                        InsuranceBoxId = InsuranceBoxId,
                        Title = Title,
                        InsurerPercent = InsurerPercent,
                        IsBasic = IsBasic,
                        IsExtra = IsExtra,
                        // BUGFIX: the original bound both StartDate and EndDate
                        // parameters to the IsDeleted value (copy-paste bug), which
                        // isn't type-safe against a DateTime column in EF. Corrected
                        // to use the actual StartDate/EndDate values.
                        StartDate = StartDate,
                        EndDate = EndDate,
                        Comment = Comment,
                        IsDeleted = IsDeleted
                    };
                    db.Insurers.Add(insurer);
                    db.SaveChanges();
                    var id = insurer.Id;

                    var finalResult = new { Id = (Id != null) ? Id.Value : id };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefinePatientSpecialDiseasesX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var SpecialDiseasId = x.HasValue("SpecialDiseasId") ? x.GetValue<int>("SpecialDiseasId") : (int?)null;

                    if (ActionType == "New")
                    {
                        var exists = db.PatientSpecialDiseases.Any(d => d.PatientId == PatientId && d.SpecialDiseasId == SpecialDiseasId);
                        if (!exists)
                        {
                            db.PatientSpecialDiseases.Add(new PatientSpecialDisease
                            {
                                PatientId = PatientId ?? 0,
                                SpecialDiseasId = SpecialDiseasId ?? 0
                            });
                            db.SaveChanges();
                        }
                    }
                    else if (ActionType == "Delete")
                    {
                        var record = db.PatientSpecialDiseases.FirstOrDefault(d => d.PatientId == PatientId && d.SpecialDiseasId == SpecialDiseasId);
                        if (record != null)
                        {
                            db.PatientSpecialDiseases.Remove(record);
                            db.SaveChanges();
                        }
                    }

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = true };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefinePatientSpecialDrugX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var SpecialDrugId = x.HasValue("SpecialDrugId") ? x.GetValue<int>("SpecialDrugId") : (int?)null;

                    if (ActionType == "New")
                    {
                        var exists = db.PatientSpecialDrugs.Any(d => d.PatientId == PatientId && d.SpecialDrugId == SpecialDrugId);
                        if (!exists)
                        {
                            db.PatientSpecialDrugs.Add(new PatientSpecialDrug
                            {
                                PatientId = PatientId ?? 0,
                                SpecialDrugId = SpecialDrugId ?? 0
                            });
                            db.SaveChanges();
                        }
                    }
                    else if (ActionType == "Delete")
                    {
                        var record = db.PatientSpecialDrugs.FirstOrDefault(d => d.PatientId == PatientId && d.SpecialDrugId == SpecialDrugId);
                        if (record != null)
                        {
                            db.PatientSpecialDrugs.Remove(record);
                            db.SaveChanges();
                        }
                    }

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = true };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefineOfficeX(dynamic searchObj)
        {
            using (var db = new DentalContext())
            using (var transactionScope = db.Database.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var OfficeName = x.HasValue("OfficeName") ? x.GetValue<string>("OfficeName") : null;
                    var DoctorName = x.HasValue("DoctorName") ? x.GetValue<string>("DoctorName") : null;
                    var OfficeCode = x.HasValue("OfficeCode") ? x.GetValue<string>("OfficeCode") : null;
                    var OfficeType = x.HasValue("OfficeType") ? x.GetValue<string>("OfficeType") : null;
                    var NezamPezeshki = x.HasValue("NezamPezeshki") ? x.GetValue<string>("NezamPezeshki") : null;
                    var PhoneNumber = x.HasValue("PhoneNumber") ? x.GetValue<string>("PhoneNumber") : null;
                    var OfficeAddress = x.HasValue("OfficeAddress") ? x.GetValue<string>("OfficeAddress") : null;
                    var Email = x.HasValue("Email") ? x.GetValue<string>("Email") : null;
                    var Website = x.HasValue("Website") ? x.GetValue<string>("Website") : null;
                    var DefaultDoctorId = x.HasValue("DefaultDoctorId") ? x.GetValue<int>("DefaultDoctorId") : (int?)null;
                    var DefaultBasicInsurerId = x.HasValue("DefaultBasicInsurerId") ? x.GetValue<int>("DefaultBasicInsurerId") : (int?)null;
                    var DefaultMaritalStatusId = x.HasValue("DefaultMaritalStatusId") ? x.GetValue<int>("DefaultMaritalStatusId") : (int?)null;
                    var DefaultEducationLevelId = x.HasValue("DefaultEducationLevelId") ? x.GetValue<int>("DefaultEducationLevelId") : (int?)null;
                    var DefaultNationalityId = x.HasValue("DefaultNationalityId") ? x.GetValue<int>("DefaultNationalityId") : (int?)null;
                    var Date = x.HasValue("ModifiedDate") ? x.GetValue<DateTime>("ModifiedDate") : DateTime.Now;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                    int id;

                    if (ActionType == "Edit")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        var office = db.Offices.FirstOrDefault(o => o.Id == Id.Value);
                        if (office == null)
                            throw new Exception("Office not found");

                        if (OfficeName != null) office.OfficeName = OfficeName;
                        if (DoctorName != null) office.DoctorName = DoctorName;
                        if (OfficeCode != null) office.OfficeCode = OfficeCode;
                        if (OfficeType != null) office.OfficeType = OfficeType;
                        if (NezamPezeshki != null) office.NezamPezeshki = NezamPezeshki;
                        if (PhoneNumber != null) office.PhoneNumber = PhoneNumber;
                        if (OfficeAddress != null) office.OfficeAddress = OfficeAddress;
                        if (Email != null) office.Email = Email;
                        if (Website != null) office.Website = Website;
                        if (DefaultDoctorId != null) office.DefaultDoctorId = DefaultDoctorId;
                        if (DefaultBasicInsurerId != null) office.DefaultBasicInsurerId = DefaultBasicInsurerId;
                        if (DefaultMaritalStatusId != null) office.DefaultMaritalStatusId = DefaultMaritalStatusId;
                        if (DefaultEducationLevelId != null) office.DefaultEducationLevelId = DefaultEducationLevelId;
                        if (DefaultNationalityId != null) office.DefaultNationalityId = DefaultNationalityId;
                        office.ModifiedDate = Date;
                        if (IsDeleted != null) office.IsDeleted = IsDeleted;

                        db.SaveChanges();
                        id = Id.Value;
                    }
                    else if (ActionType == "New")
                    {
                        var office = new Office
                        {
                            OfficeName = OfficeName,
                            DoctorName = DoctorName,
                            OfficeCode = OfficeCode,
                            OfficeType = OfficeType,
                            NezamPezeshki = NezamPezeshki,
                            PhoneNumber = PhoneNumber,
                            OfficeAddress = OfficeAddress,
                            Email = Email,
                            Website = Website,
                            DefaultDoctorId = DefaultDoctorId,
                            // BUGFIX: the original's INSERT column list included
                            // DefaultBasicInsurerId but the VALUES list omitted it
                            // (a column-count mismatch bug) - included here.
                            DefaultBasicInsurerId = DefaultBasicInsurerId,
                            DefaultMaritalStatusId = DefaultMaritalStatusId,
                            DefaultEducationLevelId = DefaultEducationLevelId,
                            DefaultNationalityId = DefaultNationalityId,
                            ModifiedDate = Date,
                            IsDeleted = IsDeleted ?? false
                        };
                        db.Offices.Add(office);
                        db.SaveChanges();
                        id = office.Id;
                    }
                    else
                    {
                        // "Delete" (and any other ActionType) was a no-op in the
                        // original too - preserved as-is.
                        id = Id ?? 0;
                    }

                    var finalResult = new { MessageId = id };

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefineBaseCodingX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var ActionName = x.HasValue("ActionName") ? x.GetValue<string>("ActionName") : null;
                var EntityName = x.HasValue("EntityName") ? x.GetValue<string>("EntityName") : null;
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var Title = x.HasValue("Title") ? x.GetValue<string>("Title") : null;
                var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;
                var BankId = x.HasValue("BankId") ? x.GetValue<int>("BankId") : (int?)null;
                var Color = x.HasValue("Color") ? x.GetValue<int>("Color") : (int?)null;

                if (EntityName == null)
                    throw new Exception("EntityName IS NULL");

                Type entityType;
                if (!_baseCodingTypeMap.TryGetValue(EntityName, out entityType))
                    throw new Exception("EntityName نامعتبر است: " + EntityName);

                using (var db = new DentalContext())
                using (var transactionScope = db.Database.BeginTransaction())
                    try
                    {
                        var idProp = entityType.GetProperty("Id");
                        var titleProp = entityType.GetProperty("Title");
                        var isDeletedProp = entityType.GetProperty("IsDeleted");
                        var colorProp = entityType.GetProperty("Color");
                        // NOTE: no BaseCoding subtype actually has a "BankId" scalar
                        // property (Bank's own extra columns are ConnectionType/
                        // PortName/BoundRate) - kept for parity with the original's
                        // parameter, applied via reflection only if a matching
                        // property exists on the resolved type.
                        var bankIdProp = entityType.GetProperty("BankId");

                        // Same reasoning as GetBaseCodingX: materialize first so the
                        // reflection-based lookups below run in-memory, not as part
                        // of a SQL translation.
                        var allRows = db.Set(entityType).Cast<object>().ToList();

                        object entity;
                        int id;

                        if (Id != null)
                        {
                            entity = db.Set(entityType).Find(Id.Value);
                            if (entity == null)
                                throw new Exception("رکورد یافت نشد");

                            if (Title != null) titleProp.SetValue(entity, Title);
                            if (IsDeleted != null) isDeletedProp.SetValue(entity, IsDeleted.Value);
                            if (Color != null && colorProp != null) colorProp.SetValue(entity, Color.Value.ToString());
                            if (BankId != null && bankIdProp != null) bankIdProp.SetValue(entity, BankId.Value);

                            db.SaveChanges();
                            id = Id.Value;
                        }
                        else
                        {
                            var alreadyExists = allRows.Any(i => (string)titleProp.GetValue(i) == Title);

                            if (alreadyExists)
                            {
                                // original: "INSERT ... WHERE NOT EXISTS" - a duplicate
                                // Title silently inserts nothing. Mirrored here by
                                // returning the existing row's Id instead of inserting.
                                var existing = allRows.First(i => (string)titleProp.GetValue(i) == Title);
                                id = (int)idProp.GetValue(existing);
                            }
                            else
                            {
                                entity = Activator.CreateInstance(entityType);
                                titleProp.SetValue(entity, Title);
                                isDeletedProp.SetValue(entity, false);
                                if (Color != null && colorProp != null) colorProp.SetValue(entity, Color.Value.ToString());
                                if (BankId != null && bankIdProp != null) bankIdProp.SetValue(entity, BankId.Value);

                                db.Set(entityType).Add(entity);
                                db.SaveChanges();
                                id = (int)idProp.GetValue(entity);
                            }
                        }

                        transactionScope.Commit();
                        return new JsonResponse<dynamic>() { Success = true, Data = (Id != null) ? Id.Value : id };
                    }
                    catch (Exception ex)
                    {
                        transactionScope.Rollback();
                        return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                    }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> DeleteEntityX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var EntityTitle = x.HasValue("EntityTitle") ? x.GetValue<string>("EntityTitle") : null;
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;

                if (EntityTitle == null)
                    throw new Exception("موجودیت مشخص نشده است");

                if (Id == null)
                    throw new Exception("کلید مشخص نشده است");

                Type entityType;
                if (!_entityTypeMap.TryGetValue(EntityTitle, out entityType))
                    throw new Exception("موجودیت نامعتبر است: " + EntityTitle);

                using (var db = new DentalContext())
                using (var transactionScope = db.Database.BeginTransaction())
                    try
                    {
                        var entity = db.Set(entityType).Find(Id.Value);
                        if (entity != null)
                            db.Set(entityType).Remove(entity);

                        db.SaveChanges();
                        transactionScope.Commit();
                        return new JsonResponse<dynamic>() { Success = true, Data = true };
                    }
                    catch (Exception ex)
                    {
                        transactionScope.Rollback();
                        return new JsonResponse<dynamic>() { Success = false, Data = false, Message = ex.Message, };
                    }
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = false, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> DataBaseBackupX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var databaseFileName = x.HasValue("DatabaseFileName") ? x.GetValue<string>("DatabaseFileName") : null;
                var databaseFilePath = x.HasValue("DatabaseFilePath") ? x.GetValue<string>("DatabaseFilePath") : null;
                var backupFileName = x.HasValue("BackupFileName") ? x.GetValue<string>("BackupFileName") : null;
                var backupFilePath = x.HasValue("BackupFilePath") ? x.GetValue<string>("BackupFilePath") : null;

                var srcFile = Path.Combine(databaseFilePath, databaseFileName);
                var destFile = Path.Combine(backupFilePath, backupFileName);

                if (File.Exists(destFile))
                    File.Delete(destFile);

                SQLiteConnection.ClearAllPools();
                File.Copy(srcFile, destFile);

                return new JsonResponse<dynamic>() { Success = true, Data = 1 };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> DataBaseRestoreX(dynamic searchObj)
        {
            try
            {
                var x = new RouteValueDictionary(searchObj);
                var databaseFileName = x.HasValue("DatabaseFileName") ? x.GetValue<string>("DatabaseFileName") : null;
                var databaseFilePath = x.HasValue("DatabaseFilePath") ? x.GetValue<string>("DatabaseFilePath") : null;
                var restoreFileName = x.HasValue("RestoreFileName") ? x.GetValue<string>("RestoreFileName") : null;
                var restoreFilePath = x.HasValue("RestoreFilePath") ? x.GetValue<string>("RestoreFilePath") : null;

                var destFile = Path.Combine(databaseFilePath, databaseFileName);
                var srcFile = Path.Combine(restoreFilePath, restoreFileName);

                if (File.Exists(destFile))
                {
                    // Original closed the shared static "sql" connection here. There's
                    // no equivalent standing connection with EF (a DentalContext is
                    // opened/closed per call), so releasing the SQLite connection pool
                    // is the direct equivalent.
                    SQLiteConnection.ClearAllPools();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    File.Delete(destFile);
                }

                File.Copy(srcFile, destFile);

                return new JsonResponse<dynamic>() { Success = true, Data = 1 };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        // ---------------------------------------------------------------------
        // Helpers for the generic, table-name-driven operations above
        // (GetBaseCodingX / DefineBaseCodingX / DeleteEntityX). The original
        // Provider.cs versions built raw "SELECT/UPDATE/INSERT/DELETE FROM
        // {EntityName}" SQL against a table name supplied by the caller. EF
        // requires a compile-time generic type, so EntityName/EntityTitle
        // (either the CLR type name, e.g. "Gender", or the physical table
        // name, e.g. "BaseCoding_Genders") is resolved to a Type here.
        // ---------------------------------------------------------------------

        private static int ParseColor(object colorValue)
        {
            if (colorValue == null) return 0;
            int parsed;
            return int.TryParse(colorValue.ToString(), out parsed) ? parsed : 0;
        }

        private static readonly Dictionary<string, Type> _baseCodingTypeMap = BuildBaseCodingTypeMap();
        private static readonly Dictionary<string, Type> _entityTypeMap = BuildEntityTypeMap();

        private static Dictionary<string, Type> BuildBaseCodingTypeMap()
        {
            var map = new Dictionary<string, Type>(StringComparer.OrdinalIgnoreCase);

            Action<Type, string> add = (t, table) =>
            {
                map[t.Name] = t;
                map[table] = t;
            };

            add(typeof(AdmissionType), "BaseCoding_AdmissionTypes");
            add(typeof(Bank), "BaseCoding_Banks");
            add(typeof(BargainSide), "BaseCoding_BargainSides");
            add(typeof(CheckupType), "BaseCoding_CheckupTypes");
            add(typeof(ChequeStatus), "BaseCoding_ChequeStatus");
            add(typeof(ChequeType), "BaseCoding_ChequeTypes");
            add(typeof(CodingICD10), "BaseCoding_CodingICD10");
            add(typeof(CostType), "BaseCoding_CostTypes");
            add(typeof(DentalUnit), "BaseCoding_DentalUnits");
            add(typeof(Diagnosis), "BaseCoding_Diagnosis");
            add(typeof(DiagnosisStatus), "BaseCoding_DiagnosisStatus");
            add(typeof(DrugFrequency), "BaseCoding_DrugFrequencies");
            add(typeof(DrugRoute), "BaseCoding_DrugRoutes");
            add(typeof(DrugShape), "BaseCoding_DrugShapes");
            add(typeof(Drug), "BaseCoding_Drugs");
            add(typeof(EducationLevel), "BaseCoding_EducationLevels");
            add(typeof(Gender), "BaseCoding_Genders");
            add(typeof(HealthcareProvider), "BaseCoding_HealthcareProviders");
            add(typeof(InsuranceBookletType), "BaseCoding_InsuranceBookletTypes");
            add(typeof(InsuranceBox), "BaseCoding_InsuranceBoxs");
            add(typeof(InsuranceType), "BaseCoding_InsuranceTypes");
            add(typeof(Insurance), "BaseCoding_Insurances");
            add(typeof(ItemUnit), "BaseCoding_ItemUnits");
            add(typeof(Job), "BaseCoding_Jobs");
            add(typeof(MaritalStatus), "BaseCoding_MaritalStatus");
            add(typeof(Nationality), "BaseCoding_Nationalities");
            add(typeof(OrdinalTerm), "BaseCoding_OrdinalTerms");
            add(typeof(OrganizationType), "BaseCoding_OrganizationTypes");
            add(typeof(PayStatus), "BaseCoding_PayStatus");
            add(typeof(PayType), "BaseCoding_PayTypes");
            add(typeof(PersonRelationType), "BaseCoding_PersonRelationTypes");
            add(typeof(ReferredReason), "BaseCoding_ReferredReasons");
            add(typeof(ReferredType), "BaseCoding_ReferredTypes");
            add(typeof(ServiceGroup), "BaseCoding_ServiceGroups");
            add(typeof(ServiceUnit), "BaseCoding_ServiceUnits");
            add(typeof(Severity), "BaseCoding_Severities");
            add(typeof(SpecialCommentType), "BaseCoding_SpecialCommentTypes");
            add(typeof(SpecialDiseas), "BaseCoding_SpecialDiseases");
            add(typeof(SpecialDrug), "BaseCoding_SpecialDrugs");
            add(typeof(Specialty), "BaseCoding_Specialties");
            add(typeof(StaffType), "BaseCoding_StaffTypes");
            add(typeof(StuffTransactionType), "BaseCoding_StuffTransactionTypes");
            add(typeof(StuffType), "BaseCoding_StuffTypes");
            add(typeof(SubstanceType), "BaseCoding_SubstanceTypes");
            add(typeof(ToothNumber), "BaseCoding_ToothNumbers");
            add(typeof(ToothPart), "BaseCoding_ToothParts");
            add(typeof(ToothSegment), "BaseCoding_ToothSegments");

            return map;
        }

        private static Dictionary<string, Type> BuildEntityTypeMap()
        {
            // DeleteEntityX targets any single-Id-keyed table, not just the
            // BaseCoding family, so this extends the base-coding map with the
            // main entities.
            var map = new Dictionary<string, Type>(BuildBaseCodingTypeMap(), StringComparer.OrdinalIgnoreCase);

            Action<Type, string> add = (t, table) =>
            {
                map[t.Name] = t;
                map[table] = t;
            };

            add(typeof(Patient), "Patients");
            add(typeof(Staff), "Staffs");
            add(typeof(Doctor), "Staff_Doctors");
            add(typeof(Cost), "Costs");
            add(typeof(Insurer), "Insurers");
            add(typeof(Office), "Offices");
            add(typeof(User), "Users");
            add(typeof(WorkTime), "WorkTimes");
            add(typeof(Visit), "Visits");
            add(typeof(Service), "Services");
            add(typeof(Tooth), "Teeth");
            add(typeof(PatientTooth), "PatientTeeth");
            add(typeof(PatientSpecialComment), "PatientSpecialComments");
            add(typeof(PatientFinancial), "PatientFinancials");
            add(typeof(PatientDocument), "PatientDocuments");
            add(typeof(PatientFollowup), "PatientFollowUps");
            add(typeof(InsurerServiceTarefeChange), "InsurerServiceTarefeChanges");
            add(typeof(InsurerFinancial), "InsurerFinancials");
            add(typeof(AppAction), "AppActions");
            add(typeof(Config), "Configs");
            add(typeof(BaseTable), "BaseTables");
            // NOTE: PatientSpecialDiseases/PatientSpecialDrugs/UserPermissions are
            // pure junction tables with composite keys and no single "Id" column -
            // the original raw "DELETE FROM {0} WHERE Id = {1}" could never have
            // worked against them either, so they're intentionally left out here.

            return map;
        }

    }
}
