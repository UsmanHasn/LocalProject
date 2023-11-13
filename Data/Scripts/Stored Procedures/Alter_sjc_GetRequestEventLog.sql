Alter PROCEDURE [dbo].[sjc_GetRequestEventLog]   
@requestId int,
@userFlag bit =null    
AS
BEGIN
  SELECT
    *
  FROM [SJCESP_DEV].[dbo].[RequestEventLog] AS C
  where RequestId =@requestId and [ShowToRequestor] =isnull(@userFlag,[ShowToRequestor])
  ORDER BY LogId
  End     
