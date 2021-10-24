CREATE PROCEDURE [users].[uspSaveProfileLink]

	@ProfileLink		NVARCHAR(MAX),
	@UserId				INT
AS
BEGIN
	
	UPDATE users.[User]
	SET ProfileLink = @ProfileLink
	WHERE UserId = @UserId

END
GO;
