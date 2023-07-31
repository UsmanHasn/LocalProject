using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class UserDelegatePermissionModel
    {
        public int UserPermissionId { get; set; }
        public int PageId { get; set; }
        public int UserId { get; set; }
        public int DelegatedUserId { get; set; }
        public string? PageNameEn { get; set; }
        public string? PageNameAr { get; set; }
        public string? PageModuleEn { get; set; }
        public bool ReadPermission { get; set; }
        public bool WritePermission { get; set; }
        public bool DeletePermission { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo { get; set; }
    }
}
