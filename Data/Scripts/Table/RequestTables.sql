CREATE TABLE RequestStatus
(
  StatusId INT identity(1,1) NOT NULL,
  NameEn NVARCHAR(200) NULL,
  NameAr NVARCHAR(200) NULL,
  IsActive bit NULL,
  CreatedBy NVARCHAR(50) NULL,
  CreatedOn DATETIME NULL,
  LastModifiedBy NVARCHAR(50) NULL,
  LastModifiedOn DATETIME NULL,
  ReviewRequired Bit NULL,
  PRIMARY KEY (StatusId)
);

CREATE TABLE RequestAction
(
  ActionId INT Identity(1,1) NOT NULL,
  NameEn NVARCHAR(200) NULL,
  NameAr NVARCHAR(200) NULL,
  ReqDocIds NVARCHAR(200) NULL,
  IsActive Bit NULL,
  CreatedBy NVARCHAR(50) NULL,
  CreatedOn DATETIME NULL,
  LastModifiedBy NVARCHAR(50) NULL,
  LastModifiedOn DATETIME NULL,
  DefaultText NVARCHAR(400) NULL,
  AvailableStatusIds NVARCHAR(200) NULL,
  ActionFor int NULL,
  PRIMARY KEY (ActionId),
  FOREIGN KEY (ActionFor) REFERENCES SEC_Roles(RoleId)
);

CREATE TABLE RequestConfig
(
  ConfigId INT identity(1,1) NOT NULL,
  NextStatusId INT NULL,
  StatusId INT NULL,
  ActionId INT NULL,
  PRIMARY KEY (ConfigId),
  FOREIGN KEY (ActionId) REFERENCES RequestAction(ActionId)
);

CREATE TABLE LKT_RequestEvents
(
  EventId INT Identity(1,1) NOT NULL,
  NameEn NVARCHAR(200) NULL,
  NameAr NVARCHAR(200) NULL,
  IsActive Bit NULL,
  PRIMARY KEY (EventId)
);

CREATE TABLE RequestEventLog
(
  LogId INT identity(1,1) NOT NULL,
  RequestId INT NULL,
  LoggedOn DATETIME NULL,
  LoggedBy NVARCHAR(50)  NULL,
  Description VARCHAR(200) NULL,
  EventId INT NULL,
  ActionId INT NULL,
  StatusId INT NULL,
  PRIMARY KEY (LogId),
  FOREIGN KEY (EventId) REFERENCES LKT_RequestEvents(EventId),
  FOREIGN KEY (ActionId) REFERENCES RequestAction(ActionId),
  FOREIGN KEY (StatusId) REFERENCES RequestStatus(StatusId)
);
Create Table COR_AdvanceLinkingConfig
(
   LinkId int identity(1,1),
   CaseGroupId int,
   LocationId int,
   CategoryId int,
   CaseTypeId int,
   SubjectId int,
   LinkAllow bit,
   LinkGroupId varchar(200),
   LinkSources varchar(200),
   RoleId varchar(200), 
   Primary key (LinkId)
   
)