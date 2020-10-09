CREATE PROCEDURE [payments].[uspUpdatePaymentByStudentId]
	@StudentId		INT,
	@TotalAmount	INT,
	@Payment		INT,
	@Balance		INT
AS
BEGIN
	
	UPDATE [payments].Payment
	SET
	 TotalAmount = @TotalAmount
	,Payment = @Payment
	,Balance = @Balance


	WHERE StudentId = @StudentId
END
GO;