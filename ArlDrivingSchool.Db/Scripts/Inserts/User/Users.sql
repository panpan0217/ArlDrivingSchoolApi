DECLARE
	@FirstName	NVARCHAR(255) = 'ej',
	@LastName	NVARCHAR(255) = 'modesto',
	@UserName	NVARCHAR(255) = 'ejmodesto',
	@Email		NVARCHAR(255) = 'ejmodesto@mailinator.com',
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
			,'/XrUkVgo3B0moPNt1eAea3g7h+FXiVjhxwhOiU3Ptqo='
			,'2120-03-18T09:28:38.322Z'
			,'0'
			,GETUTCDATE()
			,GETUTCDATE()
			,'pIhjk3ILGZ3b3r2Z5s8SFg=='
			)



	END;