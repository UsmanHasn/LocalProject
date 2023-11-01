Alter PROCEDURE [dbo].[sjc_GetAllGovernateLookup]   
 @SearchText NVARCHAR(MAX) = NULL, -- The text to search for                    
  @PageSize INT = 500,      
  @PageNumber INT = 1      
AS                      
BEGIN                      
  DECLARE @Offset INT      
  SET @Offset = (@PageNumber - 1) * @PageSize                     
 select           
 governateid,      
 Code,      
 NameEn,      
 nameAr  ,Deleted    
 from [dbo].[LKT_Governates]
 WHERE    
 (    
      (@SearchText IS NULL OR ( Code LIKE N'%' + @SearchText + N'%'   
   OR NameEn LIKE N'%' + @SearchText + N'%' OR nameAr LIKE N'%' + @SearchText + N'%'))    
       
    )        
 and  ISNULL(Deleted,0) =0         
 ORDER BY governateid OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY      
 END 

   CREATE PROCEDURE [dbo].[sjc_GetAll_GovernateCount]   
 @SearchText NVARCHAR(MAX) = NULL -- The text to search       
AS                      
BEGIN                      
     SELECT COUNT(*) AS TotalCount    
 from [dbo].[LKT_Governates]
 WHERE    
 (    
      (@SearchText IS NULL OR (Code LIKE N'%' + @SearchText + N'%'   
   OR NameEn LIKE N'%' + @SearchText + N'%' OR nameAr LIKE N'%' + @SearchText + N'%'))    
       
    )        
 and  ISNULL(Deleted,0) =0    
       
END  
