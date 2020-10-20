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
	   ,sth.Attended

	FROM users.Student AS ss

	INNER JOIN sessions.SessionThree AS sth ON sth.StudentId = ss.StudentId
	AND CAST(sth.SessionDate as date) = @Date AND sth.Schedule = @Schedule AND @SessionLocation = sth.SessionLocation

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
	   ,stw.Attended

	FROM users.Student AS ss

	INNER JOIN sessions.SessionTwo AS stw ON stw.StudentId = ss.StudentId
	AND CAST(stw.SessionDate as date) = @Date AND stw.Schedule = @Schedule AND stw.SessionLocation = @SessionLocation

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
	   ,so.Attended

	FROM users.Student AS ss

	INNER JOIN sessions.SessionOne AS so ON so.StudentId = ss.StudentId 
	AND CAST(so.SessionDate as date) = @Date AND so.Schedule = @Schedule AND @SessionLocation = so.SessionLocation
END
GO;
