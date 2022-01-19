CREATE PROCEDURE [users].[uspGetAllUser]
AS
BEGIN
	SELECT	
		    FirstName
		   ,LastName
		   ,Email
		   ,Username
		   ,Address
		   ,birthday
	FROM users.[User]
	
END
GO;