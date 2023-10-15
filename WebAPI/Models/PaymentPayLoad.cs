namespace WebAPI.Models
{
    public class PaymentPayLoad
    {
        public long tid { get; set; }
        public long? merchant_id { get; set; }
        public string? order_id { get; set; }
        public Decimal amount { get; set; }
        public string? currency { get; set; }
        public string? redirect_url { get; set; }
        public string? cancel_url { get; set; }
        public string? language { get; set; }
    }

    public class PaymentPayloadEncResponse
    {
        public string strEncRequest { get; set; }
    }

   
}

