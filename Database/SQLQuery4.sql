IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = 'PhumlaKamnandiHotelsDB')
BEGIN
    CREATE DATABASE PhumlaKamnandiHotelsDB;
END
GO

USE PhumlaKamnandiHotelsDB;
GO
CREATE TABLE Hotels (
    HotelID INT PRIMARY KEY IDENTITY,
    HotelName VARCHAR(100) NOT NULL,
    Location VARCHAR(100),
    ManagerName VARCHAR(100),
    Phone VARCHAR(20),
    Email VARCHAR(100)
);
GO


CREATE TABLE Rooms (
    RoomID INT PRIMARY KEY IDENTITY,
    HotelID INT NOT NULL,
    RoomNumber VARCHAR(10) NOT NULL,
    RoomType VARCHAR(20) CHECK(RoomType IN ('Standard','Family','Deluxe')),
    MaxOccupancy INT DEFAULT 4,
    Status VARCHAR(20) CHECK(Status IN ('Available','Occupied','OutOfService')),
    FOREIGN KEY (HotelID) REFERENCES Hotels(HotelID)
);
GO


CREATE TABLE Guests (
    GuestID INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    IDNumber VARCHAR(20),
    PassportNo VARCHAR(20),
    Phone VARCHAR(20),
    Email VARCHAR(100),
    Address VARCHAR(200),
    LoyaltyPoints INT DEFAULT 0
);
GO


CREATE TABLE Reservations (
    ReservationID INT PRIMARY KEY IDENTITY,
    GuestID INT NOT NULL,
    ReservationDate DATE NOT NULL,
    CheckInDate DATE NOT NULL,
    CheckOutDate DATE NOT NULL,
    NumberOfGuests INT CHECK(NumberOfGuests <= 4),
    BookingStatus VARCHAR(20) CHECK(BookingStatus IN ('Pending','Confirmed','Cancelled')),
    PaymentStatus VARCHAR(20) CHECK(PaymentStatus IN ('Paid','Deposit','Outstanding')),
    FOREIGN KEY (GuestID) REFERENCES Guests(GuestID)
);
GO


CREATE TABLE ReservationRooms (
    ReservationRoomID INT PRIMARY KEY IDENTITY,
    ReservationID INT NOT NULL,
    RoomID INT NOT NULL,
    RateApplied DECIMAL(10,2),
    DiscountApplied DECIMAL(10,2),
    FOREIGN KEY (ReservationID) REFERENCES Reservations(ReservationID),
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID)
);
GO


CREATE TABLE RoomAllocation (
    AllocationID INT PRIMARY KEY IDENTITY,
    RoomID INT NOT NULL,
    DateAllocated DATE NOT NULL,
    ReservationID INT NOT NULL,
    FOREIGN KEY (RoomID) REFERENCES Rooms(RoomID),
    FOREIGN KEY (ReservationID) REFERENCES Reservations(ReservationID)
);
GO


CREATE TABLE Accounts (
    AccountID INT PRIMARY KEY IDENTITY,
    ReservationID INT NOT NULL,
    Status VARCHAR(20) CHECK(Status IN ('Open','Closed','Settled')),
    TotalAmount DECIMAL(12,2) DEFAULT 0,
    Balance DECIMAL(12,2) DEFAULT 0,
    FOREIGN KEY (ReservationID) REFERENCES Reservations(ReservationID)
);
GO


CREATE TABLE Payments (
    PaymentID INT PRIMARY KEY IDENTITY,
    AccountID INT NOT NULL,
    PaymentDate DATE NOT NULL,
    PaymentType VARCHAR(20) CHECK(PaymentType IN ('Cash','Card','EFT','TravelAgent')),
    AmountPaid DECIMAL(12,2) NOT NULL,
    FOREIGN KEY (AccountID) REFERENCES Accounts(AccountID)
);
GO
CREATE TABLE TravelAgency (
    TravelAgencyID INT PRIMARY KEY IDENTITY,
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100) NOT NULL,
    AgencyName VARCHAR(100) NOT NULL,
    Phone VARCHAR(20),
    Address VARCHAR(200)
);
GO