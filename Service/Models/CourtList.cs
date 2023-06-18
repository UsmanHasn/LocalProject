using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CourtList
    {
        public string? CourtName { get; set; }
        public string? CaseID { get; set; }
        public string? Description { get; set; }

        public string? TotalNoCases { get; set; }
    }
}
