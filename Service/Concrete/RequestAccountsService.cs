using Data.Interface;
using Domain.Entities;
using Domain.Helper;
using Domain.Modeles;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Hosting;
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
        public bool AddRequestAccount(RequestAccountsModel requestAccountsModel, string userName, string folderName)
        {
            SqlParameter[] spParams = new SqlParameter[11];
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

            _systemSettingRepository.ExecuteStoredProcedure("Sp_dml_requestAccounts", spParams);
            return true;
        }

        public List<DocumentTypeLookupModel> BindDocumentType()
        {
            SqlParameter[] spParams = new SqlParameter[0];
            var model = _systemSettingRepository.ExecuteStoredProcedure<DocumentTypeLookupModel>("sjc_DocumentTypeLookup", spParams).ToList();
            return model;
        }


    }
}