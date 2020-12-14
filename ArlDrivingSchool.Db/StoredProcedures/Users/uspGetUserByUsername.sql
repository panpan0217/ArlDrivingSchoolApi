CREATE PROCEDURE [users].[uspGetUserByUsername]
(
	 @Username NVARCHAR (128)
)
AS
	SELECT u.UserId
		  ,u.FirstName
		  ,u.LastName
		  ,u.Email
		  ,u.Username
		  ,u.UserTypeId
		  ,ut.[Name] AS 'UserType'
		  FROM [users].[User] u
		INNER JOIN [lookups].UserType ut ON ut.UserTypeId = u.UserTypeId
	WHERE u.Username = @Username
GO