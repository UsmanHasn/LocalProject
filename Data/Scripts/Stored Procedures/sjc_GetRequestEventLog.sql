USE [SJCESP_DEV]
GO

/****** Object:  StoredProcedure [dbo].[sjc_GetRequestEventLog]    Script Date: 11/20/2023 5:55:50 AM ******/
DROP PROCEDURE [dbo].[sjc_GetRequestEventLog]
GO

/****** Object:  StoredProcedure [dbo].[sjc_GetRequestEventLog]    Script Date: 11/20/2023 5:55:50 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[sjc_GetRequestEventLog]       
@requestId int,    
@userFlag bit =null ,  
 @SearchText NVARCHAR(MAX) = NULL, -- The text to search for                                
    @PageSize INT = 500,                  
    @PageNumber INT = 1    
AS    
BEGIN    
 DECLARE @Offset INT                  
    SET @Offset = (@PageNumber - 1) * @PageSize           
         
  SELECT    
    *    
  FROM [SJCESP_DEV].[dbo].[RequestEventLog] AS C    
  where RequestId =@requestId and [ShowToRequestor] =isnull(@userFlag,[ShowToRequestor])    
  ORDER BY LogId  desc
    OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY     
  End   
  
  
GO


