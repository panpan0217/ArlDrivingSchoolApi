CREATE PROCEDURE [sessions].[uspDeleteSessionOne]
	@StudentId			INT
AS
BEGIN
	
	DELETE [sessions].[SessionOne]
	WHERE StudentId = @StudentId

	SELECT SCOPE_IDENTITY();
END
GO;