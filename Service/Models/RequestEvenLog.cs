using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class RequestEvenLog
    {
        public long LogId { get; set; }
        public int RequestId { get; set; }
        public DateTime? LoggedOn { get; set; }
        public string? LoggedBy { get; set; }
        public string? Description { get; set; }
        public int? EventId { get; set; }
        public int? ActionId { get; set; }
        public int? StatusId { get; set; }
        public string? UserIP { get; set; }
        public string? UserHostName { get; set; }
        public string? UserAgent { get; set; }
        public bool? ShowToRequestor { get; set; }
        public string? Amount { get; set; }
        public string? RefNo { get; set; }
        public int? PaymentRequestId { get; set; }
    }
    public class paginationRequestEvenLog
    {
        public List<RequestEvenLog> PaginatedData { get; set; }
        public int TotalCount { get; set; }
    }
}
