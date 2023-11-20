USE [SJCESP_DEV]
GO

/****** Object:  StoredProcedure [dbo].[InsertPaymentRequest]    Script Date: 11/20/2023 5:54:38 AM ******/
DROP PROCEDURE [dbo].[InsertPaymentRequest]
GO

/****** Object:  StoredProcedure [dbo].[InsertPaymentRequest]    Script Date: 11/20/2023 5:54:38 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[InsertPaymentRequest]            
    @RequestNo Nvarchar(100),  
    @RequestId   BIGINT,               
    @UserId BIGINT,        
    @merchant_id BIGINT,          
    @order_id VARCHAR(255),          
    @amount DECIMAL,          
    @currency VARCHAR(255),          
    @redirect_url VARCHAR(255),          
    @cancel_url VARCHAR(255),          
    @language VARCHAR(255) ,        
    @RequestFromUrl varchar(max) -- used for redirection back to angular after sucess or failure of payment Request        
AS          
BEGIN          
 DECLARE @UserName VARCHAR(155);
    SELECT @UserName = [UserName] FROM [SJCESP_DEV].[dbo].[SEC_Users] WHERE UserId = @UserId;
Declare @tid Bigint;

 INSERT INTO [dbo].[PaymentRequest]
           ([RequestId]
           ,[RequestNo]
           ,[merchantid]
           ,[currency]
           ,[redirect_url]
           ,[cancel_url]
           ,[language]
           ,[order_id]
		   ,[RequestFromUrl]
		   ,[CreatedDate]
		   ,[CreatedBy]
           ,[UserId])
     VALUES
           (@RequestId
           ,@RequestNo
           ,@merchant_id
           ,@currency
           ,@redirect_url
           ,@cancel_url
           ,@language
           ,@order_id
		   ,@RequestFromUrl
		   ,GETDATE()
		   ,@UserName 
           ,@UserId)
     
SET @tid = SCOPE_IDENTITY();
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
           ,@UserName
           ,Concat('Payment Request has been sent to payment gateway amount = ',@amount)    
           ,1    
           ,@amount    
           ,@order_id    
           ,@tid)      
END;  
GO


