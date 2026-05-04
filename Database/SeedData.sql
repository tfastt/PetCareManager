-- USER
INSERT INTO [User] (UserName, Phone, Address, Email, PasswordHash, Role, Note)
VALUES
(N'Nguyễn Văn An', '0901234567', N'Hà Nội', 'an@example.com', 'hash1', 'Owner', N'User demo'),
(N'Trần Bình', '0902345678', N'HCM', 'binh@example.com', 'hash2', 'Owner', N'User demo'),
(N'Admin', '0900000000', N'Hà Nội', 'admin@example.com', 'adminhash', 'Admin', N'Admin system'),
('Admin', '', '', 'admin@petcare.vn', 'admin123', 'Admin', ''),
('Owner', '', '', 'owner@petcare.vn', 'owner123', 'Owner', '');

-- TEST
SELECT * FROM [User];

-- PET
INSERT INTO Pet (PetName, Species, Breed, DateOfBirth, Weight, HealthStatus, UserID, Gender, Note)
VALUES
(N'Milo', N'Dog', N'Golden Retriever', '2023-05-10', 12.5, N'Healthy', 1, 'Male', N'Pet of Nguyễn Văn An'),
(N'Luna', N'Cat', N'British Shorthair', '2024-01-15', 4.2, N'Healthy', 1, 'Female', N'Pet of Nguyễn Văn An'),
(N'Coco', N'Dog', N'Poodle', '2022-09-20', 6.8, N'Needs vaccination follow-up', 2, 'Female', N'Pet of Trần Bình');

-- TEST PET
SELECT * FROM Pet;

-- VACCINE
INSERT INTO Vaccine (VaccineName, ForSpecies, PreventDisease, RecommendedIntervalMonths, Note)
VALUES
(N'Rabies', N'Dog, Cat', N'Prevents rabies virus', 12, N'Mandatory vaccine'),
(N'5-in-1', N'Dog', N'Prevents distemper, parvo, adenovirus...', 12, N'Core vaccine for dogs'),
(N'Feline 4-in-1', N'Cat', N'Prevents feline viral diseases', 12, N'Core vaccine for cats');

-- TEST VACCINE
SELECT * FROM Vaccine;


-- VACCINATION SCHEDULE
INSERT INTO VaccinationSchedule
(PetID, VaccineID, CreatedByUserID, VaccinationDate, NextVaccinationDate, Status, Note)
VALUES
(1, 1, 1, '2026-04-01', '2027-04-01', 'Completed', N'Milo completed rabies vaccination'),
(1, 2, 1, '2026-04-24', '2027-04-24', 'Scheduled', N'Milo scheduled for 5-in-1 vaccine'),
(2, 3, 1, '2026-04-24', '2027-04-24', 'Scheduled', N'Luna scheduled for feline 4-in-1 vaccine'),
(3, 2, 2, '2026-03-01', '2026-04-01', 'Overdue', N'Coco is overdue for 5-in-1 vaccine');

-- TEST VACCINATION SCHEDULE
SELECT * FROM VaccinationSchedule;

-- NOTIFICATION
INSERT INTO Notification
(UserID, PetID, ScheduleID, Title, Message, NotificationType, IsRead)
VALUES
(1, 1, 2, N'Upcoming Vaccination', N'Milo has an upcoming 5-in-1 vaccination schedule.', 'Upcoming', 0),
(1, 2, 3, N'Due Vaccination', N'Luna is due for Feline 4-in-1 vaccination.', 'Due', 0),
(2, 3, 4, N'Overdue Vaccination', N'Coco is overdue for 5-in-1 vaccination.', 'Overdue', 0),
(1, 1, 1, N'Vaccination Completed', N'Milo has completed rabies vaccination.', 'Upcoming', 1);

-- TEST NOTIFICATION
SELECT * FROM Notification;
