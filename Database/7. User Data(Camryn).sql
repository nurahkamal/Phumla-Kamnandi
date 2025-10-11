DBCC CHECKIDENT ('dbo.Users', RESEED, 4);

INSERT INTO dbo.Users (FullName, Username, PasswordHash, Role, IsActive, LastLoginTime)
VALUES
('John Smith', 'john', 'JHNSMT005', 'Receptionist', 1, NULL),
('Sarah Jones', 'sarah', 'SRHJON006', 'Administrator', 1, NULL),
('Michael Brown', 'michael', 'MCHBRN007', 'Manager', 1, NULL),
('Emily Davis', 'emily', 'EMLDAV008', 'Receptionist', 1, NULL),
('David Wilson', 'david', 'DVDWLS009', 'Supervisor', 1, NULL),
('Lisa Taylor', 'lisa', 'LSATAY010', 'Receptionist', 1, NULL),
('James Johnson', 'james', 'JMSJHN011', 'Administrator', 1, NULL),
('Anna White', 'anna', 'ANNWHT012', 'Receptionist', 1, NULL),
('Robert Miller', 'robert', 'RBMILL013', 'Manager', 1, NULL),
('Karen Moore', 'karen', 'KRNMOR014', 'Receptionist', 1, NULL),
('Kevin Clark', 'kevin', 'KVNCLK015', 'Supervisor', 1, NULL);

