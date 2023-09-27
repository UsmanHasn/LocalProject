using Domain.Entities;
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
        bool AddRequestAccount(RequestAccountsModel requestAccountsModel, string userName,string folderName,int count);
        public LinkCompanyModel GetCivilNo(string CivilNo);
        List<RequestAccountsModel> GetAll(int userId);
        List<RequestAccountsModel> GetAllForAdmin(string ActionTypeId, string CivilNo, string UserName);

        bool UpdateRequestAccountHistory(int requestId, int responseStatusId, string rejectedReason);

        public SystemSettings GetRequestStatusIdFromSystemSetting(string keyName); 
    }
}
