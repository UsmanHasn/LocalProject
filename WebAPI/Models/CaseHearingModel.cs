namespace WebAPI.Models
{
    public class CaseHearingModel
    {
        public int CaseHearingId { get; set; }
        public long CaseId { get; set; }
        public DateTime HearingDate { get; set; }
        public DateTime NextHearingDate { get; set; }
        public string HearingNotes { get; set; }
        public string JudgeNotes { get; set; }
    }
}
