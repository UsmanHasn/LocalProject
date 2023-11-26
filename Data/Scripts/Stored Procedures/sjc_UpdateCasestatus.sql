USE [SJCESP_DEV]
GO

DECLARE	@return_value int

EXEC	@return_value = [dbo].[sjc_UpdateCasestatus]
		@CaseStatus = N'Pending',
		@CaseId = 423,
		@UserName = N'Admin'

SELECT	'Return Value' = @return_value

GO

select * from [RequestEventLog] order by LoggedOn desc