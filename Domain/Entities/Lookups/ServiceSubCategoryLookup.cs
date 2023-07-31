using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookups
{
    public class ServiceSubCategoryLookup : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ServiceSubCategoryId { get; set; }
        //public ServiceCategoryLookup ServiceCategory { get; set; }
        public int? ServiceCategoryId { get; set; }
                    
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [Required]
        public string NameAr { get; set; }
        public int Deleted { get; set; }

    }

}
