CREATE DATABASE MuseumAccess;
GO

USE MuseumAccess;
GO

CREATE TABLE MuseumAreas (
    ID INT PRIMARY KEY,
    AreaName NVARCHAR(255) NOT NULL,
    AreaDescription NVARCHAR(MAX),
    AreaLocation NVARCHAR(255),
    AccessRules NVARCHAR(MAX)
);
GO

CREATE TABLE VisitorCapacities (
    ID INT PRIMARY KEY,
    MuseumAreaID INT,
    MaxVisitorCount INT,
    FOREIGN KEY (MuseumAreaID) REFERENCES MuseumAreas(ID)
);
GO

CREATE TABLE OpeningHours (
    ID INT PRIMARY KEY,
    MuseumAreaID INT,
    Weekday NVARCHAR(10),
    Opens TIME,
    Closes TIME,
    FOREIGN KEY (MuseumAreaID) REFERENCES MuseumAreas(ID)
);
GO

CREATE TABLE AccessLogs (
    ID INT PRIMARY KEY,
    MuseumAreaID INT,
    EntryTime DATETIME,
    ExitTime DATETIME,
    CurrentVisitorCount INT,
    FOREIGN KEY (MuseumAreaID) REFERENCES MuseumAreas(ID)
);
GO

CREATE LOGIN MuseumAccessUser WITH PASSWORD = 'SimplePassword123';
CREATE USER MuseumAccessUser FOR LOGIN MuseumAccessUser;
GO

GRANT SELECT, INSERT, UPDATE, DELETE ON SCHEMA::dbo TO MuseumAccessUser;
GO
