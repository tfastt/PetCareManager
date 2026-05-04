CREATE TABLE Pet (
    PetID         INT PRIMARY KEY IDENTITY(1,1),
    PetName       NVARCHAR(100) NOT NULL,
    Species       NVARCHAR(50),
    Breed         NVARCHAR(50),
    DateOfBirth   DATE,
    Weight        FLOAT CHECK (Weight IS NULL OR Weight > 0),
    HealthStatus  NVARCHAR(100),
    UserID        INT NOT NULL,
    Gender        NVARCHAR(10) CHECK (Gender IN ('Male', 'Female')),
    Note          NVARCHAR(255),

    FOREIGN KEY (UserID) REFERENCES [User](UserID)
);