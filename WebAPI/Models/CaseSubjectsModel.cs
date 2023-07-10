namespace WebAPI.Models
{
    public class CaseSubjectsModel
    {
        public int CaseId { get; set; }
        public int SubjectId { get; set; }
        public string SubjectNameEn { get; set; }
        public string SubjectNameAr { get; set; }
        public decimal FeeValue { get; set; }
        public bool FeePaid { get; set; }
    }
}
