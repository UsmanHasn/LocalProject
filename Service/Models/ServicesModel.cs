using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class ServicesModel
    {
        public int CategoryId { get; set; }
        public string CategoryNameEn { get; set; }
        public string CategoryNameAr { get; set; }
        public int SubCategoryId { get; set; }
        public string SubCategoryNameEn { get; set; }
        public string SubCategoryNameAr { get;set; }
        public int ServiceId { get; set; }
        public string ServiceNameEn { get; set; }
        public string ServiceNameAr { get; set;}
        public int Sequence { get; set; }
    }
}
