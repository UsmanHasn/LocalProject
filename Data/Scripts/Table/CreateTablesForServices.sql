USE [SJCESP]
GO
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703052108_CreateTablesForServices')
BEGIN
    CREATE TABLE [ServiceCategoryLookup] (
        [ServiceCategoryId] int NOT NULL IDENTITY(1,1),
        [Name] nvarchar(50) NOT NULL,
        [NameAr] nvarchar(max) NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_ServiceCategoryLookup] PRIMARY KEY ([ServiceCategoryId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703052108_CreateTablesForServices')
BEGIN
    CREATE TABLE [ServiceSubCategoryLookup] (
        [ServiceSubCategoryId] int NOT NULL IDENTITY(1,1),
        [ServiceCategoryId] int NULL,
        [Name] nvarchar(50) NOT NULL,
        [NameAr] nvarchar(max) NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_ServiceSubCategoryLookup] PRIMARY KEY ([ServiceSubCategoryId]),
        CONSTRAINT [FK_ServiceSubCategoryLookup_ServiceCategoryLookup_ServiceCategoryId] FOREIGN KEY ([ServiceCategoryId]) REFERENCES [ServiceCategoryLookup] ([ServiceCategoryId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703052108_CreateTablesForServices')
BEGIN
    CREATE TABLE [Services] (
        [ServiceId] int NOT NULL IDENTITY(1,1),
        [ServiceSubCategoryId] int NULL,
        [Name] nvarchar(50) NOT NULL,
        [NameAr] nvarchar(max) NOT NULL,
        [Sequence] int NULL,
        [IsActive] bit NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_Services] PRIMARY KEY ([ServiceId]),
        CONSTRAINT [FK_Services_ServiceSubCategoryLookup_ServiceSubCategoryId] FOREIGN KEY ([ServiceSubCategoryId]) REFERENCES [ServiceSubCategoryLookup] ([ServiceSubCategoryId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703052108_CreateTablesForServices')
BEGIN
    CREATE INDEX [IX_Services_ServiceSubCategoryId] ON [Services] ([ServiceSubCategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703052108_CreateTablesForServices')
BEGIN
    CREATE INDEX [IX_ServiceSubCategoryLookup_ServiceCategoryId] ON [ServiceSubCategoryLookup] ([ServiceCategoryId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703052108_CreateTablesForServices')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230703052108_CreateTablesForServices', N'7.0.5');
END;
GO

COMMIT;
GO

