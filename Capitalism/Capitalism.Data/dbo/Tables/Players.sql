CREATE TABLE [dbo].[Players] (
    [Id]           NVARCHAR (50) NOT NULL,
    [UserId]       NVARCHAR (50) NOT NULL,
    [DisplayName]  NVARCHAR (50) NOT NULL,
    [Health]       INT           NOT NULL,
    [Energy]       INT           NOT NULL,
    [Happiness]    INT           NOT NULL,
    [Swagger]      INT           NOT NULL,
    [MoneyOnHand]  BIGINT        NOT NULL,
	[Carpentry]    INT           NOT NULL,
	[Cooking]      INT           NOT NULL,
	[Science]      INT           NOT NULL,
	[Technology]   INT           NOT NULL,
    [ModifiedDate] DATETIME2 (7) NOT NULL,
    [CreatedDate]  DATETIME2 (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Players_UserId]
    ON [dbo].[Players]([UserId] ASC);

