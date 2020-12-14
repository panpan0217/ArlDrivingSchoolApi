CREATE PROCEDURE [users].[uspGetAccessByUserId]
	@UserId int
AS
	SELECT a.Auth,
		   a.Salt
	FROM [users].Access a
	WHERE a.UserId = a.UserId
GO