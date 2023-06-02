BEGIN
	INSERT INTO dbo.tblType(Id, TypeName, TypeIcon)
	VALUES
	(NEWID(), 'Normal', 'normal icon'),
	(NEWID(), 'Fire', 'fire icon'),
	(NEWID(), 'Water', 'water icon'),
	(NEWID(), 'Grass', 'grass icon'),
	(NEWID(), 'Electric', 'electric icon'),
	(NEWID(), 'Ice', 'ice icon'),
	(NEWID(), 'Fighting', 'fighting icon'),
	(NEWID(), 'Poison', 'poison icon'),
	(NEWID(), 'Ground', 'ground icon'),
	(NEWID(), 'Flying', 'flying icon'),
	(NEWID(), 'Psychic', 'psychic icon'),
	(NEWID(), 'Bug', 'bug icon'),
	(NEWID(), 'Rock', 'rock icon'),
	(NEWID(), 'Ghost', 'ghost icon'),
	(NEWID(), 'Dark', 'dark icon'),
	(NEWID(), 'Dragon', 'dragon icon'),
	(NEWID(), 'Steel', 'steel icon'),
	(NEWID(), 'Fairy', 'fairy icon'),
	(NEWID(), 'None', 'typeless icon')
END
