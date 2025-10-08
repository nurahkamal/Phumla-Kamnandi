USE PhumlaKamnandiHotelsDB;
GO


CREATE TABLE Users (
    UserID INT IDENTITY(1,1) PRIMARY KEY,
    FullName VARCHAR(100) NOT NULL,
    Username VARCHAR(50) NOT NULL UNIQUE,
    PasswordHash VARCHAR(50) NOT NULL, 
    Role VARCHAR(50) NOT NULL, 
    IsActive BIT DEFAULT 1
);
GO

INSERT INTO Users (FullName, Username, PasswordHash, Role, IsActive)
VALUES 
('Nurah', 'nurah', 'KMLNUR001', 'Receptionist', 1),
('Vanessa', 'vanessa', 'MKNRELOO9', 'Receptionist', 1),
('Razina', 'razina', 'CHKRAZ002', 'Manager', 1),
('Camryn', 'camryn', 'PLLCAM008', 'Manager', 1);
GO