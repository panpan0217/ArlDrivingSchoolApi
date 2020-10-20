CREATE PROCEDURE [sessions].[uspUpdateSessionTwoAttendedByStudentId]
	@StudentId			INT,
	@Attended			BIT

AS
BEGIN
	
	UPDATE [sessions].SessionTwo
	SET
	 Attended = @Attended
	

	WHERE StudentId = @StudentId
END
GO;

