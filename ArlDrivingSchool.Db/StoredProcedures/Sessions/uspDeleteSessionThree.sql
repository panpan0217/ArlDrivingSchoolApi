CREATE PROCEDURE [sessions].[uspDeleteSessionThree]
	@StudentId			INT
AS
BEGIN
	
	DELETE [sessions].[SessionThree]
	WHERE StudentId = @StudentId

	SELECT SCOPE_IDENTITY();
END
GO;