BEGIN
	INSERT INTO dbo.tblMove(Id, Name, Description, TypeId, Category, PP, Power, Accuracy, Priority, Target, CritRate)
	VALUES
	(NEWID(), 'Tackle', 'haha bonk', dbo.fnTypeId('Normal'), 'Physical', 40, 40, 100, 0, 'Any', 1/16),
	(NEWID(), 'Vine Whip', 'vine boom sound effect', dbo.fnTypeId('Grass'), 'Physical', 30, 40, 100, 0, 'Any', 1/16)
END
