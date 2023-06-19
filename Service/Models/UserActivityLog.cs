using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class UserActivityLog
    {
        public string? ID { get; set; }
        public string? Name{ get; set; }

        public string? Email { get; set; }
        public string? Role { get; set; }

        public string? Date { get; set; }
        public string? IPAddress { get; set; }

        public string? Location { get; set; }
        public string? Device { get; set; }
    }
}
