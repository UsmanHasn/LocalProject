using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class Calendar
    {
        public string? HearingDate { get; set; }
        public string? CaseNo { get; set; }

        public string? Description { get; set; }

        public string? CaseParty { get; set; }
        public string? CourtBuilding { get; set; }
    }
}
