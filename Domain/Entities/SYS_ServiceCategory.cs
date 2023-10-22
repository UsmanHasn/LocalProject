using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SYS_ServiceCategory : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int ServiceCategoryId { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string NameAr { get; set; }
        //[MaxLength(100)]
        //[Required]
        //public string CreatedBy { get; set; }
      
        //public DateTime CreatedDate { get; set; }

        
        //[MaxLength(100)]
        //[Required]
        //public string LastModifiedBy { get; set; }

        //public DateTime LastModifiedDate { get; set; }
        public int Deleted { get; set; }
    }
}
