IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211208171611_InitialMigrations')
BEGIN
    CREATE TABLE [Occasions] (
        [Id] int NOT NULL IDENTITY,
        [Name] nvarchar(max) NULL,
        [About] nvarchar(max) NULL,
        [Description] VarChar(Max) NULL,
        [StartDate] datetime2 NOT NULL,
        [EndDate] datetime2 NOT NULL,
        [FeatureImageUrl] nvarchar(max) NULL,
        [ImageId] int NOT NULL,
        [AgeLimit] nvarchar(max) NULL,
        [IsPhysicalEvent] bit NOT NULL,
        [IsVirtualEvent] bit NOT NULL,
        [City] nvarchar(max) NULL,
        [CreatedBy] nvarchar(max) NULL,
        [Created] datetime2 NOT NULL,
        [LastModifiedBy] nvarchar(max) NULL,
        [LastModified] datetime2 NULL,
        CONSTRAINT [PK_Occasions] PRIMARY KEY ([Id])
    );
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20211208171611_InitialMigrations')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20211208171611_InitialMigrations', N'6.0.0');
END;
GO

COMMIT;
GO

