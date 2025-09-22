CREATE DATABASE PhumlaKamnandiDB;
GO
USE PhumlaKamnandiDB;
GO

CREATE TABLE Hotel (
    HotelID INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Location NVARCHAR(255),
    PhoneNumber NVARCHAR(20),
    Email NVARCHAR(100)
);
GO

CREATE TABLE Room (
    RoomID INT IDENTITY(1,1) PRIMARY KEY,
    HotelID INT NOT NULL FOREIGN KEY REFERENCES Hotel(HotelID),
    RoomNumber NVARCHAR(10) NOT NULL,
    RoomType NVARCHAR(50) NOT NULL,
    PricePerNight DECIMAL(10, 2) NOT NULL,
    MaxOccupancy INT NOT NULL DEFAULT 4 CHECK (MaxOccupancy <= 4),
    IsAvailable BIT NOT NULL DEFAULT 1,
    UNIQUE (HotelID, RoomNumber)
);
GO

CREATE TABLE Staff (
    StaffID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Username NVARCHAR(50) NOT NULL UNIQUE,
    PasswordHash NVARCHAR(255) NOT NULL,
    Role NVARCHAR(50) NOT NULL,
    HotelID INT FOREIGN KEY REFERENCES Hotel(HotelID)
);
GO

CREATE TABLE Guest (
    GuestID INT IDENTITY(1,1) PRIMARY KEY,
    FirstName NVARCHAR(50) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    Email NVARCHAR(100),
    PhoneNumber NVARCHAR(20),
    DateOfBirth DATE,
    Address NVARCHAR(255)
);
GO

CREATE TABLE TravelAgency (
    AgencyID INT IDENTITY(1,1) PRIMARY KEY,
    AgencyName NVARCHAR(100) NOT NULL UNIQUE,
    ContactNumber NVARCHAR(20),
    ContactEmail NVARCHAR(100),
    Address NVARCHAR(255)
);
GO

CREATE TABLE Reservation (
    ReservationID INT IDENTITY(1,1) PRIMARY KEY,
    GuestID INT NOT NULL FOREIGN KEY REFERENCES Guest(GuestID),
    AgencyID INT NULL FOREIGN KEY REFERENCES TravelAgency(AgencyID),
    RoomID INT NOT NULL FOREIGN KEY REFERENCES Room(RoomID),
    StaffID INT NOT NULL FOREIGN KEY REFERENCES Staff(StaffID),
    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL,
    NumberOfAdults INT NOT NULL DEFAULT 1,
    NumberOfChildren INT NOT NULL DEFAULT 0,
    Status NVARCHAR(20) NOT NULL DEFAULT 'Confirmed',
    TotalCost DECIMAL(10, 2) NOT NULL,
    DateBooked DATETIME2 NOT NULL DEFAULT GETDATE(),
    CONSTRAINT CHK_CheckOutAfterCheckIn CHECK (CheckOutDate > CheckInDate)
);
GO

CREATE TABLE Payment (
    PaymentID INT IDENTITY(1,1) PRIMARY KEY,
    ReservationID INT NOT NULL FOREIGN KEY REFERENCES Reservation(ReservationID) ON DELETE CASCADE,
    Amount DECIMAL(10, 2) NOT NULL,
    PaymentDate DATETIME2 NOT NULL DEFAULT GETDATE(),
    PaymentMethod NVARCHAR(50) NOT NULL,
    Status NVARCHAR(50) NOT NULL DEFAULT 'Completed',
    Notes NVARCHAR(255) NULL
);
GO

CREATE TABLE Season (
    SeasonID INT IDENTITY(1,1) PRIMARY KEY,
    SeasonName NVARCHAR(50) NOT NULL,
    StartDate DATE NOT NULL,
    EndDate DATE NOT NULL,
    PriceMultiplier DECIMAL(5,2) NOT NULL
);
GO

INSERT INTO Hotel (Name, Location, PhoneNumber, Email) VALUES
('Phumla Kamnandi Cape Town', 'Cape Town, Western Cape', '+27 21 123 4567', 'ct@phumla.com'),
('Phumla Kamnandi Johannesburg', 'Johannesburg, Gauteng', '+27 11 765 4321', 'jhb@phumla.com');
GO

INSERT INTO Room (HotelID, RoomNumber, RoomType, PricePerNight, MaxOccupancy) VALUES
(1, '101', 'Standard', 550.00, 2),
(1, '102', 'Standard', 550.00, 2),
(1, '103', 'Standard', 550.00, 2),
(1, '104', 'Standard', 550.00, 2),
(1, '105', 'Standard', 550.00, 2);
GO

INSERT INTO Staff (FirstName, LastName, Username, PasswordHash, Role, HotelID) VALUES
('Sarah', 'Jones', 'sarah.jones', '$2a$12$r2Ru55bQ7U6sDwSdjqABC.SomeFakeHashedPasswordString123', 'Receptionist', 1),
('David', 'Smith', 'david.smith', '$2a$12$r2Ru55bQ7U6sDwSdjqABC.SomeFakeHashedPasswordString123', 'Manager', 1),
('Emily', 'Johnson', 'emily.johnson', '$2a$12$r2Ru55bQ7U6sDwSdjqABC.SomeFakeHashedPasswordString123', 'Receptionist', 2);
GO

INSERT INTO Guest (FirstName, LastName, Email, PhoneNumber, Address, DateOfBirth) VALUES
('John', 'Smith', 'john.smith@email.com', '021 123 4567', '7 Main Rd, Rondebosch, 7700', '1985-03-15'),
('Nkosinathi', 'Mthembu', 'nkosinathi.m@email.com', '031 555 7890', '14 Lungelo Drive, Mtimkhulu, Durban, 4001', '1990-07-22'),
('Sarah', 'Jones', 'sarah.jones@email.com', '082 111 2222', '1 Beach Rd, Sea Point, 8005', '1988-11-05'),
('David', 'Brown', 'david.brown@email.com', '011 777 3333', '45 Oak Ave, Johannesburg, 2000', '1978-09-14'),
('Amahle', 'Zulu', 'amahle.zulu@email.com', '083 444 5555', '67 Hillside Dr, Pietermaritzburg, 3201', '1992-12-30'),
('James', 'Wilson', 'james.wilson@email.com', '072 666 8888', '89 Valley Rd, Stellenbosch, 7600', '1982-04-18'),
('Lindiwe', 'Mbokodo', 'lindiwe.m@email.com', '084 999 0000', '123 Mountain View, Pretoria, 0002', '1995-01-25'),
('Michael', 'Taylor', 'michael.t@email.com', '021 555 1212', '5 Harbour Heights, Cape Town, 8001', '1975-08-12'),
('Nosipho', 'Khumalo', 'nosipho.k@email.com', '031 222 3434', '22 Palm Boulevard, Durban, 4000', '1989-06-08'),
('Robert', 'Davis', 'robert.davis@email.com', '011 888 9090', '33 Savannah Lane, Sandton, 2031', '1980-02-19');
GO

INSERT INTO TravelAgency (AgencyName, ContactNumber, ContactEmail, Address) VALUES
('Cape Town Adventures', '+27 21 987 6543', 'bookings@ctadventures.com', '123 Long Street, Cape Town'),
('SA Safari Tours', '+27 11 555 7890', 'info@sasafari.co.za', '456 Main Road, Johannesburg');
GO

INSERT INTO Season (SeasonName, StartDate, EndDate, PriceMultiplier) VALUES
('Low Season', '2025-12-01', '2025-12-07', 1.00),
('Mid Season', '2025-12-08', '2025-12-15', 1.3636),
('High Season', '2025-12-16', '2025-12-31', 1.8091);
GO

INSERT INTO Reservation (GuestID, RoomID, StaffID, CheckInDate, CheckOutDate, NumberOfAdults, NumberOfChildren, Status, TotalCost) VALUES
(1, 1, 1, '2025-12-25', '2025-12-27', 2, 0, 'Confirmed', (995 * 2)),
(3, 2, 1, '2025-12-25', '2025-12-27', 1, 1, 'Confirmed', (995 * 2)),
(4, 3, 1, '2025-12-25', '2025-12-27', 2, 0, 'Confirmed', (995 * 2)),
(5, 4, 1, '2025-12-25', '2025-12-27', 1, 0, 'Confirmed', (995 * 2)),
(6, 5, 1, '2025-12-25', '2025-12-27', 2, 0, 'Confirmed', (995 * 2)),
(7, 1, 1, '2025-12-27', '2025-12-29', 2, 0, 'Confirmed', (995 * 2)),
(8, 2, 1, '2025-12-27', '2025-12-29', 1, 0, 'Confirmed', (995 * 2)),
(9, 3, 1, '2025-12-27', '2025-12-29', 2, 0, 'Confirmed', (995 * 2)),
(10, 4, 1, '2025-12-27', '2025-12-29', 1, 1, 'Confirmed', (995 * 2)),
(2, 5, 1, '2025-12-01', '2025-12-03', 2, 0, 'Confirmed', (550 * 2)),
(3, 1, 1, '2025-12-10', '2025-12-12', 1, 0, 'Confirmed', (750 * 2));
GO

INSERT INTO Payment (ReservationID, Amount, PaymentDate, PaymentMethod, Status)
SELECT
    ReservationID,
    TotalCost * 0.10 AS DepositAmount,
    DATEADD(day, -15, CheckInDate) AS PaymentDate,
    'Credit Card' AS PaymentMethod,
    'Completed' AS Status
FROM Reservation;
GO