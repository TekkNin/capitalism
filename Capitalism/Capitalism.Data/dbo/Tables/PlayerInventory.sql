CREATE TABLE [dbo].[PlayerInventory]
(
    [PlayerId]     NVARCHAR (50) NOT NULL,
    [ItemType]     NVARCHAR (50) NOT NULL,
    [Quantity]     INT           NOT NULL
    PRIMARY KEY CLUSTERED ([PlayerId], [ItemType]), 
    CONSTRAINT [FK_PlayerInventory_Players] FOREIGN KEY ([PlayerId]) REFERENCES [Players]([Id])
)
