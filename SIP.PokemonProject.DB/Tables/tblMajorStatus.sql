CREATE TABLE [dbo].[tblMajorStatus]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [StatusName] VARCHAR(50) NOT NULL, 
    [StatusIcon] IMAGE NULL, 
)
