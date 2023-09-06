using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CaseBasicModel
    {
        public int CaseId { get; set; }
        public string CaseNo { get; set; }
        public DateTime? FiledOn { get; set; }
        public string? Subject { get; set; }
        public string? OriginalCaseNo { get; set; }
        public int? CaseGroupId { get; set; }
        public string? CaseGroupEn { get; set; }
        public string? CaseGroupAr { get; set; }
        public int? GovernateId { get; set; }
        public string? GovernateEn { get; set; }
        public string? GovernateAr { get; set; }
        public int? LocationId { get; set; }
        public string? LocationEn { get; set; }
        public string? LocationAr { get; set; }
        public int? CaseTypeId { get; set; }
        public string? CaseTypeEn { get; set; }
        public string? CaseTypeAr { get; set; }
        public int? CaseCategoryId { get; set; }
        public string? CaseCategoryEn { get; set; }
        public string? CaseCategoryAr { get; set; }
        public int? CaseSubCategoryId { get; set; }
        public string? CaseSubCategoryEn { get; set; }
        public string? CaseSubCategoryAr { get; set; }
        public int? CaseStatusId { get; set; }
        public string? CaseStatusEn { get; set; }
        public string? CaseStatusAr { get; set; }
        public int? PaymentDrawId { get; set; }
        public string? PaymentDrawEn { get; set; }
        public string? PaymentDrawAr { get; set; }
        public decimal? CaseFee { get; set; }
        public bool? Exempted { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? ExemptionDate { get; set; }
        public string? ReceiptNo { get; set; }
    }

}
