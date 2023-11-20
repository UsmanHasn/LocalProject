USE [SJCESP_DEV]
GO

/****** Object:  StoredProcedure [dbo].[GetPaymentResponse]    Script Date: 11/20/2023 5:54:18 AM ******/
DROP PROCEDURE [dbo].[GetPaymentResponse]
GO

/****** Object:  StoredProcedure [dbo].[GetPaymentResponse]    Script Date: 11/20/2023 5:54:18 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[GetPaymentResponse]    
  @orderId NVARCHAR(30) =null,  
  @SearchText NVARCHAR(MAX) = NULL,   -- The text to search for    
  @PageSize INT = 500,    
  @PageNumber INT = 1    
AS    
BEGIN    
  DECLARE @Offset INT    
  SET @Offset = (@PageNumber - 1) * @PageSize    
    
  -- Query to retrieve paginated PaymentResponse data    
  SELECT    
    order_id, tracking_id, bank_ref_no, order_status, failure_message,    
    payment_mode, card_name, status_code, status_message, currency,    
    amount, billing_name, billing_address, billing_city, billing_state,    
    billing_zip, billing_country, billing_tel, billing_email,    
    merchant_param1, merchant_param2, merchant_param3, merchant_param4,    
    merchant_param5, discount_value,    
    mer_amount, retry, response_code,    
    trans_date, bin_country, card_type, saveCard, order_date_time  
  FROM PaymentResponse    
  WHERE    
    (    
      (    
        @SearchText IS NULL OR    
        (    
          order_id LIKE N'%' + @SearchText + N'%' OR    
          tracking_id LIKE N'%' + @SearchText + N'%' OR    
          bank_ref_no LIKE N'%' + @SearchText + N'%' OR    
          order_status LIKE N'%' + @SearchText + N'%' OR    
          failure_message LIKE N'%' + @SearchText + N'%' OR    
          payment_mode LIKE N'%' + @SearchText + N'%' OR    
          card_name LIKE N'%' + @SearchText + N'%' OR    
          status_code LIKE N'%' + @SearchText + N'%' OR    
          status_message LIKE N'%' + @SearchText + N'%' OR    
          currency LIKE N'%' + @SearchText + N'%' OR    
          amount LIKE N'%' + @SearchText + N'%' OR    
          billing_name LIKE N'%' + @SearchText + N'%' OR    
          billing_address LIKE N'%' + @SearchText + N'%' OR    
          billing_city LIKE N'%' + @SearchText + N'%' OR    
          billing_state LIKE N'%' + @SearchText + N'%' OR    
          billing_zip LIKE N'%' + @SearchText + N'%' OR    
          billing_country LIKE N'%' + @SearchText + N'%' OR    
          billing_tel LIKE N'%' + @SearchText + N'%' OR    
          billing_email LIKE N'%' + @SearchText + N'%' OR    
          merchant_param1 LIKE N'%' + @SearchText + N'%' OR    
          merchant_param2 LIKE N'%' + @SearchText + N'%' OR    
          merchant_param3 LIKE N'%' + @SearchText + N'%' OR    
          merchant_param4 LIKE N'%' + @SearchText + N'%' OR    
          merchant_param5 LIKE N'%' + @SearchText + N'%' OR    
           
          discount_value LIKE N'%' + @SearchText + N'%' OR    
          mer_amount LIKE N'%' + @SearchText + N'%' OR    
         
          retry LIKE N'%' + @SearchText + N'%' OR    
          response_code LIKE N'%' + @SearchText + N'%' OR    
          trans_date LIKE N'%' + @SearchText + N'%' OR    
          bin_country LIKE N'%' + @SearchText + N'%' OR    
          card_type LIKE N'%' + @SearchText + N'%' OR    
          saveCard LIKE N'%' + @SearchText + N'%' OR    
          order_date_time LIKE N'%' + @SearchText + N'%'  
        )    
      )    
    )  and order_id = isnull(@orderId,order_id)  
  ORDER BY order_id  -- Replace with the column you want to order by    
  OFFSET @Offset ROWS    
  FETCH NEXT @PageSize ROWS ONLY    
    
END 
GO


