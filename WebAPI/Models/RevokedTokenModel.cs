namespace WebAPI.Models
{
    public class RevokedTokenModel
    {
        public int Id { get; set; }
        public string Token { get; set; }
        public DateTime? RevocationDate { get; set; }
        public string Reason { get; set; }
        public bool IsActive { get; set; }
        public int UserId { get; set; }
    }
}
