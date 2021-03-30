CREATE PROCEDURE [users].[uspGetPDCStudentByParams]
(
	@Certificated BIT
)
AS
BEGIN
	SELECT PDCStudentId
		  ,FullName
		  ,Certified
		  ,DateCertified
	FROM [users].[PDCStudent]
	WHERE Certified = @Certificated
END 
GO;

