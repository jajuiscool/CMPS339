USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserDetails]') AND type in (N'U'))
BEGIN
    CREATE TABLE UserDetails (
        Id INT PRIMARY KEY IDENTITY,
        Email VARCHAR NOT NULL,
        PhoneNumber VARCHAR(20) CHECK (PhoneNumber LIKE '(___) ___-____'),
        Address VARCHAR NOT NULL,
        UserId INT NOT NULL REFERENCES Users(Id)
    );
END
ELSE
BEGIN
	PRINT '"UserDetails" table already exists!';
END