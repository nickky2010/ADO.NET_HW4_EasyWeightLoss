USE [WeightLoss]
GO

/****** Объект: Table [dbo].[Products] Дата скрипта: 24.03.2019 16:05:14 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Products] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [Name]        NVARCHAR (MAX) NULL,
    [EnergyValue] INT            NOT NULL
);


