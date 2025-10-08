SELECT name, type_desc  --Run 1st
FROM sys.check_constraints
WHERE parent_object_id = OBJECT_ID('Reservations'); --use whatever constarint you get in the next query(for booking status)

ALTER TABLE Reservations  --Run 2nd
DROP CONSTRAINT CK__Reservati__Booki__300424B4; --replace this contraint with the the actual name from above


ALTER TABLE Reservations--Run 3rd
DROP COLUMN BookingStatus;

SELECT name, type_desc --Run 4th
FROM sys.check_constraints
WHERE parent_object_id = OBJECT_ID('Reservations'); --use whatever constarint you get in the next query(for payment status)

ALTER TABLE Reservations --Run 5th
DROP CONSTRAINT CK__Reservati__Payme__30F848ED;  --replace this contraint with the the actual name from above

UPDATE Reservations -- Run 6th
SET PaymentStatus = 'Deposit Paid'
WHERE PaymentStatus IN ('Paid');

UPDATE Reservations -- Run 7th
SET PaymentStatus = 'Pending'
WHERE PaymentStatus IN ('Outstanding');

ALTER TABLE Reservations -- Run 8th
ADD CONSTRAINT CK_Reservations_PaymentStatus
CHECK (PaymentStatus IN ('Deposit Paid', 'Paid in Full', 'Pending'));




