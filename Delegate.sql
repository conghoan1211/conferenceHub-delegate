CREATE DATABASE DelegateManagement;
USE DelegateManagement;


-- Bảng chức vụ (CEO, Giám đốc, Trưởng phòng, ...)
CREATE TABLE Positions (
    Id INT PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(255) UNIQUE NOT NULL,
	[IsActive] [bit] NULL,
);

-- Bảng quản lý tài khoản (Admin, Đại biểu)
CREATE TABLE Users (
    [UserId] NVARCHAR(36) PRIMARY KEY NOT NULL,
    FullName NVARCHAR(255) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    Phone NVARCHAR(20),
    [Password] NVARCHAR(500) NOT NULL,
    PositionId INT NULL,
	Company NVARCHAR(255),
    Avatar NVARCHAR(500),
	[GoogleId] [nvarchar](255) NULL,
	[Sex] [int] NULL,
	[Dob] [datetime] NULL,
    [RoleId] [int] NOT NULL,
    [Status] [int],                -- Active', 'Banned', 'Pending
	[IsActive] [bit] NULL,       -- trạng thái hoạt động
	[IsVerified] [bit] NULL,
    [CreatedAt] [datetime] DEFAULT GETDATE(),
	[UpdateAt] [datetime] NULL,
	[CreateUser] [nvarchar](36) NULL,
	[UpdateUser] [nvarchar](36) NULL,
	FOREIGN KEY (PositionId) REFERENCES Positions(Id),
);

-- Bảng địa điểm tổ chức hội thảo
CREATE TABLE Locations (
    Id INT PRIMARY KEY NOT NULL,
    [Address] NVARCHAR(120) NOT NULL,
    [Name] NVARCHAR(120) NOT NULL,
	[Capacity] [int],            -- Sức chứa
	[Description] NVARCHAR(300),
	[Status] [int],                -- 'còn trống', 'Bảo trì', 'đã đặt'
);

-- Bảng quản lý hội thảo
CREATE TABLE Conferences  (
    [Id] NVARCHAR(36) PRIMARY KEY NOT NULL,
    [Name] NVARCHAR(255) NOT NULL,
    [Description] NVARCHAR(MAX),
    [EventDate] DATETIME NOT NULL,
    [DeadlineDate] DATETIME NOT NULL,
	StartTime TIME(0) NOT NULL,  -- Chỉ lưu giờ và phút
    EndTime TIME(0) NOT NULL,
	[Thumbnail] [nvarchar](255) NOT NULL,
	[File] NVARCHAR(MAX),
    LocationId INT NOT NULL,
    MaxParticipants INT NOT NULL,
	[Status] [int], 
	[IsPublished] INT NOT NULL,
    [CreatedAt] [datetime] DEFAULT GETDATE(),
	[UpdateAt] [datetime] NULL,
	[CreateUser] [nvarchar](36) NULL,
	[UpdateUser] [nvarchar](36) NULL,
    FOREIGN KEY (LocationId) REFERENCES Locations(Id),
    FOREIGN KEY ([CreateUser]) REFERENCES Users([UserId])
);

-- Bảng quản lý đại biểu tham gia hội thảo
CREATE TABLE ConferenceDelegates (
    [Id] NVARCHAR(36) PRIMARY KEY NOT NULL,
    ConferenceId NVARCHAR(36) NOT NULL,
    UserId NVARCHAR(36) NOT NULL,
    Status INT NOT NULL,             -- Registered, Accepted
    [CreatedAt] [datetime] DEFAULT GETDATE(),
	[UpdateAt] [datetime] NULL,
	FOREIGN KEY (ConferenceId) REFERENCES Conferences(Id),
    FOREIGN KEY (UserId) REFERENCES Users(UserId)
);

-- Bảng thông báo cho đại biểu về hội thảo
CREATE TABLE Notifications (
    [Id] NVARCHAR(36) PRIMARY KEY NOT NULL,
    Title NVARCHAR(255) NOT NULL,
    Content NVARCHAR(MAX) NOT NULL,
    ConferenceId NVARCHAR(36) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ConferenceId) REFERENCES Conferences(Id)
);

-- Bảng lưu trữ tài liệu đính kèm
CREATE TABLE Files (
    [Id] NVARCHAR(36) PRIMARY KEY NOT NULL,
    FilePath NVARCHAR(500) NOT NULL,
    ConferenceId NVARCHAR(36) NULL,
    UploadedBy NVARCHAR(36) NOT NULL,
    UploadedAt DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (ConferenceId) REFERENCES Conferences(Id)  ON DELETE CASCADE,
    FOREIGN KEY (UploadedBy) REFERENCES Users(UserId)
);
 