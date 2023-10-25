using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Models
{
    public class PaymentdecryptResponseModel
    {
        public string order_id { get; set; }
        public string tracking_id { get; set; }
        public string bank_ref_no { get; set; }
        public string order_status { get; set; }
        public string failure_message { get; set; }
        public string payment_mode { get; set; }
        public string card_name { get; set; }
        public string status_code { get; set; }
        public string status_message { get; set; }
        public string currency { get; set; }
        public string amount { get; set; }
        public string billing_name { get; set; }
        public string billing_address { get; set; }
        public string billing_city { get; set; }
        public string billing_state { get; set; }
        public string billing_zip { get; set; }
        public string billing_country { get; set; }
        public string billing_tel { get; set; }
        public string billing_email { get; set; }
        public string merchant_param1 { get; set; }
        public string merchant_param2 { get; set; }
        public string merchant_param3 { get; set; }
        public string merchant_param4 { get; set; }
        public string merchant_param5 { get; set; }
        public string vault { get; set; }
        public string offer_type { get; set; }
        public string offer_code { get; set; }
        public string discount_value { get; set; }
        public string mer_amount { get; set; }
        public string eci_value { get; set; }
        public string retry { get; set; }
        public int response_code { get; set; }
        public string billing_notes { get; set; }
        public string trans_date { get; set; }
        public string bin_country { get; set; }
        public string card_type { get; set; }
        public string saveCard { get; set; }
        public string order_date_time { get; set; }
        public string token_number { get; set; }
        public string token_eligibility { get; set; }
        public string merchant_param6 { get; set; }
        public string merchant_param7 { get; set; }
        public long Request_Id { get; set; }
        public long UserId { get; set; }
    }
    public class PaginatedTransactionModel
    {
        public List<PaymentdecryptResponseModel> PaginatedData { get; set; }
        public int TotalCount { get; set; }
    }
}
