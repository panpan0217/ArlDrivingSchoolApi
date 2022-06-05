CREATE PROCEDURE [payments].uspGetPDCMonthlyIncome
AS
	SELECT SUM(Payment)
		FROM [payments].PDCPayment
		WHERE MONTH([PaymentDate]) = MONTH(GETUTCDATE())
		AND YEAR([PaymentDate]) = YEAR(GETUTCDATE());
GO

