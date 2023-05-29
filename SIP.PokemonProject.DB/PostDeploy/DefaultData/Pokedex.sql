BEGIN
	INSERT INTO dbo.tblPokedex(Id, PokedexNum, SpeciesName, Type1Id, Type2Id, BaseHP, BaseAttack, BaseDefense, BaseSpecialAttack, BaseSpecialDefense, BaseSpeed, SpriteName)
	VALUES
	(NEWID(), 1, 'Bulbasaur', dbo.fnTypeId('Grass'), dbo.fnTypeId('Poison'), 45, 49, 49, 65, 65, 45, 'bulbasaur sprite'),
	(NEWID(), 2, 'Ivysaur', dbo.fnTypeId('Grass'), dbo.fnTypeId('Poison'), 60, 62, 63, 80, 80, 60, 'ivysaur sprite'),
	(NEWID(), 3, 'Venusaur', dbo.fnTypeId('Grass'), dbo.fnTypeId('Poison'), 80, 82, 83, 100, 100, 80, 'venusaur sprite')
END