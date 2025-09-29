UPDATE Reservations  --Paragraph 1
SET PaymentStatus =
    CASE ReservationID
        WHEN 2 THEN 'Outstanding'
        WHEN 4 THEN 'Outstanding'
        WHEN 5 THEN 'Outstanding'
        WHEN 8 THEN 'Outstanding'
    END
WHERE ReservationID IN (2, 4, 5, 8);


DELETE FROM Payments; --Paragraph 2
DBCC CHECKIDENT ('Payments', RESEED, 0);


INSERT INTO Payments (AccountID, PaymentDate, PaymentType, AmountPaid) --Paragraph 3
VALUES
(1, '2025-11-19', 'Card', 55.00),
(3, '2025-11-21', 'Card', 150.00),
(6, '2025-12-11', 'Card', 99.50),
(7, '2025-12-11', 'Card', 99.50),
(9, '2025-12-11', 'Card', 99.50),
(10, '2025-12-12', 'Card', 199.00),
(11, '2025-11-19', 'Card', 199.00),
(12, '2025-11-20', 'Card', 796.00),
(13, '2025-11-21', 'Card', 298.50),
(14, '2025-11-22', 'Card', 99.50);


UPDATE Accounts    --Paragraph 4
SET Balance = CASE AccountID
        WHEN 2 THEN 550.00
        WHEN 4 THEN 1500.00
        WHEN 5 THEN 995.50
        WHEN 8 THEN 995.50
    END
WHERE AccountID IN (2, 4, 5, 8);




