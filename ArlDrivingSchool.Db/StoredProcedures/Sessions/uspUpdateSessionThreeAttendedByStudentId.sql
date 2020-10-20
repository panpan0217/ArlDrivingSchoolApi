CREATE PROCEDURE [sessions].[uspUpdateSessionThreeAttendedByStudentId]
	@StudentId			INT,
	@Attended			BIT

AS
BEGIN
	
	UPDATE [sessions].SessionThree
	SET
	 Attended = @Attended
	

	WHERE StudentId = @StudentId
END
GO;

