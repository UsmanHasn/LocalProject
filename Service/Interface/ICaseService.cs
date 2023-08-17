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
        bool AddCase(CaseModel caseModel, string userName);
        bool AddCaseParties(CaseParties caseParties, string userName);
    }
}