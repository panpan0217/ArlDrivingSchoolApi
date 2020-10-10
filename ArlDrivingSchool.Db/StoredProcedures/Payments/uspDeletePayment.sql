CREATE PROCEDURE [payments].[uspDeletePayment]
	@StudentId			INT
AS
BEGIN
	
	DELETE [payments].[Payment]
	WHERE StudentId = @StudentId

	SELECT SCOPE_IDENTITY();
END
GO;
