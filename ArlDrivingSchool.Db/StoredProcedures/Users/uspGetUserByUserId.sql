CREATE PROCEDURE [users].[uspGetUserByUserId]
(
	 @UserId INT
)
AS
	SELECT u.UserId
		  ,u.FirstName
		  ,u.LastName
		  ,u.Email
		  ,u.Username
		  ,u.[Address]
		  ,u.birthday
		  ,u.PhoneNumber
		  ,u.UserTypeId
		  FROM [users].[User] AS u
	WHERE u.UserId = @UserId
Go
