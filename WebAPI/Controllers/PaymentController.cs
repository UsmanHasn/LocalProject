using CCAV.Util;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Service.Concrete;
using Service.Interface;
using Service.Models;
using System.Collections.Specialized;
using System.Net;
using System.Net.Http.Headers;
using System.Reflection.Metadata;
using System.Web;
using System.Xml.Linq;
using WebAPI.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebAPI.Controllers
{
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _IpaymentService;
        private readonly IConfiguration Configuration;


        public PaymentController(IPaymentService paymentService, IConfiguration configuration)
        {
            _IpaymentService = paymentService;
            Configuration = configuration;
        }

        [HttpPost]
        [Route("PaymentPayLoadEnc")]
        public IActionResult PaymentPayLoadEnc(Models.PaymentPayLoad payLoad)
        {
            try
            {
                string? workingKey = Configuration["Payment:workingKey"];//put in the 32bit alpha numeric key in the quotes provided here 	
                CCACrypto ccaCrypto = new CCACrypto();
                DateTime now = DateTime.Now;
                long timestamp = now.Ticks;
                payLoad.tid = timestamp  + payLoad.UserId;
                payLoad.merchant_id = Convert.ToInt64(Configuration["Payment:merchant_id"]);
                payLoad.order_id = timestamp.ToString()+"R"+payLoad.RequestId +"U"+ payLoad.UserId;

                payLoad.redirect_url = Configuration["Payment:redirect_url"];

                payLoad.cancel_url = Configuration["Payment:cancel_url"];
                string ccaRequest = $"tid={payLoad.tid}&merchant_id={payLoad.merchant_id}&order_id={payLoad.order_id}&amount={payLoad.amount}&currency={HttpUtility.UrlEncode(payLoad.currency)}&redirect_url={HttpUtility.UrlEncode(payLoad.redirect_url)}&cancel_url={HttpUtility.UrlEncode(payLoad.cancel_url)}&language={HttpUtility.UrlEncode(payLoad.language)}&";
                Service.Models.PaymentPayLoad payloadService = new Service.Models.PaymentPayLoad();
                payloadService.merchant_id=  payLoad.merchant_id;
                payloadService.tid = payLoad.tid;
                payloadService.redirect_url = payLoad.redirect_url;
                payloadService.amount = payLoad.amount;
                payloadService.cancel_url = payLoad.cancel_url;
                payloadService.order_id = payLoad.order_id;
                payloadService.language = payLoad.language;
                payloadService.RequestId = payLoad.RequestId;
                payloadService.UserId = payLoad.UserId;
                payloadService.currency = payLoad.currency;
                payloadService.RequestUrl = payLoad.RequestUrl;//used for redirection to page from which request was generated from 
                _IpaymentService.InsertPaymentRequest(payloadService);
                PaymentPayloadEncResponse paymentPayloadEncResponse = new PaymentPayloadEncResponse();
                paymentPayloadEncResponse.strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);
                return new JsonResult(new { data = paymentPayloadEncResponse, status = HttpStatusCode.OK });
            }
            catch (Exception es)
            {

            }
            return BadRequest();
        }

        
        [HttpPost]
        [Route("PaymentResponse")]
        public IActionResult ProcessResponse([FromForm] PaymentDecResponse data)
        {
            try
            {
                if (data == null)
                {
                    return BadRequest("Invalid request data");
                }
                string workingKey = Configuration["Payment:workingKey"]; // Your working key
                CCACrypto ccaCrypto = new CCACrypto();
                string encResponse = ccaCrypto.Decrypt(data.encResp, workingKey);
                NameValueCollection Params = new NameValueCollection();
                string[] segments = encResponse.Split('&');

                foreach (string seg in segments)
                {
                    string[] parts = seg.Split('=');
                    if (parts.Length > 0)
                    {
                        string Key = parts[0].Trim();
                        string Value = parts[1].Trim();
                        Params.Add(Key, Value);
                    }
                }

                // Now, map the values to your class properties

                Service.Models.PaymentdecryptResponseModel responseModel = new Service.Models.PaymentdecryptResponseModel();
               

                responseModel.order_id = Params["order_id"];
                responseModel.tracking_id = Params["tracking_id"];
                responseModel.bank_ref_no = Params["bank_ref_no"];
                responseModel.order_status = Params["order_status"];
                responseModel.failure_message = Params["failure_message"];
                responseModel.payment_mode = Params["payment_mode"];
                responseModel.card_name = Params["card_name"];
                responseModel.status_code = Params["status_code"];
                responseModel.status_message = Params["status_message"];
                responseModel.currency = Params["currency"];
                responseModel.amount = Params["amount"];
                responseModel.billing_name = Params["billing_name"];
                responseModel.billing_address = Params["billing_address"];
                responseModel.billing_city = Params["billing_city"];
                responseModel.billing_state = Params["billing_state"];
                responseModel.billing_zip = Params["billing_zip"];
                responseModel.billing_country = Params["billing_country"];
                responseModel.billing_tel = Params["billing_tel"];
                responseModel.billing_email = Params["billing_email"];
                responseModel.merchant_param1 = Params["merchant_param1"];
                responseModel.merchant_param2 = Params["merchant_param2"];
                responseModel.merchant_param3 = Params["merchant_param3"];
                responseModel.merchant_param4 = Params["merchant_param4"];
                responseModel.merchant_param5 = Params["merchant_param5"];
                responseModel.vault = Params["vault"];
                responseModel.offer_type = Params["offer_type"];
                responseModel.offer_code = Params["offer_code"];
                responseModel.discount_value = Params["discount_value"];
                responseModel.mer_amount = Params["mer_amount"];
                responseModel.eci_value = Params["eci_value"];
                responseModel.retry = Params["retry"];
                responseModel.response_code = Convert.ToInt32(Params["response_code"]);
                responseModel.billing_notes = Params["billing_notes"];
                responseModel.trans_date = Params["trans_date"];
                responseModel.bin_country = Params["bin_country"];
                responseModel.card_type = Params["card_type"];
                responseModel.saveCard = Params["saveCard"];
                responseModel.order_date_time = Params["order_date_time"];
                responseModel.token_number = Params["token_number"];
                responseModel.token_eligibility = Params["token_eligibility"];
                responseModel.merchant_param6 = Params["merchant_param6"];
                responseModel.merchant_param7 = Params["merchant_param7"];
                _IpaymentService.InsertIntoPaymentResponse(responseModel);


                string[] responseUsersegments = responseModel.order_id.Split('U');
                string[] responseRequestsegments = responseUsersegments[0].Split('R');

                var getRequestDetail = _IpaymentService.GetPaymentRequestDetail(responseRequestsegments[1]);
                var url = Configuration["Payment:AngularResponseUrl"].ToString() + getRequestDetail.RequestUrl;
                return RedirectPermanent(url);
            }
            catch (Exception es)
            {

            }
            return BadRequest();
        }

        [HttpGet]
        [Route("GetPaymentResponse")]
        public IActionResult GetPaymentResponse(int pageSize, int pageNumber, string? SearchText)
        {
            try
            {
                var paymentModel = _IpaymentService.GetPaymentResponse(pageSize, pageNumber, SearchText);
                return new JsonResult(new { data = paymentModel, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });

            }
        }


    }
}
