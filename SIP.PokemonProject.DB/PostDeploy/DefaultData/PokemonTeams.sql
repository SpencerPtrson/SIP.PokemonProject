BEGIN
	INSERT INTO dbo.tblPokemonTeam(Id, TrainerId, PokemonId)
	VALUES
	(NEWID(), dbo.fnTrainerId('Little Timmy'), dbo.fnPokemonNicknameId('Bulby')),
	(NEWID(), dbo.fnTrainerId('Little Timmy'), dbo.fnPokemonNicknameId('Ivy')),
	(NEWID(), dbo.fnTrainerId('Little Timmy'), dbo.fnPokemonNicknameId('Venus'))
END
