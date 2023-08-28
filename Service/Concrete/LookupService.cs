using Data.Interface;
using Domain.Entities;
using Domain.Entities.Lookups;
using Microsoft.Data.SqlClient;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class LookupService : ILookupService
    {
        private readonly IRepository<LanguageLookup> _languagesRepository;
        private readonly IRepository<CountryLookup> _countryRepository;
        private readonly IRepository<NationalityLookup> _nationalityRepository;

        public LookupService(IRepository<LanguageLookup> languagesRepository, IRepository<CountryLookup> countryRepository, IRepository<NationalityLookup> nationalityRepository)
        {
            _languagesRepository = languagesRepository;
            _countryRepository = countryRepository;
            _nationalityRepository = nationalityRepository;
        }
        List<CountryLookup> ILookupService.GetCountryLookups()
        {
            return _countryRepository.GetAll().ToList();
        }

        List<LanguageLookup> ILookupService.GetLanguageValues()
        {
            return _languagesRepository.GetAll().ToList();
        }

        List<NationalityLookup> ILookupService.GetNationalityLookups()
        {
            return _nationalityRepository.GetAll().ToList();
        }
        public List<ServicesSubCategoryModel> GetServicesSubCategory()
        {
            SqlParameter[] param = new SqlParameter[0];


            var dataMenu = _languagesRepository.ExecuteStoredProcedure<ServicesSubCategoryModel>("sjc_GetServicesSubCategory", param);
            return dataMenu.ToList();
        }

        public List<AlertModel> GetAlerts(string userId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("UserId", userId);
            return _languagesRepository.ExecuteStoredProcedure<AlertModel>("sjc_GetAlerts", spParams).ToList();
        }

        public AlertModel GetAlertsById(string alertId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("AlertId", alertId);
            return _languagesRepository.ExecuteStoredProcedure<AlertModel>("sjc_GetAlertsById", spParams).FirstOrDefault();
        }

        //added by Muhammad Usman
        public ActionType GetActionById(int Id)
        {
            var dataMenu = _languagesRepository.ExecuteStoredProcedure<ActionType>("sjc_GetActionById", new Microsoft.Data.SqlClient.SqlParameter("ActionTypeId", Id));
            return dataMenu.FirstOrDefault();
        }
        public void DeleteAction(ActionType actionType, string userName)
        {
            {
                SqlParameter[] spParams = new SqlParameter[8];
                spParams[0] = new SqlParameter("@ActionTypeId", actionType.ActionTypeId);
                spParams[1] = new SqlParameter("@NameEn", actionType.NameEn);
                spParams[2] = new SqlParameter("@NameAr", actionType.NameAr);
                spParams[3] = new SqlParameter("@Createdby", userName);
                spParams[4] = new SqlParameter("@CreatedDate", actionType.CreatedDate);
                spParams[5] = new SqlParameter("@LastModifiedBy", userName);
                spParams[6] = new SqlParameter("@LastModifiedDate", actionType.LastModifiedDate);
                spParams[7] = new SqlParameter("@Action", "d");
                _languagesRepository.ExecuteStoredProcedure("sjc_ActionTypeLookup", spParams);
            }
        }
        List<ActionType> ILookupService.GetAllActionlist()
        {
            var dataMenu = _languagesRepository.ExecuteStoredProcedure<ActionType>("sjc_GetActiontypelist");
            var model = dataMenu.Select(x => new ActionType()
            {
                ActionTypeId = x.ActionTypeId,
                NameEn = x.NameEn,
                NameAr = x.NameAr,

            }).ToList();
            return model;
        }
        public void InsUpdActionLookup(ActionType actionType, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[8];
            spParams[0] = new SqlParameter("@ActionTypeId", actionType.ActionTypeId);
            spParams[1] = new SqlParameter("@NameEn", actionType.NameEn);
            spParams[2] = new SqlParameter("@NameAr", actionType.NameAr);
            spParams[3] = new SqlParameter("@Createdby", userName);
            spParams[4] = new SqlParameter("@CreatedDate", actionType.CreatedDate);
            spParams[5] = new SqlParameter("@LastModifiedBy", userName);
            spParams[6] = new SqlParameter("@LastModifiedDate", actionType.LastModifiedDate);
            spParams[7] = new SqlParameter("@Action", actionType.ActionTypeId > 0 ? "u" : "i");
            _languagesRepository.ExecuteStoredProcedure("sjc_ActionTypeLookup", spParams);
        }
        public bool UpdateAlertById(AlertModel alert)
        {
            SqlParameter[] spParams = new SqlParameter[3];
            spParams[0] = new SqlParameter("Alertid", alert.alertId);
            spParams[1] = new SqlParameter("IsViewed", true);
            spParams[2] = new SqlParameter("ViewedOn", DateTime.Now);
            _languagesRepository.ExecuteStoredProcedure("Sp_dml_updatealerts", spParams);
            return true;
        }

        public List<LookupsModel> GetCaseStatusLookup()
        {
            SqlParameter[] param = new SqlParameter[0];


            var dataMenu = _languagesRepository.ExecuteStoredProcedure<LookupsModel>("sjc_GetCaseStatusLookup", param);
            return dataMenu.ToList();
        }

        public List<GovernatesLookupModel> GetGovernatesLookupByCaseGroupId(long CaseGroupId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("CaseGroupId", CaseGroupId);
            return _languagesRepository.ExecuteStoredProcedure<GovernatesLookupModel>("sjc_GetGovernatesLookupByCaseGroupId", spParams).ToList();
        }

        public List<CaseGroupLookupModel> GetCaseGroupLookupByCaseGroupId(long CaseGroupId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("CaseGroupId", CaseGroupId);
            return _languagesRepository.ExecuteStoredProcedure<CaseGroupLookupModel>("sjc_GetCaseGroupLookup", spParams).ToList();
        }

        public List<LocationLookupModel> GetLocationLookupByGovernatesId(long GovernatesId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("GovernatesId", GovernatesId);
            return _languagesRepository.ExecuteStoredProcedure<LocationLookupModel>("sjc_GetLocationLookup", spParams).ToList();
        }

        public bool UpdateGovernatesLookupByCaseGroupId(GovernatesLookupModel governatesLookup)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("GovernateId", governatesLookup.GovernateId);
            spParams[1] = new SqlParameter("CaseGroupId", governatesLookup.CaseGroupId);
            spParams[2] = new SqlParameter("Code", governatesLookup.Code);
            spParams[3] = new SqlParameter("NameEn", governatesLookup.NameEn);
            spParams[4] = new SqlParameter("NameAr", governatesLookup.NameAr);
            spParams[5] = new SqlParameter("LastModifiedBy ", governatesLookup.LastModifiedBy);
            spParams[6] = new SqlParameter("LastModifiedDate", DateTime.Now);
            _languagesRepository.ExecuteStoredProcedure("Sjc_Update_GovernatesLookup", spParams);
            return true;
        }

        public bool UpdateCaseGroupLookup(CaseGroupLookupModel caseGroupLookup)
        {
            SqlParameter[] spParams = new SqlParameter[6];
            spParams[0] = new SqlParameter("CaseGroupId", caseGroupLookup.CaseGroupId);
            spParams[1] = new SqlParameter("Code", caseGroupLookup.Code);
            spParams[2] = new SqlParameter("NameEn", caseGroupLookup.NameEn);
            spParams[3] = new SqlParameter("NameAr", caseGroupLookup.NameAr);
            spParams[4] = new SqlParameter("LastModifiedBy ", caseGroupLookup.LastModifiedBy);
            spParams[5] = new SqlParameter("LastModifiedDate", DateTime.Now);
            _languagesRepository.ExecuteStoredProcedure("Sjc_Update_CaseGroupLookup", spParams);
            return true;
        }

        public bool UpdateLocationLookup(LocationLookupModel locationLookup)
        {
            SqlParameter[] spParams = new SqlParameter[8];
            spParams[0] = new SqlParameter("LocationId", locationLookup.LocationId);
            spParams[1] = new SqlParameter("GovernatesId", locationLookup.GovernatesId);
            spParams[2] = new SqlParameter("Code", locationLookup.Code);
            spParams[3] = new SqlParameter("NameEn", locationLookup.NameAr);
            spParams[4] = new SqlParameter("NameAr", locationLookup.NameAr);
            spParams[5] = new SqlParameter("LinkLocationId", locationLookup.NameAr);
            spParams[6] = new SqlParameter("LastModifiedBy ", locationLookup.LastModifiedBy);
            spParams[7] = new SqlParameter("LastModifiedDate", DateTime.Now);
            _languagesRepository.ExecuteStoredProcedure("Sjc_Update_LocationLookup", spParams);
            return true;
        }

        public bool AddGovernatesLookup(GovernatesLookupModel governatesLookup)
        {
            SqlParameter[] spParams = new SqlParameter[6];
            spParams[0] = new SqlParameter("CaseGroupId", governatesLookup.CaseGroupId);
            spParams[1] = new SqlParameter("Code", governatesLookup.Code);
            spParams[2] = new SqlParameter("NameEn", governatesLookup.NameEn);
            spParams[3] = new SqlParameter("NameAr", governatesLookup.NameAr);
            spParams[4] = new SqlParameter("CreatedBy", governatesLookup.CreatedBy);
            spParams[5] = new SqlParameter("Createdate", DateTime.Now);
     
            _languagesRepository.ExecuteStoredProcedure("sjc_insert_GovernatesLookup", spParams);
            return true;
        }

        public bool AddCaseGroupLookup(CaseGroupLookupModel caseGroupLookup)
        {
            SqlParameter[] spParams = new SqlParameter[5];
            spParams[0] = new SqlParameter("Code", caseGroupLookup.Code);
            spParams[1] = new SqlParameter("NameEn", caseGroupLookup.NameEn);
            spParams[2] = new SqlParameter("NameAr", caseGroupLookup.NameAr);
            spParams[3] = new SqlParameter("CreatedBy", caseGroupLookup.CreatedBy);
            spParams[4] = new SqlParameter("Createdate", DateTime.Now);

            _languagesRepository.ExecuteStoredProcedure("sjc_insert_CaseGroupLookup", spParams);
            return true;
        }

        public bool AddLocationLookup(LocationLookupModel locationLookup)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("GovernatesId", locationLookup.GovernatesId);
            spParams[1] = new SqlParameter("Code", locationLookup.Code);
            spParams[2] = new SqlParameter("NameEn", locationLookup.NameEn);
            spParams[3] = new SqlParameter("NameAr", locationLookup.NameAr);
            spParams[4] = new SqlParameter("LinkLocationId", locationLookup.LinkLocationId);
            spParams[5] = new SqlParameter("CreatedBy", locationLookup.CreatedBy);
            spParams[6] = new SqlParameter("Createdate", DateTime.Now);

            _languagesRepository.ExecuteStoredProcedure("sjc_insert_LocationLookup", spParams);
            return true;
        }

        public bool AddCaseTypeLookup(CaseTypesLookupModel caseTypeLookup)
        {
            SqlParameter[] spParams = new SqlParameter[8];
            spParams[0] = new SqlParameter("Code", caseTypeLookup.Code);
            spParams[1] = new SqlParameter("NameEn", caseTypeLookup.NameEn);
            spParams[2] = new SqlParameter("NameAr", caseTypeLookup.NameAr);
            spParams[3] = new SqlParameter("CourtTypeId", caseTypeLookup.CourtTypeId);
            spParams[4] = new SqlParameter("IsActive", caseTypeLookup.IsActive); 
            spParams[5] = new SqlParameter("CreatedBy", caseTypeLookup.CreatedBy);
            spParams[6] = new SqlParameter("Createdate", DateTime.Now);
            spParams[7] = new SqlParameter("CaseGroupId", caseTypeLookup.CaseGroupId);
            _languagesRepository.ExecuteStoredProcedure("sjc_insert_caseTypesLookup", spParams);
            return true;
        }

        public bool AddCaseCategoryLookup(CaseCategoryLookupModel caseCategoryLookup)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("Code", caseCategoryLookup.Code);
            spParams[1] = new SqlParameter("NameEn", caseCategoryLookup.NameEn);
            spParams[2] = new SqlParameter("NameAr", caseCategoryLookup.NameAr);
            spParams[3] = new SqlParameter("CaseTypeId", caseCategoryLookup.CaseTypeId);
            spParams[4] = new SqlParameter("IsActive", caseCategoryLookup.IsActive);
            spParams[5] = new SqlParameter("CreatedBy", caseCategoryLookup.CreatedBy);
            spParams[6] = new SqlParameter("Createdate", DateTime.Now);
 
            _languagesRepository.ExecuteStoredProcedure("sjc_insert_CaseCategoryLookup", spParams);
            return true;
        }

        public bool AddCaseSubCategoryLookup(CaseSubCategoryLookupModel caseSubCategoryLookup)
        {
            SqlParameter[] spParams = new SqlParameter[9];
            spParams[0] = new SqlParameter("NameEn", caseSubCategoryLookup.NameEn);
            spParams[1] = new SqlParameter("NameAr", caseSubCategoryLookup.NameAr);
            spParams[2] = new SqlParameter("CaseCategoryId", caseSubCategoryLookup.CaseCategoryId);
            spParams[3] = new SqlParameter("CodeCAAJ", caseSubCategoryLookup.CodeCAAJ);
            spParams[4] = new SqlParameter("CodeACO", caseSubCategoryLookup.CodeACO);
            spParams[5] = new SqlParameter("AllowPreviousSearch", caseSubCategoryLookup.AllowPreviousSearch);
            spParams[6] = new SqlParameter("IsActive", caseSubCategoryLookup.IsActive);
            spParams[7] = new SqlParameter("CreatedBy", caseSubCategoryLookup.CreatedBy);
            spParams[8] = new SqlParameter("Createdate", DateTime.Now);

            _languagesRepository.ExecuteStoredProcedure("sjc_insert_CaseSubCategoryLookup", spParams);
            return true;
        }

        public List<CaseTypesLookupModel> caseTypesLookup()
        {
            SqlParameter[] param = new SqlParameter[0];


            var dataMenu = _languagesRepository.ExecuteStoredProcedure<CaseTypesLookupModel>("sjc_Get_CaseTypesLookup", param);
            return dataMenu.ToList();
        }

        public List<CaseCategoryLookupModel> GetcaseCategoryLookup()
        {
            SqlParameter[] param = new SqlParameter[0];
            var dataMenu = _languagesRepository.ExecuteStoredProcedure<CaseCategoryLookupModel>("sjc_Get_CaseCategoryLookup", param);
            return dataMenu.ToList();
        }

        public List<CaseSubCategoryLookupModel> GetcaseSubCategoryLookup()
        {
            SqlParameter[] param = new SqlParameter[0];
            var dataMenu = _languagesRepository.ExecuteStoredProcedure<CaseSubCategoryLookupModel>("sjc_Get_CaseSubCategoryLookup", param);
            return dataMenu.ToList();
        }

        public bool UpdateCaseTypeLookup(CaseTypesLookupModel caseTypesLookup)
        {
            SqlParameter[] spParams = new SqlParameter[9];
            spParams[0] = new SqlParameter("CaseTypeId", caseTypesLookup.CaseTypeId);
            spParams[1] = new SqlParameter("Code", caseTypesLookup.Code);
            spParams[2] = new SqlParameter("NameEn", caseTypesLookup.NameEn);
            spParams[3] = new SqlParameter("NameAr", caseTypesLookup.NameAr);
            spParams[4] = new SqlParameter("CourtTypeId", caseTypesLookup.CourtTypeId);
            spParams[5] = new SqlParameter("IsActive", caseTypesLookup.IsActive);
            spParams[6] = new SqlParameter("LastModifiedBy ", caseTypesLookup.LastModifiedBy);
            spParams[7] = new SqlParameter("LastModifiedDate", DateTime.Now);
            spParams[8] = new SqlParameter("CaseGroupId" , caseTypesLookup.CaseGroupId);
            _languagesRepository.ExecuteStoredProcedure("Sjc_Update_CaseTypesLookup", spParams);
            return true;
        }

        public bool UpdateCaseCategoryLookup(CaseCategoryLookupModel caseCategoryLookup)
        {
            SqlParameter[] spParams = new SqlParameter[8];
            spParams[0] = new SqlParameter("CaseCategoryId", caseCategoryLookup.CaseCategoryId);
            spParams[1] = new SqlParameter("Code", caseCategoryLookup.Code);
            spParams[2] = new SqlParameter("NameEn", caseCategoryLookup.NameEn);
            spParams[3] = new SqlParameter("NameAr", caseCategoryLookup.NameAr);
            spParams[4] = new SqlParameter("CaseTypeId", caseCategoryLookup.CaseTypeId);
            spParams[5] = new SqlParameter("IsActive", caseCategoryLookup.IsActive);
            spParams[6] = new SqlParameter("LastModifiedBy ", caseCategoryLookup.LastModifiedBy);
            spParams[7] = new SqlParameter("LastModifiedDate", DateTime.Now);
            _languagesRepository.ExecuteStoredProcedure("Sjc_Update_CaseCategoryLookup", spParams);
            return true;
        }

        public bool UpdateCaseSubCategoryLookup(CaseSubCategoryLookupModel caseSubCategoryLookup)
        {
            SqlParameter[] spParams = new SqlParameter[10];
            spParams[0] = new SqlParameter("CaseSubCategoryId", caseSubCategoryLookup.CaseSubCategoryId);
            spParams[1] = new SqlParameter("NameEn", caseSubCategoryLookup.NameEn);
            spParams[2] = new SqlParameter("NameAr", caseSubCategoryLookup.NameAr);
            spParams[3] = new SqlParameter("CaseCategoryId", caseSubCategoryLookup.CaseCategoryId);
            spParams[4] = new SqlParameter("CodeCAAJ", caseSubCategoryLookup.CodeCAAJ);
            spParams[5] = new SqlParameter("CodeACO", caseSubCategoryLookup.CodeACO);
            spParams[6] = new SqlParameter("AllowPreviousSearch", caseSubCategoryLookup.AllowPreviousSearch);
            spParams[7] = new SqlParameter("IsActive", caseSubCategoryLookup.IsActive);
            spParams[8] = new SqlParameter("LastModifiedBy ", caseSubCategoryLookup.LastModifiedBy);
            spParams[9] = new SqlParameter("LastModifiedDate", DateTime.Now);
            _languagesRepository.ExecuteStoredProcedure("Sjc_Update_CaseSubCategoryLookup", spParams);
            return true;
        }

        public bool DeleteCaseTypeLookup(CaseTypesLookupModelDelete deletecaseTypesLookup)
        {
            SqlParameter[] spParams = new SqlParameter[2];
            spParams[0] = new SqlParameter("CaseTypeId", deletecaseTypesLookup.CaseTypeId);
            spParams[1] = new SqlParameter("Deleted", deletecaseTypesLookup.Deleted);
            _languagesRepository.ExecuteStoredProcedure("Sjc_delete_CaseTypesLookup", spParams);
            return true;
        }

        public bool DeleteCaseCategoryLookup(CaseCategoryLookupModelDelete deletecaseCategoryLookupModel)
        {
            SqlParameter[] spParams = new SqlParameter[2];
            spParams[0] = new SqlParameter("CaseCategoryId", deletecaseCategoryLookupModel.CaseCategoryId);
            spParams[1] = new SqlParameter("Deleted", deletecaseCategoryLookupModel.Deleted);
            _languagesRepository.ExecuteStoredProcedure("Sjc_delete_CaseCategoryLookup", spParams);
            return true;
        }

        public bool DeleteCaseSubCategoryLookupModel(CaseSubCategoryLookupModelDelete deleteCaseSubCategoryLookupModel)
        {
            SqlParameter[] spParams = new SqlParameter[2];
            spParams[0] = new SqlParameter("CaseSubCategoryId ", deleteCaseSubCategoryLookupModel.CaseSubCategoryId);
            spParams[1] = new SqlParameter("Deleted", deleteCaseSubCategoryLookupModel.Deleted);
            _languagesRepository.ExecuteStoredProcedure("Sjc_delete_CaseSubCategoryLookup", spParams);
            return true;
        }
    }
}
