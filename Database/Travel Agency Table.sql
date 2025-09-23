CREATE TABLE TravelAgencies (
    AgencyID INT PRIMARY KEY IDENTITY(1,1),
    AgencyName VARCHAR(100) NOT NULL,
    ContactPerson VARCHAR(100),
    PhoneNumber VARCHAR(20),
    Email VARCHAR(100)
);
