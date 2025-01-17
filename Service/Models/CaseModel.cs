﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CaseModel
    {
        public long CaseId { get; set; }
        public string? CaseNo { get; set; }
        public string? OriginalCaseNo { get; set; }
        public int? CourtTypeId { get; set; }
        public int? CourtBuildingId { get; set; }
        public int CaseGroupId { get; set; }
        public string? caseGroup { get; set; }
        public string? caseGroupAr { get; set; }
        public int GovernateId { get; set; }
        public string? governate { get; set; }
        public string? governateAr { get; set; }
        public int LocationId { get; set; }
        public string? LocationName { get; set; }
        public string? LocationNameAr { get; set; }
        public string? CourtName { get; set; }
        public string? courtNameAr { get; set; }
        public int CaseTypeId { get; set; }
        public string? CaseType { get; set; }
        public int CaseCategoryId { get; set; }
        public string? CaseCatName { get; set; }
        public string? caseCatNameAr { get; set; }
        public string?  caseSubCatNameAr { get; set; }
        public int CaseSubCategoryId { get; set;}
        public string? CaseSubCatName { get; set; }
        public DateTime? FiledOn { get; set; }
        public string? Subject { get; set; }
        public string? CreatedBy { get; set;}
        public DateTime? CreatedDate { get;set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get;set; }
        public int? CaseStatusId { get; set; }
        public string? CaseStatusName { get; set; }
        public string? CaseStatusNameAr { get; set; }
        public string CaseSource { get; set; }
        public string? caseCategoryName { get; set; }
        public string? CaseSubCategoryName { get; set; }
        public string? CourtTypeName { get; set; }
        public string? CourtBuildingName { get; set; }
        public string? CaseTypeName { get; set; }
        public string? CaseTypeAr { get; set; }
        public string? Fee { get; set; }
        public string? AdditionalSubjectIds { get; set; }
        public int? LinkSourceId { get; set; }
        public int? ExternalEntityId { get; set; }
        public string? RequestByType { get; set; }
        public int? UserId { get; set; }
        public int? EntityId { get; set; }
        public string? CrNo { get; set; }

    }
    public class CaseDocumentsModel
    {
        public long CaseDocumentId { get;set; }
        public long CaseId { get; set; }
        public long DocumentTypeId { get; set; }
        public string DocNameEn { get; set; }
        public string DocNameAr { get; set; }
        public string DocumentPath { get; set; }
        public string Description { get; set; }
        public DateTime? UploadDate { get; set; }

        public string? nameEn { get; set; }
        public string? nameAr { get; set;}
    public byte[]? fileStream { get; set; }

    }

    public class RequestModel
    {
        public int CaseId { get; set; }
        public string? CaseNo { get; set; }
        public int? CourtTypeId { get; set; }
        public int? CourtBuildingId { get; set; }
        public int? CaseTypeId { get; set; }
        public int? CaseCategoryId { get; set; }
        public int? CaseStatusId { get; set; }
        public int? CaseSubCategoryId { get; set; }
        public DateTime FiledOn { get; set; }
        public string? Subject { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool Deleted { get; set; }
        public string? CaseStatusNameAr { get; set; }
        public string? CaseStatusName { get; set; }
        public string? CourtNameAr { get; set; }
        public string? CourtName { get; set; }
        public string? CaseCatNameAr { get; set; }
        public string? CaseCatName { get; set; }
        public string? CaseTypeAr { get; set; }
        public decimal? Fee { get; set; }
        public string? CaseType { get; set; }
    }
    public class paginationRequestModel
    {
        public List<RequestModel> PaginatedData { get; set; }
        public int TotalCount { get; set; }
    }
    public class RequestorDetail
    {
        public string? FullName { get; set; }
        public string? CivilNo { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public string? RoleType { get; set; }
        public string? CompanyEntityName { get; set; }
    }
    public class RequestorDetailRequest
    {
        public string? RequestType { get; set; }
        public string? RequestBy { get; set; }
        public string? CRNo { get; set; }
        public int? @EntityId { get; set; }
    }
}
