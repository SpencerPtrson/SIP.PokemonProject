﻿GO
CREATE FUNCTION fnTrainerId (@Name VARCHAR(50))
	RETURNS UNIQUEIDENTIFIER AS BEGIN
		RETURN (SELECT Id FROM tblTrainer WHERE Name = @Name)
END