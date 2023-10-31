Alter PROCEDURE [dbo].[sjc_GetCaseDetail]            
@CaseId int      
AS              
BEGIN              
 select      
c.CaseId,      
c.CaseNo,      
c.CaseGroupId,      
(select cg.NameEn from [dbo].[COR_CaseGroup] as cg where cg.CaseGroupId=c.CaseGroupId) as caseGroup,      
(select cg.NameAr from [dbo].[COR_CaseGroup] as cg where cg.CaseGroupId=c.CaseGroupId) as caseGroupAr,      
c.GovernateId,      
(select g.NameEn from [dbo].[LKT_Governates] as g where g.GovernateId=c.GovernateId) governate,      
(select g.NameAr from [dbo].[LKT_Governates] as g where g.GovernateId=c.GovernateId) governateAr,    
c.locationId,      
(select l.NameEn from [dbo].[LKT_Location] as l where l.locationId=c.locationId) as LocationName,      
(select l.NameAr from [dbo].[LKT_Location] as l where l.locationId=c.locationId) as LocationNameAr,      
CaseTypeId,      
(select ct.NameEn from [dbo].[COR_CaseType] as ct where ct.CaseTypeId=c.CaseTypeId) as caseType,      
CaseCategoryId,      
(select cc.NameEn from [dbo].[COR_CaseCategory] as cc where cc.CaseCategoryId=c.CaseCategoryId) as caseCatName,      
CaseSubCategoryId,      
(select cs.NameEn from [dbo].[COR_Subject] as cs where cs.[SubjectId]=c.CaseSubCategoryId) as caseSubCatName,      
c.Subject    ,  
c.FiledOn  
From  Requests    as c      
where c.CaseId=@CaseId      
End 