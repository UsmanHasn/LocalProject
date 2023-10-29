using System.Runtime.Serialization;

namespace WebAPI.Models
{
    public class PaymentPayLoad
    {
        public long RequestId { get; set; }
        public long UserId { get; set; }
        [IgnoreDataMember]
        public long tid { get; set; }
        [IgnoreDataMember]
        public long? merchant_id { get; set; }
        public string? order_id { get; set; }
        public Decimal amount { get; set; }
        [IgnoreDataMember]
        public string? currency { get; set; }
        [IgnoreDataMember]
        public string? redirect_url { get; set; }
        [IgnoreDataMember]
        public string? cancel_url { get; set; }
        [IgnoreDataMember]
        public string? language { get; set; }
    }

    public class PaymentPayloadEncResponse
    {
        public string strEncRequest { get; set; }
    }

   
}

