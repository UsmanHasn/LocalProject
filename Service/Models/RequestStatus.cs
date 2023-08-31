using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public  class RequestStatus
    {
       
            public int StatusId { get; set; }
            public string NameEn { get; set; }
            public string NameAr { get; set; }
            public string CreatedBy { get; set; }
            public DateTime CreatedDate { get; set; }
            public string LastModifiedBy { get; set; }
            public DateTime LastModifiedDate { get; set; }
            public string Action { get; set; }
       
    }
}
