ALTER TABLE [dbo].tblPokedex
	ADD CONSTRAINT [fk_tblPokedex_Type1Id]
	FOREIGN KEY (Type1Id)
	REFERENCES [tblType] (Id)
