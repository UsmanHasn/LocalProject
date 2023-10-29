Alter Table COR_CaseGrpCatType
Add AllowOriginalCase bit
Go
Alter Table COR_CaseCategory
Add LinkSource varchar(50)
GO
CREATE TABLE LKT_RequestLinkSource
(
	Id int Identity(1,1),
	NameEn nvarchar(200),
	NameAr nvarchar(200),
	PRIMARY KEY (Id)
)