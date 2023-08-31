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
        //added by muhammad usman
        ActionType GetActionById(int Id);
        RequestStatus GetReqStatusById(int Id);
        List<ActionType> GetAllActionlist();
        List<RequestStatus> GetAllStatusList();
        void InsUpdActionLookup(ActionType actionType, string userName);
        void DeleteAction(ActionType actionType, string userName);
        void DeleteRequest(RequestStatus requestStatus, string userName);
        bool UpdateAlertById(AlertModel alert);
        void InsUpdStatusLookup(RequestStatus requestStatus, string userName);
        List<LookupsModel> GetCaseStatusLookup();
        List<GovernatesLookupModel> GetGovernatesLookupByCaseGroupId(long CaseGroupId);
        List<CaseGroupLookupModel> GetCaseGroupLookupByCaseGroupId(long CaseGroupId);
        List<LocationLookupModel> GetLocationLookupByGovernatesId(long GovernatesId);
        bool UpdateGovernatesLookupByCaseGroupId(GovernatesLookupModel governatesLookup);
        bool UpdateCaseGroupLookup(CaseGroupLookupModel caseGroupLookup);
        bool UpdateLocationLookup(LocationLookupModel locationLookup);

        bool AddGovernatesLookup(GovernatesLookupModel governatesLookup);
        bool AddCaseGroupLookup(CaseGroupLookupModel caseGroupLookup);
        bool AddLocationLookup(LocationLookupModel locationLookup);
    }
}
