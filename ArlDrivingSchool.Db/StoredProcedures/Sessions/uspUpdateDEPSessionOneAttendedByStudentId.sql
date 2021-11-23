CREATE PROCEDURE [sessions].[uspUpdateDEPSessionOneAttendedByStudentId]
	
	@StudentId			INT,
	@Attended			BIT

AS
BEGIN
	
	UPDATE [sessions].DEPSession
	SET
	 Attended = @Attended
	WHERE DEPStudentId = @StudentId
END
GO;
