namespace WebAPI.Models
{
    public class UsersModel
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string UsernameAr { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string RoleAr { get; set; }
        public string MobileNo { get; set; }
        public string? CivilID { get; set; }
        public string? Email { get; set; }
        public DateTime? LastLoginDate { get; set; }
    }
}
