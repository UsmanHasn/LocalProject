namespace WebAPI.Models
{
    public class OtpModel
    { 
        public int OtpId { get; set; }
        public int OtpType { get; set; }    
        public int UserId { get; set; }
        public bool EmailSent { get; set; }
    }
}
