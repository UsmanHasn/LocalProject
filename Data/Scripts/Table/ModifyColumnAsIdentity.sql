USE [SJCESP]
GO
--BEGIN TRANSACTION;
--GO

--IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703084306_ModifyColumnasIdentity')
--BEGIN
--    DECLARE @var0 sysname;
--    SELECT @var0 = [d].[name]
--    FROM [sys].[default_constraints] [d]
--    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
--    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Users]') AND [c].[name] = N'UserId');
--    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Users] DROP CONSTRAINT [' + @var0 + '];');
--    ALTER TABLE [Users] DROP COLUMN [UserId];
--END;
--GO

--IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703084306_ModifyColumnasIdentity')
--BEGIN
--    ALTER TABLE [Users] ADD [UserId] int NOT NULL IDENTITY;
--END;
--GO

--IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703084306_ModifyColumnasIdentity')
--BEGIN
--    DECLARE @var1 sysname;
--    SELECT @var1 = [d].[name]
--    FROM [sys].[default_constraints] [d]
--    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
--    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserInRole]') AND [c].[name] = N'UserRoleId');
--    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [UserInRole] DROP CONSTRAINT [' + @var1 + '];');
--    ALTER TABLE [UserInRole] DROP COLUMN [UserRoleId];
--END;
--GO

--IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703084306_ModifyColumnasIdentity')
--BEGIN
--    ALTER TABLE [UserInRole] ADD [UserRoleId] int NOT NULL IDENTITY;
--END;
--GO

--IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703084306_ModifyColumnasIdentity')
--BEGIN
--    DECLARE @var2 sysname;
--    SELECT @var2 = [d].[name]
--    FROM [sys].[default_constraints] [d]
--    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
--    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Roles]') AND [c].[name] = N'RoleId');
--    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Roles] DROP CONSTRAINT [' + @var2 + '];');
--    ALTER TABLE [Roles] DROP COLUMN [RoleId];
--END;
--GO

--IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703084306_ModifyColumnasIdentity')
--BEGIN
--    ALTER TABLE [Roles] ADD [RoleId] int NOT NULL IDENTITY;
--END;
--GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230703084306_ModifyColumnasIdentity')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230703084306_ModifyColumnasIdentity', N'7.0.5');
END;
GO

--COMMIT;
--GO

