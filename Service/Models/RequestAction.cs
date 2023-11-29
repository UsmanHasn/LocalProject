using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class RequestAction
    {
        public int ActionId { get; set; }
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public string ReqDocIds { get; set; }
        public string OptionalDocIds { get; set; }
        public bool IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public string? DefaultTextEn { get; set; }
        public string? DefaultTextAr { get; set; }
        public string? AvailableStatusIds { get; set; }
        public int? ActionFor { get; set; }
        public int DisplayOrder { get; set; }
        public int CheckRequired { get; set; }
        public string? CaseSubjectIds { get; set; }
        public bool Deleted { get; set; }
        public string Action { get; set; }

        public string RequestActionEnglish
        {
            get { return IsActive ? "Yes" : "No"; }
            set { }
        }
        public string RequestActionArabic
        {
            get { return IsActive ? "نعم" : "لا"; }
            set { }

        }
    }
}
