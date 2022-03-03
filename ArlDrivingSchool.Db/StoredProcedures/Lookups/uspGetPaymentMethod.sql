CREATE PROCEDURE [lookups].[uspGetPaymentMethod]
AS
BEGIN
	SELECT	PaymentModeId
		   ,PaymentModeName
	FROM	lookups.PaymentMode

END
GO;
