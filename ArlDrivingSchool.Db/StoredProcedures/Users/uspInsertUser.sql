CREATE PROCEDURE [users].[uspInsertUser]
(
	@UserTypeId INT,
	@FirstName NVARCHAR(128),
	@LastName NVARCHAR(128),
	@Username NVARCHAR(128),
	@Email NVARCHAR (128),
	@Address NVARCHAR(MAX),
	@birthday NVARCHAR(MAX),
	@CreatedAt DATETIME2,
	@UpdatedAt DATETIME2
)
AS
BEGIN
	INSERT INTO [users].[User]
	(UserTypeId,
	FirstName,
	LastName,
	Username,
	Email,
	Address,
	birthday,
	CreatedAt,
	UpdatedAt
	)
	VALUES
	(@UserTypeId,
	@FirstName,
	@LastName,
	@Username,
	@Email,
	@Address,
	@birthday,
	@CreatedAt,
	@UpdatedAt
	);
END
GO