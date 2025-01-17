﻿using Domain.Entities.Lookups;
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
        List<SYS_Language> GetLanguageValues();
        List<LKT_Nationality> GetNationalityLookups();
        List<LKT_Country> GetCountryLookups();
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
        bool UpdateGovernatesLookupByGovernateId(GovernatesLookupModel governatesLookup);
        bool UpdateCaseGroupLookup(CaseGroupLookupModel caseGroupLookup);
        bool UpdateLocationLookup(LocationLookupModel locationLookup);

        bool AddGovernatesLookup(GovernatesLookupModel governatesLookup, string userName);
        bool AddCaseGroupLookup(CaseGroupLookupModel caseGroupLookup);
        bool DeleteCaseGroupLookup(int id);
        bool DeleteGovernatesLookup(int id);
        bool DeleteLocationLookup(int id);
        bool UpdateStatus(int caseGroupId, string status);
        string AddLocationLookup(LocationLookupModel locationLookup);
        bool AddCaseTypeLookup(CaseTypesLookupModel caseTypeLookup);
        bool AddCaseCategoryLookup(CaseCategoryLookupModel caseCategoryLookup, string userName);
        List<CaseCategoryLookupModel> GetAllCaseCategory();
        public CaseCategoryLookupModel GetCaseCategoryById(int caseCategoryId);
        bool AddCaseSubCategoryLookup(CaseSubCategoryLookupModel caseSubCategoryLookup, string userName);


        //List<CaseTypesLookupModel> caseTypesLookup();
        List<CaseTypesLookupModel> caseTypesLookup(int CaseGroupId);
        List<CaseGroupLookupModel> BindCaseGroup();
        List<GovernatesLookupModel> BindGovernateLookup();
        List<LocationLookupModel> GelAllLocationLookup();
        LocationLookupModel GelLocationLookupById(int LocationId);

        paginationGovernates GetAllGovernateLookup(int pageSize, int pageNumber, string? SearchText);
        GovernatesLookupModel GetGovernateLookupById(int governateId);
        List<CaseCategoryLookupModel> GetcaseCategoryLookup();
        List<CaseSubCategoryLookupModel> GetcaseSubCategoryLookup();
        CaseSubCategoryLookupModel GetcaseSubCategoryLookupById(int caseSubCategoryId);

        List<CaseSubCategoryLookupModel> GetcaseOnlySubCategoryLookup();
        List<CaseCategoryLookupModel> GetcaseCategoryLookup(int CaseTypeId);
        List<CaseSubCategoryLookupModel> GetcaseSubCategoryLookup(int CaseCategoryId);

        bool UpdateCaseTypeLookup(CaseTypesLookupModel caseTypesLookup);
        bool UpdateCaseCategoryLookup(CaseCategoryLookupModel caseCategoryLookup, string userName);
        bool UpdateCaseSubCategoryLookup(CaseSubCategoryLookupModel caseSubCategoryLookup, string userName);

        bool DeleteCaseTypeLookup(CaseTypesLookupModelDelete deletecaseTypesLookup);
        bool DeleteCaseCategoryLookup(int id);
        bool DeleteCaseSubCategoryLookupModel(CaseSubCategoryLookupModelDelete deleteCaseSubCategoryLookupModel);


        bool AddLanguageLookup(LanguageLookupModel languageLookupModel, string userName);
        bool UpdateLanguageLookup(LanguageLookupModel languageLookupModel, string userName);
        PaginatedLanguageLookupModel GetLanguageLookup(int pageSize, int pageNumber, string? SearchText);

        LanguageLookupModel GetLanguageLookupById(int languageLookupId);
        List<LookupsModel> GetPartyTypes(int CaseTypeId);
        public LanguageLookupModel GetCode(string code);
        List<LKTGovernorateModel> getGovernorates();
        List<LookupsModel> getWilayaByGovernorate(int GovernorateId);
        List<LookupsModel> getVillageByWilaya(int GovernorateId, int WilayaId);
        List<LookupsModel> getAddressType();
        List<DocumentTypeLookupModel> GetRequiredDocumentTypes(string docIds);
        public SystemParameterModel GetSystemSettingByName(string KeyName);
        List<LookupsModel> getRequestLinkSource();

        AccountDetail CheckAccountDetail(int UserId);

       



        void InsUpdRequestLinkSource(RequestLinkSource requestLinkSource, string userName);
        RequestLinkSource GetRequestLinkSourceById(int Id);
        List<RequestLinkSource> GetRequestLinkSourceList();

        void DeleteRequestLinkSource(RequestLinkSource requestLinkSource, string userName);

        List<Lkt_RequestEvent> GetAllRequestEvents();

        Lkt_RequestEvent GetRequestEventById(int Id);

        void InsUpdLKT_RequestEvents(Lkt_RequestEvent RequestEvent, string userName);

        void DeleteRequestEvent(Lkt_RequestEvent RequestEvent, string userName);

        void  InsUpdRequestAction(RequestAction requestAction, string userName);

        void DeleteRequestAction(RequestAction requestAction, string userName);

        RequestAction GetRequestActionById(int Id);

        List<RequestAction> GetAllRequestAction();

        List<LookupsModel> getExternalEntity();
    }
}
