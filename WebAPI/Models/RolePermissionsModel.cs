using Service.Models;

namespace WebAPI.Models
{
    public class RolePermissionsModel
    {
        public List<AssignRole> items { get; set; }
        public string? group { get; set; }
       
    }
}
