using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class DelegationModel
    {
        public int userPermissionId { get; set; }
        public string civilNo { get; set; }
        public DateTime? CivilExpiryDate { get; set; }
        public int pageId { get; set; }
        public int userId { get; set; }
        public string? UsernameEn { get; set; }
        public string? UsernameAr { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public string? pageModuleEn { get; set; }
        public string? pageModuleAr { get; set; }
        public bool? ReadPermission { get; set; }
        public bool? WritePermission { get; set; }
        public bool? DeletePermission { get; set; }
        public string? CreatedBy { get; set;}
        public bool Deleted { get; set; }
        public int DelegatedByUserId { get; set; }
        public DateTime? EffectiveFrom { get; set; }
        public DateTime? EffectiveTo{ get; set; }
    }
}
