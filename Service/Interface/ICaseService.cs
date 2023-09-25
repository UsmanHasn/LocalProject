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
        bool AddCaseParties(CaseParties caseParties, string userName);
        CaseModel GetCaseById(long caseId);
        List<CaseModel> GetAllCases(string CivilNo);
        List<CaseParties> GetCaseParties(long caseId, long partyNo);
        List<CaseDocumentsModel> GeCaseDocumentsByCaseId(long CaseId);
        bool AddCaseDocuments(CaseDocumentModel caseDocumentModel, string userName);
        UpdateStatusResponse UpdateCaseStatus(long caseId, string caseStatus, string userName);
        List<CaseModel> GetAllCases();
        List<CaseModel> GetAllPendingCase(string CivilNo, int CaseStatusId);
        public List<LookupsModel> BindPaymentDraw();
        public bool UpdateCase(long caseId, string caseStatusId, int fee, int paymentDrawId, int exempted, string userName);
        CaseModel GetCasesByUserName(string CreatedBy);
        CaseModel GetCasesByCaseId(string CaseId);

        bool AddCaseTypeLookup(CaseTypesLookupModel caseTypesLookupModel, string userName);
        bool UpdateCaseTypeLookup(CaseTypesLookupModel caseTypesLookupModel, string userName);
        public List<CaseTypesLookupModel>  GetAllCaseTypeLookup();

        public CaseTypesLookupModel GetCaseTypeLookupById(int CaseTypeId);
        public List<CourtTypeLookupModel> GetAllCourtTypeLookup();

        public CaseModel GetCaseDetail(int CaseId);
        public List<CaseParties> GetCasePartiesDetail(int CaseId);
        List<CaseBasicModel> GetCasesByStatusName(string UserName, string CaseStatusName);

        bool DeleteCaseParties(CasePartiesDelete deleteCaseParties);
        List<CaseGroupModel> GetCaseGroup();
        CaseGroupCountValues GetCaseGroupCountValues();
        List<GovernoratesModel> GetGovernoratesByCaseGroupId(int caseGroupId);
        List<LocationModel> GetLocationByGovernorateId(int governorateId);
        List<treeViewGrpGovernLocModel> GetGroupGovernorateLcoations();
        List<CaseCategoryGroupModel> GetCategoryByLocationId(int locationId);
        List<CaseCategoryGroupModel> GetCategoryByGroupId(int caseGroupId);
        List<CaseCategoryTypesModel> GetTypeByCategoryId(int categoryId);
        string InsUpDel_CaseGroup(CaseGroupModel caseGroupModel, string dmlType);
        string InsUpDel_LktGovernorate(LKTGovernorateModel lktGovernorateModel, string dmlType);
        string InsUpDel_LktLocation(LKTLocationModel lktGovernorateModel, string dmlType);
        void InsUpDel_LktGroupGovernorate(LKT_GroupGovernoratesModel lKT_GroupGovernoratesModel);
        List<LKTGovernorateModel> getUnassignedGovernorates(int caseGroupId);
        List<LKTGovernorateModel> getAssignedGovernorates(int caseGroupId);
        string InsUpDel_CaseCategory(CaseGroupCategoryModel caseGroupCategoryModel, string dmlType);
        List<LKTPartyCategory> getPartyCategory();
        bool DeleteCase(int CaseId);
        List<CaseCategoryTypesModel> GetCaseCategoryTypes();
        string InsUpDel_CaseType(CaseCategoryTypesModel caseGroupCategoryModel, string dmlType);
        List<LKTPartyType> GetPartyTypes(int caseGroupId, int partyCategoryId);
        List<CaseCategoryTypesModel> GetUnassignedCaseTypes(int caseGroupId, int caseCategoryId);
        List<CaseCategoryTypesModel> GetAssignedCaseTypes(int caseGroupId, int caseCategoryId);
    }
}