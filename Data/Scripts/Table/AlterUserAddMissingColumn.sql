USE SJCESP
GO
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'CivilNumber');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
    EXEC(N'UPDATE [Users] SET [CivilNumber] = N'''' WHERE [CivilNumber] IS NULL');
    ALTER TABLE [Users] ALTER COLUMN [CivilNumber] nvarchar(max) NOT NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [CivilExpiryDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [Towncode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [Towndesc_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [Wilayatcode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [Wilayatdesc_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [name_1_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [name_2_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [name_3_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [name_4_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [name_5_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [name_6_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [Users] ADD [title_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [UserDelegatedPermissions] ADD [EffFrom] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    ALTER TABLE [UserDelegatedPermissions] ADD [EffTo] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727115806_AlterUserAddMissingColumn')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230727115806_AlterUserAddMissingColumn', N'7.0.5');
END;
GO

COMMIT;
GO

