CREATE PROCEDURE [sessions].[uspUpdateSessionOneAttendedByStudentId]
	
	@StudentId			INT,
	@Attended			BIT

AS
BEGIN
	
	UPDATE [sessions].SessionOne
	SET
	 Attended = @Attended
	

	WHERE StudentId = @StudentId
END
GO;
