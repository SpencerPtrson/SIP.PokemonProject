BEGIN
	INSERT INTO dbo.tblPokemon(Id, SpeciesId, AbilityId, NatureId, 
								Nickname, Level, Type1Id, Type2Id, CurrentHP,
								HPIVs, AttackIVs, DefenseIVs, SpecialAttackIVs, SpecialDefenseIVs, SpeedIVs, 
								HPEVs, AttackEVs, DefenseEVs, SpecialAttackEVs, SpecialDefenseEVs, SpeedEVs,
								ItemId, IsShiny)
	VALUES
	(NEWID(), dbo.fnPokedexId('Bulbasaur'), dbo.fnSpeciesAbility(dbo.fnPokedexId('Bulbasaur'), 1), dbo.fnNatureId('Adamant'), 'Bulby', 15, dbo.fnTypeId('Grass'), dbo.fnTypeId('Poison'), 48,
																					31, 31, 31, 31, 31, 31, 
																					252, 252, 0, 0, 4, 0,
																					dbo.fnItemId('Rocky Helmet'), 0),

	(NEWID(), dbo.fnPokedexId('Ivysaur'), dbo.fnSpeciesAbility(dbo.fnPokedexId('Ivysaur'), 1), dbo.fnNatureId('Adamant'), 'Ivy', 30, dbo.fnTypeId('Grass'), dbo.fnTypeId('Poison'), 113,
																					31, 31, 31, 31, 31, 31, 
																					252, 0, 0, 252, 4, 0,
																					dbo.fnItemId('Assault Vest'), 0),

	(NEWID(), dbo.fnPokedexId('Venusaur'), dbo.fnSpeciesAbility(dbo.fnPokedexId('Venusaur'), 2), dbo.fnNatureId('Adamant'), 'Venus', 15, dbo.fnTypeId('Grass'), dbo.fnTypeId('Poison'),  314,
																					31, 31, 31, 31, 31, 31, 
																					252, 0, 252, 0, 4, 0,
																					dbo.fnItemId('Leftovers'), 0)
END