create PROCEDURE [dbo].[GetPaymentRequestDetail]
 @RequestId Bigint
AS    
BEGIN  
select RequestUrl from [SJCESP_DEV].[dbo].[PaymentRequest] where RequestId = @RequestId
END