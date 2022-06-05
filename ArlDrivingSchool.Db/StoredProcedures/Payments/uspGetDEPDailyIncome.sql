CREATE PROCEDURE [payments].uspGetDEPDailyIncome
AS
	SELECT SUM(Payment)
		FROM [payments].DEPPayment
		WHERE cast(PaymentDate as Date) = cast(getutcdate() as Date);
GO

