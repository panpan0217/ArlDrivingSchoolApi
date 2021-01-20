CREATE PROCEDURE [users].[uspGetInstructor]

AS
BEGIN
	
	SELECT InstructorId	 
		  ,FullName
		  ,[Status] 
	FROM users.Instructor

END
GO;