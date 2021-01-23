CREATE PROCEDURE [users].[uspGetInstructorById]
	@Id int
AS
	SELECT	InstructorId,
			FullName,
			[Status]
	FROM [users].Instructor
	WHERE InstructorId = @Id
GO