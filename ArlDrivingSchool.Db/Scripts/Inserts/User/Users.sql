DECLARE
	@FirstName	NVARCHAR(255) = 'jm',
	@LastName	NVARCHAR(255) = 'cayanan',
	@UserName	NVARCHAR(255) = 'jmcayanan',
	@Email		NVARCHAR(255) = 'jmcayanan@mailinator.com',
	@UserId		INT
	
	SELECT @UserId = UserId FROM [users].[User] WHERE Username = @UserName;

	IF(@UserId IS NULL)
	BEGIN
		INSERT INTO [users].[User](FirstName, LastName, Username, Email, CreatedAt, UpdatedAt, UserTypeId)
		VALUES
		(@FirstName ,@LastName ,@UserName , @Email ,GETUTCDATE(), GETUTCDATE(),'2');
		SET @UserId = (SELECT SCOPE_IDENTITY() AS [SCOPE_IDENTITY]);


		INSERT INTO [users].[Access]
		(
			 UserId
			,Auth
			,ExpirationDate
			,IsTempAuthActive
			,CreatedAt
			,UpdatedAt
			,Salt
		)
		VALUES( 
			@UserId
			,'gZgut2OcrokZyV0rPR3tD6PX0YShu1G8zsePVre0h5Y='
			,'2120-03-18T09:28:38.322Z'
			,'0'
			,GETUTCDATE()
			,GETUTCDATE()
			,'+NOJDf1h5zWjS5mZxET74w=='
			)



	END;
