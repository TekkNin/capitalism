CREATE TABLE [dbo].[TownBuildings]
(
	[Id]              NVARCHAR (50) NOT NULL,
    [TownId]          NVARCHAR (50) NOT NULL,
    [XCoordinate]     INT           NOT NULL,
	[YCoordinate]     INT           NOT NULL,
	[Name]            NVARCHAR (50) NOT NULL,
	[BuildingType]    NVARCHAR (50) NOT NULL, 
    CONSTRAINT [PK_TownBuildings] PRIMARY KEY ([Id]), 
    CONSTRAINT [FK_TownBuildings_Town] FOREIGN KEY ([TownId]) REFERENCES [Towns]([Id])
)
