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
        public bool InsertIntoPaymentResponse(PaymentdecryptResponseModel paymentdecryptResponse)
        {  // Create an array of SqlParameter objects to pass the values
            SqlParameter[] spParams = new SqlParameter[42]; // Adjust the size based on the number of parameters in your stored procedure


            string[] responseUsersegments = paymentdecryptResponse.order_id.Split('U');
            string[] responseRequestsegments = responseUsersegments[0].Split('R');
            spParams[0] = new SqlParameter("@order_id", paymentdecryptResponse.order_id);
            spParams[1] = new SqlParameter("@tracking_id", paymentdecryptResponse.tracking_id);
            spParams[2] = new SqlParameter("@bank_ref_no", paymentdecryptResponse.bank_ref_no);
            spParams[3] = new SqlParameter("@order_status", paymentdecryptResponse.order_status);
            spParams[4] = new SqlParameter("@failure_message", paymentdecryptResponse.failure_message);
            spParams[5] = new SqlParameter("@payment_mode", paymentdecryptResponse.payment_mode);
            spParams[6] = new SqlParameter("@card_name", paymentdecryptResponse.card_name);
            spParams[7] = new SqlParameter("@status_code", paymentdecryptResponse.status_code);
            spParams[8] = new SqlParameter("@status_message", paymentdecryptResponse.status_message);
            spParams[9] = new SqlParameter("@currency", paymentdecryptResponse.currency);
            spParams[10] = new SqlParameter("@amount", paymentdecryptResponse.amount);
            spParams[11] = new SqlParameter("@billing_name", paymentdecryptResponse.billing_name);
            spParams[12] = new SqlParameter("@billing_address", paymentdecryptResponse.billing_address);
            spParams[13] = new SqlParameter("@billing_city", paymentdecryptResponse.billing_city);
            spParams[14] = new SqlParameter("@billing_state", paymentdecryptResponse.billing_state);
            spParams[15] = new SqlParameter("@billing_zip", paymentdecryptResponse.billing_zip);
            spParams[16] = new SqlParameter("@billing_country", paymentdecryptResponse.billing_country);
            spParams[17] = new SqlParameter("@billing_tel", paymentdecryptResponse.billing_tel);
            spParams[18] = new SqlParameter("@billing_email", paymentdecryptResponse.billing_email);
            spParams[19] = new SqlParameter("@merchant_param1", paymentdecryptResponse.merchant_param1);
            spParams[20] = new SqlParameter("@merchant_param2", paymentdecryptResponse.merchant_param2);
            spParams[21] = new SqlParameter("@merchant_param3", paymentdecryptResponse.merchant_param3);
            spParams[22] = new SqlParameter("@merchant_param4", paymentdecryptResponse.merchant_param4);
            spParams[23] = new SqlParameter("@merchant_param5", paymentdecryptResponse.merchant_param5);
            spParams[24] = new SqlParameter("@vault", paymentdecryptResponse.vault);
            spParams[25] = new SqlParameter("@offer_type", paymentdecryptResponse.offer_type);
            spParams[26] = new SqlParameter("@offer_code", paymentdecryptResponse.offer_code);
            spParams[27] = new SqlParameter("@discount_value", paymentdecryptResponse.discount_value);
            spParams[28] = new SqlParameter("@mer_amount", paymentdecryptResponse.mer_amount);
            spParams[29] = new SqlParameter("@eci_value", paymentdecryptResponse.eci_value);
            spParams[30] = new SqlParameter("@retry", paymentdecryptResponse.retry);
            spParams[31] = new SqlParameter("@response_code", paymentdecryptResponse.response_code);
            spParams[32] = new SqlParameter("@billing_notes", paymentdecryptResponse.billing_notes);
            spParams[33] = new SqlParameter("@trans_date", paymentdecryptResponse.trans_date);
            spParams[34] = new SqlParameter("@bin_country", paymentdecryptResponse.bin_country);
            spParams[35] = new SqlParameter("@card_type", paymentdecryptResponse.card_type);
            spParams[36] = new SqlParameter("@saveCard", paymentdecryptResponse.saveCard);
            spParams[37] = new SqlParameter("@order_date_time", paymentdecryptResponse.order_date_time);
            spParams[38] = new SqlParameter("@token_number", paymentdecryptResponse.token_number);
            spParams[39] = new SqlParameter("@token_eligibility", paymentdecryptResponse.token_eligibility);
            spParams[40] = new SqlParameter("@Request_Id", responseRequestsegments[1]);
            spParams[41] = new SqlParameter("@UserId", responseUsersegments[1]);
            _PaymentdecryptResponseRepository.ExecuteStoredProcedure("InsertPaymentResponse", spParams);
            return true;

        }

        public bool InsertPaymentRequest(PaymentPayLoad PaymentPayLoad)
        { // Create an array of SqlParameter objects to pass the values
            try
            {
                SqlParameter[] spParams = new SqlParameter[11]; // Adjust the size based on the number of parameters in your stored procedure

                spParams[0] = new SqlParameter("@RequestId ", PaymentPayLoad.RequestId);
                spParams[1] = new SqlParameter("@UserId ", PaymentPayLoad.UserId);
                spParams[2] = new SqlParameter("@tid", PaymentPayLoad.tid);
                spParams[3] = new SqlParameter("@merchant_id", PaymentPayLoad.merchant_id);
                spParams[4] = new SqlParameter("@order_id ", PaymentPayLoad.order_id);
                spParams[5] = new SqlParameter("@amount ", PaymentPayLoad.amount);
                spParams[6] = new SqlParameter("@currency ", PaymentPayLoad.currency);
                spParams[7] = new SqlParameter("@redirect_url ", PaymentPayLoad.redirect_url);
                spParams[8] = new SqlParameter("@cancel_url ", PaymentPayLoad.cancel_url);
                spParams[9] = new SqlParameter("@language ", PaymentPayLoad.language);
                spParams[10] = new SqlParameter("@RequestUrl ", PaymentPayLoad.RequestUrl);
                _PaymentdecryptResponseRepository.ExecuteStoredProcedure("InsertPaymentRequest", spParams);
            }
            catch (Exception e)
            {

            }
            return true;
        }

        public PaymentPayLoad GetPaymentRequestDetail(string requestId)
        {
            try
            {
                SqlParameter[] param = new SqlParameter[1];
                param[0] = new SqlParameter("requestId", requestId);
                return _PaymentdecryptResponseRepository.ExecuteStoredProcedure<PaymentPayLoad>("GetPaymentResponse", param).FirstOrDefault();
            }
            catch (Exception ex)
            {

            }
            return null;

        }
    }
}
