USE [AdminCourtOmanDB]
GO

/****** Object:  StoredProcedure [dbo].[esp_GetCaseStatus]    Script Date: 7/27/2023 11:42:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[esp_GetCaseStatus]
 
AS
 

	select cs.Case_Status_ID 
	,cs.Case_Status_En
	,cs.Case_Status_Ar
	
	from Case_Statuses cs
	where cs.Is_Active = 1
 

 
GO

/****** Object:  StoredProcedure [dbo].[esp_GetCaseType]    Script Date: 7/27/2023 11:42:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[esp_GetCaseType]
 
AS
 

	select ct.Case_Type_ID 
	,ct.Case_Type_En
	,ct.Case_Type_ar
	
	from Case_Types ct
	where ct.Is_Active = 1
 
GO

/****** Object:  StoredProcedure [dbo].[esp_GetCaseHearings]    Script Date: 7/27/2023 11:42:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[esp_GetCaseHearings]
@CaseId int 
AS
BEGIN
	Select 
		ch.Case_Hearing_ID as CaseHearingId, ch.Hearing_Date as HearingDate, ch.Case_Id as CaseId,
		ch.Next_Hearing_Date as NextHearingDate, isnull(Hearing_Notes, '') as HearingNotes, 
		isnull(Judge_Notes, '') as JudgeNotes
	From Case_Hearings as ch
	Where Case_Id = @CaseId
END
	
GO

/****** Object:  StoredProcedure [dbo].[esp_GetCaseAnnouncement]    Script Date: 7/27/2023 11:42:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[esp_GetCaseAnnouncement] -- [esp_GetCaseAnnouncement] 2669
@CaseId int
AS
BEGIN
	Select 
		cca.Case_Custom_Announcement_ID as CaseAnnouncementId, cca.Announcement_Date as AnnouncementDate,
		Form_Type_ID as FormTypeId, cca.Party_Type_ID as PartyTypeId, pt.Party_Type_Ar as PartyTypeEn,
		pt.Party_Type_Ar as PartyTypeAr, cca.Case_Id, '' as AnnouncementAr, '' as AnnouncementEn
		
	From Case_Custom_Announcements as cca
	Left outer Join Party_Types as pt on cca.Party_Type_Id = pt.Party_Type_Id
	Where Case_Id = @CaseId
END
	
GO

/****** Object:  StoredProcedure [dbo].[esp_GetCaseParties]    Script Date: 7/27/2023 11:42:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[esp_GetCaseParties] -- [esp_GetCaseParties] 2669
@CaseId int
AS
BEGIN
	Select 
		Case_Party_ID as CasePartyId, Case_ID as CaseId, 
		CASE cp.Entity_Type_ID
				WHEN 1 THEN ISNULL(cp.Name1 + ' ', '') + ISNULL(cp.Name2 + ' ', '') + ISNULL(cp.Name3 + ' ', '') +
				ISNULL(cp.Name4 + ' ', '') + ISNULL(cp.Name5 + ' ', '')
				WHEN 2 THEN cp.Business_Name 
				WHEN 3 THEN ISNULL(cp.Name1,cp.Government_Name)
			END as PartyName,
		Nationality_ID as NationalityId, '' as NationalityNameAr, '' as NationalityNameEn,
		cp.Party_Type_Id as PartyTypeId, pt.Party_Type_Ar as PartyTypeAr, pt.Party_Type_En as PartyTypeEn,
		cp.Entity_Type_Id as PartyTypeId, 
		Case cp.Entity_Type_ID 
			When 1 Then N'فرد' 
			When 2 Then N'شركة' 
			When 3 Then N'جهة حكومية' 
		end	as EntityTypeAr, 
		Case cp.Entity_Type_ID 
			When 1 Then 'Individual' 
			When 2 Then 'Business' 
			When 3 Then 'Government Entity' 
		end	as EntityTypeEn
	From Case_Parties as cp
	Inner Join Party_Types as pt on pt.Party_Type_Id = cp.Party_Type_Id
	Where cp.Case_ID = @CaseId
END

GO

/****** Object:  StoredProcedure [dbo].[esp_GetCaseSubjects]    Script Date: 7/27/2023 11:42:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[esp_GetCaseSubjects] 
@CaseId int
AS
BEGIN
	Select 
		Case_Id as CaseId, cs.Subject_Id as SubjectId, cs.Fee_Value as FeeValue, cs.Fees_Paid as FeePaid,
		s.Subject_Ar as SubjectNameAr, s.Subject_En as SubjectNameEn
	From Case_Subjects cs
	Inner Join Subjects s on cs.Subject_Id = s.Subject_Id --ORder by 1 desc
	Where cs.Case_ID = @CaseId
END
GO

/****** Object:  StoredProcedure [dbo].[esp_GetCases]    Script Date: 7/27/2023 11:42:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[esp_GetCases] --[esp_GetCases] @CaseType = 'empty', @CaseStatus = 'empty'
@CaseID Int = NULL,
@CaseNo nvarchar(25) = NULL,
@CivilNo int = NULL,
@CaseType nvarchar(10) = NULL,
@CaseStatus nvarchar(10) = NULL
AS
BEGIN
DECLARE @V_CTYPE nvarchar(10) = NULL
DECLARE @V_CSTATUS nvarchar(10) = NULL

if(@CaseType = '')
	begin
		set @V_CTYPE = null
	end
else
	begin
		set @V_CTYPE = @CaseType
	end
	if(@CaseStatus = '')
	begin
		set @V_CSTATUS = null
	end
else
	begin
		set @V_CSTATUS = @CaseStatus
	end


	Select top 25
		Case_ID as CaseId, dbo.Remove_Case_No_LeftZeros(C.Case_No) as CaseNo, Pending_Case_No as PendingCaseNo, 
		ct.Case_Type_En as CaseTypeEn, ct.Case_Type_Ar as CaseTypeAr,
		c.Comments, c.Filed_Date as CaseFiledDate, cs.Case_Status_En as CaseStatusEn,
		cs.Case_Status_Ar as CaseStatusAr,
		cg.Case_Group_En as CaseGroupEn, cg.Case_Group_Ar as CaseGroupAr,
		Fee_Value as FeeValue, cb.Court_Building_En as CourtBuildingEn, cb.Court_Building_Ar as CourtBuildingAr
	From Cases as c
	Inner join Case_Types as ct on ct.Case_Type_ID = c.Case_Type_ID
	Inner Join Case_Groups as cg on cg.Case_Group_ID = ct.Case_Group_ID
	Inner Join Case_Statuses as cs on cs.Case_Status_ID = c.Case_Status_ID
	Inner Join Court_Buildings as cb on cb.Court_Building_Id = c.Court_Building_ID
	Where Case_ID = isnull(@CaseId, 2669)
	and (  @V_CTYPE  is null or c.Case_Type_ID = @V_CTYPE)
	and (@V_CSTATUS is null or c.Case_Status_ID = @V_CSTATUS)
	UNION ALL
	Select * From (
	Select 
		top 25
		Case_ID as CaseId, dbo.Remove_Case_No_LeftZeros(C.Case_No) as CaseNo, Pending_Case_No as PendingCaseNo, 
		ct.Case_Type_En as CaseTypeEn, ct.Case_Type_Ar as CaseTypeAr,
		c.Comments, c.Filed_Date as CaseFiledDate, cs.Case_Status_En as CaseStatusEn,
		cs.Case_Status_Ar as CaseStatusAr,
		cg.Case_Group_En as CaseGroupEn, cg.Case_Group_Ar as CaseGroupAr,
		Fee_Value as FeeValue, cb.Court_Building_En as CourtBuildingEn, cb.Court_Building_Ar as CourtBuildingAr
	From Cases as c
	Inner join Case_Types as ct on ct.Case_Type_ID = c.Case_Type_ID
	Inner Join Case_Groups as cg on cg.Case_Group_ID = ct.Case_Group_ID
	Inner Join Case_Statuses as cs on cs.Case_Status_ID = c.Case_Status_ID
	Inner Join Court_Buildings as cb on cb.Court_Building_Id = c.Court_Building_ID
	Where Case_ID = ISNULL(@CaseID, Case_ID)
	AND ISNULL(Case_No,'') = ISNULL(@CaseNo, ISNULL(Case_No,'')) 
	--And c.Filed_Date >= Getdate()
	--And c.Filed_Date <= DateAdd(Month, 1, GetDate())
	and (  @V_CTYPE  is null or c.Case_Type_ID = @V_CTYPE)
	and (@V_CSTATUS is null or c.Case_Status_ID = @V_CSTATUS)

	Order by 1 desc) as T
End



GO


