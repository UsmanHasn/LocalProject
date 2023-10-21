using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class UserListModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public string RoleAr { get; set; }
        public string MobileNumber  { get; set; }
        public string CivilId { get; set; }
        public string Status { get; set; }
        public string StatusAr { get; set; }

    }
}
