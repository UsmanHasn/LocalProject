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
        public string? FiledOn { get; set;}
        public string? caseStatusNameEn { get; set; }
        public string? CaseStatusNameAr { get; set; }
        public string? CaseTypeNameEn { get; set; }
        public string? CaseTypeNameAr { get; set; }
    }
}
