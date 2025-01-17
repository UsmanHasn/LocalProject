﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class AlertModel
    {
        public int alertId { get; set; }
        public string? alertType { get; set; }
        public string? alertTypeAr { get; set; }

        public string? subject { get; set; }
        public string? email { get; set; }
        public string? mobileNo { get; set; }
        public string? message { get; set; }
        public int? userId { get; set; }
        public string? userName { get; set; }
        public int alertcount { get; set; }

        public bool IsViewed { get; set; }
        public DateTime? ViewedOn { get; set;}
    }
}
