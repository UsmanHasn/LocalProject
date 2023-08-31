using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class CasePartyModel
    {
        public string? group { get; set; }
        public List<CaseParties> items { get; set; }
    }
}
