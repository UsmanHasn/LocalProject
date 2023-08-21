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
        public int CourtTypeId { get; set; }
        public int CourtBuildingId { get; set; }
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
    }
    public class CaseDocumentsModel
    {
       // public string CaseDocumentId { get;set; }
    public long CaseId { get;set; }
    public long DocumentTypeId { get;set; }
    public string DocumentPath { get;set; }
    public string Description { get;set; }
    public DateTime? UploadDate { get;set; }

    

    }
}