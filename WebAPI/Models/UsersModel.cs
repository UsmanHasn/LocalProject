﻿namespace WebAPI.Models
{
    public class UsersModel
    {
        public string Username { get; set; }
        public string UsernameAr { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
        public string Role { get; set; }
        public string MobileNo { get; set; }
        public string? CivilID { get; set; }
        public string? Email { get; set; }
    }
}
