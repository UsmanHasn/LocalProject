using Microsoft.AspNetCore.Http;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IRequestAccountService
    {
        List<DocumentTypeLookupModel> BindDocumentType();
        bool AddLinkCompany(LinkCompanyModel linkCompanyModel, string userName);
        bool AddRequestAccount(RequestAccountsModel requestAccountsModel, string userName,string folderName);
        public LinkCompanyModel GetCivilNo(string CivilNo);
        List<RequestAccountsModel> GetAll();
    }
}
