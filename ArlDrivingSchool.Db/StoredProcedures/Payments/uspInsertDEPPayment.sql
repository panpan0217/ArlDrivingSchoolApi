CREATE PROCEDURE [payments].[uspInsertDEPPayment]
(
	@DEPStudentId INT,
	@TotalAmount INT,
	@Payment INT,
	@Balance INT
)
AS
BEGIN 
	INSERT INTO [payments].[DEPPayment]
	(
		DEPStudentId,
		PaymentDate,
		TotalAmount,
		Payment,
		Balance
	)
	VALUES 
	(
		@DEPStudentId,
		GETUTCDATE(),
		@TotalAmount,
		@Payment,
		@Balance
	);

	SELECT SCOPE_IDENTITY();
END 