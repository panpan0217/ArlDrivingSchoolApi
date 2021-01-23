CREATE PROCEDURE [sessions].[uspGetPDCSessionByInstructorId]
	@Id int
AS
BEGIN
	SELECT	PDCSessionId
		   ,[Date]
		   ,StartTime
		   ,EndTime
		   ,PDCStudentId
		   ,InstructorId
		   ,Attended
	FROM sessions.PDCSession
	WHERE InstructorId = @Id
END
GO;
