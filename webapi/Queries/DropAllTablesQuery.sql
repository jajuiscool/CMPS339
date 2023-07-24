-- Drop the 'TicketGuests' table
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketGuests]') AND type in (N'U'))
BEGIN
    DROP TABLE TicketGuests;
END

-- Drop the 'Guests' table
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Guests]') AND type in (N'U'))
BEGIN
    DROP TABLE Guests;
END

-- Drop the 'UserDetails' table
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[UserDetails]') AND type in (N'U'))
BEGIN
    DROP TABLE UserDetails;
END

-- Drop the 'Users' table
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Users]') AND type in (N'U'))
BEGIN
    DROP TABLE Users;
END

-- Drop the 'TicketDetails' table
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[TicketDetails]') AND type in (N'U'))
BEGIN
    DROP TABLE TicketDetails;
END

-- Drop the 'Tickets' table
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Tickets]') AND type in (N'U'))
BEGIN
    DROP TABLE Tickets;
END

-- Drop the 'AttractionDetails' table
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[AttractionDetails]') AND type in (N'U'))
BEGIN
    DROP TABLE AttractionDetails;
END

-- Drop the 'Attractions' table
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Attractions]') AND type in (N'U'))
BEGIN
    DROP TABLE Attractions;
END

-- Drop the 'Parks' table
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parks]') AND type in (N'U'))
BEGIN
    DROP TABLE Parks;
END
