CREATE PROCEDURE [users].[uspGetShuttleScheduleByDate]
	@Date		DATETIME2,
	@Schedule	NVARCHAR(55)
AS
BEGIN
	SELECT 
		ss.StudentId
	   ,FirstName
	   ,LastName
	   ,FBContact 
	   ,so.Schedule

	FROM users.Student AS ss
	INNER JOIN sessions.SessionOne AS so ON so.StudentId = ss.StudentId
	AND CAST(so.SessionDate as date) = @Date AND so.Schedule = @Schedule AND so.Shuttle = 1

	UNION ALL

	SELECT 
		ss.StudentId
	   ,FirstName
	   ,LastName
	   ,FBContact 
	   ,st.Schedule

	FROM users.Student AS ss
	INNER JOIN sessions.SessionTwo AS st ON st.StudentId = ss.StudentId
	AND CAST(st.SessionDate as date) = @Date AND st.Schedule = @Schedule AND st.Shuttle = 1

	UNION ALL

	SELECT 
		ss.StudentId
	   ,FirstName
	   ,LastName
	   ,FBContact 
	   ,sth.Schedule

	FROM users.Student AS ss
	INNER JOIN sessions.SessionThree AS sth ON sth.StudentId = ss.StudentId
	AND CAST(sth.SessionDate as date) = @Date AND sth.Schedule = @Schedule AND sth.Shuttle = 1

END
GO;
