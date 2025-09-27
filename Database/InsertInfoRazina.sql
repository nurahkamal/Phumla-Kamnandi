
USE PhumlaKamnandiHotelsDB;
GO

INSERT INTO Hotels (HotelName, Location, ManagerName, Phone, Email)
VALUES ('Phumla Kamnandi Hotel', 'Cape Town', 'Thandi Mokoena', '0215550000', 'info@phumlahotel.com');
GO

--rooms
INSERT INTO Rooms (HotelID, RoomNumber, RoomType, MaxOccupancy, Status)
VALUES 
(1, '101', 'Standard', 4, 'Available'),
(1, '102', 'Standard', 4, 'Available'),
(1, '103', 'Standard', 4, 'Available'),
(1, '104', 'Standard', 4, 'Available'),
(1, '105', 'Standard', 4, 'Available');
GO

--guests
INSERT INTO Guests (FirstName, LastName, Phone, Email, Address, LoyaltyPoints)
VALUES
('John', 'Smith', '0215551234', 'john.smith@email.com', '7 Main Rd, Rondebosch, 7700', 0),
('Nkosinathi', 'Mthembu', '0315555678', 'nkosi.mthembu@email.com', '14 Lungelo Drive, Mtimkhulu, Durban, 4001', 0),
('Amirah', 'Ali', '0215554321', 'amirah.ali@email.com', '22 Rose St, Cape Town, 7701', 0),
('Azraa', 'Khan', '0215558765', 'azraa.khan@email.com', '33 Oak Ave, Cape Town, 7702', 0),
('Fatima', 'Sayed', '0215551122', 'fatima.sayed@email.com', '44 Maple Rd, Cape Town, 7703', 0),
('Mohammed', 'Peters', '0215553344', 'mohammed.peters@email.com', '55 Pine St, Cape Town, 7704', 0),
('Thabo', 'Nkosi', '0315557788', 'thabo.nkosi@email.com', '66 Birch Rd, Durban, 4002', 0),
('Zanele', 'Moyo', '0315558899', 'zanele.moyo@email.com', '77 Cedar Ave, Durban, 4003', 0),
('Lerato', 'Dlamini', '0315559900', 'lerato.dlamini@email.com', '88 Elm St, Durban, 4004', 0),
('Sipho', 'Mabena', '0315556677', 'sipho.mabena@email.com', '99 Willow Rd, Durban, 4005', 0);
GO

--reservations
-- Low season
INSERT INTO Reservations (GuestID, ReservationDate, CheckInDate, CheckOutDate, NumberOfGuests, BookingStatus, PaymentStatus)
VALUES
(3, '2025-11-15', '2025-12-03', '2025-12-04', 2, 'Confirmed', 'Paid'),
(4, '2025-11-16', '2025-12-05', '2025-12-06', 1, 'Confirmed', 'Paid');

-- Mid season
INSERT INTO Reservations (GuestID, ReservationDate, CheckInDate, CheckOutDate, NumberOfGuests, BookingStatus, PaymentStatus)
VALUES
(5, '2025-11-17', '2025-12-10', '2025-12-12', 2, 'Confirmed', 'Paid'),
(6, '2025-11-18', '2025-12-13', '2025-12-15', 1, 'Confirmed', 'Paid');

-- High season
INSERT INTO Reservations (GuestID, ReservationDate, CheckInDate, CheckOutDate, NumberOfGuests, BookingStatus, PaymentStatus)
VALUES
(1, '2025-11-10', '2025-12-25', '2025-12-26', 2, 'Confirmed', 'Paid'), -- John Smith
(7, '2025-11-20', '2025-12-24', '2025-12-25', 1, 'Confirmed', 'Paid'),
(8, '2025-11-21', '2025-12-24', '2025-12-25', 2, 'Confirmed', 'Paid'),
(9, '2025-11-22', '2025-12-25', '2025-12-26', 1, 'Confirmed', 'Paid'),
(10, '2025-11-23', '2025-12-26', '2025-12-27', 2, 'Confirmed', 'Paid'),
(3, '2025-11-24', '2025-12-27', '2025-12-28', 2, 'Confirmed', 'Paid');
GO

--reservaationrooms
INSERT INTO ReservationRooms (ReservationID, RoomID, RateApplied, DiscountApplied)
VALUES
-- Low
(1, 1, 550.00, 0),
(2, 2, 550.00, 0),
-- Mid
(3, 3, 750.00, 0),
(4, 4, 750.00, 0),
-- High
(5, 1, 995.00, 0),
(6, 2, 995.00, 0),
(7, 3, 995.00, 0),
(8, 4, 995.00, 0),
(9, 5, 995.00, 0),
(10, 1, 995.00, 0);
GO

--accounts
INSERT INTO Accounts (ReservationID, Status, TotalAmount, Balance)
VALUES
-- Low
(1, 'Open', 550.00, 495.00),
(2, 'Open', 550.00, 495.00),
-- Mid
(3, 'Open', 1500.00, 1350.00),
(4, 'Open', 750.00, 675.00),
-- High
(5, 'Open', 995.00, 895.50),
(6, 'Open', 995.00, 895.50),
(7, 'Open', 995.00, 895.50),
(8, 'Open', 995.00, 895.50),
(9, 'Open', 995.00, 895.50),
(10, 'Open', 995.00, 895.50);
GO

--payments
INSERT INTO Payments (AccountID, PaymentDate, PaymentType, AmountPaid)
VALUES
-- Low
(1, '2025-11-19', 'EFT', 55.00),
(2, '2025-11-20', 'Cash', 55.00),
-- Mid
(3, '2025-11-21', 'Card', 150.00),
(4, '2025-11-22', 'EFT', 75.00),
-- High
(5, '2025-12-11', 'EFT', 99.50),
(6, '2025-12-11', 'Card', 99.50),
(7, '2025-12-11', 'Cash', 99.50),
(8, '2025-12-11', 'EFT', 99.50),
(9, '2025-12-11', 'EFT', 99.50),
(10, '2025-12-12', 'Card', 99.50);
GO

--travel agency
INSERT INTO TravelAgency (FirstName, LastName, Email, AgencyName, Phone, Address)
VALUES
('Sibusiso', 'Zulu', 'sibusiso@sunshine.co.za', 'Sunshine Travel', '0115551234', '12 Main Rd, Johannesburg, 2000'),
('Thandi', 'Ngcobo', 'thandi@holidaymakers.co.za', 'Holiday Makers', '0215555678', '34 Beach Rd, Cape Town, 7700'),
('Lerato', 'Mokoena', 'lerato@globetrotters.co.za', 'Globe Trotters', '0315559988', '56 Pine St, Durban, 4001');
GO




--room allocation

INSERT INTO RoomAllocation (RoomID, DateAllocated, ReservationID)
VALUES
-- Reservation 1 (Dec 3-4)
(1, '2025-12-03', 1),
(1, '2025-12-04', 1),
-- Reservation 2 (Dec 5-6)
(2, '2025-12-05', 2),
(2, '2025-12-06', 2);


INSERT INTO RoomAllocation (RoomID, DateAllocated, ReservationID)
VALUES
-- Reservation 3 (Dec 10-12)
(3, '2025-12-10', 3),
(3, '2025-12-11', 3),
(3, '2025-12-12', 3),
-- Reservation 4 (Dec 13-15)
(4, '2025-12-13', 4),
(4, '2025-12-14', 4),
(4, '2025-12-15', 4);


INSERT INTO RoomAllocation (RoomID, DateAllocated, ReservationID)
VALUES
-- Reservation 5 (John Smith, Dec 25-26)
(1, '2025-12-25', 5),
(1, '2025-12-26', 5),
-- Reservation 6 (Dec 24-25)
(2, '2025-12-24', 6),
(2, '2025-12-25', 6),
-- Reservation 7 (Dec 24-25)
(3, '2025-12-24', 7),
(3, '2025-12-25', 7),
-- Reservation 8 (Dec 25-26)
(4, '2025-12-25', 8),
(4, '2025-12-26', 8),
-- Reservation 9 (Dec 26-27)
(5, '2025-12-26', 9),
(5, '2025-12-27', 9),
-- Reservation 10 (Dec 27-28)
(1, '2025-12-27', 10),
(1, '2025-12-28', 10);
GO

