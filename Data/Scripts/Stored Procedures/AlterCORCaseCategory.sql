ALTER PROCEDURE [dbo].[COR_GetCaseCategoryByLocationId]
@LocationId int
AS
BEGIN
	Select 
		G.CaseGroupId, G.NameAr as CaseGroupAr, G.NameEn as CaseGroupEn, 
		c.CaseCategoryId, c.CAAJ_Code, c.ACO_Code, 
		C.NameAr as CaseCategoryAr, C.NameEn as CaseCategoryEn,
		gg.GrpgovernateId as GovernateId, l.LocationId, c.LinkSource as RequestLinkSource
	From COR_CaseGroup G
	Inner join COR_CaseCategory c on c.CaseGroupId = g.CaseGroupId
	Inner join LKT_GroupGovernates gg on gg.CaseGroupId = g.CaseGroupId
	Inner Join LKT_Governates lg on lg.GovernateId = gg.GovernateId
	Inner Join Lkt_Location l on l.GrpgovernatesId = gg.GrpgovernateId
	Where l.LocationId = @LocationId
END
GO
ALTER PROCEDURE [dbo].[COA_GetCaseTypesByCategory]
@CategoryId int
AS
BEGIN
	Select 
	gct.CaseGrpCatTypeId as CaseTypeId, CAAJ_Code, ACO_Code, NameEn, NameAr,
	gct.AllowOriginalCase as AllowLinkCase
  From COR_CaseGrpCatType gct
  inner join COR_CaseType ct on ct.CaseTypeId = gct.CaseTypeId
  Where gct.CaseCategoryId = @CategoryId
  And gct.IsActive = 1 and ct.IsActive = 1
END
