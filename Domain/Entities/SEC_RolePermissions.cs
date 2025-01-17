﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SEC_RolePermissions : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public SEC_Roles Role { get; set; }
        public int RoleId { get; set; }
        public SYS_Pages Page { get; set; }
        public int PageId { get; set; }
        public bool ReadPermission { get; set; }
        public bool WritePermission { get; set; }
        public bool DeletePermission { get; set; }
    }
}
