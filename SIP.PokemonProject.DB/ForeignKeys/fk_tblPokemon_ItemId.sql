ALTER TABLE [dbo].tblPokemon
	ADD CONSTRAINT [fk_tblPokemon_ItemId]
	FOREIGN KEY (ItemId)
	REFERENCES [tblItem] (Id)
