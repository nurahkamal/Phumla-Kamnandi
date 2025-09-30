ALTER TABLE dbo.Reservations  --removed constraint from Reseravtion table
DROP CONSTRAINT CK__Reservati__Numbe__412EB0B6;

ALTER TABLE ReservationRooms --Added guets column to ReservationRooms table
ADD NumberOfGuests INT NOT NULL DEFAULT 1;

DBCC CHECKIDENT ('Reservations', RESEED, 10); --Inserted additional data into Reservation table to fulfill test doc requiremnts
INSERT INTO Reservations 
    (GuestID, ReservationDate, CheckInDate, CheckOutDate, NumberOfGuests, BookingStatus, PaymentStatus)
VALUES
    (5, '2025-11-20', '2025-12-25', '2025-12-27', 2, 'Confirmed', 'Paid'),
    (4, '2025-11-21', '2025-12-25', '2025-12-29', 6, 'Confirmed', 'Paid'),
    (6, '2025-11-23', '2025-12-26', '2025-12-29', 1, 'Confirmed', 'Paid'),
    (7, '2025-11-23', '2025-12-28', '2025-12-30', 1, 'Confirmed', 'Paid');

UPDATE ReservationRooms --Inserted Number of Guest data into Reseravtion Rooms
SET NumberOfGuests = CASE ReservationRoomID
    WHEN 1 THEN 2 
    WHEN 2 THEN 1  
    WHEN 3 THEN 2  
    WHEN 4 THEN 1  
    WHEN 5 THEN 2  
    WHEN 6 THEN 1  
    WHEN 7 THEN 2  
    WHEN 8 THEN 1  
    WHEN 9 THEN 2  
    WHEN 10 THEN 2 
END
WHERE ReservationRoomID IN (1,2,3,4,5,6,7,8,9,10);

UPDATE ReservationRooms  --Update
SET RoomID = 1
WHERE ReservationRoomID = 9;


DBCC CHECKIDENT ('ReservationRooms', RESEED, 10); --Inserted additional data to match Reservation table
INSERT INTO ReservationRooms (ReservationID, RoomID, RateApplied, DiscountApplied, NumberOfGuests)
VALUES
(11, 5, 995.00, 0.00, 2),
(12, 2, 995.00, 0.00, 3),
(12, 3, 995.00, 0.00, 3),
(13, 4, 995.00, 0.00, 1),
(14, 5, 995.00, 0.00, 1);



DELETE FROM RoomAllocation; --Deleted current data from Room Allocation

DBCC CHECKIDENT ('RoomAllocation', RESEED, 0); --Reset increments

INSERT INTO RoomAllocation (RoomID, DateAllocated, ReservationID) --Insert data into Room Allocation to match other tables
VALUES
(1, '2025-12-03', 1),
(2, '2025-12-05', 2),
(3, '2025-12-10', 3),
(3, '2025-12-11', 3),
(4, '2025-12-13', 4),
(4, '2025-12-14', 4),
(1, '2025-12-25', 5),
(2, '2025-12-24', 6),
(3, '2025-12-24', 7),
(4, '2025-12-25', 8),
(1, '2025-12-26', 9),
(1, '2025-12-27', 10),
(1, '2025-12-28', 10),
(5, '2025-12-25', 11),
(5, '2025-12-26', 11),
(2, '2025-12-25', 12),
(2, '2025-12-26', 12),
(2, '2025-12-27', 12),
(2, '2025-12-28', 12),
(3, '2025-12-25', 12),
(3, '2025-12-26', 12),
(3, '2025-12-27', 12),
(3, '2025-12-28', 12),
(4, '2025-12-26', 13),
(4, '2025-12-27', 13),
(4, '2025-12-28', 13),
(5, '2025-12-29', 14);












