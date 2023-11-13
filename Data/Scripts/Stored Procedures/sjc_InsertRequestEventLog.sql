  
CREATE PROCEDURE [dbo].[sjc_InsertRequestEventLog]  
           @RequestId int,  
           @LoggedOn datetime,  
           @LoggedBy nvarchar(50),  
           @Description varchar(200),  
           @EventId int,  
           @ActionId int,  
           @StatusId int,  
           @UserIP nvarchar(50),  
           @UserHostName nvarchar(300),  
           @UserAgent nvarchar(300),  
           @ShowToRequestor bit,  
           @Amount nvarchar(20),  
           @RefNo nvarchar(20),  
           @PaymentRequestId bigint  
AS      
BEGIN    
INSERT INTO [dbo].[RequestEventLog]  
           ([RequestId]  
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
           ,[PaymentRequestId])  
     VALUES  
           (@RequestId  
           ,@LoggedOn  
           ,@LoggedBy  
           ,@Description  
           ,@EventId  
           ,@ActionId  
           ,@StatusId  
           ,@UserIP  
           ,@UserHostName  
           ,@UserAgent  
           ,@ShowToRequestor  
           ,@Amount  
           ,@RefNo  
           ,@PaymentRequestId)  
END 