﻿CREATE TABLE [dbo].[tblSpeciesAbility]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [PokedexId] UNIQUEIDENTIFIER NOT NULL, 
    [AbilityId] UNIQUEIDENTIFIER NOT NULL, 
    [AbilityNum] INT NOT NULL
)