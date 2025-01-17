﻿using Data.Concrete;
using Data.Interface;
using Domain.Entities;
using Domain.Modeles;
using MailKit.Search;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Printing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Azure.Core.HttpHeader;

namespace Service.Concrete
{
    public class CaseService : ICaseService
    {

        private readonly IRepository<SYS_SystemSettings> _systemSettingRepository;

        public readonly IRepository<SMS_Trans> _smsRepository;

        public CaseService(IRepository<SYS_SystemSettings> systemSettingRepository, IRepository<SMS_Trans> smsRepository)

        {
            _systemSettingRepository = systemSettingRepository;

            _smsRepository = smsRepository;
        }
        public long AddCase(CaseModel caseModel, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[25];
            spParams[0] = new SqlParameter("CaseId", caseModel.CaseId);
            spParams[1] = new SqlParameter("CaseNo", caseModel.CaseNo);
            spParams[2] = new SqlParameter("CaseGroupId", caseModel.CaseGroupId);
            spParams[3] = new SqlParameter("GovernateId", caseModel.GovernateId);
            spParams[4] = new SqlParameter("CaseTypeId", caseModel.CaseTypeId);
            spParams[5] = new SqlParameter("CaseCategoryId", caseModel.CaseCategoryId);
            spParams[6] = new SqlParameter("CaseSubCategoryId", caseModel.CaseSubCategoryId);
            spParams[7] = new SqlParameter("FiledOn", caseModel.FiledOn);
            spParams[8] = new SqlParameter("Subject", caseModel.Subject);
            spParams[9] = new SqlParameter("CreatedBy", caseModel.UserId);
            spParams[10] = new SqlParameter("LastModifiedBy", caseModel.UserId);
            spParams[11] = new SqlParameter("Deleted", false);
            spParams[12] = new SqlParameter("DML", caseModel.CaseId > 0 ? "U" : "I");
            spParams[13] = new SqlParameter("CaseStatusId", caseModel.CaseStatusId);
            spParams[14] = new SqlParameter("OriginalCaseNo", caseModel.OriginalCaseNo);
            spParams[15] = new SqlParameter("CaseSource", caseModel.CaseSource);
            spParams[16] = new SqlParameter("LocationId", caseModel.LocationId);
            spParams[17] = new SqlParameter("AdditionalSubjectIds", caseModel.AdditionalSubjectIds);
            spParams[18] = new SqlParameter("CourtTypeId", caseModel.CourtTypeId);
            spParams[19] = new SqlParameter("CourtBuildingId", caseModel.CourtBuildingId);
            spParams[20] = new SqlParameter("LinkSourceId", caseModel.LinkSourceId);
            spParams[21] = new SqlParameter("ExternalEntityId", caseModel.ExternalEntityId);
            spParams[22] = new SqlParameter("RequestByType", caseModel.RequestByType);
            spParams[23] = new SqlParameter("CrNo", caseModel.CrNo);
            spParams[24] = new SqlParameter("EntityId", caseModel.EntityId);
            var data = _systemSettingRepository.ExecuteStoredProcedure<CaseModel>("Sp_dml_cases", spParams).FirstOrDefault();
            return data.CaseId;
        }

        public CasePartiesResponse AddCaseParties(CaseParties caseParties, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[38];
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
            spParams[13] = new SqlParameter("LegalType", caseParties.PartyType == "P" ? null : caseParties.LegalType);
            spParams[14] = new SqlParameter("EntityId", caseParties.EntityId);
            spParams[15] = new SqlParameter("FamilyName", caseParties.FamilyName);
            spParams[16] = new SqlParameter("Email", caseParties.Email);
            spParams[17] = new SqlParameter("Country", caseParties.Country);
            spParams[18] = new SqlParameter("FirstName", caseParties.FirstName);
            spParams[19] = new SqlParameter("LastName", caseParties.LastName);
            spParams[20] = new SqlParameter("MiddleName", caseParties.MiddleName);
            spParams[21] = new SqlParameter("FourthName", caseParties.FourthName);
            spParams[22] = new SqlParameter("CountryId", caseParties.CountryId);
            spParams[23] = new SqlParameter("GovernorateId", caseParties.GovernorateId);
            spParams[24] = new SqlParameter("WialayId", caseParties.WilayaId);
            spParams[25] = new SqlParameter("VillageId", caseParties.VillageId);
            spParams[26] = new SqlParameter("AddressTypeId", caseParties.AddressTypeId);
            spParams[27] = new SqlParameter("WayNo", caseParties.WayNo);
            spParams[28] = new SqlParameter("AddressLine1", caseParties.AddressLine1);
            spParams[29] = new SqlParameter("AddressLine2", caseParties.AddressLine2);
            spParams[30] = new SqlParameter("CompanyName", caseParties.CompanyName);
            spParams[31] = new SqlParameter("LinkCaseParty", caseParties.LinkCaseParty);
            spParams[32] = new SqlParameter("AddressNo", caseParties.AddressNo);
            spParams[33] = new SqlParameter("BuildingNo", caseParties.BuildingNo);
            spParams[34] = new SqlParameter("SearchBy", caseParties.SearchBy);
            spParams[35] = new SqlParameter("PassportNo", caseParties.PassportNo);
            spParams[36] = new SqlParameter("PassportExpiry", caseParties.PassportExpiryDate);
            spParams[37] = new SqlParameter("PassportCountryCode", caseParties.PassportCountryCode);
            CasePartiesResponse response = _systemSettingRepository.ExecuteStoredProcedure<CasePartiesResponse>("Sp_dml_caseparties", spParams).FirstOrDefault();
            return response;
        }
        public List<CaseModel> GetAllCases(string CivilNo)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("CivilNo", CivilNo);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseModel>("sjc_GetCaseByCivilNo", parameters).ToList();
        }
        public paginationRequestModel GetAllRequest(int? caseId, int? pageSize, int? pageNumber, string? SearchText)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[4];

                param[0] = new SqlParameter("pageSize", pageSize);
                param[1] = new SqlParameter("pageNumber", pageNumber);
                param[2] = new SqlParameter("SearchText", SearchText);
                if (caseId == 0)
                {
                    param[3] = new SqlParameter("caseId", null);
                }
                else
                {
                    param[3] = new SqlParameter("caseId", caseId);
                }
                var data = _systemSettingRepository.ExecuteStoredProcedure<RequestModel>("sjc_GetRequest", param).ToList();
                int countItem = 0;
                if (SearchText != null)
                {
                    SqlParameter[] paramSearch = new SqlParameter[1];
                    paramSearch[0] = new SqlParameter("SearchText", SearchText);

                    var count = _systemSettingRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetRequestCount", paramSearch).FirstOrDefault();
                    countItem = count.TotalCount;
                }
                else
                {
                    var count = _systemSettingRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetRequestCount").FirstOrDefault();
                    countItem = count.TotalCount;
                }
                paginationRequestModel model = new paginationRequestModel()
                {
                    PaginatedData = data,
                    TotalCount = countItem
                };
                return model;

            }
            catch (Exception ex) { }
            return null;
        }
        public CaseModel GetCaseById(long caseId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("CaseId", caseId);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseModel>("sjc_GetCaseByCaseId", parameters).FirstOrDefault();
        }
        public List<CaseParties> GetCaseParties(long caseId, long PartyNo)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("CaseId", caseId);
                parameters[1] = new SqlParameter("PartyNo", PartyNo);
                return _systemSettingRepository.ExecuteStoredProcedure<CaseParties>("sjc_GetPartiesByCaseId", parameters).ToList();
            }
            catch (Exception ex)
            {
                Console.Write(ex);
                return null;
            }

        }
        public bool AddCaseDocuments(CaseDocumentModel caseDocumentModel, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("CaseDocumentId", caseDocumentModel.DocumentId);
            spParams[1] = new SqlParameter("CaseId", caseDocumentModel.CaseId);
            spParams[2] = new SqlParameter("DocumentType", caseDocumentModel.DocumentType);
            spParams[3] = new SqlParameter("DocumentPath", caseDocumentModel.DocumentPath);
            spParams[4] = new SqlParameter("Description", caseDocumentModel.Description);
            spParams[5] = new SqlParameter("DML", caseDocumentModel.DocumentId == 0 ? "I" : "U");
            spParams[6] = new SqlParameter("UploadedBy", userName);
            _systemSettingRepository.ExecuteStoredProcedure("Sp_dml_casedocument", spParams);
            return true;
        }
        public bool DeleteCaseDocument(CaseDocumentModel caseDocumentModel, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("CaseDocumentId", caseDocumentModel.DocumentId);
            spParams[1] = new SqlParameter("CaseId", caseDocumentModel.CaseId);
            spParams[2] = new SqlParameter("DocumentType", caseDocumentModel.DocumentType);
            spParams[3] = new SqlParameter("DocumentPath", caseDocumentModel.DocumentPath);
            spParams[4] = new SqlParameter("Description", caseDocumentModel.Description);
            spParams[5] = new SqlParameter("DML", "D");
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

        public paginationRequestModel GetAllPendingCase(string CivilNo, int CaseStatusId,int pageSize,int pageNumber,string ? SearchText)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("pageSize", pageSize);
                param[1] = new SqlParameter("pageNumber", pageNumber);
                param[2] = new SqlParameter("SearchText", SearchText);
                param[3] = new SqlParameter("CivilNo", CivilNo);
                if (CaseStatusId == 0)
                { param[4] = new SqlParameter("CasaStatusId", null); }
                else { param[4] = new SqlParameter("CasaStatusId", CaseStatusId); }
                
                var data = _systemSettingRepository.ExecuteStoredProcedure<RequestModel>("sjc_GetPendingCase", param).ToList();
                int countItem = 0;
                if (SearchText != null)
                {
                    SqlParameter[] paramSearch = new SqlParameter[2];
                    paramSearch[0] = new SqlParameter("SearchText", SearchText);
                    paramSearch[1] = new SqlParameter("CasaStatusId", null);
                    var count = _systemSettingRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetPendingRequestCount", paramSearch).FirstOrDefault();
                    countItem = count.TotalCount;
                }
                else
                {
                    SqlParameter[] paramSearch = new SqlParameter[2];
                    paramSearch[0] = new SqlParameter("SearchText", null);
                    paramSearch[1] = new SqlParameter("CasaStatusId", null);
                    var count = _systemSettingRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetPendingRequestCount", paramSearch).FirstOrDefault();
                    countItem = count.TotalCount;
                }
                paginationRequestModel model = new paginationRequestModel()
                {
                    PaginatedData = data,
                    TotalCount = countItem
                };
                return model;

            }
            catch (Exception ex) { }
            return null;
        }

        public List<PaymentActionModel> BindPaymentDraw()
        {
            SqlParameter[] param = new SqlParameter[0];
            var dataMenu = _systemSettingRepository.ExecuteStoredProcedure<PaymentActionModel>("sjc_GetPaymentDraw", param);
            return dataMenu.ToList();
        }

        public bool UpdateCase(long caseId, string caseStatusId, Decimal fee, int paymentDrawId, int exempted, string userName, string Comment)
        {
            SqlParameter[] parameters = new SqlParameter[7];
            parameters[0] = new SqlParameter("CaseId", caseId);
            parameters[1] = new SqlParameter("CaseStatusId", caseStatusId);
            parameters[2] = new SqlParameter("Fee", fee);
            parameters[3] = new SqlParameter("PaymentDrawId", paymentDrawId);
            parameters[4] = new SqlParameter("Exempted", exempted);
            parameters[5] = new SqlParameter("UserName", userName);
            parameters[6] = new SqlParameter("Comment", Comment);
            
            _systemSettingRepository.ExecuteStoredProcedure("sjc_UpdateCase", parameters);
            return true;
        }
        public CaseModel GetCasesByUserName(string CreatedBy)

        {

            SqlParameter[] parameters = new SqlParameter[1];

            parameters[0] = new SqlParameter("UserName", CreatedBy);

            return _systemSettingRepository.ExecuteStoredProcedure<CaseModel>("sjc_GetCasesByUserName", parameters).FirstOrDefault();

        }
        public CaseModel GetCasesByCaseId(string CaseId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("CaseId", CaseId);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseModel>("sjc_GetCasesByCaseId", parameters).FirstOrDefault();
        }

        public bool AddCaseTypeLookup(CaseTypesLookupModel caseTypesLookupModel, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("Code", caseTypesLookupModel.Code);
            spParams[1] = new SqlParameter("NameEn", caseTypesLookupModel.NameEn);
            spParams[2] = new SqlParameter("NameAr", caseTypesLookupModel.NameAr);
            spParams[3] = new SqlParameter("CourtTypeId", caseTypesLookupModel.CourtTypeId);
            spParams[4] = new SqlParameter("IsActive", caseTypesLookupModel.IsActive);
            spParams[5] = new SqlParameter("CreatedBy", userName);
            spParams[6] = new SqlParameter("CaseGroupId", caseTypesLookupModel.CaseGroupId);
            _systemSettingRepository.ExecuteStoredProcedure("sjc_insert_caseTypesLookup", spParams);
            return true;
        }

        public List<CaseTypesLookupModel> GetAllCaseTypeLookup()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _systemSettingRepository.ExecuteStoredProcedure<CaseTypesLookupModel>("sjc_Get_CaseTypesLookup", parameters).ToList();
        }

        public List<CourtTypeLookupModel> GetAllCourtTypeLookup()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _systemSettingRepository.ExecuteStoredProcedure<CourtTypeLookupModel>("sjc_GetAll_CourtTypesLookup", parameters).ToList();
        }

        public CaseTypesLookupModel GetCaseTypeLookupById(int CaseTypeId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CaseTypeId", CaseTypeId);
            var data = _systemSettingRepository.ExecuteStoredProcedure<CaseTypesLookupModel>("sjc_GetAll_CaseTypesLookup", param).FirstOrDefault();
            return data;
        }

        public bool UpdateCaseTypeLookup(CaseTypesLookupModel caseTypesLookupModel, string userName)
        {
            SqlParameter[] spParams = new SqlParameter[8];
            spParams[0] = new SqlParameter("Code", caseTypesLookupModel.Code);
            spParams[1] = new SqlParameter("NameEn", caseTypesLookupModel.NameEn);
            spParams[2] = new SqlParameter("NameAr", caseTypesLookupModel.NameAr);
            spParams[3] = new SqlParameter("CourtTypeId", caseTypesLookupModel.CourtTypeId);
            spParams[4] = new SqlParameter("IsActive", caseTypesLookupModel.IsActive);
            spParams[5] = new SqlParameter("LastModifiedBy", userName);
            spParams[6] = new SqlParameter("CaseGroupId", caseTypesLookupModel.CaseGroupId);
            spParams[7] = new SqlParameter("CaseTypeId", caseTypesLookupModel.CaseTypeId);
            _systemSettingRepository.ExecuteStoredProcedure("Sjc_Update_CaseTypesLookup", spParams);
            return true;
        }
        public CaseModel GetCaseDetail(int CaseId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CaseId", CaseId);
            var data = _systemSettingRepository.ExecuteStoredProcedure<CaseModel>("sjc_GetCaseDetail", param).FirstOrDefault();
            return data;
        }
        public List<CaseParties> GetCasePartiesDetail(int CaseId)
        {
            SqlParameter[] param = new SqlParameter[1];
            param[0] = new SqlParameter("CaseId", CaseId);
            var data = _systemSettingRepository.ExecuteStoredProcedure<CaseParties>("sjc_GetCasePartiesDetail", param).ToList();
            return data;
        }
        public List<CaseBasicModel> GetCasesByStatusName(string UserName, string CaseStatusName)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("UserName", UserName);
            parameters[1] = new SqlParameter("CaseStatusName", CaseStatusName);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseBasicModel>("sjc_GetCaseByStatusAndUser", parameters).ToList();
        }
        public bool DeleteCaseParties(CasePartiesDelete deleteCaseParties)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("CasePartyId ", deleteCaseParties.CasePartyId);
            _systemSettingRepository.ExecuteStoredProcedure("Sjc_delete_CaseParties", spParams);
            return true;
        }
        public List<CaseGroupModel> GetCaseGroup()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _systemSettingRepository.ExecuteStoredProcedure<CaseGroupModel>("COR_GetCaseGroup", parameters).ToList();
        }
        public List<CaseGroupCountValues> GetCaseGroupCountValues()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _systemSettingRepository.ExecuteStoredProcedure<CaseGroupCountValues>("sp_COA_GroupCounts", parameters).ToList();
        }
        public List<GovernoratesModel> GetGovernoratesByCaseGroupId(int caseGroupId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("CaseGroupId", caseGroupId);
            return _systemSettingRepository.ExecuteStoredProcedure<GovernoratesModel>("COR_GetGovernorates", parameters).ToList();
        }
        public List<LocationModel> GetLocationByGovernorateId(int governorateId, bool isActive)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@GovernorateId", governorateId);
            parameters[1] = new SqlParameter("@isActive", isActive);
            return _systemSettingRepository.ExecuteStoredProcedure<LocationModel>("COR_GetLocations", parameters).ToList();
        }
        public List<treeViewGrpGovernLocModel> GetGroupGovernorateLcoations()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            var data = _systemSettingRepository.ExecuteStoredProcedure<GroupGovrenorateLocationModel>("COR_ListGrpGovernLocation", parameters).ToList();
            List<treeViewGrpGovernLocModel> model = new List<treeViewGrpGovernLocModel>();
            model.AddRange(data.Select(x => new { CaseGroupId = x.CaseGroupId, CaseGroupAr = x.CaseGroupAr, CaseGroupEn = x.CaseGroupEn }).Distinct()
                .Select(y => new treeViewGrpGovernLocModel()
                {
                    Title = y.CaseGroupAr,
                    TitleEn = y.CaseGroupEn,
                    Id = y.CaseGroupId,
                    Level = 1
                }));

            model.AddRange(data.Select(g => new { CaseGroupId = g.CaseGroupId, GrpGovernateId = g.GrpGovernateId, GovernoratesAr = g.GovernoratesAr, GovernoratesEn = g.GovernoratesEn }).Distinct()
                    .Select(g => new treeViewGrpGovernLocModel()
                    {
                        Title = g.GovernoratesAr,
                        TitleEn = g.GovernoratesEn,
                        Id = g.GrpGovernateId,
                        Parent = g.CaseGroupId,
                        Level = 2
                    }));

            model.AddRange(data.Select(g => new treeViewGrpGovernLocModel()
            {
                Title = g.LocationAr,
                TitleEn = g.LocationEn,
                Id = g.LocationId,
                Parent = g.GrpGovernateId,
                Level = 3
            }));

            //model = data.Select(x => new { CaseGroupId = x.CaseGroupId, CaseGroupAr = x.CaseGroupAr, CaseGroupEn = x.CaseGroupEn }).Distinct()
            //    .Select(y => new treeViewGrpGovernLocModel()
            //    {
            //        Title = y.CaseGroupAr,
            //        TitleEn = y.CaseGroupEn,
            //        Id = y.CaseGroupId,
            //        Children = data.Where(g => g.CaseGroupId == y.CaseGroupId)
            //        .Select(g => new { CaseGroupId = g.CaseGroupId, GrpGovernateId = g.GrpGovernateId, GovernoratesAr = g.GovernoratesAr, GovernoratesEn = g.GovernoratesEn }).Distinct()
            //        .Select(g => new treeViewGrpGovernLocModel()
            //        {
            //            Title = g.GovernoratesAr,
            //            TitleEn = g.GovernoratesEn,
            //            Id = g.GrpGovernateId,
            //            Parent = g.CaseGroupId,
            //            Children = data.Where(l => l.CaseGroupId == y.CaseGroupId && l.GrpGovernateId == g.GrpGovernateId)
            //            .Select(g => new treeViewGrpGovernLocModel()
            //            {
            //                Title = g.LocationAr,
            //                TitleEn = g.LocationEn,
            //                Id = g.LocationId,
            //                Parent = g.GrpGovernateId,
            //            }).ToList()
            //        }).ToList()
            //    }).ToList();
            return model;
        }
        public List<CaseCategoryGroupModel> GetCategoryByLocationId(int locationId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("LocationId", locationId);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseCategoryGroupModel>("COR_GetCaseCategoryByLocationId", parameters).ToList();
        }
        public List<CaseCategoryGroupModel> GetCategoryByGroupId(int caseGroupId, bool isActive)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("CaseGroupId", caseGroupId);
            parameters[1] = new SqlParameter("isActive", isActive);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseCategoryGroupModel>("COR_GetCaseCategoryByGroupId", parameters).ToList();
        }
        public List<CaseCategoryTypesModel> GetTypeByCategoryId(int categoryId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("CategoryId", categoryId);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseCategoryTypesModel>("COA_GetCaseTypesByCategory", parameters).ToList();
        }
        public string InsUpDel_CaseGroup(CaseGroupModel caseGroupModel, string dmlType)
        {
            SqlParameter[] parameters = new SqlParameter[9];
            parameters[0] = new SqlParameter("@CAAJ_Code", caseGroupModel.CAAJ_Code);
            parameters[1] = new SqlParameter("@ACO_Code", caseGroupModel.ACO_Code);
            parameters[2] = new SqlParameter("@NameEn", caseGroupModel.NameEn);
            parameters[3] = new SqlParameter("@NameAr", caseGroupModel.NameAr);
            parameters[4] = new SqlParameter("@IsActive", caseGroupModel.IsActive);
            parameters[5] = new SqlParameter("@CreatedBy", caseGroupModel.CreatedBy);
            parameters[6] = new SqlParameter("@CaseGroupId", caseGroupModel.CaseGroupId);
            parameters[7] = new SqlParameter("@DmlType", dmlType);
            parameters[8] = new SqlParameter("@Message", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
            _systemSettingRepository.ExecuteStoredProcedure("sp_Dml_COA_CaseGroup", parameters);
            return parameters[8].Value.ToString() ?? "";
        }
        public string InsUpDel_LktGovernorate(LKTGovernorateModel lktGovernorateModel, string dmlType)
        {
            SqlParameter[] parameters = new SqlParameter[8];
            parameters[0] = new SqlParameter("@Code", lktGovernorateModel.Code);
            parameters[1] = new SqlParameter("@NameEn", lktGovernorateModel.NameEn);
            parameters[2] = new SqlParameter("@NameAr", lktGovernorateModel.NameAr);
            parameters[3] = new SqlParameter("@IsActive", lktGovernorateModel.IsActive);
            parameters[4] = new SqlParameter("@CreatedBy", lktGovernorateModel.CreatedBy);
            parameters[5] = new SqlParameter("@GovernateId", lktGovernorateModel.GovernateId);
            parameters[6] = new SqlParameter("@DmlType", dmlType);
            parameters[7] = new SqlParameter("@Message", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
            _systemSettingRepository.ExecuteStoredProcedure("sp_Dml_LKT_Governates", parameters);
            return parameters[7].Value.ToString() ?? "";
        }
        public string InsUpDel_LktLocation(LKTLocationModel lktGovernorateModel, string dmlType)
        {
            SqlParameter[] parameters = new SqlParameter[10];
            parameters[0] = new SqlParameter("@LocationId", lktGovernorateModel.LocationId);
            parameters[1] = new SqlParameter("@Code", lktGovernorateModel.Code);
            parameters[2] = new SqlParameter("@NameEn", lktGovernorateModel.NameEn);
            parameters[3] = new SqlParameter("@NameAr", lktGovernorateModel.NameAr);
            parameters[4] = new SqlParameter("@IsActive", lktGovernorateModel.IsActive);
            parameters[5] = new SqlParameter("@CreatedBy", lktGovernorateModel.CreatedBy);
            parameters[6] = new SqlParameter("@GrpGovernateId", lktGovernorateModel.GovernateId);
            parameters[7] = new SqlParameter("@LinkLocationId", lktGovernorateModel.LinkLocationId);
            parameters[8] = new SqlParameter("@DmlType", dmlType);
            parameters[9] = new SqlParameter("@Message", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
            _systemSettingRepository.ExecuteStoredProcedure("sp_Dml_LKT_Location", parameters);
            return parameters[9].Value.ToString() ?? "";
        }
        public void InsUpDel_LktGroupGovernorate(LKT_GroupGovernoratesModel lKT_GroupGovernoratesModel)
        {
            string gIds = "";
            foreach (var governorateId in lKT_GroupGovernoratesModel.GovernorateId)
            {
                gIds = gIds + governorateId.ToString() + ",";
            }
            gIds = gIds.Substring(0, gIds.Length - 1);
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@CaseGroupId", lKT_GroupGovernoratesModel.CaseGroupId);
            parameters[1] = new SqlParameter("@GovernorateId", gIds);
            parameters[2] = new SqlParameter("@CreatedBy", lKT_GroupGovernoratesModel.CreatedBy);
            _systemSettingRepository.ExecuteStoredProcedure("sp_Dml_LKT_GroupGovernates", parameters);

        }
        public List<LKTGovernorateModel> getUnassignedGovernorates(int caseGroupId, bool isActive)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("caseGroupId", caseGroupId);
            parameters[1] = new SqlParameter("isActive", isActive);
            return _systemSettingRepository.ExecuteStoredProcedure<LKTGovernorateModel>("sp_GetUnassignedGovernorates", parameters).ToList();
        }
        public List<LKTGovernorateModel> getAssignedGovernorates(int caseGroupId)
        {
            SqlParameter[] parameters = new SqlParameter[1];
            parameters[0] = new SqlParameter("caseGroupId", caseGroupId);
            return _systemSettingRepository.ExecuteStoredProcedure<LKTGovernorateModel>("sp_GetAssignedGovernorates", parameters).ToList();
        }
        public List<LKTPartyCategory> getPartyCategory()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _systemSettingRepository.ExecuteStoredProcedure<LKTPartyCategory>("sp_Get_LKT_PartyCategory", parameters).ToList();
        }
        public string InsUpDel_CaseCategory(CaseGroupCategoryModel caseGroupCategoryModel, string dmlType)
        {
            SqlParameter[] parameters = new SqlParameter[10];
            parameters[0] = new SqlParameter("@CAAJ_Code", caseGroupCategoryModel.CAAJ_Code);
            parameters[1] = new SqlParameter("@ACO_Code", caseGroupCategoryModel.ACO_Code);
            parameters[2] = new SqlParameter("@NameEn", caseGroupCategoryModel.NameEn);
            parameters[3] = new SqlParameter("@NameAr", caseGroupCategoryModel.NameAr);
            parameters[4] = new SqlParameter("@IsActive", caseGroupCategoryModel.IsActive);
            parameters[5] = new SqlParameter("@CreatedBy", caseGroupCategoryModel.CreatedBy);
            parameters[6] = new SqlParameter("@CaseGroupId", caseGroupCategoryModel.CaseGroupId);
            parameters[7] = new SqlParameter("@DmlType", dmlType);
            parameters[8] = new SqlParameter("@Message", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
            parameters[9] = new SqlParameter("@CaseCategoryId", caseGroupCategoryModel.CaseCategoryId);
            _systemSettingRepository.ExecuteStoredProcedure("sp_Dml_COA_CaseCategory", parameters);
            return parameters[8].Value.ToString() ?? "";
        }
        public bool DeleteCase(int CaseId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("CaseId ", CaseId);
            _systemSettingRepository.ExecuteStoredProcedure("Sjc_delete_Case", spParams);
            return true;
        }
        public List<CaseCategoryTypesModel> GetCaseCategoryTypes()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _systemSettingRepository.ExecuteStoredProcedure<CaseCategoryTypesModel>("sp_Get_COR_CaseTypes", parameters).ToList();
        }
        public string InsUpDel_CaseType(CaseCategoryTypesModel caseGroupCategoryModel, string dmlType)
        {
            SqlParameter[] parameters = new SqlParameter[11];
            parameters[0] = new SqlParameter("@CAAJ_Code", caseGroupCategoryModel.CAAJ_Code);
            parameters[1] = new SqlParameter("@ACO_Code", caseGroupCategoryModel.ACO_Code);
            parameters[2] = new SqlParameter("@NameEn", caseGroupCategoryModel.NameEn);
            parameters[3] = new SqlParameter("@NameAr", caseGroupCategoryModel.NameAr);
            parameters[4] = new SqlParameter("@IsActive", caseGroupCategoryModel.IsActive);
            parameters[5] = new SqlParameter("@CreatedBy", caseGroupCategoryModel.CreatedBy);
            parameters[6] = new SqlParameter("@CaseTypeId", caseGroupCategoryModel.CaseTypeId);
            parameters[7] = new SqlParameter("@DmlType", dmlType);
            parameters[8] = new SqlParameter("@Message", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
            parameters[9] = new SqlParameter("@FirstPartyTypeId", caseGroupCategoryModel.FirstPartyTypeId);
            parameters[10] = new SqlParameter("@SecondPartyTypeId", caseGroupCategoryModel.SecondPartyTypeId);
            _systemSettingRepository.ExecuteStoredProcedure("sp_Dml_COA_CaseType", parameters);
            return parameters[8].Value.ToString() ?? "";
        }
        public List<LKTPartyType> GetPartyTypes(int caseGroupId, int partyCategoryId)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@CaseGroupId", caseGroupId);
            parameters[1] = new SqlParameter("@PartyCategoryId", partyCategoryId);
            return _systemSettingRepository.ExecuteStoredProcedure<LKTPartyType>("sp_Get_LKT_PartyType", parameters).ToList();
        }
        public List<CaseCategoryTypesModel> GetUnassignedCaseTypes(int caseGroupId, int caseCategoryId, bool isActive)
        {
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@CaseGroupId", caseGroupId);
            parameters[1] = new SqlParameter("@CaseCategoryId", caseCategoryId);
            parameters[2] = new SqlParameter("@isActive", isActive);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseCategoryTypesModel>("sp_Get_Unassinged_COR_CaseTypes", parameters).ToList();
        }
        public List<CaseCategoryTypesModel> GetAssignedCaseTypes(int caseGroupId, int caseCategoryId)
        {
            SqlParameter[] parameters = new SqlParameter[2];
            parameters[0] = new SqlParameter("@CaseGroupId", caseGroupId);
            parameters[1] = new SqlParameter("@CaseCategoryId", caseCategoryId);
            return _systemSettingRepository.ExecuteStoredProcedure<CaseCategoryTypesModel>("sp_Get_Assinged_COR_CaseTypes", parameters).ToList();
        }
        public string InsertLKT_Subject(LKT_SubjectModel lKT_SubjectModel, string dmlType)
        {
            SqlParameter[] parameters = new SqlParameter[9];
            parameters[0] = new SqlParameter("SubjectId", lKT_SubjectModel.SubjectId);
            parameters[1] = new SqlParameter("CAAJ_Code", lKT_SubjectModel.CAAJ_Code);
            parameters[2] = new SqlParameter("ACO_Code", lKT_SubjectModel.ACO_Code);
            parameters[3] = new SqlParameter("NameEn", lKT_SubjectModel.NameEn);
            parameters[4] = new SqlParameter("NameAr", lKT_SubjectModel.NameAr);
            parameters[5] = new SqlParameter("CreatedBy", lKT_SubjectModel.CreatedBy);
            parameters[6] = new SqlParameter("@DmlType", dmlType);
            parameters[7] = new SqlParameter("@Message", SqlDbType.VarChar, 200) { Direction = ParameterDirection.Output };
            parameters[8] = new SqlParameter("@IsActive", lKT_SubjectModel.IsActive);
            _systemSettingRepository.ExecuteStoredProcedure("sjc_manage_LKT_Subject", parameters);
            return parameters[7].Value.ToString() ?? "";
        }
        public List<LKT_SubjectModel> GetAll()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _systemSettingRepository.ExecuteStoredProcedure<LKT_SubjectModel>("sjc_GetLKT_Subject", parameters).ToList();
        }
        public string InsUpdCaseCategoryDetails(CaseCategoryDetails caseCategoryDetails, string userName)
        {
            try
            {
                SqlParameter[] spParams = new SqlParameter[21];


                spParams[0] = new SqlParameter("CaseCatDtlId", caseCategoryDetails.CaseCatDtlId);
                spParams[1] = new SqlParameter("CaseCateggoryId", caseCategoryDetails.CaseCateggoryId);
                spParams[2] = new SqlParameter("Description_en", caseCategoryDetails.Description_en);
                spParams[3] = new SqlParameter("Description_ar", caseCategoryDetails.Description_ar);
                spParams[4] = new SqlParameter("ImageUrl", caseCategoryDetails.ImageUrl);
                spParams[5] = new SqlParameter("@ServiceUsers_en", caseCategoryDetails.ServiceUsers_en);
                spParams[6] = new SqlParameter("@ServiceUsers_ar", caseCategoryDetails.ServiceUsers_ar);
                spParams[7] = new SqlParameter("Procedure_en", caseCategoryDetails.Procedure_en);
                spParams[8] = new SqlParameter("Procedure_ar", caseCategoryDetails.Procedure_ar);
                spParams[9] = new SqlParameter("ReqdDocs_en", caseCategoryDetails.ReqdDocs_en);
                spParams[10] = new SqlParameter("ReqdDocs_ar", caseCategoryDetails.ReqdDocs_ar);
                spParams[11] = new SqlParameter("ReqdApprovals_en", caseCategoryDetails.ReqdApprovals_en);
                spParams[12] = new SqlParameter("ReqdApprovals_ar", caseCategoryDetails.ReqdApprovals_ar);
                spParams[13] = new SqlParameter("ServiceFee_en", caseCategoryDetails.ServiceFee_en);
                spParams[14] = new SqlParameter("ServiceFee_ar", caseCategoryDetails.ServiceFee_ar);
                spParams[15] = new SqlParameter("DeliveryTime_en", caseCategoryDetails.DeliveryTime_en);
                spParams[16] = new SqlParameter("DeliveryTime_ar", caseCategoryDetails.DeliveryTime_ar);
                spParams[17] = new SqlParameter("ReqdDocTypeIds", caseCategoryDetails.ReqdDocTypeIds);
                spParams[18] = new SqlParameter("VisibleToRoleId", caseCategoryDetails.VisibleToRoleIds);
                spParams[19] = new SqlParameter("@Action", caseCategoryDetails.CaseCatDtlId > 0 ? "u" : "i");
                spParams[20] = new SqlParameter("Message", SqlDbType.NVarChar, 255);
                spParams[20].Direction = ParameterDirection.Output;
                _systemSettingRepository.ExecuteStoredProcedure("sjc_InsUpdCOR_CaseCategoryDetails", spParams);
                string msg = spParams[20].Value.ToString();

                return msg;
            }
            catch (Exception ex)
            {


                return null;
            }

        }
        public List<CaseCategoryDetails> GetAllCaseCategoryDetails()
        {
            try
            {
                SqlParameter[] param = new SqlParameter[0];
                var data = _systemSettingRepository.ExecuteStoredProcedure<CaseCategoryDetails>("sjc_GetAllCaseCategoryDetails", param);
                return data.ToList();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public CaseCategoryDetails GetCaseCategoryDetailsbyId(int CaseCatDtlId)
        {
            try
            {
                var data = _systemSettingRepository.ExecuteStoredProcedure<CaseCategoryDetails>("sjc_getCaseCategoryDetailsbyId", new Microsoft.Data.SqlClient.SqlParameter("CaseCatDtlId", CaseCatDtlId));
                return data.FirstOrDefault();
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public string DeleteCaseCategoryDetails(CaseCategoryDetails caseCategoryDetails, string userName)
        {
            try
            {
                SqlParameter[] spParams = new SqlParameter[21];
                spParams[0] = new SqlParameter("CaseCatDtlId", caseCategoryDetails.CaseCatDtlId);
                spParams[1] = new SqlParameter("CaseCateggoryId", caseCategoryDetails.CaseCateggoryId);
                spParams[2] = new SqlParameter("Description_en", caseCategoryDetails.Description_en);
                spParams[3] = new SqlParameter("Description_ar", caseCategoryDetails.Description_ar);
                spParams[4] = new SqlParameter("ImageUrl", caseCategoryDetails.ImageUrl);
                spParams[5] = new SqlParameter("@ServiceUsers_en", caseCategoryDetails.ServiceUsers_en);
                spParams[6] = new SqlParameter("@ServiceUsers_ar", caseCategoryDetails.ServiceUsers_ar);
                spParams[7] = new SqlParameter("Procedure_en", caseCategoryDetails.Procedure_en);
                spParams[8] = new SqlParameter("Procedure_ar", caseCategoryDetails.Procedure_ar);
                spParams[9] = new SqlParameter("ReqdDocs_en", caseCategoryDetails.ReqdDocs_en);
                spParams[10] = new SqlParameter("ReqdDocs_ar", caseCategoryDetails.ReqdDocs_ar);
                spParams[11] = new SqlParameter("ReqdApprovals_en", caseCategoryDetails.ReqdApprovals_en);
                spParams[12] = new SqlParameter("ReqdApprovals_ar", caseCategoryDetails.ReqdApprovals_ar);
                spParams[13] = new SqlParameter("ServiceFee_en", caseCategoryDetails.ServiceFee_en);
                spParams[14] = new SqlParameter("ServiceFee_ar", caseCategoryDetails.ServiceFee_ar);
                spParams[15] = new SqlParameter("DeliveryTime_en", caseCategoryDetails.DeliveryTime_en);
                spParams[16] = new SqlParameter("DeliveryTime_ar", caseCategoryDetails.DeliveryTime_ar);
                spParams[17] = new SqlParameter("ReqdDocTypeIds", caseCategoryDetails.ReqdDocTypeIds);
                spParams[18] = new SqlParameter("VisibleToRoleId", caseCategoryDetails.VisibleToRoleIds);
                spParams[19] = new SqlParameter("@Action", "d");
                spParams[20] = new SqlParameter("Message", SqlDbType.NVarChar, 255);
                spParams[20].Direction = ParameterDirection.Output;
                _systemSettingRepository.ExecuteStoredProcedure("sjc_InsUpdCOR_CaseCategoryDetails", spParams);
                string msg = spParams[20].Value.ToString();

                return msg;
            }
            catch (Exception ex)
            {

                return null;
            }

        }


        public List<CORCaseSubjectModel> GetUnAssignedSubjects(int CaseGrpCatTypeId, bool isActive)
        {
            SqlParameter[] spParams = new SqlParameter[2];
            spParams[0] = new SqlParameter("CaseGrpCatTypeId ", CaseGrpCatTypeId);
            spParams[1] = new SqlParameter("isActive ", isActive);
            return _systemSettingRepository.ExecuteStoredProcedure<CORCaseSubjectModel>("sjc_GetUnAssignedSubject", spParams).ToList();
        }
        public List<CORCaseSubjectModel> GetAssignedSubjects(int CaseGrpCatTypeId)
        {
            SqlParameter[] spParams = new SqlParameter[1];
            spParams[0] = new SqlParameter("CaseGrpCatTypeId ", CaseGrpCatTypeId);
            return _systemSettingRepository.ExecuteStoredProcedure<CORCaseSubjectModel>("sjc_GetAssignedSubject", spParams).ToList();
        }
        public void InsUpDel_CorCaseSubject(CORCaseSubject cORCaseSubject)
        {
            string sId = "";
            foreach (var subjectId in cORCaseSubject.SubjectId)
            {
                sId = sId + subjectId.ToString() + ",";
            }
            sId = sId.Substring(0, sId.Length - 1);
            SqlParameter[] parameters = new SqlParameter[3];
            parameters[0] = new SqlParameter("@CaseGrpCatTypeId", cORCaseSubject.CaseGrpCatTypeId);
            parameters[1] = new SqlParameter("@SubjectId", sId);
            parameters[2] = new SqlParameter("@CreatedBy", cORCaseSubject.CreatedBy);
            _systemSettingRepository.ExecuteStoredProcedure("sp_Dml_COR_CaseSubject", parameters);
        }
        public void InsUpDel_CORGrpCatType(COR_GroupCatTypeModel cor_GroupCatTypeModel)
        {
            string cIds = "";
            foreach (var caseTypeId in cor_GroupCatTypeModel.CaseTypeId)
            {
                cIds = cIds + caseTypeId.ToString() + ",";
            }
            cIds = cIds.Substring(0, cIds.Length - 1);
            SqlParameter[] parameters = new SqlParameter[4];
            parameters[0] = new SqlParameter("@CaseGroupId", cor_GroupCatTypeModel.CaseGroupId);
            parameters[1] = new SqlParameter("@CaseCategoryId", cor_GroupCatTypeModel.CaseCategoryId);
            parameters[2] = new SqlParameter("@CaseTypeId", cIds);
            parameters[3] = new SqlParameter("@CreatedBy", cor_GroupCatTypeModel.CreatedBy);
            _systemSettingRepository.ExecuteStoredProcedure("sp_Dml_COR_CaseGrpCatType", parameters);

        }

        public bool InsUpDel_CorAdvanceLinkingConfig(COR_AdvanceLinkingConfigModel cOR_AdvanceLinkingConfigModel)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[17];
                parameters[0] = new SqlParameter("LinkId", cOR_AdvanceLinkingConfigModel.LinkId);
                parameters[1] = new SqlParameter("CaseGroupId", cOR_AdvanceLinkingConfigModel.CaseGroupId);
                parameters[2] = new SqlParameter("LocationId", cOR_AdvanceLinkingConfigModel.LocationId);
                parameters[3] = new SqlParameter("CategoryId", cOR_AdvanceLinkingConfigModel.CategoryId);
                parameters[4] = new SqlParameter("CaseTypeId", cOR_AdvanceLinkingConfigModel.CaseTypeId);
                parameters[5] = new SqlParameter("SubjectId", cOR_AdvanceLinkingConfigModel.SubjectId);
                parameters[6] = new SqlParameter("LinkAllow", cOR_AdvanceLinkingConfigModel.LinkAllow);
                parameters[7] = new SqlParameter("LinkGroupId", cOR_AdvanceLinkingConfigModel.LinkGroupId);
                parameters[8] = new SqlParameter("LinkSources", cOR_AdvanceLinkingConfigModel.LinkSources);
                parameters[9] = new SqlParameter("RoleId", cOR_AdvanceLinkingConfigModel.RoleId);
                parameters[10] = new SqlParameter("ShowRelatedCourtsOnly", cOR_AdvanceLinkingConfigModel.ShowRelatedCourtsOnly);
                parameters[11] = new SqlParameter("RequiredDocIds", cOR_AdvanceLinkingConfigModel.RequiredDocIds);
                parameters[12] = new SqlParameter("OptionalDocIds", cOR_AdvanceLinkingConfigModel.OptionalDocIds);
                parameters[13] = new SqlParameter("FirstPartyTypeId", cOR_AdvanceLinkingConfigModel.FirstPartyTypeId);
                parameters[14] = new SqlParameter("SecondPartyTypeId", cOR_AdvanceLinkingConfigModel.SecondPartyTypeId);
                parameters[15] = new SqlParameter("Deleted", false);
                parameters[16] = new SqlParameter("Action", cOR_AdvanceLinkingConfigModel.LinkId > 0 ? "U" : "I");
                _systemSettingRepository.ExecuteStoredProcedure("sjc_InsUpdDltCOR_AdvanceLinkingConfig", parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public List<COR_AdvanceLinkingConfigModel> GetCOR_AdvanceLinkingConfig()
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[0];
                return _systemSettingRepository.ExecuteStoredProcedure<COR_AdvanceLinkingConfigModel>("sjc_GetCOR_AdvanceLinkingConfig", parameters).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public COR_AdvanceLinkingConfigModel GetCOR_AdvanceLinkingConfigById(int LinkId)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("LinkId", LinkId);
                var data = _systemSettingRepository.ExecuteStoredProcedure<COR_AdvanceLinkingConfigModel>("sjc_GetCOR_AdvanceLinkingConfig", param).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public List<LKTLocationModel> getLocationsByCaseGroupId(int caseGroupId)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("CaseGroupId", caseGroupId);
                var data = _systemSettingRepository.ExecuteStoredProcedure<LKTLocationModel>("sp_GetLocationsByGroupId", param).ToList();
                return data;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
        public paginationRequestEvenLog GetAllRequestEventLog(int requestId,bool userFlag, int pageSize, int pageNumber, string? SearchText)
        {
           
            try
            {
                SqlParameter[] param = new SqlParameter[5];

                param[0] = new SqlParameter("pageSize", pageSize);
                param[1] = new SqlParameter("pageNumber", pageNumber);
                param[2] = new SqlParameter("SearchText", SearchText);
                param[3] = new SqlParameter("requestId", requestId);
                if(userFlag == false) param[4] = new SqlParameter("userFlag", null);
              else   param[4] = new SqlParameter("userFlag", userFlag); 

                var data = _systemSettingRepository.ExecuteStoredProcedure<RequestEvenLog>("sjc_GetRequestEventLog", param).ToList();
                int countItem = 0;
                if (SearchText != null)
                {
                    SqlParameter[] paramSearch = new SqlParameter[3];
                    paramSearch[0] = new SqlParameter("SearchText", SearchText);
                    paramSearch[1] = new SqlParameter("requestId", requestId);
                    if (userFlag == false) paramSearch[2] = new SqlParameter("userFlag", null);
                    else paramSearch[2] = new SqlParameter("userFlag", userFlag);

                    var count = _systemSettingRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetRequestEventLogCount", paramSearch).FirstOrDefault();
                    countItem = count.TotalCount;
                }
                else
                {
                    SqlParameter[] paramSearch = new SqlParameter[3];
                    paramSearch[0] = new SqlParameter("SearchText", null);
                    paramSearch[1] = new SqlParameter("requestId", requestId);
                    if (userFlag == false) paramSearch[2] = new SqlParameter("userFlag", null);
                    else paramSearch[2] = new SqlParameter("userFlag", userFlag);
                    var count = _systemSettingRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetRequestEventLogCount", paramSearch).FirstOrDefault();
                    countItem = count.TotalCount;
                }
                paginationRequestEvenLog model = new paginationRequestEvenLog()
                {
                    PaginatedData = data,
                    TotalCount = countItem
                };
                return model;

            }
            catch (Exception ex) { }
            return null;
        }
        public bool InsertRequestEventLog(RequestEvenLog evenLog)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[13];

                param[0] = new SqlParameter("@RequestId", evenLog.RequestId);
                param[1] = new SqlParameter("@LoggedBy", evenLog.LoggedBy);
                param[2] = new SqlParameter("@Description", evenLog.Description);
                param[3] = new SqlParameter("@EventId", null);
                param[4] = new SqlParameter("@ActionId", null);
                param[5] = new SqlParameter("@StatusId", null);
                param[6] = new SqlParameter("@UserIP", evenLog.UserIP);
                param[7] = new SqlParameter("@UserHostName", evenLog.UserHostName);
                param[8] = new SqlParameter("@UserAgent", evenLog.UserAgent);
                param[9] = new SqlParameter("@ShowToRequestor", evenLog.ShowToRequestor);
                param[10] = new SqlParameter("@Amount", evenLog.Amount);
                param[11] = new SqlParameter("@RefNo", evenLog.RefNo);
                param[12] = new SqlParameter("@PaymentRequestId", evenLog.PaymentRequestId);

                _systemSettingRepository.ExecuteStoredProcedure("sjc_InsertRequestEventLog", param);
             
                return true;

            }
            catch (Exception ex) { }
            return false ;
        }
        public RequestModel sjc_GetRequest_caseId(int? caseId)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] =  new SqlParameter("caseId", caseId);
                var data = _systemSettingRepository.ExecuteStoredProcedure<RequestModel>("sjc_GetRequest_caseId", param).FirstOrDefault();
                return data;

            }
            catch (Exception ex) { }
            return null;
        }

        public List<DocumentTypeModel> getdocumentType()
        {
            SqlParameter[] parameters = new SqlParameter[0];
            return _systemSettingRepository.ExecuteStoredProcedure<DocumentTypeModel>("SP_GetDocumentType", parameters).ToList();
        }

        public bool DeleteAdvanceLinking(int linkId)
        {
            try
            {
                SqlParameter[] parameters = new SqlParameter[2];
                parameters[0] = new SqlParameter("LinkId", linkId);
                parameters[1] = new SqlParameter("Action","D");
                _systemSettingRepository.ExecuteStoredProcedure("sjc_DltCOR_AdvanceLinkingConfig", parameters);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public List<AvailableActionOnStatus> GetActionforAvailableStatus(int? statusId, long roleId)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[2];

                param[0] = new SqlParameter("statusId", statusId);
                param[1] = new SqlParameter("roleId", roleId);
                var data = _systemSettingRepository.ExecuteStoredProcedure<AvailableActionOnStatus>("sjc_GetActionforAvailableStatus", param).ToList();
                return data;

            }
            catch (Exception ex) { }
            return null;
        }
        public bool AddCaseEventDocuments(CaseDocumentModel caseDocumentModel, string userName, long actionId)
        {
            SqlParameter[] spParams = new SqlParameter[7];
            spParams[0] = new SqlParameter("CaseDocumentId", caseDocumentModel.DocumentId);
            spParams[1] = new SqlParameter("CaseId", caseDocumentModel.CaseId);
            spParams[2] = new SqlParameter("DocumentType", caseDocumentModel.DocumentType);
            spParams[3] = new SqlParameter("DocumentPath", caseDocumentModel.DocumentPath);
            spParams[4] = new SqlParameter("Description", caseDocumentModel.Description);
            spParams[5] = new SqlParameter("DML", caseDocumentModel.DocumentId == 0 ? "I" : "U");
            spParams[6] = new SqlParameter("UploadedBy", userName);
            _systemSettingRepository.ExecuteStoredProcedure("Sp_dml_casedocument", spParams);
            return true;
        }

        public bool UpateRequestEventLogView(long? caseId, long LogId, bool ShowToRequestor)
        {
            try
            {
                SqlParameter[] spParams = new SqlParameter[3];
                spParams[0] = new SqlParameter("@ShowToRequestor", ShowToRequestor);
                spParams[1] = new SqlParameter("@RequestId", caseId);
                spParams[2] = new SqlParameter("@LogId", LogId);
                _systemSettingRepository.ExecuteStoredProcedure("UpateRequestEventLogView", spParams);
                return true;
            }
            catch(Exception ex)
            {

            }
            return false;
        }

        public PaymentStatus GetPaymentStatus(string? orderId)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];

                param[0] = new SqlParameter("@order_id", orderId);
                return _systemSettingRepository.ExecuteStoredProcedure<PaymentStatus>("GetPaymentStatus", param).FirstOrDefault(); 

            }
            catch (Exception ex) { }
            return null;
        }
        public RequestorDetail GetRequestorDetail(RequestorDetailRequest requestorDetailRequest) 
        {
            try
            {
                SqlParameter[] spParams = new SqlParameter[4];
                spParams[0] = new SqlParameter("@RequestByType", requestorDetailRequest.RequestType);
                spParams[1] = new SqlParameter("@RequestBy", requestorDetailRequest.RequestBy);
                spParams[2] = new SqlParameter("@CRNo", requestorDetailRequest.CRNo);
                spParams[3] = new SqlParameter("@EntityId", requestorDetailRequest.EntityId);
                var data = _systemSettingRepository.ExecuteStoredProcedure<RequestorDetail>("sp_GetRequestorDetail", spParams).FirstOrDefault();
                return data;
            }
            catch (Exception ex)
            {
            }
            return null;
        }
    }
}
