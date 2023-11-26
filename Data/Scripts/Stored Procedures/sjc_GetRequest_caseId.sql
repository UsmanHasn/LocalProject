USE [SJCESP_DEV]
GO

/****** Object:  StoredProcedure [dbo].[sjc_GetRequest_caseId]    Script Date: 11/22/2023 5:49:14 AM ******/
DROP PROCEDURE [dbo].[sjc_GetRequest_caseId]
GO

/****** Object:  StoredProcedure [dbo].[sjc_GetRequest_caseId]    Script Date: 11/22/2023 5:49:14 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE PROCEDURE [dbo].[sjc_GetRequest_caseId]          
@caseId  INT = NULL       
AS                                
BEGIN                                  
  SELECT  Distinct     
    C.[CaseId],        
    C.CaseNo,        
    C.CourtTypeId,        
    C.CourtBuildingId,        
    C.CaseTypeId,        
    C.CaseCategoryId,        
    C.CaseSubCategoryId,        
    C.FiledOn,        
 C.CaseStatusId,      
 C.fee ,          
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
  FROM  [SJCESP_DEV].[dbo].[Requests] AS C          
  left JOIN [dbo].[RequestParties] AS CP ON C.CaseId = CP.CaseId          
  left JOIN [dbo].[COR_CaseStatus] AS S ON C.CaseStatusId = S.CaseStatusId        
  left JOIN [dbo].[LKT_Location] AS B ON C.LocationId = B.LocationId        
  left JOIN [dbo].[COR_CaseCategory] AS CC ON C.CaseCategoryId = CC.CaseCategoryId        
  left JOIN [dbo].[COR_CaseType] AS CT ON C.CaseTypeId = CT.CaseTypeId        
  WHERE C.CaseId=@caseId          
End 
GO


