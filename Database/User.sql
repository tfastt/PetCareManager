CREATE TABLE [User] (
    UserID        INT PRIMARY KEY IDENTITY(1,1),
    UserName      NVARCHAR(100) NOT NULL,
    Phone         NVARCHAR(20),
    Address       NVARCHAR(255),
    Email         NVARCHAR(100) UNIQUE,
    PasswordHash  NVARCHAR(255) NOT NULL,
    Role          NVARCHAR(20) NOT NULL CHECK (Role IN ('Owner', 'Admin')),
    CreatedDate   DATETIME DEFAULT GETDATE(),
    Note          NVARCHAR(255)
);