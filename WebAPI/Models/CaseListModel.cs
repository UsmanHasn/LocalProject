namespace WebAPI.Models
{
    public class CaseRequest
    {
        public string civilNo { get; set; }
        public string crNo { get; set; }
        public int? entityId { get; set; }
        public string roleName { get; set; }
        public int? statusId { get; set; }
    }
    public class CaseListModel
    {
        public string Case_No { get; set; }
        public string Case_Type { get; set; }
        public string Description { get; set; }
        public string Lawyers { get; set; }
    }
    public class CasesModel
    {
        public long CaseId { get; set; }
        public string CaseNo { get; set; }
        public string PendingCaseNo { get; set; }
        public string CaseGroupEn { get; set; }
        public string CaseGroupAr { get; set; }
        public string CaseTypeEn { get; set; }
        public string CaseTypeAr { get; set; }
        public string CaseStatusEn { get; set; }
        public string CaseStatusAr { get; set; }
        public string CaseBuildingAr { get; set; }
        public string CaseBuildingEn { get; set; }
        public double FeeValue { get; set; }
        public string Comments { get; set; }
        public DateTime CaseFiledDate { get; set; }
        public string CaseSource { get; set; }
    }
}
