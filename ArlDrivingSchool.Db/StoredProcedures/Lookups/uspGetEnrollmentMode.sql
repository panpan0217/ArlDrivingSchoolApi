CREATE PROCEDURE [lookups].[uspGetEnrollmentMode]
AS
BEGIN
	SELECT	EnrollmentModeId
		   ,EnrollmentModeName
	FROM	lookups.EnrollmentMode

END
GO;
