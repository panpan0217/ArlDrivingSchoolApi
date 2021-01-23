CREATE PROCEDURE [sessions].[uspGetPDCSession]
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
	
END
GO;