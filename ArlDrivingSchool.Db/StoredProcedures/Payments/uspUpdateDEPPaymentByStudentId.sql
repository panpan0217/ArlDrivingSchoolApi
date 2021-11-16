CREATE PROCEDURE [payments].[uspUpdateDEPPaymentByStudentId]
	@DEPStudentId	INT,
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


	WHERE PDCStudentId = @DEPStudentId
END
GO;