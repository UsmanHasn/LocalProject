using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class UserRole
    {
        public string? Role { get; set; }
        public string? Description { get; set; }

    }
    public class UserAssignRole
    {
        public int RoleId { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public bool Assigned { get; set; }

    }


}
