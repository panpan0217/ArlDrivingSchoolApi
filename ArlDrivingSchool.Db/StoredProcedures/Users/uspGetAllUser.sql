CREATE PROCEDURE [users].[uspGetAllUser]
AS
BEGIN
	SELECT	UserId
		   ,FirstName
		   ,LastName
		   ,Email
		   ,Username
		   ,[Address]
		   ,UserTypeId
		   ,birthday
	FROM users.[User]
	WHERE Deleted = 0
	
END
GO;