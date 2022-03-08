CREATE PROCEDURE [users].[uspUpdatePDCStudentCertificationByIds]
	@Ids NVARCHAR(255),
	@CurrentDate DATETIME2
AS
BEGIN
	
	UPDATE users.PDCStudent
	SET
	 Certified = 1
	,DateCertified = @CurrentDate

	WHERE @Ids like '%,'+cast(PDCStudentId as varchar(20))+',%'

END
GO;
