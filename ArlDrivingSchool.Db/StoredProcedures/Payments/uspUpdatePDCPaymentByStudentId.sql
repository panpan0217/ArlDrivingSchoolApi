CREATE PROCEDURE [payments].[uspUpdatePDCPaymentByStudentId]
	@StudentId		INT,
	@TotalAmount	INT,
	@Payment		INT,
	@Balance		INT
AS
BEGIN
	
	UPDATE [payments].PDCPayment
	SET
	 TotalAmount = @TotalAmount
	,Payment = @Payment
	,Balance = @Balance


	WHERE PDCStudentId = @StudentId
END
GO;