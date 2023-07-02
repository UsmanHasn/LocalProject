USE [SJCESP]
GO
BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702054831_AlterTableUsersAddPassword')
BEGIN
    ALTER TABLE [Users] ADD [Password] nvarchar(max) NOT NULL DEFAULT N'';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702054831_AlterTableUsersAddPassword')
BEGIN
    CREATE TABLE [UserActivityInfoLog] (
        [ActivityId] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [PageName] nvarchar(100) NOT NULL,
        [Message] nvarchar(200) NOT NULL,
        [TimeLoggedIn] datetime2 NOT NULL,
        [TimeLoggedOut] datetime2 NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_UserActivityInfoLog] PRIMARY KEY ([ActivityId]),
        CONSTRAINT [FK_UserActivityInfoLog_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702054831_AlterTableUsersAddPassword')
BEGIN
    CREATE INDEX [IX_UserActivityInfoLog_UserId] ON [UserActivityInfoLog] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230702054831_AlterTableUsersAddPassword')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230702054831_AlterTableUsersAddPassword', N'7.0.5');
END;
GO

COMMIT;
GO

