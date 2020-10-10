CREATE PROCEDURE [sessions].[uspDeleteSessionTwo]
	@StudentId			INT
AS
BEGIN
	
	DELETE [sessions].[SessionTwo]
	WHERE StudentId = @StudentId

	SELECT SCOPE_IDENTITY();
END
GO;