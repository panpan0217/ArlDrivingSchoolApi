CREATE PROCEDURE [lookups].[uspGetGender]
AS
BEGIN
	SELECT	GenderId
		   ,GenderName

	FROM lookups.[Gender]

END
GO;