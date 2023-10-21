
-- Create a full-text catalog
ALter PROCEDURE [dbo].[sjc_GetAll_LanguageLookup]
  @SearchText NVARCHAR(MAX) = NULL, -- The text to search for
  @LanguageId INT = NULL,           -- Filter by LanguageId
  @PageSize INT = 500,
  @PageNumber INT = 1
AS
BEGIN
  DECLARE @Offset INT
  SET @Offset = (@PageNumber - 1) * @PageSize

  -- Query to retrieve paginated LanguageLookup data
  SELECT
    LanguageId,
    [Key],
    EnglishValue,
    ArabicValue
  FROM LanguageLookup
  WHERE
    (
      (@SearchText IS NULL OR (EnglishValue LIKE N'%' + @SearchText + N'%' OR ArabicValue LIKE N'%' + @SearchText + N'%'))
      AND (@LanguageId IS NULL OR LanguageId = @LanguageId)
    )
  ORDER BY LanguageId
  OFFSET @Offset ROWS
  FETCH NEXT @PageSize ROWS ONLY

  -- Calculate and return the total count
  SELECT COUNT(*) AS TotalCount
  FROM LanguageLookup
  WHERE
    (
      (@SearchText IS NULL OR (EnglishValue LIKE N'%' + @SearchText + N'%' OR ArabicValue LIKE N'%' + @SearchText + N'%'))
      AND (@LanguageId IS NULL OR LanguageId = @LanguageId)
    )
END

 Alter PROCEDURE [dbo].[sjc_GetAll_LanguageLookupCount]                
 @SearchText NVARCHAR(MAX) = NULL -- The text to search   
AS                  
BEGIN                  
  
  
  -- Calculate and return the total count  
  SELECT COUNT(*) AS TotalCount  
  FROM LanguageLookup      
   WHERE
    (
      (@SearchText IS NULL OR (EnglishValue LIKE N'%' + @SearchText + N'%' OR ArabicValue LIKE N'%' + @SearchText + N'%'))
 
    )    
          
END  
  