ALTER TABLE [dbo].[tblPokemon]
	ADD CONSTRAINT [fk_tblPokemon_Type1Id]
	FOREIGN KEY (Type1Id)
	REFERENCES [tblType] (Id)
