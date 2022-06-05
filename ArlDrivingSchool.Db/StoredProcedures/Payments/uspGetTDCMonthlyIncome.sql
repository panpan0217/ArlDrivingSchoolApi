CREATE PROCEDURE [payments].uspGetTDCMonthlyIncome
AS
	SELECT SUM(Payment)
		FROM [payments].[Payment]
		WHERE MONTH([PaymentDate]) = MONTH(GETUTCDATE())
		AND YEAR([PaymentDate]) = YEAR(GETUTCDATE());
GO

