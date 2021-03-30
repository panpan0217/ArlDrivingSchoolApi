CREATE PROCEDURE [users].[uspUpdatePDCStudentCertificationByIds]
	@Ids NVARCHAR(255)
AS
BEGIN
	
	UPDATE users.PDCStudent
	SET
	 Certified = 1
	,DateCertified = GETDATE()

	WHERE @Ids like '%,'+cast(PDCStudentId as varchar(20))+',%'

END
GO;
