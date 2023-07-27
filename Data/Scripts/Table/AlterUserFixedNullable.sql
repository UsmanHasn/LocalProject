BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'title_ar');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Users] ALTER COLUMN [title_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'name_6_ar');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Users] ALTER COLUMN [name_6_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'name_5_ar');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Users] ALTER COLUMN [name_5_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'name_4_ar');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Users] ALTER COLUMN [name_4_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'name_3_ar');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [Users] ALTER COLUMN [name_3_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'name_2_ar');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [Users] ALTER COLUMN [name_2_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'name_1_ar');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [Users] ALTER COLUMN [name_1_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Wilayatdesc_ar');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Wilayatdesc_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Wilayatcode');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Wilayatcode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'WayNumber');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [Users] ALTER COLUMN [WayNumber] nvarchar(20) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'VisaNumber');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [Users] ALTER COLUMN [VisaNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Towndesc_ar');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Towndesc_ar] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Towncode');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Towncode] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'TelephoneNumber');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [Users] ALTER COLUMN [TelephoneNumber] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'PhoneNumber');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [Users] ALTER COLUMN [PhoneNumber] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'PassportNumber');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [Users] ALTER COLUMN [PassportNumber] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'Gender');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [Users] ALTER COLUMN [Gender] nvarchar(max) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'CivilExpiryDate');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Users] ALTER COLUMN [CivilExpiryDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'City');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [Users] ALTER COLUMN [City] nvarchar(50) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'BuildingNumber');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [Users] ALTER COLUMN [BuildingNumber] nvarchar(250) NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    ALTER TABLE [Users] ADD [isEmailVerified] bit NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    ALTER TABLE [Users] ADD [isPhoneVerified] bit NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230727131818_AlterUserFixedNullable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230727131818_AlterUserFixedNullable', N'7.0.5');
END;
GO

COMMIT;
GO

