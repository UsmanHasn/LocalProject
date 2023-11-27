Alter PROCEDURE [dbo].[InsertPaymentResponse]        
    @order_id VARCHAR(50),  
    @tracking_id VARCHAR(50),  
    @bank_ref_no VARCHAR(50),  
    @order_status VARCHAR(50),  
    @failure_message TEXT,  
    @payment_mode VARCHAR(50),  
    @card_name VARCHAR(50),  
    @status_code VARCHAR(50),  
    @status_message TEXT,  
    @currency VARCHAR(10),  
    @amount DECIMAL(10, 3),  
    @billing_name VARCHAR(100),  
    @billing_address TEXT,  
    @billing_city VARCHAR(50),  
    @billing_state VARCHAR(50),  
    @billing_zip VARCHAR(20),  
    @billing_country VARCHAR(50),  
    @billing_tel VARCHAR(20),  
    @billing_email VARCHAR(100),  
    @merchant_param1 VARCHAR(100),  
    @merchant_param2 VARCHAR(100),  
    @merchant_param3 VARCHAR(100),  
    @merchant_param4 VARCHAR(100),  
    @merchant_param5 VARCHAR(100),  
    @discount_value DECIMAL(10, 2),  
    @mer_amount DECIMAL(10, 3),  
    @retry VARCHAR(10),  
    @response_code VARCHAR(50),  
    @bin_country VARCHAR(50),  
    @card_type VARCHAR(50),  
    @saveCard CHAR(1)  
AS  
BEGIN  
    SET NOCOUNT ON;  
  
    DECLARE @RequestId BIGINT;  
    DECLARE @PaymentRequestId BIGINT;
    DECLARE @LoggedBy VARCHAR(155);

    -- Extract RequestId and PaymentRequestId based on order_id
    SELECT @RequestId = [RequestId], @PaymentRequestId = [PaymentRequestId] 
    FROM [SJCESP_DEV].[dbo].[PaymentRequest] 
    WHERE order_id = @order_id;  

    -- Extracting UserName based on UserId
    SELECT @LoggedBy = [UserName] 
    FROM [SJCESP_DEV].[dbo].[SEC_Users] 
    WHERE [UserId] = (SELECT [UserId] FROM [SJCESP_DEV].[dbo].[PaymentRequest] WHERE order_id = @order_id);

    -- Update CaseStatusId in 'requests' table
    UPDATE requests 
    SET CaseStatusId = 12 
    WHERE CaseId = @PaymentRequestId;

    -- Insert into PaymentResponse table
    INSERT INTO [SJCESP_DEV].[dbo].[PaymentResponse] (  
        PaymentRequestId,  
        order_id,  
        tracking_id,
        bank_ref_no,
        order_status,
        failure_message,
        payment_mode,
        card_name,
        status_code,
        status_message,
        currency,
        amount,
        billing_name,
        billing_address,
        billing_city,
        billing_state,
        billing_zip,
        billing_country,
        billing_tel,
        billing_email,
        merchant_param1,
        merchant_param2,
        merchant_param3,
        merchant_param4,
        merchant_param5,
        discount_value,
        mer_amount,
        retry,
        response_code,
        trans_date,
        bin_country,
        card_type,
        saveCard,
        order_date_time  
    )  
    VALUES (  
        @PaymentRequestId,  
        @order_id,  
        @tracking_id,
        @bank_ref_no,
        @order_status,
        @failure_message,
        @payment_mode,
        @card_name,
        @status_code,
        @status_message,
        @currency,
        @amount,
        @billing_name,
        @billing_address,
        @billing_city,
        @billing_state,
        @billing_zip,
        @billing_country,
        @billing_tel,
        @billing_email,
        @merchant_param1,
        @merchant_param2,
        @merchant_param3,
        @merchant_param4,
        @merchant_param5,
        @discount_value,
        @mer_amount,
        @retry,
        @response_code,
        GETDATE(),
        @bin_country,
        @card_type,
        @saveCard,
        GETDATE()
    );  
    
    -- Insert into RequestEventLog table
    INSERT INTO [dbo].[RequestEventLog]    
    (  
        [RequestId],  
        [LoggedOn],  
        [LoggedBy],  
        [Description],  
        [ShowToRequestor],  
        [Amount],  
        [RefNo],  
        [PaymentRequestId]  
    )    
    VALUES    
    (  
        @RequestId,  
        GETDATE(),  
        @LoggedBy,  
        CONCAT(@order_status, ' ', @status_message,' for amount =',@amount ,', order number =',@order_id,' tracking no = ' ,@tracking_id),  
        1,  
        @amount,  
        @order_id,  
        @PaymentRequestId  
    );  
END;
