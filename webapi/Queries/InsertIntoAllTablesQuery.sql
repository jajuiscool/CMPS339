-- Insert into the 'Parks' table
INSERT INTO Parks (Name)
VALUES ('Wonderland Park'),
       ('Adventure World'),
       ('Fantasyland Park');

-- Insert into the 'Attractions' table
INSERT INTO Attractions (ParkId)
VALUES (1),
       (1),
       (2),
       (2),
       (3);

-- Insert into the 'AttractionDetails' table
INSERT INTO AttractionDetails (AttractionId, Name, Capacity, OpenTime, CloseTime, MinimumAge, MinimumHeight, TicketPrice)
VALUES (1, 'Roller Coaster', 50, '09:00', '18:00', 12, 48, 25.00),
       (2, 'Ferris Wheel', 30, '10:00', '20:00', 8, NULL, 10.00),
       (3, 'Water Slide', 40, '11:00', '19:00', 10, 40, 15.00),
       (4, 'Bumper Cars', 20, '12:00', '21:00', 5, NULL, 8.00),
       (5, 'Haunted House', 15, '10:30', '19:30', 14, NULL, 12.50);

-- Insert into the 'Tickets' table
INSERT INTO Tickets (AttractionId)
VALUES (1),
       (2),
       (3),
       (4),
       (5);

-- Insert into the 'TicketDetails' table
INSERT INTO TicketDetails (TicketId)
VALUES (1),
       (2),
       (3),
       (4),
       (5);

-- Insert into the 'Users' table
INSERT INTO Users (Username, Password, IsActive)
VALUES ('user1', 'password1', 1),
       ('user2', 'password2', 1),
       ('user3', 'password3', 0);

-- Insert into the 'UserDetails' table
INSERT INTO UserDetails (Email, PhoneNumber, Address, UserId)
VALUES ('user1@example.com', '(123) 456-7890', '123 Main St, City', 1),
       ('user2@example.com', '(987) 654-3210', '456 Oak Ave, Town', 2),
       ('user3@example.com', '(111) 222-3333', '789 Elm Rd, Village', 3);

-- Insert into the 'Guests' table
INSERT INTO Guests (UserId, FirstName, LastName, MiddleInitial, DateOfBirth)
VALUES (1, 'John', 'Doe', 'A', '1990-05-15'),
       (2, 'Jane', 'Smith', 'B', '1985-12-03'),
       (3, 'Michael', 'Johnson', 'C', '2002-09-22');

-- Insert into the 'TicketGuests' table (Composite Key)
INSERT INTO TicketGuests (TicketId, GuestId)
VALUES (1, 1),
       (1, 2),
       (2, 1),
       (3, 2),
       (4, 3),
       (5, 1);
