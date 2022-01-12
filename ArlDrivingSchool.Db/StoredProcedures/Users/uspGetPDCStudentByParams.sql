CREATE PROCEDURE [users].[uspGetPDCStudentByParams]
(
	@Certificated BIT,
	@StartDate DATETIME2,
	@EndDate DATETIME2
)
AS
BEGIN
	IF(@Certificated = 1)
	BEGIN
		SELECT PDCStudentId
		  ,FullName
		  ,Certified
		  ,DateCertified
		FROM [users].[PDCStudent]
		WHERE Certified = @Certificated AND CAST(DateCertified as date) BETWEEN @StartDate AND @EndDate
	END
	ELSE
	BEGIN
		SELECT PDCStudentId
		  ,FullName
		  ,Certified
		  ,DateCertified
		FROM [users].[PDCStudent]
		WHERE Certified = @Certificated;
	END
END 
GO;

