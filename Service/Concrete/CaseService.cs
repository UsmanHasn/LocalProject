using Data.Interface;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Concrete
{
    public class CaseService : ICaseService
    {

        private readonly IRepository<SystemSettings> _systemSettingRepository;
        
        public CaseService(IRepository<SystemSettings> systemSettingRepository)

        {
            _systemSettingRepository = systemSettingRepository;
        }
        public long AddCase(CaseModel caseModel,string userName)
        {
            SqlParameter[] spParams = new SqlParameter[13];
            spParams[0] = new SqlParameter("CaseId", caseModel.CaseId);
            spParams[1] = new SqlParameter("CaseNo", caseModel.CaseNo);
            spParams[2] = new SqlParameter("CourtTypeId", caseModel.CourtTypeId);
            spParams[3] = new SqlParameter("CourtBuildingId", caseModel.CourtBuildingId);
            spParams[4] = new SqlParameter("CaseTypeId", caseModel.CaseTypeId);
            spParams[5] = new SqlParameter("CaseCategoryId", caseModel.CaseCategoryId);
            spParams[6] = new SqlParameter("CaseSubCategoryId", caseModel.CaseSubCategoryId);
            spParams[7] = new SqlParameter("FiledOn", caseModel.FiledOn);
            spParams[8] = new SqlParameter("Subject", caseModel.Subject);
            spParams[9] = new SqlParameter("CreatedBy", userName);
            spParams[10] = new SqlParameter("LastModifiedBy", userName);
            spParams[11] = new SqlParameter("Deleted", false);
            spParams[12] = new SqlParameter("DML", "I");
            return _systemSettingRepository.ExecuteStoredProcedure<long>("Sp_dml_cases", spParams).First();
        }

        public bool AddCaseParties(CaseParties caseParties, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[11];
            spParams[0] = new SqlParameter("CasePartyId", caseParties.CasePartyId);
            spParams[1] = new SqlParameter("CaseId", caseParties.CaseId);
            spParams[2] = new SqlParameter("PartyType", caseParties.PartyType);
            spParams[3] = new SqlParameter("PartyCategoryId", caseParties.PartyCategoryId);
            spParams[4] = new SqlParameter("PartyTypeId", caseParties.PartyTypeId);
            spParams[5] = new SqlParameter("CivilNo", caseParties.CivilNo);
            spParams[6] = new SqlParameter("CRNo", caseParties.CRNo);
            spParams[7] = new SqlParameter("Name", caseParties.Name);
            spParams[8] = new SqlParameter("PhoneNo", caseParties.PhoneNo);
            spParams[9] = new SqlParameter("Address", caseParties.Address);
            spParams[10] = new SqlParameter("DML", "I");
            _systemSettingRepository.ExecuteStoredProcedure("Sp_dml_caseparties", spParams);
            return true;
        }
        public List<CaseModel> GetAllCases(string CivilNo)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("CivilNo", CivilNo);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseModel>("sjc_GetCaseByCivilNo", parameters).ToList();
        }
        public CaseModel GetCaseById(long caseId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("CaseId", caseId);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseModel>("sjc_GetCaseByCaseId", parameters).FirstOrDefault();
        }
        public List<CaseParties> GetCaseParties(long caseId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("CaseId", caseId);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseParties>("sjc_GetPartiesByCaseId", parameters).ToList();
        }
        public bool AddCaseDocuments(CaseDocumentModel caseDocumentModel, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("CaseDocumentId", caseDocumentModel.DocumentId);
            spParams[1] = new SqlParameter("CaseId", caseDocumentModel.CaseId);
            spParams[2] = new SqlParameter("DocumentType", caseDocumentModel.DocumentType);
            spParams[3] = new SqlParameter("DocumentPath", caseDocumentModel.DocumentPath);
            spParams[4] = new SqlParameter("Description", caseDocumentModel.Description);
            spParams[5] = new SqlParameter("DML", "I");
            spParams[6] = new SqlParameter("UploadedBy", userName);
            _systemSettingRepository.ExecuteStoredProcedure("Sp_dml_casedocument", spParams);
            return true;
        }
    }
}
