using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class DelegUser
    {
        public bool ReadPermission { get; set; }
        public bool WritePermission { get; set; }
        public bool DeletePermission { get; set; }
        public int pageId { get; set; }
        public int userPermissionId { get; set; }
        public int userId { get; set; }
        public string? CreatedBy { get; set; }
        public bool Deleted { get; set; }
        public int DelegatedByUserId { get; set; }
    }
}
