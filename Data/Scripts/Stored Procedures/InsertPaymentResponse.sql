USE [SJCESP_DEV]
GO

/****** Object:  StoredProcedure [dbo].[InsertPaymentResponse]    Script Date: 11/20/2023 5:54:59 AM ******/
DROP PROCEDURE [dbo].[InsertPaymentResponse]
GO

/****** Object:  StoredProcedure [dbo].[InsertPaymentResponse]    Script Date: 11/20/2023 5:54:59 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[InsertPaymentResponse]      
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
    SELECT @RequestId = [RequestId] FROM [SJCESP_DEV].[dbo].[PaymentRequest] WHERE order_id = @order_id;

    DECLARE @PaymentRequestId BIGINT;
    SELECT @PaymentRequestId = [PaymentRequestId] FROM [SJCESP_DEV].[dbo].[PaymentRequest] WHERE order_id = @order_id;

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
        (SELECT [UserName] FROM [SJCESP_DEV].[dbo].[SEC_Users] WHERE [UserId] = (SELECT [UserId] FROM [SJCESP_DEV].[dbo].[PaymentRequest] WHERE order_id = @order_id)),
        CONCAT(@order_status, ' ', @status_message),
        1,
        @amount,
        @order_id,
        @PaymentRequestId
    );
END
GO


