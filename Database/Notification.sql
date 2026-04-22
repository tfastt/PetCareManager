CREATE TABLE Notification (
    NotificationID    INT PRIMARY KEY IDENTITY(1,1),
    UserID            INT NOT NULL,
    PetID             INT NOT NULL,
    VaccineID         INT NOT NULL,
    Title             NVARCHAR(150) NOT NULL,
    Message           NVARCHAR(255) NOT NULL,
    NotificationType  NVARCHAR(20) NOT NULL
                      CHECK (NotificationType IN ('Upcoming', 'Due', 'Overdue')),
    NotificationDate  DATETIME DEFAULT GETDATE(),
    IsRead            BIT DEFAULT 0,
    FOREIGN KEY (UserID) REFERENCES [User](UserID),
    FOREIGN KEY (PetID) REFERENCES Pet(PetID),
    FOREIGN KEY (VaccineID) REFERENCES Vaccine(VaccineID)
);