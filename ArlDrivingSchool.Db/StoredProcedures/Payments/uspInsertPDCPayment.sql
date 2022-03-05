CREATE PROCEDURE [payments].[uspInsertPDCPayment]
(
	@PDCStudentId INT,
	@TotalAmount INT,
	@Payment INT,
	@Balance INT,
	@PayMentModeId INT
)
AS
BEGIN 
	INSERT INTO [payments].[PDCPayment]
	(
		PDCStudentId,
		PaymentDate,
		TotalAmount,
		Payment,
		Balance,
		PaymentModeId
	)
	VALUES 
	(
		@PDCStudentId,
		GETUTCDATE(),
		@TotalAmount,
		@Payment,
		@Balance,
		@PayMentModeId
	);

	SELECT SCOPE_IDENTITY();
END 