USE [WeightLoss]
GO

/****** Объект: Table [dbo].[Roles] Дата скрипта: 24.03.2019 16:05:22 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Roles] (
    [Id]       INT            IDENTITY (1, 1) NOT NULL,
    [RoleName] NVARCHAR (MAX) NULL
);


