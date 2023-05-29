BEGIN
	INSERT INTO dbo.tblTrainer(Id, Name, Money)
	VALUES
	(NEWID(), 'Little Timmy', 14),
	(NEWID(), 'Youngster Jonathan', 50000),
	(NEWID(), 'Trainer Red', 1)
END
