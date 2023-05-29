ALTER TABLE [dbo].tblPokedex
	ADD CONSTRAINT [fk_tblPokedex_Type2Id]
	FOREIGN KEY (Type2Id)
	REFERENCES [tblType] (Id)
