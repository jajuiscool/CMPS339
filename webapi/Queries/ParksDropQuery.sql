--  This Query will drop the "Parks" table from the database "CMPS_339_AmusementPark" if it exists
--  If the table does not exist, it will print that

USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parks]') AND type in (N'U'))
BEGIN
	PRINT 'Table "Parks" does not exist';
END
ELSE
BEGIN
	DROP TABLE Parks;
END