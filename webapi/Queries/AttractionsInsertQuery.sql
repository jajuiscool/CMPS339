USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attractions]') AND type in (N'U')) -- Checks to see if table exists
BEGIN
	PRINT 'Table "Attractions" does not exist';  --  If it doesn't exist, print that it doesn't
END
ELSE
BEGIN  --  If the table does exist, check to see if any of the entries have the same name as the insert
	DECLARE @Exists INT;
	SELECT @Exists = COUNT(*) FROM Attractions WHERE ParkId = (1);

	IF @Exists > 0
	BEGIN --  If there is a entry that already has that name, print that
		PRINT 'The park already exists in the "Attractions" database.';
	END
	ELSE  --  Otherwise, add the park into the 'Parks' table
		INSERT INTO Attractions (ParkId) VALUES (1);
END