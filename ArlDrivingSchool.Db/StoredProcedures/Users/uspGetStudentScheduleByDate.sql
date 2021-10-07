﻿CREATE PROCEDURE [users].[uspGetStudentScheduleByDate]
	@Date		DATETIME2,
	@Schedule	NVARCHAR(55),
	@SessionLocation NVARCHAR(55),
	@BranchId		INT
AS
BEGIN
		DECLARE @SessionsAttended TABLE(
			StudentId INT,
			SessionsAttended NVARCHAR(120)
		)
		
		INSERT INTO @SessionsAttended(
			StudentId,
			SessionsAttended
		)SELECT 
			ss.StudentId
			,CONCAT(CASE WHEN so.Attended = CAST(1 AS BIT) THEN '1,' END , CASE WHEN st.Attended = CAST(1 AS BIT) THEN '2,' END, CASE WHEN sth.Attended = CAST(1 AS BIT) THEN '3,' END)
		FROM users.Student AS ss
		INNER JOIN [lookups].[ACESStatus] AS a ON ss.ACESStatusId = a.ACESStatusId
		INNER JOIN sessions.SessionThree AS sth ON sth.StudentId = ss.StudentId
		INNER JOIN sessions.SessionOne AS so ON ss.StudentId = so.StudentId
		INNER JOIN sessions.SessionTwo AS st ON ss.StudentId = st.StudentId;


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
	   ,(SELECT CASE WHEN LEN(sa.SessionsAttended) > 1 THEN SUBSTRING(sa.SessionsAttended, 1, (LEN(sa.SessionsAttended) - 1)) ELSE  sa.SessionsAttended END FROM @SessionsAttended AS sa where sa.StudentId = ss.StudentId) AS [SessionsAttended]

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
	   ,(SELECT CASE WHEN LEN(sa.SessionsAttended) > 1 THEN SUBSTRING(sa.SessionsAttended, 1, (LEN(sa.SessionsAttended) - 1)) ELSE  sa.SessionsAttended END FROM @SessionsAttended AS sa where sa.StudentId = ss.StudentId) AS [SessionsAttended]

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
	   ,(SELECT CASE WHEN LEN(sa.SessionsAttended) > 1 THEN SUBSTRING(sa.SessionsAttended, 1, (LEN(sa.SessionsAttended) - 1)) ELSE  sa.SessionsAttended END FROM @SessionsAttended AS sa where sa.StudentId = ss.StudentId) AS [SessionsAttended]

	FROM users.Student AS ss
	INNER JOIN [lookups].[ACESStatus] AS a ON ss.ACESStatusId = a.ACESStatusId
	INNER JOIN sessions.SessionOne AS so ON so.StudentId = ss.StudentId 
	AND CAST(so.SessionDate as date) = @Date AND so.Schedule = @Schedule AND @SessionLocation = so.SessionLocation
	AND so.BranchId =@BranchId
END
GO;
