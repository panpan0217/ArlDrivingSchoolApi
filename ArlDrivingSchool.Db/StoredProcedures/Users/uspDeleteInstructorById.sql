CREATE PROCEDURE [users].[uspDeleteInstructorById]
	@InstructorId	INT
AS
BEGIN
	
	DELETE users.Instructor
	WHERE InstructorId = @InstructorId

	SELECT SCOPE_IDENTITY();
END
GO;