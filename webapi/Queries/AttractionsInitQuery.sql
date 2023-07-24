--  This query will create the 'Attractions' table if it does not already exist

USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attractions]') AND type in (N'U'))
AND EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parks]') AND type in (N'U'))
--  Basically, the if statement checks if the 'Attractions' table does not exist and if the 'Parks' table does exist
--  We need to check both because to create the table, we need to reference 'Parks'
BEGIN
	CREATE TABLE Attractions (
		Id INT IDENTITY(1,1) PRIMARY KEY,
		ParkId INT NOT NULL REFERENCES Parks(Id)
	);
END
ELSE IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attractions]') AND type in (N'U')) 
--  If 'Attractions' already exists, then print that it does
BEGIN
	PRINT 'Table "Attractions" already exists';
END
ELSE
--  If the 'Attractions' table does not exist, and earlier the code did not enter the table creation block,
--  then that means that the "Parks" table doesn't exist, as that is the only condition left that could be false
BEGIN
	PRINT 'Table "Parks" does not exist';
END