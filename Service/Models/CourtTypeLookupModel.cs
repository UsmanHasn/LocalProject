using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CourtTypeLookupModel
    {
        public int CourtTypeId { get; set; }
        public string? Code { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public int IsActive { get; set;}
        public string? CreatedBy { get; set;}
        public DateTime? CreatedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public bool? Deleted { get; set; }

    }
}
