CREATE TABLE [dbo].[tblMove]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL,
    [TypeId] UNIQUEIDENTIFIER NOT NULL,
    [Category] VARCHAR(50) NOT NULL, 
    [PP] INT NOT NULL, 
    [Power] INT NULL, 
    [Accuracy] INT NULL, 
    [Priority] INT NOT NULL, 
    [Target] VARCHAR(50) NOT NULL, 
    [CritRate] FLOAT NOT NULL, 
    [Description] VARCHAR(50) NOT NULL
)
