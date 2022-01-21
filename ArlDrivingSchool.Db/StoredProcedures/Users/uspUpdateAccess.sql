CREATE PROCEDURE [users].[uspUpdateAccess]
(
	@Auth				NVARCHAR(128),
	@Salt				NVARCHAR(128),
	@UserId				INT,
	@CreatedAt			DATETIME2,
	@UpdatedAt			DATETIME2,
	@ExpirationDate		DATETIME2,
	@IsTempAuthActive	BIT
)
AS
BEGIN
	UPDATE [users].[Access] SET
	Auth = @Auth,
	Salt = @Salt,
	UpdatedAt = @UpdatedAt,
	ExpirationDate = @ExpirationDate,
	IsTempAuthActive = @IsTempAuthActive
	WHERE UserId = @UserId;
END
GO