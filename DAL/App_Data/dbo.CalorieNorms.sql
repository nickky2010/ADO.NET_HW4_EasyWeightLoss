USE [WeightLoss]
GO

/****** Объект: Table [dbo].[CalorieNorms] Дата скрипта: 24.03.2019 16:04:36 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[CalorieNorms] (
    [Id]               INT IDENTITY (1, 1) NOT NULL,
    [Sex]              INT NOT NULL,
    [MinAge]           INT NOT NULL,
    [MaxAge]           INT NOT NULL,
    [Level]            INT NOT NULL,
    [CalorieRange_Min] INT NOT NULL,
    [CalorieRange_Max] INT NOT NULL
);


