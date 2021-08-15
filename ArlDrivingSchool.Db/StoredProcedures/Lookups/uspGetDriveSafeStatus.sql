CREATE PROCEDURE [lookups].[uspGetDriveSafeStatus]
AS
BEGIN
	SELECT	DriveSafeStatusId
		   ,StatusName
	FROM	lookups.DriveSafeStatus

END
GO;
