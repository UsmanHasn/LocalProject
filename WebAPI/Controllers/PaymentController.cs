using CCAV.Util;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Service.Interface;
using Service.Models;
using System;
using System.Collections.Specialized;
using System.Net;
using System.Reflection;
using System.Web;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/Payment")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService _paymentService;
        private readonly IConfiguration _configuration;

        public PaymentController(IPaymentService paymentService, IConfiguration configuration)
        {
            _paymentService = paymentService ?? throw new ArgumentNullException(nameof(paymentService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpPost]
        [Route("PaymentPayLoadEnc")]
        public IActionResult PaymentPayLoadEnc(Service.Models.PaymentPayLoad payLoad)
        {
            try
            {
                string workingKey = _configuration["Payment:workingKey"];
                if (string.IsNullOrEmpty(workingKey))
                    return BadRequest("Working key not found.");

                CCACrypto ccaCrypto = new CCACrypto();
                long timestamp = DateTime.Now.Ticks;
                payLoad.tid = timestamp + payLoad.UserId;
                payLoad.merchant_id = Convert.ToInt64(_configuration["Payment:merchant_id"]);
                payLoad.order_id = $"{timestamp}R{payLoad.UserId}";

                payLoad.redirect_url = _configuration["Payment:redirect_url"];
                payLoad.cancel_url = _configuration["Payment:cancel_url"];

                string ccaRequest = $"tid={payLoad.tid}&merchant_id={payLoad.merchant_id}&order_id={payLoad.order_id}&merchant_param1={payLoad.RequestId}&merchant_param2={payLoad.RequestNo}&amount={payLoad.amount}&currency={HttpUtility.UrlEncode(payLoad.currency)}&redirect_url={HttpUtility.UrlEncode(payLoad.redirect_url)}&cancel_url={HttpUtility.UrlEncode(payLoad.cancel_url)}&language={HttpUtility.UrlEncode(payLoad.language)}&";

                _paymentService.InsertPaymentRequest(payLoad);

                PaymentPayloadEncResponse paymentPayloadEncResponse = new PaymentPayloadEncResponse();
                paymentPayloadEncResponse.strEncRequest = ccaCrypto.Encrypt(ccaRequest, workingKey);

                return new JsonResult(new { data = paymentPayloadEncResponse, status = HttpStatusCode.OK });
            }
            catch (Exception ex)
            {
                // Log the exception
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
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
                    string workingKey = _configuration["Payment:workingKey"]; // Your working key
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
                    Service.Models.PaymentdecryptResponseModel responseModel = new Service.Models.PaymentdecryptResponseModel();
                    responseModel.OrderId = Params["order_id"];
                    responseModel.TrackingId = Params["tracking_id"];
                    responseModel.BankRefNo = Params["bank_ref_no"];
                    responseModel.OrderStatus = Params["order_status"];
                    responseModel.FailureMessage = Params["failure_message"];
                    responseModel.PaymentMode = Params["payment_mode"];
                    responseModel.CardName = Params["card_name"];
                    responseModel.StatusCode = Params["status_code"];
                    responseModel.StatusMessage = Params["status_message"];
                    responseModel.Currency = Params["currency"];
                    responseModel.Amount = Convert.ToDecimal(Params["amount"]);
                    responseModel.BillingName = Params["billing_name"];
                    responseModel.BillingAddress = Params["billing_address"];
                    responseModel.BillingCity = Params["billing_city"];
                    responseModel.BillingState = Params["billing_state"];
                    responseModel.BillingZip = Params["billing_zip"];
                    responseModel.BillingCountry = Params["billing_country"];
                    responseModel.BillingTel = Params["billing_tel"];
                    responseModel.BillingEmail = Params["billing_email"];
                    responseModel.MerchantParam1 = Params["merchant_param1"];
                    responseModel.MerchantParam2 = Params["merchant_param2"];
                    responseModel.MerchantParam3 = Params["merchant_param3"];
                    responseModel.MerchantParam4 = Params["merchant_param4"];
                    responseModel.MerchantParam5 = Params["merchant_param5"];
                    responseModel.DiscountValue = Convert.ToDecimal(Params["discount_value"]);
                    responseModel.MerAmount = Convert.ToDecimal(Params["mer_amount"]);
                    responseModel.Retry = Params["retry"];
                    responseModel.ResponseCode = Params["response_code"];
                    responseModel.BinCountry = Params["bin_country"];
                    responseModel.CardType = Params["card_type"];
                    responseModel.SaveCard = Convert.ToChar(Params["saveCard"]);


                    _paymentService.InsertIntoPaymentResponse(responseModel);


                    var getRequestDetail = _paymentService.GetPaymentRequestDetail(responseModel.OrderId);
                    var url = $"{_configuration["Payment:AngularResponseUrl"]}{getRequestDetail.RequestUrl}&order_id={responseModel.OrderId}";

                    return RedirectPermanent(url);
                }
                catch (Exception ex)
                {
                // Log the exception
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
            }

        [HttpGet]
            [Route("GetPaymentResponse")]
            public IActionResult GetPaymentResponse(int pageSize, int pageNumber, string? SearchText)
            {
                try
                {
                    var paymentModel = _paymentService.GetPaymentResponse(pageSize, pageNumber, SearchText);
                    return new JsonResult(new { data = paymentModel, status = HttpStatusCode.OK });
                }
                catch (Exception ex)
                {
                // Log the exception
                return new JsonResult(new { data = ex, status = HttpStatusCode.InternalServerError });
            }
            }
        }
    }
