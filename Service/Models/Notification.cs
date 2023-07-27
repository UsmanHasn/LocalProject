﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Notification
    {
        public string? CaseID { get; set; }
        public string? Type { get; set; }
        public string? Date { get; set; }
        public string? Description { get; set; }
        public string? LastViewedOn { get; set; }


    }
}