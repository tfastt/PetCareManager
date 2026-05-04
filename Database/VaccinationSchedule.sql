CREATE TABLE VaccinationSchedule (
    ScheduleID           INT PRIMARY KEY IDENTITY(1,1),
    PetID                INT NOT NULL,
    VaccineID            INT NOT NULL,
    CreatedByUserID      INT NOT NULL,
    VaccinationDate      DATE NOT NULL,
    NextVaccinationDate  DATE,
    Status               NVARCHAR(30) NOT NULL 
                         CHECK (Status IN ('Scheduled', 'Completed', 'Cancelled', 'Overdue')),
    Note                 NVARCHAR(255),

    FOREIGN KEY (PetID) REFERENCES Pet(PetID),
    FOREIGN KEY (VaccineID) REFERENCES Vaccine(VaccineID),
    FOREIGN KEY (CreatedByUserID) REFERENCES [User](UserID)
);