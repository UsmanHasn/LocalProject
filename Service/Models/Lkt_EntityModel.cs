using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Lkt_EntityModel
    {
        public int EntityId { get; set; }
        public string Code { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public bool IsActive { get; set; }
        public string Action { get; set; }

        public string EntityEnglish
        {
            get { return IsActive ? "Yes" : "No"; }
            set { }
        }
        public string EntityArabic
        {
            get { return IsActive ? "نعم" : "لا"; }
            set { }

        }
    }
}
