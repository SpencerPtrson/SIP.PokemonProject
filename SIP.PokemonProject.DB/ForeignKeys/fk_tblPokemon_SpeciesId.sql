ALTER TABLE [dbo].tblPokemon
	ADD CONSTRAINT [fk_tblPokemon_SpeciesId]
	FOREIGN KEY (SpeciesId)
	REFERENCES [tblPokedex] (Id)
