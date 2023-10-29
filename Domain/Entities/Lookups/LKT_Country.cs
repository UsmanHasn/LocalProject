using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Lookups
{
    public class LKT_Country : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Code { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string NameAr { get; set; }
    }
}
