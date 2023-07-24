USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Guests]') AND type in (N'U'))
BEGIN
    CREATE TABLE Guests (
        Id INT PRIMARY KEY IDENTITY,
        UserId INT NOT NULL REFERENCES Users(Id),
        FirstName VARCHAR NOT NULL,
        LastName VARCHAR NOT NULL,
        MiddleInitial VARCHAR(2) NOT NULL,
        DateOfBirth DATE NOT NULL
    );
END
ELSE
BEGIN
	PRINT '"Guests" table already exists!';
END