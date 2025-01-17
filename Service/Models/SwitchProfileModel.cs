﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class SwitchProfileModel
    {
        public int Id { get; set; }
        public string CivilNumber { get; set; }
        public int UserId { get; set; }
        public string UserNameEn { get; set; }
        public string UserNameAr { get; set; }
        public string RoleNameEn { get; set; }
        public string RoleNameAr { get; set; }
        public string ProfileType { get; set; }
        public string CRNo { get; set; }
        public string CRName { get; set; }
        public int EntityId { get; set; }
        public string EntityName { get; set; }
    }
}
