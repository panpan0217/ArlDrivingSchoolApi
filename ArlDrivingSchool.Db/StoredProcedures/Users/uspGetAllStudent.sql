CREATE PROCEDURE [users].[uspGetAllStudent]
AS
BEGIN
	SELECT	StudentId
		   ,FirstName
		   ,LastName
		   ,Email
		   ,Mobile

	FROM users.Student
	
END
GO;