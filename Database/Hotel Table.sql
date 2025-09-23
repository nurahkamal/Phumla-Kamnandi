CREATE TABLE Hotels (
    HotelID INT PRIMARY KEY IDENTITY(1,1),
    HotelName VARCHAR(100) NOT NULL,
    Location VARCHAR(100),
    ContactNumber VARCHAR(20)
);