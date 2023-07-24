USE SJCESP
GO
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230719134925_ModifyUserTable')
BEGIN
    ALTER TABLE [Users] ADD [IsLocked] bit NOT NULL DEFAULT CAST(0 AS bit);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230719134925_ModifyUserTable')
BEGIN
    ALTER TABLE [Users] ADD [LockedDate] datetime2 NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230719134925_ModifyUserTable')
BEGIN
    ALTER TABLE [Users] ADD [UserStatusId] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230719134925_ModifyUserTable')
BEGIN
    ALTER TABLE [Users] ADD [WrongPassword] int NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230719134925_ModifyUserTable')
BEGIN
    CREATE TABLE [UserStatusLookup] (
        [UserStatusId] int NOT NULL IDENTITY,
        [Name] nvarchar(100) NOT NULL,
        [NameAr] nvarchar(100) NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_UserStatusLookup] PRIMARY KEY ([UserStatusId])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230719134925_ModifyUserTable')
BEGIN
    CREATE INDEX [IX_Users_UserStatusId] ON [Users] ([UserStatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230719134925_ModifyUserTable')
BEGIN
    ALTER TABLE [Users] ADD CONSTRAINT [FK_Users_UserStatusLookup_UserStatusId] FOREIGN KEY ([UserStatusId]) REFERENCES [UserStatusLookup] ([UserStatusId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230719134925_ModifyUserTable')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230719134925_ModifyUserTable', N'7.0.5');
END;
GO

COMMIT;
GO

