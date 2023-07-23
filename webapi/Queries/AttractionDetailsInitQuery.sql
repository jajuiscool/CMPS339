USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttractionDetails]') AND type in (N'U'))
BEGIN
    CREATE TABLE AttractionDetails (
        Id INT PRIMARY KEY IDENTITY,
        AttractionId INT NOT NULL REFERENCES Attractions(Id),
        Name VARCHAR(30) NOT NULL,
        Capacity INTEGER NOT NULL CHECK (Capacity >= 1),
        OpenTime TIME NOT NULL,
        CloseTime TIME NOT NULL,
        MinimumAge INT NULL,
        MinimumHeight INT NULL,
        TicketPrice DECIMAL(5, 2) NOT NULL
    );
END
ELSE 
BEGIN
	PRINT 'Table "AttractionDetails" already exists!';
END