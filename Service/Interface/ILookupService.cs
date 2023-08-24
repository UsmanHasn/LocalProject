using Domain.Entities.Lookups;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ILookupService
    {
        List<LanguageLookup> GetLanguageValues();
        List<NationalityLookup> GetNationalityLookups();
        List<CountryLookup> GetCountryLookups();
        List<ServicesSubCategoryModel> GetServicesSubCategory();
        List<AlertModel> GetAlerts(string userId);
        AlertModel GetAlertsById(string alertId);

        bool UpdateAlertById(AlertModel alert);

        List<LookupsModel> GetCaseStatusLookup();
    }
}
