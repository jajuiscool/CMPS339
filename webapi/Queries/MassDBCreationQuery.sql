USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'CMPS_339_AmusementPark')
BEGIN
    -- Step b: Create a new database
    CREATE DATABASE CMPS_339_AmusementPark;
    PRINT 'Database Created.';
END
ELSE
BEGIN
    -- Step c: Database already exists
    PRINT 'Database already exists.';
END

-- Check and create the 'Parks' table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parks]') AND type in (N'U'))
BEGIN
    CREATE TABLE Parks (
        Id INT PRIMARY KEY IDENTITY,
        Name VARCHAR(30) NOT NULL
    );
END

-- Check and create the 'Attractions' table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attractions]') AND type in (N'U'))
BEGIN
    CREATE TABLE Attractions (
        Id INT PRIMARY KEY IDENTITY,
        ParkId INT NOT NULL REFERENCES Parks(Id)
    );
END

-- Check and create the 'AttractionDetails' table
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

-- Check and create the 'Tickets' table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tickets]') AND type in (N'U'))
BEGIN
    CREATE TABLE Tickets (
        Id INT PRIMARY KEY IDENTITY,
        AttractionId INT NOT NULL REFERENCES Attractions(Id)
    );
END

-- Check and create the 'TicketDetails' table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketDetails]') AND type in (N'U'))
BEGIN
    CREATE TABLE TicketDetails (
        Id INT PRIMARY KEY IDENTITY,
        TicketId INT NOT NULL REFERENCES Tickets(Id)
    );
END

-- Check and create the 'Users' table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    CREATE TABLE Users (
        Id INT PRIMARY KEY IDENTITY,
        Username VARCHAR NOT NULL,
        Password VARCHAR NOT NULL,
        IsActive BIT NOT NULL DEFAULT 1
    );
END

-- Check and create the 'UserDetails' table
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

-- Check and create the 'Guests' table
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

-- Check and create the 'TicketGuests' table
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketGuests]') AND type in (N'U'))
BEGIN
    CREATE TABLE TicketGuests (
        TicketId INT,
        GuestId INT,
        PRIMARY KEY (TicketId, GuestId),
        FOREIGN KEY (TicketId) REFERENCES Tickets(Id),
        FOREIGN KEY (GuestId) REFERENCES Guests(Id)
    );
END