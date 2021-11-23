CREATE PROCEDURE [users].[uspGetDEPStudentScheduleByDate]
	@Date		DATETIME2,
	@Schedule	NVARCHAR(55),
	@SessionLocation NVARCHAR(55),
	@BranchId		INT
AS
BEGIN
		SELECT 
		ss.DEPStudentId
	   ,FullName
	   ,FBContact
	   ,Remarks
	   ,sth.[Date] AS [SessionDate]
	   ,sth.Schedule
	   ,sth.SessionLocation
	   ,sth.Attended

	FROM users.DEPStudent AS ss
	INNER JOIN sessions.DEPSession AS sth ON sth.DEPSessionId = ss.DEPStudentId
	AND CAST(sth.[Date] as date) = @Date AND sth.Schedule = @Schedule AND @SessionLocation = sth.SessionLocation
	AND sth.BranchId =@BranchId

END
GO;
