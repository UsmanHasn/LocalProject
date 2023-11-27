using Data.Interface;
using Domain.Entities;
using Domain.Entities.Lookups;
using Microsoft.Data.SqlClient;
using Service.Interface;
using Service.Models;
using Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using Org.BouncyCastle.Utilities;
using System.Security.Cryptography;
using MailKit.Search;
using System.Drawing.Printing;
using System.Reflection;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace Service.Concrete
{
    public class PaymentService : IPaymentService
    {

        private readonly IRepository<PaymentdecryptResponse> _PaymentdecryptResponseRepository;

        public PaymentService(IRepository<Domain.Entities.PaymentdecryptResponse> PaymentdecryptResponseRepository)
        {
            _PaymentdecryptResponseRepository = PaymentdecryptResponseRepository;
        }

        public PaginatedTransactionModel GetPaymentResponse(int pageSize, int pageNumber, string? SearchText)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[3];
                param[0] = new SqlParameter("pageSize", pageSize);
                param[1] = new SqlParameter("pageNumber", pageNumber);
                param[2] = new SqlParameter("SearchText", SearchText);
                var data = _PaymentdecryptResponseRepository.ExecuteStoredProcedure<PaymentdecryptResponseModel>("GetPaymentResponse", param).ToList();
                int countItem = 0;
                if (SearchText != null)
                {
                    SqlParameter[] paramSearch = new SqlParameter[1];
                    paramSearch[0] = new SqlParameter("SearchText", SearchText);

                    var count = _PaymentdecryptResponseRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetPaymentResponseCount", paramSearch).FirstOrDefault();
                    countItem = count.TotalCount;
                }
                else
                {
                    var count = _PaymentdecryptResponseRepository.ExecuteStoredProcedure<TotalCountModel>("sjc_GetPaymentResponseCount").FirstOrDefault();
                    countItem = count.TotalCount;
                }
                PaginatedTransactionModel paginatedTransactionModel = new PaginatedTransactionModel()
                {
                    PaginatedData = data,
                    TotalCount = countItem
                };
                return paginatedTransactionModel;
            }
            catch (Exception ex)
            {

            }
            return null;
        }
        public bool InsertIntoPaymentResponse(PaymentdecryptResponseModel paymentDecryptResponse)
        {
            try
            {
                SqlParameter[] spParams = new SqlParameter[31];
                
                spParams[0] = new SqlParameter("@order_id", paymentDecryptResponse.OrderId);
                spParams[1] = new SqlParameter("@tracking_id", paymentDecryptResponse.TrackingId);
                spParams[2] = new SqlParameter("@bank_ref_no", paymentDecryptResponse.BankRefNo);
                spParams[3] = new SqlParameter("@order_status", paymentDecryptResponse.OrderStatus);
                spParams[4] = new SqlParameter("@failure_message", paymentDecryptResponse.FailureMessage);
                spParams[5] = new SqlParameter("@payment_mode", paymentDecryptResponse.PaymentMode);
                spParams[6] = new SqlParameter("@card_name", paymentDecryptResponse.CardName);
                spParams[7] = new SqlParameter("@status_code", paymentDecryptResponse.StatusCode);
                spParams[8] = new SqlParameter("@status_message", paymentDecryptResponse.StatusMessage);
                spParams[9] = new SqlParameter("@currency", paymentDecryptResponse.Currency);
                spParams[10] = new SqlParameter("@amount", paymentDecryptResponse.Amount);
                spParams[11] = new SqlParameter("@billing_name", paymentDecryptResponse.BillingName);
                spParams[12] = new SqlParameter("@billing_address", paymentDecryptResponse.BillingAddress);
                spParams[13] = new SqlParameter("@billing_city", paymentDecryptResponse.BillingCity);
                spParams[14] = new SqlParameter("@billing_state", paymentDecryptResponse.BillingState);
                spParams[15] = new SqlParameter("@billing_zip", paymentDecryptResponse.BillingZip);
                spParams[16] = new SqlParameter("@billing_country", paymentDecryptResponse.BillingCountry);
                spParams[17] = new SqlParameter("@billing_tel", paymentDecryptResponse.BillingTel);
                spParams[18] = new SqlParameter("@billing_email", paymentDecryptResponse.BillingEmail);
                // Map other parameters similarly
                spParams[19] = new SqlParameter("@merchant_param1", paymentDecryptResponse.MerchantParam1);
                spParams[20] = new SqlParameter("@merchant_param2", paymentDecryptResponse.MerchantParam2);
                spParams[21] = new SqlParameter("@merchant_param3", paymentDecryptResponse.MerchantParam3);
                spParams[22] = new SqlParameter("@merchant_param4", paymentDecryptResponse.MerchantParam4);
                spParams[23] = new SqlParameter("@merchant_param5", paymentDecryptResponse.MerchantParam5);
                spParams[24] = new SqlParameter("@discount_value", paymentDecryptResponse.DiscountValue);
                spParams[25] = new SqlParameter("@mer_amount", paymentDecryptResponse.MerAmount);
                spParams[26] = new SqlParameter("@retry", paymentDecryptResponse.Retry);
                spParams[27] = new SqlParameter("@response_code", paymentDecryptResponse.ResponseCode);
                spParams[28] = new SqlParameter("@bin_country", paymentDecryptResponse.BinCountry);
                spParams[29] = new SqlParameter("@card_type", paymentDecryptResponse.CardType);
                spParams[30] = new SqlParameter("@saveCard", paymentDecryptResponse.SaveCard);
            

                _PaymentdecryptResponseRepository.ExecuteStoredProcedure("InsertPaymentResponse", spParams);

                return true;
            }
            catch (Exception ex)
            {
                // Handle the exception
                return false;
            }
        }


        public bool InsertPaymentRequest(PaymentPayLoad PaymentPayLoad)
        { // Create an array of SqlParameter objects to pass the values
            try
            {


                SqlParameter[] spParams = new SqlParameter[11]; // Adjust the size based on the number of parameters in your stored procedure

                spParams[0] = new SqlParameter("@RequestId ", PaymentPayLoad.RequestId); // error that is why assigning default till db changes made 
                spParams[1] = new SqlParameter("@RequestNo", PaymentPayLoad.RequestNo);
                spParams[2] = new SqlParameter("@UserId", PaymentPayLoad.UserId);
                spParams[3] = new SqlParameter("@merchant_id", PaymentPayLoad.merchant_id);
                spParams[4] = new SqlParameter("@order_id", PaymentPayLoad.order_id);
                spParams[5] = new SqlParameter("@amount", PaymentPayLoad.amount);
                spParams[6] = new SqlParameter("@currency", PaymentPayLoad.currency);
                spParams[7] = new SqlParameter("@redirect_url", PaymentPayLoad.redirect_url);
                spParams[8] = new SqlParameter("@cancel_url", PaymentPayLoad.cancel_url);
                spParams[9] = new SqlParameter("@language", PaymentPayLoad.language);
                spParams[10] = new SqlParameter("@RequestFromUrl", PaymentPayLoad.RequestUrl);
                _PaymentdecryptResponseRepository.ExecuteStoredProcedure("InsertPaymentRequest", spParams);
            }
            catch (Exception e)
            {

            }
            return true;
        }

        public PaymentPayLoad GetPaymentRequestDetail(string orderId)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("@orderId", orderId);
                return _PaymentdecryptResponseRepository.ExecuteStoredProcedure<PaymentPayLoad>("GetPaymentRequestDetail", param).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return null;

        }
    }
}
