using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SYS_Menu : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? NameAr { get; set; }
        [MaxLength(1)]
        public string? MenuType { get; set; }
        public int? ParentMenuId { get; set; }
        public string? UrlPath { get; set; }
        public int Sequence { get; set; }
    }
}
