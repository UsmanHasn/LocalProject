USE [SJCESP]
GO
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    DROP TABLE [AspNetRoles];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    DROP TABLE [PasswordHistory];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    DROP TABLE [UserProfile];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    DROP TABLE [UserTimeInInfoLog];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    DROP TABLE [AspNetUsers];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    CREATE TABLE [Roles] (
        [RoleId] int NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [NameAr] nvarchar(50) NOT NULL,
        [Description] nvarchar(100) NOT NULL,
        [DescriptionAr] nvarchar(50) NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Roles] PRIMARY KEY ([RoleId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    CREATE TABLE [Users] (
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
        [BuildingNumber] nvarchar(250) NOT NULL,
        [City] nvarchar(50) NOT NULL,
        [WayNumber] nvarchar(20) NOT NULL,
        [PhoneNumber] nvarchar(50) NOT NULL,
        [TelephoneNumber] nvarchar(50) NOT NULL,
        [Gender] nvarchar(max) NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Users] PRIMARY KEY ([UserId]),
        CONSTRAINT [FK_Users_CountryLookup_CountryId] FOREIGN KEY ([CountryId]) REFERENCES [CountryLookup] ([CountryId]),
        CONSTRAINT [FK_Users_CountryLookup_PassportCountryId] FOREIGN KEY ([PassportCountryId]) REFERENCES [CountryLookup] ([CountryId]),
        CONSTRAINT [FK_Users_NationalityLookup_NationalityId] FOREIGN KEY ([NationalityId]) REFERENCES [NationalityLookup] ([NationalityId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    CREATE TABLE [UserInRole] (
        [UserRoleId] int NOT NULL,
        [UserId] int NOT NULL,
        [RoleId] int NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_UserInRole] PRIMARY KEY ([UserRoleId]),
        CONSTRAINT [FK_UserInRole_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([RoleId]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserInRole_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    CREATE INDEX [IX_UserInRole_RoleId] ON [UserInRole] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    CREATE INDEX [IX_UserInRole_UserId] ON [UserInRole] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    CREATE INDEX [IX_Users_CountryId] ON [Users] ([CountryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    CREATE INDEX [IX_Users_NationalityId] ON [Users] ([NationalityId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    CREATE INDEX [IX_Users_PassportCountryId] ON [Users] ([PassportCountryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230626144136_RemoveTestingTablesAndAddNew')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230626144136_RemoveTestingTablesAndAddNew', N'7.0.5');
END;
GO

COMMIT;
GO

