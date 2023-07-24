-- This query will drop the 'Attractions' table if it exists, and print that it doesn't exist if it doesn't

USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attractions]') AND type in (N'U'))
BEGIN
	PRINT 'Table "Attractions" does not exist';
END
ELSE
BEGIN
	DROP TABLE Attractions;
END