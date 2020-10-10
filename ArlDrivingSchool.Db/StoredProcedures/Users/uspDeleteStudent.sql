CREATE PROCEDURE [users].[uspDeleteStudent]
	@StudentId			INT
AS
BEGIN
	
	DELETE users.Student
	WHERE StudentId = @StudentId

	SELECT SCOPE_IDENTITY();
END
GO;