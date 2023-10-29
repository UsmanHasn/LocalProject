using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class PaymentPayLoad
    {
        public long RequestId { get; set; }
        public long UserId { get; set; }
        public long tid { get; set; }
        public long? merchant_id { get; set; }
        public string? order_id { get; set; }
        public Decimal amount { get; set; }
        public string? currency { get; set; }
        public string? redirect_url { get; set; }
        public string? cancel_url { get; set; }
        public string? language { get; set; }
    }
}
