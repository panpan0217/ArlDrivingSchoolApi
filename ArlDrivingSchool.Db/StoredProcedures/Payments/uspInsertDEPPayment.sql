CREATE PROCEDURE [payments].[uspInsertDEPPayment]
(
	@DEPStudentId INT,
	@TotalAmount INT,
	@Payment INT,
	@Balance INT,
	@PaymentModeId INT
)
AS
BEGIN 
	INSERT INTO [payments].[DEPPayment]
	(
		DEPStudentId,
		PaymentDate,
		TotalAmount,
		Payment,
		Balance,
		PaymentModeId
	)
	VALUES 
	(
		@DEPStudentId,
		GETUTCDATE(),
		@TotalAmount,
		@Payment,
		@Balance,
		@PaymentModeId
	);

	SELECT SCOPE_IDENTITY();
END 