CREATE PROCEDURE [payments].[uspUpdateDEPPaymentByStudentId]
	@DEPStudentId	INT,
	@TotalAmount	INT,
	@Payment		INT,
	@Balance		INT
AS
BEGIN
	
	UPDATE [payments].DEPPayment
	SET
	 TotalAmount = @TotalAmount
	,Payment = @Payment
	,Balance = @Balance
	WHERE DEPStudentId = @DEPStudentId
END
GO;