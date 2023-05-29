ALTER TABLE [dbo].tblPokemon
	ADD CONSTRAINT [fk_tblPokemon_AbilityId]
	FOREIGN KEY ([AbilityId])
	REFERENCES [tblSpeciesAbility] (Id)
