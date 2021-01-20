CREATE PROCEDURE [users].[uspUpdateInstructor]
	@InstructorId INT,
	@FullName NVARCHAR(255),
	@Status NVARCHAR(255)
AS
BEGIN
	
	UPDATE users.Instructor
	SET
	 FullName = @FullName
	,[Status] = @Status

	WHERE InstructorId = @InstructorId

END
GO;