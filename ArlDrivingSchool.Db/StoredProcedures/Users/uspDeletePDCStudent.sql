CREATE PROCEDURE [users].[uspDeletePDCStudent]
	@PDCStudentId	INT
AS
BEGIN
	
	DELETE users.PDCStudent
	WHERE PDCStudentId = @PDCStudentId

	SELECT SCOPE_IDENTITY();
END
GO;