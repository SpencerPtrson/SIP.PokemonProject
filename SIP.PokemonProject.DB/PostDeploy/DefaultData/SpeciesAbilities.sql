BEGIN
	INSERT INTO dbo.tblSpeciesAbility(Id, PokedexId, AbilityId, AbilityNum)
	VALUES
	(NEWID(), dbo.fnPokedexId('Bulbasaur'), dbo.fnAbilityId('Overgrow'), 1),
	(NEWID(), dbo.fnPokedexId('Ivysaur'), dbo.fnAbilityId('Overgrow'), 1),
	(NEWID(), dbo.fnPokedexId('Venusaur'), dbo.fnAbilityId('Overgrow'), 1),
	(NEWID(), dbo.fnPokedexId('Venusaur'), dbo.fnAbilityId('Intimidate'), 2)
END
