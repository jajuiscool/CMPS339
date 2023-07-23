-- This Query will check to see if the table 'Parks' exists in the database 'CMPS_339_AmusementPark'
-- If the table exists, it will print out a statement saying so
-- If the table doesn't exist, it will create the table

USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parks]') AND type in (N'U'))
BEGIN
	CREATE TABLE Parks (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		Name VARCHAR(30) NOT NULL
	);
END
ELSE
BEGIN
	PRINT 'Table "Parks" already exists';
END