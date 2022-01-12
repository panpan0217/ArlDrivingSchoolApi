CREATE PROCEDURE [users].[uspGetTDCStudentByParams]
(
	@Certificated BIT,
	@StartDate DATETIME2,
	@EndDate DATETIME2
)
AS
BEGIN
	IF(@Certificated = 1)
	BEGIN
		SELECT StudentId
		  ,CONCAT(FirstName, ' ', LastName) AS [FullName]
		  ,Certified
		  ,DateCertified
		FROM [users].[Student]
		WHERE Certified = @Certificated AND CAST(DateCertified as date) BETWEEN @StartDate AND @EndDate
	END
	ELSE
	BEGIN
		SELECT StudentId
		  ,CONCAT(FirstName, ' ', LastName) AS [FullName]
		  ,Certified
		  ,DateCertified
		FROM [users].[Student]
		WHERE Certified = @Certificated;
	END

END 
GO;


