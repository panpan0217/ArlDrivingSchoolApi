CREATE PROCEDURE [users].[uspGetStudentScheduleByDate]
	@Date		DATETIME2,
	@Schedule	NVARCHAR(55),
	@SessionLocation NVARCHAR(55)
AS
BEGIN
	SELECT 
		ss.StudentId
	   ,FirstName
	   ,LastName
	   ,FBContact
	   ,sth.SessionDate 
	   ,sth.Schedule
	   ,sth.SessionLocation
	   ,[Session] = 'Three'
	   ,lt.TDCStatusId
	   ,lt.StatusName

	FROM users.Student AS ss

	INNER JOIN sessions.SessionThree AS sth ON sth.StudentId = ss.StudentId
	AND CAST(sth.SessionDate as date) = @Date AND sth.Schedule = @Schedule AND @SessionLocation = sth.SessionLocation
	LEFT JOIN lookups.TDCStatus AS lt ON lt.TDCStatusId = ss.TDCStatusId

	UNION ALL

	SELECT 
		ss.StudentId
	   ,FirstName
	   ,LastName
	   ,FBContact
	   ,stw.SessionDate 
	   ,stw.Schedule
	   ,stw.SessionLocation
	   ,[Session] = 'Two'
	   ,lt.TDCStatusId
	   ,lt.StatusName

	FROM users.Student AS ss

	INNER JOIN sessions.SessionTwo AS stw ON stw.StudentId = ss.StudentId
	AND CAST(stw.SessionDate as date) = @Date AND stw.Schedule = @Schedule AND stw.SessionLocation = @SessionLocation
	LEFT JOIN lookups.TDCStatus AS lt ON lt.TDCStatusId = ss.TDCStatusId

	UNION ALL

	SELECT 
		ss.StudentId
	   ,FirstName
	   ,LastName
	   ,FBContact
	   ,so.SessionDate 
	   ,so.Schedule
	   ,so.SessionLocation
	   ,[Session] = 'One'
	   ,lt.TDCStatusId
	   ,lt.StatusName

	FROM users.Student AS ss

	INNER JOIN sessions.SessionOne AS so ON so.StudentId = ss.StudentId 
	AND CAST(so.SessionDate as date) = @Date AND so.Schedule = @Schedule AND @SessionLocation = so.SessionLocation
	LEFT JOIN lookups.TDCStatus AS lt ON lt.TDCStatusId = ss.TDCStatusId
END
GO;
