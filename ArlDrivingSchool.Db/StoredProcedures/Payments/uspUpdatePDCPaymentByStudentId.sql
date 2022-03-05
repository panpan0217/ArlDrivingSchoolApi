CREATE PROCEDURE [payments].[uspUpdatePDCPaymentByStudentId]
	@StudentId		INT,
	@TotalAmount	INT,
	@Payment		INT,
	@Balance		INT,
	@PaymentModeId INT
AS
BEGIN
	
	UPDATE [payments].PDCPayment
	SET
	 TotalAmount = @TotalAmount
	,Payment = @Payment
	,Balance = @Balance
	,PaymentModeId = @PaymentModeId

	WHERE PDCStudentId = @StudentId
END
GO;