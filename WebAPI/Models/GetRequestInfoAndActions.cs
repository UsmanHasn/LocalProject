using Service.Models;

namespace WebAPI.Models
{
    public class GetRequestInfoAndActions
    {
        public RequestModel Request { get; set; }
        public List<AvailableActionOnStatus> GetAvailableActionOnStatuses { get; set; }
    }
}
