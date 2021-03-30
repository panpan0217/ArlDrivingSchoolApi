CREATE PROCEDURE [users].[uspUpdateUncertifiedPDCStudentById]
	@Id INT
AS
BEGIN
	
	UPDATE users.PDCStudent
	SET
	 Certified = 0

	WHERE PDCStudentId = @Id

END
GO;
