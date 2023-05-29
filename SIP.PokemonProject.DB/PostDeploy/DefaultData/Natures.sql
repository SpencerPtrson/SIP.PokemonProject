BEGIN
	INSERT INTO dbo.tblNature(Id, Name, StatIncreased, StatDecreased)
	VALUES
	(NEWID(), 'Hardy', 'None', 'None'),
	(NEWID(), 'Lonely', 'Attack', 'Defense'),
	(NEWID(), 'Brave', 'Attack', 'Speed'),
	(NEWID(), 'Adamant', 'Attack', 'Special Attack'),
	(NEWID(), 'Naughty', 'Attack', 'Special Defense'),
	(NEWID(), 'Bold', 'Defense', 'Attack'),
	(NEWID(), 'Docile', 'None', 'None'),

	(NEWID(), 'Relaxed', 'Defense', 'Speed'),
	(NEWID(), 'Impish', 'Defense', 'Special Attack'),
	(NEWID(), 'Lax', 'Defense', 'Special Attack'),
	(NEWID(), 'Timid', 'Speed', 'Special Attack'),
	(NEWID(), 'Hasty', 'Speed', 'Defense'),
	(NEWID(), 'Serious', 'None', 'None'),

	(NEWID(), 'Jolly', 'Speed', 'Special Attack'),
	(NEWID(), 'Naive', 'Speed', 'Special Defense'),
	(NEWID(), 'Modest', 'Special Attack', 'Attack'),
	(NEWID(), 'Mild', 'Special Attack', 'Defense'),
	(NEWID(), 'Quiet', 'Special Attack', 'Speed'),
	(NEWID(), 'Bashful', 'None', 'None'),

	(NEWID(), 'Rash', 'Special Attack', 'Special Defense'),
	(NEWID(), 'Calm', 'Special Defense', 'Attack'),
	(NEWID(), 'Gentle', 'Special Defense', 'Defense'),
	(NEWID(), 'Sassy', 'Special Defense', 'Speed'),
	(NEWID(), 'Careful', 'Special Defense', 'Special Attack'),
	(NEWID(), 'Quirky', 'None', 'None')
END
