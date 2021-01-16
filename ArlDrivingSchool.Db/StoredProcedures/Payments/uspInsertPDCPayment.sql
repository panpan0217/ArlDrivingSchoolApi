CREATE PROCEDURE [payments].[uspInsertPDCPayment]
(
	@PDCStudentId INT,
	@TotalAmount INT,
	@Payment INT,
	@Balance INT
)
AS
BEGIN 
	INSERT INTO [payments].[PDCPayment]
	(
		PDCStudentId,
		PaymentDate,
		TotalAmount,
		Payment,
		Balance
	)
	VALUES 
	(
		@PDCStudentId,
		GETUTCDATE(),
		@TotalAmount,
		@Payment,
		@Balance
	);

	SELECT SCOPE_IDENTITY();
END 