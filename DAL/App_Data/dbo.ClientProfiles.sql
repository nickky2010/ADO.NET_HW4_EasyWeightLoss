USE [WeightLoss]
GO

/****** Объект: Table [dbo].[ClientProfiles] Дата скрипта: 24.03.2019 16:04:49 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClientProfiles] (
    [ClientId]      INT NOT NULL,
    [Age]           INT NOT NULL,
    [Sex]           INT NOT NULL,
    [ActivityLevel] INT NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_ClientId]
    ON [dbo].[ClientProfiles]([ClientId] ASC);


GO
ALTER TABLE [dbo].[ClientProfiles]
    ADD CONSTRAINT [PK_dbo.ClientProfiles] PRIMARY KEY CLUSTERED ([ClientId] ASC);


GO
ALTER TABLE [dbo].[ClientProfiles]
    ADD CONSTRAINT [FK_dbo.ClientProfiles_dbo.Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([ClientId]);


