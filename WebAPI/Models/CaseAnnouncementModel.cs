namespace WebAPI.Models
{
    public class CaseAnnouncementModel
    {
        public int CaseAnnouncementId { get; set; }
        public long CaseId { get; set; }
        public DateTime AnnouncementDate { get; set; }
        public int FormTypeId { get; set; }
        public int PartyTypeId { get; set; }
        public string PartyTypeEn { get; set; }
        public string PartyTypeAr { get; set; }
        public string AnnouncementAr { get; set; }
        public string AnnouncementEn { get; set; }
    }
}
