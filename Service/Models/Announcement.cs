using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Announcement
    {
        public string? ID { get; set; }
        public string? Type { get; set; }
        public string? Date { get; set; }
        public string? Description { get; set; }
        public string? LastViewedOn { get; set; }
    }
}
