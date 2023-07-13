using Service.Models;

namespace WebAPI.Models
{
    public class UserDelegationModel
    {
        public string? group { get; set; }
        public List<DelegationModel> items { get; set; }
        
    }
}
