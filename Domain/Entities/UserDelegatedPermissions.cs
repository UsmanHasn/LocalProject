﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class UserDelegatedPermissions : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Users User { get; set; }
        public int UserId { get; set; }
        public Pages Page { get; set; }
        public int PageId { get; set; }
        public bool ReadPermission { get; set; }
        public bool WritePermission { get; set; }
        public bool DeletePermission { get; set; }
        public int DelegatedByUserId { get; set; }
        public DateTime? EffFrom { get; set; }
        public DateTime? EffTo { get; set; }
    }
}
