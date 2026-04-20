CREATE TABLE Pet (
    PetID INT PRIMARY KEY IDENTITY(1,1),
    PetName NVARCHAR(100) NOT NULL,
    Species NVARCHAR(50),
    Breed NVARCHAR(50),
    DateOfBirth DATE,
    Weight FLOAT,
    HealthStatus NVARCHAR(100),
    OwnerID INT NOT NULL,
    Gender NVARCHAR(10) CHECK (Gender IN ('Male', 'Female')),
    Note NVARCHAR(255),
    FOREIGN KEY (OwnerID) REFERENCES Owner(OwnerID)
);