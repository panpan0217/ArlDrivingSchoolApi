CREATE PROCEDURE [payments].[uspInsertPayment]
(
	@StudentId INT,
	@TotalAmount INT,
	@Payment INT,
	@Balance INT
)
AS
BEGIN 
	INSERT INTO [payments].[Payment]
	(
		StudentId,
		PaymentDate,
		TotalAmount,
		Payment,
		Balance
	)
	VALUES 
	(
		@StudentId,
		GETUTCDATE(),
		@TotalAmount,
		@Payment,
		@Balance
	);

	SELECT SCOPE_IDENTITY();
END 