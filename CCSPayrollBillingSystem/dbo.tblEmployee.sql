CREATE TABLE [dbo].[tblEmployee]
(
	[EmpID] INT NOT NULL PRIMARY KEY, 
    [EmpFirstName] VARCHAR(50) NOT NULL, 
    [EmpLastName] VARCHAR(50) NOT NULL, 
    [EmpMiddleName] VARCHAR(50) NOT NULL, 
    [EmpHomeAddress] TEXT NULL, 
    [EmpContactNo] SMALLINT NULL, 
    [EmpBirthDate] DATE NULL, 
    [EmploymentDate] DATE NULL, 
    [EndOfContractDate] DATE NULL, 
    [DeductionID] INT NULL, 
    [JobID] SMALLINT NULL, 
    [EmpStatus] TINYINT NULL
)
