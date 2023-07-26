using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class PaymentHistoryModel
    {
        public string? caseNo { get; set; }
        public string? date { get; set;}
        public string? fee { get; set; }
        public string? status { get; set; }
    }
}
