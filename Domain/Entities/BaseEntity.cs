using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
        [MaxLength(50)]
        [Required]
        public string CreatedBy { get; set; }
        [Required]
        public DateTime? CreatedDate { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastModifiedBy { get; set; }
        [Required]
        public DateTime? LastModifiedDate { get; set; }
        public bool Deleted { get; set; }
    }
}
