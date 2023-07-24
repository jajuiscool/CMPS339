--  This query is an example of a script that will check to see if the 'Parks' table exists in 'CMPS_339_AmusementPark'
--  and then will add a new entry to it.  If it doesn't exist, it will print that

USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parks]') AND type in (N'U')) -- Checks to see if table exists
BEGIN
	PRINT 'Table "Parks" does not exist';  --  If it doesn't exist, print that it doesn't
END
ELSE
BEGIN  --  If the table does exist, check to see if any of the entries have the same name as the insert
	DECLARE @Exists INT;
	SELECT @Exists = COUNT(*) FROM Parks WHERE Name = 'Disneyland';

	IF @Exists > 0
	BEGIN --  If there is a entry that already has that name, print that
		PRINT 'The park already exists in the "Parks" database.';
	END
	ELSE  --  Otherwise, add the park into the 'Parks' table
		INSERT INTO Parks (Name) VALUES ('Disneyland');
END