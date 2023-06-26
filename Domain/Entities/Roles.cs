﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Roles : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Name { get; set; }
        [MaxLength(50)]
        [Required]
        public string NameAr { get; set; }
        [MaxLength(100)]
        [Required]
        public string Description { get; set; }
        [MaxLength(50)]
        [Required]
        public string DescriptionAr { get; set; }

    }
}
