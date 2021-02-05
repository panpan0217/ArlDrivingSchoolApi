CREATE PROCEDURE [sessions].[uspDeletePDCSession]
	@PDCSessionId			INT
AS
BEGIN
	
	DELETE [sessions].[PDCSession]
	WHERE PDCSessionId = @PDCSessionId

	SELECT SCOPE_IDENTITY();
END
GO;
