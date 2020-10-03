CREATE PROCEDURE [lookups].[uspGetACESStatus]

AS
BEGIN
	SELECT	ACESStatusId
		   ,StatusName

	FROM lookups.ACESStatus

END
GO;
