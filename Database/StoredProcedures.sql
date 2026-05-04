USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_AddPet]    Script Date: 03/05/2026 8:51:58 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_AddPet]
    @PetName NVARCHAR(100),
    @Species NVARCHAR(50),
    @Breed NVARCHAR(50),
    @DateOfBirth DATE,
    @Weight FLOAT,
    @HealthStatus NVARCHAR(100),
    @UserID INT,
    @Gender NVARCHAR(10),
    @Note NVARCHAR(255)
AS
BEGIN
    INSERT INTO Pet
    (PetName, Species, Breed, DateOfBirth, Weight, HealthStatus, UserID, Gender, Note)
    VALUES
    (@PetName, @Species, @Breed, @DateOfBirth, @Weight, @HealthStatus, @UserID, @Gender, @Note);
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_AddUser]    Script Date: 03/05/2026 8:52:41 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_AddUser]
    @UserName NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Address NVARCHAR(255),
    @Email NVARCHAR(100),
    @PasswordHash NVARCHAR(255),
    @Role NVARCHAR(20),
    @Note NVARCHAR(255)
AS
BEGIN
    INSERT INTO [User]
    (UserName, Phone, Address, Email, PasswordHash, Role, Note)
    VALUES
    (@UserName, @Phone, @Address, @Email, @PasswordHash, @Role, @Note);
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_AddVaccine]    Script Date: 03/05/2026 8:53:07 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_AddVaccine]
    @VaccineName NVARCHAR(100),
    @ForSpecies NVARCHAR(50),
    @PreventDisease NVARCHAR(255),
    @RecommendedIntervalMonths INT,
    @Note NVARCHAR(255)
AS
BEGIN
    INSERT INTO Vaccine
    (VaccineName, ForSpecies, PreventDisease, RecommendedIntervalMonths, Note)
    VALUES
    (@VaccineName, @ForSpecies, @PreventDisease, @RecommendedIntervalMonths, @Note);
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_CompleteVaccinationSchedule]    Script Date: 03/05/2026 8:53:17 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_CompleteVaccinationSchedule]
    @ScheduleID INT,
    @CompletedDate DATE,
    @Note NVARCHAR(255)
AS
BEGIN
    DECLARE @VaccineID INT;
    DECLARE @IntervalMonths INT;
    DECLARE @NextVaccinationDate DATE;

    -- Lấy VaccineID từ lịch tiêm
    SELECT @VaccineID = VaccineID
    FROM VaccinationSchedule
    WHERE ScheduleID = @ScheduleID;

    -- Lấy chu kỳ tiêm lại của vaccine
    SELECT @IntervalMonths = RecommendedIntervalMonths
    FROM Vaccine
    WHERE VaccineID = @VaccineID;

    -- Tính ngày tiêm tiếp theo
    SET @NextVaccinationDate = DATEADD(MONTH, @IntervalMonths, @CompletedDate);

    -- Đánh dấu lịch tiêm là đã hoàn thành
    UPDATE VaccinationSchedule
    SET
        VaccinationDate = @CompletedDate,
        NextVaccinationDate = @NextVaccinationDate,
        Status = 'Completed',
        Note = @Note
    WHERE ScheduleID = @ScheduleID;
END;
GO



USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_CreateVaccinationSchedule]    Script Date: 03/05/2026 8:54:14 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_CreateVaccinationSchedule]
    @PetID INT,
    @VaccineID INT,
    @CreatedByUserID INT,
    @VaccinationDate DATE,
    @Status NVARCHAR(30),
    @Note NVARCHAR(255)
AS
BEGIN
    DECLARE @IntervalMonths INT;
    DECLARE @NextVaccinationDate DATE;

    SELECT @IntervalMonths = RecommendedIntervalMonths
    FROM Vaccine
    WHERE VaccineID = @VaccineID;

    SET @NextVaccinationDate = DATEADD(MONTH, @IntervalMonths, @VaccinationDate);

    INSERT INTO VaccinationSchedule
    (PetID, VaccineID, CreatedByUserID, VaccinationDate, NextVaccinationDate, Status, Note)
    VALUES
    (@PetID, @VaccineID, @CreatedByUserID, @VaccinationDate, @NextVaccinationDate, @Status, @Note);
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteNotification]    Script Date: 03/05/2026 8:55:04 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_DeleteNotification]
    @NotificationID INT
AS
BEGIN
    DELETE FROM Notification
    WHERE NotificationID = @NotificationID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeletePet]    Script Date: 03/05/2026 8:55:21 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_DeletePet]
    @PetID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM VaccinationSchedule
        WHERE PetID = @PetID
    )
    BEGIN
        PRINT 'Cannot delete this pet because it has vaccination schedules.';
        RETURN;
    END

    DELETE FROM Pet
    WHERE PetID = @PetID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteUser]    Script Date: 03/05/2026 8:55:44 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_DeleteUser]
    @UserID INT
AS
BEGIN
    DELETE FROM [User]
    WHERE UserID = @UserID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_DeleteVaccine]    Script Date: 03/05/2026 8:56:04 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_DeleteVaccine]
    @VaccineID INT
AS
BEGIN
    IF EXISTS (
        SELECT 1
        FROM VaccinationSchedule
        WHERE VaccineID = @VaccineID
    )
    BEGIN
        PRINT 'Cannot delete this vaccine because it is used in vaccination schedules.';
        RETURN;
    END

    DELETE FROM Vaccine
    WHERE VaccineID = @VaccineID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllNotifications]    Script Date: 03/05/2026 8:56:21 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllNotifications]
AS
BEGIN
    SELECT * FROM Notification;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllUsers]    Script Date: 03/05/2026 8:57:37 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllUsers]
AS
BEGIN
    SELECT 
        UserID,
        UserName,
        Phone,
        Address,
        Email,
        Role,
        CreatedDate,
        Note
    FROM [User];
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllVaccinationSchedules]    Script Date: 03/05/2026 8:57:45 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllVaccinationSchedules]
AS
BEGIN
    SELECT
        ScheduleID,
        PetID,
        VaccineID,
        CreatedByUserID,
        VaccinationDate,
        NextVaccinationDate,
        Status,
        Note
    FROM VaccinationSchedule;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllVaccines]    Script Date: 03/05/2026 9:01:56 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllVaccines]
AS
BEGIN
    SELECT * FROM Vaccine;
END
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetNotificationsByUserID]    Script Date: 03/05/2026 9:02:03 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetNotificationsByUserID]
    @UserID INT
AS
BEGIN
    SELECT *
    FROM Notification
    WHERE UserID = @UserID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetPetByID]    Script Date: 03/05/2026 9:02:09 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetPetByID]
    @PetID INT
AS
BEGIN
    SELECT 
        PetID,
        PetName,
        Species,
        Breed,
        DateOfBirth,
        Weight,
        HealthStatus,
        UserID,
        Gender,
        Note
    FROM Pet
    WHERE PetID = @PetID;
END
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUpcomingVaccinations]    Script Date: 03/05/2026 9:02:16 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetUpcomingVaccinations]
AS
BEGIN
    SELECT
        ScheduleID,
        PetID,
        VaccineID,
        CreatedByUserID,
        VaccinationDate,
        NextVaccinationDate,
        Status,
        Note
    FROM VaccinationSchedule
    WHERE Status <> 'Completed'
      AND NextVaccinationDate <= DATEADD(DAY, 30, GETDATE());
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetUserByID]    Script Date: 03/05/2026 9:02:22 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetUserByID]
    @UserID INT
AS
BEGIN
    SELECT 
        UserID,
        UserName,
        Phone,
        Address,
        Email,
        Role,
        CreatedDate,
        Note
    FROM [User]
    WHERE UserID = @UserID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetVaccinationScheduleByID]    Script Date: 03/05/2026 9:02:33 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetVaccinationScheduleByID]
    @ScheduleID INT
AS
BEGIN
    SELECT
        ScheduleID,
        PetID,
        VaccineID,
        CreatedByUserID,
        VaccinationDate,
        NextVaccinationDate,
        Status,
        Note
    FROM VaccinationSchedule
    WHERE ScheduleID = @ScheduleID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetVaccineByID]    Script Date: 03/05/2026 9:02:41 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetVaccineByID]
    @VaccineID INT
AS
BEGIN
    SELECT * FROM Vaccine
    WHERE VaccineID = @VaccineID;
END
GO



USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_MarkNotificationAsRead]    Script Date: 03/05/2026 9:02:49 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_MarkNotificationAsRead]
    @NotificationID INT
AS
BEGIN
    UPDATE Notification
    SET IsRead = 1
    WHERE NotificationID = @NotificationID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdatePet]    Script Date: 03/05/2026 9:03:04 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_UpdatePet]
    @PetID INT,
    @PetName NVARCHAR(100),
    @Species NVARCHAR(50),
    @Breed NVARCHAR(50),
    @DateOfBirth DATE,
    @Weight FLOAT,
    @HealthStatus NVARCHAR(100),
    @UserID INT,
    @Gender NVARCHAR(10),
    @Note NVARCHAR(255)
AS
BEGIN
    UPDATE Pet
    SET
        PetName = @PetName,
        Species = @Species,
        Breed = @Breed,
        DateOfBirth = @DateOfBirth,
        Weight = @Weight,
        HealthStatus = @HealthStatus,
        UserID = @UserID,
        Gender = @Gender,
        Note = @Note
    WHERE PetID = @PetID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateUser]    Script Date: 03/05/2026 9:03:11 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_UpdateUser]
    @UserID INT,
    @UserName NVARCHAR(100),
    @Phone NVARCHAR(20),
    @Address NVARCHAR(255),
    @Email NVARCHAR(100),
    @PasswordHash NVARCHAR(255),
    @Role NVARCHAR(20),
    @Note NVARCHAR(255)
AS
BEGIN
    UPDATE [User]
    SET
        UserName = @UserName,
        Phone = @Phone,
        Address = @Address,
        Email = @Email,
        PasswordHash = @PasswordHash,
        Role = @Role,
        Note = @Note
    WHERE UserID = @UserID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateVaccinationSchedule]    Script Date: 03/05/2026 9:03:18 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_UpdateVaccinationSchedule]
    @ScheduleID INT,
    @VaccinationDate DATE,
    @Status NVARCHAR(30),
    @Note NVARCHAR(255)
AS
BEGIN
    DECLARE @VaccineID INT;
    DECLARE @IntervalMonths INT;
    DECLARE @NextVaccinationDate DATE;

    -- Lấy VaccineID của schedule
    SELECT @VaccineID = VaccineID
    FROM VaccinationSchedule
    WHERE ScheduleID = @ScheduleID;

    -- Lấy chu kỳ vaccine
    SELECT @IntervalMonths = RecommendedIntervalMonths
    FROM Vaccine
    WHERE VaccineID = @VaccineID;

    -- Tính lại ngày tiêm tiếp theo
    SET @NextVaccinationDate = DATEADD(MONTH, @IntervalMonths, @VaccinationDate);

    -- Update
    UPDATE VaccinationSchedule
    SET
        VaccinationDate = @VaccinationDate,
        NextVaccinationDate = @NextVaccinationDate,
        Status = @Status,
        Note = @Note
    WHERE ScheduleID = @ScheduleID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_UpdateVaccine]    Script Date: 03/05/2026 9:03:25 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_UpdateVaccine]
    @VaccineID INT,
    @VaccineName NVARCHAR(100),
    @ForSpecies NVARCHAR(50),
    @PreventDisease NVARCHAR(255),
    @RecommendedIntervalMonths INT,
    @Note NVARCHAR(255)
AS
BEGIN
    UPDATE Vaccine
    SET
        VaccineName = @VaccineName,
        ForSpecies = @ForSpecies,
        PreventDisease = @PreventDisease,
        RecommendedIntervalMonths = @RecommendedIntervalMonths,
        Note = @Note
    WHERE VaccineID = @VaccineID;
END;
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_GetAllPets]    Script Date: 03/05/2026 9:31:03 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_GetAllPets]
AS
BEGIN
    SELECT 
        PetID,
        PetName,
        Species,
        Breed,
        DateOfBirth,
        Weight,
        HealthStatus,
        UserID,
        Gender,
        Note
    FROM Pet;
END
GO


USE [PetCareManagement]
GO

/****** Object:  StoredProcedure [dbo].[sp_SearchPet]    Script Date: 03/05/2026 9:38:58 CH ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[sp_SearchPet]
    @Keyword NVARCHAR(100)
AS
BEGIN
    SELECT
        p.PetID,
        p.PetName,
        p.Species,
        p.Breed,
        p.DateOfBirth,
        p.Weight,
        p.HealthStatus,
        p.UserID,
        u.UserName,
        p.Gender,
        p.Note
    FROM Pet p
    JOIN [User] u ON p.UserID = u.UserID
    WHERE 
        p.PetName LIKE N'%' + @Keyword + N'%'
        OR p.Species LIKE N'%' + @Keyword + N'%'
        OR p.Breed LIKE N'%' + @Keyword + N'%';
END;
GO
CREATE OR ALTER PROCEDURE sp_GetUserByEmail
    @Email NVARCHAR(100)
AS
BEGIN
    SELECT *
    FROM [User]
    WHERE Email = @Email;
END;

