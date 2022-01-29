CREATE PROCEDURE [users].[uspGetDEPStudentByParams]
(
	@Certificated BIT,
	@StartDate DATETIME2,
	@EndDate DATETIME2
)
AS
BEGIN
	IF(@Certificated = 1)
	BEGIN
		SELECT DEPStudentId
		  ,FullName
		  ,Certified
		  ,DateCertified
		FROM [users].[DEPStudent]
		WHERE Certified = @Certificated AND CAST(DateCertified as date) BETWEEN @StartDate AND @EndDate
	END
	ELSE
	BEGIN
		SELECT DEPStudentId
		  ,FullName
		  ,Certified
		  ,DateCertified
		FROM [users].[DEPStudent]
		WHERE Certified = @Certificated;
	END
END 
GO;

