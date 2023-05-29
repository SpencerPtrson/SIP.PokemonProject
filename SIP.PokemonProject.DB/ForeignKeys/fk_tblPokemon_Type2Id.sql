ALTER TABLE [dbo].[tblPokemon]
	ADD CONSTRAINT [fk_tblPokemon_Type2Id]
	FOREIGN KEY (Type2Id)
	REFERENCES [tblType] (Id)
