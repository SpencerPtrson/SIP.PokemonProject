﻿CREATE TABLE [dbo].[tblPokemonTeam]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [TrainerId] UNIQUEIDENTIFIER NOT NULL, 
    [PokemonId] UNIQUEIDENTIFIER NOT NULL
)
