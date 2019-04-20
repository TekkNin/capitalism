CREATE TABLE [dbo].[BuildingInventory]
(
    [BuildingId]   NVARCHAR (50) NOT NULL,
    [ItemType]     NVARCHAR (50) NOT NULL,
    [Quantity]     INT           NOT NULL
    PRIMARY KEY CLUSTERED ([BuildingId], [ItemType]), 
    CONSTRAINT [FK_BuildingInventory_TownBuildings] FOREIGN KEY ([BuildingId]) REFERENCES [TownBuildings]([Id])
)
