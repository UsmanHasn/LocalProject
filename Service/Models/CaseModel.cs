using System;
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
        public int CaseTypeId { get; set; }
        public string? CaseType { get; set; }
        public int CaseCategoryId { get; set; }
        public string? CaseCatName { get; set; }
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
        public string CaseSource { get; set; }
        public string? Fee { get; set; }
    }
    public class CaseDocumentsModel
    {
        // public string CaseDocumentId { get;set; }
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
}
