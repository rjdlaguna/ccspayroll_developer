CREATE TABLE [dbo].[tblUser] (
    [UserID]    INT        IDENTITY (1, 1) NOT NULL,
    [Username]  NCHAR (10) NULL,
    [Password]  NCHAR (10) NULL,
    [EmpID] INT NOT NULL,
	[UserLevel] NCHAR (10) NULL,
    [UserStatus]  TINYINT    NULL,
    PRIMARY KEY CLUSTERED ([UserID] ASC)
);

