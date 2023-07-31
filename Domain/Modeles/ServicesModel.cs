using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Modeles
{
    public class ServicesModel
    {
        public int ServiceId { get; set; }
  
        public int ServiceSubCategoryId { get; set; }
        public string Name { get; set; }
        public string NameAr { get; set; }
        public int? Sequence { get; set; }
        public int IsActive { get; set; }
       
    }
}
