namespace WebAPI.Models
{
    public class OriginalCaseInfoModel
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string CaseType { get; set; }
        public string StatusName { get; set; }
        public DateTime DateDecision { get; set; }
    }
}
