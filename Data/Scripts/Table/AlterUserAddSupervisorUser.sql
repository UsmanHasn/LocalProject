USE [SJCESP]
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230724125805_AlterUserAddSupervisorUser')
BEGIN
    ALTER TABLE [Users] ADD [SupervisorUserId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230724125805_AlterUserAddSupervisorUser')
BEGIN
    CREATE INDEX [IX_Users_SupervisorUserId] ON [Users] ([SupervisorUserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230724125805_AlterUserAddSupervisorUser')
BEGIN
    ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_Users_SupervisorUserId] FOREIGN KEY ([SupervisorUserId]) REFERENCES [Users] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230724125805_AlterUserAddSupervisorUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230724125805_AlterUserAddSupervisorUser', N'7.0.5');
END;
GO

COMMIT;
GO

