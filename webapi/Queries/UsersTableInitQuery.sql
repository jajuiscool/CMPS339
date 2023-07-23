USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE Users (
        Id INT PRIMARY KEY IDENTITY,
        Username VARCHAR NOT NULL,
        Password VARCHAR NOT NULL,
        IsActive BIT NOT NULL DEFAULT 1
    );
END
ELSE
BEGIN
	PRINT '"Users" table already exists!';
END