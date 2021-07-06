﻿CREATE PROCEDURE [users].[uspGetStudentWithDetailsById]
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
		   ,ls.StatusName [StudentStatus]
		   ,la.StatusName [ACESStatus]
		   ,lt.StatusName [TDCStatus]
		   ,us.Remarks
		   ,us.DateRegistered
		   ,us.Certified
		   ,us.DateCertified
		   ,us.CreatedBy
		   ,us.UpdatedBy

		   ,pp.PaymentId
		   ,pp.StudentId
		   ,pp.TotalAmount
		   ,pp.Payment [PaymentAmount]
		   ,pp.Balance

		   ,sso.SessionOneId
		   ,sso.StudentId
		   ,sso.SessionDate
		   ,sso.Schedule
		   ,sso.Shuttle
		   ,sso.SessionLocation
		   ,sso.Attended
		   ,sso.BranchId

		   ,sstw.SessionTwoId
		   ,sstw.StudentId
		   ,sstw.SessionDate
		   ,sstw.Schedule
		   ,sstw.Shuttle
		   ,sstw.SessionLocation
		   ,sstw.Attended
		   ,sstw.BranchId

		   ,ssth.SessionThreeId
		   ,ssth.StudentId
		   ,ssth.SessionDate
		   ,ssth.Schedule
		   ,ssth.Shuttle
		   ,ssth.SessionLocation
		   ,ssth.Attended
		   ,ssth.BranchId

	FROM users.Student AS us
			INNER JOIN lookups.StudentStatus AS ls ON ls.StudentStatusId = us.StudentStatusId
			INNER JOIN lookups.ACESStatus AS la ON la.ACESStatusId = us.ACESStatusId
			INNER JOIN lookups.TDCStatus AS lt ON lt.TDCStatusId = us.TDCStatusId
			LEFT JOIN payments.Payment AS pp ON pp.StudentId = us.StudentId
			LEFT JOIN [sessions].SessionOne AS sso ON sso.StudentId = us.StudentId
			LEFT JOIN [sessions].SessionTwo AS sstw ON sstw.StudentId = us.StudentId
			LEFT JOIN [sessions].SessionThree AS ssth ON ssth.StudentId = us.StudentId
	WHERE us.StudentId = @StudentId;
END
GO;
