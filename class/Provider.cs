using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper;
using System.Data.SqlClient;
using System.Data.SQLite;
using System.Web.Routing;
using System.Data;
using System.Collections;
using System.Dynamic;
using FarsiMessageBox;
using Dentistry.Class;
using System.IO;

namespace Dentistry
{
    class Provider
    {
        public static SQLiteConnection sql = DB.GetConnection();

        public static JsonResponse<dynamic> LoadFormInitInfo(dynamic searchObj)
        {

            if (sql == null) sql = DB.GetConnection();

            string q = System.Environment.NewLine +
                        @"                              
                            SELECT   
                                    Id,
		                            Code,
		                            Value,
		                            Title,
		                            TerminologyId,
		                            SortOrder,
		                            IsDeleted  
                            FROM {0} 
                            ORDER BY Id ASC                           
                          ;
                        " + System.Environment.NewLine;

            Dictionary<string, string> qList = new Dictionary<string, string>();

            try
            {
                //var container = new ServiceDefinitionContainer(transactionScope);
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



                string query = "";
                query = string.Join(System.Environment.NewLine, query, System.Environment.NewLine, ";");
                var p = new Dapper.DynamicParameters();

                if (IsBaseTable == true)
                {
                    query += @"
                                SELECT 
		                                  Id ,
                                          Title ,
                                          Entity ,
                                          [Table] 
                                FROM BaseTables
                                WHERE IsDeleted <> 1
                                ";


                    query = string.Join(System.Environment.NewLine, query, System.Environment.NewLine, ";");
                }

                if (IsMaxActionId == true)
                {
                    query += @"
                                SELECT MAX(Id) AS MaxActionId FROM PatientServices 
                                WHERE 1=1 
                                ";

                    query = string.Join(System.Environment.NewLine, query, System.Environment.NewLine, ";");
                }

                if (IsMaxToothId == true)
                {
                    query += @"
                                SELECT  MAX(Id) AS MaxToothId FROM PatientTeeth
                                WHERE 1=1 
                                ";

                    query = string.Join(System.Environment.NewLine, query, System.Environment.NewLine, ";");
                }


                if (IsServiceGroup == true)
                {
                    query += @"
                                
                                SELECT  Id , Title , Color
                                FROM BaseCoding_ServiceGroups svg
                                ORDER BY Id ASC 
                                ";
                    query = string.Join(System.Environment.NewLine, query, System.Environment.NewLine, ";");
                }


                if (IsInsurance == true)
                {
                    query += string.Format(q, "BaseCoding_Insurances");
                }

                if (IsInsuranceBox == true)
                {
                    query += string.Format(q, "BaseCoding_InsuranceBoxs");
                }

                if (ISBank == true)
                {
                    query += string.Format(q, "BaseCoding_Banks");

                }

                if (IsStaffType == true)
                {
                    query += string.Format(q, "BaseCoding_StaffTypes");

                }

                if (IsCostType == true)
                {
                    query += string.Format(q, "BaseCoding_CostTypes");

                }

                if (IsPayStatus == true)
                {
                    query += string.Format(q, "BaseCoding_PayStatus");

                }

                if (IsBargainSide == true)
                {
                    query += string.Format(q, "BaseCoding_BargainSides");

                }

                if (IsPayType == true)
                {
                    query += string.Format(q, "BaseCoding_PayTypes");

                }

                if (IsChequeType == true)
                {
                    query += string.Format(q, "BaseCoding_ChequeTypes");

                }

                if (IsChequeStatus == true)
                {
                    query += string.Format(q, "BaseCoding_ChequeStatus");

                }

                if (IsSpecialDisease == true)
                {
                    query += string.Format(q, "BaseCoding_SpecialDiseases");

                }

                if (IsSpecialDrug == true)
                {
                    query += string.Format(q, "BaseCoding_SpecialDrugs");

                }

                if (IsSpecialCommentType == true)
                {
                    query += string.Format(q, "BaseCoding_SpecialCommentTypes");

                }

                if (IsSpecialty == true)
                {
                    query += string.Format(q, "BaseCoding_Specialties");
                }

                if (IsInsuranceBookletType == true)
                {
                    query += string.Format(q, "BaseCoding_InsuranceBookletTypes");

                }

                if (IsToothNumber == true)
                {
                    query += string.Format(q, "BaseCoding_ToothNumbers");

                }

                if (IsToothPart == true)
                {
                    query += string.Format(q, "BaseCoding_ToothParts");

                }

                if (IsToothSegment == true)
                {
                    query += string.Format(q, "BaseCoding_ToothSegments");

                }

                if (IsMaritalStatus == true)
                {
                    query += string.Format(q, "BaseCoding_MaritalStatus");

                }

                if (IsEducationLevel == true)
                {
                    query += string.Format(q, "BaseCoding_EducationLevels");

                }

                if (IsCheckupType == true)
                {
                    query += string.Format(q, "BaseCoding_CheckupTypes");

                }

                if (IsDiagnosis == true)
                {
                    query += string.Format(q, "BaseCoding_Diagnosis");

                }

                if (IsDiagnosisStatus == true)
                {
                    query += string.Format(q, "BaseCoding_DiagnosisStatus");

                }

                if (IsDrugFrequency == true)
                {
                    query += string.Format(q, "BaseCoding_DrugFrequencies");

                }

                if (IsDrugRoute == true)
                {
                    query += string.Format(q, "BaseCoding_DrugRoutes");

                }

                if (IsDrug == true)
                {
                    query += string.Format(q, "BaseCoding_Drugs");

                }

                if (IsDrugShape == true)
                {
                    query += string.Format(q, "BaseCoding_DrugShapes");

                }

                if (IsGender == true)
                {
                    query += string.Format(q, "BaseCoding_Genders");

                }

                if (IsHealthcareProvider == true)
                {
                    query += string.Format(q, "BaseCoding_HealthcareProviders");

                }

                if (IsCodingICD10 == true)
                {
                    query += string.Format(q, "BaseCoding_CodingICD10");

                }

                if (IsInsuranceType == true)
                {
                    query += string.Format(q, "BaseCoding_InsuranceTypes");

                }

                if (IsItemUnit == true)
                {
                    query += string.Format(q, "BaseCoding_ItemUnits");

                }

                if (IsJob == true)
                {
                    query += string.Format(q, "BaseCoding_Jobs");

                }

                if (IsOrdinalTerm == true)
                {
                    query += string.Format(q, "BaseCoding_OrdinalTerms");

                }

                if (IsOrganizationType == true)
                {
                    query += string.Format(q, "BaseCoding_OrganizationTypes");

                }

                if (IsPersonRelationType == true)
                {
                    query += string.Format(q, "BaseCoding_PersonRelationTypes");

                }

                if (IsReferredReason == true)
                {
                    query += string.Format(q, "BaseCoding_ReferredReasons");

                }

                if (IsReferredType == true)
                {
                    query += string.Format(q, "BaseCoding_ReferredTypes");

                }

                if (IsServiceUnit == true)
                {
                    query += string.Format(q, "BaseCoding_ServiceUnits");

                }

                if (IsSeverity == true)
                {
                    query += string.Format(q, "BaseCoding_Severities");

                }

                if (IsStuffTransactionType == true)
                {
                    query += string.Format(q, "BaseCoding_StuffTransactionTypes");

                }

                if (IsSubstanceType == true)
                {
                    query += string.Format(q, "BaseCoding_SubstanceTypes");

                }

                if (IsNationality == true)
                {
                    query += string.Format(q, "BaseCoding_Nationalities");

                }

                dynamic BaseTable_List = null;
                dynamic Doctor_List = null;
                dynamic Personnel_List = null;
                dynamic StaffTypes_List = null;
                dynamic PatientsTitles_List = null;
                dynamic ServiceGroup_List = null;

                dynamic CostType_List = null;
                dynamic PayStatus_List = null;
                dynamic BargainSide_List = null;
                dynamic Insurance_List = null;
                dynamic InsuranceBox_List = null;
                dynamic Insurer_List = null;
                dynamic User_List = null;
                dynamic Bank_List = null;
                dynamic BankBranch_List = null;
                dynamic PayType_List = null;

                dynamic ChequeType_List = null;
                dynamic ChequeStatus_List = null;
                dynamic SpecialDiseases_List = null;
                dynamic SpecialDrug_List = null;
                dynamic PatientSpecialDiseases_List = null;
                dynamic PatientSpecialDrug_List = null;
                dynamic SpecialCommentType_List = null;
                dynamic LastNameFirstChar_List = null;
                dynamic MaxActionId_Single = null;
                dynamic MaxToothId_Single = null;
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

                var result = sql.QueryMultiple(query, param: p, commandType: CommandType.Text);

                if (IsBaseTable == true)
                {
                    BaseTable_List = result.Read<dynamic>().Select(i =>
                    new
                    {
                        i.Id,
                        i.Title,
                        i.Entity,
                        i.Table

                    }).ToList();
                }

                if (IsMaxActionId == true)
                {
                    MaxActionId_Single =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              Id = i.MaxActionId != null ? (int)i.MaxActionId : 0,
                          }).Single();
                }
                if (IsMaxToothId == true)
                {
                    MaxToothId_Single =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              Id = i.MaxToothId != null ? (int)i.MaxToothId : 0,
                          }).Single();
                }

                if (IsServiceGroup == true)
                {
                    ServiceGroup_List = result.Read<dynamic>().Select(i =>
                        new
                        {
                            i.Id,
                            i.Title,
                            i.Color,
                            IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                        }).ToList();
                }

                if (IsInsurance == true)
                {
                    Insurance_List =
                    result.Read<dynamic>().Select(i =>
                    new
                    {
                        i.Id,
                        i.Code,
                        i.Title,
                        i.TerminologyId,
                        IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                    }).ToList();

                }

                if (IsInsuranceBox == true)
                {
                    InsuranceBox_List =
                    result.Read<dynamic>().Select(i =>
                    new
                    {
                        i.Id,
                        i.Code,
                        i.Title,
                        i.TerminologyId,
                        IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                    }).ToList();

                }

                if (ISBank == true)
                {
                    Bank_List =
                        result.Read<dynamic>().Select(i =>
                        new
                        {
                            i.Id,
                            i.Title,
                            IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted),
                            i.ConnectionType,
                            i.PortName,
                            i.BoundRate
                        }).ToList();
                }

                if (IsStaffType == true)
                {
                    StaffTypes_List = result.Read<dynamic>().Select(i =>
                       new
                       {
                           i.Id,
                           i.Title,
                           IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                       }).ToList();
                }


                if (IsCostType == true)
                {
                    CostType_List =
                    result.Read<dynamic>().Select(i =>
                    new
                    {
                        i.Id,
                        i.Title,
                        IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                    }).ToList();

                }

                if (IsPayStatus == true)
                {
                    PayStatus_List =
                    result.Read<dynamic>().Select(i =>
                    new
                    {
                        i.Id,
                        i.Title,
                    }).ToList();

                }

                if (IsBargainSide == true)
                {
                    BargainSide_List =
                    result.Read<dynamic>().Select(i =>
                    new
                    {
                        i.Id,
                        i.Title,
                        IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                    }).ToList();

                }

                if (IsPayType == true)
                {
                    PayType_List =
                        result.Read<dynamic>().Select(i =>
                            new
                            {
                                i.Id,
                                i.Title,
                                IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                            }).ToList();
                }





                if (IsChequeType == true)
                {
                    ChequeType_List =
                       result.Read<dynamic>().Select(i =>
                           new
                           {
                               i.Id,
                               i.Title,
                               IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                           }).ToList();
                }

                if (IsChequeStatus == true)
                {
                    ChequeStatus_List =
                       result.Read<dynamic>().Select(i =>
                           new
                           {
                               i.Id,
                               i.Title,
                               IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                           }).ToList();
                }

                if (IsSpecialDisease == true)
                {
                    SpecialDiseases_List =
                       result.Read<dynamic>().Select(i =>
                           new
                           {
                               i.Id,
                               i.Title,
                               IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                           }).ToList();
                }

                if (IsSpecialDrug == true)
                {
                    SpecialDrug_List =
                       result.Read<dynamic>().Select(i =>
                           new
                           {
                               i.Id,
                               i.Title,
                               IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                           }).ToList();
                }


                if (IsSpecialCommentType == true)
                {
                    SpecialCommentType_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Title,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }


                if (IsSpecialty == true)
                {
                    Specialty_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Title,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsInsuranceBookletType == true)
                {
                    InsuranceBookletType_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Title,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsToothNumber == true)
                {
                    ToothNumber_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Title,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsToothPart == true)
                {
                    ToothPart_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Title,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsToothSegment == true)
                {
                    ToothSegment_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Title,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsMaritalStatus == true)
                {
                    MaritalStatus_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsEducationLevel == true)
                {
                    EducationLevel_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                //            
                if (IsCheckupType == true)
                {
                    CheckupType_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsDiagnosis == true)
                {
                    Diagnosis_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsDiagnosisStatus == true)
                {
                    DiagnosisStatus_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsDrugFrequency == true)
                {
                    DrugFrequency_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsDrugRoute == true)
                {
                    DrugRoute_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsDrug == true)
                {
                    Drug_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsDrugShape == true)
                {
                    DrugShape_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsGender == true)
                {
                    Gender_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsHealthcareProvider == true)
                {
                    HealthcareProvider_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsCodingICD10 == true)
                {
                    CodingICD10_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsInsuranceType == true)
                {
                    InsuranceType_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsItemUnit == true)
                {
                    ItemUnit_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsJob == true)
                {
                    Job_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsOrdinalTerm == true)
                {
                    OrdinalTerm_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsOrganizationType == true)
                {
                    OrganizationType_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsPersonRelationType == true)
                {
                    PersonRelationType_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsReferredReason == true)
                {
                    ReferredReason_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsReferredType == true)
                {
                    ReferredType_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsServiceUnit == true)
                {
                    ServiceUnit_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsSeverity == true)
                {
                    Severity_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsStuffTransactionType == true)
                {
                    StuffTransactionType_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsSubstanceType == true)
                {
                    SubstanceType_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                if (IsNationality == true)
                {
                    Nationality_List =
                      result.Read<dynamic>().Select(i =>
                          new
                          {
                              i.Id,
                              i.Code,
                              i.Value,
                              i.Title,
                              i.TerminologyId,
                              i.SortOrder,
                              IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)
                          }).ToList();
                }

                var finalResult = new
                {
                    BaseTable = BaseTable_List,

                    Doctor = Doctor_List,
                    Personnel = Personnel_List,
                    StaffType = StaffTypes_List,
                    Patient = PatientsTitles_List,
                    ServiceGroup = ServiceGroup_List,


                    CostType = CostType_List,
                    PayStatus = PayStatus_List,
                    BargainSide = BargainSide_List,
                    Insurance = Insurance_List,
                    InsuranceBox = InsuranceBox_List,
                    Insurer = Insurer_List,
                    User = User_List,
                    Bank = Bank_List,
                    BankBranch = BankBranch_List,
                    PayType = PayType_List,

                    ChequeType = ChequeType_List,
                    ChequeStatus = ChequeStatus_List,
                    SpecialDiseases = SpecialDiseases_List,
                    SpecialDrug = SpecialDrug_List,
                    PatientSpecialDiseases = PatientSpecialDiseases_List,
                    PatientSpecialDrug = PatientSpecialDrug_List,
                    SpecialCommentType = SpecialCommentType_List,
                    LastNameFirstChar = LastNameFirstChar_List,
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
            catch (Exception ex)
            {

                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }


        public static JsonResponse<dynamic> GetPatientsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

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

                var FromRemianed = x.HasValue("FromRemianed") ? x.GetValue<double>("FromRemianed") : (double?)null;
                var ToRemianed = x.HasValue("ToRemianed") ? x.GetValue<double>("ToRemianed") : (double?)null;
                var IsDebtor = x.HasValue("IsDebtor") ? x.GetValue<bool>("IsDebtor") : (bool?)null;
                var IsCreditor = x.HasValue("IsCreditor") ? x.GetValue<bool>("IsCreditor") : (bool?)null;

                var query = @"

                            SELECT  *
                            FROM 
                            (
                                SELECT        
                                            pp.Id,
                                            pp.Id AS PatientId,
			                                pp.FirstName,
			                                pp.LastName,	
			                                IFNULL(pp.LastName,'') || ' ' || IFNULL(pp.FirstName,'')  AS PatientName ,		
			                                date(pp.Date) as Date, 
			                                date(pp.BirthDate) as BirthDate,           
			                                pp.JobId, 
			                                pp.Presenter, 
			                                pp.FixedPhone, 
			                                pp.MobilePhone, 
			                                pp.Address, 
			                                pp.Comment, 			
			                                pp.IsDeleted, 
			                                gen.Title AS GenderTitle,
			                                pp.GenderId,		
			                                pp.NationalityId,	
			                                pp.MaritalStatusId,	
			                                pp.EducationLevelId,	  			
			                            	
			                                pp.FatherName, 
			                                pp.NationalCode, 	
			                 
			                                pp.DoctorId,
			                                staf.FirstName || ' ' || staf.LastName AS DoctorTitle,
			                                staf.MedicalCouncilCode AS DoctorMedicalCouncilCode,								                       		
			                                	                                        
			                                (SELECT COUNT(*) FROM PatientSpecialComments WHERE PatientId = pp.Id  ) AS HasSpecialComment


                                FROM Patients pp
                                JOIN   BaseCoding_Genders gen ON gen.Id = pp.GenderId                                
                                LEFT JOIN    Staffs staf ON staf.Id = pp.DoctorId
                            )temp
                            WHERE  1=1 
                                    {0}
                                
                                ";

                var p = new Dapper.DynamicParameters();
                p.Add("PatientId", value: PatientId);
                p.Add("DoctorId", value: DoctorId);
                p.Add("NationalCode", value: NationalCode);
                p.Add("InsuredNumber", value: InsuredNumber);
                p.Add("FirstName", value: FirstName);
                p.Add("LastName", value: LastName);
                p.Add("GenderId", value: GenderId);
                p.Add("Presenter", value: Presenter);
                p.Add("FixedPhone", value: FixedPhone);
                p.Add("MobilePhone", value: MobilePhone);
                p.Add("IsDeleted", value: IsDeleted);

                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));
                p.Add("FromDateBirth", value: Publics.ConvertDateTimeToString(FromDateBirth));
                p.Add("ToDateBirth", value: Publics.ConvertDateTimeToString(ToDateBirth));


                string s0 = "";
                if (PatientId != null)
                    s0 += " AND PatientId = @PatientId ";
                if (DoctorId != null)
                    s0 += " AND DoctorId = @DoctorId ";
                if (NationalCode != null)
                    s0 += string.Format(" AND NationalCode LIKE '{0}' ", NationalCode);
                if (InsuredNumber != null)
                    s0 += string.Format(" AND BI_InsuredNumber LIKE '{0}' ", InsuredNumber);
                if (FirstName != null)
                    s0 += string.Format(" AND FirstName LIKE '%{0}%' ", FirstName);
                if (LastName != null)
                    s0 += string.Format(" AND LastName LIKE '%{0}%' ", LastName);
                if (GenderId != null)
                    s0 += " AND GenderId = @GenderId ";
                if (Presenter != null)
                    s0 += string.Format(" AND Presenter LIKE '%{0}%' ", Presenter);
                if (FixedPhone != null)
                    s0 += string.Format(" AND FixedPhone LIKE '%{0}%' ", FixedPhone);
                if (MobilePhone != null)
                    s0 += string.Format(" AND MobilePhone LIKE '%{0}%' ", MobilePhone);

                if (FromDate != null)
                    s0 += " AND Date >= @FromDate ";
                if (ToDate != null)
                    s0 += " AND Date <= @ToDate ";
                if (FromDateBirth != null)
                    s0 += " AND BirthDate >= @FromDateBirth ";
                if (ToDateBirth != null)
                    s0 += " AND BirthDate <= @ToDateBirth ";

                if (IsDeleted != null)
                    s0 += " AND IsDeleted = @IsDeleted ";


                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var patientResult = result.Select(i =>
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
                        GenderId = i.GenderId != null ? (int)i.GenderId : 0,
                        GenderTitle = (string)i.GenderTitle,
                        JobId = (int)i.JobId,
                        Presenter = (string)i.Presenter,

                        NationalityId = (int?)i.NationalityId,
                        MaritalStatusId = (int?)i.MaritalStatusId,
                        EducationLevelId = (int?)i.EducationLevelId,

                        FixedPhone = (string)i.FixedPhone,
                        MobilePhone = (string)i.MobilePhone,
                        Address = (string)i.Address,
                        Comment = (string)i.Comment,
                        IsDeleted = Convert.ToBoolean(i.IsDeleted),
                        DoctorId = i.DoctorId != null ? (int)i.DoctorId : -1,
                        DoctorTitle = (string)i.DoctorTitle,
                        DoctorMedicalCouncilCode = (string)i.DoctorMedicalCouncilCode,
                        HasSpecialComment = i.HasSpecialComment != null ? (int)i.HasSpecialComment : 0


                    }).ToList();



                var finalResult = patientResult.Select(i =>
                {

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

                    };
                }).ToList();


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetOnePatientInfoX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

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


                JsonResponse<dynamic> result = Dentistry.DataProvider.GetListPatientInfoX(sObj);
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
                        Presenter = (string)i.Presenter,
                        MaritalStatusId = (int?)i.MaritalStatusId,
                        EducationLevelId = (int?)i.EducationLevelId,
                        NationalityId = (int?)i.NationalityId,
                        FixedPhone = (string)i.FixedPhone,
                        MobilePhone = (string)i.MobilePhone,
                        Address = (string)i.Address,
                        Email = (string)i.Email,
                        IsDeleted = Convert.ToBoolean(i.IsDeleted),
                        DoctorId = i.DoctorId != null ? (int)i.DoctorId : -1,
                        DoctorTitle = (string)i.DoctorTitle,
                        DoctorMedicalCouncilCode = (string)i.DoctorMedicalCouncilCode,
                        HasSpecialComment = i.HasSpecialComment == null ? 0 : (int)i.HasSpecialComment,


                    }).SingleOrDefault();


                JsonResponse<dynamic> resultPatientInsuranceX = GetPatientInsuranceX(searchObj);
                if (resultPatientInsuranceX == null && resultPatientInsuranceX.Success != true && resultPatientInsuranceX.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var piData = resultPatientInsuranceX.Data as IEnumerable<dynamic>;

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
                if (resultSpecialDiseasesX == null && resultSpecialDiseasesX.Success != true && resultSpecialDiseasesX.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var psdiData = resultSpecialDiseasesX.Data as IEnumerable<dynamic>;

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
                if (resultSpecialDrugX == null && resultSpecialDrugX.Success != true && resultSpecialDrugX.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var psdrData = resultSpecialDrugX.Data as IEnumerable<dynamic>;

                var patientSpecialDrugResult = psdrData.Select(i =>
                    new
                    {
                        Id = (int)i.Id,
                        Title = (string)i.Title,
                    }).ToList();




                JsonResponse<dynamic> resultData = GetPatientBillX(searchObj);
                if (resultData == null || resultData.Success != true || resultData.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");

                var ff = resultData.Data;

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
            if (sql == null) sql = DB.GetConnection();

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


                JsonResponse<dynamic> resultPatientInsuranceX = GetPatientInsuranceX(new { IsDeleted = false });
                if (resultPatientInsuranceX == null && resultPatientInsuranceX.Success != true && resultPatientInsuranceX.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var piData = resultPatientInsuranceX.Data as IEnumerable<dynamic>;

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

                JsonResponse<dynamic> resultPatientServicesX = GetPatientServicesX(new { CheckupTypeId = 2, IsDeleted = false });
                if (resultPatientServicesX == null && resultPatientServicesX.Success != true && resultPatientServicesX.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var psData = resultPatientServicesX.Data as IEnumerable<dynamic>;

                var patientServicesResult = psData != null ? psData.Select(i =>
                    new
                    {
                        PatientId = (int?)i.PatientId,
                        ServicePrice = i.ServicePrice != null ? (int)i.ServicePrice : 0,

                    }).ToList() : Enumerable.Empty<dynamic>();

                JsonResponse<dynamic> resultPatientFinancialsX = GetPatientFinancialsX(new { IsDeleted = false });
                if (resultPatientFinancialsX == null && resultPatientFinancialsX.Success != true && resultPatientFinancialsX.Data == null)
                    throw new Exception("خطا در واکشی اطلاعات ");
                var pfData = resultPatientFinancialsX.Data as IEnumerable<dynamic>;

                var patientFinancialResult = pfData.Select(i =>
                    new
                    {
                        PatientId = (int?)i.PatientId,
                        Amount = i.Amount != null ? (int)i.Amount : 0,
                        PayTypeId = (int?)i.PayTypeId,

                    }).ToList();



                var query = @"

                            SELECT  *
                            FROM 
                            (
                                SELECT        
                                            pp.Id,
                                            pp.Id AS PatientId,
			                                pp.FirstName,
			                                pp.LastName,	
			                                IFNULL(pp.LastName,'') || ' ' || IFNULL(pp.FirstName,'')  AS PatientName ,		
			                                date(pp.Date) as Date, 
			                                date(pp.BirthDate) as BirthDate,           
			                                pp.JobId, 
			                                pp.Presenter, 
			                                pp.FixedPhone, 
			                                pp.MobilePhone, 
			                                pp.Address, 
			                                pp.Comment, 			
			                                pp.IsDeleted, 
			                                gen.Title AS GenderTitle,
			                                pp.GenderId,		
			                                pp.NationalityId,	
			                                pp.MaritalStatusId,	
			                                pp.EducationLevelId,	  			
			                           	
			                                pp.FatherName, 
			                                pp.NationalCode, 	
			
			                                pp.DoctorId,
			                                staf.FirstName || ' ' || staf.LastName AS DoctorTitle,
			                                staf.MedicalCouncilCode AS DoctorMedicalCouncilCode,								                       		
			                                	                                        
			                                (SELECT COUNT(*) FROM PatientSpecialComments WHERE PatientId = pp.Id  ) AS HasSpecialComment


                                FROM Patients pp
                                JOIN   BaseCoding_Genders gen ON gen.Id = pp.GenderId                                
                                LEFT JOIN    Staffs staf ON staf.Id = pp.DoctorId
                            )temp
                            WHERE  1=1 
                                    {0}
                                
                                ";

                var p = new Dapper.DynamicParameters();
                p.Add("PatientId", value: PatientId);
                p.Add("DoctorId", value: DoctorId);
                p.Add("InsurerId", value: DoctorId);
                p.Add("NationalCode", value: NationalCode);
                p.Add("InsuredNumber", value: InsuredNumber);
                p.Add("FirstName", value: FirstName);
                p.Add("LastName", value: LastName);
                p.Add("GenderId", value: GenderId);
                p.Add("Presenter", value: Presenter);
                p.Add("FixedPhone", value: FixedPhone);
                p.Add("MobilePhone", value: MobilePhone);
                p.Add("IsDeleted", value: IsDeleted);

                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));
                p.Add("FromDateBirth", value: Publics.ConvertDateTimeToString(FromDateBirth));
                p.Add("ToDateBirth", value: Publics.ConvertDateTimeToString(ToDateBirth));


                string s0 = "";
                if (PatientId != null)
                    s0 += " AND PatientId = @PatientId ";
                if (DoctorId != null)
                    s0 += " AND DoctorId = @DoctorId ";
                if (NationalCode != null)
                    s0 += string.Format(" AND NationalCode LIKE '{0}' ", NationalCode);
                if (InsuredNumber != null)
                    s0 += string.Format(" AND BI_InsuredNumber LIKE '{0}' ", InsuredNumber);
                if (FirstName != null)
                    s0 += string.Format(" AND FirstName LIKE '%{0}%' ", FirstName);
                if (LastName != null)
                    s0 += string.Format(" AND LastName LIKE '%{0}%' ", LastName);
                if (GenderId != null)
                    s0 += " AND GenderId = @GenderId ";
                if (Presenter != null)
                    s0 += string.Format(" AND Presenter LIKE '%{0}%' ", Presenter);
                if (FixedPhone != null)
                    s0 += string.Format(" AND FixedPhone LIKE '%{0}%' ", FixedPhone);
                if (MobilePhone != null)
                    s0 += string.Format(" AND MobilePhone LIKE '%{0}%' ", MobilePhone);

                if (FromDate != null)
                    s0 += " AND Date >= @FromDate ";
                if (ToDate != null)
                    s0 += " AND Date <= @ToDate ";
                if (FromDateBirth != null)
                    s0 += " AND BirthDate >= @FromDateBirth ";
                if (ToDateBirth != null)
                    s0 += " AND BirthDate <= @ToDateBirth ";

                if (IsDeleted != null)
                    s0 += " AND IsDeleted = @IsDeleted ";


                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var patientResult = result.Select(i =>
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
                        GenderId = i.GenderId != null ? (int)i.GenderId : 0,
                        GenderTitle = (string)i.GenderTitle,
                        JobId = (int?)i.JobId,
                        Presenter = (string)i.Presenter,

                        NationalityId = (int?)i.NationalityId,
                        MaritalStatusId = (int?)i.MaritalStatusId,
                        EducationLevelId = (int?)i.EducationLevelId,

                        FixedPhone = (string)i.FixedPhone,
                        MobilePhone = (string)i.MobilePhone,
                        Address = (string)i.Address,
                        Comment = (string)i.Comment,
                        IsDeleted = Convert.ToBoolean(i.IsDeleted),
                        DoctorId = i.DoctorId != null ? (int)i.DoctorId : -1,
                        DoctorTitle = (string)i.DoctorTitle,
                        DoctorMedicalCouncilCode = (string)i.DoctorMedicalCouncilCode,
                        HasSpecialComment = i.HasSpecialComment != null ? (int)i.HasSpecialComment : 0


                    }).ToList();



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
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientInsuranceX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                var p = new Dapper.DynamicParameters();
                p.Add("PatientId", value: PatientId);
                p.Add("IsDeleted", value: IsDeleted);

                string query = @"                            
                         SELECT	pin.PatientId,
		                        pin.Id                     AS BI_PatientInsuranceId, 
                                pin.InsurerId              AS BI_InsurerId, 
				                ii.InsuranceId             AS BI_InsuranceId,
				                ii.InsuranceBoxId          AS BI_InsuranceBoxId,
				                ii.Title                   AS BI_InsurerTitle, 				
				                pin.InsuredNumber          AS BI_InsuredNumber, 
				                pin.InsuranceBookletSerialNumber AS BI_InsuranceBookletSerialNumber, 
				                CASE WHEN (pin.ExpirationDate > DATE()) THEN 1 ELSE 0 END AS BI_IsActive, 
				                pin.IntroLetterNum         AS BI_IntroLetterNum, 
				                ii.InsurerPercent          AS BI_OutPatientPercent , 
				               
				                ii.StartDate               AS BI_ContractStartDate , 
				                ii.EndDate                 AS BI_ContractEndDate ,
				                pin.[Percent]              AS BI_Percent, 
				                pin.MaxPay                 AS BI_MaxPay, 
                                pin.ExpirationDate         AS BI_ExpirationDate,			
				                IFNULL((JULIANDAY(DATE()) - JULIANDAY(pin.ExpirationDate)),0) AS BI_VDateDiff,
				                pin.PageNumber             AS BI_PageNumber, 
                                pin.PersonRelationTypeId   AS BI_PersonRelationTypeId, 
				                fr.Title                   AS BI_PersonRelationTypeTitle, 
				                pin.IssuedPlaceCode        AS BI_IssuedPlaceCode ,  
				                pin.InsurerAgentCode       AS BI_InsurerAgentCode,
				                pin.HID                    AS BI_HID,
				                pin.SHEBAD                 AS BI_SHEBAD,
				                pin.InsuranceBookletTypeId AS BI_InsuranceBookletTypeId,
				                insbt.Title                AS BI_InsuranceBookletTypeTitle

                        FROM   PatientInsurances AS pin 
		                JOIN   Insurers AS ii ON ii.Id = pin.InsurerId
		                LEFT JOIN BaseCoding_PersonRelationTypes AS fr ON fr.Id = pin.PersonRelationTypeId 
		                LEFT JOIN BaseCoding_InsuranceBookletTypes insbt ON insbt.Id = pin.InsuranceBookletTypeId
	    
                        WHERE   (pin.InsuranceTypeId = 1) AND (pin.IsDeleted = 0)
                                ";
                if (PatientId != null)
                    query += " AND  pin.PatientId == @PatientId ";
                if (IsDeleted != null)
                    query += " AND pin.IsDeleted = @IsDeleted ";

                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var finalResult =
                    (from i in result
                     select new
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
                         i.BI_IsActive,
                         i.BI_IntroLetterNum,
                         i.BI_OutPatientPercent,
                         i.BI_InPatientPercent,

                         BI_ContractStartDate = i.BI_ContractStartDate != null ? Publics.GetDate(i.BI_ContractStartDate) : (DateTime?)null,
                         BI_ContractStartDateSolar = i.BI_ContractStartDate != null ? Publics.GetSolarDate(i.BI_ContractStartDate) : "",

                         BI_ContractEndDate = i.BI_ContractEndDate != null ? Publics.GetDate(i.BI_ContractEndDate) : null,
                         BI_ContractEndDateSolar = i.BI_ContractEndDate != null ? Publics.GetSolarDate(i.BI_ContractEndDate) : "",

                         BI_ExpirationDate = i.BI_ExpirationDate != null ? Publics.GetDate(i.BI_ExpirationDate) : null,
                         BI_ExpirationDateSolar = i.BI_ExpirationDate != null ? Publics.GetSolarDate(i.BI_ExpirationDate) : "",

                         i.BI_Percent,
                         i.BI_MaxPay,

                         i.BI_VDateDiff,
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
            catch (Exception ex)
            {

                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientServicesX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

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


                resultData = DataProvider.GetToothX(searchObj);
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






                var p = new Dapper.DynamicParameters();
                p.Add("PatientId", value: PatientId);
                p.Add("DoctorId", value: DoctorId);
                p.Add("PatientServiceId", value: PatientServiceId);
                p.Add("CheckupTypeId", value: CheckupTypeId);
                p.Add("ServiceGroupId", value: ServiceGroupId);
                p.Add("ServiceId", value: ServiceId);
                p.Add("ToothId", value: ToothId);
                p.Add("ProviderDoctorId", value: ProviderDoctorId);
                p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));
                p.Add("IsDeleted", value: IsDeleted);

                var s = "";
                if (PatientId != null)
                    s += " AND PatientId = @PatientId ";

                if (DoctorId != null)
                    s += " AND DoctorId = @DoctorId ";
                if (PatientServiceId != null)
                    s += " AND PatientServiceId = @PatientServiceId ";

                if (CheckupTypeId != null)
                    s += " AND CheckupTypeId = @CheckupTypeId ";
                if (ServiceGroupId != null)
                    s += " AND ServiceGroupId = @ServiceGroupId ";
                if (ServiceId != null)
                    s += " AND ServiceId = @ServiceId ";
                if (ToothId != null)
                {
                    if (ToothId == 0)
                        s += @" ";

                    else if (ToothId == -1)
                        s += @" AND ToothGroup = 1 ";

                    else if (ToothId == -2)
                        s += @" AND ToothGroup = 2 ";

                    else
                        s += @" AND @ToothId IN (ToothIds) 
	                               
                                ";
                }
                if (ProviderDoctorId != null)
                    s += " AND ProviderDoctorId = @ProviderDoctorId ";

                if (Date != null)
                    s += " AND Date = @Date ";
                if (FromDate != null)
                    s += " AND Date >= @FromDate ";
                if (ToDate != null)
                    s += " AND Date <= @ToDate ";

                string query = @"
                            SELECT  *
                            FROM 
                            (
                                SELECT  pps.Id AS PatientServiceId ,
                                        pps.PatientId,
                                        pp.DoctorId ,        
                                        pps.Date ,
                                        pps.Comment  ,
                                        pps.IsHadMoreTooth ,             
                                        IFNULL(pps.IsDeleted, 0) AS IsDeleted ,		
                                        pp.FirstName || ' ' || pp.LastName AS PatientName ,
		                                pp.NationalCode,	
        
		                                pp.BirthDate,
		                                staf1.FirstName || ' ' || staf1.LastName AS DoctorTitle,		                                

		                                svc.Id AS ServiceId,
                                        svc.Title AS ServiceTitle ,               
                                        svc.IsToothNumber ,

		                                svc.ServiceGroupId ,
                                        svg.Title AS ServiceGroupTitle ,   
                                        pps.CheckupTypeId ,
                                        cht.Title AS CheckupTypeTitle ,
		                                ProviderDoctorId ,  
		                                staf2.FirstName AS  ProviderDoctorFirstName , 
		                                staf2.FirstName AS  ProviderDoctorLastName ,                            
		                                staf2.FirstName || ' ' || staf2.LastName AS ProviderDoctorTitle,		                        
		                                pps.Count AS ServiceCount ,
		                                pps.ServicePrice AS ServicePrice ,
		                                pps.InsurerPrice AS InsurerPrice , 
		                                pps.ActionPrice AS ActionPrice ,		
		                                pps.InsurerShare AS InsurerShare,
		                                pps.FranchiseShare AS FranchiseShare,
		                                pps.FreeShare AS FreeShare,
		                                pps.ToothIds  
      		
                                FROM PatientServices AS pps
                                JOIN Services svc ON pps.ServiceId = svc.Id
                                JOIN BaseCoding_ServiceGroups svg ON svc.ServiceGroupId = svg.Id
                                JOIN BaseCoding_CheckupTypes AS cht ON cht.Id = pps.CheckupTypeId
                                JOIN Patients AS pp ON pp.Id = pps.PatientId
                                JOIN Staffs staf1 ON staf1.Id = pp.DoctorId
                                JOIN Staffs staf2 ON staf2.Id = pps.ProviderDoctorId
                               
                                WHERE pps.IsDeleted <> 1
                            )temp
                            WHERE PatientServiceId<>0 {0}
    
                                ";




                query = string.Format(query, s);

                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var resultX =
                    (from psItem in result
                     join piItem in resultPatientInsurance on psItem.PatientId equals piItem.PatientId into piTemp
                     from piItem in piTemp.DefaultIfEmpty()

                     select new
                     {

                         PatientServiceId = psItem.PatientServiceId != null ? (int)psItem.PatientServiceId : 0,
                         PatientId = (int)psItem.PatientId,
                         PatientName = (string)psItem.PatientName,
                         NationalCode = (string)psItem.NationalCode,
                         Age = Publics.GetAge(psItem.BirthDate),
                         DoctorId = (int)psItem.DoctorId,
                         DoctorTitle = (string)psItem.DoctorTitle,

                         BasicInsurerId = piItem != null ? (int)piItem.BasicInsurerId : Constant.FreeInsurerId,
                         BasicInsurerTitle = piItem != null ? (string)piItem.BasicInsurerTitle : Constant.FreeInsurerTitle,
                         BasicInsurerPercent = piItem != null ? (int)piItem.BasicInsurerPercent : 0,

                         ServiceGroupId = psItem.ServiceGroupId != null ? (int)psItem.ServiceGroupId : -1,
                         ServiceGroupTitle = (string)psItem.ServiceGroupTitle,
                         CheckupTypeId = psItem.CheckupTypeId != null ? (int)psItem.CheckupTypeId : 2,
                         ServiceId = psItem.ServiceId != null ? (int)psItem.ServiceId : -1,
                         ServiceTitle = (string)psItem.ServiceTitle,
                         Date = Publics.GetDate(psItem.Date),
                         SolarDate = Publics.GetSolarDate(psItem.Date),
                         SolarDateTime = Publics.GetSolarDateTime(psItem.Date),
                         Comment = (string)psItem.Comment,
                         IsHadMoreTooth = Convert.ToBoolean(psItem.IsHadMoreTooth),
                         IsToothNumber = Convert.ToBoolean(psItem.IsToothNumber),
                         IsDeleted = Convert.ToBoolean(psItem.IsDeleted),
                         ProviderDoctorId = psItem.ProviderDoctorId != null ? (int)psItem.ProviderDoctorId : 0,
                         ProviderDoctorTitle = (string)psItem.ProviderDoctorTitle,


                         ActionPrice = psItem.ActionPrice != null ? (decimal)psItem.ActionPrice : 0,
                         ServicePrice = psItem.ServicePrice != null ? (decimal)psItem.ServicePrice : 0,
                         InsurerPrice = psItem.InsurerPrice != null ? (decimal)psItem.InsurerPrice : 0,
                         InsurerShare = psItem.InsurerShare != null ? (decimal)psItem.InsurerShare : 0,
                         FranchiseShare = psItem.FranchiseShare != null ? (decimal)psItem.FranchiseShare : 0,
                         FreeShare = psItem.FreeShare != null ? (double)psItem.FreeShare : 0,

                         ToothIds = psItem.ToothIds != null ? (string)psItem.ToothIds : "",


                     }).OrderByDescending(i => i.Date).ToList();




                if (BasicInsurerId != null)
                    resultX = resultX.Where(i => i.BasicInsurerId == BasicInsurerId).ToList();




                var finalResult =
                                    (from item in resultX
                                     let ToothIdList = item.ToothIds?.Split(',')?.Select(Int32.Parse)?.ToList()

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
                                         item.CheckupTypeId,
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
            catch (Exception ex)
            {

                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientFinancialsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var PayTypeId = x.HasValue("PayTypeId") ? x.GetValue<int>("PayTypeId") : (int?)null;
                var PayTypeIds = x.HasValue("PayTypeIds") ? string.Join(" , ", x.GetValue<IEnumerable>("PayTypeIds").OfType<object>().Select(i => string.Format(" {0} ", int.Parse(Convert.ToString(i)))).ToArray()) : null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                var FromAmount = x.HasValue("FromAmount") ? x.GetValue<double>("FromAmount") : (double?)null;
                var ToAmount = x.HasValue("ToAmount") ? x.GetValue<double>("ToAmount") : (double?)null;
                var IsDateOfIssuance = x.HasValue("IsDateOfIssuance") ? x.GetValue<bool>("IsDateOfIssuance") : (bool?)null;
                var IsDateOfMaturity = x.HasValue("IsDateOfMaturity") ? x.GetValue<bool>("IsDateOfMaturity") : (bool?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                var p = new Dapper.DynamicParameters();
                p.Add("PatientId", value: PatientId);
                p.Add("Id", value: Id);
                p.Add("PayTypeId", value: PayTypeId);
                p.Add("PayTypeIds", value: PayTypeIds);
                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));
                p.Add("FromAmount", value: FromAmount);
                p.Add("ToAmount", value: ToAmount);
                p.Add("IsDeleted", value: IsDeleted);

                var query = @"  
                SELECT  ROW_NUMBER() OVER (ORDER BY [Date]) AS RowNumber , *
                FROM (
                        SELECT 
                                pft.PatientId ,
                                (IFNULL(pp.FirstName, '') || ' ' || IFNULL(pp.LastName, '')) AS FullName,
                                ( IFNULL(pp.FirstName, '') || ' ' || IFNULL(pp.LastName, '') ) AS PatientName,

                                pft.Id AS PatientFinancialId ,
                                pft.Date ,                             
                                pft.PayTypeId ,
                                pt.Title AS PayTypeTitle ,	
                                IFNULL(pft.Discount, 0) AS Discount ,
                                IFNULL(pft.Amount, 0) AS Amount ,
                                pft.TransactionCode,

                     
                                pft.ChequeNumber, 					 					                      
				                pft.BankId,
				                bnk.Title AS BankTitle ,				    		                      
                                pft.DateOfIssuance, 					
					            pft.DateOfMaturity,
                                pft.ChequeStatusId,
		                        chqSts.Title AS  ChequeStatusTitle,

                                pft.Comment ,
		                        pft.IsDeleted


                        FROM       PatientFinancials AS pft
                        JOIN       Patients AS pp ON pft.PatientId = pp.Id
                        JOIN       BaseCoding_PayTypes AS pt ON pft.PayTypeId = pt.Id                          
                        LEFT JOIN  BaseCoding_Banks bnk  ON bnk.Id = pft.BankId
                        LEFT JOIN  BaseCoding_ChequeStatus chqSts on chqSts.Id = pft.ChequeStatusId
                )
                WHERE PatientId <> 0 AND IsDeleted <> 1  {0}                    
                                ";

                var s0 = "";
                if (PatientId != null && PatientId != 0)
                    s0 += " AND  PatientId = @PatientId ";
                if (Id != null)
                    s0 += " AND  PatientFinancialId = @Id ";
                if (PayTypeId != null && PayTypeId != 0)
                    s0 += " AND  PayTypeId = @PayTypeId ";
                if (PayTypeIds != null && PayTypeIds.Length > 0)
                    s0 += string.Format(" AND PayTypeId IN ({0}) ", PayTypeIds);
                if (FromAmount != null)
                    s0 += " AND Amount >= @FromAmount ";
                if (ToAmount != null)
                    s0 += " AND Amount <= @ToAmount  ";

                if (IsDateOfIssuance != null)
                {
                    if (FromDate != null)
                        s0 += " AND  DateOfIssuance >= @FromDate ";
                    if (ToDate != null)
                        s0 += " AND  DateOfIssuance <= @ToDate ";
                }

                if (IsDateOfMaturity != null)
                {
                    if (FromDate != null)
                        s0 += " AND  DateOfMaturity >= @FromDate ";
                    if (ToDate != null)
                        s0 += " AND  DateOfMaturity <= @ToDate ";
                }

                if (IsDateOfIssuance == null && IsDateOfMaturity == null)
                {
                    if (FromDate != null)
                        s0 += " AND  Date >= @FromDate ";
                    if (ToDate != null)
                        s0 += " AND  Date <= @ToDate ";
                }

                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);


                var finalResult = result.Select(i =>
                    new
                    {
                        RowNumber = (int)i.RowNumber,
                        Id = (int)i.PatientFinancialId,
                        PatientFinancialId = (int)i.PatientFinancialId,
                        TransactionId = (int)i.PatientFinancialId,
                        PatientId = (int)i.PatientId,
                        Date = Publics.GetDate(i.Date),
                        SolarDate = Publics.GetSolarDateTime(i.Date),
                        Amount = (double)i.Amount,
                        PatientName = (string)i.PatientName,
                        PayTypeId = (int)i.PayTypeId,
                        PayTypeTitle = (string)i.PayTypeTitle,
                        TransactionCode = (string)i.TransactionCode,

                        ChequeNumber = (string)i.ChequeNumber,
                        BankId = (int?)i.BankId,
                        BankTitle = (string)i.BankTitle,
                        DateOfIssuance = Publics.GetDate(i.DateOfIssuance),
                        SolarDateOfIssuance = Publics.GetSolarDate(i.DateOfIssuance),
                        DateOfMaturity = Publics.GetDate(i.DateOfMaturity),
                        SolarDateOfMaturity = Publics.GetSolarDate(i.DateOfMaturity),
                        ChequeTypeId = 1, // برداشت
                        ChequeTypeTitle = "برداشت",
                        ChequeStatusId = (int?)i.ChequeStatusId,
                        ChequeStatusTitle = (string)i.ChequeStatusTitle,

                        Comment = (string)i.Comment,
                        IsDeleted = Convert.ToBoolean(i.IsDeleted),
                    }).OrderByDescending(i => i.Date).ToList();




                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {

                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientSpecialDrug(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var IsGetOnlyChecked = x.HasValue("IsGetOnlyChecked") ? x.GetValue<bool>("IsGetOnlyChecked") : false;

                var p = new Dapper.DynamicParameters();
                p.Add("PatientId", value: PatientId);


                string query = @"
                                SELECT  a.Id ,
                                        a.Title ,
                                        CASE IFNULL(b.PatientId, 0)
			                                WHEN 0 
			                                THEN 0
			                                ELSE 1
		                                END AS IsCheck
                                FROM  BaseCoding_SpecialDrugs a 
                                LEFT JOIN PatientSpecialDrugs b ON  b.SpecialDrugId = a.Id  AND b.PatientId = @PatientId
                                WHERE   a.Id <> 0


                      
                                ";
                //if (PatientId != null)
                //    query += " AND  ppii.PatientId == @PatientId ";

                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var finalResult = result.Select(i =>
                    new
                    {
                        PatientId = PatientId,
                        Id = (int)i.Id,
                        Title = (string)i.Title,
                        IsCheck = Convert.ToBoolean(i.IsCheck)
                    }).ToList();

                if (IsGetOnlyChecked)
                    finalResult = finalResult.Where(i => i.IsCheck == true).ToList();



                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {

                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientSpecialDiseases(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var IsGetOnlyChecked = x.HasValue("IsGetOnlyChecked") ? x.GetValue<bool>("IsGetOnlyChecked") : false;

                var p = new Dapper.DynamicParameters();
                p.Add("PatientId", value: PatientId);


                string query = @"  
                                SELECT  a.Id ,
                                        a.Title ,
                                        CASE IFNULL(b.PatientId, 0)
			                                WHEN 0 
			                                THEN 0
			                                ELSE 1
		                                END AS IsCheck
                                FROM  BaseCoding_SpecialDiseases a  
                                LEFT JOIN PatientSpecialDiseases b ON  b.SpecialDiseasId = a.Id  AND b.PatientId = @PatientId
                                WHERE   a.Id <> 0

                           
                                ";
                //if (PatientId != null)
                //    query += " AND  ppii.PatientId == @PatientId ";

                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var finalResult = result.Select(i =>
                    new
                    {
                        PatientId = PatientId,
                        Id = (int)i.Id,
                        Title = (string)i.Title,
                        IsCheck = Convert.ToBoolean(i.IsCheck)
                    }).ToList();

                if (IsGetOnlyChecked)
                    finalResult = finalResult.Where(i => i.IsCheck == true).ToList();

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {

                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientSpecialCommentsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {

                var x = new RouteValueDictionary(searchObj);
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                var p = new Dapper.DynamicParameters();
                p.Add("Id", value: Id);
                p.Add("PatientId", value: PatientId);
                p.Add("IsDeleted", value: IsDeleted);

                var query = @"
                                    SELECT * 
                                    FROM
                                    (
                                        SELECT 
                                                pspc.Id , 
                                                pspc.Title , 
                                                pspc.PatientId , 
                                                pspc.Date , 
                                                pspc.SpecialCommentTypeId , 
                                                spct.Title AS SpecialCommentTypeTitle , 
                                                pspc.IsDeleted
                                        FROM PatientSpecialComments pspc									
                                        JOIN BaseCoding_SpecialCommentTypes spct ON  spct.Id = pspc.SpecialCommentTypeId                                                                       
                                    )temp
                                    WHERE 1=1 {0}
                                    ";

                string s0 = "";

                if (Id != null)
                    s0 += " AND Id = @Id ";
                if (PatientId != null)
                    s0 += " AND PatientId = @PatientId ";
                if (IsDeleted != null)
                    s0 += " AND IsDeleted = @IsDeleted  ";
                //    s0 += " AND Date >= @ToDate ";

                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var resultList = result.Select(i =>
                   new
                   {
                       Id = (int)i.Id,
                       Title = (string)i.Title,
                       PatientId = (int)i.PatientId,
                       Date = Publics.GetDate(i.Date),
                       SolarDate = Publics.GetSolarDate(i.Date),
                       SpecialCommentTypeId = (int)i.SpecialCommentTypeId,
                       SpecialCommentTypeTitle = (string)i.SpecialCommentTypeTitle,
                       IsDeleted = Convert.ToBoolean(i.IsDeleted)
                   }).ToList();


                var finalResult = resultList;


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {

                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientDocsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {

                var x = new RouteValueDictionary(searchObj);
                var DocId = x.HasValue("DocId") ? x.GetValue<int>("DocId") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;


                var query = @"
                                SELECT  *
                                FROM    
                                (
                                    SELECT  pdoc.Id ,
                                            pdoc.PatientId ,
		                                    pp.FirstName || ' ' || pp.LastName AS PatientName, 
                                            pdoc.Date,
                                            pdoc.Title ,
                                            pdoc.ImagePath ,
                                            pdoc.Image ,
                                            pdoc.IsDeleted,
                                            pdoc.Comment
                                    FROM    PatientDocuments pdoc
                                    JOIN Patients pp ON pp.Id = pdoc.PatientId
                                )temp
                                WHERE  1=1 {0}
                                 ";
                var p = new Dapper.DynamicParameters();
                p.Add("DocId", value: DocId);
                p.Add("PatientId", value: PatientId);
                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));

                string s0 = "";

                if (DocId != null)
                    s0 += " AND Id = @DocId ";
                if (PatientId != null)
                    s0 += " AND PatientId = @PatientId ";

                if (FromDate != null)
                    s0 += " AND Date >= @FromDate ";
                if (ToDate != null)
                    s0 += " AND Date <= @ToDate ";

                query = string.Format(query, s0);
                var result = sql.QueryMultiple(query, param: p, commandType: CommandType.Text);

                var resultList = result.Read<dynamic>().Select(i =>
                   new
                   {
                       DocId = (int)i.Id,
                       PatientId = (int)i.PatientId,
                       PatientName = (string)i.PatientName,
                       Date = Publics.GetDate(i.Date),
                       SolarDate = Publics.GetSolarDate(i.Date),
                       Title = (string)i.Title,
                       ImagePath = (string)i.ImagePath,
                       Image = (byte[])i.Image,
                       IsDeleted = Convert.ToBoolean(i.IsDeleted),
                       Comment = (string)i.Comment
                   }).OrderByDescending(i => i.Date).ToList();


                var finalResult = resultList;

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientFollowUpsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {

                var x = new RouteValueDictionary(searchObj);
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                var query = @"
                                    SELECT * FROM
                                    (
                                        SELECT         
                                                pflp.Id ,
                                                pflp.PatientId ,
		                                        pp.FirstName || ' ' || pp.LastName AS PatientName ,
		                                        pp.MobilePhone,                                                 
                                                pflp.Date ,                
                                                pflp.FollowUpDate , 
				                                pflp.Comment,                 
                                                pflp.IsDeleted
                                        FROM  PatientFollowUps pflp
                                        JOIN  Patients pp ON pp.Id = pflp.PatientId
                                    )temp
                                    WHERE   1=1 {0}
                                 ";
                var p = new Dapper.DynamicParameters();
                p.Add("Id", value: Id);
                p.Add("DoctorId", value: DoctorId);
                p.Add("PatientId", value: PatientId);
                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));
                p.Add("IsDeleted", value: IsDeleted);


                string s0 = "";

                if (Id != null)
                    s0 += " AND Id = @Id ";
                if (DoctorId != null)
                    s0 += " AND DoctorId = @DoctorId ";
                if (PatientId != null)
                    s0 += " AND PatientId = @PatientId ";
                if (FromDate != null)
                    s0 += " AND FollowUpDate >= @FromDate ";
                if (ToDate != null)
                    s0 += " AND FollowUpDate <= @ToDate ";
                if (IsDeleted != null)
                    s0 += " AND IsDeleted = @IsDeleted ";


                query = string.Format(query, s0);
                var result = sql.QueryMultiple(query, param: p, commandType: CommandType.Text);

                var resultList = result.Read<dynamic>().Select(i =>
                   new
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
                   }).ToList();


                var finalResult = resultList;


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetPatientBillX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

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

        public static JsonResponse<dynamic> GetPatientTeethInfos(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var PatientServiceToothId = x.HasValue("PatientServiceToothId") ? x.GetValue<int>("PatientServiceToothId") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var ToothId = x.HasValue("ToothId") ? x.GetValue<int>("ToothId") : (int?)null;

                var p = new Dapper.DynamicParameters();
                p.Add("PatientServiceToothId", value: PatientServiceToothId);
                p.Add("PatientId", value: PatientId);
                p.Add("ToothId", value: ToothId);

                var query = @"   
                                    SELECT     
                                               thi.PatientId,                                             
                                               thi.Id,
		                                       thi.ToothId , 
		                                       thi.Visible , 
		                                       thi.Rotate , 
		                                       thi.TipB , 
		                                       thi.TipM , 
		                                       thi.ShiftM , 
		                                       thi.ShiftO , 
		                                       thi.ShiftB , 
		                                       thi.IsRCT , 
		                                       thi.ColorRCT , 
		                                       thi.IsBU , 
		                                       thi.ColorBU , 
		                                       thi.IsImplant , 
		                                       thi.ColorImplant , 
		                                       thi.IsCrown , 
		                                       thi.IsPontic , 
		                                       thi.IsSealant , 
		                                       thi.ColorSealant , 
		                                       thi.SurfaceColor , 
		                                       thi.Surface ,
                                               thi.Surface_B,
                                               thi.Surface_B_Color,
                                               thi.Surface_F,
                                               thi.Surface_F_Color,
                                               thi.Surface_C,
                                               thi.Surface_C_Color,
                                               thi.Surface_D,
                                               thi.Surface_D_Color,
                                               thi.Surface_E,
                                               thi.Surface_E_Color,
                                               thi.Surface_L,
                                               thi.Surface_L_Color,
                                               thi.Surface_M,
                                               thi.Surface_M_Color,
                                               thi.Surface_O,
                                               thi.Surface_O_Color,
                                               thi.Surface_I,
                                               thi.Surface_I_Color,
                                               thi.Surface_V,
                                               thi.Surface_V_Color,
                                               Description
		                            FROM  PatientTeeth thi                           
                                    WHERE  thi.IsDeleted <> 1  {0}
                                 ";

                var s = "";
                if (PatientServiceToothId != null)
                    s += " AND Id = @PatientServiceToothId ";
                if (PatientId != null)
                    s += " AND PatientId = @PatientId ";

                if (ToothId != null)
                    s += " AND ToothId = @ToothId ";


                query = string.Format(query, s);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var resultX = result.Select(i =>
                   new
                   {
                       i.PatientId,

                       ToothId = i.ToothId != null ? i.ToothId : 0,
                       Visible = Convert.ToBoolean(i.Visible),
                       Rotate = i.Rotate != null ? (int)i.Rotate : 0,
                       TipB = i.TipB != null ? (int)i.TipB : 0,
                       TipM = i.TipM != null ? (int)i.TipM : 0,
                       ShiftM = i.ShiftM != null ? (int)i.ShiftM : 0,
                       ShiftO = i.ShiftO != null ? (int)i.ShiftO : 0,
                       ShiftB = i.ShiftB != null ? (int)i.ShiftB : 0,
                       IsRCT = Convert.ToBoolean(i.IsRCT),
                       ColorRCT = i.ColorRCT != null ? (int)i.ColorRCT : 0,
                       IsBU = Convert.ToBoolean(i.IsBU),
                       ColorBU = i.ColorBU != null ? (int)i.ColorBU : 0,
                       IsImplant = Convert.ToBoolean(i.IsImplant),
                       ColorImplant = i.ColorImplant != null ? (int)i.ColorImplant : 0,
                       IsCrown = Convert.ToBoolean(i.IsCrown),
                       IsPontic = Convert.ToBoolean(i.IsPontic),

                       IsSealant = Convert.ToBoolean(i.IsSealant),
                       ColorSealant = i.ColorSealant != null ? (int)i.ColorSealant : 0,

                       Surface = i.Surface != null ? (string)i.Surface : "",
                       SurfaceColor = i.SurfaceColor != null ? (int)i.SurfaceColor : 0,
                       Surface_B = Convert.ToBoolean(i.Surface_B),
                       Surface_B_Color = i.Surface_B_Color != null ? (int)i.Surface_B_Color : 0,
                       Surface_F = Convert.ToBoolean(i.Surface_F),
                       Surface_F_Color = i.Surface_F_Color != null ? (int)i.Surface_F_Color : 0,
                       Surface_C = Convert.ToBoolean(i.Surface_C),
                       Surface_C_Color = i.Surface_C_Color != null ? (int)i.Surface_C_Color : 0,
                       Surface_D = Convert.ToBoolean(i.Surface_D),
                       Surface_D_Color = i.Surface_D_Color != null ? (int)i.Surface_D_Color : 0,
                       Surface_E = Convert.ToBoolean(i.Surface_E),
                       Surface_E_Color = i.Surface_E_Color != null ? (int)i.Surface_E_Color : 0,
                       Surface_L = Convert.ToBoolean(i.Surface_L),
                       Surface_L_Color = i.Surface_L_Color != null ? (int)i.Surface_L_Color : 0,
                       Surface_M = Convert.ToBoolean(i.Surface_M),
                       Surface_M_Color = i.Surface_M_Color != null ? (int)i.Surface_M_Color : 0,
                       Surface_O = Convert.ToBoolean(i.Surface_O),
                       Surface_O_Color = i.Surface_O_Color != null ? (int)i.Surface_O_Color : 0,
                       Surface_I = Convert.ToBoolean(i.Surface_I),
                       Surface_I_Color = i.Surface_I_Color != null ? (int)i.Surface_I_Color : 0,
                       Surface_V = Convert.ToBoolean(i.Surface_V),
                       Surface_V_Color = i.Surface_V_Color != null ? (int)i.Surface_V_Color : 0,
                       Description = i.Description != null ? (string)i.Description : "",
                   }).ToList();



                var finalResult = (from item in resultX
                                   group item by new { item.ToothId } into gItem

                                   select new
                                   {
                                       ToothId = gItem.Key.ToothId,
                                       Visible = gItem.Select(t => (bool)t.Visible).First(),
                                       Rotate = gItem.Sum(t => (int)t.Rotate),
                                       TipB = gItem.Sum(t => (int)t.TipB),
                                       TipM = gItem.Sum(t => (int)t.TipM),
                                       ShiftM = gItem.Sum(t => (int)t.ShiftM),
                                       ShiftO = gItem.Sum(t => (int)t.ShiftO),
                                       ShiftB = gItem.Sum(t => (int)t.ShiftB),

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

                                       //Actions = gItem.GroupBy(s => s.Surface).Select(t =>
                                       //   new
                                       //   {
                                       //       Surface = (string)gItem.Key.Surface,
                                       //       SurfaceColor = gItem.Select(i => (int)i.SurfaceColor).First() ,

                                       //   }
                                       //)
                                   }).ToList();

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetAccountPartyCompanyFinancialTransactionX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var BargainSideId = x.HasValue("BargainSideId") ? x.GetValue<int>("BargainSideId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;

                var query = @"

                            SELECT Id , Title , IsDeleted FROM BaseCoding_BargainSides WHERE Id = @BargainSideId
                            ;                                
                            SELECT CostTypeId , PayTypeId , PayTypeTitle , Date , CostTitle , Amount  ,  comment 
                            FROM   
                            (
                                SELECT  
                                                     cc.Id AS CostId, 						
					                                 (CASE WHEN  cc.BargainSideId <> 0 THEN ac.Title ELSE ct.Title END) AS CostTitle , 
					                                 cc.CostTypeId, 			
                                                     ct.Title AS  CostTypeTitle, 
					                                 cc.Amount, 
					                                 cc.BargainSideId, 
					                                 ac.Title AS  BargainSideTitle,
					                                 cc.PayTypeId, 
					                                 ps.Title AS PayTypeTitle, 	
					                                 cc.Date,
					                                 cc.Comment
					 										 
					 
                                FROM          Costs cc 
                                JOIN          BaseCoding_CostTypes ct ON  ct.Id = cc.CostTypeId
                                LEFT JOIN     BaseCoding_BargainSides ac ON ac.Id = cc.BargainSideId 
                                LEFT JOIN     BaseCoding_PayTypes ps ON cc.PayTypeId = ps.Id 
                                ORDER BY cc.Date
                            )temp
                            WHERE  CostTypeId = 1  AND  BargainSideId = @BargainSideId {0}
                                ";
                var p = new Dapper.DynamicParameters();
                p.Add("BargainSideId", value: BargainSideId);
                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));



                var s0 = "";
                if (FromDate != null)
                    s0 += " AND Date >= @FromDate ";
                if (ToDate != null)
                    s0 += " AND Date <= @ToDate ";


                query = string.Format(query, s0);
                var result = sql.QueryMultiple(query, param: p, commandType: CommandType.Text);

                var infoResult = result.Read<dynamic>().Select(i =>
                    new
                    {
                        BargainSideId = (int)i.Id,
                        BargainSideTitle = (string)i.Title,
                        IsDeleted = Convert.ToBoolean(i.IsDeleted),

                    }).SingleOrDefault();

                var dataResult = result.Read<dynamic>().Select(i =>
                    new
                    {
                        CostTypeId = (int)i.CostTypeId,
                        PayTypeId = (int)i.PayTypeId,
                        PayTypeTitle = (string)i.PayTypeTitle,
                        CostDate = Publics.GetDate(i.Date),
                        CostSolarDate = Publics.GetSolarDate(i.Date),
                        CostTitle = (string)i.CostTitle,
                        Amount = (decimal)i.Amount,
                        comment = (string)i.comment
                    }).ToList();

                var finalResult = new
                {
                    Info = infoResult,
                    Data = dataResult,

                };

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetOfficeReportX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);


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
                result = new JsonResponse<dynamic>();
                result = GetPatientFinancialsX(searchObj);
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
                result = new JsonResponse<dynamic>();
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
                result = new JsonResponse<dynamic>();
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
            if (sql == null) sql = DB.GetConnection();

            try
            {

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
                //}).Where(i => i.PayTypeId != 4).ToList();

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
            if (sql == null) sql = DB.GetConnection();

            try
            {
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

        public static JsonResponse<dynamic> GetPaymentFinancialInfoX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);

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
            if (sql == null) sql = DB.GetConnection();



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

                var p = new Dapper.DynamicParameters();
                p.Add("ServiceId", value: ServiceId);
                p.Add("InsurerId", value: InsurerId);
                p.Add("ServiceGroupId", value: ServiceGroupId);
                p.Add("ServiceCode", value: ServiceCode);
                p.Add("ServiceTitle", value: ServiceTitle);
                p.Add("IsDeleted", value: IsDeleted);
                p.Add("IsMoreTooth", value: IsMoreTooth);


                string query = "";
                string s0 = "";

                query = @"   
                                SELECT  *
                                FROM    
                                (
                                    SELECT  svg.Title AS ServiceGroupTitle ,                                           
                                            svc.IsToothNumber ,
		                                    svc.IsMoreTooth,
                                            svc.IsDeleted ,
		                                    svc.Code AS ServiceCode,
                                            svc.Title AS ServiceTitle ,
                                            svc.ServiceGroupId ,
                                            svc.Id AS ServiceId ,
                                            svc.Color AS ServiceColor,
		                                    svc.Comment
                                    FROM   Services AS svc
                                    JOIN   BaseCoding_ServiceGroups AS svg ON svg.Id = svc.ServiceGroupId
                                  
                                )temp
                                WHERE   ServiceId <> 0  {0}
                                ORDER BY ServiceGroupId , ServiceTitle
                                ";




                if (ServiceId != null)
                    s0 += " AND ServiceId = @ServiceId ";
                if (ServiceGroupId != null && ServiceGroupId > 0)
                    s0 += " AND ServiceGroupId = @ServiceGroupId ";
                if (ServiceCode != null)
                    s0 += " AND ServiceCode = @ServiceCode ";
                if (ServiceTitle != null)
                    s0 += string.Format(" AND ServiceTitle LIKE '%{0}%' ", ServiceTitle);

                if (IsDeleted != null)
                    s0 += " AND IsDeleted = @IsDeleted ";
                if (IsMoreTooth != null)
                    s0 += " AND IsMoreTooth = @IsMoreTooth ";


                query = string.Format(query, s0);
                var result1 = sql.Query(query, param: p, commandType: CommandType.Text);

                var serviceResult = result1.Select(i =>
                    new
                    {
                        ServiceId = (int)i.ServiceId,
                        ServiceGroupId = (int)i.ServiceGroupId,
                        ServiceGroupTitle = (string)i.ServiceGroupTitle,
                        ServiceCode = (string)i.ServiceCode,
                        ServiceTitle = (string)i.ServiceTitle,
                        IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted),
                        IsToothNumber = i.IsToothNumber == null ? false : Convert.ToBoolean(i.IsToothNumber),
                        IsMoreTooth = i.IsMoreTooth == null ? false : Convert.ToBoolean(i.IsMoreTooth),
                        ServiceColor = (int?)i.ServiceColor,

                        Comment = (string)i.Comment,
                    }).ToList();

                query = @"
                                    
                            SELECT        		                                       
	                            i.Id ,
	                            i.InsurerId,
	                            i.ServiceId,
	                            i.FreePrice,
	                            i.InsurerPrice,
	                            i.DefineDate,
	                            i.RunDate

                            FROM    InsurerServiceTarefeChanges i
                            join    (
	                            SELECT ServiceId, InsurerId, MAX(DefineDate) AS DefineDate
	                            FROM InsurerServiceTarefeChanges
	                            GROUP BY ServiceId, InsurerId
                            )g on i.ServiceId == g.ServiceId AND i.InsurerId == g.InsurerId AND i.DefineDate == g.DefineDate							 						
                            WHERE 1=1 {0}
                                 ";
                s0 = "";
                if (ServiceId != null)
                    s0 += " AND i.ServiceId = @ServiceId ";
                if (InsurerId != null)
                    s0 += " AND i.InsurerId = @InsurerId ";


                query = string.Format(query, s0);
                var result2 = sql.Query(query, param: p, commandType: CommandType.Text);
                var tarefeResult = result2.Select(i =>
                               new
                               {
                                   Id = (int)i.Id,
                                   ServiceId = (int)i.ServiceId,
                                   InsurerId = (int)i.InsurerId,

                                   FreePrice = i.FreePrice == null ? 0 : (double)i.FreePrice,
                                   InsurerPrice = i.InsurerPrice == null ? 0 : (double)i.InsurerPrice,
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
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetServiceFinancialInfoX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);


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


                var detailResult = resultX.Select(i =>
                    new
                    {
                        PatientName = (string)i.PatientName,
                        ServiceGroupTitle = (string)i.ServiceGroupTitle,
                        ServiceTitle = (string)i.ServiceTitle,
                        SolarDate = (string)i.SolarDate,
                        ToothNumbers = (string)i.Tooth,
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
            if (sql == null) sql = DB.GetConnection();

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
                    //MonthServices = monthServicesResult,                        
                    //PatientsAgeRange = patientsAgeRangeResult,
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
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var ToothId = x.HasValue("ToothId") ? x.GetValue<int>("ToothId") : (int?)null;
                var ToothIds = x.HasValue("ToothIds") ? string.Join(" , ", x.GetValue<IEnumerable>("ToothIds").OfType<object>().Select(i => string.Format(" {0} ", int.Parse(Convert.ToString(i)))).ToArray()) : null;


                var p = new Dapper.DynamicParameters();
                p.Add("ToothId", value: ToothId);
                p.Add("ToothIds", value: ToothIds);


                var query = @"   
                                    SELECT  Id ,
                                            ToothName ,
                                            ToothTitle ,
                                            ToothGroup ,
                                            ToothImage ,                                                                               
                                            ToothRegion 
                                    FROM    Teeth
                                    WHERE   1=1 {0}
                                    
                                 ";


                var s0 = "";

                if (ToothId != null)
                    s0 += " AND Id = @ToothId ";
                if (ToothIds != null && ToothIds.Count() > 0)
                    s0 += string.Format(" AND Id IN ({0}) ", ToothIds);


                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var finalResult = result.Select(i =>
                   new
                   {
                       i.Id,
                       i.ToothName,
                       i.ToothTitle,
                       Tooth = string.Join("  -  ", string.Format("({0}) {1}", i.ToothName, i.ToothTitle)),
                       i.ToothGroup,
                       i.ToothImage,
                       i.ToothRegion,
                   }).ToList();



                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetOfficeInfoX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var DocterId = x.HasValue("DocterId") ? x.GetValue<int>("DocterId") : (int?)null;


                var p = new Dapper.DynamicParameters();
                p.Add("DocterId", value: DocterId);

                var query = @"
                                SELECT                                               
                                          OfficeName ,
                                          DoctorName,
                                          OfficeCode ,
                                          OfficeType ,
                                          NezamPezeshki , 
                                          PhoneNumber , 
                                          OfficeAddress ,
                                          Email,
                                          Website ,
                                          ModifiedDate	,
                                          IsDeleted	,
                                          DefaultDoctorId ,
                                          DefaultBasicInsurerId	,
                                          DefaultMaritalStatusId ,
                                          DefaultEducationLevelId ,
                                          DefaultNationalityId	
                                FROM Offices 
                                WHERE Id = 1
                               
                                 ";



                var result = sql.QueryMultiple(query, param: p, commandType: CommandType.Text);

                var finalResult = result.Read<dynamic>().Select(i =>
                  new
                  {
                      i.OfficeName,
                      i.DoctorName,
                      i.OfficeCode,
                      i.OfficeType,
                      i.NezamPezeshki,
                      i.PhoneNumber,
                      i.OfficeAddress,
                      i.Email,
                      i.Website,
                      i.ModifiedDate,
                      i.IsDeleted,
                      i.DefaultDoctorId,
                      i.DefaultBasicInsurerId,
                      i.DefaultMaritalStatusId,
                      i.DefaultEducationLevelId,
                      i.DefaultNationalityId
                  }).ToList();


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }
        //    بیماران نوبت داده شده
        public static JsonResponse<dynamic> GetAppointmentedPatientsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {

                var x = new RouteValueDictionary(searchObj);
                var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                var ServiceGroupId = x.HasValue("ServiceGroupId") ? x.GetValue<int>("ServiceGroupId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;


                var p = new Dapper.DynamicParameters();
                p.Add("DoctorId", value: DoctorId);
                p.Add("PatientId", value: PatientId);
                p.Add("ServiceGroupId", value: ServiceGroupId);
                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));


                var query = @"
                                SELECT * 
                                FROM 
                                (
	                                SELECT  pp.Id AS PatientId ,
			                                pp.FirstName || ' ' || pp.LastName AS PatientName ,
			                                pp.MobilePhone ,
			                                vst.Date,
			                                vst.StarTime,
                                            vst.EndTime,			                               
			                                '' AS Tamas ,
			                                svcg.Id ,
			                                svcg.Title AS ServiceGroupTitle ,			                             
			                                staf.Id AS StaffId ,
			                                staf.FirstName + ' ' + staf.LastName AS DoctorTitle ,
                                            staf.MedicalCouncilCode
	                                FROM Patients pp
			                        JOIN Visits vst ON pp.Id = vst.PatientId
			                        JOIN Staffs staf ON vst.DoctorId = staf.Id
			                        LEFT JOIN BaseCoding_ServiceGroups svcg  ON vst.ServiceGroupId = svcg.Id	                            		                                    
                                )temp                       
                                WHERE  1=1 {0}
                               
                                 ";

                string s0 = "";

                if (DoctorId != null)
                    s0 += " AND DoctorId = @DoctorId ";
                if (PatientId != null)
                    s0 += " AND PatientId = @PatientId ";

                if (ServiceGroupId != null)
                    s0 += " AND ServiceGroupId = @ServiceGroupId ";
                if (FromDate != null)
                    s0 += " AND Date >= @FromDate ";
                if (ToDate != null)
                    s0 += " AND Date <= @ToDate ";

                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var finalResult = result.Select(i =>
                   new
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
                   }).ToList();




                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetVisitX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

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

                var query = @"
                                SELECT  vst.Id ,                                         
	                                    vst.PatientId , 
										pp.FirstName || ' ' || pp.LastName AS PatientName ,
										vst.DoctorId , 
										staf.FirstName || ' ' || staf.LastName AS DoctorTitle,
                                        staf.MedicalCouncilCode,										
	                                    vst.ServiceGroupId , 
										svcg.Title AS ServiceGroupTitle,
                                        vst.Date , 
	                                    vst.StartTime , 
	                                    vst.EndTime , 
                                       
	                                    vst.Description , 
	                                    vst.Color ,
	                                    vst.IsDeleted , 
                                        pp.MobilePhone	
                                FROM Visits  vst
								JOIN Patients pp ON pp.Id = vst.PatientId
								LEFT JOIN Staffs staf ON staf.Id = vst.DoctorId
                                LEFT JOIN BaseCoding_ServiceGroups svcg ON svcg.Id = vst.ServiceGroupId 
                                                                 
                                WHERE  1=1 {0}
                                 ";
                var p = new Dapper.DynamicParameters();
                p.Add("Id", value: Id);
                p.Add("DoctorId", value: DoctorId);
                p.Add("PatientId", value: PatientId);

                p.Add("ServiceGroupId", value: ServiceGroupId);
                p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));
                p.Add("IsDeleted", value: IsDeleted);

                string s0 = "";
                if (Id != null)
                    s0 += " AND vst.Id = @Id ";
                if (DoctorId != null)
                    s0 += " AND vst.DoctorId = @DoctorId ";
                if (PatientId != null)
                    s0 += " AND vst.PatientId = @PatientId ";
                if (ServiceGroupId != null)
                    s0 += " AND vst.ServiceGroupId = @ServiceGroupId ";
                if (Date != null)
                    s0 += " AND vst.Date = @Date ";
                if (FromDate != null)
                    s0 += " AND vst.Date >= @FromDate ";
                if (ToDate != null)
                    s0 += " AND vst.Date <= @ToDate ";
                if (IsDeleted != null)
                    s0 += " AND vst.IsDeleted = @IsDeleted ";

                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var resultList = result.Select(i =>
                   new
                   {
                       Id = (int)i.Id,
                       PatientId = (int?)i.PatientId,
                       PatientName = (string)i.PatientName,
                       DoctorId = (int?)i.DoctorId,
                       DoctorTitle = (string)i.DoctorTitle,
                       MedicalCouncilCode = (string)i.MedicalCouncilCode,
                       ServiceGroupId = (int?)i.ServiceGroupId,
                       ServiceGroupTitle = (string)i.ServiceGroupTitle,
                       Date = (DateTime)Publics.GetDate(i.Date),
                       SolarDate = Publics.GetSolarDate(i.Date),
                       StartTime = TimeSpan.Parse(i.StartTime),
                       EndTime = TimeSpan.Parse(i.EndTime),
                       Description = (string)i.Description,
                       Color = (int?)i.Color,
                       IsDeleted = Convert.ToBoolean(i.IsDeleted),
                       MobilePhone = (string)i.MobilePhone
                   }).ToList();


                var finalResult = resultList.Select(i =>
                new
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
                    i.SolarDate,
                    StartTime = (i.StartTime),
                    EndTime = (i.EndTime),
                    i.Description,
                    i.Color,
                    i.IsDeleted,
                    i.MobilePhone,


                    CountItems = resultList != null && resultList.Count > 0 ? resultList.Count() : 0,
                });


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetStaffsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

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

                var query = @"

                                SELECT  *
                                FROM  
                                (
                                    SELECT 
                                            staf.Id AS StaffId ,
                                            staf.StaffTypeId ,
		                                    staf.FirstName ,
		                                    staf.LastName ,
                                            staf.FirstName || '  ' || staf.LastName  AS FullName ,
                                            staf.NationalCode ,
                                            staf.FixedPhone ,
                                            staf.MobilePhone ,
                                            staf.Address ,
                                            staf.Comment ,
                                            staf.IsDeleted ,
                                            staf.Date ,
                                            staf.GenderId ,
		                                    gen.Title AS GenderTitle,
                                            staft.Title AS StaffTypeTitle ,
		                                    SpecialtyId,
                                            spi.Title AS SpecialtyTitle,
		                                    usr.Id AS UserId , 
                                            usr.UserName ,
		                                    usr.UserPass ,		                                 
                                            usr.IsDeleted AS IsDeletedUser
                                    FROM  Staffs staf
                                    JOIN  BaseCoding_StaffTypes staft  ON staf.StaffTypeId = staft.Id
                                    LEFT JOIN Users usr ON usr.StaffId = staf.Id
                                    LEFT JOIN BaseCoding_Specialties spi ON spi.Id = staf.SpecialtyId
                                    LEFT JOIN BaseCoding_Genders gen ON gen.Id = staf.GenderId
                                )temp
                                WHERE 1=1 {0}
                                 ";
                var p = new Dapper.DynamicParameters();
                p.Add("StaffId", value: StaffId);
                p.Add("StaffTypeId", value: StaffTypeId);
                p.Add("FirstName", value: FirstName);
                p.Add("LastName", value: LastName);
                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));
                p.Add("IsDeleted", value: IsDeleted);

                var s0 = "";
                if (StaffId != null)
                    s0 += " AND StaffId = @StaffId ";
                if (StaffTypeId != null)
                    s0 += " AND StaffTypeId = @StaffTypeId ";
                if (FirstName != null)
                    s0 += string.Format(" AND FirstName LIKE '%{0}%' ", FirstName);
                if (LastName != null)
                    s0 += string.Format(" AND LastName LIKE '%{0}%' ", LastName);
                if (FromDate != null)
                    s0 += " AND Date >= @FromDate ";
                if (ToDate != null)
                    s0 += " AND Date <= @ToDate ";
                if (IsDeleted != null)
                    s0 += " AND IsDeleted = @IsDeleted ";

                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var finalResult = result.Select(i =>
                   new
                   {
                       Id = (int)i.StaffId,
                       StaffId = (int)i.StaffId,
                       FirstName = (string)i.FirstName,
                       LastName = (string)i.LastName,
                       FullName = (string)i.FullName,
                       Title = (string)i.FullName,
                       NationalCode = (string)i.NationalCode,
                       FixedPhone = (string)i.FixedPhone,
                       MobilePhone = (string)i.MobilePhone,
                       Address = (string)i.Address,
                       Comment = (string)i.Comment,
                       IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted),
                       Date = Publics.GetDate(i.Date),
                       //Date = Publics.ConvertStringToDateTime(i.Date),
                       SolarRecruitmentDate = Publics.GetSolarDate(i.Date),
                       GenderId = (int?)i.GenderId,
                       GenderTitle = (string)i.GenderTitle,
                       StaffTypeId = (int?)i.StaffTypeId,
                       StaffTypeTitle = (string)i.StaffTypeTitle,

                       SpecialtyId = (int?)i.SpecialtyId,
                       SpecialtyTitle = (string)i.SpecialtyTitle,

                       UserId = (int?)i.UserId,
                       UserName = (string)i.UserName,
                       UserPass = (string)i.UserPass,
                       IsDeletedUser = i.IsDeletedUser == null ? false : Convert.ToBoolean(i.IsDeletedUser)
                   }).ToList();


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {

                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetDoctorsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();


            try
            {
                var x = new RouteValueDictionary(searchObj);
                var StaffId = x.HasValue("StaffId") ? x.GetValue<int>("StaffId") : (int?)null;

                var query = @"

                                SELECT  *
                                FROM  
                                (
                                    SELECT 
                                            staf.Id AS StaffId ,
                                            staf.StaffTypeId ,
		                                    staf.FirstName ,
		                                    staf.LastName ,
                                            staf.FirstName || '  ' || staf.LastName  AS FullName ,
                                            staf.NationalCode ,
                                            staf.FixedPhone ,
                                            staf.MobilePhone ,
                                            staf.Address ,
                                            staf.Comment ,
                                            staf.IsDeleted ,
                                            staf.Date ,
                                            staf.GenderId ,
		                                    gen.Title AS GenderTitle,
                                            staft.Title AS StaffTypeTitle ,
		                                    SpecialtyId,
                                            spi.Title AS SpecialtyTitle		                                   
                                    FROM  Staff_Doctors doc                                    
                                    LEFT JOIN Staff staf  ON staf.Id = doc.Id
                                    LEFT JOIN BaseCoding_Specialties spi ON spi.Id = staf.SpecialtyId
                                    LEFT JOIN BaseCoding_Genders gen ON gen.Id = staf.GenderId
                                )temp
                                WHERE 1=1 {0}
                                 ";
                var p = new Dapper.DynamicParameters();
                p.Add("StaffId", value: StaffId);

                var s0 = "";
                if (StaffId != null)
                    s0 += " AND StaffId = @StaffId ";


                query = string.Format(query, s0);

                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);


                var finalResult = result.Select(i =>
                   new
                   {
                       Id = (int)i.Id,
                       DoctorId = (int)i.Id,
                       FirstName = (string)i.FirstName,
                       LastName = (string)i.LastName,
                       FullName = (string)i.FullName,
                       Title = (string)i.Title,
                       NationalCode = (string)i.NationalCode,
                       FixedPhone = (string)i.FixedPhone,
                       MobilePhone = (string)i.MobilePhone,
                       Address = (string)i.Address,
                       Comment = (string)i.Comment,
                       IsDeleted = Convert.ToBoolean(i.IsDeleted),
                       Date = Convert.ToDateTime(i.Date),
                       //Date = Publics.ConvertStringToDateTime(i.Date),
                       SolarRecruitmentDate = (string)i.SolarRecruitmentDate,
                       GenderId = (int?)i.GenderId,
                       GenderTitle = (string)i.GenderTitle,
                       StaffTypeId = (int?)i.StaffTypeId,
                       StaffTypeTitle = (string)i.StaffTypeTitle,

                       SpecialtyId = (int?)i.SpecialtyId,
                       SpecialtyTitle = (string)i.SpecialtyTitle,

                   }).ToList();


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {

                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetInsuranceFinancialsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var InsuranceId = x.HasValue("InsuranceId") ? x.GetValue<int>("InsuranceId") : (int?)null;
                var InsurerId = x.HasValue("InsurerId") ? x.GetValue<int>("InsurerId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;

                var query = @"
                                    SELECT  *
                                    FROM  
                                    (
                                        SELECT      insf.Id AS InsurerFinancialId,
			                                        insf.Date AS RegisterDate, 
			                                        insf.FromDate , 
                                                    insf.ToDate , 		
			                                        ins.InsuranceId,		
			                                        ins.Id AS InsurerId, 
			                                        ins.Title AS InsurerTitle,
			                                        IFNULL(RequestedValue,0)  AS RequestedValue , 
                                                    IFNULL(ReceivedValue,0)   AS ReceivedValue, 
                                                    IFNULL(DeductionValue,0)  AS DeductionValue , 
                                                    IFNULL(RemainPrice,0)     AS RemainPrice ,
			                                        insf.Comment, 
			                                        insf.IsDeleted

                                        FROM         InsurerFinancials AS insf 
                                        INNER JOIN   Insurers AS ins ON insf.InsurerId = ins.Id
                                    )temp
                                    WHERE 1=1 {0}
                                 ";
                var p = new Dapper.DynamicParameters();
                p.Add("Id", value: Id);
                p.Add("InsuranceId", value: InsuranceId);
                p.Add("InsurerId", value: InsurerId);
                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));

                string s0 = "";
                if (Id != null)
                    s0 += " AND InsurerFinancialId = @Id ";
                if (InsuranceId != null)
                    s0 += " AND InsuranceId = @InsuranceId ";
                if (InsurerId != null)
                    s0 += " AND InsurerId = @InsurerId ";
                if (FromDate != null)
                    s0 += " AND  FromDate >= @FromDate ";
                if (ToDate != null)
                    s0 += " AND ToDate <= @ToDate ";

                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var finalResult = result.Select(i =>
                   new
                   {
                       Id = (int)i.InsurerFinancialId,
                       InsurerFinancialId = (int)i.InsurerFinancialId,
                       InsuranceId = (int)i.InsuranceId,
                       InsurerId = (int)i.InsurerId,
                       InsurerTitle = (string)i.InsurerTitle,
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
                       Comment = (string)i.Comment,
                       IsDeleted = Convert.ToBoolean(i.IsDeleted),
                   }).ToList();


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetInsurersX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var InsuranceId = x.HasValue("InsuranceId") ? x.GetValue<int>("InsuranceId") : (int?)null;
                var InsuranceBoxId = x.HasValue("InsuranceBoxId") ? x.GetValue<int>("InsuranceBoxId") : (int?)null;
                var InsurerId = x.HasValue("InsurerId") ? x.GetValue<int>("InsurerId") : (int?)null;
                var InsurerTitle = x.HasValue("InsurerTitle") ? x.GetValue<string>("InsurerTitle") : null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                var query = @"
                                    SELECT * FROM
                                    (
                                        SELECT      insr.Id AS InsurerId, 
                                                    insr.Title AS InsurerTitle,           
		                                            insr.IsDeleted,		   
		                                            insr.InsuranceId,
		                                            insc.Title AS InsuranceTitle,
		                                            insr.InsuranceBoxId,
		                                            inscb.Title AS InsuranceBoxTitle,
                                                    insr.IsBasic ,
		                                            insr.IsExtra ,
		                                            insr.InsurerPercent ,		                                     
		                                            insr.Comment 


                                        FROM       Insurers insr 
                                        JOIN       BaseCoding_Insurances insc ON insc.Id = insr.InsuranceId
                                        JOIN       BaseCoding_InsuranceBoxs inscb ON inscb.Id = insr.InsuranceBoxId
                                    )temp
                                    WHERE 1=1 {0}
                                 ";
                var p = new Dapper.DynamicParameters();
                p.Add("InsuranceId", value: InsuranceId);
                p.Add("InsuranceBoxId", value: InsuranceBoxId);
                p.Add("InsurerId", value: InsurerId);
                p.Add("InsurerTitle", value: InsurerTitle);
                p.Add("IsDeleted", value: IsDeleted);

                string s0 = "";
                if (InsuranceId != null)
                    s0 += " AND InsuranceId = @InsuranceId ";
                if (InsuranceBoxId != null)
                    s0 += " AND InsuranceBoxId = @InsuranceBoxId ";
                if (InsurerId != null)
                    s0 += " AND InsurerId = @InsurerId ";
                if (InsurerTitle != null)
                    s0 += string.Format(" AND InsurerTitle LIKE '%{0}%' ", InsurerTitle);
                if (IsDeleted != null)
                    s0 += " AND IsDeleted = @IsDeleted ";

                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var finalResult = result.Select(i =>
                   new
                   {
                       InsurerId = (int)i.InsurerId,
                       InsurerTitle = (string)i.InsurerTitle,
                       IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted),
                       InsuranceId = i.InsuranceId == null ? 0 : (int)i.InsuranceId,
                       InsuranceTitle = (string)i.InsuranceTitle,
                       InsuranceBoxId = i.InsuranceBoxId == null ? 0 : (int)i.InsuranceBoxId,
                       InsuranceBoxTitle = (string)i.InsuranceBoxTitle,


                       IsBasic = i.IsBasic == null ? false : Convert.ToBoolean(i.IsBasic),
                       IsExtra = i.IsExtra == null ? false : Convert.ToBoolean(i.IsExtra),
                       InsurerPercent = i.InsurerPercent == null ? 0 : (float)i.InsurerPercent,
                       Comment = (string)i.Comment
                   }).ToList();




                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetInsurersServicePricingX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var InsuranceId = x.HasValue("InsuranceId") ? x.GetValue<int>("InsuranceId") : (int?)null;
                var InsurerId = x.HasValue("InsurerId") ? x.GetValue<int>("InsurerId") : (int?)null;
                var ServiceId = x.HasValue("ServiceId") ? x.GetValue<int>("ServiceId") : (int?)null;
                var ServiceDate = x.HasValue("ServiceDate") ? x.GetValue<DateTime>("ServiceDate") : DateTime.Now;

                var p = new Dapper.DynamicParameters();
                p.Add("InsuranceId", value: InsuranceId);
                p.Add("InsurerId", value: InsurerId);
                p.Add("ServiceId", value: ServiceId);
                p.Add("ServiceDate", value: Publics.ConvertDateTimeToString(ServiceDate));

                string query = "";
                string s0 = "";



                query = @"                                    
                            SELECT    Id , 
                                    Title ,           		                                        		   
		                            InsuranceId,		                                       
		                            InsuranceBoxId,
                                    IsBasic ,
		                            IsExtra ,
		                            InsurerPercent,
                                    IsDeleted

                            FROM       Insurers insrr                                                                      						
                            WHERE 1=1 {0}
                            ";
                if (InsuranceId != null)
                    s0 += " AND InsuranceId = @InsuranceId ";
                if (InsurerId != null)
                    s0 += " AND Id = @InsurerId ";

                query = string.Format(query, s0);
                var result1 = sql.Query(query, param: p, commandType: CommandType.Text);

                var insurersResult = result1.Select(i =>
                       new
                       {
                           InsurerId = (int)i.Id,
                           InsurerTitle = (string)i.Title,
                           InsuranceId = i.InsuranceId == null ? 0 : (int)i.InsuranceId,
                           InsuranceBoxId = i.InsuranceBoxId == null ? 0 : (int)i.InsuranceBoxId,
                           IsBasic = i.IsBasic == null ? false : Convert.ToBoolean(i.IsBasic),
                           IsExtra = i.IsExtra == null ? false : Convert.ToBoolean(i.IsExtra),
                           InsurerPercent = i.InsurerPercent == null ? 0 : (int)i.InsurerPercent,
                           IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted),
                       }).ToList();

                if (insurersResult.Count == 0)
                    throw new Exception("1");


                query = @"
                                    
                                  SELECT        		                                       
                                        Id ,
                                        InsurerId,
                                        ServiceId,
										FreePrice,
										InsurerPrice,
										DefineDate,
										RunDate

                                  FROM    InsurerServiceTarefeChanges instc  								 						
                                  WHERE 1=1 {0}
                                 ";
                s0 = "";
                if (ServiceId != null)
                    s0 += " AND ServiceId = @ServiceId ";
                if (InsurerId != null)
                    s0 += " AND InsurerId = @InsurerId ";


                query = string.Format(query, s0);
                var result2 = sql.Query(query, param: p, commandType: CommandType.Text);
                var tarefeResult = result2.Select(i =>
                               new
                               {
                                   Id = (int?)i.Id,
                                   ServiceId = (int?)i.ServiceId,
                                   InsurerId = (int?)i.InsurerId,

                                   FreePrice = i.FreePrice == null ? 0 : (decimal)i.FreePrice,
                                   InsurerPrice = i.InsurerPrice == null ? 0 : (decimal)i.InsurerPrice,
                                   DefineDate = Publics.GetDate(i.DefineDate),
                                   SolarDefineDate = Publics.GetSolarDate(i.DefineDate),
                                   RunDate = Publics.GetDate(i.RunDate),
                                   SolarRunDate = Publics.GetSolarDate(i.RunDate),

                               }).ToList();



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
                            let defineDate = itItem != null ? itItem.DefineDate : 0
                            let solarDefineDate = itItem != null ? itItem.SolarDefineDate : 0
                            let runDate = itItem != null ? itItem.RunDate : 0
                            let solarRunDate = itItem != null ? itItem.SolarRunDate : 0
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
                                //ServiceId = result2.ToList().Where(i => i.)

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




                //var finalResult = (
                //            from iItem in insurersResult
                //            join tItem in tarefeResult on iItem.InsurerId equals tItem.InsurerId into tTemp
                //            from itItem in tTemp.DefaultIfEmpty()

                //            select new
                //            {
                //                iItem.InsuranceId,
                //                iItem.InsuranceBoxId,
                //                iItem.InsurerTitle,
                //                iItem.IsBasic,
                //                iItem.IsExtra,
                //                iItem.InsurerPercent,
                //                iItem.IsDeleted,

                //                itItem.InsurerServiceTarefeChangeId,
                //                itItem.ServiceId,
                //                itItem.InsurerId,


                //                itItem.FreePrice,
                //                itItem.InsurerPrice,
                //                itItem.DefineDate,
                //                itItem.SolarDefineDate,
                //                itItem.RunDate,
                //                itItem.SolarRunDate,

                //                itItem.serviceFinancial.InsurerShare,
                //                itItem.serviceFinancial.FranchiseShare,
                //                itItem.serviceFinancial.FreeShare,
                //                itItem.serviceFinancial.PatientShare,
                //            }).ToList()
                //         .OrderByDescending(i => i.DefineDate)
                //         .OrderByDescending(i => i.InsurerServiceTarefeChangeId)
                //         .ToList();
                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
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
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var TimeId = x.HasValue("TimeId") ? x.GetValue<int>("TimeId") : (int?)null;
                var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                var query = @"
                                SELECT Id,
                                       DoctorId,                                      
                                       Date,
                                       StartTime,
                                       EndTime,
                                       Description,
                                       IsDeleted 
                                FROM   WorkTimes                       
                                WHERE  1=1 {0}
                                ORDER BY date(Date)
                                 ";
                var p = new Dapper.DynamicParameters();
                p.Add("DoctorId", value: DoctorId);
                p.Add("FromDate", value: Publics.ConvertDateToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateToString(ToDate));
                p.Add("IsDeleted", value: IsDeleted);

                string s0 = "";
                if (DoctorId != null)
                    s0 += " AND DoctorId = @DoctorId ";
                if (FromDate != null)
                    s0 += " AND Date >= @FromDate ";
                if (ToDate != null)
                    s0 += " AND Date <= @ToDate ";
                if (IsDeleted != null)
                    s0 += " AND IsDeleted = @IsDeleted ";

                query = string.Format(query, s0);
                var result = sql.QueryMultiple(query, param: p, commandType: CommandType.Text);

                var resultList = result.Read<dynamic>().Select(i =>
                   new
                   {
                       Id = (int)i.Id,
                       DoctorId = (int)i.DoctorId,
                       Date = Publics.GetDate(i.Date),
                       DayOfWeek = Publics.GetDate(i.Date).ToString("dddd"),
                       StartTime = (string)i.StartTime,
                       EndTime = (string)i.EndTime,
                       StartDateTime = Publics.GetDate(string.Format("{0} {1}", i.Date, i.StartTime)),
                       EndDateTime = Publics.GetDate(string.Format("{0} {1}", i.Date, i.EndTime)),
                       Description = (string)i.Description,
                       IsDeleted = Convert.ToBoolean(i.IsDeleted),
                   }).ToList();


                var finalResult = resultList;


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetCostFinancialsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var CostId = x.HasValue("CostId") ? x.GetValue<int>("CostId") : (int?)null;
                var CostTypeId = x.HasValue("CostTypeId") ? x.GetValue<int>("CostTypeId") : (int?)null;
                var BargainSideId = x.HasValue("BargainSideId") ? x.GetValue<int>("BargainSideId") : (int?)null;
                var PayTypeId = x.HasValue("PayTypeId") ? x.GetValue<int>("PayTypeId") : (int?)null;
                var PayTypeIds = x.HasValue("PayTypeIds") ? string.Join(" , ", x.GetValue<IEnumerable>("PayTypeIds").OfType<object>().Select(i => string.Format(" {0} ", int.Parse(Convert.ToString(i)))).ToArray()) : null;
                var FromDate = x.HasValue("FromDate") ? x.GetValue<DateTime>("FromDate") : (DateTime?)null;
                var ToDate = x.HasValue("ToDate") ? x.GetValue<DateTime>("ToDate") : (DateTime?)null;



                var query = @"

                                SELECT  *  FROM
                                (
                                    SELECT  
                                            cc.Id AS CostId, 						
					                        (CASE WHEN  cc.BargainSideId <> 0 THEN ac.Title ELSE ct.Title END) AS CostTitle , 
					                        cc.CostTypeId, 			
                                            ct.Title AS  CostTypeTitle, 
					                        cc.Amount, 
					                        cc.BargainSideId, 
					                        ac.Title AS  BargainSideTitle,
					                        cc.PayTypeId, 
					                        ps.Title AS PayTypeTitle, 					 
					                        cc.FactorNumber, 
					                        cc.Date,
					                        cc.Comment, 
					 					                     					                                             			 
					                        cc.ChequeNumber, 					 					                      
				                            cc.BankId,
				                            bnk.Title AS BankTitle ,				    		                      
                                            cc.DateOfIssuance, 					
					                        cc.DateOfMaturity,
                                            cc.ChequeStatusId,
		                                    chqSts.Title AS  ChequeStatusTitle,
					                        cc.IsDeleted
					 										 					 
                                    FROM          Costs cc 
                                    JOIN          BaseCoding_CostTypes ct ON  ct.Id = cc.CostTypeId
                                    LEFT JOIN     BaseCoding_BargainSides ac ON ac.Id = cc.BargainSideId 
                                    LEFT JOIN     BaseCoding_PayTypes ps ON cc.PayTypeId = ps.Id 
                                    LEFT JOIN     BaseCoding_Banks bnk  ON bnk.Id = cc.BankId
                                    LEFT JOIN     BaseCoding_ChequeStatus chqSts on chqSts.Id = cc.ChequeStatusId
                                    ORDER BY cc.Date
                                )temp
                                WHERE IsDeleted <>1   {0}
                                 ";
                var p = new Dapper.DynamicParameters();
                p.Add("Id", value: Id);
                p.Add("CostId", value: CostId);
                p.Add("CostTypeId", value: CostTypeId);
                p.Add("BargainSideId", value: BargainSideId);
                p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));
                p.Add("PayTypeId", value: PayTypeId);
                p.Add("PayTypeIds", value: PayTypeIds);

                var s0 = "";
                if (Id != null)
                    s0 += " AND CostId = @Id ";
                if (CostId != null)
                    s0 += " AND CostId = @CostId ";
                if (CostTypeId != null)
                    s0 += " AND CostTypeId = @CostTypeId ";
                if (BargainSideId != null)
                    s0 += " AND BargainSideId = @BargainSideId  ";
                if (FromDate != null)
                    s0 += " AND  [Date] >= @FromDate ";
                if (ToDate != null)
                    s0 += " AND [Date] <= @ToDate ";
                if (PayTypeId != null && PayTypeId != 0)
                    s0 += " AND  PayTypeId = @PayTypeId ";
                if (PayTypeIds != null && PayTypeIds.Length > 0)
                    s0 += string.Format(" AND PayTypeId IN ({0}) ", PayTypeIds);

                query = string.Format(query, s0);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var finalResult = result.Select(i =>
                   new
                   {
                       Id = (int)i.CostId,
                       CostId = (int)i.CostId,
                       CostTitle = (string)i.CostTitle,
                       CostTypeId = (int?)i.CostTypeId,
                       CostTypeTitle = (string)i.CostTypeTitle,
                       Amount = (double)i.Amount,
                       BargainSideId = (int?)i.BargainSideId,
                       BargainSideTitle = (string)i.BargainSideTitle,
                       PayTypeId = (int?)i.PayTypeId,
                       PayTypeTitle = (string)i.PayTypeTitle,
                       FactorNumber = (string)i.FactorNumber,
                       Date = Publics.GetDate(i.Date),
                       SolarDate = Publics.GetSolarDate(i.Date),


                       ChequeNumber = (string)i.ChequeNumber,
                       BankId = (int?)i.BankId,
                       BankTitle = (string)i.BankTitle,
                       DateOfIssuance = Publics.GetDate(i.DateOfIssuance),
                       SolarDateOfIssuance = Publics.GetSolarDate(i.DateOfIssuance),
                       DateOfMaturity = Publics.GetDate(i.DateOfMaturity),
                       SolarDateOfMaturity = Publics.GetSolarDate(i.DateOfMaturity),
                       ChequeTypeId = 2, // واریز
                       ChequeTypeTitle = "واریز",
                       ChequeStatusId = (int?)i.ChequeStatusId,
                       ChequeStatusTitle = (string)i.ChequeStatusTitle,

                       Comment = (string)i.Comment,
                       IsDeleted = Convert.ToBoolean(i.IsDeleted)
                   }).OrderByDescending(i => i.Date).ToList();



                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetUserX(dynamic searchObj)
        {

            if (sql == null) sql = DB.GetConnection();

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


                var p = new Dapper.DynamicParameters();
                p.Add("UserId", value: UserId);
                p.Add("StaffId", value: StaffId);
                p.Add("UserName", value: UserName);
                p.Add("UserPass", value: UserPass);
                p.Add("Comment", value: Comment);
                p.Add("IsDeleted", value: IsDeleted);

                if (IsUserLogin == true)
                {
                    if (UserName == null)
                        throw new Exception(" نام کاربری وارد نشده است");
                    if (UserPass == null)
                        throw new Exception(" کلمه عبور وارد نشده است");
                }



                var query = @"
                                 SELECT * FROM
                                 (
                                    SELECT      user.Id,  
                                                user.UserName,
											    user.UserPass ,    
											    staff.FirstName || ' ' || staff.LastName AS staffName ,
                                                user.StaffId,
                                                user.Email,
											    user.IsDeleted
                                    FROM Users user   
								    LEFT JOIN Staffs staff ON  staff.Id = user.StaffId                                     
                                 )temp                                     
                                    WHERE   1=1 {0}
                                 ";

                string s0 = "";

                if (UserId != null)
                    s0 += " AND Id = @UserId ";
                if (StaffId != null)
                    s0 += " AND StaffId = @StaffId ";

                if (UserName != null)
                    s0 += string.Format(" AND  UserName =  LOWER('{0}') ", UserName);
                if (UserPass != null)
                    s0 += string.Format(" AND  UserPass = LOWER('{0}') ", UserPass);

                if (IsDeleted != null)
                    s0 += " AND IsDeleted = @IsDeleted ";


                query = string.Format(query, s0);
                var result = sql.QueryMultiple(query, param: p, commandType: CommandType.Text);

                var resultList = result.Read<dynamic>().Select(i =>
                   new
                   {
                       i.Id,
                       UserId = i.Id,
                       i.UserName,
                       i.UserPass,
                       UserTitle = i.staffName,
                       i.StaffId,
                       i.Email,
                       IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted)

                   }).ToList();


                var finalResult = resultList;


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                System.Windows.MessageBox.Show(ex.Message);
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetUserPermissionsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var UserId = x.HasValue("UserId") ? x.GetValue<int>("UserId") : (int?)null;

                if (UserId == null)
                    new Exception("UserId وارد نشده است");

                var query = @"
                                
                               SELECT   appA.Id AS AppActionId,
		                                appA.FormTitle,
		                                appA.GroupTitle,
		                                appA.ActionTitle,
		                                IFNULL(usrP.Value, 0) AS Value 	 
                                FROM AppActions appA 
                                LEFT JOIN UserPermissions usrP ON usrP.AppActionId = appA.Id     
                                          AND usrP.UserId = @UserId                           
                                
                                 ";


                var p = new Dapper.DynamicParameters();
                p.Add("UserId", value: UserId);

                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var finalResult = result.Select(i =>
                   new
                   {
                       i.AppActionId,
                       i.FormTitle,
                       i.GroupTitle,
                       i.ActionTitle,
                       i.Value
                   }).ToList();


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> GetBaseCodingX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();

            try
            {
                var x = new RouteValueDictionary(searchObj);
                var EntityName = x.HasValue("EntityName") ? x.GetValue<string>("EntityName") : null;
                var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                var Title = x.HasValue("Title") ? x.GetValue<string>("Title") : null;
                var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;


                if (EntityName == null)
                    throw new Exception("EntityName IS NULL");

                var p = new Dapper.DynamicParameters();
                p.Add("Id", value: Id);
                p.Add("Title", value: Title);
                p.Add("IsDeleted", value: IsDeleted);


                var query = "";
                var s0 = EntityName;
                var s1 = "";

                query = @" SELECT * FROM {0} 
                               WHERE 1=1 {1} 
                               ORDER BY Id ASC  ";

                if (Id != null)
                    s1 += " AND Id = @Id ";
                if (Title != null)
                    s1 += " AND Title = @Title ";
                if (IsDeleted != null)
                    s1 += " AND IsDeleted = @IsDeleted ";




                query = string.Format(query, s0, s1);
                var result = sql.Query(query, param: p, commandType: CommandType.Text);

                var resultList = result.Select(i =>
                   new
                   {
                       Id = i.Id,
                       Code = i.Code,
                       Title = i.Title,
                       Terminology = i.Terminology == null ? "" : i.Terminology,
                       IsDeleted = i.IsDeleted == null ? false : Convert.ToBoolean(i.IsDeleted),
                       Comment = i.Description == null ? "" : i.Description,

                       Color = i.Color == null ? 0 : (int)i.Color,
                   }).ToList();


                var finalResult = resultList;


                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static string GetSettings()
        {
            if (sql == null) sql = DB.GetConnection();

            string query = "SELECT BackupPath FROM Offices WHERE Id = 1 ";

            var result = sql.Query(query, commandType: CommandType.Text);

            var resultObj = result.Select(i =>
                       new
                       {
                           BackupPath = i.BackupPath

                       }).FirstOrDefault();

            return resultObj.BackupPath;

        }






        ///////////////////////////////////////////////////////////////////////////////////////////////////////




        public static JsonResponse<dynamic> DefineServiceX(dynamic searchObj)
        {
            if (sql == null)
                sql = DB.GetConnection();

            using (SQLiteTransaction transactionScope = sql.BeginTransaction())
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
                    var DefineDate = Publics.ConvertDateTimeToString(DateTime.Now);
                    var ModifiedDate = Publics.ConvertDateTimeToString(DateTime.Now);
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;
                    var ServiceFreePrice = x.HasValue("ServiceFreePrice") ? x.GetValue<double>("ServiceFreePrice") : (double?)null;


                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("ServiceGroupId", value: ServiceGroupId);
                    p.Add("Code", value: Code);
                    p.Add("Title", value: Title);
                    p.Add("Color", value: Color);
                    p.Add("IsToothNumber", value: IsToothNumber);
                    p.Add("IsMoreTooth", value: IsMoreTooth);
                    p.Add("IsDeleted", value: IsDeleted);
                    p.Add("DefineDate", value: DefineDate);
                    p.Add("ModifiedDate", value: ModifiedDate);
                    p.Add("Comment", value: Comment);

                    var query = "";
                    var s0 = "";

                    if (ActionType == "New")
                    {
                        query = @" 
                                    
                                INSERT  INTO Services
                                        (                                              
                                            ServiceGroupId ,    
                                            Code,
                                            Title ,
                                            Color ,
                                            IsToothNumber ,
                                            IsMoreTooth ,
                                            DefineDate,
                                            ModifiedDate,
                                            IsDeleted ,
                                            Comment
                                        )
                                       
                                    VALUES  
                                        (                                                            
                                            @ServiceGroupId ,  
                                            @Code,
                                            @Title ,
                                            @Color ,
                                            @IsToothNumber ,
                                            @IsMoreTooth ,
                                            @DefineDate,
                                            @ModifiedDate ,
                                            @IsDeleted ,
                                            @Comment
                                        )
                                   ;
                                   SELECT last_insert_rowid()
                                  
                                 ";
                    }
                    else if (ActionType == "Edit")
                    {
                        if (Id == null)
                            new Exception("ServiceId وازد نشده است");


                        query = @" 
                                
                                UPDATE Services  SET 
                                    {0}                                    
                                WHERE Id = @Id 
                                 ";



                        if (ServiceGroupId != null)
                            s0 += " ServiceGroupId = @ServiceGroupId , ";
                        if (Code != null)
                            s0 += " Code = @Code , ";
                        if (Title != null)
                            s0 += " Title = @Title , ";
                        if (Color != null)
                            s0 += " Color = @Color , ";
                        if (IsToothNumber != null)
                            s0 += " IsToothNumber = @IsToothNumber , ";
                        if (IsMoreTooth != null)
                            s0 += " IsMoreTooth = @IsMoreTooth , ";
                        if (ModifiedDate != null)
                            s0 += " ModifiedDate = @ModifiedDate , ";
                        if (IsDeleted != null)
                            s0 += " IsDeleted = @IsDeleted , ";
                        if (Comment != null)
                            s0 += " Comment = @Comment , ";

                        s0 = s0.TrimEnd().TrimEnd(',');
                    }

                    query = string.Format(query, s0);
                    var data = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var serviceId = data;

                    if (ActionType == "Edit")
                        serviceId = Id.Value;

                    if (serviceId != null && ServiceFreePrice != null)
                    {
                        JsonResponse<dynamic> result = new JsonResponse<dynamic>();

                        dynamic iObj = new ExpandoObject();
                        iObj.ServiceId = serviceId;
                        iObj.InsurerIds = new List<int>() { 0 };
                        iObj.FreePrice = Convert.ToDouble(ServiceFreePrice);
                        iObj.InsurerPrice = Convert.ToDouble(0);
                        iObj.DefineDate = DateTime.Now;
                        iObj.RunDate = DateTime.Now;

                        result = Dentistry.DataProvider.DefineInsurersPricingX(iObj);

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
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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

                    var ToothList = x.HasValue("ToothIds") ? string.Join(" , ", x.GetValue<IEnumerable>("ToothIds").OfType<object>().Select(i => i).ToArray()) : null;

                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("PatientId", value: PatientId);
                    p.Add("CheckupTypeId", value: CheckupTypeId);
                    p.Add("ServiceGroupId", value: ServiceGroupId);
                    p.Add("ServiceId", value: ServiceId);
                    p.Add("ToothIds", value: ToothList);
                    p.Add("ProviderDoctorId", value: ProviderDoctorId);
                    p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                    p.Add("Comment", value: Comment);
                    p.Add("IsHadMoreTooth", value: IsHadMoreTooth);
                    p.Add("InsurerServiceTarefeChangeId", value: InsurerServiceTarefeChangeId);
                    p.Add("IsDeleted", value: IsDeleted);

                    p.Add("ServicePrice", value: ServicePrice);
                    p.Add("InsurerPrice", value: InsurerPrice);
                    p.Add("InsurerShare", value: InsurerShare);
                    p.Add("FranchiseShare", value: FranchiseShare);
                    p.Add("FreeShare", value: FreeShare);

                    var query = "";
                    var s0 = "";
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

                        if (Id != null)
                        {
                            query += @"                                                                         
                                   
                                    UPDATE PatientServices  SET IsDeleted = 1  WHERE  Id = @Id                                                                          
                                    ;
                                ";
                        }

                        query += @"                                      
                                INSERT INTO PatientServices
                                        ( 
                                            PatientId,
		                                    ProviderDoctorId ,
		                                    ServiceGroupId ,
                                            ServiceId ,		
                                            ToothIds,
		                                    CheckupTypeId ,
                                                                                                                
                                            Date ,
                                            Comment ,
                                            IsHadMoreTooth ,       
                                            InsurerServiceTarefeChangeId,
                                            IsDeleted,
                                              
                                            ActionPrice,
                                            ServicePrice,
                                            InsurerPrice,
                                            InsurerShare,
                                            FranchiseShare,
                                            FreeShare

                                        )                                
                                VALUES  ( 
                                            @PatientId,
                                            @ProviderDoctorId,
                                            @ServiceGroupId,
                                            @ServiceId,
                                            @ToothIds,
                                            @CheckupTypeId,
                                                                                    
                                            @Date ,
                                            @Comment,
                                            @IsHadMoreTooth,   
                                            @InsurerServiceTarefeChangeId,
                                            0 ,
                                          
                                            @ServicePrice,
                                            @ServicePrice,
                                            @InsurerPrice,
                                            @InsurerShare,
                                            @FranchiseShare,
                                            @FreeShare
                                        )  
                                    ;
                                    SELECT last_insert_rowid()
                                ";


                    }

                    if (ActionType == "Delete")
                    {
                        query += @"                                                                         
                                   
                                    UPDATE PatientServices  SET IsDeleted = 1  WHERE  Id = @Id  
                                    ;
                                   
                                ";
                    }

                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    int patientServiceId = Convert.ToInt32(id);

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
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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
                    //////////////
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

                    var p = new Dapper.DynamicParameters();
                    p.Add("PatientId", value: PatientId);
                    p.Add("Date", value: Date);
                    p.Add("ToothId", value: ToothId);
                    p.Add("Visible", value: Visible ? 1 : 0);
                    p.Add("Rotate", value: Rotate);
                    p.Add("TipB", value: TipB);
                    p.Add("TipM", value: TipM);
                    p.Add("ShiftM", value: ShiftM);
                    p.Add("ShiftO", value: ShiftO);
                    p.Add("ShiftB", value: ShiftB);
                    p.Add("IsRCT", value: IsRCT ? 1 : 0);
                    p.Add("ColorRCT", value: ColorRCT);
                    p.Add("IsBU", value: IsBU ? 1 : 0);
                    p.Add("ColorBU", value: ColorBU);
                    p.Add("IsImplant", value: IsImplant ? 1 : 0);
                    p.Add("ColorImplant", value: ColorImplant);
                    p.Add("IsCrown", value: IsCrown ? 1 : 0);
                    p.Add("IsPontic", value: IsPontic ? 1 : 0);
                    p.Add("IsSealant", value: IsSealant ? 1 : 0);
                    p.Add("ColorSealant", value: ColorSealant);
                    p.Add("Surface", value: Surface);
                    p.Add("SurfaceColor", value: SurfaceColor);

                    p.Add("Surface_B", value: Surface_B ? 1 : 0);
                    p.Add("Surface_B_Color", value: Surface_B_Color);
                    p.Add("Surface_F", value: Surface_F ? 1 : 0);
                    p.Add("Surface_F_Color", value: Surface_F_Color);
                    p.Add("Surface_C", value: Surface_C ? 1 : 0);
                    p.Add("Surface_C_Color", value: Surface_C_Color);
                    p.Add("Surface_D", value: Surface_D ? 1 : 0);
                    p.Add("Surface_D_Color", value: Surface_D_Color);
                    p.Add("Surface_E", value: Surface_E ? 1 : 0);
                    p.Add("Surface_E_Color", value: Surface_E_Color);
                    p.Add("Surface_L", value: Surface_L ? 1 : 0);
                    p.Add("Surface_L_Color", value: Surface_L_Color);
                    p.Add("Surface_M", value: Surface_M ? 1 : 0);
                    p.Add("Surface_M_Color", value: Surface_M_Color);
                    p.Add("Surface_O", value: Surface_O ? 1 : 0);
                    p.Add("Surface_O_Color", value: Surface_O_Color);
                    p.Add("Surface_I", value: Surface_I ? 1 : 0);
                    p.Add("Surface_I_Color", value: Surface_I_Color);
                    p.Add("Surface_V", value: Surface_V ? 1 : 0);
                    p.Add("Surface_V_Color", value: Surface_V_Color);
                    p.Add("Description", value: Description);


                    var query = @" 
                            UPDATE PatientTeeth  SET IsDeleted = 1 WHERE PatientId = @PatientId AND ToothId=@ToothId
                            ;     
                            INSERT INTO PatientTeeth
                                (   PatientId,                                    
                                    Date,
                                    ToothId,                                        
                                    Visible,
                                    Rotate,
                                    TipB, 
                                    TipM,
                                    ShiftM,
                                    ShiftO,
                                    ShiftB,
                                    IsRCT,
                                    ColorRCT,
                                    IsBU,
                                    ColorBU,
                                    IsImplant,
                                    ColorImplant, 
                                    IsCrown,
                                    IsPontic,
                                    IsSealant,
                                    ColorSealant,
                                    SurfaceColor,
                                    Surface,
                                    Surface_B,
                                    Surface_B_Color,
                                    Surface_F,
                                    Surface_F_Color,
                                    Surface_C,
                                    Surface_C_Color,
                                    Surface_D,
                                    Surface_D_Color,
                                    Surface_E,
                                    Surface_E_Color,
                                    Surface_L,
                                    Surface_L_Color,
                                    Surface_M,
                                    Surface_M_Color,
                                    Surface_O,
                                    Surface_O_Color,
                                    Surface_I,
                                    Surface_I_Color,
                                    Surface_V,
                                    Surface_V_Color,
                                    Description

                                )                                 
                            VALUES 
                                (
                                    @PatientId,
                                    @Date,
                                    @ToothId,
                                    @Visible,
                                    @Rotate,
                                    @TipB, 
                                    @TipM,
                                    @ShiftM,
                                    @ShiftO,
                                    @ShiftB,
                                    @IsRCT,
                                    @ColorRCT,
                                    @IsBU,
                                    @ColorBU,
                                    @IsImplant,
                                    @ColorImplant, 
                                    @IsCrown,
                                    @IsPontic,
                                    @IsSealant,
                                    @ColorSealant,
                                    @SurfaceColor,
                                    @Surface,
                                    @Surface_B,
                                    @Surface_B_Color,
                                    @Surface_F,
                                    @Surface_F_Color,
                                    @Surface_C,
                                    @Surface_C_Color,
                                    @Surface_D,
                                    @Surface_D_Color,
                                    @Surface_E,
                                    @Surface_E_Color,
                                    @Surface_L,
                                    @Surface_L_Color,
                                    @Surface_M,
                                    @Surface_M_Color,
                                    @Surface_O,
                                    @Surface_O_Color,
                                    @Surface_I,
                                    @Surface_I_Color,
                                    @Surface_V,
                                    @Surface_V_Color,
                                    @Description
                                )
                                ;
                                SELECT last_insert_rowid()
                            ";



                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    int patientServiceToothId = Convert.ToInt32(id);




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
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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


                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("PatientId", value: PatientId);
                    p.Add("DoctorId", value: DoctorId);
                    p.Add("ServiceGroupId", value: ServiceGroupId);

                    p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                    p.Add("StartTime", value: StartTime != null ? StartTime.Value.ToString(@"hh\:mm") : null);
                    p.Add("EndTime", value: EndTime != null ? EndTime.Value.ToString(@"hh\:mm") : null);

                    p.Add("Description", value: Description);
                    p.Add("Color", value: Color);
                    p.Add("IsDeleted", value: IsDeleted);


                    var query = "";
                    var s0 = "";

                    if (Id != null)
                    {
                        if (Id != -1)
                            query = @" 
                                  
                                   UPDATE Visits  SET 
                                      {0}                                      
                                   WHERE Id = @Id 
                                    ;
                                   SELECT last_insert_rowid() ";
                        else
                            query = @"                                    
                                   UPDATE Visits  SET 
                                      {0}                                                            
                                     ";

                        if (PatientId != null)
                            s0 += " PatientId = @PatientId , ";
                        if (DoctorId != null)
                            s0 += " DoctorId = @DoctorId , ";
                        if (ServiceGroupId != null)
                            s0 += " ServiceGroupId = @ServiceGroupId , ";

                        if (Date != null)
                            s0 += " Date = @Date , ";
                        if (StartTime != null)
                            s0 += " StartTime = @StartTime , ";
                        if (EndTime != null)
                            s0 += " EndTime = @EndTime , ";
                        if (Description != null)
                            s0 += " Description = @Description , ";
                        if (Color != null)
                            s0 += " Color = @Color , ";
                        if (IsDeleted != null)
                            s0 += " IsDeleted = @IsDeleted , ";


                        s0 = s0.TrimEnd().TrimEnd(',');
                    }
                    else
                    {
                        query = @"
                                    INSERT  INTO Visits
                                            (   PatientId ,                                               
                                                DoctorId ,                                         
                                                ServiceGroupId ,
                                                Date ,
                                                StartTime ,
                                                EndTime ,
                                                Description ,
                                                Color ,
                                                IsDeleted 
                                            )
                                   
                                       VALUES  
                                            (   @PatientId ,
                                                @DoctorId ,                                                       
                                                @ServiceGroupId ,
                                                @Date ,
                                                @StartTime ,
                                                @EndTime ,
                                                @Description ,
                                                @Color ,
                                                @IsDeleted 
                                            );

                                    
                                    SELECT last_insert_rowid()
                                 ";
                    }


                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

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
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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



                    var p = new Dapper.DynamicParameters();
                    p.Add("DoctorId", value: DoctorId);
                    p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                    p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));

                    string query = @"   
                                    DELETE FROM WorkTimes                                    
                                    WHERE DoctorId = @DoctorId  
                                    -- AND ( ( CAST(Date AS DATE) >= CAST(@FromDate AS DATE) ) AND ( CAST(Date AS DATE) <= CAST(@ToDate AS DATE) ) ) ";

                    sql.Execute(query, param: p, transaction: transactionScope, commandType: CommandType.Text);

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
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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



                    var p = new Dapper.DynamicParameters();
                    p.Add("DoctorId", value: DoctorId);
                    p.Add("FromDate", value: Publics.ConvertDateToString(FromDate));
                    p.Add("ToDate", value: Publics.ConvertDateToString(ToDate));


                    dynamic finalResult = null;

                    IEnumerable<dynamic> WeekDayTimes = x.GetValue<IEnumerable>("WeekDayTimes").OfType<dynamic>().Select(i => i).ToArray();
                    List<dynamic> WorkTime = new List<dynamic>();

                    foreach (dynamic day in WeekDayTimes)
                    {
                        WorkTime.Add(new { DoctorId = DoctorId, DayName = day.DayName, StartTime = day.StartTime, EndTime = day.EndTime, Description = "", IsDeleted = IsDeleted });
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

                                p.Add("DoctorId", value: DoctorId);
                                //p.Add("DayOfWeek", value: date.DayOfWeek.ToString());
                                p.Add("Date", value: Publics.ConvertDateToString(date.Date));
                                p.Add("StartTime", value: day.StartTime);
                                p.Add("EndTime", value: day.EndTime);

                                string query = "";

                                if (IsDeleted == false)
                                {

                                    query = @"   
                                                                                
                                    UPDATE  WorkTimes 
                                                SET IsDeleted = 1  
                                                WHERE DoctorId = @DoctorId 
                                                      AND Date = @Date 
                                                      AND ( StartTime = @StartTime   AND   EndTime = @EndTime )
                                    ";

                                    sql.Query(query, param: p, transaction: transactionScope, commandType: CommandType.Text);

                                    query = @" INSERT  INTO WorkTimes
                                            (   DoctorId ,
                                                Date ,
                                                StartTime ,
                                                EndTime ,
                                                Description ,
                                                IsDeleted
                                            )
                              
                                    VALUES  (   @DoctorId , 
                                                @Date , 
                                                @StartTime , 
                                                @EndTime ,
                                                '' , 
                                                0 
                                            )

                                    ;
                                    SELECT last_insert_rowid()
                                    ";
                                }
                                else
                                {
                                    query = @" 
                                    UPDATE WorkTimes 
                                            SET IsDeleted = 1  
                                            WHERE DoctorId = @DoctorId 
                                                  AND Date = @Date 
                                                  AND ( StartTime >= @StartTime AND EndTime <= @EndTime)
                                    

                                    

                             
                                    ";
                                }


                                var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).SingleOrDefault();

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
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var UserId = x.HasValue("UserId") ? x.GetValue<int>("UserId") : (int?)null;
                    var AppActionIds = x.HasValue("AppActionIds") ? x.GetValue<IEnumerable>("AppActionIds").OfType<object>().Select(i => Convert.ToInt32(i)).ToArray() : null;

                    var Value = x.HasValue("Value") ? x.GetValue<bool>("Value") : (bool?)null;
                    var DefineDate = x.HasValue("DefineDate") ? x.GetValue<DateTime>("DefineDate") : DateTime.Now;


                    if (UserId == null)
                        new Exception("UserId وارد نشده است");
                    if (AppActionIds == null || AppActionIds.Count() < 1)
                        throw new Exception(" AppActionId وارد نشده است");


                    var p = new Dapper.DynamicParameters();
                    p.Add("UserId", value: UserId, dbType: DbType.Int32);
                    p.Add("AppActionIds", value: AppActionIds);
                    p.Add("Value", value: Value);

                    var query = "";

                    query = @"
                            
                            DELETE FROM UserPermissions WHERE UserId = @UserId
                            ;
                            INSERT INTO UserPermissions
                                ( 
                                    UserId, 
                                    AppActionId, 
                                    Value
                                )
                            SELECT    
	                                 @UserId, 
                                     Id, 
                                     1  
	                        FROM AppActions 
                            WHERE Id IN {0}
                            ;
                            SELECT last_insert_rowid()
                                ";



                    string s0 = "({0})";
                    if (AppActionIds != null && AppActionIds.Count() > 0)
                        s0 = string.Format(s0, string.Join(" , ", AppActionIds.Select(i => string.Format(" {0} ", int.Parse(Convert.ToString(i)))).ToArray()));

                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();



                    transactionScope.Commit();


                    return new JsonResponse<dynamic>() { Success = true, Data = true };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }




        public static JsonResponse<dynamic> DefineInsurersPricingX(dynamic searchObj, SQLiteTransaction transaction = null)
        {

            SQLiteTransaction transactionScope = null;
            if (transaction == null)
                transactionScope = sql.BeginTransaction();
            else
                transactionScope = transaction;

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

                var p = new Dapper.DynamicParameters();
                p.Add("ServiceId", value: ServiceId, dbType: DbType.Int32);
                p.Add("FreePrice", value: FreePrice);
                p.Add("InsurerPrice", value: InsurerPrice);
                p.Add("DefineDate", value: Publics.ConvertDateTimeToString(DefineDate));
                p.Add("RunDate", value: Publics.ConvertDateTimeToString(RunDate));

                var query = "";

                query = @"

                            INSERT INTO InsurerServiceTarefeChanges
                                    ( InsurerId ,
                                      ServiceId ,
                                      DefineDate ,
                                      RunDate ,
                                      FreePrice ,
                                      InsurerPrice ,
                                      UserId
                                    )
                            SELECT  Id , 
	                                @ServiceId , 
		                            @DefineDate , 
		                            @RunDate , 
		                            @FreePrice ,
		                            @InsurerPrice ,
		                            null
	                        FROM Insurers
                            WHERE Id IN {0}
                            ;
                            SELECT last_insert_rowid()
                                ";



                string s0 = "({0})";
                if (InsurerIds != null && InsurerIds.Count() > 0)
                    s0 = string.Format(s0, string.Join(" , ", InsurerIds.Select(i => string.Format(" {0} ", int.Parse(Convert.ToString(i)))).ToArray()));

                query = string.Format(query, s0);
                var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();



                transactionScope.Commit();

                var finalResult = new { Id = id };

                return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
            }
            catch (Exception ex)
            {
                transactionScope.Rollback();
                return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
            }
        }

        public static JsonResponse<dynamic> RemovePatientFromDatabaseX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
                try
                {

                    var x = new RouteValueDictionary(searchObj);
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;

                    if (PatientId == null)
                        throw new Exception("PatientId Not Find");
                    var query = @"
                                    DELETE FROM PatientServices          WHERE  PatientId = @PatientId
 
                                    DELETE FROM PatientDocuments         WHERE   PatientId=@PatientId
                                 
                                    DELETE FROM PatientFinancials        WHERE PatientId = @PatientId

                                    DELETE FROM PatientSpecialComments   WHERE  PatientId=@PatientId

                                    DELETE FROM PatientSpecialDrugs       WHERE  PatientId=@PatientId

                                    DELETE FROM PatientSpecialDiseases   WHERE  PatientId=@PatientId

                                    DELETE FROM Patients                 WHERE   Id=@PatientId
                                 ";
                    var p = new Dapper.DynamicParameters();
                    p.Add("PatientId", value: PatientId);

                    string s0 = "";


                    query = string.Format(query, s0);
                    var result = sql.Execute(query, param: p, transaction: transactionScope, commandType: CommandType.Text);

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = true };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = false, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefinePatientX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var DoctorId = x.HasValue("DoctorId") ? x.GetValue<int>("DoctorId") : (int?)null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
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




                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id, dbType: DbType.Int32);
                    p.Add("PatientId", value: PatientId, dbType: DbType.Int32);
                    p.Add("DoctorId", value: DoctorId, dbType: DbType.Int32);
                    p.Add("DoctorId", value: DoctorId, dbType: DbType.Int32);
                    p.Add("FirstName", value: FirstName);
                    p.Add("LastName", value: LastName);
                    p.Add("FatherName", value: FatherName);
                    p.Add("NationalCode", value: NationalCode);
                    p.Add("GenderId", value: GenderId);
                    p.Add("BirthDate", value: Publics.ConvertDateTimeToString(BirthDate));
                    p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                    p.Add("JobId", value: JobId);
                    p.Add("Presenter", value: Presenter);
                    p.Add("MaritalStatusId", value: MaritalStatusId);
                    p.Add("EducationLevelId", value: EducationLevelId);
                    p.Add("NationalityId", value: NationalityId);
                    p.Add("FixedPhone", value: FixedPhone);
                    p.Add("MobilePhone", value: MobilePhone);
                    p.Add("Address", value: Address);
                    p.Add("Comment", value: Comment);
                    p.Add("IsDeleted", value: IsDeleted);


                    var query = "";
                    var s0 = "";

                    if (NationalCode != null)
                    {
                        if (PatientId != null)
                            s0 += "AND Id <> @PatientId ";
                        query = @"
                                SELECT Id FROM Patients WHERE NationalCode = @NationalCode {0} ";
                        query = string.Format(query, s0);
                        var pId = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).SingleOrDefault();

                        if (pId > 0)
                            return new JsonResponse<dynamic>() { Success = false, Data = null, Message = "بیماری با این کد ملی وجود دارد" };
                    }

                    if (ActionType == "New")
                    {
                        query = "";
                        s0 = "";
                        query = @"
                               
                                INSERT INTO Patients
                                       (DoctorId,
				                        FirstName,
				                        LastName,
				                        FatherName,
				                        NationalCode,
				                        GenderId,
				                        BirthDate,
				                        [Date],
				                        JobId,
				                        Presenter,
                                        MaritalStatusId,
                                        EducationLevelId,
                                        NationalityId,
				                        FixedPhone,
				                        MobilePhone,
				                        [Address],
                                        Comment
			                           )
                                
                                VALUES  
		                               (@DoctorId,			    
				                        @FirstName,
				                        @LastName,
				                        @FatherName,
				                        @NationalCode,
				                        @GenderId,
				                        @BirthDate,
				                        @Date,
				                        @JobId , 
				                        @Presenter,
                                        @MaritalStatusId,
                                        @EducationLevelId,
                                        @NationalityId,
				                        @FixedPhone, 
				                        @MobilePhone,
				                        @Address,
                                        @Comment
			                           )	 
                                    ;
                                    SELECT last_insert_rowid()
                                 ";
                    }
                    else if (ActionType == "Edit")
                    {
                        if (PatientId == null)
                            throw new Exception("Id وارد نشده است");

                        query = "";
                        s0 = "";
                        query = @"

                                 UPDATE Patients  SET
                                 {0}
                                 WHERE  Id = @PatientId
                                 ";

                        if (DoctorId != null)
                            s0 += " DoctorId = @DoctorId , ";
                        if (FirstName != null)
                            s0 += " FirstName = @FirstName , ";
                        if (LastName != null)
                            s0 += " LastName = @LastName , ";
                        if (FatherName != null)
                            s0 += " FatherName = @FatherName , ";

                        if (NationalCode != null)
                            s0 += " NationalCode = @NationalCode , ";
                        if (GenderId != null)
                            s0 += " GenderId = @GenderId , ";

                        if (BirthDate != null)
                            s0 += " BirthDate = @BirthDate , ";
                        if (Date != null)
                            s0 += " Date = @Date , ";
                        if (JobId != null)
                            s0 += " JobId = @JobId , ";

                        if (Presenter != null)
                            s0 += " Presenter = @Presenter , ";
                        if (MaritalStatusId != null)
                            s0 += " MaritalStatusId = @MaritalStatusId , ";
                        if (EducationLevelId != null)
                            s0 += " EducationLevelId = @EducationLevelId , ";
                        if (NationalityId != null)
                            s0 += " NationalityId = @NationalityId , ";
                        if (FixedPhone != null)
                            s0 += " FixedPhone = @FixedPhone , ";
                        if (MobilePhone != null)
                            s0 += " MobilePhone = @MobilePhone , ";

                        if (Address != null)
                            s0 += " Address = @Address , ";
                        if (Comment != null)
                            s0 += " Comment = @Comment ,";
                        if (IsDeleted != null)
                            s0 += " IsDeleted = @IsDeleted ,";


                        s0 = s0.TrimEnd().TrimEnd(',');
                    }


                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var finalResult = (PatientId != null) ? PatientId.Value : id;

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }



        public static JsonResponse<dynamic> DefineStaffX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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
                    //var Picture = x.HasValue("Picture") ? x.GetValue<byte[]>("Picture") : null;
                    var FixedPhone = x.HasValue("FixedPhone") ? x.GetValue<string>("FixedPhone") : null;
                    var MobilePhone = x.HasValue("MobilePhone") ? x.GetValue<string>("MobilePhone") : null;
                    var Address = x.HasValue("Address") ? x.GetValue<string>("Address") : null;
                    var Comment = x.HasValue("Comment") ? x.GetValue<string>("Comment") : null;


                    var UserId = x.HasValue("UserId") ? x.GetValue<int>("UserId") : (int?)null;
                    var UserName = x.HasValue("UserName") ? x.GetValue<string>("UserName") : null;
                    var UserPass = x.HasValue("UserPass") ? x.GetValue<string>("UserPass") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;

                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id, dbType: DbType.Int32);
                    p.Add("StaffTypeId", value: StaffTypeId, dbType: DbType.Int32);
                    p.Add("FirstName", value: FirstName);
                    p.Add("LastName", value: LastName);
                    p.Add("NationalCode", value: NationalCode);
                    p.Add("MedicalCouncilCode", value: MedicalCouncilCode);
                    p.Add("SpecialtyId", value: SpecialtyId);
                    p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                    p.Add("GenderId", value: GenderId);
                    //p.Add("Picture", value: Picture);                
                    p.Add("FixedPhone", value: FixedPhone);
                    p.Add("MobilePhone", value: MobilePhone);
                    p.Add("Address", value: Address);
                    p.Add("Comment", value: Comment);
                    p.Add("IsDeleted", value: IsDeleted);

                    var query = "";
                    var s0 = "";

                    if (ActionType == "New")
                    {
                        query = @"
                                
                                INSERT INTO Staffs
                                        ( StaffTypeId ,                                            
                                            FirstName ,
                                            LastName ,
                                            NationalCode ,
                                            MedicalCouncilCode,
                                            SpecialtyId,
                                            Date ,
                                            GenderId ,
                                            FixedPhone ,
                                            MobilePhone ,                                          
                                            Address ,
                                            Comment
		                                )
                                
                                VALUES  (   @StaffTypeId ,                                           
                                            @FirstName ,
                                            @LastName ,
                                            @NationalCode ,
                                            @MedicalCouncilCode,
                                            @SpecialtyId,
                                            @Date ,
                                            @GenderId ,
                                            @FixedPhone ,
                                            @MobilePhone ,                                         
                                            @Address ,
                                            @Comment
		                                )
                                 ;
                                 SELECT last_insert_rowid()
                                 ";
                    }
                    else if (ActionType == "Edit")
                    {
                        if (Id == null)
                            throw new Exception("Id Is Not Define");

                        query = @"
                                
                                 UPDATE Staffs  SET
                                 {0}
                                 
                                 WHERE  Id = @Id
                            
                               
                                 ";

                        if (StaffTypeId != null)
                            s0 += " StaffTypeId = @StaffTypeId , ";
                        if (FirstName != null)
                            s0 += " FirstName = @FirstName , ";
                        if (LastName != null)
                            s0 += " LastName = @LastName , ";
                        if (NationalCode != null)
                            s0 += " NationalCode = @NationalCode , ";
                        if (MedicalCouncilCode != null)
                            s0 += " MedicalCouncilCode = @MedicalCouncilCode , ";
                        if (SpecialtyId != null)
                            s0 += " SpecialtyId = @SpecialtyId , ";

                        if (Date != null)
                            s0 += " Date = @Date , ";
                        if (GenderId != null)
                            s0 += " GenderId = @GenderId , ";
                        if (FixedPhone != null)
                            s0 += " FixedPhone = @FixedPhone , ";
                        if (MobilePhone != null)
                            s0 += " MobilePhone = @MobilePhone , ";

                        if (Address != null)
                            s0 += " Address = @Address , ";
                        if (Comment != null)
                            s0 += " Comment = @Comment , ";
                        if (IsDeleted != null)
                            s0 += " IsDeleted = @IsDeleted , ";

                        s0 = s0.TrimEnd().TrimEnd(',');
                    }
                    else if (ActionType == "Delete")
                    {
                        if (Id == null)
                            throw new Exception("Id Is Not Define");

                        query = @"
                                    UPDATE Staffs SET IsDeleted = 1  WHERE Id = @Id
                                    ;
                                    UPDATE Users  SET IsDeleted = 1  WHERE StaffId = @Id
                                                                 
                                 ";
                    }



                    query = string.Format(query, s0);

                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var staffId = (Id != null) ? Id.Value : id;

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
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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


                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("PatientId", value: PatientId);
                    p.Add("SpecialCommentTypeId", value: SpecialCommentTypeId);
                    p.Add("Title", value: Title);
                    p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                    p.Add("IsDeleted", value: IsDeleted);

                    var query = "";
                    var s0 = "";

                    if (ActionType == "New")
                    {
                        query = @"  
                                    INSERT INTO PatientSpecialComments
                                            ( PatientId ,
                                              SpecialCommentTypeId,
                                              Title ,
                                              Date ,                                              
                                              IsDeleted 
                                            )                                    
                                    VALUES  ( @PatientId ,
                                              @SpecialCommentTypeId ,
                                              @Title ,
                                              @Date ,   
                                              @IsDeleted         
                                            )
                                    ;
                                    SELECT last_insert_rowid() ";



                    }
                    else if (ActionType == "Edit")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        query = @" 
                                   UPDATE PatientSpecialComments  SET 
                                        {0}                                 
                                   WHERE Id = @Id 
                                 ";

                        if (PatientId != null)
                            s0 += " PatientId = @PatientId , ";
                        if (SpecialCommentTypeId != null)
                            s0 += " SpecialCommentTypeId = @SpecialCommentTypeId , ";
                        if (Title != null)
                            s0 += " Title = @Title , ";
                        if (Date != null)
                            s0 += " Date = @Date , ";
                        if (IsDeleted != null)
                            s0 += " IsDeleted = @IsDeleted , ";


                        s0 = s0.TrimEnd().TrimEnd(',');

                    }
                    else if (ActionType == "Delete")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        query = @"                                    
		                           DELETE FROM PatientSpecialComments WHERE  Id = @Id	                                 
                                ";
                    }

                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var finalResult =
                        new
                        {
                            Id = (Id != null) ? Id : id
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

        public static JsonResponse<dynamic> DefineCostX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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


                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("CostTypeId", value: CostTypeId);
                    p.Add("BargainSideId", value: BargainSideId);
                    p.Add("PayTypeId", value: PayTypeId);
                    p.Add("Amount", value: Amount);
                    p.Add("CostTitle", value: CostTitle);
                    p.Add("FactorNumber", value: FactorNumber);
                    p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                    p.Add("ChequeNumber", value: ChequeNumber);
                    p.Add("BankId", value: BankId);
                    p.Add("ChequeStatusId", value: ChequeStatusId);
                    p.Add("DateOfIssuance", value: DateOfIssuance);
                    p.Add("DateOfMaturity", value: DateOfMaturity);
                    p.Add("Comment", value: Comment);
                    p.Add("IsDeleted", value: IsDeleted);


                    var query = "";
                    var s0 = "";

                    if (ActionType == "New" || ActionType == "Edit")
                    {
                        if (ActionType == "Edit")
                        {
                            if (Id == null)
                                throw new Exception("Id is Null");
                        }

                        query = @" 
                                    UPDATE Costs  SET IsDeleted = 1 WHERE Id = @Id 
                                    ;
                                    INSERT  INTO Costs
                                            ( CostTypeId ,
		                                      BargainSideId ,
		                                      PayTypeId ,	     
                                              Amount ,
                                              Title ,          
                                              FactorNumber ,
                                              [Date] ,
                                              ChequeNumber,
                                              BankId,
                                              ChequeStatusId,
                                              DateOfIssuance,
                                              DateOfMaturity,
                                              Comment ,
                                              IsDeleted         
                                            )                                
                                    VALUES  ( @CostTypeId ,
                                              @BargainSideId ,
		                                      @PayTypeId ,        
                                              @Amount ,
                                              @CostTitle ,          
                                              @FactorNumber ,
                                              @Date ,
                                              @ChequeNumber,
                                              @BankId,
                                              @ChequeStatusId,
                                              @DateOfIssuance,
                                              @DateOfMaturity,
                                              @Comment ,   
		                                      @IsDeleted              
                                            )
                                    ;                                    
                                    SELECT last_insert_rowid()
                                 ";
                    }
                    if (ActionType == "Delete")
                    {

                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        query = @" 
                                    UPDATE Costs SET IsDeleted = 1 WHERE  Id=@Id 	                                                                                                              
                                ";
                    }
                    if (ActionType == "EditChequeStatus")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        query = @"  
	                                UPDATE Costs SET ChequeStatusId = @ChequeStatusId  WHERE  Id=@Id	                              
                                 ";
                    }

                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var finalResult =
                        new
                        {
                            Id = Id != null ? Id.Value : id
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

        public static JsonResponse<dynamic> DefinePatientFinancialX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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

                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("PatientId", value: PatientId);
                    p.Add("PayTypeId", value: PayTypeId);
                    p.Add("Amount", value: Amount);
                    p.Add("Date", value: Publics.ConvertDateTimeToString(Date));

                    p.Add("ChequeNumber", value: ChequeNumber);
                    p.Add("BankId", value: BankId);
                    p.Add("ChequeStatusId", value: ChequeStatusId);
                    p.Add("DateOfIssuance", value: DateOfIssuance);
                    p.Add("DateOfMaturity", value: DateOfMaturity);

                    p.Add("Comment", value: Comment);
                    p.Add("IsDeleted", value: IsDeleted);


                    var query = "";
                    var s0 = "";

                    if (ActionType == "New" || ActionType == "Edit")
                    {
                        if (ActionType == "Edit")
                        {
                            if (Id == null)
                                throw new Exception("Id is Null");
                        }
                        query = @" 
                                UPDATE PatientFinancials  SET IsDeleted = 1 WHERE Id = @Id 
                                ;
                                INSERT  INTO PatientFinancials
                                        ( PatientId ,
		                                    PayTypeId ,
		                                    Amount ,                                                 
                                            [Date] ,
                                            
                                            ChequeNumber,
                                            BankId,
                                            ChequeStatusId,
                                            DateOfIssuance,
                                            DateOfMaturity,
                                            
                                            Comment ,
                                            IsDeleted         
                                        )                           
                                VALUES  ( @PatientId ,
		                                    @PayTypeId ,
		                                    @Amount ,
                                            @Date ,
                                            
                                            @ChequeNumber,
                                            @BankId,
                                            @ChequeStatusId,
                                            @DateOfIssuance,
                                            @DateOfMaturity,
                                            
                                            @Comment ,
		                                    @IsDeleted              
                                        )
                                ;  
                                SELECT last_insert_rowid()
                                ";
                    }
                    if (ActionType == "Delete")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        query = @"  
	                                UPDATE PatientFinancials SET IsDeleted = 1  WHERE  Id=@Id	                              
                                 ";
                    }
                    if (ActionType == "EditChequeStatus")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                        query = @"  
	                                UPDATE PatientFinancials SET ChequeStatusId = @ChequeStatusId  WHERE  Id=@Id	                              
                                 ";
                    }



                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var finalResult =
                        new
                        {
                            Id = id

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


        public static JsonResponse<dynamic> DefineUserX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var UserId = x.HasValue("UserId") ? x.GetValue<int>("UserId") : (int?)null;
                    var StaffId = x.HasValue("StaffId") ? x.GetValue<int>("StaffId") : (int?)null;
                    var UserName = x.HasValue("UserName") ? x.GetValue<string>("UserName") : null;
                    var UserPass = x.HasValue("UserPass") ? x.GetValue<string>("UserPass") : null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)null;


                    var p = new Dapper.DynamicParameters();
                    p.Add("UserId", value: UserId);
                    p.Add("StaffId", value: StaffId);
                    p.Add("UserName", value: UserName);
                    p.Add("UserPass", value: UserPass);
                    p.Add("IsDeleted", value: IsDeleted);


                    var query = "";
                    var s0 = "";

                    if (UserId != null)
                    {

                        query = @"                                 
                                   UPDATE Users  SET 
                                      {0}                                    
                                   WHERE Id = @UserId 

                                 ";

                        if (UserName != null)
                            s0 += " UserName = @UserName , ";
                        if (UserPass != null)
                            s0 += " UserPass = @UserPass , ";



                        if (IsDeleted != null)
                            s0 += " IsDeleted = @IsDeleted , ";


                        s0 = s0.TrimEnd().TrimEnd(',');
                    }
                    else
                    {
                        query = @"                                    
                                    INSERT  INTO Users
                                            (   StaffId ,                                               
                                                UserName ,
                                                UserPass ,  
                                                IsDeleted 
                                            )                                   
                                       VALUES  
                                            (   @StaffId ,
                                                @UserName ,
                                                @UserPass ,  
                                                @IsDeleted 
                                            )
                                    ;
                                    SELECT last_insert_rowid()
                                 ";
                    }


                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var finalResult =
                        new
                        {
                            UserId = (UserId != null) ? UserId.Value : id
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


        public static JsonResponse<dynamic> DefineInsurerFinancialsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var InsuranceId = x.HasValue("InsuranceId") ? x.GetValue<int>("InsuranceId") : (int?)null;
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


                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("InsuranceId", value: InsuranceId);
                    p.Add("InsurerId", value: InsurerId);
                    p.Add("RequestedValue", value: RequestedValue);
                    p.Add("ReceivedValue", value: ReceivedValue);
                    p.Add("DeductionValue", value: DeductionValue);
                    p.Add("RemainPrice", value: RemainPrice);
                    p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                    p.Add("FromDate", value: Publics.ConvertDateTimeToString(FromDate));
                    p.Add("ToDate", value: Publics.ConvertDateTimeToString(ToDate));
                    p.Add("Comment", value: Comment);
                    p.Add("IsDeleted", value: IsDeleted);


                    var query = "";
                    var s0 = "";

                    if (Id != null)
                    {

                        query = @" 
                                   UPDATE InsurerFinancials  SET 
                                      {0}                                     
                                   WHERE Id = @Id 
                                 ";

                        if (InsurerId != null)
                            s0 += " InsurerId = @InsurerId , ";
                        if (RequestedValue != null)
                            s0 += " RequestedValue = @RequestedValue , ";
                        if (ReceivedValue != null)
                            s0 += " ReceivedValue = @ReceivedValue , ";
                        if (DeductionValue != null)
                            s0 += " DeductionValue = @DeductionValue , ";
                        if (RemainPrice != null)
                            s0 += " RemainPrice = @RemainPrice , ";
                        if (Date != null)
                            s0 += " Date = @Date , ";
                        if (FromDate != null)
                            s0 += " FromDate = @FromDate , ";
                        if (ToDate != null)
                            s0 += " ToDate = @ToDate , ";
                        if (Comment != null)
                            s0 += " Comment = @Comment , ";
                        if (IsDeleted != null)
                            s0 += " IsDeleted = @IsDeleted , ";


                        s0 = s0.TrimEnd().TrimEnd(',');
                    }
                    else
                    {
                        query = @"                                     
                                    INSERT  INTO InsurerFinancials
                                            (   InsurerId ,                                               
                                                RequestedValue ,
                                                ReceivedValue ,                                               
                                                DeductionValue ,
                                                RemainPrice ,
                                                Date ,
                                                FromDate,
                                                ToDate,
                                                Comment ,
                                                IsDeleted 
                                            )                                   
                                       VALUES  
                                            (   @InsurerId ,
                                                @RequestedValue ,
                                                @ReceivedValue ,                                                              
                                                @DeductionValue ,
                                                @RemainPrice ,
                                                @Date ,
                                                @FromDate,
                                                @ToDate,
                                                @Comment ,
                                                @IsDeleted 
                                            );
                                    ;                                    
                                    SELECT last_insert_rowid()
                                 ";
                    }


                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var finalResult =
                        new
                        {
                            InsurerFinancialId = (Id != null) ? Id.Value : id
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

        public static JsonResponse<dynamic> DefinePatientDocumentX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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


                    var p = new Dapper.DynamicParameters();
                    p.Add("DocId", value: DocId);
                    p.Add("PatientId", value: PatientId);
                    p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                    p.Add("ModifiedDate", value: Publics.ConvertDateTimeToString(DateTime.Now));
                    p.Add("Title", value: Title);
                    p.Add("ImagePath", value: ImagePath);
                    p.Add("Image", value: Image);
                    p.Add("Comment", value: Comment);
                    p.Add("IsDeleted", value: IsDeleted);


                    var query = "";
                    var s0 = "";

                    if (DocId != null)
                    {

                        query = @" 
                                   UPDATE PatientDocuments  SET 
                                      {0}                                     
                                   WHERE Id = @DocId 

                                  ";

                        if (PatientId != null)
                            s0 += " PatientId = @PatientId , ";
                        if (Date != null)
                            s0 += " Date = @Date , ";
                        if (Title != null)
                            s0 += " Title = @Title , ";
                        if (ImagePath != null)
                            s0 += " ImagePath = @ImagePath , ";
                        if (Image != null)
                            s0 += " Image = @Image , ";
                        if (Comment != null)
                            s0 += " Comment = @Comment , ";
                        if (IsDeleted != null)
                            s0 += " IsDeleted = @IsDeleted , ";

                        s0 += " ModifiedDate = @ModifiedDate  ";
                    }
                    else
                    {
                        query = @" 
                                    INSERT  INTO PatientDocuments
                                            (   PatientId ,                                               
                                                Date ,
                                                Title ,                                               
                                                ImagePath ,
                                                Image ,
                                                Comment ,
                                                IsDeleted 
                                            )                                   
                                     VALUES  
                                            (   @PatientId ,
                                                @Date ,
                                                @Title ,                                                              
                                                @ImagePath ,
                                                @Image ,                                         
                                                @Comment ,
                                                @IsDeleted 
                                            )
                                    ;
                                    SELECT last_insert_rowid()
                                    
                                 ";
                    }


                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var finalResult =
                        new
                        {
                            InsuranceId = (DocId != null) ? DocId.Value : id
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





        public static JsonResponse<dynamic> DefinePatientFollowUpsX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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


                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("DoctorId", value: DoctorId);
                    p.Add("PatientId", value: PatientId);
                    p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                    p.Add("FollowUpDate", value: Publics.ConvertDateTimeToString(FollowUpDate));
                    p.Add("Comment", value: Comment);
                    p.Add("IsDeleted", value: IsDeleted);


                    var query = "";
                    var s0 = "";

                    if (ActionType == "Edit")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");
                        query = @"                                    
                                   UPDATE PatientFollowUps  SET 
                                      {0}                                     
                                   WHERE Id = @Id 

                                  ";

                        if (DoctorId != null)
                            s0 += " DoctorId = @DoctorId , ";
                        if (PatientId != null)
                            s0 += " PatientId = @PatientId , ";
                        if (Date != null)
                            s0 += " Date = @Date , ";
                        if (FollowUpDate != null)
                            s0 += " FollowUpDate = @FollowUpDate , ";
                        if (Comment != null)
                            s0 += " Comment = @Comment , ";
                        if (IsDeleted != null)
                            s0 += " IsDeleted = @IsDeleted , ";


                        s0 = s0.TrimEnd().TrimEnd(',');
                    }
                    if (ActionType == "New")
                    {

                        query = @" 
                                    INSERT  INTO PatientFollowUps
                                            (   DoctorId,
                                                PatientId ,                                               
                                                Date ,
                                                FollowUpDate ,  
                                                Comment ,                                              
                                                IsDeleted 
                                            )
                                       VALUES  
                                            (   @DoctorId, 
                                                @PatientId ,
                                                @Date ,
                                                @FollowUpDate ,  
                                                @Comment ,                                             
                                                @IsDeleted 
                                            )
                                    ;                                    
                                    SELECT last_insert_rowid()
                                 ";
                    }
                    if (ActionType == "Delete")
                    {

                    }

                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var finalResult =
                        new
                        {
                            MessageId = (Id != null) ? Id.Value : id
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



        public static JsonResponse<dynamic> DefinePatientInsuranceX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var InsurerId = x.HasValue("InsurerId") ? x.GetValue<int>("InsurerId") : (int?)null;
                    var InsuranceTypeId = x.HasValue("InsuranceTypeId") ? x.GetValue<int>("InsuranceTypeId") : 1;
                    var InsuranceBookletType = x.HasValue("InsuranceBookletType") ? x.GetValue<int>("InsuranceBookletType") : 0;
                    var ExpirationDate = x.HasValue("ExpirationDate") ? x.GetValue<DateTime>("ExpirationDate") : (DateTime?)null;
                    var InsuredNumber = x.HasValue("InsuredNumber") ? x.GetValue<string>("InsuredNumber") : null;
                    var InsuranceBookletSerialNumber = x.HasValue("InsuranceBookletSerialNumber") ? x.GetValue<string>("InsuranceBookletSerialNumber") : null;
                    var Percent = x.HasValue("Percent") ? x.GetValue<float>("Percent") : (float?)null;
                    var MaxPay = x.HasValue("MaxPay") ? x.GetValue<float>("MaxPay") : (float?)null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;


                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("PatientId", value: PatientId);
                    p.Add("InsurerId", value: InsurerId);
                    p.Add("InsuranceTypeId", value: InsuranceTypeId);
                    p.Add("ExpirationDate", value: Publics.ConvertDateTimeToString(ExpirationDate));
                    p.Add("InsuredNumber", value: InsuredNumber);
                    p.Add("InsuranceBookletSerialNumber", value: InsuranceBookletSerialNumber);
                    p.Add("Percent", value: Percent);
                    p.Add("MaxPay", value: MaxPay);
                    p.Add("IsDeleted", value: IsDeleted);


                    var query = "";
                    var s0 = "";

                    query = @" 
                                UPDATE PatientInsurances  SET IsDeleted=1                                                                          
                                WHERE PatientId = @PatientId
                                ;
                                INSERT  INTO PatientInsurances
                                        (   InsurerId,
                                            PatientId , 
                                            InsuranceTypeId,
                                            InsuredNumber ,
                                            InsuranceBookletSerialNumber ,  
                                            ExpirationDate,
                                            [Percent] ,   
                                            MaxPay ,   
                                            IsDeleted 
                                        )
                                    
                                    VALUES  
                                        (   @InsurerId,
                                            @PatientId ,
                                            @InsuranceTypeId,
                                            @InsuredNumber ,
                                            @InsuranceBookletSerialNumber ,  
                                            @ExpirationDate,
                                            @Percent ,   
                                            @MaxPay ,   
                                            @IsDeleted 
                                        );

                                    
                                SELECT last_insert_rowid()
                                ";



                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

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

        public static JsonResponse<dynamic> DefineInsurerX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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


                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("InsuranceId", value: InsuranceId);
                    p.Add("InsuranceBoxId", value: InsuranceBoxId);
                    p.Add("Title", value: Title);
                    p.Add("InsurerPercent", value: InsurerPercent);
                    p.Add("IsBasic", value: IsBasic);
                    p.Add("IsExtra", value: IsExtra);
                    p.Add("StartDate", value: IsDeleted);
                    p.Add("EndDate", value: IsDeleted);
                    p.Add("Comment", value: Comment);
                    p.Add("IsDeleted", value: IsDeleted);



                    var query = "";
                    var s0 = "";

                    if (ActionType == "Edit")
                    {

                        if (Id == null)
                            throw new Exception("Id وارد نشده است");

                    }
                    if (ActionType == "New")
                    {
                        Id = -1;
                    }

                    query = @"                             
                            UPDATE Insurers  SET IsDeleted = 1  WHERE  Id = @Id  
                            ;
                            INSERT  INTO Insurers
                                    (   InsuranceId,
                                        InsuranceBoxId,
                                        Title ,   
                                        InsurerPercent,
                                        IsBasic,
                                        IsExtra,
                                        StartDate,
                                        EndDate,
                                        Comment,
                                        IsDeleted 
                                    )                                    
                            VALUES  
                                    (   @InsuranceId,
                                        @InsuranceBoxId,
                                        @Title , 
                                        @InsurerPercent,
                                        @IsBasic,
                                        @IsExtra,
                                        @StartDate,
                                        @EndDate,
                                        @Comment,
                                        @IsDeleted 
                                    )
                            ;
                            SELECT last_insert_rowid()
                            ";

                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

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




        public static JsonResponse<dynamic> DefinePatientSpecialDiseasesX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var SpecialDiseasId = x.HasValue("SpecialDiseasId") ? x.GetValue<int>("SpecialDiseasId") : (int?)null;


                    var p = new Dapper.DynamicParameters();
                    p.Add("PatientId", value: PatientId);
                    p.Add("SpecialDiseasId", value: SpecialDiseasId);

                    var query = "";
                    var s0 = "";


                    if (ActionType == "New")
                    {

                        query = @"                                                                                                            
                                        INSERT INTO PatientSpecialDiseases
                                               (    PatientId,
                                                    SpecialDiseasId
                                               )                                    
                                        SELECT  @PatientId, @SpecialDiseasId                                              
                                        WHERE NOT EXISTS (SELECT 1 FROM PatientSpecialDiseases WHERE PatientId = @PatientId AND SpecialDiseasId=@SpecialDiseasId)
                                        ;
                                        SELECT last_insert_rowid()
                                 ";
                    }
                    if (ActionType == "Delete")
                    {
                        query = @" DELETE FROM  PatientSpecialDiseases  WHERE PatientId = @PatientId  AND   SpecialDiseasId = @SpecialDiseasId ";
                    }

                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var finalResult = true;


                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DefinePatientSpecialDrugX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionType = x.HasValue("ActionType") ? x.GetValue<string>("ActionType") : null;
                    var PatientId = x.HasValue("PatientId") ? x.GetValue<int>("PatientId") : (int?)null;
                    var SpecialDrugId = x.HasValue("SpecialDrugId") ? x.GetValue<int>("SpecialDrugId") : (int?)null;


                    var p = new Dapper.DynamicParameters();
                    p.Add("PatientId", value: PatientId);
                    p.Add("SpecialDrugId", value: SpecialDrugId);

                    var query = "";
                    var s0 = "";


                    if (ActionType == "New")
                    {

                        query = @"                                    
                                    INSERT INTO PatientSpecialDrugs
                                            (    PatientId,
                                                SpecialDrugId
                                            )                                    
                                    SELECT  @PatientId, @SpecialDrugId                                               
                                    WHERE NOT EXISTS (SELECT 1 FROM PatientSpecialDrugs WHERE PatientId = @PatientId AND SpecialDrugId=@SpecialDrugId)
                                    ;
                                    SELECT last_insert_rowid()
                                 ";
                    }
                    if (ActionType == "Delete")
                    {
                        query = @" DELETE FROM  PatientSpecialDrugs  WHERE PatientId = @PatientId  AND   SpecialDrugId = @SpecialDrugId ";
                    }

                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var finalResult = true;


                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }




        public static JsonResponse<dynamic> DefineOfficeX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
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

                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("OfficeName", value: OfficeName);
                    p.Add("DoctorName", value: DoctorName);
                    p.Add("OfficeCode", value: OfficeCode);
                    p.Add("OfficeType", value: OfficeType);
                    p.Add("NezamPezeshki", value: NezamPezeshki);
                    p.Add("PhoneNumber", value: PhoneNumber);
                    p.Add("OfficeAddress", value: OfficeAddress);
                    p.Add("Email", value: Email);
                    p.Add("Website", value: Website);

                    p.Add("DefaultDoctorId", value: DefaultDoctorId);
                    p.Add("DefaultBasicInsurerId", value: DefaultBasicInsurerId);
                    p.Add("DefaultMaritalStatusId", value: DefaultMaritalStatusId);
                    p.Add("DefaultEducationLevelId", value: DefaultEducationLevelId);
                    p.Add("DefaultNationalityId", value: DefaultNationalityId);

                    p.Add("ModifiedDate", value: Publics.ConvertDateTimeToString(Date));
                    p.Add("IsDeleted", value: IsDeleted);


                    var query = "";
                    var s0 = "";

                    if (ActionType == "Edit")
                    {
                        if (Id == null)
                            throw new Exception("Id وارد نشده است");
                        query = @" 
                                   UPDATE Offices  SET 
                                      {0}                                      
                                   WHERE Id = @Id 

                                 ";

                        if (OfficeName != null)
                            s0 += " OfficeName = @OfficeName  , ";

                        if (DoctorName != null)
                            s0 += " DoctorName = @DoctorName  , ";
                        if (OfficeCode != null)
                            s0 += " OfficeCode = @OfficeCode  , ";
                        if (OfficeType != null)
                            s0 += " OfficeType = @OfficeType  , ";
                        if (NezamPezeshki != null)
                            s0 += " NezamPezeshki = @NezamPezeshki , ";
                        if (PhoneNumber != null)
                            s0 += " PhoneNumber = @PhoneNumber , ";
                        if (OfficeAddress != null)
                            s0 += " OfficeAddress = @OfficeAddress , ";
                        if (Email != null)
                            s0 += " Email = @Email , ";
                        if (Website != null)
                            s0 += " Website = @Website , ";

                        if (DefaultDoctorId != null)
                            s0 += " DefaultDoctorId = @DefaultDoctorId , ";

                        if (DefaultBasicInsurerId != null)
                            s0 += " DefaultBasicInsurerId = @DefaultBasicInsurerId , ";

                        if (DefaultMaritalStatusId != null)
                            s0 += " DefaultMaritalStatusId = @DefaultMaritalStatusId , ";

                        if (DefaultEducationLevelId != null)
                            s0 += " DefaultEducationLevelId = @DefaultEducationLevelId , ";

                        if (DefaultNationalityId != null)
                            s0 += " DefaultNationalityId = @DefaultNationalityId , ";

                        if (Date != null)
                            s0 += " ModifiedDate = @ModifiedDate , ";

                        if (IsDeleted != null)
                            s0 += " IsDeleted = @IsDeleted , ";

                        s0 = s0.TrimEnd().TrimEnd(',');


                    }
                    if (ActionType == "New")
                    {

                        query = @"                                    
                                    INSERT INTO Offices
                                            ( OfficeName ,
                                              DoctorName ,
                                              OfficeCode ,
                                              OfficeType ,
                                              NezamPezeshki ,
                                              PhoneNumber ,
                                              OfficeAddress ,
                                              Email ,
                                              Website ,
                                              DefaultDoctorId ,
                                              DefaultBasicInsurerId ,
                                              DefaultMaritalStatusId , 
                                              DefaultEducationLevelId ,
                                              DefaultNationalityId , 
                                              ModifiedDate ,
                                              IsDeleted
                                            )
                                    VALUES  ( @OfficeName , 
                                              @DoctorName ,
                                              @OfficeCode , 
                                              @OfficeType ,
                                              @NezamPezeshki ,
                                              @PhoneNumber , 
                                              @OfficeAddress , 
                                              @Email , 
                                              @Website , 
                                              @DefaultDoctorId ,
                                              @DefaultMaritalStatusId , 
                                              @DefaultEducationLevelId ,
                                              @DefaultNationalityId ,
                                              @ModifiedDate ,
                                              @IsDeleted  
                                            )
                                    ;                                    
                                    SELECT last_insert_rowid()
                                 ";
                    }
                    if (ActionType == "Delete")
                    {

                    }

                    query = string.Format(query, s0);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).FirstOrDefault();

                    var finalResult =
                    new
                    {
                        MessageId = (Id != null) ? Id.Value : id
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


        public static JsonResponse<dynamic> DefineBaseCodingX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var ActionName = x.HasValue("ActionName") ? x.GetValue<string>("ActionName") : null;
                    var EntityName = x.HasValue("EntityName") ? x.GetValue<string>("EntityName") : null;
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;
                    var Title = x.HasValue("Title") ? x.GetValue<string>("Title") : null;
                    var Date = x.HasValue("Date") ? x.GetValue<DateTime>("Date") : (DateTime?)null;
                    var IsDeleted = x.HasValue("IsDeleted") ? x.GetValue<bool>("IsDeleted") : (bool?)false;

                    // Extra Fields
                    var BankId = x.HasValue("BankId") ? x.GetValue<int>("BankId") : (int?)null;
                    var Color = x.HasValue("Color") ? x.GetValue<int>("Color") : (int?)null;

                    if (EntityName == null)
                        throw new Exception("EntityName IS NULL");

                    var p = new Dapper.DynamicParameters();
                    p.Add("Id", value: Id);
                    p.Add("Title", value: Title);
                    p.Add("Date", value: Publics.ConvertDateTimeToString(Date));
                    p.Add("IsDeleted", value: IsDeleted);


                    var query = "";
                    var s0 = EntityName;
                    string s1 = "", s2 = "", s3 = "";

                    if (Id != null)
                    {

                        query = @" 
                                    UPDATE {0}  SET 
                                        {1}                                   
                                    WHERE Id = @Id 
                                 ";

                        if (Title != null)
                            s1 += " Title = @Title , ";
                        if (Date != null)
                            s1 += " Date = @Date , ";
                        if (IsDeleted != null)
                            s1 += " IsDeleted = @IsDeleted , ";

                        if (Color != null)
                        {
                            s1 += " Color = @Color , ";

                            p.Add("Color", value: Color);
                        }

                        if (BankId != null)
                        {
                            s1 += " BankId = @BankId , ";

                            p.Add("BankId", value: BankId);
                        }

                        if (IsDeleted != null)
                        {
                            s1 += " IsDeleted = @IsDeleted , ";
                        }

                        s1 = s1.TrimEnd().TrimEnd(',');
                    }
                    else
                    {
                        query = @"      
                                    INSERT  INTO {0}
                                            (   
                                                Title ,  
                                                {2}
                                                IsDeleted                                               
                                            )                                        
                                    SELECT                                                    
                                                @Title ,
                                                {3}
                                                0 

                                    WHERE NOT EXISTS ( SELECT Id FROM {0} WHERE Title = @Title  )  
                                    ;
                                    SELECT last_insert_rowid()
                                 ";

                        if (Color != null)
                        {
                            s2 += " Color , ";
                            s3 += " @Color , ";

                            p.Add("Color", value: Color);
                        }

                        if (BankId != null)
                        {
                            s2 += " BankId , ";
                            s3 += " @BankId , ";

                            p.Add("BankId", value: BankId);
                        }

                    }


                    query = string.Format(query, s0, s1, s2, s3);
                    var id = sql.Query<int>(query, param: p, transaction: transactionScope, commandType: CommandType.Text).SingleOrDefault();

                    var finalResult = (Id != null) ? Id.Value : id;


                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = finalResult };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
                    return new JsonResponse<dynamic>() { Success = false, Data = null, Message = ex.Message, };
                }
        }

        public static JsonResponse<dynamic> DeleteEntityX(dynamic searchObj)
        {
            if (sql == null) sql = DB.GetConnection();
            using (var transactionScope = sql.BeginTransaction())
                try
                {
                    var x = new RouteValueDictionary(searchObj);
                    var EntityTitle = x.HasValue("EntityTitle") ? x.GetValue<string>("EntityTitle") : null;
                    var Id = x.HasValue("Id") ? x.GetValue<int>("Id") : (int?)null;

                    if (EntityTitle == null)
                        throw new Exception("موجودیت مشخص نشده است");

                    if (Id == null)
                        throw new Exception("کلید مشخص نشده است");

                    var p = new Dapper.DynamicParameters();
                    p.Add("EntityTitle", value: EntityTitle);
                    p.Add("Id", value: Id);

                    var query = @" DELETE FROM {0} WHERE Id = {1} ";

                    query = string.Format(query, EntityTitle, Id);
                    var result = sql.Query(query, param: p, transaction: transactionScope, commandType: CommandType.Text);

                    transactionScope.Commit();
                    return new JsonResponse<dynamic>() { Success = true, Data = true };
                }
                catch (Exception ex)
                {
                    transactionScope.Rollback();
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

                // SQLiteConnection.ClearAllPools();
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
                    var sql = DB.GetConnection();
                    sql.Close();
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









    }
}


