CREATE PROCEDURE [users].[uspUpdateDEPStudentCertificationByIds]
	@Ids NVARCHAR(255)
AS
BEGIN
	
	UPDATE users.DEPStudent
	SET
	 Certified = 1
	,DateCertified = GETDATE()

	WHERE @Ids like '%,'+cast(DEPStudentId as varchar(20))+',%'

END
GO;
