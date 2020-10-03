CREATE PROCEDURE [lookups].[uspGetTDCStatus]
AS
BEGIN
	SELECT	TDCStatusId
		   ,StatusName

	FROM lookups.TDCStatus

END
GO;

