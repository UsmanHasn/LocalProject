CReate PROCEDURE [dbo].[sjc_GetRequest]    
@caseId  INT = NULL,
 @SearchText NVARCHAR(MAX) = NULL, -- The text to search for                        
  @PageSize INT = 500,          
  @PageNumber INT = 1          
AS                          
BEGIN                          
  DECLARE @Offset INT          
  SET @Offset = (@PageNumber - 1) * @PageSize   
  SELECT     
    C.[CaseId],  
    C.CaseNo,  
    C.CourtTypeId,  
    C.CourtBuildingId,  
    C.CaseTypeId,  
    C.CaseCategoryId,  
    C.CaseSubCategoryId,  
    C.FiledOn,  
	C.CaseStatusId,
	C.fee,
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
    AND C.CaseStatusId != 1 AND C.CaseId=Isnull(@caseId,C.CaseId) 
    ORDER BY C.CaseStatusId OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY      
End    

