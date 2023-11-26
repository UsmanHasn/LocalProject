SELECT TOP (1000) [LogId]
      ,[RequestId]
      ,[LoggedOn]
      ,[LoggedBy]
      ,[Description]
      ,[EventId]
      ,[ActionId]
      ,[StatusId]
      ,[UserIP]
      ,[UserHostName]
      ,[UserAgent]
      ,[ShowToRequestor]
      ,[Amount]
      ,[RefNo]
      ,[PaymentRequestId]
  FROM [SJCESP_DEV].[dbo].[RequestEventLog] order by RequestId desc

ALTER TABLE [SJCESP_DEV].[dbo].[RequestEventLog]
ALTER COLUMN Description NVARCHAR(255);

