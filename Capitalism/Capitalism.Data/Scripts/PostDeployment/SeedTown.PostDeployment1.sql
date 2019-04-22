DECLARE @itemCount int

SELECT @itemCount = COUNT(*) FROM [Towns]

IF (@itemCount < 1)
BEGIN
	DECLARE @TownId NVARCHAR(50)
	SET @TownId = NEWID()

	INSERT INTO [Towns] ([Id], [Name], [Population], [AccountBalance], [PollutionLevel], [ModifiedDate], [CreatedDate]) VALUES (@TownId, 'Capitalville', 0, 0, 0, GETDATE(), GETDATE())

	INSERT INTO [TownBuildings] ([Id], [TownId], [XCoordinate], [YCoordinate], [Name], [BuildingType], [IsForSale], [Price], [ModifiedDate], [CreatedDate]) VALUES (NEWID(), @TownId, 0, 0, 'Mine', 'Mine', NULL, NULL, GETDATE(), GETDATE())
	INSERT INTO [TownBuildings] ([Id], [TownId], [XCoordinate], [YCoordinate], [Name], [BuildingType], [IsForSale], [Price], [ModifiedDate], [CreatedDate]) VALUES (NEWID(), @TownId, 1, 0, 'For Sale', 'EmptyLand', 1, 10, GETDATE(), GETDATE())
	INSERT INTO [TownBuildings] ([Id], [TownId], [XCoordinate], [YCoordinate], [Name], [BuildingType], [IsForSale], [Price], [ModifiedDate], [CreatedDate]) VALUES (NEWID(), @TownId, 2, 0, 'TownHall', 'TownHall', NULL, NULL, GETDATE(), GETDATE())
	INSERT INTO [TownBuildings] ([Id], [TownId], [XCoordinate], [YCoordinate], [Name], [BuildingType], [IsForSale], [Price], [ModifiedDate], [CreatedDate]) VALUES (NEWID(), @TownId, 3, 0, 'For Sale', 'EmptyLand', 1, 10, GETDATE(), GETDATE())
	INSERT INTO [TownBuildings] ([Id], [TownId], [XCoordinate], [YCoordinate], [Name], [BuildingType], [IsForSale], [Price], [ModifiedDate], [CreatedDate]) VALUES (NEWID(), @TownId, 4, 0, 'Forest', 'Forest', NULL, NULL, GETDATE(), GETDATE())

	INSERT INTO [TownBuildings] ([Id], [TownId], [XCoordinate], [YCoordinate], [Name], [BuildingType], [IsForSale], [Price], [ModifiedDate], [CreatedDate]) VALUES (NEWID(), @TownId, 0, 1, 'For Sale', 'EmptyLand', 1, 10, GETDATE(), GETDATE())
	INSERT INTO [TownBuildings] ([Id], [TownId], [XCoordinate], [YCoordinate], [Name], [BuildingType], [IsForSale], [Price], [ModifiedDate], [CreatedDate]) VALUES (NEWID(), @TownId, 1, 1, 'For Sale', 'EmptyLand', 1, 10, GETDATE(), GETDATE())
	INSERT INTO [TownBuildings] ([Id], [TownId], [XCoordinate], [YCoordinate], [Name], [BuildingType], [IsForSale], [Price], [ModifiedDate], [CreatedDate]) VALUES (NEWID(), @TownId, 2, 1, 'For Sale', 'EmptyLand', 1, 10, GETDATE(), GETDATE())
	INSERT INTO [TownBuildings] ([Id], [TownId], [XCoordinate], [YCoordinate], [Name], [BuildingType], [IsForSale], [Price], [ModifiedDate], [CreatedDate]) VALUES (NEWID(), @TownId, 3, 1, 'For Sale', 'EmptyLand', 1, 10, GETDATE(), GETDATE())
	INSERT INTO [TownBuildings] ([Id], [TownId], [XCoordinate], [YCoordinate], [Name], [BuildingType], [IsForSale], [Price], [ModifiedDate], [CreatedDate]) VALUES (NEWID(), @TownId, 4, 1, 'For Sale', 'EmptyLand', 1, 10, GETDATE(), GETDATE())	

END