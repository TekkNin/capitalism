CREATE TABLE [dbo].[Towns]
(
	[Id]             NVARCHAR (50) NOT NULL,
    [Name]           NVARCHAR (50) NOT NULL,
	[Population]     INT NOT NULL,
	[PollutionLevel] INT NOT NULL,
    [ModifiedDate]   DATETIME2 (7) NOT NULL,
    [CreatedDate]    DATETIME2 (7) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
)
