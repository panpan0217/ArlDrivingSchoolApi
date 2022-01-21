CREATE PROCEDURE [users].[uspDeleteUserById]
	@Id			INT
AS
BEGIN
	
	UPDATE users.[User]
	SET Deleted = 1
	WHERE UserId = @Id;
END
GO;
