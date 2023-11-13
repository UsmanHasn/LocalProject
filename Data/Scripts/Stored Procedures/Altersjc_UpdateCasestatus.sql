-- [dbo].[sjc_UpdateCasestatus] 'Pending', 109, 'IRFAN RAFIQ MUHAMMAD RAFIQ '  
Alter PROCEDURE [dbo].[sjc_UpdateCasestatus]   
@CaseStatus nvarchar(50),  
@CaseId bigint,  
@UserName nvarchar(200)  
AS  
BEGIN  
 DEclare @CaseStatusId int = (Select CaseStatusId From COR_CaseStatus Where NameEn = @CaseStatus),  
 @USerId int = (Select top 1 UserId From SEC_Users Where UserName = @UserName),  
 @CaseNo varchar(50) = ''  
   
 Exec sp_UpdateRequestNo @CaseId, @CaseNo OUTPUT  
   
 Update Requests   
 Set CaseStatusId = @CaseStatusId, LastModifiedBy = @UserName, LastModifiedDate = GETDATE(),  
 CaseNo = @CaseNo  
 Where CaseId = @CaseId  
  
 -- Insert into log activity table  
 INSERT INTO [dbo].[SEC_Alerts]  
 SELECT 'E', N'Application Request initiated | بدأ طلب التطبيق ', Email, PhoneNumber,   
 N'Application Request initiated - ' + @CaseNo + N' - بدأ طلب التطبيق', @UserName, GETDATE(),  
 @UserName, GETDATE(), 0, UserId, 0, NULL From SEC_Users Where UserName = @UserName  
 Select CaseNo From Requests Where CaseId = @CaseId   

 
INSERT INTO [dbo].[RequestEventLog]
           ([RequestId]
           ,[LoggedOn]
           ,[LoggedBy]
           ,[Description]
           ,[ShowToRequestor]
           ,[RefNo]
           ,[PaymentRequestId])
     VALUES
           (@CaseId
           ,Getdate()
           ,@UserName
           ,'تم نقل الطلب إلى انتظار المراجعة'
           ,1
           ,@CaseNo
           ,@CaseNo)
   
END  