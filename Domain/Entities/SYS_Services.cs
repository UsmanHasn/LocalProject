using Domain.Entities.Lookups;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SYS_Services : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
       // public int ServiceId { get; set; }
      //  public ServiceSubCategoryLookup ServiceSubCategory { get; set; }
        public int ServiceSubCategoryId { get; set; }
      
        public string Name { get; set; }

        public int Deleted { get; set; }
        public string NameAr { get; set; }
     //   public int Sequence { get; set; }
        public int IsActive { get; set; }
      //  public string NameEn { get; set; }

     //  public string CategoryId { get; set; }
    }
}
