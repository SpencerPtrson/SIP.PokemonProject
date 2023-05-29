ALTER TABLE [dbo].tblPokemon
	ADD CONSTRAINT [fk_tblPokemon_NatureId]
	FOREIGN KEY (NatureId)
	REFERENCES [tblNature] (Id)
