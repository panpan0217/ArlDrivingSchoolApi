CREATE PROCEDURE [users].[uspUpdateUncertifiedStudentById]
	@Id INT
AS
BEGIN
	
	UPDATE users.Student
	SET
	 Certified = 0

	WHERE StudentId = @Id

END
GO;
