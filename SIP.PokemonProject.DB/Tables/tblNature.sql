CREATE TABLE [dbo].[tblNature]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [StatIncreased] VARCHAR(30) NOT NULL, 
    [StatDecreased] VARCHAR(30) NOT NULL
)
