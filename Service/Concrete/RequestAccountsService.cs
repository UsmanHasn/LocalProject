using Data.Interface;
using Domain.Entities;
using Domain.Helper;
using Domain.Modeles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Asn1.Ocsp;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class RequestAccountsService : IRequestAccountService
    {
        private readonly IRepository<SystemSettings> _systemSettingRepository;
        private readonly IWebHostEnvironment environment;

        public RequestAccountsService(IWebHostEnvironment repository, IRepository<SystemSettings> systemSettingRepository)
        {
            environment = repository;
            _systemSettingRepository = systemSettingRepository;
        }

        public bool AddLinkCompany(LinkCompanyModel linkCompanyModel, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[6];
            spParams[0] = new SqlParameter("Id", linkCompanyModel.Id);
            spParams[1] = new SqlParameter("CivilNo", linkCompanyModel.CivilNo);
            spParams[2] = new SqlParameter("CRNo", linkCompanyModel.CRNo);
            spParams[3] = new SqlParameter("IsActive", linkCompanyModel.IsActive);
            spParams[4] = new SqlParameter("CreatedBy", userName);
            spParams[5] = new SqlParameter("LastModifiedBy", userName);
            _systemSettingRepository.ExecuteStoredProcedure("Sp_dml_linktocompany", spParams);
            return true;
        }

        public bool AddRequestAccount(RequestAccountsModel requestAccountsModel, string userName, string folderName, int count)
        {
            SqlParameter[] spParams = new SqlParameter[14];
            spParams[0] = new SqlParameter("RequestId", requestAccountsModel.RequestId);
            spParams[1] = new SqlParameter("ActionTypeId", requestAccountsModel.ActionTypeId);
            spParams[2] = new SqlParameter("Role", requestAccountsModel.Role);
            spParams[3] = new SqlParameter("EntityId", requestAccountsModel.EntityId);
            spParams[4] = new SqlParameter("Comments", requestAccountsModel.Comments);
            spParams[5] = new SqlParameter("RequestStatusId", requestAccountsModel.RequestStatusId);
            spParams[6] = new SqlParameter("CreatedBy", userName);
            spParams[7] = new SqlParameter("LastModifiedBy", userName);
            spParams[8] = new SqlParameter("DocumentTypeId", requestAccountsModel.DocumentTypeId);
            spParams[9] = new SqlParameter("DocPath", folderName);
            spParams[10] = new SqlParameter("FileName", requestAccountsModel.FileName);
            spParams[11] = new SqlParameter("Type", requestAccountsModel.Type);
            spParams[12] = new SqlParameter("UserId", requestAccountsModel.UserId);
            spParams[13] = new SqlParameter("Count", count);

            _systemSettingRepository.ExecuteStoredProcedure("Sp_dml_requestAccounts", spParams);
            return true;
        }

        public List<DocumentTypeLookupModel> BindDocumentType()
        {
            SqlParameter[] spParams = new SqlParameter[0];
            var model = _systemSettingRepository.ExecuteStoredProcedure<DocumentTypeLookupModel>("sjc_DocumentTypeLookup", spParams).ToList();
            return model;
        }

        public List<RequestAccountsModel> GetAll(int userId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("UserId", userId);
            return _systemSettingRepository.ExecuteStoredProcedure<RequestAccountsModel>("sjc_GetRequestAccount", spParams).ToList();
        }

        public List<RequestAccountsModel> GetAllForAdmin(string ActionTypeId, string CivilNo, string UserName)
        {
            SqlParameter[] spParams = new SqlParameter[3];
            spParams[0] = new SqlParameter("ActionTypeId", string.IsNullOrEmpty(ActionTypeId) ? "" : ActionTypeId);
            spParams[1] = new SqlParameter("CivilNo", string.IsNullOrEmpty(CivilNo) ? "" : CivilNo);
            spParams[2] = new SqlParameter("UserName", string.IsNullOrEmpty(UserName) ? "" : UserName);
            return _systemSettingRepository.ExecuteStoredProcedure<RequestAccountsModel>("sjc_GetRequestAccountForAdmin", spParams).ToList();
        }

        public LinkCompanyModel GetCivilNo(string CivilNo)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("CivilNo", CivilNo);
            return _systemSettingRepository.ExecuteStoredProcedure<LinkCompanyModel>("sjc_GetCivilNo", spParams).FirstOrDefault();
        }

        public SystemSettings GetRequestStatusIdFromSystemSetting(string keyName)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("KeyName", keyName);
            return _systemSettingRepository.ExecuteStoredProcedure<SystemSettings>("sjc_GetKeyValueByKeyName", spParams).FirstOrDefault();
        }

        public bool UpdateRequestAccountHistory(int requestId,int responseStatusId,string rejectedReason)
        {
            SqlParameter[] spParams = new SqlParameter[5];
            spParams[0] = new SqlParameter("RequestId", requestId);
            spParams[1] = new SqlParameter("RequestStatusId", responseStatusId);
            spParams[2] = new SqlParameter("AssignedTo", 1);
            spParams[3] = new SqlParameter("ResponseStatusId", responseStatusId);
            spParams[4] = new SqlParameter("RejectedReason", rejectedReason);

            _systemSettingRepository.ExecuteStoredProcedure("Sp_RequestAccountsHistory", spParams);
            return true;
        }
    }
}