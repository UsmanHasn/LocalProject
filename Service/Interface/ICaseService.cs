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
    }
}