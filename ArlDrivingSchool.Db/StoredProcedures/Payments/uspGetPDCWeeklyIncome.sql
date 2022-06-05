CREATE PROCEDURE [payments].uspGetPDCWeeklyIncome
AS
	SELECT SUM(Payment)
		FROM [payments].PDCPayment
		WHERE [PaymentDate] >= dateadd(day, 1-datepart(dw, getdate()), CONVERT(date,getdate())) 
		AND [PaymentDate] <  dateadd(day, 8-datepart(dw, getdate()), CONVERT(date,getdate()))
GO

