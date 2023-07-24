USE [SJCESP]
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230724130943_AlterUserAddLastLoginDate')
BEGIN
    ALTER TABLE [Users] ADD [LastLoginDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230724130943_AlterUserAddLastLoginDate')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230724130943_AlterUserAddLastLoginDate', N'7.0.5');
END;
GO

COMMIT;
GO

