CREATE PROCEDURE [users].[uspInsertAccess]
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
	IF EXISTS(SELECT * FROM [users].Access WHERE UserId = @UserId)            
		BEGIN            
			UPDATE [users].[Access] SET
			Auth = @Auth,
			Salt = @Salt,
			UpdatedAt = @UpdatedAt,
			ExpirationDate = @ExpirationDate,
			IsTempAuthActive = @IsTempAuthActive
			WHERE UserId = @UserId;
		END                    
	ELSE            
		BEGIN  
			INSERT INTO [users].[Access]
			(Auth,
			Salt,
			UserId,
			CreatedAt,
			UpdatedAt,
			ExpirationDate,
			IsTempAuthActive
			)
			VALUES
			(@Auth,
			@Salt,
			@UserId,
			@CreatedAt,
			@UpdatedAt,
			@ExpirationDate,
			@IsTempAuthActive);
		END 
END
GO