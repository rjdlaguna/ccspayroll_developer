CREATE TABLE [dbo].[Table]
(
	[UserID] INT NOT NULL PRIMARY KEY, 
    [Username] VARCHAR(10) NOT NULL, 
    [Password] VARCHAR(30) NOT NULL, 
    [UserLevel] VARCHAR(20) NOT NULL, 
    [IsActive] INT NOT NULL
)
