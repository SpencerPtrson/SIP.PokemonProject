GO
CREATE FUNCTION fnSpeciesAbility (@PokedexId UNIQUEIDENTIFIER, @AbilityNum INT)
	RETURNS UNIQUEIDENTIFIER AS BEGIN
		RETURN (SELECT Id FROM tblSpeciesAbility WHERE PokedexId = @PokedexId AND AbilityNum = @AbilityNum)
END