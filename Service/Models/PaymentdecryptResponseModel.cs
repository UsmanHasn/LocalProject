using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class PaymentdecryptResponseModel
    {
        public long PaymentResponseId { get; set; }
        public long PaymentRequestId { get; set; }
        public string OrderId { get; set; }
        public string TrackingId { get; set; }
        public string BankRefNo { get; set; }
        public string OrderStatus { get; set; }
        public string FailureMessage { get; set; }
        public string PaymentMode { get; set; }
        public string CardName { get; set; }
        public string StatusCode { get; set; }
        public string StatusMessage { get; set; }
        public string Currency { get; set; }
        public decimal Amount { get; set; }
        public string BillingName { get; set; }
        public string BillingAddress { get; set; }
        public string BillingCity { get; set; }
        public string BillingState { get; set; }
        public string BillingZip { get; set; }
        public string BillingCountry { get; set; }
        public string BillingTel { get; set; }
        public string BillingEmail { get; set; }
        public string MerchantParam1 { get; set; }
        public string MerchantParam2 { get; set; }
        public string MerchantParam3 { get; set; }
        public string MerchantParam4 { get; set; }
        public string MerchantParam5 { get; set; }
        public decimal DiscountValue { get; set; }
        public decimal MerAmount { get; set; }
        public string Retry { get; set; }
        public string ResponseCode { get; set; }
        public DateTime TransDate { get; set; }
        public string BinCountry { get; set; }
        public string CardType { get; set; }
        public char SaveCard { get; set; }
        public DateTime OrderDateTime { get; set; }
    }
    public class PaginatedTransactionModel
    {
        public List<PaymentdecryptResponseModel> PaginatedData { get; set; }
        public int TotalCount { get; set; }
    }
}
