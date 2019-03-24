USE [WeightLoss]
GO

/****** Объект: Table [dbo].[ClientRoles] Дата скрипта: 24.03.2019 16:04:58 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ClientRoles] (
    [ClientId] INT NOT NULL,
    [RoleId]   INT NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_ClientId]
    ON [dbo].[ClientRoles]([ClientId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_RoleId]
    ON [dbo].[ClientRoles]([RoleId] ASC);


GO
ALTER TABLE [dbo].[ClientRoles]
    ADD CONSTRAINT [PK_dbo.ClientRoles] PRIMARY KEY CLUSTERED ([ClientId] ASC, [RoleId] ASC);


GO
ALTER TABLE [dbo].[ClientRoles]
    ADD CONSTRAINT [FK_dbo.ClientRoles_dbo.Clients_ClientId] FOREIGN KEY ([ClientId]) REFERENCES [dbo].[Clients] ([ClientId]) ON DELETE CASCADE;


GO
ALTER TABLE [dbo].[ClientRoles]
    ADD CONSTRAINT [FK_dbo.ClientRoles_dbo.Roles_RoleId] FOREIGN KEY ([RoleId]) REFERENCES [dbo].[Roles] ([Id]) ON DELETE CASCADE;


