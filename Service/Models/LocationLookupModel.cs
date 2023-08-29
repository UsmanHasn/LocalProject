using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class LocationLookupModel
    {
        public long LocationId { get; set; }
        public long GovernatesId { get; set; }
        public string Code { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public long LinkLocationId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Createdate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
    }
}
