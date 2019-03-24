USE [WeightLoss]
GO

/****** Объект: Table [dbo].[__MigrationHistory] Дата скрипта: 24.03.2019 16:04:11 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[__MigrationHistory] (
    [MigrationId]    NVARCHAR (150)  NOT NULL,
    [ContextKey]     NVARCHAR (300)  NOT NULL,
    [Model]          VARBINARY (MAX) NOT NULL,
    [ProductVersion] NVARCHAR (32)   NOT NULL
);


