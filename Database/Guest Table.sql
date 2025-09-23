CREATE TABLE Guests (
    GuestID INT PRIMARY KEY IDENTITY(1,1),
    FirstName VARCHAR(50) NOT NULL,
    LastName VARCHAR(50) NOT NULL,
    Email VARCHAR(100),
    PhoneNumber VARCHAR(20),
    Address VARCHAR(255),
    City VARCHAR(50),
    PostalCode VARCHAR(10),
    DateCreated DATETIME DEFAULT GETDATE()
);