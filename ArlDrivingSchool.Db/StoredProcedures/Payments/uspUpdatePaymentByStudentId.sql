CREATE PROCEDURE [payments].[uspUpdatePaymentByStudentId]
	@StudentId		INT,
	@TotalAmount	INT,
	@Payment		INT,
	@Balance		INT,
	@PaymentModeId	INT
AS
BEGIN
	
	UPDATE [payments].Payment
	SET
	 TotalAmount = @TotalAmount
	,Payment = @Payment
	,Balance = @Balance
	,PaymentModeId = @PaymentModeId

	WHERE StudentId = @StudentId
END
GO;