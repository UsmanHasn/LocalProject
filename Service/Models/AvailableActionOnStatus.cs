using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public  class AvailableActionOnStatus
    {
        public int ActionId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string ReqDocIds { get; set; }
        public string OptionalDocIds { get; set; }
        public string DefaultTextEn { get; set; }
        public string DefaultTextAr { get; set; }
        public int ActionFor { get; set; }
        public int DisplayOrder { get; set; }
        public bool CheckRequired { get; set; }
        public string CaseSubjectIds { get; set; }
        public bool Deleted { get; set; }
        public int? NextStatusId { get; set; }
        public int? StatusId { get; set; }
    }
}
