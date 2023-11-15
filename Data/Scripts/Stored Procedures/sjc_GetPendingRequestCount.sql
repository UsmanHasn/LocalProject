
  
create PROCEDURE [dbo].[sjc_GetPendingRequestCount]    
 @SearchText NVARCHAR(MAX) = NULL ,
 @CasaStatusId int   = null  
AS                          
BEGIN    
with reultset as (  
   SELECT DISTINCT         
        C.[CaseId]            
        ,C.[CaseNo]            
        ,C.[CourtTypeId]            
        ,C.[CourtBuildingId]          
        ,C.[CaseTypeId]            
        ,C.[CaseCategoryId]            
        ,C.[CaseSubCategoryId]            
        ,C.[FiledOn]            
        ,C.[Subject]            
        ,C.[CreatedBy]            
        ,C.[CreatedDate]            
        ,C.[LastModifiedBy]            
        ,C.[LastModifiedDate]            
        ,C.[Deleted]         
        ,C.[CaseStatusId]      
        ,S.NameEn AS caseStatusName      
        ,S.NameAr AS caseStatusNameAr      
        ,CAST(C.fee AS VARCHAR) AS fee,        
        B.NameAr AS courtNameAr,      
        B.NameEn AS courtName,      
        CC.NameAr AS caseCatNameAr,      
        CC.NameEn AS caseCatName,      
        CT.NameAr AS CaseTypeAr,      
        CT.NameEn AS CaseType         
    FROM [SJCESP_DEV].[dbo].[Requests] AS C            
    INNER JOIN [SJCESP_DEV].[dbo].[RequestParties] AS CP ON C.CaseId = CP.CaseId  
    INNER JOIN [SJCESP_DEV].[dbo].[COR_CaseStatus] AS S ON C.CaseStatusId = S.CaseStatusId   
    INNER JOIN [SJCESP_DEV].[dbo].[LKT_Location] AS B ON C.LocationId = B.LocationId      
    INNER JOIN [SJCESP_DEV].[dbo].[COR_CaseCategory] AS CC ON C.CaseCategoryId = CC.CaseCategoryId      
    INNER JOIN [SJCESP_DEV].[dbo].[COR_CaseType] AS CT ON C.CaseTypeId = CT.CaseTypeId    
    WHERE      
        (@SearchText IS NULL      
        OR C.CaseNo LIKE '%' + @SearchText + '%'      
        OR C.FiledOn LIKE '%' + @SearchText + '%'      
        OR C.Subject LIKE '%' + @SearchText + '%'      
        OR S.NameAr LIKE '%' + @SearchText + '%'      
        OR S.NameEn LIKE '%' + @SearchText + '%'      
        OR B.NameAr LIKE '%' + @SearchText + '%'      
        OR B.NameEn LIKE '%' + @SearchText + '%'      
        OR CC.NameAr LIKE '%' + @SearchText + '%'      
        OR CC.NameEn LIKE '%' + @SearchText + '%'      
        OR CT.NameAr LIKE '%' + @SearchText + '%'      
        OR CT.NameEn LIKE '%' + @SearchText + '%')
        AND C.CaseStatusId > 1
        AND C.CaseStatusId = ISNULL(@CasaStatusId, C.CaseStatusId) 
 )                        
 SELECT     
     Count([CaseId]) as TotalCount  
       FROM reultset as C    
End   