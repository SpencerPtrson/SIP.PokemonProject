﻿CREATE TABLE [dbo].[tblTrainer]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) NOT NULL, 
    [Money] INT NOT NULL, 
    [TrainerClass] VARCHAR(50) NOT NULL
)
