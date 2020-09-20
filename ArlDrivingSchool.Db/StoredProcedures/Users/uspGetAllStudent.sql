CREATE PROCEDURE [users].[uspGetAllStudent]
AS
BEGIN
	SELECT	StudentId
		   ,FirstName
		   ,LastName
		   ,Email
		   ,[Location]
		   ,FBContact
		   ,Mobile
		   ,StudentStatusId
		   ,ACESStatusId
		   ,TDCStatusId
		   ,Remarks
		   ,Package
		   ,DateRegistered

	FROM users.Student
	
END
GO;