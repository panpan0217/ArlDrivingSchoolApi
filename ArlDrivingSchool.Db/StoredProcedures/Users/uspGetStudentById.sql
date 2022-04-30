CREATE PROCEDURE [users].[uspGetStudentId]
(
	 @StudentId INT
)
AS
BEGIN
	SELECT	us.StudentId
		   ,us.FirstName
		   ,us.LastName
		   ,us.Email
		   ,us.[Location]
		   ,us.FBContact
		   ,us.Mobile
		   ,us.Remarks
		   ,us.DateRegistered
		   ,us.Certified
		   ,us.DateCertified
		   ,us.AuthenticatedBy
		   ,us.ClassType
		   ,us.DriveSafeStatusId
		   ,us.SessionEmail
		   ,us.TextForm
		   ,us.CreatedBy
		   ,us.UpdatedBy
		   ,us.AcesSaveDate
		   ,us.ACESStatusId
	FROM users.Student AS us
	WHERE us.StudentId = @StudentId;
END
GO;
