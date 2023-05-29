BEGIN
	INSERT INTO dbo.tblAbility(Id, Name, Description)
	VALUES
	(NEWID(), 'Intimidate', 'When the Pokémon enters a battle, it intimidates opposing Pokémon and makes them cower, lowering their Attack stats.'),
	(NEWID(), 'Wonder Guard', 'Prevent damage from any non-supereffective damaging move'),
	(NEWID(), 'Overgrow', 'Boost Grass-Type attacks by 50% when at 1/3 health or lower.')
END
