CREATE PROCEDURE [users].[uspUpdateUser]
	@UserId INT,
	@FirstName NVARCHAR(255),
	@LastName NVARCHAR(255),
	@Username NVARCHAR(255),
	@Email NVARCHAR(255),
	@UpdatedAt DATETIME2,
	@UserTypeId INT,
	@Address NVARCHAR(255),
	@Birthday NVARCHAR(50),
	@PhoneNumber NVARCHAR(255)
AS
BEGIN
	
	UPDATE users.[User]
	SET
	 FirstName = @FirstName
	,LastName = @LastName
	,Username = @Username
	,Email = @Email
	,UpdatedAt = @UpdatedAt
	,UserTypeId = @UserTypeId
	,[Address] = @Address
	,birthday = @Birthday
	,PhoneNumber = @PhoneNumber

	WHERE UserId = @UserId

END
GO;