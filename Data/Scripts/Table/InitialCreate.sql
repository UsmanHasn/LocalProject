USE [SJCESP]
GO
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE TABLE [AspNetRoles] (
        [RoleId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [NormalizedName] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        CONSTRAINT [PK_AspNetRoles] PRIMARY KEY ([RoleId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE TABLE [AspNetUsers] (
        [UserId] int NOT NULL IDENTITY,
        [UserName] nvarchar(max) NULL,
        [NormalizedUserName] nvarchar(max) NULL,
        [Email] nvarchar(max) NULL,
        [NormalizedEmail] nvarchar(max) NULL,
        [EmailConfirmed] bit NOT NULL,
        [PasswordHash] nvarchar(max) NULL,
        [SecurityStamp] nvarchar(max) NULL,
        [ConcurrencyStamp] nvarchar(max) NULL,
        [PhoneNumber] nvarchar(max) NULL,
        [PhoneNumberConfirmed] bit NOT NULL,
        [TwoFactorEnabled] bit NOT NULL,
        [LockoutEnd] datetimeoffset NULL,
        [LockoutEnabled] bit NOT NULL,
        [AccessFailedCount] int NOT NULL,
        CONSTRAINT [PK_AspNetUsers] PRIMARY KEY ([UserId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE TABLE [CountryLookup] (
        [CountryId] int NOT NULL IDENTITY,
        [Code] nvarchar(max) NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [NameAr] nvarchar(50) NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_CountryLookup] PRIMARY KEY ([CountryId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE TABLE [LanguageLookup] (
        [LanguageId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [NameAr] nvarchar(max) NOT NULL,
        CONSTRAINT [PK_LanguageLookup] PRIMARY KEY ([LanguageId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE TABLE [Menu] (
        [MenuId] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NOT NULL,
        [NameAr] nvarchar(max) NOT NULL,
        [MenuType] nvarchar(1) NULL,
        [ParentMenuId] int NULL,
        [UrlPath] nvarchar(max) NULL,
        [Sequence] int NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Menu] PRIMARY KEY ([MenuId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE TABLE [NationalityLookup] (
        [NationalityId] int NOT NULL IDENTITY,
        [Code] nvarchar(max) NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [NameAr] nvarchar(50) NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_NationalityLookup] PRIMARY KEY ([NationalityId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE TABLE [PasswordHistory] (
        [Id] int NOT NULL IDENTITY,
        [PasswordHash] nvarchar(max) NOT NULL,
        [UserId] int NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_PasswordHistory] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_PasswordHistory_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE TABLE [UserTimeInInfoLog] (
        [Id] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [FullName] nvarchar(50) NOT NULL,
        [UserName] nvarchar(50) NOT NULL,
        [Message] nvarchar(100) NOT NULL,
        [TimeLoggedIn] datetime2 NOT NULL,
        [TimeLoggedOut] datetime2 NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_UserTimeInInfoLog] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserTimeInInfoLog_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE TABLE [UserProfile] (
        [UserId] int NOT NULL,
        [UserName] nvarchar(max) NOT NULL,
        [UserNameAr] nvarchar(max) NOT NULL,
        [CivilNumber] int NULL,
        [NationalityId] int NULL,
        [DateOfBirth] datetime2 NULL,
        [CountryId] int NULL,
        [PassportNumber] nvarchar(max) NOT NULL,
        [PassportExpiryDate] datetime2 NULL,
        [PassportCountryId] int NULL,
        [VisaNumber] nvarchar(max) NOT NULL,
        [VisaExpiryDate] datetime2 NULL,
        [DateofDeath] datetime2 NULL,
        [Email] nvarchar(256) NOT NULL,
        [Address1] nvarchar(250) NOT NULL,
        [Address2] nvarchar(250) NOT NULL,
        [City] nvarchar(50) NOT NULL,
        [Zipcode] nvarchar(20) NOT NULL,
        [Gender] nvarchar(max) NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_UserProfile] PRIMARY KEY ([UserId]),
        CONSTRAINT [FK_UserProfile_AspNetUsers_UserId] FOREIGN KEY ([UserId]) REFERENCES [AspNetUsers] ([UserId]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserProfile_CountryLookup_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [CountryLookup] ([CountryId]),
        CONSTRAINT [FK_UserProfile_CountryLookup_PassportCountryId] FOREIGN KEY ([PassportCountryId]) REFERENCES [CountryLookup] ([CountryId]),
        CONSTRAINT [FK_UserProfile_NationalityLookup_NationalityId] FOREIGN KEY ([NationalityId]) REFERENCES [NationalityLookup] ([NationalityId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE INDEX [IX_PasswordHistory_UserId] ON [PasswordHistory] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE INDEX [IX_UserProfile_CountryId] ON [UserProfile] ([CountryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE INDEX [IX_UserProfile_NationalityId] ON [UserProfile] ([NationalityId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE INDEX [IX_UserProfile_PassportCountryId] ON [UserProfile] ([PassportCountryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    CREATE INDEX [IX_UserTimeInInfoLog_UserId] ON [UserTimeInInfoLog] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625124747_InitialCreate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230625124747_InitialCreate', N'7.0.5');
END;
GO

COMMIT;
GO

