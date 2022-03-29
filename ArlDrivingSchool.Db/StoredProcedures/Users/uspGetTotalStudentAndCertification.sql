CREATE PROCEDURE [users].[uspGetTotalStudentAndCertification]
	@StartDate DATETIME2,
	@EndDate DATETIME2
AS
SELECT 
	'TDC'  [TableName],
	COUNT(s.StudentId) AS [TotalStudent],
	(SELECT COUNT(ss.StudentId) FROM users.[Student] as ss WHERE ss.Certified = 1 AND CAST(ss.DateRegistered as date) BETWEEN @StartDate AND @EndDate )  [TotalCertification]
FROM users.[Student] AS s WHERE CAST(s.DateRegistered as date) BETWEEN @StartDate AND @EndDate

UNION ALL

SELECT 
	'PDC'  [TableName],
	COUNT(s.PDCStudentId) AS [TotalStudent],
	(SELECT COUNT(ss.PDCStudentId) FROM users.[PDCStudent] as ss WHERE ss.Certified = 1 AND CAST(ss.DateRegistered as date) BETWEEN @StartDate AND @EndDate )  [TotalCertification]
FROM users.[PDCStudent] AS s WHERE CAST(s.DateRegistered as date) BETWEEN @StartDate AND @EndDate

UNION ALL

SELECT 
	'DEP'  [TableName],
	COUNT(s.DEPStudentId) AS [TotalStudent],
	(SELECT COUNT(ss.DEPStudentId) FROM users.DEPStudent as ss WHERE ss.Certified = 1 AND CAST(ss.DateRegistered as date) BETWEEN @StartDate AND @EndDate )  [TotalCertification]
FROM users.[DEPStudent] AS s WHERE CAST(s.DateRegistered as date) BETWEEN @StartDate AND @EndDate
Go
