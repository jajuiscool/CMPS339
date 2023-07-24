USE CMPS_339_AmusementPark;

IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketDetails]') AND type in (N'U'))
BEGIN
    CREATE TABLE TicketDetails (
        Id INT PRIMARY KEY IDENTITY,
        TicketId INT NOT NULL REFERENCES Tickets(Id)
    );
END
ELSE
BEGIN
	PRINT '"TicketDetails" table already exists!';
END