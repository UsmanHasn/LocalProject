USE [SJCESP_DEV]
GO

/****** Object:  StoredProcedure [dbo].[GetPaymentRequestDetail]    Script Date: 11/20/2023 5:53:54 AM ******/
DROP PROCEDURE [dbo].[GetPaymentRequestDetail]
GO

/****** Object:  StoredProcedure [dbo].[GetPaymentRequestDetail]    Script Date: 11/20/2023 5:53:54 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

  
CREATE PROCEDURE [dbo].[GetPaymentRequestDetail]  
 @orderId NVARCHAR(30)
AS      
BEGIN    
select RequestFromUrl  as RequestUrl from [SJCESP_DEV].[dbo].[PaymentRequest] where order_id = @orderId  
END
GO


