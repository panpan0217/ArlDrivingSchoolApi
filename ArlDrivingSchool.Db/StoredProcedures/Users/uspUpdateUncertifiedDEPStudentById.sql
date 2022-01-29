CREATE PROCEDURE [users].[uspUpdateUncertifiedDEPStudentById]
	@Id INT
AS
BEGIN
	
	UPDATE users.DEPStudent
	SET
	 Certified = 0

	WHERE DEPStudentId = @Id

END
GO;
