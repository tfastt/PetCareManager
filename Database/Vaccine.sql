CREATE TABLE Vaccine (
    VaccineID                   INT PRIMARY KEY IDENTITY(1,1),
    VaccineName                 NVARCHAR(100) NOT NULL,
    ForSpecies                  NVARCHAR(50),
    PreventDisease              NVARCHAR(255),
    RecommendedIntervalMonths   INT CHECK (RecommendedIntervalMonths IS NULL OR RecommendedIntervalMonths > 0),
    Note                        NVARCHAR(255)
);