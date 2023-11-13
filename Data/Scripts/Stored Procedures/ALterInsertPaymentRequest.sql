
Alter PROCEDURE [dbo].[InsertPaymentRequest]        
      @RequestId Nvarchar(25),      
    @UserId BIGINT,      
    @tid BIGINT,      
    @merchant_id BIGINT,      
    @order_id VARCHAR(255),      
    @amount DECIMAL,      
    @currency VARCHAR(255),      
    @redirect_url VARCHAR(255),      
    @cancel_url VARCHAR(255),      
    @language VARCHAR(255) ,    
 @RequestUrl varchar(max) -- used for redirection back to angular after sucess or failure of payment Request    
AS      
BEGIN      
    INSERT INTO [PaymentRequest] (RequestId, UserId, tid, merchant_id, order_id, amount, currency, redirect_url, cancel_url, language,RequestUrl)      
    VALUES (@RequestId, @UserId, @tid, @merchant_id, @order_id, @amount, @currency, @redirect_url, @cancel_url, @language,@RequestUrl);    
	
	

INSERT INTO [dbo].[RequestEventLog]
           ([RequestId]
           ,[LoggedOn]
           ,[LoggedBy]
           ,[Description]
           ,[ShowToRequestor]
           ,[Amount]
           ,[RefNo]
           ,[PaymentRequestId])
     VALUES
           (@RequestId
           ,Getdate()
           ,(select [UserName] from [SJCESP_DEV].[dbo].[SEC_Users] where [UserId]= @UserId)
           ,'Payment Request has been sent to payment gateway'
           ,1
           ,@amount
           ,@order_id
           ,@tid)  
END;
