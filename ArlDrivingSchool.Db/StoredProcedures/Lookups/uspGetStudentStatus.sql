CREATE PROCEDURE [lookups].[uspGetStudentStatus]

AS
BEGIN
	SELECT	StudentStatusId
		   ,StatusName

	FROM lookups.StudentStatus
	
END
GO;
