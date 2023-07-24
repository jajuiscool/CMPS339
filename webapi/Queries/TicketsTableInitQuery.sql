IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tickets]') AND type in (N'U'))
BEGIN
    CREATE TABLE Tickets (
        Id INT PRIMARY KEY IDENTITY,
        AttractionId INT NOT NULL REFERENCES Attractions(Id)
    );
END
ELSE
BEGIN
	PRINT '"Tickets" table already exists!';
END