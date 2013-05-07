
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/05/2013 21:14:32
-- Generated from EDMX file: C:\Users\sm\Documents\Visual Studio 2012\WebSites\WebSite2\App_Code\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [RideklubbenDatabase];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_RytterRiderpåHest_Hest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RytterRiderpåHest] DROP CONSTRAINT [FK_RytterRiderpåHest_Hest];
GO
IF OBJECT_ID(N'[dbo].[FK_RytterRiderpåHest_Rytter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[RytterRiderpåHest] DROP CONSTRAINT [FK_RytterRiderpåHest_Rytter];
GO
IF OBJECT_ID(N'[dbo].[FK_EjerEjerskab]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ejerskaber] DROP CONSTRAINT [FK_EjerEjerskab];
GO
IF OBJECT_ID(N'[dbo].[FK_HestEjerskab]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ejerskaber] DROP CONSTRAINT [FK_HestEjerskab];
GO
IF OBJECT_ID(N'[dbo].[FK_FaderHest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Heste] DROP CONSTRAINT [FK_FaderHest];
GO
IF OBJECT_ID(N'[dbo].[FK_Ejer_inherits_Rytter]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Ryttere_Ejer] DROP CONSTRAINT [FK_Ejer_inherits_Rytter];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Heste]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Heste];
GO
IF OBJECT_ID(N'[dbo].[Ryttere]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ryttere];
GO
IF OBJECT_ID(N'[dbo].[Ejerskaber]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ejerskaber];
GO
IF OBJECT_ID(N'[dbo].[Ryttere_Ejer]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Ryttere_Ejer];
GO
IF OBJECT_ID(N'[dbo].[RytterRiderpåHest]', 'U') IS NOT NULL
    DROP TABLE [dbo].[RytterRiderpåHest];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Heste'
CREATE TABLE [dbo].[Heste] (
    [HesteId] int IDENTITY(1,1) NOT NULL,
    [Navn] nvarchar(max)  NOT NULL,
    [Fødestald] nvarchar(max)  NOT NULL,
    [FødeDato] datetime  NOT NULL,
    [Højde] float  NOT NULL,
    [Vægt] float  NOT NULL,
    [Hingst] bit  NOT NULL,
    [BilledeSti] nvarchar(max)  NOT NULL,
    [Forælder_HesteId] int  NOT NULL
);
GO

-- Creating table 'Ryttere'
CREATE TABLE [dbo].[Ryttere] (
    [RytterId] int IDENTITY(1,1) NOT NULL,
    [Navn] nvarchar(max)  NOT NULL,
    [Fødselsdag] datetime  NOT NULL,
    [RytterAncinitet] datetimeoffset  NOT NULL,
    [BilledeSti] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Ejerskaber'
CREATE TABLE [dbo].[Ejerskaber] (
    [andele] smallint  NOT NULL,
    [EjerId] int  NOT NULL,
    [HesteID] int  NOT NULL,
    [Ejer_RytterId] int  NOT NULL,
    [Hest_HesteId] int  NOT NULL
);
GO

-- Creating table 'Ryttere_Ejer'
CREATE TABLE [dbo].[Ryttere_Ejer] (
    [RytterId] int  NOT NULL
);
GO

-- Creating table 'RytterRiderpåHest'
CREATE TABLE [dbo].[RytterRiderpåHest] (
    [Hest_HesteId] int  NOT NULL,
    [Rytter_RytterId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [HesteId] in table 'Heste'
ALTER TABLE [dbo].[Heste]
ADD CONSTRAINT [PK_Heste]
    PRIMARY KEY CLUSTERED ([HesteId] ASC);
GO

-- Creating primary key on [RytterId] in table 'Ryttere'
ALTER TABLE [dbo].[Ryttere]
ADD CONSTRAINT [PK_Ryttere]
    PRIMARY KEY CLUSTERED ([RytterId] ASC);
GO

-- Creating primary key on [EjerId], [HesteID] in table 'Ejerskaber'
ALTER TABLE [dbo].[Ejerskaber]
ADD CONSTRAINT [PK_Ejerskaber]
    PRIMARY KEY CLUSTERED ([EjerId], [HesteID] ASC);
GO

-- Creating primary key on [RytterId] in table 'Ryttere_Ejer'
ALTER TABLE [dbo].[Ryttere_Ejer]
ADD CONSTRAINT [PK_Ryttere_Ejer]
    PRIMARY KEY CLUSTERED ([RytterId] ASC);
GO

-- Creating primary key on [Hest_HesteId], [Rytter_RytterId] in table 'RytterRiderpåHest'
ALTER TABLE [dbo].[RytterRiderpåHest]
ADD CONSTRAINT [PK_RytterRiderpåHest]
    PRIMARY KEY NONCLUSTERED ([Hest_HesteId], [Rytter_RytterId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Hest_HesteId] in table 'RytterRiderpåHest'
ALTER TABLE [dbo].[RytterRiderpåHest]
ADD CONSTRAINT [FK_RytterRiderpåHest_Hest]
    FOREIGN KEY ([Hest_HesteId])
    REFERENCES [dbo].[Heste]
        ([HesteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Rytter_RytterId] in table 'RytterRiderpåHest'
ALTER TABLE [dbo].[RytterRiderpåHest]
ADD CONSTRAINT [FK_RytterRiderpåHest_Rytter]
    FOREIGN KEY ([Rytter_RytterId])
    REFERENCES [dbo].[Ryttere]
        ([RytterId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_RytterRiderpåHest_Rytter'
CREATE INDEX [IX_FK_RytterRiderpåHest_Rytter]
ON [dbo].[RytterRiderpåHest]
    ([Rytter_RytterId]);
GO

-- Creating foreign key on [Ejer_RytterId] in table 'Ejerskaber'
ALTER TABLE [dbo].[Ejerskaber]
ADD CONSTRAINT [FK_EjerEjerskab]
    FOREIGN KEY ([Ejer_RytterId])
    REFERENCES [dbo].[Ryttere_Ejer]
        ([RytterId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EjerEjerskab'
CREATE INDEX [IX_FK_EjerEjerskab]
ON [dbo].[Ejerskaber]
    ([Ejer_RytterId]);
GO

-- Creating foreign key on [Hest_HesteId] in table 'Ejerskaber'
ALTER TABLE [dbo].[Ejerskaber]
ADD CONSTRAINT [FK_HestEjerskab]
    FOREIGN KEY ([Hest_HesteId])
    REFERENCES [dbo].[Heste]
        ([HesteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_HestEjerskab'
CREATE INDEX [IX_FK_HestEjerskab]
ON [dbo].[Ejerskaber]
    ([Hest_HesteId]);
GO

-- Creating foreign key on [Forælder_HesteId] in table 'Heste'
ALTER TABLE [dbo].[Heste]
ADD CONSTRAINT [FK_FaderHest]
    FOREIGN KEY ([Forælder_HesteId])
    REFERENCES [dbo].[Heste]
        ([HesteId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_FaderHest'
CREATE INDEX [IX_FK_FaderHest]
ON [dbo].[Heste]
    ([Forælder_HesteId]);
GO

-- Creating foreign key on [RytterId] in table 'Ryttere_Ejer'
ALTER TABLE [dbo].[Ryttere_Ejer]
ADD CONSTRAINT [FK_Ejer_inherits_Rytter]
    FOREIGN KEY ([RytterId])
    REFERENCES [dbo].[Ryttere]
        ([RytterId])
    ON DELETE CASCADE ON UPDATE NO ACTION;
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------

SET IDENTITY_INSERT [dbo].[Heste] ON
INSERT INTO [dbo].[Heste] ([HesteId], [Navn], [Fødestald], [FødeDato], [Højde], [Vægt], [Hingst], [BilledeSti], [Forælder_HesteId]) VALUES (1, N'Stamfar', N'''''', N'2000-01-01 00:00:00', 1, 100, 1, N'images/Dansk_Varmblod.jpg', 1)
INSERT INTO [dbo].[Heste] ([HesteId], [Navn], [Fødestald], [FødeDato], [Højde], [Vægt], [Hingst], [BilledeSti], [Forælder_HesteId]) VALUES (2, N'Stammor', N'''''', N'2000-01-01 00:00:00', 1, 99, 0, N'images/20db8b3f-bd3e-4186-8a60-72128fdbf694.jpg', 2)
INSERT INTO [dbo].[Heste] ([HesteId], [Navn], [Fødestald], [FødeDato], [Højde], [Vægt], [Hingst], [BilledeSti], [Forælder_HesteId]) VALUES (3, N'Tarok', N'''''', N'1990-01-01 00:00:00', 140, 200, 1, N'images/Tarok på Grosbois 005.jpg', 1)
INSERT INTO [dbo].[Heste] ([HesteId], [Navn], [Fødestald], [FødeDato], [Højde], [Vægt], [Hingst], [BilledeSti], [Forælder_HesteId]) VALUES (5, N'føl', N'''''', N'2013-04-01 00:00:00', 21, 30, 1, N'images/Eva edit.jpg', 1)
SET IDENTITY_INSERT [dbo].[Heste] OFF


SET IDENTITY_INSERT [dbo].[Ryttere] ON
INSERT INTO [dbo].[Ryttere] ([RytterId], [Navn], [Fødselsdag], [RytterAncinitet], [BilledeSti]) VALUES (1, N'Julie', N'1999-09-20 00:00:00', N'08-01-2002 00:00:00 +02:00', N'')
INSERT INTO [dbo].[Ryttere] ([RytterId], [Navn], [Fødselsdag], [RytterAncinitet], [BilledeSti]) VALUES (2, N'Carola Karlsen', N'1952-01-01 00:00:00', N'01-01-2013 00:00:00 +01:00', N'images/ryttere/Carola_002.jpg')
SET IDENTITY_INSERT [dbo].[Ryttere] OFF

INSERT INTO [dbo].[RytterRiderpåHest] ([Hest_HesteId], [Rytter_RytterId]) VALUES (3, 2)
INSERT INTO [dbo].[RytterRiderpåHest] ([Hest_HesteId], [Rytter_RytterId]) VALUES (2, 2)
