using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class AssignRole
    {
        public int RolePermissionId { get; set; }
        public int pageId { get; set; }
        public int roleId { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? pageModuleEn { get; set; }
        public string? pageModuleAr { get; set; }
        public bool ReadPermission { get; set; }
        public bool WritePermission { get; set; }
        public bool DeletePermission { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }

    }
}
