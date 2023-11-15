using Azure.Identity;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface ICaseService
    {
        long AddCase(CaseModel caseModel, string userName);
        CasePartiesResponse AddCaseParties(CaseParties caseParties, string userName);
        CaseModel GetCaseById(long caseId);
        List<CaseModel> GetAllCases(string CivilNo);
        List<CaseParties> GetCaseParties(long caseId, long partyNo);
        List<CaseDocumentsModel> GeCaseDocumentsByCaseId(long CaseId);
        bool AddCaseDocuments(CaseDocumentModel caseDocumentModel, string userName);
        bool DeleteCaseDocument(CaseDocumentModel caseDocumentModel, string userName);
        UpdateStatusResponse UpdateCaseStatus(long caseId, string caseStatus, string userName);
        List<CaseModel> GetAllCases();
        paginationRequestModel GetAllPendingCase(string CivilNo, int CaseStatusId, int pageSize, int pageNumber, string? SearchText);
        public List<PaymentActionModel> BindPaymentDraw();
        public bool UpdateCase(long caseId, string caseStatusId, int fee, int paymentDrawId, int exempted, string userName);
        CaseModel GetCasesByUserName(string CreatedBy);
        CaseModel GetCasesByCaseId(string CaseId);
        bool AddCaseTypeLookup(CaseTypesLookupModel caseTypesLookupModel, string userName);
        bool UpdateCaseTypeLookup(CaseTypesLookupModel caseTypesLookupModel, string userName);
        public List<CaseTypesLookupModel> GetAllCaseTypeLookup();
        public CaseTypesLookupModel GetCaseTypeLookupById(int CaseTypeId);
        public List<CourtTypeLookupModel> GetAllCourtTypeLookup();
        public CaseModel GetCaseDetail(int CaseId);
        public List<CaseParties> GetCasePartiesDetail(int CaseId);
        List<CaseBasicModel> GetCasesByStatusName(string UserName, string CaseStatusName);
        bool DeleteCaseParties(CasePartiesDelete deleteCaseParties);
        List<CaseGroupModel> GetCaseGroup();
        List<CaseGroupCountValues> GetCaseGroupCountValues();
        List<GovernoratesModel> GetGovernoratesByCaseGroupId(int caseGroupId);
        List<LocationModel> GetLocationByGovernorateId(int governorateId, bool isActive);
        List<treeViewGrpGovernLocModel> GetGroupGovernorateLcoations();
        List<CaseCategoryGroupModel> GetCategoryByLocationId(int locationId);
        List<CaseCategoryGroupModel> GetCategoryByGroupId(int caseGroupId, bool isActive);
        List<CaseCategoryTypesModel> GetTypeByCategoryId(int categoryId);
        string InsUpDel_CaseGroup(CaseGroupModel caseGroupModel, string dmlType);
        string InsUpDel_LktGovernorate(LKTGovernorateModel lktGovernorateModel, string dmlType);
        string InsUpDel_LktLocation(LKTLocationModel lktGovernorateModel, string dmlType);
        void InsUpDel_LktGroupGovernorate(LKT_GroupGovernoratesModel lKT_GroupGovernoratesModel);
        List<LKTGovernorateModel> getUnassignedGovernorates(int caseGroupId, bool isActive);
        List<LKTGovernorateModel> getAssignedGovernorates(int caseGroupId);
        string InsUpDel_CaseCategory(CaseGroupCategoryModel caseGroupCategoryModel, string dmlType);
        List<LKTPartyCategory> getPartyCategory();
        bool DeleteCase(int CaseId);
        List<CaseCategoryTypesModel> GetCaseCategoryTypes();
        string InsUpDel_CaseType(CaseCategoryTypesModel caseGroupCategoryModel, string dmlType);
        List<LKTPartyType> GetPartyTypes(int caseGroupId, int partyCategoryId);
        List<CaseCategoryTypesModel> GetUnassignedCaseTypes(int caseGroupId, int caseCategoryId, bool isActive);
        List<CaseCategoryTypesModel> GetAssignedCaseTypes(int caseGroupId, int caseCategoryId);

        string InsertLKT_Subject(LKT_SubjectModel lKT_SubjectModel, string dmlType);
        List<LKT_SubjectModel> GetAll();

        string InsUpdCaseCategoryDetails(CaseCategoryDetails caseCategoryDetails, string userName);

        List<CaseCategoryDetails> GetAllCaseCategoryDetails();
        CaseCategoryDetails GetCaseCategoryDetailsbyId(int CaseCatDtlId);

        string DeleteCaseCategoryDetails(CaseCategoryDetails caseCategoryDetails, string userName);





        List<CORCaseSubjectModel> GetUnAssignedSubjects(int CaseGrpCatTypeId, bool isActive);

        List<CORCaseSubjectModel> GetAssignedSubjects(int CaseGrpCatTypeId);

        void InsUpDel_CorCaseSubject(CORCaseSubject cORCaseSubject);
        void InsUpDel_CORGrpCatType(COR_GroupCatTypeModel cor_GroupCatTypeModel);
        bool InsUpDel_CorAdvanceLinkingConfig(COR_AdvanceLinkingConfigModel cOR_AdvanceLinkingConfigModel);
        List<COR_AdvanceLinkingConfigModel> GetCOR_AdvanceLinkingConfig();
        public COR_AdvanceLinkingConfigModel GetCOR_AdvanceLinkingConfigById(int LinkId);
        List<LKTLocationModel> getLocationsByCaseGroupId(int caseGroupId);

        paginationRequestModel GetAllRequest(int? caseId, int? pageSize, int? pageNumber, string? SearchText);
        List<RequestEvenLog> GetAllRequestEventLog(int requestId, bool userFlag);
        RequestModel sjc_GetRequest_caseId(int? caseId);
        bool InsertRequestEventLog(RequestEvenLog evenLog);
    }
}
