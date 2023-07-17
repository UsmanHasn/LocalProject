BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230716052003_AddTableDelegatedUserPermissions')
BEGIN
    CREATE TABLE [UserDelegatedPermissions] (
        [UserPermissionId] int NOT NULL IDENTITY,
        [UserId] int NOT NULL,
        [PageId] int NOT NULL,
        [ReadPermission] bit NOT NULL,
        [WritePermission] bit NOT NULL,
        [DeletePermission] bit NOT NULL,
        [DelegatedByUserId] int NOT NULL,
        [CreatedBy] nvarchar(50) NOT NULL,
        [CreatedDate] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(50) NOT NULL,
        [LastModifiedDate] datetime2 NOT NULL,
        [Deleted] bit NOT NULL,
        CONSTRAINT [PK_UserDelegatedPermissions] PRIMARY KEY ([UserPermissionId]),
        CONSTRAINT [FK_UserDelegatedPermissions_Pages_PageId] FOREIGN KEY ([PageId]) REFERENCES [Pages] ([PageId]) ON DELETE CASCADE,
        CONSTRAINT [FK_UserDelegatedPermissions_Users_UserId] FOREIGN KEY ([UserId]) REFERENCES [Users] ([UserId]) ON DELETE CASCADE
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230716052003_AddTableDelegatedUserPermissions')
BEGIN
    CREATE INDEX [IX_UserDelegatedPermissions_PageId] ON [UserDelegatedPermissions] ([PageId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230716052003_AddTableDelegatedUserPermissions')
BEGIN
    CREATE INDEX [IX_UserDelegatedPermissions_UserId] ON [UserDelegatedPermissions] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20230716052003_AddTableDelegatedUserPermissions')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20230716052003_AddTableDelegatedUserPermissions', N'7.0.5');
END;
GO

COMMIT;
GO

