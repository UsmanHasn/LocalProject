USE [SJCESP]
GO
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625155651_AlterTableLanguageLookup')
BEGIN
    ALTER TABLE [LanguageLookup] ADD [CreatedBy] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625155651_AlterTableLanguageLookup')
BEGIN
    ALTER TABLE [LanguageLookup] ADD [CreatedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625155651_AlterTableLanguageLookup')
BEGIN
    ALTER TABLE [LanguageLookup] ADD [Deleted] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625155651_AlterTableLanguageLookup')
BEGIN
    ALTER TABLE [LanguageLookup] ADD [LastModifiedBy] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625155651_AlterTableLanguageLookup')
BEGIN
    ALTER TABLE [LanguageLookup] ADD [LastModifiedDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625155651_AlterTableLanguageLookup')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230625155651_AlterTableLanguageLookup', N'7.0.5');
END;
GO

COMMIT;
GO

