namespace WebAPI.Models
{
    public class CaseDocumentModel
    {
        public int CaseDocumentId { get; set; }
        public long CaseId { get; set; }
        public DateTime UploadDate { get; set; }
        public string DocumentType { get; set; }
        public string FileName { get; set; }
    }
}
