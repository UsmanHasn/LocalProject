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
            spParams[5] = new SqlParameter("LastModifiedBy ", true);
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
            spParams[4] = new SqlParameter("LastModifiedBy ", true);
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
            spParams[6] = new SqlParameter("LastModifiedBy ", true);
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
            spParams[4] = new SqlParameter("CreatedBy", true);
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
            spParams[3] = new SqlParameter("CreatedBy", true);
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
            spParams[5] = new SqlParameter("CreatedBy", true);
            spParams[6] = new SqlParameter("Createdate", DateTime.Now);

            _languagesRepository.ExecuteStoredProcedure("sjc_insert_LocationLookup", spParams);
            return true;
        }
    }
}
