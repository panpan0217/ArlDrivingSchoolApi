CREATE PROCEDURE [users].[uspGetInstructorById]
	@Id int
AS
	SELECT UserId AS InstructorId	 
			,CONCAT(FirstName, ' ' , LastName) AS FullName
			,IIF(Deleted = 1, 'Inactive', 'Active') AS [Status] 
	FROM users.[User]
	WHERE UserId = @Id
GO