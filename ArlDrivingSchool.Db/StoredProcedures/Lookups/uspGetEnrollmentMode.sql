CREATE PROCEDURE [lookups].[uspGetEnrollmentMode]
AS
BEGIN
	SELECT	EnrollmentModeId
		   ,EnrollmentModeName
		   ,[Order]
	FROM	lookups.EnrollmentMode

END
GO;
