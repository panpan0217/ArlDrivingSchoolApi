CREATE PROCEDURE [users].[uspUpdateDEPStudentCertificationByIds]
	@Ids NVARCHAR(255),
	@CurrentDate DATETIME2
AS
BEGIN
	
	UPDATE users.DEPStudent
	SET
	 Certified = 1
	,DateCertified = @CurrentDate

	WHERE @Ids like '%,'+cast(DEPStudentId as varchar(20))+',%'

END
GO;
