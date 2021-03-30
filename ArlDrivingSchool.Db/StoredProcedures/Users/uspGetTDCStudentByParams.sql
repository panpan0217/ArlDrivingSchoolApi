CREATE PROCEDURE [users].[uspGetTDCStudentByParams]
(
	@Certificated BIT
)
AS
BEGIN
	SELECT StudentId
		  ,CONCAT(FirstName, ' ', LastName) AS [FullName]
		  ,Certified
		  ,DateCertified
	FROM [users].[Student]
	WHERE Certified = @Certificated
END 
GO;


