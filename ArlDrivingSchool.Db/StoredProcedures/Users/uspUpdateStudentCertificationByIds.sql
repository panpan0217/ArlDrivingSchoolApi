CREATE PROCEDURE [users].[usp_UpdateStudentCertificationByIds]
	@Ids NVARCHAR(255)
AS
BEGIN
	
	UPDATE users.Student
	SET
	 Certified = 1
	,DateCertified = GETDATE()

	WHERE @Ids like '%,'+cast(StudentId as varchar(20))+',%'

END
GO;
