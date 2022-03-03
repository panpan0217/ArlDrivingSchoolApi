CREATE PROCEDURE [lookups].[uspGetOffice]
AS
BEGIN
	SELECT	OfficeId
		   ,OfficeName
	FROM	lookups.Office

END
GO;
