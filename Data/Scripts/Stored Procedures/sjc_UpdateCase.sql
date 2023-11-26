select * from [dbo].[RequestConfig]
select * from [dbo].[RequestAction]
select * from [dbo].[COR_CaseStatus]

select * from RequestEventLog


select * from requests where caseNo!='' order by LastModifiedDate  desc


Alter PROCEDURE [dbo].[sjc_UpdateCase]     
@CaseStatusId int,    
@CaseId bigint,    
@Fee int,  
@PaymentDrawId int,  
@Exempted int,  
@UserName nvarchar(50)    
AS    
BEGIN    
 if(@CaseStatusId = 5)-- Take id from system parameters  
 Begin  
  Update Requests     
   Set  
   CaseStatusId = @CaseStatusId,   
   LastModifiedBy = @UserName,   
   LastModifiedDate = GETDATE(),    
   PaymentDate = Getdate(),  
   ReceiptNo = dbo.sjc_GetReceiptNo()  
   Where CaseId = @CaseId    
 End  
 else  
 begin  
  Update Requests     
   Set  
   CaseStatusId = @CaseStatusId,   
   LastModifiedBy = @UserName,   
   LastModifiedDate = GETDATE(),    
   Fee=@Fee,  
   PaymentDrawId=@PaymentDrawId,  
   Exempted=@Exempted  
   Where CaseId = @CaseId    
 end  


DEclare @CaseNo int = (Select CaseNo From Requests Where CaseId = @CaseId)      
 if(@CaseStatusId = 4)-- Take id from system parameters  
 Begin   
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
           ,N'تم نقل الطلب إلى انتظار المراجعة'    
           ,1    
           ,@CaseNo    
           ,@CaseNo)    
		    End  
END  
