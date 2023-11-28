-- ================================================
-- Template generated from Template Explorer using:
-- Create Procedure (New Menu).SQL
--
-- Use the Specify Values for Template Parameters 
-- command (Ctrl-Shift-M) to fill in the parameter 
-- values below.
--
-- This block of comments will not be included in
-- the definition of the procedure.
-- ================================================
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE GetPaymentStatus
	@order_id nvarchar(200)
AS
BEGIN
	SELECT  
    CASE 
        WHEN order_status = 'Success' THEN 1  -- Set bit as true (1) if order_status is 'success'
        ELSE 0  -- Set bit as false (0) otherwise
    END as order_status,status_message
FROM [SJCESP_DEV].[dbo].[PaymentResponse] 
WHERE order_id = @order_id;
	END
GO

