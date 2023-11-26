-- =============================================  
-- Author:  <Author,,Name>  
-- Create date: <Create Date,,>  
-- Description: <Description,,>  
-- =============================================  
CREATE PROCEDURE [dbo].[sjc_GetActionforAvailableStatus]  
@statusId bigint,
@roleId int
AS  
BEGIN  
 -- SET NOCOUNT ON added to prevent extra result sets from  
 -- interfering with SELECT statements.  
 SET NOCOUNT ON;  
  
    -- Insert statements for procedure here  
  ( SELECT *
    FROM YourTableName
    WHERE EXISTS (
        SELECT value
        FROM STRING_SPLIT(YourColumnName, ',')
        WHERE LTRIM(RTRIM(value)) = @searchItem)
		) as cte 
  
SELECT RA.ActionId  
      ,RA.NameEn  
      ,RA.NameAr  
      ,RA.ReqDocIds  
      ,RA.OptionalDocIds  
      ,RA.DefaultTextEn  
      ,RA.DefaultTextAr  
      ,RA.ActionFor  
      ,RA.DisplayOrder  
      ,RA.CheckRequired  
      ,RA.CaseSubjectIds  
      ,RA.Deleted  
   ,RO.NextStatusId  
   ,RO.StatusId  
  FROM [dbo].[RequestAction] as RA  
  inner join [SJCESP_DEV].[dbo].[RequestConfig] AS RO on RO.ActionId = RA.ActionId   and ActionFor =  @roleId
 WHERE RO.StatusId =@statusId  
 and RA.IsActive =1 and RA.Deleted = 0  
END  
  

