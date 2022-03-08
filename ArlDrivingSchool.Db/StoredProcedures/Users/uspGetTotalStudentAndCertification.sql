CREATE PROCEDURE [users].[uspGetTotalStudentAndCertification]

AS
SELECT 
	'TDC'  [TableName],
	COUNT(s.StudentId) AS [TotalStudent],
	(SELECT COUNT(ss.StudentId) FROM users.[Student] as ss WHERE ss.Certified = 1 )  [TotalCertification]
FROM users.[Student] AS s

UNION ALL

SELECT 
	'PDC'  [TableName],
	COUNT(s.PDCStudentId) AS [TotalStudent],
	(SELECT COUNT(ss.PDCStudentId) FROM users.[PDCStudent] as ss WHERE ss.Certified = 1 )  [TotalCertification]
FROM users.[PDCStudent] AS s

UNION ALL

SELECT 
	'DEP'  [TableName],
	COUNT(s.DEPStudentId) AS [TotalStudent],
	(SELECT COUNT(ss.DEPStudentId) FROM users.DEPStudent as ss WHERE ss.Certified = 1 )  [TotalCertification]
FROM users.[DEPStudent] AS s
Go
