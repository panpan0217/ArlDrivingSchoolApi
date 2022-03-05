CREATE PROCEDURE [payments].[uspInsertPayment]
(
	@StudentId INT,
	@TotalAmount INT,
	@Payment INT,
	@Balance INT,
	@PaymentModeId INT
)
AS
BEGIN 
	INSERT INTO [payments].[Payment]
	(
		StudentId,
		PaymentDate,
		TotalAmount,
		Payment,
		Balance,
		PaymentModeId
	)
	VALUES 
	(
		@StudentId,
		GETUTCDATE(),
		@TotalAmount,
		@Payment,
		@Balance,
		@PaymentModeId
	);

	SELECT SCOPE_IDENTITY();
END 