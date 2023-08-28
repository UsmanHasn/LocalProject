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
            SqlParameter[] spParams = new SqlParameter[16];
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
            spParams[12] = new SqlParameter("DML", caseModel.CaseId > 0 ? "U" : "I");
            spParams[13] = new SqlParameter("CaseStatusId", caseModel.CaseStatusId);
            spParams[14] = new SqlParameter("OriginalCaseNo", caseModel.OriginalCaseNo);
            spParams[15] = new SqlParameter("CaseSource", caseModel.CaseSource);
            var data = _systemSettingRepository.ExecuteStoredProcedure<CaseModel>("Sp_dml_cases", spParams).FirstOrDefault();
            return data.CaseId;
        }

        public bool AddCaseParties(CaseParties caseParties, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[19];
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
            spParams[10] = new SqlParameter("DML", caseParties.CasePartyId > 0 ? "U" : "I");
            spParams[11] = new SqlParameter("PartyNo", caseParties.PartyNo);
            spParams[12] = new SqlParameter("CivilExpiry", caseParties.CivilExpiry);
            spParams[13] = new SqlParameter("LegalType", caseParties.LegalType);
            spParams[14] = new SqlParameter("EntityId", caseParties.EntityId);
            spParams[15] = new SqlParameter("FamilyName", caseParties.FamilyName);
            spParams[16] = new SqlParameter("Email", caseParties.Email);
            spParams[17] = new SqlParameter("Country", caseParties.Country);
            spParams[18] = new SqlParameter("City", caseParties.City);

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
        public List<CaseParties> GetCaseParties(long caseId, long PartyNo)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("CaseId", caseId);
            parameters[1] = new SqlParameter("PartyNo", PartyNo);
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

        public List<CaseDocumentsModel> GeCaseDocumentsByCaseId(long CaseId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("CaseId", CaseId);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseDocumentsModel>("sjc_GetByCaseDocumenByCaseId", parameters).ToList();
        }
        public UpdateStatusResponse UpdateCaseStatus(long caseId, string caseStatus, string userName)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("CaseId", caseId);
            parameters[1] = new SqlParameter("CaseStatus", caseStatus);
            parameters[2] = new SqlParameter("UserName", userName);
            return _systemSettingRepository.ExecuteStoredProcedure<UpdateStatusResponse>("sjc_UpdateCasestatus", parameters).FirstOrDefault();
        }

        public List<CaseModel> GetAllCases()
        {
            SqlParameter[] param = new SqlParameter[0];


            var dataMenu = _systemSettingRepository.ExecuteStoredProcedure<CaseModel>("sjc_GetAllCases", param);
            return dataMenu.ToList();
        }

        public List<CaseModel> GetAllPendingCase(string CivilNo,int CaseStatusId)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("CivilNo", CivilNo);
            parameters[1] = new SqlParameter("CasaStatusId", CaseStatusId);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseModel>("sjc_GetPendingCase", parameters).ToList();
        }

        public List<LookupsModel> BindPaymentDraw()
        {
            SqlParameter[] param = new SqlParameter[0];
            var dataMenu = _systemSettingRepository.ExecuteStoredProcedure<LookupsModel>("sjc_GetPaymentDraw", param);
            return dataMenu.ToList();
        }

        public bool UpdateCase(long caseId, string caseStatusId, int fee, int paymentDrawId, int exempted, string userName)
        {
            SqlParameter[] parameters = new SqlParameter[6];
            parameters[0] = new SqlParameter("CaseId", caseId);
            parameters[1] = new SqlParameter("CaseStatusId", caseStatusId);
            parameters[2] = new SqlParameter("Fee", fee);
            parameters[3] = new SqlParameter("PaymentDrawId", paymentDrawId);
            parameters[4] = new SqlParameter("Exempted", exempted);
            parameters[5] = new SqlParameter("UserName", userName);
            _systemSettingRepository.ExecuteStoredProcedure("sjc_UpdateCase", parameters);
            return true;
        }
    }
}
