DECLARE @itemCount int

SELECT @itemCount = COUNT(*) FROM [Towns]

IF (@itemCount < 1)
BEGIN
	INSERT INTO [Towns] ([Id], [Name], [Population], [PollutionLevel], [ModifiedDate], [CreatedDate]) VALUES (NEWID(), 'Capitalville', 0, 0, GETDATE(), GETDATE())
END