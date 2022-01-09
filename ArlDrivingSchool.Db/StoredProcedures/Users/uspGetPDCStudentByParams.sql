CREATE PROCEDURE [users].[uspGetPDCStudentByParams]
(
	@Certificated BIT,
	@StartDate DATETIME2,
	@EndDate DATETIME2
)
AS
BEGIN
	SELECT PDCStudentId
		  ,FullName
		  ,Certified
		  ,DateCertified
	FROM [users].[PDCStudent]
	WHERE Certified = @Certificated AND CAST(DateCertified as date) BETWEEN @StartDate AND @EndDate

END 
GO;

