Create TABLE [dbo].[PaymentRequest](
RequestId BIGINT,
    UserId BIGINT,
    tid BIGINT,
    merchant_id BIGINT,
    order_id VARCHAR(255),
    amount DECIMAL,
    currency VARCHAR(255),
    redirect_url VARCHAR(255),
    cancel_url VARCHAR(255),
    language VARCHAR(255)
)

Create PROCEDURE [dbo].[InsertPaymentRequest]  
      @RequestId BIGINT,
    @UserId BIGINT,
    @tid BIGINT,
    @merchant_id BIGINT,
    @order_id VARCHAR(255),
    @amount DECIMAL,
    @currency VARCHAR(255),
    @redirect_url VARCHAR(255),
    @cancel_url VARCHAR(255),
    @language VARCHAR(255)
AS
BEGIN
    INSERT INTO [PaymentRequest] (RequestId, UserId, tid, merchant_id, order_id, amount, currency, redirect_url, cancel_url, language)
    VALUES (@RequestId, @UserId, @tid, @merchant_id, @order_id, @amount, @currency, @redirect_url, @cancel_url, @language);
END;


alter PROCEDURE [dbo].[InsertPaymentRequest]  
    @order_id VARCHAR(255) null,   
    @tracking_id VARCHAR(255)null,   
    @bank_ref_no VARCHAR(255)null,   
    @order_status VARCHAR(255)null,   
    @failure_message VARCHAR(255)null,   
    @payment_mode VARCHAR(255)null,   
    @card_name VARCHAR(255)null,   
    @status_code VARCHAR(255)null,   
    @status_message VARCHAR(255)null,   
    @currency VARCHAR(255)null,   
    @amount VARCHAR(255)null,   
    @billing_name VARCHAR(255)null,   
    @billing_address VARCHAR(255)null,   
    @billing_city VARCHAR(255)null,   
    @billing_state VARCHAR(255)null,   
    @billing_zip VARCHAR(255)null,   
    @billing_country VARCHAR(255)null,   
    @billing_tel VARCHAR(255)null,   
    @billing_email VARCHAR(255)null,   
    @merchant_param1 VARCHAR(255)null,   
    @merchant_param2 VARCHAR(255)null,   
    @merchant_param3 VARCHAR(255)null,   
    @merchant_param4 VARCHAR(255)null,   
    @merchant_param5 VARCHAR(255)null,   
    @vault VARCHAR(255)null,   
    @offer_type VARCHAR(255)null,   
    @offer_code VARCHAR(255)null,   
    @discount_value VARCHAR(255)null,   
    @mer_amount VARCHAR(255)null,   
    @eci_value VARCHAR(255)null,   
    @retry VARCHAR(255)null,   
    @response_code INT null,   
    @billing_notes VARCHAR(255)null,   
    @trans_date VARCHAR(255)null,   
    @bin_country VARCHAR(255)null,   
    @card_type VARCHAR(255)null,   
    @saveCard VARCHAR(255)null,   
    @order_date_time VARCHAR(255)null,   
    @token_number VARCHAR(255)null,   
    @token_eligibility VARCHAR(255)null,
	@Request_Id Bigint,
	@UserId Bigint
AS  
BEGIN  
    INSERT INTO PaymentResponse (order_id, tracking_id, bank_ref_no, order_status, failure_message, payment_mode, card_name, status_code, status_message, currency, amount, billing_name, billing_address, billing_city, billing_state, billing_zip, billing_country, billing_tel, billing_email, merchant_param1, merchant_param2, merchant_param3, merchant_param4, merchant_param5, vault, offer_type, offer_code, discount_value, mer_amount, eci_value, retry, response_code, billing_notes, trans_date, bin_country, card_type, saveCard, order_date_time, token_number, token_eligibility,Request_Id,UserId)  
    VALUES (@order_id, @tracking_id, @bank_ref_no, @order_status, @failure_message, @payment_mode, @card_name, @status_code, @status_message, @currency, @amount, @billing_name, @billing_address, @billing_city, @billing_state, @billing_zip, @billing_country, @billing_tel, @billing_email, @merchant_param1, @merchant_param2, @merchant_param3, @merchant_param4, @merchant_param5, @vault, @offer_type, @offer_code, @discount_value, @mer_amount, @eci_value, @retry, @response_code, @billing_notes, @trans_date, @bin_country, @card_type, @saveCard, @order_date_time, @token_number, @token_eligibility,@Request_Id,@UserId);  
END  