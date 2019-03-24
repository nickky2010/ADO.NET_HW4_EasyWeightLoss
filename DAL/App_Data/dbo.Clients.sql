USE [WeightLoss]
GO

/****** Объект: Table [dbo].[Clients] Дата скрипта: 24.03.2019 16:05:06 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Clients] (
    [ClientId] INT            IDENTITY (1, 1) NOT NULL,
    [Nickname] NVARCHAR (10)  NOT NULL,
    [Password] NVARCHAR (MAX) NULL
);


