ALTER TABLE [dbo].[tblPokemonTeam]
	ADD CONSTRAINT [fk_tblPokemonTeam_TrainerId]
	FOREIGN KEY ([TrainerId])
	REFERENCES [tblTrainer] (Id)
