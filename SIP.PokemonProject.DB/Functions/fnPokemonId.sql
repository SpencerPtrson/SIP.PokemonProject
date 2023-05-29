﻿GO
CREATE FUNCTION fnPokemonNicknameId (@Name VARCHAR(50))
	RETURNS UNIQUEIDENTIFIER AS BEGIN
		RETURN (SELECT Id FROM tblPokemon WHERE Nickname = @Name)
END