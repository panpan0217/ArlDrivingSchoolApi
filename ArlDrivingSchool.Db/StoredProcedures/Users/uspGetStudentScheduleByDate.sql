CREATE PROCEDURE [users].[uspGetStudentScheduleByDate]
	@Date		DATETIME2,
	@Schedule	NVARCHAR(55),
	@SessionLocation NVARCHAR(55),
	@BranchId		INT
AS
BEGIN
		SELECT 
		ss.StudentId
	   ,FirstName
	   ,LastName
	   ,a.StatusName AS AcesStatus
	   ,FBContact
	   ,Remarks
	   ,sth.SessionDate 
	   ,sth.Schedule
	   ,sth.SessionLocation
	   ,[Session] = '3'
	   ,sth.Attended

	FROM users.Student AS ss
	INNER JOIN [lookups].[ACESStatus] AS a ON ss.ACESStatusId = a.ACESStatusId
	INNER JOIN sessions.SessionThree AS sth ON sth.StudentId = ss.StudentId
	AND CAST(sth.SessionDate as date) = @Date AND sth.Schedule = @Schedule AND @SessionLocation = sth.SessionLocation
	AND sth.BranchId =@BranchId

	UNION ALL

	SELECT 
		ss.StudentId
	   ,FirstName
	   ,LastName
	   ,a.StatusName AS AcesStatus
	   ,FBContact
	   ,Remarks
	   ,stw.SessionDate 
	   ,stw.Schedule
	   ,stw.SessionLocation
	   ,[Session] = '2'
	   ,stw.Attended

	FROM users.Student AS ss
	INNER JOIN [lookups].[ACESStatus] AS a ON ss.ACESStatusId = a.ACESStatusId
	INNER JOIN sessions.SessionTwo AS stw ON stw.StudentId = ss.StudentId
	AND CAST(stw.SessionDate as date) = @Date AND stw.Schedule = @Schedule AND stw.SessionLocation = @SessionLocation
	AND stw.BranchId =@BranchId
	UNION ALL

	SELECT 
		ss.StudentId
	   ,FirstName
	   ,LastName
	   ,a.StatusName AS AcesStatus
	   ,FBContact
	   ,Remarks
	   ,so.SessionDate 
	   ,so.Schedule
	   ,so.SessionLocation
	   ,[Session] = '1'
	   ,so.Attended

	FROM users.Student AS ss
	INNER JOIN [lookups].[ACESStatus] AS a ON ss.ACESStatusId = a.ACESStatusId
	INNER JOIN sessions.SessionOne AS so ON so.StudentId = ss.StudentId 
	AND CAST(so.SessionDate as date) = @Date AND so.Schedule = @Schedule AND @SessionLocation = so.SessionLocation
	AND so.BranchId =@BranchId
END
GO;
