ALTER TABLE [dbo].[tblMove]
	ADD CONSTRAINT [fk_tblMove_TypeId]
	FOREIGN KEY ([TypeId])
	REFERENCES [tblType] (Id)
