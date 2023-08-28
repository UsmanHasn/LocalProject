using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public  class CaseSubCategoryLookupModel
    {
        public long CaseSubCategoryId { get; set; }
      
        public string NameEn { get; set; }
        public string NameAr { get; set; }
        public long CaseCategoryId { get; set; }
        public string CodeCAAJ { get; set; }
        public string  CodeACO { get; set; }
        public string AllowPreviousSearch { get; set; }
        public string IsActive { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public int Deleted { get; set; }
    }
}
