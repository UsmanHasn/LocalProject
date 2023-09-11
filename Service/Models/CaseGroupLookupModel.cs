using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CaseGroupLookupModel
    {
        public long CaseGroupId { get; set; }
        public string Code { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Createdate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int Deleted { get; set; }
        public string Status { get; set; }
    }
}
