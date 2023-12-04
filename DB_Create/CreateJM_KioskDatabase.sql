USE master;
GO

-- Check if the database already exists and drop it if needed
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'JM_KioskDatabase')
BEGIN
    ALTER DATABASE JM_KioskDatabase SET ONLINE WITH ROLLBACK IMMEDIATE;
    DROP DATABASE JM_KioskDatabase;
END

-- Create a new database
CREATE DATABASE JM_KioskDatabase;
GO

-- Bring the new database online
ALTER DATABASE JM_KioskDatabase SET ONLINE;