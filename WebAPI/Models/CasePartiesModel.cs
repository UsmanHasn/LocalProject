namespace WebAPI.Models
{
    public class CasePartiesModel
    {
        public int CasePartyId { get; set; }
        public long CaseId { get; set; }
        public string PartyName { get; set; }
        public string NationalityNameEn { get; set; }
        public string NationalityNameAr { get; set; }
        public string PartyTypeEn { get; set; }
        public string PartyTypeAr { get; set; }
        public string EntityTypeEn { get; set; }
        public string EntityTypeAr { get; set; }
    }
}
