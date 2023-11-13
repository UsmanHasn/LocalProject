  
Create PROCEDURE [dbo].[sjc_GetRequestCount]    
 @SearchText NVARCHAR(MAX) = NULL    
AS                          
BEGIN    
with reultset as (  
  SELECT     
    C.[CaseId],  
    C.CaseNo,  
    C.CourtTypeId,  
    C.CourtBuildingId,  
    C.CaseTypeId,  
    C.CaseCategoryId,  
    C.CaseSubCategoryId,  
    C.FiledOn,  
    C.Subject,  
    C.CreatedBy,  
    C.CreatedDate,  
    C.LastModifiedBy,  
    C.LastModifiedDate,  
    C.Deleted,  
    S.NameEn AS caseStatusNameAr,  
    S.NameAr AS caseStatusName,  
    B.NameAr AS courtNameAr,  
    B.NameEn AS courtName,  
    CC.NameAr AS caseCatNameAr,  
    CC.NameEn AS caseCatName,  
    CT.NameAr AS CaseTypeAr,  
    CT.NameEn AS CaseType  
  FROM [dbo].[Requests] AS C    
  INNER JOIN [dbo].[RequestParties] AS CP ON C.CaseId = CP.CaseId    
  INNER JOIN [dbo].[COR_CaseStatus] AS S ON C.CaseStatusId = S.CaseStatusId  
  INNER JOIN [dbo].[LKT_Location] AS B ON C.LocationId = B.LocationId  
  INNER JOIN [dbo].[COR_CaseCategory] AS CC ON C.CaseCategoryId = CC.CaseCategoryId  
  INNER JOIN [dbo].[COR_CaseType] AS CT ON C.CaseTypeId = CT.CaseTypeId  
  WHERE  
    (@SearchText IS NULL  
     OR CaseNo LIKE N'%' + @SearchText + N'%'  
     OR FiledOn LIKE N'%' + @SearchText + N'%'  
     OR Subject LIKE N'%' + @SearchText + N'%'  
     OR S.NameAr LIKE N'%' + @SearchText + N'%'  
     OR S.NameEn LIKE N'%' + @SearchText + N'%'  
     OR B.NameAr LIKE N'%' + @SearchText + N'%'  
     OR B.NameEn LIKE N'%' + @SearchText + N'%'  
     OR CC.NameAr LIKE N'%' + @SearchText + N'%'  
     OR CC.NameEn LIKE N'%' + @SearchText + N'%'  
     OR CT.NameAr LIKE N'%' + @SearchText + N'%'  
     OR CT.NameEn LIKE N'%' + @SearchText + N'%')  
    AND C.CaseStatusId != 1  
 )                        
 SELECT     
     Count([CaseId]) as TotalCount  
       FROM reultset as C    
End   