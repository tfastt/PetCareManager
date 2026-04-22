CREATE TABLE Vaccine (
    VaccineID          INT PRIMARY KEY IDENTITY(1,1),
    PetID              INT NOT NULL,
    VaccineName        NVARCHAR(100) NOT NULL,
    InjectionDate      DATE,
    NextInjectionDate  DATE,
    DoseNumber         INT CHECK (DoseNumber IS NULL OR DoseNumber >= 1),
    Status             NVARCHAR(50) DEFAULT 'Pending'
                       CHECK (Status IN ('Pending', 'Completed', 'Overdue')),
    Reminder           BIT DEFAULT 0,
    Note               NVARCHAR(255),
    FOREIGN KEY (PetID) REFERENCES Pet(PetID)
);