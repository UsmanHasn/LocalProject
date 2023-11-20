USE [SJCESP_DEV]
GO

/****** Object:  StoredProcedure [dbo].[sjc_GetRequestEventLogCount]    Script Date: 11/20/2023 5:56:11 AM ******/
DROP PROCEDURE [dbo].[sjc_GetRequestEventLogCount]
GO

/****** Object:  StoredProcedure [dbo].[sjc_GetRequestEventLogCount]    Script Date: 11/20/2023 5:56:11 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


    
CREATE PROCEDURE [dbo].[sjc_GetRequestEventLogCount]        
 @SearchText NVARCHAR(MAX) = NULL,  
 @userFlag bit =null ,  
 @requestId bigint  
AS                              
BEGIN                               
  SELECT         
   cOUNT(LogId) AS TotalCount    
  FROM [dbo].[RequestEventLog] AS C        
  WHERE      
    (@SearchText IS NULL      
     OR RequestId LIKE N'%' + @SearchText + N'%'      
     OR LoggedOn LIKE N'%' + @SearchText + N'%'      
     OR LoggedBy LIKE N'%' + @SearchText + N'%'      
     OR Description LIKE N'%' + @SearchText + N'%'      
     OR EventId  LIKE N'%' + @SearchText + N'%'      
     OR ActionId  LIKE N'%' + @SearchText + N'%'      
     OR StatusId  LIKE N'%' + @SearchText + N'%'      
     OR UserIP LIKE N'%' + @SearchText + N'%'      
     OR UserHostName LIKE N'%' + @SearchText + N'%'      
     OR UserAgent LIKE N'%' + @SearchText + N'%'      
     OR ShowToRequestor LIKE N'%' + @SearchText + N'%'    
  OR Amount LIKE N'%' + @SearchText + N'%'    
  OR RefNo LIKE N'%' + @SearchText + N'%'    
  OR PaymentRequestId LIKE N'%' + @SearchText + N'%'    
  )    and RequestId =@requestId  and ShowToRequestor= isnull(@userFlag,[ShowToRequestor])  
        
End 
GO


