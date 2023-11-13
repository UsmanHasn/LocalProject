  
Alter PROCEDURE [dbo].[sjc_GetRequestEventLog]   
@requestId int      
AS
BEGIN
  SELECT
    *
  FROM [dbo].[RequestEventLog] AS C
  where RequestId =@requestId
  ORDER BY LogId
  End     