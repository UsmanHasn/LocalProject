
CREATE PROCEDURE [dbo].[sjc_GetPagesPagination]        
 @SearchText NVARCHAR(MAX) = NULL, -- The text to search for    
@pageid int = null,       
 @PageSize INT = 500,    
  @PageNumber INT = 1         
AS                        
BEGIN                        
  DECLARE @Offset INT    
  SET @Offset = (@PageNumber - 1) * @PageSize    
    
  -- Query to retrieve paginated LanguageLookup data      
 select        
 PageId as Id ,PageName,PageNameAr,PageModuleEn,PageModuleAr,CreatedDate,CreatedBy        
 from SYS_Pages        
 where   
 (    
      (@SearchText IS NULL OR (PageName LIKE N'%' + @SearchText + N'%' OR PageNameAr LIKE N'%' + @SearchText + N'%'   
   OR PageModuleEn LIKE N'%' + @SearchText + N'%' OR PageModuleAr LIKE N'%' + @SearchText + N'%'))    
      AND (@pageid IS NULL OR PageId = @pageid)    
    )        
 and  ISNULL(Deleted,0) =0      
 ORDER BY PageId OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY        
end    

  

CREATE PROCEDURE [dbo].[sjc_GetAll_PageCount]   
 @SearchText NVARCHAR(MAX) = NULL -- The text to search       
AS                      
BEGIN                      
     SELECT COUNT(*) AS TotalCount    
  FROM SYS_Pages    
  WHERE    
   (@SearchText IS NULL OR (PageName LIKE N'%' + @SearchText + N'%' OR PageNameAr LIKE N'%' + @SearchText + N'%'   
   OR PageModuleEn LIKE N'%' + @SearchText + N'%' OR PageModuleAr LIKE N'%' + @SearchText + N'%'))    
   and  ISNULL(Deleted,0) =0      
       
END 