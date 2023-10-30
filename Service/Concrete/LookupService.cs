using Data.Interface;
using Domain.Entities;
using Domain.Entities.Lookups;
using Microsoft.Data.SqlClient;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class LookupService : ILookupService
    {
        private readonly IRepository<SYS_Language> _languagesRepository;
        private readonly IRepository<LKT_Country> _countryRepository;
        private readonly IRepository<LKT_Nationality> _nationalityRepository;

        public LookupService(IRepository<SYS_Language> languagesRepository, IRepository<LKT_Country> countryRepository, IRepository<LKT_Nationality> nationalityRepository)
        {
            _languagesRepository = languagesRepository;
            _countryRepository = countryRepository;
            _nationalityRepository = nationalityRepository;
        }
        List<LKT_Country> ILookupService.GetCountryLookups()
        {
            return _countryRepository.GetAll().ToList();
        }

        List<SYS_Language> ILookupService.GetLanguageValues()
        {
            return _languagesRepository.GetAll().ToList();
            /*
            SqlParameter[] spParams = new SqlParameter[2];
            spParams[0] = new SqlParameter("PageSize", 5000);
            spParams[0] = new SqlParameter("PageNumber", 1);
            return _languagesRepository.ExecuteStoredProcedure<SYS_Language>("sjc_GetAll_LanguageLookup", spParams).ToList();*/
        }

        List<LKT_Nationality> ILookupService.GetNationalityLookups()
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
        public RequestStatus GetReqStatusById(int Id)
        {
            var dataMenu = _languagesRepository.ExecuteStoredProcedure<RequestStatus>("sjc_GetRequsetById", new Microsoft.Data.SqlClient.SqlParameter("StatusId", Id));
            return dataMenu.FirstOrDefault();
        }
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
        public void DeleteRequest(RequestStatus requestStatus, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[8];
            spParams[0] = new SqlParameter("@StatusId", requestStatus.StatusId);
            spParams[1] = new SqlParameter("@NameEn", requestStatus.NameEn);
            spParams[2] = new SqlParameter("@NameAr", requestStatus.NameAr);
            spParams[3] = new SqlParameter("@Createdby", userName);
            spParams[4] = new SqlParameter("@CreatedDate", requestStatus.CreatedDate);
            spParams[5] = new SqlParameter("@LastModifiedBy", userName);
            spParams[6] = new SqlParameter("@LastModifiedDate", requestStatus.LastModifiedDate);
            spParams[7] = new SqlParameter("@Action", "d");
            _languagesRepository.ExecuteStoredProcedure("sjc_RequestStatusLookup", spParams);
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
        List<RequestStatus> ILookupService.GetAllStatusList()
        {
            var dataMenu = _languagesRepository.ExecuteStoredProcedure<RequestStatus>("sjc_GetrequestStatusList");
            var model = dataMenu.Select(x => new RequestStatus()
            {
                StatusId = x.StatusId,
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
        public void InsUpdStatusLookup(RequestStatus requestStatus, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[8];
            spParams[0] = new SqlParameter("@StatusId", requestStatus.StatusId);
            spParams[1] = new SqlParameter("@NameEn", requestStatus.NameEn);
            spParams[2] = new SqlParameter("@NameAr", requestStatus.NameAr);
            spParams[3] = new SqlParameter("@Createdby", userName);
            spParams[4] = new SqlParameter("@CreatedDate", requestStatus.CreatedDate);
            spParams[5] = new SqlParameter("@LastModifiedBy", userName);
            spParams[6] = new SqlParameter("@LastModifiedDate", requestStatus.LastModifiedDate);
            spParams[7] = new SqlParameter("@Action", requestStatus.StatusId > 0 ? "u" : "i");
            _languagesRepository.ExecuteStoredProcedure("sjc_RequestStatusLookup", spParams);
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
            spParams[3] = new SqlParameter("NameEn", locationLookup.NameEn);
            spParams[4] = new SqlParameter("NameAr", locationLookup.NameAr);
            spParams[5] = new SqlParameter("LinkLocationId", ""); ;
            spParams[6] = new SqlParameter("LastModifiedBy ", locationLookup.LastModifiedBy);
            spParams[7] = new SqlParameter("LastModifiedDate", DateTime.Now);
            _languagesRepository.ExecuteStoredProcedure("Sjc_Update_LocationLookup", spParams);
            return true;
        }

        public bool AddGovernatesLookup(GovernatesLookupModel governatesLookup, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[6];
            spParams[0] = new SqlParameter("CaseGroupId", governatesLookup.CaseGroupId);
            spParams[1] = new SqlParameter("Code", governatesLookup.Code);
            spParams[2] = new SqlParameter("NameEn", governatesLookup.NameEn);
            spParams[3] = new SqlParameter("NameAr", governatesLookup.NameAr);
            spParams[4] = new SqlParameter("CreatedBy", userName);
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
        public string AddLocationLookup(LocationLookupModel locationLookup)
        {

            SqlParameter[] spParams = new SqlParameter[8];


            spParams[0] = new SqlParameter("GovernatesId", locationLookup.GovernatesId);
            spParams[1] = new SqlParameter("Code", locationLookup.Code);
            spParams[2] = new SqlParameter("NameEn", locationLookup.NameEn);
            spParams[3] = new SqlParameter("NameAr", locationLookup.NameAr);
            spParams[4] = new SqlParameter("LinkLocationId", locationLookup.LinkLocationId);
            spParams[5] = new SqlParameter("CreatedBy", locationLookup.CreatedBy);
            spParams[6] = new SqlParameter("Createdate", DateTime.Now);
            spParams[7] = new SqlParameter("Message", SqlDbType.NVarChar, 255);
            spParams[7].Direction = ParameterDirection.Output;
            _languagesRepository.ExecuteStoredProcedure("sjc_insert_LocationLookup", spParams);
            string msg = spParams[7].Value.ToString();

            return msg;
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

        public bool AddCaseCategoryLookup(CaseCategoryLookupModel caseCategoryLookup, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("Code", caseCategoryLookup.Code);
            spParams[1] = new SqlParameter("NameEn", caseCategoryLookup.NameEn);
            spParams[2] = new SqlParameter("NameAr", caseCategoryLookup.NameAr);
            spParams[3] = new SqlParameter("CaseTypeId", caseCategoryLookup.CaseTypeId);
            spParams[4] = new SqlParameter("IsActive", caseCategoryLookup.IsActive);
            spParams[5] = new SqlParameter("CreatedBy", userName);
            spParams[6] = new SqlParameter("Createdate", DateTime.Now);

            _languagesRepository.ExecuteStoredProcedure("sjc_insert_CaseCategoryLookup", spParams);
            return true;
        }

        public bool AddCaseSubCategoryLookup(CaseSubCategoryLookupModel caseSubCategoryLookup, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[8];
            spParams[0] = new SqlParameter("NameEn", caseSubCategoryLookup.NameEn);
            spParams[1] = new SqlParameter("NameAr", caseSubCategoryLookup.NameAr);
            spParams[2] = new SqlParameter("CaseCategoryId", caseSubCategoryLookup.CaseCategoryId);
            spParams[3] = new SqlParameter("CodeCAAJ", caseSubCategoryLookup.CodeCAAJ);
            spParams[4] = new SqlParameter("CodeACO", caseSubCategoryLookup.CodeACO);
            spParams[5] = new SqlParameter("AllowPreviousSearch", caseSubCategoryLookup.AllowPreviousSearch);
            spParams[6] = new SqlParameter("IsActive", caseSubCategoryLookup.IsActive);
            spParams[7] = new SqlParameter("CreatedBy", caseSubCategoryLookup.CreatedBy);

            _languagesRepository.ExecuteStoredProcedure("sjc_insert_CaseSubCategoryLookup", spParams);
            return true;
        }

        //public List<CaseTypesLookupModel> caseTypesLookup(int caseGroupId)
        //{
        //    SqlParameter[] param = new SqlParameter[0];
        //    var dataMenu = _languagesRepository.ExecuteStoredProcedure<CaseTypesLookupModel>("sjc_GetAll_CaseTypesLookup", param);
        //    return dataMenu.ToList();
        //}
        public List<CaseTypesLookupModel> caseTypesLookup(int CaseGroupId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CaseGroupId", CaseGroupId);
            var dataMenu = _languagesRepository.ExecuteStoredProcedure<CaseTypesLookupModel>("sjc_Get_CaseTypesLookup", param);
            return dataMenu.ToList();
        }

        public List<CaseGroupLookupModel> BindCaseGroup()
        {
            SqlParameter[] param = new SqlParameter[0];
            var data = _languagesRepository.ExecuteStoredProcedure<CaseGroupLookupModel>("sjc_GetCaseGroup", param);
            return data.ToList();
        }

        public List<GovernatesLookupModel> BindGovernateLookup()
        {
            SqlParameter[] param = new SqlParameter[0];
            var data = _languagesRepository.ExecuteStoredProcedure<GovernatesLookupModel>("sjc_GetGovernateLookup", param);
            return data.ToList();
        }

        public List<LocationLookupModel> GelAllLocationLookup()
        {
            SqlParameter[] param = new SqlParameter[0];
            var data = _languagesRepository.ExecuteStoredProcedure<LocationLookupModel>("sjc_GetAllLocationLookup", param);
            return data.ToList();
        }

        public LocationLookupModel GelLocationLookupById(int LocationId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("LocationId", LocationId);
            var data = _languagesRepository.ExecuteStoredProcedure<LocationLookupModel>("sjc_GetLocationLookupById", param).FirstOrDefault();
            return data;
        }

        public List<GovernatesLookupModel> GetAllGovernateLookup()
        {
            SqlParameter[] param = new SqlParameter[0];
            var data = _languagesRepository.ExecuteStoredProcedure<GovernatesLookupModel>("sjc_GetAllGovernateLookup", param);
            return data.ToList();
        }

        public GovernatesLookupModel GetGovernateLookupById(int governateId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("governateid", governateId);
            var data = _languagesRepository.ExecuteStoredProcedure<GovernatesLookupModel>("sjc_GetGovernateLookupById", param).FirstOrDefault();
            return data;
        }

        public bool UpdateGovernatesLookupByGovernateId(GovernatesLookupModel governatesLookup)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("GovernateId", governatesLookup.GovernateId);
            spParams[1] = new SqlParameter("CaseGroupId", governatesLookup.CaseGroupId);
            spParams[2] = new SqlParameter("Code", governatesLookup.Code);
            spParams[3] = new SqlParameter("NameEn", governatesLookup.NameEn);
            spParams[4] = new SqlParameter("NameAr", governatesLookup.NameAr);
            spParams[5] = new SqlParameter("LastModifiedBy ", true);
            spParams[6] = new SqlParameter("LastModifiedDate", DateTime.Now);
            _languagesRepository.ExecuteStoredProcedure("Sjc_Update_GovernatesLookup", spParams);
            return true;
        }

        public List<CaseCategoryLookupModel> GetcaseCategoryLookup(int CaseTypeId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CaseTypeId", CaseTypeId);
            var dataMenu = _languagesRepository.ExecuteStoredProcedure<CaseCategoryLookupModel>("sjc_Get_CaseCategoryLookup", param);
            return dataMenu.ToList();
        }

        public List<CaseSubCategoryLookupModel> GetcaseSubCategoryLookup(int CaseCategoryId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CaseCategoryId", CaseCategoryId);
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
            spParams[8] = new SqlParameter("CaseGroupId", caseTypesLookup.CaseGroupId);
            _languagesRepository.ExecuteStoredProcedure("Sjc_Update_CaseTypesLookup", spParams);
            return true;
        }

        public bool UpdateCaseCategoryLookup(CaseCategoryLookupModel caseCategoryLookup, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("CaseCategoryId", caseCategoryLookup.CaseCategoryId);
            spParams[1] = new SqlParameter("Code", caseCategoryLookup.Code);
            spParams[2] = new SqlParameter("NameEn", caseCategoryLookup.NameEn);
            spParams[3] = new SqlParameter("NameAr", caseCategoryLookup.NameAr);
            spParams[4] = new SqlParameter("CaseTypeId", caseCategoryLookup.CaseTypeId);
            spParams[5] = new SqlParameter("IsActive", caseCategoryLookup.IsActive);
            spParams[6] = new SqlParameter("LastModifiedBy ", userName);
            _languagesRepository.ExecuteStoredProcedure("Sjc_Update_CaseCategoryLookup", spParams);
            return true;
        }

        public bool UpdateCaseSubCategoryLookup(CaseSubCategoryLookupModel caseSubCategoryLookup, string userName)
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

        public bool DeleteCaseCategoryLookup(int id)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("CaseCategoryId", id);
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

        public List<CaseCategoryLookupModel> GetAllCaseCategory()
        {
            SqlParameter[] param = new SqlParameter[0];
            var data = _languagesRepository.ExecuteStoredProcedure<CaseCategoryLookupModel>("sjc_GetAll_CaseCategoryLookup", param);
            return data.ToList();
        }

        public CaseCategoryLookupModel GetCaseCategoryById(int caseCategoryId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CaseCategoryId", caseCategoryId);
            var data = _languagesRepository.ExecuteStoredProcedure<CaseCategoryLookupModel>("sjc_GetAll_CaseCategoryLookup", param).FirstOrDefault();
            return data;
        }

        public CaseSubCategoryLookupModel GetcaseSubCategoryLookupById(int caseSubCategoryId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CaseSubCategoryId", caseSubCategoryId);
            var data = _languagesRepository.ExecuteStoredProcedure<CaseSubCategoryLookupModel>("sjc_Get_CaseSubCategoryLookup", param).FirstOrDefault();
            return data;
        }

        public bool AddLanguageLookup(LanguageLookupModel languageLookupModel, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("LanguageId", languageLookupModel.LanguageId);
            spParams[1] = new SqlParameter("Key", languageLookupModel.Key);
            spParams[2] = new SqlParameter("EnglishValue", languageLookupModel.EnglishValue);
            spParams[3] = new SqlParameter("ArabicValue", languageLookupModel.ArabicValue);
            spParams[4] = new SqlParameter("CreatedBy", userName);
            spParams[5] = new SqlParameter("Deleted", false);
            spParams[6] = new SqlParameter("LastModifiedBy", userName);

            _languagesRepository.ExecuteStoredProcedure("sjc_insert_LanguageLookup", spParams);
            return true;
        }


        public List<LookupsModel> GetPartyTypes(int CaseTypeId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CaseTypeId", CaseTypeId);
            var dataMenu = _languagesRepository.ExecuteStoredProcedure<LookupsModel>("sjc_GetPartyTypeByCaseTypeId", param);
            return dataMenu.ToList();
        }

        public bool UpdateLanguageLookup(LanguageLookupModel languageLookupModel, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[5];
            spParams[0] = new SqlParameter("LanguageId", languageLookupModel.LanguageId);
            spParams[1] = new SqlParameter("Key", languageLookupModel.Key);
            spParams[2] = new SqlParameter("EnglishValue", languageLookupModel.EnglishValue);
            spParams[3] = new SqlParameter("ArabicValue", languageLookupModel.ArabicValue);
            spParams[4] = new SqlParameter("LastModifiedBy", userName);

            _languagesRepository.ExecuteStoredProcedure("sjc_update_LanguageLookup", spParams);
            return true;
        }

        public List<LanguageLookupModel> GetLanguageLookup()
        {
            SqlParameter[] param = new SqlParameter[0];
            var data = _languagesRepository.ExecuteStoredProcedure<LanguageLookupModel>("sjc_GetAll_LanguageLookup", param).ToList();
            return data;
        }

        public LanguageLookupModel GetLanguageLookupById(int languageLookupId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("LanguageId", languageLookupId);
            var data = _languagesRepository.ExecuteStoredProcedure<LanguageLookupModel>("sjc_GetAll_LanguageLookup", param).FirstOrDefault();
            return data;
        }
        public PaginatedLanguageLookupModel GetLanguageLookup(int pageSize, int pageNumber, string? SearchText)
        {

            SqlParameter[] param = new SqlParameter[3];
            param[0] = new SqlParameter("pageSize", pageSize);
            param[1] = new SqlParameter("pageNumber", pageNumber);
            param[2] = new SqlParameter("SearchText", SearchText);
            var data = _languagesRepository.ExecuteStoredProcedure<LanguageLookupModel>("sjc_GetAll_LanguageLookup", param).ToList();
            int countItem = 0;
            if (SearchText != null)
            {
                SqlParameter[] paramSearch = new SqlParameter[1];
                paramSearch[0] = new SqlParameter("SearchText", SearchText);

                var count = _languagesRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetAll_LanguageLookupCount", paramSearch).FirstOrDefault();
                countItem = count.TotalCount;
            }
            else
            {
                var count = _languagesRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetAll_LanguageLookupCount").FirstOrDefault();
                countItem = count.TotalCount;
            }
            PaginatedLanguageLookupModel paginatedLanguageLookupModel = new PaginatedLanguageLookupModel()
            {
                PaginatedData = data,
                TotalCount = countItem
            };
            return paginatedLanguageLookupModel;
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

        public bool DeleteCaseGroupLookup(int id)
        {
            SqlParameter[] spParams = new SqlParameter[2];
            spParams[0] = new SqlParameter("CaseGroupId", id);
            spParams[1] = new SqlParameter("Deleted", true);
            _languagesRepository.ExecuteStoredProcedure("Sjc_delete_CaseGroupLookup", spParams);
            return true;
        }

        public bool DeleteGovernatesLookup(int id)
        {
            SqlParameter[] spParams = new SqlParameter[2];
            spParams[0] = new SqlParameter("@GovernateId", id);
            spParams[1] = new SqlParameter("@Deleted", true);
            _languagesRepository.ExecuteStoredProcedure("Sjc_delete_GovernateLookup", spParams);
            return true;
        }

        public bool DeleteLocationLookup(int id)
        {
            SqlParameter[] spParams = new SqlParameter[2];
            spParams[0] = new SqlParameter("@LocationId ", id);
            spParams[1] = new SqlParameter("@Deleted", true);
            _languagesRepository.ExecuteStoredProcedure("Sjc_delete_LocationLookup", spParams);
            return true;
        }
        public bool UpdateStatus(int caseGroupId, string status)
        {
            SqlParameter[] spParams = new SqlParameter[2];
            spParams[0] = new SqlParameter("CaseGroupId", caseGroupId);
            spParams[1] = new SqlParameter("Status", status);
            _languagesRepository.ExecuteStoredProcedure("Sjc_update_CaseGroupStatus", spParams);
            return true;
        }

        public LanguageLookupModel GetCode(string code)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("Key", code);
            return _languagesRepository.ExecuteStoredProcedure<LanguageLookupModel>("sjc_GetLanguageCode", spParams).FirstOrDefault();
        }

        public SystemParameterModel GetSystemSettingByName(string KeyName)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("@KeyName", KeyName);
            return _languagesRepository.ExecuteStoredProcedure<SystemParameterModel>("sjc_GetSystemSettingsByKeyName", spParams).FirstOrDefault();
        }
        public List<LKTGovernorateModel> getGovernorates()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _languagesRepository.ExecuteStoredProcedure<LKTGovernorateModel>("sp_GetGovernorates", parameters).ToList();
        }
        public List<LookupsModel> getWilayaByGovernorate(int GovernorateId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@GovernorateId", GovernorateId);
            return _languagesRepository.ExecuteStoredProcedure<LookupsModel>("sp_GetWilaya", parameters).ToList();
        }
        public List<LookupsModel> getVillageByWilaya(int GovernorateId, int WilayaId)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@GovernorateId", GovernorateId);
            parameters[1] = new SqlParameter("@WilayaId", WilayaId);
            return _languagesRepository.ExecuteStoredProcedure<LookupsModel>("sp_GetVillage", parameters).ToList();
        }
        public List<LookupsModel> getAddressType()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _languagesRepository.ExecuteStoredProcedure<LookupsModel>("sp_GetAddressype", parameters).ToList();
        }
        public List<DocumentTypeLookupModel> GetRequiredDocumentTypes(string docIds)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("@DocIds", docIds);
            var model = _languagesRepository.ExecuteStoredProcedure<DocumentTypeLookupModel>("sp_ReqiuredDocumentType", spParams).ToList();
            return model;
        }
        public List<LookupsModel> getRequestLinkSource()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _languagesRepository.ExecuteStoredProcedure<LookupsModel>("sp_GetRequestLinkSource", parameters).ToList();
        }

        public AccountDetail CheckAccountDetail(int UserId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("@UserId", UserId);
            return _languagesRepository.ExecuteStoredProcedure<AccountDetail>("SJC_GetCheckAccountDetail", parameters).FirstOrDefault();

        }
    }
}
