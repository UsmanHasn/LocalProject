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
        List<CaseParties> GetCaseParties(long caseId);
        List<CaseDocumentsModel> GeCaseDocumentsByCaseId(long CaseId);
        bool AddCaseDocuments(CaseDocumentModel caseDocumentModel, string userName);
        UpdateStatusResponse UpdateCaseStatus(long caseId, string caseStatus, string userName);
        List<CaseModel> GetAllCases();

        List<CaseModel> GetCasesByUserName(string CreatedBy);
    }
}