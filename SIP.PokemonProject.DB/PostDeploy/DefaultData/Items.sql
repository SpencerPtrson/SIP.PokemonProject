BEGIN
	INSERT INTO dbo.tblItem(Id, Name, Description)
	VALUES
	(NEWID(), 'Rocky Helmet', 'Reduces the HP of attackers by 1/8 if they make physical contact.'),
	(NEWID(), 'Assault Vest', 'Boosts Special Defense but prevents use of non-attacking moves.'),
	(NEWID(), 'Leftovers', 'Recover 1/16th HP at the end of each turn.')
END
