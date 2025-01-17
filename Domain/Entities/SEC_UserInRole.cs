﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SEC_UserInRole : BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public SEC_Users User { get; set; }
        public int UserId { get; set; }
        public SEC_Roles Role { get; set; }
        public int RoleId { get; set; }
    }
}
