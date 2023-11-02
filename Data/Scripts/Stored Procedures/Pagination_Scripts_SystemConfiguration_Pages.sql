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


-- =============================================          
-- Author: Waqas Yaqoob        
-- Create date: 24-07-2023          
-- Description: To get all menu          
-- =============================================          
CREATE PROCEDURE [dbo].[sjc_GetAllMenuList]     
@SearchText NVARCHAR(MAX) = NULL, -- The text to search  
@PageSize INT = 500,      
  @PageNumber INT = 1      
AS                      
BEGIN                      
  DECLARE @Offset INT      
  SET @Offset = (@PageNumber - 1) * @PageSize             
 select         
 MenuId as Id,        
Name,        
NameAr,        
MenuType as Type,        
ParentMenuId,        
UrlPath,        
Sequence,        
PageId,        
CreatedBy,        
CreatedDate,        
LastModifiedBy,        
LastModifiedDate,        
Deleted        
 from SYS_Menu         
where (@SearchText IS NULL OR (Name LIKE N'%' + @SearchText + N'%' OR NameAr LIKE N'%' + @SearchText + N'%'   
   OR Sequence LIKE N'%' + @SearchText + N'%'))    
   and  ISNULL(Deleted,0) =0     
ORDER BY MenuId OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY      
END 

CREATE PROCEDURE [dbo].[sjc_GetAllMenuListCount]   
 @SearchText NVARCHAR(MAX) = NULL -- The text to search       
AS                      
BEGIN                      
     SELECT COUNT(*) AS TotalCount    
  FROM SYS_Menu    
  WHERE    
  (@SearchText IS NULL OR (Name LIKE N'%' + @SearchText + N'%' OR NameAr LIKE N'%' + @SearchText + N'%'   
   OR Sequence LIKE N'%' + @SearchText + N'%'))    
   and  ISNULL(Deleted,0) =0          
       
END  

Alter PROCEDURE [dbo].[sjc_GetSystemSettings]      
@SettingId int = NULL , 
@SearchText NVARCHAR(MAX) = NULL, -- The text to search  
@PageSize INT = 500,      
  @PageNumber INT = 1     
AS      
BEGIN  
DECLARE @Offset INT      
  SET @Offset = (@PageNumber - 1) * @PageSize     
 Select       
  SystemSettingId, KeyName, KeyValue, Description, CreatedBy, CreatedDate,Deleted    
 From SYS_SystemSettings      
 Where (@SearchText IS NULL OR (KeyName LIKE N'%' + @SearchText + N'%' OR KeyValue LIKE N'%' + @SearchText + N'%'   
   OR Description LIKE N'%' + @SearchText + N'%'))
   and SystemSettingId = ISNULL(@SettingId, SystemSettingId)      
 and Deleted=0  
 ORDER BY SystemSettingId OFFSET @Offset ROWS FETCH NEXT @PageSize ROWS ONLY  
END  

CREATE PROCEDURE [dbo].[sjc_GetSystemSettingsCount]   
 @SearchText NVARCHAR(MAX) = NULL -- The text to search       
AS                      
BEGIN                      
     SELECT COUNT(*) AS TotalCount    
  FROM SYS_SystemSettings    
  WHERE    
  (@SearchText IS NULL OR (KeyName LIKE N'%' + @SearchText + N'%' OR KeyValue LIKE N'%' + @SearchText + N'%'   
   OR Description LIKE N'%' + @SearchText + N'%'))  
   and  ISNULL(Deleted,0) =0          
       
END  