CREATE PROCEDURE [payments].uspGetDEPMonthlyIncome
AS
	SELECT SUM(Payment)
		FROM [payments].DEPPayment
		WHERE MONTH([PaymentDate]) = MONTH(GETUTCDATE())
		AND YEAR([PaymentDate]) = YEAR(GETUTCDATE());
GO

