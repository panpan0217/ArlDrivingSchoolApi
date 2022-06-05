CREATE PROCEDURE [payments].uspGetPDCDailyIncome
AS
	SELECT SUM(Payment)
		FROM [payments].PDCPayment
		WHERE cast(PaymentDate as Date) = cast(getutcdate() as Date);
GO

