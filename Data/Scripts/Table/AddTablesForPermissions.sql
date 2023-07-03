USE [SJCESP]
GO
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703073237_AddTablesForPermissions')
BEGIN
    CREATE TABLE [Pages] (
        [PageId] int NOT NULL IDENTITY,
        [PageName] nvarchar(100) NOT NULL,
        [PageNameAr] nvarchar(max) NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Pages] PRIMARY KEY ([PageId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703073237_AddTablesForPermissions')
BEGIN
    CREATE TABLE [SystemSettings] (
        [SystemSettingId] int NOT NULL IDENTITY,
        [KeyName] nvarchar(max) NOT NULL,
        [KeyValue] nvarchar(max) NOT NULL,
        [Description] nvarchar(max) NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_SystemSettings] PRIMARY KEY ([SystemSettingId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703073237_AddTablesForPermissions')
BEGIN
    CREATE TABLE [RolePermissions] (
        [RolePermissionId] int NOT NULL IDENTITY,
        [RoleId] int NOT NULL,
        [PageId] int NOT NULL,
        [ReadPermission] bit NOT NULL,
        [WritePermission] bit NOT NULL,
        [DeletePermission] bit NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_RolePermissions] PRIMARY KEY ([RolePermissionId]),
        CONSTRAINT [FK_RolePermissions_Pages_PageId] FOREIGN KEY ([PageId]) REFERENCES [Pages] ([PageId]) ON DELETE CASCADE,
        CONSTRAINT [FK_RolePermissions_Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [Roles] ([RoleId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703073237_AddTablesForPermissions')
BEGIN
    CREATE INDEX [IX_RolePermissions_PageId] ON [RolePermissions] ([PageId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703073237_AddTablesForPermissions')
BEGIN
    CREATE INDEX [IX_RolePermissions_RoleId] ON [RolePermissions] ([RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703073237_AddTablesForPermissions')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230703073237_AddTablesForPermissions', N'7.0.5');
END;
GO

COMMIT;
GO

