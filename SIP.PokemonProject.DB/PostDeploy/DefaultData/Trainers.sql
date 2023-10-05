BEGIN
	INSERT INTO dbo.tblTrainer(Id, Name, Money, TrainerClass)
	VALUES
	(NEWID(), 'Little Timmy', 14, 'Elite 4'),
	(NEWID(), 'Youngster Jonathan', 50000, 'Rattata Gang Leader'),
	(NEWID(), 'Trainer Red', 1, 'Champion')
END
