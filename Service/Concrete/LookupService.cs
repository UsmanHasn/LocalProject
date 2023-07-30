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
    }
}
