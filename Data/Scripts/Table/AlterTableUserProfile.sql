Use [SJCESP]
GO
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625125244_AlterTableUserProfile')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserProfile]') AND [c].[name] = N'Address1');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [UserProfile] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [UserProfile] DROP COLUMN [Address1];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625125244_AlterTableUserProfile')
BEGIN
    EXEC sp_rename N'[UserProfile].[Zipcode]', N'WayNumber', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625125244_AlterTableUserProfile')
BEGIN
    EXEC sp_rename N'[UserProfile].[Address2]', N'BuildingNumber', N'COLUMN';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625125244_AlterTableUserProfile')
BEGIN
    ALTER TABLE [UserProfile] ADD [PhoneNumber] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625125244_AlterTableUserProfile')
BEGIN
    ALTER TABLE [UserProfile] ADD [TelephoneNumber] nvarchar(50) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230625125244_AlterTableUserProfile')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230625125244_AlterTableUserProfile', N'7.0.5');
END;
GO

COMMIT;
GO

