USE [SJCESP]
GO
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230709123539_AlterPagesAddPageModules')
BEGIN
    ALTER TABLE [Pages] ADD [PageModuleAr] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230709123539_AlterPagesAddPageModules')
BEGIN
    ALTER TABLE [Pages] ADD [PageModuleEn] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230709123539_AlterPagesAddPageModules')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230709123539_AlterPagesAddPageModules', N'7.0.5');
END;
GO

COMMIT;
GO

