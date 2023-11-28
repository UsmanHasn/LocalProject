    
Alter PROCEDURE [dbo].[GetPaymentRequestDetail]    
 @orderId NVARCHAR(30)  
AS        
BEGIN      
select top 1 RequestFromUrl as RequestUrl ,RequestId  from [SJCESP_DEV].[dbo].[PaymentRequest] where order_id = @orderId  order by PaymentRequestId desc  
END