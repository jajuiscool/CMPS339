	IF NOT EXISTS
	(SELECT * FROM sys.objects WHERE
object_id = OBJECT_ID(N'[dbo].[Parks]')
AND type in (N'U'))


	BEGIN
		CREATE TABLE [dbo].[Parks]
		(
			Id INT PRIMARY KEY IDENTITY(1,1),
			[Name] VARCHAR(30) NOT NULL
		);
	END

IF NOT EXISTS
	(SELECT * FROM sys.objects WHERE
object_id = OBJECT_ID(N'[dbo].[Attractions]')
AND type in (N'U'))


	BEGIN
		CREATE TABLE [dbo].[Attractions]
		(
			Id INT PRIMARY KEY IDENTITY(1,1),
			ParkId INT NOT NULL,
			CONSTRAINT FK_Attractions_Parks
				FOREIGN KEY (ParkId) REFERENCES Parks(Id) ON DELETE CASCADE
		);
	END

IF NOT EXISTS
	(SELECT * FROM sys.objects WHERE
object_id = OBJECT_ID(N'[dbo].[AttractionDetails]')
AND type in (N'U'))


	BEGIN
		CREATE TABLE [dbo].[AttractionDetails]
		(
			Id INT PRIMARY KEY IDENTITY(1,1),
			AttractionId INT NOT NULL,
			CONSTRAINT FK_AttractionDetails_Attractions_Parks
				FOREIGN KEY (AttractionId) REFERENCES Attractions(Id) ON DELETE CASCADE,
			[Name] VARCHAR(30) NOT NULL,
			Capacity INT NOT NULL,
			CONSTRAINT Minimum_Capacity CHECK (Capacity > 0),
			OpenTime TIME NOT NULL,
			Closetime TIME NOT NULL,
			MinimumAge INT,
			MinimumHeight INT,
			TicketPrice DECIMAL(5,2)
		);
	END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE
object_id = OBJECT_ID(N'[dbo].[Tickets]')
AND type in (N'U'))

	BEGIN
		CREATE TABLE [dbo].[Tickets]
		(
		Id INT PRIMARY KEY IDENTITY(1,1),
		AttractionId INT NOT NULL,
		CONSTRAINT FK_Tickets_Attractions_Parks
			FOREIGN KEY (AttractionId) REFERENCES Attractions(Id) ON DELETE CASCADE,

		);

	END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE
object_id = OBJECT_ID(N'[dbo].[TicketDetails]')
AND type in (N'U'))

BEGIN
	CREATE TABLE [dbo].[TicketDetails]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	TicketId INT NOT NULL,
	CONSTRAINT FK_TicketDetails_Tickets_Attractions_Parks
		FOREIGN KEY (TicketId) REFERENCES Tickets(Id) ON DELETE CASCADE
	)
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE
object_id = OBJECT_ID(N'[dbo].[Users]')
AND type in (N'U'))

BEGIN
	CREATE TABLE [dbo].[Users]
	(
	Id INT PRIMARY KEY IDENTITY (1,1),
	Username VARCHAR NOT NULL,
	[Password] VARCHAR NOT NULL,
	IsActive BIT NOT NULL DEFAULT 1,
	);
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE
object_id = OBJECT_ID(N'[dbo].[UserDetails]')
AND type in (N'U'))

BEGIN
	CREATE TABLE [dbo].[UserDetails]
	(
	Id INT PRIMARY KEY IDENTITY(1,1),
	UserId INT NOT NULL,
	CONSTRAINT FK_UserDetails_UserS
		FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE, 
	Email VARCHAR NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	[Address] VARCHAR
	);
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE
object_id = OBJECT_ID(N'[dbo].[Guests]')
AND type in (N'U'))

BEGIN

	CREATE TABLE [dbo].[Guests]
	(
	Id INT PRIMARY KEY IDENTITY (1,1),
	UserId INT NOT NULL,
	CONSTRAINT FK_GUESTS_USERS
		FOREIGN KEY (UserId) REFERENCES Users(Id) ON DELETE CASCADE,
	FirstName VARCHAR NOT NULL,
	LastName VARCHAR NOT NULL,
	MiddleInitial VARCHAR(2),
	DateOfBirth DATE NOT NULL
	);
END

IF NOT EXISTS (SELECT * FROM sys.objects WHERE
object_id = OBJECT_ID(N'[dbo].[TicketGuests]')
AND type in (N'U'))

BEGIN

	CREATE TABLE TicketGuests
	(
		TicketId INT,
		GuestId INT,

		CONSTRAINT FK_TicketGuests_TicketS FOREIGN KEY (TicketId)
			REFERENCES Tickets(Id) ON DELETE CASCADE,
		CONSTRAINT FK_TicketGuests_Guests FOREIGN KEY (GuestId)
			REFERENCES Guests(Id) ON DELETE CASCADE
	)
	ALTER TABLE TicketGuests
		ADD CONSTRAINT PK_TicketGuests_GuestId UNIQUE(TicketId,GuestId)
	
END