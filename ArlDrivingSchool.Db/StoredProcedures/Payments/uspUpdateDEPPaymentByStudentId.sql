CREATE PROCEDURE [payments].[uspUpdateDEPPaymentByStudentId]
	@DEPStudentId	INT,
	@TotalAmount	INT,
	@Payment		INT,
	@Balance		INT,
	@PaymentModeId	INT
AS
BEGIN
	
	UPDATE [payments].DEPPayment
	SET
	 TotalAmount = @TotalAmount
	,Payment = @Payment
	,Balance = @Balance
	,PaymentModeId = @PaymentModeId
	WHERE DEPStudentId = @DEPStudentId
END
GO;