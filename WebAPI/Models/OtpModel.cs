namespace WebAPI.Models
{
    public class OtpModel
    { 
        public string OtpId { get; set; }
        public int OtpType { get; set; }    
        public int UserId { get; set; }
        public bool EmailSent { get; set; }
        public string Email { get; set; }
        public string MobileNumber { get; set; }
    }
}
