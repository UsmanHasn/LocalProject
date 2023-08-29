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
    }
}