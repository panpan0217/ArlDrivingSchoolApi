CREATE PROCEDURE [users].[uspGetInstructor]

AS
BEGIN
	
	SELECT UserId AS InstructorId	
		  ,CONCAT(FirstName, ' ' , LastName) AS FullName
		  ,IIF(Deleted = 1, 'Inactive', 'Active') AS [Status] 
	FROM users.[User] WHERE UserTypeId = 4

END
GO;