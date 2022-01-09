CREATE PROCEDURE [users].[uspGetTDCStudentByParams]
(
	@Certificated BIT,
	@StartDate DATETIME2,
	@EndDate DATETIME2
)
AS
BEGIN
	SELECT StudentId
		  ,CONCAT(FirstName, ' ', LastName) AS [FullName]
		  ,Certified
		  ,DateCertified
	FROM [users].[Student]
	WHERE Certified = @Certificated AND CAST(DateCertified as date) BETWEEN @StartDate AND @EndDate
END 
GO;


