ALTER TABLE [dbo].[tblPokemonTeam]
	ADD CONSTRAINT [fk_tblPokemonTeam_PokemonId]
	FOREIGN KEY (PokemonId)
	REFERENCES [tblPokemon] (Id)
