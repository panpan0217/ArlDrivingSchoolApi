CREATE PROCEDURE [users].[usp_UpdateStudentCertificationByIds]
	@Ids NVARCHAR(255),
	@CurrentDate DATETIME2
AS
BEGIN
	
	UPDATE users.Student
	SET
	 Certified = 1
	,DateCertified = @CurrentDate

	WHERE @Ids like '%,'+cast(StudentId as varchar(20))+',%'

END
GO;
