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

CREATE TABLE [Adopters] (
    [AdopterId] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Email] nvarchar(150) NOT NULL,
    [Phone] nvarchar(25) NOT NULL,
    CONSTRAINT [PK_Adopters] PRIMARY KEY ([AdopterId])
);
GO

CREATE TABLE [Breeds] (
    [BreedId] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Species] nvarchar(50) NOT NULL,
    CONSTRAINT [PK_Breeds] PRIMARY KEY ([BreedId])
);
GO

CREATE TABLE [Shelters] (
    [ShelterId] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Address] nvarchar(200) NOT NULL,
    [Phone] nvarchar(25) NOT NULL,
    CONSTRAINT [PK_Shelters] PRIMARY KEY ([ShelterId])
);
GO

CREATE TABLE [Pets] (
    [PetId] int NOT NULL IDENTITY,
    [Name] nvarchar(100) NOT NULL,
    [Age] int NOT NULL,
    [Description] nvarchar(1000) NOT NULL,
    [AdoptionStatus] nvarchar(30) NOT NULL,
    [ShelterId] int NOT NULL,
    [BreedId] int NOT NULL,
    CONSTRAINT [PK_Pets] PRIMARY KEY ([PetId]),
    CONSTRAINT [FK_Pets_Breeds_BreedId] FOREIGN KEY ([BreedId]) REFERENCES [Breeds] ([BreedId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_Pets_Shelters_ShelterId] FOREIGN KEY ([ShelterId]) REFERENCES [Shelters] ([ShelterId]) ON DELETE NO ACTION
);
GO

CREATE TABLE [AdoptionApplications] (
    [AdoptionApplicationId] int NOT NULL IDENTITY,
    [PetId] int NOT NULL,
    [AdopterId] int NOT NULL,
    [ApplicationDate] datetime2 NOT NULL,
    [Status] nvarchar(30) NOT NULL,
    CONSTRAINT [PK_AdoptionApplications] PRIMARY KEY ([AdoptionApplicationId]),
    CONSTRAINT [FK_AdoptionApplications_Adopters_AdopterId] FOREIGN KEY ([AdopterId]) REFERENCES [Adopters] ([AdopterId]) ON DELETE NO ACTION,
    CONSTRAINT [FK_AdoptionApplications_Pets_PetId] FOREIGN KEY ([PetId]) REFERENCES [Pets] ([PetId]) ON DELETE NO ACTION
);
GO

CREATE INDEX [IX_AdoptionApplications_AdopterId] ON [AdoptionApplications] ([AdopterId]);
GO

CREATE INDEX [IX_AdoptionApplications_PetId] ON [AdoptionApplications] ([PetId]);
GO

CREATE INDEX [IX_Pets_BreedId] ON [Pets] ([BreedId]);
GO

CREATE INDEX [IX_Pets_ShelterId] ON [Pets] ([ShelterId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20261116152323_InitialCreate', N'8.0.34');
GO

COMMIT;
GO

