BEGIN
	INSERT INTO dbo.tblPokedex(
			Id, PokedexNum, SpeciesName, 
			Type1Id, Type2Id, 
			BaseHP, BaseAttack, BaseDefense, 
			BaseSpecialAttack, BaseSpecialDefense, BaseSpeed, 
			SpriteName, FlavorText)
	VALUES
	(NEWID(), 1, 'Bulbasaur', 
		dbo.fnTypeId('Grass'), dbo.fnTypeId('Poison'), 
		45, 49, 49, 
		65, 65, 45, 
		'bulbasaur sprite', 'There is a plant seed on its back right from the day this Pokémon is born. The seed slowly grows larger.'),
	(NEWID(), 2, 'Ivysaur', dbo.fnTypeId('Grass'), dbo.fnTypeId('Poison'), 60, 62, 63, 80, 80, 60, 'ivysaur sprite', 'When the bulb on its back grows large, it appears to lose the ability to stand on its hind legs.'),
	(NEWID(), 3, 'Venusaur', dbo.fnTypeId('Grass'), dbo.fnTypeId('Poison'), 80, 82, 83, 100, 100, 80, 'venusaur sprite', 'Its plant blooms when it is absorbing solar energy. It stays on the move to seek sunlight.'),
	(NEWID(), 4, 'Charmander', dbo.fnTypeId('Fire'), dbo.fnTypeId('None'), 39, 52, 43, 60, 50, 65, 'charmander sprite', 'It has a preference for hot things. When it rains, steam is said to spout from the tip of its tail.')
END