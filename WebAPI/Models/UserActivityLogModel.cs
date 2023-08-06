using Service.Models;

namespace WebAPI.Models
{
    public class UserActivityLogModel
    {
        public string? group { get; set; }
        public string? groupAr { get; set; }
        public List<UserActivityLog> items { get; set; }
    }
}
