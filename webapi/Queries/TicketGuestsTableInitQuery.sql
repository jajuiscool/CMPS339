USE CMPS_339_AmusementPark;

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
ELSE
BEGIN
	PRINT '"TicketGuests" table already exists!';
END