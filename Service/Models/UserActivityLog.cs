using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class UserActivityLog
    {
        public int ID { get; set; }
        public string Name{ get; set; }
        public int UserId { get; set; }
        public string? Email { get; set; }
        public string? Role { get; set; }
        public string Message { get; set; }
        public string? Date { get; set; }
        public string? IPAddress { get; set; }

        public string? Location { get; set; }
        public string? Device { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public Boolean Deleted { get; set; }
    }
}
