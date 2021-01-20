CREATE PROCEDURE [lookups].[uspGetRestriction]
AS
BEGIN
	SELECT	RestrictionId
		   ,RestrictionCode

	FROM lookups.Restriction

END
GO;