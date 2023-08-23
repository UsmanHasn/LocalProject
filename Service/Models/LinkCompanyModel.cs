using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class LinkCompanyModel
    {
        public int Id { get; set; }
        public string? CivilNo { get; set; }
        public string? CRNo { get; set; }
        public bool IsActive { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreateDate { get;}
        public string? LastModifiedBy { get; set;}
        public DateTime? LastModifiedDate { get;}
    }
}
