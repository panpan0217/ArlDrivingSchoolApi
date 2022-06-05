CREATE PROCEDURE [payments].uspGetTDCDailyIncome
AS
	SELECT SUM(Payment)
		FROM [payments].[Payment]
		WHERE cast(PaymentDate as Date) = cast(getutcdate() as Date);
GO

