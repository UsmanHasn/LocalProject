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
    }
}